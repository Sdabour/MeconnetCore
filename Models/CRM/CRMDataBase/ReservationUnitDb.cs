using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.UMS.UMSDataBase;
using SharpVision.SystemBase;
using System.Data;
using System.Data.SqlClient;
using SharpVision.Base.BaseDataBase;
using SharpVision.COMMON.COMMONDataBase;

namespace SharpVision.CRM.CRMDataBase
{
    public class ReservationUnitDb
    {
        #region Private Data
        protected int _ReservationID;
        protected int _ChildReservation;
        protected int _UnitID;
        protected double _UnitPrice;
        protected double _cachPrice;
        protected DateTime _DeliveryDate;
        protected DateTime _RealDeliveryDate;
        bool _IsDelivered;
        protected string _ReservationIDs;
        protected string _UnitIDs;
        #endregion

        #region Constractors
        public ReservationUnitDb()
        {

        }
        public ReservationUnitDb(int intID)
        {
            _ReservationID = intID;
            DataTable dtTemp = Search();
            DataRow objDR = dtTemp.Rows[0];
            SetData(objDR);
        }
        public ReservationUnitDb(DataRow objDR)
        {
            SetData(objDR);
        }
        #endregion

        #region Public Accessorice
      
        public int ReservationID
        {
            set
            {
                _ReservationID = value;
            }
            get
            {
                return _ReservationID ;
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
        public double UnitPrice
        {
            set
            {
                _UnitPrice = value;
            }
            get
            {
                return _UnitPrice;
            }
        }
        public double CachPrice
        {
            set
            {
                _cachPrice = value;
            }
            get
            {
                return _cachPrice;
            }
        }
        public DateTime DeliveryDate
        {
            set
            {
                _DeliveryDate = value;
            }
            get
            {
                return _DeliveryDate;
            }
        }
        public DateTime RealDeliveryDate
        {
            set
            {
                _RealDeliveryDate = value;
            }
            get
            {
                return _RealDeliveryDate;
            }
        
        }
        public int ChildReservation
        {
            set
            {
                _ChildReservation = value;
            }
            get
            {
                return _ChildReservation;
            }
        }
        public bool IsDelivered
        {
            set
            {
                _IsDelivered = value;
            }
            get
            {
                return _IsDelivered;
            }
        }
        public string UnitIDs
        {
            set
            {
                _UnitIDs = value;
            }
        }
        public string ReservationIDs
        {
            set
            {
                _ReservationIDs = value;
            }
        }
        public string ReleaseChildReservedUnitStr
        {
            get
            {
                string Returned = "update CRMReservationUnit set ChildReservation =0 where ChildReservation=" + _ChildReservation ;
                return Returned;
            }
        }
        public string EditChildReservationStr
        {
            get
            {
                string Returned = "update CRMReservationUnit set ChildReservation=" + _ChildReservation +
                " where ReservationID=" + _ReservationID + " and UnitID in(" + _UnitIDs + ")";
                return Returned;
            }
        }
        public static string SearchStr
        {
            get
            {
                UnitDb objUnitDb = new UnitDb();
                string Returned = " SELECT     ReservationID, ReservationUnitPrice, "+
                    " ReservationcachPrice, ReservationDeliveryDate, ReservationRealDeliveryDate,ChildReservation,UnitTable.* " +
                     " FROM         CRMReservationUnit  inner join ("+ objUnitDb.SearchStr+") UnitTable on "+
                     " CRMReservationUnit.UnitID = UnitTable.UnitID  ";
                return Returned;
            }
        }
      
        public string AddStr
        {
            get
            {
                 double dblDeliveryDate = _DeliveryDate.ToOADate()-2;
                 double dblRealDeliveryDate = _RealDeliveryDate.ToOADate()-2;
                 string strRealDeliverDate = "";
                 if (_IsDelivered)
                     strRealDeliverDate = dblRealDeliveryDate.ToString();
                 else
                     strRealDeliverDate = "null";
                 string strSql = " INSERT INTO CRMReservationUnit"+
                            " (ReservationID, UnitID, ReservationUnitPrice,"+
                            " ReservationcachPrice, ReservationDeliveryDate, ReservationRealDeliveryDate,ChildReservation)"+
                            " VALUES     ("+_ReservationID+","+_UnitID+","+_UnitPrice+","+_cachPrice+","+dblDeliveryDate+","+strRealDeliverDate+ "," + _ChildReservation + ") ";
                return strSql;
            }
        }
        #endregion

        #region Private Methods
        void SetData(DataRow objDR)
        {
            _ReservationID = int.Parse(objDR["ReservationID"].ToString());
            _UnitID = int.Parse(objDR["UnitID"].ToString());
            _UnitPrice = double.Parse(objDR["ReservationUnitPrice"].ToString());
            _cachPrice = double.Parse(objDR["ReservationcachPrice"].ToString());
          DateTime.TryParse(objDR["ReservationDeliveryDate"].ToString(),out _DeliveryDate);
            _ChildReservation = int.Parse(objDR["ChildReservation"].ToString());
            if (objDR["ReservationRealDeliveryDate"].ToString() != "")
            {
                _IsDelivered = true;
                _RealDeliveryDate = DateTime.Parse(objDR["ReservationRealDeliveryDate"].ToString());
            }
            else
                IsDelivered = false;

        }
        #endregion

        #region Public Methods
        public void Add()
        {
            SysData.SharpVisionBaseDb.ExecuteNonQuery(AddStr);
        }
        public void DeliverUnit()
        {
            double dblRealDeliveryDate = _RealDeliveryDate.ToOADate() - 2;
            string strSql = "update CRMReservationUnit set ReservationRealDeliveryDate= " + dblRealDeliveryDate +
                " where ReservationID=" + _ReservationID + " and UnitID="+ _UnitID;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public void EditRealDeliveryDate()
        {
            double dblRealDeliveryDate = _RealDeliveryDate.ToOADate() - 2;
            string strRealDeliveryDate = "null";
            if (_IsDelivered)
                strRealDeliveryDate = dblRealDeliveryDate.ToString();
            string strSql = "update CRMReservationUnit set ReservationRealDeliveryDate= " + strRealDeliveryDate +
                " where ReservationID=" + _ReservationID + " and UnitID=" + _UnitID;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public void EditChildReservation()
        {
            if (_UnitIDs == null || _UnitIDs == "")
                return;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(EditChildReservationStr);
        }
        public DataTable Search()
        {
            string strSql = SearchStr + " WHERE   1 = 1  ";
            if(_ReservationID != 0)
                strSql += " and  ReservationID = "+_ReservationID+"";
            if (_ChildReservation != 0)
                strSql += " and ChildReservation=" + _ChildReservation;
            if(_ReservationIDs != null && _ReservationIDs != "")
                strSql+= " and ReservationID in ("+ _ReservationIDs +") ";
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql,"Unit");

        }
        #endregion



    }
}
