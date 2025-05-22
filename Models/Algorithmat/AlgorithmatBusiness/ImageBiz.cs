using System;
using System.Collections.Generic;
using System.Text;
using Algorithmat.Algorithmat.AlgorithmatDataBase;
using System.Data;
using System.Drawing;
using System.IO;
namespace Algorithmat.Algorithmat.AlgorithmatBusiness
{
    public delegate void ImageAdded();
    public class ImageBiz
    {
        #region Private Data
        protected ImageDb _ImageDb;
      
     
        protected SubjectCol _SubjectCol;
        protected CountryCol _CountryCol;
      //  protected AttachmentImageBiz _Attachment;
     
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
            _TypeBiz = new ImageTypeBiz(objDr);
            _SizeBiz = new SizeBiz();
            _SizeBiz.ID = _ImageDb.Size;
            _SizeBiz.NameA = _ImageDb.SizeName;
            _SmallBiz = new SizeBiz();
            _SmallBiz.ID = _ImageDb.SmallSize;
            _SmallBiz.NameA = _ImageDb.SmallSizeName;
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
        private ImageTypeBiz _TypeBiz;

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
        SizeBiz _SizeBiz;

        public SizeBiz SizeBiz
        {
            get {
                if (_SizeBiz == null)
                    _SizeBiz = new SizeBiz();
                return _SizeBiz; }
            set { _SizeBiz = value; }
        }
        SizeBiz _SmallBiz;

        public SizeBiz SmallBiz
        {
            get {
                if (_SmallBiz == null)
                    _SmallBiz = new SizeBiz();
                return _SmallBiz; }
            set {
 
                _SmallBiz = value; }
        }
        public string TitleA
        {
            set
            {
                _ImageDb.TitleA= value;
            }
            get
            {
                return _ImageDb.TitleA;
            }
        }
        public string TitleE
        {
            set
            {
                _ImageDb.TitleE = value;
            }
            get
            {
                return _ImageDb.TitleE;
            }
        }
        public ContentLanguage Language
        {
            get
            {
                return (ContentLanguage)_ImageDb.Language;
            }
            set
            {
                _ImageDb.Language = (int)value;
            }
        }
        public string Title
        {
            get
            {
                string Returned = "";
                if (SharpVision.SystemBase.SysData.Language == 0 && TitleA != null && TitleA != "")
                    Returned = TitleA;
                else
                    Returned = TitleE;
                return Returned;
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
        public string MainPath
        {
            set
            {
                _ImageDb.MainPath = value;
            }
            get
            {
                return _ImageDb.MainPath;
            }
        }
        public string  Path
        {
            set
            {
                _ImageDb.Path = value;
            }
            get
            {
                return _ImageDb.Path;
            }
        }
        string _ForignPath;

        public string ForignPath
        {
            get { return _ForignPath; }
            set { _ForignPath = value; }
        }
        string _ForignSmallPath;

        public string ForignSmallPath
        {
            get { return _ForignSmallPath; }
            set { _ForignSmallPath = value; }
        }

        public string FullPath
        {
            get
            {
                string Returned = ForignPath == null ? "" : ForignPath;
                string strTemp = "";
                if (ID != 0 && Name != "")
                {
                     strTemp = MainPath  + @"\" + Path +@"\"  + Name;
                }
                if (strTemp != "")
                    Returned = strTemp;
                return Returned;
            }
        }
        public string FullDirectory
        {
            get
            {
                string Returned = "";
                string strTemp = "";
                if (ID != 0)
                {
                    strTemp = MainPath + @"\" + Path + @"\" ;
                }
                if (strTemp != "")
                    Returned = strTemp;
                return Returned;
            }
        }
        public string FullSmallPath
        {
            get
            {
                string Returned = ForignSmallPath == null ? "" : ForignSmallPath;
                string strTemp = "";
                if (ID != 0 &&SmallName!= "")
                {
                    strTemp = MainPath+ @"\" + Path + @"\" + SmallName;
                }
                if (strTemp != "")
                    Returned = strTemp;
                if (Returned == "")
                    Returned = FullPath;
                return Returned;
            }
        }
        public string FullImageWebDirectory
        {
            get
            {
                string strName = Name == null || Name == "" ? SmallName : Name;
                string Returned = SharpVision.SystemBase.SysData.WebImagePath   +@"\" + Path + @"\" + strName;
                 Returned =  @"images\" + Path + @"\" + strName;
                return Returned;
            }
        }
        public string FullSmallImageWebDirectory
        {
            get
            {
                string strSmallName = SmallName == null || SmallName == "" ? Name : SmallName;
                string Returned = @"images\"+Path + @"\" +strSmallName;
                return Returned;
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
        public bool Changed
        {
            set
            {
                _ImageDb.Changed = value;
            }
            get
            {
                return _ImageDb.Changed;
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
      
        public string Name
        {
            get
            { 
                return _ImageDb.Name; 
            }
            set
            {
                _ImageDb.Name = value;
            }

        }
        public string SmallName
        {
            get
            {
                return _ImageDb.SmallName;
            }
            set
            {
                _ImageDb.SmallName = value;
            }

        }

        //public Image Image
        //{
 
        //    get
        //    {
        //       return Image.FromFile(FullPath);
        //        //return AttachmentBiz.Image;
        //    }
        //}
        //public Image SmallImage
        //{

        //    get
        //    {
        //        return Image.FromFile(FullSmallPath);
        //        //return AttachmentBiz.Image;
        //    }
        //}
        public ImageAdded NewImageAdded = new ImageAdded(OnNewImageAdded);
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
            //if (Path != "")
            //{
            //    AttachmentBiz.FilePath = Path;
            //    AttachmentBiz.Add();
            //}
            //_ImageDb.AttachmentID = _Attachment.ID;
            //_ImageDb.Country = GetCountryTable();
            //_ImageDb.Subject = GetSubjectTable();Deg
            _ImageDb.Size = SizeBiz.ID;
            _ImageDb.SmallSize = SmallBiz.ID;
            _ImageDb.Type = TypeBiz.ID;
            ImageCol objCol = new ImageCol(true);
            objCol.Add(this);
            _ImageDb.ImageTable = objCol.GetTable();
            _ImageDb.Add();
            NewImageAdded();
 
        }
        public void Edit()
        {
             
            //_ImageDb.Country = GetCountryTable();
            //_ImageDb.Subject = GetSubjectTable();
            _ImageDb.Size = SizeBiz.ID;
            _ImageDb.SmallSize = SmallBiz.ID;
            _ImageDb.Type = TypeBiz.ID;
            ImageCol objCol = new ImageCol(true);
            objCol.Add(this);
            _ImageDb.ImageTable = objCol.GetTable();
            _ImageDb.Edit();
            NewImageAdded();
        }
        public void Delete()
        {
            _ImageDb.Delete();
        }
       public static void OnNewImageAdded()
        { }
        #endregion
    }
}
