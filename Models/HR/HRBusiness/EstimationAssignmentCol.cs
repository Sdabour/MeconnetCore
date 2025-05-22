using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Collections;
using SharpVision.HR.HRDataBase;
using SharpVision.SystemBase;
namespace SharpVision.HR.HRBusiness
{
    public class EstimationAssignmentCol : CollectionBase
    {

        #region Constructor
        public EstimationAssignmentCol()
        {

        }
        public EstimationAssignmentCol(bool blIsEmbty)
        {
            if (blIsEmbty)
                return;
            EstimationAssignmentBiz objBiz = new EstimationAssignmentBiz();


            EstimationAssignmentDb objDb = new EstimationAssignmentDb();

            DataTable dtTemp = objDb.Search();


            foreach (DataRow objDR in dtTemp.Rows)
            {
                objBiz = new EstimationAssignmentBiz(objDR);
                Add(objBiz);
            }
        }

        #endregion
        #region Private Data

        #endregion
        #region Properties
        public EstimationAssignmentBiz this[int intIndex]
        {
            get
            {
                return (EstimationAssignmentBiz)this.List[intIndex];
            }
        }
        public string IDsStr
        {
            get
            {
                string Returned = "";
                foreach (EstimationAssignmentBiz objBiz in this)
                {
                    if (Returned != "")
                        Returned += ",";
                    Returned += objBiz.ID;
                }
                return Returned;
            }
        }
     
        #endregion
        #region Private Method

        #endregion
        #region Public Method 
        public void Add(EstimationAssignmentBiz objBiz)
        {
            List.Add(objBiz);
        }
        public EstimationAssignmentCol GetCol(string strTemp)
        {
            EstimationAssignmentCol Returned = new EstimationAssignmentCol(true);
            foreach (EstimationAssignmentBiz objBiz in this)
            {
                if (objBiz.Desc.CheckStr(strTemp))
                    Returned.Add(objBiz);
            }
            return Returned;
        }
        public EstimationAssignmentCol GetCol(ApplicantWorkerBiz objApplicant)
        {
            EstimationAssignmentCol Returned = new EstimationAssignmentCol(true);
            DataTable dtTemp = GetTable();
            List<EstimationAssignmentBiz> objCol = (from objBiz in this.Cast<EstimationAssignmentBiz>()
                                                   where (
                                                   (objBiz.JobCategoryEstimationBiz.ID == 0 || objBiz.JobCategoryEstimationBiz.ID == objApplicant.JobCategoryEstimationBiz.ID)&&
                                                     (objBiz.JobNatureTypeCol.Count == 0 || objBiz.JobNatureTypeCol.GetIndex(objApplicant.CurrentSubSectorBiz.JobNatureTypeBiz.ID) != -1)
                                                   &&
                                                   (objBiz.SectorBiz.ID == 0 || objApplicant.CurrentSubSectorBiz.SubSectorBiz.SectorBiz.CheckSectorParentBiz(new SectorBiz() { ID = objBiz.SectorBiz.ID,NameA=objBiz.SectorBiz.Name }))
                                                   )
                                                   
                                                   orderby objBiz.Order ascending,objBiz.SectorBiz.Level descending
                                                   select objBiz).ToList();
            foreach (EstimationAssignmentBiz objAssignment in objCol)
                Returned.Add(objAssignment);


            return Returned;
        }

        public DataTable GetTable()
        {
            DataTable Returned = new DataTable();
            Returned.Columns.AddRange(new DataColumn[] { new DataColumn("AssignmentID"), new DataColumn("AssignmentDate", System.Type.GetType("System.DateTime")), new DataColumn("AssignmentDesc"), new DataColumn("AssignmentEstimationStatement"), new DataColumn("AssignmentJob"), new DataColumn("AssignmentSector"), new DataColumn("AssignmentEstimationJobCategory"), new DataColumn("AssignmentEstimationApplicant"), new DataColumn("EstimationStatementID"), new DataColumn("EstimationStatementDate", System.Type.GetType("System.DateTime")), new DataColumn("EstimationStatementDesc"), new DataColumn("JobCategoryEstimationID"), new DataColumn("JobCategoryEstimationNameA"), new DataColumn("JobCategoryEstimationNameE"), new DataColumn("JobCategoryID"), new DataColumn("JobCategoryNameA"), new DataColumn("JobCategoryNameE"), new DataColumn("SectorID"), new DataColumn("SectorNameA") });
            DataRow objDr;
            foreach (EstimationAssignmentBiz objBiz in this)
            {
                objDr = Returned.NewRow();
                objDr["AssignmentID"] = objBiz.ID;
                objDr["AssignmentDate"] = objBiz.Date;
                objDr["AssignmentDesc"] = objBiz.Desc;
                objDr["AssignmentEstimationStatement"] = objBiz.EstimationStatement;
                objDr["AssignmentJob"] = objBiz.Job;
                objDr["AssignmentSector"] = objBiz.Sector;
                objDr["AssignmentEstimationJobCategory"] = objBiz.EstimationJobCategory;
                objDr["AssignmentEstimationApplicant"] = objBiz.EstimationApplicant;
                objDr["EstimationStatementID"] = objBiz.EstimationStatementBiz.ID;
                objDr["EstimationStatementDate"] = objBiz.EstimationStatementBiz.EstimationStatementDate;
                objDr["EstimationStatementDesc"] = objBiz.EstimationStatementBiz.EstimationStatementDesc;
                objDr["JobCategoryEstimationID"] = objBiz.JobCategoryEstimationBiz.ID;
                objDr["JobCategoryEstimationNameA"] = objBiz.JobCategoryEstimationBiz.NameA;
                objDr["JobCategoryEstimationNameE"] = objBiz.JobCategoryEstimationBiz.NameE;
                objDr["JobCategoryID"] = objBiz.JobCategoryBiz.ID;
                objDr["JobCategoryNameA"] = objBiz.JobCategoryBiz.NameA;
                objDr["JobCategoryNameE"] = objBiz.JobCategoryBiz.NameE;
                objDr["SectorID"] = objBiz.SectorBiz.ID;
                objDr["SectorNameA"] = objBiz.SectorBiz.Name;
                Returned.Rows.Add(objDr);
            }
            return Returned;
        }
        public void SetData()
        {
            EstimationAssignmentElementDb objDb = new EstimationAssignmentElementDb();
            objDb.AssignmentIDs = IDsStr;
            DataTable dtElement = objDb.Search();
            EstimationAssignmentDb objAssignmentDb = new EstimationAssignmentDb() { IDsStr = IDsStr };
            DataTable dtJobNatureType = objAssignmentDb.GetJobNature();
            EstimationAssignmentGroupDb objGroupDb = new EstimationAssignmentGroupDb() { AssignmentIDs = IDsStr };
            DataTable dtGroup = objGroupDb.Search();

           
            DataRow[] arrDr;
            foreach (EstimationAssignmentBiz objBiz in this)
            {
                arrDr = dtElement.Select("AssignmentID=" + objBiz.ID.ToString(), "AssignmentElementOrder");
                objBiz.ElementCol = new EstimationAssignmentElementCol(true);
                foreach (DataRow objDr in arrDr)
                    objBiz.ElementCol.Add(new EstimationAssignmentElementBiz(objDr));
                arrDr = dtGroup.Select("AssignmentID=" + objBiz.ID.ToString(), "GroupElementOrder");
                objBiz.GroupCol = new EstimationAssignmentGroupCol(true);
                foreach (DataRow objDr in arrDr)
                    objBiz.GroupCol.Add(new EstimationAssignmentGroupBiz(objDr));

                arrDr = dtJobNatureType.Select("AssignmentID=" + objBiz.ID.ToString(), "");
                objBiz.JobNatureTypeCol = new JobNatureTypeCol(true);
                foreach (DataRow objDr in arrDr)
                    objBiz.JobNatureTypeCol.Add(new JobNatureTypeBiz(objDr));
            }

        }
        #endregion
    }
}
