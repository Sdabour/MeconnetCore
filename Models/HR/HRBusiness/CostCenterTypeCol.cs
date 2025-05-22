using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using SharpVision.Base.BaseDataBase;
using SharpVision.Base.BaseBusiness;
using SharpVision.HR.HRDataBase;
using SharpVision.SystemBase;
using SharpVision.COMMON.COMMONBusiness;

namespace SharpVision.HR.HRBusiness
{
    public class CostCenterTypeCol : CollectionBase
    {
        public CostCenterTypeCol()
        {
            CostCenterTypeBiz objBiz;

            CostCenterTypeDb objDb = new CostCenterTypeDb();
            DataTable dtTemp = objDb.Search();
            

            foreach (DataRow DR in dtTemp.Rows)
            {
                objBiz = new CostCenterTypeBiz(DR);

                this.Add(objBiz);
            }

        }
        public CostCenterTypeCol(int intCostCenterTypeID)
        {
            CostCenterTypeBiz objBiz;

            CostCenterTypeDb objDb = new CostCenterTypeDb();
            objDb.IDSearch = intCostCenterTypeID;
            DataTable dtTemp = objDb.Search();


            foreach (DataRow DR in dtTemp.Rows)
            {
                objBiz = new CostCenterTypeBiz(DR);

                this.Add(objBiz);
            }

        }
        public CostCenterTypeCol(bool blIsEmpty)
        {
            if (!blIsEmpty)
            {
                CostCenterTypeBiz objBiz;
                objBiz = new CostCenterTypeBiz();
                objBiz.ID = 0;
                objBiz.NameA = "غير محدد";
                this.Add(objBiz);
                CostCenterTypeDb objDb = new CostCenterTypeDb();
                DataTable dtTemp = objDb.Search();


                foreach (DataRow DR in dtTemp.Rows)
                {
                    objBiz = new CostCenterTypeBiz(DR);

                    this.Add(objBiz);
                }
            }

        }
        public virtual CostCenterTypeBiz this[int intIndex]
        {
            get
            {

                return (CostCenterTypeBiz)this.List[intIndex];

         }   }

        public virtual CostCenterTypeBiz this[string strIndex]
        {
            get
            {
                CostCenterTypeBiz Returned = new CostCenterTypeBiz();
                foreach (CostCenterTypeBiz objBiz in this)
                {
                    if (objBiz.Name == strIndex)
                    {
                        Returned = objBiz.Copy();
                        break;
                    }
                }
                return Returned;
            }
        }


        public virtual void Add(CostCenterTypeBiz objBiz)
        {
            if (this[objBiz.Name].Name == null || this[objBiz.Name].Name == "")
            {
                this.List.Add(objBiz.Copy());
            }

        }


        public virtual void Add(CostCenterTypeCol objCol)
        {
            foreach (CostCenterTypeBiz objBiz in objCol)
            {
                if (this[objBiz.Name].ID == 0)
                    this.List.Add(objBiz.Copy());

            }
        }

        public CostCenterTypeCol Copy()
        {
            CostCenterTypeCol Returned = new CostCenterTypeCol(true);
            foreach (CostCenterTypeBiz objTemp in this)
            {
                Returned.Add(objTemp.Copy());
            }
            return Returned;
        }
        public string IDs
        {
            get
            {
                string strReturn = "";
                foreach (CostCenterTypeBiz objBiz in this)
                {
                    if (strReturn != "")
                        strReturn += "," + objBiz.ID.ToString();
                    else
                        strReturn += objBiz.ID.ToString();
                }
                return strReturn;
            }
        }

        public CostCenterHRCol GetCostCenterHRCol()
        {

            CostCenterHRCol objCol = new CostCenterHRCol(true);

            foreach (CostCenterTypeBiz objTypeBiz in this)
            {
                CostCenterHRDb objDb = new CostCenterHRDb();
                objDb.CostCenterType = objTypeBiz.ID;
                DataTable dtTemp = objDb.Search();
                foreach (DataRow objDr in dtTemp.Rows)
                {
                    objCol.Add(new CostCenterHRBiz(objDr));
                }
            }
            
            return objCol;
        }

        public static CostCenterTypeBiz GetCostCenterTypeBiz(int intID)
        {
            foreach (CostCenterTypeBiz objBiz in CostCenterTypeCol.CacheCostCenterTypeCol)
            {
                if (objBiz.ID == intID)
                {
                    return objBiz;
                }
            }
            return new CostCenterTypeBiz();
        }

        static CostCenterTypeCol _CacheCostCenterTypeCol;
        public static CostCenterTypeCol CacheCostCenterTypeCol
        {
            set
            {
                _CacheCostCenterTypeCol = value;
            }
            get
            {
                if (_CacheCostCenterTypeCol == null)
                {
                    _CacheCostCenterTypeCol = new CostCenterTypeCol(false);
                }
                return _CacheCostCenterTypeCol;
            }
        }
        public bool CheckType(CostCenterTypeBiz objBiz)
        {
            if (Count == 0)
                return true;
            if (Count == 1 && this[0].ID == 0)
                return true;
            foreach (CostCenterTypeBiz objTemp in this)
            {
                if (objBiz.ID == objTemp.ID)
                    return true;
            }
            return false;
        }
    }
}
