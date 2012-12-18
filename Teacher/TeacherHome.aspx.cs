using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

public partial class Teacher_TeacherHome : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            String queryString;
            DBCon myCon = new DBCon();
            myCon.ConOpen();
            queryString = "Select ComCod, CourseNo, CourseTitle from timetablemanagementsystem.tblcourses";
            MySqlDataReader myReader = myCon.ExecuteReader(queryString);
            grdCourses.DataSource = myReader;
            grdCourses.DataBind();
            myCon.ConClose();

            myCon.ConOpen();
            queryString = "Select distinct Department from timetablemanagementsystem.tblDepartment";
            MySqlDataReader ListDepartment = myCon.ExecuteReader(queryString);
            ddlDepartments.DataSource = ListDepartment;
            ddlDepartments.DataTextField = "Department";
            ddlDepartments.DataBind();
            ddlDepartments.Items.Add("All Departments");
            myCon.ConClose();
        }

    }
    protected void btnListDown_Click(object sender, EventArgs e)
    {
        String queryString;
        queryString= "Select ComCod, CourseNo, CourseTitle from timetablemanagementsystem.tblcourses";
        DBCon myCon = new DBCon();
        myCon.ConOpen();
        if (ddlDepartments.SelectedItem.Text != "All Departments")
        {
            queryString = queryString + " where ComCod in (Select ComCod from timetablemanagementsystem.tblDepartment where Department = '" + ddlDepartments.SelectedItem.Text + "'";
            if (ddlSem.SelectedItem.Text != "All Semesters")
            {
                queryString += " and Semester = '" + ddlSem.SelectedItem.Text + "'";
            }
            queryString += ")";
        }
        else
        {
            if (ddlSem.SelectedItem.Text != "All Semesters")
            {
                queryString = queryString + " where ComCod in (Select ComCod from timetablemanagementsystem.tblDepartment where Semester = '" + ddlSem.SelectedItem.Text + "')";
            }            
        }

        if (txtSearchString.Text != "")
        {
            queryString += " and " + ddlSearchItem.SelectedItem.Value + " like '%" + txtSearchString.Text + "%'";
        }
        
        MySqlDataReader myReader = myCon.ExecuteReader(queryString);
        grdCourses.DataSource = myReader;
        grdCourses.DataBind();

        myCon.ConClose();

    }
    protected void btnCourseView_Click(object sender, EventArgs e)
    {
        
    }
    protected void grdCourses_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}