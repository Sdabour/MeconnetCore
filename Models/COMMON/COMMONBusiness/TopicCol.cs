using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.COMMON.COMMONDataBase;
using System.Collections;
using SharpVision.Base.BaseBusiness;
namespace SharpVision.COMMON.COMMONBusiness
{
    public class TopicCol : BaseCol
    {
        public TopicCol()
        {
            TopicBiz objTopicBiz;

            TopicDb objTopicDb = new TopicDb();
            DataTable dtTopic = objTopicDb.Search();

            DataRow[] arrDr = dtTopic.Select("TopicID= TopicParentID");

            foreach (DataRow DR in arrDr)
            {
                objTopicBiz = new TopicBiz(DR);
                objTopicBiz.ParentBiz = objTopicBiz;
                SetTopicChildren(ref objTopicBiz, ref dtTopic);
                this.Add(objTopicBiz);
            }
        }
        public TopicCol(bool blIsEmpty)
        {
            if (!blIsEmpty)
            {
                TopicBiz objTopicBiz;
                objTopicBiz = new TopicBiz();
                objTopicBiz.ID = 0;
                objTopicBiz.NameA = "€Ì— „Õœœ";
                this.Add(objTopicBiz);
                TopicDb objTopicDb = new TopicDb();
                DataTable dtTopic = objTopicDb.Search();

                DataRow[] arrDr = dtTopic.Select("TopicID= TopicParentID");

                foreach (DataRow DR in arrDr)
                {
                    objTopicBiz = new TopicBiz(DR);
                    objTopicBiz.ParentBiz = objTopicBiz;
                    SetTopicChildren(ref objTopicBiz, ref dtTopic);
                    this.Add(objTopicBiz);
                }
            }

        }
        #region Public Property
        public virtual TopicBiz this[int intIndex]
        {
            get
            {

                return (TopicBiz)this.List[intIndex];

            }
        }
        public virtual TopicBiz this[string strIndex]
        {
            get
            {
                TopicBiz Returned = new TopicBiz();
                foreach (TopicBiz objTopicBiz in this)
                {
                    if (objTopicBiz.NameA == strIndex)
                    {
                        Returned = objTopicBiz.Copy();
                        break;
                    }
                }
                return Returned;
            }
        }

        public TopicCol LinearCol
        {
            get
            {
                TopicCol Returned = new TopicCol(true);
                foreach (TopicBiz objBiz in this)
                {
                    SetLinearCol(ref Returned, objBiz);
                }
                return Returned;

            }
        }
        #endregion
        #region Private Methods
        void SetTopicChildren(ref TopicBiz objTopicBiz, ref DataTable dtTopics)
        {
            objTopicBiz.Children = new TopicCol(true);
            DataRow[] arrDR = dtTopics.Select("TopicID <> TopicParentID and TopicParentID=" + objTopicBiz.ID, "");
            TopicBiz tempTopicBiz;
            TopicCol objTopicCol;
            objTopicCol = new TopicCol(true);
            foreach (DataRow DR in arrDR)
            {
                tempTopicBiz = new TopicBiz(DR);
                SetTopicChildren(ref tempTopicBiz, ref dtTopics);
                tempTopicBiz.ParentBiz = objTopicBiz;
                objTopicCol.Add(tempTopicBiz);

            }
            objTopicBiz.Children = objTopicCol;

        }

        void SetChildrenCol(ref TopicCol objTopicCol, string strTopicName, TopicBiz objTopicBiz)
        {
            if (objTopicBiz.Name.IndexOf(strTopicName) != -1)
                objTopicCol.Add(objTopicBiz);
            else
                if (objTopicBiz.Children != null)
                {
                    foreach (TopicBiz objBiz in objTopicBiz.Children)
                    {
                        SetChildrenCol(ref objTopicCol, strTopicName, objBiz);
                    }
                }
        }
        void SetLinearCol(ref TopicCol objTopicCol, TopicBiz objTopicBiz)
        {
            objTopicCol.Add(objTopicBiz);
            if (objTopicBiz.Children == null || objTopicBiz.Children.Count == 0)
                return;
            foreach (TopicBiz objBiz in objTopicBiz.Children)
            {
                SetLinearCol(ref objTopicCol, objBiz);
            }
        }
        void SetTailCol(ref TopicCol objTopicCol, TopicBiz objTopicBiz)
        {
            if (objTopicBiz.Children == null || objTopicBiz.Children.Count == 0)
                objTopicCol.Add(objTopicBiz);
            else
            {
                foreach (TopicBiz objBiz in objTopicBiz.Children)
                {
                    SetTailCol(ref objTopicCol, objBiz);
                }
            }
        }

        #endregion

        public virtual void Add(SubjectBiz objSubjectBiz)
        {
            if (this[objSubjectBiz.NameA].NameA == null || this[objSubjectBiz.NameA].NameA == "")
            {
                this.List.Add(objSubjectBiz);
            }

        }
        public virtual void Add(TopicCol objTopicCol)
        {
            foreach (TopicBiz objTopicBiz in objTopicCol)
            {
                if (this[objTopicBiz.NameA].ID == 0)
                    this.List.Add(objTopicBiz);

            }
        }
        public TopicCol Copy()
        {
            TopicCol Returned = new TopicCol(true);
            foreach (TopicBiz objTemp in this)
            {
                Returned.Add(objTemp.Copy());
            }
            return Returned;
        }

        public TopicCol GetTopicCol(string strTopicName)
        {
            TopicCol Returned = new TopicCol(true);
            foreach (TopicBiz objBiz in this)
            {
                SetChildrenCol(ref Returned, strTopicName, objBiz);
            }
            return Returned;
        }

    }
}

