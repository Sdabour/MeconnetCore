using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using SharpVision.Base.BaseDataBase;
namespace SharpVision.UMS.UMSDataBase
{
    public class GroupDb:BaseSelfRelatedDb
    {
        #region Private Data
      
        protected int _TypeID;
        protected GroupTypeDb _GroupTypeDb;
        private DataTable _Function;

        private int _FunctionSearchStatus;/*
                                           * 0 dont care
                                           * 1 only has function
                                           */
        private int _FunctionID;
        private string _FunctionAncestorStr;

       
        #endregion
        #region Constructors
        public GroupDb()
        {
            _GroupTypeDb = new GroupTypeDb();
        }

        public GroupDb(int intID)
        {
            _ID = intID;
            DataTable dtTemp = Search();
            DataRow objDR = Search().Rows[0];
           _NameA = objDR["GroupName"].ToString();
           _NameE = _NameA;
            _ParentID = int.Parse(objDR["GroupParentID"].ToString());
            _FamilyID = int.Parse(objDR["GroupFamilyID"].ToString());
            _TypeID = int.Parse(objDR["GroupTypeID"].ToString());
            //_GroupDb = dtTemp.NewRow();

            if ((objDR["GroupID"] != System.DBNull.Value) && (objDR["GroupTypeID"].ToString() != "0"))
            {
                _TypeID = int.Parse(objDR["GroupTypeID"].ToString());
                _GroupTypeDb = new GroupTypeDb(objDR);
            }
            else
            {
                _TypeID = 0;
                _GroupTypeDb = new GroupTypeDb ();
            }
            _TypeID = int.Parse(objDR["GroupTypeID"].ToString());
            _GroupTypeDb = new GroupTypeDb(objDR);       
            
        }
        public GroupDb(DataRow objDR)
        {
            //_GroupDb = DR;



            SetData(objDR);
            _GroupTypeDb = new GroupTypeDb(objDR);

           
        }
        public GroupDb(string strGroupName, int intGroupParentID,int intGroupFamilyID, int intGroupTypeID)
        {
            DataTable dtTemp = new DataTable();
            DataColumn dcTemp;
            dcTemp = new DataColumn("GroupID");
            dtTemp.Columns.Add(dcTemp);
            dcTemp = new DataColumn("GroupName");
            dtTemp.Columns.Add(dcTemp);
            dcTemp = new DataColumn("GroupParentID");
            dtTemp.Columns.Add(dcTemp);
            dcTemp = new DataColumn("GroupFamilyID");
            dtTemp.Columns.Add(dcTemp);
            dcTemp = new DataColumn("GroupTypeID");
            dtTemp.Columns.Add(dcTemp);
           
        }

        #endregion
        #region Public Properties
        public int TypeID
        {
            set
            {
                _TypeID = value; 
            }
            get
            {
                return _TypeID;
 
            }
        }
        public GroupTypeDb GroupTypeDb
        {
            get
            {
                return _GroupTypeDb;
            }
            set
            {
                _GroupTypeDb = value;
            }
        }

        public DataTable Function
        {
            set { _Function = value; }
            get { return _Function; }
        }
        public int FunctionSearchStatus
        {
            set
            {
                _FunctionSearchStatus = value;
            }
        }
        public int FunctionID
        {
            set
            {
                _FunctionID = value;
            }

        }
        public string FunctionAncestorStr
        {
            set
            {
                _FunctionAncestorStr = value;
            }
        }
        string _FunctionIDs;

        public string FunctionIDs
        {
            get { return _FunctionIDs; }
            set { _FunctionIDs = value; }
        }
        string _AuxiliaryFunctionIDs;

        public string AuxiliaryFunctionIDs
        {
            get { return _AuxiliaryFunctionIDs; }
            set { _AuxiliaryFunctionIDs = value; }
        }
        public string AuxiliaryGroupIDs
        {
            get
            {
                string Returned = @"SELECT  dbo.UMSUser.UG as AuxiliaryGroup 
FROM            dbo.UMSUserFunction INNER JOIN
                         dbo.UMSUser ON dbo.UMSUserFunction.UserID = dbo.UMSUser.UID
WHERE        (dbo.UMSUserFunction.FunctionID  in (" + _AuxiliaryFunctionIDs + @"))
union all
SELECT        GroupID  as AuxiliaryGroup 
FROM            dbo.UMSGroupFunction
WHERE        (FunctionID in (" + _AuxiliaryFunctionIDs+ @"))";
                Returned = "select distinct AuxiliaryGroup from ("+ Returned +") as AGTable";
                return Returned;
            }
        }
        public static String SearchStr
        {
            get
            {
                string Returned = "SELECT UMSGroup.GroupID, UMSGroup.GroupName, UMSGroup.GroupParentID, UMSGroup.GroupFamilyID , UMSGroupType.GroupTypeID, UMSGroupType.GroupTypeName, UMSGroupType.GroupTypeParentID, UMSGroupType.GroupTypeFamilyID " +
                            " FROM UMSGroup LEFT OUTER JOIN UMSGroupType ON UMSGroup.GroupTypeID = UMSGroupType.GroupTypeID";
                return Returned;
            }
        }
        #endregion
        #region Private Methods
        void SetData(DataRow objDR)
        {
            _ID = int.Parse(objDR["GroupID"].ToString());
            _NameA = objDR["GroupName"].ToString();
            _NameE = _NameA;
            _ParentID = int.Parse(objDR["GroupParentID"].ToString());
            _FamilyID = int.Parse(objDR["GroupFamilyID"].ToString());
            _TypeID = int.Parse(objDR["GroupTypeID"].ToString());
        }
        #endregion
        #region Public Methods
        public override void Add()
        {
            _ParentID = _ParentID == 0 ? _ID : _ParentID;
            _FamilyID = _FamilyID == 0 ? _ID : _FamilyID;
            string strSql = "insert into UMSGroup (GroupName, GroupParentID, GroupFamilyID,GroupTypeID)" +
            "values('" + _NameA + "'," + _ParentID + "," + _FamilyID + "," + _TypeID + ")";
            _ID = BaseDb.UMSBaseDb.InsertIdentityTable(strSql);
            if (_ParentID == 0)
            {
               
                strSql = "update UMSGroup set GroupParentID = " + _ID + ", GroupFamilyID =" + _ID;
                strSql = strSql + " where GroupID = " + _ID;
                BaseDb.UMSBaseDb.ExecuteNonQuery(strSql);
            }
        }
        public override void Edit()
        {
            _ParentID = _ParentID == 0 ? _ID : _ParentID;
            _FamilyID = _FamilyID == 0 ? _ID : _FamilyID;
            string strSql = "update  UMSGroup ";
            strSql = strSql + " set GroupName ='" + _NameA + "'";
            strSql = strSql + ",GroupParentID =" + _ParentID;
            strSql = strSql + ",GroupFamilyID=" + _FamilyID;
            strSql = strSql + ",GroupTypeID=" + _TypeID;
            strSql = strSql + " where GroupID = " + _ID;
            BaseDb.UMSBaseDb.ExecuteNonQuery(strSql);
        }
        public override void Delete()
        {
            string strSql = "update UMSGroup set Dis=Getdate() where GroupID=" + _ID;
            BaseDb.UMSBaseDb.ExecuteNonQuery(strSql);
        }

        public override DataTable Search()
        {
            string strSql = SearchStr;
            if (_AuxiliaryFunctionIDs != null && _AuxiliaryFunctionIDs != "")
            {
                strSql += " inner join ("+ AuxiliaryGroupIDs +") AuxiliaryGroupTable "+
                    " on UMSGroup.GroupID = AuxiliaryGroupTable.AuxiliaryGroup ";
            }
            strSql = strSql + " WHERE    (UMSGroup.Dis IS NULL)";
            if (_ID != 0)
                strSql = strSql + " and GroupID = " + _ID.ToString();
            if (_NameA != "" && _NameA !=null)
                strSql = strSql + " and GroupName = '" + _NameA + "'  ";
            if (_ParentID != 0)
                strSql = strSql + "  and GroupParentID = " + _ParentID;
            if (_FamilyID != 0)
                strSql = strSql + " and GroupFamilyID = " + _FamilyID;
            if (_TypeID != 0)
                strSql = strSql + " And UMSGroup.GroupTypeID = " + _TypeID;
            if (_FunctionSearchStatus == 1 )
            {
                string strFunction = "SELECT     GroupID "+
                        " FROM         dbo.UMSGroupFunction "+
                        " WHERE     ((IsPermanent = 1) OR "+
                        " (EndDate > GETDATE())) AND ((FunctionID = "+ _FunctionID +") ";
                if(_FunctionAncestorStr != null && _FunctionAncestorStr!= "")
                  strFunction += " or ((FunctionID in (" + _FunctionAncestorStr + ")) and (IsAdmin=1)) ";
                strFunction += ")";

                strSql += " and GroupID in (" + strFunction + ")";
            }
            return BaseDb.UMSBaseDb.ReturnDatatable(strSql);
        }


        public void JoinFunction()
        {
            string strSql = "delete from UMSGroupFunction where GroupID = " + _ID;
           string [] arrStr = new string[_Function.Rows.Count+1];
           arrStr[0] = strSql;
           
                

                    
                    double dblStart;
                    double dblEnd;
                    int intIndex = 0;
                    bool blIsPermanent,blIsAdmin;
                    foreach (DataRow objDR in _Function.Rows)
                    {
                        intIndex++;
                        blIsPermanent = bool.Parse(objDR["IsPermanent"].ToString());
                        blIsAdmin = bool.Parse(objDR["IsAdmin"].ToString());
                        dblStart = BaseDb.Approximate(DateTime.Parse(objDR["StartDate"].ToString()).ToOADate() - 2, 1, UmsApproximateType.Down);
                        dblEnd = BaseDb.Approximate(DateTime.Parse(objDR["EndDate"].ToString()).ToOADate() - 2, 1, UmsApproximateType.Up);

                            //dblStart = DateTime.Parse(objDR["StartDate"].ToString()).ToOADate() - 2;
                            //dblEnd = DateTime.Parse(objDR["EndDate"].ToString()).ToOADate() - 2;
                            arrStr[intIndex] = "insert into UMSGroupFunction ( GroupID, FunctionID,IsPermanent,IsAdmin,StartDate,EndDate)" +
                                " values(" + _ID + "," + objDR["FunctionID"].ToString() + "," + (blIsPermanent ? "1" : "0")  + ","
                                + (blIsAdmin?"1":"0") +  "," + dblStart + "," + dblEnd + ")";
                           
                        


                   }

                   BaseDb.UMSBaseDb.ExecuteNonQuery(arrStr);



           
        }
        public virtual DataTable  GetGroupFunction()
        {
            DataTable dtReturned;
            GroupFunctionInstantDb tempGroupFunctionDb = new GroupFunctionInstantDb();
            tempGroupFunctionDb.GroupID = _ID;
            tempGroupFunctionDb.OnlySystemFunction = true;
            dtReturned = tempGroupFunctionDb.Search();
            return dtReturned;
        }
        public virtual DataTable GetAllGroupFunction()
        {
            DataTable dtReturned;
            GroupFunctionInstantDb tempGroupFunctionDb = new GroupFunctionInstantDb();
            tempGroupFunctionDb.GroupID = _ID;
            //tempGroupFunctionDb.OnlySystemFunction = 
            dtReturned = tempGroupFunctionDb.Search();
            return dtReturned;
        }
        public void JoinParticularFunction()
        {
            if (_Function == null)
                return;
            bool blIsAdmin = false;
            bool blIsPermanent;
            double dblStart;
            double dblEnd;


            string[] arrStr = new string[Function.Rows.Count + 1];
            arrStr[0] = "delete from UMSGroupFunction where GroupID=" + _ID + " and FunctionID in (" + _FunctionIDs + ") ";
            int intIndex = 0;
            foreach (DataRow objDR in _Function.Rows)
            {
                intIndex++;
                blIsPermanent = bool.Parse(objDR["IsPermanent"].ToString());
                blIsAdmin = bool.Parse(objDR["IsAdmin"].ToString());
                if (blIsPermanent == false)
                {

                    dblStart = BaseDb.Approximate(DateTime.Parse(objDR["StartDate"].ToString()).ToOADate() - 2, 1, UmsApproximateType.Down);
                    dblEnd = BaseDb.Approximate(DateTime.Parse(objDR["EndDate"].ToString()).ToOADate() - 2, 1, UmsApproximateType.Up);
                }
                else
                {
                    dblStart = BaseDb.Approximate(DateTime.Now.ToOADate() - 2, 1, UmsApproximateType.Down);
                    dblEnd = BaseDb.Approximate(DateTime.Now.ToOADate() - 2, 1, UmsApproximateType.Up);
                }
                    arrStr[intIndex] = "insert into UMSGroupFunction ( GroupID, FunctionID,IsPermanent,IsAdmin,StartDate,EndDate)" +
                        " values(" + _ID + "," + objDR["FunctionID"].ToString() + "," + "0" +
                        "," + (blIsAdmin ? "1" : "0") + "," + dblStart + "," + dblEnd + ")";

                //}
                //else
                //{
                //    arrStr[intIndex] = "insert into UMSGroupFunction ( GroupID, FunctionID,IsPermanent,IsAdmin)" +
                //       " values(" + _ID + "," + objDR["FunctionID"].ToString() + "," + (blIsPermanent ? "1" : "0") + "," + (blIsAdmin ? "1" : "0") + ")";

                //}


            }
            BaseDb.UMSBaseDb.ExecuteNonQuery(arrStr);

        }
        #endregion
    }
}

