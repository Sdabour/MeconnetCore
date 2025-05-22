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
    public class OriginStatementBiz
    {
        #region Private Data
        protected OriginStatementDb _OriginStatementDb;
        protected OriginStatementBonusCol _BonusCol;
        protected OriginStatementBonusCol _DeleteBonusCol;  
        protected OriginStatementDiscountCol _DiscountCol;        
        protected OriginStatementDiscountCol _DeleteDiscountCol;
       protected OriginStatementBiz _PreviousStatement;
        #endregion 

        #region Constractors
        public OriginStatementBiz()
        {
            _OriginStatementDb= new OriginStatementDb();
        }
        public OriginStatementBiz(int intID)
        {
            _OriginStatementDb= new OriginStatementDb(intID);
        }
        public OriginStatementBiz(DataRow objDR)
        {
            _OriginStatementDb= new OriginStatementDb(objDR);
        }
        #endregion

        #region Public Accessorice
        public int ID
        {
            set
            {
                _OriginStatementDb.ID = value;
            }
            get
            {
                return _OriginStatementDb.ID;
            }
        }
        public DateTime Date
        {
            set
            {
                _OriginStatementDb.Date = value;
            }
            get
            {
                return _OriginStatementDb.Date;
            }
        }
        public virtual OriginStatementBiz PreviousStatement
        {
            set
            {
                _PreviousStatement = value;
            }
            get
            {
                return _PreviousStatement;
            }
        }
        public double OldDue
        {
            set
            {
                _OriginStatementDb.OldDue = value;
            }
            get
            {
                return _OriginStatementDb.OldDue;
            }
        }
        public double TaxValue
        {
            set
            {
                _OriginStatementDb.TaxValue = value;
            }
            get
            {
                return _OriginStatementDb.TaxValue;
            }
        }
        public int TaxStatement
        {
            set
            {
                _OriginStatementDb.TaxStatement = value;
            }
            get
            {
                return _OriginStatementDb.TaxStatement;
            }
        }
        public double PaidValue
        {
            set
            {
                _OriginStatementDb.PaidValue = value;
            }
            get
            {
                return _OriginStatementDb.PaidValue;
            }
        }
        public virtual double DiscountValue
        {
            set
            {
                _OriginStatementDb.DiscountValue = value;

            }
            get
            {
                return _OriginStatementDb.DiscountValue;
            }
        }
        public double TotalValue
        {
            set
            {
                _OriginStatementDb.TotalValue = value;
            }
            get
            {
                return _OriginStatementDb.TotalValue;
            }
        }
        public bool StatementReviewed
        {
            set
            {
                _OriginStatementDb.StatementReviewed = value;
            }
            get
            {
                return _OriginStatementDb.StatementReviewed;
            }
        }
        public int StatementStage
        {
            set
            {
                _OriginStatementDb.StatementStage = value;
            }
            get
            {
                return _OriginStatementDb.StatementStage;
            }
        }
        public OriginStatementBonusCol BonusCol
        {
            set
            {
                _BonusCol = value;
            }
            get
            {
                if (_BonusCol == null)
                {
                    _BonusCol = new OriginStatementBonusCol(true);
                    if (ID != 0)
                    {
                        OriginStatementBonusDb objDb = new OriginStatementBonusDb();
                        objDb.OriginStatement = ID;
                        DataTable dtTemp = objDb.Search();
                        foreach (DataRow objDr in dtTemp.Rows)
                        {
                            _BonusCol.Add(new OriginStatementBonusBiz(objDr));
                        }
                    }
                }
                return _BonusCol;
            }
        }
        public OriginStatementBonusCol DeleteBonusCol
        {
            set
            {
                _DeleteBonusCol = value;
            }
            get
            {
                if (_DeleteBonusCol == null)
                {
                    _DeleteBonusCol = new OriginStatementBonusCol(true);                   
                }
                return _DeleteBonusCol;
            }
        }
        public virtual OriginStatementDiscountCol DiscountCol
        {
            set
            {
                _DiscountCol = value;
            }
            get
            {

                if (_DiscountCol == null)
                {
                    _DiscountCol = new OriginStatementDiscountCol(true);
                    if (ID != 0)
                    {
                        OriginStatementDiscountDb objDb = new OriginStatementDiscountDb();
                        objDb.OriginStatement = ID;
                        DataTable dtTemp = objDb.Search();
                        OriginStatementDiscountBiz objTemp;
                        foreach (DataRow objDr in dtTemp.Rows)
                        {
                            objTemp = new OriginStatementDiscountBiz(objDr);
                            //objTemp.
                            _DiscountCol.Add(objTemp);
                        }
                    }
                }

                return _DiscountCol;
            }
        }
        public OriginStatementDiscountCol DeleteDiscountCol
        {
            set
            {
                _DeleteDiscountCol = value;
            }
            get
            {

                if (_DeleteDiscountCol == null)
                {
                    _DeleteDiscountCol = new OriginStatementDiscountCol(true);                   
                }

                return _DeleteDiscountCol;
            }
        }
        #endregion

        #region Private Methods

        #endregion

        #region Public Methods
        public virtual void Add()
        {
            _OriginStatementDb.Add();
        }
        public virtual void Edit()
        {
            _OriginStatementDb.Edit();
        }
        public virtual void Delete()
        {
            _OriginStatementDb.Delete();
        }
        #endregion
    }
}
