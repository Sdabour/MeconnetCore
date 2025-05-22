
using System;
using System.Collections.Generic;
using System.Linq;

using System.Data;
using System.Collections;
using SharpVision.CRM.CRMDataBase;
using SharpVision.COMMON.COMMONBusiness;
namespace SharpVision.CRM.CRMBusiness
{
    public class ModelImageCol : CollectionBase
    {
        #region Private Data and Public Properties

        #endregion
        #region Constructors
        public ModelImageCol(bool blIsEmpty)
        {

        }
        public ModelImageCol()
        {


        }
        #endregion
        #region Properties
        public ModelImageBiz this[int intIndex]
        {
            get
            {
                return (ModelImageBiz)List[intIndex];
            }
        }
        #endregion
        #region Private Methods

        #endregion
        #region Public Methods
        public void Add(ModelImageBiz objBiz)
        {
            List.Add(objBiz);
        }
        internal static DataColumn[] Columns
        {
            get
            {
                DataColumn[] Returned = new DataColumn[] {new DataColumn("ModelID"),new DataColumn("ImageID")
                    ,new DataColumn("ImageOrder")
                   ,
                new DataColumn("ModelImageTitleA"),new DataColumn("ModelImageTitleE"),new DataColumn("SecondaryModel")
 };
                return Returned;
            }
        }
     
        public DataTable GetTable()
        {
            DataTable Returned = new DataTable();
            Returned.Columns.AddRange(new DataColumn[] { new DataColumn("ModelID"), new DataColumn("ImageID"), new DataColumn("ImageOrder"), new DataColumn("ModelImageTitleA"), new DataColumn("ModelImageTitleE") });
            DataRow objDr;
            foreach (ModelImageBiz objBiz in this)
            {
                objDr = Returned.NewRow();
                objDr["ModelID"] = objBiz.ModelID;
                objDr["ImageID"] = objBiz.ImageBiz.ID;
                objDr["ImageOrder"] = objBiz.Order;
                objDr["ModelImageTitleA"] = objBiz.TitleA;
                objDr["ModelImageTitleE"] = objBiz.TitleE;
                Returned.Rows.Add(objDr);
            }
            return Returned;
        }


        #endregion
    }
}