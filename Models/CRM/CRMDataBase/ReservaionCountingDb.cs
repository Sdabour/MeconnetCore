using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.SystemBase;
namespace SharpVision.CRM.CRMDataBase
{
    public class ReservaionCountingDb
    {
        #region Private Data
        int _CellfamilyID;
        string _CellIDs;
        int _ModelID;
        DateTime _StartDate;
        DateTime _EndDate;
        int _No;
        byte _PeriodType;//0 day
                                    //1 month
      
        string _DateStr;
        #endregion
        #region Constructors
        public ReservaionCountingDb(DataRow objDr)
        {
            _No = int.Parse(objDr["No"].ToString());
            _DateStr = objDr["DateStr"].ToString();
        }
        public ReservaionCountingDb()
        {
        
        }
        #endregion
        #region Public Properties
        public byte PeriodType
        {
            set
            {
                _PeriodType = value;
            }
        }

        public int CellFamilyID
        {
            set
            {
                _CellfamilyID = value;
            }
        }
        public string CellIDs
        {
            set
            {
                _CellIDs = value;
            }
        }
        public int ModelID
        {
            set
            {
                _ModelID = value;
            }
        }
        public DateTime StartDate
        {
            set
            {
                _StartDate = value;
            }
        }
        public DateTime EndDate
        {
            set
            {
                _EndDate = value;
            }
        }
        public string DateStr
        {
            get
            {
                return _DateStr;
            }
        }
        public int No
        {
            get
            {
                return _No;
            }
        }
        public  string SearchStr
        {
            get
            {
                string strDate = " CONVERT(varchar(10), dbo.CRMReservation.ReservationDate, 102) ";
                if(_PeriodType == 1)
                  strDate = "CONVERT(varchar(7), dbo.CRMReservation.ReservationDate, 102)";
                string Returned = "SELECT     TOP 100 PERCENT "+ strDate +" AS DateStr, COUNT(*) AS No " +
                                            " FROM         dbo.CRMReservation INNER JOIN CRMReservationUnit  " +
                                            " on CRMReservationUnit.ReservationID = CRMReservation.ReservationID "+
                                           " inner join  dbo.CRMUnit ON dbo.CRMReservationUnit.UnitID = dbo.CRMUnit.UnitID INNER JOIN " +
                                           " dbo.CRMUnitCell ON dbo.CRMUnit.UnitID = dbo.CRMUnitCell.UnitID INNER JOIN " +
                                           " dbo.RPCell ON dbo.CRMUnitCell.CellID = dbo.RPCell.CellID " +
                                           " WHERE     (1=1) and CRMReservation.ReservationStatus not in (5,6)  ";
                string strWhere = "";
                if (_ModelID != 0)
                {
                    strWhere = strWhere + " and CRMUnit.UnitModel=" + _ModelID;
                }
                if (_CellfamilyID != 0)
                    strWhere = strWhere + " and RPCell.CellFamilyID=" + _CellfamilyID;
                if (_CellIDs != null && _CellIDs != "")
                    strWhere = strWhere + " and CRMUnitCell.CellID in(" + _CellIDs + ") ";
                {
                    int intStartDate = (int)(_StartDate.ToOADate() - 2);
                    int intEndDate = (int)(_EndDate.ToOADate() - 2)+1;
                    strWhere = strWhere + " and convert(float,CRMReservation.ReservationDate) >= " + intStartDate +
                        " and convert(float,CRMReservation.ReservationDate) <" + intEndDate + " ";
                }
                string strGroup = "  GROUP BY  " + strDate +
                                           " ORDER BY  " + strDate;
                Returned = Returned + strWhere + strGroup;
                return Returned;
            }
        }
        #endregion
        #region Private Methods

        #endregion
        #region Public Methods
        public DataTable Search()
        {
            DataTable Returned = SysData.SharpVisionBaseDb.ReturnDatatable(SearchStr);
            return Returned;
        }
        #endregion
    }
}
