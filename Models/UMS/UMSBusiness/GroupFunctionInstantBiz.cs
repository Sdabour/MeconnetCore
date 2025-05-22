using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.UMS.UMSDataBase;

namespace SharpVision.UMS.UMSBusiness
{
   public  class GroupFunctionInstantBiz
    {
        #region Private Data

        GroupFunctionInstantDb _GroupFunctionInstantDb;
        GroupBiz _GroupBiz;
        #endregion
        #region Constructors
        public GroupFunctionInstantBiz()
        {
            _GroupFunctionInstantDb = new GroupFunctionInstantDb();
            _GroupBiz = new GroupBiz();
        }
        public GroupFunctionInstantBiz(int inGroupID)
        {
            _GroupFunctionInstantDb = new GroupFunctionInstantDb(inGroupID);
            _GroupBiz = new GroupBiz(_GroupFunctionInstantDb.GroupDb);
        }
        public GroupFunctionInstantBiz(DataRow objDR)
        {
            _GroupFunctionInstantDb = new GroupFunctionInstantDb(objDR);
            //_GroupBiz = new GroupBiz(objDR);
        }
      public GroupFunctionInstantBiz(FunctionBiz objFunctionBiz)
      {
          _GroupFunctionInstantDb = new GroupFunctionInstantDb();
          this.ID = objFunctionBiz.ID;
          this.Name = objFunctionBiz.Name;
          this.ParentID = objFunctionBiz.ParentID;
          this.FamilyID = objFunctionBiz.FamilyID;
          this.Description = objFunctionBiz.Description;
          
      }
      public GroupFunctionInstantBiz(GroupFunctionInstantDb objGroupFunctionInstantDb)
      {
          _GroupFunctionInstantDb = objGroupFunctionInstantDb;
      }

      
       

        #endregion
        #region Public properties
        public int ID
        {
            get
            {
                return _GroupFunctionInstantDb.ID;
            }
            set
            {
                _GroupFunctionInstantDb.ID = value;
            }

        }
        public string Name
        {

            get
            {
                if (UserBiz.Language == 0)
                {
                    return _GroupFunctionInstantDb.NameA;
                }
                else
                    return _GroupFunctionInstantDb.NameE;
            }
            set
            {
                _GroupFunctionInstantDb.NameA = value;
            }
        }
       public string NameA
       {

           get
           {
               return _GroupFunctionInstantDb.NameA;
           }
           set
           {
               _GroupFunctionInstantDb.NameA = value;
           }
       }
       public string NameE
       {

           get
           {
               return _GroupFunctionInstantDb.NameE;
           }
           set
           {
               _GroupFunctionInstantDb.NameE = value;
           }
       } 
       public string Description
        {

            get
            {
                return _GroupFunctionInstantDb.Description;
            }
            set
            {
                _GroupFunctionInstantDb.Description = value;
            }
        }
      public int ParentID
      {
          get
          {
              return _GroupFunctionInstantDb.ParentID;
          }
          set
          {
              _GroupFunctionInstantDb.ParentID = value; ;
          }
      }
      public int FamilyID
      {
          get
          {
              return _GroupFunctionInstantDb.FamilyID;
          }
          set
          {
              _GroupFunctionInstantDb.FamilyID = value;
          }
      }
      public DateTime StartDate
      {
          set
          {
              _GroupFunctionInstantDb.StartDate = value;
          }
          get
          {
              return _GroupFunctionInstantDb.StartDate;
          }
      }
      public DateTime EndDate
      {
          set
          {
              _GroupFunctionInstantDb.EndDate = value;
          }
          get
          {
              return _GroupFunctionInstantDb.EndDate;
          }
      }
      public bool IsPermanent
      {
          set
          {
              _GroupFunctionInstantDb.IsPermenant = value;
          }
          get
          {
              return _GroupFunctionInstantDb.IsPermenant;
          }
      }
       public bool IsAdmin
       {
           set
           {
               _GroupFunctionInstantDb.IsAdmin = value;
           }
           get
           {
               return _GroupFunctionInstantDb.IsAdmin;
           }
       }
      public GroupBiz GroupBiz
      {
          set
          {
              _GroupBiz = value;
          }
          get
          {
              return _GroupBiz;
          }
      }
       public int UserID
       {
           set
           {
               _GroupFunctionInstantDb.UserID = value;
           }
           get
           {
               return _GroupFunctionInstantDb.UserID;
           }
       }

       public int SysID
       {
           set
           {
               _GroupFunctionInstantDb.SysID = value;
           }
           get
           {
               return _GroupFunctionInstantDb.SysID;
           }
       }
     
        #endregion
        #region Public Methods
      public GroupFunctionInstantBiz Copy()
      {
          GroupFunctionInstantBiz Returned = new GroupFunctionInstantBiz();
          Returned.ID = _GroupFunctionInstantDb.ID;
          Returned.NameA = _GroupFunctionInstantDb.NameA;
          Returned.NameE = _GroupFunctionInstantDb.NameE;
          Returned.Description = _GroupFunctionInstantDb.Description;
          Returned.ParentID = _GroupFunctionInstantDb.ParentID;
          Returned.FamilyID = _GroupFunctionInstantDb.FamilyID;
          Returned.StartDate = _GroupFunctionInstantDb.StartDate;
          Returned.EndDate = _GroupFunctionInstantDb.EndDate;
          Returned.IsPermanent = _GroupFunctionInstantDb.IsPermenant;
          Returned.IsAdmin = _GroupFunctionInstantDb.IsAdmin;
          Returned.UserID = _GroupFunctionInstantDb.UserID;
          Returned._GroupBiz = new GroupBiz(_GroupFunctionInstantDb.GroupDb);
          return Returned;

      }

        #endregion

    }
}
