using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.UMS.UMSDataBase;
using SharpVision.SystemBase;
using System.Data;
using System.Data.SqlClient;
using SharpVision.Base.BaseDataBase;

namespace SharpVision.COMMON.COMMONDataBase
{
    public class SupperCodeDb
    {
        #region Private Data
        int _ID;
        string _Code;
        string _Value;
        string _Desc;
        #endregion
        #region Constructors
        public SupperCodeDb()
        { 
        }
        public SupperCodeDb(DataRow objDr)
        {
            SetData(objDr);
        }
        public SupperCodeDb(string strCode)
        {
            _Code = strCode;
            DataTable dtTemp = Search();
            if (dtTemp.Rows.Count == 0)
                _Code = "";
            else
                SetData(dtTemp.Rows[0]);
        }

        #endregion
        #region Public Properties
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
        public string Code
        {
            set
            {
                _Code = value;
            }
            get
            {
                return _Code;
            }
        }
        public string Value
        {
            set
            {
                _Value = value;
            }
            get
            {
                return _Value;
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
        public static string SearchStr
        {
            get
            {
                string Returned = " SELECT     SupperCodeID, SupperCode, SupperCodeValue, SupperCodeDesc" +
                                  " FROM    COMMONSupperCode ";
                return Returned;
            }
        }
        #endregion
        #region Private Methods
        void SetData(DataRow objDr)
        {
            _ID = int.Parse(objDr["SupperCodeID"].ToString());
            _Code = objDr["SupperCode"].ToString();
            _Value = objDr["SupperCodeValue"].ToString();
            _Desc = objDr["SupperCodeDesc"].ToString();
        }
        #endregion
        #region Public Methods
        public void Add()
        {
            string strSql = " INSERT INTO COMMONSupperCode" +
                            " (SupperCode, SupperCodeValue, SupperCodeDesc)" +
                            " VALUES     ('"+_Code+"','"+_Value+"','"+_Desc+"') ";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public void Edit()
        {
            string strSql = " UPDATE    COMMONSupperCode" +
                            " SET   SupperCode ='" + _Code + "'" +
                            " , SupperCodeValue ='" + _Value + "'" +
                            " , SupperCodeDesc ='" + _Desc + "' " +
                            " Where SupperCodeID = " + _ID + "";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public void Delete()
        {
            string strSql = " UPDATE    COMMONSupperCode" +
                            " SET    Dis = GetDate() " +
                            " Where SupperCodeID = " + _ID + "";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql); 
        }
        public DataTable Search()
        {
            string strSql = SearchStr + " Where 1 = 1 ";
            if (_ID != 0)
                strSql = strSql + " and  SupperCodeID = " + _ID + "";
            if (_Code != null && _Code != "")
                strSql = strSql + " and SupperCode = '"+_Code+"' ";
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        #endregion
    }
}
