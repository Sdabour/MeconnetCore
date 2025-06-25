using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SharpVision.UMS.UMSBusiness;

namespace AlgorithmatENMMVCCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserFunctionAPIController : ControllerBase
    {
        [HttpGet]

        public List<FunctionInstantSimple> GetUserFunctionInstant(int intUserID)
        {
            UserCol objUserCol = new UserCol();// new UserCol(intGroupID, strUserName, strFullName, intEmpID);

            List<FunctionInstantSimple> Returned = new List<FunctionInstantSimple>();
            if (intUserID != 0)
            {
                UserBiz objBiz = new UserBiz() { ID = intUserID };
                Returned = objBiz.AllUserFunctionInstantCol.Cast<UserFunctionInstantBiz>().Select(x => x.GetFunctionInstant()).ToList();
            }
            //objUserCol.Cast<UserBiz>().Select(x => x.GetSimple()).ToList();
            return Returned;

        }
    }
}
