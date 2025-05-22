using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.UMS.UMSDataBase;

namespace SharpVision.UMS.UMSBusiness
{

    public class GroupTypeBiz
    {
        #region Private Data
        protected GroupTypeDb _GroupTypeDb;
        protected GroupTypeCol _GroupTypeFamily;
        protected GroupTypeCol _GroupTypeChildren;
        protected GroupTypeBiz _ParentBiz;
        #endregion
        #region Constructors
        public GroupTypeBiz()
        {
            _GroupTypeDb = new GroupTypeDb();
        }
        public GroupTypeBiz(int intGroupTypeID)
        {
            _GroupTypeDb = new GroupTypeDb(intGroupTypeID);
        }
        public GroupTypeBiz(DataRow objDR)
        {
            _GroupTypeDb = new GroupTypeDb(objDR);
        }
      
       public GroupTypeBiz(GroupTypeDb objGroupTypeDb)
       {
           _GroupTypeDb = objGroupTypeDb;
       }
        #endregion
        #region Public Properties
        public int ID
        {
            set
            {
                _GroupTypeDb.ID = value;
            }
            get
            {
                return _GroupTypeDb.ID;
            }
        }
        public string Name
        {
            set
            {
                _GroupTypeDb.Name = value;
            }
            get
            {
                return _GroupTypeDb.Name;
            }
        }
        
        public int ParentID
        {
            set
            {
                _GroupTypeDb.ParentID = value;
            }
            get
            {
                return _GroupTypeDb.ParentID;
            }
        }
    
       public virtual  GroupTypeBiz ParentBiz
       {
           set
           {
               _ParentBiz = value;
           }
           get
           {
               if (_ParentBiz == null)
               {
                   if (_GroupTypeDb.ID == _GroupTypeDb.ParentID)
                       _ParentBiz =  this;
                   else
                       _ParentBiz =  new GroupTypeBiz(_GroupTypeDb.ParentID);
               }
               return _ParentBiz;

           }
       }
       public int FamilyID
       {
           get
           {
              return  _GroupTypeDb.FamilyID;
           }
       }
       public GroupTypeCol GroupTypeFamily
       {
           set
           {
               _GroupTypeFamily = value;
           }
           get
           {
               return _GroupTypeFamily;
           }
       }
       public GroupTypeCol GroupTypeChildren
       {
           set
           {
               _GroupTypeChildren = value;
           }
           get
           {
               return _GroupTypeChildren;
           }
       }
        #endregion
        #region Public Methods
        public static void Add(string strGroupTypeName,int intParentID,int intFamilyID)
        {
            GroupTypeDb objGroupTypeDb = new GroupTypeDb();
            objGroupTypeDb.Name = strGroupTypeName;
            objGroupTypeDb.ParentID = intParentID;
            objGroupTypeDb.FamilyID = intFamilyID;
            objGroupTypeDb.Add();
        }
        public static void Edit(int intGroupTypeID,string strGroupTypeName,int intGroupTypeParentID,int intFamilyID)
        {
            GroupTypeDb objGroupTypeDb = new GroupTypeDb();
            objGroupTypeDb.ID = intGroupTypeID;
            objGroupTypeDb.Name = strGroupTypeName;
            objGroupTypeDb.ParentID = intGroupTypeParentID;
            objGroupTypeDb.FamilyID = intFamilyID;
            objGroupTypeDb.Edit();
        }
        public static void Delete(int intGroupTypeID)
        {
            GroupTypeDb objGroupTypeDb = new GroupTypeDb();
            objGroupTypeDb.ID = intGroupTypeID;
            objGroupTypeDb.Delete();
        }
        public virtual GroupTypeBiz Copy()
        {
            GroupTypeBiz Returned = new GroupTypeBiz();
            Returned.ID = this.ID;
            Returned.Name = this.Name;
            Returned.ParentID = this.ParentID;
            Returned.ParentBiz = this.ParentBiz;
            Returned.GroupTypeFamily = this.GroupTypeFamily;
            Returned.GroupTypeChildren = this.GroupTypeChildren;
            return Returned;
        }
        #endregion
    }
}
