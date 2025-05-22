using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using SharpVision.Base.BaseDataBase;
using SharpVision.Base.BaseBusiness;
using SharpVision.HR.HRDataBase;
using SharpVision.SystemBase;

namespace SharpVision.HR.HRBusiness
{
    public class ApplicantWorkerEstimationStatementCol : CollectionBase
    {
        #region Private Data

        #endregion
        #region Constructors
        public ApplicantWorkerEstimationStatementCol(bool isEmpty)
        {            
        }
        public ApplicantWorkerEstimationStatementCol()
        {
            ApplicantWorkerEstimationStatementDb objDb = new ApplicantWorkerEstimationStatementDb();
            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
            {
                this.Add(new ApplicantWorkerEstimationStatementBiz(objDr));
            }
            FillSubSectorAndCostCenterBiz();            
        }
        public ApplicantWorkerEstimationStatementCol(ApplicantWorkerBiz objApplicantWorkerBiz)
        {
            ApplicantWorkerEstimationStatementDb objDb = new ApplicantWorkerEstimationStatementDb();
            objDb.Applicant = objApplicantWorkerBiz.ID;
            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
            {
                this.Add(new ApplicantWorkerEstimationStatementBiz(objDr));
            }
            FillSubSectorAndCostCenterBiz();            
        }
        public ApplicantWorkerEstimationStatementCol(EstimationStatementBiz objEstimationStatementBiz)
        {
            ApplicantWorkerEstimationStatementDb objDb = new ApplicantWorkerEstimationStatementDb();
            objDb.EstimationStatement = objEstimationStatementBiz.ID;
            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
            {
                this.Add(new ApplicantWorkerEstimationStatementBiz(objDr));
            }
            FillSubSectorAndCostCenterBiz();           
        }
        public ApplicantWorkerEstimationStatementCol(EstimationStatementBiz objEstimationStatementBiz,ApplicantWorkerBiz objApplicantWorkerBiz)
        {
            ApplicantWorkerEstimationStatementDb objDb = new ApplicantWorkerEstimationStatementDb();
            objDb.EstimationStatement = objEstimationStatementBiz.ID;
            objDb.Applicant = objApplicantWorkerBiz.ID;
            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
            {
                this.Add(new ApplicantWorkerEstimationStatementBiz(objDr));
            }
            FillSubSectorAndCostCenterBiz();            
        }
        public ApplicantWorkerEstimationStatementCol(EstimationStatementCol objEstimationStatementCol, ApplicantWorkerBiz objApplicantWorkerBiz)
        {
            ApplicantWorkerEstimationStatementDb objDb = new ApplicantWorkerEstimationStatementDb();
            objDb.EstimationStatementIDs = objEstimationStatementCol.IDsStr;
            objDb.Applicant = objApplicantWorkerBiz.ID;
            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
            {
                this.Add(new ApplicantWorkerEstimationStatementBiz(objDr));
            }
            FillSubSectorAndCostCenterBiz();            
        }
        public ApplicantWorkerEstimationStatementCol(EstimationStatementCol objEstimationStatementCol, ApplicantWorkerCol objApplicantWorkerCol)
        {
            ApplicantWorkerEstimationStatementDb objDb = new ApplicantWorkerEstimationStatementDb();
            objDb.EstimationStatementIDs = objEstimationStatementCol.IDsStr;
            objDb.ApplicantIDs = objApplicantWorkerCol.IDs;
            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
            {
                this.Add(new ApplicantWorkerEstimationStatementBiz(objDr));
            }
            FillSubSectorAndCostCenterBiz();            
        }

      
        #region OldConstructor
        //public ApplicantWorkerEstimationStatementCol(EstimationStatementBiz objEstimationStatementBiz, ApplicantWorkerCol objApplicantWorkerCol)
        //{
        //    ApplicantWorkerEstimationStatementDb objDb = new ApplicantWorkerEstimationStatementDb();
        //    objDb.EstimationStatement = objEstimationStatementBiz.ID;
        //    objDb.ApplicantIDs = objApplicantWorkerCol.IDs;

        //    DataTable dtTemp = objDb.Search();
        //    ApplicantWorkerEstimationStatementBiz objBiz;

        //    Hashtable hsEstimation = new Hashtable() ;
        //    foreach (DataRow objDr in dtTemp.Rows)
        //    {
        //        objBiz = new ApplicantWorkerEstimationStatementBiz(objDr);
        //        if (objBiz.ID != 0 && hsEstimation[objBiz.ApplicantWorkerBiz.ID.ToString()] == null)
        //            hsEstimation.Add(objBiz.ApplicantWorkerBiz.ID.ToString(), objBiz);

        //    }

        //    JobCategoryEstimationCol objCategoryCol = objApplicantWorkerCol.JobCategoryEstimationCol;
        //    objCategoryCol.SetEstimationElementCol();
        //    foreach (ApplicantWorkerBiz objWorkerBiz in objApplicantWorkerCol)
        //    {
        //        objBiz = new ApplicantWorkerEstimationStatementBiz();
        //        if (hsEstimation[objWorkerBiz.ID.ToString()] != null)
        //        {
        //            objBiz = (ApplicantWorkerEstimationStatementBiz)hsEstimation[objWorkerBiz.ID.ToString()];
        //            objBiz.ApplicantWorkerBiz = objWorkerBiz;
        //            Add(objBiz);
        //        }
        //        else
        //        {
        //            objBiz.ApplicantWorkerBiz = objWorkerBiz;
        //            objBiz.EstimationStatementBiz = objEstimationStatementBiz;
        //            objBiz.SubSectorBiz = objWorkerBiz.CurrentSubSectorBiz.SubSectorBiz;
        //            objBiz.JobNatureTypeBiz = objWorkerBiz.VirualJobNatureTypeBiz;
        //            objBiz.JobCategoryEstimationBiz = objWorkerBiz.JobCategoryEstimationBiz;
        //            objBiz.EstimationStatementElementCol = new ApplicantWorkerEstimationStatementElementCol(true);
        //            if (objEstimationStatementBiz.IsGlobal || objEstimationStatementBiz.IsMixed)
        //            {
        //                objBiz.EstimationStatementElementCol.Add( objEstimationStatementBiz.GroupElementCol.ElementCol);
        //            }
        //            if (!objEstimationStatementBiz.IsGlobal || objEstimationStatementBiz.IsMixed)
        //            {
        //                objBiz.EstimationStatementElementCol.Add(objBiz.JobCategoryEstimationBiz.JobCategoryEstimationElementCol.ApplicantEstimationStatementElementCol);
        //            }
        //            Add(objBiz);
        //        }
        //    }
        //    FillSubSectorAndCostCenterBiz();
        //}
        #endregion
        public ApplicantWorkerEstimationStatementCol(EstimationStatementCol objEstimationStatementCol, ApplicantWorkerCol objApplicantWorkerCol,
            byte byOperationStatus, double dlValueFrom, double dlValueTo, SectorCol objSectorCol, byte bySectorOnly, byte byWorkUpToNowInSector)
        {
            ApplicantWorkerEstimationStatementDb objDb = new ApplicantWorkerEstimationStatementDb();
            objDb.EstimationStatementIDs = objEstimationStatementCol.IDsStr;
            objDb.ApplicantIDs = objApplicantWorkerCol.IDs;
            objDb.OperationStatus = byOperationStatus;
            objDb.EstimationValueFrom = dlValueFrom;
            objDb.EstimationValueTo = dlValueTo;
            string strSectorIDs = "";
            if (objSectorCol != null && objSectorCol.Count != 0)
                strSectorIDs = objSectorCol.IDsStr;
            if (bySectorOnly == 1)
                objDb.SectorOnlyIDs = strSectorIDs;

            if (byWorkUpToNowInSector == 1)
                objDb.WorkUpToNowSectorIDs = strSectorIDs;

            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
            {
                this.Add(new ApplicantWorkerEstimationStatementBiz(objDr));
            }
            FillSubSectorAndCostCenterBiz();
            FillLastSubSectorAndCenter(objEstimationStatementCol.IDsStr, objApplicantWorkerCol.IDs, strSectorIDs);
        }
        #endregion
        #region Public Properties

        #endregion
        #region Private Methods

        #endregion
        #region Public Methods
        public virtual ApplicantWorkerEstimationStatementBiz this[int intIndex]
        {
            get
            {
                return (ApplicantWorkerEstimationStatementBiz)this.List[intIndex];
            }
        }

        public virtual void Add(ApplicantWorkerEstimationStatementBiz objBiz)
        {
            this.List.Add(objBiz);
        }
        public string SubSectorIDs
        {
            get
            {
                string str = "";
                foreach (ApplicantWorkerEstimationStatementBiz objBiz in this)
                {
                    if (str != "")
                        str += "," + objBiz.SubSector.ToString();
                    else
                        str = objBiz.SubSector.ToString();
                }
                return str;
            }
        }
        public string CostCenterIDs
        {
            get
            {
                string str = "";
                foreach (ApplicantWorkerEstimationStatementBiz objBiz in this)
                {
                    if (str != "")
                        str += "," + objBiz.CostCenter.ToString();
                    else
                        str = objBiz.CostCenter.ToString();
                }
                return str;
            }
        }
        void FillSubSectorAndCostCenterBiz()
        {
            SubSectorCol objSubsectorCol = new SubSectorCol(SubSectorIDs);
            CostCenterHRCol objCostCenterCol = new CostCenterHRCol(CostCenterIDs);
            //string s = objSubsectorCol
            foreach (ApplicantWorkerEstimationStatementBiz objBiz in this)
            {
                if (objBiz.SubSector != 0)
                {
                    objBiz.SubSectorBiz = (SubSectorBranchBiz)objSubsectorCol[objSubsectorCol.GetIndex(objBiz.SubSector)];

                
                }
                if (objBiz.CostCenter != 0)
                {
                    objBiz.CostCenterHRBiz = objCostCenterCol[objCostCenterCol.GetIndex(objBiz.CostCenter)];
                    
                }
            }
        }
        void FillLastSubSectorAndCenter(string strEstimationStatement, string strApplicantIDs,string strSectorIDs)
        {
            ApplicantWorkerEstimationStatementDb objDb = new ApplicantWorkerEstimationStatementDb();
            objDb.SectorOnlyIDs = strSectorIDs;
            DataTable dtTemp = objDb.GetSubSectorAndCostcenter(strEstimationStatement,strApplicantIDs);
            string _SubSectorIDs = "";
            string _CostCenterIDs = "";
            string _JobNatureIDs = "";
            string _JobCategoryEstimationIDs = "";
            foreach (DataRow objDr in dtTemp.Rows)
            {
                if (_SubSectorIDs != "")
                    _SubSectorIDs += "," + objDr["SubSector"].ToString();
                else
                    _SubSectorIDs = objDr["SubSector"].ToString();

                if (_CostCenterIDs != "")
                    _CostCenterIDs += "," + objDr["CostCenter"].ToString();
                else
                    _CostCenterIDs = objDr["CostCenter"].ToString();

                if (_JobNatureIDs != "")
                    _JobNatureIDs += "," + objDr["JobNature"].ToString();
                else
                    _JobNatureIDs = objDr["JobNature"].ToString();
                if (objDr["JobCategoryEstimation"].ToString() != "")
                    if (_JobCategoryEstimationIDs != "")
                        _JobCategoryEstimationIDs += "," + objDr["JobCategoryEstimation"].ToString();
                    else
                        _JobCategoryEstimationIDs = objDr["JobCategoryEstimation"].ToString();
            }
            SubSectorCol objSubsectorCol = new SubSectorCol(_SubSectorIDs);
            CostCenterHRCol objCostCenterCol = new CostCenterHRCol(_CostCenterIDs);

            JobNatureTypeCol objJobNatureTypeCol = new JobNatureTypeCol(_JobNatureIDs,true);
            JobCategoryEstimationCol objJobCategoryEstimationCol = new JobCategoryEstimationCol(_JobCategoryEstimationIDs);
            string strTemp = "";
            foreach (ApplicantWorkerEstimationStatementBiz objBiz in this)
            {
                DataRow[] arrDR = dtTemp.Select("Applicant=" + objBiz.ApplicantWorkerBiz.ID + "", "");
                if (arrDR.Length == 0)
                    continue;
                strTemp = arrDR[0]["JobNature"].ToString();
                objBiz.ApplicantWorkerBiz.VirualJobNatureTypeBiz = objJobNatureTypeCol[objJobNatureTypeCol.GetIndex(int.Parse(arrDR[0]["JobNature"].ToString()))];
                objBiz.ApplicantWorkerBiz.VirualSubSectorBiz = (SubSectorBranchBiz)objSubsectorCol[objSubsectorCol.GetIndex(int.Parse(arrDR[0]["SubSector"].ToString()))]; ;
                if (arrDR[0]["JobCategoryEstimation"].ToString() != "")
                    objBiz.ApplicantWorkerBiz.VirualJobCategoryEstimationBiz = objJobCategoryEstimationCol[objJobCategoryEstimationCol.GetIndex(int.Parse(arrDR[0]["JobCategoryEstimation"].ToString()))];
                else
                    objBiz.ApplicantWorkerBiz.VirualJobCategoryEstimationBiz = new JobCategoryEstimationBiz();
                objBiz.ApplicantWorkerBiz.VirualCostCenterBiz = objCostCenterCol[objCostCenterCol.GetIndex(int.Parse(arrDR[0]["CostCenter"].ToString()))];
            }



        }
        ApplicantWorkerCol _ApplicantWorkerCol;
        public ApplicantWorkerCol ApplicantWorkerCol
        {
            get
            {
                if (_ApplicantWorkerCol == null)
                {
                    _ApplicantWorkerCol = new ApplicantWorkerCol(true);
                    foreach (ApplicantWorkerEstimationStatementBiz objBiz in this)
                    {
                        _ApplicantWorkerCol.Add(objBiz.ApplicantWorkerBiz);
                    }
                    _ApplicantWorkerCol = _ApplicantWorkerCol.GetApplicantWorkerOrderByVirtualJob();
                }
                return _ApplicantWorkerCol;
            }
        }
        public ApplicantWorkerEstimationStatementCol GetOrderApplicantWorkerEstimationStatementCol()
        {
            ApplicantWorkerEstimationStatementCol objCol = new ApplicantWorkerEstimationStatementCol(true);
            foreach (ApplicantWorkerBiz objApplicantBiz in ApplicantWorkerCol)
            {
                foreach (ApplicantWorkerEstimationStatementBiz objStatementBiz in this)
                {
                    if (objApplicantBiz.ID == objStatementBiz.ApplicantWorkerBiz.ID)
                        objCol.Add(objStatementBiz);
                }
            }
            return objCol;
        }
        #endregion
    }
}
