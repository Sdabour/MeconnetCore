using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.HR.HRDataBase;
using SharpVision.Base.BaseBusiness;
using SharpVision.RP.RPBusiness;
using System.Data;

namespace SharpVision.HR.HRBusiness
{
    public class SubSectorCellBiz : SubSectorBiz
    {
        #region PrivateData
        CellBiz _CellBiz;
        #endregion

        #region Constractors
        public SubSectorCellBiz()
        {
            _SubSectorDb = new  SubSectorCellDb();
        }
        public SubSectorCellBiz(int intID)
        {
            _SubSectorDb = new SubSectorCellDb(intID);
        }
        public SubSectorCellBiz(DataRow objDR)
        {
            _SubSectorDb = new SubSectorCellDb(objDR);
            _CellBiz = new CellBiz(((SubSectorCellDb)_SubSectorDb).CellID);
            _SectorBiz = new SectorBiz(objDR);
        }
        #endregion

        #region Public Accessorice
        public CellBiz CellBiz
        {
            set
            {
                _CellBiz = value;
            }
            get
            {
                return _CellBiz;
            }
        }
    
        public int CellID
        {
            set
            {
                ((SubSectorCellDb)_SubSectorDb).CellID = value;
            }
            get
            {
                return ((SubSectorCellDb)_SubSectorDb).CellID;
            }
        }
        public string CellName
        {
           
            get
            {
                return CellBiz.Name;
            }
        }
       
        #endregion

        #region PrivateMethods
        #endregion

        #region PublicMethods
        public override void Add()
        {
            ((SubSectorCellDb)_SubSectorDb).CellID = _CellBiz.ID;
            _SubSectorDb.SectorID = _SectorBiz.ID;
            _SubSectorDb.Add();
        }
        public override void Edit()
        {
            ((SubSectorCellDb)_SubSectorDb).CellID = _CellBiz.ID;
            _SubSectorDb.SectorID = _SectorBiz.ID;
            _SubSectorDb.Edit();
        }
        public override void Delete()
        {
            _SubSectorDb.Delete();
        } 
        #endregion
    }
}
