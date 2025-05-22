using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SharpVision.Base.BaseDataBase;
 
using System.Data;
using SharpVision.UMS.UMSBusiness;
using SharpVision.SystemBase;


namespace Algorithmat.Algorithmat.AlgorithmatDataBase
{
    public class PageDb
    {
        #region Private Data
        int _ID;

        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
        string _Desc;

        public string Desc
        {
            get { return _Desc; }
            set { _Desc = value; }
        }
        string _TitleA;

        public string TitleA
        {
            get { return _TitleA; }
            set { _TitleA = value; }
        }
        string _TitleE;

        public string TitleE
        {
            get { return _TitleE; }
            set { _TitleE = value; }
        }
        string _URLA;

        public string URLA
        {
            get { return _URLA; }
            set { _URLA = value; }
        }
        string _URLE;

        public string URLE
        {
            get { return _URLE; }
            set { _URLE = value; }
        }
        bool _IsStoped;

        public bool IsStoped
        {
            get { return _IsStoped; }
            set { _IsStoped = value; }
        }
        bool _IsChanged;

        public bool IsChanged
        {
            get { return _IsChanged; }
            set { _IsChanged = value; }
        }
        DataTable _PageTable;

        public DataTable PageTable
        {
            get { return _PageTable; }
            set { _PageTable = value; }
        }
        DataTable _LocationTable;

        public DataTable LocationTable
        {
            get { return _LocationImageTable; }
            set { _LocationTable = value; }
        }
        DataTable _DeletedLocationTable;

        public DataTable DeletedLocationTable
        {
            get { return _DeletedLocationTable; }
            set { _DeletedLocationTable = value; }
        }
        DataTable _LocationImageTable;

        public DataTable LocationImageTable
        {
            get { return _LocationImageTable; }
            set { _LocationImageTable = value; }
        }
        DataTable _SubTable;

        public DataTable SubTable
        {
          
            set { _SubTable = value; }
        }
        DataTable _ParagraphTable;

        public DataTable ParagraphTable
        {
            
            set { _ParagraphTable = value; }
        }
        DataTable _ParagraphImageTable;

        public DataTable ParagraphImageTable
        {
            get { return _ParagraphImageTable; }
            set { _ParagraphImageTable = value; }
        }
        DataTable _ImageTable;

        public DataTable ImageTable
        {
            get { return _ImageTable; }
            set { _ImageTable = value; }
        }
        static DataTable _CacheLocationTable;

        public static DataTable CacheLocationTable
        {
            get { return PageDb._CacheLocationTable; }
            set { PageDb._CacheLocationTable = value; }
        }
        static DataTable _CacheLocationImageTable;

        public static DataTable CacheLocationImageTable
        {
            get { return PageDb._CacheLocationImageTable; }
            set { PageDb._CacheLocationImageTable = value; }
        }
        static DataTable _CachePageImageTable;

        public static DataTable CachePageImageTable
        {
            get { return PageDb._CachePageImageTable; }
            set { PageDb._CachePageImageTable = value; }
        }
        public static string TableName
        {
            get { return "PageTable"; }
        }
        #endregion
        #region Constructors
        public PageDb()
        { }
        public PageDb(DataRow objDr)
        {
            SetData(objDr);
        }
        #endregion
        #region Public Properties
     
        public string AddStr
        {
            get
            {
                int intIsStopped = _IsStoped ? 1 : 0;
                
                string Returned = "insert into PORTALPage (PageDesc, PageTitleA, PageTitleE, PageURLA, PageURLE, PageIsStoped"+
                    ", UsrIns, TimIns) "+
                    " values ('" + _Desc +"','" + _TitleA + "','"+ _TitleE + "','"+ _URLA + "','"+
                    _URLE + "',"+ intIsStopped + "," + SysData.CurrentUser.ID  +",GetDate()) ";
                return Returned;
            }
        }
        public string EditStr
        {
            get
            {
                 int intIsStopped = _IsStoped ? 1 : 0;
                string Returned = "update PORTALPage  "+
                    " set  PageDesc ='"+ _Desc +"'"+
                    ", PageTitleA='"+ _TitleA +"'"+
                    ", PageTitleE='"+ _TitleE +"'"+
                    ", PageURLA='" +_URLA + "'"+
                    ", PageURLE='"+ _URLE +"'"+
                    ", PageIsStoped="+ intIsStopped +
                    ", PageIsChanged=1"+
                    ", UsrUpd="+  SysData.CurrentUser.ID+
                    ", TimUpd=GetDate() "+
                    " where PageID ="+_ID;
                return Returned;
            }
        }
        public string AddIdentityStr
        {
            get
            {
                string Returned = "INSERT INTO PORTALPage (PageID) " +
                     " SELECT       " + _ID + " AS PageID1 " +
                     " WHERE        (NOT EXISTS " +
                     " (SELECT        PageID " +
                     " FROM            PORTALPage  " +
                     " WHERE        (PageID = " + _ID + "))) ";
                Returned += " " + EditStr;
                return Returned;
            }
        }
        public string DeleteStr
        {
            get
            {
                string Returned = "update PORTALPage  " +
                  " set  PageIsChanged= 1 ,Dis=GetDate() " +
                  " where PageID =" + _ID;
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
                string Returned = "update PORTALPage  " +
                  " set  PageIsChanged= 0 " +
                  " where PageID in (" + _IDsStr + ") ";
                return Returned;
            }
        }
        public static string SearchStr
        {
            get
            {
                string Returned = "SELECT        PageID,PageDesc, PageTitleA, PageTitleE, PageURLA, PageURLE, PageIsStoped, PageIsChanged "+
                    " FROM            PORTALPage ";
                return Returned;
            }
        }
        #endregion
        #region Private Methods
        void SetData(DataRow objDr)
        {
            _ID = int.Parse(objDr["PageID"].ToString());
            _Desc = objDr["PageDesc"].ToString();
            _TitleA = objDr["PageTitleA"].ToString();
            _TitleE = objDr["PageTitleE"].ToString();
            _URLA = objDr["PageURLA"].ToString();
            _URLE = objDr["PageURLE"].ToString();
            _IsStoped = bool.Parse( objDr["PageIsStoped"].ToString() );
            _IsChanged = bool.Parse(objDr["PageIsChanged"].ToString());

        }
        void AddEditOnWeb()
        {
          
        }
        void DeleteOnWeb()
        {
          
        }
        DataTable SearchWeb()
        {
            DataTable Returned = new DataTable();
           

            return Returned;

        }
        #endregion
        #region Public Methods
        public void Add()
        {
            if (SysData.IsOnline)
            {
                AddEditOnWeb();
                return;
            }
            string strSql = AddStr;
           _ID =  SysData.SharpVisionBaseDb.InsertIdentityTable(strSql);
            JoinLocation();
            //JoinSub();
            JoinImage();
        }
        public void Edit()
        {
            if (SysData.IsOnline)
            {
                AddEditOnWeb();
                return;
            }
            string strSql = EditStr;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
            JoinLocation();
            JoinImage();
            //JoinSub();
        }
        public void Delete()
        {
              if (SysData.IsOnline)
            {
                AddEditOnWeb();
                return;
            }
            string strSql = DeleteStr;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public DataTable Search()
        {
            if (SysData.IsOnline)
            {
                return SearchWeb();
            }

            string strSql = SearchStr + " where Dis is null ";
            if (_ID != 0)
                strSql += " and PageID="+_ID;
            if (_Desc != null && _Desc != "")
                strSql += " and PageDesc like '%"+ _Desc +"%' ";
            if (_TitleA != null && _TitleA != "")
                strSql += " and (PageTitleA like '%" + _TitleA + "%' or PageTitleE like '%"+ _TitleA +"%')";
            if (_URLA != null && _URLA != "")
                strSql += " and (PageURLA like '%" + _TitleA + "%' or PageURLE like '%" + _TitleA + "%')";
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql,PageDb.TableName);
        }
        public void JoinLocation()
        {
            if (_LocationTable == null)
                return;
            LocationDb objLocationDb;
            LocationImageDb objImageDb ;
            DataRow[] arrImgDr;
            List<string> arrStr = new List<string>();
            foreach (DataRow objDr in _LocationTable.Rows)
            {
                 arrStr = new List<string>();
                objLocationDb = new LocationDb(objDr);
                objLocationDb.PageID = ID;
                if (objLocationDb.ID == 0)
                    objLocationDb.Add();
                else
                    arrStr.Add(objLocationDb.EditStr);

                arrImgDr = _LocationImageTable.Select("SecondaryLocation=" + objLocationDb.SecondaryLocation);

               
                arrStr.Add("Delete from PORTALLocationImage where LocationID = "+objLocationDb.ID);
                foreach (DataRow objImgDr in arrImgDr)
                {
                   objImageDb= new LocationImageDb(objImgDr);
                    objImageDb.LocationID = objLocationDb.ID;
                    arrStr.Add(objImageDb.AddStr);
                }
                SysData.SharpVisionBaseDb.ExecuteNonQuery(arrStr);

            }
           // SysData.SharpVisionBaseDb.ExecuteNonQuery(arrStr);
            if (_DeletedLocationTable != null && _DeletedLocationTable.Rows.Count > 0)
            {
                arrStr = new List<string>();
                
                foreach (DataRow objDr in _DeletedLocationTable.Rows)
                {
                    objLocationDb = new LocationDb(objDr);
                    if (objLocationDb.ID != 0)
                        arrStr.Add(objLocationDb.DeleteStr);
                }
                SysData.SharpVisionBaseDb.ExecuteNonQuery(arrStr);
            }
        }
        public void JoinImage()
        {
            List<string> arrStr = new List<string>();
            arrStr.Add("delete FROM  dbo.PORTALPageImage WHERE        (PageID = "+ ID +")");

            PageImageDb objDb;
            foreach (DataRow objDr in _ImageTable.Rows)
            {
                objDb = new PageImageDb(objDr);
                objDb.PageID = ID;
                arrStr.Add(objDb.AddStr);
            }
            SysData.SharpVisionBaseDb.ExecuteNonQuery(arrStr);
        }
        public static DataSet CollectChangedData()
        {
            string strSql = "";
            DataSet Returned = new DataSet();
            //1 size 
            strSql = SizeDb.SearchStr + " where Dis is null and SizeChanged =1 ";
            DataTable dtTemp = SysData.SharpVisionBaseDb.ReturnDatatable(SearchStr, "Size");
            Returned.Tables.Add(dtTemp);
            strSql = SizeDb.SearchStr + " where Dis is not null and SizeChanged =1 ";
            dtTemp = SysData.SharpVisionBaseDb.ReturnDatatable(SearchStr, "SizeDeleted");
            Returned.Tables.Add(dtTemp);
            //2 ContentType
            strSql = ContentTypeDb.SearchStr + " where ContentTypeChanged = 1 and Dis is null ";
            dtTemp = SysData.SharpVisionBaseDb.ReturnDatatable(strSql, "ContentType");
            Returned.Tables.Add(dtTemp);
            strSql = ContentTypeDb.SearchStr + " where ContentTypeChanged = 1 and Dis is not null ";
            dtTemp = SysData.SharpVisionBaseDb.ReturnDatatable(strSql, "ContentTypeDeleted");
            Returned.Tables.Add(dtTemp);
            //3 ImageType
            strSql = ImageTypeDb.SearchStr + " where ImageTypeChanged = 1  and Dis is null ";
            dtTemp = SysData.SharpVisionBaseDb.ReturnDatatable(strSql, "ImageType");
            Returned.Tables.Add(dtTemp);
            strSql = ImageTypeDb.SearchStr + " where ImageTypeChanged = 1  and Dis is not null ";
            dtTemp = SysData.SharpVisionBaseDb.ReturnDatatable(strSql, "ImageTypeDeleted");
            Returned.Tables.Add(dtTemp);
            //7 Image
            strSql = ImageDb.SearchStr + " where ImageChanged = 1  and Dis is null ";
            dtTemp = SysData.SharpVisionBaseDb.ReturnDatatable(strSql, "Image");
            Returned.Tables.Add(dtTemp);
            strSql = ImageDb.SearchStr + " where ImageChanged = 1  and Dis is not null ";
            dtTemp = SysData.SharpVisionBaseDb.ReturnDatatable(strSql, "ImageDeleted");
            Returned.Tables.Add(dtTemp);

            //4 FileType
            strSql = FileTypeDb.SearchStr + " where FileTypeChanged = 1  and Dis is null ";
            dtTemp = SysData.SharpVisionBaseDb.ReturnDatatable(strSql, "FileType");
            Returned.Tables.Add(dtTemp);
            strSql = FileTypeDb.SearchStr + " where FileTypeChanged = 1  and Dis is not null ";
            dtTemp = SysData.SharpVisionBaseDb.ReturnDatatable(strSql, "FileTypeDeleted");
            Returned.Tables.Add(dtTemp);

            //5 File
            strSql = FileDb.SearchStr + " where PARAGRAPHChanged = 1 and Dis is null ";
            dtTemp = SysData.SharpVisionBaseDb.ReturnDatatable(strSql, "File");
            Returned.Tables.Add(dtTemp);
            strSql = FileDb.SearchStr + " where PARAGRAPHChanged = 1 and Dis is not null ";
            dtTemp = SysData.SharpVisionBaseDb.ReturnDatatable(strSql, "FileDeleted");
            Returned.Tables.Add(dtTemp);

            //6 Paragraph
            strSql = ParagraphDb.SearchStr + " where PARAGRAPHChanged = 1 and Dis is null ";
            dtTemp = SysData.SharpVisionBaseDb.ReturnDatatable(strSql, "Paragraph");
            Returned.Tables.Add(dtTemp);
            strSql = ParagraphDb.SearchStr + " where PARAGRAPHChanged = 1 and Dis is not null ";
            dtTemp = SysData.SharpVisionBaseDb.ReturnDatatable(strSql, "ParagraphDeleted");
            Returned.Tables.Add(dtTemp);
            //13 ParagraphImage
            List<string> arrStr = SysUtility.GetStringArr(dtTemp, "ParagraphID", 5000);
            if (arrStr.Count > 0 && arrStr[0] != null && arrStr[0] != "")
            {
                strSql = ParagraphImageDb.SearchStr + " where ParagraphID  in ("+ arrStr[0] +") ";
                dtTemp = SysData.SharpVisionBaseDb.ReturnDatatable(strSql, "ParagraphImage");
                Returned.Tables.Add(dtTemp);
            }
            //7 Sub
            strSql = SUBDb.SearchStr + " where SUBChanged = 1  and Dis is null ";
            dtTemp = SysData.SharpVisionBaseDb.ReturnDatatable(strSql, "SUB");
            Returned.Tables.Add(dtTemp);
            strSql = SUBDb.SearchStr + " where SUBChanged = 1  and Dis is not null ";
            dtTemp = SysData.SharpVisionBaseDb.ReturnDatatable(strSql, "SUBDeleted");
            Returned.Tables.Add(dtTemp);
            //8 Content
            strSql = ContentDb.SearchStr + " where ContentChanged = 1 and Dis is null ";
            dtTemp = SysData.SharpVisionBaseDb.ReturnDatatable(strSql, "CONTENT");
            Returned.Tables.Add(dtTemp);
            strSql = ContentDb.SearchStr + " where ContentChanged = 1 and Dis is not null ";
            dtTemp = SysData.SharpVisionBaseDb.ReturnDatatable(strSql, "CONTENTDeleted");
            Returned.Tables.Add(dtTemp);
            
            //10 Location
            strSql = LocationDb.SearchStr + " where LocationChanged = 1 and Dis is null ";
            dtTemp = SysData.SharpVisionBaseDb.ReturnDatatable(strSql, "LOCATION");
            Returned.Tables.Add(dtTemp);
            strSql = LocationDb.SearchStr + " where LocationChanged = 1 and Dis is not null ";
            dtTemp = SysData.SharpVisionBaseDb.ReturnDatatable(strSql, "LOCATIONDeleted");
            Returned.Tables.Add(dtTemp);

            //11 LocationImage
            arrStr = SysUtility.GetStringArr(dtTemp, "LocationID", 5000);
            if (arrStr.Count > 0 && arrStr[0] != null && arrStr[0] != "")
            {
                strSql = LocationImageDb.SearchStr + " where LocationID  in (" + arrStr[0] + ") ";
                dtTemp = SysData.SharpVisionBaseDb.ReturnDatatable(strSql, "LOCATIONImage");
                Returned.Tables.Add(dtTemp);
            }
            //12 Page
            strSql = PageDb.SearchStr + " where PageIsChanged = 1 and Dis is null ";
            dtTemp = SysData.SharpVisionBaseDb.ReturnDatatable(strSql, "PAGE");
            Returned.Tables.Add(dtTemp);
            strSql = PageDb.SearchStr + " where PageIsChanged = 1 and Dis is not null ";
            dtTemp = SysData.SharpVisionBaseDb.ReturnDatatable(strSql, "PAGEDeleted");
            Returned.Tables.Add(dtTemp);
            return Returned;
        }
        /*
         * Size
ContentType
ImageType
Image
  filetype
         file
Paragraph
ParagraphImage
SUB
CONTENT
LOCATION
LOCATIONImage
PAGE
         */
        public static bool UploadData(DataSet dsTemp)
        {
            bool Returned = true;
            DataTable dtTemp;
            List<string> arrStr = new List<string>();
            if (dsTemp.Tables["Size"] != null)
            {
                dtTemp = dsTemp.Tables["Size"];
                SizeDb objSizeDb;
                foreach (DataRow objDr in dtTemp.Rows)
                {
                    objSizeDb = new SizeDb(objDr);
                    arrStr.Add(objSizeDb.AddIdentityStr);
                }
 
            }
            if (dsTemp.Tables["SizeDeleted"] != null)
            {
                dtTemp = dsTemp.Tables["SizeDeleted"];
                SizeDb objSizeDb;
                foreach (DataRow objDr in dtTemp.Rows)
                {
                    objSizeDb = new SizeDb(objDr);
                    arrStr.Add(objSizeDb.DeleteStr);
                }

            }
            //ContentType
            if (dsTemp.Tables["ContentType"] != null)
            {
                dtTemp = dsTemp.Tables["ContentType"];
                ContentTypeDb objContentTypeDb;
                foreach (DataRow objDr in dtTemp.Rows)
                {
                    objContentTypeDb = new ContentTypeDb(objDr);
                    arrStr.Add(objContentTypeDb.AddIdentityStr);
                }

            }
            if (dsTemp.Tables["ContentTypeDeleted"] != null)
            {
                dtTemp = dsTemp.Tables["ContentTypeDeleted"];
                ContentTypeDb objContentTypeDb;
                foreach (DataRow objDr in dtTemp.Rows)
                {
                    objContentTypeDb = new ContentTypeDb(objDr);
                    arrStr.Add(objContentTypeDb.DeleteStr);
                }

            }
            //IMageType
            if (dsTemp.Tables["ImageType"] != null)
            {
                dtTemp = dsTemp.Tables["ImageType"];
                ImageTypeDb objImageTypeDb;
                foreach (DataRow objDr in dtTemp.Rows)
                {
                    objImageTypeDb = new ImageTypeDb(objDr);
                    arrStr.Add(objImageTypeDb.AddIdentityStr);
                }

            }
            if (dsTemp.Tables["ImageTypeDeleted"] != null)
            {
                dtTemp = dsTemp.Tables["ImageTypeDeleted"];
                ImageTypeDb objImageTypeDb;
                foreach (DataRow objDr in dtTemp.Rows)
                {
                    objImageTypeDb = new ImageTypeDb(objDr);
                    arrStr.Add(objImageTypeDb.DeleteStr);
                }

            }
            if(arrStr.Count>0)
            SysData.SharpVisionBaseDb.ExecuteNonQuery(arrStr);
            arrStr = new List<string>();
            //Image 
            if (dsTemp.Tables["Image"] != null)
            {
                dtTemp = dsTemp.Tables["Image"];
                ImageDb objImageDb;
                foreach (DataRow objDr in dtTemp.Rows)
                {
                    objImageDb = new ImageDb(objDr);
                    arrStr.Add(objImageDb.AddIdentityStr);
                }

            }
            if (dsTemp.Tables["ImageDeleted"] != null)
            {
                dtTemp = dsTemp.Tables["ImageDeleted"];
                ImageDb objImageDb;
                foreach (DataRow objDr in dtTemp.Rows)
                {
                    objImageDb = new ImageDb(objDr);
                    arrStr.Add(objImageDb.DeleteStr);
                }

            }
            if (arrStr.Count > 0)
                SysData.SharpVisionBaseDb.ExecuteNonQuery(arrStr);
            arrStr = new List<string>();

            //FileType
            if (dsTemp.Tables["FileType"] != null)
            {
                dtTemp = dsTemp.Tables["FileType"];
                FileTypeDb objFileTypeDb;
                foreach (DataRow objDr in dtTemp.Rows)
                {
                    objFileTypeDb = new FileTypeDb(objDr);
                    arrStr.Add(objFileTypeDb.AddIdentityStr);
                }

            }
            if (dsTemp.Tables["FileTypeDeleted"] != null)
            {
                dtTemp = dsTemp.Tables["FileTypeDeleted"];
                FileTypeDb objFileTypeDb;
                foreach (DataRow objDr in dtTemp.Rows)
                {
                    objFileTypeDb = new FileTypeDb(objDr);
                    arrStr.Add(objFileTypeDb.DeleteStr);
                }

            }
            if (arrStr.Count > 0)
                SysData.SharpVisionBaseDb.ExecuteNonQuery(arrStr);
            arrStr = new List<string>();
            //File 
            if (dsTemp.Tables["File"] != null)
            {
                dtTemp = dsTemp.Tables["File"];
                FileDb objFileDb;
                foreach (DataRow objDr in dtTemp.Rows)
                {
                    objFileDb = new FileDb(objDr);
                    arrStr.Add(objFileDb.AddIdentityStr);
                }

            }
            if (dsTemp.Tables["FileDeleted"] != null)
            {
                dtTemp = dsTemp.Tables["FileDeleted"];
                FileDb objFileDb;
                foreach (DataRow objDr in dtTemp.Rows)
                {
                    objFileDb = new FileDb(objDr);
                    arrStr.Add(objFileDb.DeleteStr);
                }

            }
            if (arrStr.Count > 0)
                SysData.SharpVisionBaseDb.ExecuteNonQuery(arrStr);
            arrStr = new List<string>();

            //Paragraph
            if (dsTemp.Tables["Paragraph"] != null)
            {
                dtTemp = dsTemp.Tables["Paragraph"];
                ParagraphDb objParagraphDb;
                foreach (DataRow objDr in dtTemp.Rows)
                {
                    objParagraphDb = new ParagraphDb(objDr);
                    arrStr.Add(objParagraphDb.AddIdentityStr);
                }
                List<string> arrStr1 = SysUtility.GetStringArr(dtTemp, "PARAGRAPHID", 5000);
                if (arrStr1.Count > 0)
                {
                    arrStr.Add("delete from PORTALParagraphImage WHERE        (ParagraphID IN ("+arrStr1[0] +")) ");
                }
                if (dsTemp.Tables["ParagraphImage"] != null)
                {
                    dtTemp = dsTemp.Tables["ParagraphImage"];
                    ParagraphImageDb objParagraphImageDb;
                    foreach (DataRow objDr in dtTemp.Rows)
                    {
                        objParagraphImageDb = new ParagraphImageDb(objDr);
                        arrStr.Add(objParagraphImageDb.AddStr);
                    }

                }
            }
            
            if (dsTemp.Tables["ParagraphDeleted"] != null)
            {
                dtTemp = dsTemp.Tables["ParagraphDeleted"];
                ParagraphDb objParagraphDb;
                foreach (DataRow objDr in dtTemp.Rows)
                {
                    objParagraphDb = new ParagraphDb(objDr);
                    arrStr.Add(objParagraphDb.DeleteStr);
                }

            }
            if (arrStr.Count > 0)
                SysData.SharpVisionBaseDb.ExecuteNonQuery(arrStr);
            //SUB
            arrStr = new List<string>();
            if (dsTemp.Tables["SUB"] != null)
            {
                dtTemp = dsTemp.Tables["SUB"];
                SUBDb objSUBDb;
                foreach (DataRow objDr in dtTemp.Rows)
                {
                    objSUBDb = new SUBDb(objDr);
                    arrStr.Add(objSUBDb.AddIdentityStr);
                }

            }
            if (dsTemp.Tables["SUBDeleted"] != null)
            {
                dtTemp = dsTemp.Tables["SUBDeleted"];
                SUBDb objSUBDb;
                foreach (DataRow objDr in dtTemp.Rows)
                {
                    objSUBDb = new SUBDb(objDr);
                    arrStr.Add(objSUBDb.DeleteStr);
                }

            }
            //content
            if (dsTemp.Tables["CONTENT"] != null)
            {
                dtTemp = dsTemp.Tables["CONTENT"];
                ContentDb objCONTENTDb;
                foreach (DataRow objDr in dtTemp.Rows)
                {
                    objCONTENTDb = new ContentDb(objDr);
                    arrStr.Add(objCONTENTDb.AddIdentityStr);
                }

            }
            if (dsTemp.Tables["CONTENTDeleted"] != null)
            {
                dtTemp = dsTemp.Tables["CONTENTDeleted"];
                ContentDb objCONTENTDb;
                foreach (DataRow objDr in dtTemp.Rows)
                {
                    objCONTENTDb = new ContentDb(objDr);
                    arrStr.Add(objCONTENTDb.DeleteStr);
                }

            }
            if (arrStr.Count > 0)
                SysData.SharpVisionBaseDb.ExecuteNonQuery(arrStr);

            //Location
            arrStr = new List<string>();
            if (dsTemp.Tables["Location"] != null)
            {
                dtTemp = dsTemp.Tables["Location"];
                LocationDb objLocationDb;
                foreach (DataRow objDr in dtTemp.Rows)
                {
                    objLocationDb = new LocationDb(objDr);
                    arrStr.Add(objLocationDb.AddIdentityStr);
                }
                List<string> arrStr1 = SysUtility.GetStringArr(dtTemp, "LocationID", 5000);
                if (arrStr1.Count > 0)
                {
                    arrStr.Add("delete from PORTALLocationImage WHERE        (LocationID IN (" + arrStr1[0] + ")) ");
                }
                if (dsTemp.Tables["LocationImage"] != null)
                {
                    dtTemp = dsTemp.Tables["LocationImage"];
                    LocationImageDb objLocationImageDb;
                    foreach (DataRow objDr in dtTemp.Rows)
                    {
                        objLocationImageDb = new LocationImageDb(objDr);
                        arrStr.Add(objLocationImageDb.AddStr);
                    }

                }
            }

            if (dsTemp.Tables["LocationDeleted"] != null)
            {
                dtTemp = dsTemp.Tables["LocationDeleted"];
                LocationDb objLocationDb;
                foreach (DataRow objDr in dtTemp.Rows)
                {
                    objLocationDb = new LocationDb(objDr);
                    arrStr.Add(objLocationDb.DeleteStr);
                }

            }
            if (arrStr.Count > 0)
                SysData.SharpVisionBaseDb.ExecuteNonQuery(arrStr);

            //Page
            if (dsTemp.Tables["PAGE"] != null)
            {
                dtTemp = dsTemp.Tables["PAGE"];
                PageDb objPAGEDb;
                foreach (DataRow objDr in dtTemp.Rows)
                {
                    objPAGEDb = new PageDb(objDr);
                    arrStr.Add(objPAGEDb.AddIdentityStr);
                }

            }
            if (dsTemp.Tables["PAGEDeleted"] != null)
            {
                dtTemp = dsTemp.Tables["PAGEDeleted"];
                PageDb objPAGEDb;
                foreach (DataRow objDr in dtTemp.Rows)
                {
                    objPAGEDb = new PageDb(objDr);
                    arrStr.Add(objPAGEDb.DeleteStr);
                }

            }
            if (arrStr.Count > 0)
                SysData.SharpVisionBaseDb.ExecuteNonQuery(arrStr);

            return Returned;
        }
        public static void SetUploaded(DataSet dsTemp)
        {
            DataTable dtTemp;
            List<string> arrStr = new List<string>();
            if (dsTemp.Tables["Size"] != null)
            {
                dtTemp = dsTemp.Tables["Size"];
                SizeDb objSizeDb;
                arrStr = SysUtility.GetStringArr(dtTemp, "SizeID", 5000);
                if (arrStr.Count > 0 && arrStr[0] != "")
                {
                    objSizeDb = new SizeDb();
                    objSizeDb.IDsStr = arrStr[0];
                    SysData.SharpVisionBaseDb.ExecuteNonQuery(objSizeDb.EditChangedStr);
                }

            }
            if (dsTemp.Tables["SizeDeleted"] != null)
            {
                dtTemp = dsTemp.Tables["SizeDeleted"];
                SizeDb objSizeDb;
                arrStr = SysUtility.GetStringArr(dtTemp, "SizeID", 5000);
                if (arrStr.Count > 0 && arrStr[0] != "")
                {
                    objSizeDb = new SizeDb();
                    objSizeDb.IDsStr = arrStr[0];
                    SysData.SharpVisionBaseDb.ExecuteNonQuery(objSizeDb.EditChangedStr);
                }

            }
            //ContentType
            if (dsTemp.Tables["ContentType"] != null)
            {
                dtTemp = dsTemp.Tables["ContentType"];
                ContentTypeDb objContentTypeDb;
                arrStr = SysUtility.GetStringArr(dtTemp, "ContentTypeID", 5000);
                if (arrStr.Count > 0 && arrStr[0] != "")
                {
                    objContentTypeDb = new ContentTypeDb();
                    objContentTypeDb.IDsStr = arrStr[0];
                    SysData.SharpVisionBaseDb.ExecuteNonQuery(objContentTypeDb.EditChangedStr);
                }

            }
            if (dsTemp.Tables["ContentTypeDeleted"] != null)
            {
                dtTemp = dsTemp.Tables["ContentTypeDeleted"];
                ContentTypeDb objContentTypeDb;
                arrStr = SysUtility.GetStringArr(dtTemp, "ContentTypeID", 5000);
                if (arrStr.Count > 0 && arrStr[0] != "")
                {
                    objContentTypeDb = new ContentTypeDb();
                    objContentTypeDb.IDsStr = arrStr[0];
                    SysData.SharpVisionBaseDb.ExecuteNonQuery(objContentTypeDb.EditChangedStr);
                }

            }
            //IMageType
            if (dsTemp.Tables["ImageType"] != null)
            {
                dtTemp = dsTemp.Tables["ImageType"];
                ImageTypeDb objImageTypeDb;
                arrStr = SysUtility.GetStringArr(dtTemp, "ImageTypeID", 5000);
                if (arrStr.Count > 0 && arrStr[0] != "")
                {
                    objImageTypeDb = new ImageTypeDb();
                    objImageTypeDb.IDsStr = arrStr[0];
                    SysData.SharpVisionBaseDb.ExecuteNonQuery(objImageTypeDb.EditChangedStr);
                }

            }
            if (dsTemp.Tables["ImageTypeDeleted"] != null)
            {
                dtTemp = dsTemp.Tables["ImageTypeDeleted"];
                ImageTypeDb objImageTypeDb;
                arrStr = SysUtility.GetStringArr(dtTemp, "ImageTypeID", 5000);
                if (arrStr.Count > 0 && arrStr[0] != "")
                {
                    objImageTypeDb = new ImageTypeDb();
                    objImageTypeDb.IDsStr = arrStr[0];
                    SysData.SharpVisionBaseDb.ExecuteNonQuery(objImageTypeDb.EditChangedStr);
                }

            }
            //Image 
            if (dsTemp.Tables["Image"] != null)
            {
                dtTemp = dsTemp.Tables["Image"];
                ImageDb objImageDb;
                arrStr = SysUtility.GetStringArr(dtTemp, "ImageID", 5000);
                if (arrStr.Count > 0 && arrStr[0] != "")
                {
                    objImageDb = new ImageDb();
                    objImageDb.IDsStr = arrStr[0];
                    SysData.SharpVisionBaseDb.ExecuteNonQuery(objImageDb.EditChangedStr);
                }

            }
            if (dsTemp.Tables["ImageDeleted"] != null)
            {
                dtTemp = dsTemp.Tables["ImageDeleted"];
                ImageDb objImageDb;
                arrStr = SysUtility.GetStringArr(dtTemp, "ImageID", 5000);
                if (arrStr.Count > 0 && arrStr[0] != "")
                {
                    objImageDb = new ImageDb();
                    objImageDb.IDsStr = arrStr[0];
                    SysData.SharpVisionBaseDb.ExecuteNonQuery(objImageDb.EditChangedStr);
                }

            }
            //Paragraph
            if (dsTemp.Tables["Paragraph"] != null)
            {
                dtTemp = dsTemp.Tables["Paragraph"];
                ParagraphDb objParagraphDb;
                arrStr = SysUtility.GetStringArr(dtTemp, "ParagraphID", 5000);
                if (arrStr.Count > 0 && arrStr[0] != "")
                {
                    objParagraphDb = new ParagraphDb();
                    objParagraphDb.IDsStr = arrStr[0];
                    SysData.SharpVisionBaseDb.ExecuteNonQuery(objParagraphDb.EditChangedStr);
                }

            }
            if (dsTemp.Tables["ParagraphDeleted"] != null)
            {
                dtTemp = dsTemp.Tables["ParagraphDeleted"];
                ParagraphDb objParagraphDb;
                arrStr = SysUtility.GetStringArr(dtTemp, "ParagraphID", 5000);
                if (arrStr.Count > 0 && arrStr[0] != "")
                {
                    objParagraphDb = new ParagraphDb();
                    objParagraphDb.IDsStr = arrStr[0];
                    SysData.SharpVisionBaseDb.ExecuteNonQuery(objParagraphDb.EditChangedStr);
                }

            }
            //SUB
            if (dsTemp.Tables["SUB"] != null)
            {
                dtTemp = dsTemp.Tables["SUB"];
                SUBDb objSUBDb;
                arrStr = SysUtility.GetStringArr(dtTemp, "SUBID", 5000);
                if (arrStr.Count > 0 && arrStr[0] != "")
                {
                    objSUBDb = new SUBDb();
                    objSUBDb.IDsStr = arrStr[0];
                    SysData.SharpVisionBaseDb.ExecuteNonQuery(objSUBDb.EditChangedStr);
                }

            }
            if (dsTemp.Tables["SUBDeleted"] != null)
            {
                dtTemp = dsTemp.Tables["SUBDeleted"];
                SUBDb objSUBDb;
                arrStr = SysUtility.GetStringArr(dtTemp, "SUBID", 5000);
                if (arrStr.Count > 0 && arrStr[0] != "")
                {
                    objSUBDb = new SUBDb();
                    objSUBDb.IDsStr = arrStr[0];
                    SysData.SharpVisionBaseDb.ExecuteNonQuery(objSUBDb.EditChangedStr);
                }

            }
            //content
            if (dsTemp.Tables["Content"] != null)
            {
                dtTemp = dsTemp.Tables["Content"];
                ContentDb objContentDb;
                arrStr = SysUtility.GetStringArr(dtTemp, "ContentID", 5000);
                if (arrStr.Count > 0 && arrStr[0] != "")
                {
                    objContentDb = new ContentDb();
                    objContentDb.IDsStr = arrStr[0];
                    SysData.SharpVisionBaseDb.ExecuteNonQuery(objContentDb.EditChangedStr);
                }

            }
            if (dsTemp.Tables["ContentDeleted"] != null)
            {
                dtTemp = dsTemp.Tables["ContentDeleted"];
                ContentDb objContentDb;
                arrStr = SysUtility.GetStringArr(dtTemp, "ContentID", 5000);
                if (arrStr.Count > 0 && arrStr[0] != "")
                {
                    objContentDb = new ContentDb();
                    objContentDb.IDsStr = arrStr[0];
                    SysData.SharpVisionBaseDb.ExecuteNonQuery(objContentDb.EditChangedStr);
                }

            }

            //Location
            if (dsTemp.Tables["Location"] != null)
            {
                dtTemp = dsTemp.Tables["Location"];
                LocationDb objLocationDb;
                arrStr = SysUtility.GetStringArr(dtTemp, "LocationID", 5000);
                if (arrStr.Count > 0 && arrStr[0] != "")
                {
                    objLocationDb = new LocationDb();
                    objLocationDb.IDsStr = arrStr[0];
                    SysData.SharpVisionBaseDb.ExecuteNonQuery(objLocationDb.EditChangedStr);
                }

            }
            if (dsTemp.Tables["LocationDeleted"] != null)
            {
                dtTemp = dsTemp.Tables["LocationDeleted"];
                LocationDb objLocationDb;
                arrStr = SysUtility.GetStringArr(dtTemp, "LocationID", 5000);
                if (arrStr.Count > 0 && arrStr[0] != "")
                {
                    objLocationDb = new LocationDb();
                    objLocationDb.IDsStr = arrStr[0];
                    SysData.SharpVisionBaseDb.ExecuteNonQuery(objLocationDb.EditChangedStr);
                }

            }

            //Page
            if (dsTemp.Tables["Page"] != null)
            {
                dtTemp = dsTemp.Tables["Page"];
                PageDb objPageDb;
                arrStr = SysUtility.GetStringArr(dtTemp, "PageID", 5000);
                if (arrStr.Count > 0 && arrStr[0] != "")
                {
                    objPageDb = new PageDb();
                    objPageDb.IDsStr = arrStr[0];
                    SysData.SharpVisionBaseDb.ExecuteNonQuery(objPageDb.EditChangedStr);
                }

            }
            if (dsTemp.Tables["PageDeleted"] != null)
            {
                dtTemp = dsTemp.Tables["PageDeleted"];
                PageDb objPageDb;
                arrStr = SysUtility.GetStringArr(dtTemp, "PageID", 5000);
                if (arrStr.Count > 0 && arrStr[0] != "")
                {
                    objPageDb = new PageDb();
                    objPageDb.IDsStr = arrStr[0];
                    SysData.SharpVisionBaseDb.ExecuteNonQuery(objPageDb.EditChangedStr);
                }

            }
        }
        public static void UploadChangedData()
        {
             

        }
        #endregion
    }
}