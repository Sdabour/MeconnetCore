using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.COMMON.COMMONDataBase;
using System.Data;
using System.Drawing;
using System.IO;
namespace SharpVision.COMMON.COMMONBusiness
{
    public class ImageBiz
    {
        #region Private Data
        protected ImageDb _ImageDb;
        protected string _Path;
        protected SubjectCol _SubjectCol;
        protected CountryCol _CountryCol;
        protected AttachmentImageBiz _Attachment;
     
        #endregion
        #region Constructors
        public ImageBiz()
        {
           
            _ImageDb = new ImageDb();
        }
        public ImageBiz(int intID)
        {
            if (intID == 0)
                intID = 8;
            DataRow[] arrDr = new DataRow[0];
            if(ImageDb.CachCellImageTable != null)
             arrDr = ImageDb.CachCellImageTable.Select("ImageID=" + intID);
            if (ImageDb.CachCellImageTable != null && arrDr.Length > 0)
            {
                _ImageDb = new ImageDb(arrDr[0]);
            }
            else
              _ImageDb = new ImageDb(intID);
        }
        public ImageBiz(DataRow objDr)
        {
            _ImageDb = new ImageDb(objDr);
        }
        #endregion
        #region Public Properties
        public int ID
        {
            set
            {
                _ImageDb.ID = value;
            }
            get
            {
                return _ImageDb.ID;
            }
        }
        public string Title
        {
            set
            {
                _ImageDb.Title = value;
            }
            get
            {
                return _ImageDb.Title;
            }
        }
        public string Desc
        {
            set
            {
                _ImageDb.Desc = value;
            }
            get
            {
                return _ImageDb.Desc;
            }
        }
        public DateTime Date
        {
            set
            {
                _ImageDb.Date = value;
            }
            get
            {
                return _ImageDb.Date;
            }
        }
        public SubjectCol SubjectCol
        {
            set
            {
                _SubjectCol = value;
            }
            get
            {
                if (_SubjectCol == null)
                {
                    _SubjectCol = new SubjectCol(true);
                }
                return _SubjectCol;
            }
        }
        public CountryCol CountryCol
        {
            set
            {
                _CountryCol = value;
            }
            get
            {
                if (_CountryCol == null)
                {
                    _CountryCol = new CountryCol(true);
                    DataTable dtTemp = _ImageDb.GetCountry();
                    foreach (DataRow objDr in dtTemp.Rows)
                        _CountryCol.Add(new CountryBiz(objDr));
                }
                return _CountryCol;
            }
        }
        public string Path
        {
            set
            {
                _Path = value;
            }
            get
            {
                if (_Path == null || _Path == "")
                {
                    if (AttachmentBiz != null && AttachmentBiz.ID != 0)
                    {
                        _Path = AttachmentBiz.Path;
                    }
                    else
                        _Path = "";

                }

                return _Path;
            }
        }
      
        public AttachmentImageBiz AttachmentBiz
        {
            set
            {
                _Attachment = value;
            }
            get
            {
                if (_Attachment == null)
                {
                    if (_ImageDb.AttachmentID != 0)
                    {
                        _Attachment = new AttachmentImageBiz(_ImageDb.AttachmentID);
                    }
                    else
                        _Attachment = new AttachmentImageBiz();
                }
                return _Attachment;
            }
        }
        public Image Image
        {
           
            get
            {
                return AttachmentBiz.Image;
            }
        }
        ImageTypeBiz _TypeBiz;
        public ImageTypeBiz TypeBiz
        {
            get
            {
                if (_TypeBiz == null)
                    _TypeBiz = new ImageTypeBiz();
                return _TypeBiz;
            }
            set { _TypeBiz = value; }
        }
        #endregion
        #region Private Methods
        DataTable GetCountryTable()
        {
            DataTable Returned = new DataTable();
            Returned.Columns.AddRange(new DataColumn[]{new DataColumn("Country")});
            DataRow objDr;
            foreach(CountryBiz objCountryBiz in CountryCol)
            {
                objDr = Returned.NewRow();
                objDr["Country"] = objCountryBiz.ID;
                Returned.Rows.Add(objDr);

            }
            return Returned;
        }
        DataTable GetSubjectTable()
        { 
             DataTable Returned = new DataTable();
            Returned.Columns.AddRange(new DataColumn[]{new DataColumn("Subject")});
            DataRow objDr;
            foreach(SubjectBiz objSubjectBiz in SubjectCol)
            {
                objDr = Returned.NewRow();
                objDr["Subject"] = objSubjectBiz.ID;
                Returned.Rows.Add(objDr);

            }
            return Returned;
        }

        #endregion
        #region Public Methods
        public void Add()
        {
            if (Path != "")
            {
                AttachmentBiz.FilePath = Path;
                AttachmentBiz.Add();
            }
            _ImageDb.AttachmentID = _Attachment.ID;
            _ImageDb.Country = GetCountryTable();
            _ImageDb.Subject = GetSubjectTable();
            _ImageDb.Add();
 
        }
        public void Edit()
        {
            if (AttachmentBiz.Path != Path)
            {
                AttachmentBiz.Bytes = null;
                AttachmentBiz.FilePath = Path;
             
                AttachmentBiz.Edit();
            }
            _ImageDb.Country = GetCountryTable();
            _ImageDb.Subject = GetSubjectTable();
          
            _ImageDb.AttachmentID = _Attachment.ID;
            _ImageDb.Edit();
        }
        public void Delete()
        {
            _ImageDb.Delete();
        }
        #endregion
    }
}
