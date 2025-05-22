using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.HR.HRDataBase;
using System.Data;
using SharpVision.Base.BaseBusiness;

namespace SharpVision.HR.HRBusiness
{
    public class ShiftTypeBiz : BaseSingleBiz
    {
        #region Private Data

        #endregion
        #region Constructors
         public ShiftTypeBiz()
        {
            _BaseDb = new ShiftTypeDb();
        }
        public ShiftTypeBiz(int intID)
        {
            _BaseDb = new ShiftTypeDb(intID);
        }
        public ShiftTypeBiz(DataRow objDR)
        {
            _BaseDb = new ShiftTypeDb(objDR);
        }

        public ShiftTypeBiz(ShiftTypeDb objDb)
        {
            _BaseDb = objDb;
        }
        #endregion
        #region Public Properties

        #endregion
        #region Private Methods

        #endregion
        #region Public Methods
        public  void Add()
        {
            ((ShiftTypeDb)_BaseDb).Add();
        }
        public  void Edit()
        {            
            ((ShiftTypeDb)_BaseDb).Edit();
        }
        public  void Delete()
        {
            ((ShiftTypeDb)_BaseDb).Delete();
        }
        public ShiftTypeBiz  Copy()
        {
            ShiftTypeBiz Returned = new ShiftTypeBiz();
            Returned.ID = this.ID;
            Returned.NameA = this.NameA;
            Returned.NameE = this.NameE;            

            return Returned;
        }
        #endregion
    }
}
