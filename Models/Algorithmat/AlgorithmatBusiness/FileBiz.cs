using System;
using System.Collections.Generic;
using System.Text;
using Algorithmat.Algorithmat.AlgorithmatDataBase;
using System.Data;
using System.Drawing;
using System.IO;
namespace Algorithmat.Algorithmat.AlgorithmatBusiness
{
    public delegate void FileAdded();
    public class FileBiz
    {
        #region Private Data
        protected FileDb _FileDb;
      
     
        protected SubjectCol _SubjectCol;
        protected CountryCol _CountryCol;
      //  protected AttachmentFileBiz _Attachment;
     
        #endregion
        #region Constructors
        public FileBiz()
        {
           
            _FileDb = new FileDb();
        }
        public FileBiz(int intID)
        {
            if (intID == 0)
                intID = 8;
            DataRow[] arrDr = new DataRow[0];
            if(FileDb.CachCellFileTable != null)
             arrDr = FileDb.CachCellFileTable.Select("FileID=" + intID);
            if (FileDb.CachCellFileTable != null && arrDr.Length > 0)
            {
                _FileDb = new FileDb(arrDr[0]);
            }
            else
              _FileDb = new FileDb(intID);
        }
        public FileBiz(DataRow objDr)
        {
            _FileDb = new FileDb(objDr);
            _TypeBiz = new FileTypeBiz(objDr);
            _SizeBiz = new SizeBiz();
            _SizeBiz.ID = _FileDb.Size;
            _SizeBiz.NameA = _FileDb.SizeName;
            _SmallBiz = new SizeBiz();
            _SmallBiz.ID = _FileDb.SmallSize;
            _SmallBiz.NameA = _FileDb.SmallSizeName;
        }
        #endregion
        #region Public Properties
        public int ID
        {
            set
            {
                _FileDb.ID = value;
            }
            get
            {
                return _FileDb.ID;
            }
        }
        private FileTypeBiz _TypeBiz;

        public FileTypeBiz TypeBiz
        {
            get
            {
                if (_TypeBiz == null)
                    _TypeBiz = new FileTypeBiz();
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
                _FileDb.TitleA= value;
            }
            get
            {
                return _FileDb.TitleA;
            }
        }
        public string TitleE
        {
            set
            {
                _FileDb.TitleE = value;
            }
            get
            {
                return _FileDb.TitleE;
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
                _FileDb.Desc = value;
            }
            get
            {
                return _FileDb.Desc;
            }
        }
        public string MainPath
        {
            set
            {
                _FileDb.MainPath = value;
            }
            get
            {
                return _FileDb.MainPath;
            }
        }
        public string  Path
        {
            set
            {
                _FileDb.Path = value;
            }
            get
            {
                return _FileDb.Path;
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
                    strTemp =MainPath + @"\" + Path + @"\" ;
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
        public string FullFileWebDirectory
        {
            get
            {
                string strName = Name == null || Name == "" ? SmallName : Name;
                string Returned = SharpVision.SystemBase.SysData.WebFilePath   +@"\" + Path + @"\" + strName;
                 //Returned =  @"file:///Files\" + Path + @"\" + strName;
                Returned = @"Files\"+ Path + @"\" + strName;
                Returned = Returned.Replace(@"\",@"/");
                return Returned;
            }
        }
        public string FullSmallFileWebDirectory
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
                _FileDb.Date = value;
            }
            get
            {
                return _FileDb.Date;
            }
        }
        public bool Changed
        {
            set
            {
                _FileDb.Changed = value;
            }
            get
            {
                return _FileDb.Changed;
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
                    DataTable dtTemp = _FileDb.GetCountry();
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
                return _FileDb.Name; 
            }
            set
            {
                _FileDb.Name = value;
            }

        }
        public string SmallName
        {
            get
            {
                return _FileDb.SmallName;
            }
            set
            {
                _FileDb.SmallName = value;
            }

        }

        
        
        public FileAdded NewFileAdded = new FileAdded(OnNewFileAdded);
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
            //_FileDb.AttachmentID = _Attachment.ID;
            //_FileDb.Country = GetCountryTable();
            //_FileDb.Subject = GetSubjectTable();
         
            _FileDb.Type = TypeBiz.ID;
            _FileDb.Add();
            NewFileAdded();
 
        }
        public void Edit()
        {
             
            //_FileDb.Country = GetCountryTable();
            //_FileDb.Subject = GetSubjectTable();
            _FileDb.Size = SizeBiz.ID;
            _FileDb.SmallSize = SmallBiz.ID;
            _FileDb.Type = TypeBiz.ID;
            _FileDb.Edit();
            NewFileAdded();
        }
        public void Delete()
        {
            _FileDb.Delete();
        }
       public static void OnNewFileAdded()
        { }
        #endregion
    }
}
