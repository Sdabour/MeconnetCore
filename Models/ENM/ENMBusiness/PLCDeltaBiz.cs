using System;
using System.Collections.Generic;

using System.Web;
using System.Text;
using Microsoft.Win32; // for the registry table
using System.Net; // for the ip address
using System.Runtime.InteropServices; // for the P/Invoke
namespace AlgorithmatENM.ENM.ENMBiz
{
    public enum PLCStatus
    {
        NotSpecified =0,
        InitializingSiloValues =1,
        SiloValueInitialized =2,
        ExecutionStarted=3,
        Finished=4

    }
    public enum PLCFunction
    {
       ReadCoilsW=0,
 ReadInputsW=1,
        ReadHoldRegsW=2,
        ReadHoldRegs32W=3,
        ReadInputRegsW=4,
        WriteSingleCoilW=5,
       WriteSingleRegW=6,
        WriteSingleReg32W=7,
        WriteMultiCoilsW=8,
        WriteMultiRegsW=9,
        WriteMultipleRegisters=10,
        WriteMultipleRegisters32bit=11
    }
    public static class PLCDeltaBiz
    {
        #region Private Data and Public Properties

        #endregion
        #region Constructors

        #endregion

        #region Private Methods

        #endregion
        #region Public Methods
        #region DeltaRegion
      public static  void LoadDeltaDLL()
        {
            try
            {
                hDMTDll = new IntPtr();
                string path = System.Environment.CurrentDirectory;

                // path = path.Remove(path.Length - 9);
                path = path.Replace("\\", "\\\\");
                path += "\\";
                path = path.Insert(path.Length, "DMT.dll"); // obtain the relative path where the DMT.dll resides

                hDMTDll = LoadLibrary(path); // explicitly link to DMT.dll 


                RegistryKey MyRegKey = Registry.LocalMachine.OpenSubKey("HARDWARE\\DEVICEMAP\\SERIALCOMM");
                if (MyRegKey != null)
                {
                    foreach (string valueName in MyRegKey.GetValueNames())
                    {
                        // ComPort.Items.Add(MyRegKey.GetValue(valueName).ToString()); // list out all the serial port on the local machine
                    }
                }
            }
            catch { }
        }
        public static System.IntPtr hDMTDll; // handle of a loaded DLL

        delegate void DelegateClose(int conn_num); // function pointer for disconnection

        // About .Net P/Invoke:

        // [DllImport("XXX.dll", CharSet = CharSet.Auto)] 
        // static extern int ABC(int a , int b);

        // indicates that "ABC" function is imported from XXX.dll
        // XXX.dll exports a function of the same name with "ABC"
        // the return type and the parameter's data type of "ABC" 
        // must be identical with the function exported from XXX.dll
        // and the CharSet = CharSet.Auto causes the CLR 
        // to use the appropriate character set based on the host OS   
        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        static extern IntPtr LoadLibrary(string dllPath);
        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        static extern bool FreeLibrary(IntPtr hDll);

        // Data Access
        [DllImport("DMT.dll", CharSet = CharSet.Auto)]
        public static extern int RequestData(int comm_type, int conn_num, int slave_addr, int func_code, byte[] sendbuf, int sendlen);
        [DllImport("DMT.dll", CharSet = CharSet.Auto)]
        public static extern int ResponseData(int comm_type, int conn_num, ref int slave_addr, ref int func_code, byte[] recvbuf);

        // Serial Communication
        [DllImport("DMT.dll", CharSet = CharSet.Auto)]
        public static extern int OpenModbusSerial(int conn_num, int baud_rate, int data_len, char parity, int stop_bits, int modbus_mode);
        [DllImport("DMT.dll", CharSet = CharSet.Auto)]
        public static extern void CloseSerial(int conn_num);
        [DllImport("DMT.dll", CharSet = CharSet.Auto)]
        public static extern int GetLastSerialErr();
        [DllImport("DMT.dll", CharSet = CharSet.Auto)]
        public static extern void ResetSerialErr();

        // Socket Communication
        [DllImport("DMT.dll", CharSet = CharSet.Auto)]
       public  static extern int OpenModbusTCPSocket(int conn_num, int ipaddr);
        [DllImport("DMT.dll", CharSet = CharSet.Auto)]
        public static extern void CloseSocket(int conn_num);
        [DllImport("DMT.dll", CharSet = CharSet.Auto)]
       public  static extern int GetLastSocketErr();
        [DllImport("DMT.dll", CharSet = CharSet.Auto)]
       public static extern void ResetSocketErr();
        [DllImport("DMT.dll", CharSet = CharSet.Auto)]
        public static extern int ReadSelect(int conn_num, int millisecs);

        // MODBUS Address Calculation
        [DllImport("DMT.dll", CharSet = CharSet.Auto)]
       public  static extern int DevToAddrW(string series, string device, int qty);

        // Wrapped MODBUS Funcion : 0x01
        [DllImport("DMT.dll", CharSet = CharSet.Auto)]
       public static extern int ReadCoilsW(int comm_type, int conn_num, int slave_addr, int dev_addr, int qty, UInt32[] data_r, StringBuilder req, StringBuilder res);

        // Wrapped MODBUS Funcion : 0x02
        [DllImport("DMT.dll", CharSet = CharSet.Auto)]
       public  static extern int ReadInputsW(int comm_type, int conn_num, int slave_addr, int dev_addr, int qty, UInt32[] data_r, StringBuilder req, StringBuilder res);

        // Wrapped MODBUS Funcion : 0x03
        [DllImport("DMT.dll", CharSet = CharSet.Auto)]
      public   static extern int ReadHoldRegsW(int comm_type, int conn_num, int slave_addr, int dev_addr, int qty, UInt32[] data_r, StringBuilder req, StringBuilder res);
        [DllImport("DMT.dll", CharSet = CharSet.Auto)]
       public  static extern int ReadHoldRegs32W(int comm_type, int conn_num, int slave_addr, int dev_addr, int qty, UInt32[] data_r, StringBuilder req, StringBuilder res);

        // Wrapped MODBUS Funcion : 0x04
        [DllImport("DMT.dll", CharSet = CharSet.Auto)]
       public static extern int ReadInputRegsW(int comm_type, int conn_num, int slave_addr, int dev_addr, int qty, UInt32[] data_r, StringBuilder req, StringBuilder res);

        // Wrapped MODBUS Funcion : 0x05		   
        [DllImport("DMT.dll", CharSet = CharSet.Auto)]
        public static extern int WriteSingleCoilW(int comm_type, int conn_num, int slave_addr, int dev_addr, UInt32 data_w, StringBuilder req, StringBuilder res);

        // Wrapped MODBUS Funcion : 0x06
        [DllImport("DMT.dll", CharSet = CharSet.Auto)]
        public static extern int WriteSingleRegW(int comm_type, int conn_num, int slave_addr, int dev_addr, UInt32 data_w, StringBuilder req, StringBuilder res);
        [DllImport("DMT.dll", CharSet = CharSet.Auto)]
        public static extern int WriteSingleReg32W(int comm_type, int conn_num, int slave_addr, int dev_addr, UInt32 data_w, StringBuilder req, StringBuilder res);

        // Wrapped MODBUS Funcion : 0x0F
        [DllImport("DMT.dll", CharSet = CharSet.Auto)]
        public static extern int WriteMultiCoilsW(int comm_type, int conn_num, int slave_addr, int dev_addr, int qty, UInt32[] data_w, StringBuilder req, StringBuilder res);

        // Wrapped MODBUS Funcion : 0x10
        [DllImport("DMT.dll", CharSet = CharSet.Auto)]
        public static extern int WriteMultiRegsW(int comm_type, int conn_num, int slave_addr, int dev_addr, int qty, UInt32[] data_w, StringBuilder req, StringBuilder res);
        [DllImport("DMT.dll", CharSet = CharSet.Auto)]
        public static extern int WriteMultiRegs32W(int comm_type, int conn_num, int slave_addr, int dev_addr, int qty, UInt32[] data_w, StringBuilder req, StringBuilder res);

        #endregion
        #region Serial Comunication
        public static bool CheckConection()
        {
            bool Returned = true;

            #region Set Data
            switch (modbus_mode) // update communication params
            {
                case 1: //ASCII
                    data_len = 7;
                    parity = 'E';
                    modbus_mode = 1;
                    break;

                case 2: // RTU
                    data_len = 8;
                    parity = 'N';
                    modbus_mode = 2;
                    break;
            }
            DelegateClose CloseModbus = new DelegateClose(CloseSerial); // function pointer for disconnection
            switch (comm_type) // build the connection
            {
                case 0: // RS-232
                    comm_type = 0;
                    conn_num = 1;//com1  then 1 or com2 then 2
                    CloseModbus = CloseSerial;

                    status = OpenModbusSerial(conn_num, baud_rate, data_len, parity, stop_bits, modbus_mode);
                    if (status == -1)
                    {
                      Returned =false;
                    }
                    break;

                case 1: // Ethernet
                    comm_type = 1;
                    conn_num = 0;
                    CloseModbus = CloseSocket;

                    IPAddress ipaddress = IPAddress.Parse(_IPAddress);
                    int ip = BitConverter.ToInt32(ipaddress.GetAddressBytes(), 0); // same as inet_addr() 

                    status = OpenModbusTCPSocket(conn_num, ip);
                    if (status == -1)
                    {
                        Returned = false;
                    }
                    break;
            }
            #endregion

            CloseModbus(conn_num);
            return Returned;
        }
      
        #region ConnectionData
        static int conn_num = 0;

        static int baud_rate = 9600; // fiixed
        static int data_len = 7;
        static char parity = 'E';
        static int stop_bits = 1; // fixed 

        static int modbus_mode = 1; // 1:ASCII , 2:RTU
        static int status = 0;
        static int comm_type = 0; // 0:RS-232 , 1:Ethernet
        static string _IPAddress = "";
        static int slave_addr = 1;
        #endregion
        public static bool SetRegisterValue(string strAddress,int intValue,int intSlaveAddress)
        {
          
            List<string> arrError = new List<string>();
            bool Returned = true;
            string strReq = "";
            string strRes = "";

            #region Set Data
            switch (modbus_mode) // update communication params
            {
                case 1: //ASCII
                    data_len = 7;
                    parity = 'E';
                    modbus_mode = 1;
                    break;

                case 2: // RTU
                    data_len = 8;
                    parity = 'N';
                    modbus_mode = 2;
                    break;
            }
            DelegateClose CloseModbus = new DelegateClose(CloseSerial); // function pointer for disconnection
            switch (comm_type) // build the connection
            {
                case 0: // RS-232
                    comm_type = 0;
                    conn_num = 1;//com1  then 1 or com2 then 2
                    CloseModbus = CloseSerial;

                    status = OpenModbusSerial(conn_num, baud_rate, data_len, parity, stop_bits, modbus_mode);
                    if (status == -1)
                    {
                        arrError.Add( "Serial Connection Failed");
                        return false;
                    }
                    break;

                case 1: // Ethernet
                    comm_type = 1;
                    conn_num = 0;
                    CloseModbus = CloseSocket;

                    IPAddress ipaddress = IPAddress.Parse(_IPAddress);
                    int ip = BitConverter.ToInt32(ipaddress.GetAddressBytes(), 0); // same as inet_addr() 

                    status = OpenModbusTCPSocket(conn_num, ip);
                    if (status == -1)
                    {
                       arrError.Add( "Socket Connection Failed");
                        return false;
                    }
                    break;
            }
            #endregion
            UInt32 [] arrTodev = new UInt32[1];
          //  arrTodev[0] = 0;
            arrTodev[0] = (UInt32)intValue;

             UInt32 [] arrFromDev = new UInt32[1];
            arrFromDev[0] = 4;

            int intTemp = 0;
            if (Returned)
               intTemp =  ExecuteFunction(PLCFunction.WriteSingleRegW, strAddress, 1, ref arrFromDev,ref  arrTodev,intSlaveAddress);
            CloseModbus(conn_num);
            return Returned;
        }



        public static bool GetRegisterValue(string strAddress, out string strOut,int intSlaveAddress)
        {
            bool Returned = true;
            strOut = "";
          
            List<string> arrError = new List<string>();
           
           

            #region Set Data
            switch (modbus_mode) // update communication params
            {
                case 1: //ASCII
                    data_len = 7;
                    parity = 'E';
                    modbus_mode = 1;
                    break;

                case 2: // RTU
                    data_len = 8;
                    parity = 'N';
                    modbus_mode = 2;
                    break;
            }
            DelegateClose CloseModbus = new DelegateClose(CloseSerial); // function pointer for disconnection
            switch (comm_type) // build the connection
            {
                case 0: // RS-232
                    comm_type = 0;
                    conn_num = 1;//com1  then 1 or com2 then 2
                    CloseModbus = CloseSerial;

                    status = OpenModbusSerial(conn_num, baud_rate, data_len, parity, stop_bits, modbus_mode);
                    if (status == -1)
                    {
                        arrError.Add("Serial Connection Failed");
                        return false;
                    }
                    break;

                case 1: // Ethernet
                    comm_type = 1;
                    conn_num = 0;
                    CloseModbus = CloseSocket;

                    IPAddress ipaddress = IPAddress.Parse(_IPAddress);
                    int ip = BitConverter.ToInt32(ipaddress.GetAddressBytes(), 0); // same as inet_addr() 

                    status = OpenModbusTCPSocket(conn_num, ip);
                    if (status == -1)
                    {
                        arrError.Add("Socket Connection Failed");
                        return false;
                    }
                    break;
            }
            #endregion
            UInt32[] arrTodev = new UInt32[1];
            arrTodev[0] = 0;

            UInt32[] arrFromDev = new UInt32[1];
            arrFromDev[0] = 0;
            if (Returned)
            {
                //strAddress = "4097";
                ExecuteFunction(PLCFunction.ReadHoldRegsW, strAddress, 1, ref arrFromDev, ref arrTodev,intSlaveAddress);
            }
                CloseModbus(conn_num);
            
            strOut = arrFromDev[0].ToString();
            return Returned;
        }
        public static int DoubleConversion =1;
        #endregion
        #region SerialPort rs232
        
        #endregion
        /// <summary>
        /// Execute PLC Function 
        /// </summary>
        /// <param name="objFunction"></param>
        /// <param name="strDev">presernt register or counter  name in plc </param>
        /// <param name="dev_qty">no of registers frfault is 1</param>
        static int ExecuteFunction1(PLCFunction objFunction, string strDev, int dev_qty,
            ref UInt32[] data_from_dev,ref UInt32[] data_to_dev)
        {
            int intFunction = (int)objFunction;
            int ret = 0;
          
           
           int addr=0;
            if(dev_qty<=0)
            dev_qty=1;
            string strProduct = "DVP";
            addr = DevToAddrW(strProduct, strDev, dev_qty);

                   StringBuilder req = new StringBuilder(1024);
                StringBuilder res = new StringBuilder(1024);

                //UInt32[] data_from_dev = new UInt32[1];
                //data_from_dev[0] = 0;

                //UInt32[] data_to_dev = new UInt32[1];
                //data_to_dev[0] = 0;

            switch (intFunction)
            {
                case 0:
                    ret = ReadCoilsW(comm_type, conn_num, slave_addr, addr, dev_qty, data_from_dev, req, res);
                    break;

                case 1:
                    ret = ReadInputsW(comm_type, conn_num, slave_addr, addr, dev_qty, data_from_dev, req, res);
                    break;

                case 2:
                    ret = ReadHoldRegsW(comm_type, conn_num, slave_addr, addr, dev_qty, data_from_dev, req, res);
                    break;

                case 3:
                    ret = ReadHoldRegs32W(comm_type, conn_num, slave_addr, addr, dev_qty, data_from_dev, req, res);
                    break;

                case 4:
                    ret = ReadInputRegsW(comm_type, conn_num, slave_addr, addr, dev_qty, data_from_dev, req, res);
                    break;

                case 5:
                    ret = WriteSingleCoilW(comm_type, conn_num, slave_addr, addr, data_to_dev[0], req, res);
                    break;

                case 6:
                    ret = WriteSingleRegW(comm_type, conn_num, slave_addr, addr, data_to_dev[0], req, res);
                    break;

                case 7:
                    ret = WriteSingleReg32W(comm_type, conn_num, slave_addr, addr, data_to_dev[0], req, res);
                    break;

                case 8:
                    ret = WriteMultiCoilsW(comm_type, conn_num, slave_addr, addr, dev_qty, data_to_dev, req, res);
                    break;

                case 9:
                    ret = WriteMultiRegsW(comm_type, conn_num, slave_addr, addr, dev_qty, data_to_dev, req, res);
                    break;

                case 10:
                    ret = WriteMultiRegs32W(comm_type, conn_num, slave_addr, addr, dev_qty, data_to_dev, req, res);
                    break;
                //case 11 :
                //    ret = WriteMultipleRegisters32bit(comm_type, conn_num, slave_addr, addr, dev_qty, data_to_dev, req, res);
                //    break;

            }
           
            return ret;
        }
        static int ExecuteFunction(PLCFunction objFunction, string strDev, int dev_qty,
          ref UInt32[] data_from_dev, ref UInt32[] data_to_dev,int intSlaveAddress)
        {
            int intFunction = (int)objFunction;
            intFunction = (int)PLCFunction.ReadHoldRegsW;
            int ret = 0;


            int addr = 0;
            if (dev_qty <= 0)
                dev_qty = 1;
            string strProduct = "DVP-14ss2";
            addr = DevToAddrW(strProduct, strDev, dev_qty);

            StringBuilder req = new StringBuilder(1024);
            StringBuilder res = new StringBuilder(1024);

            //UInt32[] data_from_dev = new UInt32[1];
            //data_from_dev[0] = 0;

            //UInt32[] data_to_dev = new UInt32[1];
            //data_to_dev[0] = 0;

            switch (objFunction)
            {
                case  PLCFunction.ReadCoilsW:
                    ret = ReadCoilsW(comm_type, conn_num, intSlaveAddress, addr, dev_qty, data_from_dev, req, res);
                    break;

                case  PLCFunction.ReadInputsW:
                    ret = ReadInputsW(comm_type, conn_num, intSlaveAddress, addr, dev_qty, data_from_dev, req, res);
                    break;

                case PLCFunction.ReadHoldRegsW:
                    ret = ReadHoldRegsW(comm_type, conn_num, intSlaveAddress, addr, dev_qty, data_from_dev, req, res);
                    break;

                case PLCFunction.ReadHoldRegs32W :
                    ret = ReadHoldRegs32W(comm_type, conn_num, intSlaveAddress, addr, dev_qty, data_from_dev, req, res);
                    break;

                case PLCFunction.ReadInputRegsW:
                    ret = ReadInputRegsW(comm_type, conn_num, intSlaveAddress, addr, dev_qty, data_from_dev, req, res);
                    break;

                case PLCFunction.WriteSingleCoilW:
                    ret = WriteSingleCoilW(comm_type, conn_num, intSlaveAddress, addr, data_to_dev[0], req, res);
                    break;

                case PLCFunction.WriteSingleRegW:
                    ret = WriteSingleRegW(comm_type, conn_num, intSlaveAddress, addr, data_to_dev[0], req, res);
                    break;

                case PLCFunction.WriteSingleReg32W:
                    ret = WriteSingleReg32W(comm_type, conn_num, intSlaveAddress, addr, data_to_dev[0], req, res);
                    break;

                case  PLCFunction.WriteMultiCoilsW:
                    ret = WriteMultiCoilsW(comm_type, conn_num, intSlaveAddress, addr, dev_qty, data_to_dev, req, res);
                    break;

                case  PLCFunction.WriteMultiRegsW:
                    ret = WriteMultiRegsW(comm_type, conn_num, intSlaveAddress, addr, dev_qty, data_to_dev, req, res);
                    break;

                case PLCFunction.WriteMultipleRegisters32bit :
                    ret = WriteMultiRegs32W(comm_type, conn_num, intSlaveAddress, addr, dev_qty, data_to_dev, req, res);
                    break;

                //case 11 :
                //    ret = WriteMultipleRegisters32bit(comm_type, conn_num, intSlaveAddress, addr, dev_qty, data_to_dev, req, res);
                //    break;

            }

            return ret;
        }

        #endregion
    }
}