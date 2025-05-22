using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.CRM.CRMDataBase;
using System.Data;
using System.Collections;
using SharpVision.COMMON.COMMONBusiness;
using SharpVision.COMMON.COMMONDataBase;
using SharpVision.Base.BaseBusiness;

namespace SharpVision.CRM.CRMBusiness
{

        public class CampaignSMSCol : BaseCol
        {
            public CampaignSMSCol(bool blIsEmpty)
            {

            }
            public CampaignSMSCol()
            {
            }
            public CampaignSMSCol(int intID)
            {
                CampaignSMSDb objCampaignSMSDb = new CampaignSMSDb();
                objCampaignSMSDb.ID = intID;
                DataTable dtCampaignSMS = objCampaignSMSDb.Search();
                CampaignSMSBiz objCampaignSMSBiz;
                foreach (DataRow DR in dtCampaignSMS.Rows)
                {
                    objCampaignSMSBiz = new CampaignSMSBiz(DR);
                    this.Add(objCampaignSMSBiz);
                }
            }
            public virtual CampaignSMSBiz this[int intIndex]
            {
                get
                {
                    return (CampaignSMSBiz)this.List[intIndex];
                }
            }
            public virtual void Add(CampaignSMSBiz objCampaignSMSBiz)
            {

                this.List.Add(objCampaignSMSBiz);
            }
        }
    }

