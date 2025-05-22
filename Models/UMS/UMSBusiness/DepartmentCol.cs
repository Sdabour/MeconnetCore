using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.UMS.UMSDataBase;
using SharpVision.Base.BaseBusiness;
using SharpVision.Base.BaseDataBase;
using System.Data;
using System.Collections;


namespace SharpVision.UMS.UMSBusiness
{
    public class DepartmentCol : BaseCol
    {
        #region Private Data
        //DepartmentBiz _RootBiz;
        //int _NodeNo;
        Hashtable _DepartmentHs = new Hashtable();
        static DepartmentCol _DepartmentCol;
        #endregion
        public DepartmentCol()
        {
            DepartmentBiz objDepartmentBiz;
            DepartmentDb objDepartmentDb = new DepartmentDb();
            DataTable dtDepartment = objDepartmentDb.Search();
            string strDepartment;
            if (BaseSingleDb.Language == 0)
                strDepartment = "SectorNameA";
            else
                strDepartment = "SectorNameE";
            DataRow[] arrDr = dtDepartment.Select("SectorID = SectorParentID", strDepartment);
            foreach (DataRow DR in arrDr)
            {
                objDepartmentBiz = new DepartmentBiz(DR);
                objDepartmentBiz.ParentBiz = objDepartmentBiz;
                SetChildren(ref objDepartmentBiz, ref dtDepartment);

                this.Add(objDepartmentBiz);
            }
        }
      
        public DepartmentCol(bool blIsEmpty)
        {
            if (!blIsEmpty)
            {
                DepartmentBiz objDepartmentBiz;
                objDepartmentBiz = new DepartmentBiz();
                objDepartmentBiz.ID = 0;
                objDepartmentBiz.NameA = "€Ì— „Õœœ";
                objDepartmentBiz.NameE = "Not specified";
                this.Add(objDepartmentBiz);
                DepartmentDb objDepartmentDb = new DepartmentDb();
                DataTable dtDepartment = objDepartmentDb.Search();
                string strDepartment;
                if (BaseSingleDb.Language == 0)
                    strDepartment = "SectorNameA";
                else
                    strDepartment = "SectorNameE";
                DataRow[] arrDr = dtDepartment.Select("SectorID = SectorParentID", strDepartment);
                foreach (DataRow DR in arrDr)
                {
                    objDepartmentBiz = new DepartmentBiz(DR);
                    objDepartmentBiz.ParentBiz = objDepartmentBiz;
                    SetChildren(ref objDepartmentBiz, ref dtDepartment);
                    this.Add(objDepartmentBiz);
                }
            }
        }
        #region Private Methods
        void SetChildren(ref DepartmentBiz objDepartmentBiz, ref DataTable dtDepartments)
        {
            objDepartmentBiz.Children = new DepartmentCol(true);
            DataRow[] arrDR = dtDepartments.Select("SectorID <> SectorParentID and SectorParentID=" + objDepartmentBiz.ID);
            DepartmentBiz tempDepartmentBiz;
            DepartmentCol objDepartmentCol;
            objDepartmentCol = new DepartmentCol(true);
            int intTemp = 0;

            foreach (DataRow DR in arrDR)
            {

                tempDepartmentBiz = new DepartmentBiz(DR);

                if (intTemp == tempDepartmentBiz.ID)
                    continue;
                else
                {

                    intTemp = tempDepartmentBiz.ID;

                }
                //if (_NodeNo >= 200)
                //    break;
                SetChildren(ref tempDepartmentBiz, ref dtDepartments);
                tempDepartmentBiz.ParentBiz = objDepartmentBiz;
                if (_DepartmentHs[tempDepartmentBiz.ID.ToString()] == null)
                    _DepartmentHs.Add(tempDepartmentBiz.ID.ToString(), tempDepartmentBiz);
                objDepartmentCol.List.Add(tempDepartmentBiz);


            }
            objDepartmentBiz.Children = objDepartmentCol;

        }
        void SetChildrenCol(ref DepartmentCol objDepartmentCol, string strDepartment, DepartmentBiz objDepartmentBiz)
        {
            if ((objDepartmentBiz.Name.IndexOf(strDepartment) != -1) )
                objDepartmentCol.Add(objDepartmentBiz);
            else
            {
                if (objDepartmentBiz.Children != null)
                {
                    foreach (DepartmentBiz objBiz in objDepartmentBiz.Children)
                    {
                        SetChildrenCol(ref objDepartmentCol, strDepartment, objBiz);
                    }
                }
            }
        }
        void SetTailCol(ref DepartmentCol objDepartmentCol, DepartmentBiz objDepartmentBiz)
        {
            if (objDepartmentBiz.Children == null || objDepartmentBiz.Children.Count == 0)
                objDepartmentCol.Add(objDepartmentBiz);
            else
            {

                foreach (DepartmentBiz objBiz in objDepartmentBiz.Children)
                {
                    SetTailCol(ref objDepartmentCol, objBiz);
                }

            }
        }
        void SetLinearCol(ref DepartmentCol objDepartmentCol, DepartmentBiz objDepartmentBiz)
        {
            objDepartmentCol.Add(objDepartmentBiz);
            if (objDepartmentBiz.Children == null || objDepartmentBiz.Children.Count == 0)
                return;

            foreach (DepartmentBiz objBiz in objDepartmentBiz.Children)
            {
                SetLinearCol(ref objDepartmentCol, objBiz);
            }


        }


        #endregion
        #region Public Properties
        public virtual DepartmentBiz this[int intIndex]
        {
            get
            {
                return (DepartmentBiz)this.List[intIndex];
            }
        }
        public virtual DepartmentBiz this[string strIndex]
        {
            get
            {
                return  _DepartmentHs[strIndex] == null ? new DepartmentBiz() :
                    (DepartmentBiz)_DepartmentHs[strIndex] ;
            }
        }
        public DepartmentCol TailCol
        {
            get
            {
                DepartmentCol Returned = new DepartmentCol(true);
                foreach (DepartmentBiz objBiz in this)
                {
                    SetTailCol(ref Returned, objBiz);
                }
                return Returned;
            }
        }
        public DepartmentCol LinearCol
        {
            get
            {
                DepartmentCol Returned = new DepartmentCol(true);
                foreach (DepartmentBiz objBiz in this)
                {
                    SetLinearCol(ref Returned, objBiz);
                }
                return Returned;
            }
        }
        public static DepartmentCol CurrentDepartmentCol
        {
            get
            {
                if (_DepartmentCol == null)
                    _DepartmentCol = new DepartmentCol();
                return _DepartmentCol;
            }
        }
        #endregion
        #region Public Methods
        public void Add(DepartmentBiz objBiz)
        {
            if (_DepartmentHs[objBiz.ID.ToString()] == null)
            {
                _DepartmentHs.Add(objBiz.ID.ToString(), objBiz);
                List.Add(objBiz);
            }
        }
        public DepartmentCol GetDepartmentCol(string strDepartment)
        {

            DepartmentCol Returned = new DepartmentCol(true);
            foreach (DepartmentBiz objDepartmentbiz in this)
            {
                SetChildrenCol(ref Returned, strDepartment, objDepartmentbiz);
            }
            return Returned;
        }
     


        #endregion
    }
}
