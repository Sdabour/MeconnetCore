using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.SystemBase;
using System.Data;
using System.Data.SqlClient;
using SharpVision.Base.BaseDataBase;

namespace SharpVision.CRM.CRMDataBase
{
    public class UnitTypeDb : BaseSingleDb
    {
        #region Private Data
        #endregion

        #region Constractors
        public UnitTypeDb()
        { 

        }
        public UnitTypeDb(int intID)
        {
            DataTable dtTemp = Search();
            DataRow objDR = dtTemp.Rows[0];
            SetData(objDR);
        }
        public UnitTypeDb(DataRow objDR)
        {
            SetData(objDR);
        }
        #endregion

        #region Public Accessorice
        int _UserID;
        public int UserID
        {
            set => _UserID = value;
        }
        string _TypeIDs;
        public string TypeIDs
        {
            set => _TypeIDs = value;
        }
        public  string SearchStr
        {
            get
            {
                string Returned = " SELECT     UnitTypeID, UnitTypeNameA, UnitTypeNameE"+
                                  " FROM         CRMUnitType ";
                return Returned;
            }
        }
        #endregion

        #region Private Methods
        void SetData(DataRow objDR)
        {
            if(objDR["UnitTypeID"].ToString()!= "")
            _ID = int.Parse(objDR["UnitTypeID"].ToString());
            _NameA = objDR["UnitTypeNameA"].ToString();
            _NameE = objDR["UnitTypeNameE"].ToString();
        }
        #endregion

        #region Public Methods
        public override void Add()
        {
            string strSql = " INSERT INTO CRMUnitType"+
                            " ( UnitTypeNameA, UnitTypeNameE,UsrIns,TimIns)"+
                            " VALUES     ('"+_NameA+"','"+_NameE+"'," + SysData.CurrentUser.ID  +",GetDate()) ";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public override void Edit()
        {
            string strSql = " UPDATE    CRMUnitType"+
                            " SET  UnitTypeNameA ='"+_NameA+"'"+
                            ", UnitTypeNameE = '"+_NameE+"'"+
                            ",UsrUpd="+SysData.CurrentUser.ID +
                            ",TimUpd=GetDate() "+
                            " Where UnitTypeID  = "+_ID+"";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public override void Delete()
        {
            string strSql = " UPDATE    CRMUnitType"+
                            " SET   Dis = GetData() "+
                            " Where UnitTypeID  = " + _ID + "";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public override DataTable Search()
        {
            string strSql = SearchStr + " Where Dis Is Null ";
            if (_ID != 0)
                strSql += " and  UnitTypeID = " + _ID + "";
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        public void AssignUserUnitType()
        {
            if (_UserID == 0 || (_TypeIDs == null || _TypeIDs == ""))
                return;
            string strSql = @"delete dbo.CRMUserUnitType
WHERE(UserID = " + _UserID + ") ";
            strSql += " insert into CRMUserUnitType ( UserID, UnitType)" +
                @" SELECT        " + _UserID + @" AS UserID, UnitTypeID
FROM            dbo.CRMUnitType
WHERE        (UnitTypeID IN (" + _TypeIDs + @"))";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);

        }
        public DataTable GetUserUnitType()
        {
            string strSql = SearchStr;
            if (_UserID != 0)
                strSql += @" inner join CRMUserUnitType 
  on CRMUnitType.UnitTypeID = CRMUserUnitType.UnitType 
  where CRMUnitType.Dis Is Null and CRMUserUnitType.UserID=" + _UserID;
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        #endregion
    }
}
