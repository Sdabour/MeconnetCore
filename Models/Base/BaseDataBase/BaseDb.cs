using System;
using System.Data.SqlTypes;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.IO;
using System.Collections.Generic;

namespace SharpVision.Base.BaseDataBase
{
    /// <summary>
    /// Summary description for DbConnection.
    /// </summary>
    /// 

    public class BaseDb
    {


        private sqlConnection _sqlConnection;
        List<string> _ExArr = new List<string>();
        public BaseDb()
        {
        }
        public BaseDb(string strDbServerName, string strDbUserID, string strDbPasswords, string strDbName)
        {
            _sqlConnection = new sqlConnection(strDbServerName, strDbUserID, strDbPasswords, strDbName);

        }
        public BaseDb(string strConn)
        {
            _sqlConnection = new sqlConnection(strConn);

        }
        public SqlConnection Connection
        {
            get
            {
                SqlConnection Conn = new SqlConnection(_sqlConnection.ConnectionString);
                Conn.Open();
                return Conn;
            }
        }
        public sqlConnection sqlConnection
        {
            get
            {
                return _sqlConnection;
            }
            set
            {
                _sqlConnection = value;
            }
        }
        public List<string> ExArr
        {
            get
            {
                if (_ExArr == null)
                    _ExArr = new List<string>();
                return _ExArr;
            }
        }
        public string ExStr
        {
            get
            {
                string Returned = "";
                foreach (string strTemp in ExArr)
                {
                    if (Returned != "")
                        Returned += "\n\t";
                    Returned += strTemp;
                }
                return Returned;
            }
        }
        public bool ExecuteNonQuery(string strSql, SqlConnection connection, SqlTransaction objTrans) //Add, Edit, Delete
        {
            string strEx = "";
            _ExArr = new List<string>();
            try
            {
                //connection.Open();

                SqlCommand objCommand = new SqlCommand(strSql, connection);
                objCommand.CommandTimeout = 99999999;
                objCommand.Transaction = objTrans;
                objCommand.ExecuteNonQuery();
                return true;

            }
            catch (Exception ex)
            {
                strEx = ex.Message;
                _ExArr.Add(strEx);
                return false;
            }
            
        }


        public bool ExecuteNonQuery(string strSql) //Add, Edit, Delete
        {
            string strEx = "";

            //connection.Open();
            bool blReturned = false;
            _ExArr = new List<string>();
            try
            {
                using (SqlConnection connection = new SqlConnection(_sqlConnection.ConnectionString))
                {
                    connection.Open();
                    SqlCommand objCommand = new SqlCommand(strSql, connection);
                    objCommand.CommandTimeout = 99999999;
                    objCommand.ExecuteNonQuery();
                    connection.Close();
                }
                return true;
            }
            catch(SqlException objEx)
            {
                _ExArr.Add(objEx.Message);
               // blReturned = ExecuteNonQuery(strSql, true);


                return blReturned;
            }



        }
        public bool ExecuteNonQuery(string strSql, SqlParameter[] arrParameter) //Add, Edit, Delete
        {
            string strEx = "";

            //connection.Open();
            bool blReturned = false;
           
                using (SqlConnection connection = new SqlConnection(_sqlConnection.ConnectionString))
                {
                    _ExArr = new List<string>();
                    try
                    {
                        connection.Open();
                        SqlCommand objCommand = new SqlCommand(strSql, connection);
                        objCommand.Parameters.AddRange(arrParameter);
                        objCommand.CommandTimeout = 99999999;
                        objCommand.ExecuteNonQuery();
                        connection.Close();

                    }
                    catch (SqlException Ex)
                    {
                        _ExArr.Add(Ex.Message);
                        return false;
                    }


                }
                return true;
            



        }

        public bool ExecuteNonQuery(string[] arrStr) //Add, Edit, Delete
        {
            string strEx = "";

            //connection.Open();
            bool blReturned = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(_sqlConnection.ConnectionString))
                {
                    connection.Open();
                    _ExArr = new List<string>();
                    int x = 0;
                    foreach (string strSql in arrStr)
                    {
                        x++;
                        if (strSql == null || strSql == "")
                            continue;
                        SqlCommand objCommand = new SqlCommand(strSql, connection);

                        objCommand.CommandTimeout = 99999999;
                        try
                        {

                            objCommand.ExecuteNonQuery();
                        }
                        catch (SqlException Ex)
                        {
                            _ExArr.Add(Ex.Message);
                        }
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

        public bool ExecuteNonQuery(List<string> arrStr) //Add, Edit, Delete
        {
            string strEx = "";

            //connection.Open();
            bool blReturned = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(_sqlConnection.ConnectionString))
                {
                    connection.Open();
                    _ExArr = new List<string>();
                    int x = 0;
                    foreach (string strSql in arrStr)
                    {
                        x++;
                        if (strSql == null || strSql == "")
                            continue;
                        SqlCommand objCommand = new SqlCommand(strSql, connection);

                        objCommand.CommandTimeout = 99999999;
                        try
                        {

                            objCommand.ExecuteNonQuery();
                        }
                        catch (SqlException Ex)
                        {
                            _ExArr.Add(Ex.Message);
                        }
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

        public bool ExecuteNonQuery(string[] arrStr, SqlConnection connection, SqlTransaction objTrans) //Add, Edit, Delete
        {
            string strEx = "";

            //connection.Open();
            bool blReturned = false;
            try
            {
                
                    int x = 0;
                    _ExArr = new List<string>();
                    foreach (string strSql in arrStr)
                    {
                        x++;
                        SqlCommand objCommand = new SqlCommand(strSql, connection);
                        objCommand.Transaction = objTrans;
                        objCommand.CommandTimeout = 99999999;
                        try
                        {

                            objCommand.ExecuteNonQuery();
                        }
                        catch (Exception Ex)
                        {
                            _ExArr.Add(Ex.Message);
                            return false;
                        }
                    }
                return true;
            }
            catch
            {


                return blReturned;
            }



        }

        public bool ExecuteNonQueryInTransaction(string[] arrStr) //Add, Edit, Delete
        {
            string strEx = "";

            //connection.Open();
            bool blReturned = false;

            using (SqlConnection connection = new SqlConnection(_sqlConnection.ConnectionString))
            {
                connection.Open();
                SqlTransaction objTrans = connection.BeginTransaction(IsolationLevel.RepeatableRead);
                _ExArr = new List<string>();
                try
                {
                    foreach (string strSql in arrStr)
                    {
                        if (strSql == null || strSql == "")
                            continue;
                        SqlCommand objCommand = new SqlCommand(strSql, connection);
                        
                        objCommand.CommandTimeout = 99999999;
                        objCommand.Transaction = objTrans;


                        objCommand.ExecuteNonQuery();
                    }
                    objTrans.Commit();
                    blReturned = true;
                }
                catch (Exception Ex)
                {
                    _ExArr.Add(Ex.Message);
                    objTrans.Rollback();

                }

                connection.Close();
            }
            return blReturned;




        }
        public bool ExecuteNonQuery(string strSql, bool blSecondTime) //Add, Edit, Delete
        {
            string strEx = "";

            //connection.Open();
            try
            {
                using (SqlConnection connection = new SqlConnection(_sqlConnection.ConnectionString))
                {
                    connection.Open();
                    _ExArr = new List<string>();
                    SqlCommand objCommand = new SqlCommand(strSql, connection);
                    objCommand.CommandTimeout = 99999999;
                    objCommand.ExecuteNonQuery();
                    connection.Close();
                }
                return true;
            }
            catch (Exception Ex)
            {
                _ExArr.Add(Ex.Message);
                return false;
            }



        }
        public void EditFile(string strTableName, string strIDFieldName, string strFieldName, byte[] arrByte, int intID)
        {
            _ExArr = new List<string>();
            try
            {
                using (SqlConnection connection = new SqlConnection(_sqlConnection.ConnectionString))
                {

                    connection.Open();
                    string strSql = "update " + strTableName + " set " + strFieldName + "=@File " +
                        " where " + strIDFieldName + "= @ID";
                    SqlCommand objCommand = new SqlCommand(strSql, connection);
                    SqlParameter objParamter = new SqlParameter("@File", SqlDbType.Binary);
                    objParamter.Value = arrByte;
                    objCommand.Parameters.Add(objParamter);
                    objParamter = new SqlParameter("@ID", SqlDbType.BigInt);
                    objParamter.Value = intID;
                    objCommand.Parameters.Add(objParamter);
                    objCommand.CommandTimeout = 99999999;
                    objCommand.ExecuteNonQuery();
                    connection.Close();

                }
            }
            catch (SqlException objEx)
            {
                _ExArr.Add(objEx.Message);
            }

        }

        public int InsertIdentityTable(string strSql)
        {
            string strEx = "";
            int intReturned = 0;
            string strSqlIdentitity;
            //connection.Open();
            _ExArr = new List<string>();
            using (SqlConnection connection = new SqlConnection(_sqlConnection.ConnectionString))
            {
             
                    try
                    {
                      
                        if(connection.State != ConnectionState.Open)
                        connection.Open();
                        SqlCommand objCommand = new SqlCommand(strSql, connection);
                        objCommand.CommandTimeout = 99999999;
                        objCommand.ExecuteNonQuery();
                        strSqlIdentitity = "select @@identity as LastInserted ";
                        objCommand = new SqlCommand(strSqlIdentitity, connection);
                        object objTemp = objCommand.ExecuteScalar();
                        if (objTemp != null)
                            intReturned = int.Parse(objTemp.ToString());

                        connection.Close();
                    }
                    catch (Exception Ex)
                    {
                        _ExArr.Add(Ex.Message);
                    }


            }
            return intReturned;

        }
        public int InsertIdentityTable(string strSql, SqlConnection connection, SqlTransaction objTrans)
        {
          
            int intReturned = 0;
            string strSqlIdentitity;
            //connection.Open();
                    try
                    {
                        _ExArr = new List<string>();
                        SqlCommand objCommand = new SqlCommand(strSql, connection);
                       
                        objCommand.CommandTimeout = 99999999;
                        objCommand.Transaction = objTrans;
                        objCommand.ExecuteNonQuery();
                        strSqlIdentitity = "select @@identity as LastInserted ";
                        //objCommand = new SqlCommand(strSqlIdentitity, connection);
                        objCommand.CommandText = strSqlIdentitity;
                        object objTemp = objCommand.ExecuteScalar();
                        if (objTemp != null)
                            intReturned = int.Parse(objTemp.ToString());

                        //connection.Close();
                    }
                    catch (Exception Ex)
                    {
                        _ExArr.Add(Ex.Message);
                    }


            
            
            return intReturned;

        }

        public int InsertIdentityTable(string strTableName, string strFieldName, byte[] arrByte)
        {

            int intReturned = 0;
            string strSqlIdentitity;
            //connection.Open();
            using (SqlConnection connection = new SqlConnection(_sqlConnection.ConnectionString))
            {
                try
                {
                    _ExArr = new List<string>();
                    connection.Open();
                    string strSql = "insert into " + strTableName + " (" + strFieldName + ") values(@File)";
                    SqlCommand objCommand = new SqlCommand(strSql, connection);
                    SqlParameter objParamter = new SqlParameter("@File", SqlDbType.Binary);

                    objParamter.Value = arrByte;
                    objCommand.Parameters.Add(objParamter);

                    objCommand.CommandTimeout = 99999999;
                    objCommand.ExecuteNonQuery();
                    strSqlIdentitity = "select @@identity as LastInserted ";
                    objCommand = new SqlCommand(strSqlIdentitity, connection);
                    object objTemp = objCommand.ExecuteScalar();
                    if (objTemp != null)
                        intReturned = int.Parse(objTemp.ToString());

                    connection.Close();
                }
                catch(SqlException objEx)
                {
                    _ExArr.Add(objEx.Message);
                }
                
            }
            return intReturned;

        }
        public int InsertIdentityTable(string strSql, SqlParameter[] arrParameter)
        {

            int intReturned = 0;
            string strSqlIdentitity;

            using (SqlConnection connection = new SqlConnection(_sqlConnection.ConnectionString))
            {
                _ExArr = new List<string>();
                try
                {
                    connection.Open();

                    SqlCommand objCommand = new SqlCommand(strSql, connection);
                    objCommand.Parameters.AddRange(arrParameter);

                    objCommand.CommandTimeout = 99999999;
                    objCommand.ExecuteNonQuery();
                    strSqlIdentitity = "select @@identity as LastInserted ";
                    objCommand = new SqlCommand(strSqlIdentitity, connection);
                    object objTemp = objCommand.ExecuteScalar();
                    if (objTemp != null)
                        intReturned = int.Parse(objTemp.ToString());

                    connection.Close();
                }
                catch(SqlException objEx)
                {
                    _ExArr.Add(objEx.Message);
                }
                
            }
            return intReturned;

        }

        public DataSet ReturnDataSet(string strSql) //select
        {
            try
            {

                using (SqlConnection connection = new SqlConnection(_sqlConnection.ConnectionString))
                {
                    connection.Open();
                    SqlDataAdapter objAdapter = new SqlDataAdapter(strSql, connection);
                    DataSet objDataSet = new DataSet();
                    objAdapter.Fill(objDataSet);
                    connection.Close();
                    return (objDataSet);
                }
            }
            catch
            {
                return null;
            }

        }
        public SqlDataAdapter Adapter(string strSql)
        {
            SqlConnection connection = new SqlConnection(_sqlConnection.ConnectionString);
            connection.Open();
            SqlDataAdapter Adpt = new SqlDataAdapter(strSql, connection);
            return Adpt;
        }
        public object ReturnScalar(string strSql)
        {
            try
            {

                using (SqlConnection connection = new SqlConnection(_sqlConnection.ConnectionString))
                {
                    connection.Open();
                    object obj;
                    SqlCommand com = new SqlCommand(strSql, connection);
                    com.CommandTimeout = 99999999;
                    obj = com.ExecuteScalar();
                    connection.Close();
                    return obj;
                }
            }
            catch(Exception ex)
            {
                return null;
            }


        }
        public object ReturnScalar(string strSql,SqlConnection connection,SqlTransaction objTrans)
        {
            try
            {

            
                    object obj;
                    SqlCommand com = new SqlCommand(strSql, connection);
                    com.Transaction = objTrans;
                    obj = com.ExecuteScalar();
                    
                    return obj;
                
            }
            catch
            {
                return null;
            }


        }
      
        public DataTable ReturnDatatable(string strSql, SqlConnection connection)
        {
            string str = "";
            try
            {

                //SqlConnection connection = new SqlConnection(sqlConnection.ConnectionString);
                if (connection.State == ConnectionState.Closed)
                    connection.Open();
                SqlDataAdapter objAdapter = new SqlDataAdapter(strSql, connection);
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
        public DataTable ReturnDatatable(string strSql)
        {
            string str = "";
            try
            {

                using (SqlConnection connection = new SqlConnection(_sqlConnection.ConnectionString))
                {
                    //connection.Open();  
                    //strSql = strSql.Replace("'", "''");
                    SqlDataAdapter objAdapter = new SqlDataAdapter(strSql, connection);
                    objAdapter.SelectCommand.CommandTimeout = 99999999;
                    DataTable objDatatable = new DataTable();

                    objAdapter.Fill(objDatatable);
                    connection.Close();

                    return (objDatatable);
                }


            }
            catch (SqlException ex)
            {
                str = ex.Message;

                return null;
            }
            finally {
                
            }


        }
        public DataTable ReturnDatatable(string strSql, string strTableName)
        {
            try
            {

                using (SqlConnection connection = new SqlConnection(_sqlConnection.ConnectionString))
                {
                    connection.Open();
                    SqlDataAdapter objAdapter = new SqlDataAdapter(strSql, connection);
                    objAdapter.SelectCommand.CommandTimeout = 99999999;
                    DataTable objDatatable = new DataTable(strTableName);
                    objAdapter.Fill(objDatatable);
                    connection.Close();
                    return (objDatatable);
                }
                //				return(objDatatable);
            }
            catch (SqlException ex)
            {
                string str = ex.Message;

                return null;
            }


        }

        public SqlDataReader ReturnReader(string strSql) //select
        {

            SqlConnection connection = new SqlConnection(_sqlConnection.ConnectionString);
            connection.Open();
            //connection.Open();
            SqlCommand objCommand = new SqlCommand(strSql, connection);
            SqlDataReader objReader = objCommand.ExecuteReader();
            //connection.Close();
            return (objReader);

        }




    }
    public class sqlConnection
    {
        private string _DbServerName;
        private string _DbUserID;
        private string _DbPassword;
        private string _DbName;
        private string _ConnectionString;
        public sqlConnection(string strDbServerName, string strDbUserID, string strDbPasswords, string strDbName)
        {
            _DbServerName = strDbServerName;
            _DbUserID = strDbUserID;
            //_DbUserID = "sa";
            _DbPassword = strDbPasswords;
            //_DbPassword = "";
            _DbName = strDbName;
            //DbName = "AlmosftTV";
            _ConnectionString = "server=" + _DbServerName + ";database=" + _DbName + ";uid=" + _DbUserID + ";pwd=" + _DbPassword +";Pooling='true';Min Pool Size=2;Max Pool Size=150;";
        }
        public sqlConnection(string strConnection)
        {
            _DbServerName = "";
            _DbUserID = "";
            _DbPassword = "";
            _DbName = "";
            _ConnectionString = strConnection;
        }
        public string ConnectionString
        {
            set
            {
                _ConnectionString = value;
            }
            get
            {

                return _ConnectionString;
                //return  Config["ConnectionInfo"];
            }

        }
        public void SetConnectionVariables(string strDbServerName, string strDbUserID,
            string strDbPasswords, string strDbName)
        {
            _DbServerName = strDbServerName;
            _DbUserID = strDbUserID;
            //_DbUserID = "sa";
            _DbPassword = strDbPasswords;
            //_DbPassword = "";
            _DbName = strDbName;
        }
        public bool TestConection()
        {
            string strEx = "";
            try
            {
                string strConnection = _ConnectionString + ";Connection Timeout=30";
                SqlConnection Conn = new SqlConnection(strConnection);
                {
                    Conn.Open();
                    Conn.Close();

                }

             
                return true;
            }
            catch (SqlException ex)
            {
                strEx = ex.Message;
                return false;
            }
        }
    }
}
