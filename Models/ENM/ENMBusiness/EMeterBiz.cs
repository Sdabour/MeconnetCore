using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using AlgorithmatENM.ENM.ENMDb;
using System.IO.Ports;
namespace AlgorithmatENM.ENM.ENMBiz
{
   public class EMeterBiz
    {


        #region Constructor
        public EMeterBiz()
        {
            _EMeterDb = new EMeterDb();
        }
        public EMeterBiz(DataRow objDr)
        {
            _EMeterDb = new EMeterDb(objDr);
            _MeterTypeBiz = new EMeterTypeBiz(objDr);
            _GroupBiz = new EMeterGroupBiz(objDr);
        }

        #endregion
        #region Private Data
        EMeterDb _EMeterDb;
        #endregion
        #region Properties
        public int ID
        {
            set
            {
                _EMeterDb.ID = value;
            }
            get
            {
                return _EMeterDb.ID;
            }
        }
        public int Type
        {
            set
            {
                _EMeterDb.Type = value;
            }
            get
            {
                return _EMeterDb.Type;
            }
        }
        EMeterTypeBiz _MeterTypeBiz;
        public EMeterTypeBiz MeterTypeBiz
        {
            get
            {
                if (_MeterTypeBiz == null)
                    _MeterTypeBiz = new EMeterTypeBiz() { ID=Type};
                return _MeterTypeBiz;
            }
        }
        string _ProductName;
        public string ProductName { set => _ProductName = value; get => _ProductName; }
        public string Desc
        {
            set
            {
                _EMeterDb.Desc = value;
            }
            get
            {
                return _EMeterDb.Desc;
            }
        }
        public string WordStartAddress
        {
            set
            {
                _EMeterDb.WordStartAddress = value;
            }
            get
            {
                return _EMeterDb.WordStartAddress;
            }
        }
        public int WordNo
        {
            set
            {
                _EMeterDb.WordNo = value;
            }
            get
            {
                return _EMeterDb.WordNo;
            }
        }
        public int EService
        {
            set
            {
                _EMeterDb.EService = value;
            }
            get
            {
                return _EMeterDb.EService;
            }
        }
        public int Address
        {
            set
            {
                _EMeterDb.Address = value;
            }
            get
            {
                return _EMeterDb.Address;
            }
        }
        public bool Swap
        {
            set
            {
                _EMeterDb.Swap = value;
            }
            get
            {
                return _EMeterDb.Swap;
            }
        }
        public bool Stopped
        {
            set
            {
                _EMeterDb.Stopped = value;
            }
            get
            {
                return _EMeterDb.Stopped;
            }
        }

        EServiceBiz _ServiceBiz;
        public EServiceBiz ServiceBiz
        {
            set => _ServiceBiz = value;
            get 
            {
                if (_ServiceBiz == null)
                    _ServiceBiz = new EServiceBiz();
                return _ServiceBiz; }
        }
     
      
        MeterMeasureCol _MeasureCol;
        public MeterMeasureCol MeasureCol
        {
            get
            {
                if (_MeasureCol == null)
                {
                   _MeasureCol = MeterTypeBiz.MeasureCol.GetMeterMeasureCol(ID,DateTime.Now);
                }
                    return _MeasureCol;

                }
            }
        public MeterMeasureCol GetMeasureCol(DateTime dtTime)
        {
            MeterMeasureCol Returned  = MeterTypeBiz.MeasureCol.GetMeterMeasureCol(ID,dtTime);
               
                return Returned;

            
        }
        DateTime _StartTime;
        public DateTime StartTime { set => _StartTime = value; get => _StartTime; }
        DateTime _EndTime;
        public DateTime EndTime
        { set => _EndTime = value; get => _EndTime; }
        EMeterGroupBiz _GroupBiz;
        public EMeterGroupBiz GroupBiz
        { set => _GroupBiz = value;
            get
            { 
            if(_GroupBiz == null)
                {
                    _GroupBiz = new EMeterGroupBiz();
                }
                return _GroupBiz;
            } }
        #endregion
        #region Private Method

        #endregion
        #region Public Method 
        public void Add()
        {
            _EMeterDb.Group = GroupBiz.ID;
            _EMeterDb.Add();
        }
        public void Edit()
        {
            _EMeterDb.Group = GroupBiz.ID;
            _EMeterDb.Edit();
        }
        public void Delete()
        {
            _EMeterDb.Delete();
        }

        public MeterMeasureCol MeasureValues(DateTime dtTime)
        {
             
            MeterMeasureCol Returned = new MeterMeasureCol(true);

            byte[] arrByte = new byte[0];
            _MeasureCol = GetMeasureCol(dtTime);
            if (MeterTypeBiz.ID > 3)
            {
                string strValue = "";
                int intValue = 0;
                foreach (MeterMeasureBiz objMeasureBiz in MeasureCol)
                {
                   // objMeasureBiz.MeasureValue =
                   
                    PLCDeltaBiz.GetRegisterValue(objMeasureBiz.MeasureTypeWordStartAddress, out strValue, Address);
                    if (int.TryParse(strValue, out intValue))
                    {
                        objMeasureBiz.MeasureValue = intValue;

                        Returned.Add(objMeasureBiz);
                    }
                }



            }
            else
            {
                if (ModBus.IntializePort((Parity)ServiceBiz.Parity, (StopBits)ServiceBiz.StopBits, ServiceBiz.DataBits, ServiceBiz.BaudRate))
                {

                    int intStartWordAddress = Convert.ToInt32(WordStartAddress, 16);
                    int intTemp = 0;
                    int intOffset = 0;
                   // byte[] arrByte;
                    float fltTempValue = 0;
                    foreach (MeterMeasureBiz objMeasureBiz in MeasureCol)
                    {
                        if (objMeasureBiz.MeasureType == 13)
                        {

                        }

                        arrByte = ModBus.ReadBytes((byte)Address, objMeasureBiz.MeasureTypeWordStartAddress, objMeasureBiz.MeasureTypeWordNo);
                       //if no read
                        if (arrByte.Length == 0)
                            continue;

                        intTemp = Convert.ToInt32(objMeasureBiz.MeasureTypeWordStartAddress, 16);
                        arrByte = new byte[objMeasureBiz.MeasureTypeWordNo * 2];
                        intOffset = 0;
                        intOffset *= 2;
                        intOffset += 3;
                        int intCount = 0;
                        if (objMeasureBiz.DataType == DataType.NoData && !Swap)
                        {
                            for (int intIndex = intOffset; intIndex < (intOffset + (objMeasureBiz.MeasureTypeByteNo)); intIndex++)
                            {

                                arrByte[objMeasureBiz.MeasureTypeByteNo - intCount - 1] = arrByte[intIndex];
                                // arrByte[intCount] = Returned[intIndex + 1];
                                intCount++;
                            }
                        }
                        else if (objMeasureBiz.DataType == DataType.NoData)
                        {
                            for (int intIndex = intOffset; intIndex < (intOffset + (objMeasureBiz.MeasureTypeWordNo * 2)); intIndex += 2)
                            {

                                arrByte[intCount + 1] = arrByte[intIndex];
                                arrByte[intCount] = arrByte[intIndex + 1];
                                intCount += 2;
                            }
                        }
                        else if (objMeasureBiz.DataType == DataType.Float)
                        {
                            intCount = 0;
                            for (int intIndex = intOffset; intIndex < (intOffset + (objMeasureBiz.MeasureTypeWordNo * 2)); intIndex += 2)
                            {

                                arrByte[intCount] = arrByte[intIndex];
                                arrByte[intCount + 1] = arrByte[intIndex + 1];
                                intCount += 2;
                            }



                            // int intResultLen = result.Length;
                            // result = result.PadLeft(32,'0');
                            fltTempValue = ModBus.GetFloat32(arrByte);
                        }
                        if (objMeasureBiz.DataType == DataType.NoData)
                        {
                            int intValue = objMeasureBiz.MeasureTypeWordNo == 1 ? (int)BitConverter.ToInt16(arrByte, 0) : (int)BitConverter.ToInt32(arrByte, 0);
                            objMeasureBiz.MeasureValue = objMeasureBiz.MeasureTypeFactor == 0 ? intValue : intValue * objMeasureBiz.MeasureTypeFactor;
                        }
                        else
                        {
                            objMeasureBiz.MeasureValue = (double)fltTempValue;

                        }
                        Returned.Add(objMeasureBiz);
                    }

                }
            }
            return Returned;
        }

        public byte[] MeasureValuesOld(DateTime dtTime)
        {

            MeterMeasureCol Returned = new MeterMeasureCol(true);

            byte[] arrByte = new byte[0];
            _MeasureCol = GetMeasureCol(dtTime);
            if (MeterTypeBiz.ID > 3)
            {
                string strValue = "";
                int intValue = 0;
                foreach (MeterMeasureBiz objMeasureBiz in MeasureCol)
                {
                    // objMeasureBiz.MeasureValue =

                    PLCDeltaBiz.GetRegisterValue(objMeasureBiz.MeasureTypeWordStartAddress, out strValue, Address);
                    if (int.TryParse(strValue, out intValue))
                    {
                        objMeasureBiz.MeasureValue = intValue;

                        Returned.Add(objMeasureBiz);
                    }
                }



            }
            else
            {
                if (ModBus.IntializePort((Parity)ServiceBiz.Parity, (StopBits)ServiceBiz.StopBits, ServiceBiz.DataBits, ServiceBiz.BaudRate))
                {

                    int intStartWordAddress = Convert.ToInt32(WordStartAddress, 16);
                    int intTemp = 0;
                    int intOffset = 0;
                    // byte[] arrByte;
                    float fltTempValue = 0;
                    foreach (MeterMeasureBiz objMeasureBiz in MeasureCol)
                    {
                        if (objMeasureBiz.MeasureType == 13)
                        {

                        }

                        arrByte = ModBus.ReadBytes((byte)Address, objMeasureBiz.MeasureTypeWordStartAddress, objMeasureBiz.MeasureTypeWordNo);
                        //if no read
                        if (arrByte.Length == 0)
                            continue;

                        intTemp = Convert.ToInt32(objMeasureBiz.MeasureTypeWordStartAddress, 16);
                        arrByte = new byte[objMeasureBiz.MeasureTypeWordNo * 2];
                        intOffset = 0;
                        intOffset *= 2;
                        intOffset += 3;
                        int intCount = 0;
                        if (objMeasureBiz.DataType == DataType.NoData && !Swap)
                        {
                            for (int intIndex = intOffset; intIndex < (intOffset + (objMeasureBiz.MeasureTypeByteNo)); intIndex++)
                            {

                                arrByte[objMeasureBiz.MeasureTypeByteNo - intCount - 1] = arrByte[intIndex];
                                // arrByte[intCount] = Returned[intIndex + 1];
                                intCount++;
                            }
                        }
                        else if (objMeasureBiz.DataType == DataType.NoData)
                        {
                            for (int intIndex = intOffset; intIndex < (intOffset + (objMeasureBiz.MeasureTypeWordNo * 2)); intIndex += 2)
                            {

                                arrByte[intCount + 1] = arrByte[intIndex];
                                arrByte[intCount] = arrByte[intIndex + 1];
                                intCount += 2;
                            }
                        }
                        else if (objMeasureBiz.DataType == DataType.Float)
                        {
                            intCount = 0;
                            for (int intIndex = intOffset; intIndex < (intOffset + (objMeasureBiz.MeasureTypeWordNo * 2)); intIndex += 2)
                            {

                                arrByte[intCount] = arrByte[intIndex];
                                arrByte[intCount + 1] = arrByte[intIndex + 1];
                                intCount += 2;
                            }



                            // int intResultLen = result.Length;
                            // result = result.PadLeft(32,'0');
                            fltTempValue = ModBus.GetFloat32(arrByte);
                        }
                        if (objMeasureBiz.DataType == DataType.NoData)
                        {
                            int intValue = objMeasureBiz.MeasureTypeWordNo == 1 ? (int)BitConverter.ToInt16(arrByte, 0) : (int)BitConverter.ToInt32(arrByte, 0);
                            objMeasureBiz.MeasureValue = objMeasureBiz.MeasureTypeFactor == 0 ? intValue : intValue * objMeasureBiz.MeasureTypeFactor;
                        }
                        else
                        {
                            objMeasureBiz.MeasureValue = (double)fltTempValue;

                        }
                        Returned.Add(objMeasureBiz);
                    }

                }
            }
            return arrByte;
        }
        public bool CheckConnected()
        {
            bool Returned = true;
            if (MeterTypeBiz.ID > 3)
            {
                if (!PLCDeltaBiz.CheckConection())
                    return false;
            }
                    return Returned;
        }
            public byte[] MeasureValues1(DateTime dtTime)
        {
            byte[] Returned = new byte[0];
            _MeasureCol = GetMeasureCol(dtTime);
            if (ModBus.IntializePort((Parity)ServiceBiz.Parity, (StopBits)ServiceBiz.StopBits, ServiceBiz.DataBits, ServiceBiz.BaudRate))
            {
              Returned = ModBus.ReadBytes((byte)Address, WordStartAddress, WordNo);
                int intStartWordAddress = Convert.ToInt32(WordStartAddress, 16);
                int intTemp = 0;
                int intOffset = 0;
                byte[] arrByte;
                foreach (MeterMeasureBiz objMeasureBiz in MeasureCol)
                {
                    if (objMeasureBiz.MeasureType == 13)
                    { 
                    
                    }
                    intTemp = Convert.ToInt32(objMeasureBiz.MeasureTypeWordStartAddress, 16);
                    arrByte = new byte[objMeasureBiz.MeasureTypeWordNo * 2];
                    if (intStartWordAddress > intTemp)
                        continue;
                    intOffset = intTemp- intStartWordAddress;
                    
                    intOffset *= 2;
                    intOffset += 3;
                    if (intOffset + (objMeasureBiz.MeasureTypeWordNo) > Returned.Length)
                        break;
                    int intCount = 0;
                    for (int intIndex = intOffset; intIndex < (intOffset + (objMeasureBiz.MeasureTypeWordNo * 2)); intIndex += 2)
                    {
                        if (intIndex >= Returned.Length - 2)
                            break;
                        arrByte[intCount + 1] = Returned[intIndex];
                        arrByte[intCount] = Returned[intIndex + 1];
                        intCount+=2;
                    }
                    int intValue = objMeasureBiz.MeasureTypeWordNo == 1 ? (int)BitConverter.ToInt16(arrByte,0) :(int) BitConverter.ToInt32(arrByte,0);
                    objMeasureBiz.MeasureValue = objMeasureBiz.MeasureTypeFactor == 0 ? intValue : intValue * objMeasureBiz.MeasureTypeFactor;   
                }

            }
            return Returned;
        }
        #endregion
    }
}
