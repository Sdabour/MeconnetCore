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
    public class TopicBiz : BaseSingleBiz
    {
        #region Private Data

        #endregion
        #region Constractors
        public TopicBiz()
        {
            _BaseDb = new TopicDb();
        }
        public TopicBiz(DataRow objDR)
        {
            _BaseDb = new TopicDb(objDR);
        }
        #endregion
        #region Public Accessorice
        TopicCol _ChildrenTopicCol;

        public TopicCol ChildrenTopicCol
        {
            get {
                if (_ChildrenTopicCol == null)
                {
                    _ChildrenTopicCol = new TopicCol(true);

                }
                return _ChildrenTopicCol; }
            set { _ChildrenTopicCol = value; }
        }
        ContentCol _ContentCol;

        public ContentCol ContentCol
        {
            get {
                if (_ContentCol == null)
                {
                    _ContentCol = new ContentCol(true);
                }
                return _ContentCol; }
            set { _ContentCol = value; }
        }
        public string ContentSiteStr
        {
            get
            {
                string strContent = "";
                foreach (ContentBiz objContentBiz in ContentCol)
                {
                    strContent += objContentBiz.SiteMapStr;
                }
                if (strContent != "")
                    strContent = "<ul>" + strContent + "</ul>";
                if (ChildrenTopicCol.Count > 0)
                {
                    foreach (TopicBiz objTopicBiz in ChildrenTopicCol)
                    {
                        strContent += objTopicBiz.ContentSiteStr;
                    }
                }
                return strContent;
            }
        }
        #endregion
        #region Private Methods
        #endregion
        #region public Methods
        public void Add()
        {
            //((TopicDb)_BaseDb).Code = Code;
            ((TopicDb)_BaseDb).Add();
        }
        public void Edit()
        {
            //((TopicDb)_BaseDb).Code = Code;
            ((TopicDb)_BaseDb).Edit();
        }
        public void Delete()
        {
            ((TopicDb)_BaseDb).Delete();
        }
        public TopicBiz Copy()
        {
            TopicBiz Returned = new TopicBiz();
            Returned.ID = ID;
            Returned.Code = Code;
            Returned.NameA = NameA;
            Returned.NameE = NameE;
            return Returned;
        }
        #endregion
    }
}
