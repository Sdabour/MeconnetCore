using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.SystemBase;

namespace Algorithmat.Algorithmat.AlgorithmatDataBase
{
    public class FileDb
    {
        #region Private Data
        /// <summary>
        /// 8 FileID for No File
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
        static DataTable _CachCellFileTable;
        static string _FileIDs;
        #endregion
        #endregion
        #region Constructors
        public FileDb()
        {
 
        }
        public FileDb(DataRow objDr)
        {
            SetData(objDr);
 
        }
        public FileDb(int intID)
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
        public string NewFilePath
        {
            get
            {
                string Returned = "";
                int intTemp = ID % FolderFileNo;
                intTemp = ID - intTemp;

                intTemp = (int)(intTemp / FolderFileNo);
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
        public static int FolderFileNo
        {
            get
            {
                return 1000;
            }
        }
        public static DataTable CachCellFileTable
        {
            set
            {
                _CachCellFileTable = value;
            }
            get 
            {
                if (_CachCellFileTable == null && _FileIDs != null && _FileIDs != "")
                {
                    FileDb objDb = new FileDb();
                    _CachCellFileTable = objDb.Search();
                }
                return _CachCellFileTable;
            }
        }
        public static string FileIDs
        {
            set
            {
                _FileIDs = value;
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
                 //"SELECT     FileID, FileAttachment, FileTitle, FileDesc,FileDate "+
                 //   " FROM  COMMONFile"
                string Returned = "";
               
                Returned = "SELECT        FileID, FileType, FileShortDesc, FileTitleA, FileTitleE"+
                    ", FileMainPath, FilePath ,  FileName,FileDate, FileChanged " +
                    ",TypeTable.* " +
                   " FROM       PORTALFile "+
                 
                   " LEFT OUTER JOIN   ("+ FileTypeDb.SearchStr +") AS TypeTable "+
                   " ON PORTALFile.FileType = TypeTable.FileTypeID  ";
                return Returned;
            }
        }
        public string AddStr
        {
            get
            {
                double dblDate = _Date.ToOADate() - 2;
                string Returned = "insert into PORTALFile (  FileType, FileShortDesc, FileTitleA, FileTitleE"+
                    ", FileMainPath, FilePath,   FileName, FileDate, UsrIns, TimIns) values(" +
                   _Type + ",'"+ _Desc  + "','" + _TitleA + "','" + _TitleE  + "','" +_MainPath +"','"+ _Path + "'"+
                   ",'" + _Name   + "',"+
                   dblDate + "," + SysData.CurrentUser.ID + ",GetDate())";
                return Returned;
            }
        }
        public string EditStr
        {
            get
            {
                double dblDate = _Date.ToOADate() - 2;
                string Returned = "update PORTALFile  set  FileType=" + _Type +
                    ", FileShortDesc='" + _Desc + "'" +
                     ", FileTitleA='" + _TitleA + "'" +
                     ", FileTitleE='" + _TitleE + "'" +
                    ", FileMainPath='" + _MainPath + "'" +
                    ", FilePath='" + _Path + "'" +
                    ",   FileName= '" + _Name + "'" +
                    
                    ", FileDate=" + dblDate +
                    ", UsrUpd=" + SysData.CurrentUser.ID + ", TimUpd=GetDate() " +
                    " where FileID="+ _ID;
                return Returned;
            }
        }
        public string AddIdentityStr
        {
            get
            {
                string Returned = "INSERT INTO PORTALFile (FileID) " +
                     " SELECT       " + _ID + " AS FileID1 " +
                     " WHERE        (NOT EXISTS " +
                     " (SELECT        FileID " +
                     " FROM            PORTALFile  " +
                     " WHERE        (FileID = " + _ID + "))) ";
                Returned += " " + EditStr;
                return Returned;
            }
        }
        public string DeleteStr
        {
            get
            {
                string Returned = "update PORTALFile  set FileChanged = 1, Dis=GetDate() " +
                    " where FileID="+ _ID;;
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
                string Returned = "update PORTALFile  set FileChanged = 0 " +
                    " where FileID in(" + _IDsStr +")"; ;
                return Returned;
            }
        }
        DataTable _FileTable;

        public DataTable FileTable
        {
            get { return _FileTable; }
            set { _FileTable = value; }
        }
        public static string TableName
        {
            get {
                return "FileTable";
            }
        }
        #endregion
        #region Private Methods
        protected void SetData(DataRow objDr)
        {
            _ID = int.Parse(objDr["FileID"].ToString());
            _TitleA = objDr["FileTitleA"].ToString();
            _TitleE = objDr["FileTitleE"].ToString();

            _Desc = objDr["FileShortDesc"].ToString();

             
            if (objDr["FileDate"].ToString() != "")
                _Date = DateTime.Parse(objDr["FileDate"].ToString());
            else
                _Date = DateTime.Now;
            _Type = int.Parse(objDr["FileType"].ToString());
            _MainPath = objDr["FileMainPath"].ToString();
            _Path = objDr["FilePath"].ToString();
            _Name = objDr["FileName"].ToString();
            


        }
        void AddEditOnWeb()
        {
           

            DataSet dsTemp = new DataSet();
            dsTemp.Tables.Add(FileTable);


            _ID = 0;
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
           strSql = " update PORTALFile set FilePath='"+ NewFilePath +"' "+
               " where FileID = "+ _ID;
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
                strSql += " and FileID ="+ _ID;
            if (_IDs != null && _IDs != "")
                strSql += " and FileID in ("+_IDs+")";
            if (_TitleA != null && _TitleA != "")
                strSql += " and (FileTitleA like '%" + _TitleA + "%' or FileTitleE like '%"+ _TitleE +"%' ) ";
            if (_Desc != null && _Desc != "")
                strSql += " and FileShortDesc like '%" + _Desc + "%' ";
            if (_CountryID != 0)
                strSql += " and FileID in(select FileID from COMMONFileCountry where CountryID = " + _CountryID + ")"; 
            if (_SubjectID != 0)
                strSql += " and FileID in(select FileID from COMMONFileSubject where SubjectID = " + _SubjectID + ")";
            if (_IsDateRange)
            {
                double intStartDate = SysUtility.Approximate((_StartDate.ToOADate() - 2),1,ApproximateType.Down);
                double intEndDate = SysUtility.Approximate((_EndDate.ToOADate() - 2), 1, ApproximateType.Up);
                strSql += " and  FileDate >= " + intStartDate + " and FileDate < " + intEndDate;
            }
            if (_Type != 0)
                strSql += " and FileType = "+ _Type ;
           
            strSql = "select top 200 * from (" + strSql + ") as NativeTable order by NativeTable.FileDate desc ";
            DataTable Returned = SysData.SharpVisionBaseDb.ReturnDatatable(strSql,TableName);
          
          
            return Returned;
        }
        public DataTable GetCountry()
        {
            string strSql = CountryDb.SearchStr + " where CountryID in (select FileCountry from COMMONFileCountry where FileID="+ _ID +")";
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);

        }
        public DataTable GetSubject()
        {
            string strSql = SubjectDb.SearchStr + " where SubjectID in (select FileSubject from COMMONFileSubject where FileID=" + _ID + ")";
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        public void JoinCountry()
        {
            if (_Country == null ||_Country.Rows.Count == 0)
                return;
            string[] arrStr = new string[_Country.Rows.Count + 1];
            arrStr[0] = "delete from COMMONFileCountry where FileID=" + _ID;
            int intIndex = 1;
            foreach (DataRow objDr in _Country.Rows)
            {
                arrStr[intIndex] = "insert into COMMONFileCountry (FileID,FileCountry) values("+_ID+ "," + objDr["Country"] + ")";
                intIndex++;
            }
            SysData.SharpVisionBaseDb.ExecuteNonQuery(arrStr);
 
        }
        public void JoinSubject()
        {
            if (_Subject == null || _Subject.Rows.Count==0)
                return;
            string[] arrStr = new string[_Subject.Rows.Count + 1];
            arrStr[0] = "delete from COMMONFileSubject where FileID=" + _ID;
            int intIndex = 1;
            foreach (DataRow objDr in _Subject.Rows)
            {
                arrStr[intIndex] = "insert into COMMONFileCountry (FileID,FileSubject) values(" + _ID + "," + objDr["Subject"] + ")";
                intIndex++;
            }
            SysData.SharpVisionBaseDb.ExecuteNonQuery(arrStr);

        }
        #endregion
    }
}
