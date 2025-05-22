using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.Base.BaseDataBase;
using SharpVision.Base.BaseBusiness;
using SharpVision.GL.GLDataBase;
using SharpVision.SystemBase;
using SharpVision.COMMON.COMMONBusiness;
using SharpVision.HR.HRDataBase;
namespace SharpVision.HR.HRBusiness
{
    public class CostCenterHRCol : BaseCol
    {
        CostCenterHRBiz _RootBiz;
        Hashtable _CostCenterHash = new Hashtable();
        static CostCenterHRCol _CacheCostCenterCol;
        public CostCenterHRCol()
        {
            CostCenterHRDb objCostCenterHRDb = new CostCenterHRDb();

            CostCenterHRBiz objCostCenterHRBiz;
            DataTable dtTemp = objCostCenterHRDb.Search();
            foreach (DataRow DR in dtTemp.Rows)
            {
                objCostCenterHRBiz = new CostCenterHRBiz(DR);
                this.Add(objCostCenterHRBiz);
            }
        }
        public CostCenterHRCol(CostCenterTypeBiz objCostCenterTypeBiz)
        {
            CostCenterHRDb objCostCenterHRDb = new CostCenterHRDb();

            CostCenterHRBiz objCostCenterHRBiz;
            objCostCenterHRDb.CostCenterType = objCostCenterTypeBiz.ID;
            foreach (DataRow DR in objCostCenterHRDb.Search().Rows)
            {
                objCostCenterHRBiz = new CostCenterHRBiz(DR);
                this.Add(objCostCenterHRBiz);

            }
        }
        public CostCenterHRCol(CostCenterTypeBiz objCostCenterTypeBiz,string strIDs)
        {
            CostCenterHRDb objCostCenterHRDb = new CostCenterHRDb();

            CostCenterHRBiz objCostCenterHRBiz;
            objCostCenterHRDb.CostCenterType = objCostCenterTypeBiz.ID;
            objCostCenterHRDb.CostCenterIDs = strIDs;
            DataTable dtTemp = objCostCenterHRDb.Search();
            foreach (DataRow DR in dtTemp.Rows)
            {
                objCostCenterHRBiz = new CostCenterHRBiz(DR);
                this.Add(objCostCenterHRBiz);

            }
        }
        public CostCenterHRCol(CostCenterTypeCol objCostCenterTypeCol)
        {
            CostCenterHRDb objCostCenterHRDb = new CostCenterHRDb();

            CostCenterHRBiz objCostCenterHRBiz;
            objCostCenterHRDb.CostCenterTypeIDs = objCostCenterTypeCol.IDs;
            foreach (DataRow DR in objCostCenterHRDb.Search().Rows)
            {
                objCostCenterHRBiz = new CostCenterHRBiz(DR);
                this.Add(objCostCenterHRBiz);

            }
        }
        public CostCenterHRCol(int intCostCenterID)
        {
            CostCenterHRDb objCostCenterHRDb = new CostCenterHRDb();
            objCostCenterHRDb.ID = intCostCenterID;
            CostCenterHRBiz objCostCenterHRBiz;
            foreach (DataRow DR in objCostCenterHRDb.Search().Rows)
            {
                objCostCenterHRBiz = new CostCenterHRBiz(DR);
                this.Add(objCostCenterHRBiz);

            }


        }
        public CostCenterHRCol(string strIDs)
        {
            CostCenterHRDb objCostCenterHRDb = new CostCenterHRDb();
            objCostCenterHRDb.CostCenterIDs = strIDs;
            CostCenterHRBiz objCostCenterHRBiz;
            foreach (DataRow DR in objCostCenterHRDb.Search().Rows)
            {
                objCostCenterHRBiz = new CostCenterHRBiz(DR);
                this.Add(objCostCenterHRBiz);

            }


        }
        public CostCenterHRCol(CostCenterTypeBiz objCostCenterTypeBiz,bool blHasEmpty)
        {
            CostCenterHRDb objCostCenterHRDb = new CostCenterHRDb();

            CostCenterHRBiz objCostCenterHRBiz;
            objCostCenterHRDb.CostCenterType = objCostCenterTypeBiz.ID;
            objCostCenterHRBiz = new CostCenterHRBiz();
            objCostCenterHRBiz.ID = 0;
            objCostCenterHRBiz.NameA = "غير محدد";
            objCostCenterHRBiz.NameE = "Not Specified";
            this.Add(objCostCenterHRBiz);
            foreach (DataRow DR in objCostCenterHRDb.Search().Rows)
            {
                objCostCenterHRBiz = new CostCenterHRBiz(DR);
                this.Add(objCostCenterHRBiz);

            }


        }
        public CostCenterHRCol(bool blIsEmpty)
        {
            if (!blIsEmpty)
            {
                CostCenterHRDb objDb = new CostCenterHRDb();

                CostCenterHRBiz objCostCenterHRBiz;
                objCostCenterHRBiz = new CostCenterHRBiz();
                objCostCenterHRBiz.ID = 0;
                objCostCenterHRBiz.NameA = "غير محدد";
                objCostCenterHRBiz.NameE = "Not Specified";
                this.Add(objCostCenterHRBiz);
                foreach (DataRow DR in objDb.Search().Rows)
                {
                    objCostCenterHRBiz = new CostCenterHRBiz(DR);
                    this.Add(objCostCenterHRBiz);

                }
            }
        }
        public CostCenterHRCol(bool blIsEmpty, bool blSetCostcenterparent)
        {
            if (!blIsEmpty)
            {
                CostCenterHRDb objDb = new CostCenterHRDb();

                CostCenterHRBiz objCostCenterHRBiz;
                objCostCenterHRBiz = new CostCenterHRBiz();
                objCostCenterHRBiz.ID = 0;
                objCostCenterHRBiz.NameA = "غير محدد";
                objCostCenterHRBiz.NameE = "Not Specified";
                this.Add(objCostCenterHRBiz);
                foreach (DataRow DR in objDb.Search().Rows)
                {
                    objCostCenterHRBiz = new CostCenterHRBiz(DR, blSetCostcenterparent);
                    this.Add(objCostCenterHRBiz);

                }
            }
        }
        public bool Contains(string strName)
        {
            bool blReturned = false;
            foreach (CostCenterHRBiz objCostCenterHRBiz in this)
            {
                if (objCostCenterHRBiz.Name == strName)
                {
                    blReturned = true;
                    break;
                }
            }
            return blReturned;

        }
        public virtual CostCenterHRBiz this[int intIndex]
        {
            get
            {
                try
                {
                    return (CostCenterHRBiz)this.List[intIndex];
                }
                catch { return new CostCenterHRBiz(); }
            }
        }
        public virtual CostCenterHRBiz this[string strIndex]
        {
            get
            {
                return  _CostCenterHash[strIndex] == null ?new CostCenterHRBiz() :
                    (CostCenterHRBiz)_CostCenterHash[strIndex];
            }
        }
        public static CostCenterHRCol CacheCostCenterCol
        {
            get
            {
                if (_CacheCostCenterCol == null)
                    _CacheCostCenterCol = new CostCenterHRCol();
                return _CacheCostCenterCol;
            }
        }
        public string IDsStr
        {
            get
            {
                string Returned = "";
                foreach (CostCenterHRBiz objBiz in this)
                {
                    if (Returned != "")
                        Returned += ",";
                    Returned += objBiz.ID.ToString();
                }
                return Returned;
            }
        }
        public CostCenterHRBiz RootBiz
        {
            set
            {
                _RootBiz = value;
            }
        }
        public virtual void Add(CostCenterHRBiz objCostCenterHRBiz)
        {
          //  if (GetIndex(objCostCenterHRBiz.ID) == -1)

            if (_CostCenterHash[objCostCenterHRBiz.ID.ToString()] == null)
            {
                _CostCenterHash.Add(objCostCenterHRBiz.ID.ToString(), objCostCenterHRBiz);
                this.List.Add(objCostCenterHRBiz);
            }
        }
        public int GetIndex(int intID)
        {
            int intIndex = 0;
            foreach (CostCenterHRBiz objBiz in this)
            {
                if (objBiz.ID == intID)
                {
                    return intIndex;
                }
                intIndex++;
            }
            return -1;
        }
        public CostCenterHRCol GetCostCenterHRByNameCol(string strCostCenterHRName)
        {

            CostCenterHRCol Returned = new CostCenterHRCol(true);
            strCostCenterHRName = strCostCenterHRName.Replace(" ", "");

            foreach (CostCenterHRBiz objbiz in this)
            {
                if (SysUtility.ReplaceStringComp(objbiz.NameA).IndexOf(strCostCenterHRName) != -1)
                {
                    Returned.Add(objbiz);
                }
            }

            return Returned;
        }
        public CostCenterHRCol GetCostCenterCol(string strName)
        {

            CostCenterHRCol Returned = new CostCenterHRCol(true);
            strName = strName.Trim();
            string[] arrStr = strName.Split("%".ToCharArray());
            bool blIsFound = false;
            foreach (CostCenterHRBiz objbiz in this)
            {
                blIsFound = true;
                foreach (string strTemp in arrStr)
                {
                    if (objbiz.Name.IndexOf(strTemp) == -1)
                        blIsFound = false;
                }
                if (blIsFound)
                    Returned.Add(objbiz);
            }

            return Returned;
        }
      
       
        void SetChildren(ref CostCenterHRBiz objCostCenterHRBiz, ref DataTable dtCostcenterTree)
        {
            objCostCenterHRBiz.Children = new CostCenterHRCol(true);
            objCostCenterHRBiz.Children.RootBiz = objCostCenterHRBiz;
            DataRow[] arrDR = dtCostcenterTree.Select(" Costcenter <> CostCenterParent and CostCenterParent=" + objCostCenterHRBiz.ID);
            CostCenterHRBiz tempCostCenterHRBiz;
            CostCenterHRCol objCostCenterHRCol;
            objCostCenterHRCol = new CostCenterHRCol(true);
            int intTemp = 0;

            foreach (DataRow DR in arrDR)
            {

                //tempCostCenterHRBiz = new CostCenterHRBiz(int.Parse(DR["CostCenter"].ToString()));
                tempCostCenterHRBiz = new CostCenterHRBiz(DR);
                if (intTemp == tempCostCenterHRBiz.ID)
                    continue;
                else
                {
                    intTemp = tempCostCenterHRBiz.ID;
                }
                //if (_NodeNo >= 200)
                //    break;
                SetChildren(ref tempCostCenterHRBiz, ref dtCostcenterTree);
                tempCostCenterHRBiz.CostCenterParentBiz = objCostCenterHRBiz;
                objCostCenterHRCol.Add(tempCostCenterHRBiz);
            }
            objCostCenterHRBiz.Children = objCostCenterHRCol;

        }

        public CostCenterHRCol GetCostCenterHRCol(string strCostCenterHRName)
        {

            CostCenterHRCol Returned = new CostCenterHRCol(true);
            foreach (CostCenterHRBiz objbiz in this)
            {
                SetChildrenCol(ref Returned, strCostCenterHRName, objbiz);
            }
            return Returned;
        }
        void SetChildrenCol(ref CostCenterHRCol objCostCenterHRCol, string strCostCenterName, CostCenterHRBiz objCostCenterHRBiz)
        {
            if (objCostCenterHRBiz.Name.IndexOf(strCostCenterName) != -1)
                objCostCenterHRCol.Add(objCostCenterHRBiz);
            else
            {
                if (objCostCenterHRBiz.Children != null)
                {
                    foreach (CostCenterHRBiz objBiz in objCostCenterHRBiz.Children)
                    {
                        SetChildrenCol(ref objCostCenterHRCol, strCostCenterName, objBiz);
                    }
                }
            }
        }

        public static CostCenterHRBiz GetCostCenterHRBiz(int intID)
        {
            foreach (CostCenterHRBiz objBiz in CostCenterHRCol.CacheCostCenterHRCol)
            {
                if (objBiz.ID == intID)
                {
                    return objBiz;
                }
            }
            return new CostCenterHRBiz();
        }

        static CostCenterHRCol _CacheCostCenterHRCol;
        public static CostCenterHRCol CacheCostCenterHRCol
        {
            set
            {
                _CacheCostCenterHRCol = value;
            }
            get
            {
                if (_CacheCostCenterHRCol == null)
                {
                    _CacheCostCenterHRCol = new CostCenterHRCol(false);
                }
                return _CacheCostCenterHRCol;
            }
        }
    }
}


