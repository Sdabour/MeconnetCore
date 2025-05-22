using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.HR.HRDataBase;
using SharpVision.Base.BaseBusiness;
using System.Data;

namespace SharpVision.HR.HRBusiness
{
    public class SubSectorBranchBiz : SubSectorBiz
    {
        #region PrivateData
        protected BranchBiz _BranchBiz;
        
        #endregion

        #region Constractors
        public SubSectorBranchBiz()
        {
            _SubSectorDb = new  SubSectorBranchDb();
        }
        public SubSectorBranchBiz(int intID)
        {
            _SubSectorDb = new SubSectorBranchDb(intID);
           // _SubSectorAdminBiz = new ApplicantWorkerBiz(_SubSectorDb.SubSectorAdmin);
        }
        public SubSectorBranchBiz(DataRow objDR)
        {
            try
            {
            _SubSectorDb = new SubSectorBranchDb(objDR);
            _BranchBiz = new BranchBiz(objDR);
            _SectorBiz = new SectorBiz(objDR);

            
            }
            catch (Exception Ex)
            {                
             
            }
           
        }
        #endregion

        #region Public Accessorice
        public BranchBiz BranchBiz
        {
            set
            {
                _BranchBiz = value;
            }
            get
            {
                if (_BranchBiz == null)
                    _BranchBiz = new BranchBiz();
                return _BranchBiz;
            }
        }
        public string BranchName
        {
            get
            {
                if (_BranchBiz == null)
                    _BranchBiz = new BranchBiz();
                return _BranchBiz.Name;
            }
        }
        public int BranchID
        {
            set
            {
                ((SubSectorBranchDb)_SubSectorDb).BranchID = value;
            }
            get
            {
                return ((SubSectorBranchDb)_SubSectorDb).BranchID;
            }
        }
        
        public int SubSectorAdmin
        {
            set
            {
                _SubSectorDb.SubSectorAdmin = value;
            }
            get
            {
                return _SubSectorDb.SubSectorAdmin;
            }
        }        
#endregion

        #region PrivateMethods
        #endregion

        #region PublicMethods
        public override void Add()
        {
            ((SubSectorBranchDb)_SubSectorDb).BranchID = _BranchBiz.ID;
            _SubSectorDb.SectorID = _SectorBiz.ID;
            
            _SubSectorDb.Add();
        }
        public override void Edit()
        {
            ((SubSectorBranchDb)_SubSectorDb).BranchID = _BranchBiz.ID;
            _SubSectorDb.SectorID = _SectorBiz.ID;
            
            _SubSectorDb.Edit();
        }
        public override void Delete()
        {
            ((SubSectorBranchDb)_SubSectorDb).BranchID = _BranchBiz.ID;
            _SubSectorDb.SectorID = _SectorBiz.ID;
            _SubSectorDb.Delete();
        } 
        #endregion
    }
}
