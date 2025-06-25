using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AlgorithmatENM.ERP.ERPBusiness;
namespace AlgorithmatENMMVCCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ODDOWorkOrderController : ControllerBase
    {
        [HttpGet]
        public List<ODDOWorkOrder> GetWorkOrder()
        {
              return OddoHelper.GetODDOWorkOrderLst();
        }
    }
}
