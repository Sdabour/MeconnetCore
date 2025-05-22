using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.UMS.UMSBusiness;
using SharpVision.CRM.CRMDataBase;

using System.Data;
using SharpVision.Base.BaseBusiness;

namespace SharpVision.CRM.CRMBusiness
{
    public class UnitCellCol : BaseCol
    {
        public UnitCellCol(bool blIsempty)
        {

        }
        

        public UnitCellBiz this[int intIndex]
        {

            get
            {
                return (UnitCellBiz)List[intIndex];
            }
        }
    
        public void Add(UnitCellBiz objBiz)
        {
            bool blIsfound = Contains(objBiz);
           
            if(!blIsfound )//&& CheckParent(objBiz) )
                List.Add(objBiz);
            

        }
        public bool Contains(UnitCellBiz objBiz)
        {
            bool Returned = false;
            foreach(UnitCellBiz objUnitCellBiz in this)
            {
                if(objUnitCellBiz.CellBiz.ID == objBiz.CellBiz.ID)
                {
                    Returned = true;
                    break;
                }
              
            }
            return Returned;
        }
        public bool CheckParent(UnitCellBiz objBiz)
        {
            bool Returned = false;
            if (Count == 0)
                Returned = true;
            else
            {
                int intParentID = this[0].CellBiz.ParentID;
                if (objBiz.CellBiz.ParentID == intParentID)
                    Returned = true;
              
                    
            }
            return Returned;

        }
        internal DataTable GetTable()
        {
            DataTable dtReturned = new DataTable();
            dtReturned.Columns.AddRange(new DataColumn[] { new DataColumn("Unit"),
                new DataColumn("Cell"), new DataColumn("Survey"), new DataColumn("Order") });
            DataRow objDr;
            foreach (UnitCellBiz objBiz in this)
            {
                objDr = dtReturned.NewRow();
               
               // objDr["Unit"] = objBiz.UnitBiz.ID;
                objDr["Cell"] = objBiz.CellBiz.ID;
                objDr["Survey"] = objBiz.Survey;
                objDr["Order"] = objBiz.Order;
               
                dtReturned.Rows.Add(objDr);

            }
            return dtReturned;

        }

        

    }
}