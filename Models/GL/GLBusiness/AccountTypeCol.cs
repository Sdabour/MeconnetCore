using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.Base.BaseDataBase;
using SharpVision.Base.BaseBusiness;
using SharpVision.GL.GLDataBase;
using SharpVision.SystemBase;

namespace SharpVision.GL.GLBusiness
{
    public class AccountTypeCol : BaseCol
    {
        #region PrivateData
        AccountTypeBiz _RootBiz;
        #endregion
        #region Constructor
        public AccountTypeCol()
        {
            AccountTypeDb objAccountTypeDb = new AccountTypeDb();
            DataTable dtAccountType = objAccountTypeDb.Search();
            DataRow[] arrDR = dtAccountType.Select("Dis Is Null and AccountTypeID=AccountTypeParentID ");
            AccountTypeBiz objAccountTypeBiz;
            AccountTypeBiz objTempParent = new AccountTypeBiz();

            foreach (DataRow DR in arrDR)
            {

                objAccountTypeBiz = new AccountTypeBiz(DR);


                SetChildren(ref objAccountTypeBiz, ref dtAccountType);
                this.Add(objAccountTypeBiz);
                objAccountTypeBiz.ParentBiz = objAccountTypeBiz;

            }


        }
        public AccountTypeCol(bool blIsempty)
        {
            if (!blIsempty)
            {
                AccountTypeDb objDb = new AccountTypeDb();
                DataTable dtAccountType = objDb.Search();
                DataRow[] arrDR = dtAccountType.Select("Dis Is Null and AccountTypeID=AccountTypeParentID ");
                AccountTypeBiz objAccountTypeBiz;
                AccountTypeBiz objTempParent = new AccountTypeBiz();
                objAccountTypeBiz = new AccountTypeBiz();
                objAccountTypeBiz.NameA = "€Ì— „Õœœ";
                objAccountTypeBiz.NameE = "Not Specified";
                Add(objAccountTypeBiz);
                foreach (DataRow DR in arrDR)
                {

                    objAccountTypeBiz = new AccountTypeBiz(DR);


                    SetChildren(ref objAccountTypeBiz, ref dtAccountType);
                    this.Add(objAccountTypeBiz);
                    objAccountTypeBiz.ParentBiz = objAccountTypeBiz;

                }
            }
        }
        public AccountTypeCol(int intID)
        {
            AccountTypeDb objDb = new AccountTypeDb();
            objDb.ID = intID;
            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
            {
                Add(new AccountTypeBiz(objDr));
            }
        }

        internal AccountTypeCol(int intAccountTypeID, DataTable dtAccountType)
        {

            string strOrder = "AccountTypeOrder";


            DataRow[] arrDR = dtAccountType.Select("AccountTypeID<>" + intAccountTypeID + " and AccountTypeParentID=" + intAccountTypeID + " and Dis is null ");
            AccountTypeBiz objAccountTypeBiz;
            AccountTypeBiz objTempParent = new AccountTypeBiz();

            foreach (DataRow DR in arrDR)
            {
                objAccountTypeBiz = new AccountTypeBiz(DR);

                SetChildren(ref objAccountTypeBiz, ref dtAccountType);
                this.Add(objAccountTypeBiz);
                objAccountTypeBiz.ParentBiz = objTempParent;

            }

        }
        #endregion
        public AccountTypeBiz this[int intIndex]
        {

            get
            {
                return (AccountTypeBiz)List[intIndex];
            }
        }
        public string IDsStr
        {
            get
            {
                string Returned = "";
                foreach (AccountTypeBiz objBiz in this)
                {
                    if (Returned != "")
                        Returned += ",";
                    Returned += objBiz.ID.ToString();
                }
                return Returned;

            }
        }
        public AccountTypeBiz RootBiz
        {
            set
            {
                _RootBiz = value;
            }
        }
        public AccountTypeCol LinearCol
        {
            get
            {
               AccountTypeCol Returned = new AccountTypeCol(true);
                foreach (AccountTypeBiz objBiz in this)
                {
                    SetLinearCol(ref Returned, objBiz);
                }
                return Returned;

            }
        }
        #region Private Method
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
        void SetChildren(ref AccountTypeBiz objAccountTypeBiz, ref DataTable dtAccountTypes)
        {
            objAccountTypeBiz.Children = new AccountTypeCol(true);
            //objAccountTypeBiz.Children.RootBiz = objAccountTypeBiz;
            DataRow[] arrDR = dtAccountTypes.Select("Dis is null and AccountTypeID <> AccountTypeParentID and AccountTypeParentID=" + objAccountTypeBiz.ID);
            AccountTypeBiz tempAccountTypeBiz;
            AccountTypeCol objAccountTypeCol;
            objAccountTypeCol = new AccountTypeCol(true);
            int intTemp = 0;

            foreach (DataRow DR in arrDR)
            {

                tempAccountTypeBiz = new AccountTypeBiz(DR);

                if (intTemp == tempAccountTypeBiz.ID)
                    continue;
                else
                {

                    intTemp = tempAccountTypeBiz.ID;
                    SetChildren(ref tempAccountTypeBiz, ref dtAccountTypes);
                    tempAccountTypeBiz.ParentBiz = objAccountTypeBiz;
                    objAccountTypeCol.Add(tempAccountTypeBiz);


                }
                objAccountTypeBiz.Children = objAccountTypeCol;

            }
        }
        void SetChildrenCol(ref AccountTypeCol objAccountTypeCol, string strAccountType, AccountTypeBiz objAccountTypeBiz)
        {
            string[] arrStr = strAccountType.Split('%');
            bool blIsOk = true;

            blIsOk = true;
            foreach (string strTemp in arrStr)
            {
                if (SysUtility.ReplaceStringEComp(objAccountTypeBiz.Name).IndexOf(
                    SysUtility.ReplaceStringEComp(strTemp)) == -1)
                {
                    blIsOk = false;
                    break;

                }
            }
            if (blIsOk)
                objAccountTypeCol.Add(objAccountTypeBiz);
            else
            {
                if (objAccountTypeBiz.Children != null)
                {
                    foreach (AccountTypeBiz objBiz in objAccountTypeBiz.Children)
                    {
                        SetChildrenCol(ref objAccountTypeCol, strAccountType, objBiz);
                    }
                }
            }
        }
        #endregion
        #region Public Method
        public void Add(AccountTypeBiz objBiz)
        {
            if (GetIndex(objBiz) == -1)
                List.Add(objBiz);

        }
        public int GetIndex(AccountTypeBiz objBiz)
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
        public AccountTypeCol GetAccountTypeCol(string strAccountTypeName)
        {

            AccountTypeCol Returned = new AccountTypeCol(true);
            string[] arrStr = strAccountTypeName.Split('%');
            bool blIsOk = true;
            foreach (AccountTypeBiz objAccountTypebiz in this)
            {
                blIsOk = true;
                foreach (string strTemp in arrStr)
                {
                    if (SysUtility.ReplaceStringEComp(objAccountTypebiz.Name).IndexOf(
                        SysUtility.ReplaceStringEComp(strTemp)) == -1)
                    {
                        blIsOk = false;
                        break;

                    }
                }
                if (blIsOk)
                    Returned.Add(objAccountTypebiz);
                else
                    SetChildrenCol(ref Returned, strAccountTypeName, objAccountTypebiz);
            }

            return Returned;
        }

        #endregion



    }
}
