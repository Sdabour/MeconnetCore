using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.SystemBase;
using SharpVision.Base.BaseDataBase;

namespace SharpVision.GL.GLDataBase
{
    public class FinancialPeriodDb
    {
        #region Private Data
        protected int _ID;
        protected DateTime _StartDate;
        protected DateTime _EndDate;
        protected bool _IsCurrent;
        protected int _Year;
        protected string _Desc;

        bool _IsStopped;
        int _IsStoppedStatus;/*
                              * 0 all
                              * 1 only stopped
                              * 2 only running
                              */
   
        #endregion
        #region Constractors
        public FinancialPeriodDb()
        { 

        }
        public FinancialPeriodDb(DataRow objDR)
        {
            SetData(objDR);
        }
        #endregion
        #region Public Accessorice
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
        public int Year
        {
            set
            {
                _Year = value;
            }
            get
            {
                return _Year;
            }
        }
        public DateTime StartDate
        {
            set
            {
                _StartDate = value;
            }
            get
            {
                return _StartDate;
            }
        }
        public DateTime EndDate
        {
            set
            {
                _EndDate = value;
            }
            get
            {
                return _EndDate;
            }
        }
        public bool IsCurrent
        {
            set
            {
                _IsCurrent = value;
            }
            get
            {
                return _IsCurrent;
            }
        }
        public string Desc
        {
            set
            {
                _Desc = value;
            }
            get
            {
                return _Desc;
            }
        }
        public bool IsStopped
        {
            set
            {
                _IsStopped = value;
            }
            get
            {
                return _IsStopped;
            }
        }
        public int IsStoppedStatus
        {
            set
            {
                _IsStoppedStatus = value;
            }
        }
       
        public static string SearchStr
        {
            get
            {
                string Returned = " SELECT PeriodID,  PeriodYear"+
                    ", PeriodDesc, PeriodStartDate, PeriodEndDate,PeriodIsStopped ,YearTable.* "+
                       " FROM  dbo.GLFinancialPeriod "+
                       " left outer join ("+ FinancialYearDb.SearchStr +") as YearTable  "+
                       "  on dbo.GLFinancialPeriod.PeriodYear = YearTable.YearID  "; 
                return Returned;
            }
        }
        #endregion
        #region Private Methods
        void SetData(DataRow objDR)
        {
            _ID = int.Parse(objDR["PeriodID"].ToString());
            _StartDate = DateTime.Parse(objDR["PeriodStartDate"].ToString());
            _EndDate = DateTime.Parse(objDR["PeriodEndDate"].ToString());
            _Desc = objDR["PeriodDesc"].ToString() ;
            if(objDR["YearID"].ToString()!= "")
            _Year = int.Parse(objDR["YearID"].ToString());
        if (objDR["PeriodIsStopped"].ToString() != "")
            _IsStopped = bool.Parse(objDR["PeriodIsStopped"].ToString());
        }
        #endregion
        #region Public Methods
        public void Add()
        {
            double dblStartDate = _StartDate.ToOADate() - 2;
            double dblEndDate = _EndDate.ToOADate() - 2;
            int intIsCurrent = _IsCurrent == true ? 1 : 0;
            int intIsStopped = _IsStopped ? 1 : 0;
            string strSql = " INSERT INTO GLFinancialPeriod"+
                            " ( PeriodYear, PeriodDesc, PeriodStartDate"+
                            ", PeriodEndDate,PeriodIsStopped, UsrIns, TimIns)"+
                            " VALUES     ("+ _Year + ",'" + _Desc + "',"  +dblStartDate+","+dblEndDate+
                            ","+ intIsStopped + ","+
                            ""+SysData.CurrentUser.ID +",GetDate()) ";
            _ID =  SysData.SharpVisionBaseDb.InsertIdentityTable(strSql);
        }
        public void Edit()
        {
            double dblStartDate = _StartDate.ToOADate() - 2;
            double dblEndDate = _EndDate.ToOADate() - 2;
            int intIsCurrent = _IsCurrent == true ? 1 : 0;
            int intIsStopped = _IsStopped ? 1 : 0;
            string strSql = " UPDATE    GLFinancialPeriod" +
                            " SET PeriodYear= " + _Year +
                            ",PeriodDesc='"+ _Desc +"'"+
                            ", PeriodStartDate =" + dblStartDate + "" +
                            " , PeriodEndDate =" + dblEndDate + "" +
                            ",PeriodIsStopped = "+ intIsStopped +
                            " , UsrUpd =" + SysData.CurrentUser.ID + " " +
                            ",TimUpd=GetDate() "+
                            " where PeriodID = " + _ID;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public void Delete()
        {
            string strSql = " update GLFinancialPeriod  set Dis=GetDate() where PeriodID = " + _ID;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public DataTable Search()
        {
            string strSql = SearchStr + " where 1 = 1 ";
            if (_ID != 0)
                strSql = strSql + " and PeriodID = " + _ID;
            if (_IsStoppedStatus == 1)
                strSql += " and PeriodIsStopped = 1 ";
            if (_IsStoppedStatus == 2)
                strSql += " and PeriodIsStopped = 0 ";
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }

        public void EditCurrentPerioed()
        {

            double dblStartDate = _StartDate.ToOADate() - 2;
            double dblEndDate = _EndDate.ToOADate() - 2;
            int intIsCurrent = _IsCurrent == true ? 1 : 0;

            string strSql = " UPDATE    GLFinancialPeriod" +
                          " SET   PeriodIsCurrent = 0 ";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);

            string strUpdate = " UPDATE    GLFinancialPeriod" +
                            " SET  PeriosStartDate =" + dblStartDate + "" +
                            " , PeriodEndDate =" + dblEndDate + "" +
                            " , PeriodIsCurrent =" + intIsCurrent + " " +
                            " where PeriodID = " + _ID;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strUpdate);
        }
        public void EditStoppStatus()
        {

            int intIsStopped = _IsStopped ? 1 : 0;
            string strSql = " UPDATE    GLFinancialPeriod" +
                            " SET  PeriodIsStopped = " + intIsStopped +
                            " , UsrUpd =" + SysData.CurrentUser.ID + " " +
                            ",TimUpd=GetDate() " +
                            " where PeriodID = " + _ID;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public void JoinRecursiveTransaction()
        {
            if(_ID == 0 )
                return;
            RecursiveTransactionDb objDb = new RecursiveTransactionDb();
            objDb.PeriodID = ID;
            DataTable dtTemp = objDb.Search();
            string strSql = "";
            string[] arrStr = new string[dtTemp.Rows.Count];
            
            int intIndex = 0;
            foreach (DataRow objDr in dtTemp.Rows)
            {
                objDb = new RecursiveTransactionDb(objDr);
                strSql = " insert GLTransaction "+
                    " ( TransactionPeriod, TransactionDate, TransactionCode, TransactionType, TransactionCurrency"+
                    ", TransactionBaseCurrency, TransactionCurrencyValue, "+
                     " TransactionDesc, TransactionStatus,TransactionRecursiveTransactionID) ";
                strSql += " SELECT     "+ _ID +" AS TransactionPeriod, GETDATE() AS TRansactionDate"+
                    ", TransactionCode, TransactionType, TransactionCurrency, TransactionBaseCurrency,"+ 
                    "TransactionCurrencyValue, TransactionDesc, 1 AS TRansactionStatus ,"+ objDb.ID.ToString() + " as TransactionRecursiveID "+
                    " FROM     dbo.GLRecursiveTransaction "+
                    " WHERE     (TransactionID = "+ objDb.ID +") "+
                    " AND (NOT EXISTS "+
                    " (SELECT     dbo.GLTransaction.TransactionID "+
                    " FROM  dbo.GLTransaction "+
                    " WHERE (dbo.GLTransaction.TransactionRecursiveTransactionID = " + objDb.ID +
                    ") AND (dbo.GLTransaction.TransactionPeriod = "+ _ID +")))";
                strSql += " declare @ID int "+
                          " set @ID = (select @@Identity) ";
                strSql += " insert into   dbo.GLTransactionElement (ElementTransaction, ElementAccount, ElementValue, ElementDirection, ElementCostCenter, ElementOrder) "+
                    " SELECT  dbo.GLTransaction.TransactionID, dbo.GLRecursiveTransactionElement.ElementAccount, dbo.GLRecursiveTransactionElement.ElementValue, "+
                     " dbo.GLRecursiveTransactionElement.ElementDirection, dbo.GLRecursiveTransactionElement.ElementCostCenter,  "+
                      "dbo.GLRecursiveTransactionElement.ElementOrder "+
                      " FROM         dbo.GLTransaction INNER JOIN "+
                      " dbo.GLRecursiveTransactionElement ON dbo.GLTransaction.TransactionRecursiveTransactionID = dbo.GLRecursiveTransactionElement.ElementTransaction "+
                      " WHERE     (dbo.GLTransaction.TransactionID = @ID) "+
                      " AND (dbo.GLTransaction.TransactionRecursiveTransactionID = "+ objDb.ID +") "+
                      "  AND (dbo.GLTransaction.TransactionPeriod = "+ _ID +") ";


                arrStr[intIndex] = strSql;
                intIndex++;
            }
            SysData.SharpVisionBaseDb.ExecuteNonQuery(arrStr);
        }
        #endregion


    }
}
