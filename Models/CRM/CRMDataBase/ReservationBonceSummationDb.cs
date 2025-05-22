using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.SystemBase;
using System.Data;
using System.Data.SqlClient;
using SharpVision.Base.BaseDataBase;

namespace SharpVision.CRM.CRMDataBase
{
    public class ReservationBonceSummationDb
    {
        #region Private Data
        protected int _CustomerID; 
        protected int _CellID;  
        protected int _BonceTypeID; 

        #region Private Data For 
        protected bool _IsCustomerShow = false;
        protected bool _IsCellShow = false;
        #endregion
        #endregion

        #region Constractors
        public ReservationBonceSummationDb()
        { 

        }
        public ReservationBonceSummationDb(DataRow objDR)
        { 

        }
        #endregion

        #region Public Accessorice
        public int CustomerID
        {
            set
            {
                _CustomerID = value;
            }
            get
            {
                return _CustomerID;
            }
        }
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
        public int BonceTypeID
        {
            set
            {
                _BonceTypeID = value;
            }
            get
            {
                return _BonceTypeID;
            }
        }
        public bool IsCustomerShow
        {
            set
            {
                _IsCustomerShow = value;
            }
            get
            {
                return _IsCustomerShow;
            }
        }
        public bool IsCellShow
        {
            set
            {
                _IsCellShow = value;
            }
            get
            {
                return _IsCellShow;
            }
        }

        public static string strSearch
        {
            get
            {

                string Quary = "FROM         dbo.CRMReservation INNER JOIN"+
                      " dbo.CRMReservationCustomer ON dbo.CRMReservation.ReservationID = dbo.CRMReservationCustomer.ReservationID INNER JOIN"+
                      " dbo.CRMCustomer ON dbo.CRMReservationCustomer.CustomerID = dbo.CRMCustomer.CustomerID INNER JOIN"+
                      " dbo.CRMReservationBonus ON dbo.CRMReservation.ReservationID = dbo.CRMReservationBonus.ReservationID INNER JOIN"+
                      " dbo.CRMBonusType ON dbo.CRMReservationBonus.TypeID = dbo.CRMBonusType.BonusTypeID INNER JOIN"+
                      " dbo.CRMUnit ON dbo.CRMReservation.ReservationID = dbo.CRMUnit.CurrentReservation INNER JOIN"+
                      " dbo.CRMUnitCell ON dbo.CRMUnit.UnitID = dbo.CRMUnitCell.UnitID INNER JOIN"+
                      " dbo.RPCell ON dbo.CRMUnitCell.CellID = dbo.RPCell.CellID INNER JOIN"+
                      " dbo.RPCell RPCell_1 ON dbo.RPCell.CellFamilyID = RPCell_1.CellID";
                return Quary; 
            }
            
        }
       

        #endregion

        #region Private Methods
        void SetData(DataRow objDR)
        {
            _CustomerID = int.Parse(objDR["CustomerID"].ToString());
            _CellID = int.Parse(objDR["CellID"].ToString());
            _BonceTypeID = int.Parse(objDR["BonusTypeID"].ToString());
        }

        #endregion

        #region Public Methods

        public DataTable Search()
        {
            #region Select Close
            string Select_Close = " RPCell_1.CellNameA, SUM(dbo.CRMReservationBonus.BonusValue) AS  BonusValue";
            if (_IsCustomerShow)
                Select_Close += " , dbo.CRMCustomer.CustomerFullName ";
            if (_IsCellShow)
                Select_Close += " , RPCell_1.CellNameA";

            #endregion

            #region GroupBy Close
            string GroupBy_Close = " GROUP BY dbo.CRMBonusType.BonusTypeNameA , RPCell_1.CellNameA";
            if (_IsCustomerShow)
                GroupBy_Close += " , dbo.CRMCustomer.CustomerFullName ";
            if (_IsCellShow)
                GroupBy_Close += " ,  RPCell_1.CellID ";
            #endregion

            #region Where Close
            string Where_Close = " Where 1 = 1 ";
            if (_CustomerID != 0)
                Where_Close += " and  dbo.CRMCustomer.CustomerID = "+_CustomerID+" ";
            if (_CellID != 0)
                Where_Close += " and   RPCell_1.CellID = "+_CellID+"";
            #endregion

            return SysData.SharpVisionBaseDb.ReturnDatatable(Select_Close + strSearch + Where_Close + GroupBy_Close);

        }

        #endregion

    }
}

