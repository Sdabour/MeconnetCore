using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.COMMON.COMMONDataBase;
using SharpVision.Base.BaseBusiness;
namespace SharpVision.COMMON.COMMONBusiness
{
    public class TitleBiz : BaseSingleBiz
    {
        #region Private Data


        #endregion
        #region Constructors
        public TitleBiz()
        {
            _BaseDb = new TitleDb();
        }
        public TitleBiz(int intTitleID)
        {
            _BaseDb = new TitleDb(intTitleID);

        }
        public TitleBiz(DataRow objDR)
        {
            _BaseDb = new TitleDb(objDR);

        }
        public TitleBiz(TitleDb objTitleDb)
        {
            _BaseDb = objTitleDb;
        }

        #endregion
        #region Public Properties

        #endregion
        #region Public Methods

        public static void Add(string strNameA, string strNameE)
        {
            TitleDb objTitleDb = new TitleDb();
            objTitleDb.NameA = strNameA;
            objTitleDb.NameE = strNameE;
            objTitleDb.Add();

        }
        public static void Edit(int intTitleID, string strNameA, string strNameE)
        {
            TitleDb objTitleDb = new TitleDb();
            objTitleDb.ID = intTitleID;
            objTitleDb.NameA = strNameA;
            objTitleDb.NameE = strNameE;
            objTitleDb.Edit();

        }
        public static void Delete(int intTitleID)
        {
            TitleDb objTitleDb = new TitleDb();
            objTitleDb.ID = intTitleID;
            objTitleDb.Delete();
        }
        public TitleBiz Copy()
        {
            TitleBiz Returned = new TitleBiz();
            Returned.ID = this.ID;
            Returned.NameA = this.NameA;
            Returned.NameE = this.NameE;

            return Returned;
        }
        #endregion
    }
}
