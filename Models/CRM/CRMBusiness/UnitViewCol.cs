using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.Base.BaseBusiness;
using SharpVision.CRM.CRMDataBase;
using SharpVision.SystemBase;

namespace SharpVision.CRM.CRMBusiness
{
    public class UnitViewCol : BaseCol
    {
        public UnitViewCol(bool blIsEmpty)
        {
            if (blIsEmpty)
                return;
            UnitViewDb objDb = new UnitViewDb();

            DataTable dtTemp = objDb.Search();
            UnitViewBiz objBiz = new UnitViewBiz();
            objBiz.ID = 0;
            objBiz.NameA = "€Ì— „Õœœ";
            Add(objBiz);
            foreach (DataRow objDR in dtTemp.Rows)
            {
                //objBiz = new UnitViewBiz(objDR);
                //this.Add(objBiz);
                Add(new UnitViewBiz(objDR));
            }

        }
        public UnitViewCol()
        {
            UnitViewDb objDb = new UnitViewDb();

            DataTable dtTemp = objDb.Search();
            UnitViewBiz objBiz = new UnitViewBiz();
            foreach (DataRow objDR in dtTemp.Rows)
            {
                Add(new UnitViewBiz(objDR));
            }

        }
        public UnitViewCol(int intID)
        {
            UnitViewDb objDb = new UnitViewDb();
            objDb.ID = intID;
            DataTable dtTemp = objDb.Search();
            UnitViewBiz objBiz;

            foreach (DataRow objDR in dtTemp.Rows)
            {
                objBiz = new UnitViewBiz(objDR);
                this.Add(objBiz);
            }

        }

        public virtual UnitViewBiz this[int intIndex]
        {
            get
            {
                return (UnitViewBiz)this.List[intIndex];
            }
        }

        public virtual void Add(UnitViewBiz objBiz)
        {

            this.List.Add(objBiz);
        }
        public UnitViewCol GetCol(string strCode)
        {
            UnitViewCol Returned = new UnitViewCol(true);
            string[] arrStr = strCode.Split("%".ToCharArray());
            bool blIsFound = true;
            foreach (UnitViewBiz objBiz in this)
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
        public UnitViewCol Copy()
        {
            UnitViewCol Returned = new UnitViewCol(true);
            foreach (UnitViewBiz objBiz in this)
            {
                Returned.Add(objBiz);
            }
            return Returned;
        }
    }
}
