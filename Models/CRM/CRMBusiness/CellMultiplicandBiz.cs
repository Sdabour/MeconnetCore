using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.Base.BaseDataBase;
using SharpVision.Base.BaseBusiness;
using SharpVision.CRM.CRMDataBase;
using SharpVision.SystemBase;
using SharpVision.RP.RPBusiness;

namespace SharpVision.CRM.CRMBusiness
{
    public class CellMultiplicandBiz : MultiplicandBiz
    {
        #region Private Data
        CellBiz _CellBiz;
        #endregion

        #region Constructors
        public CellMultiplicandBiz()
        {
            _MultiplicandDb = new CellMultiplicandDb();
            _CellBiz = new CellBiz();
            
        }
        public CellMultiplicandBiz(DataRow objDR)
        {
            _MultiplicandDb = new CellMultiplicandDb(objDR);
            _CellBiz = new CellBiz(((CellMultiplicandDb)_MultiplicandDb).Cell);
        }
        #endregion

        #region Public Properties

        public CellBiz CellBiz
        {
            set
            {
                _CellBiz = value;
            }
            get
            {
                return _CellBiz;
            }
        }
        #endregion

        #region Private Methods

        #endregion

        #region Public Methods
     
        #endregion
    }
}
