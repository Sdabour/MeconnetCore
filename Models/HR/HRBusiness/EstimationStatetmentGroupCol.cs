using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Collections;
using SharpVision.HR.HRDataBase;
namespace SharpVision.HR.HRBusiness
{
    public class EstimationStatetmentGroupCol:CollectionBase
    {

        #region Constructor
        public EstimationStatetmentGroupCol()
        {

        }
        public EstimationStatetmentGroupCol(bool blIsEmbty)
        {
            if (blIsEmbty)
                return;
            EstimationStatetmentGroupBiz objBiz = new EstimationStatetmentGroupBiz();
          
            

            EstimationStatetmentGroupDb objDb = new EstimationStatetmentGroupDb();

            DataTable dtTemp = objDb.Search();


            foreach (DataRow objDR in dtTemp.Rows)
            {
                objBiz = new EstimationStatetmentGroupBiz(objDR);
                Add(objBiz);
            }
        }

        #endregion
        #region Private Data

        #endregion
        #region Properties
        Hashtable _GroupElementHs = new Hashtable();
        public EstimationStatetmentGroupBiz this[int intIndex]
        {
            get
            {
                return (EstimationStatetmentGroupBiz)this.List[intIndex];
            }
        }
        ApplicantWorkerEstimationStatementElementCol _ElementCol;
        public ApplicantWorkerEstimationStatementElementCol ElementCol
        {
            get
            {
                if (_ElementCol == null)
                {
                    _ElementCol = new ApplicantWorkerEstimationStatementElementCol(true);
                   
                    ElementDb objDb = new ElementDb();
                    objDb.GroupIDs = IDsStr;
                    DataTable dtTemp = objDb.Search();
                    ElementBiz objElementBiz;
                    EstimationStatetmentGroupBiz objGroupBiz;
                    ApplicantWorkerEstimationStatementElementBiz objBiz = new ApplicantWorkerEstimationStatementElementBiz();
                    foreach (DataRow objDr in dtTemp.Rows)
                    {
                        objElementBiz = new ElementBiz(objDr);
                      
                        objGroupBiz = new EstimationStatetmentGroupBiz();
                        if (_GroupElementHs[objElementBiz.GroupBiz.ID.ToString()] != null)
                            objGroupBiz = (EstimationStatetmentGroupBiz)_GroupElementHs[objElementBiz.GroupBiz.ID.ToString()];
                        objElementBiz.GroupBiz.Perc = objGroupBiz.Perc;
                        objElementBiz.GroupBiz.Order = objGroupBiz.Order;
                        objBiz = new ApplicantWorkerEstimationStatementElementBiz() { ElementBiz = objElementBiz, ElementValue = objElementBiz.ElementValue, EstimationValue = objElementBiz.ElementEstimation, Group = objElementBiz.GroupBiz.ID, GroupPerc = objGroupBiz.Perc, GroupOrder = objGroupBiz.Order,IsFuzzyValue=objElementBiz.IsFuzzy };
                        _ElementCol.Add(objBiz);
                    }

                }
                return _ElementCol;
            }
        }
        public string IDsStr
        {
            get
            {
                string Returned = "";
                foreach (EstimationStatetmentGroupBiz objGroup in this)
                {
                    if (Returned != "")
                        Returned += ",";
                    Returned += objGroup.GroupElementBiz.ID.ToString();
                }
                return Returned;
            }
        }
        #endregion
        #region Private Method

        #endregion
        #region Public Method 
        public void Add(EstimationStatetmentGroupBiz objBiz)
        {
            if (_GroupElementHs[objBiz.GroupElementBiz.ID.ToString()] == null)
                _GroupElementHs.Add(objBiz.GroupElementBiz.ID.ToString(), objBiz);

            List.Add(objBiz);
        }
        public EstimationStatetmentGroupCol GetCol(string strTemp)
        {
            EstimationStatetmentGroupCol Returned = new EstimationStatetmentGroupCol(true);
            foreach (EstimationStatetmentGroupBiz objBiz in this)
            {
              
                    Returned.Add(objBiz);
            }
            return Returned;
        }
        public DataTable GetTable()
        {
            DataTable Returned = new DataTable();
            Returned.Columns.AddRange(new DataColumn[] { new DataColumn("StatementID"), new DataColumn("GroupElementID"), new DataColumn("GroupElementPerc"), new DataColumn("GroupElementOrder") });
            DataRow objDr;
            foreach (EstimationStatetmentGroupBiz objBiz in this)
            {
                objDr = Returned.NewRow();
                objDr["StatementID"] = objBiz.StatementID;
                objDr["GroupElementID"] = objBiz.GroupElementBiz.ID;
                objDr["GroupElementPerc"] = objBiz.Perc;
                objDr["GroupElementOrder"] = objBiz.Order;
                Returned.Rows.Add(objDr);
            }
            return Returned;
        }

        #endregion
    }
}
