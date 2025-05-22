using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.Base.BaseDataBase;
using SharpVision.Base.BaseBusiness;
using SharpVision.GL.GLDataBase;
using SharpVision.SystemBase;
using SharpVision.COMMON.COMMONBusiness;
namespace SharpVision.GL.GLBusiness
{
    public class AccountBankCol : BaseCol
    {
        public AccountBankCol(bool blIsempty)
        {

        }
        public AccountBankCol(BankBiz objBankBiz,string strCode,string strOwnerName,
            string strDesc,CurrencyBiz objCurrencyBiz,BankAccountType objType,string strBankIDs)
        {
            if (objBankBiz == null)
                objBankBiz = new BankBiz();
            if (objCurrencyBiz == null)
                objCurrencyBiz = new CurrencyBiz();
            AccountBankDb objDb = new AccountBankDb();

            objDb.Bank = objBankBiz.ID;
            objDb.BankIDs = strBankIDs;
            if (strBankIDs != null && strBankIDs != "")
                objDb.Bank = 0;
            objDb.Code = strCode;
            objDb.Currency = objCurrencyBiz.ID;
            objDb.Desc = strDesc;
            objDb.OwnerName = strOwnerName;
            objDb.Type = (int)objType;
            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
            {
                Add(new AccountBankBiz(objDr));
            }

           
        }

        public AccountBankBiz this[int intIndex]
        {
           
            get
            {
                return (AccountBankBiz)List[intIndex];
            }
        }
        public string IDsStr
        {
            get
            {
                string Returned = "";
                foreach (AccountBankBiz objBiz in this)
                {
                    if (Returned != "")
                        Returned += ",";
                    Returned += objBiz.ID.ToString();
                }
                return Returned;
            }
        }
        public void Add(AccountBankBiz objBiz)
        {
            List.Add(objBiz);
 
        }
        public AccountBankCol GetAccountBankCredited()
        {
            AccountBankCol Returned = new AccountBankCol(true);
            AccountBankDb objDb = new AccountBankDb();
            objDb.HasMaxDate = true;
            objDb.EndDate = DateTime.Now;
            DataTable dtCheck = objDb.GetAccountCheckCredit();
            BankAccountTransactionDb objTransactionDb = new BankAccountTransactionDb();
            objTransactionDb.HasMaxDate = true;
            objTransactionDb.EndDate = DateTime.Now;
            DataTable dtAccountTransaction = objTransactionDb.AccountCounting;
            DataRow[] arrDr;
            foreach (AccountBankBiz objBiz in this)
            {
                arrDr = dtCheck.Select("CheckBankAccount=" + objBiz.ID, "");
                if (arrDr.Length > 0)
                    objBiz.CheckCredit =double.Parse( arrDr[0]["TotalOutValue"].ToString());
                arrDr = dtAccountTransaction.Select("TransactionAccount="+objBiz.ID, "");
                if (arrDr.Length > 0)
                    objBiz.Credit = double.Parse(arrDr[0]["CreditValue"].ToString());
                Returned.Add(objBiz);
            }
            return Returned;

        }
    }
}
