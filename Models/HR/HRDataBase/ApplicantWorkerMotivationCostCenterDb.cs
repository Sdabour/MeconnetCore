using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.SystemBase;
using System.Data;
using System.Data.SqlClient;
using SharpVision.Base.BaseDataBase;
using SharpVision.UMS.UMSDataBase;
using SharpVision.GL.GLDataBase;
namespace SharpVision.HR.HRDataBase
{
    public class ApplicantWorkerMotivationCostCenterDb
    {
        #region Private Data
        protected int _Applicant;
        protected int _CostCenter;
        string _ApplicantIDs;
        #endregion
        #region Constructors
        public ApplicantWorkerMotivationCostCenterDb()
        {
        }
        public ApplicantWorkerMotivationCostCenterDb(DataRow objDR)
        {
            SetData(objDR);
        }
        #endregion
        #region Public Properties
        public int Applicant
        {
            set
            {
                _Applicant = value;
            }
            get
            {
                return _Applicant;
            }
        }
        public int CostCenter
        {
            set
            {
                _CostCenter = value;
            }
            get
            {
                return _CostCenter;
            }
        }
        public string ApplicantIDs
        {
            set
            {
                _ApplicantIDs = value;
            }
        }
        public string AddStr
        {
            get
            {
                string Returned = " Insert into HRApplicantWorkerMotivationCostCenter (Applicant, CostCenter) Values ("+ _Applicant +","+_CostCenter  +")";
                return Returned;
            }
        }
        public string EditStr
        {
            get
            {
                string Returned = " ";
                return Returned;
            }
        }
        public string DeleteStr
        {
            get
            {
                string Returned = " ";
                return Returned;
            }
        }
        public static string SearchStr
        {
            get
            {
                string Returned = " SELECT     HRApplicantWorkerMotivationCostCenter.Applicant as CostCenterApplicant, HRApplicantWorkerMotivationCostCenter.CostCenter as CostCenterIDValue,CostCenterTable1.*" +
                                  " FROM         HRApplicantWorkerMotivationCostCenter" +
                                  " Inner join (" + CostCenterHRDb.SearchStr + ") as CostCenterTable1 On " +
                                  " CostCenterTable1.CostCenterID = HRApplicantWorkerMotivationCostCenter.CostCenter ";
                return Returned;
            }
        }

        #endregion
        #region Private Methods
        void SetData(DataRow objDR)
        {
            if (objDR["CostCenterApplicant"].ToString() != "")
            {
                _Applicant = int.Parse(objDR["CostCenterApplicant"].ToString());
                _CostCenter = int.Parse(objDR["CostCenterIDValue"].ToString());
            }
        }
        #endregion
        #region Public Methods
        public void Add()
        {
            SysData.SharpVisionBaseDb.ExecuteNonQuery(AddStr);
        }
        public DataTable Search()
        {
            string strSql = SearchStr + " Where 1=1 ";
            if (_Applicant != 0)
            {
                strSql += " And HRApplicantWorkerMotivationCostCenter.Applicant = "+ _Applicant +""; 
            }
            if (_CostCenter != 0)
            {
                strSql += " And HRApplicantWorkerMotivationCostCenter.CostCenter = " + _CostCenter + "";
            }
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        #endregion
    }
}
