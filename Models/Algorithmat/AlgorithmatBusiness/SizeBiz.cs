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
    public class SizeBiz : BaseSingleBiz
    {
        #region Private Data

        #endregion
        #region Constractors
        public SizeBiz()
        {
            _BaseDb = new SizeDb();
        }
        public SizeBiz(DataRow objDR)
        {
            _BaseDb = new SizeDb(objDR);
        }
        #endregion
        #region Public Accessorice
        public int Width
        {
            get { return ((SizeDb)_BaseDb).Width; }
            set { ((SizeDb)_BaseDb).Width = value; }
        }
        

        public int Length
        {
            get { return ((SizeDb)_BaseDb).Length; }
            set { ((SizeDb)_BaseDb).Length = value; }
        }
        #endregion
        #region Private Methods
        #endregion
        #region public Methods
        public void Add()
        {
            //((SizeDb)_BaseDb).Code = Code;
            ((SizeDb)_BaseDb).Add();
        }
        public void Edit()
        {
            //((SizeDb)_BaseDb).Code = Code;
            ((SizeDb)_BaseDb).Edit();
        }
        public void Delete()
        {
            ((SizeDb)_BaseDb).Delete();
        }
        public SizeBiz Copy()
        {
            SizeBiz Returned = new SizeBiz();
            Returned.ID = ID;
            Returned.Code = Code;
            Returned.NameA = NameA;
            Returned.NameE = NameE;
            Returned.Length = Length;
            Returned.Width = Width;
            return Returned;
        }
        #endregion
    }
}
