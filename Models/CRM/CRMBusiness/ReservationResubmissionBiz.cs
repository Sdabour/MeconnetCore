using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.Base.BaseDataBase;
using SharpVision.Base.BaseBusiness;
using SharpVision.CRM.CRMDataBase;
using SharpVision.SystemBase;
using SharpVision.COMMON.COMMONBusiness;

using SharpVision.HR.HRBusiness;
using SharpVision.GL.GLBusiness;
using System.Collections;
using SharpVision.UMS.UMSBusiness;
using SharpVision.RP.RPBusiness;
namespace SharpVision.CRM.CRMBusiness
{
    public class ReservationResubmissionBiz
    {
        #region Private Data
        ReservationResubmissionDb _ResubmissionDb;
        ReservationBiz _ReservationBiz;

        public ReservationBiz ReservationBiz
        {
            get 
            { 
                if (_ReservationBiz == null)
                    _ReservationBiz = new ReservationBiz();
                return _ReservationBiz; 
            }
            set { _ReservationBiz = value; }
        }
        ResubmissionTypeBiz _TypeBiz;

        public ResubmissionTypeBiz TypeBiz
        {
            get {
                if (_TypeBiz == null)
                    _TypeBiz = new ResubmissionTypeBiz();
                return _TypeBiz; }
            set { _TypeBiz = value; }
        }
        ReservationCol _ReservationCol;

        public ReservationCol ReservationCol
        {
            get {
                if (_ReservationCol == null)
                {
                    _ReservationCol = new ReservationCol(true);
                }
                return _ReservationCol; }
            set { _ReservationCol = value; }
        }
        CheckCol _CheckCol;

        public CheckCol CheckCol
        {
            get {
                if (_CheckCol == null)
                    _CheckCol = new CheckCol(true);
                return _CheckCol; }
            set { _CheckCol = value; }
        }
        #endregion
        #region Constructors
        public ReservationResubmissionBiz()
        {
            _ResubmissionDb = new ReservationResubmissionDb();
        }
        public ReservationResubmissionBiz(DataRow objDr)
        {
            _ResubmissionDb = new ReservationResubmissionDb(objDr);
            _TypeBiz = new ResubmissionTypeBiz(objDr);
            _UserBiz = new UserBiz();
            if (_ResubmissionDb.UsrIns != 0)
                _UserBiz.ID = _ResubmissionDb.UsrIns;
            _UserBiz.Name = _ResubmissionDb.UserName;
            if (_ResubmissionDb.EmployeeID != 0)
            {
                _UserBiz.EmployeeBiz = new EmployeeBiz();
                _UserBiz.EmployeeBiz.ID = _ResubmissionDb.EmployeeID;
                _UserBiz.EmployeeBiz.Name = _ResubmissionDb.EmployeeName;
            }


        }
        #endregion
        #region Public Properties
        public int ID
        {
            set
            {
                _ResubmissionDb.ID = value;
            }
            get
            {
                return _ResubmissionDb.ID;
            }
        }

        

        public int ResubmissionType
        {
            get { return _ResubmissionDb.ResubmissionType; }
            set { _ResubmissionDb.ResubmissionType = value; }
        }
        

        public string Desc
        {
            get { return _ResubmissionDb.Desc; }
            set { _ResubmissionDb.Desc = value; }
        }
        

        public DateTime Date
        {
            get { return _ResubmissionDb.Date; }
            set { _ResubmissionDb.Date = value; }
        }
       

        public bool HasEndDate
        {
            get { return _ResubmissionDb.HasEndDate; }
            set { _ResubmissionDb.HasEndDate = value; }
        }
        

        public DateTime EndDate
        {
            get { return _ResubmissionDb.EndDate; }
            set { _ResubmissionDb.EndDate = value; }
        }
     

        public int ResubmissionStatus
        {
            get { return _ResubmissionDb.ResubmissionStatus; }
            set { _ResubmissionDb.ResubmissionStatus = value; }
        }
       

        public int UsrIns
        {
            get { return _ResubmissionDb.UsrIns; }
            set { _ResubmissionDb.UsrIns = value; }
        }

        UserBiz _UserBiz;

        public UserBiz UserBiz
        {
            get {
                if (_UserBiz == null)
                    _UserBiz = new UserBiz();
                return _UserBiz; }
            set { _UserBiz = value; }
        }
       
        public DateTime TimIns
        {
            get { return _ResubmissionDb.TimIns; }
            set { _ResubmissionDb.TimIns = value; }
        }
        public int ReservationID
        {
            get { return _ResubmissionDb.ReservationID; }
            set { _ResubmissionDb.ReservationID = value; }
        }
        public bool IsLegal
        {
            get { return _ResubmissionDb.IsLegal; }
            set { _ResubmissionDb.IsLegal = value; }
        }
      

        public string Serial
        {
            get { return _ResubmissionDb.Serial; }
            set { _ResubmissionDb.Serial = value; }
        }
     

        public bool HasAlarm
        {
            get { return _ResubmissionDb.HasAlarm; }
            set { _ResubmissionDb.HasAlarm = value; }
        }
        

        public DateTime AlarmDate
        {
            get { return _ResubmissionDb.AlarmDate; }
            set { _ResubmissionDb.AlarmDate = value; }
        }
   
        public bool HasConfirmation
        {
            get { return _ResubmissionDb.HasConfirmation; }
            set { _ResubmissionDb.HasConfirmation = value; }
        }
 

        public DateTime ConfirmationDate
        {
            get { return _ResubmissionDb.ConfirmationDate; }
            set { _ResubmissionDb.ConfirmationDate = value; }
        }
  
        public string Lawyer
        {
            get { return _ResubmissionDb.Lawyer; }
            set { _ResubmissionDb.Lawyer = value; }
        }
      

        public string LegalSerial
        {
            get { return _ResubmissionDb.LegalSerial; }
            set { _ResubmissionDb.LegalSerial = value; }
        }
   

        public string Action
        {
            get { return _ResubmissionDb.Action; }
            set { _ResubmissionDb.Action = value; }
        }
        

        public string Note
        {
            get { return _ResubmissionDb.Note; }
            set { _ResubmissionDb.Note = value; }
        }
        ResubmissionAttachmentCol _ResubmissionAttachmentCol;
        public ResubmissionAttachmentCol ResubmissionAttachmentCol
        {
            set
            {
                _ResubmissionAttachmentCol = value;
            }
            get
            {
                if (_ResubmissionAttachmentCol == null)
                {
                    _ResubmissionAttachmentCol = new ResubmissionAttachmentCol(true);
                    if (ID != 0)
                    {
                        ResubmissionAttachmentDb objDb = new ResubmissionAttachmentDb();
                        objDb.ResubmissionID = ID;
                        DataTable dtTemp = objDb.Search();
                        try
                        {
                            DataRow[] arrDr = dtTemp.Select();//ResubmissionDb.CachAttachmentTable.Select("ResubmissionID=" + ID);

                            ResubmissionAttachmentBiz objTempBiz;
                            foreach (DataRow objDr in arrDr)
                            {
                                objTempBiz = new ResubmissionAttachmentBiz(objDr);
                                objTempBiz.ResubmissionBiz = this;
                                _ResubmissionAttachmentCol.Add(objTempBiz);
                            }
                        }
                        catch
                        { }
                    }
                }
                return _ResubmissionAttachmentCol;
            }

        }
        public bool IsChanged
        {
            get
            {
                return _ResubmissionDb.IsChanged;
            }
        }
        #endregion
        #region Private Methods

        #endregion
        #region Public Methods
        public void Add()
        {
            _ResubmissionDb.ResubmissionType = TypeBiz.ID;
            _ResubmissionDb.ReservationID = ReservationBiz.ID;
            _ResubmissionDb.ReservationIDs = ReservationCol.IDsStr;
            _ResubmissionDb.CheckIDs = CheckCol.IDsStr;
            if (_ReservationBiz.ID > 0)
                _ResubmissionDb.Add();
            else if (ReservationCol.Count > 0)
                _ResubmissionDb.AddManyReservationResubmission();
            else if (CheckCol.Count > 0)
                _ResubmissionDb.AddManyCheckResubmission();
        }
        public void Edit()
        {
            _ResubmissionDb.ResubmissionType = TypeBiz.ID;
            _ResubmissionDb.ReservationID = ReservationBiz.ID;
            _ResubmissionDb.ReservationIDs = ReservationCol.IDsStr;

            _ResubmissionDb.Edit();
        }
        public void Delete()
        {

            _ResubmissionDb.ReservationID = ReservationBiz.ID;
            _ResubmissionDb.Delete();
        }
        #endregion
    }
}
