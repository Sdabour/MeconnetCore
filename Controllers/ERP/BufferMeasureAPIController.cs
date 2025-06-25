using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using AlgorithmatENM.ENM.ENMBiz;
using SharpVision.UMS.UMSBusiness;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using AlgorithmatENM.ERP.ERPBusiness;
using System.Diagnostics.Metrics;
using Microsoft.AspNetCore.SignalR;
using System.Threading;
namespace AlgorithmatNewMVC.Controllers.ENMController
{
    [Route("api/[controller]")]
    [ApiController]
    public class BufferMeasureAPIController : ControllerBase
    {
       //readonly IHubContext _hubContext;
       // public BufferMeasureAPIController(IHubContext hubContext)
       // {
       //     _hubContext = hubContext;
          
       // }

        //[Route("api/BufferMeasureAPI")]
        [HttpPost]
        public List<AlgorithmatENM.ENM.ENMBiz.GroupSimple> GetMeasureGroup(GroupParameter objParam)
        {
            if (objParam.blIsDateRange == 0)
            {
                objParam.blIsDateRange = 1;
                objParam.dtStart = DateTime.Now.Date;
                objParam.dtEnd = DateTime.Now.Date;
            }
            BufferMeasureCol objCol = new BufferMeasureCol(objParam.blIsDateRange == 1, objParam.dtStart, objParam.dtEnd);
            MeasurementCol objMeasureCol = objCol.Cast<BufferMeasureBiz>().ToList().GetMeasurementLst();

            List<AlgorithmatENM.ENM.ENMBiz.GroupSimple> Returned = objMeasureCol.GetGroupSimple();
            return Returned;
        }


        
        [HttpGet]
        public List<MeterMeasureSimple> GetMeterMeasure(int intMeter,int intMeasureType,DateTime dtFrom,DateTime dtTo)
        {
            MeterMeasureSearch objSearch = new MeterMeasureSearch() { dtFrom=dtFrom,dtTo=dtTo,intMeasureType=intMeasureType,intMeter=intMeter};
            bool blIsMeasureType = objSearch.dtFrom > new DateTime(2018, 1, 1) && objSearch.dtTo >= objSearch.dtFrom;
            BufferMeasureCol objCol = new BufferMeasureCol(objSearch.intMeter, blIsMeasureType, objSearch.dtFrom, objSearch.dtTo);
            List<MeterMeasureSimple> Returned = objCol.Cast<BufferMeasureBiz>().Select(x => x.GetSimple()).ToList();

            return Returned;
        }

    }
}
