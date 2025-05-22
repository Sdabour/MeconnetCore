using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.CRM.CRMDataBase;
using System.Collections;
using SharpVision.Base.BaseBusiness;
using SharpVision.SystemBase;
namespace SharpVision.CRM.CRMBusiness
{
    public class VisitTypeCol : BaseCol
    {
        public VisitTypeCol()
        {
            VisitTypeBiz objVisitTypeBiz;

            VisitTypeDb objVisitTypeDb = new VisitTypeDb();
            DataTable dtVisitType = objVisitTypeDb.Search();

            DataRow[] arrDr = dtVisitType.Select("VisitTypeID= VisitTypeParentID");

            foreach (DataRow DR in arrDr)
            {
                objVisitTypeBiz = new VisitTypeBiz(DR);
                objVisitTypeBiz.ParentBiz = objVisitTypeBiz;
                SetVisitTypeChildren(ref objVisitTypeBiz, ref dtVisitType);
                this.Add(objVisitTypeBiz);
            }
        }
        public VisitTypeCol(bool blIsEmpty)
        {
            if (!blIsEmpty)
            {
                VisitTypeBiz objVisitTypeBiz;
                objVisitTypeBiz = new VisitTypeBiz();
                objVisitTypeBiz.ID = 0;
                objVisitTypeBiz.NameA = "غير محدد";
                this.Add(objVisitTypeBiz);
                VisitTypeDb objVisitTypeDb = new VisitTypeDb();
                DataTable dtVisitType = objVisitTypeDb.Search();

                DataRow[] arrDr = dtVisitType.Select("VisitTypeID= VisitTypeParentID");

                foreach (DataRow DR in arrDr)
                {
                    objVisitTypeBiz = new VisitTypeBiz(DR);
                    objVisitTypeBiz.ParentBiz = objVisitTypeBiz;
                    SetVisitTypeChildren(ref objVisitTypeBiz, ref dtVisitType);
                    this.Add(objVisitTypeBiz);
                }
            }

        }
        #region Public Property
        public virtual VisitTypeBiz this[int intIndex]
        {
            get
            {

                return (VisitTypeBiz)this.List[intIndex];

            }
        }
        public virtual VisitTypeBiz this[string strIndex]
        {
            get
            {
                VisitTypeBiz Returned = new VisitTypeBiz();
                foreach (VisitTypeBiz objVisitTypeBiz in this)
                {
                    if (objVisitTypeBiz.NameA == strIndex)
                    {
                        Returned = objVisitTypeBiz.Copy();
                        break;
                    }
                }
                return Returned;
            }
        }

        public VisitTypeCol LinearCol
        {
            get
            {
                VisitTypeCol Returned = new VisitTypeCol(true);
                foreach (VisitTypeBiz objBiz in this)
                {
                    SetLinearCol(ref Returned, objBiz);
                }
                return Returned;

            }
        }
        public string IDs
        {
            get
            {
                string Returned = "";
                foreach (VisitTypeBiz objTypeBiz in this)
                {
                    if (Returned != "")
                        Returned += ",";
                    Returned += objTypeBiz.ID.ToString();
                    if (objTypeBiz.Children.Count > 0)
                    {

                        Returned += ",";
                        Returned += objTypeBiz.Children.IDs;
                    }

                }
                return Returned;
            }
        }
        #endregion
        #region Private Methods
        void SetVisitTypeChildren(ref VisitTypeBiz objVisitTypeBiz, ref DataTable dtVisitTypes)
        {
            objVisitTypeBiz.Children = new VisitTypeCol(true);
            DataRow[] arrDR = dtVisitTypes.Select("VisitTypeID <> VisitTypeParentID and VisitTypeParentID=" + objVisitTypeBiz.ID, "");
            VisitTypeBiz tempVisitTypeBiz;
            VisitTypeCol objVisitTypeCol;
            objVisitTypeCol = new VisitTypeCol(true);
            foreach (DataRow DR in arrDR)
            {
                tempVisitTypeBiz = new VisitTypeBiz(DR);
                SetVisitTypeChildren(ref tempVisitTypeBiz, ref dtVisitTypes);
                tempVisitTypeBiz.ParentBiz = objVisitTypeBiz;
                objVisitTypeCol.Add(tempVisitTypeBiz);

            }
            objVisitTypeBiz.Children = objVisitTypeCol;

        }

        void SetChildrenCol(ref VisitTypeCol objVisitTypeCol, string strVisitTypeName, VisitTypeBiz objVisitTypeBiz)
        {
            if (objVisitTypeBiz.Name.IndexOf(strVisitTypeName) != -1)
                objVisitTypeCol.Add(objVisitTypeBiz);
            else
                if (objVisitTypeBiz.Children != null)
            {
                foreach (VisitTypeBiz objBiz in objVisitTypeBiz.Children)
                {
                    SetChildrenCol(ref objVisitTypeCol, strVisitTypeName, objBiz);
                }
            }
        }
        void SetLinearCol(ref VisitTypeCol objVisitTypeCol, VisitTypeBiz objVisitTypeBiz)
        {
            objVisitTypeCol.Add(objVisitTypeBiz);
            if (objVisitTypeBiz.Children == null || objVisitTypeBiz.Children.Count == 0)
                return;
            foreach (VisitTypeBiz objBiz in objVisitTypeBiz.Children)
            {
                SetLinearCol(ref objVisitTypeCol, objBiz);
            }
        }
        void SetTailCol(ref VisitTypeCol objVisitTypeCol, VisitTypeBiz objVisitTypeBiz)
        {
            if (objVisitTypeBiz.Children == null || objVisitTypeBiz.Children.Count == 0)
                objVisitTypeCol.Add(objVisitTypeBiz);
            else
            {
                foreach (VisitTypeBiz objBiz in objVisitTypeBiz.Children)
                {
                    SetTailCol(ref objVisitTypeCol, objBiz);
                }
            }
        }

        #endregion


        public virtual void Add(VisitTypeCol objVisitTypeCol)
        {
            foreach (VisitTypeBiz objVisitTypeBiz in objVisitTypeCol)
            {
                if (this[objVisitTypeBiz.NameA].ID == 0)
                    this.List.Add(objVisitTypeBiz);

            }
        }
        public void Add(VisitTypeBiz objBiz)
        {
            List.Add(objBiz);
        }
        public VisitTypeCol Copy()
        {
            VisitTypeCol Returned = new VisitTypeCol(true);
            foreach (VisitTypeBiz objTemp in this)
            {
                Returned.Add(objTemp.Copy());
            }
            return Returned;
        }

        public VisitTypeCol GetVisitTypeCol(string strVisitTypeName)
        {
            VisitTypeCol Returned = new VisitTypeCol(true);
            foreach (VisitTypeBiz objBiz in this)
            {
                SetChildrenCol(ref Returned, strVisitTypeName, objBiz);
            }
            return Returned;
        }

    }
}

