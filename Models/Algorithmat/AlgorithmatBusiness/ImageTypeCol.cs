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
    public class ImageTypeCol : BaseCol
    {
        public ImageTypeCol(bool blIsempty)
        {
            if (blIsempty)
                return;
            ImageTypeBiz objBiz = new ImageTypeBiz();
            objBiz.NameA = "غير محدد";
            objBiz.NameE = "Not Specified";
            Add(objBiz);
            ImageTypeDb objDb = new ImageTypeDb();

            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
            {
                Add(new ImageTypeBiz(objDr));
            }
        }
        public ImageTypeCol()
        {
            ImageTypeDb objDb = new ImageTypeDb();
            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
            {
                Add(new ImageTypeBiz(objDr));
            }
        }

        public ImageTypeBiz this[int intIndex]
        {

            get
            {
                return (ImageTypeBiz)List[intIndex];
            }
        }
        public void Add(ImageTypeBiz objBiz)
        {
            List.Add(objBiz);

        }
        public ImageTypeCol GetCol(string strName)
        {
            ImageTypeCol Returned = new ImageTypeCol(true);
            string[] arrStr = strName.Split('%');

            bool blIsOk = true;
            foreach (ImageTypeBiz objBiz in this)
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
        public ImageTypeCol Copy()
        {
            ImageTypeCol Returned = new ImageTypeCol(true);
            foreach (ImageTypeBiz objBiz in this)
            {
                Returned.Add(objBiz.Copy());
            }
            return Returned;

        }
        public DataTable GetTable()
        {
            DataTable Returned = new DataTable(ImageTypeDb.TableName);
            Returned.Columns.AddRange(new DataColumn[] { new DataColumn("ImageTypeID")
                ,new DataColumn("ImageTypeNameA"),new DataColumn("ImageTypeNameE")
            ,new DataColumn("ImageTypeCode") });
            DataRow objDr;
            foreach (ImageTypeBiz objBiz in this)
            {
                objDr = Returned.NewRow();
                objDr["ImageTypeID"] = objBiz.ID;
                objDr["ImageTypeNameA"] = objBiz.NameA;
                objDr["ImageTypeNameE"] = objBiz.NameE;
                objDr["ImageTypeCode"] = objBiz.Code;


                Returned.Rows.Add(objDr);
            }
            return Returned;
        }
    }
}
