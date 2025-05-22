using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.CRM.CRMDataBase;
using System.Data;
using System.Collections;
using SharpVision.COMMON.COMMONBusiness;
using SharpVision.COMMON.COMMONDataBase;
using SharpVision.Base.BaseBusiness;
using SharpVision.RP.RPBusiness;
namespace SharpVision.CRM.CRMBusiness
{
    public class CampaignCol : BaseCol
    {
        public CampaignCol(bool blIsEmpty)
        {
            
        }
        public CampaignCol()
        {
            CampaignDb objCampaignDb = new CampaignDb();
            DataTable dtCampaign = objCampaignDb.Search();
            CampaignBiz objCampaignBiz;
            foreach (DataRow DR in dtCampaign.Rows)
            {
                objCampaignBiz = new CampaignBiz(DR);
                this.Add(objCampaignBiz);
            }
        }
        public CampaignCol(int intContactID,bool blIsDateRange,
            DateTime dtFrom,DateTime dtTo,string strDesc,CellBiz objCellBiz,
            int intInstallmentStatus,int intContactStatus,int intIsSystemStatus)
        {
            if (objCellBiz == null)
                objCellBiz = new CellBiz();
            CampaignDb objCampaignDb = new CampaignDb();
            objCampaignDb.ContactItem = intContactID;
            objCampaignDb.IsDateRange = blIsDateRange;
            objCampaignDb.FromDate = dtFrom;
            objCampaignDb.ToDate = dtTo;
            objCampaignDb.Desc = strDesc;
            objCampaignDb.InstallmentStatus = intInstallmentStatus;
            objCampaignDb.CellFamilyID = objCellBiz.FamilyID;
            objCampaignDb.ContactedCustomerStatus = intContactStatus;
            objCampaignDb.SystemCampaignStatus = intIsSystemStatus;
            DataTable dtCampaign = objCampaignDb.Search();
            CampaignBiz objCampaignBiz;
            foreach (DataRow DR in dtCampaign.Rows)
            {
                objCampaignBiz = new CampaignBiz(DR);
                this.Add(objCampaignBiz);
            }
        }
        public virtual CampaignBiz this[int intIndex]
        {
            get
            {
                return (CampaignBiz)this.List[intIndex];
            }
        }
        public string IDsStr
        {
            get
            {
                string Returned = "";
                foreach (CampaignBiz objBiz in this)
                {
                    if (Returned != "")
                        Returned += ",";
                    Returned += objBiz.ID.ToString();
                }
                return Returned;
            }
        }
        public CampaignCol InstallmentCampaignCol
        {
            get
            {
                CampaignCol Returned = new CampaignCol(true);
                foreach (CampaignBiz objBiz in this)
                {
                    if (objBiz.IsForInstallment)
                        Returned.Add(objBiz);
                }
                return Returned;
            }
        }
        public virtual void Add(CampaignBiz objCampaignBiz)
        {

            this.List.Add(objCampaignBiz);
        }
        public int GetIndex(CampaignBiz objCampaignBiz)
        {
           
            int intIndex = 0;
            foreach (CampaignBiz objBiz in this)
            {
                if (objBiz.ID == objCampaignBiz.ID)
                    return intIndex;
                intIndex++;
            }
            return -1;
        }
        
    }
}
