using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using SharpVision.SystemBase;
//using SharpVision.Base.BaseDataBase;

using SharpVision.Base.BaseBusiness;

namespace SharpVision.RP.RPDataBase
{
    public class ProcessTypeCategoryDb
    {


        #region Private Data
        protected int _ProcessTypeID;
        protected int _CategoryID;
        protected double _Amount;
        protected int _UnitID;
        string _ProcessTypeIDs;
       
        #region Private data For search
        string _CategoryCode;
        string _CategoryName;
        int _CategoryTypeID;
        #endregion
        #endregion

        #region Constructors
        public ProcessTypeCategoryDb()
        {

        }
        public ProcessTypeCategoryDb(DataRow objDr)
        {
            _ProcessTypeID = int.Parse(objDr["ProcessTypeID"].ToString());
            _CategoryID = int.Parse(objDr["CategoryID"].ToString());
            _Amount = double.Parse(objDr["Amount"].ToString());
            
            _UnitID = int.Parse(objDr["Unit"].ToString());
        }
        #endregion
        #region Public Proberties
        public int ProcessTypeID
        {
            set { _ProcessTypeID = value; }
            get { return _ProcessTypeID; }
        }
        public double Amount
        {
            set { _Amount = value; }
            get { return _Amount; }

        }
        public int CategoryID
        {
            set { _CategoryID = value; }
            get { return _CategoryID; }
        }
        public int UnitID
        {
            set { _UnitID = value; }
            get { return _UnitID; }

        }
     
        public string CategoryCode
        {
            set
            {
                _CategoryCode = value;
            }
        }
        public string CategoryName
        {
            set
            {
                _CategoryName = value;
            }
        }
        public int CategoryTypeID
        {
            set
            {
                _CategoryTypeID = value;
            }
        }
        public string ProcessTypeIDs
        {
            set
            {
                _ProcessTypeIDs = value;
            }
        }
        #endregion
        #region Private Methods
        #endregion
        #region Public Methods
        public void Add()
        {
            string strSql = " INSERT INTO RPProcessTypeCategory (ProcessTypeID, CategoryID, Amount, Unit)" +
                            " VALUES     (" + _ProcessTypeID + "," + _CategoryID + "," + _Amount + "," + _UnitID + ") ";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public void Edit()
        {
            string strSql = "update  RPProcessTypeCategory ";
            strSql = strSql + " set CategoryID =" + _CategoryID;
            strSql = strSql + ",Amount =" + _Amount;
            strSql = strSql + ",ProcessTypeID =" + _ProcessTypeID;
            strSql = strSql + ",UnitID =" + _UnitID;
           
            strSql = strSql + " where  CategoryID = " + _CategoryID + " and ProcessTypeID = " + _ProcessTypeID;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public void Delete()
        {
            string strSql = "DELETE FROM RPProcessTypeCategory ";
            strSql = strSql + " where  CategoryID = " + _CategoryID + " and ProcessTypeID = " + _ProcessTypeID;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public DataTable Search()
        {
            string strSql = "SELECT dbo.RPProcessTypeCategory.ProcessTypeID, dbo.RPProcessTypeCategory.CategoryID, dbo.RPProcessTypeCategory.Amount, dbo.RPProcessTypeCategory.Unit, " +
                            " dbo.RPCategory.CategoryID,dbo.RPCategory.CategoryCode, dbo.RPCategory.CategoryNameA, dbo.RPCategory.CategoryNameE, dbo.RPCategory.MeasureStanderdUnit, " +
                            " dbo.RPCategory.IsRaw, dbo.RPCategory.CategoryType, dbo.RPCategoryType.CategoryTypeID, dbo.RPCategoryType.CategoryTypeNameA, " +
                            " dbo.RPCategoryType.CategoryTypeNameE " +
                            " FROM    dbo.RPProcessTypeCategory INNER JOIN " +
                            " dbo.RPCategory ON dbo.RPProcessTypeCategory.CategoryID = dbo.RPCategory.CategoryID INNER JOIN " +
                            " dbo.RPCategoryType ON dbo.RPCategory.CategoryType = dbo.RPCategoryType.CategoryTypeID where 1=1  ";
            if (_ProcessTypeID != 0)
                strSql = strSql + " and  dbo.RPProcessTypeCategory.ProcessTypeID=" + _ProcessTypeID;
            if (_ProcessTypeIDs != null && _ProcessTypeIDs != "")
            {
                strSql = strSql + " and  dbo.RPProcessTypeCategory.ProcessTypeID in (" + _ProcessTypeIDs + ") ";
 
            }
            if (_CategoryName != null && _CategoryName != "")
            {
                strSql = strSql + " and RPCategory.CategoryNameA like '%" + _CategoryName + "%' ";
            }
            if (_CategoryCode != null && _CategoryCode != "")
            {
                strSql = strSql + " and RPCategory.CategoryCode like '%" + _CategoryCode + "%' ";
            }
            if (_CategoryTypeID != 0)
            {
                strSql = strSql + " and RPCategory.CategoryType=" + _CategoryTypeID;
            }
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }

        #endregion

    }
}
