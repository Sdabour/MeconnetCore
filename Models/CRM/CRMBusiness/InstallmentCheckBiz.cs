using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.Base.BaseDataBase;
using SharpVision.Base.BaseBusiness;
using SharpVision.CRM.CRMDataBase;
using SharpVision.GL.GLBusiness;
using SharpVision.GL.GLDataBase;
using SharpVision.SystemBase;

namespace SharpVision.CRM.CRMBusiness
{
    public class InstallmentCheckBiz 
    {
        #region Private Data
        InstallmentCheckDb _CheckDb;
        ReservationInstallmentBiz _InstallmentBiz;
        CheckBiz _CheckBiz;
        #endregion

        #region Constractors
        public InstallmentCheckBiz()
        {
            _CheckDb = new InstallmentCheckDb();
        }
      
        public InstallmentCheckBiz(DataRow objDR)
        {
            _CheckDb = new InstallmentCheckDb(objDR);
            //_InstallmentBiz  = new ReservationInstallmentBiz(objDR);
            _CheckBiz = new CheckBiz(objDR);
        }
        #endregion

        #region Public Accessorice
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
        public CheckBiz CheckBiz
        {
            set
            {
                _CheckBiz = value;
            }
            get
            {
                return _CheckBiz;
            }
        }
        public int Status
        {
            set
            {
               _CheckDb.Status = value;
            }
            get
            {
                return _CheckDb.Status;
            }
        }
        #endregion

        #region Private Methods
        #endregion

        #region Public Methods
        public void Add()
        {
            _CheckDb.InstallmentID = _InstallmentBiz.ID;
            if (_CheckBiz.ID == 0)
                _CheckBiz.Add();
            _CheckDb.CheckID = _CheckBiz.ID;
            _CheckDb.Add();
        }
        public void Edit()
        {
            _CheckDb.InstallmentID = _InstallmentBiz.ID;
            if (_CheckBiz.ID == 0)
                _CheckBiz.Add();
            else
                _CheckBiz.Edit();
            _CheckDb.CheckID = _CheckBiz.ID;
            _CheckDb.Edit();
        }
        #endregion
    }
}
