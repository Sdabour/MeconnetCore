using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.HR.HRDataBase;
using System.Data;
using SharpVision.Base.BaseBusiness;

namespace SharpVision.HR.HRBusiness
{
    public class CostCenterTypeBiz : BaseSingleBiz
    {
        #region Private Data

        #endregion
        #region Constructors
         public CostCenterTypeBiz()
        {
            _BaseDb = new CostCenterTypeDb();
        }
        public CostCenterTypeBiz(int intID)
        {
            _BaseDb = new CostCenterTypeDb(intID);
        }
        public CostCenterTypeBiz(DataRow objDR)
        {
            _BaseDb = new CostCenterTypeDb(objDR);
        }
        public CostCenterTypeBiz(CostCenterTypeDb objDb)
        {
            _BaseDb = objDb;
        }
        #endregion
        #region Public Properties

        #endregion
        #region Private Methods

        #endregion
        #region Public Methods
        public  void Add()
        {
            ((CostCenterTypeDb)_BaseDb).Add();
        }
        public  void Edit()
        {            
            ((CostCenterTypeDb)_BaseDb).Edit();
        }
        public  void Delete()
        {
            ((CostCenterTypeDb)_BaseDb).Delete();
        }
        public CostCenterTypeBiz  Copy()
        {
            CostCenterTypeBiz Returned = new CostCenterTypeBiz();
            Returned.ID = this.ID;
            Returned.NameA = this.NameA;
            Returned.NameE = this.NameE;            

            return Returned;
        }
        public CostCenterHRCol GetCostCenterHRCol()
        {
            CostCenterHRCol objCol = new CostCenterHRCol(true);
            CostCenterHRDb objDb = new CostCenterHRDb();
            objDb.CostCenterType = this.ID;
            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
            {
                objCol.Add(new CostCenterHRBiz(objDr));
            }
            return objCol;
        }
        #endregion
    }
}
