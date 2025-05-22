using System;
using System.Collections.Generic;
using System.Text;
using System.Data;


namespace SharpVision.UMS.UMSDataBase
{
    public class SystemDb
    {
        #region Private Data
        int _ID;
        string _Name;
        string _Desc;
        int _CurrentVersion;
        string _Directory;
        string _Url;
        bool _OnlyOnlineFunction;
        bool _OnlyNonStopedFunction;
        #endregion
        #region Constructors
        public SystemDb()
        {

        }
        public SystemDb(int intSystemID)
        {
            _ID = intSystemID;
            DataTable dtTemp = Search();
            if (dtTemp == null || dtTemp.Rows.Count == 0)
                return;

            DataRow objDR = dtTemp.Rows[0];
            _Name = objDR["SysName"].ToString();
            _Desc = objDR["SysDesc"].ToString();
            _CurrentVersion = int.Parse(objDR["CurrentVersion"].ToString());
            int intTemp = 0;
            int.TryParse(objDR["CurrentVersion2"].ToString(), out intTemp);
            if (intTemp != 0)
                _CurrentVersion = intTemp;
            _Directory = objDR["UpdateDirectory"].ToString();
            _Url = objDR["UpdateUrl"].ToString();

        }
        public SystemDb(DataRow objDR)
        {
           
            _ID = int.Parse(objDR["SysID"].ToString());
            _Name = objDR["SysName"].ToString();
            _Desc = objDR["SysDesc"].ToString();
   
            _CurrentVersion = int.Parse(objDR["CurrentVersion"].ToString());
            int intTemp = 0;
            if (objDR.Table.Columns["CurrentVersion2"] != null)
            int.TryParse(objDR["CurrentVersion2"].ToString(), out intTemp);
            if (intTemp != 0)
                _CurrentVersion = intTemp;
            _Directory = objDR["UpdateDirectory"].ToString();
            _Url = objDR["UpdateUrl"].ToString();
        }

        #endregion
        #region Public Poberities
        public int ID
        {
            set
            {
                _ID = value;
            }
            get
            {
                return _ID;
            }
        }
        public string Name
        {
            set
            {
                _Name = value;
            }
            get
            {
                return _Name;
            }
        }

        public string Desc
        {
            set
            {
                _Desc = value;
            }
            get
            {
                return _Desc;
            }
        }
        public int CurrentVersion
        {
            set
            {
                _CurrentVersion = value;
            }
            get
            {
                return _CurrentVersion;
            }
        }
        public string Directory
        {
            set
            {
                _Directory = value;
            }
            get
            {
                return _Directory;
            }
        }
        public string Url
        {
            set
            {
                _Url = value;
            }
            get
            {
                return _Url;
            }
        }
        public bool OnlyOnlineFunction
        {
            set
            {
                _OnlyOnlineFunction = value;
            }
        }
        public bool OnlyNonStopedFunction
        {
            set
            {
                _OnlyNonStopedFunction = value;
            }
        }
        #endregion
        #region Public Methods
        public void Add()
        {

            string strSql = "INSERT INTO UMSSystem (SysName, SysDesc, CurrentVersion, UpdateDirectory,UpdateUrl)" +
                            " VALUES ('" + _Name + "','" + _Desc + "'," + _CurrentVersion + ",'" + _Directory + "','" + _Url  +"')";
            BaseDb.UMSBaseDb.ExecuteNonQuery(strSql);
        }
        public void Edit()
        {
            string strSql = "UPDATE UMSSystem SET SysName='" + _Name + "' ";
            strSql = strSql + "SysDesc= '" + _Desc + "'";
            strSql = strSql + ",CurrentVersion= " + _CurrentVersion + " ";
            strSql = strSql + ",UpdateDirectory= '" + _Directory + "'";
            strSql = strSql + ",UpdateUrl='" + _Url + "'";
            strSql = strSql + " WHERE SysID=" + _ID;

            BaseDb.UMSBaseDb.ExecuteNonQuery(strSql);
        }
        public void Delete()
        {

            string strSql = "DELETE FROM UMSSystem WHERE SystemID=" + _ID;
            BaseDb.UMSBaseDb.ExecuteNonQuery(strSql);
        }
        public DataTable Search()
        {
            string strSql = "SELECT  SysID, SysName, SysDesc, CurrentVersion,CurrentVersion2 , UpdateDirectory,UpdateUrl  " +
                            " FROM      UMSSystem " +
                            " WHERE     (Dis IS NULL)";
            if (_ID != 0)
            {
                strSql = strSql + " AND SysID= " + _ID;
            }
            
            DataTable dtReturned = BaseDb.UMSBaseDb.ReturnDatatable(strSql);
            return dtReturned;
        }
        public DataTable GetSystemFunction()
        {
            string strSql = "SELECT   FunctionID, FunctionNameA, FunctionNameE, FunctionDescription, FunctionParentID, FunctionFamilyID, SysID " +
                            ",FunctionIsStoped,FunctionUrl ,GetDate() as StartDate,GetDate() as EndDate,CONVERT(bit, 1) AS IsPermanent,CONVERT(bit, 1) AS IsAdmin,1 as FunctionSrc " +
                            " FROM   dbo.UMSFunction " +
                                      " WHERE     (Dis IS NULL)";
            if (_ID != 0)
            {
                strSql = strSql + " AND SysID= " + _ID;
            }
            if (_OnlyOnlineFunction)
                strSql += " and FunctionUrl is not null and FunctionUrl <> '' ";
            if (_OnlyNonStopedFunction)
                strSql += " and FunctionIsStoped = 0 ";

            DataTable dtReturned = BaseDb.UMSBaseDb.ReturnDatatable(strSql,"Function");
            return dtReturned;
        }
        #endregion
    }
}

