using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using AlgorithmatENM.ENM.ENMBiz;
using SharpVision.UMS.UMSBusiness;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Mvc;

namespace AlgorithmatNewMVC.Controllers.ENMController
{
    public class MeterMeasureSearch
    {
        public int intMeter { set; get; }
        public int intMeasureType { set; get; }
        public DateTime dtFrom { set; get; }
        public DateTime dtTo { set; get; }
    }
    public class GroupParameter
    {

        public int blIsDateRange { set; get; }
        public DateTime dtStart { set; get; }
        public DateTime dtEnd { set; get; }

    }
    public class ServiceAPIController : ControllerBase
    {
        [Route("api/ServiceAPI/GetMeasureGroup")]
        [ActionName("GetMeasureGroup")]
        [AcceptVerbs("GET", "POST")]
        public List<AlgorithmatENM.ENM.ENMBiz.GroupSimple> GetMeasureGroup(GroupParameter objParam)
        {
            MeasurementCol objCol = new MeasurementCol(objParam.blIsDateRange == 1, objParam.dtStart, objParam.dtEnd);
            //  MeasurementCol objCol =MeasurementCol.GetTodayMeasurement();

            List<AlgorithmatENM.ENM.ENMBiz.GroupSimple> Returned = objCol.GetGroupSimple();
            return Returned;
        }


        [Route("api/ServiceAPI/GetMeterMeasure")]
        [ActionName("GetMeterMeasure")]
        [AcceptVerbs("GET", "POST")]
        [HttpPost]
        public List<MeterMeasureSimple> GetMeterMeasure(MeterMeasureSearch objSearch)
        {
            bool blIsMeasureType = objSearch.dtFrom > new DateTime(2018, 1, 1) && objSearch.dtTo >= objSearch.dtFrom;
            MeterMeasureCol objCol = new MeterMeasureCol(objSearch.intMeter, objSearch.intMeasureType, blIsMeasureType, objSearch.dtFrom, objSearch.dtTo, false, false);
            List<MeterMeasureSimple> Returned = objCol.Cast<MeterMeasureBiz>().Select(x => x.GetSimple()).ToList();

            return Returned;
        }

        [Route("api/ServiceAPI/GetAlert")]
        [ActionName("GetAlert")]
        [AcceptVerbs("GET", "POST")]
        [HttpGet]
        public List<MeasureAlertSimple> GetAlert(bool blIsDateRange, DateTime dtFrom, DateTime dtTo, bool blLastStatus, int intReason, int intStoppedStatus)
        {
            MeasureAlertCol objCol = new MeasureAlertCol(blIsDateRange, dtFrom, dtTo, intReason, blLastStatus, intStoppedStatus);

            List<MeasureAlertSimple> Returned = objCol.Cast<MeasureAlertBiz>().Select(x => x.GetSimple()).ToList();

            return Returned;
        }
        [Route("api/ServiceAPI/AckAlert")]
        [ActionName("AckAlert")]
        [AcceptVerbs("GET", "POST")]
        [HttpPost]
        public bool AckAlert(string strUsrName, string strPass, int intAlert)
        {
            bool Returned = false;
            UserBiz objUser = new UserBiz();
            if (UserBiz.CheckUser(strUsrName, strPass, out objUser))
            {
                if (objUser.UserFunctionInstantCol.GetIndex(MeasureAlertBiz.UMSAckAlert) > -1)
                {
                    MeasureAlertBiz.AckAlert(intAlert, objUser.ID);
                    Returned = true;
                }
            }

            return Returned;
        }
        [Route("api/ServiceAPI/GetTankReads")]
        [ActionName("GetTankReads")]
        [AcceptVerbs("GET", "POST")]
        [HttpGet]
        public List<TankBiz> GetTankReads(string strBatchOrder)
        {
            MeterMeasureCol objMeasureCol = new MeterMeasureCol(0, 0, false, DateTime.Now.Date.AddDays(-1), DateTime.Now.Date, true, false);
            List<TankBiz> Returned = objMeasureCol.GetTankLst(strBatchOrder, false, false);
            return Returned;
        }




    }
}
