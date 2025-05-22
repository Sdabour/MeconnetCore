using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.Base.BaseBusiness;
using SharpVision.CRM.CRMDataBase;
using SharpVision.SystemBase;

namespace SharpVision.CRM.CRMBusiness
{
    public class TowerUsageTypeCol : BaseCol
    {
        public TowerUsageTypeCol(bool blIsEmpty)
        {
            if (blIsEmpty)
                return;
            TowerUsageTypeDb objDb = new TowerUsageTypeDb();

            DataTable dtTemp = objDb.Search();
            TowerUsageTypeBiz objBiz = new TowerUsageTypeBiz();
            objBiz.ID = 0;
            objBiz.NameA = "€Ì— „Õœœ";
            Add(objBiz);
            foreach (DataRow objDR in dtTemp.Rows)
            {
                //objBiz = new TowerUsageTypeBiz(objDR);
                //this.Add(objBiz);
                Add(new TowerUsageTypeBiz(objDR));
            }

        }
        public TowerUsageTypeCol()
        {
            TowerUsageTypeDb objDb = new TowerUsageTypeDb();

            DataTable dtTemp = objDb.Search();
            TowerUsageTypeBiz objBiz = new TowerUsageTypeBiz();
            foreach (DataRow objDR in dtTemp.Rows)
            {
                Add(new TowerUsageTypeBiz(objDR));
            }

        }
        public TowerUsageTypeCol(int intID)
        {
            TowerUsageTypeDb objDb = new TowerUsageTypeDb();
            objDb.ID = intID;
            DataTable dtTemp = objDb.Search();
            TowerUsageTypeBiz objBiz;

            foreach (DataRow objDR in dtTemp.Rows)
            {
                objBiz = new TowerUsageTypeBiz(objDR);
                this.Add(objBiz);
            }

        }

        public virtual TowerUsageTypeBiz this[int intIndex]
        {
            get
            {
                return (TowerUsageTypeBiz)this.List[intIndex];
            }
        }

        public virtual void Add(TowerUsageTypeBiz objBiz)
        {

            this.List.Add(objBiz);
        }
        public TowerUsageTypeCol GetCol(string strCode)
        {
            TowerUsageTypeCol Returned = new TowerUsageTypeCol(true);
            string[] arrStr = strCode.Split("%".ToCharArray());
            bool blIsFound = true;
            foreach (TowerUsageTypeBiz objBiz in this)
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
        public TowerUsageTypeCol Copy()
        {
            TowerUsageTypeCol Returned = new TowerUsageTypeCol(true);
            foreach (TowerUsageTypeBiz objBiz in this)
            {
                Returned.Add(objBiz);
            }
            return Returned;
        }
    }
}