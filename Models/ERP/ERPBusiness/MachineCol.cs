
using System.Data;
using System.Collections;
using AlgorithmatENM.ERP.ERPDataBase;
using SharpVision.SystemBase;


namespace AlgorithmatENM.ERP.ERPBusiness
{
    public class MachineCol:CollectionBase
    {

        #region Constructor
        public MachineCol()
        {

        }
        public MachineCol(bool blIsEmbty)
        {
            if (blIsEmbty)
                return;
            MachineBiz objBiz = new MachineBiz();
            objBiz.ID = 0;
            objBiz.NameA = "غير محدد";
            objBiz.NameE = "Not Specified";
            Add(objBiz);

            MachineDb objDb = new MachineDb();

            DataTable dtTemp = objDb.Search();


            foreach (DataRow objDR in dtTemp.Rows)
            {
                objBiz = new MachineBiz(objDR);
                Add(objBiz);
            }
        }

        #endregion
        #region Private Data

        #endregion
        #region Properties
        public MachineBiz this[int intIndex]
        {
            get
            {
                return (MachineBiz)this.List[intIndex];
            }
        }
        #endregion 
            #region Private Method
                
                #endregion 
                #region Public Method 
                   public void Add(MachineBiz objBiz)
        {
            List.Add(objBiz);
        }
        public MachineCol GetCol(string strTemp)
        {
            MachineCol Returned = new MachineCol(true);
            foreach (MachineBiz objBiz in this)
            {
                if (objBiz.NameA.CheckStr(strTemp))
                    Returned.Add(objBiz);
            }
            return Returned;
        }
        public DataTable GetTable()
        {
            DataTable Returned = new DataTable();
            Returned.Columns.AddRange(new DataColumn[] { new DataColumn("MachineID"), new DataColumn("MachineProcess"), new DataColumn("MachineCenter"), new DataColumn("MachineFlow"), new DataColumn("MachineCode"), new DataColumn("MachineDesc"), new DataColumn("MachineNameA"), new DataColumn("MachineNameE"), new DataColumn("MachineProcessID"), new DataColumn("MachineProcessCode"), new DataColumn("MachineProcessNameA"), new DataColumn("MachineProcessNameE"), new DataColumn("MachineCenterID"), new DataColumn("MachineCenterCode"), new DataColumn("MachineCenterNameA"), new DataColumn("MachineCenterNameE"), new DataColumn("MachineCenterDesc") });
            DataRow objDr;
            foreach (MachineBiz objBiz in this)
            {
                objDr = Returned.NewRow();
                objDr["MachineID"] = objBiz.ID;
                objDr["MachineProcess"] = objBiz.Process;
                objDr["MachineCenter"] = objBiz.Center;
                objDr["MachineFlow"] = objBiz.Flow;
                objDr["MachineCode"] = objBiz.Code;
                objDr["MachineDesc"] = objBiz.Desc;
                objDr["MachineNameA"] = objBiz.NameA;
                objDr["MachineNameE"] = objBiz.NameE;
                objDr["MachineProcessID"] = objBiz.ProcessBiz.ID;
                objDr["MachineProcessCode"] = objBiz.ProcessBiz.Code;
                objDr["MachineProcessNameA"] = objBiz.ProcessBiz.NameA;
                objDr["MachineProcessNameE"] = objBiz.ProcessBiz.NameE;
                objDr["MachineCenterID"] = objBiz.CenterBiz.ID;
                objDr["MachineCenterCode"] = objBiz.CenterBiz.Code;
                objDr["MachineCenterNameA"] = objBiz.CenterBiz.NameA;
                objDr["MachineCenterNameE"] = objBiz.CenterBiz.NameE;
                objDr["MachineCenterDesc"] = objBiz.CenterBiz.Desc;
                Returned.Rows.Add(objDr);
            }
            return Returned;
        }
        static Hashtable _CacheMachineRefTable = new Hashtable();
        public static Hashtable CacheMachineRefTable
        {
            get {
                if(_CacheMachineRefTable == null)
                {
                    MachineCol objCol = new MachineCol(false);
                    string strRef = "";
                    foreach(MachineBiz objBiz in objCol)
                    {
                        strRef = objBiz.Code;
                        if(objBiz.ID!=0&& _CacheMachineRefTable[strRef]==null)
                            _CacheMachineRefTable.Add(strRef, objBiz);
                    }

                }
                return _CacheMachineRefTable; }
        }

        #endregion
    }
}
