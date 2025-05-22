using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.Base.BaseDataBase;
using SharpVision.Base.BaseBusiness;
using SharpVision.GL.GLDataBase;
using SharpVision.SystemBase;
using SharpVision.COMMON.COMMONBusiness;

namespace SharpVision.GL.GLBusiness
{
    public enum FieldName
    {
        ACPayeeOnly=1,
        NotNegotiable=2,
        Date=3,
        PayeeLine1=4,
        PayeeLine2=5,
        BearerStrike=6,
        AmountInWords1=7,
        AmountInWords2=8,
        Amount=9,
        AccountNo=10,
        ForCompany=11,
        AuthorizedSignatory=12,
        Signature=13,
        PayableAtPar=14,
        NotAbove =15,
        NotAboveAmount=16,
        Main=17,
        Currency=18
    }
    public class DimensionBiz
    {
        #region Private Data
        DimensionDb _DimensionDb;
        #endregion
        #region Constructors
        public DimensionBiz()
        {
            _DimensionDb = new DimensionDb();
        }
        public DimensionBiz(DataRow objDr)
        {
            _DimensionDb = new DimensionDb(objDr);
        }
        #endregion
        #region Public Properties
        public int ID
        {
            set
            {
                _DimensionDb.ID = value;
            }
            get
            {
                return _DimensionDb.ID;
            }
        }
        public int LayoutID
        {
            set
            {
                _DimensionDb.LayoutID = value;
            }
            get
            {
                return _DimensionDb.LayoutID;
            }
        }
        public int FieldID
        {
            set
            {
                _DimensionDb.FieldID = value;
            }
            get
            {
                return _DimensionDb.FieldID;
            }
        }
        public double X
        {
            set
            {
                _DimensionDb.X = value;
            }
            get
            {
                return _DimensionDb.X;
            }
        }
        public double Y
        {
            set
            {
                _DimensionDb.Y = value;
            }
            get
            {
                return _DimensionDb.Y;
            }
        }
        public double Width
        {
            set
            {
                _DimensionDb.Width = value;
            }
            get
            {
                return _DimensionDb.Width;
            }
        }
        public double Height
        {
            set
            {
                _DimensionDb.Height = value;
            }
            get
            {
                return _DimensionDb.Height;
            }
        }
        #endregion
        #region Private Methods

        #endregion
        #region Public Methods

        #endregion
    }
}
