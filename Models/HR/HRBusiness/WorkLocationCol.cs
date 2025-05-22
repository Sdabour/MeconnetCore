using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;


using SharpVision.HR.HRDataBase;
using SharpVision.SystemBase;
using SharpVision.COMMON.COMMONBusiness;

namespace SharpVision.HR.HRBusiness
{
    public class WorkLocationCol:CollectionBase
    {

        #region Constructor
        public WorkLocationCol()
        {

        }
        public WorkLocationCol(bool blIsEmbty)
        {
            if (blIsEmbty)
                return;
            WorkLocationBiz objBiz = new WorkLocationBiz();
            

            WorkLocationDb objDb = new WorkLocationDb();

            DataTable dtTemp = objDb.Search();


            foreach (DataRow objDR in dtTemp.Rows)
            {
                objBiz = new WorkLocationBiz(objDR);
                Add(objBiz);
            }
        }

        #endregion
        #region Private Data

        #endregion
        #region Properties
        public WorkLocationBiz this[int intIndex]
        {
            get
            {
                return (WorkLocationBiz)this.List[intIndex];
            }
        }
        #endregion
        #region Private Method

        #endregion
        #region Public Method 
        public void Add(WorkLocationBiz objBiz)
        {
            List.Add(objBiz);
        }
        public WorkLocationCol GetCol(string strTemp)
        {
            WorkLocationCol Returned = new WorkLocationCol(true);
            foreach (WorkLocationBiz objBiz in this)
            {
                if (objBiz.Desc.CheckStr(strTemp))
                    Returned.Add(objBiz);
            }
            return Returned;
        }
        public DataTable GetTable()
        {
            DataTable Returned = new DataTable();
            Returned.Columns.AddRange(new DataColumn[] { new DataColumn("LocationID"), new DataColumn("LocationDesc"), new DataColumn("LocationCenterLong"), new DataColumn("LocationCenterLat"), new DataColumn("LocationPointLong"), new DataColumn("LocationPointLat") });
            DataRow objDr;
            foreach (WorkLocationBiz objBiz in this)
            {
                objDr = Returned.NewRow();
                objDr["LocationID"] = objBiz.ID;
                objDr["LocationDesc"] = objBiz.Desc;
                objDr["LocationCenterLong"] = objBiz.CenterLong;
                objDr["LocationCenterLat"] = objBiz.CenterLat;
                objDr["LocationPointLong"] = objBiz.PointLong;
                objDr["LocationPointLat"] = objBiz.PointLat;
                Returned.Rows.Add(objDr);
            }
            return Returned;
        }

        #endregion
    }
}