using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlgorithmatENM.ERP.ERPSimple
{
    public class BufferMeasureSimple
    {

        #region Properties
        public int MeasureID;
        public string MeasureWorkOrder;
        public DateTime MeasureDate;
        public DateTime MeasureTime;
        public double MeasureValue;
        public double MeasureFirstValue;
        public double MeasureMinValue;
        public double MeasureMaxValue;
        public DateTime MeasureMinTime;
        public int BufferID;
        public string BufferCode;
        public string BufferDesc;
        public double BufferSize;
        public string BufferTag;
        public int BufferTypeID;
        public string BufferTypeCode;
        public string BufferTypeNameA;
        public string BufferTypeNameE;
        public int BufferMachineID;
        public int BufferMachineCeneter;
        public int BufferMachineFlow;
        public string BufferMachineCode;
        public string BufferMachineDesc;
        public string BufferMachineNameA;
        public string BufferMachineNameE;
        public int BufferProductID;
        public string BufferProductCode;
        public string BufferProductNameA;
        public string BufferProductNameE;
        public bool BufferProductIsComposed;
        public int BufferCenterID;
        public string BufferCenterCode;
        public string BufferCenterNameA;
        public string BufferCenterNameE;
        public int mentID;
        public string mentCode;
        public string mentNameA;
        public string mentNameE;
        #endregion
    }
}