using System.Data;
using AlgorithmatENM.ERP.ERPDataBase;
using System.Collections;
using System.Linq;
using SharpVision.SystemBase;
namespace AlgorithmatENM.ERP.ERPBusiness
{

    public class WorkCenterCol:CollectionBase
    {

        #region Constructor
        public WorkCenterCol()
        {

        }
        public WorkCenterCol(bool blIsEmbty)
        {
            if (blIsEmbty)
                return;
            WorkCenterBiz objBiz = new WorkCenterBiz();
            objBiz.ID = 0;
            objBiz.NameA = "غير محدد";
            objBiz.NameE = "Not Specified";
            Add(objBiz);

            WorkCenterDb objDb = new WorkCenterDb();

            DataTable dtTemp = objDb.Search();


            foreach (DataRow objDR in dtTemp.Rows)
            {
                objBiz = new WorkCenterBiz(objDR);
                Add(objBiz);
            }
        }

        #endregion
        #region Private Data

        #endregion
        #region Properties
        public WorkCenterBiz this[int intIndex]
        {
            get
            {
                return (WorkCenterBiz)this.List[intIndex];
            }
        }
        #endregion 
            #region Private Method
                
                #endregion 
                #region Public Method 
                   public void Add(WorkCenterBiz objBiz)
        {
            List.Add(objBiz);
        }
        public WorkCenterCol GetCol(string strTemp)
        {
            WorkCenterCol Returned = new WorkCenterCol(true);
            foreach (WorkCenterBiz objBiz in this)
            {
                if (objBiz.NameA.CheckStr(strTemp))
                    Returned.Add(objBiz);
            }
            return Returned;
        }
        public DataTable GetTable()
        {
            DataTable Returned = new DataTable();
            Returned.Columns.AddRange(new DataColumn[] { new DataColumn("CenterID"), new DataColumn("CenterCode"), new DataColumn("CenterNameA"), new DataColumn("CenterNameE"), new DataColumn("CenterDesc") });
            DataRow objDr;
            foreach (WorkCenterBiz objBiz in this)
            {
                objDr = Returned.NewRow();
                objDr["CenterID"] = objBiz.ID;
                objDr["CenterCode"] = objBiz.Code;
                objDr["CenterNameA"] = objBiz.NameA;
                objDr["CenterNameE"] = objBiz.NameE;
                objDr["CenterDesc"] = objBiz.Desc;
                Returned.Rows.Add(objDr);
            }
            return Returned;
        }

        #endregion
    }
}
