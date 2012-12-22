using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

public partial class Teacher_TeacherHome : System.Web.UI.Page
{
    string Current_User_ID;
    String queryString;
    DBCon myCon = new DBCon();
    MySqlCommand queryCommand;
    MySqlDataAdapter sqlDA;
    protected void Page_Load(object sender, EventArgs e)
    {
        //Session["UserId"] = "teach1";
        if (Session["UserId"] == null)
        {
            Response.Write("<script LANGUAGE='JavaScript' >alert('Session timed out, please re-login');document.location='" + ResolveClientUrl("~/UserLogin.aspx") + "';</script>");
        }
        else
        {
            Current_User_ID = Session["UserId"].ToString();           
            if (!IsPostBack)
            {             
                //populate drop down list
                myCon.ConOpen();
                queryString = "Select distinct Department from timetablemanagementsystem.tblDepartment";
                MySqlDataReader ListDepartment = myCon.ExecuteReader(queryString);
                ddlDepartments.DataSource = ListDepartment;
                ddlDepartments.DataTextField = "Department";
                ddlDepartments.DataBind();
                ddlDepartments.Items.Add("All Departments");
                myCon.ConClose();

                Bind_grdAddedCourses();
                Bind_grdCourses();
            }
        }
      
    }
    private void Bind_grdCourses()
    {
        ////populate courses not added to profile
        //myCon.ConOpen();
        //queryString = "Select ComCod, CourseNo, CourseTitle from timetablemanagementsystem.tblcourses where ComCod not in ( select ComCod from timetablemanagementsystem.tblcourseteachermap where TeacherID = '" + Current_User_ID + "')";
        //queryCommand = myCon.MakeSqlCommand(queryString);
        //sqlDA = new MySqlDataAdapter(queryCommand);
        //System.Data.DataSet myDS = new System.Data.DataSet();

        //sqlDA.Fill(myDS);

        ////myReader = myCon.ExecuteReader(queryString);
        ////grdCourses.DataSource = myReader;
        //grdCourses.DataSource = myDS;
        //grdCourses.DataBind();
        //btnAddCourses.Visible = (grdCourses.Rows.Count != 0);
        //myDS.Dispose();
        //myCon.ConClose();
        String queryString;
        queryString = "Select ComCod, CourseNo, CourseTitle from timetablemanagementsystem.tblcourses where ";
        DBCon myCon = new DBCon();
        myCon.ConOpen();
        if (ddlDepartments.SelectedItem.Text != "All Departments")
        {
            queryString = queryString + " ComCod in (Select ComCod from timetablemanagementsystem.tblDepartment where Department = '" + ddlDepartments.SelectedItem.Text + "'";
            if (ddlSem.SelectedItem.Text != "All Semesters")
            {
                queryString += " and Semester = '" + ddlSem.SelectedItem.Text + "'";
            }
            queryString += ") and ";
        }
        else
        {
            if (ddlSem.SelectedItem.Text != "All Semesters")
            {
                queryString = queryString + " ComCod in (Select ComCod from timetablemanagementsystem.tblDepartment where Semester = '" + ddlSem.SelectedItem.Text + "') and ";
            }
        }

        if (txtSearchString.Text != "")
        {
            queryString +=  ddlSearchItem.SelectedItem.Value + " like '%" + txtSearchString.Text + "%' and ";
        }

        queryString += " ComCod not in ( select ComCod from timetablemanagementsystem.tblcourseteachermap where TeacherID = '" + Current_User_ID + "')";

        queryCommand = myCon.MakeSqlCommand(queryString);
        sqlDA = new MySqlDataAdapter(queryCommand);
        System.Data.DataSet myDS = new System.Data.DataSet();
        sqlDA.Fill(myDS);
        grdCourses.DataSource = myDS;
        grdCourses.DataBind();
        btnAddCourses.Visible = (grdCourses.Rows.Count != 0);

        myCon.ConClose();

    }
    private void Bind_grdAddedCourses()
    {
        //populate courses added to profile
        queryString = "Select A.ComCod as ComCod, A.CourseNo as CourseNo, A.CourseTitle as CourseTitle, B.Section as Section from timetablemanagementsystem.tblcourses as A,timetablemanagementsystem.tblcourseteachermap as B where A.ComCod in ( select ComCod from timetablemanagementsystem.tblcourseteachermap where TeacherID = '" + Current_User_ID + "') and A.ComCod = B.ComCod";
        queryCommand = myCon.MakeSqlCommand(queryString);
        sqlDA = new MySqlDataAdapter(queryCommand);
        System.Data.DataSet myDS = new System.Data.DataSet();

        sqlDA.Fill(myDS);

        //myReader = myCon.ExecuteReader(queryString);
        //grdCourses.DataSource = myReader;
        grdTeachingCourses.DataSource = myDS;
        grdTeachingCourses.DataBind();
        btnRemoveCourse.Visible = (grdTeachingCourses.Rows.Count != 0);
        myDS.Dispose();
        myCon.ConClose();
    }
    protected void btnListDown_Click(object sender, EventArgs e)
    {
        Bind_grdCourses();

    }
    protected void btnCourseView_Click(object sender, EventArgs e)
    {

    }
    protected void grdCourses_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void btnAddCourses_Click(object sender, EventArgs e)
    {
        int startIndex = grdCourses.PageIndex * grdCourses.PageSize;

        for (int i = 0; i < grdCourses.Rows.Count; i++)
        {
            GridViewRow grdSelectedRow = grdCourses.Rows[i];
            String selectedComCod = grdSelectedRow.Cells[1].Text;
            DropDownList selectedSectionList = (DropDownList)grdSelectedRow.FindControl("ddlSection");
            String selectedSection = selectedSectionList.SelectedItem.Value.ToString();
            CheckBox chkSelectedCourse = (CheckBox)grdSelectedRow.FindControl("chkItemSelect");
            if (chkSelectedCourse.Checked)
            {
                string insertQuery = "Insert into timetablemanagementsystem.tblcourseteachermap(TeacherID,ComCod,Section) values ('" + Current_User_ID + "','" + selectedComCod + "','" + selectedSection + "')";
                if (myCon.ExecuteNonQuery(insertQuery) <= 0)
                {
                    Response.Write("<script LANGUAGE='JavaScript' >alert('DB Updation failed, changes might be lost');</script>");
       
                }
               
            }
        }
        Bind_grdAddedCourses();
        Bind_grdCourses();
    }
    protected void grdCourses_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        //populate courses not added to profile
        Bind_grdCourses();
        grdCourses.PageIndex = e.NewPageIndex;
        grdCourses.DataBind();
    }
    protected void grdTeachingCourses_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        //populate courses not added to profile
        Bind_grdAddedCourses();
        grdTeachingCourses.PageIndex = e.NewPageIndex;
        grdTeachingCourses.DataBind();
    }
    protected void btnRemoveCourse_Click(object sender, EventArgs e)
    {
        int startIndex = grdTeachingCourses.PageIndex * grdTeachingCourses.PageSize;

        for (int i = 0; i < grdTeachingCourses.Rows.Count; i++)
        {
            GridViewRow grdSelectedRow = grdTeachingCourses.Rows[i];
            String selectedComCod = grdSelectedRow.Cells[1].Text;
            String selectedSection = grdSelectedRow.Cells[4].Text;
            CheckBox chkSelectedCourse = (CheckBox)grdSelectedRow.FindControl("chkItemSelectRemove");
            if (chkSelectedCourse.Checked)
            {
                string insertQuery = "delete from timetablemanagementsystem.tblcourseteachermap where TeacherID ='" + Current_User_ID + "' and ComCod = '" + selectedComCod + "' and Section = '" + selectedSection + "'";
                if (myCon.ExecuteNonQuery(insertQuery) <= 0)
                {
                    Response.Write("<script LANGUAGE='JavaScript' >alert('DB Updation failed, changes might be lost');</script>");

                }
                
            }
        }
        Bind_grdAddedCourses();
        Bind_grdCourses();
    }

    protected void btnSignOut_Click(object sender, EventArgs e)
    {
        Session["UserId"] = null;
        Response.Redirect("~/UserLogin.aspx");
    }
}
