using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.Base.BaseDataBase;

namespace SharpVision.UMS.UMSDataBase
{
    public class FunctionDb:BaseSelfRelatedDb 
    {
        #region Private Data
        protected string _Description;
        protected int _SysID;
        string _Url;
        bool _IsStoped;
        int _IsStopedStatus;//0 dont care
                            //1 only not stoped
                            //2 only stoped
        int _OnlineStatus;//0 dont care
                          //1 only online URL is not null
                          //2 only non online

        #endregion
        #region Constructors
        public FunctionDb()
        {

        }
        public FunctionDb(int intID)
        {
            _ID = intID;

            DataTable dtTemp = Search();//.Rows[0];
            if (dtTemp.Rows.Count == 0)
            {
                _ID = 0;
                return;
            }
            DataRow objDr = dtTemp.Rows[0];
            SetData(objDr);
           
        }
        public FunctionDb(DataRow DR)
        {
           
            
           if (DR["FunctionID"] == System.DBNull.Value)
                return;
            SetData(DR);
            

        }
        #endregion
        #region Public Properties
        public int ID
        {
            set
            {
                _ID = value;

            }
            get
            {
                return _ID;
            }

        }
        public string NameA
        {
            set
            {
                _NameA = value;
            }
            get
            {
                return _NameA;
            }
        }
        public string NameE
        {
            set
            {
                _NameE = value;
            }
            get
            {
                return _NameE;
            }
        }
        public string Description
        {
            set
            {
                _Description = value;
            }
            get
            {
                return _Description;
            }
        }

       
        public int ParentID
        {
            set
            {
                _ParentID = value;
            }
            get
            {
                return _ParentID;
            }
        }
        public int FamilyID
        {
            set
            {
                _FamilyID = value;
            }
            get
            {
                return _FamilyID;
            }
        }
        public string Url
        {
            set
            {
                _Url = value;
            }
            get
            {
                return _Url;
            }
        }
        public bool IsStoped
        {
            set
            {
                _IsStoped = value;
            }
            get
            {
                return _IsStoped;
            }
        }
        public int SysID
        {
            get
            {
                return _SysID;
            }
            set
            {
                _SysID = value;
                BaseDb.SysID = value;
            }
        }
        public int IsStopedStatus
        {
            set
            {
                _IsStopedStatus = value;
            }
        }
        public int OnlineStatus
        {
            set
            {
                _OnlineStatus = value;
            }
        }
        string _FunctionIDs;

        public string FunctionIDs
        {
            get { return _FunctionIDs; }
            set { _FunctionIDs = value; }
        }
        public static string SearchStr
        {
            get
            {
                string Returned = "SELECT FunctionID, FunctionNameA,FunctionNameE, FunctionDescription, FunctionParentID, FunctionFamilyID,FunctionIsStoped,FunctionUrl,UMSFunction.SysID,UMSFunction.Dis FROM  UMSFunction  inner join UMSSystem on UMSFunction.SysID = UMSSystem.SysID ";
                return Returned;
                         
            }
        }
       
        #endregion
        #region Private Methods
        void SetData(DataRow DR)
        {
            _ID = int.Parse(DR["FunctionID"].ToString());
            _NameA = DR["FunctionNameA"].ToString();
            _NameE = DR["FunctionNameE"].ToString();
            _Description = DR["FunctionDescription"].ToString();
            _ParentID = int.Parse(DR["FunctionParentID"].ToString());
            _FamilyID = int.Parse(DR["FunctionFamilyID"].ToString());
             int.TryParse(DR["SysID"].ToString(),out _SysID );
            if(DR.Table.Columns["FunctionIsStoped"]!= null)
            _IsStoped = bool.Parse(DR["FunctionIsStoped"].ToString());
            if(DR.Table.Columns["FunctionUrl"] != null)
            _Url = DR["FunctionUrl"].ToString();
        }
        #endregion
        #region Public Methods
        public override void Add()
        {
            _ParentID = _ParentID == 0 ? _ID : _ParentID;
            _FamilyID = _FamilyID == 0 ? _ID : _FamilyID;
            int intIsStoped = _IsStoped ? 1 : 0;
            string strSql = "insert into UMSFunction (FunctionNameA,FunctionNameE,FunctionDescription, FunctionParentID,FunctionFamilyID,FunctionIsStoped,FunctionUrl,SysID)" +
            "values('" + _NameA + "','" + _NameE + "','" + _Description + "'," + _ParentID + "," + _FamilyID  + "," + intIsStoped + ",'"+ _Url  + "'," + _SysID + ")";
            if (_ParentID == 0)
            {
                _ID = BaseDb.UMSBaseDb.InsertIdentityTable(strSql);
                strSql = "update UMSFunction set FunctionParentID = " + _ID + ", FunctionFamilyID =" + _ID;
                strSql = strSql + " where FunctionID = " + _ID;
                BaseDb.UMSBaseDb.ExecuteNonQuery(strSql);
            }
            else
             BaseDb.UMSBaseDb.ExecuteNonQuery(strSql);

        }

        public override void Edit()
        {
            _ParentID = _ParentID == 0 ? _ID : _ParentID;
            _FamilyID = _FamilyID == 0 ? _ID : _FamilyID;
            int intIsStoped = _IsStoped ? 1 : 0;
            string strSql = "update  UMSFunction ";
            strSql = strSql + " set FunctionDescription = '" + _Description + "'";
            strSql = strSql + ", FunctionNameA ='" + _NameA + "'";
            strSql = strSql + ", FunctionNameE ='" + _NameE + "'";
            strSql = strSql + ", FunctionParentID =" + _ParentID + "";
            strSql = strSql + ", FunctionFamilyID =" + _FamilyID + "";
            strSql += ",FunctionIsStoped = " + intIsStoped;
            strSql += ",FunctionUrl='"+ _Url +"'";
            strSql = strSql + ",SysID =" + _SysID;
            strSql = strSql + " where FunctionID=" + _ID;
            BaseDb.UMSBaseDb.ExecuteNonQuery(strSql);
        }

        public override void Delete()
        {
            string strSql = "delete from UMSFunction where FunctionID=" + _ID;
            BaseDb.UMSBaseDb.ExecuteNonQuery(strSql);
        }


        public override DataTable Search()
        {
            string strSql = SearchStr + " WHERE     UMSFunction.dis is null  and UMSSystem.Dis is null ";
            if (BaseDb.SysID != 0)
            {
                int intSysID = _SysID == 0 ? BaseDb.SysID : _SysID;
                strSql = strSql + " and UMSFunction.SysID = " + intSysID;
            }
            if (_ID != 0)
                strSql = strSql + " and FunctionID = " + _ID.ToString();
            if (_ParentID != 0)
                strSql = strSql + " And FunctionParentID =" + _ParentID + "";
            if (_FamilyID != 0)
                strSql = strSql + " And FunctionFamilyID =" + _FamilyID + "";
            if (_OnlineStatus == 1)
                strSql += " and FunctionUrl is not null and FunctionUrl<>'' ";
            if (_IsStopedStatus == 1)
                strSql += " and FunctionIsStoped = 0 ";
            if(_FunctionIDs!= null && _FunctionIDs!= "")
                strSql = strSql + " and FunctionID in (" + _FunctionIDs + ")";
            return BaseDb.UMSBaseDb.ReturnDatatable(strSql);
        }
        #endregion

    }
}

