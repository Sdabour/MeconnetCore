using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using AlgorithmatENM.ERP.ERPDataBase;
namespace AlgorithmatENM.ERP.ERPBusiness
{
    public class BufferMeasureBiz
    {

        #region Constructor
        public BufferMeasureBiz()
        {
            _BufferMeasureDb = new BufferMeasureDb();
        }
        public BufferMeasureBiz(DataRow objDr)
        {
            _BufferMeasureDb = new BufferMeasureDb(objDr);
            _PLCBiz = new PLCBiz(objDr);
        }

        #endregion
        #region Private Data
        BufferMeasureDb _BufferMeasureDb;
        #endregion
        #region Properties
        public int MeasureID
        {
            set => _BufferMeasureDb.MeasureID = value;
            get => _BufferMeasureDb.MeasureID;
        }
        public string MeasureWorkOrder
        {
            set => _BufferMeasureDb.MeasureWorkOrder = value;
            get => _BufferMeasureDb.MeasureWorkOrder;
        }
        public DateTime MeasureDate
        {
            set => _BufferMeasureDb.MeasureDate = value;
            get => _BufferMeasureDb.MeasureDate;
        }
        public DateTime MeasureTime
        {
            set => _BufferMeasureDb.MeasureTime = value;
            get => _BufferMeasureDb.MeasureTime;
        }
        public double MeasureValue
        {
            set => _BufferMeasureDb.MeasureValue = value;
            get => _BufferMeasureDb.MeasureValue;
        }
        public double MeasureFirstValue
        {
            set => _BufferMeasureDb.MeasureFirstValue = value;
            get => _BufferMeasureDb.MeasureFirstValue;
        }
        public double MeasureMinValue
        {
            set => _BufferMeasureDb.MeasureMinValue = value;
            get => _BufferMeasureDb.MeasureMinValue;
        }
        public double MeasureMaxValue
        {
            set => _BufferMeasureDb.MeasureMaxValue = value;
            get => _BufferMeasureDb.MeasureMaxValue;
        }
public double ActualValue
        {
            get
            {
                double Returned = MeasureValue;
                if(BufferIsPerHour)
                {
                   Returned= ((MeasureValue + MeasureMinValue + MeasureMaxValue + MeasureFirstValue) / 4) *(((double)MeasureTime.Subtract(MeasureMinTime).Minutes) / 60);
                }
                return Returned;
            }
        }
        public DateTime MeasureMinTime
        {
            set => _BufferMeasureDb.MeasureMinTime = value;
            get => _BufferMeasureDb.MeasureMinTime;
        }

        public int BufferID
        {
            set => _BufferMeasureDb.BufferID = value;
            get => _BufferMeasureDb.BufferID;
        }
        public string BufferCode
        {
            set => _BufferMeasureDb.BufferCode = value;
            get => _BufferMeasureDb.BufferCode;
        }
        public string BufferDesc
        {
            set => _BufferMeasureDb.BufferDesc = value;
            get => _BufferMeasureDb.BufferDesc;
        }
        public string BufferContent
        {
            get
            {
                return BufferCenterID > 0 ? BufferCenterNameA : (BufferMachineID > 0 ? BufferMachineDesc : (BufferProductID > 0 ? BufferProductNameA : BufferDesc));
            }
        }
        public double BufferSize
        {
            set => _BufferMeasureDb.BufferSize = value;
            get => _BufferMeasureDb.BufferSize;
        }
        public string BufferTag
        {
            set => _BufferMeasureDb.BufferTag = value;
            get => _BufferMeasureDb.BufferTag;
        }
        public bool BufferIsPerHour
        {
            set => _BufferMeasureDb.BufferIsPerHour = value;
            get => _BufferMeasureDb.BufferIsPerHour;
        }
        public int BufferTypeID
        {
            set => _BufferMeasureDb.BufferTypeID = value;
            get => _BufferMeasureDb.BufferTypeID;
        }
        public string BufferTypeCode
        {
            set => _BufferMeasureDb.BufferTypeCode = value;
            get => _BufferMeasureDb.BufferTypeCode;
        }
        public string BufferTypeNameA
        {
            set => _BufferMeasureDb.BufferTypeNameA = value;
            get => _BufferMeasureDb.BufferTypeNameA;
        }
        public string BufferTypeNameE
        {
            set => _BufferMeasureDb.BufferTypeNameE = value;
            get => _BufferMeasureDb.BufferTypeNameE;
        }
        public int BufferMachineID
        {
            set => _BufferMeasureDb.BufferMachineID = value;
            get => _BufferMeasureDb.BufferMachineID;
        }
        public int BufferMachineCeneter
        {
            set => _BufferMeasureDb.BufferMachineCeneter = value;
            get => _BufferMeasureDb.BufferMachineCeneter;
        }
        public int BufferMachineFlow
        {
            set => _BufferMeasureDb.BufferMachineFlow = value;
            get => _BufferMeasureDb.BufferMachineFlow;
        }
        public string BufferMachineCode
        {
            set => _BufferMeasureDb.BufferMachineCode = value;
            get => _BufferMeasureDb.BufferMachineCode;
        }
        public string BufferMachineDesc
        {
            set => _BufferMeasureDb.BufferMachineDesc = value;
            get => _BufferMeasureDb.BufferMachineDesc;
        }
        public string BufferMachineNameA
        {
            set => _BufferMeasureDb.BufferMachineNameA = value;
            get => _BufferMeasureDb.BufferMachineNameA;
        }
        public string BufferMachineNameE
        {
            set => _BufferMeasureDb.BufferMachineNameE = value;
            get => _BufferMeasureDb.BufferMachineNameE;
        }
        public int BufferProductID
        {
            set => _BufferMeasureDb.BufferProductID = value;
            get => _BufferMeasureDb.BufferProductID;
        }
        public string BufferProductCode
        {
            set => _BufferMeasureDb.BufferProductCode = value;
            get => _BufferMeasureDb.BufferProductCode;
        }
        public string BufferProductNameA
        {
            set => _BufferMeasureDb.BufferProductNameA = value;
            get => _BufferMeasureDb.BufferProductNameA;
        }
        public string BufferProductNameE
        {
            set => _BufferMeasureDb.BufferProductNameE = value;
            get => _BufferMeasureDb.BufferProductNameE;
        }
        public bool BufferProductIsComposed
        {
            set => _BufferMeasureDb.BufferProductIsComposed = value;
            get => _BufferMeasureDb.BufferProductIsComposed;
        }
        public int BufferCenterID
        {
            set => _BufferMeasureDb.BufferCenterID = value;
            get => _BufferMeasureDb.BufferCenterID;
        }
        public string BufferCenterCode
        {
            set => _BufferMeasureDb.BufferCenterCode = value;
            get => _BufferMeasureDb.BufferCenterCode;
        }
        public string BufferCenterNameA
        {
            set => _BufferMeasureDb.BufferCenterNameA = value;
            get => _BufferMeasureDb.BufferCenterNameA;
        }
        public string BufferCenterNameE
        {
            set => _BufferMeasureDb.BufferCenterNameE = value;
            get => _BufferMeasureDb.BufferCenterNameE;
        }
        public int mentID
        {
            set => _BufferMeasureDb.mentID = value;
            get => _BufferMeasureDb.mentID;
        }
        public string mentCode
        {
            set => _BufferMeasureDb.mentCode = value;
            get => _BufferMeasureDb.mentCode;
        }
        public string mentNameA
        {
            set => _BufferMeasureDb.mentNameA = value;
            get => _BufferMeasureDb.mentNameA;
        }
        public string mentNameE
        {
            set => _BufferMeasureDb.mentNameE = value;
            get => _BufferMeasureDb.mentNameE;
        }
        PLCBiz _PLCBiz;
        public PLCBiz PLCBiz { get
            { if (_PLCBiz == null)
                    _PLCBiz = new PLCBiz();
                return _PLCBiz;
            }
        }
        #endregion
        #region Private Method

        #endregion
        #region Public Method 
        public void Add()
        {
            _BufferMeasureDb.Add();
        }
        public void Edit()
        {
            _BufferMeasureDb.Edit();
        }
        public void Delete()
        {
            _BufferMeasureDb.Delete();
        }
        public BufferMeasureBiz Copy()
        {
            BufferMeasureBiz Returned = new BufferMeasureBiz() { BufferCenterCode = BufferCenterCode,BufferCenterID=BufferCenterID,BufferCenterNameA=BufferCenterNameA,BufferCenterNameE=BufferCenterNameE,BufferCode=BufferCode,BufferDesc=BufferDesc,BufferID=BufferID,BufferIsPerHour=BufferIsPerHour,BufferMachineCeneter=BufferMachineCeneter,BufferMachineCode=BufferMachineCode,BufferMachineDesc=BufferMachineDesc,BufferMachineFlow=BufferMachineFlow,BufferMachineID=BufferMachineID,BufferMachineNameA=BufferMachineNameA,BufferMachineNameE=BufferMachineNameE,BufferProductCode=BufferProductCode,BufferProductID=BufferProductID,BufferProductIsComposed=BufferProductIsComposed,BufferProductNameA=BufferProductNameA,BufferProductNameE=BufferProductNameE,BufferSize=BufferSize,BufferTag=BufferTag,BufferTypeCode=BufferTypeCode,BufferTypeID=BufferTypeID,BufferTypeNameA=BufferTypeNameA,BufferTypeNameE=BufferTypeNameE,MeasureDate=MeasureDate,MeasureFirstValue=MeasureFirstValue,MeasureID=MeasureID,MeasureMaxValue=MeasureMaxValue,MeasureMinTime=MeasureMinTime,MeasureMinValue=MeasureMinValue,MeasureTime=MeasureTime,MeasureValue=MeasureValue,MeasureWorkOrder=MeasureWorkOrder,mentCode=mentCode,mentID=mentID,mentNameA=mentNameA, mentNameE=mentNameE};
            return Returned;
        }
        #endregion
    }
}