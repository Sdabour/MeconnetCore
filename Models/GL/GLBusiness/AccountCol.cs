using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using SharpVision.Base.BaseDataBase;
using SharpVision.Base.BaseBusiness;
using SharpVision.GL.GLDataBase;
using SharpVision.SystemBase;

namespace SharpVision.GL.GLBusiness
{
    public class AccountCol : BaseCol
    {
        #region Private Data
        Hashtable _TempAccountTable = new Hashtable();
        #endregion
    
        public AccountCol()
        {
            AccountDb objAccountDb = new AccountDb();
            DataTable dtAccount = objAccountDb.Search();
            //dtAccount.Columns["AccountOrder"].DataType = Type.GetType("System.Int");
            string strOrder = "";
            DataRow[] arrDR = dtAccount.Select(" AccountID=AccountParentID ", strOrder);
            AccountBiz objAccountBiz;
            AccountBiz objTempParent = new AccountBiz();
            string strAccountIDs = "";
            foreach (DataRow DR in arrDR)
            {

                objAccountBiz = new AccountBiz(DR);
                if (_TempAccountTable[objAccountBiz.ID.ToString()] != null)
                    continue;
                if (strAccountIDs != "")
                    strAccountIDs += ",";
                strAccountIDs = strAccountIDs + objAccountBiz.ID.ToString();
                Add(objAccountBiz);
                objAccountBiz.ParentBiz = objTempParent;
                objAccountBiz.Children = new AccountCol(true);
                _TempAccountTable.Add(objAccountBiz.ID.ToString(), objAccountBiz);


            }
            SetChildren(strAccountIDs, ref dtAccount);
        }
        public AccountCol(bool blIsempty)
        {
            if (blIsempty)
                return;

            AccountDb objAccountDb = new AccountDb();
            DataTable dtAccount = objAccountDb.Search();
            DataRow[] arrDR = dtAccount.Select("AccountID=AccountParentID ");
            AccountBiz objAccountBiz;
            objAccountBiz = new AccountBiz();
            objAccountBiz.NameA = "€Ì— „Õœœ";
            Add(objAccountBiz);
            AccountBiz objTempParent = new AccountBiz();

            foreach (DataRow DR in arrDR)
            {

                objAccountBiz = new AccountBiz(DR);


                SetChildren(ref objAccountBiz, ref dtAccount);
                this.Add(objAccountBiz);
                objAccountBiz.ParentBiz = objAccountBiz;

            }
        }
        public AccountCol(AccountBiz objParentAccount)
        {
            if (objParentAccount == null)
                objParentAccount = new AccountBiz();
            AccountDb objDb = new AccountDb();
            objDb.ParentID = objParentAccount.ID;
            if (objParentAccount.ID == 0)
                objDb.OnlyFamily = true;
            DataTable dtTemp = objDb.Search();
            AccountBiz objBiz;
            foreach (DataRow objDr in dtTemp.Rows)
            {
                objBiz = new AccountBiz(objDr);
                objBiz.ParentBiz = objParentAccount;
                Add(objBiz);
            }
        }

        

        public AccountCol(string strCode, string strName,AccountBiz ParentBiz,int intStatus,int intDirection,int intType,int intSecondry)
        {
            AccountDb objDb = new AccountDb();
            objDb.Code = strCode;
            objDb.NameA = strName;
            if (ParentBiz == null)
                ParentBiz = new AccountBiz();
            objDb.ParentID = ParentBiz.ID;
            if (intStatus == 2)
                objDb.StatusDetermined = 2;

            if (intDirection < 2)
                objDb.DirectionDetermined = intDirection;
        
                objDb.SecondryDetermined = intSecondry;
            DataTable dtTemp = objDb.Search();

            foreach (DataRow objDr in dtTemp.Rows)
            {
                Add(new AccountBiz(objDr));
            }
        }
        #region Private Method
        void SetLinearCol(ref AccountCol objAccountCol, AccountBiz objAccountBiz)
        {
            if (_TempAccountTable[objAccountBiz.ID.ToString()] != null)
                return;
            _TempAccountTable.Add(objAccountBiz.ID.ToString(), objAccountBiz);
            objAccountCol.Add(objAccountBiz);
            if (objAccountBiz.Children == null || objAccountBiz.Children.Count == 0)
                return;
            foreach (AccountBiz objBiz in objAccountBiz.Children)
            {
                SetLinearCol(ref objAccountCol, objBiz);
            }
        }
        void SetChildren(string strAccountIDs, ref DataTable dtAccounts)
        {
            if (strAccountIDs == "")
                return;
            AccountBiz objParentAccountBiz;
            DataRow[] arrDR = dtAccounts.Select("AccountID <> AccountParentID " +
                " and AccountParentID in (" + strAccountIDs + ") ", "");
            AccountBiz objAccountBiz;
            AccountCol objAccountCol;
            objAccountCol = new AccountCol(true);
            strAccountIDs = "";
            int intLevel = 0;
            foreach (DataRow DR in arrDR)
            {
                objAccountBiz = new AccountBiz(DR);
                intLevel =objAccountBiz.Level;
                if (_TempAccountTable[objAccountBiz.ID.ToString()] != null)
                    continue;
                if (strAccountIDs != "")
                    strAccountIDs = strAccountIDs + ",";
                strAccountIDs = strAccountIDs + objAccountBiz.ID.ToString();
                objParentAccountBiz = (AccountBiz)_TempAccountTable[objAccountBiz.ParentID.ToString()];
                objParentAccountBiz.Children.Add(objAccountBiz);
                objAccountBiz.Children = new AccountCol(true);
                _TempAccountTable.Add(objAccountBiz.ID.ToString(), objAccountBiz);
                objAccountBiz.ParentBiz = objParentAccountBiz;
            }
            if (intLevel < SysData.CodeLevelArr.Count)  
            SetChildren(strAccountIDs, ref dtAccounts);

        }
        void SetChildren(ref AccountBiz objAccountBiz, ref DataTable dtAccounts)
        {
            objAccountBiz.Children = new AccountCol(true);
            //objAccountBiz.Children.RootBiz = objAccountBiz;
            DataRow[] arrDR = dtAccounts.Select("AccountID <> AccountParentID and AccountParentID=" + objAccountBiz.ID);
            AccountBiz tempAccountBiz;
            AccountCol objAccountCol;
            objAccountCol = new AccountCol(true);
            int intTemp = 0;

            foreach (DataRow DR in arrDR)
            {

                tempAccountBiz = new AccountBiz(DR);

                if (intTemp == tempAccountBiz.ID)
                    continue;
                else
                {

                    intTemp = tempAccountBiz.ID;
                    SetChildren(ref tempAccountBiz, ref dtAccounts);
                    tempAccountBiz.ParentBiz = objAccountBiz;
                    objAccountCol.Add(tempAccountBiz);


                }
                objAccountBiz.Children = objAccountCol;

            }
        }
        void SetChildrenCol(ref AccountCol objAccountCol, string strAccount, AccountBiz objAccountBiz)
        {
           // strAccount = SysUtility.ReverseString(strAccount );
            string[] arrStr = strAccount.Split('-');
            if (arrStr.Length <= 1)
            {
                arrStr = strAccount.Split('%');
                bool blIsOk = true;

                blIsOk = true;
                foreach (string strTemp in arrStr)
                {
                    if (SysUtility.ReplaceStringComp(objAccountBiz.Name).IndexOf(
                        SysUtility.ReplaceStringComp(strTemp), StringComparison.OrdinalIgnoreCase) == -1 &&
                        SysUtility.ReplaceStringComp(objAccountBiz.Code).IndexOf(
                        SysUtility.ReplaceStringComp(strTemp), StringComparison.OrdinalIgnoreCase) == -1)
                    {
                        blIsOk = false;
                        break;

                    }
                }
                if (blIsOk)
                    objAccountCol.Add(objAccountBiz);
                else
                {
                    if (objAccountBiz.Children != null)
                    {
                        foreach (AccountBiz objBiz in objAccountBiz.Children)
                        {
                            SetChildrenCol(ref objAccountCol, strAccount, objBiz);
                        }
                    }
                }
            }
            else 
            {
                int intL1 = 0;
                int intL2 = 0;
                int intL3 = 0;
                int intL4 = 0;
                if (arrStr.Length >= 1)
                {
                    try
                    {
                        intL1 = int.Parse(arrStr[0]);
                    }
                    catch { }
                }
                if (arrStr.Length >= 2)
                {
                    try
                    {
                        intL2 = int.Parse(arrStr[1]);
                    }
                    catch { }
                }
                if (arrStr.Length >= 3)
                {
                    try
                    {
                        intL3 = int.Parse(arrStr[2]);
                    }
                    catch { }
                }
                if (arrStr.Length >= 4)
                {
                    try
                    {
                        intL4 = int.Parse(arrStr[3]);
                    }
                    catch { }
                }
                int intLevel = 0;
                if (intL4 == 0 && intL3 == 0 && intL2 == 0)
                    intLevel = 1;
                else if (intL4 == 0 && intL3 == 0)
                    intLevel = 2;
                else if (intL4 == 0)
                    intLevel = 3;
                else
                    intLevel = 4;
                foreach (AccountBiz objbiz in objAccountBiz.Children)
                {
                    try
                    {

                         

                        if (((intL1 == 0 || intL1 == int.Parse(objbiz.CodeL1)) && objbiz.Level == 1)
                            || ((intL2==0 || intL2 == int.Parse(objbiz.CodeL2)) && objbiz.Level == 2) ||
                            ((intL3 == 0 || intL3 == int.Parse(objbiz.CodeL3)) && objbiz.Level == 3)
                            ||((intL4 == 0 || intL4 == int.Parse(objbiz.CodeL4)) && objbiz.Level == 4))
                        {
                            if(intLevel == objbiz.Level)
                               objAccountCol.Add(objbiz);
                            SetChildrenCol(ref objAccountCol, strAccount, objbiz);
                        }

                    }
                    catch { }

                }
            }
        }
        #endregion
        public AccountBiz this[int intIndex]
        {

            get
            {
                return (AccountBiz)List[intIndex];
            }
        }
        public AccountCol LinearCol
        {
            get
            {
                AccountCol Returned = new AccountCol(true);
               _TempAccountTable = new Hashtable();
                foreach (AccountBiz objBiz in this)
                {
                   if(_TempAccountTable[objBiz.ID.ToString()]== null)
                       SetLinearCol(ref Returned, objBiz);
                }
                return Returned;
            }
        }
        public AccountCol NodeCol
        {
            get 
            {
                AccountCol Returned = new AccountCol(true);
                AccountCol objLinearCol = LinearCol;
                foreach (AccountBiz objBiz in objLinearCol)
                {
                    if (objBiz.AccountLevel == 4)
                        Returned.Add(objBiz);
                }
                return Returned;
            }
 
        }
        public DataTable DataTable
        {
            get
            {
                return GetTable();
            }
        }
        public int GetIndex(int intID)
        {
            int intIndex = 0;
            foreach (AccountBiz objBiz in this)
            {

                if (objBiz.ID == intID)
                {
                    return intIndex;
 
                }
                    intIndex++;
            }
            return -1;
        }

        public void Add(AccountBiz objBiz)
        {
            List.Add(objBiz);

        }
        public DataTable GetTable()
        {
            DataTable Returned = new DataTable();
            Returned.Columns.AddRange(new DataColumn[] { new DataColumn("AccountID"), new DataColumn("AccountCode"),
                new DataColumn("AccountLevel"), new DataColumn("AccountNameA"),new DataColumn("AccountNameE"),new DataColumn("AccountIsClosing"),
                new DataColumn("AccountIsSecondary"),new DataColumn("AccountIsLeaf"),new DataColumn("AccountFamilyID") ,new DataColumn("AccountParentID"),
                new DataColumn("AccountDirection"),new DataColumn("AccountStatus"),
            new DataColumn("BalanceDesc"),new DataColumn("BalanceCredit"),new DataColumn("BalanceDebit")});
            DataRow objDR;
            foreach (AccountBiz objAccountBiz in this)
            {
                objDR = Returned.NewRow();
                objDR["AccountID"] = objAccountBiz.ID;
                objDR["AccountCode"] = objAccountBiz.Code;
                objDR["AccountLevel"] = objAccountBiz.Level;
                objDR["AccountNameA"] = objAccountBiz.NameA;
                objDR["AccountNameE"] = objAccountBiz.NameE;
                objDR["AccountIsClosing"] = objAccountBiz.IsClosing;
                objDR["AccountIsSecondary"] = objAccountBiz.IsSecondary;
                objDR["AccountIsLeaf"] = objAccountBiz.IsLeaf;
                objDR["AccountFamilyID"] = objAccountBiz.FamilyID;
                objDR["AccountParentID"] = objAccountBiz.ParentID;
                objDR["AccountDirection"] = objAccountBiz.Direction;
                objDR["AccountStatus"] = objAccountBiz.Status;
                objDR["BalanceDesc"] = objAccountBiz.BalanceDesc;
                objDR["BalanceCredit"] = objAccountBiz.CreditBalance;
                objDR["BalanceDebit"] = objAccountBiz.DebitBalance;
                Returned.Rows.Add(objDR);
            }
            return Returned;
        }
        public AccountCol GetAccountCol(string strCode, string strName)
        {
            AccountCol Returned = new AccountCol(true);
            foreach (AccountBiz objBiz in this)
            {
                if (objBiz.Name.IndexOf(strName) != -1 && objBiz.Code.IndexOf(strCode) != -1)
                    Returned.Add(objBiz);
            }
            return Returned;
        }
        public AccountCol GetAccountCol(string strAccountName)
        {
             
            AccountCol Returned = new AccountCol(true);
            //strAccountName = SysUtility.ReverseString(strAccountName);
            string strReverseName =  strAccountName ;
            string[] arrStr = strReverseName.Split('-');
             bool blIsOk = true;
             if (arrStr.Length <= 1)
             {
                 arrStr = strAccountName.Split('%');

                 foreach (AccountBiz objAccountbiz in this)
                 {
                     blIsOk = true;
                     foreach (string strTemp in arrStr)
                     {
                         if (SysUtility.ReplaceStringComp(objAccountbiz.Name).IndexOf(
                             SysUtility.ReplaceStringComp(strTemp), StringComparison.OrdinalIgnoreCase) == -1 &&
                             SysUtility.ReplaceStringComp(objAccountbiz.Code).IndexOf(
                             SysUtility.ReplaceStringComp(strTemp), StringComparison.OrdinalIgnoreCase) == -1)
                         {
                             blIsOk = false;
                             break;

                         }
                     }
                     if (blIsOk)
                         Returned.Add(objAccountbiz);
                     else
                         SetChildrenCol(ref Returned, strAccountName, objAccountbiz);
                 }
             }
             else
             {
                 int intL1 = 0;
                 int intL2 = 0;
                 int intL3 = 0;
                 int intL4 = 0;
                 
                 if (arrStr.Length >= 1)
                 {
                     try
                     {
                         intL1 = int.Parse(arrStr[0]);
                     }
                     catch { }
                 }
                 if (arrStr.Length >= 2)
                 {
                     try
                     {
                         intL2 = int.Parse(arrStr[1]);
                     }
                     catch { }
                 }
                 if (arrStr.Length >= 3)
                 {
                     try
                     {
                         intL3 = int.Parse(arrStr[2]);
                     }
                     catch { }
                 }
                 if (arrStr.Length >= 4)
                 {
                     try
                     {
                         intL4 = int.Parse(arrStr[3]);
                     }
                     catch { }
                 }
                 int intLevel = intL2==0&&intL3==0&&intL4 == 0 ? 1 :(intL3 == 0 && intL4 == 0 ? 2 : (intL4== 0 ? 3 :4));
                 foreach (AccountBiz objAccountbiz in this)
                 {
                     try
                     {
                         //if((intL1 == int.Parse(objAccountbiz.CodeL1) && objAccountbiz.Level == 1) &&
                         //    intL2 == 0&& intL3 == 0 && intL4 == 0)
                         if (intL1 == int.Parse(objAccountbiz.CodeL1) &&( intL2 == int.Parse(objAccountbiz.CodeL2)|| intL2 == 0) &&
                             (intL3 == int.Parse(objAccountbiz.CodeL3) || intL3 == 0) &&  (intL4 == int.Parse(objAccountbiz.CodeL4) || intL4 ==0)&&
                             objAccountbiz.Level >= intLevel) 
                             Returned.Add(objAccountbiz);
                         if ((intL1 == int.Parse(objAccountbiz.CodeL1) && objAccountbiz.Level == 1)
                             ||(intL2 == int.Parse(objAccountbiz.CodeL2) && objAccountbiz.Level ==2) ||
                             (intL3 == int.Parse(objAccountbiz.CodeL3) && objAccountbiz.Level ==3)
                             || (intL4 == int.Parse(objAccountbiz.CodeL4) && objAccountbiz.Level ==4))
                         {
                             
                             SetChildrenCol(ref Returned, strReverseName, objAccountbiz);
                         }

                     }
                     catch { }

                 }
             }
            return Returned;
        }
        public AccountCol GetAccountColByCode(string strAccountName)
        {

            AccountCol Returned = new AccountCol(true);
            strAccountName = SysUtility.ReverseString(strAccountName,char.Parse(""));
            string[] arrStr = strAccountName.Split('-');
            bool blIsOk = true;
          
            if(arrStr.Length > 0)
            {
                int intL1 = 0;
                int intL2 = 0;
                int intL3 = 0;
                int intL4 = 0;

                if (arrStr.Length >= 1)
                {
                    try
                    {
                        intL1 = int.Parse(arrStr[0]);
                    }
                    catch { }
                }
                if (arrStr.Length >= 2)
                {
                    try
                    {
                        intL2 = int.Parse(arrStr[1]);
                    }
                    catch { }
                }
                if (arrStr.Length >= 3)
                {
                    try
                    {
                        intL3 = int.Parse(arrStr[2]);
                    }
                    catch { }
                }
                if (arrStr.Length >= 4)
                {
                    try
                    {
                        intL4 = int.Parse(arrStr[3]);
                    }
                    catch { }
                }
                foreach (AccountBiz objAccountbiz in this)
                {
                    try
                    {
                        //if ((intL1 == int.Parse(objAccountbiz.CodeL1) || intL1 == 0)
                        //    && (intL2 == int.Parse(objAccountbiz.CodeL2) || intL2 == 0) &&
                        //    (intL3 == int.Parse(objAccountbiz.CodeL3) || intL3 == 0)
                        //    && (intL4 == int.Parse(objAccountbiz.CodeL4) || intL4 == 0))
                        if ((intL1 == int.Parse(objAccountbiz.CodeL1) && objAccountbiz.Level == 1)
                           && (intL2 == int.Parse(objAccountbiz.CodeL2) && objAccountbiz.Level == 2) &&
                            (intL3 == int.Parse(objAccountbiz.CodeL3) && objAccountbiz.Level == 3)
                            && (intL4 == int.Parse(objAccountbiz.CodeL4) && objAccountbiz.Level == 4))
                        {
                            Returned.Add(objAccountbiz);
                            SetChildrenCol(ref Returned, strAccountName, objAccountbiz);
                        }

                    }
                    catch { }

                }
            }
            return Returned;
        }
        public AccountCol GetLevelAccountCol(int intLevel)
        {
            
                AccountCol Returned = new AccountCol(true);
                AccountCol objLinearCol = LinearCol;
                foreach (AccountBiz objBiz in objLinearCol)
                {
                    if (objBiz.AccountLevel == intLevel)
                        Returned.Add(objBiz);
                }
                return Returned;
           

        }
        public AccountCol GetNodeAccountCol(string strStartCode, string strEndCode)
        {
            AccountCol Returned = new AccountCol(true);
            AccountCol objCol = NodeCol;
            int intStartL1 = 0, intStartL2 = 0, intStartL3 = 0, intStartL4 = 0;
            int intEndL1 = 0, intEndL2 = 0, intEndL3 = 0, intEndL4 = 0;
            try
            {
                intStartL1 = int.Parse(SysData.GetAccountLevelCod(1, strStartCode));
            }
            catch
            { }
            try
            {
                intStartL2 = int.Parse(SysData.GetAccountLevelCod(2, strStartCode));
            }
            catch
            { }
            try
            {
                intStartL3 = int.Parse(SysData.GetAccountLevelCod(3, strStartCode));
            }
            catch
            { }
            try
            {
                intStartL4 = int.Parse(SysData.GetAccountLevelCod(4, strStartCode));
            }
            catch
            { }
            try
            {
                intEndL1 = int.Parse(SysData.GetAccountLevelCod(1, strEndCode));
            }
            catch
            { }
            try
            {
                intEndL2 = int.Parse(SysData.GetAccountLevelCod(2, strEndCode));
            }
            catch
            { }
            try
            {
                intEndL3 = int.Parse(SysData.GetAccountLevelCod(3, strEndCode));
            }
            catch
            { }
            try
            {
                intEndL4 = int.Parse(SysData.GetAccountLevelCod(4, strEndCode));
            }
            catch
            { }

            return Returned;
        }
        public string GetNewAccountLevelCode(int intLevel)
        {
            string Returned = "";
            AccountCol objCol = GetLevelAccountCol(intLevel);
            double dblTemp = 0;
            double dblMax = 0;
            string strTempLevel = "";
            string strTempCode = "";
            foreach (AccountBiz objBiz in objCol)
            {
                try
                {
                    strTempLevel = SysData.GetAccountLevelCod(intLevel, objBiz.Code);
                    dblTemp = double.Parse(strTempLevel);
                    if (dblTemp > dblMax)
                    {
                        dblMax = dblTemp;
                        strTempCode = objBiz.Code;
                    }
                }
                catch
                {

                }
            }
            dblMax++;
            Returned = dblMax.ToString();
            return Returned;
        }
        public string GetNewAccountCode(int intLevel)
        {
            string Returned = "";
            AccountCol objCol = GetLevelAccountCol(intLevel);
            double dblTemp = 0;
            double dblMax = 0;
            string strTempLevel = "";
            string strTempCode = "";
            foreach (AccountBiz objBiz in objCol)
            {
                try
                {
                     strTempLevel = SysData.GetAccountLevelCod(intLevel, objBiz.Code);
                     dblTemp = double.Parse(strTempLevel);
                     if (dblTemp > dblMax)
                     {
                         dblMax = dblTemp;
                         strTempCode = objBiz.Code;
                     }
                }
                catch
                {
 
                }
            }
            for (int intIndex = 1; intIndex < intLevel; intIndex++)
            {
 
            }
            return Returned;
        }
        public void EditBalance()
        {
            DataTable dtTemp = GetTable();
            AccountDb objDb = new AccountDb();
            objDb.AccountTable = dtTemp;
            objDb.EditBalance();
        }
        public void InsertGeneralPurposedAccount()
        {
            DataTable dtTemp = GetTable();
            AccountDb objDb = new AccountDb();
            objDb.AccountTable = GetTable();
            objDb.InsertPredefinedContractingAccount();
  
        }
        public void InsertGeneralPurposedReservationAccount()
        {
            DataTable dtTemp = GetTable();
            AccountDb objDb = new AccountDb();
            objDb.AccountTable = GetTable();
            objDb.InsertPredefinedReservationAccount();

        }
        public static AccountCol GetLinearAccountCol()
        {
            AccountDb objAccountDb = new AccountDb();
            DataTable dtAccount = objAccountDb.Search();
            AccountCol Returned = new AccountCol(true);
            foreach (DataRow objDr in dtAccount.Rows)
            {
                Returned.Add(new AccountBiz(objDr));
            }
            return Returned;
        }
    }
}
