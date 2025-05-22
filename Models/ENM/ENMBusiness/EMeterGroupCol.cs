using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using AlgorithmatENM.ENM.ENMDb;
using System.Collections;
using SharpVision.SystemBase;
namespace AlgorithmatENM.ENM.ENMBiz
{
    public class EMeterGroupCol:CollectionBase
    {

        #region Constructor
        public EMeterGroupCol()
        {
            EMeterGroupDb objDb=new EMeterGroupDb();
            DataTable dtTemp = objDb.Search();

            EMeterGroupBiz objBiz;
            foreach (DataRow objDR in dtTemp.Rows)
            {
                objBiz = new EMeterGroupBiz(objDR);
                Add(objBiz);
            }
        }
        public EMeterGroupCol(bool blIsEmbty)
        {
            if (blIsEmbty)
                return;
            EMeterGroupBiz objBiz = new EMeterGroupBiz();
            objBiz.ID = 0;
            objBiz.NameA = "غير محدد";
            objBiz.NameE = "Not Specified";
            Add(objBiz);

            EMeterGroupDb objDb = new EMeterGroupDb();

            DataTable dtTemp = objDb.Search();


            foreach (DataRow objDR in dtTemp.Rows)
            {
                objBiz = new EMeterGroupBiz(objDR);
                Add(objBiz);
            }
        }

        #endregion
        #region Private Data

        #endregion
        #region Properties
        public EMeterGroupBiz this[int intIndex]
        {
            get
            {
                return (EMeterGroupBiz)this.List[intIndex];
            }
        }
        #endregion
        #region Private Method

        #endregion
        #region Public Method 
        public void Add(EMeterGroupBiz objBiz)
        {
            List.Add(objBiz);
        }
        public EMeterGroupCol GetCol(string strTemp)
        {
            EMeterGroupCol Returned = new EMeterGroupCol(true);
            foreach (EMeterGroupBiz objBiz in this)
            {
                if (objBiz.NameA.CheckStr(strTemp))
                    Returned.Add(objBiz);
            }
            return Returned;
        }
        public DataTable GetTable()
        {
            DataTable Returned = new DataTable();
            Returned.Columns.AddRange(new DataColumn[] { new DataColumn("GroupID"), new DataColumn("GroupCode"), new DataColumn("GroupNameA"), new DataColumn("GroupNameE"), new DataColumn("GroupDesc") });
            DataRow objDr;
            foreach (EMeterGroupBiz objBiz in this)
            {
                objDr = Returned.NewRow();
                objDr["GroupID"] = objBiz.ID;
                objDr["GroupCode"] = objBiz.Code;
                objDr["GroupNameA"] = objBiz.NameA;
                objDr["GroupNameE"] = objBiz.NameE;
                objDr["GroupDesc"] = objBiz.Desc;
                Returned.Rows.Add(objDr);
            }
            return Returned;
        }
        public EMeterGroupCol Copy()
        {
            EMeterGroupCol Returned = new EMeterGroupCol(true);
            foreach(EMeterGroupBiz objBiz in this)
            {
                Returned.Add(objBiz);

            }
            return Returned;
                
        }
        #endregion

    }
}
