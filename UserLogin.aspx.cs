using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

public partial class Home : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }     
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        string userLoginQuery = "select Type from timetablemanagementsystem.tblUsers where ID = '" + txtID.Text + "' and Password = '" + txtPWD.Text + "'";
        DBCon dbConnection = new DBCon();
        dbConnection.ConOpen();
        MySqlDataReader typeReader = dbConnection.ExecuteReader(userLoginQuery);
        
        if (typeReader.Read())
        {
            string userType = typeReader.GetString("Type");
            dbConnection.ConClose();
            switch (userType)
            {
                case "TEACHER":
                    Response.Redirect("~/Teacher/TeacherHome.aspx");
                    break;
                case "STUDENT":
                     Response.Redirect("~/Student/StudentHome.aspx");
                    break;
            }
        }
        else
        {
            lblLoginStatus.Text = "Invalid Username/ Password";
        }
    }
    
}