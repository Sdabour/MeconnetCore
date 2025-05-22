using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.COMMON.COMMONDataBase;
using SharpVision.Base.BaseBusiness;

namespace SharpVision.COMMON.COMMONBusiness
{
    public class SupperCodeBiz
    {
        #region Private Data
        SupperCodeDb _SupperCodeDb;
        #endregion
        #region Constructors
        public SupperCodeBiz()
        {
            _SupperCodeDb = new SupperCodeDb();
        }
        public SupperCodeBiz(DataRow objDR)
        {
            _SupperCodeDb = new SupperCodeDb(objDR);
        }
        public SupperCodeBiz(string strCode)
        {
            _SupperCodeDb = new SupperCodeDb(strCode);
        }
        #endregion
        #region Public Properties
        public int ID
        {
            set
            {
                _SupperCodeDb.ID = value;
            }
            get
            {
                return _SupperCodeDb.ID;
            }
        }
        public string Code
        {
            set
            {
                _SupperCodeDb.Code = value;
            }
            get
            {
                return _SupperCodeDb.Code;
            }
        }
        public string Value
        {
            set
            {
                _SupperCodeDb.Value = value;
            }
            get
            {
                return _SupperCodeDb.Value;
            }
        }
        public string Desc
        {
            set
            {
                _SupperCodeDb.Desc = value;
            }
            get
            {
                return _SupperCodeDb.Desc;
            }
        }
        #endregion
        #region Private Methods
        #endregion
        #region Public Methods
        public void Add()
        {
            _SupperCodeDb.Add();
        }
        public void Edit()
        {
            _SupperCodeDb.Edit();
        }
        public void Delete()
        {
            _SupperCodeDb.Delete();
        }
        #endregion
    }
}
