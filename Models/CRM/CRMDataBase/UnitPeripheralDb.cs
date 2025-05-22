using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.SystemBase;
using System.Data;
using System.Data.SqlClient;
using SharpVision.Base.BaseDataBase;
namespace SharpVision.CRM.CRMDataBase
{
    public class UnitPeripheralDb
    {
        #region Private Data
        int _ID;
        int _Unit;
        int _Type;
        double _Survey;

        string _Desc;

        #endregion
        #region Constructors
        public UnitPeripheralDb()
        { }
        public UnitPeripheralDb(DataRow objDr)
        {
            SetData(objDr);
        }
        #endregion
        #region Public Properties
        public int ID
        {
            set
            {
                _ID = value;
            }
            get
            {
                return _ID;
            }
        }
        public string Desc
        {
            set
            {
                _Desc = value;
            }
            get
            {
                return _Desc;
            }
        }
        public int Unit
        {
            set
            {
                _Unit = value;  
            }
            get
            {
                return _Unit;
            }
        }
        string _UnitIDs;

        public string UnitIDs
        {
            set { _UnitIDs = value; }
        }
        public int Type
        {
            set 
            {
                _Type = value;
            }
            get
            {
                return _Type;
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
        double _UnitPrice;

        public double UnitPrice
        {
            get { return _UnitPrice; }
            set { _UnitPrice = value; }
        }
        static string _UnitIDsCache;

        public static string UnitIDsCache
        {
            
            set { UnitPeripheralDb._UnitIDsCache = value; }
        }

        static DataTable _UnitPeripheralCacheTable;

        public static DataTable UnitPeripheralCacheTable
        {
            set
            {
                _UnitPeripheralCacheTable = value;
            }
            get {
                
                if (_UnitPeripheralCacheTable == null && _UnitIDsCache != null && _UnitIDsCache != "")
                {
                    UnitPeripheralDb objDb = new UnitPeripheralDb();
                    objDb.UnitIDs = _UnitIDsCache;
                    _UnitPeripheralCacheTable = objDb.Search();
                }
                return UnitPeripheralDb._UnitPeripheralCacheTable; }
             
        }
        
        public  string AddStr
        {
            get
            {
                string Returned = "insert into CRMUnitPeripheral "+
                    " ( PeriphiralUnit, PeriphiralType, PeripheralDesc, PeripheralSurvey"+
                    ",PeripheralPricePerMeter,UsrIns,TimIns) " +
                    " values ("+ _Unit + "," + _Type + ",'"+ _Desc  + "',"  + _Survey + ","+ _UnitPrice + "," +
                    SysData.CurrentUser.ID  +",GetDate()) ";
                return Returned;
            }
        }
        public string EditStr
        {
            get
            {
                string Returned = "update CRMUnitPeripheral " +
                    "  set PeriphiralUnit=" + _Unit +
                    ", PeriphiralType=" + _Type +
                    ", PeripheralDesc='" + _Desc + "'" +
                    ", PeripheralSurvey=" + _Survey +
                    ",PeripheralPricePerMeter="+_UnitPrice +
                    ",UsrUpd=" + SysData.CurrentUser.ID +
                    ",TimUpd=GetDate() " +
                    " where PeriphiralUnit = " + _Unit +
                    " and PeriphiralID=" + _ID;
                return Returned;
            }
        }
        public string DeleteStr
        {
            get
            {
                string Returned = "delete from CRMUnitPeripheral "+
                      " where PeriphiralUnit = " + _Unit +
                    " and PeriphiralID=" + _ID;
                return Returned;
            }
        }
        public static string SearchStr
        {
            get
            {
                string Returned = "SELECT  PeriphiralID, PeriphiralUnit, PeriphiralType, PeripheralDesc, PeripheralSurvey,PeripheralPricePerMeter,TypeTable.*  " +
                       " FROM   dbo.CRMUnitPeripheral "+
                       "  left outer join (" + PeripheralTypeDb.SearchStr + ") as TypeTable "+
                       " on CRMUnitPeripheral.PeriphiralType = TypeTable.PeripheralTypeID ";
                return Returned;
            }
        }
        #endregion
        #region Private Methods
        void SetData(DataRow objDr)
        {
            _ID = int.Parse(objDr["PeriphiralID"].ToString());
            _Unit = int.Parse(objDr["PeriphiralUnit"].ToString());
            _Type = int.Parse(objDr["PeriphiralType"].ToString());
            _Desc = objDr["PeripheralDesc"].ToString();
            _Survey = double.Parse(objDr["PeripheralSurvey"].ToString());
            if(objDr.Table.Columns["PeripheralPricePerMeter"]!= null)
            double.TryParse(objDr["PeripheralPricePerMeter"].ToString(), out _UnitPrice);
        }
        #endregion
        #region Public Methods
        public void Add()
        {
            string strSql = AddStr;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public void Edit()
        {
            string strSql = EditStr;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public void Delete()
        {
            string strSql = DeleteStr;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public DataTable Search()
        {
            string strSql = SearchStr + " where (1=1)  ";
            if (_Unit != 0)
                strSql += " and  PeriphiralUnit ="+_Unit;
            if (_UnitIDs != null && _UnitIDs != "")
                strSql += " and  PeriphiralUnit in (" + _UnitIDs + ") ";
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        #endregion
    }
}
