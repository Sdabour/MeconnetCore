using AlgorithmatENM.ERP.ERPBusiness;
using AlgorithmatENM.ERP.ERPDataBase;
using AlgorithmatENM.Models.ERP.ERPBusiness;
using AlgorithmatENMMVCCore.Hubs;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace AlgorithmatENM.ERP.ERPBusiness
{
    public enum MOStatus { Created,Processing,Paused,Canceled,Finished}
    public class MOBiz
    {

        #region Constructor
        public MOBiz()
        {
            _MODb = new MODb();
        }
        public MOBiz(DataRow objDr)
        {
            _MODb = new MODb(objDr);
        }
        public MOBiz(int intID)
        {
            if (intID == 0)
                _MODb = new MODb();
            else
            {
                _MODb = new MODb() { ID=intID};
                DataTable dtTemp = _MODb.Search();
                if (dtTemp.Rows.Count > 0)
                {
                    _MODb = new MODb(dtTemp.Rows[0]);
                }
                else
                    _MODb = new MODb();
            }
        }
        #endregion
        #region Private Data
        MODb _MODb;
        #endregion
        #region Properties
        public int ID
        {
            set => _MODb.ID = value;
            get => _MODb.ID;
        }
        public string Ref
        {
            set => _MODb.Ref = value;
            get => _MODb.Ref;
        }
        public DateTime Date
        {
            set => _MODb.Date = value;
            get => _MODb.Date;
        }
        public DateTime StartTime
        {
            set => _MODb.StartTime = value;
            get => _MODb.StartTime;
        }
        public string Desc
        {
            set => _MODb.Desc = value;
            get => _MODb.Desc;
        }
        public double Quantity
        {
            set => _MODb.Quantity = value;
            get => _MODb.Quantity;
        }
        public int Responsible
        {
            set => _MODb.Responsible = value;
            get => _MODb.Responsible;
        }
        public MOStatus Status
        {
            set => _MODb.Status = (int)value;
            get => (MOStatus)_MODb.Status;
        }
        public DateTime StatusTime
        {
            set => _MODb.StatusTime = value;
            get => _MODb.StatusTime;
        }
        public int UserStarted { set => _MODb.UserStarted = value; get => _MODb.UserStarted; }
        public int BOM { set => _MODb.BOM = value; get => _MODb.BOM; }
        public int Product { set => _MODb.Product = value; get => _MODb.UserStarted; }
        public string UserStartedName
        {
            set => _MODb.UserStartedName = value;
            get => _MODb.UserStartedName;
        }
        public string ResponsibleName {
            set => _MODb.ResponsibleName = value;
            get => _MODb.ResponsibleName;
        }
        public string BOMName
        {
            set => _MODb.BOMName = value;
            get => _MODb.BOMName;
        }
        public string ProductName
        {
            set => _MODb.ProductName = value;
            get => _MODb.ProductName;
        }
        MOComponentCol _ComponantCol;
        public MOComponentCol ComponentCol { get 
            {
                if(_ComponantCol == null)
                    _ComponantCol= new MOComponentCol(true);
                return _ComponantCol;
            }
            set => _ComponantCol = value; }
        MOComponentCol _ByproductCol;
        public MOComponentCol ByproductCol
        {
            get
            {
                if (_ByproductCol == null)
                    _ByproductCol = new MOComponentCol(true);
                return _ByproductCol;
            }
            set => _ByproductCol = value;
        }

        WorkOrderCol _WorkOrderCol;
        public WorkOrderCol WorkOrderCol
        {
            set=>_WorkOrderCol = value;
            get
            {
                if (_WorkOrderCol == null)
                    _WorkOrderCol = new WorkOrderCol(true);

                return _WorkOrderCol;
            }
        }
        BufferMeasureCol _MeasureCol;
        public BufferMeasureCol MeasureCol
        {
            set => _MeasureCol = value;
            get
            {
                if(_MeasureCol == null) 
                    _MeasureCol = new BufferMeasureCol(true);
                return _MeasureCol;
            }
        }


        BufferCol _BufferCol;
        public BufferCol BufferCol { set => _BufferCol = value;

            get
            {
                if(_BufferCol== null)
                    _BufferCol = new BufferCol(true);
                return _BufferCol;
            }
        
        }

        public static int MOEditStatus = 2320;


        #endregion
        #region Private Method

        #endregion
        #region Public Method 
        public void Add()
        {
            _MODb.Add();
        }
        public void AddUniqueRef()
        {
            _MODb.WorkorderTable = WorkOrderCol.GetTable();
            _MODb.ComponentTable = ComponentCol.GetTable();
            _MODb.ByproductTable = ByproductCol.GetTable();
            _MODb.AddUniqueRef();
        }
        public void Edit()
        {
            _MODb.Edit();
        }
        public void Delete()
        {
            _MODb.Delete();
        }
        public void EditStatus(int intStatus, int intUser)
        {
            _MODb.Status = intStatus;
            _MODb.User = intUser;
            _MODb.EditStatus();
            
        }
       public void SetMeasureCol()
        {
            //_MeasureCol = new BufferMeasureCol(true);
            BufferMeasureDb objDb = new BufferMeasureDb() { MO =ID};
            DataTable dtTemp = objDb.Search();
           // BufferMeasureBiz objMeasure;
            Hashtable hsBuffer = new Hashtable();
            BufferBiz objBiz = new BufferBiz();
            BufferMeasureCol objMeasureCol = new BufferMeasureCol();
            foreach (DataRow objDr in dtTemp.Rows)
            { 
            objMeasureCol.Add(new BufferMeasureBiz(objDr));
            }
            objMeasureCol = objMeasureCol.GetColWithComposition();
                foreach (BufferMeasureBiz objMeasure in objMeasureCol) 
            {
                //objMeasure = new BufferMeasureBiz(objDr);
                objBiz = objMeasure.BufferBiz;
                if (hsBuffer[objBiz.ID.ToString()]==null)
                {
                    objBiz.MeasurementCol.Add(objMeasure);
                    hsBuffer.Add(objBiz.ID.ToString(), objBiz);

                }
                else
                {
                    
                    objBiz = (BufferBiz)hsBuffer[objBiz.ID.ToString()];
                    objBiz.MeasurementCol.Add(objMeasure);
                }
                BufferCol.Add(objBiz);
            }

        }
        public void EditMOStatusChanged()
        {
            _MODb.EditStatusChangedStatus();
        }
        #endregion
    }
}
