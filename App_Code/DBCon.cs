using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

/// <summary>
/// Required operations to be done on DB
/// </summary>
public class DBCon
{
    string strCon;
    MySqlConnection myCon;
	public DBCon(string DB = "timetablemanagementsystem", string server = "localhost",string UID = "root", string PWD = "root123" )
	{
		//
		// TODO: Add constructor logic here
		//
        strCon = string.Format("Database=" + DB + ";Server=" + server + ";UID=" + UID + ";PWD=" + PWD + ";");
        myCon = new MySqlConnection(strCon);
	}
    public void InitiateCon()
    {
        myCon = new MySqlConnection(strCon);
        try
        {
            myCon.Open();           
        }
        catch (MySqlException ex)
        {
            throw ex;
        }
    }
    public Int32 ExecuteNonQuery(string SqlCommand)
    {
        MySqlCommand sqlCommand = new MySqlCommand(SqlCommand, myCon);
        try
        {
            sqlCommand.Connection.Open();
            Int32 retCode = sqlCommand.ExecuteNonQuery();
            sqlCommand.Connection.Close();
            return retCode;
            
        }
        catch (MySqlException ex)
        {
            sqlCommand.Connection.Close();
            throw ex;
        }
    }
    public int ExecuteScalarInt(string SqlCommand)
    {
        MySqlCommand sqlCommand = new MySqlCommand(SqlCommand, myCon);
        try
        {
            sqlCommand.Connection.Open();
            //Int32 retCode = (Int32)sqlCommand.ExecuteScalar();
            Int64 retCode = (Int64)sqlCommand.ExecuteScalar();
            sqlCommand.Connection.Close();
            return (int)retCode;
            

        }
        catch (MySqlException ex)
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
    public MySqlDataReader ExecuteReader(string SqlCommand)
    {
        MySqlCommand sqlCommand = new MySqlCommand(SqlCommand, myCon);
        try
        {            
            MySqlDataReader myReader = sqlCommand.ExecuteReader();            
            return myReader;
        }
        catch (MySqlException ex)
        {
            sqlCommand.Connection.Close();
            throw ex;
        }
    }
    public MySqlCommand MakeSqlCommand(string SqlCommand)
    {
        MySqlCommand Command = new MySqlCommand(SqlCommand, myCon);
        return Command;
    }
}