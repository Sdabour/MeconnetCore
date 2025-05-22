using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.Base.BaseDataBase;
namespace SharpVision.COMMON.COMMONDataBase
{
    public class AttachmentDb : BaseSelfRelatedDb
    {
        #region Private Data
        protected int _AttachmentID;
        protected string _Desc;
        protected int _AttachmentTypeID;
        protected AttachmentTypeDb _AttachmentTypeDb;
        #endregion
        #region Constructors
        public AttachmentDb()
        { 
        }
        public AttachmentDb(int intID)
        { 
        }
        public AttachmentDb(DataRow objDR)
        {
            if(objDR.Table.Columns["ReservationAttachmentID"] != null)
             _ID = int.Parse(objDR["ReservationAttachmentID"].ToString());
            _AttachmentID = int.Parse(objDR["AttachmentID"].ToString());
            _ParentID = int.Parse(objDR["AttachmentParentID"].ToString());
            _FamilyID = int.Parse(objDR["AttachmentFamilyID"].ToString());
            _AttachmentTypeID = int.Parse(objDR["AttachmentTypeID"].ToString());
            _Desc = objDR["AttachmentDesc"].ToString();

        }
        #endregion
        #region Public Properties
        public int AttachmentTypeID
        {
            set
            {
                _AttachmentTypeID = value;
            }
            get
            {
                return _AttachmentTypeID;
            }

        }
        public AttachmentTypeDb AttachmentTypeDb
        {
            set
            {
                _AttachmentTypeDb = value;
            }
            get
            {
                return _AttachmentTypeDb;
            }
        }
        public int AttachmentID
        {
            set
            {
                _AttachmentID = value;
            }
            get
            {
                return _AttachmentID;
            }

        }

        public string Desc
        {
            set
            {
                _Desc = value;
            }
            get
            {
                return _Desc;
            }

        }
        #endregion
        #region Private Methods

        #endregion
        #region Public Methods
        public override void Add()
        {
            
        }
        public override void Edit()
        {
        }
        public override void Delete()
        {
            
        }
        public override DataTable Search()
        {
            return new DataTable();
        }
        #endregion
    }
}
