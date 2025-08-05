using SharpVision.SystemBase;

using System.Data;


namespace AlgorithmatENM.ERP.ERPDataBase
{

    public class MachineDb
    {

        #region Constructor
        public MachineDb()
        {
        }
        public MachineDb(DataRow objDr)
        {
            SetData(objDr);
        }

        #endregion
        #region Properties
        int _ID;
        public int ID
        {
            set => _ID = value;
            get => _ID;
        }
        int _Process;
        public int Process
        {
            set => _Process = value;
            get => _Process;
        }
        int _Center;
        public int Center
        {
            set => _Center = value;
            get => _Center;
        }
        int _Flow;
        public int Flow
        {
            set => _Flow = value;
            get => _Flow;
        }
        string _Code;
        public string Code
        {
            set => _Code = value;
            get => _Code;
        }
        string _Desc;
        public string Desc
        {
            set => _Desc = value;
            get => _Desc;
        }
        string _NameA;
        public string NameA
        {
            set => _NameA = value;
            get => _NameA;
        }
        string _NameE;
        public string NameE
        {
            set => _NameE = value;
            get => _NameE;
        }
        int _ProcessID;
        public int ProcessID
        {
            set => _ProcessID = value;
            get => _ProcessID;
        }
        string _ProcessCode;
        public string ProcessCode
        {
            set => _ProcessCode = value;
            get => _ProcessCode;
        }
        string _ProcessNameA;
        public string ProcessNameA
        {
            set => _ProcessNameA = value;
            get => _ProcessNameA;
        }
        string _ProcessNameE;
        public string ProcessNameE
        {
            set => _ProcessNameE = value;
            get => _ProcessNameE;
        }
        int _CenterID;
        public int CenterID
        {
            set => _CenterID = value;
            get => _CenterID;
        }
        string _CenterCode;
        public string CenterCode
        {
            set => _CenterCode = value;
            get => _CenterCode;
        }
        string _CenterNameA;
        public string CenterNameA
        {
            set => _CenterNameA = value;
            get => _CenterNameA;
        }
        string _CenterNameE;
        public string CenterNameE
        {
            set => _CenterNameE = value;
            get => _CenterNameE;
        }
        string _CenterDesc;
        public string CenterDesc
        {
            set => _CenterDesc = value;
            get => _CenterDesc;
        }
        public string AddStr
        {
            get
            {
                string Returned = " insert into ERPMachine (MachineProcess,MachineCenter,MachineFlow,MachineCode,MachineDesc,MachineNameA,MachineNameE,UsrIns,TimIns) values (," + ID + "," + Process + "," + Center + "," + Flow + ",'" + Code + "','" + Desc + "','" + NameA + "','" + NameE + "'," + SysData.CurrentUser.ID + ",GetDate() ) ";
                return Returned;
            }
        }
        public string EditStr
        {
            get
            {
                string Returned = " update ERPMachine set MachineProcess=" + Process + "" +
           ",MachineCenter=" + Center + "" +
           ",MachineFlow=" + Flow + "" +
           ",MachineCode='" + Code + "'" +
           ",MachineDesc='" + Desc + "'" +
           ",MachineNameA='" + NameA + "'" +
           ",MachineNameE='" + NameE + "'" +
            ",UsrUpd=" + SysData.CurrentUser.ID + @",TimUpd=GetDate()  where MachineID= "+_ID;
                return Returned;
            }
        }
        public string DeleteStr
        {
            get
            {
                string Returned = " update ERPMachine set Dis = GetDate() where  ";
                return Returned;
            }
        }
        public string SearchStr
        {
            get
            {
                string Returned = @" SELECT dbo.ERPMachine.MachineID, dbo.ERPMachine.MachineProcess, dbo.ERPMachine.MachineCenter, dbo.ERPMachine.MachineFlow, dbo.ERPMachine.MachineCode, dbo.ERPMachine.MachineDesc, dbo.ERPMachine.MachineNameA, 
                  dbo.ERPMachine.MachineNameE, dbo.ERPProcess.ProcessID AS MachineProcessID, dbo.ERPProcess.ProcessCode AS MachineProcessCode, dbo.ERPProcess.ProcessNameA AS MachineProcessNameA, 
                  dbo.ERPProcess.ProcessNameE AS MachineProcessNameE, dbo.ERPWorkCenter.CenterID AS MachineCenterID, dbo.ERPWorkCenter.CenterCode AS MachineCenterCode, dbo.ERPWorkCenter.CenterNameA AS MachineCenterNameA, 
                  dbo.ERPWorkCenter.CenterNameE AS MachineCenterNameE, dbo.ERPWorkCenter.CenterDesc AS MachineCenterDesc
FROM     dbo.ERPProcess RIGHT OUTER JOIN
                  dbo.ERPMachine LEFT OUTER JOIN
                  dbo.ERPWorkCenter ON dbo.ERPMachine.MachineCenter = dbo.ERPWorkCenter.CenterID ON dbo.ERPProcess.ProcessID = dbo.ERPMachine.MachineProcess  ";
                return Returned;
            }
        }
        #endregion 
            #region Private Method
                 void SetData(DataRow objDr)
        {

            if (objDr.Table.Columns["MachineID"] != null)
                int.TryParse(objDr["MachineID"].ToString(), out _ID);

            if (objDr.Table.Columns["MachineProcess"] != null)
                int.TryParse(objDr["MachineProcess"].ToString(), out _Process);

            if (objDr.Table.Columns["MachineCenter"] != null)
                int.TryParse(objDr["MachineCenter"].ToString(), out _Center);

            if (objDr.Table.Columns["MachineFlow"] != null)
                int.TryParse(objDr["MachineFlow"].ToString(), out _Flow);

            if (objDr.Table.Columns["MachineCode"] != null)
                _Code = objDr["MachineCode"].ToString();

            if (objDr.Table.Columns["MachineDesc"] != null)
                _Desc = objDr["MachineDesc"].ToString();

            if (objDr.Table.Columns["MachineNameA"] != null)
                _NameA = objDr["MachineNameA"].ToString();

            if (objDr.Table.Columns["MachineNameE"] != null)
                _NameE = objDr["MachineNameE"].ToString();

            if (objDr.Table.Columns["MachineProcessID"] != null)
                int.TryParse(objDr["MachineProcessID"].ToString(), out _ProcessID);

            if (objDr.Table.Columns["MachineProcessCode"] != null)
                _ProcessCode = objDr["MachineProcessCode"].ToString();

            if (objDr.Table.Columns["MachineProcessNameA"] != null)
                _ProcessNameA = objDr["MachineProcessNameA"].ToString();

            if (objDr.Table.Columns["MachineProcessNameE"] != null)
                _ProcessNameE = objDr["MachineProcessNameE"].ToString();

            if (objDr.Table.Columns["MachineCenterID"] != null)
                int.TryParse(objDr["MachineCenterID"].ToString(), out _CenterID);

            if (objDr.Table.Columns["MachineCenterCode"] != null)
                _CenterCode = objDr["MachineCenterCode"].ToString();

            if (objDr.Table.Columns["MachineCenterNameA"] != null)
                _CenterNameA = objDr["MachineCenterNameA"].ToString();

            if (objDr.Table.Columns["MachineCenterNameE"] != null)
                _CenterNameE = objDr["MachineCenterNameE"].ToString();

            if (objDr.Table.Columns["MachineCenterDesc"] != null)
                _CenterDesc = objDr["MachineCenterDesc"].ToString();
        }

        #endregion
        #region Public Method 
        public void Add()
        {
            string strSql = AddStr;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public void Edit()
        {
            string strSql = EditStr;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public void Delete()
        {
            string strSql = DeleteStr;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public DataTable Search()
        {
            string strSql = SearchStr + " where ERPMachine.Dis is null ";


            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        #endregion 
    }
}
