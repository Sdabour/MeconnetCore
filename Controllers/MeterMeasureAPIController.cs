using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AlgorithmatENM.ENM.ENMBiz;
namespace AlgorithmatENMMVCCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeterMeasureAPIController : ControllerBase
    {
        [HttpPost]

        public List<MeterMeasureSimple> GetMeterMeasure(MeterMeasureSearch objSearch)
        {
            bool blIsMeasureType = objSearch.dtFrom > new DateTime(2018, 1, 1) && objSearch.dtTo >= objSearch.dtFrom;
            MeterMeasureCol objCol = new MeterMeasureCol(objSearch.intMeter, objSearch.intMeasureType, blIsMeasureType, objSearch.dtFrom, objSearch.dtTo, false, false);
            List<MeterMeasureSimple> Returned = objCol.Cast<MeterMeasureBiz>().Select(x => x.GetSimple()).ToList();

            return Returned;
        }
    }
}
