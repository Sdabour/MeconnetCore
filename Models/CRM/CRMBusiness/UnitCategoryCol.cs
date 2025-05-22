using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using SharpVision.CRM.CRMDataBase;
using System.Collections;
using SharpVision.SystemBase;
namespace SharpVision.CRM.CRMBusiness
{
    public class UnitCategoryCol :CollectionBase
    {

        Hashtable _CategoryNameHash = new Hashtable();
        #region Constructor
        public UnitCategoryCol()
        {

            UnitCategoryBiz objBiz = new UnitCategoryBiz();
             

            UnitCategoryDb objDb = new UnitCategoryDb();

            DataTable dtTemp = objDb.Search();


            foreach (DataRow objDR in dtTemp.Rows)
            {
                objBiz = new UnitCategoryBiz(objDR);
                Add(objBiz);
            }

        }
        public UnitCategoryCol(bool blIsEmbty)
        {
            if (blIsEmbty)
                return;
            UnitCategoryBiz objBiz = new UnitCategoryBiz();
            objBiz.ID = 0;
            objBiz.NameA = "غير محدد";
            objBiz.NameE = "Not Specified";
            Add(objBiz);

            UnitCategoryDb objDb = new UnitCategoryDb();

            DataTable dtTemp = objDb.Search();


            foreach (DataRow objDR in dtTemp.Rows)
            {
                objBiz = new UnitCategoryBiz(objDR);
                Add(objBiz);
            }
        }

        #endregion
        #region Private Data
        public UnitCategoryBiz this[int intIndex]
        {
            get => (UnitCategoryBiz)List[intIndex];
        }
        #endregion
        #region Properties
       public string IDsStr
        {
            get
            {
                string Returned = "";
                foreach (UnitCategoryBiz objBiz in this)
                {
                    if (Returned != "")
                        Returned += ",";
                    Returned += objBiz.ID.ToString();
                }
                return Returned;
            }
        }
        #endregion
        #region Private Method

        #endregion
        #region Public Method 
        public void Add(UnitCategoryBiz objBiz)
        {
            if (_CategoryNameHash[objBiz.Name.ToUpper()] == null)
                _CategoryNameHash.Add(objBiz.Name.ToUpper(), objBiz);
            List.Add(objBiz);
        }
        public UnitCategoryBiz GetCategoryBizByName(string strName)
        {
            UnitCategoryBiz Returned = new UnitCategoryBiz();
            if (_CategoryNameHash[strName.ToUpper()] != null)
                Returned =(UnitCategoryBiz) _CategoryNameHash[strName.ToUpper()];

            return Returned;
        }
        public UnitCategoryCol GetCol(string strTemp)
        {
            UnitCategoryCol Returned = new UnitCategoryCol(true);
            foreach (UnitCategoryBiz objBiz in this)
            {
                if (objBiz.Name.CheckStr(strTemp))
                    Returned.Add(objBiz);
            }
            return Returned;
        }
        public DataTable GetTable()
        {
            DataTable Returned = new DataTable();
            Returned.Columns.AddRange(new DataColumn[] { new DataColumn("CategoryID"), new DataColumn("CategoryNameA"), new DataColumn("CategoryNameE"), new DataColumn("CategoryCode") });
            DataRow objDr;
            foreach (UnitCategoryBiz objBiz in this)
            {
                objDr = Returned.NewRow();
                objDr["CategoryID"] = objBiz.ID;
                objDr["CategoryNameA"] = objBiz.NameA;
                objDr["CategoryNameE"] = objBiz.NameE;
                objDr["CategoryCode"] = objBiz.Code;
                Returned.Rows.Add(objDr);
            }
            return Returned;
        }
        public UnitCategoryCol Copy()
        {
            UnitCategoryCol Returned = new UnitCategoryCol(true);
            foreach(UnitCategoryBiz objBiz in this)
            {
                Returned.Add(objBiz);
            }
            return Returned;
        }
        #endregion
    }
}
