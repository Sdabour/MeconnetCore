using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.SystemBase;
using System.Data;
using SharpVision.Base.BaseDataBase;



namespace SharpVision.HR.HRDataBase
{
    public class EstimationStatementTypeDb : BaseSingleDb
    {
        #region Private Data
        #endregion
        #region Constructors
        public EstimationStatementTypeDb()
        {
        }
        public EstimationStatementTypeDb(int intID)
        {
            _ID = intID;
            DataTable dtTemp = Search();
            DataRow objDR = dtTemp.Rows[0];
            SetData(objDR);
        }
        public EstimationStatementTypeDb(DataRow objDR)
        {
            SetData(objDR);           
        }
        #endregion
        #region Public Properties        
        public static string SearchStr
        {
            get
            {
                string Returned = "SELECT     HREstimationStatementType.EstimationStatementTypeID, HREstimationStatementType.EstimationStatementTypeNameA, HREstimationStatementType.EstimationStatementTypeNameE FROM  HREstimationStatementType ";
                return Returned;
            }
        }
        #endregion
        #region Private Methods
        void SetData(DataRow objDR)
        {
            _ID = int.Parse(objDR["EstimationStatementTypeID"].ToString());
            _NameA = objDR["EstimationStatementTypeNameA"].ToString();
            _NameE = objDR["EstimationStatementTypeNameE"].ToString();            
        }
        #endregion
        #region Public Methods
        public override void Add()
        {
            string strSql = "insert into HREstimationStatementType (EstimationStatementTypeNameA,EstimationStatementTypeNameE,UsrIns,TimIns) " +
            "values('" + _NameA + "','" + _NameE + "'," + SysData.CurrentUser.ID + ",Getdate())";            
            _ID = SystemBase.SysData.SharpVisionBaseDb.InsertIdentityTable(strSql);
        }
        public override void Edit()
        {
            string strSql = "update  HREstimationStatementType ";
            strSql = strSql + " set EstimationStatementTypeNameA ='" + _NameA + "'";
            strSql = strSql + " ,EstimationStatementTypeNameE ='" + _NameE + "'";            
            strSql = strSql + ",UsrUpd = " + SysData.CurrentUser.ID +"";            
            strSql = strSql + ",TimUpd =Getdate() ";
            strSql = strSql + " where EstimationStatementTypeID = " + _ID;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public override void Delete()
        {
            string strSql = "update HREstimationStatementType set Dis = GetDate() where EstimationStatementTypeID=" + _ID;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public override DataTable Search()
        {
            string strSql = SearchStr + " WHERE    (HREstimationStatementType.Dis IS NULL)";
            if (_ID != 0)
                strSql = strSql + " and EstimationStatementTypeID = " + _ID.ToString();
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        #endregion
    }
}
