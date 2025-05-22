using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq;
using System.Data;

using System.Collections;
using SharpVision.UMS.UMSDataBase;
namespace SharpVision.UMS.UMSBusiness
{
    public class SingleClassCol : CollectionBase
    {
        #region Private Data

        #endregion
        #region Constructors
        public SingleClassCol()
        {

        }
        #endregion
        #region Public Properties
        Hashtable _SingleHs = new Hashtable();
        public Hashtable SingleHs
        {
            get => _SingleHs;


        }
        public SingleClassBiz this[string strIndex]
        {
            get
            {
                SingleClassBiz Returned = new SingleClassBiz();
                if (_SingleHs[strIndex] != null)
                    Returned = (SingleClassBiz)_SingleHs[strIndex];

                return Returned;

            }
        }
        public SingleClassBiz this[int intIndex]
        {
            get
            {
                return (SingleClassBiz)List[intIndex];

            }
        }
        public string IDsStr
        {
            get
            {
                string Returned = "";
                foreach (SingleClassBiz objBiz in this)
                {
                    if (objBiz.ID == 0)
                        continue;
                    if (Returned != "")
                        Returned += ",";
                    Returned += objBiz.ID.ToString();
                }
                return Returned;
            }
        }
        #endregion
        #region Private Methods

        #endregion
        #region Public Methods
        public void Add(SingleClassBiz objBiz)
        {
            if (_SingleHs[objBiz.ID.ToString()] == null)
                _SingleHs.Add(objBiz.ID.ToString(), objBiz);
            List.Add(objBiz);
        }
       
        public SingleClassCol GetCol(string strName)
        {
            SingleClassCol Returned = new SingleClassCol();
            foreach (SingleClassBiz objBiz in this)
            {
                if (objBiz.Name.CheckUmsStr(strName))
                    Returned.Add(objBiz);
            }
            return Returned;
        }
        public DataTable GetTable()
        {
            DataTable Returned = new DataTable();
            Returned.Columns.Add(new DataColumn("ID"));
            DataRow objDr;
            foreach (SingleClassBiz objBiz in this)
            {
                objDr = Returned.NewRow();
                objDr["ID"] = objBiz.ID;
                Returned.Rows.Add(objDr);

            }
            return Returned;

        }
        #endregion
    }
}
