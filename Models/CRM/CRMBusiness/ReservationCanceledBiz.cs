using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.Base.BaseDataBase;
using SharpVision.Base.BaseBusiness;
using SharpVision.CRM.CRMDataBase;
using SharpVision.SystemBase;
using SharpVision.RP.RPBusiness;
using SharpVision.HR.HRBusiness;
using SharpVision.GL.GLBusiness;
namespace SharpVision.CRM.CRMBusiness
{
    public class ReservationCanceledBiz : ReservationBiz
    {

        #region Private Data
        //ReservationCanceledDb _ReservationCanceledDb;
        //ReservationCancelationBiz _CancelationBiz;
        //ReservationPayBackCol _PayBackCol;
        #endregion

        #region Constractors
        public ReservationCanceledBiz() : base()
        {
            CancelationBiz = new ReservationCancelationBiz();
        }
        public ReservationCanceledBiz(DataRow objDR) : base(objDR)
        {
            CancelationBiz = new ReservationCancelationBiz(objDR);
        }
        public ReservationCanceledBiz(int intID)
        {
            DataRow[] arrDr = ReservationDb.CachReservationTable.Select("ReservationID=" + intID);
            if (arrDr.Length > 0)
            {
              
                 _ReservationDb = new ReservationDb(arrDr[0]);
                CancelationBiz = new ReservationCancelationBiz(arrDr[0]);
                ReservationDb.ReservationIDs = intID.ToString();
                ReservationDb.SetReservationCach();

            }
            else
            {
                ReservationDb objReservationDb = new ReservationDb();
                objReservationDb.ID = intID;
                DataTable dtTemp = objReservationDb.Search();
                DataRow[] arrDr1 = dtTemp.Select();
                if (arrDr1.Length > 0)
                {
                    _ReservationDb = new ReservationDb(arrDr1[0]);
                    CancelationBiz = new ReservationCancelationBiz(arrDr1[0]);
                }
            }
            if (_ReservationDb.ID != 0)
            {
                //_StrategyBiz = new StrategyBiz(_ReservationDb.StrategyDb);
                //_CustomerBiz = new CustomerBiz(_ReservationDb.CustomerDb);
              //  _StrategyBiz = new StrategyBiz(_ReservationDb.StrategyDb);

                _BranchBiz = new BranchBiz(_ReservationDb.BranchDb);
                if (_ReservationDb.GLLeafAccount != 0)
                    _LeafAccountBiz = new AccountBiz(arrDr[0]);
                else
                    _LeafAccountBiz = new AccountBiz();
            }
        }
        #endregion

        #region Public Accessorice
    
        //public ReservationCancelationBiz CancelationBiz
        //{
        //    set 
        //    {
        //        _CancelationBiz = value;
        //    }
        //    get 
        //    {
                
        //        return _CancelationBiz;
        //    }
        //}
        public double AvailableValue
        {
            get
            {
                if (CancelationBiz == null)
                    CancelationBiz = new ReservationCancelationBiz();
                double Returned = 0;
                double dblTotalValue = TotalPaidValue;
                dblTotalValue -= CancelationBiz.Cost;
                //if (dblTotalValue < PayBackCol.TotalValue)
                Returned = dblTotalValue - PayBackCol.TotalValue;
                return Returned;
            }
        }
        public ReservationPayBackCol PayBackCol
        {
            set
            {
                _PayBackCol = value;
            }
            get
            {
                if (_PayBackCol == null)
                {
                    _PayBackCol = new ReservationPayBackCol(true);
                    if (Status == ReservationStatus.Cancellation)
                    {

                        if (ID != 0)
                        {
                            ReservationPayBackDb objDb = new ReservationPayBackDb();
                            objDb.ReservationID = ID;
                            DataTable dtTemp = objDb.Search();
                            ReservationPayBackBiz objBiz;
                            foreach (DataRow objDr in dtTemp.Rows)
                            {
                                objBiz = new ReservationPayBackBiz(objDr);
                                objBiz.ReservationBiz = this;
                                _PayBackCol.Add(objBiz);
                            }
                        }
                    }
                }
                return _PayBackCol;
            }
        }
        #endregion

        #region Private Methods
        #endregion

        #region Public Methods
        #endregion
    }
}
