using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Collections;
using AlgorithmatENM.ERP.ERPDataBase;
using SharpVision.SystemBase;
namespace AlgorithmatENM.ERP.ERPBusiness
{
    public class BufferTypeCol:CollectionBase
    {

        #region Constructor
        public BufferTypeCol()
        {

        }
        public BufferTypeCol(bool blIsEmbty)
        {
            if (blIsEmbty)
                return;
            BufferTypeBiz objBiz = new BufferTypeBiz();
            objBiz.ID = 0;
            objBiz.NameA = "غير محدد";
            objBiz.NameE = "Not Specified";
            Add(objBiz);

            BufferTypeDb objDb = new BufferTypeDb();

            DataTable dtTemp = objDb.Search();


            foreach (DataRow objDR in dtTemp.Rows)
            {
                objBiz = new BufferTypeBiz(objDR);
                Add(objBiz);
            }
        }

        #endregion
        #region Private Data

        #endregion
        #region Properties
        public BufferTypeBiz this[int intIndex]
        {
            get
            {
                return (BufferTypeBiz)this.List[intIndex];
            }
        }
        #endregion
        #region Private Method

        #endregion
        #region Public Method 
        public void Add(BufferTypeBiz objBiz)
        {
            List.Add(objBiz);
        }
        public BufferTypeCol GetCol(string strTemp)
        {
            BufferTypeCol Returned = new BufferTypeCol(true);
            foreach (BufferTypeBiz objBiz in this)
            {
                if (objBiz.NameA.CheckStr(strTemp))
                    Returned.Add(objBiz);
            }
            return Returned;
        }
        public DataTable GetTable()
        {
            DataTable Returned = new DataTable();
            Returned.Columns.AddRange(new DataColumn[] { new DataColumn("TypeID"), new DataColumn("TypeCode"), new DataColumn("TypeNameA"), new DataColumn("TypeNameE") });
            DataRow objDr;
            foreach (BufferTypeBiz objBiz in this)
            {
                objDr = Returned.NewRow();
                objDr["TypeID"] = objBiz.ID;
                objDr["TypeCode"] = objBiz.Code;
                objDr["TypeNameA"] = objBiz.NameA;
                objDr["TypeNameE"] = objBiz.NameE;
                Returned.Rows.Add(objDr);
            }
            return Returned;
        }

        #endregion
    }
}