using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.UMS.UMSBusiness;
using SharpVision.CRM.CRMDataBase;
using System.Data;
using SharpVision.Base.BaseBusiness;
using SharpVision.HR.HRBusiness;
namespace SharpVision.CRM.CRMBusiness
{
    public class WorkerContributionBiz
    {
        #region Private Data
        WorkerContributionDb _WorkerContributionDb;
        SalesManBiz _SalesManBiz;
        #endregion

        #region Constructors
        public WorkerContributionBiz()
        {
            _WorkerContributionDb = new WorkerContributionDb();
            _SalesManBiz = new SalesManBiz();
        }
        public WorkerContributionBiz(DataRow objDR)
        {
            _WorkerContributionDb = new WorkerContributionDb(objDR);
            _SalesManBiz = new SalesManBiz(objDR);
        }
        #endregion

        #region Public Properties
        public int ReservationID
        {
            set
            {
                _WorkerContributionDb.ReservationID = value;
            }
            get
            {
                return _WorkerContributionDb.ReservationID;
            }

        }
        public int WorkerID
        {
            set
            {
                _WorkerContributionDb.WorkerID = value;
            }
            get
            {
                return _WorkerContributionDb.WorkerID;
            }

        }
        public SalesManBiz SalesManBiz
        {
            set
            {
                _SalesManBiz = value;
            }
            get
            {
                return _SalesManBiz;
            }
        }
        public double ContributionPerc
        {
            set
            {
                _WorkerContributionDb.ContributionPerc = value;
            }
            get
            {
                return _WorkerContributionDb.ContributionPerc;
            }

        }
        public double ContributionValue
        {
            set
            {
                _WorkerContributionDb.ContributionValue = value;
            }
            get
            {
                return _WorkerContributionDb.ContributionValue;
            }

        }
        public double PaidValue
        {
            set
            {
                _WorkerContributionDb.PaidValue = value;
            }
            get
            {
                return _WorkerContributionDb.PaidValue;
            }

        }
        public bool Finished
        {
            set
            {
                _WorkerContributionDb.Finished = value;
            }
            get
            {
                return _WorkerContributionDb.Finished;
            }

        }
        #endregion

        #region Private Methods

        #endregion

        #region Public Methods

        #endregion
    }
}
