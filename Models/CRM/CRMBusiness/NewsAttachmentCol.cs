using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.UMS.UMSBusiness;
using SharpVision.CRM.CRMDataBase;

using System.Data;
using SharpVision.Base.BaseBusiness;

namespace SharpVision.CRM.CRMBusiness
{
    public class NewsAttachmentCol : BaseCol
    {
        public NewsAttachmentCol(bool blIsempty)
        {

        }
        public NewsAttachmentCol(int intID)
        {
            NewsAttachmentDb objDb = new NewsAttachmentDb();
            objDb.ID = intID;
            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
            {
                Add(new NewsAttachmentBiz(objDr));
            }
        }

        public NewsAttachmentBiz this[int intIndex]
        {

            get
            {
                return (NewsAttachmentBiz)List[intIndex];
            }
        }

        public void Add(NewsAttachmentBiz objBiz)
        {
            List.Add(objBiz);

        }

        internal DataTable GetTable()
        {
            DataTable dtReturned = new DataTable();
            dtReturned.Columns.AddRange(new DataColumn[] { new DataColumn("NewsAttachmentID"), new DataColumn("AttachmentID"), new DataColumn("AttachmentParentID"), new DataColumn("AttachmentFamilyID"), new DataColumn("AttachmentTypeID"), new DataColumn("NewsID"), new DataColumn("AttachmentDesc") });
            DataRow objDr;
            foreach (NewsAttachmentBiz objBiz in this)
            {
                objDr = dtReturned.NewRow();
                objDr["NewsAttachmentID"] = objBiz.ID;
                objDr["AttachmentID"] = objBiz.AttachmentFileBiz.ID;
                objDr["AttachmentParentID"] = objBiz.ParentBiz.ID;
                objDr["AttachmentFamilyID"] = objBiz.FamilyID;
                objDr["AttachmentTypeID"] = objBiz.TypeBiz.ID;
                objDr["NewsID"] = objBiz.NewsBiz.ID;
                objDr["AttachmentDesc"] = objBiz.Desc;
                dtReturned.Rows.Add(objDr);
            }
            return dtReturned;

        }

    }
}
