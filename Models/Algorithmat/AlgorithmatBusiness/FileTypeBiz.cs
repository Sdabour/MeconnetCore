using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.Base.BaseDataBase;
using SharpVision.Base.BaseBusiness;
using Algorithmat.Algorithmat.AlgorithmatDataBase;
using SharpVision.SystemBase;

namespace Algorithmat.Algorithmat.AlgorithmatBusiness
{
    public class FileTypeBiz : BaseSingleBiz
    {
        #region Private Data

        #endregion
        #region Constractors
        public FileTypeBiz()
        {
            _BaseDb = new FileTypeDb();
        }
        public FileTypeBiz(DataRow objDR)
        {
            _BaseDb = new FileTypeDb(objDR);
        }
        #endregion
        #region Public Accessorice

        #endregion
        #region Private Methods
        #endregion
        #region public Methods
        public void Add()
        {
            //((FileTypeDb)_BaseDb).Code = Code;
            ((FileTypeDb)_BaseDb).Add();
        }
        public void Edit()
        {
            //((FileTypeDb)_BaseDb).Code = Code;
            ((FileTypeDb)_BaseDb).Edit();
        }
        public void Delete()
        {
            ((FileTypeDb)_BaseDb).Delete();
        }
        public FileTypeBiz Copy()
        {
            FileTypeBiz Returned = new FileTypeBiz();
            Returned.ID = ID;
            Returned.Code = Code;
            Returned.NameA = NameA;
            Returned.NameE = NameE;
            return Returned;
        }
        #endregion
    }
}
