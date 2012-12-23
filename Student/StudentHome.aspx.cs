using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data.Sql;

public partial class Student_StdentHome : System.Web.UI.Page
{
    String Current_User_ID;
    DBCon myCon = new DBCon();
    String Dep;
    int Sem;

    protected void Page_Load(object sender, EventArgs e)
    {
        Session["UserId"] = "stud1";
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
        if (txtComCode.Text != "" && ddlTutor.SelectedValue!= "")
        {
            string query = "select count(*) from tblStudentCourseMap where StudentID = '" + Current_User_ID + "' and DaySession = '" + ddlDay.SelectedValue.ToString() + ddlHour.SelectedValue.ToString() + "'";
            if (myCon.ExecuteScalarInt(query) > 0)
            {
                query = "update tblStudentCourseMap set ComCod = '" + txtComCode.Text + "', TeacherID ='" + ddlTutor.SelectedValue.ToString() + "' where StudentID ='" + Current_User_ID + "' and DaySession = '" + ddlDay.SelectedValue.ToString() + ddlHour.SelectedValue.ToString() + "'";
                myCon.ExecuteNonQuery(query);
            }
            else
            {
                query = "insert into tblStudentCourseMap(ComCod,TeacherID,StudentID,DaySession) values ('" + txtComCode.Text + "', '" + ddlTutor.SelectedValue.ToString() + "','" + Current_User_ID + "','" + ddlDay.SelectedValue.ToString() + ddlHour.SelectedValue.ToString() + "')";
                myCon.ExecuteNonQuery(query);
            }
            Make_Dirty_Approval_Status();
            Response.Redirect(Request.RawUrl);
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
}