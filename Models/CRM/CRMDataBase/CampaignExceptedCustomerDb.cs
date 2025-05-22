using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.SystemBase;
using System.Data;
using System.Data.SqlClient;
using SharpVision.Base.BaseDataBase;

using SharpVision.UMS.UMSDataBase;
namespace SharpVision.CRM.CRMDataBase
{
    public class CampaignExceptedCustomerDb
    {
        #region Private Data
        int _Campaign;
        int _Customer;
        string _Reason;
        bool _IsDateLimited;
        DateTime _EndDate;
        string _CustomerIDs;

        #endregion
        #region Constructors
        public CampaignExceptedCustomerDb()
        { 

        }
        public CampaignExceptedCustomerDb(DataRow objDr)
        {
            SetData(objDr);
        }
        #endregion
        #region Public Properties
        public int Campaign
        {
            set
            {
                _Campaign = value;
            }
            get
            {
                return _Campaign;
            }
        }
        public int Customer
        {
            set
            {
                _Customer = value;
            }
            get
            {
                return _Customer;
            }
        }
        public string Reason
        {
            set
            {
                _Reason = value;
            }
            get
            {
                return _Reason;
            }
        }
        public bool IsDateLimited
        {
            set
            {
                _IsDateLimited = value;
            }
            get
            {
                return _IsDateLimited;
            }
        }
        public DateTime EndDate
        {
            set
            {
                _EndDate = value;
            }
            get
            {
                return _EndDate;
            }

        }
        public string CustomerIDs
        {
            set
            {
                _CustomerIDs = value;
            }
        }
        public static string SearchStr
        {
            get
            {
                CustomerDb objCustomerDb = new CustomerDb();
                string Returned = "SELECT   Campaign, Customer,ExceptionReason, ExceptionEndDate,CustomerTable.* "+
                       " FROM   dbo.CRMCampaignExceptedCustomer "+
                       " inner join ("+ objCustomerDb.SearchStr +") as CustomerTable "+
                       " on CRMCampaignExceptedCustomer.Customer = CustomerTable.CustomerID ";

                return Returned;

            }
 
        }
        #endregion
        #region Private Methods
        void SetData(DataRow objDr)
        {
            _Campaign = int.Parse(objDr["Campaign"].ToString());
            _Customer = int.Parse(objDr["Customer"].ToString());
            _Reason = objDr["ExceptionReason"].ToString();
            _IsDateLimited = objDr["ExceptionEndDate"].ToString() != "";
            if (_IsDateLimited)
                _EndDate = DateTime.Parse(objDr["ExceptionEndDate"].ToString());

        }
        #endregion
        #region Public Methods
        public void SetExceptedSystemCampaignCustomer()
        {
            if (_CustomerIDs == null || _CustomerIDs == "")
                return;
            string strSql = "SELECT  dbo.CRMCampaignExceptedCustomer.Customer "+
                   " FROM   dbo.CRMCampaign INNER JOIN "+
                   " dbo.CRMCampaignExceptedCustomer ON dbo.CRMCampaign.CampaignID = dbo.CRMCampaignExceptedCustomer.Campaign "+
                   " WHERE (dbo.CRMCampaign.CampaignIsSystemCampaign = 1) AND (dbo.CRMCampaignExceptedCustomer.Customer IN ("+ _CustomerIDs +"))";
            strSql = "insert into CRMCampaignExceptedCustomer (Campaign, Customer) " +
                "  SELECT  dbo.CRMCampaign.CampaignID, dbo.CRMCustomer.CustomerID " +
                " FROM         dbo.CRMCustomer CROSS JOIN " +
                " dbo.CRMCampaign " +
                " WHERE     (dbo.CRMCustomer.CustomerID IN (" + _CustomerIDs + ")) " +
                " AND (dbo.CRMCampaign.CampaignIsSystemCampaign = 1) " +
                " and (dbo.CRMCustomer.CustomerID not IN (" + strSql + ")) ";
            string strDate = _IsDateLimited ? (SysUtility.Approximate(_EndDate.ToOADate() - 2, 1, ApproximateType.Down)).ToString() : "null";
            int intIsLimited = _IsDateLimited ? 1 : 0;
            strSql += " update CRMCampaignExceptedCustomer set ExceptionReason='" + _Reason + "',ExceptionEndDate= " + strDate +
                " FROM    dbo.CRMCampaignExceptedCustomer INNER JOIN "+
                " dbo.CRMCampaign ON dbo.CRMCampaignExceptedCustomer.Campaign = dbo.CRMCampaign.CampaignID "+
                " WHERE     (dbo.CRMCampaignExceptedCustomer.Customer IN ("+ _CustomerIDs +")) AND (dbo.CRMCampaign.CampaignIsSystemCampaign = 1)";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public void SetExceptedCampaignCustomer()
        {
            if (_CustomerIDs == null || _CustomerIDs == "")
                return;
            string strSql = "SELECT  dbo.CRMCampaignExceptedCustomer.Customer " +
                   " FROM   dbo.CRMCampaign INNER JOIN " +
                   " dbo.CRMCampaignExceptedCustomer ON dbo.CRMCampaign.CampaignID = dbo.CRMCampaignExceptedCustomer.Campaign " +
                   " WHERE (dbo.CRMCampaign.CampaignID = "+ _Campaign +") AND (dbo.CRMCampaignExceptedCustomer.Customer IN (" + _CustomerIDs + "))";
            strSql = "insert into CRMCampaignExceptedCustomer (Campaign, Customer) " +
                "  SELECT  dbo.CRMCampaign.CampaignID, dbo.CRMCustomer.CustomerID " +
                " FROM         dbo.CRMCustomer CROSS JOIN " +
                " dbo.CRMCampaign " +
                " WHERE     (dbo.CRMCustomer.CustomerID IN (" + _CustomerIDs + ")) " +
                " AND (dbo.CRMCampaign.CampaignID="+ _Campaign +") " +
                " and (dbo.CRMCustomer.CustomerID not IN (" + strSql + ")) ";
            string strDate = _IsDateLimited ? (SysUtility.Approximate(_EndDate.ToOADate() - 2, 1, ApproximateType.Down)).ToString() : "null";
            int intIsLimited = _IsDateLimited ? 1 : 0;
            strSql += " update CRMCampaignExceptedCustomer set ExceptionReason='" + _Reason + "',ExceptionEndDate= " + strDate +
                " FROM    dbo.CRMCampaignExceptedCustomer INNER JOIN " +
                " dbo.CRMCampaign ON dbo.CRMCampaignExceptedCustomer.Campaign = dbo.CRMCampaign.CampaignID " +
                " WHERE     (dbo.CRMCampaignExceptedCustomer.Customer IN (" + _CustomerIDs + ")) AND (dbo.CRMCampaign.CampaignID="+ _Campaign +")";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public void StopCampaignCustomerException()
        {
            if (_CustomerIDs != null && _CustomerIDs != "")
                return;
            string  strSql = " update CRMCampaignExceptedCustomer set ExceptionEndDate= GetDate() " + 
                " FROM    dbo.CRMCampaignExceptedCustomer INNER JOIN "+
                " dbo.CRMCampaign ON dbo.CRMCampaignExceptedCustomer.Campaign = dbo.CRMCampaign.CampaignID "+
                " WHERE     (dbo.CRMCampaignExceptedCustomer.Customer IN (" + _CustomerIDs + ")) ";
            if (_Campaign == 0)
                strSql += " AND (dbo.CRMCampaign.CampaignIsSystemCampaign = 1)";
            else
                strSql += " and (dbo.CRMCampaign.CampaignID= " + _Campaign + ") ";

            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public DataTable Search()
        {
            string strSql = SearchStr + " where  (ExceptionEndDate is null or ExceptionEndDate >GetDate()) ";
            if (_Campaign != 0)
                strSql += " and Campaign="+ _Campaign;
            
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        #endregion
    }
}
