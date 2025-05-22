using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.SystemBase;
using System.Data;
using System.Data.SqlClient;
using SharpVision.Base.BaseDataBase;

namespace SharpVision.CRM.CRMDataBase
{
    public class CampaignSMSDb
    {
        #region Private Data
        protected int _ID;
        protected string _PhoneNum;
        protected string _Msg;
        protected int _CustomerCampaign;
        protected int _CustomerCampaignContact;
        protected string _ProviderID;
        protected string _CustomerCampaignIDs;
        protected string _CustomerIDs;
        #region Private Data For Search
        int _Campaign;
        int _Customer;
        #endregion
        #endregion
        #region Constractors
        public CampaignSMSDb()
        { 
        }
        public CampaignSMSDb(int intID)
        {
            DataTable dtTemp = Search();
            DataRow objDR = dtTemp.Rows[0];
            SetData(objDR);
        }
        public CampaignSMSDb(DataRow objDR)
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
        public string PhoneNum
        {
            set
            {
                _PhoneNum = value;
            }
            get
            {
                return _PhoneNum;
            }
        }
        public string Msg
        {
            set
            {
                _Msg = value;
            }
            get
            {
                return _Msg;
            }
        }
        public int CustomerCampaign
        {
            set
            {
                _CustomerCampaign = value;
            }
            get
            {
                return _CustomerCampaign;
            }
        }
        public int CustomerCampaignContact
        {
            set 
            {
                _CustomerCampaignContact = value;
            }
            get
            {
                return _CustomerCampaignContact;
            }
        }
        public string ProviderID
        {
            set
            {
                _ProviderID = value;
            }
            get
            {
                return _ProviderID;
            }
        }
        public int Campaign
        {
            set
            {
                _Campaign = value;
            }
        }
        public int Customer
        {
            set
            {
                _Customer = value;
            }
        }
        public string CustomerIDs
        {
            set
            {
                _CustomerIDs = value;
            }
        }
        public string CustomerCampaignIDs
        {
            set
            {
                _CustomerCampaignIDs = value;
            }
        }
        public static string SearchStr
        {
            get
            {
                string Returned = " SELECT     SMSID, SMSPhoneNum, SMSMsg, SMSCustomerCampaign, SMSProviderID"+
                                  " FROM  CRMCampaignSMS ";
                return Returned;

            }
        }
        #endregion
        #region Private Methods
        void SetData(DataRow objDR)
        {
            _ID = int.Parse(objDR["SMSID"].ToString());
            _PhoneNum = objDR["SMSPhoneNum"].ToString();
            _Msg = objDR["SMSMsg"].ToString();
            _CustomerCampaignContact = int.Parse(objDR["SMSCustomerCampaign"].ToString());
            _ProviderID = objDR["SMSProviderID"].ToString();
        }
        #endregion
        #region Public Methods
        public void Add()
        {
            string strCustomerContact = "SELECT  MAX(CampaignContactID) AS CampaignCustomerContact "+
               " FROM         dbo.CRMCampaignCustomerContact "+
               " GROUP BY CampaignCustomerID "+
               " HAVING      (CampaignCustomerID = "+ _CustomerCampaign +")";
            string strSql = " INSERT INTO CRMCampaignSMS "+
                            " (SMSPhoneNum, SMSMsg, SMSCustomerCampaign, SMSProviderID, UsrIns, TimIns)"+
                            " "+
                            "select '"+_PhoneNum+"' as PhoneNo,'"+_Msg+"' as Msg"+
                            ",CustomerContactTable.CampaignCustomerContact as CampaignContactID,'" + _ProviderID + "' as ProvideID" +
                            " ,"+SysData.CurrentUser.ID+" as UsrINs,GetDate() as TimIns  "+
                            " from ("+ strCustomerContact +") as CustomerContactTable ";
            

            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public void AddCampaignCustomerSMSCol()
        {
            if ((_CustomerCampaignIDs == null || _CustomerCampaignIDs == "") &&
                (_Campaign == 0 &&(_CustomerIDs== null || _CustomerIDs== "")))
                return;
            string strCustomerContact = "SELECT  MAX(CampaignContactID) AS CampaignCustomerContact " +
             " FROM         dbo.CRMCampaignCustomerContact " +
             " GROUP BY CampaignCustomerID,ContactDirectCustomer,ContactCampaign " +
             " HAVING      ";
            if (_CustomerCampaignIDs != null && _CustomerCampaignIDs != "")
                strCustomerContact += " (CampaignCustomerID in (" + _CustomerCampaignIDs + ")) ";
            else if ( _CustomerIDs != null && _CustomerIDs != "")
                strCustomerContact += " (ContactCampaign = "+ _Campaign +") AND (ContactDirectCustomer in (" + _CustomerIDs + ")) ";
            string strSql = "";

            //if (_CustomerCampaignIDs != null && _CustomerCampaignIDs != "")
                strSql = " INSERT INTO CRMCampaignSMS " +
                                " (SMSPhoneNum, SMSMsg, SMSCustomerCampaign, SMSProviderID, UsrIns, TimIns)" +
                                " select '' as PhoneNum,'" + _Msg + "' as SMSMsg, CampaignCustomerContact,'" + _ProviderID +
                                "' as SMSProviderID," + SysData.CurrentUser.ID + " as UsrINs,GetDate() as TimIns  " +
                                " FROM  ("+ strCustomerContact +") as CustomerContactTable ";
            //" WHERE     (CampaignCustomerID IN (" + _CustomerCampaignIDs + ")) ";
            //else if (_CustomerIDs != null && _CustomerIDs != "")
            //    strSql = "";
            if(strSql != "")
                 SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }

        public void Edit()
        {
            string strSql = " UPDATE    CRMCampaignSMS" +
                            " SET   SMSPhoneNum ='" + _PhoneNum + "'" +
                            " , SMSMsg ='" + _Msg + "'" +
                            " , SMSCustomerCampaign =" + _CustomerCampaign + "" +
                            " , SMSProviderID ='" + _ProviderID + "'" +
                            " , UsrUpd =" + SysData.CurrentUser.ID + "" +
                            " , TimUpd = GetDate())" +
                            " Where SMSID = " + _ID + "";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public void Delete()
        {
            string strSql = " DELETE FROM CRMCampaignSMS Where  SMSID = " + _ID + "";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public DataTable Search()
        {
            string strSql = SearchStr + " Where 1 = 1 ";
            if (_ID != 0)
                strSql += " and  SMSID = " + _ID + "";
            if (_Campaign != 0)
            {
                strSql += " and SMSCustomerCampaign in (SELECT     CampaignCustomerID "+
                          " FROM         dbo.CRMCampaignCustomer "+
                           " WHERE     (Campaign = "+ _Campaign +") )";
            }
            if (_Customer != 0)
            {
                strSql += " and SMSCustomerCampaign in (SELECT     CampaignCustomerID " +
                          " FROM         dbo.CRMCampaignCustomer " +
                           " WHERE     (Customer = " + _Customer + ") )";
            }
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        #endregion
    }
}
