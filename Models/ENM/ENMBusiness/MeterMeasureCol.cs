using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpVision.SystemBase;
using AlgorithmatENM.ENM.ENMDb;
using System.Data;
using System.Collections;
namespace AlgorithmatENM.ENM.ENMBiz
{
    public class MeterMeasureCol : CollectionBase
    {

        #region Constructor
        public MeterMeasureCol(int intMeter, int intMeasureType, bool blIsDateRange, DateTime dtStartDate, DateTime dtEndDate, bool blJustLastValue, bool blJustLastValueByDate)
        {
            MeterMeasureDb objDb = new MeterMeasureDb();
            objDb.Meter = intMeter;
            objDb.MeasureType = intMeasureType;
            objDb.IsDateRange = blIsDateRange;
            objDb.DateStart = dtStartDate;
            objDb.DateEnd = dtEndDate;
            objDb.JustLastValue = blJustLastValue;
            objDb.JustLastValueByDate = blJustLastValueByDate;
            DataTable dtTemp = objDb.Search();
            DataRow[] arrDr = dtTemp.Select("", "EMeter,EMeasureTime desc");
            MeterMeasureBiz objBiz;
            foreach (DataRow objDr in arrDr)
            {
                objBiz = new MeterMeasureBiz(objDr);
                Add(objBiz);

            }

        }
        public MeterMeasureCol(bool blIsEmbty)
        {
            if (blIsEmbty)
                return;
            MeterMeasureBiz objBiz = new MeterMeasureBiz();


            MeterMeasureDb objDb = new MeterMeasureDb();

            DataTable dtTemp = objDb.Search();


            foreach (DataRow objDR in dtTemp.Rows)
            {
                objBiz = new MeterMeasureBiz(objDR);
                Add(objBiz);
            }
        }

        #endregion
        #region Private Data

        #endregion
        #region Properties
        public MeterMeasureBiz this[int intIndex]
        {
            get
            {
                return (MeterMeasureBiz)this.List[intIndex];
            }
        }
        #endregion
        #region Private Method

        #endregion
        #region Public Method 
        public void Add(MeterMeasureBiz objBiz)
        {
            List.Add(objBiz);
        }
        public MeterMeasureCol GetCol(string strTemp)
        {
            MeterMeasureCol Returned = new MeterMeasureCol(true);
            foreach (MeterMeasureBiz objBiz in this)
            {
                //if (objBiz.Name.CheckStr(strTemp))
                Returned.Add(objBiz);
            }
            return Returned;
        }
        public List<TankBiz> GetTankLst(string strOrder,bool blIsDateGroup, bool blIsTimeGroup)
        {
            var vrTankLst = from vrMeasure in this.Cast<MeterMeasureBiz>()
                            group vrMeasure by new { Name = vrMeasure.MeterBiz.Desc, DateStr = blIsDateGroup || blIsTimeGroup ? vrMeasure.MeasureTime.ToString("yyyy-MM-dd") : "", TimeStr = blIsTimeGroup ? vrMeasure.MeasureTime.ToString("HH:mm") : "", ProductName = vrMeasure.ProductName } into vrTankGroup
                            select vrTankGroup;
            List<TankBiz> lstTank = new List<TankBiz>();
            TankBiz objBiz;
            List<MeterMeasureBiz> lstMeasure;
            foreach (var objTank in vrTankLst)
            {
                objBiz = new TankBiz() { DateStr = objTank.Key.DateStr, Name = objTank.Key.Name, ProductName = objTank.Key.ProductName, TimeStr = objTank.Key.TimeStr,OrderCode=strOrder, };

                lstMeasure = objTank.ToList().Where(x => x.MeasureType == TankBiz.HeightType).OrderByDescending(y => y.MeasureTime).ToList(); objBiz.Height = lstMeasure.Count == 0 ? 0 : lstMeasure[0].CurrentValue;

                lstMeasure = objTank.ToList().Where(x => x.MeasureType == TankBiz.TempType).OrderByDescending(y => y.MeasureTime).ToList();
                objBiz.Temp = lstMeasure.Count == 0 ? 0 : lstMeasure[0].CurrentValue;

                lstMeasure = objTank.ToList().Where(x => x.MeasureType == TankBiz.VolumeType).OrderByDescending(y => y.MeasureTime).ToList(); objBiz.Volume = lstMeasure.Count == 0 ? 0 : lstMeasure[0].CurrentValue;


                lstMeasure = objTank.ToList().Where(x => x.MeasureType == TankBiz.DensityType).OrderByDescending(y => y.MeasureTime).ToList(); objBiz.Density = lstMeasure.Count == 0 ? 0 : lstMeasure[0].CurrentValue;


                lstMeasure = objTank.ToList().Where(x => x.MeasureType == TankBiz.MassType).OrderByDescending(y => y.MeasureTime).ToList(); objBiz.Mass = lstMeasure.Count == 0 ? 0 : lstMeasure[0].CurrentValue;

                lstMeasure = objTank.ToList().Where(x => x.MeasureType == TankBiz.WeightType).OrderByDescending(y => y.MeasureTime).ToList();
                objBiz.Weight = lstMeasure.Count == 0 ? 0 : lstMeasure[0].CurrentValue;

                lstTank.Add(objBiz);
            }
            return lstTank;
        }
        public DataTable GetTable()
        {
            DataTable Returned = new DataTable();
            Returned.Columns.AddRange(new DataColumn[] { new DataColumn("MeasureID"), new DataColumn("EMeter"), new DataColumn("EMeasureDate", System.Type.GetType("System.DateTime")), new DataColumn("EMeasureTime", System.Type.GetType("System.DateTime")), new DataColumn("EMeasureType"), new DataColumn("EMeasurTypeUnit"), new DataColumn("EMeasureTypeFactor"), new DataColumn("EMeasureTypeWordStartAddress"), new DataColumn("EMeasureTypeWordNo"), new DataColumn("EMeasureValue"), new DataColumn("EMeasurePreviousValue") });
            DataRow objDr;
            foreach (MeterMeasureBiz objBiz in this)
            {
                objDr = Returned.NewRow();
                objDr["MeasureID"] = objBiz.MeasureID;
                objDr["EMeter"] = objBiz.Meter;
                objDr["EMeasureDate"] = objBiz.MeasureDate;
                objDr["EMeasureTime"] = objBiz.MeasureTime;
                objDr["EMeasureType"] = objBiz.MeasureType;
                objDr["EMeasurTypeUnit"] = objBiz.MeasurTypeUnit;
                objDr["EMeasureTypeFactor"] = objBiz.MeasureTypeFactor;
                objDr["EMeasureTypeWordStartAddress"] = objBiz.MeasureTypeWordStartAddress;
                objDr["EMeasureTypeWordNo"] = objBiz.MeasureTypeWordNo;
                objDr["EMeasureValue"] = objBiz.MeasureValue;
                objDr["EMeasurePreviousValue"] = objBiz.MeasurePreviousValue;
                Returned.Rows.Add(objDr);
            }
            return Returned;
        }
        public DataTable GetTempTable(int intService)
        {
            DataTable Returned = new DataTable();
            Returned.Columns.AddRange(new DataColumn[] { new DataColumn("Service"), new DataColumn("EMeter"), new DataColumn("EMeasureDate", System.Type.GetType("System.DateTime")), new DataColumn("EMeasureTime", System.Type.GetType("System.DateTime")), new DataColumn("EMeasureType"), new DataColumn("EMeasurTypeUnit"), new DataColumn("EMeasureTypeFactor"), new DataColumn("EMeasureTypeWordStartAddress"), new DataColumn("EMeasureTypeWordNo"), new DataColumn("EMeasureValue"), new DataColumn("EMeasurePreviousValue") });
            //,new DataColumn("MeasureID") 
            DataRow objDr;
            foreach (MeterMeasureBiz objBiz in this)
            {

                objDr = Returned.NewRow();
                if (objBiz.MeasureValue <= 0.1)
                {
                    continue;
                }
                objDr["Service"] = intService;
                //objDr["MeasureID"] = objBiz.MeasureID;
                objDr["EMeter"] = objBiz.Meter;
                objDr["EMeasureDate"] = objBiz.MeasureDate;
                objDr["EMeasureTime"] = objBiz.MeasureTime;
                objDr["EMeasureType"] = objBiz.MeasureType;
                objDr["EMeasurTypeUnit"] = objBiz.MeasurTypeUnit;
                objDr["EMeasureTypeFactor"] = objBiz.MeasureTypeFactor;
                objDr["EMeasureTypeWordStartAddress"] = objBiz.MeasureTypeWordStartAddress;
                objDr["EMeasureTypeWordNo"] = objBiz.MeasureTypeWordNo;
                objDr["EMeasureValue"] = objBiz.MeasureValue;
                objDr["EMeasurePreviousValue"] = objBiz.MeasurePreviousValue;
                Returned.Rows.Add(objDr);
            }
            return Returned;
        }

        public DataTable GetViewTable()
        {
            DataTable Returned = new DataTable();
            Returned.Columns.AddRange(new DataColumn[] { new DataColumn("MeasureID"), new DataColumn("EMeter"), new DataColumn("EMeasureDate"), new DataColumn("EMeasureTime"), new DataColumn("EMeasureType"), new DataColumn("EMeasurTypeUnit"), new DataColumn("EMeasureValue"), new DataColumn("EMeasurePreviousValue") });
            DataRow objDr;
            foreach (MeterMeasureBiz objBiz in this)
            {
                objDr = Returned.NewRow();
                objDr["MeasureID"] = objBiz.MeasureID;
                objDr["EMeter"] = objBiz.MeterBiz.Desc;
                objDr["EMeasureDate"] = "-" + objBiz.MeasureDate.ToString("yyyy-MM-dd") + "-";
                objDr["EMeasureTime"] = "-" + objBiz.MeasureTime.ToString("HH:mm:ss") + "-";
                objDr["EMeasureType"] = objBiz.MeasureTypeName;
                objDr["EMeasurTypeUnit"] = objBiz.MeasurTypeUnit;

                objDr["EMeasureValue"] = objBiz.MeasureValue.ToString("0.00");
                objDr["EMeasurePreviousValue"] = objBiz.MeasurePreviousValue;
                Returned.Rows.Add(objDr);
            }
            return Returned;
        }
        public void Save1()
        {
            DataTable dtTemp = GetTable();
            MeterMeasureDb objDb = new MeterMeasureDb();
            objDb.MeasureTable = dtTemp;
            objDb.JoinMeterMeasure();
        }
        public void Save(int intService)
        {
            DataTable dtTemp = GetTempTable(intService);
            MeterMeasureDb objDb = new MeterMeasureDb();
            objDb.MeasureTable = dtTemp;
            objDb.Service = intService;
            objDb.SaveMeterMeasure();
        }
        #endregion
    }
}
