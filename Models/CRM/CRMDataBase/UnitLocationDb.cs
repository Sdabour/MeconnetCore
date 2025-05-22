using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.SystemBase;
namespace SharpVision.CRM.CRMDataBase
{
    public class UnitLocationDb
    {
        #region Private Data
        int _UnitID;
        int _LocationID;
        int _OldLocationID;
        int _ImageID;

        #endregion
        #region Constructors
        public UnitLocationDb()
        { 
        }
        public UnitLocationDb(DataRow objDr)
        {
            SetData(objDr);
        }
        #endregion
        #region Public Properties
        public int UnitID
        {
            set
            {
                _UnitID = value;
            }
            get
            {
                return _UnitID;
            }
        }
        public int LocationID
        {
            set
            {
                _LocationID = value;
            }
            get
            {
                return _LocationID;
            }
        }
        public int ImageID
        {
            set
            {
                _ImageID = value;
            }
        }
        public static string SearchStr
        {
            get
            {
                UnitDb objUnitDb = new UnitDb();
                string Returned = "SELECT  RPCell.CellOrder,LocationUnit, Location,LocationTable.*,UnitTable.* "+
                      " FROM    dbo.CRMUnitImageLocation inner join ("+ CellLocationDb.SearchStr +") as LocationTable on CRMUnitImageLocation.Location = LocationTable.LocationID  "+
                      " inner join ("+ objUnitDb.SearchStr+") as UnitTable on CRMUnitImageLocation.LocationUnit = UnitTable.UnitID "+
                      " inner join CRMUnitCell on CRMUnitCell.UnitID = UnitTable.UnitID "+
                      " inner join RPCell on RPCell.CellID = CRMUnitCell.CellID ";
                return Returned;
            }
        }
        #endregion
        #region Private Methods
        void SetData(DataRow objDr)
        {
            _UnitID = int.Parse(objDr["LocationUnit"].ToString());
            _LocationID = int.Parse(objDr["Location"].ToString());
            _OldLocationID = _LocationID;
        }
        #endregion
        #region Public Methods
        public void Add()
        {
            string strSql = "insert into CRMUnitImageLocation (LocationUnit, Location) values ("+ _UnitID + "," + _LocationID +")";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
            
 
        }
        public void Edit()
        {
            string strSql = "update CRMUnitImageLocation Set Location=" + _LocationID + " where Location ="+ _OldLocationID + 
                " and LocationUnit= "+ _UnitID;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
            
        }
        public DataTable Search()
        {
            string strSql = SearchStr + " where (1=1) ";
            strSql = strSql + " and  UnitClosedPermanent=0 And (UnitTable.CurrentReservation = 0 or UnitTable.CurrentReservation is null) " +
                        " and (UnitUserClosed=0 or UnitUserClosed=" + SysData.CurrentUser.ID +
                        " or UnitTimeOpen<GetDate() ) ";
            if (_ImageID != 0)
                strSql += " and LocationTable.LocationImage=" + _ImageID;
            if (_UnitID != 0)
                strSql += " and LocationUnit="+ _UnitID;
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
      
        #endregion
    }
}
