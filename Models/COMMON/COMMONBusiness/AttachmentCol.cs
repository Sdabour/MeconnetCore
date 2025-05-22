using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.COMMON.COMMONDataBase;
using System.Collections;

namespace SharpVision.COMMON.COMMONBusiness
{
    public class AttachmentCol : CollectionBase 
    {
        public AttachmentCol()
        {
 
        }
        public AttachmentCol(bool blIsEmpty)
        {
 
        }
        public AttachmentBiz this[int intIndex]
        {
            get
            {
                return (AttachmentBiz) List[intIndex];
            }
        }
        public void Add(AttachmentBiz objBiz)
        {
            List.Add(objBiz);
        }
    }
}
