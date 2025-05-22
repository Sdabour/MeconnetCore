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
    public class DefaultStrategyInstallmentDb : StrategyInstallmentDb
    {
        #region Private Data
        DataTable _TempDataTable;
        #endregion

         #region Constructors
        public DefaultStrategyInstallmentDb()
        { 

        }
        public DefaultStrategyInstallmentDb(DataRow objDR)
        {
            _PeriodAmount = int.Parse(objDR["InstallmentPeriodAmount"].ToString());
            //_Period = int.Parse(objDR["InstallmentPeriod"].ToString());
            //_ApproximationValue = double.Parse(objDR["ApproximationValue"].ToString());
            //_AproximationType = int.Parse(objDR["AproximationType"].ToString());
            //_IsBasePerc = bool.Parse(objDR["InstallmentIsBasePerc"].ToString());
            _Perc = double.Parse(objDR["InstallmentPerc"].ToString());
            //_Type = int.Parse(objDR["InstallmentType"].ToString());
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
                string Returned = " SELECT   InstallmentType, InstallmentPerc, InstallmentIsBasePerc, InstallmentPeriod, InstallmentPeriodAmount, ApproximationValue, AproximationType"+
                                  " FROM   CRMDefaultStrategyInstallment ";
                return Returned;

            }
        }
        #endregion

        #region Private Methods

        #endregion

        #region Public Methods
        public  DataTable Search()
        {
            string strSql = SearchStr;
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        public  void InsertCol()
        {

            if (_TempDataTable == null || _TempDataTable.Rows.Count == 0)
                return;
            string[] arrStr = new string[_TempDataTable.Rows.Count + 1];
            arrStr[0] = "delete from CRMDefaultMultiplicand ";
            int intIndex = 1;
            foreach (DataRow objDR in _TempDataTable.Rows)
            {
                arrStr[intIndex] = " INSERT INTO CRMDefaultMultiplicand (PeriodAmount, Period, YearlyToMonthly) VALUES " +
                    " (" + int.Parse(objDR["Amount"].ToString()) + "," + int.Parse(objDR["Period"].ToString()) + "," + int.Parse(objDR["YearlyToMonthly"].ToString()) + ")";
                intIndex++;
            }
            SysData.SharpVisionBaseDb.ExecuteNonQuery(arrStr);
        }

        #endregion
    }
}
