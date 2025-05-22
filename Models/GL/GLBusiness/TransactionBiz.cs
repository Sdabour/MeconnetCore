using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using SharpVision.Base.BaseDataBase;
using SharpVision.Base.BaseBusiness;
using SharpVision.GL.GLDataBase;
using SharpVision.SystemBase;
using SharpVision.COMMON.COMMONBusiness;
using SharpVision.UMS.UMSBusiness;
namespace SharpVision.GL.GLBusiness
{
    public enum TransactionSystemSource
    {
        NotSpecified =0,
        Rp = 4,
        CRM=6
    }
    public enum TransactionRPSystemType
    {
        NotSpecified = 0,
        Statement=1,
         Invoice = 2,
        Payment = 3
            ,
        Insurance = 4,
        Tax = 5,
        VariedDiscount=6,
        AdminstrativeExpenses = 7


    }
    public enum TransactionCRMSystemType
    {
        NotSpeacified=0,
        Contracting=1,
        Delivery=2,
        Cancelation=3,
        Payment=4,
        Mulct=5,
        Discount =6

    }
    public  class TransactionBiz
    {
        #region Privatedata
        protected TransactionDb _TransactionDb;
        protected JournalTypeBiz _TypeBiz;
        protected TransactionElementCol _ElementCol;
        CurrencyBiz _CurrencyBiz;
        CurrencyBiz _BaseCurrencyBiz;
        AccountBiz _AccountToBiz;
        AccountBiz _AccountFromBiz;

        FinancialPeriodBiz _PeriodBiz;
        SpecificBiz _SpecificBiz;
        static TransactionBiz _CopyTransactionBiz;
        UserBiz _UsrInsBiz;
        UserBiz _UsrUpdBiz;
        List<string> _SrcIDs;//Other Modules IDs
        #endregion

        #region Constractors
        public TransactionBiz()
        {
            _TransactionDb = new TransactionDb();
        }
        public TransactionBiz(DataRow objDR)
        {
            _TransactionDb = new TransactionDb(objDR);
            _TypeBiz = new JournalTypeBiz(objDR);
            _CurrencyBiz = new CurrencyBiz(objDR);
            if (_TransactionDb.AccountFromCode != null &&
                _TransactionDb.AccountFromCode!= "")
            {
                _AccountFromBiz = new AccountBiz();
                _AccountFromBiz.ID = -1;
                _AccountFromBiz.NameA = _TransactionDb.AccountFromNameA;
                _AccountFromBiz.Code = _TransactionDb.AccountFromCode;
               
            }
            if (_TransactionDb.AccountToCode!= null &&
                _TransactionDb.AccountToCode!= "")
            {
                _AccountToBiz = new AccountBiz();
                _AccountToBiz.ID = -1;
                _AccountToBiz.NameA = _TransactionDb.AccountToNameA;
                _AccountToBiz.Code = _TransactionDb.AccountToCode;
               
            }
            if (_TransactionDb.BaseCurrency != 0)
            {
                _BaseCurrencyBiz = new CurrencyBiz();
                _BaseCurrencyBiz.ID = _TransactionDb.BaseCurrency;
                _BaseCurrencyBiz.Code = _TransactionDb.BaseCurrencyCode;
                _BaseCurrencyBiz.NameA = _TransactionDb.BaseCurrencyName;
            }
            if (_TransactionDb.SpecificID != 0)
                _SpecificBiz = new SpecificBiz(objDR);
            if (_TransactionDb.PeriodID != 0)
                _PeriodBiz = new FinancialPeriodBiz(objDR);
        }
        #endregion

        #region Public Accessorice
        public int ID
        {
            set
            {
                _TransactionDb.ID = value;
            }
            get
            {
                return _TransactionDb.ID;
            }
        }
        public DateTime Date
        {
            set
            {
                _TransactionDb.Date = value;
            }
            get
            {
                return _TransactionDb.Date;
            }
        }
        public string Code
        {
            set
            {
                _TransactionDb.Code = value;
            }
            get
            {
                return _TransactionDb.Code;
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
                    if (ID != 0)
                    {
                        DataRow[] arrDr;
                        arrDr = TransactionElementDb.CacheElementTable.Select("TransactionID=" + ID, "ElementOrder");
                        if (arrDr.Length == 0)
                        {
                            TransactionElementDb objDb = new TransactionElementDb();
                            objDb.TRansaction = ID;
                            DataTable dtTemp;
                            dtTemp = objDb.Search();
                            arrDr = dtTemp.Select("TransactionID=" + ID, "ElementOrder");
                        }
                        foreach (DataRow objDr in arrDr)
                        {
                            _ElementCol.Add(new TransactionElementBiz(objDr));
                        }
                    }
                 
                    
                }
                return _ElementCol;
            }
        }
        public string ElementCreditStr
        {
            get
            {
                TransactionElementCol objCol = ElementCol.CreditTransactionElementCol;
                string Returned = "";
                Hashtable hsTemp = new Hashtable();
                AccountCol objAccountCol = new AccountCol(true);
                foreach (TransactionElementBiz objBiz in objCol)
                {
                    if (hsTemp[objBiz.AccountBiz.ID.ToString()] == null)
                    {
                        hsTemp.Add(objBiz.AccountBiz.ID.ToString(), objBiz.AccountBiz);
                        objAccountCol.Add(objBiz.AccountBiz);

                    }
                 

                }
                if (objAccountCol.Count == 1)
                    Returned += objAccountCol[0].Name;
                else if(objAccountCol.Count == 2)
                    Returned = objAccountCol[0].Name+"&" + objAccountCol[1].Name;
                else if(objAccountCol.Count >2)
                     Returned = objAccountCol[0].Name + "&--&" + objAccountCol[objAccountCol.Count-1].Name;
                return Returned;

            }
        }
        public string ElementDebitStr
        {
            get
            {
                TransactionElementCol objCol = ElementCol.DebitTransactionElementCol;
                string Returned = "";
                Hashtable hsTemp = new Hashtable();
                AccountCol objAccountCol = new AccountCol(true);
                foreach (TransactionElementBiz objBiz in objCol)
                {
                    if (hsTemp[objBiz.AccountBiz.ID.ToString()] == null)
                    {
                        hsTemp.Add(objBiz.AccountBiz.ID.ToString(), objBiz.AccountBiz);
                        objAccountCol.Add(objBiz.AccountBiz);

                    }


                }
                if (objAccountCol.Count == 1)
                    Returned += objAccountCol[0].Name;
                else if (objAccountCol.Count == 2)
                    Returned = objAccountCol[0].Name+"&" + objAccountCol[1].Name;
                else if (objAccountCol.Count > 2)
                    Returned = objAccountCol[0].Name + "&--&" + objAccountCol[objAccountCol.Count - 1].Name;
                return Returned;

            }
        }
        public string CreditStr
        {
            get
            {
                string Returned = "";
              
                if (AccountFromBiz.ID != 0)
                {
                    Returned = Value.ToString()  + " من ح " + AccountFromBiz.Name;
                
                }
                else if (ReservationID != 0)
                {
                    string strReservation = UnitStr + "(" + CustomerStr + ")";
                    Returned = Value.ToString() + " من ح " + strReservation;
                }
                return Returned;
            }
        }
        public string DebitStr
        {
            get
            {
                string Returned = "";
               
                if (AccountToBiz.ID != 0)
                {
                    Returned = Value.ToString() + " الى ح " + AccountToBiz.Name;

                }
                else if (ReservationID != 0)
                {
                    string strReservation = UnitStr + "(" + CustomerStr + ")";
                    Returned = Value.ToString() + " الى ح " + strReservation;
                }
                return Returned;
            }
        }

        public JournalTypeBiz TypeBiz
        {
            set
            {
                _TypeBiz = value;
            }
            get
            {
                if (_TypeBiz == null)
                    _TypeBiz = new JournalTypeBiz();
                return _TypeBiz;
            }
        }
        public CurrencyBiz CurrencyBiz
        {
            set
            {
                _CurrencyBiz = value;
            }
            get
            {
                if (_CurrencyBiz == null)
                    _CurrencyBiz = new CurrencyBiz();
                return _CurrencyBiz;
            }
        }
        public CurrencyBiz BaseCurrencyBiz
        {
            set
            {
                _BaseCurrencyBiz = value;
            }
            get
            {
                if (_BaseCurrencyBiz == null)
                    _BaseCurrencyBiz = new CurrencyBiz();
                return _BaseCurrencyBiz;
            }
        }
        public double CurrencyValue
        {
            set
            {
                _TransactionDb.CurrencyValue = value;
            }
            get
            {
                return _TransactionDb.CurrencyValue;
            }
        }
        public string Desc
        {
            set
            {
                _TransactionDb.Desc = value;
            }
            get
            {
                return _TransactionDb.Desc;
            }
        }
        public int Status
        {
            set
            {
                _TransactionDb.PostStatus = value;
            }
            get
            {
                return _TransactionDb.PostStatus;
            }
        }
        public double Value
        {
            set
            {
                _TransactionDb.Value = value;
            }
            get
            {
                return _TransactionDb.Value;
            }
        }
        public int SystemSource
        {
            set
            {
                _TransactionDb.SystemSource = value;
            }
            get
            {
                return _TransactionDb.SystemSource;
            }

        }
        public int SystemType
        {
            set
            {
                _TransactionDb.SystemType = value;
            }
            get
            {
                return _TransactionDb.SystemType;
            }
        }
        public int RecursiveTransactionID
        {
            get
            {
                return _TransactionDb.RecursiveTransactionID;
            }
        }
        public FinancialPeriodBiz PeriodBiz
        {
            set
            {
                _PeriodBiz = value;
            }
            get
            {
                if (_PeriodBiz == null)
                    _PeriodBiz = new FinancialPeriodBiz();
                return _PeriodBiz;
            }
        }
        public SpecificBiz SpecificBiz
        {
            set
            {
                _SpecificBiz = value;
            }
            get
            {
                if (_SpecificBiz == null)
                    _SpecificBiz = new SpecificBiz();
                return _SpecificBiz;
            }
        }
        public AccountBiz AccountToBiz
        {
            set
            {
                _AccountToBiz = value;
            }
            get
            {
                if (_AccountToBiz == null)
                    _AccountToBiz = new AccountBiz();
                return _AccountToBiz;
            }
        }
        public AccountBiz AccountFromBiz
        {
            set
            {
                _AccountFromBiz = value;
            }
            get 
            {
                if (_AccountFromBiz == null)
                    _AccountFromBiz = new AccountBiz();
                return _AccountFromBiz;
            }
        }
        public static TransactionBiz CopyTransactionBiz
        {
            set
            {
                _CopyTransactionBiz = value;
            }
            get
            {
                if (_CopyTransactionBiz == null)
                    _CopyTransactionBiz = new TransactionBiz();
                return _CopyTransactionBiz;
            }
        }
        public int SerialNo
        {
            get
            {
                return _TransactionDb.SerialNo;
            }
        }
        internal int UsrIns
        {
            get
            {
                return _TransactionDb.UsrIns;
            }
        }
        internal int UsrUpd
        {
            get
            {
                return _TransactionDb.UsrUpd;
            }
        }
       public DateTime TimIns
        {
            get
            {
                return _TransactionDb.TimIns;
            }
        }
       public DateTime TimUpd
        {
            get
            {
                return _TransactionDb.TimUpd;
            }
        }
        public UserBiz UsrInsBiz
        {
            internal set
            {
                _UsrInsBiz = value;
            }
            get
            {
                if (_UsrInsBiz == null)
                    _UsrInsBiz = new UserBiz();
                return _UsrInsBiz;
            }
        }
        public UserBiz UsrUpdBiz
        {
            internal set
            {
                _UsrUpdBiz = value;
            }
            get
            {
                if (_UsrUpdBiz == null)
                    _UsrUpdBiz = new UserBiz();
                return _UsrUpdBiz;
            }
        }
        public string DisplayedCode
        {
            get
            {
                string Returned = "";
                if (Code == null || Code == "")
                {
                    if (SerialNo == 0)
                        Returned = ID.ToString();
                    else
                        Returned = PeriodBiz.StartDate.ToString("yyyy-MM") + "/" + TypeBiz.Code + "/" + SerialNo.ToString();
                }
                else
                    Returned = Code;
                return Returned;
            }
        }
        public List<string> OtherModuleSrcIDs
        {
            set
            {
                _SrcIDs = value;
            }
            get
            {
                if (_SrcIDs == null)
                    _SrcIDs = new List<string>();
                return _SrcIDs;
            }
        }
     
        public string OtherModuleSrcIDsStr
        {
            get
            {
                string Returned = "";
                foreach (string strTemp in OtherModuleSrcIDs)
                {
                    if (Returned != "")
                        Returned += ",";
                    Returned += strTemp;
                }
                return Returned;
            }
        }
        public static List<string> TransactionRPSystemTypeLst1
        {
            get
            {
                List<string> Returned = new List<string>();
        //        NotSpecified = 0,
                Returned.Add("غير محدد");
        // Invoice = 1,
                Returned.Add("مستخلصات");
        //Payment = 2,
                Returned.Add("سلفيات");
        //Insurance=3,
                Returned.Add("تأمينات");
        //Tax=4,
                Returned.Add("ضرائب");
        //AdminstrativeExpenses=5
                Returned.Add("مصاريف ادارية");
                return Returned;
            }

        }
        public static List<string> TransactionRPSystemTypeLst
        {
            get
            {
                List<string> Returned = new List<string>();
                //        NotSpecified = 0,
                Returned.Add("غير محدد");
                Returned.Add("تسويات");
                // Invoice = 1,
                Returned.Add("مستخلصات");
                //Payment = 2,
                Returned.Add("سلفيات");
                Returned.Add("تأمينات");
        //       Insurance = 3,
        //Tax = 4,
                Returned.Add("ضرائب");
        //VariedDiscount=5,
                Returned.Add("خصومات وحدات ومتنوع");
        //AdminstrativeExpenses = 6
                Returned.Add("مصاريف ادارية");
                return Returned;
            }

        }
        public static List<string> TransactionCRMSystemTypeLst
        {
            get
            {
                List<string> Returned = new List<string>();
                //        NotSpecified = 0,
                Returned.Add("غير محدد");
                Returned.Add("تعاقد");
                // Invoice = 1,
                Returned.Add("استلام");
                //Payment = 2,
                Returned.Add("الغاء");
                Returned.Add("مدفوعات");
                Returned.Add("غرامات");
                Returned.Add("خصومات");
                return Returned;
            }

        }
        public static List<string> TransactionSystemSourceStrLst
        {
            get
            {
                List<string> Returned = new List<string>();
                //        NotSpecified = 0,
                Returned.Add("غير محدد");
                Returned.Add("مقاولين");
                // Invoice = 1,
                Returned.Add("تسويق عقارى");
               

                return Returned;
            }

        }
        public static List<int> TransactionSystemSourceIDLst
        {
            get
            {
                List<int> Returned = new List<int>();
                //        NotSpecified = 0,
                Returned.Add((int)TransactionSystemSource.NotSpecified);
                Returned.Add((int)TransactionSystemSource.Rp);
                Returned.Add((int)TransactionSystemSource.CRM);


                return Returned;
            }

        }
        #region Reservation Data
        public int ReservationID
        {
            set
            {
                _TransactionDb.ReservationID = value;
            }
            get
            {
                return _TransactionDb.ReservationID;
            }
        }
        public DateTime ReservationDate
        {
            set
            {
                _TransactionDb.ReservationDate = value;
            }
            get
            {
                return _TransactionDb.ReservationDate;
            }
        }
        public bool IsContracted
        {
            set
            {
                _TransactionDb.IsContracted = value;
            }
            get
            {
                return _TransactionDb.IsContracted;
            }
        }
        public DateTime ContractingDate
        {
            set
            {
                _TransactionDb.ContractingDate = value;
            }
            get
            {
                return _TransactionDb.ContractingDate;
            }
        }
        public string CustomerStr
        {
            set
            {
                _TransactionDb.CustomerStr = value;
            }
            get
            {
                return _TransactionDb.CustomerStr;
            }
        }
        public string UnitStr
        {
            set
            {
                _TransactionDb.UnitStr = value;
            }
            get
            {
                return _TransactionDb.UnitStr;
            }
        }
        public int TowerID
        {
            set
            {
                _TransactionDb.TowerID = value;
            }
            get
            {
                return _TransactionDb.TowerID;
            }
        }
        public string TowerName
        {
            set
            {
                _TransactionDb.TowerName = value;
            }
            get
            {
                return _TransactionDb.TowerName;
            }
        }
        public string ProjectName
        {
            set
            {
                _TransactionDb.ProjectName = value;
            }
            get
            {
                return _TransactionDb.ProjectName;
            }
        }
       

        #endregion
        #endregion

        #region PrivateMethods
      
        #endregion

        #region PublicMethods
        public virtual void Add()
        {
            if (_TypeBiz != null)
                _TransactionDb.Type = _TypeBiz.ID;
            else
                _TransactionDb.Type = 0;
            _TransactionDb.Currency = CurrencyBiz.ID;
            _TransactionDb.BaseCurrency = BaseCurrencyBiz.ID;
            _TransactionDb.PeriodID = PeriodBiz.ID;
            _TransactionDb.SpecificID = SpecificBiz.ID;
            _TransactionDb.ElementTable = ElementCol.GetTable();
            _TransactionDb.Add();
           
         
        }
        public virtual void Edit()
        {
            if (_TypeBiz != null)
                _TransactionDb.Type = _TypeBiz.ID;
            else
                _TransactionDb.Type = 0;
            _TransactionDb.Currency = CurrencyBiz.ID;
            _TransactionDb.BaseCurrency = BaseCurrencyBiz.ID;
            _TransactionDb.PeriodID = PeriodBiz.ID;
            _TransactionDb.SpecificID = SpecificBiz.ID;
            _TransactionDb.ElementTable = ElementCol.GetTable();
            _TransactionDb.Edit();
          
        }
        public virtual void Delete()
        {
            _TransactionDb.Delete();
        }
        public TransactionBiz Copy()
        {
            TransactionBiz Returned = new TransactionBiz();
            Returned.BaseCurrencyBiz = BaseCurrencyBiz;
            Returned.Code = Code;
            Returned.CurrencyBiz = CurrencyBiz;
            Returned.Date = Date;
            Returned.Desc = Desc;
            Returned.ElementCol = ElementCol.Copy();
            Returned.PeriodBiz = PeriodBiz;
            Returned.SpecificBiz = SpecificBiz;
            Returned.TypeBiz = TypeBiz;
            Returned.Value = Value;
            Returned.SystemSource = SystemSource;
            Returned.SystemType = SystemType;
            return Returned;
        }
        public static TransactionBiz GetMaxTransactionBiz(FinancialPeriodBiz objPeriodBiz,JournalTypeBiz objType)
        {
            if (objPeriodBiz == null)
                objPeriodBiz = new FinancialPeriodBiz();
            if (objType == null)
                objType = new JournalTypeBiz();
            TransactionBiz Returned = new TransactionBiz();
            TransactionDb objDb = new TransactionDb();
            objDb.Type = objType.ID;
            objDb.PeriodID = objPeriodBiz.ID;
            DataTable dtTemp = objDb.GetMaxPeriodJournalTypeTransaction();
            if (dtTemp.Rows.Count > 0)
            {
                Returned = new TransactionBiz(dtTemp.Rows[0]);
            }
            return Returned;
        }
        public void SetTransactionData()
        {
            if (_TypeBiz != null)
                _TransactionDb.Type = _TypeBiz.ID;
            else
                _TransactionDb.Type = 0;
            _TransactionDb.Currency = CurrencyBiz.ID;
            _TransactionDb.BaseCurrency = BaseCurrencyBiz.ID;
            _TransactionDb.PeriodID = PeriodBiz.ID;
            _TransactionDb.SpecificID = SpecificBiz.ID;
        }
        #endregion
    }
}
