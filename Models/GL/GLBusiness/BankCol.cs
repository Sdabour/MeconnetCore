using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.Base.BaseDataBase;
using SharpVision.Base.BaseBusiness;
using SharpVision.GL.GLDataBase;
using SharpVision.SystemBase;
using System.Collections;
namespace SharpVision.GL.GLBusiness
{
    public class BankCol : BaseCol
    {
        #region PrivateData
        BankBiz _RootBiz;
        static Hashtable _BankHS;
        public static Hashtable BankHS
        {
            get
            {
                if (_BankHS == null)
                {
                    _BankHS = new Hashtable();
                    BankDb objBankDb = new BankDb();
                    DataTable dtBank = objBankDb.Search();
                    DataRow[] arrDR = dtBank.Select("");
                    BankBiz objBankBiz;
                    BankBiz objTempParent = new BankBiz();

                    foreach (DataRow DR in arrDR)
                    {

                        objBankBiz = new BankBiz(DR);
                        if (_BankHS[objBankBiz.ID.ToString()] == null)
                            _BankHS.Add(objBankBiz.ID.ToString(), objBankBiz);




                    }


                }
                return _BankHS;
            }
        }
        #endregion
        #region Constructor
        public BankCol()
        {
            BankDb objBankDb = new BankDb();
            DataTable dtBank = objBankDb.Search();
            DataRow[] arrDR = dtBank.Select("Dis Is Null and BankID=BankParentID ");
            BankBiz objBankBiz;
            BankBiz objTempParent = new BankBiz();

            foreach (DataRow DR in arrDR)
            {

                objBankBiz = new BankBiz(DR);


                SetChildren(ref objBankBiz, ref dtBank);
                this.Add(objBankBiz);
                objBankBiz.ParentBiz = objBankBiz;

            }


        }
        public BankCol(bool blIsempty)
        {
            if (!blIsempty)
            {
                BankDb objDb = new BankDb();
                DataTable dtBank = objDb.Search();
                DataRow[] arrDR = dtBank.Select("Dis Is Null and BankID=BankParentID ");
                BankBiz objBankBiz;
                BankBiz objTempParent = new BankBiz();
                objBankBiz = new BankBiz();
                objBankBiz.NameA = "غير محدد";
                objBankBiz.NameE = "Not Specified";
                Add(objBankBiz);
                foreach (DataRow DR in arrDR)
                {

                    objBankBiz = new BankBiz(DR);


                    SetChildren(ref objBankBiz, ref dtBank);
                    this.Add(objBankBiz);
                    objBankBiz.ParentBiz = objBankBiz;

                }
            }
        }
        public BankCol(int intID)
        {
            BankDb objDb = new BankDb();
            objDb.ID = intID;
            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
            {
                Add(new BankBiz(objDr));
            }
        }

        internal BankCol(int intBankID, DataTable dtBank)
        {

            string strOrder = "BankOrder";


            DataRow[] arrDR = dtBank.Select("BankID<>" + intBankID + " and BankParentID=" + intBankID + " and Dis is null ");
            BankBiz objBankBiz;
            BankBiz objTempParent = new BankBiz();

            foreach (DataRow DR in arrDR)
            {
                objBankBiz = new BankBiz(DR);

                SetChildren(ref objBankBiz, ref dtBank);
                this.Add(objBankBiz);
                objBankBiz.ParentBiz = objTempParent;

            }

        }
        #endregion
        public BankBiz this[int intIndex]
        {

            get
            {
                return (BankBiz)List[intIndex];
            }
        }
        public string IDsStr
        {
            get
            {
                string Returned = "";
                foreach (BankBiz objBiz in this)
                {
                    if (Returned != "")
                        Returned += ",";
                    Returned += objBiz.ID.ToString();
                }
                return Returned;

            }
        }
        public BankBiz RootBiz
        {
            set
            {
                _RootBiz = value;
            }
        }
        #region Private Method

        void SetChildren(ref BankBiz objBankBiz, ref DataTable dtBanks)
        {
            objBankBiz.Children = new BankCol(true);
            //objBankBiz.Children.RootBiz = objBankBiz;
            DataRow[] arrDR = dtBanks.Select("Dis is null and BankID <> BankParentID and BankParentID=" + objBankBiz.ID);
            BankBiz tempBankBiz;
            BankCol objBankCol;
            objBankCol = new BankCol(true);
            int intTemp = 0;

            foreach (DataRow DR in arrDR)
            {

                tempBankBiz = new BankBiz(DR);

                if (intTemp == tempBankBiz.ID)
                    continue;
                else
                {

                    intTemp = tempBankBiz.ID;
                    SetChildren(ref tempBankBiz, ref dtBanks);
                    tempBankBiz.ParentBiz = objBankBiz;
                    objBankCol.Add(tempBankBiz);


                }
                objBankBiz.Children = objBankCol;

            }
        }
        void SetLinearCol(ref AccountTypeCol objAccountTypeCol, AccountTypeBiz objAccountTypeBiz)
        {
            objAccountTypeCol.Add(objAccountTypeBiz);
            if (objAccountTypeBiz.Children == null || objAccountTypeBiz.Children.Count == 0)
                return;
            foreach (AccountTypeBiz objBiz in objAccountTypeBiz.Children)
            {
                SetLinearCol(ref objAccountTypeCol, objBiz);
            }
        }
        void SetChildrenCol(ref BankCol objBankCol, string strBank, BankBiz objBankBiz)
        {
            string[] arrStr = strBank.Split('%');
            bool blIsOk = true;

            blIsOk = true;
            foreach (string strTemp in arrStr)
            {
                if (SysUtility.ReplaceStringEComp(objBankBiz.Name).IndexOf(
                    SysUtility.ReplaceStringEComp(strTemp)) == -1)
                {
                    blIsOk = false;
                    break;

                }
            }
            if (blIsOk)
                objBankCol.Add(objBankBiz);
            else
            {
                if (objBankBiz.Children != null)
                {
                    foreach (BankBiz objBiz in objBankBiz.Children)
                    {
                        SetChildrenCol(ref objBankCol, strBank, objBiz);
                    }
                }
            }
        }
        #endregion
        #region Public Method
        public void Add(BankBiz objBiz)
        {
            if (GetIndex(objBiz) == -1)
                List.Add(objBiz);

        }
        public int GetIndex(BankBiz objBiz)
        {
            for (int intIndex = 0; intIndex < Count; intIndex++)
            {
                if (this[intIndex].ID == objBiz.ID && objBiz.ID != 0)
                {
                    return intIndex;
                }
            }
            return -1;
        }
        public BankCol GetBankCol(string strBankName)
        {

            BankCol Returned = new BankCol(true);
            string[] arrStr = strBankName.Split('%');
            bool blIsOk = true;
            foreach (BankBiz objBankbiz in this)
            {
                blIsOk = true;
                foreach (string strTemp in arrStr)
                {
                    if (SysUtility.ReplaceStringEComp(objBankbiz.Name).IndexOf(
                        SysUtility.ReplaceStringEComp(strTemp)) == -1)
                    {
                        blIsOk = false;
                        break;

                    }
                }
                if (blIsOk)
                    Returned.Add(objBankbiz);
                else
                    SetChildrenCol(ref Returned, strBankName, objBankbiz);
            }

            return Returned;
        }
        public void SetBankAccountCol()
        {
            DataRow[] arrDr;
            AccountBankDb objDb = new AccountBankDb();
            objDb.BankIDs = IDsStr;

            DataTable dtTemp = objDb.Search();
            AccountBankBiz objAccountBiz = new AccountBankBiz();

            foreach (BankBiz objBiz in this)
            {
                arrDr = dtTemp.Select("BankID=" + objBiz.ID);
                objBiz.AccountCol = new AccountBankCol(true);
                objAccountBiz = new AccountBankBiz();
                objAccountBiz.Desc = "غير محدد";
                objBiz.AccountCol.Add(objAccountBiz);
                foreach (DataRow objDr in arrDr)
                {
                    objBiz.AccountCol.Add(new AccountBankBiz(objDr));
                }
            }
        }
        public BankCol Copy()
        {
            BankCol Returned = new BankCol(true);
            foreach (BankBiz objBiz in this)
            {
                Returned.Add(objBiz);
            }
            return Returned;
        }
        #endregion



    }
}
