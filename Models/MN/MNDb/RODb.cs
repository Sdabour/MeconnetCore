using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using SharpVision.SystemBase;

namespace AlgorithmatMN.MN.MNDb
{
   public  class RODb
    {


        #region Constructor
        public RODb()
        {
        }
        public RODb(DataRow objDr)
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
        string _Code;
        public string Code
        {
            set
            {
                _Code = value;
            }
            get
            {
                return _Code;
            }
        }
        string _ExactCode;
        public string ExactCode
        {
            set
            {
                _ExactCode = value;
            }
          
        }
        string _ProjectCode;
        public string ProjectCode
        {
            set
            {
                _ProjectCode = value;
            }
            get
            {
                return _ProjectCode;
            }
        }
        string _ProjectCodeS;
        public string ProjectCodeS
        {
            set
            {
                _ProjectCodeS = value;
            }
           
        }
        string _TowerCode;
        public string TowerCode { set => _TowerCode = value; get => _TowerCode; }
        double _Area;
        public double Area { set => _Area = value; get => _Area; }
        int _Type;
        public int Type
        {
            set
            {
                _Type = value;
            }
            get
            {
                return _Type;
            }
        }
        int _ReservationID;
        public int ReservationID { set => _ReservationID = value; get => _ReservationID; }
        string _SapContract;
        public string SapContract { set => _SapContract = value; get => _SapContract; }
        string _SapCustomerNo;
        public string SapCustomerNo { set => _SapCustomerNo = value; get => _SapCustomerNo; }
        string _Customer;
        public string Customer
        {
            set
            {
                _Customer = value;
            }
            get
            {
                return _Customer;
            }
        }
        string _IDs;
        public string IDs
        { set =>_IDs= value; }
        bool _IsDelivered;
        public bool IsDelivered { set => _IsDelivered = value; get => _IsDelivered; }
        int _IsDeliveredStatus;
        public int IsDeliveredStatus { set => _IsDeliveredStatus = value; }
        DateTime _DeliveryDate;
        public DateTime DeliveryDate
        {
            set
            {
                _DeliveryDate = value;
            }
            get
            {
                return _DeliveryDate;
            }
        }
        bool _IsEnded;
        public bool IsEnded
        { set => _IsEnded = value; get => _IsEnded; }
        DateTime _EndDate;
        public DateTime EndDate
        {
            set
            {
                _EndDate = value;
            }
            get
            {
                return _EndDate;
            }
        }
        double _InitialMaintainanceValue;
        public double InitialMaintainanceValue
        {
            set
            {
                _InitialMaintainanceValue = value;
            }
            get
            {
                return _InitialMaintainanceValue;
            }
        }
        double _MaintainanceBonusPercPerYear;
        public double MaintainanceBonusPercPerYear
        {
            set
            {
                _MaintainanceBonusPercPerYear = value;
            }
            get
            {
                return _MaintainanceBonusPercPerYear;
            }
        }
        DateTime _ContractingDate;
        public DateTime ContractingDate { get => _ContractingDate; 
        }
        bool _IsCanceled;
        public bool IsCanceled { get => _IsCanceled; }
        DateTime _CancelDate;
        public DateTime CancelDate { get => _CancelDate; }
        double _Value;
        public double Value { get => _Value; }
        public string AddStr
        {
            get
            {
                string Returned = " insert into MNRO (ROCode,ROArea,ROReservationID,ROProjectCode,ROTowerCode,ROType,ROSapContract,ROSapCustomerNo,ROCustomer,ROIsDelivered,RODeliveryDate,ROInitialMaintainanceValue,ROMaintainanceBonusPercPerYear,UsrIns,TimIns) values ('" + Code + "'," + _Area + "," + _ReservationID + ",'" + ProjectCode+"','"+_TowerCode + "'," + Type + ",'" + _SapContract + "','" + _SapCustomerNo + "','" + Customer + "'," + (_IsDelivered?"1":"0")+"," + (DeliveryDate.ToOADate() - 2).ToString() + "," + InitialMaintainanceValue + "," + MaintainanceBonusPercPerYear + "," + SysData.CurrentUser.ID + ",GetDate() ) ";

                return Returned;
            }
        }
        public string EditStr
        {
            get
            {
                string Returned = " update MNRO set  ROCode='" + Code + "'" +
           ",ROProjectCode='" + ProjectCode + "'" +
           ",ROTowerCode='"+_TowerCode+"'"+
           ",ROArea=" +_Area+
           ",ROType=" + Type + "" +
           ",ROSapContract='"+_SapContract+"'"+
           ",ROSapCustomerNo='"+_SapCustomerNo+"'"+
           ",ROCustomer='" + Customer + "'" +
           ",RODeliveryDate=" + (DeliveryDate.ToOADate() - 2).ToString() + "" +
           ",ROInitialMaintainanceValue=" + InitialMaintainanceValue + "" +
           ",ROMaintainanceBonusPercPerYear=" + MaintainanceBonusPercPerYear + "" + ",UsrUpd=" + SysData.CurrentUser.ID + @",TimUpd=GetDate()  where ROID="+_ID;
                return Returned;
            }
        }

        public string EditValueDeliveryDateStr
        {
            get
            {
                string strCreditRO = @"SELECT CreditRO, COUNT(CreditID) AS CreditCount
FROM     dbo.MNROCredit
GROUP BY CreditRO ";
                string Returned = " update MNRO set ROSapContract='" + _SapContract + "'" +
           ",ROSapCustomerNo='" + _SapCustomerNo + "'" +
           ",ROCustomer='" + Customer + "'" +
           ",ROIsDelivered="+(_IsDelivered?"1":"0")+
           ",RODeliveryDate=" + (DeliveryDate.ToOADate() - 2).ToString() + "" +
           ",ROInitialMaintainanceValue=" + InitialMaintainanceValue + "" +
           ",ROMaintainanceBonusPercPerYear=" + MaintainanceBonusPercPerYear + "" + ",UsrUpd=" + SysData.CurrentUser.ID + @",TimUpd=GetDate() 
 from MNRO left outer join ("+strCreditRO+@") as CreditTable 
 on MNRO.ROID = CreditTable.CreditRO 
   where ROCode = '"+ _Code +"' and ROProjectCode = '"+_ProjectCode+"' and ROID=" + _ID + " and CreditTable.CreditRO is null ";
                return Returned;
            }
        }
        public string DeleteStr
        {
            get
            {
                string Returned = " update MNRO set Dis = GetDate() where  ";
                return Returned;
            }
        }
        public string SearchStr
        {
            get
            {
                string strReservationValue = @"SELECT ReservationValueTable.ReservationID, ReservationValueTable.TotalValue, ISNULL(derivedtbl_1.TotalBonus, 0) AS TotalBonus, ISNULL(DiscountTable.TotalDiscount, 0) AS TotalDiscount
FROM     (SELECT ReservationID, SUM(Value) AS TotalValue
                  FROM      (SELECT ReservationID, InstallmentDueDate, InstallmentValue AS Value, 'z' AS ConditionType
                                     FROM      dbo.CRMReservationInstallment
                                     UNION ALL
                                     SELECT dbo.CRMTempReservationPayment.ReservationID, dbo.GLPayment.PaymentDate, dbo.GLPayment.PaymentValue AS Value, 'z401' AS ConditionType
                                     FROM     dbo.CRMTempReservationPayment INNER JOIN
                                                       dbo.GLPayment ON dbo.CRMTempReservationPayment.PaymentID = dbo.GLPayment.PaymentID) AS ValueTbale
                  GROUP BY ReservationID) AS ReservationValueTable LEFT OUTER JOIN
                      (SELECT ReservationID, SUM(DiscountValue) AS TotalDiscount
                       FROM      dbo.CRMReservationDiscount
                       GROUP BY ReservationID) AS DiscountTable ON ReservationValueTable.ReservationID = DiscountTable.ReservationID LEFT OUTER JOIN
                      (SELECT ReservationID, SUM(BonusValue) AS TotalBonus
                       FROM      dbo.CRMReservationBonus
                       GROUP BY ReservationID) AS derivedtbl_1 ON ReservationValueTable.ReservationID = derivedtbl_1.ReservationID ";
                string strReservation = @" SELECT dbo.CRMReservation.ReservationID as MainReservationID, dbo.CRMReservation.ReservationContractingDate
,ReservationValueTable.TotalValue-ReservationValueTable.TotalBonus as ReservationValue1, dbo.CRMReservationCancelation.ReservationID AS CanceledReservationID, 
                  dbo.CRMReservationCancelation.CancelationDate
FROM     dbo.CRMReservation LEFT OUTER JOIN
                  dbo.CRMReservationCancelation ON dbo.CRMReservation.ReservationID = dbo.CRMReservationCancelation.ReservationID  inner join (" + strReservationValue + @") as ReservationValueTable  on dbo.CRMReservation.ReservationID = ReservationValueTable.ReservationID ";
                string Returned = @" select ROID,ROCode,ROArea,ROReservationID,ROProjectCode,ROTowerCode,ROType,ROSapContract,ROSapCustomerNo,ROCustomer,ROIsDelivered,RODeliveryDate,ROIsEnded,ROEndDate,ROInitialMaintainanceValue,ROMaintainanceBonusPercPerYear,ReservationTable.*  from MNRO  
 left outer join (" + strReservation + @") as ReservationTable 
 on MNRO.ROReservationID = ReservationTable.MainReservationID ";
                return Returned;
            }
        }
        public string SearchStr1
        {
            get
            {
                string strReservation = @" SELECT dbo.CRMReservation.ReservationID as MainReservationID, dbo.CRMReservation.ReservationContractingDate, dbo.CRMReservation.ReservationValue, dbo.CRMReservationCancelation.ReservationID AS CanceledReservationID, 
                  dbo.CRMReservationCancelation.CancelationDate
FROM     dbo.CRMReservation LEFT OUTER JOIN
                  dbo.CRMReservationCancelation ON dbo.CRMReservation.ReservationID = dbo.CRMReservationCancelation.ReservationID ";
                string Returned = @" select ROID,ROCode,ROArea,ROReservationID,ROProjectCode,ROTowerCode,ROType,ROSapContract,ROSapCustomerNo,ROCustomer,ROIsDelivered,RODeliveryDate,ROIsEnded,ROEndDate,ROInitialMaintainanceValue,ROMaintainanceBonusPercPerYear,ReservationTable.*  from MNRO  
 left outer join ("+ strReservation + @") as ReservationTable 
 on MNRO.ROReservationID = ReservationTable.MainReservationID ";
                return Returned;
            }
        }
        #endregion
        #region Private Method
        void SetData(DataRow objDr)
        {

            if (objDr.Table.Columns["ROID"] != null)
                int.TryParse(objDr["ROID"].ToString(), out _ID);

            if (objDr.Table.Columns["ROCode"] != null)
                _Code = objDr["ROCode"].ToString();

            if (objDr.Table.Columns["ROProjectCode"] != null)
                _ProjectCode = objDr["ROProjectCode"].ToString();

            if (objDr.Table.Columns["ROTowerCode"] != null)
                _TowerCode = objDr["ROTowerCode"].ToString();

            if (objDr.Table.Columns["ROType"] != null)
                int.TryParse(objDr["ROType"].ToString(), out _Type);

            if (objDr.Table.Columns["ROCustomer"] != null)
                _Customer = objDr["ROCustomer"].ToString();

            if (objDr.Table.Columns["ROSapContract"] != null)
                _SapContract = objDr["ROSapContract"].ToString();

            if (objDr.Table.Columns["ROSapCustomerNo"] != null)
                _SapCustomerNo = objDr["ROSapCustomerNo"].ToString();

            if (objDr.Table.Columns["RODeliveryDate"] != null)
                DateTime.TryParse(objDr["RODeliveryDate"].ToString(), out _DeliveryDate);

            if (objDr.Table.Columns["ROInitialMaintainanceValue"] != null)
                double.TryParse(objDr["ROInitialMaintainanceValue"].ToString(), out _InitialMaintainanceValue);

            if (objDr.Table.Columns["ROMaintainanceBonusPercPerYear"] != null)
                double.TryParse(objDr["ROMaintainanceBonusPercPerYear"].ToString(), out _MaintainanceBonusPercPerYear);
            if (objDr.Table.Columns["ROArea"] != null)
                double.TryParse(objDr["ROArea"].ToString(), out _Area);
            if (objDr.Table.Columns["ROReservationID"] != null)
                int.TryParse(objDr["ROReservationID"].ToString(), out _ReservationID);
            if (objDr.Table.Columns["ROIsEnded"] != null)
                bool.TryParse(objDr["ROIsEnded"].ToString(), out _IsEnded);
            if (objDr.Table.Columns["ROEndDate"] != null)
                DateTime.TryParse(objDr["ROEndDate"].ToString(), out _EndDate);
            if (objDr.Table.Columns["ROIsDelivered"] != null)
                bool.TryParse(objDr["ROIsDelivered"].ToString(), out _IsDelivered);
            if (objDr.Table.Columns["ReservationContractingDate"] != null)
                DateTime.TryParse(objDr["ReservationContractingDate"].ToString(), out _ContractingDate);
            if (objDr.Table.Columns["ReservationValue1"] != null)
                double.TryParse(objDr["ReservationValue1"].ToString(), out _Value);
            if (objDr.Table.Columns["CanceledReservationID"] != null && objDr["CanceledReservationID"].ToString() != "")
            {
                _IsCanceled = true;
                DateTime.TryParse(objDr["CancelationDate"].ToString(), out _CancelDate);

            }
        }

        #endregion
        #region Public Method 
        public void Add()
        {
            string strSql = AddStr;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public void Edit()
        {
            string strSql = EditStr;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public void EditMaintainanceValue()
        {
            string strSql = EditValueDeliveryDateStr ;
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
            if (_Code != null && _Code != "")
                strSql += " and ROCode like '%"+_Code+"%' ";
            if (_ExactCode != null && _ExactCode != "")
                strSql += " and ROCode ='" + _ExactCode + "' ";
            if (_ProjectCode != null && _ProjectCode != "")
                strSql += " and ROProjectCode='"+ _ProjectCode +"' ";
            if (_ProjectCodeS != null && _ProjectCodeS != "")
                strSql += " and ROProjectCode in (" + _ProjectCodeS + ") ";
            if (_ID != 0)
                strSql += " and ROID = "+_ID;
            if (_IsDeliveredStatus == 1)
                strSql += " and ROIsDelivered=1 ";
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        public void DeleteAllCredit()
        { 
        
        }
        #endregion
    }
}
