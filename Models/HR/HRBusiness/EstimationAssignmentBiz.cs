using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpVision.HR.HRDataBase;
using System.Data;
namespace SharpVision.HR.HRBusiness
{
   public  class EstimationAssignmentBiz
    {

        #region Constructor
        public EstimationAssignmentBiz()
        {
            _EstimationAssignmentDb = new EstimationAssignmentDb();
        }
        public EstimationAssignmentBiz(DataRow objDr)
        {
            _EstimationAssignmentDb = new EstimationAssignmentDb(objDr);
        }

        #endregion
        #region Private Data
        EstimationAssignmentDb _EstimationAssignmentDb;
        #endregion
        #region Properties
        public int ID
        {
            set
            {
                _EstimationAssignmentDb.ID = value;
            }
            get
            {
                return _EstimationAssignmentDb.ID;
            }
        }
        public DateTime Date
        {
            set
            {
                _EstimationAssignmentDb.Date = value;
            }
            get
            {
                return _EstimationAssignmentDb.Date;
            }
        }
        public string Desc
        {
            set
            {
                _EstimationAssignmentDb.Desc = value;
            }
            get
            {
                return _EstimationAssignmentDb.Desc;
            }
        }
        public int EstimationStatement
        {
            set
            {
                _EstimationAssignmentDb.EstimationStatement= value;
            }
            get
            {
                return _EstimationAssignmentDb.EstimationStatement;
            }
        }
        public int Job
        {
            set
            {
                _EstimationAssignmentDb.Job = value;
            }
            get
            {
                return _EstimationAssignmentDb.Job;
            }
        }
        public int Sector
        {
            set
            {
                _EstimationAssignmentDb.Sector = value;
            }
            get
            {
                return _EstimationAssignmentDb.Sector;
            }
        }
        public int EstimationJobCategory
        {
            set
            {
                _EstimationAssignmentDb.EstimationJobCategory = value;
            }
            get
            {
                return _EstimationAssignmentDb.EstimationJobCategory;
            }
        }
        public int EstimationApplicant
        {
            set
            {
                _EstimationAssignmentDb.EstimationApplicant = value;
            }
            get
            {
                return _EstimationAssignmentDb.EstimationApplicant;
            }
        }
        EstimationStatementBiz _EstimationStatementBiz;
        public EstimationStatementBiz EstimationStatementBiz
        {
            set => _EstimationStatementBiz = value;
            get
            {
                if (_EstimationStatementBiz == null)
                {
                    _EstimationStatementBiz = new EstimationStatementBiz() { ID = _EstimationAssignmentDb.EstimationStatementID, EstimationStatementDesc = _EstimationAssignmentDb.EstimationStatementDesc, EstimationStatementDate = _EstimationAssignmentDb.EstimationStatementDate };
             
                }
                return _EstimationStatementBiz;
            }
               

        }
        JobCategoryEstimationBiz _JobCategoryEstimationBiz;
        public JobCategoryEstimationBiz JobCategoryEstimationBiz
        {
            set => _JobCategoryEstimationBiz = value;
            get
            {
                if (_JobCategoryEstimationBiz == null)
                {
                    _JobCategoryEstimationBiz = new JobCategoryEstimationBiz() { ID = _EstimationAssignmentDb.JobCategoryEstimationID, NameA = _EstimationAssignmentDb.JobCategoryEstimationNameA, NameE = _EstimationAssignmentDb.JobCategoryEstimationNameE };
                }
                return _JobCategoryEstimationBiz;
            }
        }
        JobCategoryBiz _JobCategoryBiz;
        public JobCategoryBiz JobCategoryBiz
        {
            set => _JobCategoryBiz = value;
            get
            {
                if (_JobCategoryBiz == null)
                {
                    _JobCategoryBiz = new JobCategoryBiz() { ID = _EstimationAssignmentDb.JobCategoryID, NameA = _EstimationAssignmentDb.JobCategoryNameA, NameE = _EstimationAssignmentDb.JobCategoryNameE };
                }
                return _JobCategoryBiz;
            }
        }

        //SectorBiz _SectorBiz;
        //public SectorBiz SectorBiz
        //{
        //    set => _SectorBiz = value;
        //    get
        //    {
        //        if (_SectorBiz == null)
        //        { _SectorBiz = new SectorBiz() { ID =_EstimationAssignmentDb.SectorID, NameA = _EstimationAssignmentDb.SectorNameA }; 
        //        }
        //        return _SectorBiz;
        //    } }
        SectorSimple _SectorBiz;
        public SectorSimple SectorBiz
        {
            set => _SectorBiz = value;
            get
            {
                if (_SectorBiz == null)
                {
                    _SectorBiz = new SectorSimple() { ID = _EstimationAssignmentDb.SectorID, Name = _EstimationAssignmentDb.SectorNameA ,Level=0};
                    if (_EstimationAssignmentDb.SectorID != 0)
                    {
                        List<SectorSimple> objCol = (from objSimple in SectorSimple.SectorLst where objSimple.ID == _EstimationAssignmentDb.SectorID
                                                    select objSimple).ToList();
                        if (objCol != null && objCol.Count > 0)
                            _SectorBiz = objCol[0];
                        //  SectorSimple.SectorLst
                    }
                }
                return _SectorBiz;
            }
        }
       
        public bool IsEn
        { set => _EstimationAssignmentDb.IsEn = value; get => _EstimationAssignmentDb.IsEn; }

        EstimationAssignmentGroupCol _GroupCol;
        public EstimationAssignmentGroupCol GroupCol
        {
            set => _GroupCol = value;
            get {
                if (_GroupCol == null)
                {
                    _GroupCol = new EstimationAssignmentGroupCol();
                    if (ID != 0)
                    {
                        EstimationAssignmentGroupDb objDb = new EstimationAssignmentGroupDb();
                        objDb.AssignmentID = ID;
                        DataTable dtTemp = objDb.Search();
                        foreach (DataRow objDr in dtTemp.Rows)
                        {
                            _GroupCol.Add(new EstimationAssignmentGroupBiz(objDr));
                        }
                    }

                }
                return _GroupCol;
            }
        }
        EstimationAssignmentElementCol _ElementCol;
        public EstimationAssignmentElementCol ElementCol
        {
            set => _ElementCol = value;
            get
            {
                if (_ElementCol == null)
                {
                    _ElementCol = new EstimationAssignmentElementCol(true);
                    if (ID != 0)
                    {
                        EstimationAssignmentElementDb objDb = new EstimationAssignmentElementDb();
                        objDb.ID = ID;
                         DataTable dtTemp = objDb.Search();
                        DataRow[] arrDr = dtTemp.Select("", "");
                        foreach (DataRow objDr in dtTemp.Rows)
                        {
                            _ElementCol.Add(new EstimationAssignmentElementBiz(objDr));
                        }
                    }
                }
                    return _ElementCol;
            }
        }
        JobNatureTypeCol _JobNatureCol;
        public JobNatureTypeCol JobNatureTypeCol
        {
            get
            {
                if (_JobNatureCol == null)
                {
                    _JobNatureCol = new JobNatureTypeCol(true);
                    if (ID != 0)
                    {
                        DataTable dtTemp = _EstimationAssignmentDb.GetJobNature();
                        foreach (DataRow objDr in dtTemp.Rows)
                            _JobNatureCol.Add(new JobNatureTypeBiz(objDr));
                    }
                }
             return   _JobNatureCol;
            }
            set
            {
                _JobNatureCol = value;
            }
        }
        public int Order
        {
            get
            {
                int Returned = (SectorBiz.ID > 0 && JobCategoryEstimationBiz.ID > 0 && JobNatureTypeCol.Count > 0
                                                   ? 1 : (SectorBiz.ID > 0 && JobNatureTypeCol.Count > 0 ? 2 :
                                                   (SectorBiz.ID > 0 && JobCategoryEstimationBiz.ID>0? 3 : (SectorBiz.ID > 0 ? 4 :( JobNatureTypeCol.Count>0? 5:(JobCategoryEstimationBiz.ID>0?6:7)
                                                   )))
                                                   ));
                return Returned;

            }
        }
        #endregion
        #region Private Method
        DataTable GetJobNatureTypeTable()
        {
            DataTable Returned = new DataTable();
            Returned.Columns.AddRange(new DataColumn[] { new DataColumn("AssignmentID"), new DataColumn("AssignmentJobNature") });
            DataRow objDr;
            foreach (JobNatureTypeBiz objType in JobNatureTypeCol)
            {
                objDr = Returned.NewRow();
                objDr["AssignmentID"] = ID;
                objDr["AssignmentJobNature"] = objType.ID;
                Returned.Rows.Add(objDr);

            }
            return Returned;
        }
        #endregion
        #region Public Method 
        public void Add()
        {
            _EstimationAssignmentDb.EstimationStatement = EstimationStatementBiz.ID;
            _EstimationAssignmentDb.Sector = SectorBiz.ID;
            _EstimationAssignmentDb.Job = JobCategoryBiz.ID;
            _EstimationAssignmentDb.EstimationJobCategory = JobCategoryEstimationBiz.ID;
            _EstimationAssignmentDb.ElementTable = ElementCol.GetTable();
            _EstimationAssignmentDb.GroupTable = GroupCol.GetTable();
            _EstimationAssignmentDb.JobNatureTable = GetJobNatureTypeTable();
            _EstimationAssignmentDb.Add();
        }
        public void Edit()
        {
            _EstimationAssignmentDb.EstimationStatement = EstimationStatementBiz.ID;
            _EstimationAssignmentDb.Sector = SectorBiz.ID;
            _EstimationAssignmentDb.Job = JobCategoryBiz.ID;
            _EstimationAssignmentDb.EstimationJobCategory = JobCategoryEstimationBiz.ID;
            _EstimationAssignmentDb.ElementTable = ElementCol.GetTable();
            _EstimationAssignmentDb.GroupTable = GroupCol.GetTable();
            _EstimationAssignmentDb.JobNatureTable = GetJobNatureTypeTable();
            _EstimationAssignmentDb.Edit();
        }
        public void Delete()
        {
            _EstimationAssignmentDb.Delete();
        }
        public void DeleteElementByElementID(int intElementID)
        {
            EstimationAssignmentElementCol objCol = new EstimationAssignmentElementCol(true);
            foreach (EstimationAssignmentElementBiz objBiz in ElementCol)
            {
                if (objBiz.ElementBiz.ID != intElementID)
                    objCol.Add(objBiz);

            }
            _ElementCol = objCol;
        }
        public void DeleteGroupByID(int intGroupID)
        {
            EstimationAssignmentGroupCol objCol = new EstimationAssignmentGroupCol();
            foreach (EstimationAssignmentGroupBiz objBiz in GroupCol)
            {
                if (objBiz.GroupElementBiz.ID != intGroupID)
                    objCol.Add(objBiz);

            }
            _GroupCol = objCol;
        }
        public bool CheckElement(int intElementID)
        {
           List<EstimationAssignmentElementBiz> lstAssignmentElement = (from objAssignmentELement1 in ElementCol.Cast<EstimationAssignmentElementBiz>() where objAssignmentELement1.ElementBiz.ID == intElementID
                                                                        select objAssignmentELement1).ToList();
            return lstAssignmentElement.Count > 0;
        }
        public void AdjustElementGroup()
        {
            var vrGroupCol = from objElement in ElementCol.Cast<EstimationAssignmentElementBiz>()
                             group objElement by objElement.GroupBiz.ID into objGroupID
                             select objGroupID;
            List<int> arrGroupID = new List<int>();
            foreach (var vrGroupID in vrGroupCol)
            {

                arrGroupID.Add(vrGroupID.Key);
            }
            EstimationAssignmentGroupCol objGroupCol = new EstimationAssignmentGroupCol(true);
            double dblPerc = 100;
            EstimationAssignmentGroupBiz objGroupBiz;
            if(arrGroupID.Count >0)
            {
                foreach (int intGroupID in arrGroupID)
                {
                    objGroupBiz = GroupCol[intGroupID.ToString()];
                    objGroupCol.Add(objGroupBiz);
                    
                }

            }
            objGroupCol.AdjustGroupCol();
            double dblTotalPerc = 0;
            foreach(var vrGroup in vrGroupCol)
            {
                dblTotalPerc = vrGroup.ToList().Sum(x => x.ElementWeight);


                objGroupBiz = objGroupCol[vrGroup.Key.ToString()];

                foreach (var vrElement in vrGroup.ToList())
                {
                    vrElement.GroupBiz = objGroupBiz.GroupElementBiz;
                    vrElement.ElementGroupOrder = objGroupBiz.Order;
                    vrElement.ElementGroupPerc = objGroupBiz.Perc;
                    if (dblTotalPerc == 0)
                    {
                        vrElement.ElementWeight = (100 / (double)vrGroup.ToList().Count());

                    }
                    else if (dblTotalPerc != 100)
                    {
                        vrElement.ElementWeight = (vrElement.ElementWeight / dblTotalPerc) * 100;
                    }
                }
            }
        }
        #endregion
    }
}
