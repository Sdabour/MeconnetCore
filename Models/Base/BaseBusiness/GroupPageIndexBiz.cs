using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
namespace SharpVision.Base.BaseBusiness
{
    public class GroupPageIndexBiz
    {
        public GroupPageIndexBiz(DataRow objDr)
        {
            _GroupIndex = int.Parse(objDr["GroupIndex"].ToString());
            _MaxID = int.Parse(objDr["MaxID"].ToString());
            _MinID = int.Parse(objDr["MinID"].ToString());
        }
        int _GroupIndex;

        public int GroupIndex
        {
            get { return _GroupIndex; }
            set { _GroupIndex = value; }
        }
        int _MaxID;

        public int MaxID
        {
            get { return _MaxID; }
            set { _MaxID = value; }
        }
        int _MinID;

        public int MinID
        {
            get { return _MinID; }
            set { _MinID = value; }
        }
    }
}