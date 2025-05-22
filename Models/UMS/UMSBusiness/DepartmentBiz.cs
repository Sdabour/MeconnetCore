using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.UMS.UMSDataBase;
using SharpVision.Base.BaseBusiness;

using System.Data;

namespace SharpVision.UMS.UMSBusiness
{
    public class DepartmentBiz:BaseSelfeRelatedBiz
    {

        #region Private Data

        #endregion
        #region Constructors
        public DepartmentBiz()
        {
            _BaseDb = new DepartmentDb();
        }
        public DepartmentBiz(DataRow objDr)
        {
            _BaseDb = new DepartmentDb(objDr);
 
        }
        public DepartmentBiz(int intID)
        {
            if (intID != 0)
            {
                DataRow[] arrDr = DepartmentDb.CacheDepartmentTable.Select("SectorID="+ intID);
                if (arrDr.Length > 0)
                {
                    _BaseDb = new DepartmentDb(arrDr[0]);
                }
                else
                    _BaseDb = new DepartmentDb();
            }
            else
                _BaseDb = new DepartmentDb();
        }
        #endregion
        #region Public Properties
        public string TypeNameA
        {
            get
            {
                return ((DepartmentDb)_BaseDb).TypeName;
            }

        }
        public DepartmentCol Children
        {
            set
            {
                _Children = value;
            }
            get
            {
                return (DepartmentCol)_Children;
            }
        }
        public DepartmentBiz ParentBiz
        {
            set
            {
                _ParentBiz = value;
            }
            get
            {
                if (_ParentBiz == null)
                    _ParentBiz = DepartmentCol.CurrentDepartmentCol[((DepartmentDb)_BaseDb).ParentID.ToString()];
                return (DepartmentBiz)_ParentBiz;
            }
        }
        #endregion
        #region Private Methods

        #endregion
        #region Public Methods

        #endregion
    }
}
