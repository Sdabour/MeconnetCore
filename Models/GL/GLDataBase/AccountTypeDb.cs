using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.SystemBase;
using SharpVision.Base.BaseDataBase;

namespace SharpVision.GL.GLDataBase
{
    public class AccountTypeDb : BaseSelfRelatedDb
    {
        #region Private Data
   
        #endregion
        #region PrivateData For Search
        bool _OnlyFamilies;
        bool _NoChildren;
        static DataTable _AccountTypeTable;
        #endregion
        #region Constructors
        public AccountTypeDb()
        {

        }
        public AccountTypeDb(int intID)
        {
            _ID = intID;
            DataTable dtTemp = Search();
            if (dtTemp.Rows.Count > 0)
            {
                DataRow objDR = dtTemp.Rows[0];
                SetData(objDR);
            }
            
        }
        public AccountTypeDb(DataRow objDR)
        {
            SetData(objDR);
        }
        #endregion
        #region Public Properties
     
        public static string SearchStr
        {
            get
            {
                string Returned = " SELECT  AccountTypeID, AccountTypeNameA, AccountTypeNameE," +
                    " AccountTypeParentID, AccountTypeFamilyID,Dis  FROM GLAccountType ";
                return Returned;
            }
        }

        public static DataTable AccountTypeTable
        {
            set
            {
                _AccountTypeTable = value;
            }
            get
            {
                if (_AccountTypeTable == null)
                {
                    AccountTypeDb objAccountTypeDb = new AccountTypeDb();
                    _AccountTypeTable = objAccountTypeDb.Search();
                    _AccountTypeTable.PrimaryKey = new DataColumn[] { _AccountTypeTable.Columns["AccountTypeID"] };
                }
                return _AccountTypeTable;
            }
        }
        #endregion
        #region Private Methods
        void SetData(DataRow objDR)
        {
            if (objDR["AccountTypeID"].ToString() == "")
                return;
            _ID = int.Parse(objDR["AccountTypeID"].ToString());
            _NameA = objDR["AccountTypeNameA"].ToString();
            _NameE = objDR["AccountTypeNameE"].ToString();

            _FamilyID = int.Parse(objDR["AccountTypeFamilyID"].ToString());
            _ParentID = int.Parse(objDR["AccountTypeParentID"].ToString());
        }
        void SetRelatedAccountTypes(string strParentID, DataTable dtTemp, ref string strIDs)
        {
            DataRow[] arrDR = dtTemp.Select("AccountTypeID <> AccountTypeParentID and AccountTypeParentID = " + strParentID);
            string strTempParent;
            foreach (DataRow objDR in arrDR)
            {
                if (strIDs != "")
                    strIDs = strIDs + ",";
                strTempParent = objDR["AccountTypeID"].ToString();
                strIDs = strIDs + objDR["AccountTypeID"].ToString();
                SetRelatedAccountTypes(strTempParent, dtTemp, ref strIDs);
            }


        }



        void SetRecursiveChildernTable(string strParentAccountTypeID, ref DataTable dtDist, ref DataTable dtSource)
        {
            if (_NoChildren || _OnlyFamilies)
                return;
            DataRow[] arrDr = dtSource.Select("AccountTypeID<>AccountTypeParentID and AccountTypeParentID=" + strParentAccountTypeID);




            if (arrDr.Length > 0)
            {
                foreach (DataRow objDr in arrDr)
                {
                    string strTemp = objDr["AccountTypeID"].ToString();
                    dtDist.ImportRow(objDr);

                    dtSource.Rows.Remove(objDr);

                    SetRecursiveChildernTable(strTemp, ref dtDist, ref dtSource);
                }
            }
        }

        #endregion
        #region Public Methods
        public override void Add()
        {
            _FamilyID = _FamilyID == 0 ? _ID : _FamilyID;
            _ParentID = _ParentID == 0 ? _ID : _ParentID;
          
            string strSql = " INSERT INTO GLAccountType" +
                            " (AccountTypeNameA, AccountTypeNameE, AccountTypeParentID, AccountTypeFamilyID,UsrIns,TimIns)" +
                            " VALUES     ('" + _NameA + "','" + _NameE + "'," + _ParentID + "," + _FamilyID + "," + SysData.CurrentUser.ID + ",GetDate()) ";
            _ID = SysData.SharpVisionBaseDb.InsertIdentityTable(strSql);
            if (_ParentID == 0)
            {

                strSql = "update GLAccountType set AccountTypeParentID = " + _ID + ", AccountTypeFamilyID =" + _ID;
                strSql = strSql + " where AccountTypeID = " + _ID;
                SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
            }
        }
        public override void Edit()
        {
            _ParentID = _ParentID == 0 ? _ID : _ParentID;
            _FamilyID = _FamilyID == 0 ? _ID : _FamilyID;
            string strSql = " UPDATE    GLAccountType" +
                            " SET AccountTypeNameA ='" + _NameA + "' "+
                            ", AccountTypeNameE ='" + _NameE + "' "+
                            ", AccountTypeParentID =" + _ParentID+
                            ", AccountTypeFamilyID =" +_FamilyID +
                            ", UsrUpd =" + SysData.CurrentUser.ID + "" +
                            ", TimUpd = GetDate()" +
                            " WHERE     (AccountTypeID = " + _ID + ")";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);

            strSql = "select * from GLAccountType where AccountTypeFamilyID in " +
               " (select AccountTypeFamilyID from GLAccountType where AccountTypeParentID=" + _ID + " and AccountTypeID <> " + _ID + " and AccountTypeFamilyID <> " + _FamilyID + ")";
            DataTable dtTemp = SysData.SharpVisionBaseDb.ReturnDatatable(strSql);

            if (dtTemp.Rows.Count == 0)
                return;
            string strIDs = "";
            SetRelatedAccountTypes(_ID.ToString(), dtTemp, ref strIDs);
            strSql = "Update GLAccountType set AccountTypeFamilyID = " + _FamilyID + " where AccountTypeID in ( " + strIDs + ")";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);

        }
        public override void Delete()
        {
            string strSql = " Update GLAccountType Set Dis = GetDate() ";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public override DataTable Search()
        {
            string strSql = SearchStr + " WHERE  (GLAccountType.Dis IS NULL)";
            if (_ID != 0)
                strSql = strSql + " and AccountTypeID = " + _ID.ToString();
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);

        }

        #endregion

        public DataTable GetChildrenTable()
        {
            DataTable dtReturned = new DataTable();
            foreach (DataColumn dcTemp in AccountTypeTable.Columns)
            {
                dtReturned.Columns.Add(dcTemp.ColumnName, dcTemp.DataType);
            }
            DataTable dtSrc = AccountTypeTable.Copy();
            DataRow[] arrDr = dtSrc.Select("AccountTypeID=" + _ID.ToString());
            if (arrDr.Length != 0)
            {
                dtReturned.ImportRow(arrDr[0]);
                SetRecursiveChildernTable(_ID.ToString(), ref dtReturned, ref dtSrc);
            }
            return dtReturned;

        }
    }
}
