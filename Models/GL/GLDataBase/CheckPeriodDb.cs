using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.SystemBase;
namespace SharpVision.GL.GLDataBase
{
    public class CheckPeriodDb
    {
        #region Private Data
        int _ID;
        string _Name;
        DateTime _StartDate;
        DateTime _EndDate;

        #endregion
        #region Constructors
        public CheckPeriodDb()
        { 
        }
        public CheckPeriodDb(DataRow objDr)
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
            _ID = int.Parse(objDr["CeckPeriodID"].ToString());
            _Name = objDr["CeckPeriodName"].ToString();
            if(objDr["CeckPeriodStartDate"].ToString()!= "")
            _StartDate = DateTime.Parse(objDr["CeckPeriodStartDate"].ToString());
            if(objDr["CeckPeriodEndDate"].ToString()!= "")
            _EndDate = DateTime.Parse(objDr["CeckPeriodEndDate"].ToString());
 
        }
        #endregion
        #region Public Methods
        public DataTable Search()
        {
            string strSql = "SELECT     CeckPeriodID, CheckPeriodName, CheckPeriodStartDate, CheckPeriodEndDate "+
                   " FROM  dbo.GLCheckPeriodReport ";
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        #endregion
    }
}
