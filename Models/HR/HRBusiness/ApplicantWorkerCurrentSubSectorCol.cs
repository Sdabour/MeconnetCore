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
    public class ApplicantWorkerCurrentSubSectorCol : CollectionBase
    {
        #region Private Data

        #endregion
        #region Constructors
        public ApplicantWorkerCurrentSubSectorCol(bool IsEmpty)
        { 
        }
        public ApplicantWorkerCurrentSubSectorCol()
        {
            ApplicantWorkerCurrentSubSectorDb _ApplicantWorkerCurrentSubSectorDb = new ApplicantWorkerCurrentSubSectorDb();
            DataTable dtApplicantWorkerCurrentSubSector = _ApplicantWorkerCurrentSubSectorDb.Search();
            ApplicantWorkerCurrentSubSectorBiz objApplicantWorkerCurrentSubSectorBiz;

            foreach (DataRow DR in dtApplicantWorkerCurrentSubSector.Rows)
            {
                objApplicantWorkerCurrentSubSectorBiz = new ApplicantWorkerCurrentSubSectorBiz(DR);
                this.Add(objApplicantWorkerCurrentSubSectorBiz);
            }

        }
        #endregion
        #region Public Properties

        #endregion
        #region Private Methods
        public virtual ApplicantWorkerCurrentSubSectorBiz this[int intIndex]
        {
            get
            {
                if (intIndex >= Count)
                {
                    return new ApplicantWorkerCurrentSubSectorBiz();

                }
                return (ApplicantWorkerCurrentSubSectorBiz)this.List[intIndex];
            }
        }

        public virtual void Add(ApplicantWorkerCurrentSubSectorBiz objApplicantWorkerCurrentSubSectorBiz)
        {

            this.List.Add(objApplicantWorkerCurrentSubSectorBiz);
        }
        internal DataTable GetTable()
        {
            DataTable dtReturned = new DataTable("HRApplicantWorkerCurrentSubSector");
            dtReturned.Columns.AddRange(new DataColumn[] { new DataColumn("ApplicantWorkerID"), new DataColumn("SubSectorID"),new DataColumn("SubOrdinationID"),new DataColumn("JobID"), new DataColumn("Description"),new DataColumn("StatusFromDate"), new DataColumn("FromDate") 
            ,new DataColumn("StatusToDate"),new DataColumn("ToDate"),new DataColumn("JobTitleID"),new DataColumn("JobNatureID"),new DataColumn("JobCategoryEstimation")});
            DataRow objDr;
            foreach (ApplicantWorkerCurrentSubSectorBiz objBiz in this)
            {
                objDr = dtReturned.NewRow();
                objDr["ApplicantWorkerID"] = objBiz.ApplicantWorkerID;
                objDr["SubSectorID"] = objBiz.SubSectorBiz.ID;
                objDr["JobID"] = objBiz.JobTypeBiz.ID;
                objDr["JobTitleID"] = objBiz.JobTitleTypeBiz.ID;
                objDr["JobNatureID"] = objBiz.JobNatureTypeBiz.ID;
                objDr["SubOrdinationID"] = objBiz.SubOrdinationID;
                objDr["Description"] = objBiz.Description;
                objDr["StatusFromDate"] = objBiz.StatusFromDate;
                objDr["StatusToDate"] = objBiz.StatusToDate;
                objDr["FromDate"] = objBiz.FromDate;
                objDr["ToDate"] = objBiz.ToDate;
                objDr["JobCategoryEstimation"] = objBiz.JobCategoryEstimationBiz.ID;
                
                dtReturned.Rows.Add(objDr);
            }
            return dtReturned;

        }
        #endregion
        #region Public Methods
        public bool Contains(SectorBiz objSectorBiz, JobNatureTypeBiz objJobBiz)
        {
            foreach (ApplicantWorkerCurrentSubSectorBiz objBiz in this)
            {
                if (objBiz.SubSectorBiz.SectorBiz.ID == objSectorBiz.ID && objBiz.JobNatureTypeBiz.ID == objJobBiz.ID)
                {
                    return true;
                }
            }
            return false;
        }
        #endregion
    }
}
