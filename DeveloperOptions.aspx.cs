using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Sql;
using System.Data.SqlClient;

public partial class DeveloperOptions : System.Web.UI.Page
{
    DBCon myCon = new DBCon();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnPerform_Click(object sender, EventArgs e)
    {
        if (ddlOperation.SelectedItem.Text == "Insert")
        {
            string query = "insert into " + ddlTableName.SelectedValue + " values ('" + txtVal1.Text + "','" + txtVal2.Text + "','" + txtVal3.Text + "'";
            if (txtVal4.Text != "")
            {
                query += ",'" + txtVal4.Text + "'";
            }
            query += ")";
            myCon.ExecuteNonQuery(query);
        }
        else
        {
            if (ddlOperation.SelectedItem.Text == "View")
            {
                string query = "select * from " + ddlTableName.SelectedValue;
                myCon.ConOpen();
                SqlDataReader reader = myCon.ExecuteReader(query);
                grdDetails.DataSource = reader;
                grdDetails.DataBind();
                myCon.ConClose();
            }
        }
    }
}