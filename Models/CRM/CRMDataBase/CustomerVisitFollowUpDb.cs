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
    public class CustomerVisitFollowUpDb
    {
        #region Private Data
        protected int _ID;
        protected int _Visit;
        protected int _FollowUpType;
        protected string _FollowUpDesc;
        protected DateTime _FollowUpDate;
        protected int _SalesMan;
        protected int _Status;
        protected bool _dtSearch;
        protected DateTime _dtFromSearch;
        protected DateTime _dtToSearch;
        //protected int _SalesManApplicantSearch;
        #endregion
        #region Constractors
        public CustomerVisitFollowUpDb()
        {

        }
        public CustomerVisitFollowUpDb(DataRow objDR)
        {
            SetData(objDR);
        }
        #endregion
        #region Public Accessorice
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
        public int Visit
        {
            set
            {
                _Visit = value;
            }
            get
            {
                return _Visit;
            }
        }
        public int FollowUpType
        {
            set
            {
                _FollowUpType = value;
            }
            get
            {
                return _FollowUpType;
            }
        }
        public string FollowUpDesc
        {
            set
            {
                _FollowUpDesc = value;
            }
            get
            {
                return _FollowUpDesc;
            }
        }
        public DateTime FollowUpDate
        {
            set
            {
                _FollowUpDate = value;
            }
            get
            {
                return _FollowUpDate;
            }
        }
        public int SalesMan
        {
            set
            {
                _SalesMan = value;

            }
            get
            {
                return _SalesMan;
            }
        }
        public bool dtSearch
        {
            set
            {
                _dtSearch = value;
            }
        }
        public DateTime dtFromSearch
        {
            set
            {
                _dtFromSearch = value;
            }
        }
        public DateTime dtToSearch
        {
            set
            {
                _dtToSearch = value;
            }
        }
        public int Status
        {
            set
            {
                _Status = value;
            }
            get
            {
                return _Status;
            }
        }
        public string AddStr
        {
            get
            {
               double dblDate = _FollowUpDate.ToOADate() - 2;
                string Returned =" INSERT INTO CRMCustomerVisitFollowUp" +
                            " (Visit, FollowUpType, FollowUpDesc, FollowUpDate,SalesMan)" +
                            " VALUES     (" + _Visit + "," + _FollowUpType + ",'" + _FollowUpDesc + "'," + dblDate + "," + _SalesMan + ") ";
                return Returned;
            }
        }
        public string EditStr
        {
            get
            {
                double dblDate = _FollowUpDate.ToOADate() - 2;
                string Returned = " UPDATE    CRMCustomerVisitFollowUp" +
                            " SET   Visit = " + _Visit + "" +
                            " , FollowUpType =" + _FollowUpType + "" +
                            " , FollowUpDesc ='" + _FollowUpDesc + "'" +
                            " , FollowUpDate = " + dblDate + "" +
                            " , SalesMan = " + _SalesMan + "" +
                            " Where CustomerVisitFollowUpID = " + _ID + "";
                return Returned;
            }
        }
        public string DeleteStr
        {
            get
            {
                string Returned = " DELETE FROM CRMCustomerVisitFollowUp " +
                            " Where CustomerVisitFollowUpID = " + _ID + "";
                return Returned;
            }
        }
        public static string SearchStr
        {
            get
            {
                string Returned = "SELECT     CustomerVisitFollowUpID, Visit, FollowUpType, FollowUpDesc, FollowUpDate,SalesMan,FollowUpStatus" +
                                  " FROM         CRMCustomerVisitFollowUp";
                return Returned;
            }
        }
        #endregion
        #region Private Methods

        void SetData(DataRow objDR)
        {
            _ID = int.Parse(objDR["CustomerVisitFollowUpID"].ToString());
            _SalesMan = int.Parse(objDR["SalesMan"].ToString());
            _Visit = int.Parse(objDR["Visit"].ToString());
            _FollowUpType = int.Parse(objDR["FollowUpType"].ToString());
            _FollowUpDesc = objDR["FollowUpDesc"].ToString();
            _FollowUpDate = DateTime.Parse(objDR["FollowUpDate"].ToString());
            //if(objDR["FollowUpStatus"].ToString()!="")
            //_Status = int.Parse(objDR["FollowUpStatus"].ToString());
        }


        #endregion
        #region Public Methods
        public void Add()
        {            
            SysData.SharpVisionBaseDb.ExecuteNonQuery(AddStr);
        }
        public void Edit()
        {            
            SysData.SharpVisionBaseDb.ExecuteNonQuery(EditStr);
        }
        public void EditStatus()
        {
            string strSql = " UPDATE    CRMCustomerVisitFollowUp" +
                            " SET FollowUpStatus = "+_Status+""+
                            " Where CustomerVisitFollowUpID = " + _ID + "";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public void Delete()
        {           
            SysData.SharpVisionBaseDb.ExecuteNonQuery(DeleteStr);
        }
        public DataTable Search()
        {
            string strSql = SearchStr + " WHERE   (1=1)";
            if (_ID != 0)
                strSql = strSql + " and CustomerVisitFollowUpID = " + _ID + "";
            if (_Visit != 0)
                strSql = strSql + " and Visit = " + _Visit + " ";
            if (_FollowUpType != 0)
                strSql = strSql + " and FollowUpType = " + _FollowUpType + " ";
            if (_SalesMan != 0)
                strSql = strSql + " and SalesMan = " + _SalesMan + ""; ;
            if (_dtSearch == true)
            {
                double dlFrom = _dtFromSearch.ToOADate() - 2;
                double dlTo = _dtToSearch.ToOADate() - 1;

                strSql += " And FollowUpDate Between " + dlFrom + " and " + dlTo + "";
            }
            strSql += " Order by FollowUpDate,Visit";
            DataTable Returned = SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
            return Returned;

        }
        #endregion
    }
}
