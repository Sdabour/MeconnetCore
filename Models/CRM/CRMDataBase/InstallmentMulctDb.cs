using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.UMS.UMSDataBase;
using SharpVision.SystemBase;
using System.Data;
using System.Data.SqlClient;
using SharpVision.Base.BaseDataBase;
using SharpVision.COMMON.COMMONDataBase;

namespace SharpVision.CRM.CRMDataBase
{
    public class InstallmentMulctDb : BaseSingleDb
    {

        #region Private Data
        protected int _InstallmentID;
        protected int _ReservationID;
        protected double _MulctValue;
        protected int _MulctReason;
        protected DateTime _MulctDate;
        protected int _Status;
        protected string _StatusText;

        protected bool _Direction;
        protected int _GLTransaction;
        protected int _GLTransactionStatus;

        #region Private Data For Search
        string _InstallmentIDs;
        string _ReservationIDs;


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

        protected bool _IsMulctdateRange;
        protected DateTime _MulctDateFrom;
        protected DateTime _MulctDateTo;


        #endregion
        #endregion
        #region Constructors
        public InstallmentMulctDb()
        { 

        }
        public InstallmentMulctDb(DataRow objDR)
        {
            SetData(objDR);
        }


        #endregion
        #region Public Properties

        public string StatusText
        {
            set
            {
                _StatusText = value;
            }
            get
            {
                return _StatusText;
            }

        }
        public int Status
        {
            set
            {
                _Status = value;
            }
            get
            {
                return _Status;
            }

        }
        public int InstallmentID
        {
            set
            {
                _InstallmentID = value;
            }
            get
            {
                return _InstallmentID;
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
        public double MulctValue
        {
            set
            {
                _MulctValue = value;
            }
            get
            {
                return _MulctValue;
            }

        }
        public int MulctReason
        {
            set
            {
                _MulctReason = value;
            }
            get
            {
                return _MulctReason;
            }

        }
        public DateTime MulctDate
        {
            set
            {
                _MulctDate = value;
            }
            get
            {
                return _MulctDate;
            }

        }
        public string InstallmentIDs
        {
            set
            {
                _InstallmentIDs = value;
            }
        }
        public string ReservationIDs
        {
            set
            {
                _ReservationIDs = value;
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

        public bool IsMulctdateRange
        {
            set
            {
                _IsMulctdateRange = value;
            }
            get
            {
                return _IsMulctdateRange;
            }
        }
        public DateTime MulctDateFrom
        {
            set
            {
                _MulctDateFrom = value;
            }
            get
            {
                return _MulctDateFrom;
            }
        }
        public DateTime MulctDateTo
        {
            set
            {
                _MulctDateTo = value;
            }
            get
            {
                return _MulctDateTo;
            }
        }

        public bool Direction
        {
            set
            {
                _Direction = value;
            }
            get
            {
                return _Direction;
            }
        }
        public int GLTransaction
        {
            set
            {
                _GLTransaction = value;
            }
            get
            {
                return _GLTransaction;
            }
        }
        public int GLTransactionStatus
        {
            set
            {
                _GLTransactionStatus = value;   
            }
           
        }





        public static string SearchStr
        {
            get
            {
                string Returned = " SELECT MulctID,CRMInstallmentMulct.InstallmentID,CRMInstallmentMulct.ReservationID,MulctValue, MulctReason" +
                    ", MulctDate,MulctStatusText,MulctStatus,MulctReasonTable.*,CRMInstallmentMulct.ReservationID " +
                    " FROM    CRMInstallmentMulct  left outer  join (" + MulctReasonDb.SearchStr + ") as MulctReasonTable " +
                    " on  CRMInstallmentMulct.MulctReason = MulctReasonTable.ReasonID  ";
                //" inner join dbo.CRMReservationInstallment " +
                //" on CRMInstallmentMulct.InstallmentID = dbo.CRMReservationInstallment.InstallmentID ";

                return Returned;
            }
        }
        #endregion
        #region Private Methods
        void SetData(DataRow objDR)
        {
            _ID = int.Parse(objDR["MulctID"].ToString());
            _InstallmentID = int.Parse(objDR["InstallmentID"].ToString());
            if(objDR["ReservationID"].ToString()!= "")
                _ReservationID = int.Parse(objDR["ReservationID"].ToString());
            _MulctValue = double.Parse(objDR["MulctValue"].ToString());
            _MulctReason = int.Parse(objDR["MulctReason"].ToString());
            _MulctDate = DateTime.Parse(objDR["MulctDate"].ToString());
            _Status = int.Parse(objDR["MulctStatus"].ToString());
            _StatusText = objDR["MulctStatusText"].ToString();
        }


        #endregion
        #region Public Methods

        public override void Add()
        {
            double Date = _MulctDate.ToOADate() - 2;
            string strSql = " INSERT INTO CRMInstallmentMulct (InstallmentID,ReservationID, MulctValue, MulctReason, MulctDate)" +
                            " VALUES     (" + _InstallmentID + "," + _ReservationID + "," + _MulctValue + "," + _MulctReason + "," + Date + ")";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }

        public override void Edit()
        {
            string strSql = " UPDATE    CRMInstallmentMulct" +
                                "SET  InstallmentID =" + _InstallmentID + "" +
                                ",ReservationID="+_ReservationID + 
                                ", MulctValue =" + _MulctValue + "" +
                                ", MulctReason =" + _MulctReason + "" +
                                ", MulctDate = " + _MulctDate + "" +
                            " where InstallmentID =" + _InstallmentID + " And MulctID = " + _ID + "";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }

        public void EditStatus()
        {
            string strSql = "  UPDATE    CRMInstallmentMulct" +
                            " SET  MulctStatus =" + _Status + "" +
                            ", MulctStatusText ='" + _StatusText + "'" +
                            " where InstallmentID =" + _InstallmentID + " And MulctID = "+_ID+"";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }

        public override DataTable Search()
        {



            double dblDateFrom = _DateFrom.ToOADate() - 2;
            int TempStartDate = (int)dblDateFrom;
            double dblDateTimeto = _DateTo.ToOADate() - 2;
            int TempEndDate = (int)dblDateTimeto;

            double dblContractDateFrom = _ContractingDateFrom.ToOADate() - 2;
            int TempContractStartDate = (int)dblDateFrom;
            double dblContractDateTimeto = _ContractingDateTo.ToOADate() - 2;
            int TempContractEndDate = (int)dblDateTimeto;



            double dblMulctDateFrom = _MulctDateFrom.ToOADate() - 2;
            int TempMulctDateFrom = (int)dblMulctDateFrom;
            double dblMulctDateTo = _MulctDateTo.ToOADate() - 2;
            int TempMulctDateTo = (int)dblMulctDateTo;


            string strSql = SearchStr + " WHERE    (1 = 1)";
            if (_InstallmentID != 0)
                strSql = strSql + " and InstallmentID = " + _InstallmentID.ToString();
            if (_InstallmentIDs != null && _InstallmentIDs != "")
            {
                strSql = strSql + " and InstallmentID in (" + _InstallmentIDs + ")";
 
            }
            if (_ReservationIDs != null && _ReservationIDs != "")
            {
                strSql = strSql + " and dbo.CRMInstallmentMulct.ReservationID in  (" + _ReservationIDs + ")";
                    //"(SELECT  InstallmentID  FROM  dbo.CRMReservationInstallment where ReservationID in("+
                    //_ReservationIDs+"))";
            }
            if (_IsDateRange || _IsContractingDateRange || _CellID != 0 || _CellFamilyID != 0)
            {
                string strReservation = "SELECT     dbo.CRMReservation.ReservationID " +
                     " FROM         dbo.CRMUnitCell INNER JOIN " +
                     " dbo.CRMUnit ON dbo.CRMUnitCell.UnitID = dbo.CRMUnit.UnitID INNER JOIN " +
                     " dbo.RPCell ON dbo.CRMUnitCell.CellID = dbo.RPCell.CellID INNER JOIN " +
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
                //if (_IsMulctdateRange)
                //    strReservation += "  and Convert(float,dbo.CRMReservation.ReservationContractingDate) >= " + TempContractStartDate + " and Convert(float,dbo.CRMReservation.ReservationContractingDate) < " + TempContractEndDate + "";
                strSql += " and ReservationID in (" + strReservation + ")";
            }

            if (_GLTransactionStatus != 0)
            {
                if (_GLTransactionStatus == 1)
                {
                    strSql += " and CRMInstallmentMulct.MulctGLTransaction > 0 ";
                }
                else if (_GLTransactionStatus == 2)
                {
                    strSql += " and (CRMInstallmentMulct.MulctGLTransaction = 0)";
                }
            }


            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql,"InstallmentMulctTable");
        }

        public override void Delete()
        {
            string strSql = " delete from    CRMInstallmentMulct" +
                        " where InstallmentID =" + _InstallmentID + " And MulctID = " + _ID + "";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }

        #endregion

    }
}
