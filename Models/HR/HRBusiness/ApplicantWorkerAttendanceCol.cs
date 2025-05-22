using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using SharpVision.Base.BaseDataBase;
using SharpVision.Base.BaseBusiness;
using SharpVision.HR.HRDataBase;
using SharpVision.SystemBase;
using SharpVision.COMMON.COMMONBusiness;

namespace SharpVision.HR.HRBusiness
{
    public class ApplicantWorkerAttendanceCol : CollectionBase
    {
        #region Private Data

        #endregion
        #region Constructors
        public ApplicantWorkerAttendanceCol(bool IsEmpty)
        { 
        }
        public ApplicantWorkerAttendanceCol()
        {
            
        }
        public ApplicantWorkerAttendanceCol(int intApplicantID)
        {
            ApplicantWorkerAttendanceDb _ApplicantWorkerAttendanceDb = new ApplicantWorkerAttendanceDb();
            _ApplicantWorkerAttendanceDb.Applicant = intApplicantID;
            DataTable dtApplicantWorkerAttendance = _ApplicantWorkerAttendanceDb.Search();
            ApplicantWorkerAttendanceBiz objApplicantWorkerAttendanceBiz;
            foreach (DataRow DR in dtApplicantWorkerAttendance.Rows)
            {
                objApplicantWorkerAttendanceBiz = new ApplicantWorkerAttendanceBiz(DR);
                this.Add(objApplicantWorkerAttendanceBiz);
            }
        }
        public ApplicantWorkerAttendanceCol(bool blIsProcessed, int intApplicantID, bool blOrderDesc)
        {
            ApplicantWorkerAttendanceDb _ApplicantWorkerAttendanceDb = new ApplicantWorkerAttendanceDb();
            _ApplicantWorkerAttendanceDb.Applicant = intApplicantID;
            _ApplicantWorkerAttendanceDb.OrderDescSearch = blOrderDesc;
            _ApplicantWorkerAttendanceDb.HasAttendanceStatement = blIsProcessed;
            DataTable dtApplicantWorkerAttendance = _ApplicantWorkerAttendanceDb.Search();
            ApplicantWorkerAttendanceBiz objApplicantWorkerAttendanceBiz;
            foreach (DataRow DR in dtApplicantWorkerAttendance.Rows)
            {
                objApplicantWorkerAttendanceBiz = new ApplicantWorkerAttendanceBiz(DR);
                this.Add(objApplicantWorkerAttendanceBiz);
            }
        }
        public ApplicantWorkerAttendanceCol(ApplicantWorkerBiz objApplicantWorkerBiz, DateTime dtFrom, DateTime dtTo)
        {
            ApplicantWorkerAttendanceDb _ApplicantWorkerAttendanceDb = new ApplicantWorkerAttendanceDb();
            _ApplicantWorkerAttendanceDb.Applicant = objApplicantWorkerBiz.ID;
            _ApplicantWorkerAttendanceDb.DateSearch = true;
            _ApplicantWorkerAttendanceDb.DateFromSearch = dtFrom;
            _ApplicantWorkerAttendanceDb.DateToSearch = dtTo;

            DataTable dtApplicantWorkerAttendance = _ApplicantWorkerAttendanceDb.Search();
            ApplicantWorkerAttendanceBiz objApplicantWorkerAttendanceBiz;
            foreach (DataRow DR in dtApplicantWorkerAttendance.Rows)
            {
                objApplicantWorkerAttendanceBiz = new ApplicantWorkerAttendanceBiz(DR);
                this.Add(objApplicantWorkerAttendanceBiz);
            }
        }
        public ApplicantWorkerAttendanceCol(bool blIsProcessed,ApplicantWorkerBiz objApplicantWorkerBiz, DateTime dtFrom, DateTime dtTo,bool blOrderDesc)
        {
            ApplicantWorkerAttendanceDb _ApplicantWorkerAttendanceDb = new ApplicantWorkerAttendanceDb();
            _ApplicantWorkerAttendanceDb.Applicant = objApplicantWorkerBiz.ID;
            _ApplicantWorkerAttendanceDb.DateSearch = true;
            _ApplicantWorkerAttendanceDb.DateFromSearch = dtFrom;
            _ApplicantWorkerAttendanceDb.DateToSearch = dtTo;
            _ApplicantWorkerAttendanceDb.OrderDescSearch = blOrderDesc;
            _ApplicantWorkerAttendanceDb.HasAttendanceStatement = blIsProcessed;
            DataTable dtApplicantWorkerAttendance = _ApplicantWorkerAttendanceDb.Search();
            ApplicantWorkerAttendanceBiz objApplicantWorkerAttendanceBiz;
            foreach (DataRow DR in dtApplicantWorkerAttendance.Rows)
            {
                objApplicantWorkerAttendanceBiz = new ApplicantWorkerAttendanceBiz(DR);
                this.Add(objApplicantWorkerAttendanceBiz);
            }
        }
        public ApplicantWorkerAttendanceCol(ApplicantWorkerCol objApplicantWorkerCol, DateTime dtFrom, DateTime dtTo)
        {

            ApplicantWorkerAttendanceDb _ApplicantWorkerAttendanceDb = new ApplicantWorkerAttendanceDb();
            _ApplicantWorkerAttendanceDb.ApplicantIDs = objApplicantWorkerCol.IDs;
            _ApplicantWorkerAttendanceDb.DateSearch = true;
            _ApplicantWorkerAttendanceDb.DateFromSearch = dtFrom;
            _ApplicantWorkerAttendanceDb.DateToSearch = dtTo;

            DataTable dtApplicantWorkerAttendance = _ApplicantWorkerAttendanceDb.Search();
            ApplicantWorkerAttendanceBiz objApplicantWorkerAttendanceBiz;
            foreach (DataRow DR in dtApplicantWorkerAttendance.Rows)
            {
                objApplicantWorkerAttendanceBiz = new ApplicantWorkerAttendanceBiz(DR);
                this.Add(objApplicantWorkerAttendanceBiz);
            }
        }
        #endregion
        #region Public Properties
        public string IDsStr
        {
            get
            {
                string Returned = "";
                foreach (ApplicantWorkerAttendanceBiz objBiz in this)
                {
                    if (Returned != "")
                        Returned += ",";
                    Returned += objBiz.ApplicantAttendanceID.ToString();
                }
                return Returned;
            }
        }
        public int MaxIndex
        {
            get
            {
                int Returned = 0;
                for (int intIndex = 0;intIndex < Count;intIndex++)
                {
                    if (this[intIndex].AttendanceTime > this[Returned].AttendanceTime)
                        Returned = intIndex;
 
                }
                return Returned;
            }
        }
        public int MinIndex
        {
            get
            {
                int Returned = 0;
                for (int intIndex = 0; intIndex < Count; intIndex++)
                {
                    if (this[intIndex].AttendanceTime < this[Returned].AttendanceTime)
                        Returned = intIndex;

                }
                return Returned;
            }
        }
        public ApplicantWorkerCol ApplicantCol
        {
            get
            {
                ApplicantWorkerCol Returned = new ApplicantWorkerCol(true);
                foreach (ApplicantWorkerAttendanceBiz objBiz in this)
                {
                    Returned.Add(objBiz.ApplicantWorkerBiz);
                }
                return Returned;
            }
        }

        #endregion
        #region Private Methods
        public virtual ApplicantWorkerAttendanceBiz this[int intIndex]
        {
            get
            {
                return (ApplicantWorkerAttendanceBiz)this.List[intIndex];
            }
            set
            {
                List[intIndex] = value;
            }
        }

        public virtual void Add(ApplicantWorkerAttendanceBiz objApplicantWorkerAttendanceBiz)
        {

            bool blIsFound = false;
            foreach (ApplicantWorkerAttendanceBiz objTemp in this)
            {
                if (objTemp.ApplicantAttendanceID == objApplicantWorkerAttendanceBiz.ApplicantAttendanceID &&
                    objTemp.ApplicantAttendanceID != 0)
                {
                    blIsFound = true;
                    break;
                }
            }
            if(!blIsFound)
              this.List.Add(objApplicantWorkerAttendanceBiz);
        }
        public  void Add(ApplicantWorkerAttendanceCol objApplicantWorkerAttendanceCol)
        {

            foreach (ApplicantWorkerAttendanceBiz objBiz in objApplicantWorkerAttendanceCol)
            {
                Add(objBiz);
            }
        }
        
        internal DataTable GetTable1()
        {
            DataTable dtReturned = new DataTable("HRApplicantWorkerAttendance");
            dtReturned.Columns.AddRange(new DataColumn[] { new DataColumn("ApplicantAttendanceID"), new DataColumn("Applicant"), 
                new DataColumn("AttendanceTime"),new DataColumn("AttandanceType"),new DataColumn("AttendanceStatement")});
            DataRow objDr;
            foreach (ApplicantWorkerAttendanceBiz objBiz in this)
            {
                objDr = dtReturned.NewRow();
                objDr["ApplicantAttendanceID"] = objBiz.ApplicantAttendanceID;
                objDr["Applicant"] = objBiz.ApplicantWorkerBiz.ID;
                objDr["AttendanceTime"] = objBiz.AttendanceTime;
                objDr["AttandanceType"] = objBiz.AttandanceType;
                //if(objBiz.AttendanceStatementBiz!= null)
                objDr["AttendanceStatement"] = objBiz.AttendanceStatement;                               
                dtReturned.Rows.Add(objDr);
            }
            return dtReturned;

        }
        public DataTable GetTable()
        {
            DataTable dtReturned = new DataTable("HRApplicantWorkerAttendance");
            dtReturned.Columns.AddRange(new DataColumn[] { new DataColumn("ApplicantAttendanceID"), new DataColumn("Applicant"), 
                new DataColumn("AttendanceTime"),
                new DataColumn("AttandanceType",Type.GetType("System.Boolean")),
                new DataColumn("AttendanceStatement")});
            DataRow objDr;
            foreach (ApplicantWorkerAttendanceBiz objBiz in this)
            {
                objDr = dtReturned.NewRow();
                objDr["ApplicantAttendanceID"] = objBiz.ApplicantAttendanceID;
                objDr["Applicant"] = objBiz.ApplicantWorkerBiz.ID;
                objDr["AttendanceTime"] = objBiz.AttendanceTime;
                objDr["AttandanceType"] = objBiz.AttandanceType == 1 ;
                //if(objBiz.AttendanceStatementBiz!= null)
                objDr["AttendanceStatement"] = objBiz.AttendanceStatement;
                dtReturned.Rows.Add(objDr);
            }
            return dtReturned;

        }

        public DataTable GetExportTable()
        {
            DataTable dtReturned = new DataTable("HRApplicantWorkerAttendance");
            dtReturned.Columns.AddRange(new DataColumn[] 
            { new DataColumn("Department"),new DataColumn("Job"), new DataColumn("ApplicantCode"), new DataColumn("ApplicantName"),
                new DataColumn("AttendanceTime"),
                new DataColumn("AttandanceType")
                });
            DataRow objDr;
            foreach (ApplicantWorkerAttendanceBiz objBiz in this)
            {
                objDr = dtReturned.NewRow();
                objDr["Department"] = objBiz.ApplicantWorkerBiz.CurrentSubSectorBiz.SubSectorBiz.SectorName;
                objDr["Job"] = objBiz.ApplicantWorkerBiz.CurrentSubSectorBiz.JobNatureTypeBiz.Name;
                objDr["ApplicantCode"] = objBiz.ApplicantWorkerBiz.Code;
                objDr["ApplicantName"] = objBiz.ApplicantWorkerBiz.Name;
                objDr["AttendanceTime"] = objBiz.AttendanceTime;
                objDr["AttandanceType"] = objBiz.AttandanceType == 1 ?"I" : "O";
                //if(objBiz.AttendanceStatementBiz!= null)
               // objDr["AttendanceStatement"] = objBiz.AttendanceStatement;
                dtReturned.Rows.Add(objDr);
            }
            return dtReturned;

        }
        #endregion
        #region Public Methods
        public ApplicantWorkerAttendanceCol GetAttendanceCol(int intApplicantID, DateTime dtFrom, DateTime dtTo)
        {
            ApplicantWorkerAttendanceDb _ApplicantWorkerAttendanceDb = new ApplicantWorkerAttendanceDb();
            _ApplicantWorkerAttendanceDb.Applicant = intApplicantID;
            _ApplicantWorkerAttendanceDb.DateSearch = true;
            _ApplicantWorkerAttendanceDb.DateFromSearch = dtFrom;
            _ApplicantWorkerAttendanceDb.DateToSearch = dtTo;
            ApplicantWorkerAttendanceCol ReturnCol = new ApplicantWorkerAttendanceCol(true);
            DataTable dtApplicantWorkerAttendance = _ApplicantWorkerAttendanceDb.Search();
            ApplicantWorkerAttendanceBiz objApplicantWorkerAttendanceBiz;
            foreach (DataRow DR in dtApplicantWorkerAttendance.Rows)
            {
                objApplicantWorkerAttendanceBiz = new ApplicantWorkerAttendanceBiz(DR);
                ReturnCol.Add(objApplicantWorkerAttendanceBiz);
            }
            return ReturnCol;
        }
        public int GetIndex(int intID)
        {
            int intIndex = 0;
            foreach (ApplicantWorkerAttendanceBiz objBiz in this)
            {
                if (objBiz.ApplicantAttendanceID ==intID)
                {
                    return intIndex;
                }
                intIndex++;
            }
            return -1;
        }
        public int GetIndex(DateTime dtAttendanceTime)
        {
            int intIndex = 0;
            foreach (ApplicantWorkerAttendanceBiz objBiz in this)
            {
                if (objBiz.AttendanceTime  == dtAttendanceTime)
                {
                    return intIndex;
                }
                intIndex++;
            }
            return -1;
        }
       public  ApplicantWorkerAttendanceCol GetCol(DateTime dtTemp)
        {
            ApplicantWorkerAttendanceCol Returned = new ApplicantWorkerAttendanceCol(true);
            foreach (ApplicantWorkerAttendanceBiz objBiz in this)
            {
                if (objBiz.AttendanceTime.DayOfYear == dtTemp.DayOfYear)
                    Returned.Add(objBiz);
            }
            return Returned;
 
        }
        //public ApplicantWorkerAttendanceCol GetCol(DateTime dtTemp,int intDirection)
        //{
        //    ApplicantWorkerAttendanceCol Returned = new ApplicantWorkerAttendanceCol(true);
        //    DateTime dtDate;
        //    foreach (ApplicantWorkerAttendanceBiz objBiz in this)
        //    {
        //       // if (intDirection == 0)
        //            dtDate = objBiz.AttendanceTime.AddHours(-4);
        //        //else
        //        //    dtDate = objBiz.AttendanceTime;
        //        //if (objBiz.AttendanceTime.DayOfYear == dtTemp.DayOfYear && 
        //        //    objBiz.AttandanceType == intDirection)
        //        if (dtDate.DayOfYear == dtTemp.DayOfYear &&
        //            objBiz.AttandanceType == intDirection)
        //            Returned.Add(objBiz);
        //    }
        //    return Returned;

        //}
        public ApplicantWorkerAttendanceCol GetCol(ApplicantWorkDayBiz objWorkDayBiz, int intDirection)
        {
            ApplicantWorkerAttendanceCol Returned = new ApplicantWorkerAttendanceCol(true);
            ApplicantWorkDayBiz objNextWorkDay = new ApplicantWorkDayBiz();
            objNextWorkDay.Index = -1;
            if (objWorkDayBiz.WorkDayCol.Count > objWorkDayBiz.Index + 1)
                objNextWorkDay = objWorkDayBiz.WorkDayCol[objWorkDayBiz.Index + 1];
            DateTime dtAttendace;
            double dblDate, dblAttendace;
            DateTime dtDate = objWorkDayBiz.WorkDay;
           
            dblDate = SysUtility.Approximate(dtDate.ToOADate() - 2, 1, ApproximateType.Down);
            double dblDateIn = SysUtility.Approximate(objWorkDayBiz.FormalTimeIn.ToOADate() - 2, 1, ApproximateType.Down);
            double dblDateOut = SysUtility.Approximate(objWorkDayBiz.FormalTimeOut.ToOADate() - 2, 1, ApproximateType.Down);
            int intDiff = objWorkDayBiz.FormalTimeOut.Hour < objWorkDayBiz.FormalTimeIn.Hour ? 0: 0;
            int intIndex = 0;
            foreach (ApplicantWorkerAttendanceBiz objBiz in this)
            {
                intIndex++;
                if (objBiz.IsVisited )
                    continue;

            
                dtAttendace = objBiz.AttendanceTime.AddHours(-1 * intDiff);
                dblAttendace= SysUtility.Approximate(dtAttendace.ToOADate() - 2, 1, ApproximateType.Down);
                //if (dblAttendace != dblDateIn && dblAttendace != dblDateOut)
                //    continue;
                if (((intDirection == 1 &&  dblAttendace == dblDateIn && objBiz.AttandanceType == intDirection)||
                    (intDirection == 0 &&  dblAttendace == dblDateOut && objBiz.AttandanceType == intDirection)) &&
                     (Returned.Count == 0 || dblDateIn== dblDateOut || objNextWorkDay.Index ==-1 || 
                     Math.Abs(objNextWorkDay.FormalTimeIn.Hour -objBiz.AttendanceTime.Hour) > 
                     Math.Abs(objWorkDayBiz.FormalTimeOut.Hour -objBiz.AttendanceTime.Hour)))
                {
                    objBiz.IsVisited = true;
                    Returned.Add(objBiz);
                }
                else if (Returned.Count == 0 && objBiz.AttandanceType == intDirection &&
                    intDirection == 0 &&
                    dblAttendace - dblDate == 1 &&
                    objBiz.AttendanceTime.Hour < objWorkDayBiz.FormalTimeIn.Hour - 1)
                {
                    objBiz.IsVisited = true;
                    Returned.Add(objBiz);
                }
                else if (Returned.Count == 0 && objBiz.AttandanceType != intDirection &&
                  dblAttendace > dblDate)
                {
                    if (objNextWorkDay.Index != -1 &&
                          dblAttendace >= dblDate && dblAttendace - dblDate <= 1 &&
                        Math.Abs(objWorkDayBiz.FormalTimeOut.Hour - objBiz.AttendanceTime.Hour) < Math.Abs(objNextWorkDay.FormalTimeIn.Hour - objBiz.AttendanceTime.Hour))
                    {
                        objBiz.IsVisited = true;
                        Returned.Add(objBiz);
                    }
                    else if (dblAttendace>dblDateOut)
                        break;
                }
                else if(dblAttendace>=dblDateOut )
                     break;
              
            }
            
            return Returned;

        }
        public ApplicantWorkerAttendanceCol GetColLastCopy(ApplicantWorkDayBiz objWorkDayBiz, int intDirection)
        {
            ApplicantWorkerAttendanceCol Returned = new ApplicantWorkerAttendanceCol(true);

            DateTime dtTemp;
            double dblDate, dblTemp;
            DateTime dtDate = objWorkDayBiz.WorkDay;
            dblDate = SysUtility.Approximate(dtDate.ToOADate() - 2, 1, ApproximateType.Down);
            int intDiff = objWorkDayBiz.FormalTimeOut.Hour < objWorkDayBiz.FormalTimeIn.Hour ? 0 : 0;
            int intIndex = 0;
            foreach (ApplicantWorkerAttendanceBiz objBiz in this)
            {
                intIndex++;
                if (objBiz.IsVisited)
                    continue;


                dtTemp = objBiz.AttendanceTime.AddHours(-1 * intDiff);
                dblTemp = SysUtility.Approximate(dtTemp.ToOADate() - 2, 1, ApproximateType.Down);
                if ((dblDate == dblTemp ||
                    (objWorkDayBiz.FormalTimeIn.Hour > objWorkDayBiz.FormalTimeOut.Hour && dblDate == dblTemp - 1)) &&
                    objBiz.AttandanceType == intDirection)
                {
                    objBiz.IsVisited = true;
                    Returned.Add(objBiz);
                }
                else if (Returned.Count == 0 && objBiz.AttandanceType == intDirection &&
                    intDirection == 0 &&
                    dblTemp - dblDate == 1 &&
                    objBiz.AttendanceTime.Hour < objWorkDayBiz.FormalTimeIn.Hour - 1)
                {
                    objBiz.IsVisited = true;
                    Returned.Add(objBiz);
                }
                else if (Returned.Count == 0 && objBiz.AttandanceType != intDirection &&
                  dblTemp > dblDate)
                    break;

            }

            return Returned;

        }
        public ApplicantWorkerAttendanceCol GetCol(ref ApplicantWorkDayCol objWorkDayCol,int intWorkdayIndex, int intDirection)
        {
            ApplicantWorkDayBiz objWorkDayBiz = objWorkDayCol[intWorkdayIndex];
            ApplicantWorkerAttendanceCol Returned = new ApplicantWorkerAttendanceCol(true);
            DateTime dtTemp;
            double dblDate, dblTemp;
            DateTime dtDate = objWorkDayBiz.WorkDay;
            dblDate = SysUtility.Approximate(dtDate.ToOADate() - 2, 1, ApproximateType.Down);
            int intDiff = objWorkDayBiz.FormalTimeOut.Hour < objWorkDayBiz.FormalTimeIn.Hour ? 0 : 0;
            int intIndex = 0;
            foreach (ApplicantWorkerAttendanceBiz objBiz in this)
            {
                intIndex++;
                if (objBiz.IsVisited)
                    continue;


                dtTemp = objBiz.AttendanceTime.AddHours(-1 * intDiff);
                dblTemp = SysUtility.Approximate(dtTemp.ToOADate() - 2, 1, ApproximateType.Down);
                if ((dblDate == dblTemp || (objWorkDayBiz.FormalTimeIn.Day <objWorkDayBiz.FormalTimeOut.Day && dblDate==dblTemp-1) )&& objBiz.AttandanceType == intDirection)
                {
                    objBiz.IsVisited = true;
                    Returned.Add(objBiz);
                }
                else if (Returned.Count == 0 && objBiz.AttandanceType == intDirection &&
                    intDirection == 0 &&
                    dblTemp - dblDate == 1 &&
                    objBiz.AttendanceTime.Hour < objWorkDayBiz.FormalTimeIn.Hour - 1)
                {
                    objBiz.IsVisited = true;
                    Returned.Add(objBiz);
                }
                else if (Returned.Count == 0 && objBiz.AttandanceType != intDirection &&
                  dblTemp > dblDate)
                    break;

            }

            return Returned;

        }
        public ApplicantWorkerAttendanceCol GetCol1(ApplicantWorkDayBiz objWorkDayBiz, int intDirection)
        {
            ApplicantWorkerAttendanceCol Returned = new ApplicantWorkerAttendanceCol(true);
            DateTime dtDate;
            DateTime dtTemp = objWorkDayBiz.WorkDay;
            int intDiff = objWorkDayBiz.FormalTimeOut.Hour < objWorkDayBiz.FormalTimeIn.Hour ? 10 : 6;
            foreach (ApplicantWorkerAttendanceBiz objBiz in this)
            {
                dtDate = objBiz.AttendanceTime.AddHours(-1 * intDiff);
                if (SysUtility.Approximate(objWorkDayBiz.FormalTimeOut.ToOADate(), 1, ApproximateType.Down) ==
                    SysUtility.Approximate(objWorkDayBiz.FormalTimeIn.ToOADate(), 1, ApproximateType.Down) ||
                    intDirection == 1)
                {
                    if (dtDate.DayOfYear == dtTemp.DayOfYear &&
                        objBiz.AttandanceType == intDirection)
                        Returned.Add(objBiz);
                }
                else if (intDirection == 0 &&
                    SysUtility.Approximate(objWorkDayBiz.FormalTimeOut.ToOADate(), 1, ApproximateType.Down) >
                    SysUtility.Approximate(objWorkDayBiz.FormalTimeIn.ToOADate(), 1, ApproximateType.Down))
                {
                    dtDate = objBiz.AttendanceTime.AddHours(-12);
                    //if (dtDate.DayOfYear == dtTemp.DayOfYear &&
                    //    objBiz.AttandanceType == intDirection)
                    if (SysUtility.Approximate(dtDate.ToOADate(), 1, ApproximateType.Down) ==
                        SysUtility.Approximate(dtTemp.ToOADate(), 1, ApproximateType.Down) &&
                       objBiz.AttandanceType == intDirection)
                        Returned.Add(objBiz);
                }
            }
            //if(Returned.Count ==1 && Returned[0].AttandanceType == 1 && Returned[0].AttendanceTime)
            return Returned;

        }
        public void RemoveByID(int intID)
        {
            int intIndex = GetIndex(intID);
            if(intIndex != -1)
              RemoveAt(intIndex);
        }
        public void EditAttendanceStatement(int intStatementID)
        {
            ApplicantWorkerAttendanceDb objDb = new ApplicantWorkerAttendanceDb();
            objDb.AttendanceStatement = intStatementID;
            objDb.IDsStr = IDsStr;
            objDb.EditAttendanceStatement();


        }
        public ApplicantWorkerAttendanceCol _BufferCheckInCol;
        public ApplicantWorkerAttendanceCol _BufferCheckOutCol;
        public ApplicantWorkerAttendanceCol BufferCheckInCol
        {
            get
            {
                if (_BufferCheckInCol == null)
                {
                    _BufferCheckInCol = new ApplicantWorkerAttendanceCol(true);
                    DateTime dtDate;
                    foreach (ApplicantWorkerAttendanceBiz objBiz in this)
                    {
                        if (objBiz.AttandanceType == 1)
                            _BufferCheckInCol.Add(objBiz);
                    }                   
                }
                return _BufferCheckInCol;
            }
        }
        public ApplicantWorkerAttendanceCol BufferCheckOutCol
        {
            get
            {
                if (_BufferCheckOutCol == null)
                {
                    _BufferCheckOutCol = new ApplicantWorkerAttendanceCol(true);
                    DateTime dtDate;
                    foreach (ApplicantWorkerAttendanceBiz objBiz in this)
                    {
                        if (objBiz.AttandanceType == 0)
                            _BufferCheckOutCol.Add(objBiz);
                    }
                }
                return _BufferCheckOutCol;
            }
        }
        public ApplicantWorkerAttendanceCol GetCheckCol(int intDirection)
        {
            ApplicantWorkerAttendanceCol Returned = new ApplicantWorkerAttendanceCol(true);
            DateTime dtDate;
            foreach (ApplicantWorkerAttendanceBiz objBiz in this)
            {               
               if (objBiz.AttandanceType == intDirection)
                    Returned.Add(objBiz);
            }
            return Returned;
        }
        public ApplicantWorkerAttendanceCol ReorderCheckCol()
        {
            DataTable dtTemp = new DataTable();
            dtTemp.Columns.AddRange(new DataColumn[]{ new DataColumn("Order"),new DataColumn( "Time",Type.GetType("System.DateTime"))});
            int intOrder = 0;
            DataRow objDr;
            foreach (ApplicantWorkerAttendanceBiz objBiz in this)
            {
                objDr = dtTemp.NewRow();
                objDr["Order"] = intOrder;
                objDr["Time"] = objBiz.AttendanceTime;
                dtTemp.Rows.Add(objDr);
                intOrder++;
            }
            ApplicantWorkerAttendanceCol Returned = new ApplicantWorkerAttendanceCol(true);
            DataRow[] arrDr = dtTemp.Select("", "Time asc");
            foreach (DataRow objDr1 in arrDr)
            { 
                Returned.Add( this[int.Parse(objDr1["Order"].ToString())] );

            }
            return Returned;

        }
        public void ReSetVisted()
        {
            foreach (ApplicantWorkerAttendanceBiz objBiz in this)
            {
                objBiz.IsVisited = false;
            }
        }
        #endregion
    }
}
