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
    public class CustomerVisitRecoginationMediaDb
    {
        #region Private Data
        protected int _CustomerVisit;
        protected int _RecoginationMedia;
        #endregion
        #region Constructors
        public CustomerVisitRecoginationMediaDb()
        {
        }
        public CustomerVisitRecoginationMediaDb(DataRow objDr)
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
        public int RecoginationMedia
        {
            set { _RecoginationMedia = value; }
            get { return _RecoginationMedia; }
        }
        public string AddStr
        {
            get
            {
                string strReturn = " INSERT INTO CRMCustomerVisitRecoginationMedia "+
                                   " (CustomerVisit, RecoginationMedia)"+
                                   " VALUES  (" + _CustomerVisit + ","+ _RecoginationMedia +")";
                return strReturn;
            }
        }
        public static string SearchStr
        {
            get
            {
                string strReturn = " SELECT     CustomerVisit, RecoginationMedia FROM         CRMCustomerVisitRecoginationMedia";
                return strReturn;
            }
        }

        #endregion
        #region Private Methods
        void SetData(DataRow objDr)
        {
            _CustomerVisit = int.Parse(objDr["CustomerVisit"].ToString());
            _RecoginationMedia = int.Parse(objDr["RecoginationMedia"].ToString());
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
            if (_RecoginationMedia != 0)
                strSql += " And (RecoginationMedia=" + _RecoginationMedia + ")";
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        #endregion
    }
}
