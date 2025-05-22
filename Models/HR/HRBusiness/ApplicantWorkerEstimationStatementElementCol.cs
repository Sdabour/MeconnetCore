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
    public class ApplicantWorkerEstimationStatementElementCol : CollectionBase
    {
        #region Private Data

        #endregion
        #region Constructors
        public ApplicantWorkerEstimationStatementElementCol()
        {
            ApplicantWorkerEstimationStatementElementDb objDb = new ApplicantWorkerEstimationStatementElementDb();
            DataTable dtTemp = objDb.Search();
            foreach (DataRow objdr in dtTemp.Rows)
            {
                this.Add(new ApplicantWorkerEstimationStatementElementBiz(objdr));
            }
        }
        public ApplicantWorkerEstimationStatementElementCol(bool blEmpty)
        {
        }
        public ApplicantWorkerEstimationStatementElementCol(ApplicantWorkerEstimationStatementBiz objBiz)
        {
            if (objBiz.ID == 0)
                return;
            ApplicantWorkerEstimationStatementElementDb objDb = new ApplicantWorkerEstimationStatementElementDb();
            objDb.ID = objBiz.ID;
            DataTable dtTemp = objDb.Search();
            foreach (DataRow objdr in dtTemp.Rows)
            {
                this.Add(new ApplicantWorkerEstimationStatementElementBiz(objdr));
            }
        }
        #endregion
        #region Public Properties
        public virtual ApplicantWorkerEstimationStatementElementBiz this[int intIndex]
        {
            get
            {
                return (ApplicantWorkerEstimationStatementElementBiz)this.List[intIndex];
            }
        }

        public virtual void Add(ApplicantWorkerEstimationStatementElementBiz objBiz)
        {
            this.List.Add(objBiz);
        }
        public virtual void Add(ApplicantWorkerEstimationStatementElementCol objCol)
        {
            foreach(ApplicantWorkerEstimationStatementElementBiz objBiz in objCol)
             Add(objBiz);
        }
        #endregion
        #region Private Methods

        #endregion
        #region Public Methods
        public double TotalEstimationValue
        {
            get
            {
                double dlValue = 0;
                foreach (ApplicantWorkerEstimationStatementElementBiz objBiz in this)
                {
                    if (objBiz.EstimationValue != -1)
                        dlValue += objBiz.EstimationValue;
                }
                return dlValue;
            }
        }
        public double TotalElementValue
        {
            get
            {
                double dlValue = 0;
                foreach (ApplicantWorkerEstimationStatementElementBiz objBiz in this)
                {
                    if (objBiz.EstimationValue != -1)
                        dlValue += objBiz.ElementValue;
                }
                return dlValue;
            }
        }
        public double TotalElementEstimation
        {
            get
            {
                double intTotal = 0;
                foreach (ApplicantWorkerEstimationStatementElementBiz objBiz in this)
                {
                    intTotal += objBiz.ElementBiz.ElementEstimation;
                }
                return intTotal;
            }
        }
        public double EstimationAverage
        {
            get
            {
                if (this.Count == 0)
                    return 0;
                return SysUtility.Approximate((TotalEstimationValue / TotalElementValue) * 100, 1, ApproximateType.Default);
            }
        }
        public bool IsAr
        {
            get
            {
                int intCount = 0;

                bool Returned = true;
                int intElementCount = 0;
                foreach (ApplicantWorkerEstimationStatementElementBiz objElement in this)
                {
                    intCount = 0;
                    foreach (char chrTemp in objElement.ElementBiz.Name.ToCharArray())
                    {
                        if (!SysUtility.CheckForArabicAndNumeric((int)chrTemp))
                        {
                            Returned = false;

                        }
                        intCount++;
                        if (intCount >= 4)
                            break;
                    }
                    intElementCount++;
                    if (intElementCount >= 4)
                        break;
                }
                return Returned;
            }
        }
        public DataTable GetTable()
        {
            DataTable Returned = new DataTable();
            Returned.Columns.AddRange(new DataColumn[] { new DataColumn("ApplicantEstimationStatement"), new DataColumn("Element"), new DataColumn("EstimationValue"), new DataColumn("ElementValue"), new DataColumn("ElementIsFuzzyValue", System.Type.GetType("System.Boolean")), new DataColumn("ElementFuzzyValue"), new DataColumn("ElementGroup"), new DataColumn("ElementGroupPerc"), new DataColumn("ElementGroupOrder"), new DataColumn("GroupElementName"),new DataColumn("ElementDesc"),new DataColumn("ElementWeight"),new DataColumn("ElementTempElement") });
            DataRow objDr;
            foreach (ApplicantWorkerEstimationStatementElementBiz objBiz in this)
            {
                objDr = Returned.NewRow();
                objDr["ApplicantEstimationStatement"] = 0;
                objDr["Element"] = objBiz.ElementBiz.ID;
                objDr["EstimationValue"] = objBiz.EstimationValue;
                objDr["ElementValue"] = objBiz.ElementValue;
                objDr["ElementIsFuzzyValue"] = objBiz.IsFuzzyValue;
                objDr["ElementFuzzyValue"] = (int)objBiz.FuzzyValue;
                objDr["ElementGroup"] = objBiz.Group;
                objDr["ElementGroupPerc"] = objBiz.GroupPerc;
                objDr["ElementGroupOrder"] = objBiz.GroupOrder;
                objDr["GroupElementName"] = objBiz.ElementBiz.GroupBiz.Name;
                objDr["ElementDesc"] = objBiz.Desc;
                objDr["ElementWeight"] = objBiz.Weight;
                objDr["ElementTempElement"] = objBiz.TempElement;
                Returned.Rows.Add(objDr);
            }
            return Returned;
        }
        #endregion
    }
}
