using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.HR.HRDataBase;
using System.Data;
using SharpVision.UMS.UMSBusiness;
namespace SharpVision.HR.HRBusiness
{
    public class ApplicantEstimationBiz
    {
        #region Private Data
        ApplicantEstimationDb _ApplicantEstimationDb;
        EmployeeBiz _ApplicantBiz;
        EmployeeBiz _EstimatorApplicantBiz;
        #endregion
        #region Constructors
        public ApplicantEstimationBiz()
        {
            _ApplicantEstimationDb = new ApplicantEstimationDb();
            _ApplicantBiz = new EmployeeBiz();
            _EstimatorApplicantBiz = new EmployeeBiz();
        }
        public ApplicantEstimationBiz(int intApplicantEstimationID, int intApplicantID, int intEstimationStatementID, int intEstimationEstimatorID)
        {
            _ApplicantEstimationDb = new ApplicantEstimationDb(intApplicantEstimationID, intApplicantID, intEstimationStatementID, intEstimationEstimatorID);
            _ApplicantBiz = new EmployeeBiz();
            _EstimatorApplicantBiz = new EmployeeBiz();
        }
        public ApplicantEstimationBiz(DataRow objDR)
        {
            _ApplicantEstimationDb = new ApplicantEstimationDb(objDR);
            if (objDR["ApplicantID"].ToString() != "")
                _ApplicantBiz = new EmployeeBiz(objDR);
            else
                _ApplicantBiz = new EmployeeBiz();

            if (_ApplicantEstimationDb.EstimationEstimator != 0)
                _EstimatorApplicantBiz = new EmployeeBiz();
            else
                _EstimatorApplicantBiz = new EmployeeBiz();



            
        }
        #endregion
        #region Public Properties
        public int ApplicantEstimationID
        {
            set { _ApplicantEstimationDb.ApplicantEstimationID = value; }
            get { return _ApplicantEstimationDb.ApplicantEstimationID; }
        }
        public int EstimationStatementID
        {
            set { _ApplicantEstimationDb.EstimationStatementID = value; }
            get { return _ApplicantEstimationDb.EstimationStatementID; }
        }
        public DateTime EstimationDate
        {
            set { _ApplicantEstimationDb.EstimationDate = value; }
            get { return _ApplicantEstimationDb.EstimationDate; }
        }
        public float EstimationValue
        {
            set { _ApplicantEstimationDb.EstimationValue = value; }
            get { return _ApplicantEstimationDb.EstimationValue; }
        }
        public bool StatusDelete
        {
            set { _ApplicantEstimationDb.StatusDelete = value; }
            get { return _ApplicantEstimationDb.StatusDelete; }
        }
        public EmployeeBiz ApplicantBiz
        {
            set { _ApplicantBiz = value; }
            get { return _ApplicantBiz; }
        }
        public EmployeeBiz EstimatorApplicantBiz
        {
            set { _EstimatorApplicantBiz = value; }
            get { return _EstimatorApplicantBiz; }
        }
        #endregion
        #region Private Methods
        #endregion
        #region Public Methods
        public void Add()
        {
            _ApplicantEstimationDb.ApplicantID = ApplicantBiz.ID;
            _ApplicantEstimationDb.EstimationEstimator = EstimatorApplicantBiz.ID;
            _ApplicantEstimationDb.Add();
        }
        public void Edit()
        {
            _ApplicantEstimationDb.ApplicantID = ApplicantBiz.ID;
            _ApplicantEstimationDb.EstimationEstimator = EstimatorApplicantBiz.ID;
            _ApplicantEstimationDb.Edit();
        }
        public void Delete()
        {
            _ApplicantEstimationDb.Delete();
        }
        #endregion
    }
}
