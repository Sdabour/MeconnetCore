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
    public class CustomerAttachmentBiz :AttachmentBiz
    {

        #region Private Data

     
        CustomerBiz _CustomerBiz;
        #endregion

        #region Constructors

        public CustomerAttachmentBiz()
        {
            _BaseDb = new CustomerAttachmentDb();
            _TypeBiz = new AttachmentTypeBiz();
        }

        public CustomerAttachmentBiz(int intID)
        {
            _BaseDb = new CustomerAttachmentDb(intID);
        }
        public CustomerAttachmentBiz(DataRow objDR)
        {
            _BaseDb = new CustomerAttachmentDb(objDR);
            _TypeBiz = new AttachmentTypeBiz(objDR);
        }

        #endregion

        #region Public Properties
     

        public CustomerBiz CustomerBiz
        {
            set
            {
                _CustomerBiz = value;
            }
            get
            {
                return _CustomerBiz;
            }
        }

        #endregion

        #region Public Method
        public void Add()
        {
            char[] Spliter = @"\".ToCharArray();
            string[] objName = Path.Split(Spliter);
            int Count = objName.Length;
            _AttachmentBiz.Name = objName.GetValue(Count - 1).ToString();
            _AttachmentBiz.Add();
            ((CustomerAttachmentDb)_BaseDb).AttachmentID = _AttachmentBiz.ID;
            ((CustomerAttachmentDb)_BaseDb).CustomerID = _CustomerBiz.ID;
            ((CustomerAttachmentDb)_BaseDb).AttachmentTypeID = _TypeBiz.ID;

            _BaseDb.Add();
        }
        public void Edit()
        {
            if (_AttachmentBiz.Path != Path)
                _AttachmentBiz.Edit();
            ((CustomerAttachmentDb)_BaseDb).AttachmentID = _AttachmentBiz.ID;
            ((CustomerAttachmentDb)_BaseDb).CustomerID = _CustomerBiz.ID;
            ((CustomerAttachmentDb)_BaseDb).AttachmentTypeID = _TypeBiz.ID;
            _BaseDb.Edit();
        }

     
        public void Delete()
        {
            ((CustomerAttachmentDb)_BaseDb).Delete();

        }
        #endregion
        
    }
}
