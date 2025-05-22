
using System;
using System.Collections.Generic;
using System.Text;
//using SharpVision.UMS.UMSBusiness;
using SharpVision.HR.HRDataBase;
using SharpVision.Base.BaseBusiness;
using System.Data;
namespace SharpVision.HR.HRBusiness
{
    public class BranchTypeBiz : BaseSingleBiz
    {
        #region Private Data
       

       
        #endregion
        #region Constructors
        public BranchTypeBiz()
        {
            _BaseDb = new BranchTypeDb();
        }
        public BranchTypeBiz(int intBranchTypeID)
        {
            _BaseDb = new BranchTypeDb(intBranchTypeID);
        }
        public BranchTypeBiz(DataRow objDR)
        {
            _BaseDb = new BranchTypeDb(objDR);
        }

        public BranchTypeBiz(BranchTypeDb objBranchTypeDb)
        {
            _BaseDb = objBranchTypeDb;
        }
        #endregion
        #region Public Properties
    
        #endregion
        #region Private Methods

        #endregion
        #region Public Methods
        public static void Add(string strBranchTypeNameA,string strBranchTypeNameE)
        {

            BranchTypeDb objBranchTypeDb = new BranchTypeDb();
            objBranchTypeDb.NameA = strBranchTypeNameA;
            objBranchTypeDb.NameE = strBranchTypeNameE;

            objBranchTypeDb.Add();
        }
        public static void Edit(int intBranchTypeID, string strBranchTypeNameA, string strBranchTypeNameE)
        {
            BranchTypeDb objBranchTypeDb = new BranchTypeDb();
            objBranchTypeDb.ID = intBranchTypeID;
            objBranchTypeDb.NameA = strBranchTypeNameA;
            objBranchTypeDb.NameE = strBranchTypeNameE;

            objBranchTypeDb.Edit();
        }
        public static void Delete(int intBranchTypeID)
        {
            BranchTypeDb objBranchTypeDb = new BranchTypeDb();
            objBranchTypeDb.ID = intBranchTypeID;
            objBranchTypeDb.Delete();
        }
        public BranchTypeBiz Copy()
        {
            BranchTypeBiz Returned = new BranchTypeBiz();
            Returned.ID = this.ID;
            Returned.NameA = this.NameA;
            Returned.NameE = this.NameE;

            return Returned;
        }
        #endregion
    }
}

