using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.SystemBase;
namespace SharpVision.HR.HRDataBase
{
    public class AttendanceTimeApplicantDb : AttendanceTimeDb
    {
        #region Private Data
        protected int _AttendanceApplicant;
        protected int _ImageID;
        protected int _ShiftID;
        DateTime _StartDateSearch;
        DateTime _EndDateSearch;
        bool _DateSearch;
        string _ApplicantIDs;
        #endregion
        #region Constructors
        public AttendanceTimeApplicantDb()
        {
            _Periority = 1;
        }
        public AttendanceTimeApplicantDb(DataRow objDr) : base(objDr)
        {
            try
            {
                _Periority = 1;
               
                _AttendanceApplicant = int.Parse(objDr["AttendanceApplicant"].ToString());
                if (objDr["ImageID"].ToString() == "")
                    return;
                _ImageID = int.Parse(objDr["ImageID"].ToString());
                if (objDr["Shift"].ToString() == "")
                    return;
                _ShiftID = int.Parse(objDr["Shift"].ToString());
            }
            catch
            { }
        }
        #endregion
        #region Public Properties
        public int AttendanceApplicant
        {
            set
            {
                _AttendanceApplicant = value;
            }
            get
            {
                return _AttendanceApplicant;
            }
        }
        public int ImageID 
        {
            set
            {
                _ImageID = value;
            }
            get
            {
                return _ImageID;
            }
        }
        public int ShiftID
        {
            set
            {
                _ShiftID = value;
            }
            get
            {
                return _ShiftID;
            }
        }
        public DateTime StartDateSearch
        {
            set
            {
                _StartDateSearch = value;
            }            
        }
        public DateTime EndDateSearch
        {
            set
            {
                _EndDateSearch = value;
            }
        }
        public bool DateSearch 
        {
            set
            {
                _DateSearch = value;
            }
        }
        public string ApplicantIDs 
        {
            set
            {
                _ApplicantIDs = value;
            }
        }
        public string AddStr
        {
            get
            {              

                string ReturnedStr = " INSERT INTO HRAttendanceTimeApplicant" +
                                     " (AttendanceTimeID,AttendanceApplicant,ImageID,Shift)" +
                                     " VALUES (" + _ID + "," + _AttendanceApplicant + "," + _ImageID + ","+ _ShiftID +")";
                return ReturnedStr;
            }
        }
        public string EditStr
        {
            get
            {
               

                string ReturnedStr = " UPDATE    HRAttendanceTimeApplicant" +
                                     " SET AttendanceApplicant =" + _AttendanceApplicant + "" +
                                     " ,ImageID = " + _ImageID + " " +
                                     " ,Shift = " + _ShiftID + " " +
                                     " Where  (AttendanceTimeID = " + _ID + ")";
                return ReturnedStr;
            }
        }
        public string DeleteStr
        {
            get
            {
                string ReturnedStr = " DELETE FROM HRAttendanceTimeApplicant" +
                                     " WHERE     (AttendanceTimeID = " + _ID + ")";
                return ReturnedStr;
            }
        }
        public override string StrSearch
        {
            get
            {
                string Returned = SearchStr;
                //double dblStart, dblEnd;
                //dblStart = (double)((int)(_StartDate.ToOADate() - 2));
                //dblEnd = (double)((int)_EndDate.ToOADate() - 1);

                //Returned += " where AttendanceTimeStartDate<= " + dblStart +
                //    " and  (AttendanceTimeEndDate is null or  AttendanceTimeEndDate >= " + dblStart + ") ";
                //if (_WorkerID != 0)
                //    Returned += " and ApplicantWorkerTable.ApplicantID=" + _WorkerID;
                return Returned;
            }
        }
        bool _IgnoreApplicant;
       public bool IgnoreApplicant
        { set => _IgnoreApplicant = value; }
        public  string SearchStr
        {
            get
            {
                string ReturnedStr = " SELECT     HRAttendanceTimeApplicant.AttendanceTimeID,HRAttendanceTimeApplicant.AttendanceApplicant,HRAttendanceTimeApplicant.ImageID," +
                                     " HRAttendanceTimeApplicant.Shift";
               if(!_IgnoreApplicant)
                ReturnedStr += ",ApplicantWorkerTable.*";
                 
               ReturnedStr+= ",ShiftTable.*" +
                                     " FROM         HRAttendanceTimeApplicant";
             if(!_IgnoreApplicant)
                ReturnedStr += " Left Outer Join (" + new ApplicantWorkerDb().ShortSearchStr + ") as ApplicantWorkerTable On ApplicantWorkerTable.ApplicantID = HRAttendanceTimeApplicant.AttendanceApplicant ";

                                    ReturnedStr+= " Left Outer join (" + ShiftDb.SearchStr + ") As ShiftTable ON ShiftTable.ShiftID = HRAttendanceTimeApplicant.Shift";
                return ReturnedStr;
            }
        }
        #endregion
        #region Private Methods
       
        #endregion
        #region Public Methods
        public override void Add()
        {
            base.Add();
            SysData.SharpVisionBaseDb.ExecuteNonQuery(AddStr);            
        }
        public override void Edit()
        {
            base.Edit();
            SysData.SharpVisionBaseDb.ExecuteNonQuery(EditStr);
            
        }
        public override void Delete()
        {
            base.Delete();
           // SysData.SharpVisionBaseDb.ExecuteNonQuery(DeleteStr);
           
        }
        public override DataTable Search()
        {
            string StrSql = AttendanceTimeDb.SearchStr + " Where HRAttendanceTime.Dis is null and  AttendancePeriority =1 and AttendanceApplicant  is not null ";
            if (_AttendanceApplicant != 0)
                StrSql = StrSql + " And AttendanceTimeApplicantTable.AttendanceApplicant = " + _AttendanceApplicant + "";
            if (_DateSearch == true)
            {
                double dblEndDate = _EndDateSearch.ToOADate() - 2;
                int intEndDate = (int)dblEndDate;
                if (intEndDate < dblEndDate)
                    intEndDate++;
                double dblStartDate = _StartDateSearch.ToOADate() - 2;
                int intStartDate = (int)dblStartDate;
                if (intStartDate > dblStartDate)
                    intEndDate--;
                StrSql = StrSql + " And ((HRAttendanceTime.AttendanceTimeStartDate>=" + intStartDate + " and HRAttendanceTime.AttendanceTimeStartDate<=" + intEndDate + ") " +
                    " or (HRAttendanceTime.AttendanceTimeEndDate>=" + intStartDate + " and HRAttendanceTime.AttendanceTimeEndDate<=" + intEndDate + ") " +
                    " or (HRAttendanceTime.AttendanceTimeStartDate<=" + intStartDate + " and HRAttendanceTime.AttendanceTimeEndDate>=" + intStartDate + ") " +
                    " or (HRAttendanceTime.AttendanceTimeStartDate<=" + intEndDate + " and HRAttendanceTime.AttendanceTimeEndDate>=" + intEndDate + ") " +
                    " or (HRAttendanceTime.AttendanceTimeStartDate<=" + intStartDate + " and  HRAttendanceTime.AttendanceTimeEndDate is null)) ";
            }
            if (_ApplicantIDs != null && _ApplicantIDs != "")
            {
                StrSql = StrSql + " And AttendanceTimeApplicantTable.AttendanceApplicant IN (" + _ApplicantIDs + ")";
            }
            StrSql = StrSql + " Order By HRAttendanceTime.AttendanceTimeStartDate desc";
            return SysData.SharpVisionBaseDb.ReturnDatatable(StrSql);
        }
        #endregion
    }
}
