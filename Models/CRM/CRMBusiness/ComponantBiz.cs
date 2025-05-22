using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.Base.BaseDataBase;
using SharpVision.Base.BaseBusiness;
using SharpVision.CRM.CRMDataBase;
using SharpVision.SystemBase;

namespace SharpVision.CRM.CRMBusiness
{
    public class ComponantBiz : BaseSingleBiz
    {
        #region Private Data
        //ComponantDb _ComponantDb;
        ReservationInstallmentCol _InstallmentCol;
        #endregion
        #region Constructors
        public ComponantBiz()
        {
            _BaseDb = new ComponantDb();
        }
        public ComponantBiz(int intID)
        {
            _BaseDb = new ComponantDb(intID);
        }
        public ComponantBiz(DataRow objDR)
        {
            _BaseDb = new ComponantDb(objDR);
        }

        #endregion
        #region Public Properties
        public ReservationInstallmentCol InstallmentCol
        {
            set
            {
                _InstallmentCol = value;
            }
            get
            {
                return _InstallmentCol;
            }
        }

        #endregion
        #region Private Methods

        #endregion
        #region Public Methods
        public static void Add(string strNameA, string strNameE)
        {
            ComponantDb objComponantDb = new ComponantDb();
            objComponantDb.NameA = strNameA;
            objComponantDb.NameE = strNameE;
            objComponantDb.Add();
        }
        public static void Edit(int intPaymentID, string strNameA, string strNameE)
        {
            ComponantDb objComponantDb = new ComponantDb();
            objComponantDb.ID = intPaymentID;
            objComponantDb.NameA = strNameA;
            objComponantDb.NameE = strNameE;
            objComponantDb.Edit();
        }
        public static void Delete(int intID)
        {
            ComponantDb objComponantDb = new ComponantDb();
            objComponantDb.ID = intID;
            objComponantDb.Delete();
        }
        #endregion
    }
}
