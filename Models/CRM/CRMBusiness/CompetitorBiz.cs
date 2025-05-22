using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.Base.BaseDataBase;
using SharpVision.Base.BaseBusiness;
using SharpVision.CRM.CRMDataBase;
using SharpVision.SystemBase;

namespace SharpVision.CRM.CRMBusiness
{
    public class CompetitorBiz : BaseSingleBiz
    {
        #region Private Data
        CompetitorProejctCol _ProjectCol;
        #endregion

        #region Constractors
        public CompetitorBiz()
        {
            _BaseDb = new CompetitorDb();
        }
        public CompetitorBiz(int intID)
        {
            _BaseDb = new CompetitorDb(intID);
        }
        public CompetitorBiz(DataRow objDR)
        {
            _BaseDb = new CompetitorDb(objDR);
        }
        #endregion

        #region Public Accessorice
        public CompetitorProejctCol ProjectCol
        {
            set
            {
                _ProjectCol = value;
            }
            get
            {
                if (_ProjectCol == null)
                {
                    _ProjectCol = new CompetitorProejctCol(true);
                    if (ID != 0)
                    {
                        DataRow[] arrDr = CompetitorDb.CompetitorProjectCacheTable.Select("CompetitorID=" + ID);
                        foreach (DataRow objDr in arrDr)
                        {
                            _ProjectCol.Add(new CompetitorProejctBiz(objDr));
                        }
                    }
                }
                return _ProjectCol;
            }
        }
        #endregion

        #region Private Methods
        #endregion

        #region Public Methods
        public void Add()
        {
            _BaseDb.Add();
        }
        public void Edit()
        {
            _BaseDb.Edit();
        }
        public void Delete()
        {
            _BaseDb.Delete();
        }
        public static void ResetCacheProject()
        {
            CompetitorDb.CompetitorProjectCacheTable = null;
        }
        #endregion
    }
}
