using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.SystemBase;
namespace SharpVision.RP.RPDataBase
{
    public class ContractElementDiscountDb : ContractElementDb
    {
        #region Private Data
        int _DiscountID;
        double _InitialValue;
        int _EmployeeID;

        string _EmployeeName;
        string _EmployeeCode;
        #endregion
        #region Constructors
        public ContractElementDiscountDb(DataRow objDr)
            : base(objDr)
        {
           
        }
        public ContractElementDiscountDb()
        {


        }
        #endregion
        #region Public Properties
        public int DiscountID
        {
            set
            {
                _DiscountID = value;
            }
            get
            {
                return _DiscountID;
            }
        }
        public double InitialValue
        {
            set
            {
                _InitialValue = value;
            }
            get
            {
                return _InitialValue;
            }
        }

        public int EmployeeID
        {
            set
            {
                _EmployeeID = value;
            }
            get
            {
                return _EmployeeID;
            }
        }
        public string EmployeeName
        {
            get
            {
                return _EmployeeName;
            }
        }
        public string EmployeeCode
        {
            get
            {
                return _EmployeeCode;
            }
        }
        public override string AddStr
        {
            get
            {
                string Returned = base.AddStr;
                Returned += " " ;
                Returned += " declare @ID int "+
                    " set @ID = (select @@IDENTITY  as LastID) ";
                Returned += " insert into RPContractElementDiscount  (ContractElementID," +
                "DiscountEmployee, DiscountTypeID,InitialValue) " +
                " values (@ID," + _EmployeeID + "," + _DiscountID + "," + _InitialValue + ")";

                return Returned;
            }
        }
        public override string EditStr
        {
            get
            {
                string Returned = base.EditStr;
                Returned += " ";
                Returned += "insert into RPContractElementDiscount  (ContractElementID," +
               "DiscountEmployee, DiscountTypeID,InitialValue) " +
               " values (" + _ID + "," + _EmployeeID + "," + _DiscountID + "," + _InitialValue + ")";
                return Returned;
            }
        }
        public static string SearchStr
        {
            get
            {
                string strDiscountEmployee = "SELECT dbo.HRApplicant.ApplicantID AS DiscountEmployeeID, dbo.HRApplicant.ApplicantFirstName AS DiscountEmployeeName, "+
                    " dbo.HRApplicantWorker.ApplicantCode AS DiscountEmployeeCode "+
                    " FROM  dbo.HRApplicant INNER JOIN "+
                    " dbo.HRApplicantWorker ON dbo.HRApplicant.ApplicantID = dbo.HRApplicantWorker.ApplicantID ";
                string Returned = "SELECT   ContractElementID as ContractElementDiscountID,DiscountTable.*,DiscountEmployeeTable.*,RPContractElementDiscount.InitialValue as DiscountInitialValue " +
                          " FROM  dbo.RPContractElementDiscount inner join (" + //DiscountTypeDb.SearchStr + 
                          ") as DiscountTable " +
                          " on  DiscountTable.DiscountTypeID = RPContractElementDiscount.DiscountTypeID "+
                          " left outer join ("+ strDiscountEmployee +") as DiscountEmployeeTable "+
                          " on RPContractElementDiscount.DiscountEmployee = DiscountEmployeeTable.DiscountEmployeeID  ";
                return Returned;
            }
        }
        #endregion
        #region Private Methods
        protected override void SetData(DataRow objDr)
        {
            base.SetData(objDr);
            if (objDr.Table.Columns["DiscountInitialValue"] != null && objDr["DiscountInitialValue"].ToString() != "")
                _InitialValue = double.Parse(objDr["DiscountInitialValue"].ToString());
            if (objDr.Table.Columns["DiscountEmployeeID"] != null && objDr["DiscountEmployeeID"].ToString() != "")
                _EmployeeID = int.Parse(objDr["DiscountEmployeeID"].ToString());
            if (objDr.Table.Columns["DiscountEmployeeName"] != null)
                _EmployeeName = objDr["DiscountEmployeeName"].ToString();
            if (objDr.Table.Columns["DiscountEmployeeCode"] != null)
                _EmployeeCode = objDr["DiscountEmployeeCode"].ToString();
            if (objDr.Table.Columns["DiscountTypeID"] != null && objDr["DiscountTypeID"].ToString() != "")
                _DiscountID = int.Parse(objDr["DiscountTypeID"].ToString());
        }
        #endregion
        #region Public Methods
        public override void Add()
        {
            base.Add();
            string strSql = "insert into RPContractElementDiscount  (ContractElementID,"+
                "DiscountEmployee, DiscountTypeID,InitialValue) " +
                " values (" + _ID + ","  + _EmployeeID + "," + _DiscountID + ","  + _InitialValue +")";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);

        }
        public override void Edit()
        {
            base.Edit();
            string strSql = "insert into RPContractElementDiscount  (ContractElementID," +
               "DiscountEmployee, DiscountTypeID,InitialValue) " +
               " values (" + _ID + "," + _EmployeeID + "," + _DiscountID + "," + _InitialValue + ")";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);

        }
        public override void Delete()
        {
            base.Delete();
            string strSql = "delete from  RPContractElementDiscount "+
                   " where ContractElementID=" + _ID + " and   not Exists (SELECT  ContractElementID " +
                   " FROM         dbo.RPContractElement " +
                   " WHERE     (ContractElementID = " + _ID + "))";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public override DataTable Search()
        {
            ContractElementDb objContractElementDb = new ContractElementDb();
            string strSql = objContractElementDb.SearchStr + " where DiscountTable.DiscountID is not null " +
                      " and DiscountTable.DiscountID != 0 ";
            if (_ContractID != 0)
                strSql = strSql + " and RPContractElement.ContractID = " + _ContractID;
            if (_DiscountID != 0)
                strSql = strSql + " and DiscountTable.DiscountID= " + _DiscountID;
            if (_ContractElementDesc != null && _ContractElementDesc != "")
                strSql = strSql + " and ContractElementDesc like '%" + _ContractElementDesc + "%'";

            strSql = "select top 100 from (" + strSql + ") as NativeTable ";
            DataTable Returned = SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
            return Returned;
        }

        #endregion
    }
}
