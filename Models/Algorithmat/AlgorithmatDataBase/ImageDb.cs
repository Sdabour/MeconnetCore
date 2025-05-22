using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.SystemBase;

namespace Algorithmat.Algorithmat.AlgorithmatDataBase
{
    public class ImageDb
    {
        #region Private Data
        /// <summary>
        /// 8 ImageID for No Image
        /// </summary>
       
        protected int _AttachmentID;
        protected DateTime _Date;
        protected DataTable _Country;
        protected DataTable _Subject;
        DataTable _PageTable;

        public DataTable PageTable
        {
            get {
                
                return _PageTable; }
            set
            {
                _PageTable = value; 
            }
        }

        #region Private Data For Search
        protected DateTime _StartDate;
        protected DateTime _EndDate;
        protected bool _IsDateRange;
        protected int _CountryID;
        protected int _SubjectID;
        protected string _IDs;
        #endregion
        #region Private Data For caching
        static DataTable _CachCellImageTable;
        static string _ImageIDs;
        #endregion
        #endregion
        #region Constructors
        public ImageDb()
        {
 
        }
        public ImageDb(DataRow objDr)
        {
            SetData(objDr);
 
        }
        public ImageDb(int intID)
        {
            _ID = intID;
            DataTable dtTemp = Search();
            if (dtTemp.Rows.Count > 0)
            {
                DataRow objDr = dtTemp.Rows[0];
                SetData(objDr);
            }
        }
        #endregion
        #region Public Properties
        protected int _ID;
        protected string _TitleA;
        protected string _Desc;
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
        public string TitleA
        {
            set
            {
                _TitleA = value;
            }
            get
            {
                return _TitleA;
            }
        }
        string _TitleE;

        public string TitleE
        {
            get { return _TitleE; }
            set { _TitleE = value; }
        }

        public string Desc
        {
            set
            {
                _Desc = value;
            }
            get
            {
                return _Desc;
            }
        }
        public DateTime Date
        {
            set
            {
                _Date = value;
            }
            get
            {
                return _Date;
            }
        }
        string _MainPath;

        public string MainPath
        {
            get { return _MainPath; }
            set { _MainPath = value; }
        }
        string _Path;

        public string Path
        {
            get { return _Path; }
            set { _Path = value; }
        }
        public string NewImagePath
        {
            get
            {
                string Returned = "";
                int intTemp = ID % FolderImageNo;
                intTemp = ID - intTemp;

                intTemp = (int)(intTemp / FolderImageNo);
                intTemp += 1;
                Path = intTemp.ToString()+ @"\"+ ID.ToString() ;
                Returned = Path;
                return Returned;
            }
        }
        int _Type;

        public int Type
        {
            get { return _Type; }
            set { _Type = value; }
        }
        bool _Changed;

        public bool Changed
        {
            get { return _Changed; }
            set { _Changed = value; }
        }
        public static int FolderImageNo
        {
            get
            {
                return 1000;
            }
        }
        int _Language;

        public int Language
        {
            get { return _Language; }
            set { _Language = value; }
        }
        public static DataTable CachCellImageTable
        {
            set
            {
                _CachCellImageTable = value;
            }
            get 
            {
                if (_CachCellImageTable == null && _ImageIDs != null && _ImageIDs != "")
                {
                    ImageDb objDb = new ImageDb();
                    _CachCellImageTable = objDb.Search();
                }
                return _CachCellImageTable;
            }
        }
        public static string ImageIDs
        {
            set
            {
                _ImageIDs = value;
            }
        }
        public string IDs
        {
            set
            {
                _IDs = value;
            }
        }
        public DataTable Country
        {
            set
            {
                _Country = value;
            }
        }
        public DataTable Subject
        {
            set
            {
                _Subject = value;
            }
        }
        public int AttachmentID
        {
            set
            {
                _AttachmentID = value;
            }
            get
            {
                return _AttachmentID;
            }
        }
        public DateTime StartDate
        {
            set
            {
                _StartDate = value;
            }
        }
        public DateTime EndDate
        {
            set
            {
                _EndDate = value;
            }
        }
        public bool IsDateRange
        {
            set
            {
                _IsDateRange = value;
            }
        }
        public int CountryID
        {
            set
            {
                _CountryID = value;
            }
        }
        public int SubjectID
        {
            set
            {
                _SubjectID = value;
            }
        }
        string _Name;

        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }
        string _SmallName;

        public string SmallName
        {
            get { return _SmallName; }
            set { _SmallName = value; }
        }
        int _Size;

        public int Size
        {
            get { return _Size; }
            set { _Size = value; }
        }
        string _SizeName;

        public string SizeName
        {
            get { return _SizeName; }
            set { _SizeName = value; }
        }
        int _SmallSize;

        public int SmallSize
        {
            get { return _SmallSize; }
            set { _SmallSize = value; }
        }
        string _SmallSizeName;

        public string SmallSizeName
        {
            get { return _SmallSizeName; }
            set { _SmallSizeName = value; }
        }
        public static string SearchStr
        {
            get
            {
                 //"SELECT     ImageID, ImageAttachment, ImageTitle, ImageDesc,ImageDate "+
                 //   " FROM  COMMONImage"
                string Returned = "";
                string strSize = "SELECT        SizeID AS ImageSizeID, SizeNameA AS ImageSizeName "+
                    " FROM            PORTALImageSize ";
                string strSmallSize = "SELECT        SizeID AS ImageSmallSizeID, SizeNameA AS ImageSmallSizeName "+
                    " FROM   PORTALImageSize ";
                Returned = "SELECT        ImageID, ImageType, ImageShortDesc, ImageTitleA, ImageTitleE"+
                    ", ImageMainPath, ImagePath ,  ImageName, ImageSmallName, ImageSize, ImageSmallSize,ImageDate"+
                    ",ImageLanguage, ImageChanged " +
                    ",ImageSizeTable.*,SmallSizeTable.*,TypeTable.* " +
                   " FROM       PORTALImage "+
                   "  left outer join ("+ strSize +")  AS ImageSizeTable  "+
                   " ON PORTALImage.ImageSize = ImageSizeTable.ImageSizeID "+
                   " left outer join (" + strSmallSize + ") AS SmallSizeTable "+
                   " ON PORTALImage.ImageSmallSize = SmallSizeTable.ImageSmallSizeID  "+
                   " LEFT OUTER JOIN   ("+ ImageTypeDb.SearchStr +") AS TypeTable "+
                   " ON PORTALImage.ImageType = TypeTable.ImageTypeID  ";
                return Returned;
            }
        }
        public string AddStr
        {
            get
            {
                double dblDate = _Date.ToOADate() - 2;
                string Returned = "insert into PORTALImage (  ImageType, ImageShortDesc, ImageTitleA, ImageTitleE"+
                    ", ImageMainPath, ImagePath,   ImageName, ImageSmallName, ImageSize, ImageSmallSize, ImageDate,ImageLanguage, UsrIns, TimIns) values(" +
                   _Type + ",'"+ _Desc  + "','" + _TitleA + "','" + _TitleE  + "','" +_MainPath +"','"+ _Path + "'"+
                   ",'" + _Name   + "','" +_SmallName + "',"+ _Size + "," +_SmallSize + ","+
                   dblDate + "," + _Language + "," + SysData.CurrentUser.ID + ",GetDate())";
                return Returned;
            }
        }
        public string EditStr
        {
            get
            {
                double dblDate = _Date.ToOADate() - 2;
                string Returned = "update PORTALImage  set  ImageType=" + _Type +
                    ", ImageShortDesc='" + _Desc + "'" +
                     ", ImageTitleA='" + _TitleA + "'" +
                     ", ImageTitleE='" + _TitleE + "'" +
                    ", ImageMainPath='" + _MainPath + "'" +
                    ", ImagePath='" + _Path + "'" +
                    ",   ImageName= '" + _Name + "'" +
                    ", ImageSmallName='" + _SmallName + "'" +
                    ", ImageSize=" + _Size +
                    ", ImageSmallSize=" + _SmallSize +
                    ",ImageLanguage="+ _Language +
                    ", ImageDate=" + dblDate +
                    ", UsrUpd=" + SysData.CurrentUser.ID + ", TimUpd=GetDate() " +
                    " where ImageID="+ _ID;
                return Returned;
            }
        }
        public string AddIdentityStr
        {
            get
            {
                string Returned = "INSERT INTO PORTALImage (ImageID) " +
                     " SELECT       " + _ID + " AS ImageID1 " +
                     " WHERE        (NOT EXISTS " +
                     " (SELECT        ImageID " +
                     " FROM            PORTALImage  " +
                     " WHERE        (ImageID = " + _ID + "))) ";
                Returned += " " + EditStr;
                return Returned;
            }
        }
        public string DeleteStr
        {
            get
            {
                string Returned = "update PORTALImage  set ImageChanged = 1, Dis=GetDate() " +
                    " where ImageID="+ _ID;;
                return Returned;
            }
        }
        string _IDsStr;

        public string IDsStr
        {
            set { _IDsStr = value; }
        }
        public string EditChangedStr
        {
            get
            {
                string Returned = "update PORTALImage  set ImageChanged = 0 " +
                    " where ImageID in(" + _IDsStr +")"; ;
                return Returned;
            }
        }

        public static string TableName
        {
            get { return "ImageTable"; }
        }
        DataTable _ImageTable;

        public DataTable ImageTable
        {
            get { return _ImageTable; }
            set { _ImageTable = value; }
        }
        #endregion
        #region Private Methods
        protected void SetData(DataRow objDr)
        {
            _ID = int.Parse(objDr["ImageID"].ToString());
            _TitleA = objDr["ImageTitleA"].ToString();
            _TitleE = objDr["ImageTitleE"].ToString();

            _Desc = objDr["ImageShortDesc"].ToString();

             
            if (objDr["ImageDate"].ToString() != "")
                _Date = DateTime.Parse(objDr["ImageDate"].ToString());
            else
                _Date = DateTime.Now;
            _Type = int.Parse(objDr["ImageType"].ToString());
            _MainPath = objDr["ImageMainPath"].ToString();
            _Path = objDr["ImagePath"].ToString();
            _Name = objDr["ImageName"].ToString();
            _SmallName = objDr["ImageSmallName"].ToString();
            _Size = int.Parse(objDr["ImageSize"].ToString());
            _SmallSize = int.Parse(objDr["ImageSmallSize"].ToString());
            _SmallSizeName = objDr["ImageSmallName"].ToString();
            _SizeName = objDr["ImageSizeName"].ToString();
            _Language = 0;
            int.TryParse(objDr["ImageLanguage"].ToString(), out _Language);

        }
        void AddEditOnWeb()
        {
           
        }
        void DeleteOnWeb()
        {
            
        }
        DataTable SearchOnWeb()
        {
            DataTable Returned = new DataTable();
          
         

            return Returned;

        }
       
        #endregion
        #region Public Methods
        public virtual void Add()
        {
            if (SysData.IsOnline)
            {
                AddEditOnWeb();
                return;
            }

            string strSql = AddStr;
           _ID = SysData.SharpVisionBaseDb.InsertIdentityTable(strSql);
           strSql = " update PORTALImage set ImagePath='"+ NewImagePath +"' "+
               " where ImageID = "+ _ID;
           SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
           JoinCountry();
           JoinSubject();
            
        }
        public virtual void Edit()
        {
            if (SysData.IsOnline)
            {
                AddEditOnWeb();
                return;
            }
            double dblDate = _Date.ToOADate() - 2;
            string strSql = EditStr;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
            JoinCountry();
            JoinSubject();
        }
        public virtual void Delete()
        {
            if (SysData.IsOnline)
            {
                DeleteOnWeb();
                return;
            }
            string strSql =DeleteStr;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
            
        }
        public virtual DataTable Search()
        {
            if (SysData.IsOnline)
            {
                return SearchOnWeb();
            }
            string strSql = SearchStr + " where (1=1) ";
            if (_ID != 0)
                strSql += " and ImageID ="+ _ID;
            if (_IDs != null && _IDs != "")
                strSql += " and ImageID in ("+_IDs+")";
            if (_TitleA != null && _TitleA != "")
                strSql += " and (ImageTitleA like '%" + _TitleA + "%' or ImageTitleE like '%"+ _TitleE +"%' ) ";
            if (_Desc != null && _Desc != "")
                strSql += " and ImageShortDesc like '%" + _Desc + "%' ";
            if (_CountryID != 0)
                strSql += " and ImageID in(select ImageID from COMMONImageCountry where CountryID = " + _CountryID + ")"; 
            if (_SubjectID != 0)
                strSql += " and ImageID in(select ImageID from COMMONImageSubject where SubjectID = " + _SubjectID + ")";
            if (_IsDateRange)
            {
                double intStartDate = SysUtility.Approximate((_StartDate.ToOADate() - 2), 1, ApproximateType.Down);
                double intEndDate = SysUtility.Approximate((_EndDate.ToOADate() - 2), 1, ApproximateType.Up);
                strSql += " and   ImageDate  >= " + intStartDate + " and ImageDate < " + intEndDate;
            }
            if (_Type != 0)
                strSql += " and ImageType = "+ _Type ;
            if (_Size != 0)
                strSql += " and ( ImageSize = " + _Size + " or ImageSmallSize ="+ _Size +" ) ";
            if (_Language != 0)
            {

                strSql += " and (ImageLanguage = " + _Language + " or ImageLanguage =0 ) ";
            }
            strSql = "select top 200 * from (" + strSql + ") as NativeTable order by NativeTable.ImageDate desc ";
            DataTable Returned = SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
          
          
            return Returned;
        }
        public DataTable GetCountry()
        {
            string strSql = CountryDb.SearchStr + " where CountryID in (select ImageCountry from COMMONImageCountry where ImageID="+ _ID +")";
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);

        }
        public DataTable GetSubject()
        {
            string strSql = SubjectDb.SearchStr + " where SubjectID in (select ImageSubject from COMMONImageSubject where ImageID=" + _ID + ")";
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        public void JoinCountry()
        {
            if (_Country == null ||_Country.Rows.Count == 0)
                return;
            string[] arrStr = new string[_Country.Rows.Count + 1];
            arrStr[0] = "delete from COMMONImageCountry where ImageID=" + _ID;
            int intIndex = 1;
            foreach (DataRow objDr in _Country.Rows)
            {
                arrStr[intIndex] = "insert into COMMONImageCountry (ImageID,ImageCountry) values("+_ID+ "," + objDr["Country"] + ")";
                intIndex++;
            }
            SysData.SharpVisionBaseDb.ExecuteNonQuery(arrStr);
 
        }
        public void JoinSubject()
        {
            if (_Subject == null || _Subject.Rows.Count==0)
                return;
            string[] arrStr = new string[_Subject.Rows.Count + 1];
            arrStr[0] = "delete from COMMONImageSubject where ImageID=" + _ID;
            int intIndex = 1;
            foreach (DataRow objDr in _Subject.Rows)
            {
                arrStr[intIndex] = "insert into COMMONImageCountry (ImageID,ImageSubject) values(" + _ID + "," + objDr["Subject"] + ")";
                intIndex++;
            }
            SysData.SharpVisionBaseDb.ExecuteNonQuery(arrStr);

        }
        #endregion
    }
}
