using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
namespace SharpVision.Base.BaseDataBase
{
    public abstract class BaseSelfRelatedDb : BaseSingleDb
    {
        #region Protected Data
        protected int _ParentID;
        protected int _FamilyID;
        //protected string _Code;
        
        #endregion
        #region Public Data

        public virtual int ParentID
        {
            set
            {
                _ParentID = value;
            }
            get
            {
                return _ParentID;
            }
        }

        public virtual int FamilyID
        {
            set
            {
                _FamilyID = value;
            }
            get
            {
                return _FamilyID;
            }
        }
       
        
         #endregion
    }
}
