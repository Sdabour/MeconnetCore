using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.SystemBase;
namespace SharpVision.RP.RPDataBase
{
    public class ContractElementProcessDb:ContractElementDb
    {
        #region Private Data
        int _ProcessID;
        #endregion
        #region Constructors
        public ContractElementProcessDb(DataRow objDr):base(objDr)
        {

 
        }
        public ContractElementProcessDb()
        {


        }
        #endregion
        #region Public Properties
        public int ProcessID
        {
            set
            {
                _ProcessID = value;
            }
            get
            {
                return _ProcessID;
            }
        }
        public override string AddStr
        {
            get
            {
                string Returned = base.AddStr;
                Returned += " ";
                Returned += " declare @ID int " +
                 " set @ID = (select @@IDENTITY  as LastID) ";
                Returned += "insert into RPContractElementProcess  (ContractElementID, ProcessID) " +
                " values (@ID," + _ProcessID + ")";

                return Returned;
            }
        }
        public override string EditStr
        {
            get
            {
                string Returned = base.EditStr;
                Returned += " ";
                Returned += "insert into RPContractElementProcess  (ContractElementID, ProcessID) " +
              " values (" + _ID + "," + _ProcessID + ")";
                return Returned;
            }
        }
        public static string SearchStr
        {
            get
            {
                string Returned = "SELECT   ContractElementID as ContractElementProcessID,ProcessTable.* "+
                          " FROM  dbo.RPContractElementProcess inner join ("+new ProcessDb().SearchStr +") as ProcessTable " +
                          " on  ProcessTable.ProcessID = RPContractElementProcess.ProcessID ";
                return Returned;
            }
        }
        #endregion
        #region Private Methods
        protected override void SetData(DataRow objDR)
        {
            base.SetData(objDR);
            _ProcessID = int.Parse(objDR["ProcessID"].ToString());

        }
        #endregion
        #region Public Methods
        public override void Add()
        {
            base.Add();
            string strSql = "insert into RPContractElementProcess  (ContractElementID, ProcessID) "+
                " values (" + _ID + "," + _ProcessID + ")";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
            
        }
        public override void Edit()
        {
            base.Edit();
            string strSql = "insert into RPContractElementProcess  (ContractElementID, ProcessID) " +
              " values (" + _ID + "," + _ProcessID + ")";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public override DataTable Search()
        {
            ContractElementDb objContractElementDb = new ContractElementDb();
            string strSql = objContractElementDb.SearchStr + " where ProcessTable.ProcessID is not null " +
                      " and ProcessTable.ProcessID != 0 ";
            if (_ContractID != 0)
                strSql = strSql + " and RPContractElement.ContractID = " + _ContractID;
            if (_ElementType != 0)
                strSql = strSql + " and ProcessTable.ProcessTypeID= " + _ElementType;
            if (_ContractElementDesc != null && _ContractElementDesc != "")
                strSql = strSql + " and ContractElementDesc like '%"+ _ContractElementDesc +"%'";
            
            strSql = "select top 100 from ("+ strSql +") as NativeTable ";
            DataTable Returned = SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
            return Returned;
        }

        #endregion
    }
}
