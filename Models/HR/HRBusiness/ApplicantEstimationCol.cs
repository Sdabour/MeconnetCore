using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using SharpVision.Base.BaseDataBase;
using SharpVision.Base.BaseBusiness;
using SharpVision.HR.HRDataBase;
using SharpVision.SystemBase;
using SharpVision.COMMON.COMMONBusiness;

namespace SharpVision.HR.HRBusiness
{
    public class ApplicantEstimationCol :  CollectionBase
    {
        #region Private Data

        #endregion
        #region Constructors
        public ApplicantEstimationCol(bool IsEmpty)
        {
        }
        public ApplicantEstimationCol()
        {
            ApplicantEstimationBiz _objApplicantEstimationBiz;
            ApplicantEstimationDb _objApplicantEstimationDb = new ApplicantEstimationDb();
            DataTable dtApplicantEstimation = _objApplicantEstimationDb.Search();
            foreach (DataRow objDR in dtApplicantEstimation.Rows)
            {
                _objApplicantEstimationBiz = new ApplicantEstimationBiz(objDR);
                this.Add(_objApplicantEstimationBiz);
            }            
        }
        public ApplicantEstimationCol(int intApplicantEstimationID, int intApplicantID, int intEstimationStatementID)
        {
            ApplicantEstimationBiz _objApplicantEstimationBiz;
            ApplicantEstimationDb _objApplicantEstimationDb = new ApplicantEstimationDb();

            _objApplicantEstimationDb.ApplicantEstimationID = intApplicantEstimationID;
            _objApplicantEstimationDb.ApplicantID = intApplicantID;
            _objApplicantEstimationDb.EstimationStatementID = intEstimationStatementID;
            DataTable dtApplicantEstimation = _objApplicantEstimationDb.Search();
            foreach (DataRow objDR in dtApplicantEstimation.Rows)
            {
                _objApplicantEstimationBiz = new ApplicantEstimationBiz(objDR);
                this.Add(_objApplicantEstimationBiz);
            }
        }
        public ApplicantEstimationCol(int intEstimationStatementID, string strApplicantName, string strApplicantFamousName, string strApplicantCode)
        {
            ApplicantEstimationBiz _objApplicantEstimationBiz;
            ApplicantEstimationDb _objApplicantEstimationDb = new ApplicantEstimationDb();

            _objApplicantEstimationDb.EstimationStatementID = intEstimationStatementID;

            _objApplicantEstimationDb.ApplicantName  = strApplicantName;
            _objApplicantEstimationDb.ApplicantFamousName = strApplicantFamousName;
            _objApplicantEstimationDb.ApplicantCode = strApplicantCode;

            DataTable dtApplicantEstimation = _objApplicantEstimationDb.Search();
            foreach (DataRow objDR in dtApplicantEstimation.Rows)
            {
                _objApplicantEstimationBiz = new ApplicantEstimationBiz(objDR);
                this.Add(_objApplicantEstimationBiz);
            }
        }
        #endregion
        #region Public Properties
        public virtual ApplicantEstimationBiz this[int intIndex]
        {
            get
            {
                return (ApplicantEstimationBiz)this.List[intIndex];
            }
        }
        internal string IDsStr
        {
            get
            {
                string Returned = "";
                foreach (ApplicantEstimationBiz objBiz in this)
                {
                    if (Returned != "")
                        Returned += ",";
                    Returned += objBiz.ApplicantBiz.ID;
                }
                return Returned;
            }
        }
        #endregion
        #region Private Methods
    
        #endregion
        #region Public Methods
        
        public bool Contains(ApplicantEstimationBiz objBiz)
        {
            bool Returned = false;
            foreach (ApplicantEstimationBiz objpplicantEstimationBiz in this)
            {
                if (objpplicantEstimationBiz.ApplicantBiz.ID == objBiz.ApplicantBiz.ID)
                {
                    Returned = true;
                    break;
                }

            }
            return Returned;
        }
        public virtual string Add(ApplicantEstimationBiz objApplicantEstimationBiz)
        {
            bool blIsfound = Contains(objApplicantEstimationBiz);

            if (!blIsfound)
            {
                this.List.Add(objApplicantEstimationBiz);
                return "";
            }
            else
            {
                return "هذا الموظف موجود من قبل";
            }
        }
        internal DataTable GetTable()
        {
            DataTable dtReturned = new DataTable("HRApplicantEstimation");
            dtReturned.Columns.AddRange(new DataColumn[] { new DataColumn("ApplicantEstimationID"), new DataColumn("ApplicantID"),
                new DataColumn("EstimationStatementID"), new DataColumn("EstimationDate"), 
                new DataColumn("EstimationValue"), new DataColumn("EstimationEstimator"), new DataColumn("StatusDelete") });
            DataRow objDr;
            foreach (ApplicantEstimationBiz objBiz in this)
            {
                objDr = dtReturned.NewRow();
                objDr["ApplicantEstimationID"] = objBiz.ApplicantEstimationID;
                objDr["ApplicantID"] = objBiz.ApplicantBiz.ID;
                objDr["EstimationStatementID"] = objBiz.EstimationStatementID;
                objDr["EstimationDate"] = objBiz.EstimationDate;
                objDr["EstimationValue"] = objBiz.EstimationValue;
                objDr["EstimationEstimator"] = objBiz.EstimatorApplicantBiz.ID;
                objDr["StatusDelete"] = objBiz.StatusDelete;

                dtReturned.Rows.Add(objDr);
            }
            return dtReturned;
        }
        #endregion
    }
}
