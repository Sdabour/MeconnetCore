using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.UMS.UMSDataBase;
using SharpVision.SystemBase;
using System.Data;
using System.Data.SqlClient;
using SharpVision.Base.BaseDataBase;
using SharpVision.COMMON.COMMONDataBase;

namespace SharpVision.CRM.CRMDataBase
{

    public class ReservationUserLogDb
    {
        ///
        /// this class to Show The Log File For Users In the CRM Projects
        ///

        #region Private Data
        protected string _UnitFullName;
        protected string _CustomerFullName;
        protected int _Status;
        protected DateTime _ReservationDate;
        protected DateTime _ContractingDate;
        protected DateTime _TimeIns;
        protected string _UserInsert;
        protected int _UserID;
        #endregion


        #region Constractors
        #endregion

        #region Public Accessorice
        public string UnitFullName
        {
            set
            {
                _UnitFullName = value;
            }
            get
            {
                return _UnitFullName;
            }
        }
        public string CustomerFullName
        {
            set
            {
                _CustomerFullName = value;
            }
            get
            {
                return _CustomerFullName;
            }
        }
        public string UserInsert
        {
            set
            {
                _UserInsert = value;
            }
            get
            {
                return _UserInsert;
            }
        }
        public int Status
        {
            set
            {
                _Status = value;
            }
            get
            {
                return _Status;
            }
        }
        public DateTime ReservationDate
        {
            set
            {
                _ReservationDate = value;
            }
            get
            {
                return _ReservationDate;
            }
        }
        //public DateTime 
        #endregion

        #region PrivateMethods
        #endregion

        #region Public Methods
        #endregion




    }
}
