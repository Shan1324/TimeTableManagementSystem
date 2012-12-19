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
        Session["UserId"] = "teach1";
        if (Session["UserId"] == null)
        {
            Response.Write("<script LANGUAGE='JavaScript' >alert('Session timed out, please re-login');document.location='" + ResolveClientUrl("~/UserLogin.aspx") + "';</script>");
        }
        else
        {
            Current_User_ID = Session["UserId"].ToString();
            if (!IsPostBack)
            {
               
                myCon.ConOpen();
                queryString = "Select ComCod, CourseNo, CourseTitle from timetablemanagementsystem.tblcourses where ComCod not in ( select ComCod from timetablemanagementsystem.tblcourseteachermap where TeacherID = '" + Current_User_ID +"')";
                queryCommand = myCon.MakeSqlCommand(queryString);
                sqlDA = new MySqlDataAdapter(queryCommand);
                System.Data.DataSet myDS = new System.Data.DataSet();

                sqlDA.Fill(myDS);

                //myReader = myCon.ExecuteReader(queryString);
                //grdCourses.DataSource = myReader;
                grdCourses.DataSource = myDS;
                grdCourses.DataBind();
                btnAddCourses.Visible = (grdCourses.Rows.Count != 0); 
                myDS.Dispose();
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
        btnAddCourses.Visible = grdCourses.Visible;

    }
    protected void btnListDown_Click(object sender, EventArgs e)
    {
        String queryString;
        queryString = "Select ComCod, CourseNo, CourseTitle from timetablemanagementsystem.tblcourses";
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

        queryString += " and ComCod not in ( select ComCod from timetablemanagementsystem.tblcourseteachermap where TeacherID = '" + Current_User_ID +"')";

        queryCommand = myCon.MakeSqlCommand(queryString);
        sqlDA = new MySqlDataAdapter(queryCommand);
        System.Data.DataSet myDS = new System.Data.DataSet();
        sqlDA.Fill(myDS);
        grdCourses.DataSource = myDS;
        grdCourses.DataBind();
        btnAddCourses.Visible = (grdCourses.Rows.Count != 0);

        myCon.ConClose();

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
    }
    protected void grdCourses_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        myCon.ConOpen();
        queryString = "Select ComCod, CourseNo, CourseTitle from timetablemanagementsystem.tblcourses";
        queryCommand = myCon.MakeSqlCommand(queryString);
        sqlDA = new MySqlDataAdapter(queryCommand);
        System.Data.DataSet myDS = new System.Data.DataSet();
        sqlDA.Fill(myDS);

        //myReader = myCon.ExecuteReader(queryString);
        //grdCourses.DataSource = myReader;
        grdCourses.DataSource = myDS;
        grdCourses.DataBind();
        myDS.Dispose();
        myCon.ConClose();
        grdCourses.PageIndex = e.NewPageIndex;
        grdCourses.DataBind();
    }
}
