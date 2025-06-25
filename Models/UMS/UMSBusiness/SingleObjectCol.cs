using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
namespace SharpVision.UMS.UMSBusiness
{
   public  class SingleObjectCol:CollectionBase
    {
        Hashtable hsTemp = new Hashtable();
        public SingleObjectCol()
        { 
        }
        public SingleObjectBiz this[int intIndex]
        { get => (SingleObjectBiz)List[intIndex]; 
        }
        public SingleObjectBiz this[string strIndex]
        {
            get
            {
                SingleObjectBiz Returned = new SingleObjectBiz();
                if (hsTemp[strIndex] != null)
                    Returned = (SingleObjectBiz)hsTemp[strIndex];
                return Returned;
            }
        }
        public void Add(SingleObjectBiz objBiz)
        {
            if (hsTemp[objBiz.ID.ToString()] == null)
            {
                hsTemp.Add(objBiz.ID.ToString(), objBiz);
                List.Add(objBiz);
            }
        }
    }
}
