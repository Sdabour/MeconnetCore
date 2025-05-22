using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.UMS.UMSDataBase;
using SharpVision.Base.BaseBusiness;

namespace SharpVision.UMS.UMSBusiness
{



    public class FunctionBiz :BaseSelfeRelatedBiz
    {
        #region Private Data
        protected FunctionCol _FunctionFamily;
        protected FunctionCol _FunctionChildren;
        protected string _AncestorIDs;
        protected UserCol _UserCol;
        FunctionBiz _RootBiz;
       // FunctionCol _Children;
        #endregion
        #region Constructors
        public FunctionBiz()
        {

            _BaseDb= new FunctionDb();
        }
        public FunctionBiz(int intFunctionID)
        {
            _BaseDb = new FunctionDb(intFunctionID);
        }
        public FunctionBiz(DataRow DR)
        {
            _BaseDb = new FunctionDb(DR);
        }
        public FunctionBiz(FunctionDb objFunctionDb)
        {
            _BaseDb = objFunctionDb;
        }


        #endregion
        #region Public Properties
     
        public string Description
        {
            get
            {
                return ((FunctionDb)_BaseDb).Description;
            }
            set
            {

                ((FunctionDb)_BaseDb).Description = value;
            }
        }
        public FunctionBiz ParentBiz
        {
            set
            {
                _ParentBiz = value;
            }
            get
            {
                if (_ParentBiz == null)
                {
                    if (((FunctionDb)_BaseDb).ID == ((FunctionDb)_BaseDb).ParentID)
                        _ParentBiz = this;
                    else
                        _ParentBiz = new FunctionBiz(((FunctionDb)_BaseDb).ParentID);
                    
                }
                return(FunctionBiz) _ParentBiz;

            }
        }
        public FunctionBiz RootBiz
        {
            set
            {
                _RootBiz = value;
            }
            get
            {
                if (_RootBiz == null)
                {
                    _RootBiz = new FunctionBiz();

                }
                return _RootBiz;

            }
        }

        public FunctionCol FunctionFamily
        {
            set
            {
                _FunctionFamily = value;
            }
            get
            {
                return _FunctionFamily;
            }
        }
        public FunctionCol FunctionChildren
        {
            set
            {
                _FunctionChildren = value;
            }
            get
            {
                return _FunctionChildren;
            }
        }
        public FunctionCol Children
        {
            set
            {
                _Children = value;

            }
            get
            {
                return (FunctionCol)_Children;
            }
        }
        public int SysID
        {
            set
            {
                ((FunctionDb)_BaseDb).SysID = value;
            }
            get
            {
                return ((FunctionDb)_BaseDb).SysID;
            }
        }

        public string Url
        {
            set
            {
                ((FunctionDb)_BaseDb).Url = value;
            }
            get
            {

                if (((FunctionDb)_BaseDb).Url == null)
                    return "";
                return ((FunctionDb)_BaseDb).Url;
            }
        }
        public bool IsStoped
        {
            set
            {
                ((FunctionDb)_BaseDb).IsStoped = value;
            }
            get
            {
                return ((FunctionDb)_BaseDb).IsStoped;
            }
        }
        public UserCol UserCol
        {
            set
            {
                _UserCol = value;
            }
            get
            {
                if (_UserCol == null)
                {
                    _UserCol = new UserCol(true);
                    if (ID != 0)
                    {
                        GroupDb objGroupDb = new GroupDb();
                        objGroupDb.FunctionSearchStatus = 1;
                        objGroupDb.FunctionID = ID;
                        objGroupDb.FunctionAncestorStr = AncestorIDs;
                        DataTable dtGroup = objGroupDb.Search();
                        DataRow[] arrGroup = dtGroup.Select("", "GroupID");
                        string strGroup = "";
                        string strGroupIDs = "";
                        foreach (DataRow objDr in dtGroup.Rows)
                        {
                            if (strGroup != objDr["GroupID"].ToString())
                            {
                                strGroup = objDr["GroupID"].ToString();
                                if (strGroupIDs != "")
                                    strGroupIDs += ",";
                                strGroupIDs += strGroup;

                            }
 
                        }
                        UserDb objUserDb = new UserDb();
                        objUserDb.FunctionSearchStatus = 1;
                        objUserDb.FunctionID = ID;
                        objUserDb.FunctionAncestorStr = AncestorIDs;
                        objUserDb.FunctionGroupIDs = strGroupIDs;
                        DataTable dtUser = objUserDb.Search();
                        foreach (DataRow objDr in dtUser.Rows)
                        {
                            _UserCol.Add(new UserBiz(objDr));
                        }
                    }

                }
                
                return _UserCol;
            }
        }
        public string  AncestorIDs
        {
          
            get
            {
                string Returned = "";
                if (ID != ParentBiz.ID)
                {
                    Returned += ParentBiz.AncestorIDs;
                    if (Returned != "")
                        Returned += ",";
                    Returned +=  ParentBiz.ID.ToString();
                }
                return Returned;
            }
 
        }
        #endregion
        #region Private Methods

        #endregion
        #region Public Methods
        public void Add()
        {
            if (_ParentBiz == null)
                _ParentBiz = new FunctionBiz();
            ((FunctionDb)_BaseDb).ParentID = _ParentBiz.ID;
            ((FunctionDb)_BaseDb).FamilyID = _ParentBiz.FamilyID;
            //((FunctionDb)_BaseDb).SysID = sysid
            ((FunctionDb)_BaseDb).Add();
        }
        public void Edit()
        {
            if (_ParentBiz == null)
                _ParentBiz = new FunctionBiz();
            ((FunctionDb)_BaseDb).ParentID = _ParentBiz.ID;
            ((FunctionDb)_BaseDb).FamilyID = _ParentBiz.FamilyID;
           ((FunctionDb) _BaseDb).Edit();

        }

        public static void Add(string strNameA,string strNameE, string strDescription, int intParentID, int intFamilyID,int intSysID)
        {
            FunctionDb objFunctionDb = new FunctionDb();
            objFunctionDb.NameA = strNameA;
            objFunctionDb.NameE = strNameE;
            objFunctionDb.Description = strDescription;
            objFunctionDb.ParentID = intParentID;
            objFunctionDb.FamilyID = intFamilyID;
            objFunctionDb.SysID = intSysID;
            objFunctionDb.Add();
        }
        public static void Edit(int intID, string strNameA, string strNameE, string strDescription, int intParentID, int intFamilyID, int intSysID)
        {
            FunctionDb objFunctionDb = new FunctionDb();
            objFunctionDb.ID = intID;
            objFunctionDb.NameA = strNameA;
            objFunctionDb.NameE = strNameE;
            objFunctionDb.Description = strDescription;
            objFunctionDb.ParentID = intParentID;
            objFunctionDb.FamilyID = intFamilyID;
            objFunctionDb.SysID = intSysID;
            objFunctionDb.Edit();

        }
        public static void Delete(int intID)
        {
            FunctionDb objFunctionDb = new FunctionDb();
            objFunctionDb.ID = intID;
            objFunctionDb.Delete();
        }
        public FunctionBiz Copy()
        {
            FunctionBiz Returned = new FunctionBiz();
            Returned.ID = this.ID;
            Returned.NameA = this.NameA;
            Returned.NameE = this.NameE;
            Returned.Description = this.Description;
            Returned.ParentID = this.ParentID;
            Returned.ParentBiz = this.ParentBiz;
            Returned.FamilyID = this.FamilyID;
            Returned.FunctionChildren = this.FunctionChildren;

            return Returned;
        }
        #endregion
    }


}
