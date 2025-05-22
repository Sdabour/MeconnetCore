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
    public class FinancialStatementBiz
    {
        #region Private Data
        FinancialStatementDb _FinancialStatmentDb;
        FinancialStatmentTypeBiz _TypeBiz;
        #endregion

        #region Constractors
        public FinancialStatementBiz()
        {
            _FinancialStatmentDb = new FinancialStatementDb();
        }
        public FinancialStatementBiz(int intID)
        {
            _FinancialStatmentDb = new FinancialStatementDb(intID);
        }
        public FinancialStatementBiz(DataRow objDR)
        {
            _FinancialStatmentDb = new FinancialStatementDb(objDR);
        }
        #endregion

        #region Public Accessorice
         public int ID 
        {
            set
            {
                _FinancialStatmentDb.ID= value;
            }
            get
            {
                return _FinancialStatmentDb.ID;
            }
        }

        public string Title
        {
            set
            {
                _FinancialStatmentDb.Title = value;
            }
            get
            {
                return _FinancialStatmentDb.Title;
            }
        }

        public DateTime Date
        {
            set
            {
                _FinancialStatmentDb.Date = value;
            }
            get
            {
                return _FinancialStatmentDb.Date;
            }

        }
       
        public FinancialStatmentTypeBiz TypeBiz
        {
            set
            {
                _TypeBiz = value;
            }
            get
            {
                return _TypeBiz;
            }
        }
        #endregion

        #region Private Methods

        #endregion

        #region Public Methods
        public void Add()
        {
            _FinancialStatmentDb.Type = _TypeBiz.ID;
            _FinancialStatmentDb.Add();
        }
        public void Edit()
        {
            _FinancialStatmentDb.Type = _TypeBiz.ID;
            _FinancialStatmentDb.Edit();
        }
        public void Delete()
        {
            _FinancialStatmentDb.Delete();
        }
        #endregion
    }
}
