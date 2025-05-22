
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Collections;
using Algorithmat.Algorithmat.AlgorithmatDataBase;
namespace Algorithmat.Algorithmat.AlgorithmatBusiness
{
    public class LocationImageCol : CollectionBase
    {
        #region Private Data and Public Properties

        #endregion
        #region Constructors
        public LocationImageCol(bool blIsEmpty)
        {

        }
        public LocationImageCol()
        {
           

        }
        #endregion
        #region Properties
        public LocationImageBiz this[int intIndex]
        {
            get
            {
                return (LocationImageBiz)List[intIndex];
            }
        }
        #endregion
        #region Private Methods

        #endregion
        #region Public Methods
        public void Add(LocationImageBiz objBiz)
        {
            List.Add(objBiz);
        }
        internal static DataColumn[] Columns
        {
            get
            {
                DataColumn[] Returned = new DataColumn[] {new DataColumn("LocationID"),new DataColumn("ImageID")
                    ,new DataColumn("ImageOrder")
                   ,
                new DataColumn("LocationImageTitleA"),new DataColumn("LocationImageTitleE"),new DataColumn("SecondaryLocation")
 };
                return Returned;
            }
        }
        public DataTable GetTable(int intSeondaryLocation)
        {
            DataTable Returned = new DataTable("LocationImageTable");
            Returned.Columns.AddRange(Columns);
            DataRow objDr;
            foreach (LocationImageBiz objBiz in this)
            {
                objDr = objBiz.GetRow(intSeondaryLocation,Returned);

                Returned.Rows.Add(objDr);
            }
            return Returned;
        }
        #endregion
    }
}