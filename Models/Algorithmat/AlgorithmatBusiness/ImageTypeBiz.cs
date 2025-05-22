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
    public class ImageTypeBiz : BaseSingleBiz
    {
        #region Private Data

        #endregion
        #region Constractors
        public ImageTypeBiz()
        {
            _BaseDb = new ImageTypeDb();
        }
        public ImageTypeBiz(DataRow objDR)
        {
            _BaseDb = new ImageTypeDb(objDR);
        }
        #endregion
        #region Public Accessorice

        #endregion
        #region Private Methods
        #endregion
        #region public Methods
        public void Add()
        {
            //((ImageTypeDb)_BaseDb).Code = Code;
            ((ImageTypeDb)_BaseDb).Add();
        }
        public void Edit()
        {
            //((ImageTypeDb)_BaseDb).Code = Code;
            ((ImageTypeDb)_BaseDb).Edit();
        }
        public void Delete()
        {
            ((ImageTypeDb)_BaseDb).Delete();
        }
        public ImageTypeBiz Copy()
        {
            ImageTypeBiz Returned = new ImageTypeBiz();
            Returned.ID = ID;
            Returned.Code = Code;
            Returned.NameA = NameA;
            Returned.NameE = NameE;
            return Returned;
        }
        #endregion
    }
}
