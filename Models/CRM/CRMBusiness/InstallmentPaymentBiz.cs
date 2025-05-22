using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.Base.BaseDataBase;
using SharpVision.Base.BaseBusiness;
using SharpVision.CRM.CRMDataBase;
using SharpVision.SystemBase;
using SharpVision.GL.GLBusiness;
using SharpVision.COMMON.COMMONBusiness;
namespace SharpVision.CRM.CRMBusiness
{
    //public enum PaymentType
    //{
    //    Cash,
    //    Check,
    //    BankingTransfering
 
    //}
    public class InstallmentPaymentBiz : PaymentBiz
    {

        #region Private Data
        PaymentTypeBiz _PaymentTypeBiz;
        ReservationInstallmentBiz _InstallmentBiz;
        static AccountBiz _CofferAccountBiz;
        double _OldPaymentValue;
        #endregion
        #region Constructors

         public InstallmentPaymentBiz()
        {
            _PaymentDb = new InstallmentPaymentDb();
            _InstallmentBiz = new ReservationInstallmentBiz();
        }

        public InstallmentPaymentBiz(DataRow objDR)
        {
            _PaymentDb = new InstallmentPaymentDb(objDR);
            _InstallmentBiz = new ReservationInstallmentBiz();
            if (_PaymentDb.CheckID != 0)
                _CheckBiz = new CheckBiz(objDR);
            else
                _CheckBiz = new CheckBiz();

        }

        #endregion
        #region Public Properties
        public int InstallmentID
        {
            set
            {
                ((InstallmentPaymentDb)_PaymentDb).InstallmentID = value;
            }
            get
            {
                return ((InstallmentPaymentDb)_PaymentDb).InstallmentID;
            }

        }
        public ReservationInstallmentBiz InstallmentBiz
        {
            set
            {
                _InstallmentBiz = value;
            }
            get
            {
                return _InstallmentBiz;
            }
        }
        public bool EnableTempEditing
        {
            get
            {
                if (((InstallmentPaymentDb)_PaymentDb).TimIns >= DateTime.Now.AddHours(-6))
                {
                    return true;
                }
                return false;
            }
        }
        public static AccountBiz CofferAccountBiz
        {
            set
            {
                _CofferAccountBiz = value;
            }
            get
            {
                if (_CofferAccountBiz == null)
                {
                    _CofferAccountBiz = new AccountBiz();
                    SupperCodeBiz objTemp = new SupperCodeBiz("CofferAccount");
                    if (objTemp.ID != 0)
                    {
                        try
                        {
                            _CofferAccountBiz = new AccountBiz(int.Parse(objTemp.Value));
                        }
                        catch
                        {
 
                        }
                    }
                }
                return _CofferAccountBiz;
            }
        }
        public TransactionBiz TransactionBiz
        {
            get
            {
                TransactionBiz Returned = new TransactionBiz();
                Returned.CurrencyBiz = CurrencyBiz.CurrencyCol.GetCurrencyByID(1);
                Returned.CurrencyValue = 1;
                Returned.Date = Date;
                Returned.Desc = "æÍÏÉ : " + InstallmentBiz.Reservation.UnitFullName + " - " + 
                    InstallmentBiz.Reservation.CustomerStr + " - ÞÓØ ÑÞã " + InstallmentBiz.InstallmentNo.ToString(); 
                Returned.TypeBiz = JournalTypeBiz.JournalTypeCol.GetJournalTypeByID(1);
                TransactionElementBiz objCreditBiz,objDebitBiz;
                #region Credit Element
                //Direction = true 
                objCreditBiz = new TransactionElementBiz();
                objCreditBiz.Direction = true;
                objCreditBiz.AccountBiz = CofferAccountBiz;
                //objCreditBiz.AccountBiz.ID = SysData.CofferAccountID;
                objCreditBiz.Value = Value;
                objCreditBiz.TransactionBiz = Returned;
                Returned.ElementCol.Add(objCreditBiz);
                #endregion
                #region DebitElement
                //Direction = false;
                objDebitBiz = new TransactionElementBiz();
                objDebitBiz.Direction = false;
                objDebitBiz.AccountBiz = InstallmentBiz.Reservation.LeafAccountBiz;
                objDebitBiz.Value = Value;
                objDebitBiz.TransactionBiz = Returned;
                Returned.ElementCol.Add(objDebitBiz);
                #endregion
                return Returned;
            }
        }

        #endregion
        #region Private Methods
        void GetData()
        {
            _PaymentDb.Currency = 1;
            _PaymentDb.CurrencyValue = 1;
            if (_CheckBiz != null && _CheckBiz.Value > 0 && _CheckBiz.ID == 0)
            {
                _CheckBiz.Status = CheckStatus.Postponeded;
                _CheckBiz.Add();
            }
            if (_CheckBiz != null && _CheckBiz.ID != 0)
            {
                _PaymentDb.CheckID = _CheckBiz.ID;
              
                _PaymentDb.CheckPreviousTotalPayment = _CheckBiz.TotalPayment;
            }
            _PaymentDb.Desc = "ÓÏÇÏ " + _InstallmentBiz.Type.Name + " ÑÞã " +
                  _InstallmentBiz.InstallmentNo.ToString() + " Úä ÍÌÒ (" + _InstallmentBiz.Reservation.DirectUnitCodeStr + ")";
            _PaymentDb.Desc = "ÓÏÇÏ ÞÓØ Úä æÍÏÉ : " +
               _InstallmentBiz.Reservation.DirectUnitCodeStr + " ãÔÑæÚ :" +_InstallmentBiz.Reservation.DirectProjectName;
            _PaymentDb.CollectingCofferID = CollectingCofferBiz.ID;
            _PaymentDb.CofferID = CofferBiz.ID;
            ((InstallmentPaymentDb)_PaymentDb).InstallmentID = _InstallmentBiz.ID;

         
        }
        #endregion
        #region Public Methods
        public override void Add()
        {
            GetData();

            //if (Value >= _InstallmentBiz.VirtualRemainingValue)
            //{
            //    _InstallmentBiz.EditStatus(InstallmentStatus.Paid,false);
            //}
            ((InstallmentPaymentDb)_PaymentDb).Add();

            
        }
        public override void Edit()
        {

            GetData();
           //if (_InstallmentBiz.VirtualRemainingValue<= 0)
           // {
           //     _InstallmentBiz .EditStatus(InstallmentStatus.Paid,false);
           // }
           // else
           // {
           //     if(_InstallmentBiz.InstallmentStatus == InstallmentStatus.Paid)
           //     {
           //         _InstallmentBiz.EditStatus(InstallmentStatus.Created,true);
           //     }
           // }
            ((InstallmentPaymentDb)_PaymentDb).Edit();


        }
        public void AddCollectedPayment(DateTime dtCollectingDate,
        int intEmployeeID, int intBranchID, int intCofferID, PaymentCacheType objPaymentType, int intOldPayment)
        {
            if (_CheckBiz == null || _CheckBiz.ID == 0)
                return;
            GetData();
            _PaymentDb.CheckID = CheckBiz.ID;
            _PaymentDb.WireTransafere = WireTransfereBiz.ID;
            _PaymentDb.CofferID = CofferBiz.ID;
            _PaymentDb.CollectingCofferID = CollectingCofferBiz.ID;
            _PaymentDb.CheckID = _CheckBiz.ID;
            _PaymentDb.IsCollected = true;
            _PaymentDb.CollectingDate = dtCollectingDate;
            _PaymentDb.CollectingEmployeeID = intEmployeeID;
            _PaymentDb.CollectingBranchID = intBranchID;
            _PaymentDb.CollectingCofferID = intCofferID;
        
            // _PaymentDb.Type = blIsCollected ? (objPaymentType == PaymentCacheType.BankingTransfering ? (int)PaymentType.BankingTransfering : (objPaymentType == PaymentCacheType.Visa ? (int) PaymentType.Visa : (int)PaymentType.Cash)) : (int)PaymentType.Check;
            _PaymentDb.Type = (int)objPaymentType;
            _PaymentDb.OldPaymentID = intOldPayment;
            _PaymentDb.Add();

        }
        public bool AddDiscount(double dblDiscountValue, DiscountTypeBiz objDiscoutType, 
            string strDiscountDesc,DateTime dtDiscountDate,int intUserID)
        {
            InstallmentPaymentDb objDb = new InstallmentPaymentDb();
            objDb.InstallmentID = InstallmentBiz.ID;
            objDb.ID = ID;
            objDb.DiscountDate = dtDiscountDate;
            objDb.DiscountDesc = strDiscountDesc;
            objDb.DiscountType = objDiscoutType.ID;
            objDb.DiscountValue = dblDiscountValue;
            objDb.UserID = intUserID;
            objDb.ApplyDiscount();
            return objDb.DiscountID > 0;
             
           
        }
        public void Delete()
        {
            double dblPaymentValue = _InstallmentBiz.PaymentCol.Value;
            int intIndex = _InstallmentBiz.PaymentCol.GetIndex(ID);
            if (intIndex != -1)
                _InstallmentBiz.PaymentCol.RemoveAt(intIndex);

            //if (_InstallmentBiz.VirtualRemainingValue <= 0)
            //{
            //    _InstallmentBiz.EditStatus(InstallmentStatus.Paid,false);
            //}
            //else
            //{
            //    if (_InstallmentBiz.InstallmentStatus == InstallmentStatus.Paid || dblPaymentValue == _InstallmentBiz.InstallmentValue)
            //    {
            //        _InstallmentBiz.EditStatus(InstallmentStatus.Created,true);
            //    }
            //}
            ((InstallmentPaymentDb)_PaymentDb).Delete();

        }
        public void CreateTransaction()
        {
            TransactionCol objTemp = new TransactionCol(true);
            objTemp.Add(TransactionBiz);
            ((InstallmentPaymentDb)_PaymentDb).TransactionTable = objTemp.GetTable();
            ((InstallmentPaymentDb)_PaymentDb).TransactionElementTable = TransactionBiz.ElementCol.GetTable();

            ((InstallmentPaymentDb)_PaymentDb).CreateTransaction();
        }
        #endregion

    }
}
