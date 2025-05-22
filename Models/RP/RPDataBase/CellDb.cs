using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Threading;
using SharpVision.SystemBase;
using SharpVision.Base.BaseDataBase;
using SharpVision.COMMON.COMMONDataBase;
namespace SharpVision.RP.RPDataBase
{
    public class CellDb : BaseSelfRelatedDb
    {
        #region Private Data
        protected string _AlterName;
        protected string _Desc;
        protected int _Order;
        protected CellTypeDb _TypeDb;
        protected int _TypeID;
        protected double _ParentCostPerc;
        protected DateTime _WorkStartDate;
        protected bool _IsEstimatedDeliver;
        protected DateTime _EstimatedDeliverDate;
        int _CostCenterID;
        string _CostCenterCode;
        string _CostCenterName;
        
        bool _IsDelivered;
        protected DateTime _DeliverDate;
        protected bool _IsVirtual;
        protected double _Survey;
        int _Layout;
        int _Logo;
        int _Icon;
        int _GLAccount;
        string _GLAccountCode;
        string _GLAccountName;
        int _TowerUnitNo;
        protected int _Level;
        int _NodeNo;
        string _IDsStr;
        DataTable _CellTableSearch;
        DataTable _Characteristic;
        DataTable _KeyInstant;

        string _CharcteristicIDs;
        static DataTable _CellTable;
        static object _CellCriticalSec = new object();

        
        #region Private Data for search
        byte _VirtualSearch ;// 0 not specified
                                         // isvirtual = 0
                                         // isvirtual =1
        DateTime _StartDate;
        DateTime _EndDate;
        string _NameALike;
        string _NameELike;
        string _AlterNameLike;
        bool _AllProcesses;
        bool _OnlyFamilies;
        bool _NoChildren;
        bool _OnlyType;
        bool _TableChanged;
        #endregion
        static int _CachCellID;
        
        static string _CachCellIDs;
        static int _CachTypeID;
        DataTable _CostCenterTable;
        #endregion
        #region Constructors
        public CellDb()
        {
            _TypeDb = new CellTypeDb();
        }

        public CellDb(int intID)
        {
            _ID = intID;
            DataRow[] arrDR = CellTable.Select("CellID=" + _ID);
            if (arrDR.Length <= 0)
                return;
            DataRow objDR = arrDR[0];
            SetData(objDR);
        }
        public CellDb(DataRow objDR)
        {
            //_CellDb = DR;

            SetData(objDR);
        }
        public CellDb(int intID, string strName)
        {
            _ID = intID;
            _NameA = strName;
            _TypeDb = new CellTypeDb();
        }


        #endregion
        #region Public Properties
        public string ALterName
        {
            set
            {
                _AlterName = value;
            }
            get
            {
                return _AlterName;
            }
        }
        public string Desc
        {
            set
            {
                _Desc = value;
            }
            get
            {
                return _Desc;
            }
        }
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
        public int Layout
        {
            set
            {
                _Layout = value;
            }
            get
            {
                return _Layout;
            }
        }
        public int Logo
        {
            set
            {
                _Logo = value;
            }
            get
            {
                return _Logo;
            }
        }
        public int Icon
        {
            set
            {
                _Icon = value;
            }
            get
            {
                return _Icon;
            }
        }
        public int GLAccount
        {
            set
            {
                _GLAccount = value;
            }
            get
            {
                return _GLAccount;
            }
        }
        public string GLAccountCode
        {
            get
            {
                return _GLAccountCode;
            }
        }
        public string GLAccountName
        {
            get
            {
                return _GLAccountName;
            }
        }
        public CellTypeDb CellTypeDb
        {
            set
            {
                _TypeDb = value;
            }
            get
            {
                return _TypeDb;
            }
 
        }
        public int TypeID
        {
            set
            {
                _TypeID = value;
            }
            get
            {
                return _TypeID;
            }

        }
        public double ParentCostPerc
        {
            set
            {
                _ParentCostPerc = value;
            }
            get
            {
                return _ParentCostPerc;
            }
        }
        public DataTable Characteristic
        {
            set
            {
                _Characteristic = value;
            }
            get 
            {
                return _Characteristic;
            }
        }
        public int Level
        {
            set
            {
                _Level = value;
            }
            get 
            {
                return _Level;
            }
        }
        public DateTime WorkStartDate
        {
            set
            {
                _WorkStartDate = value;
            }
            get
            {
                return _WorkStartDate;
            }
        }
        public bool IsEstimatedDeliver
        {
            set
            {
                _IsEstimatedDeliver = value;
            }
            get
            {
                return _IsEstimatedDeliver;
            }
        }
        public DateTime EstimatedDeliverDate
        {
            set
            {
                _EstimatedDeliverDate = value;
            }
            get
            {
                return _EstimatedDeliverDate;
            }
        }
        public bool IsDelivered
        {
            set
            {
                _IsDelivered = value;
            }
            get
            {
                return _IsDelivered;
            }
        }
        public DateTime DeliverDate
        {
            set
            {
                _DeliverDate = value;
            }
            get
            {
                return _DeliverDate;
            }
        }
        
        public double Survey
        {
            set
            {
                _Survey = value;
            }
            get
            {
                return _Survey;
            }
        }
        public bool IsVirtual
        {
            set
            {
                _IsVirtual = value;
            }
            get
            {
                return _IsVirtual;
            }
        }
        public static int CachCellID
        {
            set
            {
                _CachCellID = value;
            }
            get
            {
                return _CachCellID;
            }
        }
        public static string CachCellIDs
        {
            set
            {
                _CachCellIDs = value;
            }
            get
            {
                return _CachCellIDs;
            }
        }
        public static int CachTypeID
        {
            set
            {
                _CachTypeID = value;
            }
            get
            {
                return  _CachTypeID;
            }
        }
        public DataTable CostCenterTable
        {
            set
            {
                _CostCenterTable = value;
            }
        }
        #region Set Properties for Search
        public DateTime StartDate
        {
            set
            {
                _StartDate = value;
            }
        }
        public DateTime EndDate
        {
            set
            {
                _EndDate = value;
            }
        }
        public string CharcteristicIDs
        {
            set
            {
                _CharcteristicIDs = value;
            }
        }
        public byte VirtualSearch
        {
            set
            {
                _VirtualSearch = value;
            }
        }
        public string NameLike
        {
            set
            {
                if(SysData.Language == 0)
                 _NameALike = value;
                else
                    _NameELike = value;
            }
        }
        public string AlterNameLike
        {
            set
            {
                _AlterNameLike = value;
            }
        }
        public DataTable CellTableSearch
        {
            set
            {
                _CellTableSearch = value;
            }
        }
       
        public bool AllProcesses
        {
            set
            {
                _AllProcesses = value;
            }
        }
        public bool OnlyFamilies
        {
            set
            {
                _OnlyFamilies = value;
            }
        }
        public bool NoChildren
        {
            set
            {
                _NoChildren = value;
            }
        }
        public bool OnlyType
        {
            set
            {
                _OnlyType = value;
            }
        }
        public string IDsStr
        {
            set
            {
                _IDsStr = value;
            }
        }
     #endregion
        #region GetOnlyProperty
        public static DataTable CellTable
        {
            set
            {
                _CellTable = value;
            }
            get
            {
                Monitor.Enter(_CellCriticalSec);
                if (_CellTable == null)
                {
                    
                    CellDb objCellDb = new CellDb();
                    _CellTable = objCellDb.Search();
                    _CellTable.PrimaryKey = new DataColumn[] { _CellTable.Columns["CellID"] };
                    string strImageIDs = "";
                    DataRow[] arrDr = _CellTable.Select("CellIcon <>0");
                    foreach (DataRow objDr in arrDr)
                    {
                        if (strImageIDs != "")
                            strImageIDs += ",";
                        strImageIDs += objDr["CellIcon"].ToString();
                    }
                    arrDr = _CellTable.Select("CellLayOut<>0");
                    foreach (DataRow objDr in arrDr)
                    {
                        if (strImageIDs != "")
                            strImageIDs += ",";
                        strImageIDs += objDr["CellLayout"].ToString();
                    }
                    arrDr = _CellTable.Select("CellLogo<>0");
                    foreach (DataRow objDr in arrDr)
                    {
                        if (strImageIDs != "")
                            strImageIDs += ",";
                        strImageIDs += objDr["CellLogo"].ToString();
                    }
                    ImageDb.ImageIDs = strImageIDs;
                    ImageDb.CachCellImageTable = null;
                    
                }
                Monitor.Exit(_CellCriticalSec);
                return _CellTable;
            }
        }
        public int TowerUnitNo
        {
            get
            {
                return _TowerUnitNo;
            }
        }
        public int CostCenterID
        {
            get
            {
                return _CostCenterID;
            }
        }
        public string CostCenterCode
        {
            get
            {
                return _CostCenterCode;
            }
        }
        public string CostCenterName
        {
            get
            {
                return _CostCenterName;
            }
        }
        public static string SearchStr
        {
            get
            {
                string strTowerUnit = "SELECT  dbo.RPCell.CellID AS TowerID, COUNT(DISTINCT dbo.CRMUnit.UnitID) AS TowerUnitNo "+
                      " FROM         dbo.RPCell INNER JOIN "+
                      " dbo.CRMUnit INNER JOIN "+
                      " dbo.CRMUnitCell ON dbo.CRMUnit.UnitID = dbo.CRMUnitCell.UnitID INNER JOIN "+
                      " dbo.RPCell AS RPCell_1 ON dbo.CRMUnitCell.CellID = RPCell_1.CellID ON dbo.RPCell.CellID = RPCell_1.CellParentID "+
                      " GROUP BY dbo.RPCell.CellID ";
                string strCostCenter = "SELECT  CostCenterID AS CellCostCenterID, CostCenterCode AS CellCostCenterCode, CostCenterNameA AS CellCostCenterName " +
                     " FROM  dbo.GLCostCenter ";
                string strAccount = "SELECT  dbo.GLAccount.AccountID AS CellAccountID, dbo.GLAccount.AccountCode AS CellAccountCode, dbo.GLAccount.AccountNameA AS CellAccountName "+
                    " FROM  dbo.GLAccount ";
                string Returned = "SELECT  dbo.RPCell.CellID, dbo.RPCell.CellNameA, dbo.RPCell.CellNameE,RPCell.CellAlterName," +
                            " dbo.RPCell.CellDesc, dbo.RPCell.CellParentID, dbo.RPCell.CellFamilyID," +
                            "dbo.RPCell.CellType,RPCell.CellParentCostPerc,CellWorkStartDate, "+
                            " CellEstimatedDeliverDate, CellDeliverDate, CellIsVirtual, CellSurvey" +
                            ",RPCell.CellOrder,CellLayout,CellLogo,CellIcon,CellGLAccount,dbo.RPCell.Dis," +
                            "0 as CellLevel,0 as CellExpanded,RPCellType.CellTypeOrder  " +
                            " ,TowerTable.TowerUnitNo,CostCenterTable.*,AccountTable.* "+
                            " FROM  dbo.RPCell inner join RPCellType on RPCellType.CellTypeID = RPcell.CellType "+
                            " left outer join (" + strTowerUnit + ") As TowerTable "+
                            " on RPCell.CellID = TowerTable.TowerID  "+
                             " left outer join (" + strCostCenter + ") CostCenterTable " +
                            "  on RPCell.CellGLCostCenter =  CostCenterTable.CellCostCenterID "+
                            " left outer join (" + strAccount + ") as AccountTable  "+
                            " on  RPCell.CellGLAccount = AccountTable.CellAccountID  ";
                return Returned;
            }
        }
      
        #endregion

        #endregion
        #region Private Methodsda
        void SetData(DataRow objDR)
        {
            _ID = int.Parse(objDR["CellID"].ToString());
            _NameA = objDR["CellNameA"].ToString();
            _NameE = objDR["CellNameE"].ToString();
            _Order = int.Parse(objDR["CellOrder"].ToString());
            _Desc = objDR["CellDesc"].ToString();
            _ParentID = int.Parse(objDR["CellParentID"].ToString());
            _FamilyID = int.Parse(objDR["CellFamilyID"].ToString());
            _TypeID = int.Parse(objDR["CellType"].ToString());
            _ParentCostPerc = double.Parse(objDR["CellParentCostPerc"].ToString());
            _Level = int.Parse(objDR["CellLevel"].ToString());
            _Layout = int.Parse(objDR["CellLayout"].ToString());
            _Icon = int.Parse(objDR["CellIcon"].ToString());
            _Logo = int.Parse(objDR["CellLogo"].ToString());
            _GLAccount = int.Parse(objDR["CellGLAccount"].ToString());
           
            try
            {
                _AlterName = objDR["CellAlterName"].ToString();
            }
            catch
            {
                _AlterName = "";
            }
            if(objDR["CellWorkStartDate"].ToString()!= "")
               _WorkStartDate = DateTime.Parse(objDR["CellWorkStartDate"].ToString());
           if (objDR["CellEstimatedDeliverDate"].ToString() != "")
           {
               _IsEstimatedDeliver = true;
               _EstimatedDeliverDate = DateTime.Parse(objDR["CellEstimatedDeliverDate"].ToString());
           }
           else
               _IsEstimatedDeliver = false;
        if (objDR["CellDeliverDate"].ToString() != "")
        {
            _IsDelivered = true;
            _DeliverDate = DateTime.Parse(objDR["CellDeliverDate"].ToString());
        }
        else
            _IsDelivered = false;
        _IsVirtual = bool.Parse(objDR["CellIsVirtual"].ToString());
        _Survey = double.Parse(objDR["CellSurvey"].ToString());
        if (objDR["TowerUnitNo"].ToString() != "")
            _TowerUnitNo = int.Parse(objDR["TowerUnitNo"].ToString());
        if (objDR.Table.Columns["CellCostCenterID"] != null && objDR["CellCostCenterID"].ToString() != "")
            _CostCenterID = int.Parse(objDR["CellCostCenterID"].ToString());
        if (objDR.Table.Columns["CellCostCenterCode"] != null)
            _CostCenterCode = objDR["CellCostCenterCode"].ToString();
        if (objDR.Table.Columns["CellCostCenterName"] != null)
            _CostCenterName = objDR["CellCostCenterName"].ToString();
        }
        /// <summary>
        /// this function sets the related childrren ids of cell
        /// </summary>
        /// <param name="strParentID"></param>
        /// presents the the cell for which you need to get children
        /// <param name="dtTemp"></param>
        /// presents the whole table from which u get the related cell
        /// <param name="strIDs"></param>
        /// presents the returned related cell IDs 
        void SetRelatedCells(string strParentID,DataTable dtTemp, ref string strIDs)
        {
            if (strParentID == "")
                return;
            DataRow[] arrDR = dtTemp.Select("CellID <> CellParentID and CellParentID in (" + strParentID + ") ");
            string strTempParent = "";
            foreach (DataRow objDR in arrDR)
            {
                if (strIDs != "")
                    strIDs = strIDs + ",";
                if (strTempParent != "")
                    strTempParent += ",";
                strTempParent += objDR["CellID"].ToString();
                strIDs = strIDs + objDR["CellID"].ToString();
                
            }
            SetRelatedCells(strTempParent, dtTemp, ref strIDs);

        }
        DataTable GetCell(DataTable dtCell)
        {
            _TableChanged = false;
            double dblStartDate = _StartDate.ToOADate() - 2;
            double dblEndDate = _EndDate.ToOADate() - 2;
           
            string strWhere = "Dis is null";
            if (_ID != 0)
                strWhere = strWhere + " and CellID=" + _ID;
            else
            {
                if (_FamilyID != 0)
                {
                    strWhere = strWhere + " and CellFamilyID =" + _FamilyID;
                }
                if (_OnlyFamilies)
                    strWhere = strWhere + " and CellID = CellParentID ";
                else
                {
                    if (_TypeID != 0)
                    {
                        string strTempID = "";
                        string strTempWhere = strWhere;
                        if (_AlterNameLike != null && _AlterNameLike != "")
                        {
                            _TableChanged = true;
                            strTempWhere = strWhere + " and (CellNameA like '%" + _NameALike + "%' or CellAlterName like '%" + _NameALike + "%') ";
                        }
                        else
                        {
                            if (_NameALike != null && _NameALike != "")
                            {
                                _TableChanged = true;
                                strTempWhere = strTempWhere + " and (CellNameA like '%" + _NameALike + "%' or CellAlterName like '%"+ _NameALike +"%') ";

                            }
                        }
                        DataRow[] arrTemp = dtCell.Select(strTempWhere, "");
                        string strCellID = "";
                        foreach (DataRow objDr in arrTemp)
                        {
                            if (strTempID != "")
                                strTempID = strTempID + ",";
                            strTempID = strTempID + objDr["CellID"];
                            if (strCellID != "")
                                strCellID += ",";
                            strCellID += objDr["CellID"].ToString();
                           
                        }
                        if (!_OnlyType)
                            SetRelatedCells(strCellID, dtCell, ref strTempID);


                        strWhere = strWhere + " and (CellType=" + _TypeID + ")";

                        if (strTempID != "")
                        {
                            _TableChanged = true;
                            strWhere = strWhere + " and CellID in (" + strTempID + ") ";
                        }
                        if (_VirtualSearch == 1)
                            strWhere += " and CellIsVirtual=0 ";
                        else if (_VirtualSearch == 2)
                            strWhere += " and CellIsVirtual=1 "; 
                    }
                    else
                    {
                        if (_AlterNameLike != null && _AlterNameLike != "")
                        {
                            _TableChanged = true;
                            strWhere = strWhere + " and (CellNameA like '%" + _NameALike + "%' or CellAlterName like '%" + _NameALike + "%') ";
                        }
                        else
                        {
                            if (_NameALike != null && _NameALike != "")
                            {
                                _TableChanged = true;
                                strWhere = strWhere + " and (CellNameA like '%" + _NameALike + "%' or CellAlterName like '%" + _NameALike + "%') ";
                            }
                            if (_NameELike != null && _NameELike != "")
                            {
                                _TableChanged = true;
                                strWhere = strWhere + " and CellNameE like '%" + _NameELike + "%' ";
                            }
                        }
                        if (_VirtualSearch == 1)
                            strWhere += " and CellIsVirtual=0 ";
                        else if (_VirtualSearch == 2)
                            strWhere += " and CellIsVirtual=1 "; 
                    }
                }
            }
            DataRow [] arrDr = dtCell.Select(strWhere, "");
            DataTable dtReturned = new DataTable();
            foreach (DataColumn dcTemp in dtCell.Columns)
            {
                dtReturned.Columns.Add(new DataColumn(dcTemp.ColumnName, dcTemp.DataType));
            }
            foreach (DataRow objDr in arrDr)
            {
                dtReturned.ImportRow(objDr);
            }


            return dtReturned;

        }
      
        void SetRecursiveTable(string strParentCellID,ref DataTable dtDist,ref DataTable dtSource)
        {
            if (strParentCellID == "")
                return;
            DataRow[] arrDr = dtSource.Select("CellID in(" + strParentCellID +")");
            string strTemp;
            string strParentID = "";
           foreach (DataRow objDr in arrDr)
            {
              
             
                _NodeNo++;
           
                if (objDr["CellID"].ToString() != objDr["CellParentID"].ToString() )
                {
                    strTemp = objDr["CellParentID"].ToString();
                    if (strParentID != "")
                        strParentID = strParentID + ",";
                    strParentID = strParentID + strTemp;
                    
                 
                   

                }
               
                 
                    dtDist.ImportRow(objDr);
                    dtSource.Rows.Remove(objDr);
 
                
            }
            SetRecursiveTable(strParentID, ref dtDist, ref dtSource);
        }
        void SetRecursiveChildernTable(string strParentCellID, ref DataTable dtDist,ref DataTable dtSource)
        {
            if (_NoChildren || _OnlyFamilies)
                return;
            string strFilter = "CellID<>CellParentID and CellParentID in (" + strParentCellID + ") ";
            if (_VirtualSearch == 1)
                strFilter += " and CellIsVirtual=0 ";
            DataRow[] arrDr = dtSource.Select(strFilter,"");
            string strParentID = "";
            if (arrDr.Length > 0)
            {
                foreach (DataRow objDr in arrDr)
                {

                    string strTemp = objDr["CellID"].ToString();
                    if (strParentID != "")
                        strParentID = strParentID + ",";
                    strParentID = strParentID + strTemp;
                    
                
                    if (!_OnlyType || _TypeID == 0 || _TypeID == int.Parse(objDr["CellType"].ToString()) && ( _Order == 0 || _Order == int.Parse(objDr["CellOrder"].ToString()) ))
                    {
                        dtDist.ImportRow(objDr);
                        _NodeNo++;
                    }
                   
                    dtSource.Rows.Remove(objDr);
                   
                    
                 }
                 SetRecursiveChildernTable(strParentID, ref dtDist, ref dtSource);
            }
        }
        
        void EditCellCach()
        {
            //if (_CellTable != null)
            //{
                CellDb objCellDb = new CellDb();
                _CellTable = objCellDb.Search();
            //}
        }
        void EditReservationAccount()
        {
            string strSql = "update   CRMReservation set ReservationGLAccount="+ _GLAccount+
                      " FROM         dbo.CRMReservation INNER JOIN "+
                      " dbo.CRMReservationUnit ON dbo.CRMReservation.ReservationID = dbo.CRMReservationUnit.ReservationID INNER JOIN "+
                      " dbo.CRMUnitCell ON dbo.CRMReservationUnit.UnitID = dbo.CRMUnitCell.UnitID "+
                      " where CRMUnitCell.CellID in(" + _IDsStr +")";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }

        #endregion
        #region Public Methods
        public override void Add()
        {
            _FamilyID = _FamilyID == 0 ? _ID : _FamilyID;
            _ParentID = _ParentID == 0 ? _ID : _ParentID;
            double dblworkerStartDate = _WorkStartDate.ToOADate() - 2;
            double dblEstimatedDelivarDate = SysUtility.Approximate( _EstimatedDeliverDate.ToOADate() - 2,1,ApproximateType.Down);
            string strEstimatedDate = _IsEstimatedDeliver ?( _EstimatedDeliverDate.ToOADate()-2).ToString() : "null";
            double dblDelivarDate = SysUtility.Approximate(  _DeliverDate.ToOADate() - 2,1,ApproximateType.Down);
            string strDeliverDate = _IsDelivered ? dblDelivarDate.ToString() : "null";
            int IsVirtual = _IsVirtual == true ? 1 : 0;

            string strSql = "insert into RPCell (CellNameA,CellNameE,CellAlterName, CellDesc, CellParentID, CellFamilyID,CellType,CellParentCostPerc,CellWorkStartDate, CellEstimatedDeliverDate, CellDeliverDate, CellIsVirtual, CellSurvey,CellOrder,CellGLAccount,UsrIns, TimIns) values(";
            strSql = strSql + "'" + _NameA + "','" + _NameE + "','" + _AlterName + "','" + _Desc + "'," + _ParentID + "," + _FamilyID + "," + _TypeID +
                   "," + _ParentCostPerc + "," + dblworkerStartDate + "," + strEstimatedDate + "," + strDeliverDate + "," + IsVirtual + ","+_Survey+"," + _Order + ","+_GLAccount+"," + SysData.CurrentUser.ID + ",Getdate())";
            _ID = SysData.SharpVisionBaseDb.InsertIdentityTable(strSql);
            if (_ParentID == 0)
            {
               
                strSql = "update RPCell set CellParentID = " + _ID + ", CellFamilyID =" + _ID;
                strSql = strSql + " where CellID = " + _ID;
                SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
            }
            
            EditCellCach();



        }
        public override void Edit()
        {
            _FamilyID = _FamilyID == 0 ? _ID : _FamilyID;
            _ParentID = _ParentID == 0 ? _ID : _ParentID;
            double dblworkerStartDate = _WorkStartDate.ToOADate() - 2;
            double dblEstimatedDelivarDate = SysUtility.Approximate( _EstimatedDeliverDate.ToOADate() - 2,1,ApproximateType.Down);
            double dblDelivarDate = SysUtility.Approximate(_DeliverDate.ToOADate() - 2,1,ApproximateType.Down);
            string strDeliverDate = _IsDelivered ? dblDelivarDate.ToString() : "null";
            string strEstimatedDate = _IsEstimatedDeliver ? dblEstimatedDelivarDate.ToString() : "null";
            int IsVirtual = _IsVirtual == true ? 1 : 0;

            string strSql = "update  RPCell ";
            strSql = strSql + " set CellNameA ='" + _NameA + "'";
            strSql = strSql + ",CellNameE ='" + _NameE + "'";
            strSql = strSql + ",CellAlterName ='" + _AlterName + "'";
            strSql = strSql + " ,CellDesc ='" + _Desc + "'";
            strSql = strSql + ",CellParentID =" + _ParentID;
            strSql = strSql + ",CellFamilyID=" + _FamilyID;
            strSql = strSql + ",CellType=" + _TypeID;
            strSql = strSql + ",CellParentCostPerc=" + _ParentCostPerc;
            strSql = strSql + ",CellWorkStartDate = " + dblworkerStartDate;
            strSql = strSql + ",CellEstimatedDeliverDate = " + strEstimatedDate;
            strSql = strSql + ",CellDeliverDate = " + strDeliverDate;
            strSql = strSql + ",CellIsVirtual = " + IsVirtual;
            strSql = strSql + ",CellSurvey = " + _Survey;
            strSql = strSql + ",CellOrder=" + _Order;
            //strSql = strSql + " ,CellGLAccount= " + _GLAccount;
            strSql = strSql + ",TimUpd = GetDate()";
            strSql = strSql + ",UsrUpd =" + SysData.CurrentUser.ID;
            strSql = strSql + " where CellID = " + _ID;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
            strSql = "select * from RPCell where CellFamilyID in " + 
                " (select CellFamilyID from RPCell where CellParentID=" + _ID + " and CellID <> " + _ID + " and CellFamilyID <> " + _FamilyID  + ")";
            DataTable dtTemp = SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
          
            if (dtTemp.Rows.Count == 0)
                return;
            string strIDs = "";
            SetRelatedCells(_ID.ToString(), dtTemp, ref strIDs);
            strSql = "Update RPCell set CellFamilyID = " + _FamilyID + " where CellID in ( " + strIDs + ")";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
            EditCellCach();

            
        }
        public  void EditDeliverDate()
        {
            if (_ID == 0 && (_IDsStr == null || _IDsStr == ""))
                return;

            double dblDeliveryDate = 0;
            dblDeliveryDate = SysUtility.Approximate( _DeliverDate.ToOADate() - 2,1,ApproximateType.Down);
            string strDeliverDate =!_IsDelivered ? "null" : dblDeliveryDate.ToString();
         

            string strSql = "update  RPCell ";
            strSql = strSql + " set CellDeliverDate = " + strDeliverDate ;
                     strSql = strSql + ",TimUpd = GetDate()";
            strSql = strSql + ",UsrUpd =" + SysData.CurrentUser.ID;
            if(_ID!= 0)
            strSql = strSql + " where CellID = " + _ID;
            else
            strSql = strSql + " where CellID  in (" + _IDsStr  + ") ";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public void EditEstimatedDeliverDate()
        {
            if (_ID == 0 && (_IDsStr == null || _IDsStr == ""))
                return;

            double dblDeliveryDate = 0;
            dblDeliveryDate = SysUtility.Approximate(_EstimatedDeliverDate.ToOADate() - 2, 1, ApproximateType.Down);
            string strEstimatedDeliverDate = !_IsEstimatedDeliver ? "null" : dblDeliveryDate.ToString();


            string strSql = "update  RPCell ";
            strSql = strSql + " set CellEstimatedDeliverDate = " + strEstimatedDeliverDate;
            strSql = strSql + ",TimUpd = GetDate()";
            strSql = strSql + ",UsrUpd =" + SysData.CurrentUser.ID;
            if (_ID != 0)
                strSql = strSql + " where CellID = " + _ID;
            else
                strSql = strSql + " where CellID  in (" + _IDsStr + ") ";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public void EditAccount()
        {
            if (_IDsStr == null || _IDsStr == "")
                return;
            string strSql = "update RPCell set CellGLAccount=" + _GLAccount + " where CellID = " + _ID;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
            EditReservationAccount();

        }
        public void EditLayout()
        {
            string strSql = "update RPCell set CellLayout=" + _Layout + " where CellID = " + _ID;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public void EditParentCostPerc()
        {
            string strSql = "update  RPCell set CellParentCostPerc =" + _ParentCostPerc +
                            " where CellID="+ _ID;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
            EditCellCach();
        }

        public override void Delete()
        {
            string strSql = "update  RPCell  set Dis= GetDate() where CellID=" + _ID;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
           
        }

        public override DataTable Search()
        {
            string strSql = SearchStr + " WHERE (1=1)";
            if (_ID != 0)
                strSql = strSql + " and RPCell.CellID = " + _ID.ToString();
            if (_NameA != "" && _NameA != null)
                strSql = strSql + " and RPCell.CellNameA = '" + _NameA + "'  ";
            if (_ParentID != 0)
                strSql = strSql + "  and RPCell.CellParentID = " + _ParentID;
            if (_FamilyID != 0)
                strSql = strSql + " and RPCell.CellFamilyID = " + _FamilyID;
            if (_TypeID != 0)
                strSql = strSql + " and RPCell.CellType=" + _TypeID;
            if (_NameALike != null && _NameALike != "")
                strSql = strSql + " and RPCell.CellNameA like '%" + _NameALike + "%' ";

            if (_NameELike != null && _NameELike != "")
                strSql = strSql + " and RPCell.CellNameE like '%" + _NameELike + "%' ";
            if (_AlterNameLike != null && _AlterNameLike != "")
            {
                strSql = strSql + " and RPCell.CellAlterName like '%"+ _AlterNameLike +"% ";
            }
            if (_GLAccount != 0)
                strSql = strSql + " and RPCell.CellGLAccount = " + _GLAccount + " ";
            
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql,"Cell");


        }
        public DataTable GetChildrenTable()
        {
            DataTable dtReturned = new DataTable();
            foreach (DataColumn dcTemp in CellTable.Columns)
            {

                dtReturned.Columns.Add(dcTemp.ColumnName, dcTemp.DataType);
            }
            if (_ID != -1)
            {
                DataTable dtSrc = CellTable.Copy();
                DataRow[] arrDr = dtSrc.Select("CellID=" + _ID.ToString());
                string strCellIDs = "";
                if (arrDr.Length != 0)
                {
                  
                  
                    if (!_OnlyType || _TypeID == 0 || _TypeID == int.Parse(arrDr[0]["CellType"].ToString()))
                        dtReturned.ImportRow(arrDr[0]);
                    if (strCellIDs != "")
                        strCellIDs = strCellIDs + ",";
                    strCellIDs += arrDr[0]["CellID"].ToString();

                }
                SetRecursiveChildernTable(strCellIDs, ref dtReturned, ref dtSrc);
            }
         
            return dtReturned;
 
        }

        #region Native GetAllCell
        public DataTable GetAllCell()
        {

            DataTable dtTempCell;
            if (_ParentID == 0 || _CellTableSearch == null)
            {
                dtTempCell = CellTable;
            }
            else
            {
                dtTempCell = _CellTableSearch;

            }
            //DataTable dtAllCell = 
            DataTable dtAllCell  = GetCell(dtTempCell);


            DataTable dtReturned = new DataTable();
            if (dtAllCell.Rows.Count == 0)
                return dtReturned;


            foreach (DataColumn dcTemp in dtTempCell.Columns)
            {
                dtReturned.Columns.Add(new DataColumn(dcTemp.ColumnName, dcTemp.DataType));
            }

            string strCellID;
            DataTable dtSrc = CellTable.Copy();


            if (_TableChanged)
            {
                strCellID = "";
                foreach (DataRow drTemp in dtAllCell.Rows)
                {
                    if (strCellID != "")
                        strCellID += ",";
                    strCellID += drTemp["CellID"].ToString();
                 

                }
                SetRecursiveTable(strCellID, ref dtReturned, ref dtSrc);
                //int intLevel = int.Parse(drTemp["CellLevel"].ToString());
                SetRecursiveChildernTable(strCellID, ref dtReturned, ref dtSrc);
            }
            else
            {
                if (_ParentID != 0)
                {

                    SetRecursiveTable(_ParentID.ToString(), ref dtAllCell, ref dtSrc);
                    dtReturned = dtAllCell;


                }
                else
                    dtReturned = dtAllCell;
                
            }
            
            return dtReturned;

        }
        #endregion
      
        public void JoinCharacteristic()
        {
            string strSql = "delete from RPCellCharacteristic where CellID = " + _ID;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
            foreach (DataRow objDR in _Characteristic.Rows)
            {
                strSql = "insert into RPCellCharacteristic (CellID,CharacteristicID) Values (" + _ID + "," + objDR["CharacteristicID"].ToString() + ")";
                SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
            }
        }

        public DataTable GetCellCharacteristics()
        {
            
            string strSql = "select Char.CharacteristicID,Char.CharacteristicName from RPCharacteristic as Char,RPCellCharacteristic as CellChar where Char.CharacteristicID=CellChar.CharacteristicID and CellChar.CellID=" + _ID;
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        public DataTable GetCellProcess()
        {
            ProcessDb objTemp = new ProcessDb();
            objTemp.CellID = _ID;
            objTemp.AllProcess = _AllProcesses;
            return objTemp.Search();
        }
        public DataTable GetCategories()
        {
            return new DataTable();
            //CellCategoryDb objTemp = new CellCategoryDb();
            //objTemp.CellID = _ID;
            //return objTemp.Search();

        }
        public void EditCostCenter()
        {
            if (_CostCenterTable == null || _CostCenterTable.Rows.Count == 0)
                return;
            string[] arrStr = new string[_CostCenterTable.Rows.Count];
            int intIndex = 0;
            foreach (DataRow objDr in _CostCenterTable.Rows)
            {
                arrStr[intIndex] = "Update RPCell set  CellGLCostCenter=" + objDr["CostCenterID"].ToString() +
                    " where CellID= " + objDr["CellID"].ToString();
                intIndex++;
            }
            SysData.SharpVisionBaseDb.ExecuteNonQuery(arrStr);
        }
        #endregion
    }
}
