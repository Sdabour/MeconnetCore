using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using SharpVision.Base.BaseDataBase;
using SharpVision.HR.HRDataBase;
using SharpVision.SystemBase;
using SharpVision.COMMON.COMMONBusiness;

namespace SharpVision.HR.HRBusiness
{
    public class GlobalStatementCol : CollectionBase
    {
        #region Private Data
        Hashtable _StatementHash;
        #endregion
        #region Constructors
        public GlobalStatementCol(bool IsEmpty)
        { 
        }
        public GlobalStatementCol()
        {
            GlobalStatementDb _GlobalStatementDb = new GlobalStatementDb();
            DataTable dtGlobalStatement = _GlobalStatementDb.Search();
            GlobalStatementBiz objGlobalStatementBiz;

            foreach (DataRow DR in dtGlobalStatement.Rows)
            {
                objGlobalStatementBiz = new GlobalStatementBiz(DR);
                this.Add(objGlobalStatementBiz);
            }

        }
        public GlobalStatementCol(int intEstimationStatementID)
        {
            GlobalStatementDb _GlobalStatementDb = new GlobalStatementDb();
            _GlobalStatementDb.EstimationStatement = intEstimationStatementID;
            DataTable dtGlobalStatement = _GlobalStatementDb.Search();
            GlobalStatementBiz objGlobalStatementBiz;

            foreach (DataRow DR in dtGlobalStatement.Rows)
            {
                objGlobalStatementBiz = new GlobalStatementBiz(DR);
                this.Add(objGlobalStatementBiz);
            }

        }
        public GlobalStatementCol(bool blSearch,DateTime dtDateFrom, DateTime dtDateTo,bool blBaseSalary)
        {
            GlobalStatementDb _GlobalStatementDb = new GlobalStatementDb();
            _GlobalStatementDb.StatementSearch = blSearch;            
            _GlobalStatementDb.StatementDateFromSearch = dtDateFrom;
            _GlobalStatementDb.StatementDateToSearch = dtDateTo;
            _GlobalStatementDb.BaseSalarySearch = blBaseSalary;
            DataTable dtGlobalStatement = _GlobalStatementDb.Search();
            GlobalStatementBiz objGlobalStatementBiz;

            foreach (DataRow DR in dtGlobalStatement.Rows)
            {
                objGlobalStatementBiz = new GlobalStatementBiz(DR);
                this.Add(objGlobalStatementBiz);
            }

        }    
        #endregion
        #region Public Properties
        public string IDsStr
        {
            get
            {
                string Returned = "";
                foreach (GlobalStatementBiz objBiz in this)
                {
                    if (Returned != "")
                        Returned += ",";
                    Returned += objBiz.ID.ToString();
                }
                return Returned;
            }
        }
        #endregion
        #region Private Methods
        public virtual GlobalStatementBiz this[int intIndex]
        {
            get
            {
                return (GlobalStatementBiz)this.List[intIndex];
            }
        }

        public virtual void Add(GlobalStatementBiz objGlobalStatementBiz)
        {
            if (StatementHash[objGlobalStatementBiz.ID.ToString()] == null)
            {
                
                StatementHash.Add(objGlobalStatementBiz.ID.ToString(), objGlobalStatementBiz);
                this.List.Add(objGlobalStatementBiz);
            }
        }
        internal DataTable GetTable()
        {
            DataTable dtReturned = new DataTable("HRGlobalStatement");
            dtReturned.Columns.AddRange(new DataColumn[] { new DataColumn("StatementID"), new DataColumn("StatementDesc"), //new DataColumn("EstimationStatement")
                new DataColumn("StatementDate"),new DataColumn("StatementDateTo"),new DataColumn("BaseSalary"),new DataColumn("StatementWeekDayNo"),new DataColumn("StatementDayHourNo") 
            ,new DataColumn("StatementBonusDesc"),new DataColumn("StatementBonusValue"),new DataColumn("StatementIncreasePerc")
            ,new DataColumn("InvolveLoan"),new DataColumn("InvolveAttendance"),new DataColumn("InvolvePenalty"),new DataColumn("InvolveService"),new DataColumn("AttendanceStatement")});     
            DataRow objDr;
            foreach (GlobalStatementBiz objBiz in this)
            {
                objDr = dtReturned.NewRow();
                objDr["StatementID"] = objBiz.ID;
                //objDr["EstimationStatement"] = objBiz.EstimationStatementBiz.ID;

                objDr["AttendanceStatement"] = objBiz.AttendanceStatementBiz.ID;
                objDr["StatementDesc"] = objBiz.StatementDesc;
                objDr["StatementDate"] = objBiz.StatementDate;
                objDr["StatementDateTo"] = objBiz.StatementDateTo;
                objDr["BaseSalary"] = objBiz.BaseSalary;
                objDr["StatementWeekDayNo"] = objBiz.WeekDayNo;
                objDr["StatementDayHourNo"] = objBiz.DayHourNo;

                objDr["StatementBonusDesc"] = objBiz.BonusDesc;
                objDr["StatementBonusValue"] = objBiz.BonusValue;
                objDr["StatementIncreasePerc"] = objBiz.IncreasePerc;
                objDr["InvolveLoan"] = objBiz.InvolveLoan;
                objDr["InvolveAttendance"] = objBiz.InvolveAttendance;
                objDr["InvolvePenalty"] = objBiz.InvolvePenalty;
                objDr["InvolveService"] = objBiz.InvolveService;
                dtReturned.Rows.Add(objDr);
            }
            return dtReturned;

        }
        public ArrayList ArrYear
        {
            get
            {
                ArrayList arrYear = new ArrayList();
                foreach (GlobalStatementBiz objBiz in this)
                {
                    if (!CheckExistValInArr(arrYear, objBiz.StatementDateTo.Year))
                        arrYear.Add(objBiz.StatementDateTo.Year);
                }
                return arrYear;
            }
        }

        public Hashtable StatementHash
        { get
            {
                if (_StatementHash == null) _StatementHash = new Hashtable();
                return _StatementHash;
            }
            set => _StatementHash = value; }

        bool CheckExistValInArr(ArrayList arr, int intVal)
        {
            if (arr.Count == 0)
                return false;
            for (int i = 0; i < arr.Count; i++)
            {
                if (int.Parse(arr[i].ToString()) == intVal)
                    return true;
            }
            return false;
        }
        #endregion
        #region Public Methods

        #endregion
    }
}
