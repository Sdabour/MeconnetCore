using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.Base.BaseDataBase;
namespace SharpVision.Base.BaseBusiness
{
    public abstract class BaseSelfeRelatedBiz : BaseSingleBiz
    {
        #region Protected Data
        //protected BaseSelfRelatedDb _BaseDb;
        protected BaseCol _Children;
        protected BaseSelfeRelatedBiz _ParentBiz;

        protected static int _CodeLength = 8;

        #endregion
        #region Public Properties
        public virtual int ParentID
        {
            set
            {
                ((BaseSelfRelatedDb)_BaseDb).ParentID = value;

               
            }
            get
            {
                return ((BaseSelfRelatedDb)_BaseDb).ParentID;
            }
        }
        public virtual int FamilyID
        {
            set
            {
                ((BaseSelfRelatedDb)_BaseDb).FamilyID = value;

            }
            get
            {
                return ((BaseSelfRelatedDb)_BaseDb).FamilyID;
            }
 
        }
        public static int CodeLength
        {
            set
            {
                _CodeLength = value;
            }
            get
            {
                return _CodeLength;
            }
        }
        public virtual BaseCol Children
        {
            set
            {
                _Children = value;
            }
            get
            {
                return _Children;
            }
        }
        public virtual BaseSelfeRelatedBiz ParentBiz
        {
            set
            {
                _ParentBiz = value;
            }
            get
            {
                return _ParentBiz;
            }
        }
        public virtual string IDsStr
        {
            get
            {
                if (_BaseDb.ID == 0)
                    return "";
                else
                {
                    string strReturned = "";
                    strReturned = _BaseDb.ID.ToString();
                    if (_Children == null)
                        return strReturned;
                    foreach (BaseSelfeRelatedBiz objBiz in Children)
                    {

                        strReturned = strReturned + "," + objBiz.IDsStr;
                    }
                    return strReturned;

                }
            }
        }
        #endregion
    }
}
