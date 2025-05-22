using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.Base.BaseBusiness;
using SharpVision.COMMON.COMMONDataBase;
namespace SharpVision.COMMON.COMMONBusiness
{
    public abstract class AttachmentBiz :BaseSelfeRelatedBiz
    {
        #region Private Data
        protected AttachmentFileBiz _AttachmentBiz;
        protected AttachmentTypeBiz _TypeBiz;
        protected string _Path;
        #endregion
        #region Constructors
        public AttachmentBiz()
        { 
        }
        public AttachmentBiz(int intID)
        { 
        }
        public AttachmentBiz(DataRow objDR)
        {
            _BaseDb = new AttachmentDb(objDR);
            _TypeBiz = new AttachmentTypeBiz(objDR);
        }
        #endregion
        #region Public Properties
            public string Path
        {
            set 
            {
                _Path = value;
            }
            get
             {
                if(_Path == null || _Path == "")
                {
                    if (AttachmentFileBiz != null && AttachmentFileBiz.ID != 0)
                    {
                        _Path = AttachmentFileBiz.Path;
                    }

                }

                return _Path; 
            }
        }
        public  AttachmentFileBiz AttachmentFileBiz
        {
            set
            {
                _AttachmentBiz = value;
            }
            get
            {
                if (_AttachmentBiz == null)
                {

                    if (((AttachmentDb)_BaseDb).AttachmentID != 0)
                    {
                        _AttachmentBiz = new AttachmentFileBiz(((AttachmentDb)_BaseDb).AttachmentID);
                    }
                    else
                        _AttachmentBiz = new AttachmentFileBiz();
                }
                return _AttachmentBiz;
            }

        }
        public AttachmentTypeBiz TypeBiz
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

        public  string Desc
        {
            set
            {
                ((AttachmentDb)_BaseDb).Desc = value;
            }
            get
            {
                return ((AttachmentDb)_BaseDb).Desc;
            }

        }
        public override string Name
        {
            get
            {
                string Returned = Desc == null || Desc == "" ? _TypeBiz.Name : Desc;
                return Returned;
            }
        }
        #endregion
        #region Private Methods

        #endregion
        #region Public Methods

        #endregion
    }
}
