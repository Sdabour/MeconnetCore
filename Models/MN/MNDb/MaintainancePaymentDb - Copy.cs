using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using SharpVision.SystemBase;

namespace AlgorithmatMN.MN.MNDb
{
    public class MaintainancePayment1Db
    {

        #region Constructor
        public MaintainancePayment1Db()
        {
        }
        public MaintainancePayment1Db(DataRow objDr)
        {
            SetData(objDr);
        }

        #endregion
        #region Properties
        int _ID;
        public int ID
        {
            set
            {
                _ID = value;
            }
            get
            {
                return _ID;
            }
        }
        int _CreditROID;
        public int CreditROID
        {
            set
            {
                _CreditROID = value;
            }
            get
            {
                return _CreditROID;
            }
        }
        int _CreditID;
        public int CreditID
        {
            set
            {
                _CreditID = value;
            }
            get
            {
                return _CreditID;
            }
        }
        double _Value;
        public double Value
        {
            set
            {
                _Value = value;
            }
            get
            {
                return _Value;
            }
        }
        DateTime _Date;
        public DateTime Date
        {
            set
            {
                _Date = value;
            }
            get
            {
                return _Date;
            }
        }
        int _Currency;
        public int Currency
        {
            set
            {
                _Currency = value;
            }
            get
            {
                return _Currency;
            }
        }
        double _CurrencyValue;
        public double CurrencyValue
        {
            set
            {
                _CurrencyValue = value;
            }
            get
            {
                return _CurrencyValue;
            }
        }
        int _Type;
        public int Type
        {
            set
            {
                _Type = value;
            }
            get
            {
                return _Type;
            }
        }
        string _Desc;
        public string Desc
        {
            set
            {
                _Desc = value;
            }
            get
            {
                return _Desc;
            }
        }
        bool _Direction;
        public bool Direction
        {
            set
            {
                _Direction = value;
            }
            get
            {
                return _Direction;
            }
        }
        int _Employee;
        public int Employee
        {
            set
            {
                _Employee = value;
            }
            get
            {
                return _Employee;
            }
        }
        int _Branch;
        public int Branch
        {
            set
            {
                _Branch = value;
            }
            get
            {
                return _Branch;
            }
        }
        int _Coffer;
        public int Coffer
        {
            set
            {
                _Coffer = value;
            }
            get
            {
                return _Coffer;
            }
        }
        bool _HasReceipt;
        public bool HasReceipt
        {
            set
            {
                _HasReceipt = value;
            }
            get
            {
                return _HasReceipt;
            }
        }
        int _Receipt;
        public int Receipt
        {
            set
            {
                _Receipt = value;
            }
            get
            {
                return _Receipt;
            }
        }
        int _SourceID;
        public int SourceID
        {
            set
            {
                _SourceID = value;
            }
            get
            {
                return _SourceID;
            }
        }
        int _ReverseID;
        public int ReverseID
        {
            set
            {
                _ReverseID = value;
            }
            get
            {
                return _ReverseID;
            }
        }
        int _CollectingID;
        public int CollectingID
        {
            set
            {
                _CollectingID = value;
            }
            get
            {
                return _CollectingID;
            }
        }
        int _CheckID;
        public int CheckID
        {
            set
            {
                _CheckID = value;
            }
            get
            {
                return _CheckID;
            }
        }
        bool _IsCollected;
        public bool IsCollected
        {
            set
            {
                _IsCollected = value;
            }
            get
            {
                return _IsCollected;
            }
        }
        DateTime _CollectingDate;
        public DateTime CollectingDate
        {
            set
            {
                _CollectingDate = value;
            }
            get
            {
                return _CollectingDate;
            }
        }
        int _CollectingUsr;
        public int CollectingUsr
        {
            set
            {
                _CollectingUsr = value;
            }
            get
            {
                return _CollectingUsr;
            }
        }
        int _CollectingEmployee;
        public int CollectingEmployee
        {
            set
            {
                _CollectingEmployee = value;
            }
            get
            {
                return _CollectingEmployee;
            }
        }
        int _CollectingBranch;
        public int CollectingBranch
        {
            set
            {
                _CollectingBranch = value;
            }
            get
            {
                return _CollectingBranch;
            }
        }
        int _CollectingCoffer;
        public int CollectingCoffer
        {
            set
            {
                _CollectingCoffer = value;
            }
            get
            {
                return _CollectingCoffer;
            }
        }
        DateTime _CollectingRealDate;
        public DateTime CollectingRealDate
        {
            set
            {
                _CollectingRealDate = value;
            }
            get
            {
                return _CollectingRealDate;
            }
        }
        string _CheckEditorName;
        public string CheckEditorName
        {
            set
            {
                _CheckEditorName = value;
            }
            get
            {
                return _CheckEditorName;
            }
        }
        string _CheckCode;
        public string CheckCode
        {
            set
            {
                _CheckCode = value;
            }
            get
            {
                return _CheckCode;
            }
        }
        double _CheckValue;
        public double CheckValue
        {
            set
            {
                _CheckValue = value;
            }
            get
            {
                return _CheckValue;
            }
        }
        DateTime _CheckIssueDate;
        public DateTime CheckIssueDate
        {
            set
            {
                _CheckIssueDate = value;
            }
            get
            {
                return _CheckIssueDate;
            }
        }
        DateTime _CheckDueDate;
        public DateTime CheckDueDate
        {
            set
            {
                _CheckDueDate = value;
            }
            get
            {
                return _CheckDueDate;
            }
        }
        DateTime _CheckDate;
        public DateTime CheckDate
        {
            set
            {
                _CheckDate = value;
            }
            get
            {
                return _CheckDate;
            }
        }
        int _CheckCurrentStatus;
        public int CheckCurrentStatus
        {
            set
            {
                _CheckCurrentStatus = value;
            }
            get
            {
                return _CheckCurrentStatus;
            }
        }
        DateTime _CheckCurrentStatusDate;
        public DateTime CheckCurrentStatusDate
        {
            set
            {
                _CheckCurrentStatusDate = value;
            }
            get
            {
                return _CheckCurrentStatusDate;
            }
        }
        public string AddCheckPaymentStr
        {
            get
            {
                double dblStatusDate = _CheckCurrentStatusDate.ToOADate() - 2;
                int intStatusDate = (int)dblStatusDate;
                int intIsCollected = _IsCollected ? 1 : 0;
                double dblCollectingDate = SysUtility.Approximate(_CollectingDate.ToOADate() - 2, 1, ApproximateType.Down);
                string strCollectingDate = _IsCollected ? dblCollectingDate.ToString() : "null";
                intStatusDate = intStatusDate > dblStatusDate ? intStatusDate - 1 : intStatusDate;
                string strCollectingUser = _IsCollected ? SysData.CurrentUser.ID.ToString() : "null";
                _CollectingEmployee = _IsCollected ? _CollectingEmployee : 0;
                _CollectingBranch = _IsCollected ? _CollectingBranch : 0;
                string strCollectingRealDate = _IsCollected ? "GetDate()" : "NULL";
                string strPaymentID = _ID == 0 ? "@PaymentID" : _ID.ToString();
                string strStatus = intStatusDate < 0 ? "null" : intStatusDate.ToString();
                string Returned = " INSERT INTO GLCheckPayment " +
                                " (CheckID, PaymentID,PaymentIsCollected,PaymentCollectingDate,PaymentCollectingUsr" +
                                ",PaymentCollectingEmployee,PaymentCollectingBranch,PaymentCollectingRealDate" +
                                ", UsrIns, TimIns)" +
                                " VALUES     (" + _CheckID + "," + strPaymentID + "," + intIsCollected + "," +
                                strCollectingDate + "," + strCollectingUser + "," + _CollectingEmployee.ToString() +
                                "," + _CollectingBranch.ToString() +
                                "," + strCollectingRealDate + "," +
                                SysData.CurrentUser.ID + ",GetDate())";
                return Returned;
            }
        }
        public string AddPaymentStr
        { get
            {
                string Returned = "declare @PaymentID int;";
                Returned+= @"insert into GLPayment (PaymentValue,PaymentDate,PaymentCurrency,PaymentCurrencyValue,PaymentType,PaymentDesc,PaymentDirection,PaymentEmployee,PaymentBranch,PaymentCoffer,PaymentHasReceipt,PaymentReceipt,PaymentSourceID,PaymentReverseID,PaymentCollectingID
) 
 values (" + Value + @"," + (Date.ToOADate() - 2).ToString() + @"," + Currency + "," + CurrencyValue + "," + Type + ",'" + Desc + "'," + (Direction ? 1 : 0) + "," + Employee + "," + Branch + "," + Coffer + "," + (HasReceipt ? 1 : 0) + "," + Receipt + "," + SourceID + "," + ReverseID + "," + CollectingID + @")
  set @PaymentID=(select @@IDENTITY) ";
                if (_CheckID != 0)
                    Returned += " " + AddCheckPaymentStr;
                return Returned;
            }
        }
        public string AddStr
        {
            get
            {
                string Returned = "";
                Returned += @"begin transaction Trans1;
       ";
                Returned += AddPaymentStr;
                Returned+= @" insert into MNROCreditPayment (PaymentID,CreditROID,CreditID)
     values (@PaymentID," + CreditROID + "," + CreditID + ") ";
                Returned += " goto commitline;";
                Returned += " commitline: commit transaction Trans1;select  @PaymentID as exp1 ; return ; ";
                Returned += " rolLine: RollBack TRAN Trans1 ;select  -1 as exp1 ;";
                return Returned;
            }
        }
        public string EditStr
        {
            get
            {
                string Returned = " update MNROCreditPayment set " + "PaymentID=" + ID + "" +
           ",CreditROID=" + CreditROID + "" +
           ",CreditID=" + CreditID + "" +
           ",PaymentValue=" + Value + "" +
           ",PaymentDate=" + (Date.ToOADate() - 2).ToString() + "" +
           ",PaymentCurrency=" + Currency + "" +
           ",PaymentCurrencyValue=" + CurrencyValue + "" +
           ",PaymentType=" + Type + "" +
           ",PaymentDesc='" + Desc + "'" +
           ",PaymentDirection=" + (Direction ? 1 : 0) + "" +
           ",PaymentEmployee=" + Employee + "" +
           ",PaymentBranch=" + Branch + "" +
           ",PaymentCoffer=" + Coffer + "" +
           ",PaymentHasReceipt=" + (HasReceipt ? 1 : 0) + "" +
           ",PaymentReceipt=" + Receipt + "" +
           ",PaymentSourceID=" + SourceID + "" +
           ",PaymentReverseID=" + ReverseID + "" +
           ",PaymentCollectingID=" + CollectingID + "" +
           ",CheckID=" + CheckID + "" +
           ",PaymentIsCollected=" + (IsCollected ? 1 : 0) + "" +
           ",PaymentCollectingDate=" + (CollectingDate.ToOADate() - 2).ToString() + "" +
           ",PaymentCollectingUsr=" + CollectingUsr + "" +
           ",PaymentCollectingEmployee=" + CollectingEmployee + "" +
           ",PaymentCollectingBranch=" + CollectingBranch + "" +
           ",PaymentCollectingCoffer=" + CollectingCoffer + "" +
           ",PaymentCollectingRealDate=" + (CollectingRealDate.ToOADate() - 2).ToString() + "" +
           ",CheckEditorName='" + CheckEditorName + "'" +
           ",CheckCode='" + CheckCode + "'" +
           ",CheckValue=" + CheckValue + "" +
           ",CheckIssueDate=" + (CheckIssueDate.ToOADate() - 2).ToString() + "" +
           ",CheckDueDate=" + (CheckDueDate.ToOADate() - 2).ToString() + "" +
           ",CheckPaymentDate=" + (CheckDate.ToOADate() - 2).ToString() + "" +
           ",CheckCurrentStatus=" + CheckCurrentStatus + "" +
           ",CheckCurrentStatusDate=" + (CheckCurrentStatusDate.ToOADate() - 2).ToString() + "" + ",UsrUpd=" + SysData.CurrentUser.ID + @",TimUpd=GetDate()  where ";
                return Returned;
            }
        }
        public string DeleteStr
        {
            get
            {
                string Returned = " update MNROCreditPayment set Dis = GetDate() where  ";
                return Returned;
            }
        }
        public string SearchStr
        {
            get
            {
                string Returned = @"SELECT        dbo.MNROCreditPayment.PaymentID, dbo.MNROCreditPayment.CreditROID, dbo.MNROCreditPayment.CreditID, dbo.GLPayment.PaymentValue, dbo.GLPayment.PaymentDate, dbo.GLPayment.PaymentCurrency, 
                                                    dbo.GLPayment.PaymentCurrencyValue, dbo.GLPayment.PaymentType, dbo.GLPayment.PaymentDesc, dbo.GLPayment.PaymentDirection, dbo.GLPayment.PaymentEmployee, dbo.GLPayment.PaymentBranch, 
                                                    dbo.GLPayment.PaymentCoffer, dbo.GLPayment.PaymentHasReceipt, dbo.GLPayment.PaymentReceipt, dbo.GLPayment.PaymentSourceID, dbo.GLPayment.PaymentReverseID, 
                                                    dbo.GLPayment.PaymentCollectingID, dbo.GLCheckPayment.CheckID, dbo.GLCheckPayment.PaymentIsCollected, dbo.GLCheckPayment.PaymentCollectingDate, dbo.GLCheckPayment.PaymentCollectingUsr, 
                                                    dbo.GLCheckPayment.PaymentCollectingEmployee, dbo.GLCheckPayment.PaymentCollectingBranch, dbo.GLCheckPayment.PaymentCollectingCoffer, dbo.GLCheckPayment.PaymentCollectingRealDate, 
                                                    dbo.GLCheckPayment.PaymentCollectingID AS Expr1, dbo.GLCheck.CheckEditorName, dbo.GLCheck.CheckCode, dbo.GLCheck.CheckValue, dbo.GLCheck.CheckIssueDate, dbo.GLCheck.CheckDueDate, 
                                                    dbo.GLCheck.CheckPaymentDate, dbo.GLCheck.CheckCurrentStatus, dbo.GLCheck.CheckCurrentStatusDate,ROTable.*  
                           FROM            dbo.GLCheck RIGHT OUTER JOIN
                                                    dbo.GLCheckPayment ON dbo.GLCheck.CheckID = dbo.GLCheckPayment.CheckID RIGHT OUTER JOIN
                                                    dbo.MNROCreditPayment INNER JOIN
                                                    dbo.GLPayment ON dbo.MNROCreditPayment.PaymentID = dbo.GLPayment.PaymentID ON dbo.GLCheckPayment.PaymentID = dbo.GLPayment.PaymentID 
   inner join (" + new RODb().SearchStr + @") as ROTable 
    on MNROCreditPayment.CreditROID = ROTable.ROID ";
                return Returned;
            }
        }
        #endregion
        #region Private Method
        void SetData(DataRow objDr)
        {

            if (objDr.Table.Columns["PaymentID"] != null)
                int.TryParse(objDr["PaymentID"].ToString(), out _ID);

            if (objDr.Table.Columns["CreditROID"] != null)
                int.TryParse(objDr["CreditROID"].ToString(), out _CreditROID);

            if (objDr.Table.Columns["CreditID"] != null)
                int.TryParse(objDr["CreditID"].ToString(), out _CreditID);

            if (objDr.Table.Columns["PaymentValue"] != null)
                double.TryParse(objDr["PaymentValue"].ToString(), out _Value);

            if (objDr.Table.Columns["PaymentDate"] != null)
                DateTime.TryParse(objDr["PaymentDate"].ToString(), out _Date);

            if (objDr.Table.Columns["PaymentCurrency"] != null)
                int.TryParse(objDr["PaymentCurrency"].ToString(), out _Currency);

            if (objDr.Table.Columns["PaymentCurrencyValue"] != null)
                double.TryParse(objDr["PaymentCurrencyValue"].ToString(), out _CurrencyValue);

            if (objDr.Table.Columns["PaymentType"] != null)
                int.TryParse(objDr["PaymentType"].ToString(), out _Type);

            if (objDr.Table.Columns["PaymentDesc"] != null)
                _Desc = objDr["PaymentDesc"].ToString();

            if (objDr.Table.Columns["PaymentDirection"] != null)
                bool.TryParse(objDr["PaymentDirection"].ToString(), out _Direction);

            if (objDr.Table.Columns["PaymentEmployee"] != null)
                int.TryParse(objDr["PaymentEmployee"].ToString(), out _Employee);

            if (objDr.Table.Columns["PaymentBranch"] != null)
                int.TryParse(objDr["PaymentBranch"].ToString(), out _Branch);

            if (objDr.Table.Columns["PaymentCoffer"] != null)
                int.TryParse(objDr["PaymentCoffer"].ToString(), out _Coffer);

            if (objDr.Table.Columns["PaymentHasReceipt"] != null)
                bool.TryParse(objDr["PaymentHasReceipt"].ToString(), out _HasReceipt);

            if (objDr.Table.Columns["PaymentReceipt"] != null)
                int.TryParse(objDr["PaymentReceipt"].ToString(), out _Receipt);

            if (objDr.Table.Columns["PaymentSourceID"] != null)
                int.TryParse(objDr["PaymentSourceID"].ToString(), out _SourceID);

            if (objDr.Table.Columns["PaymentReverseID"] != null)
                int.TryParse(objDr["PaymentReverseID"].ToString(), out _ReverseID);

            if (objDr.Table.Columns["PaymentCollectingID"] != null)
                int.TryParse(objDr["PaymentCollectingID"].ToString(), out _CollectingID);

            if (objDr.Table.Columns["CheckID"] != null)
                int.TryParse(objDr["CheckID"].ToString(), out _CheckID);

            if (objDr.Table.Columns["PaymentIsCollected"] != null)
                bool.TryParse(objDr["PaymentIsCollected"].ToString(), out _IsCollected);

            if (objDr.Table.Columns["PaymentCollectingDate"] != null)
                DateTime.TryParse(objDr["PaymentCollectingDate"].ToString(), out _CollectingDate);

            if (objDr.Table.Columns["PaymentCollectingUsr"] != null)
                int.TryParse(objDr["PaymentCollectingUsr"].ToString(), out _CollectingUsr);

            if (objDr.Table.Columns["PaymentCollectingEmployee"] != null)
                int.TryParse(objDr["PaymentCollectingEmployee"].ToString(), out _CollectingEmployee);

            if (objDr.Table.Columns["PaymentCollectingBranch"] != null)
                int.TryParse(objDr["PaymentCollectingBranch"].ToString(), out _CollectingBranch);

            if (objDr.Table.Columns["PaymentCollectingCoffer"] != null)
                int.TryParse(objDr["PaymentCollectingCoffer"].ToString(), out _CollectingCoffer);

            if (objDr.Table.Columns["PaymentCollectingRealDate"] != null)
                DateTime.TryParse(objDr["PaymentCollectingRealDate"].ToString(), out _CollectingRealDate);

            if (objDr.Table.Columns["CheckEditorName"] != null)
                _CheckEditorName = objDr["CheckEditorName"].ToString();

            if (objDr.Table.Columns["CheckCode"] != null)
                _CheckCode = objDr["CheckCode"].ToString();

            if (objDr.Table.Columns["CheckValue"] != null)
                double.TryParse(objDr["CheckValue"].ToString(), out _CheckValue);

            if (objDr.Table.Columns["CheckIssueDate"] != null)
                DateTime.TryParse(objDr["CheckIssueDate"].ToString(), out _CheckIssueDate);

            if (objDr.Table.Columns["CheckDueDate"] != null)
                DateTime.TryParse(objDr["CheckDueDate"].ToString(), out _CheckDueDate);

            if (objDr.Table.Columns["CheckPaymentDate"] != null)
                DateTime.TryParse(objDr["CheckPaymentDate"].ToString(), out _CheckDate);

            if (objDr.Table.Columns["CheckCurrentStatus"] != null)
                int.TryParse(objDr["CheckCurrentStatus"].ToString(), out _CheckCurrentStatus);

            if (objDr.Table.Columns["CheckCurrentStatusDate"] != null)
                DateTime.TryParse(objDr["CheckCurrentStatusDate"].ToString(), out _CheckCurrentStatusDate);
        }

        #endregion
        #region Public Method 
        public void Add()
        {
            string strSql = AddStr;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public void Edit()
        {
            string strSql = EditStr;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public void Delete()
        {
            string strSql = DeleteStr;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public DataTable Search()
        {
            string strSql = SearchStr + " where Dis is null ";


            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        #endregion

    }
}
