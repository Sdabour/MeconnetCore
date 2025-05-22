using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.COMMON.COMMONDataBase;
using System.Collections;
using SharpVision.Base.BaseBusiness;
namespace SharpVision.COMMON.COMMONBusiness
{
    public class SubjectCol : BaseCol

    {
        public SubjectCol()
        {
            SubjectBiz objSubjectBiz;

            SubjectDb objSubjectDb = new SubjectDb();
            DataTable dtSubject = objSubjectDb.Search();

            DataRow[] arrDr = dtSubject.Select("SubjectID= SubjectParentID");

            foreach (DataRow DR in arrDr)
            {
                objSubjectBiz = new SubjectBiz(DR);
                SetSubjectChildren(ref objSubjectBiz, ref dtSubject);
                this.Add(objSubjectBiz);
            }
        }
        public SubjectCol(bool blIsEmpty)
        {
            if (!blIsEmpty)
            {
                SubjectBiz objSubjectBiz;
                objSubjectBiz = new SubjectBiz();
                objSubjectBiz.ID = 0;
                objSubjectBiz.NameA = "€Ì— „Õœœ";
                this.Add(objSubjectBiz);
                SubjectDb objSubjectDb = new SubjectDb();
                DataTable dtSubject = objSubjectDb.Search();

                DataRow[] arrDr = dtSubject.Select("SubjectID= SubjectParentID");

                foreach (DataRow DR in arrDr)
                {
                    objSubjectBiz = new SubjectBiz(DR);
                    SetSubjectChildren(ref objSubjectBiz, ref dtSubject);
                    this.Add(objSubjectBiz);
                }
            }

        }
        #region Public Property
        public virtual SubjectBiz this[int intIndex]
        {
            get
            {

                return (SubjectBiz)this.List[intIndex];

            }
        }
        public virtual SubjectBiz this[string strIndex]
        {
            get
            {
                SubjectBiz Returned = new SubjectBiz();
                foreach (SubjectBiz objSubjectBiz in this)
                {
                    if (objSubjectBiz.NameA == strIndex)
                    {
                        Returned = objSubjectBiz.Copy();
                        break;
                    }
                }
                return Returned;
            }
        }
        
        public SubjectCol LinearCol
        {
            get
            {
                SubjectCol Returned = new SubjectCol(true);
                foreach (SubjectBiz objBiz in this)
                {
                    SetLinearCol(ref Returned, objBiz);
                }
                return Returned;

            }
        }
        #endregion
        #region Private Methods
        void SetSubjectChildren(ref SubjectBiz objSubjectBiz, ref DataTable dtSubjects)
        {
            objSubjectBiz.Children = new SubjectCol(true);
            DataRow[] arrDR = dtSubjects.Select("SubjectID <> SubjectParentID and SubjectParentID=" + objSubjectBiz.ID, "");
            SubjectBiz tempSubjectBiz;
            SubjectCol objSubjectCol;
            objSubjectCol = new SubjectCol(true);
            foreach (DataRow DR in arrDR)
            {
                tempSubjectBiz = new SubjectBiz(DR);
                SetSubjectChildren(ref tempSubjectBiz, ref dtSubjects);
                tempSubjectBiz.ParentBiz = objSubjectBiz;
                objSubjectCol.Add(tempSubjectBiz);

            }
            objSubjectBiz.Children = objSubjectCol;

        }

        void SetChildrenCol(ref SubjectCol objSubjectCol, string strSubjectName, SubjectBiz objSubjectBiz)
        {
            if (objSubjectBiz.Name.IndexOf(strSubjectName) != -1)
                objSubjectCol.Add(objSubjectBiz);
            else
                if (objSubjectBiz.Children != null)
                {
                    foreach (SubjectBiz objBiz in objSubjectBiz.Children)
                    {
                        SetChildrenCol(ref objSubjectCol, strSubjectName, objBiz);
                    }
                }
        }
        void SetLinearCol(ref SubjectCol objSubjectCol, SubjectBiz objSubjectBiz)
        {
            objSubjectCol.Add(objSubjectBiz);
            if (objSubjectBiz.Children == null || objSubjectBiz.Children.Count == 0)
                return;
            foreach (SubjectBiz objBiz in objSubjectBiz.Children)
            {
                SetLinearCol(ref objSubjectCol, objBiz);
            }
        }
        void SetTailCol(ref SubjectCol objSubjectCol, SubjectBiz objSubjectBiz)
        {
            if (objSubjectBiz.Children == null || objSubjectBiz.Children.Count == 0)
                objSubjectCol.Add(objSubjectBiz);
            else
            {
                foreach (SubjectBiz objBiz in objSubjectBiz.Children)
                {
                    SetTailCol(ref objSubjectCol, objBiz);
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
        public virtual void Add(SubjectCol objSubjectCol)
        {
            foreach (SubjectBiz objSubjectBiz in objSubjectCol)
            {
                if (this[objSubjectBiz.NameA].ID == 0)
                    this.List.Add(objSubjectBiz);

            }
        }
        public SubjectCol Copy()
        {
            SubjectCol Returned = new SubjectCol(true);
            foreach (SubjectBiz objTemp in this)
            {
                Returned.Add(objTemp.Copy());
            }
            return Returned;
        }

        public SubjectCol GetSubjectCol(string strSubjectName)
        {
            SubjectCol Returned = new SubjectCol(true);
            foreach (SubjectBiz objBiz in this)
            {
                SetChildrenCol(ref Returned, strSubjectName, objBiz);
            }
            return Returned;
        }

    }
}

