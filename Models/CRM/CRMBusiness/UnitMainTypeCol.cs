using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.Base.BaseBusiness;
using SharpVision.CRM.CRMDataBase;
using SharpVision.SystemBase;

namespace SharpVision.CRM.CRMBusiness
{
    public class UnitMainTypeCol : BaseCol
    {
        public UnitMainTypeCol(bool blIsEmpty)
        {
            if (blIsEmpty)
                return;
            UnitMainTypeDb objDb = new UnitMainTypeDb();

            DataTable dtTemp = objDb.Search();
            UnitMainTypeBiz objBiz = new UnitMainTypeBiz();
            objBiz.ID = 0;
            objBiz.NameA = "€Ì— „Õœœ";
            Add(objBiz);
            foreach (DataRow objDR in dtTemp.Rows)
            {
                //objBiz = new UnitMainTypeBiz(objDR);
                //this.Add(objBiz);
                Add(new UnitMainTypeBiz(objDR));
            }

        }
        public UnitMainTypeCol()
        {
            UnitMainTypeDb objDb = new UnitMainTypeDb();

            DataTable dtTemp = objDb.Search();
            UnitMainTypeBiz objBiz = new UnitMainTypeBiz();
            foreach (DataRow objDR in dtTemp.Rows)
            {
                Add(new UnitMainTypeBiz(objDR));
            }

        }
        public UnitMainTypeCol(int intID)
        {
            UnitMainTypeDb objDb = new UnitMainTypeDb();
            objDb.ID = intID;
            DataTable dtTemp = objDb.Search();
            UnitMainTypeBiz objBiz;

            foreach (DataRow objDR in dtTemp.Rows)
            {
                objBiz = new UnitMainTypeBiz(objDR);
                this.Add(objBiz);
            }

        }

        public virtual UnitMainTypeBiz this[int intIndex]
        {
            get
            {
                return (UnitMainTypeBiz)this.List[intIndex];
            }
        }

        public virtual void Add(UnitMainTypeBiz objBiz)
        {

            this.List.Add(objBiz);
        }
        public UnitMainTypeCol GetCol(string strCode)
        {
            UnitMainTypeCol Returned = new UnitMainTypeCol(true);
            string[] arrStr = strCode.Split("%".ToCharArray());
            bool blIsFound = true;
            foreach (UnitMainTypeBiz objBiz in this)
            {
                blIsFound = true;
                foreach (string strTemp in arrStr)
                {
                    if (SysUtility.ReplaceStringComp(objBiz.Code).IndexOf(SysUtility.ReplaceStringComp(strTemp), StringComparison.OrdinalIgnoreCase) == -1 &&
                        SysUtility.ReplaceStringComp(objBiz.Name).IndexOf(SysUtility.ReplaceStringComp(strTemp), StringComparison.OrdinalIgnoreCase) == -1)
                        blIsFound = false;

                }
                if (blIsFound)
                    Returned.Add(objBiz);
            }
            return Returned;
        }
        public UnitMainTypeCol Copy()
        {
            UnitMainTypeCol Returned = new UnitMainTypeCol(true);
            foreach (UnitMainTypeBiz objBiz in this)
            {
                Returned.Add(objBiz);
            }
            return Returned;
        }
    }
}
