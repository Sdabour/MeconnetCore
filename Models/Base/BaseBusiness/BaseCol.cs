using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
namespace SharpVision.Base.BaseBusiness
{
    public class BaseCol : CollectionBase
    {
        public BaseCol()
        { 
        }
        public virtual BaseSingleBiz this[int intIndex]
        {
            get
            {
                return (BaseSingleBiz)this.List[intIndex];
            }
        }

       
       
        public virtual void Add(BaseSingleBiz objTempBiz)
        {
          

            this.List.Add(objTempBiz);
        }
      
        public virtual BaseCol Copy()
        {
            BaseCol Returned = new BaseCol();
             foreach (BaseSelfeRelatedBiz objBiz in this)
            {
               
                Returned.Add(objBiz);
            }
            return Returned;
        }
       
        public static void SetLinearCol(BaseCol objBaseCol, ref BaseCol objDesCol)
        {
            if (objDesCol == null)
                return;
            foreach (BaseSingleBiz objBiz in objBaseCol)
            {
                objDesCol.Add(objBiz);
                SetLinearCol(((BaseSelfeRelatedBiz)objBiz).Children, ref objDesCol);


            }
        }
        


    }

}
