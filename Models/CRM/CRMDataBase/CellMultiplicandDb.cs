using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.SystemBase;
using System.Data;
using System.Data.SqlClient;
using SharpVision.COMMON.COMMONDataBase;
using SharpVision.Base.BaseDataBase;

namespace SharpVision.CRM.CRMDataBase
{
    public class CellMultiplicandDb : MultiplicandDb
    {
        #region Private Data
        protected int _Cell;
        DataTable _TempDataTable;

        #endregion

        #region Constructors
         public CellMultiplicandDb()
        { 

        }
        public CellMultiplicandDb(DataRow objDR)
        {
            _Cell = int.Parse(objDR["Cell"].ToString());
            _PeriodAmount = int.Parse(objDR["PeriodAmount"].ToString());
            _Period = int.Parse(objDR["Period"].ToString());
            _YearlyToMonthly = double.Parse(objDR["YearlyToMonthly"].ToString());
        }
        #endregion

        #region Public Properties

        public int Cell
        {
            set
            {
                _Cell = value;
            }
            get
            {
                return _Cell;
            }

        }

        public DataTable TempDataTable
        {
            set
            {
                _TempDataTable = value;
            }
            get
            {
                return _TempDataTable;
            }

        }
        public static string strSearch
        {
            get
            {
                string Returned = " SELECT     Cell, PeriodAmount, Period, YearlyToMonthly" +
                                    " FROM         CRMCellMultiplicand ";
                return Returned;

            }
        }
        #endregion

        #region Private Methods

        #endregion

        #region Public Methods
        public override DataTable Search()
        {
            string strSql = strSearch + " where 1= 1 ";
            if (_Cell != 0)
                strSql = strSql + " and Cell=" + _Cell;
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        public override void InsertCol()
        {

            if (_TempDataTable == null || _TempDataTable.Rows.Count == 0)
                return;
            string[] arrStr = new string[_TempDataTable.Rows.Count+1];
            arrStr[0] = "delete from CRMCellMultiplicand where Cell=" + _Cell;
            int intIndex = 1;
            foreach (DataRow objDR in _TempDataTable.Rows)
            {
                arrStr[intIndex] = " INSERT INTO CRMCellMultiplicand (PeriodAmount, Period, YearlyToMonthly,Cell) VALUES " +
                    " (" + int.Parse(objDR["Amount"].ToString()) + "," + int.Parse(objDR["Period"].ToString()) + "," + int.Parse(objDR["YearlyToMonthly"].ToString()) + ","+int.Parse(objDR["Cell"].ToString())+")";
                intIndex++;
            }
            SysData.SharpVisionBaseDb.ExecuteNonQuery(arrStr);
        }
        #endregion
    }
}
