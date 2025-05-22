using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.COMMON.COMMONDataBase;
using SharpVision.Base.BaseBusiness;
using System.Data;
using System.Collections;
using SharpVision.SystemBase;
namespace SharpVision.COMMON.COMMONBusiness
{
    public class CurrencyCol : BaseCol
    {
        #region PrivateData
        #endregion

        public CurrencyCol()
        {
            CurrencyDb objCurrencyDb = new CurrencyDb();
            DataTable dtCurrency = objCurrencyDb.Search();
            CurrencyBiz objCurrencyBiz;
            foreach (DataRow objDR in dtCurrency.Rows)
            {
                Add(new CurrencyBiz(objDR));

            }
        }

       
        public CurrencyCol(bool blIsEmpty)
        {
            if (!blIsEmpty)
            {
                CurrencyBiz objBiz = new CurrencyBiz();
                objBiz.ID = 0;
                objBiz.NameA = "€Ì— „Õœœ";
                objBiz.NameE = "Not Specified";
                Add(objBiz);
                CurrencyDb objDb = new CurrencyDb();
                DataTable dtTemp = objDb.Search();
                foreach (DataRow objDr in dtTemp.Rows)
                {
                    Add(new CurrencyBiz(objDr));
                }
            }
        }
        public virtual CurrencyBiz this[int intIndex]
        {
            get
            {
                return (CurrencyBiz)this.List[intIndex];
            }
        }
        public virtual CurrencyBiz this[string strIndex]
        {
            get
            {
                CurrencyBiz Returned = new CurrencyBiz();
                foreach (CurrencyBiz objCurrencyBiz in this)
                {
                    if (objCurrencyBiz.Name == strIndex)
                    {
                        Returned = objCurrencyBiz;
                        break;
                    }
                }
                return Returned;
            }
        }
        static CurrencyCol _CacheCurrencyCol;
        public static CurrencyCol CacheCurrencyCol
        {
            get
            {
                if (_CacheCurrencyCol == null)
                    _CacheCurrencyCol = new CurrencyCol(false);
                return _CacheCurrencyCol;
            }
        }
        #region  Privaet methods
        #endregion
        public virtual void Add(CurrencyBiz objCurrencyBiz)
        {
            this.List.Add(objCurrencyBiz);
        }

        public virtual void Add(CurrencyCol objCurrencyCol)
        {
            foreach (CurrencyBiz objCurrencyBiz in objCurrencyCol)
            {
                if (this[objCurrencyBiz.Name].ID == 0)
                    this.List.Add(objCurrencyBiz.Copy());

            }
        }
        public int GetStandardID()
        {
            
            int ID = 0;
            foreach (CurrencyBiz objBiz in this)
            {
                if (objBiz.IsStanderd)
                {
                    ID = objBiz.ID;
                }
            }
            return ID;
        }
        public CurrencyBiz GetStandardCurrency()
        {

            CurrencyBiz Returned = new CurrencyBiz();
            foreach (CurrencyBiz objBiz in this)
            {
                if (objBiz.IsStanderd)
                {
                    Returned= objBiz;
                    break;
                }
            }
            return Returned;
        }
        public int GetIndexUsingCode(string strCode)
        {
            int intIndex = 0;
            foreach (CurrencyBiz objBiz in this)
            {
                if (objBiz.Code == strCode)
                    return intIndex;
                intIndex++;
            }
            return -1;

        }
        public CurrencyBiz GetCurrencyByID(int intCurrencyID)
        {
            CurrencyBiz Returned = new CurrencyBiz();
            foreach (CurrencyBiz objBiz in this)
            {
                if (objBiz.ID == intCurrencyID)
                {
                    Returned = objBiz;
                    break;
                }
            }
            return Returned;
        }
        public CurrencyCol GetCurrencyCol(string strName)
        {
            CurrencyCol Returned = new CurrencyCol(true);
            foreach (CurrencyBiz objBiz in this)
            {
                if (objBiz.Code.IndexOf(strName) != -1 || objBiz.Name.IndexOf(strName) != -1)
                    Returned.Add(objBiz);
            }
            return Returned;
        }
        public CurrencyCol Copy()
        {
            CurrencyCol Returned = new CurrencyCol(true);
            foreach (CurrencyBiz objTemp in this)
            {
                Returned.Add(objTemp.Copy());
            }
            return Returned;
        }
        public DataTable GetTable()
        {
            DataTable Returned = new DataTable();
            Returned.Columns.AddRange(new DataColumn[] { new DataColumn("CurrencyID"), 
                new DataColumn("CurrencyNameA") ,new DataColumn("CurrencyNameE"),new DataColumn("CurrencyCode"),
            new DataColumn("CurrencyIsStandarad",Type.GetType("System.Boolean")),new DataColumn("CurrencyValue")});
            DataRow objDr;
            CurrencyBiz objStandardCurrency = GetStandardCurrency();

            foreach (CurrencyBiz objBiz in this)
            {
                objDr = Returned.NewRow();
                objDr["CurrencyID"] = objBiz.ID;
                objDr["CurrencyNameA"] = objBiz.NameA;
                objDr["CurrencyNameE"] = objBiz.NameE;
                objDr["CurrencyCode"] = objBiz.Code;
                objDr["CurrencyIsStandarad"] = objStandardCurrency.ID == objBiz.ID && objBiz.IsStanderd ? 
                    objBiz.IsStanderd : false;
                objDr["CurrencyValue"] = objStandardCurrency.ID == objBiz.ID && objBiz.IsStanderd ? 1 : objBiz.Value;
                Returned.Rows.Add(objDr);
            }
            return Returned;

        }
        public void EditRates()
        {
            DataTable dtTemp = GetTable();
            CurrencyDb objDb = new CurrencyDb();
            objDb.CurrencyTable = dtTemp;
            objDb.EditRates();
        }


    }
}