using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;

namespace AlgorithmatENM.ENM.ENMBiz
{
    public enum DataType
    {
        NoData,
        Decimal,
        Hexadecimal,
        Float,
        Reverse
    }
    public class RegisterDataType
    {
        DataType _Type;
        public DataType Type { set => _Type = value; get => _Type; }
        string _Desc;
        public string Desc { set => _Desc = value; get => _Desc; }
        int _WordNo;
       public int WordNo { set => _WordNo = value; get => _WordNo; }
        double _Factor;
        public double Factor { set => _Factor = value; get => _Factor; }
        public RegisterDataType(DataType objType)
        {
            Type = objType;
            switch(objType)
            {
                case DataType.Decimal:_WordNo = 1;_Factor = 1;_Desc = "Decimal";break;
                case DataType.Float:_WordNo = 2;_Factor = 0.001;_Desc = "Float";break;
                case DataType.Hexadecimal:_WordNo = 1;break;

            }

        }
    }
   public static class ModBus
    {
        private static SerialPort _Port;
        static string _PortName = SerialPort.GetPortNames().Length>0 ? SerialPort.GetPortNames()[0]:"";
        static Parity _Parity = Parity.None;
        static StopBits _StopBits = StopBits.One;
        static int _DataBits = 8;
        static int _BaudRate = 9600;
        private static readonly ushort[] crcTable = {
            0X0000, 0XC0C1, 0XC181, 0X0140, 0XC301, 0X03C0, 0X0280, 0XC241,
            0XC601, 0X06C0, 0X0780, 0XC741, 0X0500, 0XC5C1, 0XC481, 0X0440,
            0XCC01, 0X0CC0, 0X0D80, 0XCD41, 0X0F00, 0XCFC1, 0XCE81, 0X0E40,
            0X0A00, 0XCAC1, 0XCB81, 0X0B40, 0XC901, 0X09C0, 0X0880, 0XC841,
            0XD801, 0X18C0, 0X1980, 0XD941, 0X1B00, 0XDBC1, 0XDA81, 0X1A40,
            0X1E00, 0XDEC1, 0XDF81, 0X1F40, 0XDD01, 0X1DC0, 0X1C80, 0XDC41,
            0X1400, 0XD4C1, 0XD581, 0X1540, 0XD701, 0X17C0, 0X1680, 0XD641,
            0XD201, 0X12C0, 0X1380, 0XD341, 0X1100, 0XD1C1, 0XD081, 0X1040,
            0XF001, 0X30C0, 0X3180, 0XF141, 0X3300, 0XF3C1, 0XF281, 0X3240,
            0X3600, 0XF6C1, 0XF781, 0X3740, 0XF501, 0X35C0, 0X3480, 0XF441,
            0X3C00, 0XFCC1, 0XFD81, 0X3D40, 0XFF01, 0X3FC0, 0X3E80, 0XFE41,
            0XFA01, 0X3AC0, 0X3B80, 0XFB41, 0X3900, 0XF9C1, 0XF881, 0X3840,
            0X2800, 0XE8C1, 0XE981, 0X2940, 0XEB01, 0X2BC0, 0X2A80, 0XEA41,
            0XEE01, 0X2EC0, 0X2F80, 0XEF41, 0X2D00, 0XEDC1, 0XEC81, 0X2C40,
            0XE401, 0X24C0, 0X2580, 0XE541, 0X2700, 0XE7C1, 0XE681, 0X2640,
            0X2200, 0XE2C1, 0XE381, 0X2340, 0XE101, 0X21C0, 0X2080, 0XE041,
            0XA001, 0X60C0, 0X6180, 0XA141, 0X6300, 0XA3C1, 0XA281, 0X6240,
            0X6600, 0XA6C1, 0XA781, 0X6740, 0XA501, 0X65C0, 0X6480, 0XA441,
            0X6C00, 0XACC1, 0XAD81, 0X6D40, 0XAF01, 0X6FC0, 0X6E80, 0XAE41,
            0XAA01, 0X6AC0, 0X6B80, 0XAB41, 0X6900, 0XA9C1, 0XA881, 0X6840,
            0X7800, 0XB8C1, 0XB981, 0X7940, 0XBB01, 0X7BC0, 0X7A80, 0XBA41,
            0XBE01, 0X7EC0, 0X7F80, 0XBF41, 0X7D00, 0XBDC1, 0XBC81, 0X7C40,
            0XB401, 0X74C0, 0X7580, 0XB541, 0X7700, 0XB7C1, 0XB681, 0X7640,
            0X7200, 0XB2C1, 0XB381, 0X7340, 0XB101, 0X71C0, 0X7080, 0XB041,
            0X5000, 0X90C1, 0X9181, 0X5140, 0X9301, 0X53C0, 0X5280, 0X9241,
            0X9601, 0X56C0, 0X5780, 0X9741, 0X5500, 0X95C1, 0X9481, 0X5440,
            0X9C01, 0X5CC0, 0X5D80, 0X9D41, 0X5F00, 0X9FC1, 0X9E81, 0X5E40,
            0X5A00, 0X9AC1, 0X9B81, 0X5B40, 0X9901, 0X59C0, 0X5880, 0X9841,
            0X8801, 0X48C0, 0X4980, 0X8941, 0X4B00, 0X8BC1, 0X8A81, 0X4A40,
            0X4E00, 0X8EC1, 0X8F81, 0X4F40, 0X8D01, 0X4DC0, 0X4C80, 0X8C41,
            0X4400, 0X84C1, 0X8581, 0X4540, 0X8701, 0X47C0, 0X4680, 0X8641,
            0X8201, 0X42C0, 0X4380, 0X8341, 0X4100, 0X81C1, 0X8081, 0X4040
        };
        public static long[] TwosTable = { 1,
2 ,
4 ,
8 ,
16 ,
32 ,
64 ,
128 ,
256 ,
512 ,
1,024,
2,048 ,
4,096 ,
8,192 ,
16,384 ,
32,768,
65,536 ,
131,072 ,
262,144 ,
524,288 ,
1,048,576,
2,097,152 ,
4,194,304 ,
8,388,608 ,
16,777,216 ,
33,554,432 ,
67,108,864 ,
134,217,728 ,
268,435,456 ,
536,870,912 ,
1,073,741,824,
2,147,483,648 };
        public static byte[] CalculateCrc(byte[] data)
        {
            if (data == null)
                throw new ArgumentNullException("data");

            ushort crc = ushort.MaxValue;

            foreach (byte b in data)
            {
                byte tableIndex = (byte)(crc ^ b);
                crc >>= 8;
                crc ^= crcTable[tableIndex];
            }

            return BitConverter.GetBytes(crc);
        }
        public static byte[] CalculateCrc1(byte[] data)
        {
            if (data == null)
                throw new ArgumentNullException("data");

            
            byte[] btCRC = new byte[2];
            GetCRC(data,ref btCRC);
            return btCRC;
        }
        private static void GetCRC(byte[] message, ref byte[] CRC)
        {
            //Function expects a modbus message of any length as well as a 2 byte CRC array in which to 
            //return the CRC values:

            ushort CRCFull = 0xFFFF;
            byte CRCHigh = 0xFF, CRCLow = 0xFF;
            char CRCLSB;

            for (int i = 0; i < (message.Length) - 2; i++)
            {
                CRCFull = (ushort)(CRCFull ^ message[i]);

                for (int j = 0; j < 8; j++)
                {
                    CRCLSB = (char)(CRCFull & 0x0001);
                    CRCFull = (ushort)((CRCFull >> 1) & 0x7FFF);

                    if (CRCLSB == 1)
                        CRCFull = (ushort)(CRCFull ^ 0xA001);
                }
            }
            CRC[1] = CRCHigh = (byte)((CRCFull >> 8) & 0xFF);
            CRC[0] = CRCLow = (byte)(CRCFull & 0xFF);
        }

        static ushort GetNewCRC(byte[] ptBuf)
        {
            
            ushort crc16, temp;
            byte flag;
            crc16 = 0xffff;
            for(int num=ptBuf.Length;num>0;num--)
            {
                temp = (ushort)ptBuf[ptBuf.Length - num];
                temp &= 0x00ff;
                int intTemp = crc16 ^ temp;
                crc16 =(ushort) Convert.ToInt32( crc16 ^ temp);
                for (int c = 0; c < 8; c++)
                {
                    flag = (byte)Convert.ToInt32( crc16 & 0x01);
                    crc16 = (ushort)Convert.ToInt32(crc16 >> 1);
                    if(flag!=0)
                    {
                        crc16 = (ushort)Convert.ToInt32(crc16 ^ 0x0a001);

                    }


                }


            }
            crc16 = (ushort)Convert.ToInt32((crc16 >> 8) | (crc16 << 8));
            return crc16;
        }
        public static bool IntializePort(Parity objParity,StopBits objStopBits,int intDataBits,int intBaudRate)
        {
            if (_Port!= null && _Port.IsOpen)
            {
                try {
                    _Port.Close();
                } catch { }
            }
            _Port = new SerialPort();
            _PortName = SerialPort.GetPortNames().Length > 0 ? SerialPort.GetPortNames()[0] : "";
            if(_PortName=="")
            { return false; }
            _Port.PortName = _PortName;
            _Port.Parity = objParity;
            _Port.StopBits = objStopBits;
            _Port.DataBits = intDataBits;
            _Port.BaudRate = intBaudRate;

            try
            {
                _Port.Open();
                _Port.DiscardOutBuffer();
                _Port.DiscardInBuffer();
            }
            catch {
                return false;
            }

            return true;
        }
        public static float GetFloat322(byte[] arrByte)
        {
            string Binary = "";
            foreach (byte btTemp in arrByte)
                Binary += Convert.ToString(btTemp, 2).PadLeft(8, '0');


            char[] arrBit = Binary.ToCharArray();
            bool negative = Binary.ToCharArray()[0] == '1';
            string strExponent = Binary.Substring(1, 8);
            int exponent = Convert.ToInt32(strExponent, 2); //(int)((HexNumber & 0x7f800000) >> 23);
            exponent -= 127;
            //float.
           
            string strMantissa = Binary.Substring(9, 23);
            

            double dblTotal = 0;
            
            int intCount = 0;
            int intReal = 0;
            string strReal = strMantissa.Substring(0, exponent);
            char[] arrChr;
            arrChr = strReal.ToCharArray();
            char chr;
            for (int intIndex=0;intIndex<exponent;intIndex++)
            {
                chr = arrChr[intIndex];
                
                
                
                dblTotal += (chr == '1' ? 1 : 0) * Math.Pow(2.0,  exponent-intIndex);
                
            }
            dblTotal += Math.Pow(2, exponent);
            intReal = (int)dblTotal;
              arrChr = strMantissa.Substring(intCount, strMantissa.Length-intCount).ToCharArray();
            intCount = 1;
            dblTotal = 0;
            foreach (char chr1 in arrChr)
            {
                
                dblTotal += (chr1 == '1' ? 1 : 0) * Math.Pow(2.0, -1*intCount);
                intCount++;
            }
           


            int sign = negative ? -1 : 1;



            float value = (float)(sign * (intReal+dblTotal));

            return value;
        }
        public static float GetFloat32(byte[] arrByte)
        {
            string Binary = "";
            foreach (byte btTemp in arrByte)
                Binary += Convert.ToString(btTemp, 2).PadLeft(8, '0');


            char[] arrBit = Binary.ToCharArray();
            bool negative = Binary.ToCharArray()[0] == '1';
            string strExponent = Binary.Substring(1, 8);
            int exponent = Convert.ToInt32(strExponent, 2); //(int)((HexNumber & 0x7f800000) >> 23);
            exponent -= 127;
            //float.
            string strMantissa = Binary.Substring(9, 23);
            double dblTotal = 0;
            int intCount = 1;
            foreach (char chr in strMantissa.ToCharArray())
            {
                dblTotal += (chr == '1' ? 1 : 0) * Math.Pow(2.0, -1 * intCount);
                intCount++;
            }
            dblTotal += 1;


            int sign = negative ? -1 : 1;



            float value = sign * (float)Math.Pow(2.0, exponent) * (float)dblTotal;

            return value;
        }
        public static float GetFloat32Copy(byte[] arrByte)
        {
            string Binary = "";
            foreach (byte btTemp in arrByte)
                Binary += Convert.ToString(btTemp, 2).PadLeft(8, '0');
            UInt32 HexNumber = BitConverter.ToUInt32(arrByte, 0);

            bool negative = !((HexNumber & 0x80000000) == 0x80000000);
            int exponent = (int)(HexNumber & 0x7f800000) >> 23;
            int sign = negative ? -1 : 1;

            // Subtract 127 from the exponent
            exponent -= 127;

            // Convert the mantissa into decimal using the
            // last 23 bits
            int power = -1;
            float total = 0;
            for (int i = 0; i < 23; i++)
            {
                int c = Binary[i + 9] - '0';
                total += (float)c * (float)Math.Pow(2.0, power);
                power--;
            }
            total += 1;

            float value = sign * (float)Math.Pow(2.0, exponent) * total;

            return value;
        }
        public static byte[] ReadBytes(byte btAddress, string strFirstWordAdress, int intWordNo)
        {
            List<byte> lstByte = new List<byte>();
            lstByte.Add(btAddress);
            //Function Code 0x3 Read
            lstByte.Add(0x3);
            byte[] arrTemp = new byte[2];
            short shortTemp = Convert.ToInt16(strFirstWordAdress, 16);
            //shortTemp += 40000;
            int intMax =intWordNo> 10?10:intWordNo;
            int intGroupIndex = 0;
            double dblGroupCount = ((double)intWordNo / intMax);
            
            arrTemp = BitConverter.GetBytes(shortTemp);
            lstByte.Add(arrTemp[1]);
            lstByte.Add(arrTemp[0]);

            shortTemp = (short)intWordNo;
            arrTemp = BitConverter.GetBytes(shortTemp);
            lstByte.Add(arrTemp[1]);
            lstByte.Add(arrTemp[0]);
           // lstByte.Add(0);
            //lstByte.Add(0);
            byte[] arrByte = lstByte.ToArray();
            byte[] arrCRC = CalculateCrc(arrByte);

            byte[] arrCRCNew = BitConverter.GetBytes(GetNewCRC(arrByte));

            lstByte.Add(arrCRC[0]);
            lstByte.Add(arrCRC[1]);
            arrByte = lstByte.ToArray();
            _Port.Write(arrByte, 0, arrByte.Length);




            int intByteNo = intWordNo * 2;
            int intCRCByteNo = 2;
            int intTotalByteNo = intByteNo + 3 + intCRCByteNo;
            
           byte[] Returned = new byte[intTotalByteNo];
            List<byte> lstReturned = new List<byte>();
            System.Threading.Thread.Sleep(20);
            int intTemp=0;
           
            _Port.ReadTimeout =1000;
           //intTemp = _Port.Read(Returned, 0, intTotalByteNo);
           // return Returned;
            //string strTemp = _Port.ReadExisting();
            //Returned = Encoding.ASCII.GetBytes(strTemp);
            //Returned = Encoding.UTF8.GetBytes(strTemp);
           // return Returned;
            for (int intIndex =0;intIndex<intTotalByteNo;intIndex++)
            {
                intTemp = _Port.ReadByte();
                if (intTemp != -1)
                {
                    //lstReturned.Add((byte)intTemp);
                    Returned[intIndex] = (byte)intTemp;


                }
            }
           // Returned = lstReturned.ToArray();
            return Returned;
        }
    }
}
