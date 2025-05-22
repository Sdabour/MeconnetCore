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
    public class EstimationAssignmentGroupCol : CollectionBase
    {

        #region Constructor
        public EstimationAssignmentGroupCol()
        {

        }
        public EstimationAssignmentGroupCol(bool blIsEmbty)
        {
            if (blIsEmbty)
                return;
            EstimationAssignmentGroupBiz objBiz = new EstimationAssignmentGroupBiz();



            EstimationAssignmentGroupDb objDb = new EstimationAssignmentGroupDb();

            DataTable dtTemp = objDb.Search();


            foreach (DataRow objDR in dtTemp.Rows)
            {
                objBiz = new EstimationAssignmentGroupBiz(objDR);
                Add(objBiz);
            }
        }

        #endregion
        #region Private Data

        #endregion
        #region Properties
        Hashtable _GroupElementHs = new Hashtable();
        public EstimationAssignmentGroupBiz this[int intIndex]
        {
            get
            {
                return (EstimationAssignmentGroupBiz)this.List[intIndex];
            }
        }
        public EstimationAssignmentGroupBiz this[string strIndex]
        {
            get
            {
                EstimationAssignmentGroupBiz Returned = new EstimationAssignmentGroupBiz();
                if (_GroupElementHs[strIndex] != null)
                    Returned =(EstimationAssignmentGroupBiz) _GroupElementHs[strIndex];

                return Returned;
            }
        }
        //ApplicantWorkerEstimationAssignmentElementCol _ElementCol;
        //public ApplicantWorkerEstimationAssignmentElementCol ElementCol
        //{
        //    get
        //    {
        //        if (_ElementCol == null)
        //        {
        //            _ElementCol = new ApplicantWorkerEstimationAssignmentElementCol(true);

        //            ElementDb objDb = new ElementDb();
        //            objDb.GroupIDs = IDsStr;
        //            DataTable dtTemp = objDb.Search();
        //            ElementBiz objElementBiz;
        //            EstimationAssignmentGroupBiz objGroupBiz;
        //            ApplicantWorkerEstimationAssignmentElementBiz objBiz = new ApplicantWorkerEstimationAssignmentElementBiz();
        //            foreach (DataRow objDr in dtTemp.Rows)
        //            {
        //                objElementBiz = new ElementBiz(objDr);

        //                objGroupBiz = new EstimationAssignmentGroupBiz();
        //                if (_GroupElementHs[objElementBiz.GroupBiz.ID.ToString()] != null)
        //                    objGroupBiz = (EstimationAssignmentGroupBiz)_GroupElementHs[objElementBiz.GroupBiz.ID.ToString()];
        //                objElementBiz.GroupBiz.Perc = objGroupBiz.Perc;
        //                objElementBiz.GroupBiz.Order = objGroupBiz.Order;
        //                objBiz = new ApplicantWorkerEstimationAssignmentElementBiz() { ElementBiz = objElementBiz, ElementValue = objElementBiz.ElementValue, EstimationValue = objElementBiz.ElementEstimation, Group = objElementBiz.GroupBiz.ID, GroupPerc = objGroupBiz.Perc, GroupOrder = objGroupBiz.Order, IsFuzzyValue = objElementBiz.IsFuzzy };
        //                _ElementCol.Add(objBiz);
        //            }

        //        }
        //        return _ElementCol;
        //    }
        //}
        public string IDsStr
        {
            get
            {
                string Returned = "";
                foreach (EstimationAssignmentGroupBiz objGroup in this)
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
        public void Add(EstimationAssignmentGroupBiz objBiz)
        {
            if (_GroupElementHs[objBiz.GroupElementBiz.ID.ToString()] == null)
            {
                _GroupElementHs.Add(objBiz.GroupElementBiz.ID.ToString(), objBiz);

                List.Add(objBiz);
            }
            else{
                EstimationAssignmentGroupBiz objGroup = (EstimationAssignmentGroupBiz)_GroupElementHs[objBiz.GroupElementBiz.ID.ToString()];
                objGroup.Order = objBiz.Order;
                objGroup.Perc = objBiz.Perc;

            }
        }
        public EstimationAssignmentGroupCol GetCol(string strTemp)
        {
            EstimationAssignmentGroupCol Returned = new EstimationAssignmentGroupCol(true);
            foreach (EstimationAssignmentGroupBiz objBiz in this)
            {

                Returned.Add(objBiz);
            }
            return Returned;
        }
        public DataTable GetTable()
        {
            DataTable Returned = new DataTable();
            Returned.Columns.AddRange(new DataColumn[] { new DataColumn("AssignmentID"), new DataColumn("GroupElementID"), new DataColumn("GroupElementPerc"), new DataColumn("GroupElementOrder") });
            DataRow objDr;
            foreach (EstimationAssignmentGroupBiz objBiz in this)
            {
                objDr = Returned.NewRow();
                objDr["AssignmentID"] = objBiz.AssignmentID;
                objDr["GroupElementID"] = objBiz.GroupElementBiz.ID;
                objDr["GroupElementPerc"] = objBiz.Perc;
                objDr["GroupElementOrder"] = objBiz.Order;
                Returned.Rows.Add(objDr);
            }
            return Returned;
        }
        public int GetIndex(int intID)
        {
            for (int intIndex = 0; intIndex < Count; intIndex++)
            {
                if (this[intIndex].GroupElementBiz.ID == intID)
                    return intIndex;
            }
            return -1;
        }
        public void AdjustGroupCol()
        {
            double dblTotalPerc = this.Cast<EstimationAssignmentGroupBiz>().Sum(x=>x.Perc);
            double dblPerc = 100;
            int intZeroIndex = GetIndex(0);
            int intCount = Count;
            if(intZeroIndex!=-1)
            {
                this[intZeroIndex].Perc = (dblPerc / Count);
                intCount--;
                dblPerc -= this[intZeroIndex].Perc;


            }
            foreach(EstimationAssignmentGroupBiz objGroupiz in this)
            {
                if(objGroupiz.GroupElementBiz.ID!=0)
                objGroupiz.Perc = (objGroupiz.Perc / dblTotalPerc) * dblPerc;
            }

            
        }
        #endregion
    }
}
