using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.SystemBase;
using SharpVision.Base.BaseDataBase;
using SharpVision.COMMON.COMMONDataBase;
namespace SharpVision.GL.GLDataBase
{
    public class DimensionDb
    {
        #region Private Data
        private int _ID;
        private int _LayoutID;
        private int _FieldID;
        private double _X;
        private double _Y;
        private double _Width;
        private double _Height;
        #endregion
        #region Constructors
        public DimensionDb()
        {
        }
        public DimensionDb(DataRow objDr)
        {
            SetData(objDr);
        }
        #endregion
        #region public properties
        public int ID
        {
            set
            {
                _ID = value;
            }
            get
            {
                return _ID;
            }
        }
        public int LayoutID
        {
            set
            {
                _LayoutID = value;
            }
            get
            {
                return _LayoutID;
            }
        }
        public int FieldID
        {
            set
            {
                _FieldID = value;
            }
            get
            {
                return _FieldID;
            }
        }
        public double X
        {
            set
            {
                _X = value;
            }
            get
            {
                return _X;
            }
        }
        public double Y
        {
            set
            {
                _Y = value;
            }
            get
            {
                return _Y;
            }
        }
        public double Width
        {
            set
            {
                _Width = value;
            }
            get
            {
                return _Width;
            }
        }
        public double Height
        {
            set
            {
                _Height = value;
            }
            get 
            {
                return _Height;
            }
        }
        public string AddStr
        {
            get
            {
                string Returned = " insert into GLCheckModelDimension "+
                    " (ModelID, DimensionFeildID, DimensionX, DimensionY, DimensionWidth, DimensionHeight)"+
                    " values ("+_LayoutID + "," + _FieldID + "," + _X + "," + _Y + "," + _Width + "," + _Height +") ";
                return Returned;

            }
        }
        public string SearchStr
        {
            get
            {
                string Returned = "SELECT   DimensionFeildID, DimensionX, DimensionY, DimensionWidth"+
                    ", DimensionHeight,ModelTable.* "+
                       " FROM     dbo.GLCheckModelDimension "+
                       " inner join (" + new CheckModelDb().SearchStr + ") as ModelTable "+
                       " on dbo.GLCheckModelDimension.ModelID = ModelTable.ModelID where (1=1) ";
                if (_LayoutID != 0)
                    Returned += " and ModelTable.ModelID = "+_LayoutID;
                return Returned;
            }
        }
          #endregion
        #region Private Method
        void SetData(DataRow objDr)
        {
            _LayoutID = int.Parse(objDr["ModelID"].ToString());
            _FieldID = int.Parse(objDr["DimensionFeildID"].ToString());
            _X = double.Parse(objDr["DimensionX"].ToString());
            _Y = double.Parse(objDr["DimensionY"].ToString());
            _Width = double.Parse(objDr["DimensionWidth"].ToString());
            _Height = double.Parse(objDr["DimensionHeight"].ToString());

        }
        #endregion
        #region Public Method
        public DataTable Search()
        {
            string strSql = SearchStr;
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        #endregion

    }
}
