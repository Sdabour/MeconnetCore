using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.GL.GLDataBase;
using SharpVision.Base.BaseBusiness;
using SharpVision.Base.BaseDataBase;
using SharpVision.UMS.UMSBusiness;
using SharpVision.COMMON.COMMONBusiness;
using System.Data;
using SharpVision.SystemBase;
namespace SharpVision.GL.GLBusiness
{
    #region Enumration
    public enum AccountStatus
    { 
        Desabled = 0,
        Enabled = 1,
        All = 2
    }
    public enum AccountType
    {
        Closed = 1,
        Secondry = 2,
        All = 0
    }
    public enum AccountDirection
    { 
        Crdit = 1,
        Dept = 2,
        All = 0
    }
    public enum PredefinedContractingAccount
    {
        NotSpecified = 0,
      ExecutedProcesses =1,//√⁄„«·  Õ  «· ‰›Ì–
      ContractorAccount=2,//Õ”«» «·„ﬁ«Ê·Ì‰
        ContractorInsurance=3,// √„Ì‰«  «·„ﬁ«Ê·Ì‰
        ContractorTax=4,//«·œ«∆‰Ê‰ ÷—«∆»
        ContractorExpensesValue =5,//Õ”«» «·„’«—Ì› «·«œ«—Ì…
        VarriedDiscount=6,//Õ”«» «·Œ’Ê„«  «·„ ‰Ê⁄…
        Coffer=7,//Õ”«» «·Œ“Ì‰…
        Discount =8 //Õ”«» «·Œ’Ê„« 

    }
    public enum PredefinedReservationAccount
    {
        NotSpecified = 0,
        CofferAccount=1,
        UnitCreditorAccount=2,
       SalesAccount=3,
        CustomerAccount=4,
        MulctAccount=5,
        DiscountAccount=6

    }
    #endregion

    public class AccountBiz : BaseSelfeRelatedBiz
    {
        #region Private Data
        TransactionElementCol _ElementCol;
        AccountTypeBiz _AccountTypeBiz;
        CostCenterBiz _DefaultCostCenter;
        AccountCostCenterCol _CostCenterCol;
        AccountCostCenterCol _RunningCostCenterCol;
        static AccountCol _PredifinedContractingAccountCol;
        static AccountCol _PredifinedReservationAccountCol;
        double _CreditValue;
        double _DebitValue;

        #endregion

        #region Constractors
        public AccountBiz()
        {
            _BaseDb = new AccountDb();
        }
        public AccountBiz(int intID)
        {
            if (intID == 0)
                _BaseDb = new AccountDb();
            else
            {
                AccountDb objTemp = new AccountDb();
                objTemp.ID = intID;
                DataTable dtTemp = objTemp.Search();
                if (dtTemp.Rows.Count > 0)
                    _BaseDb = new AccountDb(dtTemp.Rows[0]);
                else
                    _BaseDb = new AccountDb();
            }
        }
        public AccountBiz(DataRow objDR)
        {
            _BaseDb = new AccountDb(objDR);
            _AccountTypeBiz = new AccountTypeBiz(objDR);
            _DefaultCostCenter = new CostCenterBiz();
            if (((AccountDb)_BaseDb).DefaultCostCenter != 0)
            {
                _DefaultCostCenter.ID = ((AccountDb)_BaseDb).DefaultCostCenter;
                _DefaultCostCenter.Code = ((AccountDb)_BaseDb).DefaultCostCenterCode;
                _DefaultCostCenter.NameA = ((AccountDb)_BaseDb).DefaultCostCenterName;
            }
        }

        public AccountBiz(string strCode)
        {
            if (strCode == "")
                _BaseDb = new AccountDb();
            else
            {
                AccountDb objTemp = new AccountDb();
                objTemp.LikeCode = strCode;
                DataTable dtTemp = objTemp.Search();
                if (dtTemp.Rows.Count > 0)
                    _BaseDb = new AccountDb(dtTemp.Rows[0]);
                else
                    _BaseDb = new AccountDb();
            }
        }
        #endregion

        #region Public Accessorice
        public AccountCol Children
        {
            set
            {
                _Children = value;
            }
            get
            {
                if (_Children == null)
                {
                  
                        _Children = new AccountCol(true);

                }
                return (AccountCol)_Children;
            }
        }
        public AccountBiz ParentBiz
        {
            set
            {
                _ParentBiz = value;
            }
            get
            {
                return (AccountBiz)_ParentBiz;
            }
        }
        public string Code
        {
            set
            {
               ((AccountDb)_BaseDb).Code = value;
            }
            get
            {
                return ((AccountDb)_BaseDb).Code;
            }
        }
        public int Level
        {
            set
            {
                ((AccountDb)_BaseDb).Level = value;
            }
            get
            {
                return ((AccountDb)_BaseDb).Level;
            }
        }
        public bool IsClosing
        {
            set
            {
                ((AccountDb)_BaseDb).IsClosing = value;
            }
            get
            {
                return ((AccountDb)_BaseDb).IsClosing;
            }
        }
        public bool IsSecondary
        {
            set
            {
                ((AccountDb)_BaseDb).IsSecondary = value;
            }
            get
            {
                return ((AccountDb)_BaseDb).IsSecondary;
            }
        }
        public bool IsLedger
        {
            set
            {
                ((AccountDb)_BaseDb).IsLedger = value;
            }
            get
            {
                return ((AccountDb)_BaseDb).IsLedger;
            }
        }
        public bool IsLeaf
        {
            set
            {
                ((AccountDb)_BaseDb).IsLeaf = value;
            }
            get
            {
                return ((AccountDb)_BaseDb).IsLeaf;
            }
        }
        public bool Direction
        {
            set
            {
                ((AccountDb)_BaseDb).Direction = value;
            }
            get
            {
                return ((AccountDb)_BaseDb).Direction;
            }
        }

        public bool Status
        {
            set
            {
                ((AccountDb)_BaseDb).Status = value;
            }
            get
            {
                return ((AccountDb)_BaseDb).Status;
            }
        }
        public AccountTypeBiz AccountTypeBiz
        {
            set
            {
                _AccountTypeBiz = value;
            }
            get
            {
                if (_AccountTypeBiz == null)
                    _AccountTypeBiz = new AccountTypeBiz();
                return _AccountTypeBiz;
            }
        }
        public bool HasCostCenter
        {
            set
            {
                ((AccountDb)_BaseDb).HasCostCenter = value;
            }
            get
            {
                return ((AccountDb)_BaseDb).HasCostCenter;
            }
        }
        public double DebitBalance
        {
            set
            {
                ((AccountDb)_BaseDb).DebitBalance = value;
            }
            get
            {
                return ((AccountDb)_BaseDb).DebitBalance;
            }
        }
        public double CreditBalance
        {
            set
            {
                ((AccountDb)_BaseDb).CreditBalance = value;
            }
            get
            {
                return ((AccountDb)_BaseDb).CreditBalance;
            }
        }
        public double DebitElementBalance
        {
            set
            {
                ((AccountDb)_BaseDb).DebitElementBalance = value;
            }
            get
            {
                return ((AccountDb)_BaseDb).DebitElementBalance;
            }
        }
        public double CreditElementBalance
        {
            set
            {
                ((AccountDb)_BaseDb).CreditElementBalance = value;
            }
            get
            {
                return ((AccountDb)_BaseDb).CreditElementBalance;
            }
        }
        public string BalanceDesc
        {
            set
            {
                ((AccountDb)_BaseDb).BalanceDesc = value;
            }
            get
            {
                return ((AccountDb)_BaseDb).BalanceDesc;
            }
        }
        public CostCenterBiz DefaultCostCenter
        {
            set
            {
                _DefaultCostCenter = value;
            }
            get
            {
                if (_DefaultCostCenter == null)
                    _DefaultCostCenter = new CostCenterBiz();
                return _DefaultCostCenter;
            }
        }
        public double CreditValue
        {
            set
            {
                _CreditValue = value;
            }
            get
            {
                return _CreditValue;
            }
        }
        public double DebitValue
        {
            set
            {
                _DebitValue = value;
            }
            get
            {
                return _DebitValue;
            }
        }
        public string ParentCode
        {
            get
            {
                return ((AccountDb)_BaseDb).ParentCode;
            }
        }

        public string ParentName
        {
            get
            {
                return ((AccountDb)_BaseDb).ParentName;
            }
        }
        public AccountCostCenterCol CostCenterCol
        {
            set
            {
                _CostCenterCol = value;
            }
            get
            {
                if (_CostCenterCol == null)
                {
                    _CostCenterCol = new AccountCostCenterCol(true);
                    if (ID != 0)
                    {
                        AccountCostCenterDb objDb = new AccountCostCenterDb();
                        objDb.Account = ID;
                        DataTable dtTemp = objDb.Search();
                        foreach (DataRow objDr in dtTemp.Rows)
                        {
                            _CostCenterCol.Add(new AccountCostCenterBiz(objDr));
                        }
                    }
                }
                return _CostCenterCol;
            }
        }
        public double TotalCreditBalance
        {
            get
            {
                return CreditBalance + CreditElementBalance;
            }
        }
        public double TotalDebitBalance
        {
            get
            {
                return DebitBalance + DebitElementBalance;
            }
        }
        public double Balance
        {
            get
            {
                double Returned = 0;
                Returned = TotalDebitBalance - TotalCreditBalance;
                Returned += DebitValue - CreditValue;
                return Returned;
            }
        }

        public AccountCostCenterCol RuningCostCenterCol
        {
         
            get
            {
             
                if (_RunningCostCenterCol == null)
                {
                    _RunningCostCenterCol = new AccountCostCenterCol(true);
                    if (ID != 0)
                    {
                        AccountCostCenterDb objDb = new AccountCostCenterDb();
                        objDb.Account = ID;
                        DataTable dtTemp = objDb.GetNodes();
                        AccountCostCenterBiz objTemp = new AccountCostCenterBiz();
                        CostCenterCol objCostCenterCol = new CostCenterCol(true);
                        DataRow[] arrDr;
                        foreach (DataRow objDr in dtTemp.Rows)
                        {
                            objTemp = new AccountCostCenterBiz(objDr);
                            //arrDr = CostCenterDb.CostCenterCacheTable.Select("CostCenterID =" +objTemp.CostCenterID + " or CostCenterParentID="+ 
                            //    objTemp.CostCenterID + " or CostCenterFamilyID= "+objTemp.CostCenterID);
                            string strSelct = "";
                            if (objTemp.CostCenterLevel == 2)
                                strSelct = "CostCenterParentID=" + objTemp.CostCenterID;
                            else
                                strSelct = "CostCenterID =" + objTemp.CostCenterID.ToString();
                            arrDr = CostCenterDb.CostCenterCacheTable.Select(strSelct);
                         
                            foreach (DataRow objTempDr in arrDr)
                            {
                                objTemp = new AccountCostCenterBiz();
                                objTemp.AccountBiz = this;
                                objTemp.CostCenterBiz = new CostCenterBiz(objTempDr);
                                _RunningCostCenterCol.Add(objTemp);

                            }
                           
                        }
                    }
                }
                return _RunningCostCenterCol;
            }
        }
        public static List<string> PredefineContractingdAccountStrCol
        {
            get
            {
                List<string> Returned = new List<string>();
                Returned.Add("€Ì— „Õœœ");
                 Returned.Add("√⁄„«·  Õ  «· ‰›Ì–");
                 Returned.Add("Õ”«» «·„ﬁ«Ê·Ì‰");
                 Returned.Add(" √„Ì‰«  «·„ﬁ«Ê·Ì‰");
                 Returned.Add("«·œ«∆‰Ê‰ ÷—«∆»");
                 Returned.Add("Õ”«» «·„’«—Ì› «·«œ«—Ì…");
                 Returned.Add("Õ”«» Œ’Ê„«  «·ÊÕœ«  Ê«·„ ‰Ê⁄");
                 Returned.Add("Õ”«» «·Œ“Ì‰…");
                 Returned.Add("Õ”«» «·Œ’Ê„« ");
                return Returned;
            }
        }
        public static List<string> PredefinedReservationAccountStrCol
        {
            get
            {
                List<string> Returned = new List<string>();
                Returned.Add("€Ì— „Õœœ");
                Returned.Add("Õ”«» Œ“Ì‰…");
                Returned.Add("Õ”«» œ«∆‰Ê« «·ÊÕœ« ");
                Returned.Add("Õ”«» „»Ì⁄« ");
                Returned.Add("Õ”«» «·⁄„·«¡");
                Returned.Add("Õ”«» «·€—«„« ");
                Returned.Add("Õ”«» «·Œ’Ê„« ");
                return Returned;
            }
        }
        public static AccountBiz ContractorAccountBiz
        {
            get
            {
                AccountBiz Returned = new AccountBiz();
                Returned = PredifinedContractingAccountCol[(int)PredefinedContractingAccount.ContractorAccount];
                return Returned;
            }
        }
        public static AccountBiz ContractorInsuranceAccountBiz
        {
            get
            {
                AccountBiz Returned = new AccountBiz();
                Returned = PredifinedContractingAccountCol[(int)PredefinedContractingAccount.ContractorInsurance];
                return Returned;
            }
        }
        public static AccountBiz ContractorTaxAccountBiz
        {
            get
            {
                AccountBiz Returned = new AccountBiz();
                Returned = PredifinedContractingAccountCol[(int)PredefinedContractingAccount.ContractorTax];
                return Returned;
            }
        }
        public static AccountBiz ContractorExpensesValueAccountBiz
        {
            get
            {
                AccountBiz Returned = new AccountBiz();
                Returned = PredifinedContractingAccountCol[(int)PredefinedContractingAccount.ContractorExpensesValue];
                return Returned;
            }
        }
        public static AccountBiz VarriedDiscountAccountBiz
        {
            get
            {
                AccountBiz Returned = new AccountBiz();
                Returned = PredifinedContractingAccountCol[(int)PredefinedContractingAccount.VarriedDiscount];
                return Returned;
            }
        }
        public static AccountBiz CofferAccountBiz
        {
            get
            {
                AccountBiz Returned = new AccountBiz();
                Returned = PredifinedContractingAccountCol[(int)PredefinedContractingAccount.Coffer];
                return Returned;
            }
        }
        public static AccountBiz DiscountAccountBiz
        {
            get
            {
                AccountBiz Returned = new AccountBiz();
                Returned = PredifinedContractingAccountCol[(int)PredefinedContractingAccount.Discount];
                return Returned;
            }
        }
        public static AccountCol PredifinedContractingAccountCol
        {
            set
            {
                _PredifinedContractingAccountCol = value;
            }
            get
            {
                if (_PredifinedContractingAccountCol == null)
                {
                    _PredifinedContractingAccountCol = new AccountCol(true);
                    DataTable dtTemp = new AccountDb().GetPredefinedContractingAccount();
                    DataRow[] arrDr;
                    _PredifinedContractingAccountCol.Add(new AccountBiz());
                    for (int intIndex = 1; intIndex < PredefineContractingdAccountStrCol.Count; intIndex++)
                    {

                        arrDr = dtTemp.Select("GeneralAccountIdentifier=" + intIndex.ToString());
                        if (arrDr.Length > 0)
                            _PredifinedContractingAccountCol.Add(new AccountBiz(arrDr[0]));
                        else
                            _PredifinedContractingAccountCol.Add(new AccountBiz());
                    }
                }
                return _PredifinedContractingAccountCol;
            }
        }



       
        public static AccountBiz CRMUnitCreditorAccountBiz
        {
            get
            {
                AccountBiz Returned = new AccountBiz();
                Returned = PredifinedReservationAccountCol[(int)PredefinedReservationAccount.UnitCreditorAccount];
                return Returned;
            }
        }
        public static AccountBiz CRMSalesAccountBiz
        {
            get
            {
                AccountBiz Returned = new AccountBiz();
                Returned = PredifinedReservationAccountCol[(int)PredefinedReservationAccount.SalesAccount];
                return Returned;
            }
        }
        public static AccountBiz CRMCofferAccountBiz
        {
            get
            {
                AccountBiz Returned = new AccountBiz();
                Returned = PredifinedReservationAccountCol[(int)PredefinedReservationAccount.CofferAccount];
                return Returned;
            }
        }
        public static AccountBiz CRMMulctAccountBiz
        {
            get
            {
                AccountBiz Returned = new AccountBiz();
                Returned = PredifinedReservationAccountCol[(int)PredefinedReservationAccount.MulctAccount];
                return Returned;
            }
        }
        public static AccountBiz CRMDiscountAccountBiz
        {
            get
            {
                AccountBiz Returned = new AccountBiz();
                Returned = PredifinedReservationAccountCol[(int)PredefinedReservationAccount.DiscountAccount];
                return Returned;
            }
        }
        public static AccountBiz CRMCustomerAccountBiz
        {
            get
            {
                AccountBiz Returned = new AccountBiz();
                Returned = PredifinedReservationAccountCol[(int)PredefinedReservationAccount.CustomerAccount];
                return Returned;
            }
        }
        public static AccountCol PredifinedReservationAccountCol
        {
            set
            {
                _PredifinedReservationAccountCol = value;
            }
            get
            {
                if (_PredifinedReservationAccountCol == null)
                {
                    _PredifinedReservationAccountCol = new AccountCol(true);
                    DataTable dtTemp = new AccountDb().GetPredefinedReservationAccount();
                    DataRow[] arrDr;
                    _PredifinedReservationAccountCol.Add(new AccountBiz());
                    for (int intIndex = 1; intIndex < PredefinedReservationAccountStrCol.Count; intIndex++)
                    {

                        arrDr = dtTemp.Select("GeneralAccountIdentifier=" + intIndex.ToString());
                        if (arrDr.Length > 0)
                            _PredifinedReservationAccountCol.Add(new AccountBiz(arrDr[0]));
                        else
                            _PredifinedReservationAccountCol.Add(new AccountBiz());
                    }
                }
                return _PredifinedReservationAccountCol;
            }
        }
        public TransactionElementCol ElementCol
        {
            set
            {
                _ElementCol = value;
            }
            get
            {
                if (_ElementCol == null)
                {
                    _ElementCol = new TransactionElementCol(true);
                   
                }
                return _ElementCol;
            }
        }
        #region Code Data
        public string CodeL1
        {
            get
            {
                string Returned = "";
                Returned = SysData.GetAccountLevelCod(1, Code);
                return Returned;
            }
        }
        public string CodeL2
        {
            get
            {
                string Returned = "";
                Returned = SysData.GetAccountLevelCod(2, Code);
                return Returned;
            }
        }
        public string CodeL3
        {
            get
            {
                string Returned = "";
                Returned = SysData.GetAccountLevelCod(3, Code);
                return Returned;
            }
        }
        public string CodeL4
        {
            get
            {
                string Returned = "";
                Returned = SysData.GetAccountLevelCod(4, Code);
                return Returned;
            }
        }
        public int AccountLevel
        {
            get
            {
                int Returned = 0;
                int intTemp = 0;
                try
                {
                    intTemp = int.Parse(CodeL2);
                    if (intTemp == 0)
                        return 1;
                }
                catch { }
                try
                 {
                    intTemp = int.Parse(CodeL3);
                    if (intTemp == 0)
                        return 2;
                }
                catch { }
                try
                {
                    intTemp = int.Parse(CodeL4);
                    if (intTemp == 0)
                        return 3;
                }
                catch { }
                Returned = 4;
                return Returned;
            }
        }
        #endregion
        #endregion

        #region Private Methods

        #endregion

        #region Public Methods
        public void Add()
        {
            ((AccountDb)_BaseDb).ParentID = _ParentBiz.ID;
            ((AccountDb)_BaseDb).FamilyID = _ParentBiz.FamilyID;
            ((AccountDb)_BaseDb).AccountType = AccountTypeBiz.ID;
            ((AccountDb)_BaseDb).DefaultCostCenter = DefaultCostCenter.ID;
            ((AccountDb)_BaseDb).CostCenterTable = CostCenterCol.GetTable();
            ((AccountDb)_BaseDb).Add();
        }
        public void Edit()
        {
            ((AccountDb)_BaseDb).ParentID = _ParentBiz.ID;
            ((AccountDb)_BaseDb).FamilyID = _ParentBiz.FamilyID;
            ((AccountDb)_BaseDb).AccountType = AccountTypeBiz.ID;
            ((AccountDb)_BaseDb).DefaultCostCenter = DefaultCostCenter.ID;
            ((AccountDb)_BaseDb).CostCenterTable = CostCenterCol.GetTable();
            ((AccountDb)_BaseDb).Edit();
        }
        public void Delete()
        {
            ((AccountDb)_BaseDb).Delete();
        }
        #endregion 
    }
}