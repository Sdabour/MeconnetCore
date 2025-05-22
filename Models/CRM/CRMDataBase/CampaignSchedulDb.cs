using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using SharpVision.SystemBase;
namespace SharpVision.CRM.CRMDataBase
{
   public class CampaignScheduleDb
    {
        #region Private Data
        int _ID;
        public int ID
        {
            set { _ID = value; }
            get { return _ID; }
        }
        int _Campaign;
        public int Campaign
        {
            set { _Campaign = value; }
            get { return _Campaign; }
        }
        DateTime _Time;
        public DateTime Time
        {
            set { _Time = value; }
            get { return _Time; }
        }
        int _Order;
        public int Order
        {
            set { _Order = value; }
            get { return _Order; }
        }
        double _Perc;
        public double Perc
        {
            set { _Perc = value; }
            get { return _Perc; }
        }
        bool _Executed;
        public bool Executed
        {
            set { _Executed = value; }
            get { return _Executed; }
        }
        #endregion
        #region Constructors
        public CampaignScheduleDb()
        { }
        public CampaignScheduleDb(DataRow objDr)
        {
            SetData(objDr);
        }
        #endregion
        #region Public Properties

        public string AddStr
        {
            get
            {
                double dblTime = _Time.ToOADate() - 2;
                string Returned = " insert into CRMCampaignSchedule  (ScheduleCampaign, ScheduleTime, ScheduleOrder, SchedulePerc" +
                    ",UsrIns,TimIns) values (" + _Campaign + "," + dblTime + "," + _Order + "," + _Perc + "," + SysData.CurrentUser.ID + ",GetDate())";
                return Returned;
            }
        }
        public string EditStr
        {
            get
            {
                double dblTime = _Time.ToOADate() - 2;
                string Returned = " update  CRMCampaignSchedule  set ScheduleTime=" + dblTime +
", ScheduleOrder=" +_Order +
", SchedulePerc="+_Perc +
" where ScheduleID="+ID + " and ScheduleCampaign="+_Campaign;
                return Returned;
            }
        }
        public string DeleteStr
        {
            get
            {
                string Returned = " delete from CRMCampaignSchedule  "+
                    " where ScheduleID=" + ID + " and ScheduleCampaign=" + _Campaign + 
                    " and ScheduleExecuted = 0 ";
                
                return Returned;
            }
        }
        public static string SearchStr
        {
            get
            {
                string Returned = @"SELECT        ScheduleID, ScheduleCampaign, ScheduleTime, ScheduleOrder, SchedulePerc, ScheduleExecuted
FROM dbo.CRMCampaignSchedule";
                return Returned;
            }
        }
        #endregion
        #region Private Methods
        void SetData(DataRow objDr)
        {
            int.TryParse( objDr["ScheduleID"].ToString(),out _ID);
            int.TryParse(objDr["ScheduleCampaign"].ToString(),out _Campaign);
            DateTime.TryParse( objDr["ScheduleTime"].ToString(),out _Time);
            int.TryParse( objDr["ScheduleOrder"].ToString(),out _Order);
            double.TryParse(objDr["SchedulePerc"].ToString(),out _Perc);
            if(objDr.Table.Columns["ScheduleExecuted"]!= null)
           bool.TryParse(objDr["ScheduleExecuted"].ToString(),out _Executed);

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
            string strSql = SearchStr + " where (1=1) ";
            if (_Campaign != 0)
                strSql += " and ScheduleCampaign = "+ _Campaign;
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        #endregion

    }
}
