using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data.Sql;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html;

public partial class Student_StdentHome : System.Web.UI.Page
{
    String Current_User_ID;
    DBCon myCon = new DBCon();
    String Dep;
    int Sem;

    protected void Page_Load(object sender, EventArgs e)
    {
        //Session["UserId"] = "stud1";
        if (Session["UserId"] == null)
        {
            Response.Write("<script LANGUAGE='JavaScript' >alert('Session timed out, please re-login');document.location='" + ResolveClientUrl("~/UserLogin.aspx") + "';</script>");
        }
        else
        {
            Current_User_ID = Session["UserId"].ToString();
            if (!IsPostBack)
            {
                Current_User_ID = Session["UserID"].ToString();
                Determine_Sem_Dep();
                Populate_Insert_Items();
                //Populate_Inserted_Items();
            }
            
        }
        Get_Approval_Status();
    }

    private void Populate_Insert_Items()
    {
        string query = "select CourseTitle,ComCod from tblCourses where ComCod in (select ComCod from tblDepartment where Semester ='" + Sem + "' and Department ='" + Dep + "')";
        myCon.ConOpen();
        SqlDataReader Courses = myCon.ExecuteReader(query);
        ddlCourseTitle.DataSource = Courses;
        ddlCourseTitle.DataTextField = "CourseTitle";
        ddlCourseTitle.DataValueField = "ComCod";
        ddlCourseTitle.DataBind();
        myCon.ConClose();
        ddlCourseTitle.Items.Add("--- Select Course ---");
        ddlCourseTitle.SelectedIndex = ddlCourseTitle.Items.Count - 1;
    }

    private void Determine_Sem_Dep()
    {
        string query = "select Semester,Department from tblStudentSemMap where StudentID = '" + Current_User_ID + "'";
        myCon.ConOpen();
        SqlDataReader sem_dep = myCon.ExecuteReader(query);
        if (sem_dep.Read())
        {
            Sem = Convert.ToInt32(sem_dep.GetValue(0));
            Dep = sem_dep.GetString(1);
            myCon.ConClose();
        }
        else
        {
            myCon.ConClose();
            Response.Write("<script LANGUAGE='JavaScript' >alert('Unable to determine Semester/Department for student.');document.location='" + ResolveClientUrl("~/UserLogin.aspx") + "';</script>");
        }
    }
    protected void ddlCourseTitle_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlCourseTitle.SelectedIndex < (ddlCourseTitle.Items.Count - 1))
        {
            string query = "select TeacherID from tblCourseTeacherMap where ComCod = '" + ddlCourseTitle.SelectedValue.ToString() + "' and TeacherID in (Select ID from tblApprovalStatus where Status = 'Approved') and TeacherID not in (Select TeacherID from tblStudentCourseMap group by TeacherID,ComCod having Count(*) > 60 and ComCod = '" + ddlCourseTitle.SelectedValue.ToString() +"')";
            myCon.ConOpen();
            SqlDataReader teacher_list = myCon.ExecuteReader(query);
            ddlTutor.DataSource = teacher_list;
            ddlTutor.DataTextField = "TeacherID";
            ddlTutor.DataValueField = "TeacherID";
            ddlTutor.DataBind();
            myCon.ConClose();

            query = "select ComCod,CourseNo from tblCourses where ComCod = '" + ddlCourseTitle.SelectedValue.ToString() + "'";
            myCon.ConOpen();
            teacher_list = myCon.ExecuteReader(query);
            if (teacher_list.Read())
            {
                if (!teacher_list.IsDBNull(0))
                {
                    txtComCode.Text = Convert.ToString(teacher_list.GetSqlDecimal(0));
                    if (!teacher_list.IsDBNull(1))
                    {
                        txtCouresNo.Text = teacher_list.GetString(1);
                    }
                }
            }
        }
    }
    protected void btnInsert_Click(object sender, EventArgs e)
    {
        bool isValidOperation = true;
        string insertQuery = "";
        SqlDataReader listDaySession;
        if (txtComCode.Text != "" && ddlTutor.SelectedValue != "")
        {
            string DaySession;
            DBCon myCon2 = new DBCon();
            string query = "select DaySession from tblCourseTeacherMap where ComCod = '" + ddlCourseTitle.SelectedValue + "' and TeacherID = '" + ddlTutor.SelectedValue + "'";
            if (ddlOperation.SelectedValue == "Insert")
            {
                myCon.ConOpen();
                listDaySession = myCon.ExecuteReader(query);
                while (listDaySession.Read() && isValidOperation)
                {
                    DaySession = listDaySession.GetString(0);
                    string checkQuery = "select count(*) from tblStudentCourseMap where DaySession = '" + DaySession + "'";
                    int Occurence = myCon2.ExecuteScalarInt(checkQuery);
                    if (Occurence > 0)
                    {
                        Response.Write("<script LANGUAGE='JavaScript' >alert('" + DaySession + " has another entry, aborting operation. Please remove entry and try again.');</script>");
                        isValidOperation = false;
                        break;
                    }
                }
                myCon.ConClose();
            }

            myCon.ConOpen();            
            query = "select DaySession from tblCourseTeacherMap where ComCod = '" + ddlCourseTitle.SelectedValue + "' and TeacherID = '" + ddlTutor.SelectedValue + "'";
            listDaySession = myCon.ExecuteReader(query);
            while (listDaySession.Read() && isValidOperation)
            {
                DaySession = listDaySession.GetString(0);
                if (ddlOperation.SelectedValue == "Insert")
                {
                    insertQuery = "insert into tblStudentCourseMap(StudentID,ComCod,DaySession,TeacherID) values ('" + Current_User_ID + "','" + txtComCode.Text + "','" + DaySession + "','" + ddlTutor.SelectedValue + "')";
                }
                else
                {
                    if (ddlOperation.SelectedValue == "Remove")
                    {                       
                        insertQuery = "Delete from tblStudentCourseMap where StudentID = '" + Current_User_ID + "' and ComCod = '" + txtComCode.Text + "' and DaySession = '" + DaySession + "' and TeacherID = '" + ddlTutor.SelectedValue + "'";                        
                    }
                }
                myCon2.ExecuteNonQuery(insertQuery);
            }
            myCon.ConClose();
            if (isValidOperation)
            {
                Make_Dirty_Approval_Status();
                Response.Redirect(Request.RawUrl);
            }
        }
    }
    private void Get_Approval_Status()
    {
        string query = "select Status,Message from tblApprovalStatus where ID = '" + Current_User_ID + "'";
        myCon.ConOpen();
        SqlDataReader ApprovalStat = myCon.ExecuteReader(query);
        if (ApprovalStat.Read())
        {

            lblApprovalStatus.Text = ApprovalStat.GetString(0);
            if (ApprovalStat.IsDBNull(1))
            {
                txtMessageBox.Text = "No Messages from Admin";
            }
            else
            {
                txtMessageBox.Text = ApprovalStat.GetString(1);
            }            
        }
        else
        {
            lblApprovalStatus.Text = "No requests made";
        }
        myCon.ConClose();
        if (lblApprovalStatus.Text == "Approved")
        {
            btnPrint.Visible = true;
        }
        else
        {
            btnPrint.Visible = false;
        }
    }
    private void Make_Dirty_Approval_Status()
    {
        string query = "select Count(*) from tblApprovalStatus where ID = '" + Current_User_ID + "'";
        if (myCon.ExecuteScalarInt(query) > 0)
        {
            query = "update tblApprovalStatus set Status = 'Pending Approval' where ID = '" + Current_User_ID + "'";
            myCon.ExecuteNonQuery(query);
        }
        else
        {
            query = "insert into tblApprovalStatus(Status,ID) values ('Pending Approval', '" + Current_User_ID + "')";
            myCon.ExecuteNonQuery(query);
        }
    }
    protected void btnSendForApproval_Click(object sender, EventArgs e)
    {
        string query = "select Count(*) from tblApprovalStatus where ID = '" + Current_User_ID + "'";
        if (myCon.ExecuteScalarInt(query) > 0)
        {
            query = "update tblApprovalStatus set Status ='Requested Approval' where ID = '" + Current_User_ID + "'";
            myCon.ExecuteNonQuery(query);
        }
        else
        {
            query = "insert into tblApprovalStatus(Status,ID) values ('Requested Approval', '" + Current_User_ID + "')";
            myCon.ExecuteNonQuery(query);
        }
        Get_Approval_Status();
    }
    protected void btnSignOut_Click(object sender, EventArgs e)
    {
        Session["UserId"] = null;
        Response.Redirect("~/UserLogin.aspx");
    }
    protected void btnPrint_Click(object sender, EventArgs e)
    {
       Prepare_Print();
    }
    protected void Prepare_Print()
    {
        String[] weekDays = new String[] { " ","Sun", "Mon", "Tue", "Wed", "Thu" };
        int[] sessions = new int[] {0,1,2,3,4,5,6,7,8,9};
        PdfPTable tblSchedule = new PdfPTable(10);  
        PdfPRow[] tempRow = new PdfPRow[6];
        PdfPCell[][] tempCell = new PdfPCell[6][];
        int rowIndex = 0;
        int cellIndex = 0;
        Paragraph subject = new Paragraph();
        Paragraph teacher = new Paragraph();
        Paragraph lunch = new Paragraph();
        Paragraph dayPara = new Paragraph();
        Paragraph sessionPara = new Paragraph();
        Paragraph teacherPara = new Paragraph();

        Font lunch_font = new Font();
        Font day_session_para = new Font();
        Font session_font = new Font();
        Font teacher_font = new Font();

        session_font.Size = 10;
        teacher_font.SetStyle("Italics");
        teacher_font.Size = 7;

        lunch_font.SetColor(153, 153, 255);
        lunch_font.SetStyle("italics");
        lunch = new Paragraph("Lunch", lunch_font);

        day_session_para.SetColor(0, 0, 153);

        foreach (String weekDay in weekDays)
        {
            tempCell[rowIndex] = new PdfPCell[10];
            tempRow[rowIndex] = new PdfPRow(tempCell[rowIndex]);
            foreach (int session in sessions)
            {
                if (session == 0 || session == 6)
                {
                    if (session == 0)
                    {
                        dayPara = new Paragraph(weekDays[rowIndex],day_session_para);
                        tempCell[rowIndex][cellIndex] = new PdfPCell(dayPara);                        
                    }
                    else
                        if (weekDay != " ")
                        {
                            tempCell[rowIndex][cellIndex] = new PdfPCell(lunch);                            
                        }
                        else
                        {
                            //tempCell[rowIndex][cellIndex] = new PdfPCell(new Phrase(Convert.ToString(sessions[cellIndex])));
                            dayPara = new Paragraph(Convert.ToString(sessions[cellIndex]), day_session_para);
                            tempCell[rowIndex][cellIndex] = new PdfPCell(dayPara);
                        }
                }
                else
                {
                    if (weekDay == " ")
                    {
                        dayPara = new Paragraph(Convert.ToString(sessions[cellIndex]), day_session_para);
                        tempCell[rowIndex][cellIndex] = new PdfPCell(dayPara);
                        //tempCell[rowIndex][cellIndex] = new PdfPCell(new Phrase(Convert.ToString(sessions[cellIndex])));
                    }
                    else
                    {
                        string query = "select B.CourseTitle,A.TeacherID from tblStudentCourseMap as A,tblCourses as B where A.ComCod = B.ComCod and A.DaySession = '" + weekDay + session + "' and A.StudentID = '" + Current_User_ID + "'";
                        myCon.ConOpen();
                        SqlDataReader sessionDet = myCon.ExecuteReader(query);

                        if (sessionDet.Read())
                            if (!sessionDet.IsDBNull(0))
                            {
                                sessionPara = new Paragraph(sessionDet.GetString(0), session_font);
                                //tempCell[rowIndex][cellIndex] = new PdfPCell(sessionPara);
                                teacherPara = new Paragraph(sessionDet.GetString(1), teacher_font);
                                tempCell[rowIndex][cellIndex] = new PdfPCell(new Phrase(sessionPara));
                                tempCell[rowIndex][cellIndex].Phrase.Add(new Phrase("\n"));
                                tempCell[rowIndex][cellIndex].Phrase.Add(teacherPara);
                                //tempCell[rowIndex][cellIndex] = new PdfPCell(new Phrase(sessionDet.GetString(0) + "\n" + sessionDet.GetString(1)));
                            }
                            else
                            {
                                tempCell[rowIndex][cellIndex] = new PdfPCell(new Phrase(""));
                                //tempCell[rowIndex][cellIndex
                            }
                        else
                            tempCell[rowIndex][cellIndex] = new PdfPCell(new Phrase(""));
                        myCon.ConClose();
                        tempCell[rowIndex][cellIndex].FixedHeight = 75;
                    }
                    
                }
                
                //tempCell[rowIndex][cellIndex].Width = 50;
                cellIndex++;
                //tempRow[rowIndex].Cells.Add(tempCell[cellIndex++, rowIndex]);
            }
            cellIndex = 0;
            //rowIndex++;
            tblSchedule.Rows.Add(tempRow[rowIndex++]);
        }

        Font HeaderFont = new Font();
        Font HeadingFont = new Font();
        HeaderFont.Size = 20;
        HeaderFont.SetStyle(Font.UNDERLINE);
        HeadingFont.Size = 15;
        HeadingFont.SetStyle(Font.UNDERLINE);
        Paragraph HeaderPara = new Paragraph("BITS PILANI, DUBAI OFFCAMPUS - TIMETABLE", HeaderFont);
        Paragraph HeadingPara = new Paragraph("Time Table allotment for " + Current_User_ID + ".",HeadingFont);
        HeaderPara.Alignment = HeadingPara.Alignment = 1;

        Document rptTimetable = new Document(PageSize.A4_LANDSCAPE.Rotate());
        PdfWriter.GetInstance(rptTimetable, new FileStream(Request.PhysicalApplicationPath + "\\" + Current_User_ID + "_timetable.pdf", FileMode.Create));
        rptTimetable.Open();
        rptTimetable.AddCreationDate();
        rptTimetable.AddHeader("BITS PILANI, DUBAI OFFCAMPUS", "TIMETABLE");
        rptTimetable.Add(new Paragraph("\n"));
        rptTimetable.AddTitle("BITS PILANI, DUBAI OFFCAMPUS - TIMETABLE");
        rptTimetable.Add(HeaderPara);
        rptTimetable.Add(HeadingPara);
        rptTimetable.Add(new Paragraph("\n\n"));

        if (rptTimetable != null && tblSchedule != null)
        {
            rptTimetable.Add(tblSchedule);
        }
        rptTimetable.Close();
        Response.Redirect("~\\" + Current_User_ID + "_timetable.pdf");
    }
}