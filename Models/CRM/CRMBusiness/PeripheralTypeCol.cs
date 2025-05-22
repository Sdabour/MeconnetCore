using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.Base.BaseBusiness;
using SharpVision.CRM.CRMDataBase;
using SharpVision.SystemBase;
using SharpVision.SystemBase;
namespace SharpVision.CRM.CRMBusiness
{
    public class PeripheralTypeCol : BaseCol
    {
        public PeripheralTypeCol(bool blIsEmpty)
        {
            if (blIsEmpty)
                return;
            PeripheralTypeDb objDb = new PeripheralTypeDb();

            DataTable dtTemp = objDb.Search();
            PeripheralTypeBiz objBiz = new PeripheralTypeBiz();
            objBiz.ID = 0;
            objBiz.NameA = "€Ì— „Õœœ";
            if (!blIsEmpty)
                Add(objBiz);
            foreach (DataRow objDR in dtTemp.Rows)
            {
                Add(new PeripheralTypeBiz(objDR));
            }

        }
        public PeripheralTypeCol()
        {
            PeripheralTypeDb objDb = new PeripheralTypeDb();

            DataTable dtTemp = objDb.Search();
            PeripheralTypeBiz objBiz = new PeripheralTypeBiz();
            foreach (DataRow objDR in dtTemp.Rows)
            {
                Add(new PeripheralTypeBiz(objDR));
            }
        }
        public PeripheralTypeCol(int intID)
        {
            PeripheralTypeDb objDb = new PeripheralTypeDb();
            objDb.ID = intID;
            DataTable dtTemp = objDb.Search();
            PeripheralTypeBiz objBiz;

            foreach (DataRow objDR in dtTemp.Rows)
            {
                objBiz = new PeripheralTypeBiz(objDR);
                this.Add(objBiz);
            }

        }

        public virtual PeripheralTypeBiz this[int intIndex]
        {
            get
            {
                return (PeripheralTypeBiz)this.List[intIndex];
            }
        }
        public PeripheralTypeBiz GetPeripheralTypeByName(string strName)
        {
            PeripheralTypeBiz Returned = new PeripheralTypeBiz();
            foreach (PeripheralTypeBiz objBiz in this)
            {
                if (objBiz.Name == strName)
                    return objBiz;
            }
            return Returned;
        }
        public PeripheralTypeCol GetCol(string strName)
        {
            PeripheralTypeCol Returned = new PeripheralTypeCol(true);
            foreach (PeripheralTypeBiz objBiz in this)
            {
                if (objBiz.Name.CheckStr(strName) )
                    Returned.Add(objBiz);
            }
            return Returned;
        }
        public virtual void Add(PeripheralTypeBiz objBiz)
        {

            this.List.Add(objBiz);
        }
        public PeripheralTypeCol Copy()
        {
            PeripheralTypeCol Returned = new PeripheralTypeCol(true);
            foreach (PeripheralTypeBiz objBiz in this)
            {
                Returned.Add(objBiz);
            }
            return Returned;
        }
    }
}
