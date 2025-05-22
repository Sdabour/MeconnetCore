using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.Base.BaseDataBase;
using SharpVision.Base.BaseBusiness;
using SharpVision.CRM.CRMDataBase;
using SharpVision.SystemBase;

namespace SharpVision.CRM.CRMBusiness
{
    public class InstallmentMulctBiz : BaseSingleBiz
    {
        #region Private Data
        ReservationInstallmentBiz _InstallmentBiz;
        ReservationBiz _ReservationBiz;
        MulctReasonBiz _ReasonBiz;
        #endregion
        #region Constructors
        public InstallmentMulctBiz()
        {
            _BaseDb = new InstallmentMulctDb();
        }
       
        public InstallmentMulctBiz(DataRow objDR)
        {
            _BaseDb = new InstallmentMulctDb(objDR);
            _ReasonBiz = new MulctReasonBiz(objDR);
        }
        #endregion
        #region Public Properties
        public string StatusText
        {
            set
            {
                ((InstallmentMulctDb)_BaseDb).StatusText = value;
            }
            get
            {
                return ((InstallmentMulctDb)_BaseDb).StatusText;
            }

        }
        public int Status
        {
            set
            {
                ((InstallmentMulctDb)_BaseDb).Status = value;
            }
            get
            {
                return ((InstallmentMulctDb)_BaseDb).Status;
            }

        }
        public int InstallmentID
        {
            set
            {
                ((InstallmentMulctDb)_BaseDb).InstallmentID = value;
            }
            get
            {
                return ((InstallmentMulctDb)_BaseDb).InstallmentID;
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
                if (_InstallmentBiz == null)
                    _InstallmentBiz = new ReservationInstallmentBiz();
                return _InstallmentBiz;
            }
        }

        public ReservationBiz ReservationBiz
        {
            set
            {
                _ReservationBiz = value;    
            }
            get
            {
                if (_ReservationBiz == null)
                    _ReservationBiz = new ReservationBiz();
                return _ReservationBiz;
            }
        }
        public double MulctValue
        {
            set
            {
                ((InstallmentMulctDb)_BaseDb).MulctValue = value;
            }
            get
            {
                return ((InstallmentMulctDb)_BaseDb).MulctValue;
            }

        }
        public MulctReasonBiz ReasonBiz
        {
            set
            {
               _ReasonBiz= value;
            }
            get
            {
                if (_ReservationBiz == null)
                    _ReasonBiz = new MulctReasonBiz();
                return _ReasonBiz;
            }

        }
        public DateTime MulctDate
        {
            set
            {
                ((InstallmentMulctDb)_BaseDb).MulctDate = value;
            }
            get
            {
                return ((InstallmentMulctDb)_BaseDb).MulctDate;
            }

        }
        #endregion
        #region Private Methods

        #endregion
        #region Public Methods

        public void Add()
        {
            ((InstallmentMulctDb)_BaseDb).InstallmentID = InstallmentBiz.ID;
            ((InstallmentMulctDb)_BaseDb).MulctReason = ReasonBiz.ID;
            ((InstallmentMulctDb)_BaseDb).ReservationID = ReservationBiz.ID;
            _BaseDb.Add();
        }

        public void Edit()
        {
            ((InstallmentMulctDb)_BaseDb).InstallmentID = InstallmentBiz.ID;
            ((InstallmentMulctDb)_BaseDb).MulctReason = ReasonBiz.ID;
            ((InstallmentMulctDb)_BaseDb).ReservationID = ReservationBiz.ID;
            _BaseDb.Edit();
        }
    
        public static void EditStatus(int intID, int intStatus, int intInstallmentID, string strStatusText)
        {
            InstallmentMulctDb objInstallmentMulctDb = new InstallmentMulctDb();
            objInstallmentMulctDb.ID = intID;
            objInstallmentMulctDb.InstallmentID = intInstallmentID;
            objInstallmentMulctDb.Status = intStatus;
            objInstallmentMulctDb.StatusText = strStatusText;
            objInstallmentMulctDb.EditStatus();

        }
        public  void Delete()
        {
            
            _BaseDb.Delete();
            
        }

        #endregion
    }
}
