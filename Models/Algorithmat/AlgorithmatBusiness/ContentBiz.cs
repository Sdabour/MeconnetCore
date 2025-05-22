using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Algorithmat.Algorithmat.AlgorithmatDataBase;
using SharpVision.SystemBase;
namespace Algorithmat.Algorithmat.AlgorithmatBusiness
{
    public enum ContentLanguage
    {
        NotSpecified,
        Arabic,
        English
    }
    public class ContentBiz
    {
        #region Private Data and Public Properties
        ContentTypeBiz _TypeBiz;

        public ContentTypeBiz TypeBiz
        {
            get {
                if (_TypeBiz == null)
                    _TypeBiz = new ContentTypeBiz();
                return _TypeBiz; }
            set { _TypeBiz = value; }
        }
        ContentDb _ContentDb;
        public int ID
        {
            get { return _ContentDb.ID; }
            set { _ContentDb.ID = value; }
        }


        public string Desc
        {
            get { return _ContentDb.Desc; }
            set { _ContentDb.Desc = value; }
        }


        public string TitleA
        {
            get { return _ContentDb.TitleA; }
            set { _ContentDb.TitleA = value; }
        }


        public string TitleE
        {
            get { return _ContentDb.TitleE; }
            set { _ContentDb.TitleE = value; }
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
        public string Title1A
        {
            get { return _ContentDb.Title1A; }
            set { _ContentDb.Title1A = value; }
        }


        public string Title1E
        {
            get { return _ContentDb.Title1E; }
            set { _ContentDb.Title1E = value; }
        }

        public string Title1
        {
            get
            {
                string Returned = "";
                if (SharpVision.SystemBase.SysData.Language == 0 && Title1A != null && Title1A != "")
                    Returned = Title1A;
                else
                    Returned = Title1E;
                return Returned;
            }
        }
        public string LinkA
        {
            get { return _ContentDb.LinkA; }
            set { _ContentDb.LinkA = value; }
        }


        public string LinkE
        {
            get { return _ContentDb.LinkE; }
            set { _ContentDb.LinkE = value; }
        }

        public string Link
        {
            get
            {
                string Returned = "";
                if (SharpVision.SystemBase.SysData.Language == 0 && LinkA != null && LinkA != "")
                    Returned = LinkA;
                else
                    Returned =  LinkE != null && LinkE != "" ? LinkE : LinkA ;
                return Returned;
            }
        }
        public string DisplayLinkA
        {
            get
            {
                string strLink = "";
                if (LinkA != null && LinkA != "")
                    strLink = LinkA;
                else if (LinkE != null && LinkE != "")
                    strLink = LinkE;
                if (strLink != "")
                    strLink += "?cnt=" + ID;
                string Returned = strLink;
                return Returned;
            }
        }
        public string DisplayLinkE
        {
            get
            {
                string strLink = "";
                if (LinkE != null && LinkE != "")
                    strLink = LinkE;
                else if (LinkA != null && LinkA != "")
                    strLink = LinkA;
                if (strLink != "")
                    strLink += "?cnt=" + ID;
                string Returned = strLink;
                return Returned;
            }
        }
        public string DisplayLink
        {
            get
            {
                string Returned = Link +"?cnt="+ID;
                return Returned;
            }
        }
        public string DisplayHTMLLinkA
        {
            get
            {
                int intTemp = ID % 1000;
                intTemp = ID - intTemp;
                intTemp = (intTemp / 1000) + 1;
                string Returned = intTemp.ToString();
                Returned+=@"\" + ID.ToString();
                if (Language == ContentLanguage.Arabic || Language == ContentLanguage.NotSpecified)
                    Returned += "Ar.html";
                else
                    Returned += "En.html";

                return Returned;
            }
        }
        public string FullDisplayHTMLLinkA
        {
            get
            {
                string Returned = "";
                Returned = DisplayHTMLLinkA;
                Returned = Returned.Replace(@"\", "/");
                Returned = SysData.MainURL + Returned;
                return Returned;
            }
        }
        public string DisplayHTMLLinkE
        {
            get
            {
                int intTemp = ID % 1000;
                intTemp = ID - intTemp;
                intTemp = (intTemp / 1000) + 1;
                string Returned = intTemp.ToString();
                Returned +=@"\"+ ID.ToString();
                if (Language == ContentLanguage.Arabic)
                    Returned += "Ar.html";
                else
                    Returned += "En.html";
                return Returned;
            }
        }
        public string FullDisplayHTMLLinkE
        {
            get
            {
                string Returned = "";
                Returned = DisplayHTMLLinkE;
                Returned = Returned.Replace(@"\", "/");
                Returned = SysData.MainURL + Returned;
                return Returned;
            }
        }
        public string DisplayHTMLLink
        {
            get
            {
                string Returned = "";
                if (SharpVision.SystemBase.SysData.Language == 0 && DisplayHTMLLinkA != null && DisplayHTMLLinkA != "")
                    Returned = DisplayHTMLLinkA;
                else
                    Returned = DisplayHTMLLinkE;
                return Returned;
            }
        }
        public string ShortA
        {
            get { return _ContentDb.ShortA; }
            set { _ContentDb.ShortA = value; }
        }
        

        public string ShortE
        {
            get { return _ContentDb.ShortE; }
            set { _ContentDb.ShortE = value; }
        }

        public string Short
        {
            get
            {
                string Returned = "";
                if (SharpVision.SystemBase.SysData.Language == 0 && ShortA != null && ShortA != "")
                    Returned = ShortA;
                else
                    Returned = ShortE;
                return Returned;
            }
        }
        public string TextA
        {
            get { return _ContentDb.TextA; }
            set { _ContentDb.TextA = value; }
        }
        

        public string TextE
        {
            get { return _ContentDb.TextE; }
            set { _ContentDb.TextE = value; }
        }
        public string Text
        {
            get
            {
                string Returned = "";
                if (SharpVision.SystemBase.SysData.Language == 0 && TextA != null && TextA != "")
                    Returned = TextA;
                else
                    Returned = TextE;
                return Returned;
            }
        }
        public string InnerHTML
        {
            get { return _ContentDb.InnerHTML; }
            set { _ContentDb.InnerHTML = value; }
        }

      
        public bool SendToCustomer
        {
            get { return _ContentDb.SendToCustomer; }
            set { _ContentDb.SendToCustomer = value; }
        }

        public ContentLanguage Language
        {
            set
            {
                _ContentDb.ContentLanguage = (int)value;
            }
            get
            {
                return (ContentLanguage)_ContentDb.ContentLanguage;
            }
        }

        public bool Sent
        {
            get { return _ContentDb.Sent; }
            set { _ContentDb.Sent = value; }
        }

      

        public bool IsChanged
        {
            get { return _ContentDb.IsChanged; }
            set { _ContentDb.IsChanged = value; }
        }
        public int DisplayIndex
        {
            get { return _ContentDb.DisplayIndex; }
            set { _ContentDb.DisplayIndex = value; }
        }
        SubCol _SubCol;

        public SubCol SubCol
        {
            get
            {
                if (_SubCol == null)
                {
                    _SubCol = new SubCol(true);
                    if (ID != 0)
                    {
                        DataRow[] arrDr;
                        SubBiz objSubBiz;
                      
                        DataTable dtTemp;
                        if (SysData.IsOnline)
                        {

                            dtTemp = ContentDb.CacheSubTable;
                        }
                        else
                        {
                            SUBDb objDb = new SUBDb();
                            objDb.ContentID = ID;
                            dtTemp = objDb.Search();
                        }
                        arrDr = dtTemp.Select("SUBContentID="+ID, "SUBOrder");
                        foreach (DataRow objDr in arrDr)
                        {
                            objSubBiz = new SubBiz(objDr);
                            _SubCol.Add(objSubBiz);
                        }

                        if (_SubCol.Count > 0)
                        {
                            ParagraphDb objParagraph = new ParagraphDb();
                            if (SysData.IsOnline)
                            {
                                dtTemp = ContentDb.CacheParagraphTabl;
                            }
                            else
                            {
                                objParagraph.SUBIDs = _SubCol.IDs;
                                dtTemp = objParagraph.Search();
                            }
                            DataTable dtImage;
                            if (SysData.IsOnline)
                            {
                                dtImage = ContentDb.CacheParagraphImageTable;
                            }
                            else
                            {
                                ParagraphImageDb objImageDb = new ParagraphImageDb();
                                objImageDb.ContentID = ID;
                                dtImage = objImageDb.Search();
                            }
                                DataRow[] arrImage;
                            ParagraphBiz objParagraphBiz;
                            foreach (SubBiz objBiz in _SubCol)
                            {
                                arrDr = dtTemp.Select("PARAGRAPHSUBID=" + objBiz.ID.ToString(), "PARAGRAPHOrder");
                                foreach (DataRow objDr in arrDr)
                                {
                                    objParagraphBiz = new ParagraphBiz(objDr);
                                    arrImage = dtImage.Select("ParagraphID=" + objParagraphBiz.ID, "ImageOrder");
                                    foreach (DataRow objDrImage in arrImage)
                                    {
                                        objParagraphBiz.ImageCol.Add(new ParagraphImageBiz(objDrImage));
                                    }
                                    objBiz.ParagraphCol.Add(objParagraphBiz);
                                }
                            }
                        }
                    }
                }
                return _SubCol;
            }
            set
            {

                _SubCol = value;
            }
        }
        SubCol _DeletedSubCol;

        public SubCol DeletedSubCol
        {
            get {
                if (_DeletedSubCol == null)
                    _DeletedSubCol = new SubCol(true);
                return _DeletedSubCol; }
            set { _DeletedSubCol = value; }
        }
        ParagraphCol _DeletedParagraphCol;

        public ParagraphCol DeletedParagraphCol
        {
            get {
                if (_DeletedParagraphCol == null)
                    _DeletedParagraphCol = new ParagraphCol(true);
                return _DeletedParagraphCol; }
            set { _DeletedParagraphCol = value; }
        }
        TopicBiz _TopicBiz;

        public TopicBiz TopicBiz
        {
            get {
                if (_TopicBiz == null)
                    _TopicBiz = new TopicBiz();
                return _TopicBiz; }
            set { _TopicBiz = value; }
        }
        TopicBiz _MainTopicBiz;

        public TopicBiz MainTopicBiz
        {
            get {
                if (_MainTopicBiz == null)
                    _MainTopicBiz = new TopicBiz();
                return _MainTopicBiz; }
            set { _MainTopicBiz = value; }
        }
        public string SiteMapStr
        {
            get
            {
                string Returned = "<li><a href='" +  DisplayLink + "'>" + Title + "</a></li>";
                return Returned;
            }
        }

        public static List<string> ContentLanguageStrLst
        {
            get 
            {
                List<string> Returned = new List<string>();
                Returned.Add("غير محدد");
                Returned.Add("عربى");
                Returned.Add("انجليزى");
                return Returned;
            }
        }

        #endregion
        #region Constructors
        public ContentBiz()
        {
            _ContentDb = new ContentDb();
        }
        public ContentBiz(DataRow objDr)
        {
            _ContentDb = new ContentDb(objDr);
            if(_ContentDb.Type!= 0)
            _TypeBiz = new ContentTypeBiz(objDr);
            _TopicBiz = new TopicBiz();
            _TopicBiz.ID = _ContentDb.TopicID;
            _TopicBiz.NameA = _ContentDb.TopicNameA;
            _TopicBiz.NameE = _ContentDb.TopicNameE;

            _MainTopicBiz = new TopicBiz();
            _MainTopicBiz.ID = _ContentDb.MainTopicID;
            _MainTopicBiz.NameA = _ContentDb.MainTopicNameA;
            _MainTopicBiz.NameE = _ContentDb.MainTopicNameE;

        }
        public ContentBiz(int intContentID)
        {
            _ContentDb = new ContentDb();
            if (intContentID == 0)
                return;

            ContentDb objDb = new ContentDb();
            objDb.ID = intContentID;
            DataTable dtTemp = objDb.Search();
            if (dtTemp.Rows.Count > 0)
            {
                DataRow objDr = dtTemp.Rows[0];
                _ContentDb = new ContentDb(objDr);
                if (_ContentDb.Type != 0)
                    _TypeBiz = new ContentTypeBiz(objDr);
            }
        }
        #endregion

        #region Private Methods

        #endregion
        #region Public Methods
        public void Add()
        {
            _ContentDb.Type = TypeBiz.ID;
            DataTable dtSub, dtParagraph, dtParagraphImage;
            dtSub = SubCol.GetTable(out dtParagraph, out dtParagraphImage,false);
            _ContentDb.SubTable = dtSub;
            _ContentDb.ParagraphTable = dtParagraph;
            _ContentDb.ParagraphImageTable = dtParagraphImage;
            _ContentDb.MainTopicID = MainTopicBiz.ID;
            _ContentDb.TopicID = TopicBiz.ID;
            ContentCol objCol = new ContentCol(true);
            objCol.Add(this);
            _ContentDb.ContentTable = objCol.GetTable();
            _ContentDb.Add();
        }
        public void Edit()
        {
            _ContentDb.Type = TypeBiz.ID;
            DataTable dtSub, dtParagraph, dtParagraphImage;
            dtSub = SubCol.GetTable(out dtParagraph, out dtParagraphImage,false);
            _ContentDb.SubTable = dtSub;
            _ContentDb.ParagraphTable = dtParagraph;
            _ContentDb.MainTopicID = MainTopicBiz.ID;
            _ContentDb.TopicID = TopicBiz.ID;
            _ContentDb.ParagraphImageTable = dtParagraphImage;
            DataTable dtTable1,dtTable2;
            _ContentDb.DeletedSubTable = DeletedSubCol.GetTable(out dtTable1, out dtTable2,true);
            ContentCol objCol = new ContentCol(true);
            objCol.Add(this);
            _ContentDb.ContentTable = objCol.GetTable();
            DeletedParagraphCol = new ParagraphCol(true);
            foreach (SubBiz objSubBiz in SubCol)
            {
                DeletedParagraphCol.Add(objSubBiz.DeletedParagraphCol);
            }
            _ContentDb.Edit();
        }
        public void Delete()
        {
            _ContentDb.Delete();
        }

        #endregion
    }
}