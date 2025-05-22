using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using SharpVision.HR.HRDataBase;
using System.Linq;
namespace SharpVision.HR.HRBusiness
{
    public class ApplicantWorkerEstimationStatementBiz
    {
        #region Private Data
        ApplicantWorkerEstimationStatementDb _ApplicantWorkerEstimationStatementDb;
        ApplicantWorkerBiz _ApplicantWorkerBiz;
        EstimationStatementBiz _EstimationStatementBiz;
        ApplicantWorkerEstimationStatementElementCol _EstimationStatementElementCol;
        JobNatureTypeBiz _JobNatureTypeBiz;
        JobCategoryEstimationBiz _JobCategoryEstimationBiz;
        SubSectorBiz _SubSectorBiz;
        CostCenterHRBiz _CostCenterHRBiz;
        // ApplicantWorkerAttendanceStatementBiz _ApplicantWorkerAttendanceStatementBiz;
        #endregion
        #region Constructors
        public ApplicantWorkerEstimationStatementBiz()
        {
            _ApplicantWorkerEstimationStatementDb = new ApplicantWorkerEstimationStatementDb();
            _ApplicantWorkerBiz = new ApplicantWorkerBiz();
            _EstimationStatementBiz = new EstimationStatementBiz();
            _JobNatureTypeBiz = new JobNatureTypeBiz();
            _JobCategoryEstimationBiz = new JobCategoryEstimationBiz();

        }
        public ApplicantWorkerEstimationStatementBiz(DataRow objDr)
        {
            _ApplicantWorkerEstimationStatementDb = new ApplicantWorkerEstimationStatementDb(objDr);
            _ApplicantWorkerBiz = new ApplicantWorkerBiz(objDr);
            _EstimationStatementBiz = new EstimationStatementBiz(objDr);
            _JobNatureTypeBiz = new JobNatureTypeBiz(objDr);
            _JobCategoryEstimationBiz = new JobCategoryEstimationBiz(objDr);
        }
        public ApplicantWorkerEstimationStatementBiz(EstimationStatementBiz objEstimationStatementBiz, ApplicantWorkerBiz objApplicantWorkerBiz)
        {
            _ApplicantWorkerBiz = objApplicantWorkerBiz;
            _EstimationStatementBiz = objEstimationStatementBiz;
            _ApplicantWorkerEstimationStatementDb = new ApplicantWorkerEstimationStatementDb(_EstimationStatementBiz.ID, _ApplicantWorkerBiz.ID);
            _JobNatureTypeBiz = JobNatureTypeCol.GetJobNatureTypeBiz(_ApplicantWorkerEstimationStatementDb.JobNature);
            _JobCategoryEstimationBiz = JobCategoryEstimationCol.GetJobCategoryEstimationBiz(_ApplicantWorkerEstimationStatementDb.JobCategoryEstimation);
        }
        #endregion
        #region Public Properties
        public int ID
        {
            set { _ApplicantWorkerEstimationStatementDb.ID = value; }
            get { return _ApplicantWorkerEstimationStatementDb.ID; }
        }
        public ApplicantWorkerBiz ApplicantWorkerBiz
        {
            set { _ApplicantWorkerBiz = value; }
            get { return _ApplicantWorkerBiz; }
        }
        public EstimationStatementBiz EstimationStatementBiz
        {
            set { _EstimationStatementBiz = value; }
            get { return _EstimationStatementBiz; }
        }
        public bool EstimationStatementIsSum
        {
            set { _ApplicantWorkerEstimationStatementDb.EstimationStatementIsSum = value; }
            get { return _ApplicantWorkerEstimationStatementDb.EstimationStatementIsSum; }
        }
        public double EstimationValue
        {
            set { _ApplicantWorkerEstimationStatementDb.EstimationValue = value; }
            get { return _ApplicantWorkerEstimationStatementDb.EstimationValue; }
        }
        public double EstimationValuePrec
        {
            set { _ApplicantWorkerEstimationStatementDb.EstimationValuePrec = value; }
            get { return _ApplicantWorkerEstimationStatementDb.EstimationValuePrec; }
        }
        public int SubSector
        {
            set { _ApplicantWorkerEstimationStatementDb.SubSector = value; }
            get { return _ApplicantWorkerEstimationStatementDb.SubSector; }
        }
        public int CostCenter
        {
            set { _ApplicantWorkerEstimationStatementDb.CostCenter = value; }
            get { return _ApplicantWorkerEstimationStatementDb.CostCenter; }
        }
        public string Remarks
        {
            set { _ApplicantWorkerEstimationStatementDb.Remarks = value; }
            get { return _ApplicantWorkerEstimationStatementDb.Remarks; }
        }
        public string Remarks1
        {
            set { _ApplicantWorkerEstimationStatementDb.Remarks1 = value; }
            get { return _ApplicantWorkerEstimationStatementDb.Remarks1; }
        }
        public string Remarks2
        {
            set { _ApplicantWorkerEstimationStatementDb.Remarks2 = value; }
            get { return _ApplicantWorkerEstimationStatementDb.Remarks2; }
        }
        public string Remarks3
        {
            set { _ApplicantWorkerEstimationStatementDb.Remarks3 = value; }
            get { return _ApplicantWorkerEstimationStatementDb.Remarks3; }
        }
        public string Remarks4
        {
            set { _ApplicantWorkerEstimationStatementDb.Remarks4 = value; }
            get { return _ApplicantWorkerEstimationStatementDb.Remarks4; }
        }
        public string Remarks5
        {
            set { _ApplicantWorkerEstimationStatementDb.Remarks5 = value; }
            get { return _ApplicantWorkerEstimationStatementDb.Remarks5; }
        }
    //Old EstimationStatementElementCol
        public ApplicantWorkerEstimationStatementElementCol EstimationStatementElementCol1
        {
            set
            {
                _EstimationStatementElementCol = value;
            }
            get
            {
                if (_EstimationStatementElementCol == null)
                {
                    _EstimationStatementElementCol = new ApplicantWorkerEstimationStatementElementCol(this);
                    ApplicantWorkerEstimationStatementElementBiz objElementBiz;
                    if (ID == 0 && ApplicantWorkerBiz.ID > 0 && (
                     _EstimationStatementBiz.IsMixed ||   !_EstimationStatementBiz.IsGlobal  || _EstimationStatementBiz.GroupElementCol.Count == 0))
                    {


                        foreach (JobCategoryEstimationElementBiz objBiz in ApplicantWorkerBiz.VirualJobCategoryEstimationBiz.JobCategoryEstimationElementCol)
                        {
                            objElementBiz = new ApplicantWorkerEstimationStatementElementBiz() { ElementBiz = objBiz.ElementBiz, EstimationValue = 0, ElementValue = objBiz.ElementBiz.ElementValue };
                            _EstimationStatementElementCol.Add(objElementBiz);

                        }
                    }
                    else if (ID == 0 && ApplicantWorkerBiz.ID > 0 && (
                        (_EstimationStatementBiz.IsGlobal || _EstimationStatementBiz.IsMixed) && _EstimationStatementBiz.GroupElementCol.Count > 0))

                    {
                        _EstimationStatementElementCol = _EstimationStatementBiz.GroupElementCol.ElementCol;

                    }
                }
                return _EstimationStatementElementCol;
            }
        }
        public JobNatureTypeBiz JobNatureTypeBiz
        {
            set
            {
                _JobNatureTypeBiz = value;
            }
            get
            {
                return _JobNatureTypeBiz;
            }
        }
        public JobCategoryEstimationBiz JobCategoryEstimationBiz
        {
            set
            {
                _JobCategoryEstimationBiz = value;
            }
            get
            {
                return _JobCategoryEstimationBiz;
            }
        }
        public SubSectorBiz SubSectorBiz
        {
            set
            {
                _SubSectorBiz = value;
            }
            get
            {
                if (_SubSectorBiz == null)
                    _SubSectorBiz = new SubSectorBranchBiz();

                return _SubSectorBiz;
            }
        }
        public CostCenterHRBiz CostCenterHRBiz
        {
            set
            {
                _CostCenterHRBiz = value;
            }
            get
            {
                if (_CostCenterHRBiz == null)
                    _CostCenterHRBiz = new CostCenterHRBiz();
               
                return _CostCenterHRBiz;
            }
        }
        ApplicantWorkerAttendanceStatementCol _AttendanceStatementCol;
        public ApplicantWorkerAttendanceStatementCol AttendanceStatementCol
        {
            get
            {
                if (_AttendanceStatementCol == null)
                {
                    _AttendanceStatementCol = new ApplicantWorkerAttendanceStatementCol(true);
                    if (EstimationStatementBiz.ID != 0)
                    {
                        ApplicantWorkerEstimationStatementDb objDb = new ApplicantWorkerEstimationStatementDb() {  Applicant=ApplicantWorkerBiz.ID,EstimationStatement=EstimationStatementBiz.ID};
                        DataTable dtTemp = objDb.GetAttendanceStatementTable();
                        foreach (DataRow objDr in dtTemp.Rows)
                        {
                            _AttendanceStatementCol.Add(new ApplicantWorkerAttendanceStatementBiz(objDr));

                        }
                        
                    }

                }
                return _AttendanceStatementCol;
            }
        }
        public static int UMSApplicantEstimation { get => 553; }
        public static bool UMSApplicantEstimationAuthorized { get => SharpVision.SystemBase.SysData.CurrentUser.UserFunctionInstantCol.GetIndex(UMSApplicantEstimation) >= 0; }
        #endregion
        #region Private Methods

        #endregion
        #region Public Methods
        public void Add()
        {
            _ApplicantWorkerEstimationStatementDb.Applicant = _ApplicantWorkerBiz.ID;
            _ApplicantWorkerEstimationStatementDb.EstimationStatement = _EstimationStatementBiz.ID;
            _ApplicantWorkerEstimationStatementDb.JobNature = _JobNatureTypeBiz.ID;
            _ApplicantWorkerEstimationStatementDb.JobCategoryEstimation = _JobCategoryEstimationBiz.ID;
            if (_SubSectorBiz != null)
                _ApplicantWorkerEstimationStatementDb.SubSector = _SubSectorBiz.ID;
            else
                _ApplicantWorkerEstimationStatementDb.SubSector = 0;

            if (_CostCenterHRBiz != null)
                _ApplicantWorkerEstimationStatementDb.CostCenter = _CostCenterHRBiz.ID;
            else
                _ApplicantWorkerEstimationStatementDb.CostCenter = 0;
            AdjustGroupWeight();
          //  _ApplicantWorkerEstimationStatementDb.ElementTable = EstimationStatementElementCol.GetTable();
            _ApplicantWorkerEstimationStatementDb.Add();
            _ApplicantWorkerEstimationStatementDb.JoinElementCol();

            //SaveEstimationElement();
        }
        public void Edit()
        {
            _ApplicantWorkerEstimationStatementDb.Applicant = _ApplicantWorkerBiz.ID;
            _ApplicantWorkerEstimationStatementDb.EstimationStatement = _EstimationStatementBiz.ID;
            _ApplicantWorkerEstimationStatementDb.JobNature = _JobNatureTypeBiz.ID;
            _ApplicantWorkerEstimationStatementDb.JobCategoryEstimation = _JobCategoryEstimationBiz.ID;
            if (_SubSectorBiz != null)
                _ApplicantWorkerEstimationStatementDb.SubSector = _SubSectorBiz.ID;
            else
                _ApplicantWorkerEstimationStatementDb.SubSector = 0;

            if (_CostCenterHRBiz != null)
                _ApplicantWorkerEstimationStatementDb.CostCenter = _CostCenterHRBiz.ID;
            else
                _ApplicantWorkerEstimationStatementDb.CostCenter = 0;
            AdjustGroupWeight();
           //_ApplicantWorkerEstimationStatementDb.ElementTable = EstimationStatementElementCol.GetTable();
            _ApplicantWorkerEstimationStatementDb.Edit();
            //SaveEstimationElement();
            _ApplicantWorkerEstimationStatementDb.JoinElementCol();
        }
       
        public void AdjustGroupWeight()
        {
            //var vrGroupCol = from objElement in EstimationStatementElementCol.Cast<ApplicantWorkerEstimationStatementElementBiz>()
            //                 where objElement.ElementBiz.ID != 0
            //                 group objElement by new { objElement.Group, objElement.GroupOrder, objElement.GroupPerc }
            //              into objGroup
            //                 select objGroup;
            //double dblGroupValue = vrGroupCol.Sum(x => x.Key.GroupPerc);
            //double dblGroupDiff = dblGroupValue-100;
            //double dblTotalElmentWeight = 0;
            //double dblElementWeightDiff = 0;
            ////if (dblGroupValue != 100)
            //{
            //    foreach (var vrGroup in vrGroupCol)
            //    {
            //        dblTotalElmentWeight = vrGroup.Sum(x => x.Weight);
            //        dblElementWeightDiff = 100 - dblTotalElmentWeight;
            //        foreach (var vrElement in vrGroup)
            //        {
            //            vrElement.GroupPerc = vrGroup.Key.GroupPerc - (dblGroupDiff / vrGroupCol.Count());
            //            vrElement.Weight += dblElementWeightDiff / vrGroup.Count();
            //        }

                   

            //    }

            //}
        


        }
        public void Delete()
        {
            _ApplicantWorkerEstimationStatementDb.Applicant = _ApplicantWorkerBiz.ID;
            _ApplicantWorkerEstimationStatementDb.EstimationStatement = _EstimationStatementBiz.ID;
            _ApplicantWorkerEstimationStatementDb.Delete();
            RemoveEstimationElement();
        }
        
        void RemoveEstimationElement()
        {
            ApplicantWorkerEstimationStatementElementDb objDb = new ApplicantWorkerEstimationStatementElementDb();
            objDb.ID = this.ID;
            objDb.Delete();
        }
        #endregion
    }
}
