using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AlgorithmatENM.ERP.ERPBusiness;
using AlgorithmatENM.ERP.ERPSimple;
namespace AlgorithmatENMMVCCore.Controllers.ERP
{
    [Route("api/[controller]")]
    [ApiController]
    public class BufferMeasureSearchAPIController : ControllerBase
    {
        [HttpGet]   
        public List<BufferMeasureSimple> GetBufferMeasure(int intBuffer,int intIsDateRange,DateTime dtStart,DateTime dtEnd)
        {
            BufferMeasureCol objCol = new BufferMeasureCol(intIsDateRange==1,dtStart, dtEnd,intBuffer:intBuffer);
            List<BufferMeasureSimple> Returned = objCol.Cast<BufferMeasureBiz>().Select(x=>x.GetSimple()).ToList();
            return Returned;
        }
    }
}
