using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AlgorithmatENM.ERP.ERPBusiness;
using System.Collections;
using AlgorithmatENM.ERP.ERPSimple;
using System.Runtime.CompilerServices;
namespace AlgorithmatENMMVCCore.Controllers.ERP
{
    [Route("api/[controller]")]
    [ApiController]
    public class BufferApiController : ControllerBase
    {
        [HttpGet]
        public List<BufferSimple> GetBuffer(int intBufferType,string strCode,int intPlc)
        {
            BufferCol objCol = new BufferCol(intBufferType, strCode, intPlc);

            List<BufferSimple> Returned = objCol.Cast<BufferBiz>().Select(x=>x.GetSimple()).ToList();
            return Returned;
        }
    }
}
