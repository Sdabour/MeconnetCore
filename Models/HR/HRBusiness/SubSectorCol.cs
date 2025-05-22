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
    public class SubSectorCol : BaseCol
    {
        BranchBiz _BranchBiz;
        public SubSectorCol()
        {
            //BranchBiz ObjBranchBiz
            //_BranchBiz = new BranchBiz();
            //_BranchBiz = ObjBranchBiz;
            SubSectorDb objSubSectorDb = new SubSectorDb();
            DataTable dtSubSector = objSubSectorDb.Search();
            
            FillCol(dtSubSector);
        }



        #region Old Code
        //public SubSectorCol(SectorBiz _SectorBiz,BranchBiz _BranchBiz)
        //{
        //  SubSectorDb objSubSectorDb = new SubSectorDb();
        //  //if(_BranchBiz != null && _BranchBiz.ID != 0)
        //  //    objSubSectorDb.BranchID = _BranchBiz.ID;
        //    if(_SectorBiz != null && _SectorBiz.ID != 0)
        //        objSubSectorDb.SectorID = _SectorBiz.ID;
        //  DataTable dtSubSector = objSubSectorDb.Search();
        //    FillCol(dtSubSector);

        //    #region OldCode
        //    ////SubSectorDb objSubSectorDb = new SubSectorDb();
        //    //////if(_BranchBiz != null && _BranchBiz.ID != 0)
        //    //////  objSubSectorDb.BranchID = _BranchBiz.ID;
        //    ////if(_SectorBiz != null && _SectorBiz.ID != 0)
        //    ////    objSubSectorDb.SectorID = _SectorBiz.ID;
        //    ////DataTable dtSubSector = objSubSectorDb.Search();
        //    ////SubSectorBiz objSubSectorBiz;
        //    ////foreach (DataRow objDr in dtSubSector.Rows)
        //    ////{
        //    ////    objSubSectorBiz = new SubSectorBranchBiz(objDr);
        //    ////    this.Add(objSubSectorBiz);
        //    ////}
        //    #endregion
        //}
        #endregion

        public SubSectorCol(bool blIsempty)
         {

         }
        public SubSectorCol(int intID)
        {
            SubSectorDb objDb = new SubSectorDb();
            objDb.ID = intID;
            DataTable dtTemp = objDb.Search();
            
            foreach (DataRow objDr in dtTemp.Rows)
            {
                Add(new SubSectorBranchBiz(objDr));
            }
        }
        public SubSectorCol(string strIDs)
        {
            SubSectorDb objDb = new SubSectorDb();
            objDb.SubSectorIDs = strIDs;
            DataTable dtTemp = objDb.Search();

            foreach (DataRow objDr in dtTemp.Rows)
            {
                Add(new SubSectorBranchBiz(objDr));
            }
        }

        public SubSectorCol(int intSectorID,int intBranchID,int intCellID)
        {
            SubSectorDb objDb = new SubSectorDb();
            objDb.SectorID = intSectorID;
            objDb.BranchID = intBranchID;
            objDb.CellID = intCellID;
            DataTable dtTemp = objDb.Search();
            
            FillCol(dtTemp);
            //foreach (DataRow objDr in dtTemp.Rows)
            //{
            //    Add(new SubSectorBranchBiz(objDr));
            //}
        }
        public SubSectorCol(string strName,int intSectorID, int intBranchID, int intCellID)
        {
            SubSectorDb objDb = new SubSectorDb();
            objDb.SectorID = intSectorID;
            objDb.BranchID = intBranchID;
            objDb.CellID = intCellID;
            objDb.SectorNameSearch = strName;
            DataTable dtTemp = objDb.Search();

            FillCol(dtTemp);
            //foreach (DataRow objDr in dtTemp.Rows)
            //{
            //    Add(new SubSectorBranchBiz(objDr));
            //}
        }


        public SubSectorBiz this[int intIndex]
        {

            get
            {
                return (SubSectorBiz)List[intIndex];
            }
        }

        #region Private Methods
         void FillCol(DataTable dtSubSector)
        {
            SubSectorBiz objSubSectorBiz;
            foreach (DataRow DR in dtSubSector.Rows)
            {
                if (DR["BranchID"].ToString() == "" || DR["BranchID"].ToString() == "0")
                    objSubSectorBiz = new SubSectorCellBiz(DR);
                else                    
                objSubSectorBiz = new SubSectorBranchBiz(DR);

                this.Add(objSubSectorBiz);
            }
        }
            
        public void Add(SubSectorBiz objBiz)
        {
            List.Add(objBiz);


        }
        public int GetIndex(int intID)
        {
            int intIndex = 0;
            foreach (SubSectorBiz objBiz in this)
            {
                if (objBiz.ID == intID)
                {
                    return intIndex;
                }
                intIndex++;
            }
            return -1;
        }
        #endregion

    }
}
