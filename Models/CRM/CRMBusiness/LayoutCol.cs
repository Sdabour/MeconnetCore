using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using SharpVision.CRM.CRMDataBase;
namespace SharpVision.CRM.CRMBusiness
{
    public class LayoutCol : CollectionBase
    {
        public LayoutCol(bool blIsEmpty)
        { 
        }
        public LayoutCol(int intProjectID)
        {
            LayoutDb objDb = new LayoutDb();
            objDb.ProjectID = intProjectID;
            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
            {
                Add(new LayoutBiz(objDr));
            }

        }
        public LayoutCol(int intProjectID, LayoutType objType)
        {
            LayoutDb objDb = new LayoutDb();
            objDb.ProjectID = intProjectID;
            objDb.Type = (byte)objType;
            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
            {
                Add(new LayoutBiz(objDr));
            }
 
        }
        public LayoutBiz this[int intIndex]
        {
            set
            {
                List[intIndex] = value;
            }
            get
            {
                return (LayoutBiz)List[intIndex];
            }
        }
        public void Add(LayoutBiz objBiz)
        {
            List.Add(objBiz);
        }
    }
}
