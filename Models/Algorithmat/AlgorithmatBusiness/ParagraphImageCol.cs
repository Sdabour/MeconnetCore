
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Collections;
using Algorithmat.Algorithmat.AlgorithmatDataBase;
namespace Algorithmat.Algorithmat.AlgorithmatBusiness
{
    public class ParagraphImageCol : CollectionBase
    {
        #region Private Data and Public Properties

        #endregion
        #region Constructors
        public ParagraphImageCol(bool blIsEmpty)
        {

        }
        public ParagraphImageCol()
        {


        }
        #endregion
        #region Properties
        public ParagraphImageBiz this[int intIndex]
        {
            get
            {
                return (ParagraphImageBiz)List[intIndex];
            }
        }
        #endregion
        #region Private Methods

        #endregion
        #region Public Methods
        public void Add(ParagraphImageBiz objBiz)
        {
            List.Add(objBiz);
        }
        internal static DataColumn[] Columns
        {
            get
            {
                DataColumn[] Returned = new DataColumn[] {new DataColumn("ParagraphID"),new DataColumn("ImageID")
                    ,new DataColumn("ImageOrder")
                   ,
                new DataColumn("ParagraphImageTitleA"),new DataColumn("ParagraphImageTitleE"),new DataColumn("SecondaryParagraph")
 };
                return Returned;
            }
        }
        public DataTable GetTable(int intSeondaryParagraph)
        {
            DataTable Returned = new DataTable("ParagraphImageTable");
            Returned.Columns.AddRange(Columns);
            DataRow objDr;
            foreach (ParagraphImageBiz objBiz in this)
            {
                objDr = objBiz.GetRow(intSeondaryParagraph, Returned);

                Returned.Rows.Add(objDr);
            }
            return Returned;
        }
        #endregion
    }
}