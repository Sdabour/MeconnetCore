using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpVision.CRM.CRMDataBase;
using System.Data;
using SharpVision.Base.BaseBusiness;
namespace SharpVision.CRM.CRMBusiness
{
    public class CampaignScheduleCol : BaseCol
    {
        public CampaignScheduleCol()
        { }
        public CampaignScheduleBiz this[int intInde]
        {
            get
            {
                return (CampaignScheduleBiz)List[intInde];
            }
        }
        public void Add(CampaignScheduleBiz objBiz)
        {
            List.Add(objBiz);
        }
        public DataTable GetTable()
        {
            DataTable Returned = new DataTable();
            Returned.Columns.AddRange(new DataColumn[] { new DataColumn("ScheduleID")
                , new DataColumn("ScheduleCampaign"),
                new DataColumn("ScheduleTime",Type.GetType("System.DateTime")), new DataColumn("ScheduleOrder"), new DataColumn("SchedulePerc") });
            DataRow objDr;
            foreach (CampaignScheduleBiz objBiz in this)
            {
                objDr = Returned.NewRow();
                objDr["ScheduleID"] = objBiz.ID;
                objDr["ScheduleCampaign"] = objBiz.CampaignBiz.ID;
                objDr["ScheduleTime"] = objBiz.Time;
                objDr["ScheduleOrder"] = objBiz.Order;
                objDr["SchedulePerc"] = objBiz.Perc;
                Returned.Rows.Add(objDr);
            }
            return Returned;
        }
    }
}
