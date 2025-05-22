using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.Base.BaseBusiness;
using SharpVision.CRM.CRMDataBase;
using SharpVision.SystemBase;

namespace SharpVision.CRM.CRMBusiness
{
    public class UnitUsageTypeCol : BaseCol
    {
        public UnitUsageTypeCol(bool blIsEmpty)
        {
            if (blIsEmpty)
                return;
            UnitUsageTypeDb objDb = new UnitUsageTypeDb();

            DataTable dtTemp = objDb.Search();
            UnitUsageTypeBiz objBiz = new UnitUsageTypeBiz();
            objBiz.ID = 0;
            objBiz.NameA = "€Ì— „Õœœ";
            Add(objBiz);
            foreach (DataRow objDR in dtTemp.Rows)
            {
                //objBiz = new UnitUsageTypeBiz(objDR);
                //this.Add(objBiz);
                Add(new UnitUsageTypeBiz(objDR));
            }

        }
        public UnitUsageTypeCol()
        {
            UnitUsageTypeDb objDb = new UnitUsageTypeDb();

            DataTable dtTemp = objDb.Search();
            UnitUsageTypeBiz objBiz = new UnitUsageTypeBiz();
            foreach (DataRow objDR in dtTemp.Rows)
            {
                Add(new UnitUsageTypeBiz(objDR));
            }

        }
        public UnitUsageTypeCol(int intID)
        {
            UnitUsageTypeDb objDb = new UnitUsageTypeDb();
            objDb.ID = intID;
            DataTable dtTemp = objDb.Search();
            UnitUsageTypeBiz objBiz;

            foreach (DataRow objDR in dtTemp.Rows)
            {
                objBiz = new UnitUsageTypeBiz(objDR);
                this.Add(objBiz);
            }

        }

        public virtual UnitUsageTypeBiz this[int intIndex]
        {
            get
            {
                return (UnitUsageTypeBiz)this.List[intIndex];
            }
        }

        public virtual void Add(UnitUsageTypeBiz objBiz)
        {

            this.List.Add(objBiz);
        }
        public UnitUsageTypeCol GetCol(string strCode)
        {
            UnitUsageTypeCol Returned = new UnitUsageTypeCol(true);
            string[] arrStr = strCode.Split("%".ToCharArray());
            bool blIsFound = true;
            foreach (UnitUsageTypeBiz objBiz in this)
            {
                blIsFound = true;
                foreach (string strTemp in arrStr)
                {
                    if (SysUtility.ReplaceStringComp( objBiz.Code).IndexOf(SysUtility.ReplaceStringComp(strTemp),StringComparison.OrdinalIgnoreCase) == -1 &&
                        SysUtility.ReplaceStringComp(objBiz.Name).IndexOf(SysUtility.ReplaceStringComp(strTemp), StringComparison.OrdinalIgnoreCase) == -1)
                        blIsFound = false;

                }
                if (blIsFound)
                    Returned.Add(objBiz);
            }
            return Returned;
        }
        public UnitUsageTypeCol Copy()
        {
            UnitUsageTypeCol Returned = new UnitUsageTypeCol(true);
            foreach (UnitUsageTypeBiz objBiz in this)
            {
                Returned.Add(objBiz);
            }
            return Returned;
        }
    }
}
