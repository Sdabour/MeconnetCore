using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

using System.Data;
using SharpVision.HR.HRDataBase;
using SharpVision.SystemBase;
namespace SharpVision.HR.HRBusiness
{
    public class EstimationAssignmentElementCol:CollectionBase
    {

        #region Constructor
        public EstimationAssignmentElementCol()
        {

        }
        public EstimationAssignmentElementCol(bool blIsEmbty)
        {
            if (blIsEmbty)
                return;
            EstimationAssignmentElementBiz objBiz = new EstimationAssignmentElementBiz();
            objBiz.ID = 0;
           

            EstimationAssignmentElementDb objDb = new EstimationAssignmentElementDb();

            DataTable dtTemp = objDb.Search();


            foreach (DataRow objDR in dtTemp.Rows)
            {
                objBiz = new EstimationAssignmentElementBiz(objDR);
                Add(objBiz);
            }
        }

        #endregion
        #region Private Data

        #endregion
        #region Properties
        public EstimationAssignmentElementBiz this[int intIndex]
        {
            get
            {
                return (EstimationAssignmentElementBiz)this.List[intIndex];
            }
        }
        public ApplicantWorkerEstimationStatementElementCol ApplicantWorkerEstimationStatmentElementCol
        {
            get
            {
                ApplicantWorkerEstimationStatementElementCol Returned = new ApplicantWorkerEstimationStatementElementCol(true);
                foreach (EstimationAssignmentElementBiz objElementBiz in this)
                    Returned.Add(objElementBiz.ApplicantWorkerEstimationStatementElementBiz);

                return Returned;
            }
        }
        #endregion
        #region Private Method

        #endregion
        #region Public Method 
        public void Add(EstimationAssignmentElementBiz objBiz)
        {
           List<EstimationAssignmentElementBiz> lstElement = (from  objElement in this.Cast<EstimationAssignmentElementBiz>()
                                                              where objElement.ElementBiz.ID== objBiz.ElementBiz.ID && objBiz.ElementBiz.ID!=0
                                                              select objElement).ToList();
            
            if (lstElement.Count == 0)
            {

                List.Add(objBiz);


            }
            else
            {
                foreach (EstimationAssignmentElementBiz objElementBiz1 in lstElement)
                {
                    objElementBiz1.ElementWeight = objBiz.ElementWeight;
                    objElementBiz1.ElementValue = objBiz.ElementValue;
                    objElementBiz1.ElementIsFuzzy = objBiz.ElementIsFuzzy;
                    objElementBiz1.ElementOrder = objBiz.ElementOrder;
                    objElementBiz1.GroupBiz = objBiz.GroupBiz;
                }
            }
        }
        public void ReOrder()
        {
            List<EstimationAssignmentElementBiz> arrOrdered = (from objBiz in List.Cast<EstimationAssignmentElementBiz>()
                                                              orderby objBiz.ElementOrder
                                                              select objBiz).ToList();
            List.Clear();
            foreach (EstimationAssignmentElementBiz objElementBiz in arrOrdered)
            {
                objElementBiz.ElementOrder = List.Count;
                List.Add(objElementBiz);
            }


        }
        public EstimationAssignmentElementCol GetCol(string strTemp,GroupElementBiz objGroup)
        {
            if (objGroup == null)
                objGroup = new GroupElementBiz();
            EstimationAssignmentElementCol Returned = new EstimationAssignmentElementCol(true);
            foreach (EstimationAssignmentElementBiz objBiz in this)
            {
                if ((objGroup.ID==0 || objBiz.GroupBiz.ID == objGroup.ID) &&objBiz.ElementBiz.Name.CheckStr(strTemp))
                    Returned.Add(objBiz);
            }
            return Returned;
        }
        public EstimationAssignmentElementCol GetCol(int intElementID)
        {
            EstimationAssignmentElementCol Returned = new EstimationAssignmentElementCol(true);
            foreach (EstimationAssignmentElementBiz objBiz in this)
            {
                if (objBiz.ElementBiz.ID==intElementID)
                    Returned.Add(objBiz);
            }
            return Returned;
        }
       
        public DataTable GetTable()
        {
            ReOrder();
            DataTable Returned = new DataTable();
            Returned.Columns.AddRange(new DataColumn[] { new DataColumn("AssignmentID"), new DataColumn("AssignmentElementID"), new DataColumn("AssignmentElementGroup"), new DataColumn("AssignmentElementGroupPerc"), new DataColumn("AssignmentElementGroupOrder"), new DataColumn("AssignmentElementWeight"), new DataColumn("AssignmentElementIsFuzzy", System.Type.GetType("System.Boolean")), new DataColumn("AssignmentElementValue"), new DataColumn("AssignmentElementOrder"), new DataColumn("AssignmentGroupElelemntID"), new DataColumn("AssignmentGroupElementCode"), new DataColumn("AssignmentGroupElementNameA"), new DataColumn("AssignmentGroupElementNameE") });
            DataRow objDr;
            foreach (EstimationAssignmentElementBiz objBiz in this)
            {
                objDr = Returned.NewRow();
                objDr["AssignmentID"] = objBiz.ID;
              
                objDr["AssignmentElementID"] = objBiz.ElementBiz.ID;
                objDr["AssignmentElementGroup"] = objBiz.GroupBiz.ID;
                objDr["AssignmentElementGroupPerc"] = objBiz.ElementGroupPerc;
                objDr["AssignmentElementGroupOrder"] = objBiz.ElementGroupOrder;
                objDr["AssignmentElementWeight"] = objBiz.ElementWeight;
                objDr["AssignmentElementIsFuzzy"] = objBiz.ElementIsFuzzy;
                objDr["AssignmentElementValue"] = objBiz.ElementValue;
                objDr["AssignmentElementOrder"] = objBiz.ElementOrder;
                objDr["AssignmentGroupElelemntID"] = objBiz.GroupBiz.ID;
                objDr["AssignmentGroupElementCode"] = objBiz.GroupBiz.Code;
                objDr["AssignmentGroupElementNameA"] = objBiz.GroupBiz.NameA;
                objDr["AssignmentGroupElementNameE"] = objBiz.GroupBiz.NameE;
                Returned.Rows.Add(objDr);
            }
            return Returned;
        }

        #endregion
    }
}
