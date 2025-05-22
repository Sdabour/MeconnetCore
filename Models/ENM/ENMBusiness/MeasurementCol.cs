using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpVision.SystemBase;
using System.Data;
using System.Collections;
using AlgorithmatENM.ENM.ENMDb;
namespace AlgorithmatENM.ENM.ENMBiz
{
    public class MeasurementCol:CollectionBase
    {

        #region Constructor
        public MeasurementCol()
        {

        }
        public MeasurementCol(bool blIsEmbty)
        {
            if (blIsEmbty)
                return;
            MeasurementBiz objBiz = new MeasurementBiz();
        

            MeasurementDb objDb = new MeasurementDb();

            DataTable dtTemp = objDb.Search();


            foreach (DataRow objDR in dtTemp.Rows)
            {
                objBiz = new MeasurementBiz(objDR);
                Add(objBiz);
            }
        }
        public MeasurementCol(bool blIsDateRange,DateTime dtStart,DateTime dtEnd)
        {
            
            MeasurementBiz objBiz = new MeasurementBiz();


            MeasurementDb objDb = new MeasurementDb() { IsDateRange=blIsDateRange,StartDate=dtStart,EndDate=dtEnd};

            DataTable dtTemp = objDb.Search();


            foreach (DataRow objDR in dtTemp.Rows)
            {
                objBiz = new MeasurementBiz(objDR);
                Add(objBiz);
            }
        }
        #endregion
        #region Private Data

        #endregion
        #region Properties
        public MeasurementBiz this[int intIndex]
        {
            get
            {
                return (MeasurementBiz)this.List[intIndex];
            }
        }
        #endregion
        #region Private Method

        #endregion
        #region Public Method 
        public void Add(MeasurementBiz objBiz)
        {
            List.Add(objBiz);
        }
        public MeasurementCol GetCol(string strTemp)
        {
            MeasurementCol Returned = new MeasurementCol(true);
            foreach (MeasurementBiz objBiz in this)
            {
               // if (objBiz..CheckStr(strTemp))
                    Returned.Add(objBiz);
            }
            return Returned;
        }
        public DataTable GetTable()
        {
            DataTable Returned = new DataTable();
            Returned.Columns.AddRange(new DataColumn[] { new DataColumn("MeterID"), new DataColumn("MeterTypeID"), new DataColumn("MeterTypeCode"), new DataColumn("MeterTypeNameA"), new DataColumn("MeterTypeNameE"), new DataColumn("MeterGroup"), new DataColumn("MeterGroupCode"), new DataColumn("MeterGroupNameA"), new DataColumn("MeterGroupNameE"), new DataColumn("MeterGroupDesc"), new DataColumn("LastNonZeroMeasureDate", System.Type.GetType("System.DateTime")), new DataColumn("LastNonZeroMeasureTime", System.Type.GetType("System.DateTime")), new DataColumn("LastNonZeroMeasureUnit"), new DataColumn("LastNonZeroMeasureValue"), new DataColumn("LastNonZeroMeasureType"), new DataColumn("LastNonZeroMeasureTypeID"), new DataColumn("LastNonZeroMeasureTypeCode"), new DataColumn("LastNonZeroMeasureTypeNameA"), new DataColumn("LastNonZeroMeasureTypeNameE"), new DataColumn("LastMeasureDate", System.Type.GetType("System.DateTime")), new DataColumn("LasMeasureTime", System.Type.GetType("System.DateTime")), new DataColumn("LastMeasureUnit"), new DataColumn("LastMeasureValue"), new DataColumn("LastMeasureType"), new DataColumn("LastMeasureTypeID"), new DataColumn("LastMeasureTypeCode"), new DataColumn("LastMeasureTypeNameA"), new DataColumn("LastMeasureTypeNameE") });
            DataRow objDr;
            foreach (MeasurementBiz objBiz in this)
            {
                objDr = Returned.NewRow();
                objDr["MeterID"] = objBiz.MeterID;
                objDr["MeterTypeID"] = objBiz.MeterTypeID;
                objDr["MeterTypeCode"] = objBiz.MeterTypeCode;
                objDr["MeterTypeNameA"] = objBiz.MeterTypeNameA;
                objDr["MeterTypeNameE"] = objBiz.MeterTypeNameE;
                objDr["MeterGroup"] = objBiz.MeterGroup;
                objDr["MeterGroupCode"] = objBiz.MeterGroupCode;
                objDr["MeterGroupNameA"] = objBiz.MeterGroupNameA;
                objDr["MeterGroupNameE"] = objBiz.MeterGroupNameE;
                objDr["MeterGroupDesc"] = objBiz.MeterGroupDesc;
                objDr["LastNonZeroMeasureDate"] = objBiz.LastNonZeroMeasureDate;
                objDr["LastNonZeroMeasureTime"] = objBiz.LastNonZeroMeasureTime;
                objDr["LastNonZeroMeasureUnit"] = objBiz.LastNonZeroMeasureUnit;
                objDr["LastNonZeroMeasureValue"] = objBiz.LastNonZeroMeasureValue;
                objDr["LastNonZeroMeasureType"] = objBiz.LastNonZeroMeasureType;
                objDr["LastNonZeroMeasureTypeID"] = objBiz.LastNonZeroMeasureTypeID;
                objDr["LastNonZeroMeasureTypeCode"] = objBiz.LastNonZeroMeasureTypeCode;
                objDr["LastNonZeroMeasureTypeNameA"] = objBiz.LastNonZeroMeasureTypeNameA;
                objDr["LastNonZeroMeasureTypeNameE"] = objBiz.LastNonZeroMeasureTypeNameE;
                objDr["LastMeasureDate"] = objBiz.LastMeasureDate;
                objDr["LasMeasureTime"] = objBiz.LasMeasureTime;
                objDr["LastMeasureUnit"] = objBiz.LastMeasureUnit;
                objDr["LastMeasureValue"] = objBiz.LastMeasureValue;
                objDr["LastMeasureType"] = objBiz.LastMeasureType;
                objDr["LastMeasureTypeID"] = objBiz.LastMeasureTypeID;
                objDr["LastMeasureTypeCode"] = objBiz.LastMeasureTypeCode;
                objDr["LastMeasureTypeNameA"] = objBiz.LastMeasureTypeNameA;
                objDr["LastMeasureTypeNameE"] = objBiz.LastMeasureTypeNameE;
                Returned.Rows.Add(objDr);
            }
            return Returned;
        }
        public List<GroupSimple> GetGroupSimple()
        {
            List<GroupSimple> Returned = new List<GroupSimple>();
            MeterSimple objMeterSimple;
            //var vrGroupLst = from objMeasure in this.Cast<MeasurementBiz>()
            //            group objMeasure by new GroupSimple() { ID = objMeasure.MeterGroup, Code = objMeasure.MeterGroupCode, Desc = objMeasure.MeterGroupDesc, NameA = objMeasure.MeterGroupNameA, NameE = objMeasure.MeterGroupNameE } into objGroup
            //            select objGroup;
            var vrGroupLst = from objMeasure in this.Cast<MeasurementBiz>()
                             group objMeasure by new {objMeasure.MeterGroup, objMeasure.MeterGroupCode, objMeasure.MeterGroupDesc, objMeasure.MeterGroupNameA,  objMeasure.MeterGroupNameE } into objNewGroup
                             select objNewGroup;
            int intCount = vrGroupLst.Count();
            DataTable dtTemp = GetTable();
            GroupSimple objGroup = new GroupSimple();
            foreach(var vrGroup in vrGroupLst)
            {
                objGroup = new GroupSimple() { Code = vrGroup.Key.MeterGroupCode, Desc = vrGroup.Key.MeterGroupDesc,ID=vrGroup.Key.MeterGroup,NameA=vrGroup.Key.MeterGroupNameA, NameE=vrGroup.Key.MeterGroupNameE};
                //var vrMeterLst = from objMeasure1 in vrGroup group objMeasure1 by new MeterSimple() {Desc=objMeasure1.MeterDesc,GroupCode=objMeasure1.MeterGroupCode,GroupDesc=objMeasure1.MeterGroupDesc,GroupID=objMeasure1.MeterGroup,GroupNameA=objMeasure1.MeterGroupNameA,GroupNameE=objMeasure1.MeterGroupNameE,ID=objMeasure1.MeterID,TypeCode=objMeasure1.MeterTypeCode,TypeID=objMeasure1.MeterTypeID,TypeNameA=objMeasure1.MeterTypeNameA,TypeNameE=objMeasure1.MeterTypeNameE } into objMeter select objMeter;
                var vrMeterLst = from objMeasure1 in vrGroup group objMeasure1 by  new { objMeasure1.MeterDesc,objMeasure1.MeterGroupCode,objMeasure1.MeterGroupDesc, objMeasure1.ProductName,objMeasure1.MeterGroup, objMeasure1.MeterGroupNameA, objMeasure1.MeterGroupNameE, objMeasure1.MeterID, objMeasure1.MeterTypeCode,  objMeasure1.MeterTypeID, objMeasure1.MeterTypeNameA, objMeasure1.MeterTypeNameE }
                into objNewMeter select objNewMeter;
                intCount = vrMeterLst.Count();
                foreach (var vrMeter in vrMeterLst)
                {
                    objMeterSimple = new MeterSimple() { Desc = vrMeter.Key.MeterDesc, GroupCode = vrMeter.Key.MeterGroupCode, GroupDesc = vrMeter.Key.MeterGroupDesc, GroupID = vrMeter.Key.MeterGroup, GroupNameA = vrMeter.Key.MeterGroupNameA, GroupNameE = vrMeter.Key.MeterGroupNameE, ID = vrMeter.Key.MeterID, TypeCode = vrMeter.Key.MeterTypeCode, TypeID = vrMeter.Key.MeterTypeID, TypeNameA = vrMeter.Key.MeterTypeNameA, TypeNameE = vrMeter.Key.MeterTypeNameE,ProductName=vrMeter.Key.ProductName };
                    objMeterSimple.MeasureLst = vrMeter.ToList().GetSimpleLst();
                   objGroup.MeterLst.Add(objMeterSimple);
                }
                objGroup.LastReadTime = DateTime.Now.ToString("HH:mm:ss");
                Returned.Add(objGroup);
            }
            return Returned;
        }
        public static MeasurementCol GetTodayMeasurement()
        {
            MeasurementCol Returned = new MeasurementCol(true);
            MeasurementDb objDb = new MeasurementDb() { MeasureDateRange = true, MeasureDate = DateTime.Now };
            DataTable dtTemp = objDb.Search();

            MeasurementBiz objBiz;
            foreach (DataRow objDR in dtTemp.Rows)
            {
                objBiz = new MeasurementBiz(objDR);
               Returned.Add(objBiz);
            }
            return Returned;
        }
        #endregion
    }
}