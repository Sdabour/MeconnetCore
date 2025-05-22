using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using SharpVision.Base.BaseDataBase;

namespace SharpVision.UMS.UMSDataBase
{
    public class DepartmentDb :BaseSelfRelatedDb
    {
        #region Private Data

        protected string _TypeName;
        static DataTable _CacheDepartmentTable;

        #endregion
        #region Constructors
        public DepartmentDb(DataRow objDr)
        {
            SetData(objDr);

        }
        public DepartmentDb()
        { }
        #endregion
        #region Public Properties
        public static DataTable CacheDepartmentTable
        {
            set
            {
                _CacheDepartmentTable = value;
            }
            get
            {
                if (_CacheDepartmentTable == null)
                {

                    _CacheDepartmentTable =
                        BaseDb.UMSBaseDb.ReturnDatatable(SearchStr);
                }
                return _CacheDepartmentTable;
            }
        }
        public string TypeName
        {
            get
            {
                return _TypeName;
            }
        }
        public static string SearchStr
        {
            get
            {
                string Returned = "SELECT   dbo.HRSector.SectorID, dbo.HRSector.SectorType, dbo.HRSector.SectorNameA, dbo.HRSector.SectorNameE, dbo.HRSector.SectorParentID, "+
                      " dbo.HRSector.SectorFamilyID, dbo.HRSector.Dis, dbo.HRSectorType.TypeNameA "+
                      " FROM  dbo.HRSector INNER JOIN "+
                      " dbo.HRSectorType ON dbo.HRSector.SectorType = dbo.HRSectorType.SectorTypeID "+
                      " ";
                return Returned;

            }
        }
        #endregion
        #region Private Methods
        void SetData(DataRow objDr)
        {
            _ID = int.Parse(objDr["SectorID"].ToString());
            _NameA = objDr["SectorNameA"].ToString();
            _ParentID = int.Parse(objDr["SectorParentID"].ToString());
            _FamilyID = int.Parse(objDr["SectorFamilyID"].ToString());
            _TypeName = objDr["TypeNameA"].ToString();



 
        }
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
            string strSql = SearchStr + " WHERE  (dbo.HRSector.Dis IS NULL) ";
            return BaseDb.UMSBaseDb.ReturnDatatable(strSql);
        }
        #endregion
    }
}
