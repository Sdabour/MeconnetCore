using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.Base.BaseDataBase;
using SharpVision.Base.BaseBusiness;
using SharpVision.GL.GLDataBase;
using SharpVision.SystemBase;
using SharpVision.COMMON.COMMONBusiness;
namespace SharpVision.GL.GLBusiness
{
    public class CheckInBiz :CheckBiz 
    {
        #region Private Data
        CheckInDb _CheckInDb;
        BankBiz _Bank;
      
        #endregion
        #region Constructors
        public CheckInBiz()
        {
            _CheckInDb = new CheckInDb();
        }
        public CheckInBiz(int intID)
        {
            _CheckInDb = new CheckInDb(intID);
        }
        public CheckInBiz(DataRow objDR)
        {
            _CheckInDb = new CheckInDb(objDR);
        }
        #endregion

        #region Public Properties
        public int ID
        {
            set
            {
                _CheckInDb.ID = value;
            }
            get
            {
                return _CheckInDb.ID;
            }
        }
        public DateTime EntryDate
        {
            set
            {
                _CheckInDb.EntryDate = value;
            }
            get
            {
                return _CheckInDb.EntryDate;
            }
        }
        public BankBiz InBankBiz
        {
            set
            {
                _Bank = value;
            }
            get
            {
                return _Bank;
            }
        }
        #endregion

        #region Private Methods

        #endregion

        #region Public Methods
        public void Add()
        {
            _CheckInDb.BankID = InBankBiz.ID;
            _CheckInDb.Add();

        }
        public void Edit()
        {
            _CheckInDb.BankID = InBankBiz.ID;
            _CheckInDb.Edit();

        }
        public void Delete()
        {
            _CheckInDb.Delete();
        }
        #endregion
    }
}
