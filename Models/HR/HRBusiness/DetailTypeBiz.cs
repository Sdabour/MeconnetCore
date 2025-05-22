
using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.HR.HRDataBase;
using SharpVision.Base.BaseBusiness;
using System.Data;
namespace SharpVision.HR.HRBusiness
{
    public class DetailTypeBiz : BaseSingleBiz
    {
        #region Private Data
              
        #endregion
        #region Constructors
        public DetailTypeBiz()
        {
            _BaseDb = new DetailTypeDb();
        }
        public DetailTypeBiz(int intDetailTypeID)
        {
            _BaseDb = new DetailTypeDb(intDetailTypeID);
        }
        public DetailTypeBiz(DataRow objDR)
        {
            _BaseDb = new DetailTypeDb(objDR);
        }

        public DetailTypeBiz(DetailTypeDb objDetailTypeDb)
        {
            _BaseDb = objDetailTypeDb;
        }
        #endregion
        #region Public Properties
        public bool DetailTypeEstimationEffect
        {
            set { ((DetailTypeDb)_BaseDb).DetailTypeEstimationEffect = value; }
            get { return ((DetailTypeDb)_BaseDb).DetailTypeEstimationEffect; }            
        }
        #endregion
        #region Private Methods

        #endregion
        #region Public Methods
        public static void Add(string strDetailTypeNameA, string strDetailTypeNameE, bool blDetailTypeEstimationEffect)
        {

            DetailTypeDb objDetailTypeDb = new DetailTypeDb();
            objDetailTypeDb.NameA = strDetailTypeNameA;
            objDetailTypeDb.NameE = strDetailTypeNameE;
            objDetailTypeDb.DetailTypeEstimationEffect = blDetailTypeEstimationEffect;

            objDetailTypeDb.Add();
        }
        public static void Edit(int intDetailTypeID, string strDetailTypeNameA, string strDetailTypeNameE, bool blDetailTypeEstimationEffect)
        {
            DetailTypeDb objDetailTypeDb = new DetailTypeDb();
            objDetailTypeDb.ID = intDetailTypeID;
            objDetailTypeDb.NameA = strDetailTypeNameA;
            objDetailTypeDb.NameE = strDetailTypeNameE;
            objDetailTypeDb.DetailTypeEstimationEffect = blDetailTypeEstimationEffect;
            objDetailTypeDb.Edit();
        }
        public static void Delete(int intDetailTypeID)
        {
            DetailTypeDb objDetailTypeDb = new DetailTypeDb();
            objDetailTypeDb.ID = intDetailTypeID;
            objDetailTypeDb.Delete();
        }
        public void Add()
        {
            _BaseDb.Add();
        }
        public void Edit()
        {
            _BaseDb.Edit();
        }
        public void Delete()
        {
            _BaseDb.Delete();
        }
        public DetailTypeBiz Copy()
        {
            DetailTypeBiz Returned = new DetailTypeBiz();
            Returned.ID = this.ID;
            Returned.NameA = this.NameA;
            Returned.NameE = this.NameE;

            return Returned;
        }
        #endregion
    }
}

