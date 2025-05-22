using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.Base.BaseDataBase;
using SharpVision.Base.BaseBusiness;
using Algorithmat.Algorithmat.AlgorithmatDataBase;
using SharpVision.SystemBase;



namespace Algorithmat.Algorithmat.AlgorithmatBusiness
{
    public class ContentTypeCol : BaseCol
    {
        public ContentTypeCol(bool blIsempty)
        {
            if (blIsempty)
                return;
            ContentTypeBiz objBiz = new ContentTypeBiz();
            objBiz.NameA = "غير محدد";
            objBiz.NameE = "Not Specified";
            Add(objBiz);
            ContentTypeDb objDb = new ContentTypeDb();

            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
            {
                Add(new ContentTypeBiz(objDr));
            }
        }
        public ContentTypeCol()
        {
            ContentTypeDb objDb = new ContentTypeDb();
            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
            {
                Add(new ContentTypeBiz(objDr));
            }
        }

        public ContentTypeBiz this[int intIndex]
        {

            get
            {
                return (ContentTypeBiz)List[intIndex];
            }
        }
        public void Add(ContentTypeBiz objBiz)
        {
            List.Add(objBiz);

        }
        public ContentTypeCol GetCol(string strName)
        {
            ContentTypeCol Returned = new ContentTypeCol(true);
            string[] arrStr = strName.Split('%');

            bool blIsOk = true;
            foreach (ContentTypeBiz objBiz in this)
            {
                blIsOk = true;
                foreach (string strTemp in arrStr)
                {
                    if (SysUtility.ReplaceStringComp(objBiz.Name).
                        IndexOf(SysUtility.ReplaceStringComp(strTemp)) == -1 &&
                        objBiz.Code.
                        IndexOf(SysUtility.ReplaceStringComp(strTemp)) == -1)
                    {
                        blIsOk = false;
                        break;
                    }

                }
                if (blIsOk)
                    Returned.Add(objBiz);
            }
            return Returned;
        }
        public ContentTypeCol Copy()
        {
            ContentTypeCol Returned = new ContentTypeCol(true);
            foreach (ContentTypeBiz objBiz in this)
            {
                Returned.Add(objBiz.Copy());
            }
            return Returned;

        }
        public DataTable GetTable()
        {
            DataTable Returned = new DataTable(ContentTypeDb.TableName);
            Returned.Columns.AddRange(new DataColumn[] { new DataColumn("ContentTypeID")
                ,new DataColumn("ContentTypeNameA"),new DataColumn("ContentTypeNameE")
            ,new DataColumn("ContentTypeCode"),new DataColumn("ContentTypeDisplayPageA")
            ,new DataColumn("ContentTypeDisplayPageE"),new DataColumn("ContentTypeDisplayIndex")});
            DataRow objDr;
            foreach (ContentTypeBiz objBiz in this)
            {
                objDr = Returned.NewRow();
                objDr["ContentTypeID"] = objBiz.ID;
                objDr["ContentTypeNameA"] = objBiz.NameA;
                objDr["ContentTypeNameE"] = objBiz.NameE;
                objDr["ContentTypeCode"] = objBiz.Code;
                objDr["ContentTypeDisplayPageA"] = objBiz.DisplayPageA;
                objDr["ContentTypeDisplayPageE"] = objBiz.DisplayPageE;
                objDr["ContentTypeDisplayIndex"] = objBiz.DisplayIndex;
                    
                Returned.Rows.Add(objDr);
            }
            return Returned;
        }
    }

}
