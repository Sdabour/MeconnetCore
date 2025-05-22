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
    public class ShiftCol : CollectionBase
    {
        public ShiftCol()
        {
            ShiftBiz objBiz;

            ShiftDb objDb = new ShiftDb();
            DataTable dtTemp = objDb.Search();
            

            foreach (DataRow DR in dtTemp.Rows)
            {
                objBiz = new ShiftBiz(DR);

                this.Add(objBiz);
            }

        }
        public ShiftCol(ShiftTypeBiz objShiftTypeBiz)
        {
            ShiftBiz objBiz;

            ShiftDb objDb = new ShiftDb();
            objDb.ShiftType = objShiftTypeBiz.ID;
            DataTable dtTemp = objDb.Search();


            foreach (DataRow DR in dtTemp.Rows)
            {
                objBiz = new ShiftBiz(DR);

                this.Add(objBiz);
            }

        }
        public ShiftCol(ShiftTypeBiz objShiftTypeBiz, bool blIsEmpty,int intIsStop)
        {
            ShiftBiz objBiz;
            if (!blIsEmpty)
            {
                objBiz = new ShiftBiz();
                objBiz.ID = 0;
                objBiz.NameA = "غير محدد";
                this.Add(objBiz);
            }
           
            ShiftDb objDb = new ShiftDb();
            if (objShiftTypeBiz.ID == 0)
                return;
            objDb.ShiftType = objShiftTypeBiz.ID;
            objDb.IsStopSearch = intIsStop;

            DataTable dtTemp = objDb.Search();


            foreach (DataRow DR in dtTemp.Rows)
            {
                objBiz = new ShiftBiz(DR);

                this.Add(objBiz);
            }

        }
        public ShiftCol(bool blIsEmpty)
        {
            if (!blIsEmpty)
            {
                ShiftBiz objBiz;
                objBiz = new ShiftBiz();
                objBiz.ID = 0;
                objBiz.NameA = "غير محدد";
                this.Add(objBiz);
                ShiftDb objDb = new ShiftDb();
                DataTable dtTemp = objDb.Search();


                foreach (DataRow DR in dtTemp.Rows)
                {
                    objBiz = new ShiftBiz(DR);

                    this.Add(objBiz);
                }
            }

        }
        public virtual ShiftBiz this[int intIndex]
        {
            get
            {

                return (ShiftBiz)this.List[intIndex];

         }   }

        public virtual ShiftBiz this[string strIndex]
        {
            get
            {
                ShiftBiz Returned = new ShiftBiz();
                foreach (ShiftBiz objBiz in this)
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


        public virtual void Add(ShiftBiz objBiz)
        {
            if (this[objBiz.Name].Name == null || this[objBiz.Name].Name == "")
            {
                this.List.Add(objBiz);
            }

        }


        public virtual void Add(ShiftCol objCol)
        {
            foreach (ShiftBiz objBiz in objCol)
            {
                if (this[objBiz.Name].ID == 0)
                    this.List.Add(objBiz.Copy());

            }
        }

        public ShiftCol Copy()
        {
            ShiftCol Returned = new ShiftCol(true);
            foreach (ShiftBiz objTemp in this)
            {
                Returned.Add(objTemp.Copy());
            }
            return Returned;
        }
        public static ShiftBiz GetShiftBiz(int intID)
        {
            foreach (ShiftBiz objBiz in ShiftCol.CacheShiftCol)
            {
                if (objBiz.ID == intID)
                {
                    return objBiz;
                }
            }
            return new ShiftBiz();
        }

        static ShiftCol _CacheShiftCol;
        public static ShiftCol CacheShiftCol
        {
            set
            {
                _CacheShiftCol = value;
            }
            get
            {
                if (_CacheShiftCol == null)
                {
                    _CacheShiftCol = new ShiftCol(false);
                }
                return _CacheShiftCol;
            }
        }
    }
}
