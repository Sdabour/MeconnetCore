using System;
using System.Collections;

namespace S7.Net.Types
{
    /// <summary>
    /// Create an instance of a memory block that can be read by using ReadMultipleVars
    /// </summary>
    public class DataItem
    {
        ///// <summary>
        ///// Buffer Id to identify the sent data when retreiving the packet
        ///// </summary>
        //public int Buffer { get; set; }
        /// <summary>
        /// Memory area to read 
        /// </summary>
        /// 

        public DataType DataType { get; set; }

        /// <summary>
        /// Type of data to be read (default is bytes)
        /// </summary>
        public VarType VarType { get; set; }

        /// <summary>
        /// Address of memory area to read (example: for DB1 this value is 1, for T45 this value is 45)
        /// </summary>
        public int DB { get; set; }

        /// <summary>
        /// Address of the first byte to read
        /// </summary>
        public int StartByteAdr { get; set; }

        /// <summary>
        /// Number of variables to read
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// Contains the value of the memory area after the read has been executed
        /// </summary>
        public object Value { get; set; }

        /// <summary>
        /// Create an instance of DataItem
        /// </summary>
        public DataItem()
        {
            VarType = VarType.Byte;
            Count = 1;
        }
        public DataItem(string strTag)
        {
            Count = 1;
            if (strTag == null || strTag=="")
            {
                VarType = VarType.Byte;
                return;
            }
            DataType mDataType;
            int mDB;
            int mByte;
            int mBit;

            byte objByte;
            UInt16 objUInt16;
            UInt32 objUInt32;
            double objDouble;
            BitArray objBoolArray;

            string txt = strTag.ToUpper();
            txt = txt.Replace(" ", "");     // remove spaces
            string strTemp = txt.Substring(2);
            int intTemp = 0;
            int.TryParse(txt.Split('.')[1], out intTemp);
            //StartByteAdr = intTemp;
            try
            {
                switch (txt.Substring(0, 2))
                {
                    case "DB":
                        { 
                        DataType = DataType.DataBlock;
                        string[] strings = txt.Split(new char[] { '.' });
                        if (strings.Length < 2)
                            throw new Exception();

                        DB = int.Parse(strings[0].Substring(2));

                        string dbType = strings[1].Substring(0, 3);
                        int dbIndex = int.Parse(strings[1].Substring(3));
                            StartByteAdr = dbIndex;
                        switch (dbType)
                        {
                            case "DBB":
                                VarType = VarType.Byte; break;
                            //byte obj = (byte)Read(DataType.DataBlock, mDB, dbIndex, VarType.Byte, 1);
                            //return obj;
                            case "DBW":
                                VarType = VarType.Word; break;
                            //UInt16 objI = (UInt16)Read(DataType.DataBlock, mDB, dbIndex, VarType.Word, 1);
                            //return objI;
                            case "DBD":
                                VarType = VarType.DWord; break;
                            //object objTemp = Read(DataType.DataBlock, mDB, dbIndex, VarType.Real, 1);

                            //UInt32 objU = (UInt32)Read(DataType.DataBlock, mDB, dbIndex, VarType.DWord, 1);
                            //double dblTemp = S7.Net.Types.Double.FromDWord(objU);
                            ////decimal objU = (decimal)Read(DataType.DataBlock, mDB, dbIndex, VarType.Real, 1);
                            //return dblTemp;
                            case "DBX":
                                VarType = VarType.Byte; break;
                            //mByte = dbIndex;
                            //mBit = int.Parse(strings[2]);
                            //if (mBit > 7) throw new Exception();
                            //byte obj2 = (byte)Read(DataType.DataBlock, mDB, mByte, VarType.Byte, 1);
                            //objBoolArray = new BitArray(new byte[] { obj2 });
                            //return objBoolArray[mBit];
                            default:
                                throw new Exception();
                        }

                        break; }
                    case "EB":
                        {
                            DataType = DataType.Input;
                            VarType = VarType.Byte;
                            break;
                            // Input byte
                            //objByte = (byte)Read(DataType.Input, 0, int.Parse(txt.Substring(2)), VarType.Byte, 1);
                            //return objByte;
                        }
                    case "EW":
                        {
                            DataType = DataType.Input;
                            VarType = VarType.Word;
                            break;
                        }
                        //// Input word
                        //objUInt16 = (UInt16)Read(DataType.Input, 0, int.Parse(txt.Substring(2)), VarType.Word, 1);
                        //return objUInt16;
                    case "ED":
                        {
                            DataType = DataType.Input;
                            VarType = VarType.DWord;
                            break;
                        }
                    //// Input double-word
                    //objUInt32 = (UInt32)Read(DataType.Input, 0, int.Parse(txt.Substring(2)), VarType.DWord, 1);
                    //return objUInt32;
                    case "AB":
                        {
                            DataType = DataType.Output;
                            VarType = VarType.Byte;
                            break;
                        }
                    // Output byte
                    //objByte = (byte)Read(DataType.Output, 0, int.Parse(txt.Substring(2)), VarType.Byte, 1);
                    //return objByte;
                    case "AW":
                        {
                            DataType = DataType.Output;
                            VarType = VarType.Word;
                            break;
                        }
                    // Output word
                    //objUInt16 = (UInt16)Read(DataType.Output, 0, int.Parse(txt.Substring(2)), VarType.Word, 1);
                    //return objUInt16;
                    case "AD":
                        {
                            DataType = DataType.Output;
                            VarType = VarType.DWord;
                            break;
                        }
                    // Output double-word
                    //objUInt32 = (UInt32)Read(DataType.Output, 0, int.Parse(txt.Substring(2)), VarType.DWord, 1);
                    //return objUInt32;
                    case "MB":
                        {
                            DataType = DataType.Input;
                            VarType = VarType.Word;
                            break;
                        }
                    // Memory byte
                    //objByte = (byte)Read(DataType.Memory, 0, int.Parse(txt.Substring(2)), VarType.Byte, 1);
                    //return objByte;
                    case "MW":
                        {
                            DataType = DataType.Memory;
                            VarType = VarType.Word;
                            break;
                        }
                    // Memory word
                    //objUInt16 = (UInt16)Read(DataType.Memory, 0, int.Parse(txt.Substring(2)), VarType.Word, 1);
                    //return objUInt16;
                    case "MD":
                        {
                            DataType = DataType.Memory;
                            VarType = VarType.DWord;
                            break;
                        }
                    // Memory double-word
                    //objUInt32 = (UInt32)Read(DataType.Memory, 0, int.Parse(txt.Substring(2)), VarType.DWord, 1);
                    //return objUInt32;
                    default:
                        switch (txt.Substring(0, 1))
                        {
                            case "E":
                            case "I":
                                // Input
                                DataType = DataType.Input;
                                break;
                            case "A":
                            case "O":
                                // Output
                                DataType = DataType.Output;
                                break;
                            case "M":
                                // Memory
                                mDataType = DataType.Memory;
                                break;
                            case "T":
                                {
                                    DataType = DataType.Timer;
                                    VarType = VarType.Timer;
                                    break;
                                }
                            // Timer
                            //objDouble = (double)Read(DataType.Timer, 0, int.Parse(txt.Substring(1)), VarType.Timer, 1);
                            //return objDouble;
                            case "Z":
                            case "C":
                                {
                                    DataType = DataType.Counter;
                                    VarType = VarType.Counter;
                                    break;
                                }
                            // Counter
                            //objUInt16 = (UInt16)Read(DataType.Counter, 0, int.Parse(txt.Substring(1)), VarType.Counter, 1);
                            //return objUInt16;
                            default:
                                throw new Exception();
                        }

                        string txt2 = txt.Substring(1);
                        if (txt2.IndexOf(".") == -1)
                            throw new Exception();

                        mByte = int.Parse(txt2.Substring(0, txt2.IndexOf(".")));
                        mBit = int.Parse(txt2.Substring(txt2.IndexOf(".") + 1));
                        if (mBit > 7) throw new Exception();
                        break;
                        //var obj3 = (byte)Read(mDataType, 0, mByte, VarType.Byte, 1);
                        //objBoolArray = new BitArray(new byte[] { obj3 });
                        //return objBoolArray[mBit];
                }
            }
            catch
            {
               // 0LastErrorCode = ErrorCode.WrongVarFormat;
                //LastErrorString = "The strTag'" + strTag + "' could not be read. Please check the syntax and try again.";
                //return LastErrorCode;
            }

        }
        public string GetTagStr()
        {
            string Returned =  "DB";
            switch(DataType)
            {
                case DataType.DataBlock:Returned="DB";break;
                case DataType.Input: Returned = "EB";break;
                default:Returned = "DB";break;

            }
            Returned += DB.ToString();
            Returned += ".";
            switch(VarType)
            {
                case VarType.Byte:Returned += "DBB"; break;
               case VarType.Word: Returned += "DBW"; break;
                case VarType.Real: Returned += "DBD"; break;
                //case VarType.Word: Returned += "DBX"; break;

            }
            return Returned;
        }
    }
}
