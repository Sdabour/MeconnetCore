using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.SystemBase;
using SharpVision.Base.BaseDataBase;

namespace SharpVision.GL.GLDataBase
{
    public class BankDb : BaseSelfRelatedDb
    {
        #region Private Data
        protected bool _IsVirtual;
        #endregion
        #region PrivateData For Search
        bool _OnlyFamilies;
        bool _NoChildren;
        static DataTable _BankTable;
        #endregion
        #region Constructors
        public BankDb()
        { 

        }   
        public BankDb(int intID)
        {
            _ID = intID;
            DataTable dtTemp = Search();
            if (dtTemp.Rows.Count > 0)
            {
                DataRow objDR = dtTemp.Rows[0];
                SetData(objDR);
            }
        }
        public BankDb(DataRow objDR)
        {
            SetData(objDR);
        }
        #endregion
        #region Public Properties
        public bool IsVirtual
        {
            set
            {
                _IsVirtual = value;
            }
            get
            {
                return _IsVirtual;
            }
        }
        public static string SearchStr
        {
            get
            {
                string Returned = " SELECT  BankID, BankNameA, BankNameE, BankIsVirtual,"+
                    " BankParentID, BankFamilyID,Dis  FROM GLBank ";
                return Returned;
            }
        }

        public static DataTable BankTable
        {
            set
            {
                _BankTable = value;
            }
            get
            {
                if (_BankTable == null)
                {
                    BankDb objBankDb = new BankDb();
                    _BankTable = objBankDb.Search();
                    _BankTable.PrimaryKey = new DataColumn[] { _BankTable.Columns["BankID"] };
                }
                return _BankTable;
            }
        }
        #endregion
        #region Private Methods
        void SetData(DataRow objDR)
        {
            _ID = int.Parse(objDR["BankID"].ToString());
            _NameA = objDR["BankNameA"].ToString();
            _NameE = objDR["BankNameE"].ToString();
            _IsVirtual = bool.Parse(objDR["BankIsVirtual"].ToString());
            _FamilyID = int.Parse(objDR["BankFamilyID"].ToString());
            _ParentID = int.Parse(objDR["BankParentID"].ToString());
        }
        void SetRelatedBanks(string strParentID, DataTable dtTemp, ref string strIDs)
        {
            DataRow[] arrDR = dtTemp.Select("BankID <> BankParentID and BankParentID = " + strParentID);
            string strTempParent;
            foreach (DataRow objDR in arrDR)
            {
                if (strIDs != "")
                    strIDs = strIDs + ",";
                strTempParent = objDR["BankID"].ToString();
                strIDs = strIDs + objDR["BankID"].ToString();
                SetRelatedBanks(strTempParent, dtTemp, ref strIDs);
            }


        }



        void SetRecursiveChildernTable( string strParentBankID, ref DataTable dtDist, ref DataTable dtSource)
        {
            if (_NoChildren || _OnlyFamilies)
                return;
            DataRow[] arrDr = dtSource.Select("BankID<>BankParentID and BankParentID=" + strParentBankID);




            if (arrDr.Length > 0)
            {
                foreach (DataRow objDr in arrDr)
                {
                    string strTemp = objDr["BankID"].ToString();
                    dtDist.ImportRow(objDr);

                    dtSource.Rows.Remove(objDr);

                    SetRecursiveChildernTable( strTemp, ref dtDist, ref dtSource);
                }
            }
        }

        #endregion
        #region Public Methods
        public override void Add()
        {
            _FamilyID = _FamilyID == 0 ? _ID : _FamilyID;
            _ParentID = _ParentID == 0 ? _ID : _ParentID;
            int intIsVirtual = _IsVirtual ? 1 : 0;
            string strSql = " INSERT INTO GLBank" +
                            " (BankNameA, BankNameE, BankIsVirtual, BankParentID, BankFamilyID,UsrIns,TimIns)" +
                            " VALUES     ('" + _NameA + "','" + _NameE + "'," + intIsVirtual + "," + _ParentID + "," + _FamilyID + "," + SysData.CurrentUser.ID + ",GetDate()) ";
             _ID = SysData.SharpVisionBaseDb.InsertIdentityTable(strSql);
             if (_ParentID == 0)
             {

                 strSql = "update GLBank set BankParentID = " + _ID + ", BankFamilyID =" + _ID;
                 strSql = strSql + " where BankID = " + _ID;
                 SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
             }
        }
        public override void Edit()
        {
            _ParentID = _ParentID == 0 ? _ID : _ParentID;
            _FamilyID = _FamilyID == 0 ? _ID : _FamilyID;
            int intIsVirtual = _IsVirtual ? 1 : 0;
            string strSql = " UPDATE    GLBank" +
                            " SET BankNameA ='" + _NameA + "' "+
                            ", BankNameE ='" + _NameE + "' "+ 
                            ", BankIsVirtual =" + intIsVirtual+
                            ", BankParentID =" + _ParentID +
                            ", BankFamilyID =" + _FamilyID +
                            ", UsrUpd =" + SysData.CurrentUser.ID + "" +
                            ", TimUpd = GetDate()" +
                            " WHERE     (BankID = " + _ID + ")";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);

            strSql = "select * from GLBank where BankFamilyID in " +
               " (select BankFamilyID from GLBank where BankParentID=" + _ID + " and BankID <> " + _ID + " and BankFamilyID <> " + _FamilyID + ")";
            DataTable dtTemp = SysData.SharpVisionBaseDb.ReturnDatatable(strSql);

            if (dtTemp.Rows.Count == 0)
                return;
            string strIDs = "";
            SetRelatedBanks(_ID.ToString(), dtTemp, ref strIDs);
            strSql = "Update GLBank set BankFamilyID = " + _FamilyID + " where BankID in ( " + strIDs + ")";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);

        }
        public override void Delete()
        {
            string strSql = " Update GLBank Set Dis = GetDate() ";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public override DataTable Search()
        { 
            string strSql = SearchStr + " WHERE  (GLBank.Dis IS NULL)";
            if (_ID != 0)
                strSql = strSql + " and BankID = " + _ID.ToString();
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);

        }

        #endregion

        public DataTable GetChildrenTable()
        {
            DataTable dtReturned = new DataTable();
            foreach (DataColumn dcTemp in BankTable.Columns)
            {
                dtReturned.Columns.Add(dcTemp.ColumnName, dcTemp.DataType);
            }
            DataTable dtSrc = BankTable.Copy();
            DataRow[] arrDr = dtSrc.Select("BankID=" + _ID.ToString());
            if (arrDr.Length != 0)
            {
                dtReturned.ImportRow(arrDr[0]);
                SetRecursiveChildernTable( _ID.ToString(), ref dtReturned, ref dtSrc);
            }
            return dtReturned;

        }
    }
}
