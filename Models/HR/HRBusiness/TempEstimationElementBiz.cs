using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SharpVision.HR.HRDataBase;
using System.Data;

namespace SharpVision.HR.HRBusiness
{
    public class TempEstimationElementBiz
    {

        #region Constructor
        public TempEstimationElementBiz()
        {
            _TempEstimationElementDb = new TempEstimationElementDb();
        }
        public TempEstimationElementBiz(DataRow objDr)
        {
            _TempEstimationElementDb = new TempEstimationElementDb(objDr);
        }

        #endregion
        #region Private Data
        TempEstimationElementDb _TempEstimationElementDb;
        #endregion
        #region Properties
        public int ID
        {
            set
            {
                _TempEstimationElementDb.ID = value;
            }
            get
            {
                return _TempEstimationElementDb.ID;
            }
        }
        public string NameA
        {
            set
            {
                _TempEstimationElementDb.NameA = value;
            }
            get
            {
                return _TempEstimationElementDb.NameA;
            }
        }
        public string NameE
        {
            set
            {
                _TempEstimationElementDb.NameE = value;
            }
            get
            {
                return _TempEstimationElementDb.NameE;
            }
        }
        public int Applicant
        {
            set
            {
                _TempEstimationElementDb.Applicant = value;
            }
            get
            {
                return _TempEstimationElementDb.Applicant;
            }
        }
        public bool IsFuzzy
        {
            set
            {
                _TempEstimationElementDb.IsFuzzy = value;
            }
            get
            {
                return _TempEstimationElementDb.IsFuzzy;
            }
        }
        public double GradeValue
        {
            set
            {
                _TempEstimationElementDb.GradeValue = value;
            }
            get
            {
                return _TempEstimationElementDb.GradeValue;
            }
        }
        #endregion
        #region Private Method

        #endregion
        #region Public Method 
        public void Add()
        {
            _TempEstimationElementDb.Add();
        }
        public void Edit()
        {
            _TempEstimationElementDb.Edit();
        }
        public void Delete()
        {
            _TempEstimationElementDb.Delete();
        }
        #endregion
    }
}