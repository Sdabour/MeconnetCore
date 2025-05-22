using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
namespace SharpVision.CRM.CRMDataBase
{
    public class ReservationCessionedDb : ReservationDb
    {
        #region Private Data
        ReservationCessioinDb _CessionDb;
        #endregion
        #region Constructors
        public ReservationCessionedDb()
        { 
        }
        public ReservationCessionedDb(DataRow objDr)
            : base(objDr)
        {
 
        }
        #endregion
        #region Public Properties
        public ReservationCessioinDb CessionDb
        {
            set
            {
                _CessionDb = value;
            }
            get
            {
                return _CessionDb;
            }
        }
        #endregion
        #region Private Methods

        #endregion
        #region Public Methods

        #endregion
    }
}
