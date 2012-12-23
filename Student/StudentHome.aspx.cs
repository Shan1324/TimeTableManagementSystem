using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Student_StdentHome : System.Web.UI.Page
{
    String Current_User_ID;
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
                Current_User_ID = Session["UserID"].ToString();
                Determine_Sem_Dep();
            }
        }
      
    }

    private void Determine_Sem_Dep()
    {
        string query = "select Semester,Department from tblStudentSemMap where ID = '" + Current_User_ID + "'";
    }
}