using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlgorithmatENM.ENM.ENMDb;
using System.Data;
using System.Collections;
using SharpVision.SystemBase;
namespace AlgorithmatENM.ENM.ENMBiz
{
    public class EMeterTypeCol:CollectionBase
    {

        #region Constructor
        public EMeterTypeCol()
        {
            EMeterTypeBiz objBiz = new EMeterTypeBiz();
          

            EMeterTypeDb objDb = new EMeterTypeDb();

            DataTable dtTemp = objDb.Search();


            foreach (DataRow objDR in dtTemp.Rows)
            {
                objBiz = new EMeterTypeBiz(objDR);
                Add(objBiz);
            }
        }
        public EMeterTypeCol(bool blIsEmbty)
        {
            if (blIsEmbty)
                return;
            EMeterTypeBiz objBiz = new EMeterTypeBiz();
            objBiz.ID = 0;
            objBiz.NameA = "غير محدد";
            objBiz.NameE = "Not Specified";
            Add(objBiz);

            EMeterTypeDb objDb = new EMeterTypeDb();

            DataTable dtTemp = objDb.Search();


            foreach (DataRow objDR in dtTemp.Rows)
            {
                objBiz = new EMeterTypeBiz(objDR);
                Add(objBiz);
            }
        }

        #endregion
        #region Private Data

        #endregion
        #region Properties
        public EMeterTypeBiz this[int intIndex]
        {
            get
            {
                return (EMeterTypeBiz)this.List[intIndex];
            }
        }
        #endregion
        #region Private Method

        #endregion
        #region Public Method 
        public void Add(EMeterTypeBiz objBiz)
        {
            List.Add(objBiz);
        }
        public EMeterTypeCol GetCol(string strTemp)
        {
            EMeterTypeCol Returned = new EMeterTypeCol(true);
            foreach (EMeterTypeBiz objBiz in this)
            {
                if (objBiz.NameA.CheckStr(strTemp))
                    Returned.Add(objBiz);
            }
            return Returned;
        }
        public DataTable GetTable()
        {
            DataTable Returned = new DataTable();
            Returned.Columns.AddRange(new DataColumn[] { new DataColumn("EMeterTypeID"), new DataColumn("EMeterTypeCode"), new DataColumn("EMeterTypeNameA"), new DataColumn("EMeterTypeNameE"), new DataColumn("EMeterTypeWordStartAddress"), new DataColumn("EMeterTypeWordNo") });
            DataRow objDr;
            foreach (EMeterTypeBiz objBiz in this)
            {
                objDr = Returned.NewRow();
                objDr["EMeterTypeID"] = objBiz.ID;
                objDr["EMeterTypeCode"] = objBiz.Code;
                objDr["EMeterTypeNameA"] = objBiz.NameA;
                objDr["EMeterTypeNameE"] = objBiz.NameE;
                objDr["EMeterTypeWordStartAddress"] = objBiz.WordStartAddress;
                objDr["EMeterTypeWordNo"] = objBiz.WordNo;
                Returned.Rows.Add(objDr);
            }
            return Returned;
        }
        public EMeterTypeCol Copy()
        {
            EMeterTypeCol Returned = new EMeterTypeCol(true);
            foreach (EMeterTypeBiz objBiz in this)
                Returned.Add(objBiz);

            return Returned;
        }
        #endregion
    }
}
