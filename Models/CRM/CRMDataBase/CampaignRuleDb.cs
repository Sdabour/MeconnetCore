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
    public class CampaignRuleDb
    {
        #region Private Data
        int _ID;
        int _Campaign;
        int _DayDiff;
        string _Desc;
        string _Msg;
        int _PeriodType;/*
                         * 0 Descrete Period
                         * 1 Continious Period
                         */
        #endregion
        #region Constructors
        public CampaignRuleDb()
        { 
        }
        public CampaignRuleDb(DataRow objDr)
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
        public int DayDiff
        {
            set
            {
                _DayDiff = value;
            }
            get
            {
                return _DayDiff;
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
        public int PeriodType
        {
            set
            {
                _PeriodType = value;
            }
            get
            {
                return _PeriodType;
            }
        }
        string _InstallmentTypeIDs;

        public string InstallmentTypeIDs
        {
            get { return _InstallmentTypeIDs; }
            set { _InstallmentTypeIDs = value; }
        }
        public string InstallemntDiscreteDueStr
        {
            get
            {
                string Returned = "SELECT        dbo.CRMReservationInstallment.InstallmentID "+
                               " FROM    dbo.CRMReservationInstallment INNER JOIN "+
                                " dbo.CRMCampaignRule ON DATEDIFF(day, dbo.GetApproximateDate(GETDATE()), dbo.GetApproximateDate(dbo.CRMReservationInstallment.InstallmentDueDate)) = dbo.CRMCampaignRule.RuleDayDiff "+
                                " WHERE        (dbo.CRMCampaignRule.RuleID = "+ _ID +")";
                if (_InstallmentTypeIDs != null && _InstallmentTypeIDs != "")
                    Returned += " and dbo.CRMReservationInstallment.InstallmentType in (" + _InstallmentTypeIDs + ") ";
                return Returned;
            }
        }

        public string InstallmentRemainingValueStr
        {
            get
            {
                ReservationInstallmentDb objInstallmentDb = new ReservationInstallmentDb();
                string strRemaining =  objInstallmentDb.InstallmentRemainingValueStr;
                string strDue = InstallemntDiscreteDueStr;
                string Returned = "select InstallmentTable.InstallmentID,InstallmentTable.ReservationID "+
                    "  from ("+ strDue +") as DueInstallmentTable  "+
                    " inner join ("+ strRemaining +") as InstallmentTable "+
                    " on DueInstallmentTable.InstallmentID = InstallmentTable.InstallmentID "+
                    " where InstallmentTable.TotalRemainingValue > 2 ";

                return Returned;
            }
        }
        public string CustomerSearchStr
        {
            get
            {
                string Returned = "SELECT    distinct   CustomerTable.* "+ 
                     " FROM  ( "+ InstallmentRemainingValueStr +") AS InstallmentTable INNER JOIN "+
                     " dbo.CRMReservationCustomer ON InstallmentTable.ReservationID = dbo.CRMReservationCustomer.ReservationID INNER JOIN "+
                     " CRMCustomer AS CustomerTable ON dbo.CRMReservationCustomer.CustomerID = CustomerTable.CustomerID";
                return Returned;
            }
        }
        public string AddStr
        {
            get
            {
                string Returned = "insert into CRMCampaignRule (RuleCampaign, RuleDayDiff, "+
                    "RuleDesc, RuleMsg,RulePeriodType,UsrIns,TimIns)" +
               " values (" + _Campaign + "," + _DayDiff + ",'" + _Desc + "','" + _Msg + "',"+_PeriodType + "," + 
               SysData.CurrentUser.ID + ",GetDate())";
                return Returned;
            }
        }
        public string EditStr
        {
            get
            {
                string Returned = "update CRMCampaignRule set RuleDayDiff=" + _DayDiff +
                ",RuleDesc='" + _Desc + "'" +
                ",RuleMsg='" + _Msg + "' " +
                ",RulePeriodType="+ _PeriodType+
                ",UsrUpd="+SysData.CurrentUser.ID+
                ",TimUpd=GetDate()"+
                " where RuleCampaign = " + _Campaign +
                " and RuleID=" + _ID; ;
                return Returned;
            }
        }
        public string SearchStr
        {
            get 
            {
                string Returned = "SELECT RuleID, RuleCampaign, RuleDayDiff, RuleDesc, RuleMsg,RulePeriodType "+
                       " FROM    dbo.CRMCampaignRule ";
                return Returned;
            }
        }

        #endregion
        #region Private Methods
        void SetData(DataRow objDr)
        {
            _ID = int.Parse(objDr["RuleID"].ToString());
            _DayDiff = int.Parse(objDr["RuleDayDiff"].ToString());
            _Campaign = int.Parse(objDr["RuleCampaign"].ToString());
            _Desc = objDr["RuleDesc"].ToString();
            _Msg = objDr["RuleMsg"].ToString();
            if (objDr["RulePeriodType"].ToString() != "")
                _PeriodType = int.Parse(objDr["RulePeriodType"].ToString());

        }
        #endregion
        #region Public Methods
        public void Add()
        {
            string strSql = AddStr;
            _ID = SysData.SharpVisionBaseDb.InsertIdentityTable(strSql);
        }
        public void Edit()
        {
            string strSql = EditStr;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public void Delete()
        {
            string strSql = "update CRMCampaignRule set Dis = GetDate() where RuleCampaign = "+ _Campaign +
                " and RuleID="+_ID;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public DataTable Search()
        {
            string strSql = SearchStr + " where Dis is null ";
            if (_Campaign != 0)
                strSql += " and RuleCampaign="+ _Campaign ;
            strSql += " order by RuleDayDiff desc ";
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        public DataTable GetCustomer()
        {
            return SysData.SharpVisionBaseDb.ReturnDatatable(CustomerSearchStr);

        }
        #endregion
    }
}
