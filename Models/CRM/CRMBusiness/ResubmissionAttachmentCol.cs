using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.UMS.UMSBusiness;
using SharpVision.CRM.CRMDataBase;

using System.Data;
using SharpVision.Base.BaseBusiness;

namespace SharpVision.CRM.CRMBusiness
{
    public class ResubmissionAttachmentCol : BaseCol
    {
        public ResubmissionAttachmentCol(bool blIsempty)
        {

        }
        public ResubmissionAttachmentCol(int intID)
        {
            ResubmissionAttachmentDb objDb = new ResubmissionAttachmentDb();
            objDb.ID = intID;
            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
            {
                Add(new ResubmissionAttachmentBiz(objDr));
            }
        }

        public ResubmissionAttachmentBiz this[int intIndex]
        {

            get
            {
                return (ResubmissionAttachmentBiz)List[intIndex];
            }
        }

        public void Add(ResubmissionAttachmentBiz objBiz)
        {
            List.Add(objBiz);

        }

        internal DataTable GetTable()
        {
            DataTable dtReturned = new DataTable();
            dtReturned.Columns.AddRange(new DataColumn[] { new DataColumn("ResubmissionAttachmentID"), new DataColumn("AttachmentID"), new DataColumn("AttachmentParentID"), new DataColumn("AttachmentFamilyID"), new DataColumn("AttachmentTypeID"), new DataColumn("ResubmissionID"), new DataColumn("AttachmentDesc") });
            DataRow objDr;
            foreach (ResubmissionAttachmentBiz objBiz in this)
            {
                objDr = dtReturned.NewRow();
                objDr["ResubmissionAttachmentID"] = objBiz.ID;
                objDr["AttachmentID"] = objBiz.AttachmentFileBiz.ID;
                objDr["AttachmentParentID"] = objBiz.ParentBiz.ID;
                objDr["AttachmentFamilyID"] = objBiz.FamilyID;
                objDr["AttachmentTypeID"] = objBiz.TypeBiz.ID;
                objDr["ResubmissionID"] = objBiz.ResubmissionBiz.ID;
                objDr["AttachmentDesc"] = objBiz.Desc;
                dtReturned.Rows.Add(objDr);
            }
            return dtReturned;

        }

    }
}
