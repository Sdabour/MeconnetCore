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
    public class FileTypeCol : BaseCol
    {
        public FileTypeCol(bool blIsempty)
        {
            if (blIsempty)
                return;
            FileTypeBiz objBiz = new FileTypeBiz();
            objBiz.NameA = "غير محدد";
            objBiz.NameE = "Not Specified";
            Add(objBiz);
            FileTypeDb objDb = new FileTypeDb();

            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
            {
                Add(new FileTypeBiz(objDr));
            }
        }
        public FileTypeCol()
        {
            FileTypeDb objDb = new FileTypeDb();
            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
            {
                Add(new FileTypeBiz(objDr));
            }
        }

        public FileTypeBiz this[int intIndex]
        {

            get
            {
                return (FileTypeBiz)List[intIndex];
            }
        }
        public void Add(FileTypeBiz objBiz)
        {
            List.Add(objBiz);

        }
        public FileTypeCol GetCol(string strName)
        {
            FileTypeCol Returned = new FileTypeCol(true);
            string[] arrStr = strName.Split('%');

            bool blIsOk = true;
            foreach (FileTypeBiz objBiz in this)
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
        public FileTypeCol Copy()
        {
            FileTypeCol Returned = new FileTypeCol(true);
            foreach (FileTypeBiz objBiz in this)
            {
                Returned.Add(objBiz.Copy());
            }
            return Returned;

        }
        public DataTable GetTable()
        {
            DataTable Returned = new DataTable(FileTypeDb.TableName);
            Returned.Columns.AddRange(new DataColumn[] { new DataColumn("FileTypeID")
                ,new DataColumn("FileTypeNameA"),new DataColumn("FileTypeNameE")
            ,new DataColumn("FileTypeCode") });
            DataRow objDr;
            foreach (FileTypeBiz objBiz in this)
            {
                objDr = Returned.NewRow();
                objDr["FileTypeID"] = objBiz.ID;
                objDr["FileTypeNameA"] = objBiz.NameA;
                objDr["FileTypeNameE"] = objBiz.NameE;
                objDr["FileTypeCode"] = objBiz.Code;
              

                Returned.Rows.Add(objDr);
            }
            return Returned;
        }

    }
}
