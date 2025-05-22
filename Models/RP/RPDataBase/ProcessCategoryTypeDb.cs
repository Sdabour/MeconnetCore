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
    public class ProcessCategoryTypeDb
    {


        #region Private Data
        protected int _ProcessID;
        protected int _CategoryID;
        protected double _Amount;
        protected double _AllowedScrapPerc;
        protected int _UnitID;
        string _ProcessIDs;

        #region Private data For search
        string _CategoryCode;
        string _CategoryName;
        int _CategoryTypeID;
        #endregion
        #endregion

        #region Constructors
        public ProcessCategoryTypeDb()
        {

        }
        public ProcessCategoryTypeDb(DataRow objDr)
        {
            _ProcessID = int.Parse(objDr["ProcessID"].ToString());
            _CategoryID = int.Parse(objDr["CategoryTypeID"].ToString());
            _Amount = double.Parse(objDr["CategoryAmount"].ToString());
            _AllowedScrapPerc = double.Parse(objDr["CategoryAllowedScrapPerc"].ToString());
            _UnitID = int.Parse(objDr["CategoryUnit"].ToString());
        }
        #endregion
        #region Public Proberties
        public int ProcessID
        {
            set { _ProcessID = value; }
            get { return _ProcessID; }
        }
        public double Amount
        {
            set { _Amount = value; }
            get { return _Amount; }

        }
        public double AllowedScrapPerc
        {
            set
            {
                _AllowedScrapPerc = value;
            }
            get
            {
                return _AllowedScrapPerc;
            }
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
        public string ProcessIDs
        {
            set
            {
                _ProcessIDs = value;
            }
        }
        public string SearchStr
        {
            get
            {
                string Returned = "SELECT     ProcessTable.*, CategoryTypeTable.*, dbo.RPProcessCategoryType.Amount AS CategoryAmount,dbo.RPProcessCategoryType.AllowedScrapPerc AS CategoryAllowedScrapPerc, " +
                      " dbo.RPProcessCategoryType.Unit AS CategoryUnit " +
                      " FROM  (" +new ProcessDb().SearchStr + ") ProcessTable INNER JOIN " +
                      " dbo.RPProcessCategoryType ON ProcessTable.ProcessID = dbo.RPProcessCategoryType.ProcessID INNER JOIN " +
                      " (" + //CategoryTypeDb.SearchStr + 
                      ") CategoryTypeTable ON dbo.RPProcessCategoryType.CategoryID = CategoryTypeTable.CategoryTypeID";
                return Returned;
            }
        }
        #endregion
        #region Private Methods
        #endregion
        #region Public Methods
        public void Add()
        {
            string strSql = " INSERT INTO RPProcessCategory (ProcessID, CategoryID, Amount, Unit)" +
                            " VALUES     (" + _ProcessID + "," + _CategoryID + "," + _Amount + "," + _UnitID + ") ";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public void Edit()
        {
            string strSql = "update  RPProcessCategory ";
            strSql = strSql + " set CategoryID =" + _CategoryID;
            strSql = strSql + ",Amount =" + _Amount;
            strSql = strSql + ",ProcessID =" + _ProcessID;
            strSql = strSql + ",UnitID =" + _UnitID;

            strSql = strSql + " where  CategoryID = " + _CategoryID + " and ProcessID = " + _ProcessID;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public void Delete()
        {
            string strSql = "DELETE FROM RPProcessCategory ";
            strSql = strSql + " where  CategoryID = " + _CategoryID + " and ProcessID = " + _ProcessID;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public DataTable Search()
        {
            string strSql = SearchStr + " where 1=1  ";
            if (_ProcessID != 0)
                strSql = strSql + " and  ProcessTable.ProcessID=" + _ProcessID;
            if (_ProcessIDs != null && _ProcessIDs != "")
            {
                strSql = strSql + " and  ProcessTable.ProcessID in (" + _ProcessIDs + ") ";

            }
            if (_CategoryName != null && _CategoryName != "")
            {
                strSql = strSql + " and CategoryTypeTable.CategoryTypeNameA like '%" + _CategoryName + "%' ";
            }
            if (_CategoryCode != null && _CategoryCode != "")
            {
                strSql = strSql + " and CategoryTypeTable.CategoryTypeCode like '%" + _CategoryCode + "%' ";
            }
            if (_CategoryTypeID != 0)
            {
                strSql = strSql + " and CategoryTypeTable.CategoryTypeID=" + _CategoryTypeID;
            }
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }

        #endregion

    }
}
