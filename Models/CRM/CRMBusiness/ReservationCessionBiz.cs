using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.CRM.CRMDataBase;
using SharpVision.SystemBase;
namespace SharpVision.CRM.CRMBusiness
{
    public class ReservationCessionBiz
    {
        #region Private Data
        ReservationCessioinDb _CessionDb;
        ReservationBiz _OldReservationBiz;
        ReservationBiz _NewReservationBiz;

        #endregion
        #region Constructors
        public ReservationCessionBiz()
        {
            _CessionDb = new ReservationCessioinDb();
        }
        public ReservationCessionBiz(DataRow objDr)
        {
            _CessionDb = new ReservationCessioinDb(objDr);
        }
        #endregion
        #region Public Properties
        public ReservationBiz OldReservationBiz
        {
            set
            {
                _OldReservationBiz = value;
            }
            get 
            {
                if (_OldReservationBiz == null)
                {
                    if (ReservationDb.CachOldReservationTable != null)
                    {
                        DataRow[] arrDr =
                            ReservationDb.CachOldReservationTable.Select("ReservationID=" +
                            _CessionDb.OldReservationID.ToString());
                        if (arrDr.Length > 0)
                            _OldReservationBiz = new ReservationBiz(arrDr[0]);
                        else
                            _OldReservationBiz = new ReservationBiz();

                    }
                    else
                        _OldReservationBiz = new ReservationBiz();
                }
                return _OldReservationBiz;
            }
        }
        public ReservationBiz NewReservationBiz
        {
            set 
            {
                _NewReservationBiz = value;
            }
            get 
            {
                return _NewReservationBiz;
            }
        }
        public double Cost
        {
            set 
            {
                _CessionDb.CessionCost = value;
            }
            get
            {
                return _CessionDb.CessionCost;
            }
        }
        public DateTime Date
        {
            set
            {
                _CessionDb.CessionDate = value;

            }
            get
            {
                return _CessionDb.CessionDate;
            }
        }
        public string UnitFullName
        {
            get
            {
                return _CessionDb.UnitFullName;
            }
        }
        public string NewCustomerFullName
        {
            get
            {
                return _CessionDb.NewReservationCustomerName;
            }
        }
        public string OldCustoerFullName
        {
            get
            {
                return _CessionDb.OldReservationCustomerName;
            }
        }
        public double RemainingValue
        {
            get
            {
                double Returned = 0;
                Returned = _NewReservationBiz.VirtualRemainingValue + Cost;
                return Returned;
            }
        }

        #endregion
        #region Private Methods

        #endregion
        #region Public Methods
        public void Add()
        {
            if (_OldReservationBiz.ParentID== 0)
                _NewReservationBiz.UnitCol.EditReservation(new ReservationBiz());
            else
            {
                _NewReservationBiz.ParentID = _OldReservationBiz.ParentID;
                ReservationUnitDb objTempDb = new ReservationUnitDb();
                objTempDb.ChildReservation = 0;
                objTempDb.ReservationID = _OldReservationBiz.ParentID;
                objTempDb.UnitIDs = _NewReservationBiz.UnitCol.UnitIDsStr;
                objTempDb.EditChildReservation();
 
            }

         
            if (Cost > 0)
            {
                ReservationBonusBiz objTempBiz = new ReservationBonusBiz();
                objTempBiz.ReservationBiz = NewReservationBiz;
                objTempBiz.Value = Cost;
                objTempBiz.Reason = "مصاريف تنازل";
                objTempBiz.Date = Date;
                objTempBiz.TypeBiz = new BonusTypeBiz();
                objTempBiz.TypeBiz.ID = 6;
                _NewReservationBiz.BonusCol.Add(objTempBiz);
            }
            _NewReservationBiz.Add();
            _OldReservationBiz.EditStatus(ReservationStatus.Cession);
            _CessionDb.NewReservationID = _NewReservationBiz.ID;
            _CessionDb.OldReservationID = _OldReservationBiz.ID;
            _CessionDb.OldReservationPreviousPaidValue = _NewReservationBiz.PreviousPaidValue;
            _CessionDb.Add();
        }
        #endregion
    }
}
