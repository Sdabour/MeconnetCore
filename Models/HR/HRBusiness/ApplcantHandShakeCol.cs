using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SharpVision.HR.HRDataBase;
using SharpVision.SystemBase;
using System.Data;
using System.Collections;
namespace SharpVision.HR.HRBusiness
{
    public class ApplicantHandShakeCol:CollectionBase
    {


        #region Constructor
        public ApplicantHandShakeCol()
        {

        }
        public ApplicantHandShakeCol(bool blIsEmbty)
        {
            if (blIsEmbty)
                return;
            ApplicantHandShakeBiz objBiz = new ApplicantHandShakeBiz();
            

            ApplicantHandShakeDb objDb = new ApplicantHandShakeDb();

            DataTable dtTemp = objDb.Search();


            foreach (DataRow objDR in dtTemp.Rows)
            {
                objBiz = new ApplicantHandShakeBiz(objDR);
                Add(objBiz);
            }
        }

        public ApplicantHandShakeCol(int intOnlineStatus,string strApplicantIDs,int intApplicantID,bool blIsDateRange,DateTime dtStart,DateTime dtEnd)
        {
           
            ApplicantHandShakeBiz objBiz = new ApplicantHandShakeBiz();


            ApplicantHandShakeDb objDb = new ApplicantHandShakeDb();
            objDb.ApplicantID = intApplicantID;
            objDb.OnlineStatus = intOnlineStatus;
            objDb.ApplicantIDs = strApplicantIDs;
            objDb.IsDateStatus = blIsDateRange;
            objDb.StartDate = dtStart;
            objDb.EndDate = dtEnd;
            DataTable dtTemp = objDb.Search();


            foreach (DataRow objDR in dtTemp.Rows)
            {
                objBiz = new ApplicantHandShakeBiz(objDR);
                Add(objBiz);
            }
        }

        #endregion
        #region Private Data

        #endregion
        #region Properties
        public ApplicantHandShakeBiz this[int intIndex]
        {
            get
            {
                return (ApplicantHandShakeBiz)this.List[intIndex];
            }
        }
        #endregion
        #region Private Method

        #endregion
        #region Public Method 
        public void Add(ApplicantHandShakeBiz objBiz)
        {
            List.Add(objBiz);
        }
        public ApplicantHandShakeCol GetCol(string strTemp)
        {
            ApplicantHandShakeCol Returned = new ApplicantHandShakeCol(true);
            foreach (ApplicantHandShakeBiz objBiz in this)
            {
                if (objBiz.ApplicantFirstName.CheckStr(strTemp))
                    Returned.Add(objBiz);
            }
            return Returned;
        }
        public DataTable GetTable()
        {
            DataTable Returned = new DataTable();
            Returned.Columns.AddRange(new DataColumn[] { new DataColumn("ApplicantID"), new DataColumn("ApplicantCode"), new DataColumn("ApplicantFirstName"), new DataColumn("SectorNameA"), new DataColumn("JobNatureNameA"), new DataColumn("HandShakeID"), new DataColumn("ApplicantHandShakeDate", System.Type.GetType("System.DateTime")), new DataColumn("ApplicantHandShakeTime", System.Type.GetType("System.DateTime")), new DataColumn("ApplicantHandShakeHour"), new DataColumn("ApplicantHandShakeLong"), new DataColumn("ApplicantHandShakeLat") });
            DataRow objDr;
            foreach (ApplicantHandShakeBiz objBiz in this)
            {
                objDr = Returned.NewRow();
                objDr["ApplicantID"] = objBiz.ApplicantID;
                objDr["ApplicantCode"] = objBiz.ApplicantCode;
                objDr["ApplicantFirstName"] = objBiz.ApplicantFirstName;
                objDr["SectorNameA"] = objBiz.SectorNameA;
                objDr["JobNatureNameA"] = objBiz.JobNatureNameA;
                objDr["HandShakeID"] = objBiz.HandShakeID;
                objDr["ApplicantHandShakeDate"] = objBiz.Date;
                objDr["ApplicantHandShakeTime"] = objBiz.Time;
                objDr["ApplicantHandShakeHour"] = objBiz.Hour;
                objDr["ApplicantHandShakeLong"] = objBiz.Long;
                objDr["ApplicantHandShakeLat"] = objBiz.Lat;
                Returned.Rows.Add(objDr);
            }
            return Returned;
        }
        public static  ApplicantHandShakeCol GetOnlineHandShakeCol(string strApplicantIDs)
        {
            ApplicantHandShakeCol Returned = new ApplicantHandShakeCol(true);
            ApplicantHandShakeDb objDb = new ApplicantHandShakeDb() { OnlineStatus = 1, ApplicantIDs = strApplicantIDs };
            DataTable dtTemp = objDb.Search();
            foreach(DataRow objDr in dtTemp.Rows)
            { 
                Returned.Add(new ApplicantHandShakeBiz(objDr));
            }

            return Returned;
        }
        public static ApplicantHandShakeCol GetTodayHandShakeCol(string strApplicantIDs)
        {
            ApplicantHandShakeCol Returned = new ApplicantHandShakeCol(true);
            ApplicantHandShakeDb objDb = new ApplicantHandShakeDb() { IsDateStatus=true,EndDate=DateTime.Now, StartDate=DateTime.Now,OnlineStatus=3,ApplicantIDs = strApplicantIDs };
            DataTable dtTemp = objDb.Search();
            ApplicantHandShakeBiz objBiz;
            foreach (DataRow objDr in dtTemp.Rows)
            {
               objBiz =  new ApplicantHandShakeBiz(objDr);
                objBiz.Status = objBiz.Long == "0" ? HandShakeStatus.LogedOut : (DateTime.Now.Subtract(objBiz.Time).TotalMinutes > 10 ? HandShakeStatus.Disconnected : (DateTime.Now.Subtract(objBiz.Time).TotalMinutes < 10 && DateTime.Now.Subtract(objBiz.Time).TotalMinutes > 5 ? HandShakeStatus.Idle : HandShakeStatus.Online));
                if(objBiz.Status == HandShakeStatus.LogedOut)
                {
                    objBiz.Long = objBiz.MaxOnlineHandSHakeLong;
                    objBiz.Lat = objBiz.MaxOnlineHandSHakeLat;
                }
                Returned.Add(objBiz);
            }
            #region LogedOut
            List<ApplicantHandShakeBiz> objLogedOutCol = (from objLogedOutBiz in Returned.Cast<ApplicantHandShakeBiz>()
                                                          where objLogedOutBiz.Status == HandShakeStatus.LogedOut
                                                          select objLogedOutBiz).ToList();
            string strAppIDs = "";
            foreach(ApplicantHandShakeBiz objHandShakeBiz in objLogedOutCol)
            { if (strAppIDs != "")
                    strAppIDs += ",";
                strAppIDs += objHandShakeBiz.ApplicantID.ToString();
                        }
            objDb.ApplicantIDs = strAppIDs;
            #endregion
            return Returned;
        }
        #endregion
    }
}