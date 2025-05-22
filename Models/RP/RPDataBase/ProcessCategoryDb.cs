using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using SharpVision.SystemBase;
using SharpVision.Base.BaseDataBase;
namespace SharpVision.RP.RPDataBase
{
    public class ProcessCategoryDb
    {
        #region Private Data
        protected int _ID;
        protected int _ProcessID;
        protected int _CategoryID;
        protected double _Amount;
        protected double _UnitCost;
        protected int _UnitCostCurrency;
        protected int _UnitID;
        #endregion
        #region Constructors
        public ProcessCategoryDb()
        {

        }
        public ProcessCategoryDb(DataRow objDr)
        {
            _ID = int.Parse(objDr["ID"].ToString());
            _ProcessID = int.Parse(objDr["ProcessID"].ToString());
            _CategoryID = int.Parse(objDr["CategoryID"].ToString());
            _Amount = double.Parse(objDr["Amount"].ToString());
            _UnitCost = double.Parse(objDr["UnitCost"].ToString());
            _UnitCostCurrency = int.Parse(objDr["UnitCostCurrency"].ToString());
            _UnitID = int.Parse(objDr["UnitID"].ToString());     
        }
        #endregion
        #region Public Properties
        public int ID
        {
            set
            {
                _ID = value; 
            }
            get
            {
                return _ID; 
            }
        }
        public int ProcessID
        {
            set
            {
                _ProcessID = value; 
            }
            get
            { 
                return _ProcessID; 
            }
        }
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
        public double Amount
        {
            set
            {
                _Amount = value;
            }
            get 
            {
                return _Amount;
            }
        }
        public double UnitCost
        {
              set 
              {
                 _UnitCost = value;
              }
              get
              {
                 return _UnitCost; 
              }

        }
        public int UnitCostCurrency
        {
             set 
             {
                  _UnitCostCurrency = value;
             }
             get 
             {
                  return _UnitCostCurrency; 
             }

        }
        public int UnitID
        {
            set
            {
                _UnitID = value;
            }
            get
            {
                return _UnitID;
            }
        }
        #endregion
        #region Private Methods
        #endregion
        #region Public Methods
        public void Add()
        {
            string strSql = "INSERT INTO RPProcessCategory (ProcessID, CategoryID, Amount, UnitCost, UnitCostCurrency) VALUES (";
            strSql = strSql + _ProcessID + "," + _CategoryID + "," + _Amount + ","+_UnitCost+","+_UnitCostCurrency + ")";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public void Edit()
        {
            string strSql = "update  RPProcessCategory ";
            strSql = strSql + " set CategoryID =" + _CategoryID;
            strSql = strSql + ",Amount =" + _Amount ;
            strSql = strSql + ",UnitCost =" + _UnitCost;
            strSql = strSql + ",UnitCostCurrency =" + _UnitCostCurrency;
            strSql = strSql + " where  ID = " + _ID + " and ProcessID = " + _ProcessID;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public void Delete()
        {
            string strSql = "DELETE FROM RPProcessCategory ";
            strSql = strSql + " where  ID = " + _ID + " and ProcessID = " + _ProcessID;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }

        #endregion
    }
}


