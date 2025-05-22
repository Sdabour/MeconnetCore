using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.SystemBase;
namespace SharpVision.COMMON.COMMONDataBase
{
    public class ImageDb
    {
        #region Private Data
        /// <summary>
        /// 8 ImageID for No Image
        /// </summary>
        protected int _ID;
        protected string _Title;
        protected string _Desc;
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
        public string Title
        {
            set
            {
                _Title = value;
            }
            get
            {
                return _Title;
            }
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
        public static string SearchStr
        {
            get
            {
                string Returned = "SELECT     ImageID, ImageAttachment, ImageTitle, ImageDesc,ImageDate "+
                    " FROM  COMMONImage";
                return Returned;
            }
        }
        #endregion
        #region Private Methods
        protected void SetData(DataRow objDr)
        {
            _ID = int.Parse(objDr["ImageID"].ToString());
            _Title = objDr["ImageTitle"].ToString();
            _Desc = objDr["ImageDesc"].ToString();
            _AttachmentID = int.Parse(objDr["ImageAttachment"].ToString());
            if (objDr["ImageDate"].ToString() != "")
                _Date = DateTime.Parse(objDr["ImageDate"].ToString());
            else
                _Date = DateTime.Now;
 
        }
        #endregion
        #region Public Methods
        public virtual void Add()
        {
            double dblDate = _Date.ToOADate() - 2;
            string strSql = "insert into COMMONImage (ImageAttachment, ImageTitle, ImageDesc,ImageDate, UsrIns, TimIns) values(" +
               _AttachmentID + ",'" + _Title + "','" + _Desc + "',"+ dblDate + "," + SysData.CurrentUser.ID  + ",GetDate())";
           _ID = SysData.SharpVisionBaseDb.InsertIdentityTable(strSql);
           JoinCountry();
           JoinSubject();
            
        }
        public virtual void Edit()
        {
            double dblDate = _Date.ToOADate() - 2;
            string strSql = "update COMMONImage ";
            strSql += " set ImageAttachment=" + _AttachmentID;
            strSql += ",ImageTitle='"+ _Title +"'";
            strSql += ",ImageDesc='" + _Desc + "'";
            strSql += ",ImageDate=" + dblDate + "";
            strSql += ",UsrUpd=" + SysData.CurrentUser.ID;
            strSql += ",TimUpd=GetDate() ";
            strSql += " where ImageID =" + _ID;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
            JoinCountry();
            JoinSubject();
        }
        public virtual void Delete()
        {

            string strSql = "delete from COMMONImage where ImageID=" + _ID;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
            strSql = "delete from COMMONAttachment where AttachmentID= " + _AttachmentID;
            SysData.AttachmentDb.ExecuteNonQuery(strSql);
        }
        public virtual DataTable Search()
        {
            string strSql = SearchStr + " where (1=1) ";
            if (_ID != 0)
                strSql += " and ImageID ="+ _ID;
            if (_IDs != null && _IDs != "")
                strSql += " and ImageID in ("+_IDs+")";
            if (_Title != null && _Title != "")
                strSql += " and ImageTitle like '%" + _Title + "%' ";
            if (_Desc != null && _Desc != "")
                strSql += " and ImageDesc like '%" + _Desc +"%' ";
            if (_CountryID != 0)
                strSql += " and ImageID in(select ImageID from COMMONImageCountry where CountryID = " + _CountryID + ")"; 
            if (_SubjectID != 0)
                strSql += " and ImageID in(select ImageID from COMMONImageSubject where SubjectID = " + _SubjectID + ")";
            if (_IsDateRange)
            {
                int intStartDate = (int)(_StartDate.ToOADate() - 2);
                int intEndDate = (int)(_EndDate.ToOADate() - 2)+1;
                strSql += " and CONVERT(float, ImageDate) between " + intStartDate + " and " + intEndDate;
            }

            strSql = "select top 200 * from (" + strSql + ") as NativeTable order by NativeTable.ImageDate desc ";
            DataTable Returned = SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
            string strAttachmentID = "";
            foreach (DataRow objDr in Returned.Rows)
            {
                if (objDr["ImageAttachment"].ToString() != "0" && objDr["ImageAttachment"].ToString() != "")
                {
                    if (strAttachmentID != "")
                        strAttachmentID += ",";
                    strAttachmentID += objDr["ImageAttachment"].ToString();
                }
            }
            if (strAttachmentID != "")
            {
                AttachmentFileDb.CacheAttachmentTable = null;
                AttachmentFileDb.AttachmentIDs = strAttachmentID;
            }
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
            if (_Country == null)
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
            if (_Subject == null)
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
