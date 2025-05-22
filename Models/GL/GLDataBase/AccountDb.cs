using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.SystemBase;
using SharpVision.Base.BaseDataBase;

namespace SharpVision.GL.GLDataBase
{
    public class AccountDb : BaseSelfRelatedDb
    {
        #region Private Data
        protected string _Code;
        protected int _Level;
        protected bool _IsClosing;
        protected bool _IsSecondary;
        protected bool _IsLedger;
        protected bool _IsLeaf;
        protected bool _Direction;
        protected bool _Status;
        protected int _AccountType;
        protected double _DebitBalance;
        protected double _CreditBalance;
        protected double _DebitElementBalance;
        protected double _CreditElementBalance;
        protected string _BalanceDesc;
        protected int _DefaultCostCenter;
        protected int _ParentLevel = 3;
        protected bool _HasCostCenter;
        protected string _DefaultCostCenterCode;
        protected string _DefaultCostCenterName;
        protected string _ParentCode;
        protected string _ParentName;
        DataTable _CostCenterTable;
        #region Private Data For Search
        protected string _LikeNameA;
        protected string _LikeNameE;
        protected string _LikeCode;
        protected bool _OnlyFamily;
        int _SecondryDetermined;
        int _DirectionDetermined;
        int _StatusDetermined;
        int _LeafDetermined;
        string _IDsStr;
        DataTable _AccountTable;
        #endregion
        #endregion
        #region Public Constractors
        public AccountDb()
        { 

        }
        public AccountDb(string strCode)
        {
            _Code = strCode;
            DataTable dtTemp = Search();
            if (dtTemp.Rows.Count == 0)
            {
                _Code = "";
                return;
            }
            SetData(dtTemp.Rows[0]);

        }
        public AccountDb(int intID)
        {
            _ID = intID;
            DataTable dtTemp = Search();
            if (dtTemp.Rows.Count == 0)
            {
                _ID = 0;
                return;
            }
            SetData(dtTemp.Rows[0]);

        }
        
        public AccountDb(DataRow objDR)
        {
            SetData(objDR);
        }
       
        #endregion
        #region Public Accessorice
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
        public bool IsClosing
        {
            set
            {
                _IsClosing = value;
            }
            get
            {
                return _IsClosing;
            }
        }
        public bool IsSecondary
        {
            set
            {
                _IsSecondary = value;
            }
            get
            {
                return _IsSecondary;
            }
        }
        public bool IsLedger
        {
            set
            {
                _IsLedger = value;
            }
            get
            {
                return _IsLedger;
            }
        }
        public bool IsLeaf
        {
            set
            {
                _IsLeaf = value;
            }
            get
            {
                return _IsLeaf;
            }
        }
        public bool Direction
        {
            set
            {
                _Direction = value;
            }
            get
            {
                return _Direction;
            }
        }
        public int DefaultCostCenter
        {
            set
            {
                _DefaultCostCenter = value;
            }
            get
            {
                return _DefaultCostCenter;
            }
        }
        public bool HasCostCenter
        {
            set
            {
                _HasCostCenter = value;
            }
            get
            {
                return _HasCostCenter;
            }
        }
        public bool Status
        {
            set
            {
                _Status = value;
            }
            get
            {
                return _Status;
            }
        }
        public int AccountType
        {
            set
            {
                _AccountType = value;
            }
            get
            {
                return _AccountType;
            }
        }
        public double DebitBalance
        {
            set
            {
                _DebitBalance = value;
            }
            get
            {
                return _DebitBalance;
            }
        }
        public double CreditBalance
        {
            set
            {
                _CreditBalance = value;
            }
            get
            {
                return _CreditBalance;
            }
        }
        public double DebitElementBalance
        {
            set
            {
                _DebitElementBalance = value;
            }
            get
            {
                return _DebitElementBalance;
            }
        }
        public double CreditElementBalance
        {
            set
            {
                _CreditElementBalance = value;
            }
            get
            {
                return _CreditElementBalance;
            }
        }

        public string BalanceDesc
        {
            set
            {
                _BalanceDesc = value;
            }
            get
            {
                return _BalanceDesc;
            }
        }

        public DataTable CostCenterTable
        {
            set
            {
                _CostCenterTable = value;
            }
        }
        public DataTable AccountTable
        {
            set
            {
                _AccountTable = value;
            }
            
        }
        public int ParentLevel
        {
            set 
            {
                _ParentLevel = value;
            }
        }
        #region Public Set Accessoric For Search
        public string LikeNameA
        {
            set
            {
                _LikeNameA = value;
            }
        }
        public string LikeNameE
        {
            set
            {
                _LikeNameE = value;
            }
        }
        public string LikeCode
        {
            set
            {
                _LikeCode = value;
            }
        }
        public bool OnlyFamily
        {
            set
            {
                _OnlyFamily = value;
            }
           
        }
        public int SecondryDetermined
        {
            set
            {
                _SecondryDetermined = value;
            }
        }
        public int DirectionDetermined
        {
            set
            {
                _DirectionDetermined = value;
            }
        }
        public int StatusDetermined
        {
            set
            {
                _StatusDetermined = value;
            }
        }
        public string IDsStr
        {
            set
            {
                _IDsStr = value;
            }
        }
        public string DefaultCostCenterCode
        {
            get
            {
                return _DefaultCostCenterCode;
            }
        }
        public string DefaultCostCenterName
        {
            get
            {
                return _DefaultCostCenterName;
            }
        }
        public string ParentCode
        {
            get
            {
                return _ParentCode;
            }
        }

        public string ParentName
        {
            get
            {
                return _ParentName;
            }
        }
        public string AddStr
        {
            get
            {
                _FamilyID = _FamilyID == 0 ? _ID : _FamilyID;
                _ParentID = _ParentID == 0 ? _ID : _ParentID;
                int intIsClosing = _IsClosing ? 1 : 0;
                int intIsSecondary = _IsSecondary ? 1 : 0;
                int intDirectory = _Direction ? 1 : 0;
                int intStatus = _Status ? 1 : 0;
                int intIsLedger = _IsLedger ? 1 : 0;
                int intIsLeaf = _IsLeaf ? 1 : 0;
                int intHasCostCenter = _HasCostCenter ? 1 : 0;
                string Returned = " INSERT INTO GLAccount" +
                                " (AccountType,AccountCode, AccountNameA, AccountNameE, AccountParentID, AccountFamilyID, AccountLevel, AccountIsClosing, AccountIsSecondary," +
                                "AccountIsLedger,AccountIsLeaf,AccountDirection,AccountStatus,AccountHasCostCenter,AccountDefaultCostCenter"+
                                ",UsrIns,TimIns)" +
                                " VALUES     ("+ _AccountType +",'" + _Code + "','" + _NameA + "','" + _NameE + "'," + _ParentID + "," + _FamilyID + "," + _Level + "," + intIsClosing + "," + intIsSecondary + "," +
                                intIsLedger + "," + intIsLeaf + "," + intDirectory + "," + intStatus + "," + intHasCostCenter + "," + _DefaultCostCenter +
                                "," + SysData.CurrentUser.ID + ",GetDate()) ";
                return Returned;
            }
        }
        public  string SearchStr
        {
            get
            {
                string strDefaultCostCenter = "SELECT CostCenterID AS DefaultCostCenterID "+
                    ", CostCenterCode AS DefaultCostCenterCode, CostCenterNameA AS DefaultCostCenterName "+
                    " FROM   dbo.GLCostCenter ";
                string strBalance = "SELECT     BalanceAccount,BalanceCostCenter, MAX(BalanceID) AS MaxBalanceID "+
                                     " FROM     dbo.GLAccountBalance  "+
                                      " GROUP BY BalanceAccount,BalanceCostCenter  ";
                strBalance = "SELECT     dbo.GLAccountBalance.BalanceAccount,dbo.GLAccountBalance.BalanceCostCenter, dbo.GLAccountBalance.BalanceDesc"+
                    ", dbo.GLAccountBalance.BalanceCredit," +
                    " dbo.GLAccountBalance.BalanceDebit,  "+
                    " dbo.GLAccountBalance.BlanceElementCredit, dbo.GLAccountBalance.BalanceElementDebit, dbo.GLAccountBalance.BalanceDate "+
                    " FROM         dbo.GLAccountBalance INNER JOIN "+
                    "("+ strBalance +") AS MaxBalanceTable ON dbo.GLAccountBalance.BalanceID = MaxBalanceTable.MaxBalanceID AND  "+
                     " dbo.GLAccountBalance.BalanceAccount = MaxBalanceTable.BalanceAccount and MaxBalanceTable.BalanceCostCenter = 0 ";
                string strParent = "SELECT  AccountCode AS AccountParentCode, AccountNameA AS AccountParentName "+
                       " FROM     dbo.GLAccount ";
                string Returned = " SELECT     AccountID, AccountCode, AccountNameA, AccountNameE, AccountParentID, AccountFamilyID, AccountLevel, AccountIsClosing, " +
                                  "AccountIsSecondary,AccountIsLeaf,AccountDirection,AccountStatus,AccountHasCostCenter" +
                                  ",dbo.GLAccount.AccountDebitBalance, dbo.GLAccount.AccountCreditBalance"+
                                  ",AccountType,AccountTypeTable.*,DefaultCostCenterTable.*"+
                                  //",AccountBalanceTable.*" +
                                  ",ParentTable.*  " +
                                  " FROM    GLAccount " +
                                  " left outer join (" + AccountTypeDb.SearchStr + ") as AccountTypeTable "+
                                  " on GLAccount.AccountType = AccountTypeTable.AccountTypeID  "+
                                  " left outer join (" + strDefaultCostCenter + ")   as DefaultCostCenterTable "+
                                  " on GLAccount.AccountDefaultCostCenter = DefaultCostCenterTable.DefaultCostCenterID "+
                                  //" left outer join (" + strBalance + ") as AccountBalanceTable " +
                                  //" on GLAccount.AccountID = AccountBalanceTable.BalanceAccount " +
                                  " left outer join (" + strParent + ") as ParentTable "+
                                  " on dbo.GetAccountCodeLevel(GLAccount.AccountCode,"+ _ParentLevel +") = ParentTable.AccountParentCode ";
                return Returned;
            }
        }
         
        #endregion

        #endregion
        #region Private Methods
        void SetData(DataRow objDR)
        {
            _ID = int.Parse(objDR["AccountID"].ToString());
            _Code = objDR["AccountCode"].ToString();
            _Level = int.Parse(objDR["AccountLevel"].ToString());
            _NameA = objDR["AccountNameA"].ToString();
            _NameE = objDR["AccountNameE"].ToString();
            _IsClosing = bool.Parse(objDR["AccountIsClosing"].ToString());
            _IsSecondary = bool.Parse(objDR["AccountIsSecondary"].ToString());
            _IsLeaf = bool.Parse(objDR["AccountIsLeaf"].ToString());
            _FamilyID = int.Parse(objDR["AccountFamilyID"].ToString());
            _ParentID = int.Parse(objDR["AccountParentID"].ToString());
            if(objDR["AccountDirection"].ToString()!= "")
            _Direction = bool.Parse(objDR["AccountDirection"].ToString());
            if(objDR["AccountStatus"].ToString()!= "")
            _Status = bool.Parse(objDR["AccountStatus"].ToString());
            if(objDR.Table.Columns["AccountType"] != null && objDR["AccountType"].ToString() != "")
               _AccountType = int.Parse(objDR["AccountType"].ToString());
           if (objDR["AccountHasCostCenter"].ToString() != "")
               _HasCostCenter = bool.Parse(objDR["AccountHasCostCenter"].ToString());
           if (objDR["DefaultCostCenterID"].ToString() != "")
               _DefaultCostCenter = int.Parse(objDR["DefaultCostCenterID"].ToString());
           _DefaultCostCenterCode = objDR["DefaultCostCenterCode"].ToString();
           _DefaultCostCenterName = objDR["DefaultCostCenterName"].ToString();
           if (objDR.Table.Columns["BalanceCredit"]!= null && objDR["BalanceCredit"].ToString() != "")
               _CreditBalance = double.Parse(objDR["BalanceCredit"].ToString());
           if (objDR.Table.Columns["BalanceDebit"]!= null && objDR["BalanceDebit"].ToString() != "")
               _DebitBalance = double.Parse(objDR["BalanceDebit"].ToString());
           if (objDR.Table.Columns["BlanceElementCredit"]!= null&& objDR["BlanceElementCredit"].ToString() != "")
               _CreditElementBalance = double.Parse(objDR["BlanceElementCredit"].ToString());
           if ( objDR.Table.Columns["BalanceElementDebit"]!= null && objDR["BalanceElementDebit"].ToString() != "")
               _DebitElementBalance = double.Parse(objDR["BalanceElementDebit"].ToString());
            if(objDR.Table.Columns["BalanceDesc"]!= null)
           _BalanceDesc = objDR["BalanceDesc"].ToString();
           _ParentCode = objDR["AccountParentCode"].ToString();
           _ParentName = objDR["AccountParentName"].ToString();
        }
        void SetRelatedAccount(string strParentID, DataTable dtTemp, ref string strIDs)
        {
            DataRow[] arrDR = dtTemp.Select("AccountID <> AccountParentID and AccountParentID = " + strParentID);
            string strTempParent;
            foreach (DataRow objDR in arrDR)
            {
                if (strIDs != "")
                    strIDs = strIDs + ",";
                strTempParent = objDR["AccountID"].ToString();
                strIDs = strIDs + objDR["AccountID"].ToString();
                SetRelatedAccount(strTempParent, dtTemp, ref strIDs);
            }
        }
        #endregion
        #region Public Methods
        public override void Add()
        {
         
            _ID = SysData.SharpVisionBaseDb.InsertIdentityTable(AddStr);
            JoinCostCenter();
            if (_ParentID == 0)
            {

                string strSql = "update GLAccount set AccountParentID = " + _ID + ", AccountFamilyID =" + _ID;
                strSql = strSql + " where AccountID = " + _ID;
                SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
              
            }
        }
        public override void Edit()
        {
            _FamilyID = _FamilyID == 0 ? _ID : _FamilyID;
            _ParentID = _ParentID == 0 ? _ID : _ParentID;
            int intIsClosing = _IsClosing ? 1 : 0;
            int intIsSecondary = _IsSecondary ? 1 : 0;
            int intDirectory = _Direction ? 1 : 0;
            int intStatus = _Status ? 1 : 0;
            int intIsLedger = _IsLedger ? 1 : 0;
            int intIsLeaf = _IsLeaf ? 1 : 0;
            int intHasCostCenter = _HasCostCenter ? 1 : 0;
            string strSql = " UPDATE    GLAccount"+
                            " SET AccountType = "+ _AccountType +
                            ", AccountCode ='"+_Code+"'"+
                            " , AccountNameA ='"+_NameA+"' "+
                            " , AccountNameE ='"+_NameE+"' "+
                            " , AccountParentID ="+_ParentID+""+
                            " , AccountFamilyID ="+_FamilyID+""+
                            " , AccountLevel ="+_Level+""+
                            " , AccountIsClosing ="+intIsClosing+""+
                            " , AccountIsSecondary = "+intIsSecondary+""+
                            " , AccountIsLedger = "+intIsLedger+""+
                            " , AccountIsLeaf = " + intIsLeaf + "" +
                            " , AccountDirection = " + intDirectory + "" +
                            " , AccountStatus = " + intStatus + "" +
                            ",AccountHasCostCenter="+ intHasCostCenter +
                            ",AccountDefaultCostCenter="+ _DefaultCostCenter +
                            " , UsrUpd =" + SysData.CurrentUser.ID + "" +
                            " , TimUpd = GetDate()" +
                            "   WHERE  AccountID = " + _ID + "";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);

            strSql = " select * from GLAccount where AccountFamilyID in " +
               " (select AccountFamilyID from GLAccount where AccountParentID=" + _ID + " and AccountID <> " + _ID + " and AccountFamilyID <> " + _FamilyID + ")";
            DataTable dtTemp = SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
            JoinCostCenter();
            if (dtTemp.Rows.Count == 0)
                return;
            string strIDs = "";
            SetRelatedAccount(_ID.ToString(), dtTemp, ref strIDs);
            strSql = " Update GLAccount set AccountFamilyID = " + _FamilyID + " where AccountID in ( " + strIDs + ")";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
          

        }
        public override void Delete()
        {
            string strSql = " DELETE FROM GLAccount WHERE  AccountID = " + _ID + "";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
            
        }
        public override DataTable Search()
        {
            string strSql = SearchStr + " Where 1 = 1 ";
            if (_ID != 0)
                strSql = strSql + " and  AccountID = " + _ID + "";
            if (_IDsStr != null && _IDsStr != "")
                strSql += " and AccountID in ("+ _IDsStr +")";
            if (_Code != null && _Code != "")
                strSql = strSql + " and AccountCode = '" + _Code + "'";
            if (_NameA != null && _NameA != "")
                strSql = strSql + " and  AccountNameA like  '%" + _NameA + "%'";
            if (_NameE != null && _NameE != "")
                strSql = strSql + " and  AccountNameE = '%" + _NameE + "%'";
            if (_LikeCode != null && _LikeCode != "")
                strSql = strSql + " and  AccountCode Like '%" + _LikeCode + "%'";
            if (_LikeNameA != null && _LikeNameA != "")
                strSql = strSql + " and  AccountNameA Like '%" + _LikeNameA + "%'";
            if (_LikeNameE != null && _LikeNameE != "")
                strSql = strSql + " and  AccountNameE Like '%" + _LikeNameE + "%'";
            if (_Level != 0)
                strSql = strSql + " and  AccountLevel = "+_Level+"";
            if (_ParentID != 0)
                strSql = strSql + " and  AccountParentID = " + _ParentID + "";
            if (_FamilyID != 0)
                strSql = strSql + " and  AccountFamilyID = " + _FamilyID + "";
            if (_OnlyFamily)
                strSql = strSql + " and AccountFamilyID =AccountID ";
        
            if (_StatusDetermined == 1)
                strSql = strSql + " and AccountStatus = 0 ";
            else if(_StatusDetermined == 2)
                strSql = strSql + " and AccountStatus = 1 ";

            if (_SecondryDetermined == 1)
                strSql += " and AccountIsSecondary=0";
            else if(_SecondryDetermined == 2)
                strSql += " and AccountIsSecondary=1";
            if (_LeafDetermined == 1)
                strSql += " and AccountIsLeaf=0 ";
            else if (_LeafDetermined == 2)
                strSql += " and AccountIsLeaf=1 ";
            

            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        public void JoinCostCenter()
        {
            if (_CostCenterTable == null || _CostCenterTable.Rows.Count == 0)
                return;
            string[] arrStr = new string[_CostCenterTable.Rows.Count];
            AccountCostCenterDb objDb;
            int intIndex = 0;
            foreach (DataRow objDr in _CostCenterTable.Rows)
            {
                objDb = new AccountCostCenterDb(objDr);
                objDb.Account = _ID;
                if (objDb.ID == 0)
                    arrStr[intIndex] = objDb.AddStr;
                else
                    arrStr[intIndex] = objDb.EditStr;
                intIndex++;
            }
            SysData.SharpVisionBaseDb.ExecuteNonQuery(arrStr);
        }
        public void EditBalance()
        {
            if (_AccountTable == null || _AccountTable.Rows.Count == 0)
                return;
            string[] arrStr = new string[_AccountTable.Rows.Count];
            int intIndex = 0;
            foreach(DataRow objDr in _AccountTable.Rows)
            {
                arrStr[intIndex] = "insert into GLAccountBalance (BalanceAccount, BalanceDesc, BalanceCredit, BalanceDebit, BalanceDate, UsrIns, TimIns)  " +
                    " values ("+ objDr["AccountID"].ToString() + ",'" + objDr["BalanceDesc"].ToString() + "'," + 
                    objDr["BalanceCredit"].ToString() + "," + objDr["BalanceDebit"].ToString() + ",GetDate()," + SysData.CurrentUser.ID   +",GetDate()) ";
                intIndex++;
            }
            SysData.SharpVisionBaseDb.ExecuteNonQuery(arrStr);
        }
        public void InsertPredefinedContractingAccount()
        {
            if (_AccountTable == null || _AccountTable.Rows.Count == 0)
                return;
            string[] arrStr = new string[_AccountTable.Rows.Count + 1];
            arrStr[0] = "delete from GLGeneralPurposedContractingAccount ";
            int intIndex = 1;
            foreach (DataRow objDr in _AccountTable.Rows)
            {
                arrStr[intIndex] = "insert into GLGeneralPurposedContractingAccount (GeneralAccountIdentifier,GeneralAcountID) "+
                    " values ("+ intIndex.ToString() + "," + objDr["AccountID"].ToString() +") ";
                intIndex++;
            }
            SysData.SharpVisionBaseDb.ExecuteNonQuery(arrStr);

        }
        public DataTable GetPredefinedContractingAccount()
        {
            string strSql = "select AccountTable.*,  dbo.GLGeneralPurposedContractingAccount.GeneralAccountIdentifier "+
                " from   dbo.GLGeneralPurposedContractingAccount "+
                " inner join (" + new AccountDb().SearchStr + ") as AccountTable "+
                "  on dbo.GLGeneralPurposedContractingAccount.GeneralAcountID=AccountTable.AccountID ";
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        public void InsertPredefinedReservationAccount()
        {
            if (_AccountTable == null || _AccountTable.Rows.Count == 0)
                return;
            string[] arrStr = new string[_AccountTable.Rows.Count + 1];
            arrStr[0] = "delete from GLGeneralPurposedReservationAccount ";
            int intIndex = 1;
            foreach (DataRow objDr in _AccountTable.Rows)
            {
                arrStr[intIndex] = "insert into GLGeneralPurposedReservationAccount (GeneralAccountIdentifier,GeneralAcountID) " +
                    " values (" + intIndex.ToString() + "," + objDr["AccountID"].ToString() + ") ";
                intIndex++;
            }
            SysData.SharpVisionBaseDb.ExecuteNonQuery(arrStr);

        }
        public DataTable GetPredefinedReservationAccount()
        {
            string strSql = "select AccountTable.*,  dbo.GLGeneralPurposedReservationAccount.GeneralAccountIdentifier " +
                " from   dbo.GLGeneralPurposedReservationAccount " +
                " inner join (" + new AccountDb().SearchStr + ") as AccountTable " +
                "  on dbo.GLGeneralPurposedReservationAccount.GeneralAcountID=AccountTable.AccountID ";
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        #endregion
    }
}
