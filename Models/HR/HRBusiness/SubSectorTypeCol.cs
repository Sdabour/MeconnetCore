
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.HR.HRDataBase;
using System.Collections;
namespace SharpVision.HR.HRBusiness
{
    public class SubSectorTypeCol : CollectionBase
    {
        public SubSectorTypeCol()
        {
            SubSectorTypeBiz objSubSectorTypeBiz;

            SubSectorTypeDb objSubSectorTypeDb = new SubSectorTypeDb();
            DataTable dtSubSectorType = objSubSectorTypeDb.Search();


            foreach (DataRow DR in dtSubSectorType.Rows)
            {
                objSubSectorTypeBiz = new SubSectorTypeBiz(DR);

                this.Add(objSubSectorTypeBiz);
            }

        }
        public SubSectorTypeCol(bool blIsEmpty)
        {
            if (!blIsEmpty)
            {
                SubSectorTypeBiz objSubSectorTypeBiz;
                objSubSectorTypeBiz = new SubSectorTypeBiz();
                objSubSectorTypeBiz.ID = 0;
                objSubSectorTypeBiz.NameA = "غير محدد";
                this.Add(objSubSectorTypeBiz);
                SubSectorTypeDb objSubSectorTypeDb = new SubSectorTypeDb();
                DataTable dtSubSectorType = objSubSectorTypeDb.Search();


                foreach (DataRow DR in dtSubSectorType.Rows)
                {
                    objSubSectorTypeBiz = new SubSectorTypeBiz(DR);

                    this.Add(objSubSectorTypeBiz);
                }
            }

        }
        public virtual SubSectorTypeBiz this[int intIndex]
        {
            get
            {

                return (SubSectorTypeBiz)this.List[intIndex];

            }
        }
        public virtual SubSectorTypeBiz this[string strIndex]
        {
            get
            {
                SubSectorTypeBiz Returned = new SubSectorTypeBiz();
                foreach (SubSectorTypeBiz objSubSectorTypeBiz in this)
                {
                    if (objSubSectorTypeBiz.NameA == strIndex)
                    {
                        Returned = objSubSectorTypeBiz.Copy();
                        break;
                    }
                }
                return Returned;
            }
        }
        public virtual void Add(SubSectorTypeBiz objSubSectorTypeBiz)
        {
            if (this[objSubSectorTypeBiz.NameA].NameA == null || this[objSubSectorTypeBiz.NameA].NameA == "")
            {
                this.List.Add(objSubSectorTypeBiz.Copy());
            }

        }
        public virtual void Add(SubSectorTypeCol objSubSectorTypeCol)
        {
            foreach (SubSectorTypeBiz objSubSectorTypeBiz in objSubSectorTypeCol)
            {
                if (this[objSubSectorTypeBiz.NameA].ID == 0)
                    this.List.Add(objSubSectorTypeBiz.Copy());

            }
        }
        public SubSectorTypeCol Copy()
        {
            SubSectorTypeCol Returned = new SubSectorTypeCol(true);
            foreach (SubSectorTypeBiz objTemp in this)
            {
                Returned.Add(objTemp.Copy());
            }
            return Returned;
        }
        public static SubSectorTypeBiz GetSubSectorTypeBiz(int intID)
        {
            foreach (SubSectorTypeBiz objBiz in SubSectorTypeCol.CacheSubSectorTypeCol)
            {
                if (objBiz.ID == intID)
                {
                    return objBiz;
                }
            }
            return new SubSectorTypeBiz();
        }

        static SubSectorTypeCol _CacheSubSectorTypeCol;
        public static SubSectorTypeCol CacheSubSectorTypeCol
        {
            set
            {
                _CacheSubSectorTypeCol = value;
            }
            get
            {
                if (_CacheSubSectorTypeCol == null)
                {
                    _CacheSubSectorTypeCol = new SubSectorTypeCol(false);
                }
                return _CacheSubSectorTypeCol;
            }
        }
    }
}

