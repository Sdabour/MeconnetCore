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
    public class OriginStatementDiscountBiz
    {
        #region Private Data
        OriginStatementDiscountDb _OriginStatementDiscountDb;
        #endregion

        #region Constractors
        public OriginStatementDiscountBiz()
        {
            _OriginStatementDiscountDb = new OriginStatementDiscountDb();
        }
        public OriginStatementDiscountBiz(int intID)
        {
            _OriginStatementDiscountDb = new OriginStatementDiscountDb(intID);
        }
        public OriginStatementDiscountBiz(DataRow objDR)
        {
            _OriginStatementDiscountDb = new OriginStatementDiscountDb(objDR);
        }
        #endregion

        #region Public Accessorice
        public int OriginStatement
        {
            set
            {
                _OriginStatementDiscountDb.OriginStatement = value;
            }
            get
            {
                return _OriginStatementDiscountDb.OriginStatement;
            }
        }
        public string Desc
        {
            set
            {
                _OriginStatementDiscountDb.Desc = value;
            }
            get
            {
                return _OriginStatementDiscountDb.Desc;
            }
        }
        public double Value
        {
            set
            {
                _OriginStatementDiscountDb.Value = value;
            }
            get
            {
                return _OriginStatementDiscountDb.Value;
            }
        }
        public DateTime Date
        {
            set
            {
                _OriginStatementDiscountDb.Date = value;
            }
            get
            {
                return _OriginStatementDiscountDb.Date;
            }
        }
        #endregion

        #region Private Methods
        #endregion

        #region Public Methods
        public void Add()
        {
            _OriginStatementDiscountDb.Add();
        }
        public void Edit()
        {
            _OriginStatementDiscountDb.Edit();
        }
        public void Delete()
        {
            _OriginStatementDiscountDb.Delete();
        }

        #endregion
    }
}
