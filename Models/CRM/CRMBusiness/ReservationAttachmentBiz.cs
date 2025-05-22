using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.Base.BaseDataBase;
using SharpVision.Base.BaseBusiness;
using SharpVision.CRM.CRMDataBase;
using SharpVision.SystemBase;
using SharpVision.COMMON.COMMONBusiness;

namespace SharpVision.CRM.CRMBusiness
{
    public class ReservationAttachmentBiz : AttachmentBiz
    {

        #region Private Data
        
        ReservationBiz _ReservationBiz;
        #endregion

        #region Constructors

        public ReservationAttachmentBiz()
        {
            _BaseDb = new ReservationAttachmentDb();
            _TypeBiz = new AttachmentTypeBiz();
        }

        public ReservationAttachmentBiz(int intID)
        {
            _BaseDb = new ReservationAttachmentDb(intID);
        }
        public ReservationAttachmentBiz(DataRow objDR)
        {
            _BaseDb = new ReservationAttachmentDb(objDR);
            _TypeBiz = new AttachmentTypeBiz(objDR);
        }

        #endregion

        #region Public Properties
    
        public ReservationBiz ReservationBiz
        {
            set
            {
                _ReservationBiz = value;
            }
            get
            {
                return _ReservationBiz;
            }
        }

     
        
        #endregion

        #region Private Methods
        public void Add()
        {
            char[] Spliter = @"\".ToCharArray();
            string[] objName = Path.Split(Spliter);
            int Count = objName.Length ;
            _AttachmentBiz.Name = objName.GetValue(Count - 1).ToString();
            _AttachmentBiz.Add();
            ((ReservationAttachmentDb)_BaseDb).AttachmentID = _AttachmentBiz.ID;
            ((ReservationAttachmentDb)_BaseDb).AttachmentTypeID = _TypeBiz.ID;
            ((ReservationAttachmentDb)_BaseDb).ReservationID = _ReservationBiz.ID;
            _BaseDb.Add();
        }
        public void Edit()
        {
            if(_AttachmentBiz.Path != Path)
             _AttachmentBiz.Edit();
            ((ReservationAttachmentDb)_BaseDb).AttachmentTypeID = _TypeBiz.ID;
           _BaseDb.Edit();
        }

        public static void Add(string strNameA, string strNameE, int intRservationID, int intAttachmentTypeID, int intFamilyID, int intParentID, string strDesc)
        {
            ReservationAttachmentDb objReservationAttachmentDb = new ReservationAttachmentDb();
            objReservationAttachmentDb.NameA = strNameA;
            objReservationAttachmentDb.NameE = strNameE;
            objReservationAttachmentDb.ReservationID = intRservationID;
            objReservationAttachmentDb.AttachmentTypeID = intAttachmentTypeID;
            objReservationAttachmentDb.ParentID = intParentID;
            objReservationAttachmentDb.FamilyID = intFamilyID;
            objReservationAttachmentDb.Desc = strDesc;
            objReservationAttachmentDb.Add();
        }
        public static void Edit(string strNameA, string strNameE, int intRservationID, int intAttachmentTypeID, int intFamilyID, int intParentID, string strDesc)
        {
            ReservationAttachmentDb objReservationAttachmentDb = new ReservationAttachmentDb();
            objReservationAttachmentDb.NameA = strNameA;
            objReservationAttachmentDb.NameE = strNameE;
            objReservationAttachmentDb.ReservationID = intRservationID;
            objReservationAttachmentDb.AttachmentTypeID = intAttachmentTypeID;
            objReservationAttachmentDb.ParentID = intParentID;
            objReservationAttachmentDb.FamilyID = intFamilyID;
            objReservationAttachmentDb.Desc = strDesc;
            objReservationAttachmentDb.Edit();
        }
        public  void Delete()
        {
            ((ReservationAttachmentDb)_BaseDb).Delete();
        }
        #endregion
        #region Public Methods
        #endregion
    }
}
