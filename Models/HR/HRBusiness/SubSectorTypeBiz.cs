
using System;
using System.Collections.Generic;
using System.Text;
//using SharpVision.UMS.UMSBusiness;
using SharpVision.HR.HRDataBase;
using SharpVision.Base.BaseBusiness;
using System.Data;
namespace SharpVision.HR.HRBusiness
{
    public class SubSectorTypeBiz : BaseSingleBiz
    {
        #region Private Data



        #endregion
        #region Constructors
        public SubSectorTypeBiz()
        {
            _BaseDb = new SubSectorTypeDb();
        }
        public SubSectorTypeBiz(int intSectorTypeID)
        {
            _BaseDb = new SubSectorTypeDb(intSectorTypeID);
        }
        public SubSectorTypeBiz(DataRow objDR)
        {
            _BaseDb = new SubSectorTypeDb(objDR);
        }

        public SubSectorTypeBiz(SubSectorTypeDb objSectorTypeDb)
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
        public static void Add(string strSubSectorTypeNameA, string strSubSectorTypeNameE)
        {

            SubSectorTypeDb objSubSectorTypeDb = new SubSectorTypeDb();
            objSubSectorTypeDb.NameA = strSubSectorTypeNameA;
            objSubSectorTypeDb.NameE = strSubSectorTypeNameE;

            objSubSectorTypeDb.Add();
        }
        public virtual void Edit()
        {
            _BaseDb.Edit();
        }
        public static void Edit(int intSubSectorTypeID, string strSubSectorTypeNameA, string strSubSectorTypeNameE)
        {
            SubSectorTypeDb objSubSectorTypeDb = new SubSectorTypeDb();
            objSubSectorTypeDb.ID = intSubSectorTypeID;
            objSubSectorTypeDb.NameA = strSubSectorTypeNameA;
            objSubSectorTypeDb.NameE = strSubSectorTypeNameE;

            objSubSectorTypeDb.Edit();
        }
        public virtual void Delete()
        {
            _BaseDb.Delete();
        }
        public static void Delete(int intSubSectorTypeID)
        {
            SubSectorTypeDb objSubSectorTypeDb = new SubSectorTypeDb();
            objSubSectorTypeDb.ID = intSubSectorTypeID;
            objSubSectorTypeDb.Delete();
        }
        public SubSectorTypeBiz Copy()
        {
            SubSectorTypeBiz Returned = new SubSectorTypeBiz();
            Returned.ID = this.ID;
            Returned.NameA = this.NameA;
            Returned.NameE = this.NameE;

            return Returned;
        }
        #endregion
    }
}

