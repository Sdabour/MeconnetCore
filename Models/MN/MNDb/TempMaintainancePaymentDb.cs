using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using SharpVision.SystemBase;
namespace AlgorithmatMN.MN.MNDb
{
    public class TempMaintainancePaymentDb
    {

        #region Constructor
        public TempMaintainancePaymentDb()
        {
        }
        public TempMaintainancePaymentDb(DataRow objDr)
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
        int _InternalRef;
        public int InternalRef
        {
            set
            {
                _InternalRef = value;
            }
            get
            {
                return _InternalRef;
            }
        }
        int _PayementInternalType;
        public int PayementInternalType
        {
            set
            {
                _PayementInternalType = value;
            }
            get
            {
                return _PayementInternalType;
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
        int _System;
        public int System
        {
            set
            {
                _System = value;
            }
            get
            {
                return _System;
            }
        }
        int _GLID;
        public int GLID
        {
            set
            {
                _GLID = value;
            }
            get
            {
                return _GLID;
            }
        }
        string _BankRef;
        public string BankRef
        {
            set
            {
                _BankRef = value;
            }
            get
            {
                return _BankRef;
            }
        }
        string _TempPaymentRef;
        public string TempPaymentRef { get => _TempPaymentRef; }
        public string AddStr
        {
            get
            {
                string Returned = " insert into MNROCreditTempPayment (PaymentDate,PaymentValue,PaymentInternalRef,PayementInternalType,PaymentDesc,PaymentSystem,GLPaymentID,BankRef) values (GetDate()," + Value + "," + InternalRef + "," + PayementInternalType + ",'" + Desc + "'," + System + "," + GLID + ",'" + BankRef + @"')  
";
                Returned += @" declare @TempPaymentID numeric(18,0); 
   set @TempPaymentID = (select @@IDENTITY); 
   SELECT PaymentID, PaymentDate, { fn MINUTE(PaymentDate) } AS PaymentMinute, { fn SECOND(PaymentDate) } AS PaymentSecond
FROM     dbo.MNROCreditTempPayment
WHERE  (PaymentID = @TempPaymentID)";
                return Returned;
            }
        }
        public string EditStr
        {
            get
            {
                string Returned = " update MNROCreditTempPayment set PaymentDate=" + (Date.ToOADate() - 2).ToString() + "" +
           ",PaymentValue=" + Value + "" +
           ",PaymentInternalRef=" + InternalRef + "" +
           ",PayementInternalType=" + PayementInternalType + "" +
           ",PaymentDesc='" + Desc + "'" +
           ",PaymentSystem=" + System + "" +
           ",GLPaymentID=" + GLID + "" +
           ",BankRef='" + BankRef + "'" + ",UsrUpd=" + SysData.CurrentUser.ID + @",TimUpd=GetDate()  where PaymentID = "+_ID;
                return Returned;
            }
        }
        public string DeleteStr
        {
            get
            {
                string Returned = " update MNROCreditTempPayment set Dis = GetDate() where  ";
                return Returned;
            }
        }
        public string SearchStr
        {
            get
            {
                string Returned = " select PaymentID,PaymentDate,PaymentValue,PaymentInternalRef,PayementInternalType,PaymentDesc,PaymentSystem,GLPaymentID,BankRef from MNROCreditTempPayment  ";
                return Returned;
            }
        }
        #endregion
        #region Private Method
        void SetData(DataRow objDr)
        {

            if (objDr.Table.Columns["PaymentID"] != null)
                int.TryParse(objDr["PaymentID"].ToString(), out _ID);

            if (objDr.Table.Columns["PaymentDate"] != null)
                DateTime.TryParse(objDr["PaymentDate"].ToString(), out _Date);

            if (objDr.Table.Columns["PaymentValue"] != null)
                double.TryParse(objDr["PaymentValue"].ToString(), out _Value);

            if (objDr.Table.Columns["PaymentInternalRef"] != null)
                int.TryParse(objDr["PaymentInternalRef"].ToString(), out _InternalRef);

            if (objDr.Table.Columns["PayementInternalType"] != null)
                int.TryParse(objDr["PayementInternalType"].ToString(), out _PayementInternalType);

            if (objDr.Table.Columns["PaymentDesc"] != null)
                _Desc = objDr["PaymentDesc"].ToString();

            if (objDr.Table.Columns["PaymentSystem"] != null)
                int.TryParse(objDr["PaymentSystem"].ToString(), out _System);

            if (objDr.Table.Columns["GLPaymentID"] != null)
                int.TryParse(objDr["GLPaymentID"].ToString(), out _GLID);

            if (objDr.Table.Columns["BankRef"] != null)
                _BankRef = objDr["BankRef"].ToString();
        }

        #endregion
        #region Public Method 
        public void Add()
        {
            string strSql = AddStr;
           DataTable dtTemp = SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
            if(dtTemp!= null&& dtTemp.Rows.Count>0)
            {
                int.TryParse(dtTemp.Rows[0]["PaymentID"].ToString(), out _ID);
                string strSecond = dtTemp.Rows[0]["PaymentSecond"].ToString().PadLeft(2,'0');
                string strMinute = dtTemp.Rows[0]["PaymentMinute"].ToString().PadLeft(2,'0');
                _TempPaymentRef = strMinute + strSecond + _ID.ToString();
            }
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
            string strSql = SearchStr + " where (1=1) ";


            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        #endregion
    }
}