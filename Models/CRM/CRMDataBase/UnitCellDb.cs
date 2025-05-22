using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.SystemBase;
using System.Data;
using System.Data.SqlClient;
using SharpVision.Base.BaseDataBase;

namespace SharpVision.CRM.CRMDataBase
{
    public class UnitCellDb
    {
        #region Private Data
        int _CellID;
        int _UnitID;
        double _Survey;
        int _Order;
        #region Private Data for Search
        string _UnitIDs;
        string _CellIDs;
        string _ReservationIDs;
        #endregion
        #endregion
        #region Constructors
        public UnitCellDb()
        { 

        }
        public UnitCellDb(DataRow objDr)
        {
            try
            {
                _CellID = int.Parse(objDr["CellID"].ToString());
            }
            catch { }
            _UnitID = int.Parse(objDr["UnitID"].ToString());
            _Order = int.Parse(objDr["UnitOrder"].ToString());
            _Survey = double.Parse(objDr["UnitPartSurvey"].ToString());
        }
        #endregion
        #region Public Properties
        public int CellID
        {
            set
            {
                _CellID = value;
            }
            get
            {
                return _CellID;
            }
        }
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
        public int Order
        {
            set
            {
                _Order = value;
            }
            get
            {
                return _Order;
            }
        }
        public double Survey
        {
            set
            {
                _Survey = value;
            }
            get
            {
                return _Survey;
            }
        }
        public string UnitIDs
        {
            set
            {
                _UnitIDs = value;
            }
        }
        public string CellIDs
        {
            set
            {
                _CellIDs = value;
            }
        }
        public string ReservationIDs
        {
            set
            {
                _ReservationIDs = value;
            }
        }
        public static string SearchStr
        {
            get
            {
                UnitDb objUnitDb = new UnitDb();
                string Returned = "SELECT CellID, UnitPartSurvey, CRMUnitCell.UnitOrder,UnitTable.* " +
                        " FROM  dbo.CRMUnitCell inner join ("+ objUnitDb.SearchStr +") as UnitTable on CRMUnitCell.UnitID = UnitTable.UnitID ";
                return Returned;
            }
        }

        #endregion
        #region Private Methods

        #endregion
        #region Public Methods
        public DataTable Search()
        {
            string strSql = SearchStr + " where (1=1) ";
            if (_UnitID != 0)
                strSql = strSql + " and UnitTable.UnitID=" + _UnitID;
            if (_CellID != 0)
                strSql = strSql + " and CellID = " + _CellID;
            if (_UnitIDs != null && _UnitIDs != "")
                strSql = strSql + " and UnitTable.UnitID in (" + _UnitIDs + ")";
            if (_CellIDs != null && _CellIDs != "")
                strSql = strSql + " and CellID in (" + _CellIDs + ")";
            if (_ReservationIDs != null && _ReservationIDs != "")
            {
                strSql = strSql + " and UnitTable.UnitID in (SELECT     UnitID "+
                              " FROM  dbo.CRMReservationUnit where ReservationID in ("+ _ReservationIDs +"))";
            }
           
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql,"CellTable");
        }
        #endregion
    }
}
