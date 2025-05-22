using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.SystemBase;
using System.Data;
using System.Data.SqlClient;
using SharpVision.RP.RPDataBase;
using SharpVision.Base.BaseDataBase;

namespace SharpVision.CRM.CRMDataBase
{
    public class CustomerVisitCellDb
    {
        #region Private Data
        protected int _CustomerVisit;
        protected int _Cell;
        #endregion
        #region Constructors
        public CustomerVisitCellDb()
        {
        }
        public CustomerVisitCellDb(DataRow objDr)
        {
            SetData(objDr);
        }
        #endregion
        #region Public Properties
        public int CustomerVisit
        {
            set { _CustomerVisit = value; }
            get { return _CustomerVisit; }
         }
        public int Cell
        {
            set { _Cell = value; }
            get { return _Cell; }
        }
        public string AddStr
        {
            get
            {
                string strReturn = " INSERT INTO CRMCustomerVisitCell "+
                                   " (CustomerVisit, CustomerVisitCell)"+
                                   " VALUES  (" + _CustomerVisit + ","+ _Cell +")";
                return strReturn;
            }
        }
        public static string SearchStr
        {
            get
            {
                string strReturn = " SELECT     CustomerVisit, CustomerVisitCell FROM         CRMCustomerVisitCell";
                return strReturn;
            }
        }

        #endregion
        #region Private Methods
        void SetData(DataRow objDr)
        {
            _CustomerVisit = int.Parse(objDr["CustomerVisit"].ToString());
            _Cell = int.Parse(objDr["CustomerVisitCell"].ToString());
        }
        #endregion
        #region Public Methods
        public void Add()
        {
            SysData.SharpVisionBaseDb.ExecuteNonQuery(AddStr);
        }
        public DataTable Search()
        {
            string strSql = SearchStr + " Where 1=1 ";
            if (_CustomerVisit != 0)
                strSql += " And (CustomerVisit=" + _CustomerVisit + ")";
            if (_Cell != 0)
                strSql += " And (CustomerVisitCell=" + _Cell + ")";
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        #endregion
    }
}
