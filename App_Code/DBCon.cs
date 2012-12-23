using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
/// <summary>
/// Required operations to be done on DB
/// </summary>
public class DBCon
{
    string strCon;
    SqlConnection myCon;
    public DBCon(string DB = "timetablemanagementsystem", string server = "localhost", string UID = "sa", string PWD = "root123")
	{
		//
		// TODO: Add constructor logic here
		//
        strCon = string.Format("Server=.\\SQLExpress;Database=" + DB + ";Trusted_Connection=Yes;");
        myCon = new SqlConnection(strCon);
	}
    public void InitiateCon()
    {
        myCon = new SqlConnection(strCon);
        try
        {
            myCon.Open();           
        }
        catch (SqlException ex)
        {
            throw ex;
        }
    }
    public Int32 ExecuteNonQuery(string SqlCommand)
    {
        SqlCommand sqlCommand = new SqlCommand(SqlCommand, myCon);
        try
        {
            sqlCommand.Connection.Open();
            Int32 retCode = sqlCommand.ExecuteNonQuery();
            sqlCommand.Connection.Close();
            return retCode;
            
        }
        catch (SqlException ex)
        {
            sqlCommand.Connection.Close();
            throw ex;
        }
    }
    public int ExecuteScalarInt(string SqlCommand)
    {
        SqlCommand sqlCommand = new SqlCommand(SqlCommand, myCon);
        try
        {
            sqlCommand.Connection.Open();
            int retcode = (int)sqlCommand.ExecuteScalar();
            sqlCommand.Connection.Close();
            return retcode;
           
        }
        catch (SqlException ex)
        {
            sqlCommand.Connection.Close();
            throw ex;
        }
    }
    public void ConOpen()
    {
        myCon.Open();
    }
    public void ConClose()
    {
        myCon.Close();
    }
    public SqlDataReader ExecuteReader(string SqlCommand)
    {
        SqlCommand sqlCommand = new SqlCommand(SqlCommand, myCon);
        try
        {            
            SqlDataReader myReader = sqlCommand.ExecuteReader();            
            return myReader;
        }
        catch (SqlException ex)
        {
            sqlCommand.Connection.Close();
            throw ex;
        }
    }
    public SqlCommand MakeSqlCommand(string SqlCommand)
    {
        SqlCommand Command = new SqlCommand(SqlCommand, myCon);
        return Command;
    }
}