using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using SharpVision.SystemBase;

namespace SharpVision.HR.HRDataBase
{
    public class ApplicantHandShakeDb
    {

        #region Constructor
        public ApplicantHandShakeDb()
        {
        }
        public ApplicantHandShakeDb(DataRow objDr)
        {
            SetData(objDr);
        }

        #endregion
        #region Properties
        int _ApplicantID;
        public int ApplicantID
        {
            set
            {
                _ApplicantID = value;
            }
            get
            {
                return _ApplicantID;
            }
        }
        string _ApplicantCode;
        public string ApplicantCode
        {
            set
            {
                _ApplicantCode = value;
            }
            get
            {
                return _ApplicantCode;
            }
        }
        string _ApplicantFirstName;
        public string ApplicantFirstName
        {
            set
            {
                _ApplicantFirstName = value;
            }
            get
            {
                return _ApplicantFirstName;
            }
        }
        string _SectorNameA;
        public string SectorNameA
        {
            set
            {
                _SectorNameA = value;
            }
            get
            {
                return _SectorNameA;
            }
        }
        string _JobNatureNameA;
        public string JobNatureNameA
        {
            set
            {
                _JobNatureNameA = value;
            }
            get
            {
                return _JobNatureNameA;
            }
        }
        int _HandShakeID;
        public int HandShakeID
        {
            set
            {
                _HandShakeID = value;
            }
            get
            {
                return _HandShakeID;
            }
        }
        DateTime _Date;
        public DateTime Date
        {
            set
            {
                _Date = value;
            }
            get
            {
                return _Date;
            }
        }
        //bool _IsDateStatus;
        //public bool IsDateStatus { set => _IsDateStatus = value; }
        //DateTime _StartDate;
        //public DateTime StartDate { set => _StartDate = value; }
        //DateTime _EndDate;
        //public DateTime EndDate { set => _EndDate = value; }
        DateTime _Time;
        public DateTime Time
        {
            set
            {
                _Time = value;
            }
            get
            {
                return _Time;
            }
        }
        int _Hour;
        public int Hour
        {
            set
            {
                _Hour = value;
            }
            get
            {
                return _Hour;
            }
        }
        string _Long;
        public string Long
        {
            set
            {
                _Long = value;
            }
            get
            {
                return _Long;
            }
        }
        string _Lat;
        public string Lat
        {
            set
            {
                _Lat = value;
            }
            get
            {
                return _Lat;
            }
        }
        DateTime _TimIns;
        public DateTime TimIns
        { set => _TimIns = value;
            get => _TimIns;
        }
        int _OnlineStatus;
        /// <summary>
        ///online status 1 only online  
        /// </summary>
        public int OnlineStatus
        { set => _OnlineStatus = value; }
        string _ApplicantIDs;
        public string ApplicantIDs { set => _ApplicantIDs = value; }
        bool _IsDateStatus;
        public bool IsDateStatus { set => _IsDateStatus = value; }
        DateTime _StartDate;
        public DateTime StartDate { set => _StartDate = value; }
        DateTime _EndDate;
        public DateTime EndDate { set => _EndDate = value; }
        
        public string MaxHandShakeStr
        {
            get
            {
                string Returned = @"SELECT        dbo.HRApplicantWorkerHandShake.HandShakeID AS MaxHandShakeID, dbo.HRApplicantWorkerHandShake.ApplicantID AS MaxHandShakeApplicantID, 
                         dbo.HRApplicantWorkerHandShake.ApplicantHandShakeDate AS MaxHandShakeDate, dbo.HRApplicantWorkerHandShake.ApplicantHandShakeTime AS MaxHandShakeTime, 
                         dbo.HRApplicantWorkerHandShake.ApplicantHandShakeLong AS MaxHandShakeLong, dbo.HRApplicantWorkerHandShake.ApplicantHandShakeLat AS MaxHandSHakeLat,dbo.HRApplicantWorkerHandShake.ApplicantHandShakeTimIns AS MaxHandShakeTimIns 

 FROM            dbo.HRApplicantWorkerHandShake INNER JOIN
                             (";
                Returned += @"SELECT        ApplicantID, ApplicantHandShakeDate, MAX(HandShakeID) AS MaxHandShakeID
                                FROM            dbo.HRApplicantWorkerHandShake AS HRApplicantWorkerHandShake_1
                                GROUP BY ApplicantID, ApplicantHandShakeDate ";
                if(_ApplicantIDs!= null && _ApplicantIDs!= "" &&_IsDateStatus)
    Returned+=@" HAVING        (ApplicantID IN ("+_ApplicantIDs+@")) AND (ApplicantHandShakeDate BETWEEN  "+(_StartDate.Date.ToOADate()-2)+@" AND "+(_EndDate.Date.ToOADate()-2)+@" ";
                Returned+=@")) AS derivedtbl_1 ON dbo.HRApplicantWorkerHandShake.ApplicantID = derivedtbl_1.ApplicantID AND 
                         dbo.HRApplicantWorkerHandShake.ApplicantHandShakeDate = derivedtbl_1.ApplicantHandShakeDate AND dbo.HRApplicantWorkerHandShake.HandShakeID = derivedtbl_1.MaxHandShakeID ";
                return Returned;
            }
        }
        #region MaxOnline HandShake
        int _MaxOnlineHandShakeID;
        public int MaxOnlineHandShakeID
        {
            set { _MaxOnlineHandShakeID = value; }
            get { return _MaxOnlineHandShakeID; }
        }
        int _MaxOnlineHandShakeApplicantID;
        public int MaxOnlineHandShakeApplicantID
        {
            set { _MaxOnlineHandShakeApplicantID = value; }
            get { return _MaxOnlineHandShakeApplicantID; }
        }
        DateTime _MaxOnlineHandShakeDate;
        public DateTime MaxOnlineHandShakeDate
        {
            set { _MaxOnlineHandShakeDate = value; }
            get { return _MaxOnlineHandShakeDate; }
        }
        DateTime _MaxOnlineHandShakeTime;
        public DateTime MaxOnlineHandShakeTime
        {
            set { _MaxOnlineHandShakeTime = value; }
            get { return _MaxOnlineHandShakeTime; }
        }
        string _MaxOnlineHandShakeLong;
        public string MaxOnlineHandShakeLong
        {
            set { _MaxOnlineHandShakeLong = value; }
            get { return _MaxOnlineHandShakeLong; }
        }
        string _MaxOnlineHandSHakeLat;
        public string MaxOnlineHandSHakeLat
        {
            set { _MaxOnlineHandSHakeLat = value; }
            get { return _MaxOnlineHandSHakeLat; }
        }
        DateTime _MaxOnlineHandShakeTimIns;
        public DateTime MaxOnlineHandShakeTimIns
        {
            set { _MaxOnlineHandShakeTimIns = value; }
            get { return _MaxOnlineHandShakeTimIns; }
        }
        public string MaxOnlineHandShakeStr
        {
            get
            {
                string Returned = @"SELECT        dbo.HRApplicantWorkerHandShake.HandShakeID AS MaxOnlineHandShakeID, dbo.HRApplicantWorkerHandShake.ApplicantID AS MaxOnlineHandShakeApplicantID, 
                         dbo.HRApplicantWorkerHandShake.ApplicantHandShakeDate AS MaxOnlineHandShakeDate, dbo.HRApplicantWorkerHandShake.ApplicantHandShakeTime AS MaxOnlineHandShakeTime, 
                         dbo.HRApplicantWorkerHandShake.ApplicantHandShakeLong AS MaxOnlineHandShakeLong, dbo.HRApplicantWorkerHandShake.ApplicantHandShakeLat AS MaxOnlineHandSHakeLat,dbo.HRApplicantWorkerHandShake.ApplicantHandShakeTimIns AS MaxOnlineHandShakeTimIns 

 FROM            dbo.HRApplicantWorkerHandShake INNER JOIN
                             (";
                Returned += @"SELECT        ApplicantID, ApplicantHandShakeDate, MAX(HandShakeID) AS MaxHandShakeID
                                FROM            dbo.HRApplicantWorkerHandShake AS HRApplicantWorkerHandShake_1
where ApplicantHandShakeLat <>'0' 
                                GROUP BY ApplicantID, ApplicantHandShakeDate 
              ";
                if (_ApplicantIDs != null && _ApplicantIDs != "" && _IsDateStatus)
                    Returned += @"  HAVING      (ApplicantID IN (" + _ApplicantIDs + @")) AND (ApplicantHandShakeDate BETWEEN  " + (_StartDate.Date.ToOADate() - 2) + @" AND " + (_EndDate.Date.ToOADate() - 2) + @" ";
                Returned += @")) AS derivedtbl_1 ON dbo.HRApplicantWorkerHandShake.ApplicantID = derivedtbl_1.ApplicantID AND 
                         dbo.HRApplicantWorkerHandShake.ApplicantHandShakeDate = derivedtbl_1.ApplicantHandShakeDate AND dbo.HRApplicantWorkerHandShake.HandShakeID = derivedtbl_1.MaxHandShakeID ";
                return Returned;
            }
        }
        #endregion
        public string AddStr
        {
            get
            {
                IsDateStatus = true;
                _StartDate = _Date;
                _EndDate = _Date;
                _ApplicantIDs = _ApplicantID.ToString();

                string strExists = @"SELECT        dbo.HRApplicantWorkerHandShake.ApplicantHandShakeLong, 0 AS Expr1, DATEDIFF(minute, dbo.HRApplicantWorkerHandShake.ApplicantHandShakeTime, GETDATE()) AS Expr2, 
                         dbo.HRApplicantWorkerHandShake.ApplicantHandShakeLat
FROM            dbo.HRApplicantWorkerHandShake INNER JOIN
                             ("+MaxHandShakeStr+ @") AS derivedtbl_1 ON dbo.HRApplicantWorkerHandShake.ApplicantID = derivedtbl_1.MaxHandShakeApplicantID AND 
                         dbo.HRApplicantWorkerHandShake.ApplicantHandShakeDate = derivedtbl_1.MaxHandShakeDate AND dbo.HRApplicantWorkerHandShake.HandShakeID = derivedtbl_1.MaxHandShakeID
  WHERE        ((dbo.HRApplicantWorkerHandShake.ApplicantHandShakeLong= '0') and ('0' = '"+_Long+ @"'))
or (DATEDIFF(minute, dbo.HRApplicantWorkerHandShake.ApplicantHandShakeTime, GETDATE()) < 10 and dbo.HRApplicantWorkerHandShake.ApplicantHandShakeLong<> '0' and ('0' <> '" + _Long + @"') 
and  dbo.GetDistant(dbo.HRApplicantWorkerHandShake.ApplicantHandShakeLong,"+_Long+@", dbo.HRApplicantWorkerHandShake.ApplicantHandShakeLat, "+_Lat+@")<0.05)";
                string Returned = @" insert into HRApplicantWorkerHandShake  (ApplicantID,ApplicantHandShakeDate,ApplicantHandShakeTime,ApplicantHandShakeHour,ApplicantHandShakeLong,ApplicantHandShakeLat,ApplicantHandShakeTimIns) select  " + ApplicantID+ @" as ApplicantID,dbo.GetApproximateDate(GetDate()) as HandShakeDate,GetDate() as HandShakeTime,{ fn HOUR(GETDATE()) }  as HandShakeHour,'" + Long + "' as HandShakeLong,'" + Lat + @"' as HandShakeLat,GetDate()   FROM            dbo.HRApplicant INNER JOIN
                         dbo.HRApplicantWorker ON dbo.HRApplicant.ApplicantID = dbo.HRApplicantWorker.ApplicantID
    
WHERE        (dbo.HRApplicant.ApplicantID = "+_ApplicantID+@") AND (dbo.HRApplicantWorker.ApplicantCode = '"+ _ApplicantCode + @"')  AND (dbo.HRApplicantWorker.ApplicantStatusID = 1) and not exists (SELECT        ApplicantID
FROM            dbo.HRApplicantWorkerHandShake
WHERE        (ApplicantID = "+ _ApplicantID + @") AND (DATEDIFF(minute, ApplicantHandShakeTimIns, GETDATE()) < 30))   ";
                return Returned;
            }
        }
        public string EditStr
        {
            get
            {
                string Returned = @" update HRApplicantWorkerHandShake  set ApplicantHandShakeTime=GetDate() " +
           ",ApplicantHandShakeHour={ fn HOUR(GETDATE()) } " +
           ",ApplicantHandShakeLong='" + Long + "'" +
           ",ApplicantHandShakeLat='" + Lat + "'" +
           @"  WHERE        (ApplicantID = "+_ApplicantID+ @") AND (DATEDIFF(minute, ApplicantHandShakeTimIns, GETDATE()) < 30) ";
                return Returned;
            }
        }
        public string DeleteStr
        {
            get
            {
                string Returned = " update HRApplicantWorkerHandShake  set Dis = GetDate() where  ";
                return Returned;
            }
        }
        public string SearchStr
        {
            get
            {
                string Returned = @" SELECT        derivedtbl_1.MaxApplicantSubsector, dbo.HRApplicant.ApplicantID, dbo.HRApplicantWorker.ApplicantCode, dbo.HRApplicant.ApplicantFirstName, dbo.HRSector.SectorNameA, dbo.HRJobNatureType.JobNatureNameA, 
                         dbo.HRApplicantWorkerHandShake.HandShakeID, dbo.HRApplicantWorkerHandShake.ApplicantHandShakeDate, dbo.HRApplicantWorkerHandShake.ApplicantHandShakeTime, 
                         dbo.HRApplicantWorkerHandShake.ApplicantHandShakeHour, dbo.HRApplicantWorkerHandShake.ApplicantHandShakeLong, dbo.HRApplicantWorkerHandShake.ApplicantHandShakeLat,ApplicantHandShakeTimIns ";
                if (_OnlineStatus == 3)
                    Returned += ",MaxOnlineTable.* ";

        Returned+=@" FROM            dbo.HRSubSector INNER JOIN
                         dbo.HRApplicantWorkerCurrentSubSector AS HRApplicantWorkerCurrentSubSector_1 ON dbo.HRSubSector.SubSectorID = HRApplicantWorkerCurrentSubSector_1.SubSectorID INNER JOIN
                         dbo.HRSector ON dbo.HRSubSector.SectorID = dbo.HRSector.SectorID INNER JOIN
                             (SELECT        ApplicantID, MAX(ApplicantSubSectorID) AS MaxApplicantSubsector
                                FROM            dbo.HRApplicantWorkerCurrentSubSector
                                GROUP BY ApplicantID, Dis
                                HAVING        (Dis IS NULL) AND (ApplicantID > 0)) AS derivedtbl_1 ON HRApplicantWorkerCurrentSubSector_1.ApplicantSubSectorID = derivedtbl_1.MaxApplicantSubsector AND 
                         HRApplicantWorkerCurrentSubSector_1.ApplicantID = derivedtbl_1.ApplicantID INNER JOIN
                         dbo.HRApplicantWorker ON HRApplicantWorkerCurrentSubSector_1.ApplicantID = dbo.HRApplicantWorker.ApplicantID INNER JOIN
                         dbo.HRApplicant ON dbo.HRApplicantWorker.ApplicantID = dbo.HRApplicant.ApplicantID INNER JOIN
                         dbo.HRApplicantWorkerHandShake ON dbo.HRApplicantWorker.ApplicantID = dbo.HRApplicantWorkerHandShake.ApplicantID LEFT OUTER JOIN
                         dbo.HRJobNatureType ON HRApplicantWorkerCurrentSubSector_1.JobNatureID = dbo.HRJobNatureType.JobNatureID ";
                if(_OnlineStatus != 0)
                {
                    string strMaxTable = @"SELECT        ApplicantID, MAX(HandShakeID) AS MaxHandShakeID
                                FROM            dbo.HRApplicantWorkerHandShake AS HRApplicantWorkerHandShake_1
                                GROUP BY ApplicantID";
                    Returned += @" INNER JOIN
                             ("+strMaxTable+@") AS MaxTable ON dbo.HRApplicantWorkerHandShake.ApplicantID = MaxTable.ApplicantID AND dbo.HRApplicantWorkerHandShake.HandShakeID = MaxTable.MaxHandShakeID ";
                }
                if(_OnlineStatus == 3)
                {
                    Returned += " left outer join ("+MaxOnlineHandShakeStr+ @") as MaxOnlineTable 
    ON dbo.HRApplicantWorkerHandShake.ApplicantID = MaxOnlineTable.MaxOnlineHandShakeApplicantID AND 
                         dbo.HRApplicantWorkerHandShake.ApplicantHandShakeDate = MaxOnlineTable.MaxOnlineHandShakeDate ";
                }
                return Returned;
            }
        }
        #endregion
        #region Private Method

        void SetData(DataRow objDr)
        {

            if (objDr.Table.Columns["ApplicantID"] != null)
                int.TryParse(objDr["ApplicantID"].ToString(), out _ApplicantID);

            if (objDr.Table.Columns["ApplicantCode"] != null)
                _ApplicantCode = objDr["ApplicantCode"].ToString();

            if (objDr.Table.Columns["ApplicantFirstName"] != null)
                _ApplicantFirstName = objDr["ApplicantFirstName"].ToString();

            if (objDr.Table.Columns["SectorNameA"] != null)
                _SectorNameA = objDr["SectorNameA"].ToString();

            if (objDr.Table.Columns["JobNatureNameA"] != null)
                _JobNatureNameA = objDr["JobNatureNameA"].ToString();

            if (objDr.Table.Columns["HandShakeID"] != null)
                int.TryParse(objDr["HandShakeID"].ToString(), out _HandShakeID);

            if (objDr.Table.Columns["ApplicantHandShakeDate"] != null)
                DateTime.TryParse(objDr["ApplicantHandShakeDate"].ToString(), out _Date);

            if (objDr.Table.Columns["ApplicantHandShakeTime"] != null)
                DateTime.TryParse(objDr["ApplicantHandShakeTime"].ToString(), out _Time);

            if (objDr.Table.Columns["ApplicantHandShakeHour"] != null)
                int.TryParse(objDr["ApplicantHandShakeHour"].ToString(), out _Hour);

            if (objDr.Table.Columns["ApplicantHandShakeLong"] != null)
                _Long = objDr["ApplicantHandShakeLong"].ToString();

            if (objDr.Table.Columns["ApplicantHandShakeLat"] != null)
                _Lat = objDr["ApplicantHandShakeLat"].ToString();
            if (objDr.Table.Columns["ApplicantHandShakeTimIns"] != null)
                DateTime.TryParse(objDr["ApplicantHandShakeTimIns"].ToString(), out _TimIns);
            SetMaxOnlineData(objDr);
        }
        void SetMaxOnlineData(DataRow objDr)
        {

            if (objDr.Table.Columns["MaxOnlineHandShakeID"] != null)
                int.TryParse(objDr["MaxOnlineHandShakeID"].ToString(), out _MaxOnlineHandShakeID);

            if (objDr.Table.Columns["MaxOnlineHandShakeApplicantID"] != null)
                int.TryParse(objDr["MaxOnlineHandShakeApplicantID"].ToString(), out _MaxOnlineHandShakeApplicantID);

            if (objDr.Table.Columns["MaxOnlineHandShakeDate"] != null)
                DateTime.TryParse(objDr["MaxOnlineHandShakeDate"].ToString(), out _MaxOnlineHandShakeDate);

            if (objDr.Table.Columns["MaxOnlineHandShakeTime"] != null)
                DateTime.TryParse(objDr["MaxOnlineHandShakeTime"].ToString(), out _MaxOnlineHandShakeTime);

            if (objDr.Table.Columns["MaxOnlineHandShakeLong"] != null)
                _MaxOnlineHandShakeLong = objDr["MaxOnlineHandShakeLong"].ToString();

            if (objDr.Table.Columns["MaxOnlineHandSHakeLat"] != null)
                _MaxOnlineHandSHakeLat = objDr["MaxOnlineHandSHakeLat"].ToString();

            if (objDr.Table.Columns["MaxOnlineHandShakeTimIns"] != null)
                DateTime.TryParse(objDr["MaxOnlineHandShakeTimIns"].ToString(), out _MaxOnlineHandShakeTimIns);
        }

        #endregion
        #region Public Method 
        public void Add()
        {
            string strSql = AddStr+@"
   "+EditStr ;
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
            if(_OnlineStatus == 1 &&_ApplicantIDs!= null &&_ApplicantIDs!= "")
            {
                strSql += " and dbo.HRApplicantWorker.ApplicantID in ("+_ApplicantIDs+ @") and  
 (ApplicantHandShakeDate = dbo.GetApproximateDate(GetDate()))
  and (DATEDIFF(minute, ApplicantHandShakeTime, GETDATE()) < 10) and   dbo.HRApplicantWorkerHandShake.ApplicantHandShakeLong
<>'0' ";
            }
            if (_OnlineStatus ==2 && _ApplicantIDs != null && _ApplicantIDs != "")
            {
                strSql += " and dbo.HRApplicantWorker.ApplicantID in (" + _ApplicantIDs + @")  and ((DATEDIFF(minute, ApplicantHandShakeTime, GETDATE()) >10) or   dbo.HRApplicantWorkerHandShake.ApplicantHandShakeLong
='0') ";
            }
            if (_ApplicantID!= 0)
            { strSql += " and dbo.HRApplicantWorker.ApplicantID="+_ApplicantID; }
            if (_ApplicantIDs != null && _ApplicantIDs!= "" && (_OnlineStatus == 0||_OnlineStatus == 3) )
            {
                strSql += " and dbo.HRApplicantWorker.ApplicantID in (" + _ApplicantIDs + ")";
            }
            if (_IsDateStatus)
            {
                strSql += " and ApplicantHandShakeDate between "+(_StartDate.Date.ToOADate()-2)+" and "+(_EndDate.Date.ToOADate()-2);
            }

            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        #endregion
    }
}