using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.UMS.UMSBusiness;
using SharpVision.CRM.CRMDataBase;
using System.Data;
using SharpVision.Base.BaseBusiness;
using SharpVision.SystemBase;
using System.Net;
using System.IO;
namespace SharpVision.CRM.CRMBusiness
{
    public class SalesRepAdminCol : BaseCol
    {
        #region Private Data
        
        #endregion
        #region Constructors
        public SalesRepAdminCol()
        {
            SalesRepAdminDb objDb = new SalesRepAdminDb();
            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
            {
                Add(new SalesRepAdminBiz(objDr));
            }
 
        }
        #endregion
        #region Public Properties
        public SalesRepAdminBiz this[int intIndex]
        {
            get
            {
                return (SalesRepAdminBiz)List[intIndex];
            }
        }
        public string PhoneNo
        {
            get
            {
                string Returned = "";
                string strNo = "";
                foreach (SalesRepAdminBiz objBiz in this)
                {
                    strNo = objBiz.PhoneNo;
                    if (CampaignSMSBiz.CheckMsgNo(ref strNo))
                    {
                        if (Returned != "")
                            Returned += ",";
                        Returned += strNo;
                    }

                }
                return Returned;
            }
        }
        #endregion
        #region Private Methods
      
        #endregion
        #region Public Methods
        public void Add(SalesRepAdminBiz objBiz)
        {
            List.Add(objBiz);
        }
        #endregion
    }
}
