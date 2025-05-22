using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.SystemBase;
using System.Data;
using System.Data.SqlClient;
using SharpVision.Base.BaseDataBase;
using SharpVision.RP.RPDataBase;
using SharpVision.UMS.UMSDataBase;
namespace SharpVision.CRM.CRMDataBase
{
    public class CampaignCustomerReservationDb
    {
        #region Private Data
        int _ID;

        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
        int _CampaignCustomerID;

        public int CampaignCustomerID
        {
            get { return _CampaignCustomerID; }
            set { _CampaignCustomerID = value; }
        }
        int _ReservationID;

        public int ReservationID
        {
            get { return _ReservationID; }
            set { _ReservationID = value; }
        }
        string _CampaignCustomerIDs;

        public string CampaignCustomerIDs
        {
         
            set { _CampaignCustomerIDs = value; }
        }

        public string SearchStr
        {
            get
            {
                string Returned = "SELECT        CampaignCustomerReservationID, CampaignCustomerID, CampaignReservation "+
                      " FROM            dbo.CRMCampaignCustomerReservation where (1=1)  ";
                if (_CampaignCustomerIDs != null && _CampaignCustomerIDs != "")
                    Returned += " and CampaignCustomerID in ("+ _CampaignCustomerIDs + ") ";
 
                return Returned;
            }
        }
        #endregion
        #region Constructor
        public CampaignCustomerReservationDb()
        { 
        }
        public CampaignCustomerReservationDb(DataRow objDr)
        {
            _ID = int.Parse(objDr["CampaignCustomerReservationID"].ToString());
            _CampaignCustomerID = int.Parse(objDr["CampaignCustomerID"].ToString());
            _ReservationID = int.Parse(objDr["CampaignReservation"].ToString());
        }
        #endregion
        #region Public Method
        public DataTable Search()
        {
            return SysData.SharpVisionBaseDb.ReturnDatatable(SearchStr);
        }
        #endregion
    }
}
