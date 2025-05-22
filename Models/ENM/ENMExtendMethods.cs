using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AlgorithmatENM.ERP.ERPBusiness;
namespace AlgorithmatENM.ENM.ENMBiz
{
    public static class ENMExtendMethods
    {
        public static List<MeasurementSimple> GetSimpleLst(this List<MeasurementBiz> objLst)
        {
            List<MeasurementSimple> Returned = new List<MeasurementSimple>();
            foreach (MeasurementBiz objBiz in objLst)
            {
                Returned.Add(objBiz.GetSimple());
            }
            return Returned;
        }

        public static List<MeasurementSimple> GetSimpleLst(this List<BufferMeasureBiz> objLst)
        {
            List<MeasurementSimple> Returned = new List<MeasurementSimple>();
            foreach (BufferMeasureBiz objBiz in objLst)
            {
                //Returned.Add(objBiz.GetSimple());
            }
            return Returned;
        }

        public static MeasurementCol GetMeasurementLst(this List<BufferMeasureBiz> objLst)
        {
            MeasurementCol Returned = new MeasurementCol(true);
            var vrMeasureGroup = from objMeasure in objLst
                                 orderby objMeasure.MeasureTime
                                 group objMeasure by new { PLCID = objMeasure.PLCBiz.ID, PLCDesc = objMeasure.PLCBiz.Desc, objMeasure.BufferID, BufferContent = objMeasure.BufferCode == null || objMeasure.BufferCode == "" ? objMeasure.BufferDesc : objMeasure.BufferCode, objMeasure.MeasureDate } into objMeasureGroup

                                 select objMeasureGroup;
            MeasurementBiz objMeasurement;
            foreach (var vrMeasure in vrMeasureGroup)
            {
                objMeasurement = new MeasurementBiz() { LasMeasureTime = vrMeasure.Last<BufferMeasureBiz>().MeasureTime, LastMeasureDate = vrMeasure.Last<BufferMeasureBiz>().MeasureDate, LastMeasureValue = vrMeasure.Last<BufferMeasureBiz>().MeasureValue, MeterDesc = vrMeasure.Key.PLCDesc, MeterGroup = vrMeasure.Last<BufferMeasureBiz>().BufferTypeID, MeterGroupCode = vrMeasure.Last<BufferMeasureBiz>().BufferTypeCode, MeterGroupDesc = vrMeasure.Last<BufferMeasureBiz>().BufferTypeNameA, MeterTypeNameE = vrMeasure.Last<BufferMeasureBiz>().BufferTypeNameE, MeterID = vrMeasure.Key.PLCID, MeterGroupNameA = vrMeasure.Last<BufferMeasureBiz>().BufferTypeNameA, MeterTypeNameA = vrMeasure.Last<BufferMeasureBiz>().BufferTypeNameA, MeterGroupNameE = vrMeasure.Last<BufferMeasureBiz>().BufferTypeNameE, MeterTypeCode = vrMeasure.Last<BufferMeasureBiz>().BufferTypeCode, MeterTypeID = vrMeasure.Last<BufferMeasureBiz>().BufferTypeID, ProductName = "", TypeMaxValue = vrMeasure.Last<BufferMeasureBiz>().MeasureMaxValue, TypeMinValue = vrMeasure.First<BufferMeasureBiz>().MeasureMinValue, LastMeasureType = vrMeasure.First<BufferMeasureBiz>().BufferTypeID, LastMeasureTypeCode = vrMeasure.First<BufferMeasureBiz>().BufferCode, LastMeasureTypeID = vrMeasure.First<BufferMeasureBiz>().BufferID, LastMeasureTypeNameA = vrMeasure.Key.BufferContent, LastMeasureTypeNameE = vrMeasure.Key.BufferContent, LastMeasureUnit = vrMeasure.First<BufferMeasureBiz>().BufferIsPerHour ? "L/H" : "", LastNonZeroMeasureValue = vrMeasure.First<BufferMeasureBiz>().MeasureMaxValue, LastNonZeroMeasureDate = vrMeasure.First<BufferMeasureBiz>().MeasureDate, LastNonZeroMeasureTime = vrMeasure.First<BufferMeasureBiz>().MeasureTime };
                if (vrMeasure.First().BufferIsPerHour)
                {

                }
                objMeasurement.LastMeasureValue = vrMeasure.First().BufferIsPerHour ? vrMeasure.ToList().Sum(x => ((x.MeasureValue + x.MeasureMinValue + x.MeasureMaxValue + x.MeasureFirstValue) / 4) * (((double)x.MeasureTime.Subtract(x.MeasureMinTime).Minutes) / 60)) : (objMeasurement.LastMeasureValue);

                Returned.Add(objMeasurement);

            }
            return Returned;
        }

        public static MeasurementSimple GetSimple(this MeasurementBiz objBiz)
        {
            MeasurementSimple Returned = new MeasurementSimple() { LasMeasureTime = objBiz.LasMeasureTime, LastMeasureDate = objBiz.LastMeasureDate, LastMeasureType = objBiz.LastMeasureType, LastMeasureTypeCode = objBiz.LastMeasureTypeCode, LastMeasureTypeID = objBiz.LastMeasureTypeID, LastMeasureTypeNameA = objBiz.LastMeasureTypeNameA, LastMeasureTypeNameE = objBiz.LastMeasureTypeNameE, LastMeasureUnit = objBiz.LastMeasureUnit, LastMeasureValue = objBiz.LastMeasureValue, LastNonZeroMeasureDate = objBiz.LastNonZeroMeasureDate, LastNonZeroMeasureTime = objBiz.LastNonZeroMeasureTime, LastNonZeroMeasureType = objBiz.LastNonZeroMeasureType, LastNonZeroMeasureTypeCode = objBiz.LastNonZeroMeasureTypeCode, LastNonZeroMeasureTypeID = objBiz.LastNonZeroMeasureTypeID, LastNonZeroMeasureTypeNameA = objBiz.LastNonZeroMeasureTypeNameA, LastNonZeroMeasureTypeNameE = objBiz.LastNonZeroMeasureTypeNameE, LastNonZeroMeasureUnit = objBiz.LastNonZeroMeasureUnit, LastNonZeroMeasureValue = objBiz.LastNonZeroMeasureValue, MeterGroup = objBiz.MeterGroup, MeterGroupCode = objBiz.MeterGroupCode, MeterGroupDesc = objBiz.MeterGroupDesc, MeterGroupNameA = objBiz.MeterGroupNameA, MeterGroupNameE = objBiz.MeterGroupNameE, MeterID = objBiz.MeterID, MeterTypeCode = objBiz.MeterTypeCode, MeterTypeID = objBiz.MeterTypeID, MeterTypeNameA = objBiz.MeterTypeNameA, MeterTypeNameE = objBiz.MeterTypeNameE, TypeMaxValue = objBiz.TypeMaxValue, TypeMinValue = objBiz.TypeMinValue, ProductName = objBiz.ProductName };

            return Returned;
        }

        //public static MeasurementSimple GetSimple(this BufferMeasureBiz objBiz)
        //{
        //    MeasurementSimple Returned = new MeasurementSimple() { LasMeasureTime = objBiz.LasMeasureTime, LastMeasureDate = objBiz.LastMeasureDate, LastMeasureType = objBiz.LastMeasureType, LastMeasureTypeCode = objBiz.LastMeasureTypeCode, LastMeasureTypeID = objBiz.LastMeasureTypeID, LastMeasureTypeNameA = objBiz.LastMeasureTypeNameA, LastMeasureTypeNameE = objBiz.LastMeasureTypeNameE, LastMeasureUnit = objBiz.LastMeasureUnit, LastMeasureValue = objBiz.LastMeasureValue, LastNonZeroMeasureDate = objBiz.LastNonZeroMeasureDate, LastNonZeroMeasureTime = objBiz.LastNonZeroMeasureTime, LastNonZeroMeasureType = objBiz.LastNonZeroMeasureType, LastNonZeroMeasureTypeCode = objBiz.LastNonZeroMeasureTypeCode, LastNonZeroMeasureTypeID = objBiz.LastNonZeroMeasureTypeID, LastNonZeroMeasureTypeNameA = objBiz.LastNonZeroMeasureTypeNameA, LastNonZeroMeasureTypeNameE = objBiz.LastNonZeroMeasureTypeNameE, LastNonZeroMeasureUnit = objBiz.LastNonZeroMeasureUnit, LastNonZeroMeasureValue = objBiz.LastNonZeroMeasureValue, MeterGroup = objBiz.MeterGroup, MeterGroupCode = objBiz.MeterGroupCode, MeterGroupDesc = objBiz.MeterGroupDesc, MeterGroupNameA = objBiz.MeterGroupNameA, MeterGroupNameE = objBiz.MeterGroupNameE, MeterID = objBiz.MeterID, MeterTypeCode = objBiz.MeterTypeCode, MeterTypeID = objBiz.MeterTypeID, MeterTypeNameA = objBiz.MeterTypeNameA, MeterTypeNameE = objBiz.MeterTypeNameE, TypeMaxValue = objBiz.TypeMaxValue, TypeMinValue = objBiz.TypeMinValue, ProductName = objBiz.ProductName };

        //    return Returned;
        //}

        public static MeterMeasureSimple GetSimple(this MeterMeasureBiz objBiz)
        {
            MeterMeasureSimple Returned = new MeterMeasureSimple() { Date = objBiz.MeasureDate, ID = objBiz.MeasureID, MeterDesc = objBiz.MeterBiz.Desc, MeterID = objBiz.MeterBiz.ID, Time = objBiz.MeasureTime, Type = objBiz.MeasureType, TypeName = objBiz.MeasureTypeName, Unit = objBiz.MeasurTypeUnit, Value = objBiz.MeasureValue, IsAccumulated = objBiz.MeasureTypeAccumulated, FirstValue = objBiz.FirstValue, MaxValue = objBiz.MaxValue, MinTime = objBiz.MinTime, MinValue = objBiz.MinValue, ProductName = objBiz.ProductName };
            return Returned;

        }
        public static MeterMeasureSimple GetSimple(this BufferMeasureBiz objBiz)
        {
            MeterMeasureSimple Returned = new MeterMeasureSimple() { Date = objBiz.MeasureDate, ID = objBiz.MeasureID, MeterDesc = objBiz.BufferContent, MeterID = objBiz.BufferID, Time = objBiz.MeasureTime, Type = objBiz.BufferTypeID, TypeName = objBiz.BufferTypeNameA, Unit = "", Value = objBiz.MeasureValue, IsAccumulated = false, FirstValue = objBiz.MeasureFirstValue, MaxValue = objBiz.MeasureMaxValue, MinTime = objBiz.MeasureMinTime, MinValue = objBiz.MeasureMinValue, ProductName = objBiz.BufferContent };
            return Returned;

        }
        public static MeasureAlertSimple GetSimple(this MeasureAlertBiz objBiz)
        {
            MeasureAlertSimple Returned = new MeasureAlertSimple() { Ack = objBiz.Ack, AckTime = objBiz.AckTime, AckUser = objBiz.AckUser, EMeasureTypeAccumulated = objBiz.EMeasureTypeAccumulated, EMeasureTypeNameA = objBiz.EMeasureTypeNameA, EMeasureTypeNameE = objBiz.EMeasureTypeNameE, EMeasureTypeUnit = objBiz.EMeasureTypeUnit, EMeterDesc = objBiz.EMeterDesc, ID = objBiz.ID, MaxValue = objBiz.MaxValue, MeasureType = objBiz.MeasureType, Meter = objBiz.Meter, MinValue = objBiz.MinValue, Reason = objBiz.Reason, SnoozeTime = objBiz.SnoozeTime, Stop = objBiz.Stop, StopTime = objBiz.StopTime, Time = objBiz.Time, UFN = objBiz.UFN, UN = objBiz.UN, Value = objBiz.Value };
            return Returned;
        }


    }
}