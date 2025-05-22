using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SharpVision.SystemBase;
using AlgorithmatENM.ERP.ERPDataBase;
using System.Collections;
using System.Data;
namespace AlgorithmatENM.ERP.ERPBusiness
{
    public class MOCol:CollectionBase
    {

        #region Constructor
        public MOCol()
        {

        }
        public MOCol(bool blIsEmbty)
        {
            if (blIsEmbty)
                return;
            MOBiz objBiz = new MOBiz();
            objBiz.ID = 0;
           

            MODb objDb = new MODb();

            DataTable dtTemp = objDb.Search();


            foreach (DataRow objDR in dtTemp.Rows)
            {
                objBiz = new MOBiz(objDR);
                Add(objBiz);
            }
        }

        #endregion
        #region Private Data

        #endregion
        #region Properties
        public MOBiz this[int intIndex]
        {
            get
            {
                return (MOBiz)this.List[intIndex];
            }
        }
        #endregion
        #region Private Method

        #endregion
        #region Public Method 
        public void Add(MOBiz objBiz)
        {
            List.Add(objBiz);
        }
        public MOCol GetCol(string strTemp)
        {
            MOCol Returned = new MOCol(true);
            foreach (MOBiz objBiz in this)
            {
                if (objBiz.Desc.CheckStr(strTemp))
                    Returned.Add(objBiz);
            }
            return Returned;
        }
        public DataTable GetTable()
        {
            DataTable Returned = new DataTable();
            Returned.Columns.AddRange(new DataColumn[] { new DataColumn("MOID"), new DataColumn("MORef"), new DataColumn("MODate", System.Type.GetType("System.DateTime")), new DataColumn("MOStartTime", System.Type.GetType("System.DateTime")), new DataColumn("MODesc"), new DataColumn("MOQuantity"), new DataColumn("MOResponsible"), new DataColumn("MOStatus"), new DataColumn("MOStatusTime", System.Type.GetType("System.DateTime")) });
            DataRow objDr;
            foreach (MOBiz objBiz in this)
            {
                objDr = Returned.NewRow();
                objDr["MOID"] = objBiz.ID;
                objDr["MORef"] = objBiz.Ref;
                objDr["MODate"] = objBiz.Date;
                objDr["MOStartTime"] = objBiz.StartTime;
                objDr["MODesc"] = objBiz.Desc;
                objDr["MOQuantity"] = objBiz.Quantity;
                objDr["MOResponsible"] = objBiz.Responsible;
                objDr["MOStatus"] = objBiz.Status;
                objDr["MOStatusTime"] = objBiz.StatusTime;
                Returned.Rows.Add(objDr);
            }
            return Returned;
        }
        public static MOCol CreatedRuningCol
        {
            get
            {
                MOCol Returned = new MOCol(true);
                MODb objDb = new MODb() { StatusStr="0,1"};
                DataTable dtTemp = objDb.Search();
                foreach (DataRow objDr in dtTemp.Rows)
                    Returned.Add(new MOBiz(objDr));
                return Returned;
            }
        }

        #endregion
    }
}
