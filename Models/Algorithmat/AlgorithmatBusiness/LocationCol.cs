using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Collections;
using Algorithmat.Algorithmat.AlgorithmatDataBase;
namespace Algorithmat.Algorithmat.AlgorithmatBusiness
{
    public class LocationCol : CollectionBase
    {
        #region Private Data and Public Properties
        Hashtable _LocationHs = new Hashtable();
        #endregion
        #region Constructors
        public LocationCol(bool blIsEmpty)
        {

        }
        public LocationCol()
        {
            //LocationDb objDb = new LocationDb();
            //DataTable dtTemp = objDb.Search();
            //foreach (DataRow objDr in dtTemp.Rows)
            //    Add(new LocationBiz(objDr));

        }
        #endregion
        #region Properties
        public LocationBiz this[int intIndex]
        {
            get
            {
                return (LocationBiz)List[intIndex];
            }
        }
        #endregion
        #region Private Methods

        #endregion
        #region Public Methods
        public void Add(LocationBiz objBiz)
        {
            List.Add(objBiz);
            if (_LocationHs[objBiz.Order.ToString()] == null)
                _LocationHs.Add(objBiz.Order.ToString(), objBiz);
        }
        public LocationBiz GetLocationBizByOrder(int intOrder)
        {
            LocationBiz Returned = new LocationBiz();
            if (_LocationHs[intOrder.ToString()] != null)
                Returned = (LocationBiz)_LocationHs[intOrder.ToString()];
            return Returned;
        }
        internal DataColumn[] Columns
        {
            get
            {
                DataColumn[] Returned = new DataColumn[] {new DataColumn("LocationID"), new DataColumn("LocationPageID"),
                new DataColumn("LocationOrder"),new DataColumn("LocationDesc"),new DataColumn("LocationTitleA"),
                new DataColumn("LocationTitleE"),new DataColumn("LocationTitle1A"),
                new DataColumn("LocationTitle1E"),new DataColumn("LocationDisplayPage"),new DataColumn("LocationLinkA")
                ,new DataColumn("LocationLinkE")
                ,new DataColumn("LocationChanged",Type.GetType("System.Boolean")),new DataColumn("LocationContent"),new DataColumn("SecondaryLocation")
 };
                return Returned;
            }
        }
        public DataTable GetTable(out DataTable dtImage,bool blGetDeleted)
        {
            dtImage = new DataTable(LocationImageDb.TableName);
            string strDeleted = blGetDeleted ? "Deleted" : "";
            dtImage.Columns.AddRange(LocationImageCol.Columns);
            DataTable Returned = new DataTable(strDeleted+ LocationDb.TableName);
            Returned.Columns.AddRange(Columns);
            DataRow objDr;
            DataRow objImageDr;
            int intSecondaryLocation = 0;
            foreach (LocationBiz objBiz in this)
            {
                intSecondaryLocation++;
                objDr = Returned.NewRow();
                objDr["LocationID"] = objBiz.ID;
                objDr["LocationPageID"] = objBiz.PageID;
                objDr["LocationOrder"] = objBiz.Order;
                objDr["LocationDisplayPage"] = objBiz.DisplayPage;
                objDr["LocationDesc"] = objBiz.Desc;
                objDr["LocationTitleA"] = objBiz.TitleA;
                objDr["LocationTitleE"] = objBiz.TitleE;
                objDr["LocationTitle1A"] = objBiz.Title1A;
                objDr["LocationTitle1E"] = objBiz.Title1E;
                objDr["LocationChanged"] = objBiz.IsChanged ;
                objDr["LocationLinkE"] = objBiz.LinkE;
                objDr["LocationLinkA"] = objBiz.LinkA;
                objDr["LocationContent"] = objBiz.ContentBiz.ID;
                objDr["SecondaryLocation"] = intSecondaryLocation;
                foreach (LocationImageBiz objImageBiz in objBiz.ImageCol)
                {
                    objImageDr = objImageBiz.GetRow(intSecondaryLocation, dtImage);
                    dtImage.Rows.Add(objImageDr);
                }
                Returned.Rows.Add(objDr);
            }
            return Returned;
        }
        #endregion
    }
}