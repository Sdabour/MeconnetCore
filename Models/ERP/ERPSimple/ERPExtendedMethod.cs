using AlgorithmatENM.ERP.ERPSimple;
using AlgorithmatENM.Models.ERP.ERPSimple;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlgorithmatENM.ERP.ERPBusiness
{
    public static class ERPExtendedMethod
    {
        public static List<WorkOrderSimple> GetWorkOrderLst(this BufferMeasureCol objCol)
        {
            List<WorkOrderSimple> Returned = new List<WorkOrderSimple>();
            var vrMeasureGroup = from objMeasure in objCol.Cast<BufferMeasureBiz>()
                                 orderby objMeasure.MeasureMinTime
                                 group objMeasure by new { WorkOrder = objMeasure.MeasureWorkOrder, Date = objMeasure.MeasureDate.ToString("yyyyMMdd") } into objMeasureGroup
                                 select objMeasureGroup;
            WorkOrderSimple objSImple;

            foreach (var vrMeasure in vrMeasureGroup)
            {
                objSImple = new WorkOrderSimple() { Date = vrMeasure.Key.Date, WorkOrder = vrMeasure.Key.WorkOrder, StartTime = vrMeasure.First().MeasureMinTime.ToString("HH:mm:ss"), EndTime = vrMeasure.Last().MeasureTime.ToString("HH:mm:ss") };
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
            return new MOSimple() { BOM = objBiz.BOM, BOMName = objBiz.BOMName, Date = objBiz.Date, Desc = objBiz.Desc, ID = objBiz.ID, Product = objBiz.Product, ProductName = objBiz.ProductName, Quantity = objBiz.Quantity, Ref = objBiz.Ref, Responsible = objBiz.Responsible, ResponsibleName = objBiz.ResponsibleName, StartTime = objBiz.StartTime, Status = objBiz.Status, StatusTime = objBiz.StatusTime, UserStarted = objBiz.UserStarted, UserStartedName = objBiz.UserStartedName };
        }
        public static PLCSimple GetSimple(this PLCBiz objBiz)
        {
            return new PLCSimple() { CPUType = objBiz.CpuType, Desc = objBiz.Desc, ID = objBiz.ID, IP = objBiz.IP, Rack = objBiz.Rack, Slot = objBiz.Slot, Type = objBiz.Type };
        }
        public static BufferTypeSimple GetSimple(this BufferTypeBiz objBiz) { return new BufferTypeSimple() { Code = objBiz.Code, ID = objBiz.ID, NameA = objBiz.NameA, NameE = objBiz.NameE }; }
        public static BufferSimple GetSimple(this BufferBiz objBiz)
        {
            return new BufferSimple() { Code = objBiz.Code, ID = objBiz.ID, Desc = objBiz.Desc, Machine = objBiz.Machine, Measurement = objBiz.Measurement, PLC = objBiz.PLCBiz.GetSimple(), PLCDataType = objBiz.PLCDataType, PLCVarType = objBiz.PLCVarType, Product = objBiz.Product, Size = objBiz.Size, Tag = objBiz.Tag, Type = objBiz.TypeBiz.GetSimple() };
        }
        public static BufferMeasureSimple GetSimple(this BufferMeasureBiz objBiz) {

            return new BufferMeasureSimple() { Buffer=objBiz.bufferbi.GetSimple(),};
        }

    }
}