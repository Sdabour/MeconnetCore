using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpVision.SystemBase;
using AlgorithmatMN.MN.MNDb;
using System.Collections;
using System.Data;
namespace AlgorithmatMN.MN.MNBiz
{
    public class CreditCol:CollectionBase
    {
        Hashtable _CreditHash = new Hashtable();
        #region Constructor
        public CreditCol()
        {

        }
        public CreditCol(bool blIsEmbty)
        {
            if (blIsEmbty)
                return;
            CreditBiz objBiz = new CreditBiz();
          

            CreditDb objDb = new CreditDb();

            DataTable dtTemp = objDb.Search();


            foreach (DataRow objDR in dtTemp.Rows)
            {
                objBiz = new CreditBiz(objDR);
                Add(objBiz);
            }
        }
        public CreditCol(string strProjectCode)
        {
            
                
            CreditBiz objBiz = new CreditBiz();


            CreditDb objDb = new CreditDb();
            objDb.ProjectCode = strProjectCode;
            DataTable dtTemp = objDb.Search();


            foreach (DataRow objDR in dtTemp.Rows)
            {
                objBiz = new CreditBiz(objDR);
                Add(objBiz);
            }
        }
        public CreditCol(string strProjectCode,string strRo,List<int> lstYear)
        {


            CreditBiz objBiz = new CreditBiz();

            string strYear = "";
            if (lstYear == null)
                lstYear = new List<int>();
            foreach (int intYear in lstYear)
            {
                if (strYear != "")
                    strYear += ",";
                strYear += intYear.ToString();
            }
            CreditDb objDb = new CreditDb();
            objDb.ProjectCode = strProjectCode;
            objDb.ROCode = strRo;
            objDb.YearsStr = strYear;
            DataTable dtTemp = objDb.Search();


            foreach (DataRow objDR in dtTemp.Rows)
            {
                objBiz = new CreditBiz(objDR);
                Add(objBiz);
            }
        }
        #endregion
        #region Private Data

        #endregion
        #region Properties
        public CreditBiz this[int intIndex]
        {
            get
            {
                return (CreditBiz)this.List[intIndex];
            }
        }
        public CreditBiz this[string StrIndex]
        {
            get
            {
                CreditBiz Returned = new CreditBiz();
                if (_CreditHash[StrIndex] != null)
                    Returned = (CreditBiz)_CreditHash[StrIndex];
                return Returned;
            }
        }
        public double TotalCostPart
        { get => this.Cast<CreditBiz>().Sum(x => x.CostPart); }
       
        public string IDsStr
        { get { string Returned = "";
                foreach(CreditBiz objBiz in this)
                { if (Returned != "")
                        Returned += ",";
                    Returned += objBiz.ID.ToString();
                }
                return Returned;
            } }
        public ROCol ROCol
        { get
            {
                ROCol Returned = new ROCol(true);
                ROBiz objRo;
                List<CreditBiz> lstCredit = (from objCredit1 in this.Cast<CreditBiz>()
                                            orderby objCredit1.RO, objCredit1.Year
                                            select objCredit1).ToList();
                foreach (CreditBiz objCredit in lstCredit)
                {
                    objRo = Returned[objCredit.RO.ToString()];
                    if (objRo.ID == 0)
                    { objRo = objCredit.ROBiz;
                        Returned.Add(objRo);
                    }
                    objRo.CreditCol.Add(objCredit);
                        
                   
                }
                return Returned;
            }
        }
       
        #endregion
        #region Private Method

        #endregion
        #region Public Method 
        public void Add(CreditBiz objBiz)
        {
            if (_CreditHash[objBiz.Key] == null)
            {
                _CreditHash.Add(objBiz.Key, objBiz);
                List.Add(objBiz);
            }
            else 
            {
            }
        }
        public void Add(CreditCol objCol)
        {
            foreach(CreditBiz objBiz in objCol)
             Add(objBiz);
        }
        public CreditCol GetCol(string strTemp)
        {
            CreditCol Returned = new CreditCol(true);
            foreach (CreditBiz objBiz in this)
            {
               // if (objBiz.Name.CheckStr(strTemp))
                    Returned.Add(objBiz);
            }
            return Returned;
        }
        public DataTable GetTable(bool blOnlyZeroCredited,ref DataTable dtPayment,ref DataTable dtDiscount,ref DataTable dtCost)
        {
            List<int> lstCost,lstDiscount,lstPayment;

            
                DataTable Returned = new DataTable();
            Returned.Columns.AddRange(new DataColumn[] { new DataColumn("CreditID"), new DataColumn("CreditRO"), new DataColumn("CreditYear"), new DataColumn("CreditStartDate", System.Type.GetType("System.DateTime")), new DataColumn("CreditEndDate", System.Type.GetType("System.DateTime")), new DataColumn("CrditInitialValue"), new DataColumn("CreditBonusValue"), new DataColumn("CreditPaymentValue"),new DataColumn("CreditDiscountValue"), new DataColumn("CreditCost"), new DataColumn("CreditUser"), new DataColumn("CreditOrder") }) ;
                DataRow objDr;
            int intOrder = 0;
                foreach (CreditBiz objBiz in this)
                {
                if (objBiz.ID > 0 && blOnlyZeroCredited)
                    continue;
                objDr = Returned.NewRow();
                    objDr["CreditID"] = objBiz.ID;
                    objDr["CreditRO"] = objBiz.RO;
                    objDr["CreditYear"] = objBiz.Year;
                    objDr["CreditStartDate"] = objBiz.StartDate;
                    objDr["CreditEndDate"] = objBiz.EndDate;
                    objDr["CrditInitialValue"] = objBiz.CrditInitialValue;
                    objDr["CreditBonusValue"] = objBiz.BonusValue;
                    objDr["CreditPaymentValue"] = objBiz.PaymentValue;
                objDr["CreditDiscountValue"] = objBiz.DiscountValue;
                    objDr["CreditCost"] = objBiz.Cost;
                objDr["CreditUser"] = SysData.CurrentUser.ID.ToString();
                    Returned.Rows.Add(objDr);
                objDr["CreditOrder"] = ++intOrder;
                #region Discount
                lstDiscount = (from objDiscount in objBiz.DiscountCol.Cast<MaintainanceDiscountBiz>()
                              select objDiscount.ID).ToList();
                SysUtility.AddForignMultipleRow("MNROCreditDiscount", ref dtDiscount, intOrder, lstDiscount);

                #endregion
                #region Payment
                lstPayment = (from objPayment in objBiz.PaymentCol.Cast<MaintainancePaymentBiz>()
                               select objPayment.ID).ToList();
                SysUtility.AddForignMultipleRow("MNROCreditPayment", ref dtPayment, intOrder, lstPayment);

                #endregion
                #region Cost
                lstCost = (from objCost in objBiz.ROCostCol.Cast<ROCostBiz>()
                               select objCost.ID).ToList();
                SysUtility.AddForignMultipleRow("MNROCost", ref dtCost, intOrder, lstCost);

                #endregion
            }
            return Returned;
           
        }
        public void SaveNewCredit()
        {
            DataTable dtDiscount = SysUtility.GetEmptyTempForignTable();
            DataTable dtPayment = SysUtility.GetEmptyTempForignTable();
            DataTable dtCost = SysUtility.GetEmptyTempForignTable();
            DataTable dtTemp = GetTable(true,ref dtPayment,ref dtDiscount,ref dtCost);
            DataRow[] arrDr = dtTemp.Select("CreditID=0");
            if (arrDr.Length == 0)
                return;
            dtTemp = arrDr.CopyToDataTable();

            CreditDb objDb = new CreditDb();
            objDb.CreditTable = dtTemp;
            objDb.PaymentTable = dtPayment;
            objDb.DiscountTable = dtDiscount;
            objDb.CostTable = dtCost;
            objDb.AddMultiple();
        }
        public void DeleteCredit()
        {
            CreditDb objDb = new CreditDb() { IDs = IDsStr };
            objDb.Delete();
        }
        #endregion
    }
}
