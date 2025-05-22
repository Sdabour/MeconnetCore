using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.HR.HRDataBase;
using SharpVision.Base.BaseBusiness;
using System.Data;

namespace SharpVision.HR.HRBusiness
{
    public abstract class SubSectorBiz
    {
        #region PrivateData
        protected SubSectorDb _SubSectorDb;
        protected SectorBiz _SectorBiz;
       
        #endregion
        #region Constractors
        public SubSectorBiz()
        {
            _SubSectorDb = new SubSectorDb();
            _SectorBiz = new SectorBiz();
           
        }
        public SubSectorBiz(int intID)
        {
            _SubSectorDb = new SubSectorDb(intID);
            _SectorBiz = new SectorBiz(_SubSectorDb.SectorID);
            
           
        }
        public SubSectorBiz(DataRow objDR)
        {
            _SubSectorDb = new SubSectorDb(objDR);
            _SectorBiz = new SectorBiz(objDR);

           
            
        }
        #endregion
        #region PublicAccessorice
        public SectorBiz SectorBiz 
        {
            set
            {
                _SectorBiz = value;
            }
            get
            {
                if (_SectorBiz == null)
                    _SectorBiz = new SectorBiz();
                return _SectorBiz;
            }
        }
        public int ID 
        {
            set
            {
                _SubSectorDb.ID = value;
            }
            get
            {
                return _SubSectorDb.ID;
            }
        }
        public string Desc
        {
            set
            {
                _SubSectorDb.Desc = value;
            }
            get
            {
                return _SubSectorDb.Desc;
            }
        }
        public string SectorName
        {
            get
            {
                return SectorBiz.Name;
            }
        }
       
        #endregion
        #region Private Methods
        #endregion
        #region Public Methods
        public abstract void Add();
        public abstract void Edit();
        public abstract void Delete();
        #endregion
    }
}
