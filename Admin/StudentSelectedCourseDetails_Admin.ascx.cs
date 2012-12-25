using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data.Sql;

public partial class Student_StudentSelectedCourseDetails : System.Web.UI.UserControl
{
    DBCon myCon = new DBCon();
    String Current_Student_ID;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["StudentID"] != null)
        {
            Current_Student_ID = Session["StudentID"].ToString();
            string query = "select A.ComCod,TeacherID,CourseTitle,CourseNo from tblStudentCourseMap as A,tblCourses as B where StudentID = '" + Current_Student_ID + "' and A.ComCod = B.ComCod and DaySession = '" + this.ID.ToString() + "'";
            myCon.ConOpen();
            SqlDataReader presentCourses = myCon.ExecuteReader(query);
            if (presentCourses.Read())
            {

                txtSelectedComCod.Text = Convert.ToString(presentCourses.GetSqlDecimal(0));
                txtSelectedTutor.Text = presentCourses.GetString(1);
                txtSelectedTitle.Text = presentCourses.GetString(2);
                txtSelectedCourseNo.Text = presentCourses.GetString(3);
            }
            else
            {
                txtSelectedComCod.Text = txtSelectedTutor.Text = txtSelectedTitle.Text = txtSelectedCourseNo.Text = "";
            }
            myCon.ConClose();
            Set_Visibiltiy();
        }
    }
    public void Set_Visibiltiy()
    {
        txtSelectedComCod.Visible =
        txtSelectedCourseNo.Visible =
        txtSelectedTitle .Visible =
        txtSelectedTutor.Visible =
        Label1.Visible = Label2.Visible = Label3.Visible = Label4.Visible =
            (txtSelectedComCod.Text != "");
        Label5.Visible = (txtSelectedComCod.Text == "");
    }
}