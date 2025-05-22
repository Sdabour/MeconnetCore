using System;
using System.Data.SqlTypes;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.IO;
namespace SharpVision.Base.BaseDataBase
{
    /// <summary>
    /// Summary description for DbConnection.
    /// </summary>
    public class BaseOLEDb
    {  
      OleDbConnection _OleDbConnection;
        string _ConStr;
        public BaseOLEDb(string strCon)
        {
            _ConStr = strCon;
            _OleDbConnection = new OleDbConnection(_ConStr);
            
        }
        public int InsertIdentityTable(string strSql)
        {
            string strEx = "";
            int intReturned = 0;
            string strSqlIdentitity;
            //connection.Open();
            using (OleDbConnection connection = new OleDbConnection(_ConStr))
            {
                while (intReturned == 0)
                {
                    try
                    {
                        connection.Open();
                        OleDbCommand objCommand = new OleDbCommand(strSql, connection);
                        objCommand.CommandTimeout = 99999999;
                        objCommand.ExecuteNonQuery();
                        strSqlIdentitity = "select @@identity as LastInserted ";
                        objCommand = new OleDbCommand(strSqlIdentitity, connection);
                        object objTemp = objCommand.ExecuteScalar();
                        if (objTemp != null)
                            intReturned = int.Parse(objTemp.ToString());

                        connection.Close();
                    }
                    catch (Exception Ex)
                    {

                    }


                }
            }
            return intReturned;

        }
        public bool ExecuteNonQuery(string strSql ) //Add, Edit, Delete
        {
            string strEx = "";

            //connection.Open();
            bool blReturned = false;
            try
            {
                using (OleDbConnection connection = new OleDbConnection(_ConStr))
                {
                    connection.Open();
                    OleDbCommand objCommand = new OleDbCommand(strSql, connection);
                    objCommand.CommandTimeout = 99999999;
                    objCommand.ExecuteNonQuery();
                    connection.Close();
                }
                return true;
            }
            catch
            {                
                return blReturned;
            }



        }
        public bool ExecuteNonQuery(string[] arrStr) //Add, Edit, Delete
        {
            string strEx = "";

            //connection.Open();
            bool blReturned = false;
            try
            {
                using (OleDbConnection connection = new OleDbConnection(_OleDbConnection.ConnectionString))
                {
                    connection.Open();
                    foreach (string strSql in arrStr)
                    {
                        OleDbCommand objCommand = new OleDbCommand(strSql, connection);

                        objCommand.CommandTimeout = 99999999;
                        try
                        {

                            objCommand.ExecuteNonQuery();
                        }
                        catch (Exception Ex)
                        { }
                    }
                    connection.Close();
                }
                return true;
            }
            catch
            {


                return blReturned;
            }



        }
        public DataTable ReturnDatatable(string strSql)
        {
            string str = "";
            try
            {

                //SqlConnection connection = new SqlConnection(sqlConnection.ConnectionString);
                if (_OleDbConnection.State == ConnectionState.Closed)
                    _OleDbConnection.Open();
                OleDbDataAdapter objAdapter = new OleDbDataAdapter(strSql, _OleDbConnection);
                objAdapter.SelectCommand.CommandTimeout = 99999999;
                DataTable objDatatable = new DataTable();
                objAdapter.Fill(objDatatable);
                return (objDatatable);
            }
            catch (SqlException ex)
            {
                str = ex.Message;

                return null;
            }
        }
        public bool TestCon()
        {

            OleDbConnection objCon = new OleDbConnection(_ConStr);
            try
            {
                objCon.Open();
                objCon.Close();
            }
            catch
            {
                return false;
            }
            return true;
        }
    }   
}
