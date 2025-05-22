using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.Base.BaseDataBase;
namespace SharpVision.Base.BaseBusiness
{
    public abstract class BaseSingleBiz
    {
   #region Protected Data
        protected BaseSingleDb _BaseDb;
		 
	#endregion
        public virtual string NameE
        {
            set
            {
                _BaseDb.NameE = value;
            }
            get
            {
                return _BaseDb.NameE;
            }
        }
        public virtual string NameA
        {
            set
            {
                _BaseDb.NameA = value;
            }
            get
            {
                return _BaseDb.NameA;
            }
        }
        public virtual string Name
        {
            get
            {

                if (_BaseDb.Name == null)
                    _BaseDb.NameA = "";
                return _BaseDb.Name;
            }
        }
        public virtual string Code
        {
            set
            {
                _BaseDb.Code = value;
            }
            get
            {
                if (_BaseDb.Code == null)
                    return "";
                return _BaseDb.Code;
            }
        }
        public virtual int ID
        {
            get 
            { 
                return _BaseDb.ID;
            }
            set
            {
                _BaseDb.ID = value; 
            }
        }
        
        public SerializableBiz SerializableObject
        {
            get
            {
                SerializableBiz Returned = new SerializableBiz(ID, Code, Name,0);
                return Returned;
            }
        }
        public static int Language
        {
            set
            {
                BaseSingleDb.Language = value;
            }
        }
    }
}
