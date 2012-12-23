using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Student_StudentSelectedCourseDetails : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Set_Visibiltiy();
    }
    public void Set_Visibiltiy()
    {
        btnRemoveSelectedCourse.Visible =
        txtSelectedComCod.Visible =
        txtSelectedCourseNo.Visible =
        txtSelectedTitle .Visible =
        txtSelectedTutor.Visible =
        Label1.Visible = Label2.Visible = Label3.Visible = Label4.Visible =
            (txtSelectedComCod.Text != "");
        Label5.Visible = (txtSelectedComCod.Text == "");
    }
}