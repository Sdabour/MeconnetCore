using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.SystemBase;
namespace SharpVision.RP.RPDataBase
{
    public class ContractElementCategoryDb : ContractElementDb
    {
        #region Private Data
        int _CategoryID;
        double _EstimatedValue;
        #endregion
        #region Constructors
        public ContractElementCategoryDb(DataRow objDr)
            : base(objDr)
        {

            _EstimatedValue = double.Parse(objDr["EstimatedValue"].ToString());

        }
        public ContractElementCategoryDb()
        {


        }
        #endregion
        #region Public Properties
        public int CategoryID
        {
            set
            {
                _CategoryID = value;
            }
            get
            {
                return _CategoryID;
            }
        }
        public double EstimatedValue
        {
            set
            {
                _EstimatedValue = value;
            }
            get
            {
                return _EstimatedValue;
            }
        }
        public static string SearchStr
        {
            get
            {
                string Returned = "SELECT   ContractElementID as ContractElementCategoryID,EstimatedValue,CategoryTable.* " +
                          " FROM  dbo.RPContractElementCategory inner join (" + //CategoryDb.SearchStr +
                          ") as CategoryTable " +
                          " on  CategoryTable.CategoryID = RPContractElementCategory.CategoryID ";
                return Returned;
            }
        }
        #endregion
        #region Private Methods

        #endregion
        #region Public Methods
        public override void Add()
        {
            base.Add();
            string strSql = "insert into RPContractElementCategory  (ContractElementID, CategoryID,EstimatedValue) " +
                " values (" + _ID + "," + _CategoryID + "," + _EstimatedValue + ")";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);

        }
        public override DataTable Search()
        {
            ContractElementDb objContractElementDb = new ContractElementDb();
            string strSql = objContractElementDb.SearchStr + " where CategoryTable.CategoryID is not null " +
                      " and CategoryTable.CategoryID != 0 ";
            if (_ContractID != 0)
                strSql = strSql + " and RPContractElement.ContractID = " + _ContractID;
            if (_CategoryType != 0)
                strSql = strSql + " and CategoryTable.CategoryTypeID= " + _CategoryType;
            if (_ContractElementDesc != null && _ContractElementDesc != "")
                strSql = strSql + " and ContractElementDesc like '%" + _ContractElementDesc + "%'";

            strSql = "select top 100 from (" + strSql + ") as NativeTable ";
            DataTable Returned = SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
            return Returned;
        }

        #endregion
    }
}
