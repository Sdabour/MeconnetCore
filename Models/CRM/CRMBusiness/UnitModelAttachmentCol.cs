using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.UMS.UMSBusiness;
using SharpVision.CRM.CRMDataBase;

using System.Data;
using SharpVision.Base.BaseBusiness;

namespace SharpVision.CRM.CRMBusiness
{
    public class UnitModelAttachmentCol : BaseCol
    {
        public UnitModelAttachmentCol(bool blIsempty)
        {

        }
        public UnitModelAttachmentCol(int intID)
        {
            UnitModelAttachmentDb objDb = new UnitModelAttachmentDb();
            objDb.ID = intID;
            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
            {
                Add(new UnitModelAttachmentBiz(objDr));
            }
        }

        public UnitModelAttachmentBiz this[int intIndex]
        {

            get
            {
                return (UnitModelAttachmentBiz)List[intIndex];
            }
        }

        public void Add(UnitModelAttachmentBiz objBiz)
        {
            List.Add(objBiz);

        }



    }
}
