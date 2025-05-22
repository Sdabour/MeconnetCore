using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.HR.HRDataBase;
using System.Data;
using SharpVision.COMMON.COMMONBusiness;
using SharpVision.UMS.UMSBusiness;
using SharpVision.Base.BaseBusiness;

namespace SharpVision.HR.HRBusiness
{
    public class SubSectorBranchCol : BaseCol
    {
        
         
        public SubSectorBranchCol()
        {
            SubSectorBranchDb objSubSectorBranchDb = new SubSectorBranchDb();
            DataTable dtSubSectorBranch = objSubSectorBranchDb.Search();
            FillCachSubSectorAdminTable(dtSubSectorBranch);
            SubSectorBranchBiz objSubSectorBranchBiz;
            foreach (DataRow objDr in dtSubSectorBranch.Rows)
            {
                //if(objDr["BranchID"].ToString()!= "")
                objSubSectorBranchBiz = new SubSectorBranchBiz(objDr);
                


                this.Add(objSubSectorBranchBiz);
            }
        }
        public SubSectorBranchCol(SectorBiz objSectorBiz,BranchBiz objBranchBiz)
        {
            SubSectorBranchDb objSubSectorBranchDb = new SubSectorBranchDb();
            if (objBranchBiz != null && objBranchBiz.ID != 0)
                objSubSectorBranchDb.BranchID = objBranchBiz.ID;
            if(objSectorBiz != null && objSectorBiz.ID != 0)
                objSubSectorBranchDb.SectorID = objSectorBiz.ID;
            DataTable dtSubSectorBranch = objSubSectorBranchDb.Search();
            FillCachSubSectorAdminTable(dtSubSectorBranch);
            SubSectorBranchBiz objSubSectorBranchBiz;
            foreach (DataRow objDr in dtSubSectorBranch.Rows)
            {
                objSubSectorBranchBiz = new SubSectorBranchBiz(objDr);
                this.Add(objSubSectorBranchBiz);
            }
        }
         public SubSectorBranchCol(bool blIsempty)
        {

        }
        public SubSectorBranchCol(int intID)
        {
            SubSectorBranchDb objDb = new SubSectorBranchDb();
            objDb.ID = intID;
            DataTable dtTemp = objDb.Search();
            FillCachSubSectorAdminTable(dtTemp);
            foreach (DataRow objDr in dtTemp.Rows)
            {
                Add(new SubSectorBranchBiz(objDr));
            }
        }



        public SubSectorBranchBiz this[int intIndex]
        {

            get
            {
                return (SubSectorBranchBiz)List[intIndex];
            }
        }

        #region Private Methods

        static void FillCachSubSectorAdminTable(DataTable dtSubSectorBranch)
        {
            DataRow[] arrDR;
            arrDR = dtSubSectorBranch.Select("", "SectorAdmin");
            string strTempSubSectorAdmin = "";
            string strSubSectorAdminIDs = "";
            foreach (DataRow objDr in arrDR)
            {
                if (objDr["SubSectorAdmin"].ToString() != "0")
                {
                    if (strTempSubSectorAdmin != objDr["SubSectorAdmin"].ToString())
                    {
                        if (strSubSectorAdminIDs != "")
                            strSubSectorAdminIDs += ",";
                        strSubSectorAdminIDs += objDr["SubSectorAdmin"].ToString();
                        strTempSubSectorAdmin = objDr["SubSectorAdmin"].ToString();
                    }
                }
            }
            
        }  

        public void Add(SubSectorBranchBiz objBiz)
        {
            List.Add(objBiz);

        }

        #endregion

    }
}
