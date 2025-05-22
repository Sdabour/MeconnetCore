using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Algorithmat.Algorithmat.AlgorithmatDataBase;
namespace Algorithmat.Algorithmat.AlgorithmatBusiness
{
    public class LocationImageBiz
    {
        #region Private Data and Public Properties
        LocationImageDb _LocationImagedDb;
        ImageBiz _ImageBiz;

        public ImageBiz ImageBiz
        {
            get { return _ImageBiz; }
            set { _ImageBiz = value; }
        }
        public int LocationID
        {
            get { return _LocationImagedDb.LocationID; }
            set { _LocationImagedDb.LocationID = value; }
        }
       

        
      

        public int Order
        {
            get { return _LocationImagedDb.Order; }
            set { _LocationImagedDb.Order = value;
            }
        }
        

        public string TitleA
        {
            get { return _LocationImagedDb.TitleA; }
            set { _LocationImagedDb.TitleA = value; }
        }
       

        public string TitleE
        {
            get { return _LocationImagedDb.TitleE; }
            set { _LocationImagedDb.TitleE = value; }
        }
        public string Title
        {
            get
            {
                string Returned = "";
                if (SharpVision.SystemBase.SysData.Language == 0 || TitleE == null || TitleE == "")
                    Returned = TitleA;
                else
                    Returned = TitleE;
                return Returned;
            }
        }
        #endregion
        #region Constructors
        public LocationImageBiz()
        {
            _LocationImagedDb = new LocationImageDb();
        }
        public LocationImageBiz(DataRow objDr)
        {
            _LocationImagedDb = new LocationImageDb(objDr);
            _ImageBiz = new ImageBiz(objDr);
        }
        #endregion

        #region Private Methods

        #endregion
        #region Public Methods
        public DataRow GetRow(int intLocation, DataTable dtImage)
        {
            DataRow objDr = dtImage.NewRow();
            objDr["LocationID"] = LocationID;
            objDr["ImageID"] = ImageBiz.ID;
            objDr["ImageOrder"] = Order;
            objDr["LocationImageTitleA"] = TitleA;
            objDr["LocationImageTitleE"] = TitleE;
            objDr["SecondaryLocation"] = intLocation;
            return objDr;
        }
        #endregion
    }
}