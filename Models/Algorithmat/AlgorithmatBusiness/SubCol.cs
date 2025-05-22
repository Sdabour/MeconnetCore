using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Collections;
using Algorithmat.Algorithmat.AlgorithmatDataBase;
namespace Algorithmat.Algorithmat.AlgorithmatBusiness
{
    public class SubCol : CollectionBase
    {
        #region Private Data and Public Properties

        #endregion
        #region Constructors
        public SubCol(bool blIsEmpty)
        {

        }
        public SubCol()
        {
            SUBDb objDb = new SUBDb();
            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
                Add(new SubBiz(objDr));

        }
        #endregion
        #region Properties
        public SubBiz this[int intIndex]
        {
            get
            {
                return (SubBiz)List[intIndex];
            }
        }
        #endregion
        #region Private Methods

        #endregion
        #region Public Methods
        public void Add(SubBiz objBiz)
        {
            List.Add(objBiz);
        }
        public string IDs
        {
            get
            {
                string Returned = "";
                foreach (SubBiz objSubBiz in this)
                {
                    if (Returned != "")
                        Returned += ",";
                    Returned += objSubBiz.ID.ToString();
                }
                return Returned;
            }
        }
        internal static DataColumn[] Columns
        {
            get
            {
                DataColumn[] Returned = new DataColumn[] {new DataColumn("SubID"),new DataColumn("SUBContentID")
                    ,new DataColumn("SUBOrder")
                    , new DataColumn("SubDesc"),
                new DataColumn("SubTitleA"),new DataColumn("SubTitleE"),new DataColumn("SubIsChanged",Type.GetType("System.Boolean")),new DataColumn("SecondarySubID"),new DataColumn("SUBHasAnIndex",System.Type.GetType("System.Boolean"))
 };
                return Returned;
            }
        }
        public DataTable GetTable(out DataTable objParagraphTable, out DataTable objImageTable,bool blGetDeleted)
        {
            string strDeleted = blGetDeleted ? "Deleted" : "";
            objImageTable = new DataTable( strDeleted+ ParagraphImageDb.TableName);
            objParagraphTable = new DataTable(strDeleted + ParagraphDb.TableName);
            objParagraphTable.Columns.AddRange(ParagraphCol.Columns);
            DataTable Returned = new DataTable(strDeleted + SUBDb.TableName);
            Returned.Columns.AddRange(Columns);
            DataRow objDr;
            objImageTable.Columns.AddRange(ParagraphImageCol.Columns);
            int intSecondarySub = 0;
            int intSecondaryParagraph = 0;
            foreach (SubBiz objBiz in this)
            {
                intSecondarySub++;
                objDr = Returned.NewRow();
                objDr["SubID"] = objBiz.ID;
                objDr["SubDesc"] = objBiz.Desc;
                objDr["SubTitleA"] = objBiz.TitleA;
                objDr["SubTitleE"] = objBiz.TitleE;
                objDr["SUBOrder"] = objBiz.Order;
                objDr["SUBContentID"] = objBiz.ContentID;
                objDr["SubIsChanged"] = objBiz.IsChanged ? 1 : 0;
                objDr["SecondarySubID"] = intSecondarySub;
                objDr["SUBHasAnIndex"] = objBiz.HasAnIndex;
                foreach (ParagraphBiz objParagraphBiz in objBiz.ParagraphCol)
                {
                    intSecondaryParagraph++;
                    objParagraphTable.Rows.Add(objParagraphBiz.GetRow(intSecondaryParagraph,intSecondarySub,objParagraphTable));
                    foreach (ParagraphImageBiz objImageBiz in objParagraphBiz.ImageCol)
                    {
                        objImageTable.Rows.Add(objImageBiz.GetRow(intSecondaryParagraph,objImageTable));
                    }

                }
                Returned.Rows.Add(objDr);
            }
            return Returned;
        }
        #endregion
    }
}