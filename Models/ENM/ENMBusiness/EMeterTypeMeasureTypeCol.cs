using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlgorithmatENM.ENM.ENMDb;
using SharpVision.SystemBase;
using System.Collections;
using System.Data;
namespace AlgorithmatENM.ENM.ENMBiz
{
    public class EMeterTypeMeasureTypeCol:CollectionBase
    {

        #region Constructor
        public EMeterTypeMeasureTypeCol()
        {

        }
        public EMeterTypeMeasureTypeCol(bool blIsEmbty)
        {
            if (blIsEmbty)
                return;
            EMeterTypeMeasureTypeBiz objBiz = new EMeterTypeMeasureTypeBiz();
           

            EMeterTypeMeasureTypeDb objDb = new EMeterTypeMeasureTypeDb();

            DataTable dtTemp = objDb.Search();


            foreach (DataRow objDR in dtTemp.Rows)
            {
                objBiz = new EMeterTypeMeasureTypeBiz(objDR);
                Add(objBiz);
            }
        }

        #endregion
        #region Private Data

        #endregion
        #region Properties
        public EMeterTypeMeasureTypeBiz this[int intIndex]
        {
            get
            {
                return (EMeterTypeMeasureTypeBiz)this.List[intIndex];
            }
        }
        public MeterMeasureCol GetMeterMeasureCol(int intMeter,DateTime dtTime)
        { 

                MeterMeasureCol Returned = new MeterMeasureCol(true);
                foreach (EMeterTypeMeasureTypeBiz objBiz in this)
                    Returned.Add(objBiz.GetMeterMeasure(intMeter,dtTime));
                return Returned;
            }
        #endregion
        #region Private Method

        #endregion
        #region Public Method 
        public void Add(EMeterTypeMeasureTypeBiz objBiz)
        {
            List.Add(objBiz);
        }
        public EMeterTypeMeasureTypeCol GetCol(string strTemp)
        {
            EMeterTypeMeasureTypeCol Returned = new EMeterTypeMeasureTypeCol(true);
            foreach (EMeterTypeMeasureTypeBiz objBiz in this)
            {
                if (objBiz.MeasurTypeUnit.CheckStr(strTemp))
                    Returned.Add(objBiz);
            }
            return Returned;
        }
        public DataTable GetTable()
        {
            DataTable Returned = new DataTable();
            Returned.Columns.AddRange(new DataColumn[] { new DataColumn("EMeterType"), new DataColumn("EMeasureType"), new DataColumn("EMeasurTypeUnit"), new DataColumn("EMeasureTypeFactor"), new DataColumn("EMeasureTypeWordStartAddress"), new DataColumn("EMeasureTypeWordNo") ,new DataColumn("EMeasureTypeDataType") });
            DataRow objDr;
            foreach (EMeterTypeMeasureTypeBiz objBiz in this)
            {
                objDr = Returned.NewRow();
                objDr["EMeterType"] = objBiz.MeterType;
                objDr["EMeasureType"] = objBiz.MeasureTypeBiz.ID;
                objDr["EMeasurTypeUnit"] = objBiz.MeasurTypeUnit;
                objDr["EMeasureTypeFactor"] = objBiz.MeasureTypeFactor;
                objDr["EMeasureTypeWordStartAddress"] = objBiz.MeasureTypeWordStartAddress;
                objDr["EMeasureTypeWordNo"] = objBiz.MeasureTypeWordNo;
                objDr["EMeasureTypeDataType"] = (int)objBiz.DataType;
                Returned.Rows.Add(objDr);
            }
            return Returned;
        }

        #endregion
    }
}
