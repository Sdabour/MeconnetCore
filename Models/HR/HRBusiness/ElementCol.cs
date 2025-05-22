using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using SharpVision.Base.BaseDataBase;
using SharpVision.Base.BaseBusiness;
using SharpVision.HR.HRDataBase;
using SharpVision.SystemBase;
using SharpVision.COMMON.COMMONBusiness;

namespace SharpVision.HR.HRBusiness
{
    public class ElementCol : CollectionBase
    {
        public ElementCol()
        {
            ElementBiz objBiz;

            ElementDb objDb = new ElementDb();
            DataTable dtTemp = objDb.Search();


            foreach (DataRow DR in dtTemp.Rows)
            {
                objBiz = new ElementBiz(DR);

                this.Add(objBiz);
            }

        }
        public ElementCol(string strElementIDs)
        {
            ElementBiz objBiz;

            ElementDb objDb = new ElementDb();
            objDb.ElementIDs = strElementIDs;
            DataTable dtTemp = objDb.Search();


            foreach (DataRow DR in dtTemp.Rows)
            {
                objBiz = new ElementBiz(DR);

                this.Add(objBiz);
            }

        }
        public ElementCol(bool blIsEmpty)
        {
            if (!blIsEmpty)
            {
                ElementBiz objBiz;
                objBiz = new ElementBiz();
                objBiz.ID = 0;
                objBiz.NameA = "غير محدد";
                this.Add(objBiz);
                ElementDb objDb = new ElementDb();
                DataTable dtTemp = objDb.Search();


                foreach (DataRow DR in dtTemp.Rows)
                {
                    objBiz = new ElementBiz(DR);

                    this.Add(objBiz);
                }
            }

        }
        public ElementCol(bool blIsEmpty, int intElement)
        {
            if (!blIsEmpty)
            {
                ElementBiz objBiz;
                objBiz = new ElementBiz();
                objBiz.ID = 0;
                objBiz.NameA = "غير محدد";
                this.Add(objBiz);
                ElementDb objDb = new ElementDb();
                objDb.ID = intElement;
                DataTable dtTemp = objDb.Search();


                foreach (DataRow DR in dtTemp.Rows)
                {
                    objBiz = new ElementBiz(DR);

                    this.Add(objBiz);
                }
            }

        }



        public virtual ElementBiz this[int intIndex]
        {
            get
            {

                return (ElementBiz)this.List[intIndex];

            }
        }

        public virtual ElementBiz this[string strIndex]
        {
            get
            {
                ElementBiz Returned = new ElementBiz();
                foreach (ElementBiz objBiz in this)
                {
                    if (objBiz.Name == strIndex)
                    {
                        Returned = objBiz.Copy();
                        break;
                    }
                }
                return Returned;
            }
        }


        public virtual void Add(ElementBiz objBiz)
        {
            if (this[objBiz.Name].Name == null || this[objBiz.Name].Name == "")
            {
                this.List.Add(objBiz.Copy());
            }

        }


        public virtual void Add(ElementCol objCol)
        {
            foreach (ElementBiz objBiz in objCol)
            {
                if (this[objBiz.Name].ID == 0)
                    this.List.Add(objBiz.Copy());

            }
        }

        public ElementCol Copy()
        {
            ElementCol Returned = new ElementCol(true);
            foreach (ElementBiz objTemp in this)
            {
                Returned.Add(objTemp.Copy());
            }
            return Returned;
        }

        public static ElementBiz GetElementBiz(int intID)
        {
            foreach (ElementBiz objBiz in ElementCol.CacheElementCol)
            {
                if (objBiz.ID == intID)
                {
                    return objBiz;
                }
            }
            return new ElementBiz();
        }

        static ElementCol _CacheElementCol;
        public static ElementCol CacheElementCol
        {
            set
            {
                _CacheElementCol = value;
            }
            get
            {
                if (_CacheElementCol == null)
                {
                    _CacheElementCol = new ElementCol(false);
                }
                return _CacheElementCol;
            }
        }
        public ElementCol GetCol(GroupElementBiz objGroupBiz, string strFilter)
        {
            if (objGroupBiz == null)
                objGroupBiz = new GroupElementBiz();
            ElementCol Returned = new ElementCol(true);
            bool blIsFound = true;
            string[] arrStr = strFilter.Split("%".ToCharArray());
            foreach (ElementBiz objBiz in this)
            {
                if (objGroupBiz.ID != 0 && objGroupBiz.ID != objBiz.GroupBiz.ID)
                    continue;
                blIsFound = true;
                foreach (string strTemp in arrStr)
                {
                    if (objBiz.Code.IndexOf(strTemp) == -1 &&
                        objBiz.NameA.IndexOf(strTemp) == -1 && objBiz.NameE.IndexOf(strTemp) == -1)
                        blIsFound = false;

                }
                if (blIsFound)
                    Returned.Add(objBiz);
            }
            return Returned;
        }
    }
}
