using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlgorithmatENM.ENM.ENMBiz
{
    public class MeasurementSimple
    {

        #region Properties
        public int MeterID{ get; set; } 
        public int MeterTypeID{ get; set; } 
        public string MeterTypeCode{ get; set; } 
        public string ProductName{ get; set; } 
        public string MeterTypeNameA{ get; set; } 
        public string MeterTypeNameE{ get; set; } 
        public int MeterGroup{ get; set; } 
        public string MeterGroupCode{ get; set; } 
        public string MeterGroupNameA{ get; set; } 
        public string MeterGroupNameE{ get; set; } 
        public string MeterGroupDesc{ get; set; } 
        public DateTime LastNonZeroMeasureDate{ get; set; } 
        public string LastNonZeroMeasureDateStr { get => LastNonZeroMeasureType==0?"": LastNonZeroMeasureDate.ToString("yyyy-MM-dd"); }
        public DateTime LastNonZeroMeasureTime;
        public string LastNonZeroMeasureTimeStr { get => LastNonZeroMeasureType==0?"": LastNonZeroMeasureTime.ToString("HH:mm"); }
        public string LastNonZeroMeasureUnit{ get; set; } 
        public double LastNonZeroMeasureValue{ get; set; } 
        public int LastNonZeroMeasureType{ get; set; } 
        public int LastNonZeroMeasureTypeID{ get; set; } 
        public string LastNonZeroMeasureTypeCode{ get; set; } 
        public string LastNonZeroMeasureTypeNameA{ get; set; } 
        public string LastNonZeroMeasureTypeNameE{ get; set; } 
        public DateTime LastMeasureDate{ get; set; } 
        public DateTime LasMeasureTime{ get; set; } 
        public string LastMeasureDateStr { get => LastMeasureType == 0?"":LastMeasureDate.ToString("yyyy-MM-dd"); }
        public string LasMeasureTimeStr
        { get => LastMeasureType==0?"": LastNonZeroMeasureTime.ToString("HH:mm"); }
        public int OnlineStatus { get
            {
                double dblTime = DateTime.Now.Subtract(LasMeasureTime).Minutes;
                if (dblTime < 5)
                    return 1;
                else if (dblTime > 5 && dblTime < 10)
                    return 2;
                else
                    return 0;
            }
        }
        public bool ValueStatus
        {
            get
            {
                
               if(TypeMaxValue== TypeMinValue&& TypeMinValue ==0)
                {
                    if (LastMeasureValue == 0)
                        return false;
                }
               else
                {
                    if (LastMeasureValue > TypeMaxValue || LastMeasureValue < TypeMinValue)
                        return false;

                }
                return true;
            }
        }
        public string LastMeasureUnit{ get; set; } 
        public double LastMeasureValue{ get; set; } 
        public int LastMeasureType{ get; set; } 
        public int LastMeasureTypeID{ get; set; } 
        public string LastMeasureTypeCode{ get; set; } 
        public string LastMeasureTypeNameA{ get; set; } 
        public string LastMeasureTypeNameE{ get; set; } 
        public double TypeMinValue{ get; set; } 
        public double TypeMaxValue{ get; set; } 
        #endregion
    }
}