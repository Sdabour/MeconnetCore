using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using SharpVision.HR.HRDataBase;

namespace SharpVision.HR.HRBusiness
{
 [Serializable]
    public class ApplicantHandShakeSimple
    {
        public int ApplicantID;
        public string ApplicantCode;
        public string ApplicantName;
        public string SectorName;
        public string JobDesc;
        public string LastTime;
        public string LastDateStr;
        public string LastTimeStr;
        public string Long;
        public string Lat;
        public string TimStart;
        public int Status;
        public string StatusStr;
    }
    public enum HandShakeStatus
    {
        
        Online,
        Idle,
        Disconnected,
        LogedOut
    }
    public class ApplicantHandShakeBiz
    {

        #region Constructor
        public ApplicantHandShakeBiz()
        {
            _ApplcantHandShakeDb = new ApplicantHandShakeDb();
        }
        public ApplicantHandShakeBiz(DataRow objDr)
        {
            _ApplcantHandShakeDb = new ApplicantHandShakeDb(objDr);
        }

        #endregion
        #region Private Data
        ApplicantHandShakeDb _ApplcantHandShakeDb;
        #endregion
        #region Properties
        public int ApplicantID
        {
            set
            {
                _ApplcantHandShakeDb.ApplicantID = value;
            }
            get
            {
                return _ApplcantHandShakeDb.ApplicantID;
            }
        }
        public string ApplicantCode
        {
            set
            {
                _ApplcantHandShakeDb.ApplicantCode = value;
            }
            get
            {
                return _ApplcantHandShakeDb.ApplicantCode;
            }
        }
        public string ApplicantFirstName
        {
            set
            {
                _ApplcantHandShakeDb.ApplicantFirstName = value;
            }
            get
            {
                return _ApplcantHandShakeDb.ApplicantFirstName;
            }
        }
        public string SectorNameA
        {
            set
            {
                _ApplcantHandShakeDb.SectorNameA = value;
            }
            get
            {
                return _ApplcantHandShakeDb.SectorNameA;
            }
        }
        public string JobNatureNameA
        {
            set
            {
                _ApplcantHandShakeDb.JobNatureNameA = value;
            }
            get
            {
                return _ApplcantHandShakeDb.JobNatureNameA;
            }
        }
        public int HandShakeID
        {
            set
            {
                _ApplcantHandShakeDb.HandShakeID = value;
            }
            get
            {
                return _ApplcantHandShakeDb.HandShakeID;
            }
        }
        public DateTime Date
        {
            set
            {
                _ApplcantHandShakeDb.Date = value;
            }
            get
            {
                return _ApplcantHandShakeDb.Date;
            }
        }
        public DateTime Time
        {
            set
            {
                _ApplcantHandShakeDb.Time = value;
            }
            get
            {
                return _ApplcantHandShakeDb.Time;
            }
        }
        public int Hour
        {
            set
            {
                _ApplcantHandShakeDb.Hour = value;
            }
            get
            {
                return _ApplcantHandShakeDb.Hour;
            }
        }
        public string Long
        {
            set
            {
                _ApplcantHandShakeDb.Long = value;
            }
            get
            {
                return _ApplcantHandShakeDb.Long;
            }
        }
        public string Lat
        {
            set
            {
                _ApplcantHandShakeDb.Lat = value;
            }
            get
            {
                return _ApplcantHandShakeDb.Lat;
            }
        }
        public DateTime TimIns
        { set => _ApplcantHandShakeDb.TimIns= value; get => _ApplcantHandShakeDb.TimIns; }
       
        public string MaxOnlineHandSHakeLat
        {
            get => _ApplcantHandShakeDb.MaxOnlineHandSHakeLat;
        }
        public string MaxOnlineHandSHakeLong
        {
            get => _ApplcantHandShakeDb.MaxOnlineHandShakeLong;
        }
        HandShakeStatus _Status;
       public HandShakeStatus Status
        { set => _Status = value;
            get => _Status;
        }

        public ApplicantHandShakeSimple HandShakeSimple
        {
            get
            {
                return new ApplicantHandShakeSimple() { ApplicantID=ApplicantID,ApplicantCode = ApplicantCode, ApplicantName = ApplicantFirstName, JobDesc = JobNatureNameA, LastTime = Time.ToString("HH:mm:ss"), Lat = Lat, Long = Long,SectorName="",TimStart=TimIns.ToString("MM-dd HH:mm") ,Status=(int)Status,StatusStr=Status.ToString(),LastDateStr=Time.ToString("yyyy-MM-dd"),LastTimeStr= Time.ToString("HH:mm")};
            }
        }
        static int UMSOnlineHandShakedShow { get => 2325; } 
        public static bool UMSOnlineHandShakedShowAuthorized { get => SharpVision.SystemBase.SysData.CurrentUser.UserFunctionInstantCol.GetIndex(UMSOnlineHandShakedShow) >= 0; }

        static int UMSHandShakeSearchAll { get => 2327; }
        public static bool UMSHandShakeSearchAllAuthorized { get => SharpVision.SystemBase.SysData.CurrentUser.UserFunctionInstantCol.GetIndex(UMSHandShakeSearchAll) >= 0; }
        #endregion
        #region Private Method

        #endregion
        #region Public Method 
        public void Add()
        {
            _ApplcantHandShakeDb.Add();
        }
        public void Edit()
        {
            _ApplcantHandShakeDb.Edit();
        }
        public void Delete()
        {
            _ApplcantHandShakeDb.Delete();
        }
        #endregion

    }
}