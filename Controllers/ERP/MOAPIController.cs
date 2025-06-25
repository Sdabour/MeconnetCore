using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AlgorithmatENM.ERP.ERPBusiness;
using Microsoft.AspNetCore.SignalR;
using AlgorithmatENMMVCCore.Hubs;
using System;
using AlgorithmatENM.ENM.ENMBiz;
using SharpVision.UMS.UMSBusiness;

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
    public class MO
    {
        public int id { get; set; }
        public SingleValue bom { set; get; } = new SingleValue();
        public SingleValue product { set; get; } = new SingleValue();
        public List<SingleValueQuantity> workorders = new List<SingleValueQuantity>();
        public SingleValue user { set; get; } = new SingleValue();
        public double quantity { set; get; }
        public SingleValue responsible { set; get; } = new SingleValue();
        public List<Component> components { set; get; } = new List<Component>();
        public List<Component> byproducts { set; get; } = new List<Component>();
        public MOBiz MOBiz
        {
            get
            {
                MOBiz Returned = new MOBiz() { BOM = bom.id, Date = DateTime.Now.Date, Desc = "", Product = product.id, Quantity = quantity, Ref = id.ToString(), Responsible = responsible.id,ResponsibleName=responsible.name,ID=id, StartTime = DateTime.Now, UserStarted = user.id,BOMName=bom.name,ProductName=product.name,UserStartedName=user.name };

                return Returned;
            }
        }
    }

    [Route("api/[controller]")]
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
            MOBiz objMO = objParam.MOBiz;
            objMO.AddUniqueRef();

            await _hubContext.Clients.All.SendAsync("ReceiveMessage", "API:" + AlgHubServiceMessageType.MoReq.ToString(), System.Text.Json.JsonSerializer.Serialize(objMO.GetSimple()));



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
                    await _hubContext.Clients.All.SendAsync("ReceiveMessage", "API:EditStatus" ,System.Text.Json.JsonSerializer.Serialize(objMO.GetSimple()));
                    Returned = true;
                }
            }

            return Returned;




        }


    }
}
