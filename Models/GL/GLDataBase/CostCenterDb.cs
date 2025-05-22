using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.SystemBase;
using SharpVision.Base.BaseDataBase;

namespace SharpVision.GL.GLDataBase
{
    public class CostCenterDb : BaseSelfRelatedDb
    {
        #region Private Data
        protected string _Code;
        protected int _Level;
      
        protected string _DefaultCostCenterCode;
        protected string _DefaultCostCenterName;
        protected int _OrderVal;
        #region Private Data For Search
        protected string _LikeNameA;
        protected string _LikeNameE;
        protected string _LikeCode;
        protected bool _OnlyFamily;
        int _SecondryDetermined;
        int _DirectionDetermined;
        int _StatusDetermined;
        int _LeafDetermined;
        string _IDsStr;
        static DataTable _CostCenterCacheTable;
        #endregion
        #endregion
        #region Public Constractors
        public CostCenterDb()
        {

        }
        public CostCenterDb(string strCode)
        {
            _Code = strCode;
            DataTable dtTemp = Search();
            if (dtTemp.Rows.Count == 0)
            {
                _Code = "";
                return;
            }
            SetData(dtTemp.Rows[0]);

        }
        public CostCenterDb(int intID)
        {
            _ID = intID;
            DataTable dtTemp = Search();
            if (dtTemp.Rows.Count == 0)
            {
                _ID = 0;
                return;
            }
            SetData(dtTemp.Rows[0]);

        }

        public CostCenterDb(DataRow objDR)
        {
            SetData(objDR);
        }

        #endregion
        #region Public Accessorice
        public string Code
        {
            set
            {
                _Code = value;
            }
            get
            {
                return _Code;
            }
        }
        public int Level
        {
            set
            {
                _Level = value;
            }
            get
            {
                return _Level;
            }
        }
        public int OrderVal
        {
            set
            {
                _OrderVal = value;
            }
            get
            {
                return _OrderVal;
            }
        }

        #region Public Set Accessoric For Search
        public string LikeNameA
        {
            set
            {
                _LikeNameA = value;
            }
        }
        public string LikeNameE
        {
            set
            {
                _LikeNameE = value;
            }
        }
        public string LikeCode
        {
            set
            {
                _LikeCode = value;
            }
        }
        public bool OnlyFamily
        {
            set
            {
                _OnlyFamily = value;
            }

        }
        public int SecondryDetermined
        {
            set
            {
                _SecondryDetermined = value;
            }
        }
        public int DirectionDetermined
        {
            set
            {
                _DirectionDetermined = value;
            }
        }
        public int StatusDetermined
        {
            set
            {
                _StatusDetermined = value;
            }
        }
        public string IDsStr
        {
            set
            {
                _IDsStr = value;
            }
        }
        public string DefaultCostCenterCode
        {
            get
            {
                return _DefaultCostCenterCode;
            }
        }
        public string DefaultCostCenterName
        {
            get
            {
                return _DefaultCostCenterName;
            }
        }
        public string AddStr
        {
            get
            {
                _FamilyID = _FamilyID == 0 ? _ID : _FamilyID;
                _ParentID = _ParentID == 0 ? _ID : _ParentID;
               
                string Returned = " INSERT INTO GLCostCenter" +
                                " (CostCenterType,CostCenterCode, CostCenterNameA, CostCenterNameE, CostCenterParentID, CostCenterFamilyID, CostCenterLevel, UsrIns,TimIns)" +
                                " VALUES     ("  + _Code + "','" + _NameA + "','" + _NameE + "'," + _ParentID + "," + _FamilyID + "," + _Level  +
                                "," + SysData.CurrentUser.ID + ",GetDate()) ";
                return Returned;
            }
        }
        public static string SearchStr
        {
            get
            {
                 
                string Returned = " SELECT     CostCenterID, CostCenterCode, CostCenterNameA, CostCenterNameE, CostCenterParentID, CostCenterFamilyID, CostCenterLevel " +
                                  " FROM    GLCostCenter " +
                                  "";
                return Returned;
            }
        }

        #endregion
        public static DataTable CostCenterCacheTable
        {
            set
            {
                _CostCenterCacheTable = value;
            }
            get
            {
                if (_CostCenterCacheTable == null)
                    _CostCenterCacheTable = new CostCenterDb().Search();
                return _CostCenterCacheTable;
            }
        }
        #endregion
        #region Private Methods
        void SetData(DataRow objDR)
        {
            int.TryParse(objDR["CostCenterID"].ToString(),out _ID);
            if(objDR.Table.Columns["CostCenterCode"]!= null)
            _Code = objDR["CostCenterCode"].ToString();
        if (objDR.Table.Columns["CostCenterLevel"] != null && objDR["CostCenterLevel"].ToString() != "")
            _Level = int.Parse(objDR["CostCenterLevel"].ToString());
        if (objDR.Table.Columns["CostCenterNameA"] != null)
            _NameA = objDR["CostCenterNameA"].ToString();
        if (objDR.Table.Columns["CostCenterNameE"] != null)
            _NameE = objDR["CostCenterNameE"].ToString();
        if (objDR.Table.Columns["CostCenterFamilyID"] != null && objDR["CostCenterFamilyID"].ToString() != "")
            {
                _FamilyID = int.Parse(objDR["CostCenterFamilyID"].ToString());
                _ParentID = int.Parse(objDR["CostCenterParentID"].ToString());
            }
        }
        void SetRelatedCostCenter(string strParentID, DataTable dtTemp, ref string strIDs)
        {
            DataRow[] arrDR = dtTemp.Select("CostCenterID <> CostCenterParentID and CostCenterParentID = " + strParentID);
            string strTempParent;
            foreach (DataRow objDR in arrDR)
            {
                if (strIDs != "")
                    strIDs = strIDs + ",";
                strTempParent = objDR["CostCenterID"].ToString();
                strIDs = strIDs + objDR["CostCenterID"].ToString();
                SetRelatedCostCenter(strTempParent, dtTemp, ref strIDs);
            }
        }
        #endregion
        #region Public Methods
        public override void Add()
        {

            _ID = SysData.SharpVisionBaseDb.InsertIdentityTable(AddStr);
          
            if (_ParentID == 0)
            {

                string strSql = "update GLCostCenter set CostCenterParentID = " + _ID + ", CostCenterFamilyID =" + _ID;
                strSql = strSql + " where CostCenterID = " + _ID;
                SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);

            }
        }
        public override void Edit()
        {
            _FamilyID = _FamilyID == 0 ? _ID : _FamilyID;
            _ParentID = _ParentID == 0 ? _ID : _ParentID;
           
            string strSql = " UPDATE    GLCostCenter" +
                            " SET   CostCenterCode ='" + _Code + "'" +
                            " , CostCenterNameA ='" + _NameA + "' " +
                            " , CostCenterNameE ='" + _NameE + "' " +
                            " , CostCenterParentID =" + _ParentID + "" +
                            " , CostCenterFamilyID =" + _FamilyID + "" +
                            " , CostCenterLevel =" + _Level + "" +
                             " , UsrUpd =" + SysData.CurrentUser.ID + "" +
                            " , TimUpd = GetDate()" +
                            "   WHERE  CostCenterID = " + _ID + "";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);

            strSql = " select * from GLCostCenter where CostCenterFamilyID in " +
               " (select CostCenterFamilyID from GLCostCenter where CostCenterParentID=" + _ID + " and CostCenterID <> " + _ID + " and CostCenterFamilyID <> " + _FamilyID + ")";
            DataTable dtTemp = SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
         
            if (dtTemp.Rows.Count == 0)
                return;
            string strIDs = "";
            SetRelatedCostCenter(_ID.ToString(), dtTemp, ref strIDs);
            strSql = " Update GLCostCenter set CostCenterFamilyID = " + _FamilyID + " where CostCenterID in ( " + strIDs + ")";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);


        }
        public override void Delete()
        {
            string strSql = " update  GLCostCenter set Dis=GetDate() WHERE  CostCenterID = " + _ID + "";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);

        }
        public override DataTable Search()
        {
            string strSql = SearchStr + " Where Dis is null ";
            if (_ID != 0)
                strSql = strSql + " and  CostCenterID = " + _ID + "";
            if (_IDsStr != null && _IDsStr != "")
                strSql += " and CostCenterID in (" + _IDsStr + ")";
            if (_Code != null && _Code != "")
                strSql = strSql + " and CostCenterCode = '" + _Code + "'";
            if (_NameA != null && _NameA != "")
                strSql = strSql + " and  CostCenterNameA like  '%" + _NameA + "%'";
            if (_NameE != null && _NameE != "")
                strSql = strSql + " and  CostCenterNameE = '%" + _NameE + "%'";
            if (_LikeCode != null && _LikeCode != "")
                strSql = strSql + " and  CostCenterCode Like '%" + _LikeCode + "%'";
            if (_LikeNameA != null && _LikeNameA != "")
                strSql = strSql + " and  CostCenterNameA Like '%" + _LikeNameA + "%'";
            if (_LikeNameE != null && _LikeNameE != "")
                strSql = strSql + " and  CostCenterNameE Like '%" + _LikeNameE + "%'";
            if (_Level != 0)
                strSql = strSql + " and  CostCenterLevel = " + _Level + "";
            if (_ParentID != 0)
                strSql = strSql + " and  CostCenterParentID = " + _ParentID + "";
            if (_FamilyID != 0)
                strSql = strSql + " and  CostCenterFamilyID = " + _FamilyID + "";
            if (_OnlyFamily)
                strSql = strSql + " and CostCenterFamilyID =CostCenterID ";

        


            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
       
        #endregion
    }
}
