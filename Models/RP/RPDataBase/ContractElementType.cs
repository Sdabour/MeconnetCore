using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.SystemBase;
using System.Data;
using System.Data.SqlClient;
using SharpVision.Base.BaseDataBase;

namespace SharpVision.RP.RPDataBase
{
    public class ContractElementTypeDb : BaseSingleDb
    {
        #region Private Data
       
        #endregion
        #region Constructors
        public ContractElementTypeDb()
        {

        }

        public ContractElementTypeDb(int intID)
        {
            _ID = intID;
            DataTable dtTemp = Search();
            DataRow objDR = dtTemp.Rows[0];
            _NameA = objDR["ContractElementTypeNameA"].ToString();
            _NameE = objDR["ContractElementTypeNameE"].ToString();
           
        }
        public ContractElementTypeDb(DataRow objDR)
        {
            try
            {
                if (objDR.Table.Columns["ContractElementTypeID"] == null)
                    return;
                _ID = int.Parse(objDR["ContractElementTypeID"].ToString());
                _NameA = objDR["ContractElementTypeNameA"].ToString();
                _NameE = objDR["ContractElementTypeNameE"].ToString();
           
            }
            catch
            {
            }

        }
        public ContractElementTypeDb(int intID, string strName)
        {
            _ID = intID;
            if (SysData.Language == 0)
            {
                _NameA = strName;

            }
            else
            {
                _NameA = strName;


            }
        }
       
        #endregion
        #region Public Properties
               public string SearchStr
        {
            get
            {
                string Returned = "SELECT RPContractElementType.ContractElementTypeID, RPContractElementType.ContractElementTypeNameA,RPContractElementType.ContractElementTypeNameE " +
                    ",case when "+SysData.Language + "=0 then RPContractElementType.ContractElementTypeNameA else RPContractElementType.ContractElementTypeNameE end as ContractElementTypeName "+
                    " from RPContractElementType ";
                return Returned;
            }
        }


        #endregion
        #region Private Methods

        #endregion
        #region Public Methods
        public override void Add()
        {
            string strSql = "insert into RPContractElementType (ContractElementTypeNameA,ContractElementTypeNameE,UsrIns,TimIns) " +
            "values('" + _NameA + "','" + _NameE + "'," + SysData.CurrentUser.ID + ",Getdate())";
            _ID = SysData.SharpVisionBaseDb.InsertIdentityTable(strSql);
           
        }
        public override void Edit()
        {
            string strSql = "update  RPContractElementType ";
            strSql = strSql + " set ContractElementTypeNameA ='" + _NameA + "'";
            strSql = strSql + " ,ContractElementTypeNameE ='" + _NameE + "'";
            strSql = strSql + ",UsrUpd = " + SysData.CurrentUser.ID;
            strSql = strSql + ",TimUpd =Getdate() ";
            strSql = strSql + " where ContractElementTypeID = " + _ID;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
            
        }
        public override void Delete()
        {
            string strSql = "update RPContractElementType set Dis = GetDate() where ContractElementTypeID=" + _ID;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }

        public override DataTable Search()
        {
            string strSql = SearchStr + " WHERE    (1=1)";//(RPContractElementType.Dis IS NULL)";
            if (_ID != 0)
                strSql = strSql + " and ContractElementTypeID = " + _ID.ToString();


            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
      
        #endregion
    }
}
