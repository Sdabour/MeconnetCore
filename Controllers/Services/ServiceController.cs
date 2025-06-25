using Microsoft.AspNetCore.Mvc;
using AlgorithmatENM.ENM.ENMBiz;
using SharpVision.UMS.UMSBusiness;
using AlgorithmatENM.ERP.ERPBusiness;

namespace AlgorithmatENMMVCCore.Controllers
{
    public class MeterMeasureSearch
    {
        public int intMeter; public int intMeasureType; public DateTime dtFrom; public DateTime dtTo;
    }
    public class GroupParameter
    {

        public int blIsDateRange;
        public DateTime dtStart;
        public DateTime dtEnd;

    }
    public class ServiceController : Controller
    {
        public IActionResult Index()
        {
            return View("ServiceBufferRUN");
        }
        public IActionResult ServiceRunIndex()
        {
            return View("ServiceRUN");
        }
        
    }
}
