using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.SystemBase;
namespace SharpVision.GL.GLDataBase
{
    public class CheckPeriodStatisticDb
    {
        #region Private Data
        int _PeriodNo;
        string _Place;
        double _Value;
        string _PeriodName;
        bool _Direction = true;
        #endregion
        #region Constructors
        public CheckPeriodStatisticDb()
        { 
        }
        public CheckPeriodStatisticDb(DataRow objDr)
        {
            SetData(objDr);
 
        }
        #endregion
        #region Public Properties
        public bool Direction
        {
            set
            {
                _Direction = value;
            }
        }
        public int PeriodNo
        {
            get
            {
                return _PeriodNo;
            }
        }
        public string PeriodName
        {
            get
            {
                return _PeriodName;
            }
        }
        public string Place
        {
            get
            {
                return _Place;
            }
        }
        public double Value
        {
            get
            {
                return _Value;
            }
        }
        public string SearchStr
        {
            get
            {
                int intDirection = _Direction ? 1 : 0;
                string strPlace = _Direction ? "dbo.GLCoffer.CofferNameA" : " dbo.GLBank.BankNameA";
                string strPlaceCondition = _Direction? " and GLCheck.ChcekCurrentPlace<>0 " : "";
                string strSql = "SELECT   TOP 100 PERCENT dbo.GLCheckPeriodReport.CheckPeriodID, dbo.GLCheckPeriodReport.CheckPeriodName, SUM(dbo.GLCheck.CheckValue) "+
                                " AS TotalValue,"+ strPlace +
                                " FROM         dbo.GLCheckPeriodReport INNER JOIN "+
                                " dbo.GLCheck ON dbo.GLCheckPeriodReport.CheckPeriodStartDate <= dbo.GLCheck.CheckDueDate AND "+
                                " dbo.GLCheckPeriodReport.CheckPeriodEndDate > dbo.GLCheck.CheckDueDate OR "+
                                " dbo.GLCheckPeriodReport.CheckPeriodStartDate <= dbo.GLCheck.CheckDueDate AND dbo.GLCheckPeriodReport.CheckPeriodEndDate IS NULL OR "+
                                " dbo.GLCheckPeriodReport.CheckPeriodEndDate > dbo.GLCheck.CheckDueDate AND dbo.GLCheckPeriodReport.CheckPeriodStartDate IS NULL "+
                                " LEFT OUTER JOIN "+
                                " dbo.GLCoffer ON dbo.GLCheck.ChcekCurrentPlace = dbo.GLCoffer.CofferID "+
                                " LEFT OUTER JOIN "+
                                " dbo.GLBank ON dbo.GLCheck.CheckBank = dbo.GLBank.BankID "+
                                " WHERE  (dbo.GLCheck.CheckDirection="+ intDirection +") and (dbo.GLCheck.CheckCurrentStatus IN (0, 1, 3, 5))  " + strPlaceCondition +
                                " GROUP BY dbo.GLCheckPeriodReport.CheckPeriodID, dbo.GLCheckPeriodReport.CheckPeriodName, "+ strPlace +
                                " ORDER BY dbo.GLCheckPeriodReport.CheckPeriodID";
                return strSql;
            }
        }
        #endregion
        #region Private Methods
        void SetData(DataRow objDr)
        {
            _PeriodNo = int.Parse(objDr["CheckPeriodID"].ToString());
            if (objDr.Table.Columns["CofferNameA"] != null)
                _Place = objDr["CofferNameA"].ToString();
            else
                _Place = objDr["BankNameA"].ToString();
            if (_Place == "")
                _Place = "€Ì— „Õœœ";
            _Value = double.Parse(objDr["Totalvalue"].ToString());
           _PeriodName = objDr["CheckPeriodName"].ToString();
        }
        #endregion
        #region Public Methods
        public DataTable Search()
        {
            string strSql = SearchStr;
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        #endregion
    }
}
