using AlgorithmatENM.ERP.ERPBusiness;
using AlgorithmatENM.ERP.ERPDataBase;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SharpVision.SystemBase;
using System.Text;
using System.Text.Json;

namespace AlgorithmatENMMVCCore.Controllers
{
    public class ResponseDto
    {
        public int StatusCode { get; set; }
        public object Data { get; set; }
        public string ErrorMessage { get; set; }
    }
    public interface IManufacturingService
    {
        Task<ResponseDto> CreateManufacturingOrder(MO moDto);
    }
    public class ManufacturingService : IManufacturingService
    {
        public async Task<ResponseDto> CreateManufacturingOrder(MO moDto)
        {
            try
            {
               
                // Validate required fields
                if (moDto.bom == null)
                {
                    return new ResponseDto
                    {
                        StatusCode = 400,
                        ErrorMessage = "Missing key in payload 'bom'"
                    };
                   // moDto.bom=new SingleValue() { id = 0 ,name="NoBom"};
                }

                // Add your business logic here to process the MO
                // For example, save to database or integrate with SCADA system
                MOBiz objMo = moDto.GetMOBiz();
                objMo.AddUniqueRef();
                var responseData = new
                {
                    Id =objMo.ID, // Simulate SCADA ID
                    Lot = $"WW{DateTime.Now:yyMMddHHmmss}",
                    StartTime = DateTime.UtcNow.ToString("o")
                };

                return new ResponseDto
                {
                    StatusCode = 201,
                    Data = responseData
                };
            }
            catch (Exception ex)
            {
                return new ResponseDto
                {
                    StatusCode = 500,
                    ErrorMessage = ex.Message
                };
            }
        }
    }
    //[Route("api/[controller]")]
    [Route("odoo/mrp_production/create")]
    [ApiController]
    public class MrpProductionController : ControllerBase
    {
        private readonly IManufacturingService _manufacturingService;

        public MrpProductionController(IManufacturingService manufacturingService)
        {
            _manufacturingService = manufacturingService;
        }

        [HttpPost]
        //[FromHeader(Name = "x-api-key")] string apiKey,
        //[FromHeader(Name = "x-timestamp")]
        //string timestamp
        public async Task<IActionResult> Create()
        {
            MODb.InsertLog();
            MO moDto = new MO() ;
            // Validate API key
            var request = HttpContext.Request;
            string apiKey ="";
           if( request.Headers.TryGetValue("x-api-key", out var apiKeyTemp))
            apiKey = apiKeyTemp.ToString();

            if (string.IsNullOrEmpty(apiKey) || !IsValidApiKey(apiKey))
            {
                return Unauthorized(new ResponseDto
                {
                    StatusCode = 300,
                    ErrorMessage = "Invalid Credentials"
                });
            }
            string strMo = "";
            Request.EnableBuffering(); // Allow re-reading the stream
            using (StreamReader reader = new StreamReader(Request.Body, Encoding.UTF8, true, 4096, true))
            {
            strMo = await reader.ReadToEndAsync();
            }
            if (strMo != "")

            {
                moDto=JsonSerializer.Deserialize<MO>(strMo);
            }               // string rawBody = await reader.ReadToEndAsync();
                // Process the request
                var result = await _manufacturingService.CreateManufacturingOrder(moDto);

            // Return appropriate response
            return result.StatusCode switch
            {
                201 => Created("", result),
                400 => BadRequest(result),
                500 => StatusCode(500, result),
                _ => BadRequest(result)
            };
        }

        private bool IsValidApiKey(string apiKey)
        {
            if(string.IsNullOrEmpty(apiKey))
                { return false; }
            // Implement your API key validation logic
            // Compare against stored keys or validate JWT if using tokens
            string strUser = SysUtility.GetClaimValue(apiKey, "UserName").Replace("'", "");
            //if (strUser != "oddoo")
            //{
            //    await Task.FromResult(Unauthorized("Unauthorized"));
            //    return;
            //}
            return strUser == "oddoo";
        }
    }
}
