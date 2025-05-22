using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.UMS.UMSBusiness;
using SharpVision.CRM.CRMDataBase;

using System.Data;
using SharpVision.Base.BaseBusiness;

namespace SharpVision.CRM.CRMBusiness
{
    public class ReservationAttachmentCol : BaseCol
    {
        public ReservationAttachmentCol(bool blIsempty)
        {

        }
        public ReservationAttachmentCol(int intID)
        {
            ReservationAttachmentDb objDb = new ReservationAttachmentDb();
            objDb.ID = intID;
            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
            {
                Add(new ReservationAttachmentBiz(objDr));
            }
        }

        public ReservationAttachmentBiz this[int intIndex]
        {
           
            get
            {
                return (ReservationAttachmentBiz)List[intIndex];
            }
        }

        public void Add(ReservationAttachmentBiz objBiz)
        {
            List.Add(objBiz);
 
        }

        internal DataTable GetTable()
        {
            DataTable dtReturned = new DataTable();
            dtReturned.Columns.AddRange(new DataColumn[] { new DataColumn("ReservationAttachmentID"), new DataColumn("AttachmentID"), new DataColumn("AttachmentParentID"), new DataColumn("AttachmentFamilyID"), new DataColumn("AttachmentTypeID"), new DataColumn("ReservationID"), new DataColumn("AttachmentDesc") });
            DataRow objDr;
            foreach (ReservationAttachmentBiz objBiz in this)
            {
                objDr = dtReturned.NewRow();
                objDr["ReservationAttachmentID"] = objBiz.ID;
                objDr["AttachmentID"] = objBiz.AttachmentFileBiz.ID;
                objDr["AttachmentParentID"] = objBiz.ParentBiz.ID;
                objDr["AttachmentFamilyID"] = objBiz.FamilyID;
                objDr["AttachmentTypeID"] = objBiz.TypeBiz.ID;
                objDr["ReservationID"] = objBiz.ReservationBiz.ID;
                objDr["AttachmentDesc"] = objBiz.Desc;
                dtReturned.Rows.Add(objDr);
            }
            return dtReturned;

        }

    }
}
