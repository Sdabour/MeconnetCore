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
    public class OriginStatementBonusBiz
    {
        #region Private Data
        OriginStatementBonusDb _OriginStatementBonusDb;
        #endregion

        #region Constractors
        public OriginStatementBonusBiz()
        {
            _OriginStatementBonusDb = new OriginStatementBonusDb();
        }
        public OriginStatementBonusBiz(int intID)
        {
            _OriginStatementBonusDb = new OriginStatementBonusDb(intID);
        }
        public OriginStatementBonusBiz(DataRow objDR)
        {
            _OriginStatementBonusDb = new OriginStatementBonusDb(objDR);
        }
        #endregion

        #region Public Accessorice
        public int OriginStatement
        {
            set
            {
                _OriginStatementBonusDb.OriginStatement = value;
            }
            get
            {
                return _OriginStatementBonusDb.OriginStatement;
            }
        }
        public string Desc
        {
            set
            {
                _OriginStatementBonusDb.Desc = value;
            }
            get
            {
                return _OriginStatementBonusDb.Desc;
            }
        }
        public double Value
        {
            set
            {
                _OriginStatementBonusDb.Value = value;
            }
            get
            {
                return _OriginStatementBonusDb.Value;
            }
        }
        public DateTime Date
        {
            set
            {
                _OriginStatementBonusDb.Date = value;
            }
            get
            {
                return _OriginStatementBonusDb.Date;
            }
        }
        #endregion

        #region Private Methods
        #endregion

        #region Public Methods
        public void Add()
        {
            _OriginStatementBonusDb.Add();
        }
        public void Edit()
        {
            _OriginStatementBonusDb.Edit();
        }
        public void Delete()
        {
            _OriginStatementBonusDb.Delete();
        }

        #endregion
    }
}
