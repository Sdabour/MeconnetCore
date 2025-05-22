
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Collections;
using Algorithmat.Algorithmat.AlgorithmatDataBase;
namespace Algorithmat.Algorithmat.AlgorithmatBusiness
{
    public class PageImageCol : CollectionBase
    {
        #region Private Data and Public Properties

        #endregion
        #region Constructors
        public PageImageCol(bool blIsEmpty)
        {

        }
        public PageImageCol()
        {


        }
        #endregion
        #region Properties
        public PageImageBiz this[int intIndex]
        {
            get
            {
                return (PageImageBiz)List[intIndex];
            }
        }
        #endregion
        #region Private Methods

        #endregion
        #region Public Methods
        public void Add(PageImageBiz objBiz)
        {
            List.Add(objBiz);
        }
        internal static DataColumn[] Columns
        {
            get
            {
                DataColumn[] Returned = new DataColumn[] {new DataColumn("PageID"),new DataColumn("ImageID")
                    ,new DataColumn("ImageOrder")
                   ,
                new DataColumn("PageImageTitleA"),new DataColumn("PageImageTitleE"),new DataColumn("SecondaryPage")
 };
                return Returned;
            }
        }
        public DataTable GetTable()
        {
            DataTable Returned = new DataTable(PageImageDb.TableName);
            Returned.Columns.AddRange(Columns);
            DataRow objDr;
            foreach (PageImageBiz objBiz in this)
            {
                objDr = objBiz.GetRow( Returned);

                Returned.Rows.Add(objDr);
            }
            return Returned;
        }
        #endregion
    }
}