using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Student_StdentHome : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Determine_Sem_Dep();
        }
    }

    private void Determine_Sem_Dep()
    {
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
       
    }
}