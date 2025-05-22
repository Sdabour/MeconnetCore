using System;
using System.Collections.Generic;
using System.Text;
//using SharpVision.UMS.UMSBusiness;
using SharpVision.COMMON.COMMONDataBase;
using System.Data;
namespace SharpVision.COMMON.COMMONBusiness
{
    public class IDTypeBiz
    {
        #region Private Data
        protected IDTypeDb _IDTypeDb;

       
        #endregion
        #region Constructors
        public IDTypeBiz()
        {
            _IDTypeDb = new IDTypeDb();
        }
        public IDTypeBiz(int intIDTypeID)
        {
            _IDTypeDb = new IDTypeDb(intIDTypeID);
        }
        public IDTypeBiz(DataRow objDR)
        {
            _IDTypeDb = new IDTypeDb(objDR);
        }

        public IDTypeBiz(IDTypeDb objIDTypeDb)
        {
            _IDTypeDb = objIDTypeDb;
        }
        #endregion
        #region Public Properties
        public string Name
        {
            set
            {
                _IDTypeDb.NameA = value;
            }
            get
            {
                return _IDTypeDb.NameA;
            }
        }
        public int ID
        {
            set
            {
                _IDTypeDb.ID = value;
            }
            get
            {
                return _IDTypeDb.ID;
            }
        }
        #endregion
        #region Private Methods

        #endregion
        #region Public Methods
        public static void Add(string strIDTypeName)
        {

            IDTypeDb objIDTypeDb = new IDTypeDb();
            objIDTypeDb.NameA = strIDTypeName;

            objIDTypeDb.Add();
        }
        public static void Edit(int intIDTypeID, string strIDTypeName)
        {
            IDTypeDb objIDTypeDb = new IDTypeDb();
            objIDTypeDb.ID = intIDTypeID;
            objIDTypeDb.NameA = strIDTypeName;

            objIDTypeDb.Edit();
        }
        public static void Delete(int intIDTypeID)
        {
            IDTypeDb objIDTypeDb = new IDTypeDb();
            objIDTypeDb.ID = intIDTypeID;
            objIDTypeDb.Delete();
        }
        public IDTypeBiz Copy()
        {
            IDTypeBiz Returned = new IDTypeBiz();
            Returned.ID = this.ID;
            Returned.Name = this.Name;

            return Returned;
        }
        #endregion
    }
}
