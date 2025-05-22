using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.HR.HRDataBase;
using System.Data;
using SharpVision.Base.BaseBusiness;

namespace SharpVision.HR.HRBusiness
{
    public class ShiftBiz : BaseSingleBiz
    {
        #region Private Data
        ShiftTypeBiz _ShiftTypeBiz;
        #endregion
        #region Constructors
         public ShiftBiz()
        {
            _BaseDb = new ShiftDb();
            _ShiftTypeBiz = new ShiftTypeBiz();
        }
        public ShiftBiz(int intID)
        {
            _BaseDb = new ShiftDb(intID);
            _ShiftTypeBiz = new ShiftTypeBiz(((ShiftDb)_BaseDb).ShiftType);
        }
        public ShiftBiz(DataRow objDR)
        {
            _BaseDb = new ShiftDb(objDR);
            _ShiftTypeBiz = new ShiftTypeBiz(objDR);
        }

        public ShiftBiz(ShiftDb objDb)
        {
            _BaseDb = objDb;
            _ShiftTypeBiz = new ShiftTypeBiz(((ShiftDb)_BaseDb).ShiftType);
        }
        #endregion
        #region Public Properties
        public DateTime TimeIn
        {
            set { ((ShiftDb)_BaseDb).TimeIn = value; }
            get { return ((ShiftDb)_BaseDb).TimeIn; }
        }
        public DateTime TimeOut
        {
            set { ((ShiftDb)_BaseDb).TimeOut = value; }
            get { return ((ShiftDb)_BaseDb).TimeOut; }
        }
        public ShiftTypeBiz ShiftTypeBiz
        {
            set { _ShiftTypeBiz = value; }
            get { return _ShiftTypeBiz; }
        }
        public bool IsStop
        {
            set { ((ShiftDb)_BaseDb).IsStop = value; }
            get { return ((ShiftDb)_BaseDb).IsStop; }
        }
        #endregion
        #region Private Methods

        #endregion
        #region Public Methods
        public  void Add()
        {
            ((ShiftDb)_BaseDb).ShiftType = _ShiftTypeBiz.ID;
            ((ShiftDb)_BaseDb).Add();
        }
        public  void Edit()
        {
            ((ShiftDb)_BaseDb).ShiftType = _ShiftTypeBiz.ID;
            ((ShiftDb)_BaseDb).Edit();
        }
        public  void Delete()
        {
            ((ShiftDb)_BaseDb).Delete();
        }
        public ShiftBiz  Copy()
        {
            ShiftBiz Returned = new ShiftBiz();
            Returned.ID = this.ID;
            Returned.NameA = this.NameA;
            Returned.NameE = this.NameE;
            Returned.TimeIn = this.TimeIn;
            Returned.TimeOut = this.TimeOut;
            Returned.ShiftTypeBiz = this.ShiftTypeBiz;

            return Returned;
        }
        #endregion
    }
}
