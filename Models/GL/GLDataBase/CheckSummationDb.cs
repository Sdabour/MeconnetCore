using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.SystemBase;
using SharpVision.Base.BaseDataBase;

namespace SharpVision.GL.GLDataBase
{
    public class CheckSummationDb
    {
        #region Private Data
        //protected int _ID;
        protected int _Bank;
        //protected string _Code;
        //protected double _Value;
        //protected DateTime _DueDate;
        //protected int _Status;
        protected int _GroupType;//0 Bank
                                  //1 Place
        protected string _BankName;

        protected double _NotSpecified;
        protected double _DuePostponeded;
        protected double _NotDuePostponeded;
        protected double _Collected;
        protected double _Rejected;
        protected double _Reclaimed;
        protected double _Submitted;
        protected int _AccountID;

        protected bool _IsDateRange;
        protected DateTime _DateFrom;
        protected DateTime _DateTo;

        protected bool _IsIssueRange;
        DateTime _IssueDateFrom;
        DateTime _IssueDateTo;

        protected string _DateStr;
        bool _IsGrouped;

        bool _IsStatusDateRange;
        DateTime _DateStatusFrom;
        DateTime _DateStatusTo;

        int _Status;
        int _Place;
        int _OldPlace;
        int _CollectingPaymentStatus;

        int _PeriodType=1;
        bool _Direction = true;
        int _OrientedStatus = 0;
        #endregion

        #region Constractors
        public CheckSummationDb()
        { 

        }
        //public CheckSummationDb(int intID)
        //{
        //    _ID = intID;
        //    DataTable dtTemp = Search();
        //    if (dtTemp.Rows.Count == 0)
        //    {
        //        _ID = 0;
        //        return;
        //    }
        //    DataRow objDR = dtTemp.Rows[0];
        //    SetData(objDR);
        //}
        public CheckSummationDb(DataRow objDR)
        {
            SetData(objDR);
        }
        #endregion

        #region public Properties
     
        public int Bank
        {
            set
            {
                _Bank = value;
            }
            get
            {
                return _Bank;
            }
        }
       
        public string BankName
        {
            set
            {
                _BankName = value;
            }
            get
            {
                return _BankName;
            }
        }

        public double NotSpecified
        {
            set
            {
                _NotSpecified = value;
            }
            get
            {
                return _NotSpecified;
            }
        }
        public double DuePostponeded
        {
            set
            {
                _DuePostponeded = value;
            }
            get
            {
                return _DuePostponeded;
            }
        }
        public double NotDuePostponeded
        {
            set
            {
                _NotDuePostponeded = value;
            }
            get
            {
                return _NotDuePostponeded;
            }
        }
        public double Collected
        {
            set
            {
                _Collected = value;
            }
            get
            {
                return _Collected;
            }
        }
        public double Reclaimed
        {
            set
            {
                _Reclaimed = value;
            }
            get
            {
                return _Reclaimed;
            }
        }
        public double Rejected
        {
            set
            {
                _Rejected = value;
            }
            get
            {
                return _Rejected;
            }
        }
        public bool Direction
        {
            set
            {
                _Direction = value;
            }
        }
        public string DateStr
        {
            get
            {
                return _DateStr;
            }
        }
        public double Submitted
        {
            set
            {
                _Submitted = value;
            }
            get
            {
                return _Submitted;
            }
        }

        public bool IsDateRange
        {
            set
            {
                _IsDateRange = value;
            }
            get
            {
                return _IsDateRange;
            }
        }
        public DateTime DateFrom
        {
            set
            {
                _DateFrom = value;
            }
        }
        public DateTime DateTo
        {
            set
            {
                _DateTo = value;
            }
        }
        public bool IsIssueRange
        {
            set
            {
                _IsIssueRange = value;
            }
        }
        public DateTime IssueDateFrom
        {
            set
            {
                _IssueDateFrom = value;
            }
        }
        public DateTime IssueDateTo
        {
            set
            {
                _IssueDateTo = value;
            }
        }

        public bool IsGrouped
        {
            set
            {
                _IsGrouped = value;
            }
        }
        public bool IsStatusDateRange
        {
            set
            {
                _IsStatusDateRange = value;
            }
        }
        public DateTime DateStatusFrom
        {
            set
            {
                _DateStatusFrom = value;
            }
        }
        public DateTime DateStatusTo
        {
            set
            {
                _DateStatusTo = value;
            }
        }

        public int Status
        {
            set
            {
                _Status = value;
            }
        }
        public int Place
        {
            set
            {
                _Place = value;
            }
        }
        public int GroupType
        {
            set
            {
                _GroupType = value;
            }
        }
        public int OldPlace
        {
            set
            {
                _OldPlace = value;
            }
        }
        public int CollectingPaymentStatus
        {
            set
            {
                _CollectingPaymentStatus = value;
            }
        }
        public int PeriodType
        {
            set
            {
                _PeriodType = value;
            }
        }
        public int OrientedStatus
        {
            set
            {
                _OrientedStatus = value;
            }
        }
        public int AccountID
        {
            set
            {
                _AccountID = value;
            }
        }
        public string SearchStr
        {
            get
            {
                string strOrder = "";
                string strPeriod = "";
                string strPayment = "select CheckID,sum(PaymentValue) as TotalPayment" +
                   ",sum(case when PaymentIsCollected=1 then PaymentValue else 0 end) as CollectedPaymentValue from " +
                   " (SELECT     CheckID, GLPayment.PaymentID, PaymentValue,PaymentIsCollected " +
                   " FROM         GLCheckPayment INNER JOIN " +
                   " GLPayment ON GLCheckPayment.PaymentID = GLPayment.PaymentID) as CheckPaymentTable " +
                   " group by CheckID ";
                string strAccount = "SELECT  dbo.GLCheckOut.CheckID as AccountCheckID,GlBankAccount.AccountID,dbo.GLBank.BankNameA + CASE WHEN dbo.GLBankAccount.AccountDesc IS NULL OR" +
                      " dbo.GLBankAccount.AccountDesc = '' THEN '' ELSE '-' + dbo.GLBankAccount.AccountDesc END + CASE WHEN dbo.GLBankAccount.AccountOwnerName "+
                       " IS NULL OR "+
                      " dbo.GLBankAccount.AccountOwnerName = '' THEN '' ELSE '-' + dbo.GLBankAccount.AccountOwnerName END + CASE WHEN dbo.GLBankAccount.AccountCode "+
                       " IS NULL OR "+
                      " dbo.GLBankAccount.AccountCode = '' THEN '' ELSE '-' + dbo.GLBankAccount.AccountCode END AS BankAccount "+
                      " FROM         dbo.GLBankAccount INNER JOIN "+
                      " dbo.GLCheckOut ON dbo.GLBankAccount.AccountID = dbo.GLCheckOut.CheckBankAccount INNER JOIN "+
                      " dbo.GLBank ON dbo.GLBankAccount.AccountBank = dbo.GLBank.BankID"; 
                if (!_IsGrouped)
                {
                    if (_PeriodType == 0)
                    {
                        strOrder = "Year(CheckDueDate),Month(CheckDueDate)";
                        strPeriod = "SUBSTRING(CONVERT(varchar(10), CheckDueDate, 103), 4, 10) ";

                    }
                    if (_PeriodType == 1)
                    {
                        strOrder = " Year(CheckDueDate),  CASE WHEN month(CheckDueDate) < 4 THEN 1 WHEN Month(CheckDueDate) < 7 THEN 2 WHEN Month(checkduedate) " +
                                     " < 9 THEN 3 ELSE 4 END  ";
                        strPeriod = " CASE WHEN month(CheckDueDate) < 4 THEN 'ÇáÑÈÚ ÇáÇæá' WHEN Month(CheckDueDate) < 7 THEN 'ÇáÑÈÚ ÇáËÇäì' WHEN Month(checkduedate) " +
                                     " < 9 THEN 'ÇáÑÈÚ ÇáËÇáË' ELSE 'ÇáÑÈÚ ÇáÇÎíÑ' END  + Convert(varchar(4),Year(CheckDueDate)) ";
                    }
                    if (_PeriodType == 2)
                    {
                        strOrder = " Year(CheckDueDate) ";
                        strPeriod = "  Convert(varchar(4),Year(CheckDueDate)) ";
                    }

                }
            string strGroup = "";
            if (_GroupType == 0)
            {
                if (_Direction)
                    strGroup = "dbo.GLBank.BankNameA";
                else
                    strGroup = " BankAccountTable.BankAccount ";
            }
            else
            {
                if (_Place != 0)
                    strGroup = " dbo.GLCoffer.CofferNameA ";
                else
                {
                    strGroup = " case when dbo.GLCheck.CheckCurrentStatus = 2 then ' ãÍÕá ãä ÇáÈäß ' when dbo.GLCheck.CheckCurrentStatus=4 then 'ãÓÊÑÏ' else dbo.GLCoffer.CofferNameA end ";
                    //"  dbo.GLCoffer.CofferNameA ";
                }
            }
               
            string Returned = " SELECT  " + strGroup + " As CofferNameA , SUM(CASE WHEN dbo.GLCheck.CheckCurrentStatus = 0  or GLCheck.CheckDueDate is null THEN dbo.GLCheck.CheckValue ELSE 0 END) AS NotSpecified, " +
                  " SUM(CASE WHEN dbo.GLCheck.CheckCurrentStatus = 1 AND dbo.GLCheck.CheckDueDate < GetDate()  "+
                  " THEN dbo.GLCheck.CheckValue - (case when CollectedPaymentValue is null then 0 else CollectedPaymentValue end)   ELSE 0 END) " +
                  " AS DuePostponeded, SUM(CASE WHEN dbo.GLCheck.CheckCurrentStatus = 1 AND dbo.GLCheck.CheckDueDate > GetDate() " +
                  " THEN dbo.GLCheck.CheckValue -  (case when CollectedPaymentValue is null then 0 else CollectedPaymentValue end)   ELSE 0 END) AS NotDuePostponded, " +
                  " SUM(CASE WHEN dbo.GLCheck.CheckCurrentStatus = 2 THEN dbo.GLCheck.CheckValue ELSE case when CollectedPaymentValue is null then 0 else CollectedPaymentValue end   END) AS Collected, " +
                  " SUM(CASE WHEN dbo.GLCheck.CheckCurrentStatus = 3 THEN dbo.GLCheck.CheckValue - (case when CollectedPaymentValue is null then 0 else CollectedPaymentValue end)  ELSE 0 END) AS Rejected, " +
                  " SUM(CASE WHEN dbo.GLCheck.CheckCurrentStatus = 4 THEN dbo.GLCheck.CheckValue-(case when CollectedPaymentValue is null then 0 else CollectedPaymentValue end)  ELSE 0 END) AS Reclaimed, " +
                  " SUM(CASE WHEN dbo.GLCheck.CheckCurrentStatus = 5 THEN dbo.GLCheck.CheckValue-(case when CollectedPaymentValue is null then 0 else CollectedPaymentValue end) ELSE 0 END) AS Submitted";
            if (strPeriod != "")
            {
                Returned += "," + strPeriod + " as CheckPeriod ";
                if(strOrder != "")
                    Returned+= "," +strOrder ;
            }
            Returned += " FROM      dbo.GLCheck ";
            if (_GroupType == 0)
            {
                Returned += " inner join GLBank  ON dbo.GLBank.BankID = dbo.GLCheck.CheckBank ";
                if (!_Direction)
                    Returned += " left outer join ("+ strAccount +
                        ") as BankAccountTable on GLCheck.CheckID = BankAccountTable.AccountCheckID  ";


            }
            else if (_GroupType == 1)
                Returned += " inner join GLCoffer on GLCheck.ChcekCurrentPlace = GLCoffer.CofferID ";

            Returned += " left outer join (" + strPayment + 
                ") as PaymentTable on GLCheck.CheckID = PaymentTable.CheckID  ";



                double dblDateFrom = _DateFrom.ToOADate() - 2;
                dblDateFrom = SysUtility.Approximate(dblDateFrom, 1, ApproximateType.Down);
                double dblDateTimeto = _DateTo.ToOADate() - 2;
                dblDateTimeto = SysUtility.Approximate(dblDateTimeto, 1, ApproximateType.Up);

                int intDirection = _Direction ? 1 : 0;
                Returned = Returned + " where (dbo.GLCheck.CheckDirection="+ intDirection +")";
                if (_IsDateRange)
                    Returned += " and Convert(float,dbo.GLCheck.CheckDueDate) >= " + dblDateFrom +
                        " and Convert(float,dbo.GLCheck.CheckDueDate) < " + dblDateTimeto + "";
                double dblStart = 0; double dblEnd = 0;
                if (_IsIssueRange)
                {
                    dblStart = _IssueDateFrom.ToOADate() - 2;
                    dblStart = SysUtility.Approximate(dblStart, 1, ApproximateType.Down);
                    dblEnd = _IssueDateTo.ToOADate() - 2;
                    dblEnd = SysUtility.Approximate(dblEnd, 1, ApproximateType.Up);

                    Returned += " and CheckIssueDate >=" + dblStart +
                        " and CheckIssueDate < " + dblEnd;

                }
                if (_Bank != 0 )
                    Returned += " and  (dbo.GLCheck.CheckBank = " + _Bank + ") ";
                if (_Place != 0)
                    Returned += " and (GLCheck.CheckCurrentStatus<>2) and (GLCheck.CheckCurrentStatus <> 4) and (GLCheck.ChcekCurrentPlace=" + _Place + ")";
                if (_OldPlace != 0)
                    Returned += " and CheckCurrentOldPlace =" + _OldPlace;
                if (_OrientedStatus != 0)
                {
                    if (_OrientedStatus == 1)
                        Returned += " and CheckIsBankOriented=1 ";
                    else if (_OrientedStatus == 2)
                        Returned += " and CheckIsBankOriented = 0 ";

                }
                if (_IsStatusDateRange)
                {
                    double dblStatusFrom = _DateStatusFrom.ToOADate() - 2;
                    dblStatusFrom = SysUtility.Approximate(dblStatusFrom, 1, ApproximateType.Down);
                    double dblStatusTo = _DateStatusTo.ToOADate() - 2;
                    dblStatusTo = SysUtility.Approximate(dblStatusTo, 1, ApproximateType.Up);
                    Returned += " and CheckCurrentStatusDate >="  + dblStatusFrom + 
                        " and CheckCurrentStatusDate < " +  dblStatusTo;
                }
                if (_Status != 0)
                {
                    Returned += " and GLCheck.CheckCurrentStatus = " + _Status;
 
                }
                if (_AccountID != 0)
                {
                    Returned += " and BankAccountTable.AccountID="+ _AccountID ;
                }
                if (_CollectingPaymentStatus != 0)
                {
                    if (_CollectingPaymentStatus == 1)
                    {
                        Returned += " and GLCheck.CheckID in (SELECT     GLCheck.CheckID " +
                              " FROM  GlCheck left outer join dbo.GLCheckPayment on " +
                              " GLCheck.CheckID = GLCheckPayment.CheckID " +
                              " WHERE  (GLCheckPayment.CheckID is null) or (PaymentIsCollected = 0))";
                    }
                    else if (_CollectingPaymentStatus == 2)
                    {
                        Returned += " and GLCheck.CheckID not in (SELECT  CheckID " +
                                                " FROM   dbo.GLCheckPayment " +
                                                " WHERE  (PaymentIsCollected = 0))";
                    }
                    else if (_CollectingPaymentStatus == 3)
                    {
                        Returned += " and CollectedPaymentValue is not null and CollectedPaymentValue > 0 " +
                            "  and CheckValue > CollectedPaymentValue  ";
                    }
                    else if (_CollectingPaymentStatus == 4)
                    {
                        Returned += " and CheckValue <= CollectedPaymentValue ";

                    }
                }
                //" case when CollectedPaymentValue is null then 0 else CollectedPaymentValue end "
                if(strGroup != "")
                Returned += " GROUP BY " + strGroup;
                if (strPeriod != "")
                    Returned += "," + strPeriod  ;
                if(strOrder != "")
                    Returned+= ","+ strOrder;

                if (strOrder != "")
                    Returned += " order by " + strOrder;

                return Returned;
            }
        }
        #endregion

        #region Private Methods
        void SetData(DataRow objDR)
        {
           

            _NotSpecified = double.Parse(objDR["NotSpecified"].ToString());
            _DuePostponeded = double.Parse(objDR["DuePostponeded"].ToString());
            _NotDuePostponeded = double.Parse(objDR["NotDuePostponded"].ToString());
            _Collected = double.Parse(objDR["Collected"].ToString());
            _Rejected = double.Parse(objDR["Rejected"].ToString());
            _Reclaimed = double.Parse(objDR["Reclaimed"].ToString());
            _Submitted = double.Parse(objDR["Submitted"].ToString());
            if (objDR.Table.Columns["BankNameA"] != null)
                _BankName = objDR["BankNameA"].ToString();
            else if(objDR.Table.Columns["CofferNameA"]!= null)
                _BankName = objDR["CofferNameA"].ToString();
            if(objDR.Table.Columns["CheckPeriod"]!= null)
            _DateStr = objDR["CheckPeriod"].ToString();
        }
        #endregion

        #region Public Methods
        public DataTable Search()
        {
         
            return SysData.SharpVisionBaseDb.ReturnDatatable(SearchStr);
        }
        #endregion
    }
}
