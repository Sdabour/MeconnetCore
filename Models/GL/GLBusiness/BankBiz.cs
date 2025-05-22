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
    public class BankBiz : BaseSelfeRelatedBiz
    {
        #region Private Data
        AccountBankCol _AccountCol;
        #endregion

        #region Constructors
        public BankBiz()
        {
            _BaseDb = new BankDb();
        }
        public BankBiz(int intID)
        {
            DataRow[] arrDr = BankDb.BankTable.Select("BankID=" + intID);
            if (arrDr.Length > 0)
            {
                _BaseDb = new BankDb(arrDr[0]);
            }
            else
                _BaseDb = new BankDb();
        }
        public BankBiz(DataRow objDR)
        {
            _BaseDb = new BankDb(objDR);
        }
        #endregion

        #region Public Properties
        public bool IsVirtual
        {
            set
            {
                ((BankDb)_BaseDb).IsVirtual = value;
            }
            get
            {
                return ((BankDb)_BaseDb).IsVirtual;
            }
        }

        public BankCol Children
        {
            set
            {
                _Children = value;
            }
            get
            {
                if (_Children == null)
                {
                    //((BankDb)_BaseDb).Level = Level;
                    _Children = new BankCol(ID, ((BankDb)_BaseDb).GetChildrenTable());

                }
                return (BankCol)_Children;
            }
        }
        public AccountBankCol AccountCol
        {
            set
            {
                _AccountCol = value;
            }
            get
            {
                if (_AccountCol == null)
                {
                    _AccountCol = new AccountBankCol(true);
                    if (ID != 0)
                    {
                        AccountBankBiz objBiz;
                        AccountBankDb objDb = new AccountBankDb();
                        objDb.Bank = ID;
                        DataTable dtTemp = objDb.Search();
                        foreach (DataRow objDr in dtTemp.Rows)
                        {
                            objBiz = new AccountBankBiz(objDr);
                            _AccountCol.Add(objBiz);

                        }
                    }
                }
                return _AccountCol;
            }
        }
        public static BankCol NonVirtualBankCol
        {
            get
            {
                BankCol Returned = new BankCol(true);
                BankBiz objTemp = new BankBiz();
                objTemp.NameA = "غير محدد";
                objTemp.NameE = "Not Specified";
                Returned.Add(objTemp);
                DataRow[] arrDr = BankDb.BankTable.Select("dis is null and  BankIsVirtual=0");
                foreach (DataRow objDr in arrDr)
                {
                    Returned.Add(new BankBiz(objDr));
                }
                return Returned;
            }
        }
        public static BankCol VirtualBankCol
        {
            get
            {
                BankCol Returned = new BankCol(true);
                BankBiz objTemp = new BankBiz();
                objTemp.NameA = "غير محدد";
                objTemp.NameE = "Not Specified";
                Returned.Add(objTemp);
                DataRow[] arrDr = BankDb.BankTable.Select("dis is null and BankIsVirtual=1");
                foreach (DataRow objDr in arrDr)
                {
                    Returned.Add(new BankBiz(objDr));
                }
                return Returned;
            }
        }
        #endregion

        #region Private Methods

        #endregion

        #region Public Methods
        
        public void Add()
        {
            ((BankDb)_BaseDb).ParentID = ParentBiz.ID;
            ((BankDb)_BaseDb).FamilyID = ParentBiz.FamilyID;
            ((BankDb)_BaseDb).Add();
        }
        public void Edit()
        {
            ((BankDb)_BaseDb).ParentID = ParentBiz.ID;
            ((BankDb)_BaseDb).FamilyID = ParentBiz.FamilyID;
            ((BankDb)_BaseDb).Edit();
        }
        public void Delete()
        {
            ((BankDb)_BaseDb).Delete();
        }

        #endregion
    }
}
