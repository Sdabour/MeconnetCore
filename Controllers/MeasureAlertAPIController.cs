using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AlgorithmatENM.ENM.ENMBiz;
using SharpVision.UMS.UMSBusiness;

namespace AlgorithmatENMMVCCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeasureAlertAPIController : ControllerBase
    {
        [HttpGet]
        public List<MeasureAlertSimple> GetAlert(bool blIsDateRange, DateTime dtFrom, DateTime dtTo, bool blLastStatus, int intReason, int intStoppedStatus)
        {
            MeasureAlertCol objCol = new MeasureAlertCol(blIsDateRange, dtFrom, dtTo, intReason, blLastStatus, intStoppedStatus);

            List<MeasureAlertSimple> Returned = objCol.Cast<MeasureAlertBiz>().Select(x => x.GetSimple()).ToList();

            return Returned;
        }
      
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
    }
}
