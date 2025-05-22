using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.UMS.UMSBusiness;
using SharpVision.CRM.CRMDataBase;

using System.Data;
using SharpVision.Base.BaseBusiness;
using SharpVision.SystemBase;
namespace SharpVision.CRM.CRMBusiness
{
    public class InstallmentTypeCol : BaseCol
    {
        public InstallmentTypeCol()
        {
            InstallmentTypeDb objDb = new InstallmentTypeDb();
            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
            {
                Add(new InstallmentTypeBiz(objDr));
            }
        }
        public InstallmentTypeCol(bool blIsempty)
        {
            if (!blIsempty)
            {
                InstallmentTypeBiz objBiz = new InstallmentTypeBiz();
                objBiz.ID = 0;
                objBiz.NameA = "€Ì— „Õœœ";
                objBiz.NameE = "Not Specified";
                Add(objBiz);
                InstallmentTypeDb objDb = new InstallmentTypeDb();
                DataTable dtTemp = objDb.Search();
                foreach (DataRow objDr in dtTemp.Rows)
                {
                    Add(new InstallmentTypeBiz(objDr));
                }
            }
        }
        public InstallmentTypeCol(int intID)
        {
            InstallmentTypeDb objDb = new InstallmentTypeDb();
            objDb.ID = intID;
            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
            {
                Add(new InstallmentTypeBiz(objDr));
            }
        }

        public InstallmentTypeBiz this[int intIndex]
        {
           
            get
            {
                return (InstallmentTypeBiz)List[intIndex];
            }
        }
        public string IDsStr
        {
            get
            {
                string Returned = "";
                foreach (InstallmentTypeBiz objBiz in this)
                {
                    if (Returned != "")
                        Returned += ",";
                    Returned += objBiz.ID.ToString();
                }
                return Returned;
            }
        }
        static InstallmentTypeCol _CacheInstallmentTypeCol;
        public static InstallmentTypeCol CacheInstallmentTypeCol
        {
            get
            {
                if (_CacheInstallmentTypeCol == null)
                    _CacheInstallmentTypeCol = new InstallmentTypeCol(false);
                return _CacheInstallmentTypeCol;
            }
        }
        public void Add(InstallmentTypeBiz objBiz)
        {
            if (objBiz.ID == 0 || !Contains(objBiz))
              List.Add(objBiz);
 
        }
        public void Add(InstallmentTypeCol objCol)
        {
            foreach (InstallmentTypeBiz objBiz in objCol)
            {
                if (objBiz.ID== 0 || !Contains(objBiz))
                    List.Add(objBiz);
            }

        }
        public bool Contains(InstallmentTypeBiz objTypeBiz )
        {
            foreach (InstallmentTypeBiz objBiz in this)
            {
                if (objBiz.ID == objTypeBiz.ID)
                {
                    return true;
                }
 
            }
            return false;
        }
        public InstallmentTypeCol GetInstallmentTypeByName(string strName)
        {
            InstallmentTypeCol Returned = new InstallmentTypeCol(true);
            foreach (InstallmentTypeBiz objBiz in this)
            {
                if (SysUtility.ReplaceStringComp(objBiz.Name).IndexOf
                    (SysUtility.ReplaceStringComp(strName)) != -1)
                    Returned.Add(objBiz);
            }
            return Returned;
        }
        public int GetIndex(int intID)
        {
            for (int intIndex = 0; intIndex < Count; intIndex++)
            {
                if (this[intIndex].ID == intID)
                    return intIndex;
            }
            return -1;
        }
        internal DataTable GetTable()
        {
            DataTable dtReturned = new DataTable();
            dtReturned.Columns.AddRange(new DataColumn[] { new DataColumn("ID"), new DataColumn("NameA"), new DataColumn("NameE"), new DataColumn("Name") });
            DataRow objDr;
            foreach (InstallmentTypeBiz objBiz in this)
            {
                objDr = dtReturned.NewRow();
                objDr["ID"] = objBiz.ID;
                objDr["Name"] = objBiz.Name;
                objDr["NameA"] = objBiz.NameA;
                objDr["NameE"] = objBiz.NameE;
                dtReturned.Rows.Add(objDr);

            }
            return dtReturned;

        }
        public InstallmentTypeCol Copy()
        {
            InstallmentTypeCol Returned = new InstallmentTypeCol(true);
            foreach (InstallmentTypeBiz objBiz in this)
            {
                Returned.Add(objBiz);
            }
            return Returned;
        }
    }
}
