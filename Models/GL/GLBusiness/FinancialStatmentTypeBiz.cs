using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.GL.GLDataBase;
using SharpVision.Base.BaseBusiness;
using SharpVision.Base.BaseDataBase;
using SharpVision.UMS.UMSBusiness;
using SharpVision.COMMON.COMMONBusiness;
using System.Data;

namespace SharpVision.GL.GLBusiness
{
    public class FinancialStatmentTypeBiz : BaseSingleBiz
    {
        #region Private Data

        #endregion

        #region Constractors
        public FinancialStatmentTypeBiz()
        {
            _BaseDb = new FinancialStatmentTypeDb();
        }
        public FinancialStatmentTypeBiz(int intID)
        {
             _BaseDb = new FinancialStatmentTypeDb(intID);
        }
        public FinancialStatmentTypeBiz(DataRow objDR)
        {
            _BaseDb = new FinancialStatmentTypeDb(objDR);
        }
        #endregion

        #region Public Accessorice
        public int Period
        {
            set
            {
                ((FinancialStatmentTypeDb)_BaseDb).Period = value;
            }
            get
            {
                return ((FinancialStatmentTypeDb)_BaseDb).Period;
            }
        }
        public double PeriodAmount
        {
            set
            {
                ((FinancialStatmentTypeDb)_BaseDb).PeriodAmount = value;
            }
            get
            {
                return ((FinancialStatmentTypeDb)_BaseDb).PeriodAmount;
            }
        }

        public string PeriodStr
        {
            get
            {
                string Returned = Period.ToString() + "  " + PeriodAmount.ToString();
                return Returned;
            }
        }
        #endregion

        #region Private Methods

        #endregion

        #region public Methods
        public void Add()
        {
            _BaseDb.Add();
        }
        public void Edit()
        {
            _BaseDb.Edit();
        }
        public void Delete()
        {
            _BaseDb.Delete();
        }
        #endregion

    }
}
