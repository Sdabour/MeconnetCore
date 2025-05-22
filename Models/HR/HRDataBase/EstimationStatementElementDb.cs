using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.SystemBase;
using System.Data;
namespace SharpVision.HR.HRDataBase
{
    public class EstimationStatementElementDb
    {
        #region Private Data                              
        protected int _Element;
        protected int _EstimationStatement;
        protected float _PercValue;
        protected bool _StatusDelete;
        #endregion
        #region Constructors
        public EstimationStatementElementDb()
        {
        }
        public EstimationStatementElementDb(DataRow objDR)
        {
            SetData(objDR);
        }
        #endregion
        #region Public Properties        

        public int Element
        {
            set { _Element = value; }
            get { return _Element; }
        }

        public int EstimationStatement
        {
            set { _EstimationStatement = value; }
            get { return _EstimationStatement; }
        }

        public float PercValue
        {
            set { _PercValue = value; }
            get { return _PercValue; }
        }
        public static string SearchStr
        {
            get
            {
                string ReturnStr = " SELECT     HREstimationStatementElement.EstimationStatement, HREstimationStatementElement.Element, HREstimationStatementElement.PercValue" +
                                   " ,ElementTable.*" +
                                   " FROM         HREstimationStatementElement " +
                                   " Inner join ( " + ElementDb.SearchStr + " ) ElementTable On HREstimationStatementElement.Element = ElementTable.ElementID";
                return ReturnStr;
            }
        }
        public string AddStr
        {
            get
            {
                string Returned = " INSERT INTO HREstimationStatementElement " +
                                  " (EstimationStatement, Element," +
                                  " PercValue, UsrIns, TimIns)" +
                                  " VALUES " +
                                  " (" + _EstimationStatement + "," + _Element + "," + _PercValue + "," + SysData.CurrentUser.ID + ",GetDate())";
                return Returned;

            }
        }
        public string EditStr
        {
            get
            {
                string Returned = " ";
                return Returned;
            }
        }
        public virtual string DeleteStr
        {
            get
            {
                string Returned = " DELETE FROM HREstimationStatementElement" +
                                  " Where   (EstimationStatement = " + _EstimationStatement + ") And (Element=" + _Element + ")";
                return Returned;
            }
        }
        #endregion
        #region Private Methods
        void SetData(DataRow objDR)
        {
            _EstimationStatement = int.Parse(objDR["EstimationStatement"].ToString());
            _Element = int.Parse(objDR["Element"].ToString());
            _PercValue = float.Parse(objDR["PercValue"].ToString());
        }
        #endregion
        #region Public Methods
        public void Add()
        {
            SystemBase.SysData.SharpVisionBaseDb.ExecuteNonQuery(AddStr);
        }
        public void Edit()
        {
            SysData.SharpVisionBaseDb.ExecuteNonQuery(EditStr);
        }
        public void Delete()
        {
            SysData.SharpVisionBaseDb.ExecuteNonQuery(DeleteStr);
        }
        public DataTable Search()
        {
            string strSql = SearchStr + " Where 1=1 ";

            if (_EstimationStatement != 0)
                strSql = strSql + " And   (EstimationStatement = " + _EstimationStatement + ")";
            if (_Element != 0)
                strSql = strSql + " And   (Element = " + _Element + ")";
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        #endregion
    }
}
