using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.UMS.UMSBusiness;
using SharpVision.CRM.CRMDataBase;
using System.Data;
using SharpVision.RP.RPBusiness;
using SharpVision.Base.BaseBusiness;

namespace SharpVision.CRM.CRMBusiness
{
    public class MulctReasonBiz
    {
        #region Private Data
        MulctReasonDb _MulctReasonDb;
        #endregion

        #region Constructors
        public MulctReasonBiz()
        {
            _MulctReasonDb = new MulctReasonDb();
        }
        public MulctReasonBiz(int intID)
        {
            _MulctReasonDb = new MulctReasonDb(intID);
        }
        public MulctReasonBiz(DataRow objDR)
        {
            _MulctReasonDb = new MulctReasonDb(objDR);
        }
        #endregion

        #region Public Properties
        public int ID
        {
            set
            {
                _MulctReasonDb.ID = value;
            }
            get
            {
                return _MulctReasonDb.ID;
            }

        }
        public string Desc
        {
            set
            {
                _MulctReasonDb.Desc = value;
            }
            get
            {
                return _MulctReasonDb.Desc;
            }

        }
        #endregion

        #region Private Methods

        #endregion

        #region Public Methods
        public void Add(string strDesc)
        {
            MulctReasonDb objMulctReasonDb = new MulctReasonDb();
            objMulctReasonDb.Desc = strDesc;
            objMulctReasonDb.Add();
        }
        public void Edit(int intID, string strDesc)
        {
            MulctReasonDb objMulctReasonDb = new MulctReasonDb();
            objMulctReasonDb.Desc = strDesc;
            objMulctReasonDb.ID = intID;
            objMulctReasonDb.Edit();
        }
        public void Delete(int intID)
        {
            MulctReasonDb objMulctReasonDb = new MulctReasonDb();
            objMulctReasonDb.ID = intID;
            objMulctReasonDb.Delete();
        }
        #endregion
    }
}
