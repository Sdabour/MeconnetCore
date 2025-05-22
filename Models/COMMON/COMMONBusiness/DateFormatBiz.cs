using System;
using System.Collections.Generic;
using System.Text;
//using SharpVision.UMS.UMSBusiness;
using SharpVision.COMMON.COMMONDataBase;
using SharpVision.Base.BaseBusiness;
using System.Data;
namespace SharpVision.COMMON.COMMONBusiness
{
    public class DateFormatBiz
    {
        #region Private Data
        DateFormatDb _FormatDb;
        #endregion
        #region Constructors
        public DateFormatBiz()
        {
            _FormatDb = new DateFormatDb();
        }
        public DateFormatBiz(DataRow objDr)
        {
            _FormatDb = new DateFormatDb(objDr);
        }
        #endregion
        #region Public Properties
        public int ID
        {
            set
            {
                _FormatDb.ID = value;
            }
            get
            {
                return _FormatDb.ID;
            }
        }
        public string Format
        {
            set
            {
                _FormatDb.Format = value;
            }
            get
            {
                return _FormatDb.Format;
            }
        }
        public string Name
        {
            set
            {
                _FormatDb.Name = value;
            }
            get
            {
                return _FormatDb.Name;
            }
        }
        public string ExtraOne
        {
            set
            {
                _FormatDb.ExtraOne = value;
            }
            get
            {
                return _FormatDb.ExtraOne;
            }
        }
        public string ExtraTwo
        {
            set
            {
                _FormatDb.ExtraTwo = value;
            }
            get
            {
                return _FormatDb.ExtraTwo;
            }
        }
        #endregion
        #region Private Methods

        #endregion
        #region Public Methods

        #endregion
    }
}
