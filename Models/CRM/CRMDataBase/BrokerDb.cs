using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using SharpVision.SystemBase;
using SharpVision.UMS.UMSDataBase;
namespace SharpVision.CRM.CRMDataBase
{
    public class BrokerDb
    {

        #region Constructor
        public BrokerDb()
        {
        }
        public BrokerDb(DataRow objDr)
        {
            SetData(objDr);
        }

        #endregion
        #region Properties
        int _ID;
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
        int _Type;
        public int Type
        { set => _Type = value;
            get => _Type;
        }
        string _Name;
        public string Name
        {
            set
            {
                _Name = value;
            }
            get
            {
                return _Name;
            }
        }
        string _IDNum;
        public string IDNum
        {
            set
            {
                _IDNum = value;
            }
            get
            {
                return _IDNum;
            }
        }
        int _IDType;
        public int IDType
        {
            set
            {
                _IDType = value;
            }
            get
            {
                return _IDType;
            }
        }
        string _MobileNo;
        public string MobileNo
        {
            set
            {
                _MobileNo = value;
            }
            get
            {
                return _MobileNo;
            }
        }
        string _PhoneNo;
        public string PhoneNo
        {
            set
            {
                _PhoneNo = value;
            }
            get
            {
                return _PhoneNo;
            }
        }
        int _CustomerID;
        public int CustomerID
        {
            set
            {
                _CustomerID = value;
            }
            get
            {
                return _CustomerID;
            }
        }
        string _CustomerName;
        public string CustomerName
        { get => _CustomerName; }
        string _CustomerUnitFullName;
        public string CustomerUnitFullName
        { get => _CustomerUnitFullName; }
        int _ApplicantID;
        public int ApplicantID
        {
            set
            {
                _ApplicantID = value;
            }
            get
            {
                return _ApplicantID;
            }
        }

        int _Region;
        public int Region
        {
            set
            {
                _Region = value;
            }
            get
            {
                return _Region;
            }
        }
        public string AddStr
        {
            get
            {
                string Returned = " insert into CRMBroker (BrokerType,BrokerName,BrokerIDNum,BrokerIDType,BrokerMobileNo,BrokerPhoneNo,BrokerCustomerID,BrokerApplicantID,BrokerRegion,UsrIns,TimIns) values ("+_Type+@",'" + Name + "','" + IDNum + "'," + IDType + ",'" + MobileNo + "','" + PhoneNo + "'," +
                    CustomerID + "," + ApplicantID + "," + Region + "," + SysData.CurrentUser.ID + ",GetDate() ) ";
                return Returned;
            }
        }
        public string EditStr
        {
            get
            {
                string Returned = " update CRMBroker set BrokerType = "+ _Type +
            ",BrokerName ='" + Name + "'" +
           ",BrokerIDNum='" + IDNum + "'" +
           ",BrokerIDType=" + IDType + "" +
           ",BrokerMobileNo='" + MobileNo + "'" +
           ",BrokerPhoneNo='" + PhoneNo + "'" +
           ",BrokerCustomerID=" + CustomerID + "" +
           ",BrokerApplicantID=" + ApplicantID + "" +
           ",BrokerRegion=" + Region + "" + ",UsrUpd=" + SysData.CurrentUser.ID + @",TimUpd=GetDate()  where BrokerID=" + ID  ;
                return Returned;
            }
        }
        public string DeleteStr
        {
            get
            {
                string Returned = " update CRMBroker set Dis = GetDate() where  BrokerID=" + ID;
                return Returned;
            }
        }
        public string SearchStr
        {
            get
            {
                string strCustomer = @"SELECT        CustomerID AS BrokerCustomer, CustomerFullName AS BrokerCustomerName,CustomerUnitTable.CustomerUnitFullName 
 FROM            dbo.CRMCustomer 
  left outer join (" + new CustomerDb().UnitStr + @") as CustomerUnitTable 
  on CRMCustomer.CustomerID = CustomerUnitTable.UnitCustomerID ";


                string Returned = @" select BrokerID,dbo.CRMBroker.BrokerType,BrokerName,BrokerIDNum,BrokerIDType,BrokerMobileNo,BrokerPhoneNo,BrokerCustomerID,BrokerApplicantID,BrokerRegion,CustomerTable.*,EmployeeTable.*,BrokerTypeTable.*  
   from CRMBroker 
  left outer join (" + strCustomer + @") as CustomerTable 
  on CRMBroker.BrokerCustomerID = CustomerTable.BrokerCustomer 
  left outer join ("+ EmployeeDb.SearchStr + @") as EmployeeTable
  on CRMBroker.BrokerApplicantID = EmployeeTable.ApplicantID 
 left outer join ("+BrokerTypeDb.SearchStr+ @") as BrokerTypeTable 
 on dbo.CRMBroker.BrokerType = BrokerTypeTable.BrokerTypeID ";
                return Returned;
            }
        }
        #endregion
        #region Private Method
        void SetData(DataRow objDr)
        {

            if (objDr.Table.Columns["BrokerID"] != null)
                int.TryParse(objDr["BrokerID"].ToString(), out _ID);

            if (objDr.Table.Columns["BrokerName"] != null)
                _Name = objDr["BrokerName"].ToString();

            if (objDr.Table.Columns["BrokerIDNum"] != null)
                _IDNum = objDr["BrokerIDNum"].ToString();

            if (objDr.Table.Columns["BrokerIDType"] != null)
                int.TryParse(objDr["BrokerIDType"].ToString(), out _IDType);

            if (objDr.Table.Columns["BrokerMobileNo"] != null)
                _MobileNo = objDr["BrokerMobileNo"].ToString();

            if (objDr.Table.Columns["BrokerPhoneNo"] != null)
                _PhoneNo = objDr["BrokerPhoneNo"].ToString();

            if (objDr.Table.Columns["BrokerCustomerID"] != null)
                int.TryParse(objDr["BrokerCustomerID"].ToString(), out _CustomerID);

            if (objDr.Table.Columns["BrokerCustomerName"] != null)
                _CustomerName = objDr["BrokerCustomerName"].ToString();

            if (objDr.Table.Columns["CustomerUnitFullName"] != null)
                _CustomerUnitFullName = objDr["CustomerUnitFullName"].ToString();

            if (objDr.Table.Columns["BrokerApplicantID"] != null)
                int.TryParse(objDr["BrokerApplicantID"].ToString(), out _ApplicantID);

            if (objDr.Table.Columns["BrokerRegion"] != null)
                int.TryParse(objDr["BrokerRegion"].ToString(), out _Region);
            if (objDr.Table.Columns["BrokerType"] != null)
                int.TryParse(objDr["BrokerType"].ToString(), out _Type);
        }

        #endregion
        #region Public Method 
        public void Add()
        {
            string strSql = AddStr;
            _ID = SysData.SharpVisionBaseDb.InsertIdentityTable(strSql);
        }
        public void Edit()
        {
            string strSql = EditStr;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public void Delete()
        {
            string strSql = DeleteStr;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public DataTable Search()
        {
            string strSql = SearchStr + " where Dis is null ";

            if (_Name != null && _Name != "")
                strSql += " and BrokerName like '%"+ _Name +"%' ";
            if (_CustomerID != 0)
                strSql += " and CRMBroker.BrokerCustomerID =" + _CustomerID;
            if (_ApplicantID != 0)
                strSql += " and CRMBroker.BrokerApplicantID=" + _ApplicantID;
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        #endregion
    }
}
