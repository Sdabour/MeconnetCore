using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.SystemBase;
namespace SharpVision.CRM.CRMDataBase
{
    public class InstallmentPeriodDb
    {
        #region Private Data
        int _ID;
        string _Name;
        DateTime _StartDate;
        DateTime _EndDate;

        #endregion
        #region Constructors
        public InstallmentPeriodDb()
        {
        }
        public InstallmentPeriodDb(DataRow objDr)
        {
            SetData(objDr);
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
        public string Name
        {
            set
            {
                _Name = value;
            }
            get
            {
                return _Name;
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
        #endregion
        #region Private Methods
        void SetData(DataRow objDr)
        {
            _ID = int.Parse(objDr["InstallmentPeriodID"].ToString());
            _Name = objDr["InstallmentPeriodName"].ToString();
            if (objDr["InstallmentPeriodStartDate"].ToString() != "")
                _StartDate = DateTime.Parse(objDr["InstallmentPeriodStartDate"].ToString());
            if (objDr["InstallmentPeriodEndDate"].ToString() != "")
                _EndDate = DateTime.Parse(objDr["InstallmentPeriodEndDate"].ToString());

        }
        #endregion
        #region Public Methods
        public DataTable Search()
        {
            string strSql = "SELECT     InstallmentPeriodID, InstallmentPeriodName, InstallmentPeriodStartDate, InstallmentPeriodEndDate " +
                   " FROM  dbo.CRMInstallmentPeriodReport ";
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        #endregion
    }
}
