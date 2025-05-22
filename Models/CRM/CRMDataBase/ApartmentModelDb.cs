using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.SystemBase;
using System.Data;
using System.Data.SqlClient;
using SharpVision.Base.BaseDataBase;
namespace SharpVision.CRM.CRMDataBase
{
    public class ApartmentModelDb : BaseSingleDb
    {
        #region Private Data
        protected int _CellID;
        protected double _Survey;
        protected double _UnitPrice;
        protected int _Finishing;
        #region Privaet Data
        string _NameALike;
        string _NameELike;
        double _SurveyFrom;
        double _SurveyTo;
        double _UnitPriceFrom;
        double _UnitPriceTo;
        #endregion 
        #endregion
        #region Constructors
        public ApartmentModelDb()
        { 

        }
        public ApartmentModelDb(int intID)
        {
            _ID = intID;
            DataTable dtTemp = Search();
            DataRow objDR = Search().Rows[0];
            _NameA = objDR["ModelNameA"].ToString();
            _NameE = objDR["ModelNameE"].ToString();
            _CellID = int.Parse(objDR["ModelCellID"].ToString());
            _Survey = double.Parse(objDR["ModelSurvey"].ToString());
            _UnitPrice = double.Parse(objDR["ModelUnitPrice"].ToString());
 
        }
        public ApartmentModelDb(DataRow objDR)
        {
            _ID = int.Parse(objDR["ModelID"].ToString());
            _NameA = objDR["ModelNameA"].ToString();
            _NameE = objDR["ModelNameE"].ToString();
            _CellID = int.Parse(objDR["ModelCellID"].ToString());
            _Survey = double.Parse(objDR["ModelSurvey"].ToString());
            _UnitPrice = double.Parse(objDR["ModelUnitPrice"].ToString());

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
        public static string SearchStr
        {
            get
            {
                string Returned = " SELECT     ModelID, ModelCellID, ModelNameA, ModelNameE, ModelSurvey, ModelUnitPrice,ModelFinishing " +
                                  " FROM  CRMApartmentModel";
                return Returned;
            }
        }
        #endregion
        #region Private Methods
        #endregion
        #region Public Methods
        public override void Add()
        {
            string strSql = " INSERT INTO CRMApartmentModel "+
                            " (ModelCellID, ModelNameA, ModelNameE, ModelSurvey, ModelUnitPrice,ModelFinishing)" +
                            " VALUES     ("+_CellID+",'"+_NameA+"','"+_NameE+"',"+_Survey+","+_UnitPrice+","+_Finishing+") ";
           _ID = SysData.SharpVisionBaseDb.InsertIdentityTable(strSql);
        }
        public override void Edit()
        {
            string strSql = " UPDATE    CRMApartmentModel " +
                            " SET  ModelNameA ='" + _NameA + "'" +
                            ", ModelNameE ='" + _NameE + "'" +
                            ", ModelSurvey =" + _Survey + "" +
                            ", ModelUnitPrice = " + _UnitPrice + "" +
                            ", ModelFinishing = "+_Finishing+""+
                            " Where ModelID  = " + _ID + "";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);

        }
        public override void Delete()
        {
            string strSql = " UPDATE    CRMApartmentModel SET  Dis = GetDate() " +
                             " Where ModelID  = " + _ID + "";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);

        }
        public override DataTable Search()
        {
            string strSql = SearchStr + " WHERE    (Dis IS NULL)";
            if (_ID != 0)
                strSql = strSql + " And ModelID = " + _ID.ToString();
            if (_CellID != 0)
                strSql = strSql + " and ModelCellID=" + _CellID;
            if (_NameALike != null &&  _NameALike != "")
            {
                strSql = strSql + " and ModelNameA like '%" + _NameALike + "%' ";
            }
            if (_NameELike != null && _NameELike != "")
            {
                strSql = strSql + " and ModelNameE like '%" + _NameELike + "%' ";
            }
            if (_Survey != 0)
                strSql = strSql + " and ModelSurvey = " + _Survey ;

            if (_UnitPrice != 0)
            {
                strSql = strSql + " and ModelunitPrice = " + _UnitPrice;
            }
            if (_UnitPriceFrom != 0)
            {
                strSql = strSql + " and ModelunitPrice >=" + _UnitPriceFrom + " and ModelunitPrice <=" + _UnitPriceTo;
            }
            if(_SurveyFrom != 0)
                strSql = strSql + " and ModelSurvey >=" + _SurveyFrom + " and ModelSurvey<=" + _SurveyTo;

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
        #endregion
    }
}
