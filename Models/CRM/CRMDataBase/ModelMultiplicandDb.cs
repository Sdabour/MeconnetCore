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
    public class ModelMultiplicandDb : MultiplicandDb
    {
        #region Private Data
        protected int _Model;
        DataTable _TempDataTable;

        #endregion

        #region Constructors
         public ModelMultiplicandDb()
        { 

        }
        public ModelMultiplicandDb(DataRow objDR)
        {
            _Model = int.Parse(objDR["Model"].ToString());
            _PeriodAmount = int.Parse(objDR["PeriodAmount"].ToString());
            _Period = int.Parse(objDR["Period"].ToString());
            _YearlyToMonthly = double.Parse(objDR["YearlyToMonthly"].ToString());
        }
        #endregion

        #region Public Properties

        public int Model
        {
            set
            {
                _Model = value;
            }
            get
            {
                return _Model;
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
                string Returned = " SELECT     Model, PeriodAmount, Period, YearlyToMonthly" +
                                    " FROM         CRMModelMultiplicand ";
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
            strSql = strSql + " and Model=" + _Model;
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        public override void InsertCol()
        {

            if (_TempDataTable == null || _TempDataTable.Rows.Count == 0)
                return;
            string[] arrStr = new string[_TempDataTable.Rows.Count+1];
            arrStr[0] = "delete from CRMModelMultiplicand where Model=" + _Model;
            int intIndex = 1;
            foreach (DataRow objDR in _TempDataTable.Rows)
            {
                arrStr[intIndex] = " INSERT INTO CRMModelMultiplicand (PeriodAmount, Period, YearlyToMonthly,Model) VALUES " +
                    " (" + int.Parse(objDR["Amount"].ToString()) + "," + int.Parse(objDR["Period"].ToString()) + "," + int.Parse(objDR["YearlyToMonthly"].ToString()) + ","+int.Parse(objDR["Model"].ToString())+")";
                intIndex++;
            }
            SysData.SharpVisionBaseDb.ExecuteNonQuery(arrStr);
        }
        #endregion
    }
}
