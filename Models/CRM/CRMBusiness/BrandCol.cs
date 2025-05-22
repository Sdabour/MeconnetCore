using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.Base.BaseBusiness;
using SharpVision.CRM.CRMDataBase;
using SharpVision.SystemBase;

namespace SharpVision.CRM.CRMBusiness
{
    public class BrandCol : BaseCol
    {
        public BrandCol(bool blIsEmpty)
        {
            if (blIsEmpty)
                return;
            BrandDb objDb = new BrandDb();

            DataTable dtTemp = objDb.Search();
            BrandBiz objBiz = new BrandBiz();
            objBiz.ID = 0;
            objBiz.NameA = "غير محدد";
            Add(objBiz);
            foreach (DataRow objDR in dtTemp.Rows)
            {
                //objBiz = new BrandBiz(objDR);
                //this.Add(objBiz);
                Add(new BrandBiz(objDR));
            }

        }
        public BrandCol()
        {
            BrandDb objDb = new BrandDb();

            DataTable dtTemp = objDb.Search();
            BrandBiz objBiz = new BrandBiz();
            foreach (DataRow objDR in dtTemp.Rows)
            {
                Add(new BrandBiz(objDR));
            }

        }
        public BrandCol(int intID)
        {
            BrandDb objDb = new BrandDb();
            objDb.ID = intID;
            DataTable dtTemp = objDb.Search();
            BrandBiz objBiz;

            foreach (DataRow objDR in dtTemp.Rows)
            {
                objBiz = new BrandBiz(objDR);
                this.Add(objBiz);
            }

        }

        public virtual BrandBiz this[int intIndex]
        {
            get
            {
                return (BrandBiz)this.List[intIndex];
            }
        }
        public string IDsStr
        {
            get
            {
                string Returned = "";
                foreach (BrandBiz objBiz in this)
                {
                    if (Returned != "")
                        Returned += ",";
                    Returned += objBiz.ID.ToString();
                }
                return Returned;
            }
        }
        public virtual void Add(BrandBiz objBiz)
        {

            this.List.Add(objBiz);
        }
        public BrandCol GetCol(string strCode)
        {
            BrandCol Returned = new BrandCol(true);
            string[] arrStr = strCode.Split("%".ToCharArray());
            bool blIsFound = true;
            foreach (BrandBiz objBiz in this)
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
        public BrandCol Copy()
        {
            BrandCol Returned = new BrandCol(true);
            foreach (BrandBiz objBiz in this)
            {
                Returned.Add(objBiz);
            }
            return Returned;
        }
    }
}