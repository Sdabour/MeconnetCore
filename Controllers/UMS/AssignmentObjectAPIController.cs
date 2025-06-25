using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SharpVision.Base.BaseBusiness;
using SharpVision.UMS.UMSBusiness;

namespace AlgorithmatENMMVCCore.Controllers
{
    public class AssignmentObjectListSimple
    {
        public int intUser { set; get; }
        public string strCode { set; get; }
        public List<SerializableBiz> lstAssignment { set; get; } = new List<SerializableBiz>();
    }
    [Route("api/[controller]")]
    [ApiController]
    public class AssignmentObjectAPIController : ControllerBase
    {
        [HttpGet]
        public List<AssignmentObjectSimple> GetAssignmentObjectLst()
        {
            AssignmentObjectCol objCol = new AssignmentObjectCol(false);
            List<AssignmentObjectSimple> Returned = objCol.Cast<AssignmentObjectBiz>().Select(x => x.GetSimple()).ToList();
            return Returned;
        }
     
    }
}
