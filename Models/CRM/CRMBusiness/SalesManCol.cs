using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.UMS.UMSBusiness;
using SharpVision.CRM.CRMDataBase;
using System.Data;
using SharpVision.Base.BaseBusiness;
using SharpVision.COMMON.COMMONBusiness;
using SharpVision.COMMON.COMMONDataBase;
using SharpVision.HR.HRBusiness;

namespace SharpVision.CRM.CRMBusiness
{
   public  class SalesManCol : BaseCol
    {

       public SalesManCol()
       {
           
       }

       public SalesManCol(bool blIsempty)
        {
            if (blIsempty)
                return;
           SalesManDb objDb = new SalesManDb();
            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
            {
                Add(new SalesManBiz(objDr));
            }
       }
        public SalesManCol(int intID)
        {
            SalesManDb objDb = new SalesManDb();
            objDb.ID = intID;
            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
            {
                Add(new SalesManBiz(objDr));
            }
        }

       public SalesManCol(BranchBiz objBranchBiz)
       {
           SalesManBiz objBiz = new SalesManBiz();
           objBiz.Name = "€Ì— „Õœœ";
           Add(objBiz);
           SalesManDb objDb = new SalesManDb();
           objDb.BranchID = objBranchBiz.ID;
           DataTable dtTemp = objDb.Search();
           foreach (DataRow objDR in dtTemp.Rows)
           {
               Add(new SalesManBiz(objDR));
           }
       }

       public SalesManCol(int UserID, bool isAdmin)
       {
           SalesManDb objDb = new SalesManDb();
          // objDb.User = UserID;
           objDb.IsSectorAdmin = false;
           DataTable dtTemp = objDb.Search();
           foreach (DataRow objDr in dtTemp.Rows)
           {
               Add(new SalesManBiz(objDr));
           }
       }

       public SalesManCol(BranchBiz objBranchBiz,bool blIsempty)
       {

           if (!blIsempty)
           {
               SalesManBiz objBiz = new SalesManBiz();
               objBiz.Name = "€Ì— „Õœœ";
               Add(objBiz);

               SalesManDb objDb = new SalesManDb();
               objDb.BranchID = objBranchBiz.ID;
               DataTable dtTemp = objDb.Search();
               foreach (DataRow objDR in dtTemp.Rows)
               {
                   Add(new SalesManBiz(objDR));
               }
           }
       }

        public SalesManCol(BranchCol objBranchCol)
       {
           if (objBranchCol == null)
               objBranchCol = new BranchCol(true,0);
           
               SalesManBiz objBiz = new SalesManBiz();
               objBiz.Name = "€Ì— „Õœœ";
               Add(objBiz);

               SalesManDb objDb = new SalesManDb();
               objDb.BranchIDs = objBranchCol.IDs;
               DataTable dtTemp = objDb.Search();
               foreach (DataRow objDR in dtTemp.Rows)
               {
                   Add(new SalesManBiz(objDR));
               }
           }
       public SalesManCol(string strName,string strNameComp,string strFamousName,string strCode,BranchBiz _BranchBiz)
        {
            SalesManDb objSalesManDb = new SalesManDb();
            objSalesManDb.FirstNameLike = strName;
            objSalesManDb.NameCompLike = strNameComp;
            objSalesManDb.FamousNameLike = strFamousName;
            objSalesManDb.BranchID = _BranchBiz.ID;
            objSalesManDb.CodeLike = strCode;
            DataTable dtApplicant = objSalesManDb.Search();
            SalesManBiz objSalesManBiz;
            foreach (DataRow objDr in dtApplicant.Rows)
            {
                objSalesManBiz = new SalesManBiz(objDr);
                this.Add(objSalesManBiz);
            }
        }


        public SalesManBiz this[int intIndex]
        {
           
            get
            {
                return (SalesManBiz)List[intIndex];
            }
        }

        public void Add(SalesManBiz objBiz)
        {
            List.Add(objBiz);
 
        }
       public string ApplicantIDs
       {
           get
           {
               string strIDs = "";
               foreach (SalesManBiz objBiz in this)
               {
                   if (strIDs != "")
                       strIDs += "," + objBiz.ID.ToString();
                   else
                       strIDs += objBiz.ID.ToString();
               }
               return strIDs;
           }
       }
    }
}
