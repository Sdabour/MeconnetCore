using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.GL.GLDataBase;
namespace SharpVision.CRM.CRMDataBase
{
    public class TransactionElementReservationDb :TransactionElementDb
    {
        #region Private data
        int _ReservationID;
        int _ReservationCellFamilyID;
        string _ReservationCellIDs;


        #endregion
        #region Contrcuctors
        public TransactionElementReservationDb()
            : base()
        { }
        public TransactionElementReservationDb(DataRow objDr)
            : base(objDr)
        { }

        #endregion
        #region Public Properties
        public int ReservationID
        {
            set
            {
                _ReservationID = value;
            }
        }
        public int ReservationCellFamilyID
        {
            set
            {
                _ReservationCellFamilyID = value;
            }
        }
        public string ReservationCellIDs
        {
            set
            {
                _ReservationCellIDs = value;
            }
        }
        public override string SearchStr
        {
            get
            {
                ReservationDb objDb = new ReservationDb();
                objDb.CellFamilyID = _ReservationCellFamilyID;
                objDb.CellIDs = _ReservationCellIDs;
                objDb.ID = _ReservationID;
                string Returned = "select BaseTable.*,CustomerTable.CustomerFullName"+
                    ",UnitTable.UnitFullName,UnitTable.ProjectName,UnitTable.TowerName,UnitTable.UnitSurvey  " +
                    " from ("+ base.SearchStr +") as BaseTable "+
                    " inner join  CRMReservation on BaseTable.ElementReservation = CRMReservation.ReservationID "+
                    " inner join ("+ objDb.CustomerSearchStr +") as CustomerTable "+
                    " on CRMReservation.ReservationID = CustomerTable.ReservationID " +
                    " inner join ("+ objDb.UnitSearchStr +") as UnitTable "+
                    " on CRMReservation.ReservationID = UnitTable.CurrentReservation  where (1=1) ";
                if (_ReservationID != 0)
                    Returned += " and CRMReservation.ReservationID="+ _ReservationID;
                return Returned;
            }
        }
        #endregion
    }
}
