using AlgorithmatENM.ENM.ENMBiz;
using AlgorithmatENM.ERP.ERPBusiness;
using AlgorithmatENM.Models.ERP.ERPBusiness;
using AlgorithmatENMMVCCore.Hubs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using SharpVision.SystemBase;
using SharpVision.UMS.UMSBusiness;
using System;
using System.Net;
using System.Text;
using System.Text.Json;

//using System.Web.Http;

namespace AlgorithmatENMMVCCore.Controllers
{
    public class ChangeMOStatusParam
    {
        public string strUserName { get; set; }
        public string strPass { get; set; }
        public int intMO { get; set; }
        public int intStatus { get; set; }
    }
    public class SingleValue
    {
        public int id { get; set; }
        public string name { set; get; }
    }
    public class SingleValueQuantity : SingleValue
    {

        public double quantity { set; get; }
    }
    public class Component : SingleValueQuantity
    {
        public SingleValue uom { set; get; }
    }
    public class WorkOrder
    {
        public int id { get; set; }
        = 0;
        public string operation { set; get; }
        public SingleValueQuantity product { set; get; } = new SingleValueQuantity();
    }
    public class MO
    {
        public int id { get; set; }
        public SingleValue bom { set; get; } = new SingleValue();
        /// <summary>
        /// the product to be produced
        /// </summary>
        public SingleValue product { set; get; } = new SingleValue();
        public List<WorkOrder> workorders { set; get; } = new List<WorkOrder>();
        public SingleValue user { set; get; } = new SingleValue();
        public double quantity { set; get; }
        public SingleValue responsible { set; get; } = new SingleValue();
        public List<Component> components { set; get; } = new List<Component>();
        public List<Component> byproducts { set; get; } = new List<Component>();
        
        public MOBiz GetMOBiz()
        {
            
                MOBiz Returned = new MOBiz() { BOM = bom.id, Date = DateTime.Now.Date, Desc = "", Product = ProductCol.GetEqualProductByRef(product.name).ID, Quantity = quantity, Ref = id.ToString(), Responsible = responsible.id, ResponsibleName = responsible.name, StartTime = DateTime.Now, UserStarted = user.id, BOMName = bom.name, ProductName = product.name, UserStartedName = user.name };
                foreach (Component objComponnet in components)
                {
                    Returned.ComponentCol.Add(new MOComponentBiz() { MeasurementUnitBiz = MeasurementUnitCol.GetMeasureUnitByRef(objComponnet.uom.id.ToString()), MO = id, MOBiz = Returned, Product = ProductCol.GetEqualProductByRef(objComponnet.name).ID, Quantity = objComponnet.quantity, ProductRef = objComponnet.id });
                     
            }
                foreach(WorkOrder objSingle in workorders)
                {
                    Returned.WorkOrderCol.Add(new WorkOrderBiz() {Ref = objSingle.id.ToString(), Date=DateTime.Now.Date,Desc=objSingle.operation,Product= ProductCol.GetEqualProductByRef(objSingle.product.name).ID,Quantity = objSingle.product.quantity });
                }
                foreach(Component objComponant in byproducts)
                {
                    Returned.ByproductCol.Add(new MOComponentBiz() {MeasurementUnitBiz = MeasurementUnitCol.GetMeasureUnitByRef(objComponant.uom.id.ToString()), MO = id, MOBiz = Returned, Product = ProductCol.GetEqualProductByRef(objComponant.name).ID, Quantity = objComponant.quantity,ProductRef=objComponant.id });
                }
                return Returned;
             
        }
    }

    [Route("api/[controller]")]
    //[Route("mrp_production/create")]
    [ApiController]
    public class MOAPIController : ControllerBase
    {

        private readonly IHubContext<AlgHub> _hubContext;

        public MOAPIController(IHubContext<AlgHub> hubContext)
        {
            _hubContext = hubContext;
        }
        [HttpPost]
        public async Task Create(MO objParam)
        {
            var request = this.HttpContext;
            MOBiz objMo = objParam.GetMOBiz();

            string strToken = SysUtility.GetToken(this.HttpContext);
            strToken = strToken.Replace("Bearer ", "");
            //MOSimple objSimple = objParam.MOBiz.GetSimple().;
            //strToken = SysData.OnlineToken;
            string strURL = SysData.ForeignURL + "mrp_production/create";
            var requestMessage = new HttpRequestMessage(HttpMethod.Post, strURL);
            requestMessage.Headers.Add("Authorization", $"Bearer {strToken}");

            requestMessage.Headers.Add("X-API-KEY", strToken);
            requestMessage.Headers.Add("X-Timezone", DateTime.Now.ToString("O"));
            string strTemp = System.Text.Json.JsonSerializer.Serialize<MO>(objMo.GetMO());
            requestMessage.Content = new StringContent(strTemp, Encoding.UTF8, "application/json");
            //requestMessage.AddParameter("application/json", body, ParameterType.RequestBody);
            HttpClient _httpClient = new HttpClient();
            var response = await _httpClient.SendAsync(requestMessage);


        }
        async Task Create1(MO objParam)
        {
            var request = this.HttpContext;
            string strToken = SysUtility.GetToken(this.HttpContext);
            if (strToken == "")
            {
                await Task.FromResult(Unauthorized("Unauthorized"));
                return;
            }
            else
            {

                string strUser = SysUtility.GetClaimValue(strToken, "UserName").Replace("'", "");
                if (strUser != "oddoo")
                {
                    await Task.FromResult(Unauthorized("Unauthorized"));
                    return;
                }
                MOBiz objMO = objParam.GetMOBiz();
                objMO.AddUniqueRef();

                await _hubContext.Clients.All.SendAsync("ReceiveMessage", "API:" + AlgHubServiceMessageType.MoReq.ToString(), System.Text.Json.JsonSerializer.Serialize(objMO.GetSimple()));
            }


        }
        [HttpPut]
        public async Task<bool> ChangeStatusByUser(ChangeMOStatusParam objParam)
        {
            MOBiz objMO = new MOBiz() { ID = objParam.intMO };
            bool Returned = false;
            UserBiz objUser = new UserBiz();

            if (UserBiz.CheckUser(objParam.strUserName, objParam.strPass, out objUser))
            {
                if (objUser.UserFunctionInstantCol.GetIndex(MOBiz.MOEditStatus) > -1)
                {
                    objMO.EditStatus(objParam.intStatus, objUser.ID);
                    
                   objMO.StatusTime = DateTime.Now;
                    int intTemp = 0;
                    objMO = new MOBiz(objParam.intMO);
                    await _hubContext.Clients.All.SendAsync("ReceiveMessage", "API:EditStatus", System.Text.Json.JsonSerializer.Serialize(objMO.GetSimple()));

                  
                    bool blCreated = false;
                    using (var objMutex = new Mutex(false, SysData.MOUpdateStatusMutex))
                    {
                        if (objMutex.WaitOne())
                        {
                            try
                            {
                                blCreated = true;

                                MOCol objCol = new MOCol(true);
                                objCol.Add(objMO);
                                if (objCol.Count > 0)
                                {

                                    objCol.SetCol();

                                    intTemp = 0;
                                    if (int.TryParse(objMO.Ref, out intTemp))
                                    {

                                        objMO.SetMeasureCol();
                                        ProgressUpdateRequest objRequest = objMO.GetProgressUpdateRequest();
                                        try
                                        {
                                            OdooScadaApiClient objClient = new OdooScadaApiClient(SysData.ODOOURL, SysData.APIKey);
                                            objClient.UpdateManufacturingOrderProgress(intTemp, DateTime.Now, objRequest);
                                            objMO.EditMOStatusChanged();
                                        }
                                        catch { }
                                    }




                                }
                            }
                            catch (Exception ex) { }
                            finally
                            {
                                if (blCreated)
                                {
                                    objMutex.ReleaseMutex();
                                }

                            }

                        }
                    }
                  
                    Returned = true;


                }

        
        } 
        

            return Returned;




        }

        [HttpGet]
        public async Task<List<MOSimple>> GetMO(string intStatus,int intDateRange,DateTime dtStart,DateTime dtEnd)
        {
            MOCol objCol = new MOCol(intStatus,intDateRange==1,dtStart,dtEnd);  
            List<MOSimple> Returned = objCol.Cast<MOBiz>().Select(x=>x.GetSimple()).ToList();
             return  Returned;
        }
    }
}
