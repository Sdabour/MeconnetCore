using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Collections;
using Algorithmat.Algorithmat.AlgorithmatDataBase;
namespace Algorithmat.Algorithmat.AlgorithmatBusiness
{
    public class ParagraphCol : CollectionBase
    {
        #region Private Data and Public Properties

        #endregion
        #region Constructors
        public ParagraphCol(bool blIsEmpty)
        {

        }
        public ParagraphCol()
        {
            //ParagraphDb objDb = new ParagraphDb();
            //DataTable dtTemp = objDb.Search();
            //foreach (DataRow objDr in dtTemp.Rows)
            //    Add(new ParagraphBiz(objDr));

        }
        #endregion
        #region Properties
        public ParagraphBiz this[int intIndex]
        {
            get
            {
                return (ParagraphBiz)List[intIndex];
            }
        }
        #endregion
        #region Private Methods

        #endregion
        #region Public Methods
        public void Add(ParagraphBiz objBiz)
        {
            List.Add(objBiz);
        }
        public void Add(ParagraphCol objCol)
        {
            foreach (ParagraphBiz objBiz in objCol)
                Add(objBiz);
        }
        internal static DataColumn[] Columns
        {
            get
            {
                DataColumn[] Returned = new DataColumn[] {new DataColumn("ParagraphID"),new DataColumn("PARAGRAPHSUBID")
                    ,new DataColumn("ParagraphOrder")
                   ,new DataColumn("ContentID"),
                new DataColumn("ParagraphTextA"),new DataColumn("ParagraphTextE"),
                new DataColumn("ParagraphInnerHTMLA"),new DataColumn("ParagraphInnerHTMLE"),new DataColumn("ParagraphTitleA"),new DataColumn("ParagraphTitleE"),new DataColumn("ParagraphIsChanged",Type.GetType("System.Boolean")),new DataColumn("SecondarySub")
                ,new DataColumn("SecondaryParagraph"),new DataColumn("PARAGRAPHIsCodePiece",
                    Type.GetType("System.Boolean")),new DataColumn("PARAGRAPHFile")
 };
                return Returned;
            }
        }
        public DataTable GetTable()
        {
            DataTable Returned = new DataTable("ParagraphTable");
            Returned.Columns.AddRange(Columns);
            DataRow objDr;
            foreach (ParagraphBiz objBiz in this)
            {
                objDr = objBiz.GetRow(0,0,Returned);

                Returned.Rows.Add(objDr);
            }
            return Returned;
        }
        #endregion
    }
}