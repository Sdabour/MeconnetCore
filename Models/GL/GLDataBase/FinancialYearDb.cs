using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.SystemBase;
using SharpVision.Base.BaseDataBase;

namespace SharpVision.GL.GLDataBase
{
    public class FinancialYearDb
    {
        #region Private Data
        protected int _ID;
        protected DateTime _StartDate;
        protected DateTime _EndDate;
        protected DateTime _CloseDate;
        protected bool _IsClosed;
        protected string _Desc;
        protected int _Company;
        protected string _CompanyName;
        int _LastPeriodID;
        string _LastPeriodDesc;
        DateTime _LastPeriodStartDate;
        DateTime _LastPeriodEndDate;
        #endregion
        #region Constractors
        public FinancialYearDb()
        {

        }
        public FinancialYearDb(DataRow objDR)
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
        public DateTime CloseDate
        {
            set
            {
                _CloseDate = value;
            }
            get
            {
                return _CloseDate;
            }
        }
        public bool IsClosed
        {
            set
            {
                _IsClosed = value;
            }
            get
            {
                return _IsClosed;
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
        public int Company
        {
            set
            {
                _Company = value;
            }
            get
            {
                return _Company;
            }
        }
        public string CompanyName
        {
            get
            {
                return _CompanyName;
            }
        }
        public int LastPeriodID
        {
            get
            {
                return _LastPeriodID;
            }
        }
        public string LastPeriodDesc
        {
            get
            {
                return _LastPeriodDesc;
            }
        }
        public DateTime LastPeriodStartDate
        {
            get
            {
                return _LastPeriodStartDate;
            }
        }
        public DateTime LastPeriodEndDate
        {
            get
            {
                return _LastPeriodEndDate;
            }
        }
        public static string SearchStr
        {
            get
            {
                string strLastFinacialPeriod = "SELECT     dbo.GLFinancialPeriod.PeriodID AS LastPeriodID, dbo.GLFinancialPeriod.PeriodYear AS LastPeriodYear"+
                    ", dbo.GLFinancialPeriod.PeriodDesc AS LastPeriodDesc, "+
                     "dbo.GLFinancialPeriod.PeriodStartDate AS LastPeriodStartDate, dbo.GLFinancialPeriod.PeriodEndDate AS LastPeriodEndDate"+
                     " FROM         dbo.GLFinancialPeriod INNER JOIN "+
                     " (SELECT     PeriodYear, MAX(PeriodID) AS MaxPeriod "+
                     " FROM         dbo.GLFinancialPeriod AS GLFinancialPeriod_1 "+
                     " GROUP BY PeriodYear) AS NativeTable ON dbo.GLFinancialPeriod.PeriodID = NativeTable.MaxPeriod ";
                string strCompany = "SELECT CompanyID AS YearCompanyID, CompanyNameA AS YearCompanyName "+
                       " FROM         dbo.GLCompany ";
                string Returned = " SELECT  YearID,YearDesc,YearCompany, YearStartDate, YearEndDate,YearCloseDate " +
                    ",YearCompanyTable.*,LastPeriodTable.*  "+
                                  " FROM  GLFinancialYear "+
                                  " left outer join (" + strCompany + ") as YearCompanyTable "+
                                  " on GLFinancialYear.YearCompany = YearCompanyTable.YearCompanyID  "+
                                  " left outer join ("+ strLastFinacialPeriod +") as LastPeriodTable "+
                                  " on GLFinancialYear.YearID = LastPeriodTable.LastPeriodYear ";
                return Returned;
            }
        }
        #endregion
        #region Private Methods
        void SetData(DataRow objDR)
        {
            if (objDR.Table.Columns["YearID"] == null || objDR["YearID"].ToString() == "")
                return;
            _ID = int.Parse(objDR["YearID"].ToString());
            _StartDate = DateTime.Parse(objDR["YearStartDate"].ToString());
            _EndDate = DateTime.Parse(objDR["YearEndDate"].ToString());
            _IsClosed = false;
            if(objDR["YearCloseDate"].ToString()!= "")
            {
             _CloseDate = DateTime.Parse(objDR["YearCloseDate"].ToString());
        _IsClosed = true;
         }
         _Desc = objDR["YearDesc"].ToString();
         if (objDR.Table.Columns["YearCompanyID"] != null &&
             objDR["YearCompanyID"].ToString() != "")
         {
             _Company = int.Parse(objDR["YearCompanyID"].ToString());
             _CompanyName = objDR["YearCompanyName"].ToString();
            
         }
         if (objDR.Table.Columns["LastPeriodID"] != null)
         {
             if (objDR["LastPeriodID"].ToString() != "")
                 _LastPeriodID = int.Parse(objDR["LastPeriodID"].ToString());
             _LastPeriodDesc = objDR["LastPeriodDesc"].ToString();
             if (objDR["LastPeriodStartDate"].ToString() != "")
                 _LastPeriodStartDate = DateTime.Parse(objDR["LastPeriodStartDate"].ToString());
             if(objDR["LastPeriodEndDate"].ToString()!= "")
                 _LastPeriodEndDate = DateTime.Parse(objDR["LastPeriodEndDate"].ToString());

         }
        }
        #endregion
        #region Public Methods
        public void Add()
        {
            double dblStartDate = SysUtility.Approximate( _StartDate.ToOADate() - 2,1,ApproximateType.Down);
            double dblEndDate =  SysUtility.Approximate(_EndDate.ToOADate() - 2,1,ApproximateType.Down);
            string strCloseDate = _IsClosed ?
                SysUtility.Approximate(_CloseDate.ToOADate() - 2, 1, ApproximateType.Down).ToString() : "null";
            string strSql = " INSERT INTO GLFinancialYear" +
                            " (YearDesc,YearCompany,YearStartDate, YearEndDate,YearCloseDate)" +
                            " VALUES     ('" + _Desc  + "'," + _Company + ","  +
                            dblStartDate + "," + dblEndDate + "," + strCloseDate + ") ";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public void Edit()
        {
            double dblStartDate = SysUtility.Approximate(_StartDate.ToOADate() - 2, 1, ApproximateType.Down);
            double dblEndDate = SysUtility.Approximate(_EndDate.ToOADate() - 2, 1, ApproximateType.Down);
            string strCloseDate = _IsClosed ?
              SysUtility.Approximate(_CloseDate.ToOADate() - 2, 1, ApproximateType.Down).ToString() : "null";
            string strSql = " UPDATE  GLFinancialYear" +
                            " SET  YearDesc='"+ _Desc +"'"+
                            ",YearCompany="+ _Company +
                            ",YearStartDate =" + dblStartDate + "" +
                            " , YearEndDate =" + dblEndDate + "" +
                            ",YearCloseDate=" + strCloseDate + 
                            " where YearID = " + _ID;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public void Delete()
        {
            string strSql = " update GLFinancialYear set Dis = GetDate() where YearID = " + _ID;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public DataTable Search()
        {
            string strSql = SearchStr + " where Dis is null ";
            if (_ID != 0)
                strSql = strSql + " and YearID = " + _ID;
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }

        public void EditCurrentPerioed()
        {

            //double dblStartDate = _StartDate.ToOADate() - 2;
            //double dblEndDate = _EndDate.ToOADate() - 2;
           

            //string strSql = " UPDATE    GLFinancialYear" +
            //              " SET   YearIsCurrent = 0 ";
            //SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);

            //string strUpdate = " UPDATE    GLFinancialYear" +
            //                " SET  YearStartDate =" + dblStartDate + "" +
            //                " , YearEndDate =" + dblEndDate + "" +
            //                " , YearIsCurrent =" + intIsCurrent + " " +
            //                " where YearID = " + _ID;
            //SysData.SharpVisionBaseDb.ExecuteNonQuery(strUpdate);
        }
        #endregion


    }
}
