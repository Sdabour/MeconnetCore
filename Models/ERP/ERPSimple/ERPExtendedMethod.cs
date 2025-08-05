using AlgorithmatENM.ERP.ERPSimple;
using AlgorithmatENM.Models.ERP.ERPBusiness;
using AlgorithmatENM.Models.ERP.ERPSimple;
using AlgorithmatENMMVCCore.Controllers;
using AlgorithmatENMMVCCore.Hubs;
using SharpVision.UMS.UMSBusiness;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlgorithmatENM.ERP.ERPBusiness
{
    public static class ERPExtendedMethod
    {
        public static List<WorkOrderSimple1> GetWorkOrderLst(this BufferMeasureCol objCol)
        {
            List<WorkOrderSimple1> Returned = new List<WorkOrderSimple1>();
            var vrMeasureGroup = from objMeasure in objCol.Cast<BufferMeasureBiz>()
                                 orderby objMeasure.MeasureMinTime
                                 group objMeasure by new { WorkOrder = objMeasure.MeasureWorkOrder, Date = objMeasure.MeasureDate.ToString("yyyyMMdd") } into objMeasureGroup
                                 select objMeasureGroup;
            WorkOrderSimple1 objSImple;

            foreach (var vrMeasure in vrMeasureGroup)
            {
                objSImple = new WorkOrderSimple1() { Date = vrMeasure.Key.Date, WorkOrder = vrMeasure.Key.WorkOrder, StartTime = vrMeasure.First().MeasureMinTime.ToString("HH:mm:ss"), EndTime = vrMeasure.Last().MeasureTime.ToString("HH:mm:ss") };
                objSImple.BOM = vrMeasure.ToList().Where(x => x.BufferProductID > 0).GroupBy(y => new { y.BufferProductCode, y.BufferProductNameA, y.BufferProductNameE }).Select(z => new BOMSimple() { Code = z.Key.BufferProductCode, Date = z.First().MeasureDate.ToString("yyyy-MM-dd"), EndTime = z.First().MeasureMinTime.ToString("HH:mm"), StartTime = z.Last().MeasureMinTime.ToString("HH:mm"), Desc = z.First().BufferDesc, Value = z.ToList().Sum(m => m.ActualValue) }).ToList();
                //objSImple.BOM = vrMeasure.ToList().Where(x => x.BufferProductID > 0).Select(y => new BOMSimple() { Code = y.BufferProductCode, Date = vrMeasure.Key.Date, EndTime = y.MeasureTime.ToString("HH:mm"), StartTime = y.MeasureMinTime.ToString("HH:mm"), Desc = y.BufferDesc, Value = y.MeasureValue }).ToList();
                objSImple.MachineLst = vrMeasure.ToList().Where(x => x.BufferMachineID > 0).Select(y => new RouteSimple() { Code = y.BufferMachineCode, Date = vrMeasure.Key.Date, EndTime = y.MeasureTime.ToString("HH:mm"), StartTime = y.MeasureMinTime.ToString("HH:mm"), Desc = y.BufferMachineNameA, ProcessingPeriod = (y.MeasureTime.Subtract(y.MeasureMinTime).Minutes / 60) }).ToList();

                objSImple.WorkCenterLst = vrMeasure.ToList().Where(x => x.MeasureValue == 1 && x.BufferCenterID > 0).Select(y => new RouteSimple()
                {
                    Code = y.BufferCenterCode,
                    Date = vrMeasure.Key.Date,
                    EndTime = y.MeasureTime.ToString("HH:mm"),
                    StartTime = y.MeasureMinTime.ToString("HH:mm"),
                    Desc = y.BufferCenterNameA,
                    ProcessingPeriod = (y.MeasureTime.Subtract(y.MeasureMinTime).Minutes / 60)
                }).ToList();
                Returned.Add(objSImple);
            }

            return Returned;
        }
        public static MOSimple GetSimple(this MOBiz objBiz)
        {
            MOSimple Returned = new MOSimple() { BOM = objBiz.BOM, BOMName = objBiz.BOMName, Date = objBiz.Date, Desc = objBiz.Desc, ID = objBiz.ID, Product = objBiz.Product, ProductName = objBiz.ProductName, Quantity = objBiz.Quantity, Ref = objBiz.Ref, Responsible = objBiz.Responsible, ResponsibleName = objBiz.ResponsibleName, StartTime = objBiz.StartTime, Status = (int)objBiz.Status, StatusTime = objBiz.StatusTime, UserStarted = objBiz.UserStarted, UserStartedName = objBiz.UserStartedName };
            Returned.WorkorderLst = objBiz.WorkOrderCol.Cast<WorkOrderBiz>().Select(x => x.GetSimple()).ToList();
            Returned.ComponentLst = objBiz.ComponentCol.Cast<MOComponentBiz>().Select(x=> x.GetSimple()).ToList();
            Returned.ByproductLst = objBiz.ByproductCol.Cast<MOComponentBiz>().Select(x=>x.GetSimple()).ToList();
            return Returned;

        }
        public static MOBiz GetBiz(this MOSimple objBiz)
        {
            MOBiz Returned = new MOBiz() { BOM = objBiz.BOM, BOMName = objBiz.BOMName, Date = objBiz.Date, Desc = objBiz.Desc, ID = objBiz.ID, Product = objBiz.Product, ProductName = objBiz.ProductName, Quantity = objBiz.Quantity, Ref = objBiz.Ref, Responsible = objBiz.Responsible, ResponsibleName = objBiz.ResponsibleName, StartTime = objBiz.StartTime, Status = (MOStatus)objBiz.Status, StatusTime = objBiz.StatusTime, UserStarted = objBiz.UserStarted, UserStartedName = objBiz.UserStartedName };
            List<WorkOrderBiz> lstWorkOrder = objBiz.WorkorderLst.Select(x => x.GetBiz()).ToList();
            foreach (WorkOrderBiz objWorkOrder in lstWorkOrder)
            {
                Returned.WorkOrderCol.Add(objWorkOrder);
            }
            List<MOComponentBiz> lstMOComponent = objBiz.ComponentLst.Select(x => x.GetBiz()).ToList();
            foreach(MOComponentBiz objComponent in lstMOComponent) { Returned.ComponentCol.Add(objComponent); }

            //Returned.ComponentLst = objBiz.ComponentCol.Cast<MOComponentBiz>().Select(x => x.GetSimple()).ToList();
            List<MOComponentBiz> lstByproduct = objBiz.ByproductLst.Select(x => x.GetBiz()).ToList();
            foreach(MOComponentBiz mOComponentBiz in lstByproduct) { Returned.ByproductCol.Add(mOComponentBiz); }
         
            return Returned;

        }

        //this is an extended function but it is stopped temorarly
        public static MO GetMO(this MOBiz objBiz)
        {

            MO Returned = new MO() {quantity=objBiz.Quantity,responsible=new SingleValue() { id=objBiz.Responsible,name=objBiz.ResponsibleName},user=new SingleValue() {id=objBiz.UserStarted,name=objBiz.UserStartedName } };
            int intTemp = 0;
            int.TryParse(objBiz.Ref, out intTemp);
            Returned.id= intTemp;
            intTemp = 0;


            Returned.product = ProductCol.GetEqualProductByID(objBiz.Product);
            Returned.workorders = new List<WorkOrder>();
            foreach(WorkOrderBiz objWorkOrder in objBiz.WorkOrderCol)
            {
                intTemp = 0;
                int.TryParse(objWorkOrder.Ref,out intTemp);
                Returned.workorders.Add(new WorkOrder() { id = intTemp, operation = objWorkOrder.Desc, product = new SingleValueQuantity() { id = ProductCol.GetEqualProductByID(objWorkOrder.Product).id, name = objWorkOrder.ProductNameA, quantity = objWorkOrder.Quantity } });
            }
            Returned.components = new List<Component>();
            SingleValue objSingle = new SingleValue();
            foreach(MOComponentBiz objProduct in objBiz.ComponentCol)
            {
                intTemp = 0;
                objSingle = ProductCol.GetEqualProductByID(objProduct.Product);
                Returned.components.Add(new Component() { id = objSingle.id, name = objSingle.name, quantity = objProduct.Quantity, uom = new SingleValue() { id = objProduct.MeasurementUnitBiz.ID, name = objProduct.MeasurementUnitBiz.NameA } });
            }
            return Returned;
        }
        public static ProgressUpdateRequest GetProgressUpdateRequest(this MOBiz objBiz)
        {
            ProgressUpdateRequest Returned = new ProgressUpdateRequest() ;
          Returned.workcenter_id = objBiz.WorkOrderCol.Count > 0 ? objBiz.WorkOrderCol[0].MachineCenterID : 0 ;
            objBiz.SetMeasureCol();
           
            BufferBiz objBuffer = new BufferBiz() ;
            List<BufferBiz> lstBuffer = new List<BufferBiz>() ;
            int intTemp =0;
            double dblValue = 0;
            BufferMeasureBiz objMeasure;
            int intMeasureID = 0;
            foreach(WorkOrderBiz objWorkOrder in objBiz.WorkOrderCol)
            {
                intTemp=0;
                dblValue = 0;
                lstBuffer=objBiz.BufferCol.Cast<BufferBiz>().Where(x=>x.Machine== objWorkOrder.MachineID).ToList();
                if(lstBuffer.Count > 0 )
                {
                    objBuffer = lstBuffer[0];
                    dblValue = objBuffer.MeasurementCol.Cast<BufferMeasureBiz>().Sum(x=>x.ActualValue);
                }
                int.TryParse(objWorkOrder.Ref, out intTemp);
                Returned.workorders.Add(new Workorder() { id = intTemp, time_elapsed =(float)dblValue});
            }
            Returned.elapsed_time = Returned.workorders.Sum(x=>x.time_elapsed);
            //"ongoing", "finished", "failure", "paused"
            switch(objBiz.Status)
            {
                case MOStatus.Paused: Returned.status="paused";break;
                case MOStatus.Processing:
                    Returned.status = "ongoing";break;
                case MOStatus.Finished:
                    Returned.status = "finished"; break;
                  default:Returned.status = "";break;

            }
            Returned.timestamp = DateTime.Now.ToString("o");
            //Returned.status = objBiz.Status ==MOStatus.Processing ? "ongoing"
            foreach (MOComponentBiz objComponent in objBiz.ComponentCol)
            {
                intTemp = 0;
                
                dblValue = 0;
                lstBuffer = objBiz.BufferCol.Cast<BufferBiz>().Where(x => x.Product == objComponent.Product).ToList();
                if (lstBuffer.Count > 0)
                {
                    objBuffer = lstBuffer[0];
                    dblValue = objBuffer.MeasurementCol.Cast<BufferMeasureBiz>().Sum(x => x.ActualValue);
                }
                intTemp =objComponent.ProductRef;
                intMeasureID = 0;
                int.TryParse(objComponent.MeasurementUnitBiz.Code, out intMeasureID);
                    Returned.consumption.Add(new ConsumptionItem() { id = intTemp, quantity = (float)dblValue, uom_id = intMeasureID });
                

                }
            foreach (MOComponentBiz objByProduct in objBiz.ByproductCol)
            {
                intTemp = 0;

                dblValue = 0;
                lstBuffer = objBiz.BufferCol.Cast<BufferBiz>().Where(x => x.Product == objByProduct.Product).ToList();
                if (lstBuffer.Count > 0)
                {
                    objBuffer = lstBuffer[0];
                    dblValue = objBuffer.MeasurementCol.Cast<BufferMeasureBiz>().Sum(x => x.ActualValue);
                }
                intTemp = objByProduct.ProductRef;
                intMeasureID = 0;
                int.TryParse(objByProduct.MeasurementUnitBiz.Code, out intMeasureID);
                Returned.byproducts.Add(new Byproduct() { id = intTemp, quantity = (float)dblValue, uom_id = intMeasureID });
            }



            return Returned;
        }
            public static PLCSimple GetSimple(this PLCBiz objBiz)
        {
            return new PLCSimple() { CPUType = objBiz.CpuType, Desc = objBiz.Desc, ID = objBiz.ID, IP = objBiz.IP, Rack = objBiz.Rack, Slot = objBiz.Slot, Type = objBiz.Type };
        }
        public static BufferTypeSimple GetSimple(this BufferTypeBiz objBiz) { return new BufferTypeSimple() { Code = objBiz.Code, ID = objBiz.ID, NameA = objBiz.NameA, NameE = objBiz.NameE }; }
        public static ProcessSimple GetSimple(this ProcessBiz objBiz)
        {
            return new ProcessSimple() { Code = objBiz.Code, NameA = objBiz.NameA, ID = objBiz.ID, NameE = objBiz.NameE };
        }
        public static WorkCenterSimple GetSimple(this WorkCenterBiz objBiz)
        {
            return new WorkCenterSimple() { Code = objBiz.Code, NameE = objBiz.NameE, Desc = objBiz.Desc, ID = objBiz.ID, NameA = objBiz.NameA };
        }

        public static BufferSimple GetSimple(this BufferBiz objBiz)
        {
            return new BufferSimple() { Code = objBiz.Code, ID = objBiz.ID, Desc = objBiz.Desc, Machine = objBiz.Machine, Measurement = objBiz.Measurement, PLC = objBiz.PLCBiz.GetSimple(), PLCDataType = objBiz.PLCDataType, PLCVarType = objBiz.PLCVarType, Product = objBiz.Product, Size = objBiz.Size, Tag = objBiz.Tag, Type = objBiz.TypeBiz.GetSimple() };
        }
        public static BufferMeasureSimple GetSimple(this BufferMeasureBiz objBiz)
        {

            return new BufferMeasureSimple() {Buffer=objBiz.BufferBiz.GetSimple(),Date=objBiz.MeasureDate,FirstValue=objBiz.MeasureFirstValue,ID=objBiz.MeasureID,MaxValue=objBiz.MeasureMaxValue,MinTime=objBiz.MeasureMinTime,MinValue=objBiz.MeasureMinValue,Time=objBiz.MeasureTime,Value=objBiz.MeasureValue,WorkOrder=objBiz.MeasureWorkOrder };
        }
        public static WorkOrderBiz GetBiz(this WorkOrderSimple objSimple) { 
      return new WorkOrderBiz()
        {
            ID = objSimple.ID,
            MO = objSimple.MO,
            Ref = objSimple.Ref,
            Desc = objSimple.Desc,
            Type = objSimple.Type,
            Product = objSimple.Product,
            Date = objSimple.Date,
            Time = objSimple.Time,
            Quantity = objSimple.Quantity,
            Periority = objSimple.Periority,
            ProductCode = objSimple.ProductCode,
            ProductNameA = objSimple.ProductNameA,
            ProductNameE = objSimple.ProductNameE,
            ProductMeasurementUnit = objSimple.ProductMeasurementUnit,
            ProductMeasurementCode = objSimple.ProductMeasurementCode,
            ProductMeasurementNameA = objSimple.ProductMeasurementNameA,
            ProductMeasurementNameE = objSimple.ProductMeasurementNameE
        };
        }
        public static MOComponentBiz GetBiz(this MOComponentSimple objSimple)
        {
            return new MOComponentBiz()
            {
                MO = objSimple.MO,

                Quantity = objSimple.Quantity,
                Product = objSimple.Product.ID
               ,
                MeasurementUnitBiz = new MeasurementUnitBiz() { ID = objSimple.MeasurementUnit == null ? 0 : objSimple.MeasurementUnit.ID },ProductRef=objSimple.ProductRef
               
            };
        }

}
}