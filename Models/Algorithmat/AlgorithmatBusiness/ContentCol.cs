using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Collections;
using Algorithmat.Algorithmat.AlgorithmatDataBase;
using SharpVision.Base.BaseBusiness;
namespace Algorithmat.Algorithmat.AlgorithmatBusiness
{
    public class ContentCol : CollectionBase
    {
        #region Private Data and Public Properties
        DataTable _SearchGroupTable;

        public DataTable SearchGroupTable
        {
            get { return _SearchGroupTable; }
            set { _SearchGroupTable = value; }
        }
        GroupPageIndexCol _IndexCol;

        public GroupPageIndexCol IndexCol
        {
            get { return _IndexCol; }
            set { _IndexCol = value; }
        }
        public List<string> DisplayHTMLLinkLst
        {
            get 
            {
                List<string> Returned = new List<string>();
                foreach (ContentBiz objBiz in this)
                {
                    if(objBiz.Language == ContentLanguage.Arabic || objBiz.Language == ContentLanguage.NotSpecified)
                    Returned.Add( objBiz.FullDisplayHTMLLinkA);
                    if (objBiz.Language == ContentLanguage.English || objBiz.Language == ContentLanguage.NotSpecified)
                    Returned.Add(objBiz.FullDisplayHTMLLinkE);
                }
                return Returned;
            }
        }
        public List<string> DisplayLinkLst
        {
            get 
            {
                
                List<string> Returned = new List<string>();
                foreach (ContentBiz objBiz in this)
                {
                    if(objBiz.Language == ContentLanguage.Arabic || objBiz.Language == ContentLanguage.NotSpecified)
                    Returned.Add( objBiz.DisplayLinkA);
                    if (objBiz.Language == ContentLanguage.English || objBiz.Language == ContentLanguage.NotSpecified)
                    Returned.Add(objBiz.DisplayLinkE);
                }
                return Returned;
            }
        }
        #endregion
        #region Constructors
        public ContentCol(bool blIsEmpty)
        {

        }
        public ContentCol()
        {
            ContentDb objDb = new ContentDb();
            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
                Add(new ContentBiz(objDr));

        }
        public ContentCol(int intID, ContentTypeBiz objType, string strDesc)
        {
            if (objType == null)
                objType = new ContentTypeBiz();
            ContentDb objDb = new ContentDb();
            objDb.ID = intID;
            objDb.Type = objType.ID;
            objDb.Desc = strDesc;
      
            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
                Add(new ContentBiz(objDr));
        }
        public ContentCol(int intType,int intMinIndex,int intMaxIndex)
        {
           
            ContentDb objDb = new ContentDb();
            
            objDb.Type =intType;
            objDb.MaxID = intMaxIndex;
            objDb.MinID = intMinIndex;
            if(intMinIndex==0 && intMaxIndex == 0 )
            objDb.IncludeSearchGroupTable = true;

            DataTable dtTemp = objDb.Search();

            foreach (DataRow objDr in dtTemp.Rows)
                Add(new ContentBiz(objDr));
            if (intMinIndex == 0 && intMaxIndex == 0)
            {
                dtTemp = objDb.SearchGroupTable;
                _IndexCol = new GroupPageIndexCol(dtTemp);
            }
        }
        #endregion
        #region Properties
        public ContentBiz this[int intIndex]
        {
            get
            {
                return (ContentBiz)List[intIndex];
            }
        }
        #endregion
        #region Private Methods

        #endregion
        #region Public Methods
        public void Add(ContentBiz objBiz)
        {
            List.Add(objBiz);
        }
        internal static DataColumn[] Columns
        {
            get
            {
                DataColumn[] Returned = new DataColumn[] {new DataColumn("ContentID"),new DataColumn("ContentType")
                    , new DataColumn("ContentDesc"),
                new DataColumn("ContentTitleA"),new DataColumn("ContentTitleE")
                , new DataColumn("ContentTitle1A"),new DataColumn("ContentTitle1E"),new DataColumn("ContentShortA"),
                new DataColumn("ContentShortE"),new DataColumn("ContentTextA"),new DataColumn("ContentTextE")
                ,new DataColumn("ContentLinkA"),new DataColumn("ContenteLinkE") 
                ,new DataColumn("ContentInnerHTML")
                ,new DataColumn("ContentIsStoped"),new DataColumn("ContentChanged")
                ,new DataColumn("ContentSendToCustomer",Type.GetType("System.Boolean"))
                ,new DataColumn("ContentSent",Type.GetType("System.Boolean"))
                ,new DataColumn("LocationForeignID"),new DataColumn("ContentLanguage"),new DataColumn("ContentIsChanged"),
                new DataColumn("ContentDisplayIndex"),new DataColumn("ContentTopicID"),new DataColumn("ContentMainTopicID")
 };
                return Returned;
            }
        }
        public DataTable GetTable()
        {
            DataTable Returned = new DataTable(ContentDb.TableName);
            Returned.Columns.AddRange(Columns);
            DataRow objDr;
            foreach (ContentBiz objBiz in this)
            {
                objDr = Returned.NewRow();
                objDr["ContentID"] = objBiz.ID;
                objDr["ContentDesc"] = objBiz.Desc;
                objDr["ContentTitleA"] = objBiz.TitleA;
                objDr["ContentTitleE"] = objBiz.TitleE;
                objDr["ContentTitle1A"] = objBiz.Title1A;
                objDr["ContentTitle1E"] = objBiz.Title1E;
                objDr["ContentType"] = objBiz.TypeBiz.ID;
                objDr["ContentShortA"] = objBiz.ShortA;
                objDr["ContentShortE"] = objBiz.ShortE;
                objDr["ContentTextA"] = objBiz.TextA;
                objDr["ContentTextE"] = objBiz.TextE;
                objDr["ContentLinkA"] = objBiz.LinkA;
                objDr["ContenteLinkE"] = objBiz.LinkE;
                objDr["ContentInnerHTML"] = objBiz.InnerHTML;
                //objDr["LocationForeignID"] = objBiz.fo
                objDr["ContentChanged"] = objBiz.IsChanged;
                objDr["ContentSendToCustomer"] = objBiz.SendToCustomer;
                //objDr["ContentSent"] = objBiz.sen
                objDr["ContentLanguage"] = (int)objBiz.Language;
                objDr["ContentIsChanged"] = objBiz.IsChanged ? 1 : 0;
                objDr["ContentDisplayIndex"] = objBiz.DisplayIndex;
                objDr["ContentTopicID"] = objBiz.TopicBiz.ID;
                objDr["ContentMainTopicID"] = objBiz.MainTopicBiz.ID;
                Returned.Rows.Add(objDr);
            }
            return Returned;
        }
        public TopicCol GetMainTopicCol()
        {
            TopicCol Returned = new TopicCol(true);
            Hashtable hsMainTopic = new Hashtable();
            Hashtable hsTopic = new Hashtable();
            TopicBiz objMain;
            TopicBiz objTopic;
            string strTopicKey= "";
            foreach (ContentBiz objBiz in this)
            {
                objMain = objBiz.MainTopicBiz;
                objTopic = objBiz.TopicBiz;
                if (hsMainTopic[objMain.ID.ToString()] != null)
                    objMain = (TopicBiz)hsMainTopic[objMain.ID.ToString()];
                else
                {
                    hsMainTopic.Add(objMain.ID.ToString(), objMain);
                    Returned.Add(objMain);
                }
                strTopicKey = objMain.ID.ToString()+"-"+objTopic.ID.ToString();
                if (hsTopic[strTopicKey] != null)
                    objTopic = (TopicBiz)hsTopic[strTopicKey];
                else
                {
                    hsTopic.Add(strTopicKey, objTopic);
                    objMain.ChildrenTopicCol.Add(objTopic);

                }
                objTopic.ContentCol.Add(objBiz);

            }
            return Returned;
        }
        public ContentTypeCol GetContentTypeCol()
        {
            ContentTypeCol Returned = new ContentTypeCol(true);
            string strTypeCode,strMainTopicCode,strTopicCode;
            Hashtable hsType = new Hashtable();
            Hashtable hsMainTopic = new Hashtable();
            Hashtable hsTopic = new Hashtable();
            ContentTypeBiz objTypBiz;
            TopicBiz objTopicBiz,objMainTopicBiz;
            foreach (ContentBiz objContentBiz in this)
            {
                strTypeCode = ""; strMainTopicCode = ""; strTopicCode="";
                objTypBiz = objContentBiz.TypeBiz;
                objMainTopicBiz = objContentBiz.MainTopicBiz;
                objTopicBiz = objContentBiz.TopicBiz;
                if (objTypBiz.ID == 0)
                    continue;
                strTypeCode = objTypBiz.ID.ToString();
                if (objMainTopicBiz.ID != 0)
                {
                    strMainTopicCode = strTypeCode + "-" + objMainTopicBiz.ID.ToString();
                    if (objTopicBiz.ID != 0)
                        strTopicCode = strMainTopicCode + "-" + objTopicBiz.ID.ToString();
                }

                #region decide typpe
                if (hsType[strTypeCode] == null)
                {
                    Returned.Add(objTypBiz);
                    hsType.Add(strTypeCode, objTypBiz);
                }
                else
                    objTypBiz = (ContentTypeBiz)hsType[strTypeCode];
                #region MainTopic
                if (objMainTopicBiz.ID == 0)
                    objTypBiz.ContentCol.Add(objContentBiz);
                else
                {
                    if (hsMainTopic[strMainTopicCode] == null)
                    {
                      
                        hsMainTopic.Add(strMainTopicCode, objMainTopicBiz);
                        objTypBiz.MainTopicCol.Add(objMainTopicBiz);
                    }
                    else
                        objMainTopicBiz  = (TopicBiz)hsType[strMainTopicCode];
                    #region topic
                    if (objTopicBiz.ID == 0)
                        objMainTopicBiz.ContentCol.Add(objContentBiz);
                    else
                    {
                        if (hsTopic[strTopicCode] == null)
                        {
                            hsTopic.Add(strTopicCode, objTopicBiz);
                            objMainTopicBiz.ChildrenTopicCol.Add(objTopicBiz);
                        }
                        else
                            objTopicBiz = (TopicBiz)hsTopic[strTopicCode];
                        objTopicBiz.ContentCol.Add(objContentBiz);
                    }
                    #endregion
                }
                #endregion
                #endregion

            }
            return Returned;
        }
        public string GetSiteMap()
        {
            string Returned = "";
            Returned += "<ul>";
            PageCol objPageCol = new PageCol();

            ContentTypeCol objTypeCol = GetContentTypeCol();
            foreach (ContentTypeBiz objTypeBiz in objTypeCol)
            {
             
                Returned += objTypeBiz.GetHTMLElement();
              
              
            }
            Returned += "</ul>";
            return Returned;
        }
        #endregion
    }
}