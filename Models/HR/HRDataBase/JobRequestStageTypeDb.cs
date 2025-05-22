using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.SystemBase;
using System.Data;
using SharpVision.Base.BaseDataBase;



namespace SharpVision.HR.HRDataBase
{
    public class JobRequestStageTypeDb : BaseSingleDb
    {
        #region Private Data
        #endregion
        #region Constructors
        public JobRequestStageTypeDb()
        {
        }
        public JobRequestStageTypeDb(int intID)
        {
            _ID = intID;
            DataTable dtTemp = Search();
            DataRow objDR = dtTemp.Rows[0];
            SetData(objDR);
        }
        public JobRequestStageTypeDb(DataRow objDR)
        {
            SetData(objDR);           
        }
        #endregion
        #region Public Properties        
        public static string SearchStr
        {
            get
            {
                string Returned = "SELECT     HRJobRequestStageType.StageTypeID, HRJobRequestStageType.StageTypeNameA, HRJobRequestStageType.StageTypeNameE FROM  HRJobRequestStageType ";
                return Returned;
            }
        }
        #endregion
        #region Private Methods
        void SetData(DataRow objDR)
        {
            _ID = int.Parse(objDR["StageTypeID"].ToString());
            _NameA = objDR["StageTypeNameA"].ToString();
            _NameE = objDR["StageTypeNameE"].ToString();            
        }
        #endregion
        #region Public Methods
        public override void Add()
        {
            string strSql = "insert into HRJobRequestStageType (StageTypeNameA,StageTypeNameE,UsrIns,TimIns) " +
            "values('" + _NameA + "','" + _NameE + "'," + SysData.CurrentUser.ID + ",Getdate())";            
            _ID = SystemBase.SysData.SharpVisionBaseDb.InsertIdentityTable(strSql);
        }
        public override void Edit()
        {
            string strSql = "update  HRJobRequestStageType ";
            strSql = strSql + " set StageTypeNameA ='" + _NameA + "'";
            strSql = strSql + " ,StageTypeNameE ='" + _NameE + "'";            
            strSql = strSql + ",UsrUpd = " + SysData.CurrentUser.ID +"";            
            strSql = strSql + ",TimUpd =Getdate() ";
            strSql = strSql + " where StageTypeID = " + _ID;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public override void Delete()
        {
            string strSql = "update HRJobRequestStageType set Dis = GetDate() where StageTypeID=" + _ID;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public override DataTable Search()
        {
            string strSql = SearchStr + " WHERE    (HRJobRequestStageType.Dis IS NULL)";
            if (_ID != 0)
                strSql = strSql + " and StageTypeID = " + _ID.ToString();
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        #endregion
    }
}
