using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.Base.BaseBusiness;
using SharpVision.CRM.CRMDataBase;
using SharpVision.SystemBase;

namespace SharpVision.CRM.CRMBusiness
{
    public class TowerTypeCol : BaseCol
    {
        public TowerTypeCol(bool blIsEmpty)
        {
            if (blIsEmpty)
                return;
            TowerTypeDb objDb = new TowerTypeDb();

            DataTable dtTemp = objDb.Search();
            TowerTypeBiz objBiz = new TowerTypeBiz();
            objBiz.ID = 0;
            objBiz.NameA = "€Ì— „Õœœ";
            Add(objBiz);
            foreach (DataRow objDR in dtTemp.Rows)
            {
                //objBiz = new TowerTypeBiz(objDR);
                //this.Add(objBiz);
                Add(new TowerTypeBiz(objDR));
            }

        }
        public TowerTypeCol()
        {
            TowerTypeDb objDb = new TowerTypeDb();

            DataTable dtTemp = objDb.Search();
            TowerTypeBiz objBiz = new TowerTypeBiz();
            foreach (DataRow objDR in dtTemp.Rows)
            {
                Add(new TowerTypeBiz(objDR));
            }

        }
        public TowerTypeCol(int intID)
        {
            TowerTypeDb objDb = new TowerTypeDb();
            objDb.ID = intID;
            DataTable dtTemp = objDb.Search();
            TowerTypeBiz objBiz;

            foreach (DataRow objDR in dtTemp.Rows)
            {
                objBiz = new TowerTypeBiz(objDR);
                this.Add(objBiz);
            }

        }

        public virtual TowerTypeBiz this[int intIndex]
        {
            get
            {
                return (TowerTypeBiz)this.List[intIndex];
            }
        }

        public virtual void Add(TowerTypeBiz objBiz)
        {

            this.List.Add(objBiz);
        }
        public TowerTypeCol GetCol(string strCode)
        {
            TowerTypeCol Returned = new TowerTypeCol(true);
            string[] arrStr = strCode.Split("%".ToCharArray());
            bool blIsFound = true;
            foreach (TowerTypeBiz objBiz in this)
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
        public TowerTypeCol Copy()
        {
            TowerTypeCol Returned = new TowerTypeCol(true);
            foreach (TowerTypeBiz objBiz in this)
            {
                Returned.Add(objBiz);
            }
            return Returned;
        }
    }
}