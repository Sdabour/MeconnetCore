using AlgorithmatENM.ERP.ERPBusiness;
using AlgorithmatENM.Models.ERP.ERPSimple;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlgorithmatENM.ERP.ERPSimple
{
    public class BufferSimple
    {


        #region Properties
        public int ID
        {
            set;
            get;
        }
        public BufferTypeSimple Type
        {
            set;
            get;
        }
        public string Code
        {
            set;
            get;
        }
        public string Desc
        {
            set;
            get;
        }
        public double Size
        {
            set;
            get;
        }
        public string Tag
        {
            set;
            get;
        }
        public int WorkCenter
        {
            set;
            get;
        }
        public int Machine
        {
            set;
            get;
        }
        public int Product
        {
            set;
            get;
        }
        public int Measurement
        {
            set;
            get;
        }
        public PLCSimple PLC
        {
            set;
            get;
        }
        public int PLCDataType
        {
            set;
            get;
        }
        public int PLCVarType
        {
            set;
            get;
        }
        public double Threshold
        {
            set;
            get;
        }
        public bool IsPerHour
        {
            set;
            get;
        }
        #endregion
    }
}