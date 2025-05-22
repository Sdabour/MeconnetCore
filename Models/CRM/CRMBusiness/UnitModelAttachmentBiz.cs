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
    public class UnitModelAttachmentBiz : BaseSelfeRelatedBiz
    {

        #region Private Data

        AttachmentFileBiz _AttachmentBiz;
        AttachmentTypeBiz _TypeBiz;
        //UnitModelAttachmentDb _UnitModelAttachmentDb;
        string _Path;
        bool _Modified;
        UnitModelBiz _ModelBiz;
        #endregion

        #region Constructors

        public UnitModelAttachmentBiz()
        {
            _BaseDb = new UnitModelAttachmentDb();
            _TypeBiz = new AttachmentTypeBiz();
        }

        public UnitModelAttachmentBiz(int intID)
        {
            _BaseDb = new UnitModelAttachmentDb(intID);
        }
        public UnitModelAttachmentBiz(DataRow objDR)
        {
            _BaseDb = new UnitModelAttachmentDb(objDR);
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
                if (_Path == null || _Path == "")
                {
                    if (AttachmentBiz != null && AttachmentBiz.ID != 0)
                    {
                        _Path = AttachmentBiz.Path;
                    }
                    else
                        _Path = "";

                }

                return _Path;
            }
        }

        public UnitModelBiz ModelBiz
        {
            set
            {
                _ModelBiz = value;
            }
            get
            {
                return _ModelBiz;
            }
        }
        public AttachmentFileBiz AttachmentBiz
        {
            set
            {
                _AttachmentBiz = value;
            }
            get
            {
                if (_AttachmentBiz == null)
                {

                    if (((UnitModelAttachmentDb)_BaseDb).AttachmentID != 0)
                    {
                        _AttachmentBiz = new AttachmentFileBiz(((UnitModelAttachmentDb)_BaseDb).AttachmentID);
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

        public string Desc
        {
            set
            {
                ((UnitModelAttachmentDb)_BaseDb).Desc = value;
            }
            get
            {
                return ((UnitModelAttachmentDb)_BaseDb).Desc;
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
        public void Add()
        {
            char[] Spliter = @"\".ToCharArray();
            string[] objName = Path.Split(Spliter);
            int Count = objName.Length;

            if (_AttachmentBiz == null)
                _AttachmentBiz = new AttachmentFileBiz();

            _AttachmentBiz.Name = objName.GetValue(Count - 1).ToString();
            _AttachmentBiz.Add();
            ((UnitModelAttachmentDb)_BaseDb).AttachmentID = _AttachmentBiz.ID;
            ((UnitModelAttachmentDb)_BaseDb).UnitModelID = _ModelBiz.ID;

            ((UnitModelAttachmentDb)_BaseDb).AttachmentTypeID = _TypeBiz.ID;

            _BaseDb.Add();
        }
        public void Edit()
        {
            if (_AttachmentBiz.Path != Path)
                _AttachmentBiz.Edit();
            ((UnitModelAttachmentDb)_BaseDb).AttachmentTypeID = _TypeBiz.ID;
            _BaseDb.Edit();
        }

        public static void Add(string strNameA, string strNameE, int intUnitModelID, int intAttachmentTypeID, int intFamilyID, int intParentID, string strDesc)
        {
            UnitModelAttachmentDb objUnitModelAttachmentDb = new UnitModelAttachmentDb();
            objUnitModelAttachmentDb.NameA = strNameA;
            objUnitModelAttachmentDb.NameE = strNameE;
            objUnitModelAttachmentDb.UnitModelID = intUnitModelID;
            objUnitModelAttachmentDb.AttachmentTypeID = intAttachmentTypeID;
            objUnitModelAttachmentDb.ParentID = intParentID;
            objUnitModelAttachmentDb.FamilyID = intFamilyID;
            objUnitModelAttachmentDb.Desc = strDesc;
            objUnitModelAttachmentDb.Add();
        }
        public static void Edit(string strNameA, string strNameE, int intUnitModelID, int intAttachmentTypeID, int intFamilyID, int intParentID, string strDesc)
        {
            UnitModelAttachmentDb objUnitModelAttachmentDb = new UnitModelAttachmentDb();
            objUnitModelAttachmentDb.NameA = strNameA;
            objUnitModelAttachmentDb.NameE = strNameE;
            objUnitModelAttachmentDb.UnitModelID = intUnitModelID;
            objUnitModelAttachmentDb.AttachmentTypeID = intAttachmentTypeID;
            objUnitModelAttachmentDb.ParentID = intParentID;
            objUnitModelAttachmentDb.FamilyID = intFamilyID;
            objUnitModelAttachmentDb.Desc = strDesc;
            objUnitModelAttachmentDb.Edit();
        }
        public void Delete()
        {
            ((UnitModelAttachmentDb)_BaseDb).Delete();

        }
        #endregion
        #region Public Methods
        #endregion
    }
}
