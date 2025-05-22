using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.GL.GLDataBase;
using SharpVision.Base.BaseBusiness;
using SharpVision.Base.BaseDataBase;
using SharpVision.UMS.UMSBusiness;
using SharpVision.COMMON.COMMONBusiness;
using System.Data;

namespace SharpVision.GL.GLBusiness
{
    public class JournalTypeBiz : BaseSingleBiz
    {
        #region Private Data
        static JournalTypeCol _JournalTypeCol;
        #endregion

        #region Constractors
        public JournalTypeBiz()
        {
            _BaseDb = new JournalTypeDb();
        }
        public JournalTypeBiz(DataRow objDR)
        {
            _BaseDb = new JournalTypeDb(objDR);
        }

        #endregion

        #region Public Accessorice
        public string Code
        {
            set
            {
                ((JournalTypeDb)_BaseDb).Code = value;
            }
            get
            {
                return ((JournalTypeDb)_BaseDb).Code;
            }
        }
        public static JournalTypeCol JournalTypeCol
        {
            get
            {
                if (_JournalTypeCol == null)
                    _JournalTypeCol = new JournalTypeCol(false);
                return _JournalTypeCol;
            }
        }
        #endregion

        #region Private Methods
        #endregion

        #region Public Methods
        public void Add()
        {
            ((JournalTypeDb)_BaseDb).Add();
        }
        public void Edit()
        {
            ((JournalTypeDb)_BaseDb).Edit();
        }
        public void Delete()
        {
            ((JournalTypeDb)_BaseDb).Delete();
        }
        #endregion
    }
}
