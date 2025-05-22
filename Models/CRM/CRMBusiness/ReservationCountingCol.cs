using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.Base.BaseDataBase;
using SharpVision.Base.BaseBusiness;
using SharpVision.CRM.CRMDataBase;
using SharpVision.CRM.CRMBusiness;
using SharpVision.SystemBase;
using SharpVision.RP.RPBusiness;
namespace SharpVision.CRM.CRMBusiness
{
    public class ReservationCountingCol : BaseCol
    {
        #region Private Data

        #endregion

        #region Constructors
        public ReservationCountingCol(bool blIsEmpty)
        {

        }
        public ReservationCountingCol(CellBiz objCellBiz,UnitModelBiz objModelBiz,
            DateTime dtStartDate,DateTime dtEndDate,byte btPeriodType)
        {
            ReservaionCountingDb objDb = new ReservaionCountingDb();
            objDb.PeriodType = btPeriodType;
            objDb.StartDate = dtStartDate;
            objDb.EndDate = dtEndDate;
            objDb.ModelID = objModelBiz.ID;
            if (objCellBiz.ID == objCellBiz.ParentID)
            {
                objDb.CellFamilyID = objCellBiz.ID;
            }
            else
                objDb.CellIDs = objCellBiz.IDsStr;
            DataTable dtTemp = objDb.Search();
            DataRow [] arrDr = dtTemp.Select("", "NO Desc");
            foreach (DataRow objDr in arrDr)
            {
                Add(new ReservationCountingBiz(objDr));
            }

        }
        #endregion

        #region Public Properties
        public virtual ReservationCountingBiz this[int intIndex]
        {
            get
            {
                return (ReservationCountingBiz)this.List[intIndex];
            }
        }


        #endregion

        #region Private Methods

        #endregion

        #region Public Methods
        public virtual void Add(ReservationCountingBiz objCountingBiz)
        {

            this.List.Add(objCountingBiz);
        }

     


        #endregion

    }
}
