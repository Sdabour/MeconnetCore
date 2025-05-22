using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.CRM.CRMDataBase;
using SharpVision.RP.RPBusiness;
using SharpVision.SystemBase;
using System.Collections;
namespace SharpVision.CRM.CRMBusiness
{
    public class ReservationCessionCol : CollectionBase
    {
        #region Private Data

        #endregion
        #region Constructors
        public ReservationCessionCol()
        {
 
        }
        public ReservationCessionCol(bool blIsEmpty)
        { 

        }
        public ReservationCessionCol(int intNewReservationStatus,CellBiz objCellBiz,string strUnitCode, bool blIsDateRange,
            DateTime dtStartDate, 
            DateTime dtEndDate)
        {
            ReservationCessioinDb objDb = new ReservationCessioinDb();
            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
            {
                Add(new ReservationCessionBiz(objDr));
            }

        }
        #endregion
        #region Public Properties
        public ReservationCessionBiz this[int intIndex]
        {
            get
            {
                return (ReservationCessionBiz)List[intIndex];
            }
        }
        #endregion
        #region Private Methods

        #endregion
        #region Public Methods
        public void Add(ReservationCessionBiz objBiz)
        {
            List.Add(objBiz);
        }
        #endregion
    }
}
