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
    public class EMeasureTypeCol:CollectionBase
    {

        #region Constructor
        public EMeasureTypeCol()
        {
            EMeasureTypeDb objDb = new EMeasureTypeDb();

            DataTable dtTemp = objDb.Search();
            EMeasureTypeBiz objBiz;

            foreach (DataRow objDR in dtTemp.Rows)
            {
                objBiz = new EMeasureTypeBiz(objDR);
                Add(objBiz);
            }
        }
        public EMeasureTypeCol(bool blIsEmbty)
        {
            if (blIsEmbty)
                return;
            EMeasureTypeBiz objBiz = new EMeasureTypeBiz();
            objBiz.ID = 0;
            objBiz.NameA = "غير محدد";
            objBiz.NameE = "Not Specified";
            Add(objBiz);

            EMeasureTypeDb objDb = new EMeasureTypeDb();

            DataTable dtTemp = objDb.Search();


            foreach (DataRow objDR in dtTemp.Rows)
            {
                objBiz = new EMeasureTypeBiz(objDR);
                Add(objBiz);
            }
        }

        #endregion
        #region Private Data

        #endregion
        #region Properties
        public EMeasureTypeBiz this[int intIndex]
        {
            get
            {
                return (EMeasureTypeBiz)this.List[intIndex];
            }
        }
        #endregion
        #region Private Method

        #endregion
        #region Public Method 
        public void Add(EMeasureTypeBiz objBiz)
        {
            List.Add(objBiz);
        }
        public EMeasureTypeCol GetCol(string strTemp)
        {
            EMeasureTypeCol Returned = new EMeasureTypeCol(true);
            foreach (EMeasureTypeBiz objBiz in this)
            {
                if (objBiz.NameA.CheckStr(strTemp))
                    Returned.Add(objBiz);
            }
            return Returned;
        }
        public DataTable GetTable()
        {
            DataTable Returned = new DataTable();
            Returned.Columns.AddRange(new DataColumn[] { new DataColumn("EMeasureTypeID"), new DataColumn("EMeasureTypeCode"), new DataColumn("EMeasureTypeNameA"), new DataColumn("EMeasureTypeNameE"), new DataColumn("EMeasureTypeUnit"),new DataColumn("EMeasureTypeAccumulated",Type.GetType("System.Boolean")) });
            DataRow objDr;
            foreach (EMeasureTypeBiz objBiz in this)
            {
                objDr = Returned.NewRow();
                objDr["EMeasureTypeID"] = objBiz.ID;
                objDr["EMeasureTypeCode"] = objBiz.Code;
                objDr["EMeasureTypeNameA"] = objBiz.NameA;
                objDr["EMeasureTypeNameE"] = objBiz.NameE;
                objDr["EMeasureTypeUnit"] = objBiz.Unit;
                objDr["EMeasureTypeAccumulated"] = objBiz.Accumulated;
                Returned.Rows.Add(objDr);
            }
            return Returned;
        }
        public EMeasureTypeCol Copy()

        { EMeasureTypeCol Returned = new EMeasureTypeCol(true);
            foreach (EMeasureTypeBiz objBiz in this)
                Returned.Add(objBiz);
            return Returned;
        }
        #endregion
    }
}
