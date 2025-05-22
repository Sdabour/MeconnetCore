using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Collections;
using AlgorithmatENM.ERP.ERPDataBase;
using SharpVision.SystemBase;
namespace AlgorithmatENM.Models.ERP.ERPBusiness
{
    public class MeasurementUnitCol:CollectionBase
    {

        #region Constructor
        public MeasurementUnitCol()
        {

        }
        public MeasurementUnitCol(bool blIsEmbty)
        {
            if (blIsEmbty)
                return;
            MeasurementUnitBiz objBiz = new MeasurementUnitBiz();
            objBiz.ID = 0;
            objBiz.NameA = "غير محدد";
            objBiz.NameE = "Not Specified";
            Add(objBiz);

            MeasurementUnitDb objDb = new MeasurementUnitDb();

            DataTable dtTemp = objDb.Search();


            foreach (DataRow objDR in dtTemp.Rows)
            {
                objBiz = new MeasurementUnitBiz(objDR);
                Add(objBiz);
            }
        }

        #endregion
        #region Private Data

        #endregion
        #region Properties
        public MeasurementUnitBiz this[int intIndex]
        {
            get
            {
                return (MeasurementUnitBiz)this.List[intIndex];
            }
        }
        #endregion
        #region Private Method

        #endregion
        #region Public Method 
        public void Add(MeasurementUnitBiz objBiz)
        {
            List.Add(objBiz);
        }
        public MeasurementUnitCol GetCol(string strTemp)
        {
            MeasurementUnitCol Returned = new MeasurementUnitCol(true);
            foreach (MeasurementUnitBiz objBiz in this)
            {
                if (objBiz.NameA.CheckStr(strTemp))
                    Returned.Add(objBiz);
            }
            return Returned;
        }
        public DataTable GetTable()
        {
            DataTable Returned = new DataTable();
            Returned.Columns.AddRange(new DataColumn[] { new DataColumn("MeasurementID"), new DataColumn("MeasurementMain"), new DataColumn("MeasurementCode"), new DataColumn("MeasurementNameA"), new DataColumn("MeasurementNameE"), new DataColumn("MeasurementFactor"), new DataColumn("MeasurementIsBasic", System.Type.GetType("System.Boolean")) });
            DataRow objDr;
            foreach (MeasurementUnitBiz objBiz in this)
            {
                objDr = Returned.NewRow();
                objDr["MeasurementID"] = objBiz.ID;
                objDr["MeasurementMain"] = objBiz.Main;
                objDr["MeasurementCode"] = objBiz.Code;
                objDr["MeasurementNameA"] = objBiz.NameA;
                objDr["MeasurementNameE"] = objBiz.NameE;
                objDr["MeasurementFactor"] = objBiz.Factor;
                objDr["MeasurementIsBasic"] = objBiz.IsBasic;
                Returned.Rows.Add(objDr);
            }
            return Returned;
        }

        #endregion
    }
}