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
        public MOCol(string strStatus,bool blIsDateRange,DateTime dtStart,DateTime dtEnd,int? intChangeStatus=0,int? inStatusChangedStatus=0)
        {
           
            MOBiz objBiz = new MOBiz();
            objBiz.ID = 0;

            //string strStatus = "";
            //if(intStatus !=0)
            //{
            //    intStatus = intStatus - 1;
            //    strStatus = intStatus.ToString();
            //}    
            MODb objDb = new MODb() {IsDateRange=blIsDateRange,DateStart = dtStart,DateEnd=dtEnd,StatusStr=strStatus,ChangedStatus=intChangeStatus.GetValueOrDefault(),StatusChangedStatus= inStatusChangedStatus.GetValueOrDefault() };

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
        public string IDsStr
        {
            get
            {
                string Returned = "";
                foreach(MOBiz objBiz in this)
                {
                    if (Returned != "")
                        Returned += ",";
                    Returned += objBiz.ID.ToString();
                }
                return Returned;
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
                objDr["MOStatus"] = (int)objBiz.Status;
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
                MODb objDb = new MODb() { StatusStr="0,1,2"};
                DataTable dtTemp = objDb.Search();
                foreach (DataRow objDr in dtTemp.Rows)
                    Returned.Add(new MOBiz(objDr));
                return Returned;
            }
        }
        public void SetCol()
        {
       
        Hashtable hsTemp = new Hashtable();
            foreach(MOBiz objBiz in this)
            {
                if (hsTemp[objBiz.ID.ToString()] == null)
                    hsTemp.Add(objBiz.ID.ToString(), objBiz);
            }
            MOBiz objMo;
            WorkOrderBiz objWorkOrder = new WorkOrderBiz();
            WorkOrderDb objWorkOrderDb = new WorkOrderDb() { MOIDs = IDsStr };
            DataTable dtTemp = objWorkOrderDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
            {
                objWorkOrder = new WorkOrderBiz(objDr);
                if (hsTemp[objWorkOrder.MO.ToString()] != null)
                {
                    objMo = (MOBiz)hsTemp[objWorkOrder.MO.ToString()];
                    objMo.WorkOrderCol.Add(objWorkOrder);
                }
            }
            MOComponentBiz objMOComponent =new MOComponentBiz();
            MOComponentDb objMOComponentDb = new MOComponentDb() { MOIDs = IDsStr };
             dtTemp = objMOComponentDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
            {
                objMOComponent = new MOComponentBiz(objDr);
                if (hsTemp[objMOComponent.MO.ToString()] != null)
                {
                    objMo = (MOBiz)hsTemp[objMOComponent.MO.ToString()];
                    objMo.ComponentCol.Add(objMOComponent);
                }
            }
            objMOComponentDb = new MOComponentDb() { MOIDs = IDsStr,IsByProduct=true };
            dtTemp = objMOComponentDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
            {
                objMOComponent = new MOComponentBiz(objDr);
                if (hsTemp[objMOComponent.MO.ToString()] != null)
                {
                    objMo = (MOBiz)hsTemp[objMOComponent.MO.ToString()];
                    objMo.ByproductCol.Add(objMOComponent);
                }
            }

        }
        public void EditChanged(bool blIsChanged)
        {
            MODb objDb = new MODb() { IDs=IDsStr,ChangedStatus=blIsChanged?1:0};
            objDb.EditChangedStatus();
        }
        #endregion
    }
}
