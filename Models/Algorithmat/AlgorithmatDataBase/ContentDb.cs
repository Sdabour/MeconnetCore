using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SharpVision.Base.BaseDataBase;

using System.Data;
using SharpVision.UMS.UMSBusiness;
using SharpVision.SystemBase;
//using Algorithmat.OnlineService;
//using Algorithmat.AlgorithmatOnline;

namespace Algorithmat.Algorithmat.AlgorithmatDataBase
{
    public class ContentDb
    {
        #region Private Data
        int _ID;

        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
        string _IDStr;

      
        int _Type;

        public int Type
        {
            get { return _Type; }
            set { _Type = value; }
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
        string _Title1A;

        public string Title1A
        {
            get { return _Title1A; }
            set { _Title1A = value; }
        }
        string _Title1E;

        public string Title1E
        {
            get { return _Title1E; }
            set { _Title1E = value; }
        }
        string _Desc;

        public string Desc
        {
            get { return _Desc; }
            set { _Desc = value; }
        }
        string _ShortA;

        public string ShortA
        {
            get { return _ShortA; }
            set { _ShortA = value; }
        }
        string _ShortE;

        public string ShortE
        {
            get { return _ShortE; }
            set { _ShortE = value; }
        }
        string _TextA;

        public string TextA
        {
            get { return _TextA; }
            set { _TextA = value; }
        }
        string _TextE;

        public string TextE
        {
            get { return _TextE; }
            set { _TextE = value; }
        }
        string _InnerHTML;

        public string InnerHTML
        {
            get { return _InnerHTML; }
            set { _InnerHTML = value; }
        }
       

        bool _IsChanged;

        public bool IsChanged
        {
            get { return _IsChanged; }
            set { _IsChanged = value; }
        }
        int _LocationForeignID;

        public int LocationForeignID
        {
            get { return _LocationForeignID; }
            set { _LocationForeignID = value; }
        }
        string _LinkA;

        public string LinkA
        {
            get { return _LinkA; }
            set { _LinkA = value; }
        }
        string _LinkE;

        public string LinkE
        {
            get { return _LinkE; }
            set { _LinkE = value; }
        }
        bool _SendToCustomer;

        public bool SendToCustomer
        {
            get { return _SendToCustomer; }
            set { _SendToCustomer = value; }
        }
        int _SendToCustomerStatus;

        public int SendToCustomerStatus
        {
            get { return _SendToCustomerStatus; }
            set { _SendToCustomerStatus = value; }
        }
        bool _Sent;

        public bool Sent
        {
            get { return _Sent; }
            set { _Sent = value; }
        }
        int _ContentLanguage;

        public int ContentLanguage
        {
            get { return _ContentLanguage; }
            set { _ContentLanguage = value; }
        }
        int _SentStatus;

        public int SentStatus
        {
            get { return _SentStatus; }
            set { _SentStatus = value; }
        }
        DataTable _SubTable;

        public DataTable SubTable
        {
            get 
            {
                if (_SubTable == null)
                {
 
                }
 
                return _SubTable;
            }
            set { _SubTable = value; }
        }
        static DataTable _CacheSubTable;

        public static DataTable CacheSubTable
        {
            get { return ContentDb._CacheSubTable; }
            set { ContentDb._CacheSubTable = value; }
        }
        DataTable _ParagraphTable;

        public DataTable ParagraphTable
        {
            get { return _ParagraphTable; }
            set { _ParagraphTable = value; }
        }
        static DataTable _CacheParagraphTabl;

        public static DataTable CacheParagraphTabl
        {
            get { return ContentDb._CacheParagraphTabl; }
            set { ContentDb._CacheParagraphTabl = value; }
        }
        DataTable _ParagraphImageTable;

        public DataTable ParagraphImageTable
        {
            get { return _ParagraphImageTable; }
            set { _ParagraphImageTable = value; }
        }
        static DataTable _CacheParagraphImageTable;

        public static DataTable CacheParagraphImageTable
        {
            get { return ContentDb._CacheParagraphImageTable; }
            set { ContentDb._CacheParagraphImageTable = value; }
        }
        DataTable _DeletedSubTable;

        public DataTable DeletedSubTable
        {
            get { return _DeletedSubTable; }
            set { _DeletedSubTable = value; }
        }
        DataTable _DeletedParagraphTable;

        public DataTable DeletedParagraphTable
        {
            get { return _DeletedParagraphTable; }
            set { _DeletedParagraphTable = value; }
        }
        bool _IncludeSearchGroupTable;

        public bool IncludeSearchGroupTable
        {
            get { return _IncludeSearchGroupTable; }
            set { _IncludeSearchGroupTable = value; }
        }
        DataTable _SearchGroupTable;

        public DataTable SearchGroupTable
        {
            get { return _SearchGroupTable; }
            set { _SearchGroupTable = value; }
        }
        int _MaxID;

        public int MaxID
        {
            get { return _MaxID; }
            set { _MaxID = value; }
        }
        int _MinID;

        public int MinID
        {
            get { return _MinID; }
            set { _MinID = value; }
        }
        int _DisplayIndex;

        public int DisplayIndex
        {
            get { return _DisplayIndex; }
            set { _DisplayIndex = value; }
        }
        static int _PageElementNo =5;

        public static int PageElementNo
        {
            get { return ContentDb._PageElementNo; }
            set { ContentDb._PageElementNo = value; }
        }
        int _SourceID;

        public int SourceID
        {
            get { return _SourceID; }
            set { _SourceID = value; }
        }
        int _TopicID;

        public int TopicID
        {
            get { return _TopicID; }
            set { _TopicID = value; }
        }
        string _TopicNameA;

        public string TopicNameA
        {
            get { return _TopicNameA; }
            set { _TopicNameA = value; }
        }
        string _TopicNameE;

        public string TopicNameE
        {
            get { return _TopicNameE; }
            set { _TopicNameE = value; }
        }
        int _MainTopicID;

        public int MainTopicID
        {
            get { return _MainTopicID; }
            set { _MainTopicID = value; }
        }
        string _MainTopicNameA;

        public string MainTopicNameA
        {
            get { return _MainTopicNameA; }
            set { _MainTopicNameA = value; }
        }
        string _MainTopicNameE;

        public string MainTopicNameE
        {
            get { return _MainTopicNameE; }
            set { _MainTopicNameE = value; }
        }

        #endregion
        #region Constructors
        public ContentDb()
        { }
        public ContentDb(DataRow objDr)
        {
            SetData(objDr);
        }
        #endregion
        #region Public Properties
        
        public string AddStr
        {
            get
            {

                int intSendToCustomer = _SendToCustomer ? 1 : 0;
                string Returned = "insert into PORTALContent ("+
                    "ContentType,ContentTitleA, ContentTitleE, ContentTitle1A, ContentTitle1E"+
                    ", ContentDesc, ContentShortA, ContentShortE" +
                    ", ContentTextA, ContentTextE,ContentLinkA,ContenteLinkE, ContentInnerHTML" +
                    ",ContentSendToCustomer,ContentLanguage,ContentDisplayIndex,ContentMainTopic, ContentTopic, UsrIns, TimIns) " +
                    "  select "+ _Type +" as CType,'" + _TitleA.Trim() + "' as CTitleA,'" + _TitleE.Trim() + "' as CTitleE"+
                    ",'"+_Title1A.Trim() +"' as CTitle1A ,'"+ _Title1E.Trim() + "' as CTitle1E "+
                    ",'" + _Desc.Trim() + "' as CDesc,'" +
                    _ShortA.Trim() + "' as CShortA,'" +
                    _ShortE.Trim() + "' as CShortE,'" + _TextA.Trim() + "' as CTextA,'" + _TextE.Trim() + "' as CTextE,'" +
                    _LinkA.Trim()  + "' as CLinkA,'" + _LinkE.Trim()  +"' as CLinkE,'"+ 
                    _InnerHTML  + "' as CInnerHTML," + intSendToCustomer + " as CSendToCustomer"+
                    ","+_ContentLanguage + " as ContentLanguage ,"+ _DisplayIndex + " as DisplayIndex1 "+
                    "," + _MainTopicID + "," + _TopicID+   "," +SysData.CurrentUser.ID + " as CUsrIns,GetDate() as CTimIns  ";

                return Returned;
            }
        }
        public string EditStr
        {
            get
            {
                int intSendToCustomer = _SendToCustomer ? 1 : 0;
                string Returned = "update PORTALContent  " +
                    " set ContentType =" + _Type +
                    ", ContentTitleA='" + _TitleA.Trim().Replace("'", "''") + "'" +
                    ", ContentTitleE='" + _TitleE.Trim().Replace("'", "''") + "'" +
                     ", ContentTitle1A='" + _Title1A.Trim().Replace("'", "''") + "'" +
                    ", ContentTitle1E='" + _Title1E.Trim().Replace("'", "''") + "'" +
                    ", ContentDesc='" + _Desc.Trim().Replace("'", "''") + "'" +
                    ", ContentShortA='" + _ShortA.Trim().Replace("'", "''") + "'" +
                    ", ContentShortE='" + _ShortE.Trim().Replace("'", "''") + "'" +
                    ", ContentTextA='" + _TextA.Trim().Replace("'", "''") + "'" +
                    ", ContentTextE='" + _TextE.Trim().Replace("'", "''") + "'" +
                   ",ContentLinkA='" + _LinkA + "'" +
                   ",ContenteLinkE='" + _LinkE + "'" +
                    ", ContentInnerHTML='" + _InnerHTML.Replace("'", "''") + "'" +
                    ",ContentSendToCustomer=" + intSendToCustomer +
                    ",ContentLanguage="+ _ContentLanguage +
                    ",ContentDisplayIndex="+_DisplayIndex+
                    ",ContentMainTopic="+ _MainTopicID +
                    ", ContentTopic="+_TopicID+
                    ", ContentChanged=1" +
                    ", UsrUpd=" + SysData.CurrentUser.ID +
                    ", TimUpd=GetDate() ";
                if (_IDStr != null && _IDStr != "")
                {
                    Returned += " where ContentID =" + _IDStr;
                }
                else
                    Returned+= " where ContentID =" + _ID;
                return Returned;
            }
        }
        public string AddIdentityStr
        {
            get
            {
                string strForeign = "SELECT        ForeignID " +
                    " FROM            PORTALContentForeign " +
                     " WHERE        (ForeignID = " + _ID + ")";
                string Returned = "insert into PORTALContent (ContentTypeCode) " +
                    " SELECT        '' AS Expr1 "+
                    " WHERE        (NOT EXISTS "+
                    " ("+ strForeign +"))"+
                     " insert into PORTALContentForeign (ForeignID,ContentID,ForeignSource) "+
                     " select "+ ID +",@IDENTITY,"+ _SourceID +" as SourceID  "+
                     " where not exists ("+ strForeign +") ";
                Returned = " ";
                _IDStr = " SELECT        TOP (1) ContentID "+
                  " FROM            dbo.PORTALContentForeign "+
                  " WHERE        (ForeignID = "+ _ID +") ";
                Returned += " " + EditStr;
                return Returned;
            }
        }
        public string DeleteStr
        {
            get
            {
                string Returned = "update PORTALContent  " +
                  " set  ContentChanged =1, Dis=GetDate() " +
                  " where ContentID =" + _ID;
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
                string Returned = "update PORTALContent  " +
                  " set  ContentChanged =0 " +
                  " where ContentID in (" + _IDsStr + ") ";
                return Returned;
            }
        }
        public static string SearchStr
        {
            get
            {
                string Returned = "SELECT   ContentID,ContentType, ContentTitleA, ContentTitleE, ContentTitle1A, ContentTitle1E"+
                    ", ContentDesc, ContentShortA"+
                    ", ContentShortE, ContentTextA,ContentLinkA,ContenteLinkE, ContentTextE, ContentInnerHTML,ContentSendToCustomer"+
                    ",ContentSent,ContentLanguage, dbo.PORTALContent.ContentDisplayIndex, ContentChanged,ContentTypeTable.* " +
                    ",  MainTopicTable.TopicID AS ContentMainTopicID, MainTopicTable.TopicNameA AS ContentMainTopicNameA, MainTopicTable.TopicNameE AS ContentMainTopicNameE, TopicTable.TopicID AS ContentTopicID, "+
                         " TopicTable.TopicNameA AS ContentTopicNameA, TopicTable.TopicNameE AS ContentTopicNameE "+
                    " FROM     PORTALContent "+
                    " left outer join ("+ ContentTypeDb.SearchStr +") as ContentTypeTable "+
                    " on PortalContent.ContentType = ContentTypeTable.ContentTypeID "+
                    "  LEFT OUTER JOIN  dbo.PORTALTopic as TopicTable " +
                    " ON dbo.PORTALContent.ContentTopic = TopicTable.TopicID " +
                    " LEFT OUTER JOIN  dbo.PORTALTopic AS MainTopicTable "+
                    " ON dbo.PORTALContent.ContentMainTopic = MainTopicTable.TopicID ";
                return Returned;
            }
        }
        public string StrSearch
        {
            get
            {
                string Returned = SearchStr + " where PORTALContent.Dis is null ";
                if (_ID != 0)
                    Returned += " and ContentID=" + _ID;
                if (_Type != 0)
                    Returned += " and ContentType=" + _Type;
                if (_Desc != null && _Desc != "")
                    Returned += " and ContentDesc like '%" + _Desc + "%' ";
                if (_MaxID > 0 && _MinID > 0)
                    Returned += " and  ContentID>=" + _MinID + " and ContentID <= "+ _MaxID;
                return Returned;
            }
        }
        public static string TableName
        {
            get { return "ContentTable"; }
        }
        public static string GroupTableName
        {
            get { return "ContentGroupTable"; }
        }
        DataTable _ContentTable;

        public DataTable ContentTable
        {
            get { return _ContentTable; }
            set { _ContentTable = value; }
        }
        #endregion
        #region Private Methods
       protected void SetData(DataRow objDr)
        {
            _ID = int.Parse(objDr["ContentID"].ToString());
            _Desc = objDr["ContentDesc"].ToString();
            _TitleA = objDr["ContentTitleA"].ToString();
            _TitleE = objDr["ContentTitleE"].ToString();
            _Title1A = objDr["ContentTitle1A"].ToString();
            _Title1E = objDr["ContentTitle1E"].ToString();
            _Type = int.Parse(objDr["ContentType"].ToString());
            _ShortA = objDr["ContentShortA"].ToString();
            _ShortE = objDr["ContentShortE"].ToString();
            _TextA = objDr["ContentTextA"].ToString();
            _TextE = objDr["ContentTextE"].ToString();
            _LinkA = objDr["ContentLinkA"].ToString();
            _LinkE = objDr["ContenteLinkE"].ToString();
            _InnerHTML = objDr["ContentInnerHTML"].ToString();
            if (objDr.Table.Columns["LocationForeignID"] != null && objDr["LocationForeignID"].ToString() != "")
                _LocationForeignID = int.Parse(objDr["LocationForeignID"].ToString());
            _IsChanged = bool.Parse(objDr["ContentChanged"].ToString());
            if(objDr["ContentSendToCustomer"].ToString()!="")
            _SendToCustomer = bool.Parse(objDr["ContentSendToCustomer"].ToString());
           if(objDr["ContentSent"].ToString()!="")
            _Sent = bool.Parse(objDr["ContentSent"].ToString());
           int.TryParse(objDr["ContentLanguage"].ToString(), out _ContentLanguage);
           int.TryParse(objDr["ContentDisplayIndex"].ToString(), out _DisplayIndex);


           int.TryParse(objDr["ContentTopicID"].ToString(), out _TopicID);
           if(objDr.Table.Columns["ContentTopicNameA"]!= null)
           _TopicNameA = objDr["ContentTopicNameA"].ToString();
           if (objDr.Table.Columns["ContentTopicNameE"] != null)
           _TopicNameE = objDr["ContentTopicNameE"].ToString();

           int.TryParse(objDr["ContentMainTopicID"].ToString(), out _MainTopicID);
           if(objDr.Table.Columns["ContentMainTopicNameA"]!= null)
           _MainTopicNameA = objDr["ContentMainTopicNameA"].ToString();
           if (objDr.Table.Columns["ContentMainTopicNameE"] != null)
           _MainTopicNameE = objDr["ContentMainTopicNameE"].ToString();
        }
       void AddEditOnWeb()
       {
          
       }
       void DeleteOnWeb()
       {
          
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
            _ID =  SysData.SharpVisionBaseDb.InsertIdentityTable(strSql);
            JoinSub();
        }
        public virtual void Edit()
        {
            if (SysData.IsOnline)
            {
                AddEditOnWeb();
                return;
            }
            string strSql = EditStr;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
            JoinSub();
        }
        public virtual void Delete()
        {
            if (SysData.IsOnline)
            {
                DeleteOnWeb();
                return;
            }
            string strSql = DeleteStr;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public virtual DataTable Search()
        {
            if (SysData.IsOnline)
                return SearchWeb();
            string strSql = StrSearch;
            string strTemp = "select ContentID as ID,ROW_NUMBER() OVER (ORDER BY ContentID DESC) AS NewID "+
                " from ("+ strSql +") as NativeTable ";
            string strGroup = "SELECT     ((NewID -  { fn MOD(NewID, "+ _PageElementNo +") })/"+ _PageElementNo +") +1  as GroupIndex,max(NewID) as MaxIndex,min(NewID) as MinIndex "+
                     " FROM  ("+  strTemp +") as GroupTable "+
                     " GROUP  by (NewID -  { fn MOD(NewID,"+ _PageElementNo +") })/"+ _PageElementNo +"  "+
                     "";
            strGroup = "select GroupIndex,MaxRowTable.ID as MinID , MinRowTable.ID as MaxID "+
                " from ("+ strGroup +") as GroupTable "+
                " inner join ("+ strTemp +") as MaxRowTable "+
                " on GroupTable.MaxIndex = MaxRowTable.NewID "+
                " inner join (" + strTemp + ") as MinRowTable " +
                " on GroupTable.MinIndex = MinRowTable.NewID ";
            
           if (_IncludeSearchGroupTable && _MinID ==0 && _MaxID == 0)
                _SearchGroupTable = SysData.SharpVisionBaseDb.ReturnDatatable(strGroup,GroupTableName);
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql,ContentDb.TableName);
        }
        DataTable SearchWeb()
        {
            DataTable Returned = new DataTable();
           

            return Returned;

        }
        public void JoinSub()
        {
            if (_SubTable == null)
                return;
            SUBDb objSubDb;
            ParagraphDb objParagraphDb;
            ParagraphImageDb objImageDb;
            DataRow[] arrPargraphDr;
            DataRow[] arrImageDr;
            List<string> arrStr;
            foreach (DataRow objSubDr in _SubTable.Rows)
            {

                objSubDb = new SUBDb(objSubDr);
                objSubDb.ContentID = ID;
                if (objSubDb.ID == 0)
                    objSubDb.Add();
                else
                    objSubDb.Edit();
                arrPargraphDr = _ParagraphTable.Select("SecondarySub=" + objSubDb.SecondarySubID);
                foreach (DataRow objParagraphDr in arrPargraphDr)
                {
                    arrStr = new List<string>();
                    objParagraphDb = new ParagraphDb(objParagraphDr);
                    objParagraphDb.SUBID = objSubDb.ID;
                    arrStr = new List<string>();
                    if(objParagraphDb.ID != 0)
                    arrStr.Add(" delete FROM  PORTALParagraphImage WHERE        (ParagraphID = "+objParagraphDb.ID+")");
                    if (objParagraphDb.ID == 0)
                        objParagraphDb.Add();
                    else
                        objParagraphDb.Edit();
                    arrImageDr = _ParagraphImageTable.Select("SecondaryParagraph='" + objParagraphDb.SecondaryParagraph.ToString() + "'");
                   
                    foreach (DataRow objParagraphImageDr in arrImageDr)
                    {
                        objImageDb = new ParagraphImageDb(objParagraphImageDr);
                        objImageDb.ParagraphID = objParagraphDb.ID;
                        arrStr.Add(objImageDb.AddStr);

                    }

                    if (arrStr.Count > 0)
                        SysData.SharpVisionBaseDb.ExecuteNonQuery(arrStr);
                }


            }
            if (_DeletedParagraphTable != null && _DeletedParagraphTable.Rows.Count == 0)
            {
                arrStr = new List<string>();
                foreach(DataRow objDr in _DeletedParagraphTable.Rows)
                {
                    objParagraphDb = new ParagraphDb(objDr);
                    arrStr.Add(objParagraphDb.DeleteStr);

                    
                }
                SysData.SharpVisionBaseDb.ExecuteNonQuery(arrStr);
            }
            if (_DeletedSubTable != null && _DeletedSubTable.Rows.Count > 0)
            {
                arrStr = new List<string>();
                foreach (DataRow objDr in _DeletedSubTable.Rows)
                {
                    objSubDb = new SUBDb(objDr);
                    arrStr.Add(objSubDb.DeleteStr);
                }
                SysData.SharpVisionBaseDb.ExecuteNonQuery(arrStr);
            }

        }
        #endregion
    }
}