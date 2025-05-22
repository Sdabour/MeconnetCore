using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.SystemBase;
using System.Data;
using System.Data.SqlClient;

namespace SharpVision.CRM.CRMDataBase
{
    public class ReservationBonusDb
    {
        #region Private Data
        int _ID;
        int _ReservationID;
        double _Value;
        string _Reason;
        DateTime _Date;
        bool _Scheduled;
        string _ReservationIDs;
        int _TypeID;

        #endregion

        #region Constructors
        public ReservationBonusDb()
        {

        }
        public ReservationBonusDb(int intID)
        {
            _ID = intID;
            DataTable dtTemp = Search();
            DataRow objDR = dtTemp.Rows[0];
            _ReservationID = int.Parse(objDR["ReservationID"].ToString());
            _Reason = objDR["BonusReason"].ToString();
            _Date = DateTime.Parse(objDR["BonusDate"].ToString());
            _Value = double.Parse(objDR["BonusValue"].ToString());
            _Scheduled = bool.Parse(objDR["Scheduled"].ToString());
            _TypeID = int.Parse(objDR["TypeID"].ToString());

        }
        public ReservationBonusDb(DataRow objDR)
        {
            _ID = int.Parse(objDR["BonusID"].ToString());
            _ReservationID = int.Parse(objDR["ReservationID"].ToString());
            _Reason = objDR["BonusReason"].ToString();
            _Date = DateTime.Parse(objDR["BonusDate"].ToString());
            _Value = double.Parse(objDR["BonusValue"].ToString());
            //_Scheduled = bool.Parse(objDR["Scheduled"].ToString());
            _TypeID = int.Parse(objDR["TypeID"].ToString());

        }
        #endregion

        #region Public Properties
        public DateTime Date
        {
            set
            {
                _Date = value;
            }
            get
            {
                return _Date;
            }

        }
        public string Reason
        {
            set
            {
                _Reason = value;
            }
            get
            {
                return _Reason;
            }

        }
        public double Value
        {
            set
            {
                _Value = value;
            }
            get
            {
                return _Value;
            }

        }
        public int ReservationID
        {
            set
            {
                _ReservationID = value;
            }
            get
            {
                return _ReservationID;
            }

        }
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
        public int TypeID
        {
            set
            {
                _TypeID = value;
            }
            get
            {
                return _TypeID;
            }
        }

        public bool Scheduled
        {
            set
            {
                _Scheduled = value;
            }
            get
            {
                return _Scheduled;
            }

        }
        public string ReservationIDs
        {
            set
            {
                _ReservationIDs = value;
            }
        }
        public string AddStr
        {
            get
            {
                int intScheduled = _Scheduled ? 1 : 0;
                double dblDate = _Date.ToOADate() - 2;
                string strSql = " INSERT INTO CRMReservationBonus" +
                                " ( ReservationID, BonusValue, BonusReason, BonusDate,Scheduled,TypeID)" +
                                " VALUES     (" + _ReservationID + "," + _Value + ",'" + _Reason + "'," + dblDate + "," + intScheduled + ","+_TypeID+") ";
                return strSql;
            }
        }
        public string EditStr
        {
            get
            {
                int intScheduled = _Scheduled ? 1 : 0;
                double dblDate = _Date.ToOADate() - 2;
                string strSql = " UPDATE    CRMReservationBonus" +
                                " SET  ReservationID =" + _ReservationID + "" +
                                " , BonusValue =" + _Value + "" +
                                " , Scheduled = " + intScheduled + "" +
                                " ,TypeID = "+_TypeID+""+
                                " , BonusReason ='" + _Reason + "'" +
                                " , BonusDate =" + dblDate + "" +
                                " WHERE  ReservationID =" +_ReservationID +" and   (BonusID = " + _ID + ") ";
                return strSql;
            }
        }
        public string DeleteStr
        {
            get
            {
                string Returned =  " DELETE FROM CRMReservationBonus  WHERE  (ReservationID=" + _ReservationID + ") and "+
                    "   (BonusID = " + _ID + ") ";
                return Returned;

            }
        }
        public static string SearchStr
        {
            get
            {

                string Returned = " SELECT     CRMReservationBonus.BonusID, CRMReservationBonus.ReservationID, CRMReservationBonus.BonusValue, CRMReservationBonus.BonusReason, "+
                                   " CRMReservationBonus.BonusDate, CRMReservationBonus.Scheduled, CRMReservationBonus.TypeID,BonusTypeTable.* "+
                                   " FROM         CRMReservationBonus LEFT OUTER JOIN"+
                                   " (" + BonusTypeDb.SearchStr + ") as BonusTypeTable ON CRMReservationBonus.TypeID = BonusTypeTable.BonusTypeID ";
                return Returned;
            }
        }
        
        #endregion

        #region Private Methods

        #endregion

        #region Public Methods
        public void Add()
        {
           
            _ID = SysData.SharpVisionBaseDb.InsertIdentityTable(AddStr);

        }
        public void Edit()
        {
           
            SysData.SharpVisionBaseDb.ExecuteNonQuery(EditStr);

        }

        public void Schedul()
        {
            int intSchedul = _Scheduled ? 1 : 0;
            string strSql = "  UPDATE    CRMReservationBonus" +
                            " SET   Scheduled =" + _Scheduled + "" +
                            " WHERE     (ReservationID = " + _ReservationID + ") AND (BonusID = " + _ID + ") ";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);

        }

        public void Delete()
        {
            string strSql = DeleteStr;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public DataTable Search()
        {
            string strSql = SearchStr + " WHERE    (1=1)";
            if (_ID != 0)
                strSql = strSql + " and BonusID = " + _ID.ToString();
            if (_ReservationID != 0)
                strSql = strSql + " and ReservationID = " + _ReservationID.ToString();
            else if (_ReservationIDs != null && _ReservationIDs != "")
                strSql = strSql + " and ReservationID  in (" + _ReservationIDs + ") ";
            if (_TypeID != 0)
                strSql = strSql + " and TypeID = "+_TypeID+" ";
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql, "Bonus");

        }
        #endregion
    }
}
