using AlgorithmatENM.ERP.ERPDataBase;
using SharpVision.SystemBase;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
namespace AlgorithmatENM.ERP.ERPBusiness
{
    public class ProcessCol:CollectionBase
    {

        #region Constructor
        public ProcessCol()
        {

        }
        public ProcessCol(bool blIsEmbty)
        {
            if (blIsEmbty)
                return;
            ProcessBiz objBiz = new ProcessBiz();
            objBiz.ID = 0;
            objBiz.NameA = "غير محدد";
            objBiz.NameE = "Not Specified";
            Add(objBiz);

            ProcessDb objDb = new ProcessDb();

            DataTable dtTemp = objDb.Search();


            foreach (DataRow objDR in dtTemp.Rows)
            {
                objBiz = new ProcessBiz(objDR);
                Add(objBiz);
            }
        }

        #endregion
        #region Private Data

        #endregion
        #region Properties
        public ProcessBiz this[int intIndex]
        {
            get
            {
                return (ProcessBiz)this.List[intIndex];
            }
        }
        #endregion 
            #region Private Method
                
                #endregion 
                #region Public Method 
                   public void Add(ProcessBiz objBiz)
        {
            List.Add(objBiz);
        }
        public ProcessCol GetCol(string strTemp)
        {
            ProcessCol Returned = new ProcessCol(true);
            foreach (ProcessBiz objBiz in this)
            {
                if (objBiz.NameA.CheckStr(strTemp))
                    Returned.Add(objBiz);
            }
            return Returned;
        }
        public DataTable GetTable()
        {
            DataTable Returned = new DataTable();
            Returned.Columns.AddRange(new DataColumn[] { new DataColumn("ProcessID"), new DataColumn("ProcessCode"), new DataColumn("ProcessNameA"), new DataColumn("ProcessNameE") });
            DataRow objDr;
            foreach (ProcessBiz objBiz in this)
            {
                objDr = Returned.NewRow();
                objDr["ProcessID"] = objBiz.ID;
                objDr["ProcessCode"] = objBiz.Code;
                objDr["ProcessNameA"] = objBiz.NameA;
                objDr["ProcessNameE"] = objBiz.NameE;
                Returned.Rows.Add(objDr);
            }
            return Returned;
        }

        #endregion
    }
}
