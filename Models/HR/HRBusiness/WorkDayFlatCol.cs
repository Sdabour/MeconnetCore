using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpVision.HR.HRDataBase;
using System.Data;
using System.Collections;

namespace SharpVision.HR.HRBusiness
{
    public class WorkDayFlatCol:CollectionBase
    {

        #region Constructor
        public WorkDayFlatCol()
        {

        }
        public WorkDayFlatCol(bool blIsEmbty)
        {
            if (blIsEmbty)
                return;
            WorkDayFlatBiz objBiz = new WorkDayFlatBiz();
            

            WorkDayFlatDb objDb = new WorkDayFlatDb();

            DataTable dtTemp = objDb.Search();


            foreach (DataRow objDR in dtTemp.Rows)
            {
                objBiz = new WorkDayFlatBiz(objDR);
                Add(objBiz);
            }
        }

        #endregion
        #region Private Data

        #endregion
        #region Properties
        public WorkDayFlatBiz this[int intIndex]
        {
            get
            {
                return (WorkDayFlatBiz)this.List[intIndex];
            }
        }
        #endregion
        #region Private Method

        #endregion
        #region Public Method 
        public void Add(WorkDayFlatBiz objBiz)
        {
            List.Add(objBiz);
        }
        public WorkDayFlatCol GetCol(string strTemp)
        {
            WorkDayFlatCol Returned = new WorkDayFlatCol(true);
            foreach (WorkDayFlatBiz objBiz in this)
            {
                //if (objBiz.Name.CheckStr(strTemp))
                    Returned.Add(objBiz);
            }
            return Returned;
        }
        public DataTable GetTable()
        {
            DataTable Returned = new DataTable();
            Returned.Columns.AddRange(new DataColumn[] { new DataColumn("WorkDayID"), new DataColumn("ApplicantID"), new DataColumn("ApplicantAttendanceStatement"), new DataColumn("FurloughID"), new DataColumn("VacationID"), new DataColumn("MissionID"), new DataColumn("WorkDayDate", System.Type.GetType("System.DateTime")), new DataColumn("FormalTimeIn", System.Type.GetType("System.DateTime")), new DataColumn("FormalTimeOut", System.Type.GetType("System.DateTime")), new DataColumn("CheckIn", System.Type.GetType("System.DateTime")), new DataColumn("CheckOut", System.Type.GetType("System.DateTime")), new DataColumn("DayHourNo"), new DataColumn("IsAbsent", System.Type.GetType("System.Boolean")), new DataColumn("IsIgnoreDelay", System.Type.GetType("System.Boolean")), new DataColumn("WorkDayManualIgnoreDelay", System.Type.GetType("System.Boolean")), new DataColumn("WorkDayManualIgnoreDelayValue"), new DataColumn("TotalMinutes"), new DataColumn("FormalTotalMinutes"), new DataColumn("TimeDelay"), new DataColumn("EarlierOut"), new DataColumn("OverTime"), new DataColumn("IsVacancy", System.Type.GetType("System.Boolean")), new DataColumn("IsOverDay", System.Type.GetType("System.Boolean")), new DataColumn("IsAlterDay", System.Type.GetType("System.Boolean")), new DataColumn("IsMission", System.Type.GetType("System.Boolean")), new DataColumn("ISNonCountedDay", System.Type.GetType("System.Boolean")), new DataColumn("CommentError"), new DataColumn("IsVacationAccident", System.Type.GetType("System.Boolean")), new DataColumn("IsVacationCommon", System.Type.GetType("System.Boolean")), new DataColumn("IsVacationSick", System.Type.GetType("System.Boolean")) });
            DataRow objDr;
            foreach (WorkDayFlatBiz objBiz in this)
            {
                objDr = Returned.NewRow();
                objDr["WorkDayID"] = objBiz.ID;
                objDr["ApplicantID"] = objBiz.ApplicantID;
                objDr["ApplicantAttendanceStatement"] = objBiz.ApplicantAttendanceStatement;
                objDr["FurloughID"] = objBiz.FurloughID;
                objDr["VacationID"] = objBiz.VacationID;
                objDr["MissionID"] = objBiz.MissionID;
                objDr["WorkDayDate"] = objBiz.Date;
                objDr["FormalTimeIn"] = objBiz.FormalTimeIn;
                objDr["FormalTimeOut"] = objBiz.FormalTimeOut;
                objDr["CheckIn"] = objBiz.CheckIn;
                objDr["CheckOut"] = objBiz.CheckOut;
                objDr["DayHourNo"] = objBiz.DayHourNo;
                objDr["IsAbsent"] = objBiz.IsAbsent;
                objDr["IsIgnoreDelay"] = objBiz.IsIgnoreDelay;
                objDr["WorkDayManualIgnoreDelay"] = objBiz.ManualIgnoreDelay;
                objDr["WorkDayManualIgnoreDelayValue"] = objBiz.ManualIgnoreDelayValue;
                objDr["TotalMinutes"] = objBiz.TotalMinutes;
                objDr["FormalTotalMinutes"] = objBiz.FormalTotalMinutes;
                objDr["TimeDelay"] = objBiz.TimeDelay;
                objDr["EarlierOut"] = objBiz.EarlierOut;
                objDr["OverTime"] = objBiz.OverTime;
                objDr["IsVacancy"] = objBiz.IsVacancy;
                objDr["IsOverDay"] = objBiz.IsOverDay;
                objDr["IsAlterDay"] = objBiz.IsAlterDay;
                objDr["IsMission"] = objBiz.IsMission;
                objDr["ISNonCountedDay"] = objBiz.ISNonCountedDay;
                objDr["CommentError"] = objBiz.CommentError;
                objDr["IsVacationAccident"] = objBiz.IsVacationAccident;
                objDr["IsVacationCommon"] = objBiz.IsVacationCommon;
                objDr["IsVacationSick"] = objBiz.IsVacationSick;
                Returned.Rows.Add(objDr);
            }
            return Returned;
        }

        #endregion
    }
}
