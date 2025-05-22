using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.HR.HRDataBase;
using System.Data;
namespace SharpVision.HR.HRBusiness
{
    public class DetailStatementBiz
    {
        #region Private Data
        DetailStatementDb _DetailStatementDb;
        DetailTypeBiz _DetailTypeBiz;
        #endregion
        #region Constructors
        public DetailStatementBiz()
        {
            _DetailStatementDb = new DetailStatementDb();
            _DetailTypeBiz = new DetailTypeBiz();
        }
        public DetailStatementBiz(int intDetailStatementID)
        {
            _DetailStatementDb = new DetailStatementDb(intDetailStatementID);            
            _DetailTypeBiz = new DetailTypeBiz(_DetailStatementDb.DetailStatementBonuisType);
        }
        public DetailStatementBiz(DataRow objDR)
        {
            _DetailStatementDb = new DetailStatementDb(objDR);
            if (objDR["DetailTypeID"].ToString() != "")
                _DetailTypeBiz = new DetailTypeBiz(int.Parse(objDR["DetailTypeID"].ToString()));
            else
                _DetailTypeBiz = new DetailTypeBiz();
        }
        #endregion
        #region Public Properties
        public int DetailStatementID
        {
            set { _DetailStatementDb.DetailStatementID = value; }
            get { return _DetailStatementDb.DetailStatementID; }
        }
        
        public int DetailStatementEstimationStatement
        {
            set { _DetailStatementDb.DetailStatementEstimationStatement = value; }
            get { return _DetailStatementDb.DetailStatementEstimationStatement; }
        }

        public DateTime DetailStatementDate
        {
            set { _DetailStatementDb.DetailStatementDate = value; }
            get { return _DetailStatementDb.DetailStatementDate; }
        }

        public string DetailStatementDesc
        {
            set { _DetailStatementDb.DetailStatementDesc = value; }
            get { return _DetailStatementDb.DetailStatementDesc; }
        }

        public DetailTypeBiz DetailTypeBiz
        {
            set { _DetailTypeBiz = value; }
            get { return _DetailTypeBiz; }
        }

        public bool StatusDelete
        {
            set { _DetailStatementDb.StatusDelete = value; }
            get { return _DetailStatementDb.StatusDelete; }
        }
#endregion
        #region Private Methods

        #endregion
        #region Public Methods
        public void Add()
        {
            _DetailStatementDb.DetailStatementBonuisType = _DetailTypeBiz.ID;
            _DetailStatementDb.Add();
        }
        public void Edit()
        {
            _DetailStatementDb.DetailStatementBonuisType = _DetailTypeBiz.ID;
            _DetailStatementDb.Edit();
        }
        public void Delete()
        {
            _DetailStatementDb.Delete();
        }
        #endregion
    }
}
