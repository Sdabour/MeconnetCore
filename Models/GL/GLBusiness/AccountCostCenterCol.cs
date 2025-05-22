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
    public class AccountCostCenterCol:BaseCol
    {
        #region Private Data
      
        #endregion
        #region Constructors
        public AccountCostCenterCol(bool blIsEmpty)
        { }
        #endregion
        #region Public Properties
        public AccountCostCenterBiz this[int intIndex]
        {
            get
            {
                return (AccountCostCenterBiz)List[intIndex];
            }
        }
        public CostCenterCol CostCenterCol
        {
            get
            {
                CostCenterCol Returned = new CostCenterCol(true);
                foreach (AccountCostCenterBiz objBiz in this)
                {
                    Returned.Add(objBiz.CostCenterBiz);
                }
                return Returned;
            }
        }
        #endregion
        #region Private Methods
       
        #endregion
        #region Public Methods
        public void Add(AccountCostCenterBiz objBiz)
        {
            List.Add(objBiz);
        }
        public DataTable GetTable()
        {
            DataTable Returned = new DataTable();
            Returned.Columns.AddRange(new DataColumn[] { new DataColumn("AccountCostCenterID"),
                new DataColumn("AccountID") ,new DataColumn("CostCenterID"),
                new DataColumn("IsStopped",Type.GetType("System.Boolean")),new DataColumn("Debit"),new DataColumn("Credit"),new DataColumn("BalanceDesc")});
            DataRow objDr;

            foreach (AccountCostCenterBiz objBiz in this)
            {
                objDr = Returned.NewRow();
                objDr["AccountCostCenterID"] = objBiz.ID;
                objDr["AccountID"] = objBiz.AccountBiz.ID;
                objDr["CostCenterID"] = objBiz.CostCenterBiz.ID;
                objDr["IsStopped"] = objBiz.IsStopped;
                objDr["Debit"] = objBiz.Debit;
                objDr["Credit"] = objBiz.Credit;
                objDr["BalanceDesc"] = objBiz.BalanceDesc;
                Returned.Rows.Add(objDr);
            }        
            return Returned;
 
        }
        public AccountCostCenterCol GetAccountCostCenterCol(string strCode)
        {
            AccountCostCenterCol Returned = new AccountCostCenterCol(true);
            foreach (AccountCostCenterBiz objBiz in this)
            {
                if (objBiz.CostCenterBiz.CompareCodeString(strCode))
                    Returned.Add(objBiz);
            }
            return Returned;
        }
        public void EditBalance()
        {
            DataTable dtTemp = GetTable();
            AccountCostCenterDb objDb = new AccountCostCenterDb();
            objDb.AccountCostCenterTable = dtTemp;
            objDb.EditBalance();
        }
        #endregion
         
         
    }
}
