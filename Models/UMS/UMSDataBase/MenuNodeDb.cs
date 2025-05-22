using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
namespace SharpVision.UMS.UMSDataBase
{
    public class MenuNodeDb
    {


        #region Constructor
        public MenuNodeDb()
        {
        }
        public MenuNodeDb(DataRow objDr)
        {
            SetData(objDr);
        }

        #endregion
        #region Properties
        int _ID;
        public int ID
        {
            set
            {
                _ID = value;
            }
            get
            {
                return _ID;
            }
        }
        string _Code;
        public string Code
        {
            set
            {
                _Code = value;
            }
            get
            {
                return _Code;
            }
        }
        string _NameA;
        public string NameA
        {
            set
            {
                _NameA = value;
            }
            get
            {
                return _NameA;
            }
        }
        string _NameE;
        public string NameE
        {
            set
            {
                _NameE = value;
            }
            get
            {
                return _NameE;
            }
        }
        int _Parent;
        public int Parent
        {
            set
            {
                _Parent = value;
            }
            get
            {
                return _Parent;
            }
        }
        string _ParentNameA;
        public string ParentNameA
        {
            set
            {
                _ParentNameA = value;
            }
            get
            {
                return _ParentNameA;
            }
        }
        string _ParentNameE;
        public string ParentNameE
        {
            set
            {
                _ParentNameE = value;
            }
            get
            {
                return _ParentNameE;
            }
        }
        int _Function;
        public int Function
        {
            set
            {
                _Function = value;
            }
            get
            {
                return _Function;
            }
        }
        int _System;
        public int System
        {
            set
            {
                _System = value;
            }
            get
            {
                return _System;
            }
        }

        int _Order;
        public int Order
        {
            set
            {
                _Order = value;
            }
            get
            {
                return _Order;
            }
        }
        string _SystemName;
        public string SystemName
        {
            set { _SystemName = value; }
            get { return _SystemName; }
        }
        string _SystemDesc;
        public string SystemDesc
        {
            set { _SystemDesc = value; }
            get { return _SystemDesc; }
        }
        int _ParentSys;
        public int ParentSys
        {
            get
            {
                return _ParentSys;
            }
        }
        string _FunctionNameA;
        public string FunctionNameA
        {
            set { _FunctionNameA = value; }
            get { return _FunctionNameA; }
        }
        string _FunctionNameE;
        public string FunctionNameE
        {
            set { _FunctionNameE = value; }
            get { return _FunctionNameE; }
        }
        string _FunctionUrl;
        public string FunctionUrl
        {
            get { return _FunctionUrl; }
            set
            { _FunctionUrl = value; }
        }
        int _FunctionSysID;
        public int FunctionSysID
        {
            set { _FunctionSysID = value; }
            get { return _FunctionSysID; }
        }
        bool _IsStopped;
        public bool IsStopped
        {
            set
            {
                _IsStopped = value;
            }
            get
            {
                return _IsStopped;
            }
        }
        string _URL;
        public string URL
        {
            get => _URL;
            set => _URL = value;
        }
        bool _IsNotDisplayed;
        public bool IsNotDisplayed
        {
            get => _IsNotDisplayed;
            set => _IsNotDisplayed = value;
        }
        public string AddStr
        {
            get
            {
                if (_Parent == _ID)
                    _Parent = 0;
                string Returned = " insert into UMSSystemMenu (NodeCode,NodeNameA,NodeNameE,NodeParent,NodeFunction,NodeSystem,NodeOrder,NodeIsStopped, NodeIsNotDisplayed, NodeURL) values (" +
                    "'" + Code + "','" + NameA + "','" + NameE + "'," + Parent + "," +
                    Function + "," + System + "," + _Order + "," + (IsStopped ? 1 : 0) + "," + (IsNotDisplayed ? 1 : 0) + ",'" + URL + "') ";
                return Returned;
            }
        }
        public string EditStr
        {
            get
            {
                if (_Parent == _ID)
                    _Parent = 0;
                string Returned = " update UMSSystemMenu set NodeCode='" + Code + "'" +
           ",NodeNameA='" + NameA + "'" +
           ",NodeNameE='" + NameE + "'" +
           ",NodeParent=" + Parent + "" +
           ",NodeFunction=" + Function + "" +
           ",NodeSystem=" + System + "" +
           ",NodeOrder =" + _Order +
           ",NodeIsStopped=" + (IsStopped ? 1 : 0) + "" +
           ", NodeIsNotDisplayed=" + (IsNotDisplayed ? 1 : 0) +
           ", NodeURL='" + URL + "'" +
           "  where NodeID=" + _ID;
                return Returned;
            }
        }
        public string DeleteStr
        {
            get
            {
                string Returned = " update UMSSystemMenu set Dis = GetDate() where NodeID=" + _ID;
                return Returned;
            }
        }
        public string SearchStr
        {
            get
            {
                string strFunction = @"SELECT  FunctionID AS NodeFunctionID, FunctionNameA AS NodeFunctionNameA
,FunctionUrl as NodeFunctionUrl 
, FunctionNameE AS NodeFunctionNameE, SysID AS NodeFunctionSysID
FROM            dbo.UMSFunction ";
                string strSystem = @"SELECT  SysID AS NodeSystemID, SysName AS NodeSystemName, SysDesc AS NodeSystemDesc
FROM dbo.UMSSystem";
                string strParent = @"SELECT  NodeID AS ParentNodeID, NodeNameA AS ParentNodeNameA, NodeNameE AS ParentNodeNameE,NodeSystem ParentNodeSys 
     FROM            dbo.UMSSystemMenu";
                string Returned = @" select NodeID,NodeCode,NodeNameA,NodeNameE,NodeParent
,NodeFunction,NodeSystem,NodeOrder,NodeIsStopped, NodeIsNotDisplayed, NodeURL
,NodeParentTable.*,SystemTable.*,FunctionTable.* 
 from UMSSystemMenu  
         left outer  join (" + strParent + @") as NodeParentTable 
      on UMSSystemMenu.NodeParent = NodeParentTable.ParentNodeID 
inner join (" + strSystem + @") AS SystemTable 
ON dbo.UMSSystemMenu.NodeSystem = SystemTable.NodeSystemID 
 left outer join (" + strFunction + @") AS FunctionTable ON dbo.UMSSystemMenu.NodeFunction = FunctionTable.NodeFunctionID ";
                return Returned;
            }
        }
        #endregion
        #region Private Method
        void SetData(DataRow objDr)
        {

            if (objDr.Table.Columns["NodeID"] != null)
                int.TryParse(objDr["NodeID"].ToString(), out _ID);

            if (objDr.Table.Columns["NodeCode"] != null)
                _Code = objDr["NodeCode"].ToString();

            if (objDr.Table.Columns["NodeNameA"] != null)
                _NameA = objDr["NodeNameA"].ToString();

            if (objDr.Table.Columns["NodeNameE"] != null)
                _NameE = objDr["NodeNameE"].ToString();

            if (objDr.Table.Columns["NodeParent"] != null)
                int.TryParse(objDr["NodeParent"].ToString(), out _Parent);

            if (objDr.Table.Columns["NodeFunction"] != null)
                int.TryParse(objDr["NodeFunction"].ToString(), out _Function);

            if (objDr.Table.Columns["NodeSystem"] != null)
                int.TryParse(objDr["NodeSystem"].ToString(), out _System);

            if (objDr.Table.Columns["NodeIsStopped"] != null)
                bool.TryParse(objDr["NodeIsStopped"].ToString(), out _IsStopped);
            _ParentNameA = objDr["ParentNodeNameA"].ToString();
            _ParentNameE = objDr["ParentNodeNameE"].ToString();


            //_SystemID = objDr["NodeSystemID"].ToString();
            _SystemName = objDr["NodeSystemName"].ToString();
            _SystemDesc = objDr["NodeSystemDesc"].ToString();
            //   int.TryParse( objDr["NodeFunctionID"].ToString(),out _FunctionID);
            _FunctionNameA = objDr["NodeFunctionNameA"].ToString();
            _FunctionNameE = objDr["NodeFunctionNameE"].ToString();
            _FunctionUrl = objDr["NodeFunctionUrl"].ToString();
            int.TryParse(objDr["NodeFunctionSysID"].ToString(), out _FunctionSysID);
            int.TryParse(objDr["NodeOrder"].ToString(), out _Order);
            if (objDr.Table.Columns["ParentNodeSys"] != null)
                int.TryParse(objDr["ParentNodeSys"].ToString(), out _ParentSys);
            _URL = "";
            if (objDr.Table.Columns["NodeURL"] != null)
                _URL = objDr["NodeURL"].ToString();
            if (objDr.Table.Columns["NodeIsNotDisplayed"] != null && objDr["NodeIsNotDisplayed"].ToString() != "")
                bool.TryParse(objDr["NodeIsNotDisplayed"].ToString(), out _IsNotDisplayed);
        }
        #endregion
        #region Public Method 
        public void Add()
        {
            string strSql = AddStr;
            BaseDb.UMSBaseDb.ExecuteNonQuery(strSql);
        }
        public void Edit()
        {
            string strSql = EditStr;
            BaseDb.UMSBaseDb.ExecuteNonQuery(strSql);
        }
        public void Delete()
        {
            string strSql = DeleteStr;
            BaseDb.UMSBaseDb.ExecuteNonQuery(strSql);
        }
        public DataTable Search()
        {
            string strSql = SearchStr + " where (Dis is null) ";

            if (_System != 0)
                strSql += " and NodeSystem = " + _System;
            return BaseDb.UMSBaseDb.ReturnDatatable(strSql);
        }
        #endregion
    }
}
