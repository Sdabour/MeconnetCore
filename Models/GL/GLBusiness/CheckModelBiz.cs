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
    public class CheckModelBiz
    {
        #region Private Data
        CheckModelDb _ModelDb;
        DateFormatBiz _DateFormatBiz;
        DimensionCol _DimensionCol;
        ImageBiz _ImageBiz;
        
        #endregion
        #region Constructors
        public CheckModelBiz()
        {
            _ModelDb = new CheckModelDb();
        }
        public CheckModelBiz(DataRow objDr)
        {
            _ModelDb = new CheckModelDb(objDr);
            if (_ModelDb.FormatID != 0)
                _DateFormatBiz = new DateFormatBiz(objDr);
        }
        #endregion
        #region Public Properties
        public int ID
        {
            set
            {
                _ModelDb.ID = value;
            }
            get
            {
                return _ModelDb.ID;
            }

        }
        public DateFormatBiz DateFormatBiz
        {
            set
            {
                _DateFormatBiz = value;
            }
            get
            {
                if (_DateFormatBiz == null)
                    _DateFormatBiz = new DateFormatBiz();
                return _DateFormatBiz;
            }
        }
        public string Name
        {
            set
            {
                _ModelDb.Name = value;
            }
            get
            {
                return _ModelDb.Name;
            }

        }
        public int Image 
        {
            set
            {
                _ModelDb.Image = value;
            }
            get
            {
                return _ModelDb.Image;
            }

        }
        public ImageBiz ImageBiz
        {
            set
            {
                _ImageBiz = value;
            }
            get
            {
                if (_ImageBiz == null)
                {
                    if (_ModelDb.Image == 0)
                        _ImageBiz = new ImageBiz();
                    else
                        _ImageBiz = new ImageBiz(_ModelDb.Image);
                }

                return _ImageBiz;
            }
        }
        public string DateSpacing
        {
            set
            {
                _ModelDb.DateSpacing = value;
            }
            get
            {
                return _ModelDb.DateSpacing;
            }

        }
        public bool PayeeLineTwo
        {
            set
            {
                _ModelDb.PayeeLineTwo = value;
            }
            get
            {
                return _ModelDb.PayeeLineTwo;
            }

        }
        public bool AmountInWordsTwo
        {
            set
            {
                _ModelDb.AmountInWordsTwo = value;
            }
            get
            {
                return _ModelDb.AmountInWordsTwo;
            }

        }
        public DimensionCol DimensionCol
        {
            set
            {
                _DimensionCol = value;
            }
            get
            {
                if (_DimensionCol == null)
                {
                    _DimensionCol = new DimensionCol(true);
                    if (ID != 0)
                    {
                        DimensionDb objDb = new DimensionDb();
                        objDb.LayoutID = ID;
                        DataTable dtTemp = objDb.Search();
                        DataRow[] arrDr = dtTemp.Select("", "DimensionFeildID");
                        DimensionBiz objBiz;
                        int intIndex = 0;
                        foreach(DataRow objDr in arrDr)
                        {
                            objBiz = new DimensionBiz(objDr);
                            _DimensionCol.Add(objBiz);
                            intIndex++;
                        }
                    }
                }
                return _DimensionCol;
            }
        }
        #endregion
        #region Private Methods

        #endregion
        #region Public Methods
        public void Add()
        {
            if (ImageBiz.Path != null && ImageBiz.Path != "" && ImageBiz.Path != "No Image")
            {
                ImageBiz.Add();
            }
            _ModelDb.FormatID = DateFormatBiz.ID;
            _ModelDb.DimensionTable = DimensionCol.GetTable();
            _ModelDb.Image = ImageBiz.ID;
            _ModelDb.Add();
        }
        public void Edit()
        {
            if (ImageBiz.Path != null && ImageBiz.Path != "" && ImageBiz.Path != "No Image" && ImageBiz.ID == 0)
            {
                ImageBiz.Add();
            }
            else if(ImageBiz.ID != 0)
            {
               // ImageBiz.Delete();
                ImageBiz.Edit();
            }
            _ModelDb.FormatID = DateFormatBiz.ID;
            _ModelDb.DimensionTable = DimensionCol.GetTable();
            _ModelDb.Image = ImageBiz.ID;
            _ModelDb.Edit();
        }
        public void Delete()
        {
            _ModelDb.Delete();
        }
        #endregion

    }
}
