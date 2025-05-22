using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.UMS.UMSDataBase;
using SharpVision.Base.BaseBusiness;
namespace SharpVision.UMS.UMSBusiness
{



    public class GroupBiz:BaseSelfeRelatedBiz
    {
        #region Private Data
       
        GroupCol _GroupFamily;
        GroupCol _GroupChildren;
       // GroupBiz _ParentBiz;
        GroupTypeBiz _GroupTypeBiz;
        GroupTypeDb _GroupTypeDb;
        GroupFunctionInstantCol _GroupFunctionInstantCol;

        

        #endregion
        #region Constructors
        public GroupBiz()
        {
            _BaseDb = new GroupDb();
            _GroupTypeDb = new GroupTypeDb();
        }
        public GroupBiz(int intGroupID)
        {
            if (intGroupID == 0)
            {
                _BaseDb = new GroupDb();
                return;
            }
                _BaseDb = new GroupDb(intGroupID);
            _GroupTypeBiz = new GroupTypeBiz(((GroupDb)_BaseDb).GroupTypeDb);
        }
        public GroupBiz(DataRow objDR)
        {
            _BaseDb = new GroupDb(objDR);
            _GroupTypeBiz = new GroupTypeBiz(((GroupDb)_BaseDb).GroupTypeDb);
        }
        public GroupBiz(string strText, int intParentID, int intFamilyID,int intGroupTypeID)
        {
            _BaseDb = new GroupDb(strText, intParentID, intFamilyID,intGroupTypeID);
        }
        public GroupBiz(GroupDb objGroupDb)
        {
           // objGroupDb = new GroupDb();
            _BaseDb = objGroupDb;
            try
            {
                _GroupTypeBiz = new GroupTypeBiz(((GroupDb)_BaseDb).GroupTypeDb);
            }
            catch { }
        }

        #endregion
        #region Public Properties
        public int   GroupTypeID //int
        {
            get { return _GroupTypeDb.ID; }
            set {
                if (_GroupTypeDb == null)
                    _GroupTypeDb = new GroupTypeDb();
                _GroupTypeDb.ID = value; }
        } 
        public GroupCol Children
        {
            set
            {
                _Children = value;
            }
            get
            {
                return (GroupCol)_Children;
            }
        }
        public GroupBiz ParentBiz
        {
            set
            {
                _ParentBiz = value;
            }
            get
            {
                if (_ParentBiz == null)
                {
                    if (((GroupDb)_BaseDb).ID == ((GroupDb)_BaseDb).ParentID)
                        _ParentBiz = this;
                    else
                        _ParentBiz = new GroupBiz(((GroupDb)_BaseDb).ParentID);
                }
                return (GroupBiz)_ParentBiz;

            }
        }
        public GroupFunctionInstantCol GroupFunctionInstantColCanceled
        {
            set
            {
                _GroupFunctionInstantCol = value;

            }
            get
            {
                if (_GroupFunctionInstantCol == null)
                {
                    
                    DataTable dtTemp = ((GroupDb)_BaseDb).GetAllGroupFunction();

                    _GroupFunctionInstantCol = new GroupFunctionInstantCol(true);
                    GroupFunctionInstantBiz tempGroupFunctionInstantBiz;
                    foreach (DataRow DR in dtTemp.Rows)
                    {
                        tempGroupFunctionInstantBiz = new GroupFunctionInstantBiz(DR);
                        _GroupFunctionInstantCol.Add(tempGroupFunctionInstantBiz);

                    }
                   // return _GroupFunctionInstantCol;
                }
              
                    return _GroupFunctionInstantCol;
            }
        }
        public GroupFunctionInstantCol GroupFunctionInstantCol
        {
            set
            {
                _GroupFunctionInstantCol = value;

            }
            get
            {
                if (_GroupFunctionInstantCol == null)
                {

                    _GroupFunctionInstantCol = new GroupFunctionInstantCol(true);
                    if (ID != 0)
                    {
                        GroupFunctionInstantDb objDb = new GroupFunctionInstantDb();
                        objDb.GroupID = ID;
                        DataTable dtTemp = objDb.PureSearch();
                        _GroupFunctionInstantCol = new GroupFunctionInstantCol(true);
                        GroupFunctionInstantBiz tempGroupFunctionInstantBiz;
                        foreach (DataRow DR in dtTemp.Rows)
                        {
                            tempGroupFunctionInstantBiz = new GroupFunctionInstantBiz(DR);
                            _GroupFunctionInstantCol.Add(tempGroupFunctionInstantBiz);

                        }
                    }
                    // return _GroupFunctionInstantCol;
                }

                return _GroupFunctionInstantCol;
            }
        }

        public GroupCol GroupFamily
        {
            set
            {
                _GroupFamily = value;
            }
            get
            {
                return _GroupFamily;
            }
        }
        public GroupCol GroupChildren
        {
            set
            {
                _GroupChildren = value;
            }
            get
            {
                return _GroupChildren;
            }
        }
        public GroupTypeBiz GroupTypeBiz
        {
            set
            {
                _GroupTypeBiz = value;
            }
            get
            {
              //  _GroupTypeBiz = new GroupTypeBiz(((GroupDb)_BaseDb).GroupTypeDb);
                return _GroupTypeBiz;
            }
        }
        #endregion
        #region Public Methods
        
        public static void Add(string strText, int intParentID, int intFamilyID,int intGroupTypeID,GroupFunctionInstantCol objGroupFunctionInstantCol)
        {
            int intCUrrentID = 0;
            GroupDb objGroupDb = new GroupDb();
            objGroupDb.NameA = strText;
            objGroupDb.ParentID = intParentID;
            objGroupDb.FamilyID = intFamilyID;
            objGroupDb.TypeID = intGroupTypeID;
            objGroupDb.Add();
            intCUrrentID = objGroupDb.ID;

            JoinFunction(objGroupDb.ID, objGroupFunctionInstantCol);
        }
        public static void Edit(int intGroupID, string strText, int intParentID, int intFamilyID, int intGroupTypeID, GroupFunctionInstantCol objGroupFunctionInstantCol)
        {
            GroupDb objGroupDb = new GroupDb();
            objGroupDb.ID = intGroupID;
            objGroupDb.NameA = strText;
            objGroupDb.ParentID = intParentID;
            objGroupDb.FamilyID = intFamilyID;
            objGroupDb.TypeID = intGroupTypeID;
            objGroupDb.Edit();
            JoinFunction(objGroupDb.ID, objGroupFunctionInstantCol);
        }
        public static void Delete(int intGroupID)
        {
            GroupDb objGroupDb = new GroupDb();
            objGroupDb.ID = intGroupID;
            objGroupDb.Delete();
        }
        public static void JoinFunction(int intGroupID, GroupFunctionInstantCol objGroupFunctionInstantCol)
        {
            GroupDb objGroupDb = new GroupDb();

            objGroupDb.ID = intGroupID;
            DataTable dtTemp = new DataTable();
            DataColumn dcTemp = new DataColumn("FunctionID");
            dtTemp.Columns.Add(dcTemp);
            dcTemp = new DataColumn("IsPermanent");
            dtTemp.Columns.Add(dcTemp);
            dcTemp = new DataColumn("IsAdmin");
            dtTemp.Columns.Add(dcTemp);
            dcTemp = new DataColumn("StartDate");
            dtTemp.Columns.Add(dcTemp);
            dcTemp = new DataColumn("EndDate");
            dtTemp.Columns.Add(dcTemp);

            DataRow drTemp;
            foreach (GroupFunctionInstantBiz objGroupFunctionInstantBiz in objGroupFunctionInstantCol)
            {
                drTemp = dtTemp.NewRow();
                drTemp["FunctionID"] = objGroupFunctionInstantBiz.ID;
                drTemp["IsPermanent"] = objGroupFunctionInstantBiz.IsPermanent;
                drTemp["IsAdmin"] = objGroupFunctionInstantBiz.IsAdmin;
                drTemp["StartDate"] = objGroupFunctionInstantBiz.StartDate;
                drTemp["EndDate"] = objGroupFunctionInstantBiz.EndDate;
                dtTemp.Rows.Add(drTemp);

            }
            objGroupDb.Function = dtTemp;
            objGroupDb.JoinFunction();
        }
        public GroupBiz Copy()
        {
            GroupBiz Returned = new GroupBiz();
            Returned.ID = this.ID;
            Returned.NameA = this.Name;
            Returned.ParentID = this.ParentID;
            Returned.FamilyID = this.FamilyID;
            //Returned.GroupTypeID = this.GroupTypeID;
            Returned.ParentBiz = this.ParentBiz;
            Returned.GroupFamily = this.GroupFamily;
            Returned.GroupChildren = this.GroupChildren;
            Returned.GroupTypeBiz = this.GroupTypeBiz.Copy();
            return Returned;
        }
        public GroupFunctionInstantCol GetFunctionInstantCol(string strFunctionIDs)
        {
            GroupFunctionInstantCol Returned = new GroupFunctionInstantCol(true);
            GroupFunctionInstantDb objDb = new GroupFunctionInstantDb();
            objDb.GroupID = ID;
            objDb.FunctionIDs = strFunctionIDs;
            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
                Returned.Add(new GroupFunctionInstantBiz(objDr));

            return Returned;
        }
        public void AssignFunctionCol(string strFunctionIDs, GroupFunctionInstantCol objCol)
        {
            GroupDb objDb = new GroupDb();
            objDb.ID = ID;
            objDb.Function = objCol.GetTable();
            objDb.FunctionIDs = strFunctionIDs;
            objDb.JoinParticularFunction();
        }
        #endregion
    }
}
