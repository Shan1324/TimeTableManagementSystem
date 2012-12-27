using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Sql;
using System.Data.SqlClient;

public partial class Home : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }     
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        string userLoginQuery = "select Type from tblUsers where ID = '" + txtID.Text + "' and Password = '" + txtPWD.Text + "'";
        DBCon dbConnection = new DBCon();
        dbConnection.ConOpen();
        SqlDataReader typeReader = dbConnection.ExecuteReader(userLoginQuery);
        
        if (typeReader.Read())
        {
            Session["UserId"] = txtID.Text;
            string userType = typeReader.GetString(0);
            dbConnection.ConClose();
            switch (userType)
            {
                case "TEACHER":
                    Response.Redirect("~/Teacher/TeacherHome.aspx");
                    break;
                case "STUDENT":
                     Response.Redirect("~/Student/StudentHome.aspx");
                    break;
                case "ADMIN":
                    Response.Redirect("~/Admin/AdminHome.aspx");
                    break;
            }
        }
        else
        {
            lblLoginStatus.Text = "Invalid Username/ Password";
        }
    }
    
}