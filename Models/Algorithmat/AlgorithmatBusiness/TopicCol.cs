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
    public class TopicCol : BaseCol
    {
        public TopicCol(bool blIsempty)
        {
            if (blIsempty)
                return;
            TopicBiz objBiz = new TopicBiz();
            objBiz.NameA = "غير محدد";
            objBiz.NameE = "Not Specified";
            Add(objBiz);
            TopicDb objDb = new TopicDb();

            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
            {
                Add(new TopicBiz(objDr));
            }
        }
        public TopicCol()
        {
            TopicDb objDb = new TopicDb();
            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
            {
                Add(new TopicBiz(objDr));
            }
        }

        public TopicBiz this[int intIndex]
        {

            get
            {
                return (TopicBiz)List[intIndex];
            }
        }
        public void Add(TopicBiz objBiz)
        {
            List.Add(objBiz);

        }
        public TopicCol GetCol(string strName)
        {
            TopicCol Returned = new TopicCol(true);
            string[] arrStr = strName.Split('%');

            bool blIsOk = true;
            foreach (TopicBiz objBiz in this)
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
        public TopicCol Copy()
        {
            TopicCol Returned = new TopicCol(true);
            foreach (TopicBiz objBiz in this)
            {
                Returned.Add(objBiz.Copy());
            }
            return Returned;

        }
        public DataTable GetTable()
        {
            DataTable Returned = new DataTable(TopicDb.TableName);
            Returned.Columns.AddRange(new DataColumn[] { new DataColumn("TopicID")
                ,new DataColumn("TopicNameA"),new DataColumn("TopicNameE")
            ,new DataColumn("TopicCode") });
            DataRow objDr;
            foreach (TopicBiz objBiz in this)
            {
                objDr = Returned.NewRow();
                objDr["TopicID"] = objBiz.ID;
                objDr["TopicNameA"] = objBiz.NameA;
                objDr["TopicNameE"] = objBiz.NameE;
                objDr["TopicCode"] = objBiz.Code;


                Returned.Rows.Add(objDr);
            }
            return Returned;
        }

    }
}
