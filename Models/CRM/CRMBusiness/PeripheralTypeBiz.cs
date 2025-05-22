using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.Base.BaseBusiness;
using SharpVision.CRM.CRMDataBase;
using SharpVision.SystemBase;

namespace SharpVision.CRM.CRMBusiness
{
    public class PeripheralTypeBiz : BaseSingleBiz
    {

        #region Private Data
        #endregion

        #region Constractors
        public PeripheralTypeBiz()
        {
            _BaseDb = new PeripheralTypeDb();
        }
        public PeripheralTypeBiz(int intID)
        {
            _BaseDb = new PeripheralTypeDb(intID);
        }
        public PeripheralTypeBiz(DataRow objDR)
        {
            _BaseDb = new PeripheralTypeDb(objDR);
        }
        #endregion

        #region Public Accessorice


        #endregion

        #region Private Methods
        #endregion

        #region Public Methods
        public void Add()
        {
            ((PeripheralTypeDb)_BaseDb).Add();
        }
        public void Edit()
        {
            ((PeripheralTypeDb)_BaseDb).Edit();
        }
        public void Delete()
        {
            ((PeripheralTypeDb)_BaseDb).Delete();
        }
        #endregion

    }
}
