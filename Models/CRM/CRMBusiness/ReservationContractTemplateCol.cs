using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.UMS.UMSBusiness;
using SharpVision.CRM.CRMDataBase;

using System.Data;
using SharpVision.Base.BaseBusiness;
using System.Collections;
namespace SharpVision.CRM.CRMBusiness
{
    public class ReservationContractTemplateCol : CollectionBase
    {
        #region Private Data

        #endregion
        #region Constructors
        public ReservationContractTemplateCol(bool blIsEmpty)
        {
 
        }
        public ReservationContractTemplateCol()
        {
            ReservationContractTemplateDb objDb = new ReservationContractTemplateDb();
            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
            {
                Add(new ReservationContractTemplateBiz(objDr));
            }
        }
        #endregion
        #region Public Properties
        public ReservationContractTemplateBiz this[int intIndex]
        {
            get
            {
                return (ReservationContractTemplateBiz)List[intIndex];
            }
        }
        #endregion
        #region Private Methods

        #endregion
        #region Public Methods
        public void Add(ReservationContractTemplateBiz objBiz)
        {
            List.Add(objBiz);
        }
        #endregion
    }
}
