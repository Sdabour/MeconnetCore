using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpVision.SystemBase;
using System.Data;
using System.Collections;
using AlgorithmatMN.MN.MNDb;
namespace AlgorithmatMN.MN.MNBiz
{
    public class CostTypeCol : CollectionBase
    {

        #region Constructor
        public CostTypeCol()
        {
            CostTypeDb objDb = new CostTypeDb();

            DataTable dtTemp = objDb.Search();
            CostTypeBiz objBiz;

            foreach (DataRow objDR in dtTemp.Rows)
            {
                objBiz = new CostTypeBiz(objDR);
                Add(objBiz);
            }
        }
        public CostTypeCol(bool blIsEmbty)
        {
            if (blIsEmbty)
                return;
            CostTypeBiz objBiz = new CostTypeBiz();
            objBiz.ID = 0;
            objBiz.NameA = "غير محدد";
            objBiz.NameE = "Not Specified";
            Add(objBiz);

            CostTypeDb objDb = new CostTypeDb();

            DataTable dtTemp = objDb.Search();


            foreach (DataRow objDR in dtTemp.Rows)
            {
                objBiz = new CostTypeBiz(objDR);
                Add(objBiz);
            }
        }

        #endregion
        #region Private Data

        #endregion
        #region Properties
        public CostTypeBiz this[int intIndex]
        {
            get
            {
                return (CostTypeBiz)this.List[intIndex];
            }
        }
        #endregion
        #region Private Method

        #endregion
        #region Public Method 
        public void Add(CostTypeBiz objBiz)
        {
            List.Add(objBiz);
        }
        public CostTypeCol GetCol(string strTemp)
        {
            CostTypeCol Returned = new CostTypeCol(true);
            foreach (CostTypeBiz objBiz in this)
            {
                if (objBiz.NameA.CheckStr(strTemp))
                    Returned.Add(objBiz);
            }
            return Returned;
        }
        public DataTable GetTable()
        {
            DataTable Returned = new DataTable();
            Returned.Columns.AddRange(new DataColumn[] { new DataColumn("CostTypeID"), new DataColumn("CostTypeCode"), new DataColumn("CostTypeNameA"), new DataColumn("CostTypeNameE"), new DataColumn("CostTypeUnit"), new DataColumn("CostTypeAccumulated", Type.GetType("System.Boolean")) });
            DataRow objDr;
            foreach (CostTypeBiz objBiz in this)
            {
                objDr = Returned.NewRow();
                objDr["CostTypeID"] = objBiz.ID;
                objDr["CostTypeCode"] = objBiz.Code;
                objDr["CostTypeNameA"] = objBiz.NameA;
                objDr["CostTypeNameE"] = objBiz.NameE;
 
                Returned.Rows.Add(objDr);
            }
            return Returned;
        }
        public CostTypeCol Copy()

        {
            CostTypeCol Returned = new CostTypeCol(true);
            foreach (CostTypeBiz objBiz in this)
                Returned.Add(objBiz);
            return Returned;
        }
        #endregion
    }
}
