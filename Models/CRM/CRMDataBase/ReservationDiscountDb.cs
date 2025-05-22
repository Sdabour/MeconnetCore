using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.SystemBase;
using System.Data;
using System.Data.SqlClient;

namespace SharpVision.CRM.CRMDataBase
{
    public class ReservationDiscountDb
    {
        #region Private Data
        int _ID;
        int _ReservationID;
        double _Value;
        string _Reason;
        DateTime _Date;
        bool _Scheduled;
        int _TypeID;
        string _ReservationIDs;

        #region Private Data For Reservation
        protected bool _IsDateRange;
        protected DateTime _DateFrom;
        protected DateTime _DateTo;

        protected bool _IsContractingDateRange;
        protected DateTime _ContractingDateFrom;
        protected DateTime _ContractingDateTo;

        protected int _CellFamilyID;
        protected int _CellID;

        protected double _ValFrom;
        protected double _ValTo;

        protected bool _IsDiscountdateRange;
        protected DateTime _DiscountDateFrom;
        protected DateTime _DiscountDateTo;

        #endregion

        #endregion

        #region Constructors
        public ReservationDiscountDb()
        { 

        }
        public ReservationDiscountDb(int intID)
        {
            _ID = intID;
            DataTable dtTemp = Search();
            DataRow objDR = dtTemp.Rows[0];
            _ReservationID = int.Parse(objDR["ReservationID"].ToString());
            _Reason = objDR["DiscountReason"].ToString();
            _Date = DateTime.Parse(objDR["DiscountDate"].ToString());
            _Value = double.Parse(objDR["DiscountValue"].ToString());
            _Scheduled = bool.Parse(objDR["Scheduled"].ToString());
            _TypeID = int.Parse(objDR["TypeID"].ToString());
        }
        public ReservationDiscountDb(DataRow objDR)
        {
            _ID = int.Parse(objDR["DiscountID"].ToString());
            _ReservationID = int.Parse(objDR["ReservationID"].ToString());
            _Reason = objDR["DiscountReason"].ToString();
            _Date = DateTime.Parse(objDR["DiscountDate"].ToString());
            _Value = double.Parse(objDR["DiscountValue"].ToString());
            _Scheduled = bool.Parse(objDR["Scheduled"].ToString());
            _TypeID = int.Parse(objDR["TypeID"].ToString());


        }
        #endregion

        #region Public Properties
        public DateTime Date
        {
            set
            {
                _Date = value;
            }
            get
            {
                return _Date;
            }

        }
        public string Reason
        {
            set
            {
                _Reason = value;
            }
            get
            {
                return _Reason;
            }

        }
        public double Value
        {
            set
            {
                _Value = value;
            }
            get
            {
                return _Value;
            }

        }

        public int ReservationID
        {
            set
            {
                _ReservationID = value;
            }
            get
            {
                return _ReservationID;
            }

        }
       
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
        public bool Scheduled
        {
            set
            {
                _Scheduled = value;
            }
            get
            {
                return _Scheduled;
            }

        }
        public int TypeID
        {
            set
            {
                _TypeID = value;
            }
            get
            {
                return _TypeID;
            }
        }
        public string ReservationIDs
        {
            set
            {
                _ReservationIDs = value;
            }
            get
            {
                return _ReservationIDs;
            }
        }

        public bool IsDateRange
        {
            set
            {
                _IsDateRange = value;
            }
            get
            {
                return _IsDateRange;
            }
        }
        public DateTime DateFrom
        {
            set
            {
                _DateFrom = value;
            }
        }
        public DateTime DateTo
        {
            set
            {
                _DateTo = value;
            }
        }


        public bool IsContractingDateRange
        {
            set
            {
                _IsContractingDateRange = value;
            }
            get
            {
                return _IsContractingDateRange;
            }
        }
        public DateTime ContractingDateFrom
        {
            set
            {
                _ContractingDateFrom = value;
            }

        }
        public DateTime ContractingDateTo
        {
            set
            {
                _ContractingDateTo = value;
            }

        }
        public int CellFamilyID
        {
            set
            {
                _CellFamilyID = value;
            }
            get
            {
                return _CellFamilyID;
            }
        }
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

        public double ValFrom
        {
            set
            {
                _ValFrom = value;
            }
            get
            {
                return _ValFrom;

            }
        }
        public double ValTo
        {
            set
            {
                _ValTo = value;
            }
            get
            {
                return _ValTo;
            }
        }

        public bool IsDiscountdateRange
        {
            set
            {
                _IsDiscountdateRange = value;
            }
            get
            {
                return _IsDiscountdateRange;
            }
        }
        public DateTime DiscountDateFrom
        {
            set
            {
                _DiscountDateFrom = value;
            }
            get
            {
                return _DiscountDateFrom;
            }
        }
        public DateTime DiscountDateTo
        {
            set
            {
                _DiscountDateTo = value;
            }
            get
            {
                return _DiscountDateTo;
            }
        }

        public string AddStr
        {
            get
            {
                int intScheduled = _Scheduled ? 1 : 0;
                double dblDate = _Date.ToOADate() - 2;
                string Returned = " INSERT INTO CRMReservationDiscount" +
                                " ( ReservationID, DiscountValue, DiscountReason, DiscountDate,Scheduled,TypeID)" +
                                " VALUES     (" + _ReservationID + "," + _Value + ",'" + _Reason + "'," + dblDate + "," + intScheduled + ","+_TypeID+") ";
                return Returned;
            }
        }
        public string EditStr
        {
            get
            {
                
                int intScheduled = _Scheduled ? 1 : 0;
                double dblDate = _Date.ToOADate() - 2;
                string Returned = " UPDATE    CRMReservationDiscount" +
                                " SET  ReservationID =" + _ReservationID + "" +
                                " , DiscountValue =" + _Value + "" +
                                " , Scheduled = " + intScheduled + "" +
                                " , TypeID = "+_TypeID+""+
                                " , DiscountReason ='" + _Reason + "'" +
                                " , DiscountDate =" + dblDate + "" +
                                " WHERE   ReservationID = " + _ReservationID + " and  (DiscountID = " + _ID + ") ";
                return Returned;
            }
          }
        public string DeleteStr
        {
            get
            {

                string Returned = " DELETE FROM CRMReservationDiscount  WHERE  ReservationID  ="+_ReservationID+" and  (DiscountID = " + _ID + ") ";
                return Returned;
            }
        }
        public static string SearchStr
        {
            get
            {

                string Returned = " SELECT     CRMReservationDiscount.DiscountID, CRMReservationDiscount.ReservationID, CRMReservationDiscount.DiscountValue, "+
                                   " CRMReservationDiscount.DiscountReason, CRMReservationDiscount.DiscountDate, CRMReservationDiscount.Scheduled, "+
                                   " CRMReservationDiscount.TypeID,DiscountTypeTable.*"+
                                   " FROM         CRMReservationDiscount LEFT OUTER JOIN"+
                                   " (" + DiscountTypeDb.SearchStr + ") as DiscountTypeTable ON CRMReservationDiscount.TypeID = DiscountTypeTable.DiscountTypeID ";
                return Returned;
            }
        }
        #endregion

        #region Private Methods

        #endregion

        #region Public Methods
        public void Add()
        {
          
            _ID = SysData.SharpVisionBaseDb.InsertIdentityTable(AddStr);

        }
        public void Edit()
        {
            
            SysData.SharpVisionBaseDb.ExecuteNonQuery(EditStr);

        }

        public void Schedul()
        {
            int intSchedul = _Scheduled ? 1 : 0;
            string strSql = "  UPDATE    CRMReservationDiscount"+
                            " SET   Scheduled ="+ _Scheduled + ""+
                            " WHERE     (ReservationID = " + _ReservationID + ") AND (DiscountID = "+_ID+") ";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);

        }

        public void Delete()
        {
            SysData.SharpVisionBaseDb.ExecuteNonQuery(DeleteStr);
        }
        public DataTable Search()
        {

            double dblDateFrom = _DateFrom.ToOADate() - 2;
            int TempStartDate = (int)dblDateFrom;
            double dblDateTimeto = _DateTo.ToOADate() - 2;
            int TempEndDate = (int)dblDateTimeto;

            double dblContractDateFrom = _ContractingDateFrom.ToOADate() - 2;
            int TempContractStartDate = (int)dblDateFrom;
            double dblContractDateTimeto = _ContractingDateTo.ToOADate() - 2;
            int TempContractEndDate = (int)dblDateTimeto;



            double dblDiscountDateFrom = _DiscountDateFrom.ToOADate() - 2;
            int TempDiscountDateFrom = (int)dblDiscountDateFrom;
            double dblDiscountDateTo = _DiscountDateTo.ToOADate() - 2;
            int TempDiscountDateTo = (int)dblDiscountDateTo;


            string strSql = SearchStr + " WHERE    (1=1) ";
            if (_ID != 0)
                strSql = strSql + " and DiscountID = " + _ID.ToString();
            if(_ReservationID != 0)
                strSql = strSql + " and ReservationID = " + _ReservationID.ToString();
            else if(_ReservationIDs != null && _ReservationIDs != "")
                strSql = strSql + " and ReservationID  in (" + _ReservationIDs + ") ";
            if (_TypeID != 0)
                strSql = strSql + " and TypeID = "+_TypeID+" ";
            if (_ValTo != 0 && _ValFrom != 0)
                strSql = strSql + " and  CRMReservationDiscount.DiscountValue >= " + _ValFrom + " and CRMReservationDiscount.DiscountValue <= " + _ValTo + "";
            if (_IsDiscountdateRange)
                strSql = strSql + " and Convert(float,CRMReservationDiscount.DiscountDate) >= " + TempDiscountDateFrom + " and Convert(float,CRMReservationDiscount.DiscountDate) < " + TempDiscountDateTo + " ";

            if (_IsDateRange || _IsContractingDateRange || _CellID != 0 || _CellFamilyID != 0)
            {
                string strReservation = "SELECT     dbo.CRMReservation.ReservationID "+
                     " FROM         dbo.CRMUnitCell INNER JOIN "+
                     " dbo.CRMUnit ON dbo.CRMUnitCell.UnitID = dbo.CRMUnit.UnitID INNER JOIN "+
                     " dbo.RPCell ON dbo.CRMUnitCell.CellID = dbo.RPCell.CellID INNER JOIN "+
                     " dbo.CRMReservation ON dbo.CRMUnit.CurrentReservation = dbo.CRMReservation.ReservationID ";
                strReservation += " where 1= 1 ";
                if (_IsDateRange)
                    strReservation += " and Convert(float,dbo.CRMReservation.ReservationDate) >= " + TempStartDate + " and Convert(float,dbo.CRMReservation.ReservationDate) < " + TempEndDate + "";
                if (_IsContractingDateRange)
                    strReservation += "   and Convert(float,dbo.CRMReservation.ReservationContractingDate) >= " + TempContractStartDate + " and Convert(float,dbo.CRMReservation.ReservationContractingDate) < " + TempContractEndDate + "";
                if (_CellFamilyID != 0)
                    strReservation += " and  dbo.RPCell.CellFamilyID = " + _CellFamilyID + "";
                if (_CellID != 0)
                    strReservation += " and dbo.RPCell.CellID =" + _CellID + " ";
             strSql += " and ReservationID in (" + strReservation + ")";
            }


            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql,"Discount");


        }
        #endregion
    }
}
