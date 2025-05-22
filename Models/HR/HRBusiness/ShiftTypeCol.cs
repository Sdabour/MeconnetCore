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
    public class ShiftTypeCol : CollectionBase
    {
        public ShiftTypeCol()
        {
            ShiftTypeBiz objBiz;

            ShiftTypeDb objDb = new ShiftTypeDb();
            DataTable dtTemp = objDb.Search();
            

            foreach (DataRow DR in dtTemp.Rows)
            {
                objBiz = new ShiftTypeBiz(DR);

                this.Add(objBiz);
            }

        }
        public ShiftTypeCol(bool blIsEmpty)
        {
            if (!blIsEmpty)
            {
                ShiftTypeBiz objBiz;
                objBiz = new ShiftTypeBiz();
                objBiz.ID = 0;
                objBiz.NameA = "غير محدد";
                this.Add(objBiz);
                ShiftTypeDb objDb = new ShiftTypeDb();
                DataTable dtTemp = objDb.Search();


                foreach (DataRow DR in dtTemp.Rows)
                {
                    objBiz = new ShiftTypeBiz(DR);

                    this.Add(objBiz);
                }
            }

        }
        public ShiftTypeCol(bool blIsEmpty,int intShiftType)
        {
            if (!blIsEmpty)
            {
                ShiftTypeBiz objBiz;
                objBiz = new ShiftTypeBiz();
                objBiz.ID = 0;
                objBiz.NameA = "غير محدد";
                this.Add(objBiz);
                ShiftTypeDb objDb = new ShiftTypeDb();
                objDb.ID = intShiftType;
                DataTable dtTemp = objDb.Search();

                
                foreach (DataRow DR in dtTemp.Rows)
                {
                    objBiz = new ShiftTypeBiz(DR);

                    this.Add(objBiz);
                }
            }

        }
        public virtual ShiftTypeBiz this[int intIndex]
        {
            get
            {

                return (ShiftTypeBiz)this.List[intIndex];

         }   }

        public virtual ShiftTypeBiz this[string strIndex]
        {
            get
            {
                ShiftTypeBiz Returned = new ShiftTypeBiz();
                foreach (ShiftTypeBiz objBiz in this)
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


        public virtual void Add(ShiftTypeBiz objBiz)
        {
            if (this[objBiz.Name].Name == null || this[objBiz.Name].Name == "")
            {
                this.List.Add(objBiz.Copy());
            }

        }


        public virtual void Add(ShiftTypeCol objCol)
        {
            foreach (ShiftTypeBiz objBiz in objCol)
            {
                if (this[objBiz.Name].ID == 0)
                    this.List.Add(objBiz.Copy());

            }
        }

        public ShiftTypeCol Copy()
        {
            ShiftTypeCol Returned = new ShiftTypeCol(true);
            foreach (ShiftTypeBiz objTemp in this)
            {
                Returned.Add(objTemp.Copy());
            }
            return Returned;
        }
        public static ShiftTypeBiz GetShiftTypeBiz(int intID)
        {
            foreach (ShiftTypeBiz objBiz in ShiftTypeCol.CacheShiftTypeCol)
            {
                if (objBiz.ID == intID)
                {
                    return objBiz;
                }
            }
            return new ShiftTypeBiz();
        }

        static ShiftTypeCol _CacheShiftTypeCol;
        public static ShiftTypeCol CacheShiftTypeCol
        {
            set
            {
                _CacheShiftTypeCol = value;
            }
            get
            {
                if (_CacheShiftTypeCol == null)
                {
                    _CacheShiftTypeCol = new ShiftTypeCol(false);
                }
                return _CacheShiftTypeCol;
            }
        }
    }
}
