using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.HR.HRDataBase;
using System.Data;
using SharpVision.COMMON.COMMONBusiness;
using SharpVision.UMS.UMSBusiness;
using SharpVision.Base.BaseBusiness;
using SharpVision.RP.RPBusiness;

namespace SharpVision.HR.HRBusiness
{
    public class SubSectorCellCol : BaseCol
    {
         public SubSectorCellCol()
        {
            SubSectorCellDb objSubSectorCellDb = new SubSectorCellDb();
            DataTable dtSubSectorCell = objSubSectorCellDb.Search();
            SubSectorCellBiz objSubSectorCellBiz;
            foreach (DataRow objDr in dtSubSectorCell.Rows)
            {
                objSubSectorCellBiz = new SubSectorCellBiz(objDr);
                


                this.Add(objSubSectorCellBiz);
            }
        }
        public SubSectorCellCol(SectorBiz _SectorBiz,CellBiz _CellBiz)
        {
            SubSectorCellDb objSubSectorCellDb = new SubSectorCellDb();
            if(_SectorBiz != null && _SectorBiz.ID != 0)
                objSubSectorCellDb.SectorID = _SectorBiz.ID;
            DataTable dtSubSectorCell = objSubSectorCellDb.Search();
            SubSectorCellBiz objSubSectorCellBiz;
            foreach (DataRow objDr in dtSubSectorCell.Rows)
            {
                objSubSectorCellBiz = new SubSectorCellBiz(objDr);
                this.Add(objSubSectorCellBiz);
            }
        }
         public SubSectorCellCol(bool blIsempty)
        {

        }
        public SubSectorCellCol(int intID)
        {
            SubSectorCellDb objDb = new SubSectorCellDb();
            objDb.ID = intID;
            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
            {
                Add(new SubSectorCellBiz(objDr));
            }
        }



        public SubSectorCellBiz this[int intIndex]
        {

            get
            {
                return (SubSectorCellBiz)List[intIndex];
            }
        }

        public void Add(SubSectorCellBiz objBiz)
        {
            List.Add(objBiz);

        }
    }
}
