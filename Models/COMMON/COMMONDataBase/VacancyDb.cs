using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.SystemBase;
using System.Data;
using System.Data.SqlClient;
using SharpVision.Base.BaseDataBase;

namespace SharpVision.COMMON.COMMONDataBase
{
    public class VacancyDb
    {
        #region Private Data
        protected int _ID;
        protected string _Desc;
        protected bool _IsWeekly;
        protected bool _IsMonthly;
        protected bool _IsYearly;
        protected DateTime _StartDate;
        protected DateTime _EndDate;
        protected bool _IsDoubledSalary;
        protected bool _DateSearch;
        protected DateTime _StartDateSearch;
        protected DateTime _EndDateSearch;
        protected bool _IsShowInInsurance;
        protected byte _IsShowInInsuranceSearch;
        #endregion
        #region Constructors
        public VacancyDb()
        {

        }
        public VacancyDb(int intID)
        {
            _ID = intID;
            DataTable dtTemp = Search();
            if (dtTemp.Rows.Count != 0)
            {
                DataRow objDR = dtTemp.Rows[0];
                _Desc = objDR["VacancyDesc"].ToString();
                _IsWeekly = bool.Parse(objDR["VacancyIsWeekly"].ToString());
                _IsMonthly = bool.Parse(objDR["VacancyIsMonthly"].ToString());
                _StartDate = DateTime.Parse(objDR["VacancyStartDate"].ToString());
                _EndDate = DateTime.Parse(objDR["VacancyEndDate"].ToString());
                _IsYearly = bool.Parse(objDR["VacancyIsYearly"].ToString());
                if (objDR["VacancyDoubledSalary"].ToString() != "")
                    _IsDoubledSalary = bool.Parse(objDR["VacancyDoubledSalary"].ToString());
                else
                    _IsDoubledSalary = false;

                if (objDR["IsShowInInsurance"].ToString() != "")
                    _IsShowInInsurance = bool.Parse(objDR["IsShowInInsurance"].ToString());
                else
                    _IsShowInInsurance = false;
            }
        }
        public VacancyDb(DataRow objDR)
        {
            _ID = int.Parse(objDR["VacancyID"].ToString());
            _Desc = objDR["VacancyDesc"].ToString();
            _IsWeekly = bool.Parse(objDR["VacancyIsWeekly"].ToString());
            _IsMonthly = bool.Parse(objDR["VacancyIsMonthly"].ToString());
            _StartDate = DateTime.Parse(objDR["VacancyStartDate"].ToString());
            _EndDate = DateTime.Parse(objDR["VacancyEndDate"].ToString());
            _IsYearly = bool.Parse(objDR["VacancyIsYearly"].ToString());
            if (objDR["VacancyDoubledSalary"].ToString() != "")
                _IsDoubledSalary = bool.Parse(objDR["VacancyDoubledSalary"].ToString());
            else
                _IsDoubledSalary = false;
            if (objDR["IsShowInInsurance"].ToString() != "")
                _IsShowInInsurance = bool.Parse(objDR["IsShowInInsurance"].ToString());
            else
                _IsShowInInsurance = false;
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
        public bool IsWeekly
        {
            set
            {
                _IsWeekly = value;
            }
            get
            {
                return _IsWeekly;
            }

        }
        public bool IsMonthly
        {
            set
            {
                _IsMonthly = value;
            }
            get
            {
                return _IsMonthly;
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

        public bool IsYearly
        {
            set
            {
                _IsYearly = value;
            }
            get
            {
                return _IsYearly;
            }

        }

        public bool IsDoubledSalary
        {
            set
            {
                _IsDoubledSalary = value;
            }
            get
            {
                return _IsDoubledSalary;
            }

        }
        public bool IsShowInInsurance
        {
            set
            {
                _IsShowInInsurance = value;
            }
            get
            {
                return _IsShowInInsurance;
            }

        }
        public byte IsShowInInsuranceSearch
        {
            set
            {
                _IsShowInInsuranceSearch = value;
            }           
        }
        public DateTime StartDateSearch
        {
            set
            {
                _StartDateSearch = value;
            }            
        }
        public DateTime EndDateSearch
        {
            set
            {
                _EndDateSearch = value;
            }            
        }
        public bool DateSearch
        {
            set
            {
                _DateSearch = value;
            }
        }
        public static string SearchStr
        {
            get
            {
                string Returned = " SELECT  VacancyID, VacancyDesc, VacancyIsWeekly, VacancyIsMonthly, VacancyStartDate, VacancyEndDate "+
                                  " ,VacancyIsYearly,VacancyDoubledSalary ,IsShowInInsurance" +
                                  " FROM   COMMONVacancy ";
                return Returned;
            }
        }

        #endregion
        #region Private Methods

        #endregion
        #region Public Methods
        public void Add()
        {
            int IsWeek = _IsWeekly ? 1 : 0;
            int IsMonth = _IsMonthly ? 1 : 0;
            int IsYear = _IsYearly ? 1 : 0;
            int IsDoubledSalary = _IsYearly ? 1 : 0;
            int intIsShowInInsurance = _IsShowInInsurance ? 1 : 0;
            double StartDate = _StartDate.ToOADate() - 2;
            double EndDate = _EndDate.ToOADate() - 2;

            string strSql = " INSERT INTO COMMONVacancy "+
                            "(VacancyDesc, VacancyIsWeekly, VacancyIsMonthly, VacancyStartDate, VacancyEndDate,VacancyIsYearly,VacancyDoubledSalary,IsShowInInsurance)" +
                            " VALUES     ('" + _Desc + "'," + IsWeek + "," + IsMonth + "," + StartDate + "," + EndDate + "," + IsYear + "," + IsDoubledSalary + ","+ intIsShowInInsurance +") ";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public void Edit()
        {
            int IsWeek = _IsWeekly ? 1 : 0;
            int IsMonth = _IsMonthly ? 1 : 0;
            int IsYear = _IsYearly ? 1 : 0;
            int IsDoubledSalary = _IsYearly ? 1 : 0;
            double StartDate = _StartDate.ToOADate() - 2;
            double EndDate = _EndDate.ToOADate() - 2;
            int intIsShowInInsurance = _IsShowInInsurance ? 1 : 0;
            string strSql = " UPDATE    COMMONVacancy " +
                            " SET VacancyDesc ='" + _Desc + "'" +
                            ", VacancyIsWeekly =" + IsWeek + "" +
                            ", VacancyIsMonthly =" + IsMonth + "" +
                            ", VacancyIsYearly =" + IsYear + "" +
                            ", VacancyStartDate =" + StartDate + "" +
                            ", VacancyEndDate =" + EndDate + "" +
                            ", VacancyDoubledSalary =" + IsDoubledSalary + "" +
                            ", IsShowInInsurance=" + intIsShowInInsurance + "" +
                            " WHERE     (VacancyID = " + _ID + ") ";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public void Delete()
        {
            string strSql = " UPDATE    COMMONVacancy SET   Dis = GetDate()"+
                " WHERE     (VacancyID = " + _ID + ") ";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public DataTable Search()
        {
            //and ((VacancyIsWeekly=1) or (VacancyIsMonthly=1) (VacancyIsYearly =1) or )
            string strSql = SearchStr + " WHERE     (Dis IS NULL)   ";
            if (_ID != 0)
                strSql += " And  VacancyID  = " + _ID + "";
            if (_DateSearch)
            {
                double dlStartDate = _StartDateSearch.ToOADate() - 2;
                double dlEndDate = _EndDateSearch.ToOADate() - 2;

                strSql += " And ( VacancyStartDate Between "+ dlStartDate +" And "+ dlEndDate +" )";

            }
            if (_IsShowInInsuranceSearch != 0)
            {
                if (_IsShowInInsuranceSearch == 1)
                {
                    strSql += " And ( IsShowInInsurance =1)";
                }
                else 
                {
                    strSql += " And ( IsShowInInsurance =0)";
                }

            }
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        #endregion
    }
}
