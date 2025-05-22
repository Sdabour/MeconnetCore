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
    public class ReservationStatisticDb
    {
        #region PrivateData
        protected string _WorkerName;
        protected int _ContractCount;
        protected int _DeservedCount;
        protected int _EndingCount;
        protected int _CanselationCount;
        protected int _CessionCount;
        protected double _TotalValue;
        
        #region PrivateData For Search
        protected int _CellID;
        protected int _WorkerID;
        protected int _Status;
        protected int _BranchID;
        protected DateTime _dtFrom;
        protected DateTime _dtTo;
        #endregion
        #endregion

        #region Constractors
        public ReservationStatisticDb()
        {

        }
        public ReservationStatisticDb(DataRow objDR)
        {
            SetData(objDR);
        }
        #endregion

        #region Public Accessorice
        public string WorkerName
        {
            set { _WorkerName = value; }
            get { return _WorkerName; }
        }
        public int ContractCount
        {
            set { _ContractCount = value; }
            get { return _ContractCount; }
            
        }
        public int DeservedCount
        {
            set { _DeservedCount = value; }
            get { return _DeservedCount; }
            
        }
        public int EndingCount
        {
            set { _EndingCount = value; }
            get { return _EndingCount; }
            
        }
        public int CanselationCount
        {
            set { _CanselationCount = value; }
            get { return _CanselationCount; }
            
        }
        public int CessionCount
        {
            set { _CessionCount = value; }
            get { return _CessionCount; }
            
        }
        public double TotalValue
        {
            set { _TotalValue = value; }
            get { return _TotalValue; }

        }
        #region Accessorice For Search
        public int CellID
        {
            set { _CellID = value; }
            
        }
        public int WorkerID
        {
            set { _WorkerID = value; }
           
        }
        public int Status
        {
            set { _Status = value; }
          
        }
        public int BranchID
        {
            set
            {
                _BranchID = value; 
            }
        }
        public DateTime DtFrom
        {
            set
            {
                _dtFrom = value; 
            }
        }
        public DateTime DtTo
        {
            set 
            {
                _dtTo = value; 
            }
        }
        #endregion
        #region Set Only Accessorice
        public  string SearchStr
        {
            get
            {
                string Returned = " SELECT     HRWorker.WorkerFirstName, SUM(CASE WHEN ReservationStatus = 3 THEN 1 ELSE 0 END) AS Contracting, "+
                      " SUM(CASE WHEN ReservationStatus = 2 THEN 1 ELSE 0 END) AS Deserved, SUM(CASE WHEN ReservationStatus = 4 THEN 1 ELSE 0 END) AS Ending, "+
                      " SUM(CASE WHEN ReservationStatus = 6 THEN 1 ELSE 0 END) AS Canselation, SUM(CASE WHEN ReservationStatus = 5 THEN 1 ELSE 0 END) AS Cession, "+
                      " SUM(CASE WHEN ReservationStatus = 3 THEN ReservationValue ELSE 0 END) AS TotalValue"+
                      " FROM         CRMUnit INNER JOIN"+
                      " CRMReservation ON CRMUnit.UnitID = CRMReservation.ReservationUnitID INNER JOIN"+
                      " CRMUnitCell ON CRMUnit.UnitID = CRMUnitCell.UnitID INNER JOIN"+
                      " RPCell ON CRMUnitCell.CellID = RPCell.CellID INNER JOIN"+
                      " RPCell RPCell_1 ON RPCell.CellFamilyID = RPCell_1.CellID INNER JOIN"+
                      " CRMReservationWorkerContribution ON CRMReservation.ReservationID = CRMReservationWorkerContribution.ReservationID INNER JOIN"+
                      " HRWorker ON CRMReservationWorkerContribution.WorkerID = HRWorker.WorkerID";
                string strWhere = "";
                string strGroup = "";
                if(_CellID != 0)
                {

                }
                strWhere = " WHERE     (RPCell.CellFamilyID = 63)";
                strGroup = " GROUP BY HRWorker.WorkerFirstName";
                return Returned + strWhere + strGroup;
            }

        }

        #endregion
        #endregion

        #region Private Methods
        void SetData(DataRow objDR)
        {
            _WorkerName = objDR["WorkerFirstName"].ToString();
            _ContractCount = int.Parse(objDR["Contracting"].ToString());
            _DeservedCount = int.Parse(objDR["Deserved"].ToString());
            _EndingCount = int.Parse(objDR["Ending"].ToString());
            _CanselationCount = int.Parse(objDR["Canselation"].ToString());
            _CessionCount = int.Parse(objDR["Cession"].ToString());
            _TotalValue = double.Parse(objDR["TotalValue"].ToString());
        }
        #endregion

        #region Public Methods
        public DataTable Search()
        {
            return SysData.SharpVisionBaseDb.ReturnDatatable(SearchStr);
            
        }
        #endregion
    }
}
