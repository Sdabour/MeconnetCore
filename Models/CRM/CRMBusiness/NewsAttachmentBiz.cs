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
    public class NewsAttachmentBiz : AttachmentBiz
    {

        #region Private Data

        NewsBiz _NewsBiz;
        NewsAttachmentTypeBiz _TypeBiz;
        #endregion

        #region Constructors

        public NewsAttachmentBiz()
        {
            _BaseDb = new NewsAttachmentDb();
            _TypeBiz = new NewsAttachmentTypeBiz();
        }

        public NewsAttachmentBiz(int intID)
        {
            _BaseDb = new NewsAttachmentDb(intID);
        }
        public NewsAttachmentBiz(DataRow objDR)
        {
            _BaseDb = new NewsAttachmentDb(objDR);
            _TypeBiz = new NewsAttachmentTypeBiz(objDR);
        }

        #endregion

        #region Public Properties

        public NewsBiz NewsBiz
        {
            set
            {
                _NewsBiz = value;
            }
            get
            {
                return _NewsBiz;
            }
        }


        public NewsAttachmentTypeBiz TypeBiz
        {
            set
            {
                _TypeBiz = value;
            }
            get
            {
                if (_TypeBiz == null)
                    _TypeBiz = new NewsAttachmentTypeBiz();
                return _TypeBiz;
            }
        }
        public override string Name
        {
            get
            {
                
                string Returned = Desc == null || Desc == "" ? TypeBiz.Name : Desc;
                return Returned;
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
            ((NewsAttachmentDb)_BaseDb).AttachmentID = _AttachmentBiz.ID;
            ((NewsAttachmentDb)_BaseDb).AttachmentTypeID = _TypeBiz.ID;
            ((NewsAttachmentDb)_BaseDb).NewsID = _NewsBiz.ID;
            _BaseDb.Add();
        }
        public void Edit()
        {
            if (_AttachmentBiz.Path != Path)
                _AttachmentBiz.Edit();
            ((NewsAttachmentDb)_BaseDb).AttachmentTypeID = _TypeBiz.ID;
            _BaseDb.Edit();
        }

        public static void Add(string strNameA, string strNameE, int intRservationID, int intAttachmentTypeID, int intFamilyID, int intParentID, string strDesc)
        {
            NewsAttachmentDb objNewsAttachmentDb = new NewsAttachmentDb();
            objNewsAttachmentDb.NameA = strNameA;
            objNewsAttachmentDb.NameE = strNameE;
            objNewsAttachmentDb.NewsID = intRservationID;
            objNewsAttachmentDb.AttachmentTypeID = intAttachmentTypeID;
            objNewsAttachmentDb.ParentID = intParentID;
            objNewsAttachmentDb.FamilyID = intFamilyID;
            objNewsAttachmentDb.Desc = strDesc;
            objNewsAttachmentDb.Add();
        }
        public static void Edit(string strNameA, string strNameE, int intRservationID, int intAttachmentTypeID, int intFamilyID, int intParentID, string strDesc)
        {
            NewsAttachmentDb objNewsAttachmentDb = new NewsAttachmentDb();
            objNewsAttachmentDb.NameA = strNameA;
            objNewsAttachmentDb.NameE = strNameE;
            objNewsAttachmentDb.NewsID = intRservationID;
            objNewsAttachmentDb.AttachmentTypeID = intAttachmentTypeID;
            objNewsAttachmentDb.ParentID = intParentID;
            objNewsAttachmentDb.FamilyID = intFamilyID;
            objNewsAttachmentDb.Desc = strDesc;
            objNewsAttachmentDb.Edit();
        }
        public void Delete()
        {
            ((NewsAttachmentDb)_BaseDb).Delete();
        }
        #endregion
        #region Public Methods
        #endregion
    }
}
