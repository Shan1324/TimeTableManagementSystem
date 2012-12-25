using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Sql;
using System.Data.SqlClient;

public partial class Admin_AdminHome : System.Web.UI.Page
{
    DBCon myCon = new DBCon();
    bool showUserDet = false;
    string Current_User_ID;
    protected void Page_Load(object sender, EventArgs e)
    {
        Session["UserId"] = "admin1";
        if (Session["UserId"] == null)
        {
            Response.Write("<script LANGUAGE='JavaScript' >alert('Session timed out, please re-login');document.location='" + ResolveClientUrl("~/UserLogin.aspx") + "';</script>");
        }
        else
        {
            if (!IsPostBack)
            {
                ddlDepartment.Visible = ddlSemester.Visible = false;
            }
            Current_User_ID = Session["UserId"].ToString();
        }
    }
    protected void btnSignOut_Click(object sender, EventArgs e)
    {
        Session["UserId"] = null;
        Response.Redirect("~/UserLogin.aspx");
    }
    protected void ddlUserType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlUserType.SelectedIndex > 0 && ddlUserType.SelectedIndex < 3)
        {
            string query = "select distinct Department from tblDepartment";
            myCon.ConOpen();
            SqlDataReader depList = myCon.ExecuteReader(query);
            ddlDepartment.DataSource = depList;
            ddlDepartment.DataTextField = "Department";
            ddlDepartment.DataBind();
            myCon.ConClose();
            ddlDepartment.Items.Add(" --- Department --- ");
            ddlDepartment.SelectedIndex = ddlDepartment.Items.Count - 1;
            ddlDepartment.Visible = true;

            grdSelectedUserDet.DataSource = lstUserList.DataSource = null;
            lstUserList.DataBind();
            grdSelectedUserDet.DataBind();

            if (ddlUserType.SelectedValue == "Student")
            {
                ddlSemester.Visible = true;
            }
            else
            {
                ddlSemester.Visible = false;
            }
            btnGo.Visible = true;
            pnlApprove.Visible = false;
            pnlDetails.Visible = false;
        }
        else
        {
            if (ddlUserType.SelectedIndex == 4)
            {
                string query = "select ComCod,DaySession,TeacherID,Count(*) as Count_Student from tblStudentCourseMap group by ComCod,DaySession,TeacherID";
                myCon.ConOpen();
                SqlDataReader reader = myCon.ExecuteReader(query);
                grdSelectedUserDet.DataSource = reader;
                grdSelectedUserDet.DataBind();
                myCon.ConClose();

                lblID.Text = "User Preference ";
                pnlDetails.Visible = true;
            }
        }
    }
    private void Load_LstUsers()
    {
        string subQuery = "select ID from tblUsers where Type = '" + ddlUserType.SelectedValue + "'";        
        if (ddlUserType.SelectedValue == "Student")
        {
            subQuery = "select StudentID from tblStudentSemMap where Semester = '" + ddlSemester.SelectedValue + "' and Department = '" + ddlDepartment.SelectedValue + "'";
        }
        else
        {
            if (ddlUserType.SelectedValue == "Teacher")
            {
                subQuery = "select TeacherID from tblCourseTeacherMap where ComCod in(select ComCod from tblDepartment where Department = '" + ddlDepartment.SelectedValue + "')";
            }
        }
        string query = "select ID from tblApprovalStatus where Status in ('Rejected','Requested Approval') and ID in (" + subQuery + ")";
        myCon.ConOpen();
        SqlDataReader Reader = myCon.ExecuteReader(query);
        lstUserList.DataSource = Reader;
        lstUserList.DataBind();
        lstUserList.Visible = true;
        myCon.ConClose();
        pnlApprove.Visible = false;
        pnlDetails.Visible = false;


    }
    protected void lblSelectedUser_Click(object sender, EventArgs e)
    {
        string query;
        LinkButton btn = (LinkButton)sender;
        if (ddlUserType.SelectedItem.Text == "Teacher")
        {
            query = "select ComCod,Section from tblCourseTeacherMap where TeacherID = '" + btn.Text + "'";
            myCon.ConOpen();
            SqlDataReader reader = myCon.ExecuteReader(query);
            grdSelectedUserDet.DataSource = reader;
            grdSelectedUserDet.DataBind();
            myCon.ConClose();
            pnlApprove.Visible = true;
            pnlDetails.Visible = true;
            lblID.Text = btn.Text;
        }
        else
        {
            if (ddlUserType.SelectedItem.Text == "Student")
            {
                query = "select ComCod,DaySession,TeacherID from tblStudentCourseMap where StudentID = '" + btn.Text + "'";
                myCon.ConOpen();
                SqlDataReader reader = myCon.ExecuteReader(query);
                grdSelectedUserDet.DataSource = reader;
                grdSelectedUserDet.DataBind();
                myCon.ConClose();
                pnlApprove.Visible = true;
                pnlDetails.Visible = true;
                lblID.Text = btn.Text;
            }
        }   
    }
    protected void btnGo_Click(object sender, EventArgs e)
    {
        Load_LstUsers();
    }
    protected void btnApply_Click(object sender, EventArgs e)
    {
        if (ddlRequestService.SelectedValue == "Approve")
        {
            string query = "update tblApprovalStatus set Status = 'Approved', Message = '" + txtMessage.Text + "' where ID = '" + lblID.Text + "'";
            myCon.ExecuteNonQuery(query);
            Load_LstUsers();
        }
        else
        {
            if (ddlRequestService.SelectedValue == "Reject")
            {
                string query = "update tblApprovalStatus set Status = 'Rejected', Message = '" + txtMessage.Text + "' where ID = '" + lblID.Text + "'";
                myCon.ExecuteNonQuery(query);
                Load_LstUsers();
            }
        }      
    }
}