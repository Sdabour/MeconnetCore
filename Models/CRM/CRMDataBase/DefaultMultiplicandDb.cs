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
    public class DefaultMultiplicandDb : MultiplicandDb
    {
        #region Private Data
        DataTable _TempDataTable;
        #endregion

        #region Constructors
        public DefaultMultiplicandDb()
        { 

        }
        public DefaultMultiplicandDb(DataRow objDR)
        {
            _PeriodAmount = int.Parse(objDR["PeriodAmount"].ToString());
            _Period = int.Parse(objDR["Period"].ToString());
            _YearlyToMonthly = double.Parse(objDR["YearlyToMonthly"].ToString());
        }
        #endregion

        #region Public Properties
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
        public static string SearchStr
        {
            get
            {
                string Returned = " SELECT     PeriodAmount, Period, YearlyToMonthly" +
                                  " FROM    CRMDefaultMultiplicand ";
                return Returned;

            }
        }
        #endregion

        #region Private Methods

        #endregion

        #region Public Methods
        public override DataTable Search()
        {
            string strSql =  SearchStr;
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        public override void InsertCol()
        {
            
            if (_TempDataTable == null || _TempDataTable.Rows.Count == 0)
                return;
            string[] arrStr = new string[_TempDataTable.Rows.Count+1];
            arrStr[0] = "delete from CRMDefaultMultiplicand ";
            int intIndex = 1;
            foreach (DataRow objDR in _TempDataTable.Rows)
            {
                arrStr[intIndex] = " INSERT INTO CRMDefaultMultiplicand (PeriodAmount, Period, YearlyToMonthly) VALUES "+
                    " (" + int.Parse(objDR["Amount"].ToString()) + "," + int.Parse(objDR["Period"].ToString()) + "," + int.Parse(objDR["YearlyToMonthly"].ToString()) + ")";
                intIndex++;
            }
            SysData.SharpVisionBaseDb.ExecuteNonQuery(arrStr);
        }
        
        #endregion
    }
}
