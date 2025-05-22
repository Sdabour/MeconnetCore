using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.UMS.UMSDataBase;

namespace SharpVision.UMS.UMSBusiness
{
  public   class UserFunctionInstantBiz
    {
       #region Private Data

        UserFunctionInstantDb _UserFunctionInstantDb;
        UserBiz _UserBiz;
        #endregion
       #region Constructors
        public UserFunctionInstantBiz()
        {
            _UserFunctionInstantDb = new UserFunctionInstantDb();
            _UserBiz = new UserBiz();
        }
        public UserFunctionInstantBiz(int intUserID)
        {
            _UserFunctionInstantDb = new UserFunctionInstantDb(intUserID);
            _UserBiz = new UserBiz(_UserFunctionInstantDb.UserDb);
        }
        public UserFunctionInstantBiz(DataRow objDR)
        {
            _UserFunctionInstantDb = new UserFunctionInstantDb(objDR);
            _UserBiz = new UserBiz();
        }
      public UserFunctionInstantBiz(FunctionBiz objFunctionBiz)
      {
          _UserFunctionInstantDb = new UserFunctionInstantDb();
          this.ID = objFunctionBiz.ID;
          this.NameE = objFunctionBiz.NameE;
          this.NameA = objFunctionBiz.NameA;
          this.ParentID = objFunctionBiz.ParentID;
          this.FamilyID = objFunctionBiz.FamilyID;
          this.Description = objFunctionBiz.Description;
      }
      public UserFunctionInstantBiz(UserFunctionInstantDb objUserFunctionInstantDb)
      {
          _UserFunctionInstantDb = objUserFunctionInstantDb;
      }

      
       

        #endregion
       #region Public properties
        public int ID
        {
            get
            {
                return _UserFunctionInstantDb.ID;
            }
            set
            {
                _UserFunctionInstantDb.ID = value;
            }

        }
        public string Name
        {

            get
            {
                if (UserBiz.Language == 0)
                {
                    return _UserFunctionInstantDb.NameA;
                }
                else
                    return _UserFunctionInstantDb.NameE;
            }
           
           
        }
        public string NameA
        {

            get
            {
                return _UserFunctionInstantDb.NameA;
            }
            set
            {
                _UserFunctionInstantDb.NameA = value;
            }
        }
        public string NameE
        {

            get
            {
                return _UserFunctionInstantDb.NameE;
            }
            set
            {
                _UserFunctionInstantDb.NameE = value;
            }
        }
        public string Description
        {

            get
            {
                return _UserFunctionInstantDb.Description;
            }
            set
            {
                _UserFunctionInstantDb.Description = value;
            }
        }
      public int ParentID
      {
          get
          {
              return _UserFunctionInstantDb.ParentID;
          }
          set
          {
              _UserFunctionInstantDb.ParentID = value; ;
          }
      }
      public int FamilyID
      {
          get
          {
              return _UserFunctionInstantDb.FamilyID;
          }
          set
          {
              _UserFunctionInstantDb.FamilyID = value;
          }
      }
        public string Url
        {

            get
            {
                return _UserFunctionInstantDb.Url;
            }
            set
            {
                _UserFunctionInstantDb.Url = value;
            }
        }
        public int SysID
      {
          set
          {
              _UserFunctionInstantDb.SysID=value;
          }
          get 
          {
              return _UserFunctionInstantDb.SysID;
          }
      }
      public DateTime StartDate
      {
          set
          {
              _UserFunctionInstantDb.StartDate = value;
          }
          get
          {
              return _UserFunctionInstantDb.StartDate;
          }
      }
      public DateTime EndDate
      {
          set
          {
              _UserFunctionInstantDb.EndDate = value;
          }
          get
          {
              return _UserFunctionInstantDb.EndDate;
          }
      }
      public bool IsPermanent
      {
          set
          {
              _UserFunctionInstantDb.IsPermenant = value;
          }
          get
          {
              return _UserFunctionInstantDb.IsPermenant;
          }
      }
      public bool IsAdmin
      {
          set
          {
              _UserFunctionInstantDb.IsAdmin = value;
          }
          get
          {
              return _UserFunctionInstantDb.IsAdmin;
          }
      }
      public UserBiz UserBiz
      {
          set
          {
              _UserBiz = value;
          }
          get
          {
              return _UserBiz;
          }
      }

       #endregion
       #region Public Methods
       public UserFunctionInstantBiz Copy()
       {
           UserFunctionInstantBiz Returned = new UserFunctionInstantBiz();
           Returned.ID = _UserFunctionInstantDb.ID;
           Returned.NameA = _UserFunctionInstantDb.NameA;
           Returned.NameE = _UserFunctionInstantDb.NameE;
         
           Returned.Description = _UserFunctionInstantDb.Description;
           Returned.ParentID = _UserFunctionInstantDb.ParentID;
           Returned.FamilyID = _UserFunctionInstantDb.FamilyID;
           Returned.StartDate = _UserFunctionInstantDb.StartDate;
           Returned.EndDate = _UserFunctionInstantDb.EndDate;
           Returned.IsPermanent = _UserFunctionInstantDb.IsPermenant;
           Returned._UserBiz = new UserBiz(_UserFunctionInstantDb.UserDb);
           return Returned;

       }

       #endregion

    }
}
