using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.SystemBase;
using SharpVision.Base.BaseDataBase;

namespace SharpVision.GL.GLDataBase
{
    public class ReceiptDb
    {
        #region Private Data
        int _ID;
        bool _Direction;
        DateTime _Date;
        string _Desc;
        int _Book;
        int _Model;
        string _ModelDesc;
        int _ModelAttachment;
        double _Value;
        string _DiscountStr;
        string _Beneficiary;
        string _InstallmentDueDate;
        string _CheckSerial;
        string _FullDesc;
        string _PaymentEffect;
        string _PaymentMean;
        string _Note;
        DateTime _CheckDueDate;
        DateTime _WireTranfereDate;
        string _WireTransfereBank;
        

        string _Unit;
        string _Tower;
        string _Project;
        string _Serial;
        //string _ManualSerial;
        int _SerialNum;
        string _ManualSerial = "";
        int _Editor;
        string _EditorName;
        int _Branch;
        string _BranchName;
        int _VersionNo;
        int _Status;
        DataTable _PaymentTable;
        #region Private Data For Search
        bool _IsDateRange;
        DateTime _StartDate;
        DateTime _EndDate;
        bool _IsStatusDateRange;
        DateTime _StartStatusDate;
        DateTime _EndStatusDate;
        string _IDsStr;


        #endregion
        #endregion
        #region Constructors
        public ReceiptDb()
        { 
        }
        public ReceiptDb(DataRow objDr)
        {
            SetData(objDr);
        }
        #endregion
        #region Public Properties
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
        public int VersionNo
        {
            set
            {
                _VersionNo = value;
            }
            get 
            {
                return _VersionNo;
            }
        }
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
        public int Book
        {
            set
            {
                _Book = value;
            }
            get
            {
                return _Book;
            }
        }
        public int Model
        {
            set
            {
                _Model= value;
            }
            get
            {
                return _Model;
            }
        }
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
        public string DiscountStr
        {
            set
            {
                _DiscountStr = value;
            }
            get
            {
                return _DiscountStr;
            }
        }
        public string Beneficiary
        {
            set
            {
                _Beneficiary = value;
            }
            get
            {
                return _Beneficiary;
            }
        }
        public string Unit
        {
            set
            {
                _Unit = value;
            }
            get
            {
                return _Unit;
            }
        }
        public string Tower
        {
            set
            {
                _Tower = value;
            }
            get
            {
                return _Tower;
            }
        }
        public string Project
        {
            set
            {
                _Project = value;
            }
            get
            {
                return _Project;
            }
        }
        public string Serial
        {
            set
            {
                _Serial = value;
            }
            get
            {
                if (_Serial == null)
                    _Serial = "";
                return _Serial;
            }
        }
        public string ManualSerial
        {
            set
            {
                _ManualSerial = value;
            }
            get
            {
                if (_ManualSerial == null)
                    _ManualSerial = "";
                return _ManualSerial;
            }
        }
         
        public int SerialNum
        {
            set
            {
                _SerialNum = value;
            }
            get
            {
                return _SerialNum;
            }
        }
        public int Editor
        {
            set
            {
                _Editor = value;
            }
            get
            {
                return _Editor;
            }
        }
        public string EditorName
        {
            set
            {
                _EditorName = value;
            }
            get
            {
                if (_EditorName == null)
                    _EditorName = "";
                return _EditorName;
            }
        }
        public int Status
        {
            set
            {
                _Status = value;
            }
            get
            {
                return _Status;
            }
        }
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

        public string BranchName
        {
            set
            {
                _BranchName = value;
            }
            get
            {
                return _BranchName;
            }
        }
        public string InstallmentDueDate
        {
            set
            {
                _InstallmentDueDate = value;
            }
            get
            {
                return _InstallmentDueDate;
            }
        }
        public string CheckSerial
        {
            set
            {
                _CheckSerial = value;
            }
            get
            {
                return _CheckSerial;
            }
        }
        public string FullDesc
        {
            set
            {
                _FullDesc = value;
            }
            get
            {
                return _FullDesc;
            }
        }
        public string PaymentEffect
        {
            set
            {
                _PaymentEffect = value;
            }
            get
            {
                return _PaymentEffect;
            }
        }
        public string PaymentMean
        {
            set
            {
                _PaymentMean = value;
            }
            get
            {
                return _PaymentMean;
            }
        }
        public string Note
        {
            set
            {
                _Note = value;
            }
            get
            {
                return _Note;
            }
        }
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
        public DateTime WireTranfereDate
        {
            set
            {
                _WireTranfereDate = value;
            }
            get
            {
                return _WireTranfereDate;
            }
        }
        public string WireTransfereBank
        {
            set
            {
                _WireTransfereBank = value;
            }
            get
            {
                return _WireTransfereBank;
            }
        }
        public string ModelDesc
        {
            get
            {
                return _ModelDesc;
            }
        }
        string _IP;

        public string IP
        {
            get { return _IP; }
            set { _IP = value; }
        }
        int _Type;

        public int Type
        {
            get { return _Type; }
            set { _Type = value; }
        }
        public int ModelAttachment
        {
            get 
            {
                return _ModelAttachment;
            }
        }
        public DataTable PaymentTable
        {
            set
            {
                _PaymentTable = value;
            }
        }
        public bool IsDateRange
        {
            set
            {
                _IsDateRange = value;
            }
        }
        public DateTime StartDate
        {
            set
            {
                _StartDate = value;
            }
        }
        public DateTime EndDate
        {
            set
            {
                _EndDate = value;
            }

        }
        public bool IsStatusDateRange
        {
            set
            {
                _IsStatusDateRange = value;
            }
        }
        public DateTime StartStatusDate
        {
            set
            {
                _StartStatusDate = value;   
            }
        }
        public DateTime EndStatusDate
        {
            set
            {
                _EndStatusDate = value;
            }
        }
        public string IDsStr
        {
            set
            {
                _IDsStr = value;
            }
        }
        public string AddStr
        {
            get
            {
                int intDirection = _Direction ? 1 : 0;
                double dblDate = SysUtility.Approximate(_Date.ToOADate() - 2, 1, ApproximateType.Down);
                dblDate = _Date.ToOADate() - 2;
                string strCheckDueDate = SysUtility.Approximate(_CheckDueDate.ToOADate()-2,1,ApproximateType.Down) >2 ?
                    SysUtility.Approximate(_CheckDueDate.ToOADate()-2,1,ApproximateType.Down).ToString() : "Null";
                string strTransfereDate = SysUtility.Approximate(_WireTranfereDate.ToOADate() - 2, 1, ApproximateType.Down) > 2 ?
                  SysUtility.Approximate(_WireTranfereDate.ToOADate() - 2, 1, ApproximateType.Down).ToString() : "Null";
                string strMaxSrial = "SELECT  MAX(GLReceipt_1.ReceiptSerialNum) AS MaxSerialNum "+
                       " FROM         dbo.GLReceipt INNER JOIN "+
                       " dbo.GLReceipt AS GLReceipt_1 ON  "+
                       "  dbo.GLReceipt.ReceiptDirection = GLReceipt_1.ReceiptDirection " +
                       " WHERE     (dbo.GLReceipt.ReceiptID = @ID)";
                string Returned = " declare @ID int "+
                    "  insert into GLReceipt (ReceiptDirection,ReceiptDate, ReceiptBook, ReceiptModel, ReceiptValue" +
                    ", ReceiptDesc, ReceiptBeneficiary, ReceiptSerial"+
                    ", ReceiptSerialNum, ReceiptEditor,ReceiptEditorName,ReceiptBranch,ReceiptBranchName, VersionNo,  " +
                       "ReceiptStatus"+
                       ", ReceiptStatusDate, ReceiptInstallmentDueDate, ReceiptCheckSerial, ReceiptFullDesc, ReceiptPaymentEffect, ReceiptPaymentMean, ReceiptNote, "+
                       "ReceiptCheckDueDate, ReceiptWireTranfereDate, ReceiptWireTransfereBank, ReceiptUnit"+
                       ", ReceiptTower, ReceiptProject, ReceiptManualSerial,ReceiptIP"+
                       ",ReceiptType,UsrIns,TimIns) " +
                       " values ("+ intDirection + "," + dblDate + "," + _Book + "," +_Model + "," + _Value +
                       ",'" + _Desc + "','" + _Beneficiary + "','" +_Serial + "'," +
                       _SerialNum + "," + _Editor  + ",'" + _EditorName + "'," + _Branch + ",'" + _BranchName +"',"+ 
                       _VersionNo + "," + 
                       _Status +",GetDate(),'" + _InstallmentDueDate + "','" + _CheckSerial + "','" + _FullDesc + "','" + _PaymentEffect + "','" + 
                        _PaymentMean + "','" + _Note+ "',"+ strCheckDueDate + "," + strTransfereDate + ",'"+ _WireTransfereBank +"','" +
                        _Unit + "','" + _Tower + "','" + _Project +"','"+_ManualSerial + "'"+
                        ",'"+ _IP + "',"+  _Type + ","+
                        SysData.CurrentUser.ID + ",GetDate()) ";
                Returned += " set @ID = @@IDENTITY ";
                Returned += " update GLReceipt set ReceiptSerialNum = ("+ strMaxSrial +")  "+
                    "  where ReceiptID = @ID ";
                Returned += @" update GLReceipt set ReceiptSerialNum= ReceiptSerialNum+1, ReceiptSerial =convert(varchar(10),year(GetDate())) +'/'+ convert (varchar(50), ReceiptSerialNum+1)   " +
                    "  where ReceiptID = @ID ";
                
                return Returned;
            }
        }
        
        public string EditStr
        {
            get
            {
                double dblDate = SysUtility.Approximate(_Date.ToOADate() - 2, 1, ApproximateType.Down);
                dblDate = _Date.ToOADate() - 2;
                string Returned = "update GLReceipt "+
                    " set ReceiptDate ="+dblDate +
                    ", ReceiptBook="+ _Book +
                    ", ReceiptModel="+_Model +
                    ", ReceiptValue=" + _Value +
                    ", ReceiptDesc'"+ _Desc +"'"+
                    ", ReceiptBeneficiary='"+ _Beneficiary +"'"+
                    ", ReceiptSerial='" + _Serial +"'"+
                    ", ReceiptEditor="+ _Editor +
                    ", VersionNo="+ _VersionNo +

                    ",ReceiptStatus="+_Status +
                    ",ReceiptIP='"+ _IP+"'"+
                    ",ReceiptType="+_Type +
                    ",UsrUpd="+SysData.CurrentUser.ID+
                    ",TimUpd = GetDate() "+
                    " where ReceiptID="+ID;
                return Returned;
            }
        }
        public string EditStatusStr
        {
            get
            {
                double dblDate = SysUtility.Approximate(_Date.ToOADate() - 2, 1, ApproximateType.Down);
                dblDate = _Date.ToOADate() - 2;
                string Returned = "update GLReceipt " +
                    " set ReceiptStatus=" + _Status +
                    ",ReceiptStatusDate=GetDate() "+
                    ",UsrUpd=" + SysData.CurrentUser.ID +
                    ",TimUpd = GetDate() ";
                if (_ID != 0)
                    Returned += " where ReceiptID=" + ID;
                else if (_IDsStr != null && _IDsStr != "")
                    Returned += " where ReceiptID in (" + _IDsStr + ")";
                else
                    Returned += " where 1=0 ";

                   
                return Returned;
            }
        }
        public string DeleteStr
        {
            get
            {
                string Returned = "delete from GLReceipt "+
                    " where ReceiptID=" + ID;
                return Returned;
            }
        }
        public static string SearchStr
        {
            get
            {
                string strBranch = "SELECT BranchID AS ReceiptBranchID, BranchNameA AS ReceiptBranchName "+
                       " FROM  dbo.HRBranch ";
                string strModel = "SELECT     ModelID, ModelDesc, ModelAttachmentID "+
                       " FROM         dbo.GLReceiptModel ";
                string Returned = "SELECT  dbo.GLReceipt.ReceiptID,GLReceipt.ReceiptDate, dbo.GLReceipt.ReceiptBook, dbo.GLReceipt.ReceiptModel, dbo.GLReceipt.ReceiptValue, dbo.GLReceipt.ReceiptDesc," + 
                      " dbo.GLReceipt.ReceiptBeneficiary, dbo.GLReceipt.ReceiptSerial, dbo.GLReceipt.ReceiptSerialNum"+
                      ", dbo.GLReceipt.ReceiptEditor,dbo.GLReceipt.ReceiptEditorName,dbo.GLReceipt.VersionNo, dbo.GLReceipt.ReceiptStatus,BranchTable.* " +
                      ",  ReceiptStatusDate, ReceiptInstallmentDueDate, ReceiptCheckSerial, ReceiptFullDesc, ReceiptPaymentEffect, ReceiptPaymentMean, ReceiptNote, "+
                      " ReceiptCheckDueDate, ReceiptWireTranfereDate, ReceiptWireTransfereBank, ReceiptUnit, ReceiptTower, ReceiptProject, ReceiptManualSerial,ReceiptIP "+
                     ",ModelTable.* "+
                      " FROM  dbo.GLReceipt LEFT OUTER JOIN "+
                      " ("+ strModel +") AS ModelTable ON dbo.GLReceipt.ReceiptModel = ModelTable.ModelID LEFT OUTER JOIN "+
                      " dbo.GLReceiptBook AS BookTable ON dbo.GLReceipt.ReceiptBook = BookTable.ReceiptBookID "+
                      " left outer join ("+ strBranch +") as BranchTable "+
                      " on GLReceipt.ReceiptBranch = BranchTable.ReceiptBranchID "; 
                
                return Returned;
            }
        }
        public string StrSearch
        {
            get 
            {
                string Returned = SearchStr + " where 1=1 ";
                 Returned +=" and  dbo.GLReceipt.ReceiptStatus ="+_Status;
                 double dblStart = SysUtility.Approximate(_StartDate.ToOADate() - 2, 1, ApproximateType.Down);
                 double dblEnd = SysUtility.Approximate(_EndDate.ToOADate() - 2, 1, ApproximateType.Up);
                 if (_IsDateRange)
                 {
                     Returned += " and GLReceipt.ReceiptDate >= "+ dblStart + " and GLReceipt.ReceiptDate < " + dblEnd ;
                 }
                 dblStart = SysUtility.Approximate(_StartStatusDate.ToOADate() - 2, 1, ApproximateType.Down);
                 dblEnd = SysUtility.Approximate(_EndStatusDate.ToOADate() - 2, 1, ApproximateType.Up);
                 if(_IsStatusDateRange)
                     Returned += " and GLReceipt.ReceiptStatusDate >= " + dblStart +
                     " and GLReceipt.ReceiptStatusDate < "+ dblEnd;
                if (_Serial != null && _Serial != "")
                    Returned += " and (dbo.GLReceipt.ReceiptSerial like '%" + _Serial + "%' or dbo.GLReceipt.ReceiptManualSerial like '%"+_Serial +"%')";
                 if (_Branch != 0)
                     Returned += " and GLReceipt.ReceiptBranch="+_Branch;
                 if (_Editor != 0)
                     Returned += " and GLReceipt.ReceiptEditor="+_Editor;
                 if (_Unit != null && _Unit != "")
                     Returned += " and GLReceipt.ReceiptUnit like '"+ _Unit +"'";
                 if (_Beneficiary != null && _Beneficiary != "")
                     Returned += " and GLReceipt.ReceiptBeneficiary like '" + _Beneficiary + "'";
                return Returned;
            }
        }
        #endregion
        #region Private Methods
        void SetData(DataRow objDr)
        {
            _ID = int.Parse( objDr["ReceiptID"].ToString());
            _Date = DateTime.Parse(objDr["ReceiptDate"].ToString());
            _Book = int.Parse(objDr["ReceiptBook"].ToString());
            _Model = int.Parse(objDr["ReceiptModel"].ToString());
            if (objDr.Table.Columns["ModelDesc"] != null)
                _ModelDesc = objDr["ModelDesc"].ToString();
            if (objDr.Table.Columns["ModelAttachmentID"] != null && objDr["ModelAttachmentID"].ToString() != "")
                _ModelAttachment = int.Parse(objDr["ModelAttachmentID"].ToString());
            _Value = double.Parse(objDr["ReceiptValue"].ToString());
            _Desc = objDr["ReceiptDesc"].ToString();
            _Beneficiary = objDr["ReceiptBeneficiary"].ToString();
            _Serial = objDr["ReceiptSerial"].ToString();
            _SerialNum = int.Parse(objDr["ReceiptSerialNum"].ToString());
            _Editor =int.Parse( objDr["ReceiptEditor"].ToString());
            _EditorName = objDr["ReceiptEditorName"].ToString();
            _VersionNo = int.Parse(objDr["VersionNo"].ToString());

            _Status = int.Parse(objDr["ReceiptStatus"].ToString());
            if(objDr["ReceiptBranchID"].ToString()!= "")
              _Branch = int.Parse(objDr["ReceiptBranchID"].ToString());
            _BranchName = objDr["ReceiptBranchName"].ToString();
            _InstallmentDueDate = objDr["ReceiptInstallmentDueDate"].ToString();
            _CheckSerial = objDr["ReceiptCheckSerial"].ToString();
            _FullDesc = objDr["ReceiptFullDesc"].ToString();
            _PaymentEffect = objDr["ReceiptPaymentEffect"].ToString();
            _PaymentMean = objDr["ReceiptPaymentMean"].ToString();
            _Note = objDr["ReceiptNote"].ToString();
            if(objDr["ReceiptCheckDueDate"].ToString()!= "")
            _CheckDueDate = DateTime.Parse(objDr["ReceiptCheckDueDate"].ToString());
        if (objDr["ReceiptWireTranfereDate"].ToString() != "")
            _WireTranfereDate = DateTime.Parse(objDr["ReceiptWireTranfereDate"].ToString());
            _WireTransfereBank = objDr["ReceiptWireTransfereBank"].ToString();
            _Unit = objDr["ReceiptUnit"].ToString();
            _Tower = objDr["ReceiptTower"].ToString();
            _Project = objDr["ReceiptProject"].ToString();
            _ManualSerial = objDr["ReceiptManualSerial"].ToString();
        }
        #endregion
        #region Public Methods
        public virtual void Add()
        {
            string strSql = AddStr;
            _ID = SysData.SharpVisionBaseDb.InsertIdentityTable(strSql);
           
            string strSerial = "SELECT     ReceiptSerial, ReceiptSerialNum "+
                   " FROM         dbo.GLReceipt "+
                   " WHERE     (ReceiptID = "+ _ID +")";
            DataTable dtTemp = SysData.SharpVisionBaseDb.ReturnDatatable(strSerial);
            if (dtTemp.Rows.Count > 0)
            {
                _Serial = dtTemp.Rows[0]["ReceiptSerial"].ToString();
                _SerialNum = int.Parse(dtTemp.Rows[0]["ReceiptSerialNum"].ToString());
            }
            JoinReservationPayment();

        }
        public virtual void Edit()
        {
            string strSql = EditStr;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
            JoinReservationPayment();
        }
        public  void EditStatus()
        {
            string strSql = EditStatusStr;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
            JoinReservationPayment();
        }
        public virtual void Delete()
        {
            string strSql = DeleteStr;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public virtual DataTable Search()
        {
            string strSql = StrSearch;
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        public void JoinReservationPayment()
        {
            if (_PaymentTable == null || _PaymentTable.Rows.Count == 0 || _ID == 0)
                return;
            List<string> arrStr = SysUtility.GetStringArr(_PaymentTable, "PaymentID", 5000);
            if (arrStr.Count > 0)
            {
                string strSql = "insert into  dbo.GLReceiptPayment ( ReceiptID, PaymentID, PaymentValue)  "+
                    "  SELECT     "+ ID +" AS ReceiptID, PaymentID, PaymentValue "+
                    " FROM         dbo.GLPayment "+
                    " where PaymentID in ("+ arrStr[0] +")  " +
                    " update GLReceipt "+
                    " set VersionNo = "+
                    "(SELECT     MAX(ReceiptNo) AS VersionNo "+
                    " FROM         (SELECT     PaymentID, COUNT(ReceiptID) AS ReceiptNo "+
                    " FROM         dbo.GLReceiptPayment "+
                    " WHERE     (PaymentID IN ("+ arrStr[0] +")) "+
                    "  GROUP BY PaymentID) AS derivedtbl_1)"+
                    "  where ReceiptID="+ _ID;
                strSql += "  update CRMReservationInstallmentDiscount set DiscountReceipt = "+ _ID + 
                      " FROM   dbo.CRMReservationInstallmentDiscount INNER JOIN "+
                      " dbo.CRMInstallmentPayment ON dbo.CRMReservationInstallmentDiscount.InstallmentID = dbo.CRMInstallmentPayment.InstallmentID "+
                      " WHERE     (dbo.CRMInstallmentPayment.PaymentID IN ("+ arrStr[0] +")) AND (dbo.CRMReservationInstallmentDiscount.DiscountReceipt = 0) ";
                SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
                strSql = "SELECT  VersionNo FROM     dbo.GLReceipt "+
                     " WHERE     (ReceiptID ="+ _ID +")";
                _VersionNo = (int)SysData.SharpVisionBaseDb.ReturnScalar(strSql);


            }
        }
        #endregion
    }
}
