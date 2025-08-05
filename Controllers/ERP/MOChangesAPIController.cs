using AlgorithmatENM.ERP.ERPBusiness;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SharpVision.COMMON.COMMONBusiness;
using SharpVision.SystemBase;
using System.Net.NetworkInformation;

namespace AlgorithmatENMMVCCore.Controllers.ERP
{
    [Route("api/[controller]")]
    [ApiController]
    public class MOChangesAPIController : ControllerBase
    {
        [HttpGet]
        public async Task<List<MOSimple>> GetAsync() {
            var request = this.HttpContext;
            string strToken = SysUtility.GetToken(this.HttpContext);
            if (strToken == "")
            {
                await Task.FromResult(Unauthorized("Unauthorized"));
                return new List<MOSimple>();
            }
            else
            {

                string strUser = SysUtility.GetClaimValue(strToken, "UserName").Replace("'", "");
                if (strUser != "algorithmat")
                {
                    await Task.FromResult(Unauthorized("Unauthorized"));
                    return new List<MOSimple>();
                }
                MOCol objCol = new MOCol("", false, DateTime.Now, DateTime.Now, 1);
                objCol.SetCol();
                List<MOSimple> Returned = objCol.Cast<MOBiz>().Select(x => x.GetSimple()).ToList();
                return Returned;
            }
        }
        [HttpPost]
        public async Task PostAsync(List<MOSimple> lstMO) 
        {
            var request = this.HttpContext;
            string strToken = SysUtility.GetToken(this.HttpContext);
            if (strToken == "")
            {
                await Task.FromResult(Unauthorized("Unauthorized"));

            }
            else
            {

                string strUser = SysUtility.GetClaimValue(strToken, "UserName").Replace("'", "");
                if (strUser != "algorithmat")
                {
                    await Task.FromResult(Unauthorized(strUser));
                }
                else
                {
                    MOCol objCol = new MOCol();
                    foreach (MOSimple objSimple in lstMO)
                    {
                        objCol.Add(objSimple.GetBiz());
                    }
                    //await Task.FromResult(() => {
                         
                       
                        

                    //});
                    objCol.EditChanged(false);
                }
            }
        }
        [HttpPut]
        public async Task EditChangedAsync(List<MOSimple> lstMO)
        {
          
        }
    }
}
