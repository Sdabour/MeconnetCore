using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AlgorithmatENM.ENM.ENMBiz;
namespace AlgorithmatENMMVCCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeasurementGroupAPIController : ControllerBase
    {
        [Route("api/MeasurementGroupAPI")]
        [HttpPost]
        public List<AlgorithmatENM.ENM.ENMBiz.GroupSimple> GetMeasureGroup(GroupParameter objParam)
        {
            MeasurementCol objCol = new MeasurementCol(objParam.blIsDateRange == 1, objParam.dtStart, objParam.dtEnd);
            //  MeasurementCol objCol =MeasurementCol.GetTodayMeasurement();

            List<AlgorithmatENM.ENM.ENMBiz.GroupSimple> Returned = objCol.GetGroupSimple();
            return Returned;
        }
    }
}
