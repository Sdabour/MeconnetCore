
using System;
using System.Collections.Generic;
using System.Text;
//using SharpVision.UMS.UMSBusiness;
using SharpVision.HR.HRDataBase;
using SharpVision.Base.BaseBusiness;
using System.Data;
namespace SharpVision.HR.HRBusiness
{
    public class SectorTypeBiz : BaseSingleBiz
    {
        #region Private Data



        #endregion
        #region Constructors
        public SectorTypeBiz()
        {
            _BaseDb = new SectorTypeDb();
        }
        public SectorTypeBiz(int intSectorTypeID)
        {
            _BaseDb = new SectorTypeDb(intSectorTypeID);
        }
        public SectorTypeBiz(DataRow objDR)
        {
            _BaseDb = new SectorTypeDb(objDR);
        }

        public SectorTypeBiz(SectorTypeDb objSectorTypeDb)
        {
            _BaseDb = objSectorTypeDb;
        }
        #endregion
        #region Public Properties

        #endregion
        #region Private Methods

        #endregion
        #region Public Methods
        public virtual void Add()
        {
            _BaseDb.Add();
        }
        public static void Add(string strSectorTypeNameA, string strSectorTypeNameE)
        {

            SectorTypeDb objSectorTypeDb = new SectorTypeDb();
            objSectorTypeDb.NameA = strSectorTypeNameA;
            objSectorTypeDb.NameE = strSectorTypeNameE;

            objSectorTypeDb.Add();
        }
        public virtual void Edit()
        {
            _BaseDb.Edit();
        }
        public static void Edit(int intSectorTypeID, string strSectorTypeNameA, string strSectorTypeNameE)
        {
            SectorTypeDb objSectorTypeDb = new SectorTypeDb();
            objSectorTypeDb.ID = intSectorTypeID;
            objSectorTypeDb.NameA = strSectorTypeNameA;
            objSectorTypeDb.NameE = strSectorTypeNameE;

            objSectorTypeDb.Edit();
        }
        public virtual void Delete()
        {
            _BaseDb.Delete();
        }
        public static void Delete(int intSectorTypeID)
        {
            SectorTypeDb objSectorTypeDb = new SectorTypeDb();
            objSectorTypeDb.ID = intSectorTypeID;
            objSectorTypeDb.Delete();
        }
        public SectorTypeBiz Copy()
        {
            SectorTypeBiz Returned = new SectorTypeBiz();
            Returned.ID = this.ID;
            Returned.NameA = this.NameA;
            Returned.NameE = this.NameE;

            return Returned;
        }
        #endregion
    }
}

