using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.CRM.CRMDataBase;
using System.Data;
namespace   SharpVision.CRM.CRMBusiness
{
    public class ReservationCancelationBiz
    {
        #region Private Data
        ReservationCancelationDb _CancelationDb;
        ReservationBiz _ReservationBiz;
        CancelationTypeBiz _TypeBiz;

        public CancelationTypeBiz TypeBiz
        {
            get {
                if (_TypeBiz == null)
                    _TypeBiz = new CancelationTypeBiz();
                return _TypeBiz; }
            set { _TypeBiz = value; }
        }
        #endregion
        #region Constructors
        public ReservationCancelationBiz()
        {
            _CancelationDb = new ReservationCancelationDb();
        }
        public ReservationCancelationBiz(DataRow objDr)
        {
            _CancelationDb = new ReservationCancelationDb(objDr);
            if (_CancelationDb.Type != 0)
                _TypeBiz = new CancelationTypeBiz(objDr);
        }
        #endregion
        #region Public Properties
        public ReservationBiz ReservationBiz
        {
            set
            {
                _ReservationBiz = value;
            }
        }
        public int ReservationID
        {
            set
            {
                _CancelationDb.ReservationID = value;
            }
            get
            {
                return _CancelationDb.ReservationID;
            }
        }
        public DateTime Date
        {
            set
            {
                _CancelationDb.Date = value;
            }
            get
            {
                return _CancelationDb.Date;
            }
        }
        public string Note
        {
            set
            {
                _CancelationDb.Note = value;
            }
            get
            {
                if (_CancelationDb.Note == null)
                    _CancelationDb.Note = "";
                return _CancelationDb.Note;
            }
        }
        public double Cost
        {
            set
            {
                _CancelationDb.Cost = value;
            }
            get
            {
                return _CancelationDb.Cost;
            }
        }
        public bool PayBackComplete
        {
            set
            {
                _CancelationDb.PayBackComplete = value;
            }
            get
            {
                return _CancelationDb.PayBackComplete;
            }
        }
        public bool IsDelegated
        {
            set
            {
                _CancelationDb.IsDelegated = value;
            }
            get
            {
                return _CancelationDb.IsDelegated;
            }
        }
        public bool Canceled
        {
            set
            {
                _CancelationDb.Canceled = value;
            }
            get
            {
                return _CancelationDb.Canceled;
            }
        }
        public DateTime DelegationDate
        {
            set
            {
                _CancelationDb.DelegationDate = value;
            }
            get
            {
                return _CancelationDb.DelegationDate;
            }
        }
        public DateTime PayBackCompleteDate
        {
            get { return _CancelationDb.PayBackCompleteDate; }
            set { _CancelationDb.PayBackCompleteDate = value; }
        }
      

        public int PayBackCompleteUsr
        {
            get { return _CancelationDb.PayBackCompleteUsr; }
            set { _CancelationDb.PayBackCompleteUsr = value; }
        }
        #endregion
        #region Private Methods

        #endregion
        #region Public Methods
        public void Add()
        {
            _CancelationDb.ReservationID = _ReservationBiz.ID;
            _CancelationDb.Type = TypeBiz.ID;
           //_ReservationBiz.EditStatus(ReservationStatus.Cancellation);

            //if (_CancelationDb.Cost == 0)
            //    _CancelationDb.PayBackComplete = true;

            _CancelationDb.Add();
        }
        public void Edit()
        {
            _CancelationDb.Type = TypeBiz.ID;
            _CancelationDb.ReservationID = _ReservationBiz.ID;

           // _ReservationBiz.EditStatus(ReservationStatus.Cancellation,false);

            //if (_CancelationDb.Cost == 0)
            //    _CancelationDb.PayBackComplete = true;

            _CancelationDb.Edit() ;
            
        }
        public bool Delete()
        {
          
                _CancelationDb.Delete();
              
            return _CancelationDb.ReasignedSucceded;


        }
        public static void DeleteNonCollectedCheckPayment(int intReservationID)
        {
            if (intReservationID == 0)
                return;
            ReservationCancelationDb objDb = new ReservationCancelationDb();
            objDb.ReservationID = intReservationID;
            objDb.DeleteNonCollectedCheckPayment();
 
        }
        #endregion
    }
}
