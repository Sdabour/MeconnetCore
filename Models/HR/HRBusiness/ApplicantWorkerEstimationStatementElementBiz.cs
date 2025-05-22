using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using SharpVision.HR.HRDataBase;
namespace SharpVision.HR.HRBusiness
{
    public enum EstimationFuzzyValueOld
    {
        NotSpecified,
        Poor,
        BelowExpectations,
        MeetExpectations,
        Exceeding,
        Excellent
    }
    public enum EstimationFuzzyValue
    {
        NotSpecified,
        Rejected,
        Poor,
        Accepted,
        Good,
        VeryGood,
        Distinctive
    }
    public class ApplicantWorkerEstimationStatementElementBiz
    {
        #region Private Data
        ApplicantWorkerEstimationStatementElementDb _ApplicantWorkerEstimationStatementElementDb;
        ElementBiz _ElementBiz;
        #endregion
        #region Constructors
        public ApplicantWorkerEstimationStatementElementBiz()
        {
            _ApplicantWorkerEstimationStatementElementDb = new ApplicantWorkerEstimationStatementElementDb();
            _ElementBiz = new ElementBiz();
        }
        public ApplicantWorkerEstimationStatementElementBiz(DataRow objDr)
        {
            _ApplicantWorkerEstimationStatementElementDb = new ApplicantWorkerEstimationStatementElementDb(objDr);
            if (_ApplicantWorkerEstimationStatementElementDb.Element != 0)
                _ElementBiz = new ElementBiz(objDr);


        }
        #endregion
        #region Public Properties
        public int ID { set { _ApplicantWorkerEstimationStatementElementDb.ID = value; } get { return _ApplicantWorkerEstimationStatementElementDb.ID; } }
        public string Desc
        { set => _ApplicantWorkerEstimationStatementElementDb.Desc = value; get { return _ApplicantWorkerEstimationStatementElementDb.Desc == null ?"" : _ApplicantWorkerEstimationStatementElementDb.Desc; } }
        public string GroupNameA
        { set => _ApplicantWorkerEstimationStatementElementDb.GroupNameA = value;
            get { return _ApplicantWorkerEstimationStatementElementDb.GroupNameA == null ? "" : _ApplicantWorkerEstimationStatementElementDb.GroupNameA; } }
        public string GroupNameE
        {
            set => _ApplicantWorkerEstimationStatementElementDb.GroupNameE = value;
            get { return _ApplicantWorkerEstimationStatementElementDb.GroupNameE == null ? "" : _ApplicantWorkerEstimationStatementElementDb.GroupNameE; }
        }
        public ElementBiz ElementBiz { set { _ElementBiz = value; } get {
                if (_ElementBiz == null)
                    _ElementBiz = new ElementBiz();
                return _ElementBiz; } }
        public double EstimationValue { set { _ApplicantWorkerEstimationStatementElementDb.EstimationValue = value; } get { return _ApplicantWorkerEstimationStatementElementDb.EstimationValue; } }
        public double Weight
        { set => _ApplicantWorkerEstimationStatementElementDb.Weight = value; get => _ApplicantWorkerEstimationStatementElementDb.Weight; }
        public int TempElement
        {
            set => _ApplicantWorkerEstimationStatementElementDb.TempElement = value;
            get => _ApplicantWorkerEstimationStatementElementDb.TempElement;
        }
        public double ElementValue { set { _ApplicantWorkerEstimationStatementElementDb.ElementValue = value; } get { return _ApplicantWorkerEstimationStatementElementDb.ElementValue; } }
        public bool IsFuzzyValue
        {
            set { _ApplicantWorkerEstimationStatementElementDb.IsFuzzyValue = value; }
            get { return _ApplicantWorkerEstimationStatementElementDb.IsFuzzyValue; }
        }
        public EstimationFuzzyValue FuzzyValue
        {
            set { _ApplicantWorkerEstimationStatementElementDb.FuzzyValue = (int)value; }
            get
            {
                if (IsFuzzyValue)
                    return (EstimationFuzzyValue)_ApplicantWorkerEstimationStatementElementDb.FuzzyValue;
                else
                {
                    double dblValue = (EstimationValue / ElementValue) * 100;
                    return (EstimationFuzzyValue)EstimationFuzzyValueBiz.GetFuzzyValue(dblValue).ID;
                }
            }
        }
        public int Group
        {
            set => _ApplicantWorkerEstimationStatementElementDb.Group = value;
            get => _ApplicantWorkerEstimationStatementElementDb.Group;
        }

        public double GroupPerc
        {
            set => _ApplicantWorkerEstimationStatementElementDb.GroupPerc = value;
            get => _ApplicantWorkerEstimationStatementElementDb.GroupPerc;
        }

        public int GroupOrder
        {
            set => _ApplicantWorkerEstimationStatementElementDb.GroupOrder = value;
            get => _ApplicantWorkerEstimationStatementElementDb.GroupOrder;
        }
        public static List<string> EstimationFuzzyValueStrArr
        {
            get
            {
                List<string> Returned = new List<string>();
                Returned.AddRange(new string[] { "NotSpecified","Rejected", "Poor",
                    "Accepted" ,"Good","VeryGood","Distinctive"});
                return Returned;
            }
        }
        #endregion
        #region Private Methods

        #endregion
        #region Public Methods
        public void Add()
        {
            _ApplicantWorkerEstimationStatementElementDb.Element = _ElementBiz.ID;
            _ApplicantWorkerEstimationStatementElementDb.Add();
        }
        public void Delete()
        {
            _ApplicantWorkerEstimationStatementElementDb.Element = _ElementBiz.ID;
            _ApplicantWorkerEstimationStatementElementDb.Delete();
        }
        #endregion
    }
}
