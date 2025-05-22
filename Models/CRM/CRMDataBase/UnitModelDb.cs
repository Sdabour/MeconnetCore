using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.SystemBase;
using System.Data;
using System.Data.SqlClient;
using SharpVision.Base.BaseDataBase;

namespace SharpVision.CRM.CRMDataBase
{
    public class UnitModelDb : BaseSelfRelatedDb
    {
        #region Private Data
        protected int _CellID;
        protected double _Survey;
        protected double _UnitPrice;
        protected double _CachePrice;
        protected int _Finishing;
        protected int _RoomNo;
        protected int _FloorNo;
        protected int _Movie;
        protected int _Logo;
        DataTable _ComponantTable;
        
        #region Privaet Data
        string _NameALike;
        string _NameELike;
        double _SurveyFrom;
        double _SurveyTo;
        double _UnitPriceFrom;
        double _UnitPriceTo;
        int _CellFamilyID;
        string _CellIDs;
        #endregion 
        #endregion
        #region Constructors
        public UnitModelDb()
        { 

        }
        public UnitModelDb(int intID)
        {
            _ID = intID;
            DataTable dtTemp = Search();
            if (dtTemp.Rows.Count == 0)
            {
                _ID = 0;
                return;
            }
            DataRow objDR = dtTemp.Rows[0];
            SetData(objDR);
 
        }
        public UnitModelDb(DataRow objDR)
        {
            SetData(objDR);

        }
        #endregion
        #region Public Properties
        public int CellID
        {
            set
            {
                _CellID = value;
            }
            get
            {
                return _CellID;
            }

        }
        public double Survey
        {
            set
            {
                _Survey = value;
            }
            get
            {
                return _Survey;
            }

        }
        public double UnitPrice
        {
            set
            {
                _UnitPrice = value;
            }
            get
            {
                return _UnitPrice;
            }

        }

        public int Finishing
        {
            set
            {
                _Finishing = value;
            }
            get
            {
                return _Finishing;
            }
        }
        public int FloorNo
        {
            set
            {
                _FloorNo = value;
            }
            get
            {
                return _FloorNo;
            }
        }
        public int RoomNo
        {
            set
            {
                _RoomNo = value;
            }
            get
            {
                return _RoomNo;
            }
        }
        public int Logo
        {
            set
            {
                _Logo = value;
            }
            get
            {
                return _Logo;
            }
        }
        public int Movie
        {
            set
            {
                _Movie = value;
            }
            get
            {
                return _Movie;
            }
        }

        public string NameAlike
        {
            set
            {
                _NameALike = value;
            }
        }
        public string NameElike
        {
            set
            {
                _NameELike = value;
            }
        }
        public double SurveyFrom
        {
            set
            {
                _SurveyFrom = value;
            }
        }
        public double SurveyTo
        {
            set 
            {
                _SurveyTo = value;
            }
        }
        public double UnitPriceFrom
        {
            set
            {
                _UnitPriceFrom = value;
            }
        }
        public double UnitPriceTo
        {
            set
            {
                _UnitPriceTo = value;
            }
        }
        public int CellFamilyID
        {
            set
            {
                _CellFamilyID = value;
            }
        }
        public string CellIDs
        {
            set
            {
                _CellIDs = value;
            }
        }
        public DataTable ComponantTable
        {
            set
            {
                _ComponantTable = value;
            }
        }
        public double CachePrice
        {
            set
            {
                _CachePrice = value;
            }
            get
            {
                return _CachePrice;
            }
        }
        DataTable _ImageTable;
        public DataTable ImageTable
        {
            set
            {
                _ImageTable = value;
            }
        }
        public static string SearchStr
        {
            get
            {
                string Returned = " SELECT     CRMUnitModel.ModelID, CRMUnitModel.ModelCellID, CRMUnitModel.ModelNameA"+
                    ", CRMUnitModel.ModelNameE, CRMUnitModel.ModelSurvey " +
                    ", CRMUnitModel.ModelUnitPrice,CRMUnitModel.ModelCachePrice,CRMUnitModel.ModelFinishing"+
                    ",CRMUnitModel.ModelRoomNo,CRMUnitModel.ModelFloorNo,CRMUnitModel.ModelLogo"+
                    ",CRMUnitModel.ModelMovie,CRMUnitModel.ModelParentID,CRMUnitModel.ModelFamilyID  " +
                    ",ModelFamilyTable.ModelNameA as ModelFamilyName " +
                    ",case when CRMUnitModel.ModelUnitPrice = 0 and CRMUnitModel.ModelCachePrice = 0 then " +
                    " case when ModelFamilyTable.ModelCachePrice = 0 then ModelFamilyTable.ModelSurvey * ModelFamilyTable.ModelUnitPrice else ModelFamilyTable.ModelCachePrice end " +
                    " else "+
                    " case when CRMUnitModel.ModelCachePrice = 0 then CRMUnitModel.ModelSurvey * CRMUnitModel.ModelUnitPrice else CRMUnitModel.ModelCachePrice end " +
                    " end as AppliedModelPrice "+
                     " FROM  CRMUnitModel " +
                     " inner join CRMUnitModel as ModelFamilyTable "+
                     " on CRMUnitModel.ModelFamilyID = ModelFamilyTable.ModelID  ";
                return Returned;
            }
        }
        #endregion
        #region Private Methods
        void SetData(DataRow objDR)
        {
            if (objDR["ModelID"].ToString() != "")
            {
                _ID = int.Parse(objDR["ModelID"].ToString());
                _ParentID = int.Parse(objDR["ModelParentID"].ToString());
                _FamilyID = int.Parse(objDR["ModelFamilyID"].ToString());
                _NameA = objDR["ModelNameA"].ToString();
                _NameE = objDR["ModelNameE"].ToString();
                _CellID = int.Parse(objDR["ModelCellID"].ToString());
                _Survey = double.Parse(objDR["ModelSurvey"].ToString());
                _UnitPrice = double.Parse(objDR["ModelUnitPrice"].ToString());
                _CachePrice = double.Parse(objDR["ModelCachePrice"].ToString());
                _RoomNo = int.Parse(objDR["ModelRoomNo"].ToString());
                _FloorNo = int.Parse(objDR["ModelFloorNo"].ToString());
                _Logo = int.Parse(objDR["ModelLogo"].ToString());
                _Movie = int.Parse(objDR["ModelMovie"].ToString());
            }
            
        }
        void SetOldRelatedCustomers(string strParentID, DataTable dtTemp, ref string strIDs)
        {
            DataRow[] arrDR = dtTemp.Select("ModelParentID = " + strParentID);
            string strTempParent;
            foreach (DataRow objDR in arrDR)
            {
                if (strIDs != "")
                    strIDs = strIDs + ",";
                strTempParent = objDR["ModelID"].ToString();
                strIDs = strIDs + objDR["ModelID"].ToString();
                SetOldRelatedCustomers(strTempParent, dtTemp, ref strIDs);
            }
        }
        #endregion
        #region Public Methods
        public override void Add()
        {
            _ParentID = _ParentID == 0 ? _ID : _ParentID;
            _FamilyID = _FamilyID == 0 ? _ID : _FamilyID;
            string strSql = " INSERT INTO CRMUnitModel "+
                            " (ModelCellID, ModelNameA, ModelNameE, ModelSurvey, ModelUnitPrice,ModelCachePrice,ModelFinishing,ModelRoomNo,ModelFloorNo,ModelLogo,ModelMovie,ModelParentID,ModelFamilyID,UsrIns,TimIns)" +
                            " VALUES     ("+_CellID+",'"+_NameA+"','"+_NameE+"',"+_Survey+","+_UnitPrice+","+ _CachePrice + "," +
                            _Finishing+ "," +
                            _RoomNo + "," + _FloorNo +","+_Logo+","+_Movie+","+_ParentID+","+_FamilyID+"," + SysData.CurrentUser.ID +",GetDate()  ) ";
           _ID = SysData.SharpVisionBaseDb.InsertIdentityTable(strSql);
           if (_ParentID == 0)
           {
               strSql = "update CRMUnitModel set ModelParentID =" + _ID + ",ModelFamilyID=" + _ID + " where ModelID= " + _ID;
               SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
               _ParentID = _ID;
               _FamilyID = _ID;

           }
           JoinComponant();
            JoinImage();
        }
        public override void Edit()
        {
            _ParentID = _ParentID == 0 ? _ID : _ParentID;
            _FamilyID = _FamilyID == 0 ? _ID : _FamilyID;

            string strSql = " UPDATE    CRMUnitModel " +
                            " SET  ModelNameA ='" + _NameA + "'" +
                            ", ModelNameE ='" + _NameE + "'" +
                            ", ModelSurvey =" + _Survey + "" +
                            ", ModelUnitPrice = " + _UnitPrice + "" +
                            ", ModelFinishing = " + _Finishing + "" +
                            ", ModelRoomNo = " + _RoomNo + "" +
                            ", ModelFloorNo = " + _FloorNo + "" +
                            ", ModelLogo = "+_Logo+""+
                            ", ModelMovie = "+_Movie+""+
                            ", UsrUpd = " + SysData.CurrentUser.ID + "" +
                            ",TimUpd=GetDate()"+
                            " Where ModelID  = " + _ID + "";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
            strSql = "select * from CRMUnitModel where ModelCellID in" +
                  "(select ModelFamilyID from CRMUnitModel where ModelFamilyID=" + _ID + "and ModelID<>" + _ID + "and ModelFamilyID<>" + _FamilyID + ")";
            DataTable dtTemp = SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
            JoinImage();
            if (dtTemp.Rows.Count == 0)
                return;
            string strIDs = "";
            SetOldRelatedCustomers(_ID.ToString(), dtTemp, ref strIDs);
            strSql = "Update CRMUnitModel set ModelFamilyID = " + _FamilyID + " where ModelID in ( " + strIDs + ")";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
            JoinComponant();
            
        }
        public override void Delete()
        {
            string strSql = " UPDATE    CRMUnitModel SET  Dis = GetDate() " +
                             " Where ModelID  = " + _ID + "";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);

        }
        public override DataTable Search()
        {
            string strSql = SearchStr + " WHERE    (CRMUnitModel.Dis IS NULL) ";
            if (_ID != 0)
                strSql = strSql + " And CRMUnitModel.ModelID = " + _ID.ToString();
            if (_CellID != 0)
                strSql = strSql + " and CRMUnitModel.ModelCellID=" + _CellID;
            if (_Movie != 0)
                strSql = strSql + " and CRMUnitModel.ModelMovie = " + _Movie;
            if(_CellFamilyID != 0)
                strSql = strSql + " and CRMUnitModel.ModelCellID in (select CellID from RPCell Where CellFamilyID= " + _CellFamilyID + ") ";
            if (_CellIDs != null && _CellIDs != "")
            {
                strSql = strSql + " and CRMUnitModel.ModelCellID in (" + _CellIDs + ")";
            }
            if (_NameA != null && _NameA != "")
            {
                strSql = strSql + " and CRMUnitModel.ModelNameA ='" + _NameA + "' ";
            }
            if (_NameALike != null &&  _NameALike != "")
            {
                strSql = strSql + " and CRMUnitModel.ModelNameA like '%" + _NameALike + "%' ";
            }
            if (_NameELike != null && _NameELike != "")
            {
                strSql = strSql + " and CRMUnitModel.ModelNameE like '%" + _NameELike + "%' ";
            }
            if (_RoomNo != 0)
                strSql = strSql + " and CRMUnitModel.ModelRoomNo=" + _RoomNo;
            if (_FloorNo > 1)
                strSql = strSql + " and CRMUnitModel.ModelFloorNo=" + _FloorNo;
            if (_Survey != 0)
                strSql = strSql + " and CRMUnitModel.ModelSurvey = " + _Survey;

            if (_UnitPrice != 0)
            {
                strSql = strSql + " and CRMUnitModel.ModelunitPrice = " + _UnitPrice;
            }
            if (_UnitPriceFrom != 0)
            {
                strSql = strSql + " and CRMUnitModel.ModelunitPrice >=" + _UnitPriceFrom + " and CRMUnitModel.ModelunitPrice <=" + _UnitPriceTo;
            }
            if(_SurveyFrom != 0)
                strSql = strSql + " and CRMUnitModel.ModelSurvey >=" + _SurveyFrom + " and CRMUnitModel.ModelSurvey<=" + _SurveyTo;
            strSql = "select Top 300 * from (" + strSql + ") as NativeTable order by ModelID desc ";
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        public DataTable GetStrategy()
        {
            DataTable Returned;
            StrategyDb objStrategyDb = new StrategyDb();
            objStrategyDb.ModelID = _ID;
            Returned = objStrategyDb.Search();
            return Returned;
        }
        public void JoinComponant()
        {
            if (_ComponantTable == null)
                return;
            string[] arrStr = new string[_ComponantTable.Rows.Count + 1];
            arrStr[0] = "delete from CRMModelComponant where ModelID=" + _ID;
            int intIndex = 0;
            foreach (DataRow objDr in _ComponantTable.Rows)
            {
                intIndex++;
                arrStr[intIndex] = "insert into CRMModelComponant (ModelID, ComponantID, ComponantNo, Length, Width) values(" +
                    _ID + "," + objDr["Componant"].ToString() + "," + objDr["No"].ToString() + "," + objDr["Length"].ToString() +
                    "," + objDr["Width"].ToString() + ")";
 
            }
            SysData.SharpVisionBaseDb.ExecuteNonQuery(arrStr);
 
        }
        public void JoinImage()
        {
            if (_ImageTable == null)
                return;
            List<string> arrStr = new List<string>();
            arrStr.Add("delete from CRMUnitModelImage where ModelID = "+_ID);
            ModelImageDb objDb;
            foreach (DataRow objDr in _ImageTable.Rows)
            {
                objDb = new ModelImageDb(objDr);
                objDb.ModelID = _ID;
                arrStr.Add(objDb.AddStr);
            }
            SysData.SharpVisionBaseDb.ExecuteNonQuery(arrStr);
            
        }
        #endregion
    }
}
