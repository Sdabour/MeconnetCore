using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpVision.CRM.CRMDataBase;
using System.Data;
namespace SharpVision.CRM.CRMBusiness
{
   public class CampaignScheduleBiz
    {
        #region Private Data
        CampaignScheduleDb _ScheduleDb;
        CampaignBiz _CampaignBiz;
        #endregion
        #region Constructors
        public CampaignScheduleBiz()
        {
            _ScheduleDb = new CampaignScheduleDb();
        }
        public CampaignScheduleBiz(DataRow objDr)
        {
            _ScheduleDb = new CampaignScheduleDb(objDr);
        }
        #endregion
        #region Public Properties
        public int ID
        {
            set { _ScheduleDb.ID = value; }
            get {
                if (_CampaignBiz == null)
                    _CampaignBiz = new CampaignBiz();
                return _ScheduleDb.ID; }
        }
        public CampaignBiz CampaignBiz
        {
            set { _CampaignBiz = value; }
            get {
                if (_CampaignBiz == null)
                    _CampaignBiz = new CampaignBiz();
                return _CampaignBiz; }
        }
        public DateTime Time
        {
            set { _ScheduleDb.Time = value; }
            get { return _ScheduleDb.Time; }
        }
        public int Order
        {
            set { _ScheduleDb.Order = value; }
            get { return _ScheduleDb.Order; }
        }
        public Double Perc
        {
            set { _ScheduleDb.Perc = value; }
            get { return _ScheduleDb.Perc; }
        }
        public bool Executed
        {
            set { _ScheduleDb.Executed = value; }
            get { return _ScheduleDb.Executed; }
        }
        #endregion
        #region Private Methods

        #endregion
        #region Public Methods
        public void Delete()
        {
            _ScheduleDb.Delete();
        }
        #endregion
    }
}
