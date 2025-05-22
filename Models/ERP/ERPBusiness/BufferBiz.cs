using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AlgorithmatENM.ERP.ERPDataBase;
using System.Data;
using S7.Net.Types;
namespace AlgorithmatENM.ERP.ERPBusiness
{
    public class BufferBiz
    {

        #region Constructor
        public BufferBiz()
        {
            _BufferDb = new BufferDb();
        }
        public BufferBiz(DataRow objDr)
        {
            _BufferDb = new BufferDb(objDr);
            _PLCBiz = new PLCBiz(objDr);
        }

        #endregion
        #region Private Data
        BufferDb _BufferDb;
        #endregion
        #region Properties
        public int ID
        {
            set => _BufferDb.ID = value;
            get => _BufferDb.ID;
        }
        public int Type
        {
            set => _BufferDb.Type = value;
            get => _BufferDb.Type;
        }
        public string Code
        {
            set => _BufferDb.Code = value;
            get => _BufferDb.Code;
        }
        public string Desc
        {
            set => _BufferDb.Desc = value;
            get => _BufferDb.Desc;
        }
        public double Size
        {
            set => _BufferDb.Size = value;
            get => _BufferDb.Size;
        }
        public string Tag
        {
            set => _BufferDb.Tag = value;
            get => _BufferDb.Tag;
        }
        public int WorkCenter
        {
            set => _BufferDb.WorkCenter = value;
            get => _BufferDb.WorkCenter;
        }
        public int Machine
        {
            set => _BufferDb.Machine = value;
            get => _BufferDb.Machine;
        }
        public int Product
        {
            set => _BufferDb.Product = value;
            get => _BufferDb.Product;
        }
        public int Measurement
        {
            set => _BufferDb.Measurement = value;
            get => _BufferDb.Measurement;
        }
        public int PLC
        {
            set => _BufferDb.PLC = value;
            get => _BufferDb.PLC;
        }
        PLCBiz _PLCBiz;
        public PLCBiz PLCBiz
        {
            set => _PLCBiz = value;
            get
            {
                if (_PLCBiz == null)
                    _PLCBiz = new PLCBiz();
                return _PLCBiz;
            }
        }
        public int PLCDataType
        {
            set => _BufferDb.PLCDataType = value;
            get => _BufferDb.PLCDataType;
        }
        public int PLCVarType
        {
            set => _BufferDb.PLCVarType = value;
            get => _BufferDb.PLCVarType;
        }
        DataItem _DataItem;
        public DataItem DataItem
        {
            set => _DataItem = value;
            get
            {
                if (_DataItem == null)
                    _DataItem = new DataItem(Tag);
                return _DataItem;
            }
        }
        public double TempValue { set; get; }
        #endregion
        #region Private Method

        #endregion
        #region Public Method 
        public void Add()
        {
            _BufferDb.Add();
        }
        public void Edit()
        {
            _BufferDb.Edit();
        }
        public void Delete()
        {
            _BufferDb.Delete();
        }
        #endregion
    }
}