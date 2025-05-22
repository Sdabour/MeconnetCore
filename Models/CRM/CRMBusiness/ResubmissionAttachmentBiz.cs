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
    public class ResubmissionAttachmentBiz : AttachmentBiz
    {

        #region Private Data

        ReservationResubmissionBiz _ResubmissionBiz;
        #endregion

        #region Constructors

        public ResubmissionAttachmentBiz()
        {
            _BaseDb = new ResubmissionAttachmentDb();
            _TypeBiz = new AttachmentTypeBiz();
        }

        public ResubmissionAttachmentBiz(int intID)
        {
            _BaseDb = new ResubmissionAttachmentDb(intID);
        }
        public ResubmissionAttachmentBiz(DataRow objDR)
        {
            _BaseDb = new ResubmissionAttachmentDb(objDR);
            _TypeBiz = new AttachmentTypeBiz(objDR);
        }

        #endregion

        #region Public Properties

        public ReservationResubmissionBiz ResubmissionBiz
        {
            set
            {
                _ResubmissionBiz = value;
            }
            get
            {
                return _ResubmissionBiz;
            }
        }



        #endregion

        #region Private Methods
        public void Add()
        {
            char[] Spliter = @"\".ToCharArray();
            string[] objName = Path.Split(Spliter);
            int Count = objName.Length;
            _AttachmentBiz.Name = objName.GetValue(Count - 1).ToString();
            _AttachmentBiz.Add();
            ((ResubmissionAttachmentDb)_BaseDb).AttachmentID = _AttachmentBiz.ID;
            ((ResubmissionAttachmentDb)_BaseDb).AttachmentTypeID = _TypeBiz.ID;
            ((ResubmissionAttachmentDb)_BaseDb).ResubmissionID = _ResubmissionBiz.ID;
            _BaseDb.Add();
        }
        public void Edit()
        {
            if (_AttachmentBiz.Path != Path)
                _AttachmentBiz.Edit();
            ((ResubmissionAttachmentDb)_BaseDb).AttachmentTypeID = _TypeBiz.ID;
            _BaseDb.Edit();
        }

        public static void Add(string strNameA, string strNameE, int intRservationID, int intAttachmentTypeID, int intFamilyID, int intParentID, string strDesc)
        {
            ResubmissionAttachmentDb objResubmissionAttachmentDb = new ResubmissionAttachmentDb();
            objResubmissionAttachmentDb.NameA = strNameA;
            objResubmissionAttachmentDb.NameE = strNameE;
            objResubmissionAttachmentDb.ResubmissionID = intRservationID;
            objResubmissionAttachmentDb.AttachmentTypeID = intAttachmentTypeID;
            objResubmissionAttachmentDb.ParentID = intParentID;
            objResubmissionAttachmentDb.FamilyID = intFamilyID;
            objResubmissionAttachmentDb.Desc = strDesc;
            objResubmissionAttachmentDb.Add();
        }
        public static void Edit(string strNameA, string strNameE, int intRservationID, int intAttachmentTypeID, int intFamilyID, int intParentID, string strDesc)
        {
            ResubmissionAttachmentDb objResubmissionAttachmentDb = new ResubmissionAttachmentDb();
            objResubmissionAttachmentDb.NameA = strNameA;
            objResubmissionAttachmentDb.NameE = strNameE;
            objResubmissionAttachmentDb.ResubmissionID = intRservationID;
            objResubmissionAttachmentDb.AttachmentTypeID = intAttachmentTypeID;
            objResubmissionAttachmentDb.ParentID = intParentID;
            objResubmissionAttachmentDb.FamilyID = intFamilyID;
            objResubmissionAttachmentDb.Desc = strDesc;
            objResubmissionAttachmentDb.Edit();
        }
        public void Delete()
        {
            ((ResubmissionAttachmentDb)_BaseDb).Delete();
        }
        #endregion
        #region Public Methods
        #endregion
    }
}
