using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.SystemBase;
using SharpVision.HR.HRDataBase;
namespace SharpVision.HR.HRDataBase
{
    public class AttendanceTimeSectorDb : AttendanceTimeDb
    {
        #region Private Data
        
        protected int _AttendanceSector;
        protected int _ImageID;
        string _SectorIDs;
        #endregion
        #region Constructors
        public AttendanceTimeSectorDb()
        {
            _Periority = 3;
        }
        public AttendanceTimeSectorDb(DataRow objDr)
            : base(objDr)
        {
            _Periority = 3;
            _AttendanceSector = int.Parse(objDr["AttendanceSector"].ToString());
            
            if (objDr["ImageID"].ToString() == "")
                return;
            _ImageID = int.Parse(objDr["ImageID"].ToString());
        }
        #endregion
        #region Public Properties
       
        public int AttendanceSector
        {
            set
            {
                _AttendanceSector = value;
            }
            get
            {
                return _AttendanceSector;
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
        public string SectorIDs
        {
            set
            {
                _SectorIDs = value;
            }
        }
        public string AddStr
        {
            get
            {

                string ReturnedStr = " INSERT INTO HRAttendanceTimeSector" +
                                     " (AttendanceTimeID,AttendanceSector,ImageID)" +
                                     " VALUES (" + _ID + "," + _AttendanceSector + "," + _ImageID + ")";
                return ReturnedStr;
            }
        }
        public string EditStr
        {
            get
            {


                string ReturnedStr = " UPDATE    HRAttendanceTimeSector" +
                                     " SET AttendanceSector=" + _AttendanceSector + "" +
                                     " ,ImageID = " + _ImageID + " " +
                                     " Where  (AttendanceTimeID = " + _ID + ")";
                return ReturnedStr;
            }
        }
        public string DeleteStr
        {
            get
            {
                string ReturnedStr = " DELETE FROM HRAttendanceTimeSector" +
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
                //if (_SectorID != 0)
                //    Returned += " and SectorTable.SectorID=" + _SectorID;
                return Returned;
            }
        }
        public static string SearchStr
        {
            get
            {
                string ReturnedStr = " SELECT     HRAttendanceTimeSector.AttendanceTimeID,HRAttendanceTimeSector.AttendanceSector,HRAttendanceTimeSector.ImageID,SectorTable.* " +
                                     " FROM         HRAttendanceTimeSector" +
                                     " Left Outer Join (" + SectorDb.SearchStr + ") as SectorTable On SectorTable.SectorID= HRAttendanceTimeSector.AttendanceSector";
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
            SysData.SharpVisionBaseDb.ExecuteNonQuery(DeleteStr);

        }
        public override DataTable Search()
        {
            string StrSql = AttendanceTimeDb.SearchStr + " Where HRAttendanceTime.AttendancePeriority =3 and AttendanceTimeSectorTable.AttendanceSector is not null  ";
            if(_AttendanceSector!=0)
              StrSql = StrSql + " And AttendanceTimeSectorTable.AttendanceSector = "+ _AttendanceSector +"";
          if (_SectorIDs != null && _SectorIDs != "")
          {
              StrSql += " and AttendanceTimeSectorTable.AttendanceSector  in (SELECT   HRSector.SectorID" +
             " FROM         dbo.HRSector INNER JOIN " +
             " dbo.HRSubSector ON dbo.HRSector.SectorID = dbo.HRSubSector.SectorID  " +
             " WHERE     (dbo.HRSector.SectorID IN (" + _SectorIDs + "))) ";
          }
          StrSql += "Order by AttendanceTimeSectorTable.AttendanceSector ";
            return SysData.SharpVisionBaseDb.ReturnDatatable(StrSql);
        }
        #endregion
    }
}
