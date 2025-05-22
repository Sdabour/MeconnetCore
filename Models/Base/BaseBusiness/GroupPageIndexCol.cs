using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Collections;
namespace SharpVision.Base.BaseBusiness
{
    public class GroupPageIndexCol:CollectionBase
    {
        public GroupPageIndexCol()
        { }
        public GroupPageIndexCol(DataTable dtTemp)
        { 
            foreach(DataRow objDr in dtTemp.Rows)
            {
                Add(new GroupPageIndexBiz(objDr));
            }
        }
        public GroupPageIndexBiz this[int intIndex]
        {
            get
            {
                return (GroupPageIndexBiz)List[intIndex];
            }

        }
        public void Add(GroupPageIndexBiz objBiz)
        {
            List.Add(objBiz);
        }
    }
}