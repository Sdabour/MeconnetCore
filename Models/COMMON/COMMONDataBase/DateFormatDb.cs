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
    public class DateFormatDb
    {
        #region Private Data
        int _ID;
        string _Format;
        string _Name;
        string _ExtraOne;
        string _ExtraTwo;
        #endregion
        #region Constructors
        public DateFormatDb()
        { 
        }
        public DateFormatDb(DataRow objDr)
        {
            SetData(objDr);
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
        public string Format
        {
            set
            {
                _Format = value;
            }
            get
            {
                return _Format;
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
        public string ExtraOne
        {
            set
            {
                _ExtraOne = value;
            }
            get
            {
                return _ExtraOne;
            }
        }
        public string ExtraTwo
        {
            set
            {
                _ExtraTwo = value;
            }
            get
            {
                return _ExtraTwo;
            }
        }
        public string AddStr
        {
            get
            {
                string Returned = "";
                return Returned;
            }
        }
        public string EditStr
        {
            get
            {
                string Returned = "";
                return Returned;
            }
        }
        public string DeleteStr
        {
            get
            {
                string Returned = "";
                return Returned;
            }
        }
        public static string SearchStr
        {
            get
            {
                string Returned = "SELECT FormatID, Format, FormatName, FormatExtraOne, FormatExtraTwo "+
                        " FROM   dbo.COMMONDateFormat ";
                return Returned;
            }
        }
        #endregion
        #region Private Methods
        void SetData(DataRow objDr)
        {
            _ID = int.Parse(objDr["FormatID"].ToString());
            _Format = objDr["Format"].ToString();
            _Name = objDr["FormatName"].ToString();
            _ExtraOne = objDr["FormatExtraOne"].ToString();
            _ExtraTwo = objDr["FormatExtraTwo"].ToString();

        }
        #endregion
        #region Public Methods
        public void Add()
        {
            string strSql = AddStr;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public void Edit()
        {
            string strSql = EditStr;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public void Delete()
        {
            string strSql = DeleteStr;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public DataTable Search()
        {
            string strSql = SearchStr;
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        #endregion
    }
}
