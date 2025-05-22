using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.SystemBase;
using System.Data;
using System.Data.SqlClient;
using SharpVision.Base.BaseDataBase;
using SharpVision.UMS.UMSDataBase;


namespace SharpVision.HR.HRDataBase
{
    public class BranchDb : BaseSelfRelatedDb
    {
        #region Private Data
        protected string _Desc;
        protected BranchTypeDb _TypeDb;
        protected int _TypeID;
        protected string _Location;
        #region
        protected int _NodeNo;
        protected DataTable _BranchTableSearch;
        protected DataTable _Characteristic;
        protected DataTable _KeyInstant;

        protected string _CharcteristicIDs;
        protected static DataTable _BranchTable;
        #endregion


        #region Private Data for search

        protected string _NameALike;
        protected string _NameELike;

        protected bool _OnlyFamilies;
        protected bool _NoChildren;

        protected bool _TableChanged;
        #endregion
        #endregion
        #region Constructors
        public BranchDb()   
        {
            _TypeDb = new BranchTypeDb();
        }

        public BranchDb(int intID)
        {
            _ID = intID;
            DataRow[] arrDR = BranchTable.Select("BranchID=" + _ID);
            if (arrDR.Length <= 0)
                return;
            //DataTable dtTemp = Search();

            DataRow objDR = arrDR[0];

            SetData(objDR);
           

        }
        public BranchDb(DataRow objDR)
        {
            //_BranchDb = DR;
            SetData(objDR);

        }
        public BranchDb(int intID, string strName)
        {
            _ID = intID;
            _NameA = strName;
            _TypeDb = new BranchTypeDb();
        }


        #endregion
        #region Public Properties

        public string Desc
        {
            set
            {
                _Desc = value;
            }
            get
            {
                return _Desc;
            }
        }
   
        public BranchTypeDb BranchTypeDb
        {
            set
            {
                _TypeDb = value;
            }
            get
            {
                return _TypeDb;
            }

        }
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
      
        public DataTable Characteristic
        {
            set
            {
                _Characteristic = value;
            }
            get
            {
                return _Characteristic;
            }
        }
        bool _IsStopped;

        public bool IsStopped
        {
            get { return _IsStopped; }
            set { _IsStopped = value; }
        }
        int _IsStoppedStatus;

        public int IsStoppedStatus
        {
         
            set { _IsStoppedStatus = value; }
        }

        #region Set Properties for Search
      
      
        public string NameLike
        {
            set
            {
                if (SysData.Language == 0)
                    _NameALike = value;
                else
                    _NameELike = value;
            }
        }
        public DataTable BranchTableSearch
        {
            set
            {
                _BranchTableSearch = value;
            }
        }

      
        public bool OnlyFamilies
        {
            set
            {
                _OnlyFamilies = value;
            }
        }
        public bool NoChildren
        {
            set
            {
                _NoChildren = value;
            }
        }

        #endregion
        #region GetOnlyProperty
        public static DataTable BranchTable
        {
            get
            {
                if (_BranchTable == null)
                {
                    BranchDb objBranchDb = new BranchDb();
                    _BranchTable = objBranchDb.Search();
                    _BranchTable.PrimaryKey = new DataColumn[] { _BranchTable.Columns["BranchID"] };
                }
                return _BranchTable;
            }
        }
        public static string SearchStr
        {
            get
            {
                string Returned = "SELECT     BranchID,BranchType, BranchNameA, BranchNameE, BranchDesc, BranchLocation, BranchParentID, BranchFamilyID,BranchIsStopped,BranchTypeTable.*  "+
                                            " FROM    dbo.HRBranch inner join ("+ BranchTypeDb.SearchStr +") as BranchTypeTable on BranchTypeTable.BranchTypeID = HRBranch.BranchType ";
                return Returned;
            }
        }

        #endregion

        #endregion
        #region Private Methodsda
        void SetData(DataRow objDR)
        {
            try
            {
                _ID = int.Parse(objDR["BranchID"].ToString());
                _NameA = objDR["BranchNameA"].ToString();

                _NameE = objDR["BranchNameE"].ToString();
                _Location = objDR["BranchLocation"].ToString();
                _Desc = objDR["BranchDesc"].ToString();
                bool.TryParse(objDR["BranchIsStopped"].ToString(), out _IsStopped);
                _ParentID = int.Parse(objDR["BranchParentID"].ToString());
                _FamilyID = int.Parse(objDR["BranchFamilyID"].ToString());
                _TypeID = int.Parse(objDR["BranchType"].ToString());

            }
            catch
            { }
        }

       
        void SetRelatedBranchs(string strParentID, DataTable dtTemp, ref string strIDs)
        {
            DataRow[] arrDR = dtTemp.Select("BranchID <> BranchParentID and BranchParentID = " + strParentID);
            string strTempParent;
            foreach (DataRow objDR in arrDR)
            {
                if (strIDs != "")
                    strIDs = strIDs + ",";
                strTempParent = objDR["BranchID"].ToString();
                strIDs = strIDs + objDR["BranchID"].ToString();
                SetRelatedBranchs(strTempParent, dtTemp, ref strIDs);
            }


        }
        DataTable GetBranch(DataTable dtBranch)
        {
            _TableChanged = false;
          

            string strWhere = "Dis is null";
            if (_OnlyFamilies)
                strWhere = strWhere + " and BranchID = BranchParentID ";
            else
            {
                if (_TypeID != 0)
                {
                    string strTempID = "";
                    string strTempWhere = strWhere;
                    if (_NameALike != null && _NameALike != "")
                    {
                        strTempWhere = strTempWhere + " and BranchNameA like '%" + _NameALike + "%' ";
                        DataRow[] arrTemp = dtBranch.Select(strTempWhere, "");

                        foreach (DataRow objDr in arrTemp)
                        {
                            if (strTempID != "")
                                strTempID = strTempID + ",";
                            strTempID = strTempID + objDr["BranchID"];
                            SetRelatedBranchs(objDr["BranchID"].ToString(), dtBranch, ref strTempID);
                        }
                    }


                    strWhere = strWhere + " and (BranchType=" + _TypeID + ")";

                    if (strTempID != "")
                    {
                        _TableChanged = true;
                        strWhere = strWhere + " and BranchID in (" + strTempID + ") ";
                    }
                }
                else
                {
                    if (_NameALike != null && _NameALike != "")
                    {
                        _TableChanged = true;
                        strWhere = strWhere + " and BranchNameA like '%" + _NameALike + "%' ";
                    }
                    if (_NameELike != null && _NameELike != "")
                    {
                        _TableChanged = true;
                        strWhere = strWhere + " and BranchNameE like '%" + _NameELike + "%' ";
                    }
                }
            }
            DataRow[] arrDr = dtBranch.Select(strWhere, "");
            DataTable dtReturned = new DataTable();
            foreach (DataColumn dcTemp in dtBranch.Columns)
            {
                dtReturned.Columns.Add(new DataColumn(dcTemp.ColumnName, dcTemp.DataType));
            }
            foreach (DataRow objDr in arrDr)
            {
                dtReturned.ImportRow(objDr);
            }


            return dtReturned;

        }

        void SetRecursiveTable(string strParentBranchID, ref DataTable dtDist, ref DataTable dtSource)
        {
            DataRow[] arrDr = dtSource.Select("BranchID=" + strParentBranchID);

            if (arrDr.Length > 0)
            {
                string strTemp = arrDr[0]["BranchParentID"].ToString();
                _NodeNo++;
                if (_NodeNo >= 200)
                    return;


                string strLevel = "1";
                if (strTemp != strParentBranchID)
                {
                    SetRecursiveTable(strTemp, ref dtDist, ref dtSource);
                    DataRow[] arrParentDr = dtSource.Select("BranchID=" + strTemp);

                }

                dtDist.ImportRow(arrDr[0]);
                dtSource.Rows.Remove(arrDr[0]);


            }
        }
        void SetRecursiveChildernTable( string strParentBranchID, ref DataTable dtDist, ref DataTable dtSource)
        {
            if (_NoChildren || _OnlyFamilies)
                return;
            int intNewLevel =  1;
            DataRow[] arrDr = dtSource.Select("BranchID<>BranchParentID and BranchParentID=" + strParentBranchID);




            if (arrDr.Length > 0)
            {
                foreach (DataRow objDr in arrDr)
                {
                    string strTemp = objDr["BranchID"].ToString();
                    _NodeNo++;
                  
                    dtDist.ImportRow(objDr);

                    dtSource.Rows.Remove(objDr);

                    SetRecursiveChildernTable( strTemp, ref dtDist, ref dtSource);
                }
            }
        }

        void EditBranchCach()
        {
            //if (_BranchTable != null)
            //{
            BranchDb objBranchDb = new BranchDb();
            _BranchTable = objBranchDb.Search();
            //}
        }

        #endregion
        #region Public Methods
        public override void Add()
        {
            _FamilyID = _FamilyID == 0 ? _ID : _FamilyID;
            _ParentID = _ParentID == 0 ? _ID : _ParentID;
            int intIsStopped = _IsStopped ? 1 : 0;

            string strSql = "insert into HRBranch ( BranchType, BranchNameA, BranchNameE, BranchDesc, BranchLocation, BranchParentID, BranchFamilyID,BranchIsStopped,  UsrIns, TimIns) values(";
            strSql = strSql + ""+ _TypeID + ",'"+  _NameA + "','" + _NameE + "','" + _Desc + "','" + _Location + "'," +
                _ParentID + "," + _FamilyID + "," + intIsStopped + "," +
                 + SysData.CurrentUser.ID + ",Getdate())";
            _ID = SysData.SharpVisionBaseDb.InsertIdentityTable(strSql);
            if (_ParentID == 0)
            {

                strSql = "update HRBranch set BranchParentID = " + _ID + ", BranchFamilyID =" + _ID;
                strSql = strSql + " where BranchID = " + _ID;
                SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
            }

            EditBranchCach();



        }
        public override void Edit()
        {
            _FamilyID = _FamilyID == 0 ? _ID : _FamilyID;
            _ParentID = _ParentID == 0 ? _ID : _ParentID;
            int intIsStopped = _IsStopped ? 1 : 0;
            string strSql = "update  HRBranch ";
            strSql = strSql + " set BranchType=" + _TypeID;
            strSql = strSql + " ,BranchNameA ='" + _NameA + "'";
            strSql = strSql + ",BranchNameE ='" + _NameE + "'";
            strSql = strSql + " ,BranchDesc ='" + _Desc + "'";
            strSql = strSql + " ,BranchLocation ='" + _Location + "'";
            strSql = strSql + ",BranchParentID =" + _ParentID;
            strSql = strSql + ",BranchFamilyID=" + _FamilyID;
            strSql += ",BranchIsStopped=" + intIsStopped;
           
            strSql = strSql + ",TimUpd = GetDate()";
            strSql = strSql + ",UsrUpd =" + SysData.CurrentUser.ID;
            strSql = strSql + " where BranchID = " + _ID;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
            strSql = "select * from HRBranch where BranchFamilyID in " +
                " (select BranchFamilyID from HRBranch where BranchParentID=" + _ID + " and BranchID <> " + _ID + " and BranchFamilyID <> " + _FamilyID + ")";
            DataTable dtTemp = SysData.SharpVisionBaseDb.ReturnDatatable(strSql);

            if (dtTemp.Rows.Count == 0)
                return;
            string strIDs = "";
            SetRelatedBranchs(_ID.ToString(), dtTemp, ref strIDs);
            strSql = "Update HRBranch set BranchFamilyID = " + _FamilyID + " where BranchID in ( " + strIDs + ")";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
            EditBranchCach();


        }


        public override void Delete()
        {
            string strSql = "update  HRBranch  set Dis= GetDate() where BranchID=" + _ID;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);

        }

        public override DataTable Search()
        {
            string strSql = SearchStr + " WHERE (1=1) And Dis is null ";
            if (_ID != 0)
                strSql = strSql + " and HRBranch.BranchID = " + _ID.ToString();
            if (_NameA != "" && _NameA != null)
                strSql = strSql + " and HRBranch.BranchNameA = '" + _NameA + "'  ";
            if (_ParentID != 0)
                strSql = strSql + "  and HRBranch.BranchParentID = " + _ParentID;
            if (_FamilyID != 0)
                strSql = strSql + " and HRBranch.BranchFamilyID = " + _FamilyID;
            if (_TypeID != 0)
                strSql = strSql + " and HRBranch.BranchType=" + _TypeID;
            if (_NameALike != null && _NameALike != "")
                strSql = strSql + " and HRBranch.BranchNameA like '%" + _NameALike + "%' ";
            if (_NameELike != null && _NameELike != "")
                strSql = strSql + " and HRBranch.BranchNameE like '%" + _NameELike + "%' ";
            if (_IsStoppedStatus == 2)
                strSql += " and (BranchIsStopped = 0 )";

            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);


        }
        public DataTable GetChildrenTable()
        {
            DataTable dtReturned = new DataTable();
            foreach (DataColumn dcTemp in BranchTable.Columns)
            {
                dtReturned.Columns.Add(dcTemp.ColumnName, dcTemp.DataType);
            }
            DataTable dtSrc = BranchTable.Copy();
            DataRow[] arrDr = dtSrc.Select("BranchID=" + _ID.ToString());
            if (arrDr.Length != 0)
            {
                dtReturned.ImportRow(arrDr[0]);
                SetRecursiveChildernTable( _ID.ToString(), ref dtReturned, ref dtSrc);
            }
            return dtReturned;

        }

        #region Native GetAllBranch
        public DataTable GetAllBranch()
        {

            DataTable dtTempBranch;
            if (_ParentID == 0)
            {
                dtTempBranch = BranchTable;
            }
            else
            {
                dtTempBranch = _BranchTableSearch;

            }
            //DataTable dtAllBranch = 
            DataTable dtAllBranch = GetBranch(dtTempBranch);


            DataTable dtReturned = new DataTable();
            if (dtAllBranch.Rows.Count == 0)
                return dtReturned;


            foreach (DataColumn dcTemp in dtTempBranch.Columns)
            {
                dtReturned.Columns.Add(new DataColumn(dcTemp.ColumnName, dcTemp.DataType));
            }

            string strBranchID;
            DataTable dtSrc = BranchTable.Copy();


            if (_TableChanged)
            {
                foreach (DataRow drTemp in dtAllBranch.Rows)
                {
                    strBranchID = drTemp["BranchID"].ToString();
                    SetRecursiveTable(strBranchID, ref dtReturned, ref dtSrc);
                    int intLevel = int.Parse(drTemp["BranchLevel"].ToString());
                    SetRecursiveChildernTable( strBranchID, ref dtReturned, ref dtSrc);

                }
            }
            else
            {
                if (_ParentID != 0)
                {
                    SetRecursiveTable(_ParentID.ToString(), ref dtAllBranch, ref dtSrc);
                    dtReturned = dtAllBranch;

                }
                else
                    dtReturned = dtAllBranch;

            }

            return dtReturned;

        }
        #endregion

       
        #endregion
    }
}
