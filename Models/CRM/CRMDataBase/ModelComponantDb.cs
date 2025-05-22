using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.SystemBase;
using System.Data;
using System.Data.SqlClient;
using SharpVision.Base.BaseDataBase;

namespace SharpVision.CRM.CRMDataBase
{
    public class ModelComponantDb
    {
        #region Private Data
        int _ComponantID;
        int _ModelID;
        double _Length;
        double _Width;
        int _No;
        #region Private Data for Search
        string _ModelIDs;
        string _ComponantIDs;
        #endregion
        #endregion
        #region Constructors
        public ModelComponantDb()
        {

        }
        public ModelComponantDb(DataRow objDr)
        {
            _ComponantID = int.Parse(objDr["ComponantID"].ToString());
            _ModelID = int.Parse(objDr["ModelID"].ToString());
            _No = int.Parse(objDr["ComponantNo"].ToString());
            _Length = double.Parse(objDr["Length"].ToString());
            _Width = double.Parse(objDr["Width"].ToString());
        }
        #endregion
        #region Public Properties
        public int ComponantID
        {
            set
            {
                _ComponantID = value;
            }
            get
            {
                return _ComponantID;
            }
        }
        public int ModelID
        {
            set
            {
                _ModelID = value;
            }
            get
            {
                return _ModelID;
            }
        }
        public int No
        {
            set
            {
                _No = value;
            }
            get
            {
                return _No;
            }
        }
        public double Length
        {
            set
            {
                _Length = value;
            }
            get
            {
                return _Length;
            }
        }
        public double Width
        {
            set
            {
                _Width = value;
            }
            get
            {
                return _Width;
            }
        }
        public string ModelIDs
        {
            set
            {
                _ModelIDs = value;
            }
        }
        public string ComponantIDs
        {
            set
            {
                _ComponantIDs = value;
            }
        }
        public static string SearchStr
        {
            get
            {
                string Returned = "SELECT ModelID,ComponantNo,Length,Width,ComponantTable.* " +
                        " FROM  dbo.CRMModelComponant inner join (" + ComponantDb.SearchStr + ") as ComponantTable on CRMModelComponant.ComponantID = ComponantTable.ComponantID ";
                return Returned;
            }
        }

        #endregion
        #region Private Methods

        #endregion
        #region Public Methods
        public DataTable Search()
        {
            string strSql = SearchStr + " where (1=1) ";
            if (_ModelID != 0)
                strSql = strSql + " and ModelID=" + _ModelID;
            if (_ComponantID != 0)
                strSql = strSql + " and ComponantTable.ComponantID = " + _ComponantID;
            if (_ModelIDs != null && _ModelIDs != "")
                strSql = strSql + " and ModelID in (" + _ModelIDs + ")";
            if (_ComponantIDs != null && _ComponantIDs != "")
                strSql = strSql + " and ComponantTable.ComponantID in (" + _ComponantIDs + ")";

            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        #endregion
    }
}
