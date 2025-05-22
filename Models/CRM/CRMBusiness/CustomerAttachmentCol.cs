using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.UMS.UMSBusiness;
using SharpVision.CRM.CRMDataBase;

using System.Data;
using SharpVision.Base.BaseBusiness;
using SharpVision.COMMON.COMMONBusiness;
namespace SharpVision.CRM.CRMBusiness
{
    public class CustomerAttachmentCol : AttachmentCol
    {
        public CustomerAttachmentCol(bool blIsempty)
        {

        }
        public CustomerAttachmentCol(int intID)
        {
            CustomerAttachmentDb objDb = new CustomerAttachmentDb();
            objDb.ID = intID;
            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
            {
                Add(new CustomerAttachmentBiz(objDr));
            }
        }

        public CustomerAttachmentBiz this[int intIndex]
        {

            get
            {
                return (CustomerAttachmentBiz)List[intIndex];
            }
        }

        public void Add(CustomerAttachmentBiz objBiz)
        {
            List.Add(objBiz);

        }



    }
}
