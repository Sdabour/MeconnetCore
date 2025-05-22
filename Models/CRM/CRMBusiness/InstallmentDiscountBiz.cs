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
    public class InstallmentDiscountBiz
    {
        #region Private Data
        InstallmentDiscountDb _InstallmentDiscountDb;
        ReservationInstallmentBiz _InstallmentBiz;
        DiscountTypeBiz _TypeBiz;
        TransactionBiz _TransactionBiz;
        static AccountBiz _DiscountAccountBiz;
        #endregion
        #region Constructors
        public InstallmentDiscountBiz()
        {

            _InstallmentDiscountDb = new InstallmentDiscountDb();
            _InstallmentBiz = new ReservationInstallmentBiz();

        }
        public InstallmentDiscountBiz(int intID)
        {
            _InstallmentDiscountDb = new InstallmentDiscountDb(intID);

        }
        public InstallmentDiscountBiz(DataRow objDR)
        {
            _InstallmentDiscountDb = new InstallmentDiscountDb(objDR);
            _InstallmentBiz = new ReservationInstallmentBiz(objDR);
            if (_InstallmentDiscountDb.TypeID != 0)
                _TypeBiz = new DiscountTypeBiz(objDR);
            else
                _TypeBiz = new DiscountTypeBiz();

        }
        #endregion
        #region Public Properties
        public DateTime Date
        {
            set
            {
                _InstallmentDiscountDb.Date = value;
            }
            get
            {
                return _InstallmentDiscountDb.Date;
            }

        }
        public string Reason
        {
            set
            {
                _InstallmentDiscountDb.Reason = value;
            }
            get
            {
                return _InstallmentDiscountDb.Reason;
            }

        }
        public double Value
        {
            set
            {
                _InstallmentDiscountDb.Value = value;
            }
            get
            {
                return _InstallmentDiscountDb.Value;
            }

        }
        public int InstallmentID
        {
            set
            {
                _InstallmentDiscountDb.InstallmentID = value;
            }
            get
            {
                return _InstallmentDiscountDb.InstallmentID;
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
        public int ID
        {
            set
            {
                _InstallmentDiscountDb.ID = value;
            }
            get
            {
                return _InstallmentDiscountDb.ID;
            }

        }
        public DiscountTypeBiz TypeBiz
        {
            set
            {
                _TypeBiz = value;
            }
            get
            {
                return _TypeBiz;
            }
        }
        public static AccountBiz DiscountAccountBiz
        {
            set
            {
                _DiscountAccountBiz = value;
            }
            get
            {
                if (_DiscountAccountBiz == null)
                {
                    _DiscountAccountBiz = new AccountBiz();
                    SupperCodeBiz objTemp = new SupperCodeBiz("DiscountAccount");
                    if (objTemp.ID != 0)
                    {
                        try
                        {
                            _DiscountAccountBiz = new AccountBiz(int.Parse(objTemp.Value));
                        }
                        catch
                        {

                        }
                    }
                }
                return _DiscountAccountBiz;
            }
        }
        public TransactionBiz TransactionBiz
        {
            get
            {
                if (_TransactionBiz == null)
                {
                    _TransactionBiz = new TransactionBiz();
                    _TransactionBiz.CurrencyBiz = CurrencyBiz.CurrencyCol.GetCurrencyByID(1);
                    _TransactionBiz.CurrencyValue = 1;
                    _TransactionBiz.Date = Date;
                    //Returned.Desc = "وحدة : " + InstallmentBiz.Reservation.UnitFullName + " - " + 
                    //    InstallmentBiz.Reservation.CustomerStr + " - قسط رقم " + InstallmentBiz.InstallmentNo.ToString(); 
                    _TransactionBiz.TypeBiz = JournalTypeBiz.JournalTypeCol.GetJournalTypeByID(1);

                    _TransactionBiz.AccountToBiz = DiscountAccountBiz;
                    _TransactionBiz.ReservationID = InstallmentBiz.ReservationID;
                    _TransactionBiz.UnitStr = InstallmentBiz.UnitStr;
                    _TransactionBiz.CustomerStr = InstallmentBiz.CustomerStr;
                    _TransactionBiz.Value = Value;
                }

                return _TransactionBiz;
            }
        }
        #endregion

        #region Private Methods

        #endregion
        #region Public Methods
        public void Add()
        {
            _InstallmentDiscountDb.InstallmentID = _InstallmentBiz.ID;
            _InstallmentDiscountDb.TypeID = _TypeBiz.ID;

            _InstallmentDiscountDb.Add();
            _InstallmentBiz.InstallmentDiscountCol = null;
            if (Value >= _InstallmentBiz.VirtualRemainingValue)
            {
                _InstallmentBiz.EditStatus(InstallmentStatus.Paid,false);
               
            }
        }
        public void Edit()
        {
            _InstallmentBiz.InstallmentDiscountCol = null;
            if (_InstallmentBiz.VirtualRemainingValue <= 0)
            {
                _InstallmentBiz.EditStatus(InstallmentStatus.Paid,false);
            }
            else
            {
                if (_InstallmentBiz.InstallmentStatus == InstallmentStatus.Paid)
                {
                    _InstallmentBiz.EditStatus(InstallmentStatus.Created,false);
                }
            }
            _InstallmentDiscountDb.TypeID = _TypeBiz.ID;

           _InstallmentDiscountDb.Edit();

        }
        
        public void Delete()
        {
            int intIndex = _InstallmentBiz.InstallmentDiscountCol.GetIndex(ID);
            if (intIndex != -1)
                _InstallmentBiz.InstallmentDiscountCol.RemoveAt(intIndex);

            if (_InstallmentBiz.VirtualRemainingValue <= 0)
            {
                _InstallmentBiz.EditStatus(InstallmentStatus.Paid,false);
            }
            else
            {
                if (_InstallmentBiz.InstallmentStatus == InstallmentStatus.Paid)
                {
                    _InstallmentBiz.EditStatus(InstallmentStatus.Created,false);
                }
            }
            _InstallmentDiscountDb.Delete();
        }
        #endregion
    }
}
