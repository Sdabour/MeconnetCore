using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.Base.BaseDataBase;
using SharpVision.Base.BaseBusiness;
using Algorithmat.Algorithmat.AlgorithmatDataBase;
using SharpVision.SystemBase;

namespace Algorithmat.Algorithmat.AlgorithmatBusiness
{
    public class ContentTypeBiz : BaseSingleBiz
    {
        #region Private Data

        #endregion
        #region Constractors
        public ContentTypeBiz()
        {
            _BaseDb = new ContentTypeDb();
        }
        public ContentTypeBiz(DataRow objDR)
        {
            _BaseDb = new ContentTypeDb(objDR);
        }
        #endregion
        #region Public Accessorice

        public string DisplayPageA
        {
            get {
             
                return ((ContentTypeDb)_BaseDb).DisplayPageA; }
            set { ((ContentTypeDb)_BaseDb).DisplayPageA = value; }
        }
        public string DisplayPageE
        {
            get
            {

                return ((ContentTypeDb)_BaseDb).DisplayPageE;
            }
            set { ((ContentTypeDb)_BaseDb).DisplayPageE = value; }
        }
        public string DisplayPage
        {
            get
            {
                string Returned = "";
                if (SharpVision.SystemBase.SysData.Language == 0 && DisplayPageA != null && DisplayPageA != "")
                    Returned = DisplayPageA;
                else
                    Returned = DisplayPageE;
                return Returned;
            }
        }
        public int DisplayIndex
        {
            get { return ((ContentTypeDb)_BaseDb).DisplayIndex; }
            set { ((ContentTypeDb)_BaseDb).DisplayIndex = value; }
        }
        ContentCol _ContentCol;

        public ContentCol ContentCol
        {
            get {
                if (_ContentCol == null)
                    _ContentCol = new ContentCol(true);
                return _ContentCol; }
            set { _ContentCol = value; }
        }
        TopicCol _MainTopicCol;

        public TopicCol MainTopicCol
        {
            get {
                if (_MainTopicCol == null)
                    _MainTopicCol = new TopicCol(true);
                return _MainTopicCol; }
            set { _MainTopicCol = value; }
        }
        TopicCol _TopicCol;

        public TopicCol TopicCol
        {
            get {
                if (_TopicCol == null)
                    _TopicCol = new TopicCol(true);
                return _TopicCol; }
            set { _TopicCol = value; }
        }
        #endregion
        #region Private Methods
        #endregion
        #region public Methods
        public void Add()
        {
            //((ContentTypeDb)_BaseDb).Code = Code;
            ((ContentTypeDb)_BaseDb).Add();
        }
        public void Edit()
        {
            //((ContentTypeDb)_BaseDb).Code = Code;
            ((ContentTypeDb)_BaseDb).Edit();
        }
        public void Delete()
        {
            ((ContentTypeDb)_BaseDb).Delete();
        }
        public ContentTypeBiz Copy()
        {
            ContentTypeBiz Returned = new ContentTypeBiz();
            Returned.ID = ID;
            Returned.Code = Code;
            Returned.NameA = NameA;
            Returned.NameE = NameE;
            return Returned;
        }
        public string GetHTMLElement()
        {
            string Returned = "";
            Returned += "<li>";
            Returned += Name;
          
            string strContent = "";
            foreach (ContentBiz objBiz in ContentCol)
            {
                strContent += objBiz.SiteMapStr;
            }
            if (strContent != "")
                strContent = "<ul>" + strContent + "</ul>";
            Returned += strContent;
            foreach (TopicBiz objTopicBiz in MainTopicCol)
            {
                Returned += objTopicBiz.ContentSiteStr;
               



            }
           
           Returned += "</li>";
            return Returned;
        }
        #endregion
    }
}
