using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using AlgorithmatENM.ERP.ERPDataBase;
using S7.Net;
using S7.Net.Types;
using System.Collections;

namespace AlgorithmatENM.ERP.ERPBusiness
{
    public enum PLCType { Seimense }
    public class PLCBiz
    {

        #region Constructor
        public PLCBiz()
        {
            _PLCDb = new PLCDb();
        }
        public PLCBiz(DataRow objDr)
        {
            _PLCDb = new PLCDb(objDr);
        }

        #endregion
        #region Private Data
        PLCDb _PLCDb;
        #endregion
        #region Properties
        public int ID
        {
            set => _PLCDb.ID = value;
            get => _PLCDb.ID;
        }
        public string Desc { set => _PLCDb.Desc = value; get => _PLCDb.Desc; }
        public int Type
        {
            set => _PLCDb.Type = value;
            get => _PLCDb.Type;
        }
        public int CpuType
        {
            set => _PLCDb.CpuType = value;
            get => _PLCDb.CpuType;
        }
        public string IP
        {
            set => _PLCDb.IP = value;
            get => _PLCDb.IP;
        }
        public int Slot
        {
            set => _PLCDb.Slot = value;
            get => _PLCDb.Slot;
        }
        public int Rack
        {
            set => _PLCDb.Rack = value;
            get => _PLCDb.Rack;
        }
        BufferCol _BufferCol;
        public BufferCol BufferCol
        {
            set => _BufferCol = value;
            get
            {
                if (_BufferCol == null)
                    _BufferCol = new BufferCol(true);
                return _BufferCol;
            }
        }
        Plc _S7PLC;
        Plc S7PLC
        {
            get
            {
                if (_S7PLC == null)
                    _S7PLC = new Plc((S7.Net.CpuType)CpuType, IP, (short)Rack, (short)Slot);
                return _S7PLC;
            }
        }
        #endregion
        #region Private Method

        #endregion
        #region Public Method 
        public void Add()
        {
            _PLCDb.Add();
        }
        public void Edit()
        {
            _PLCDb.Edit();
        }
        public void Delete()
        {
            _PLCDb.Delete();
        }
        public bool OpenS7Plc()
        {
            if (!S7PLC.IsAvailable) { return false; }
            try
            {
                S7PLC.Open();
                return true;
            }
            catch { return false; }
        }
        public void CloseS7Plc()
        {

            try
            {
                S7PLC.Close();

            }
            catch { }
        }
        public double ReadTag(string strTag)
        {
            double Returned = 0;
            try
            {
                object objTemp = S7PLC.Read(strTag);
                bool blTemp = false;
                if (!double.TryParse(objTemp.ToString(), out Returned))
                {
                    bool.TryParse(objTemp.ToString(), out blTemp);
                    Returned = blTemp ? 1 : 0;
                }
            }
            catch { }
            return Returned;
        }
        public void ReadMultipleVars(string strWorkOrder, DateTime dtTime, List<BufferBiz> lstBuffer, ref DataTable dtTemp)
        {



            double dblValue = 0;
            if (ID != 0 && IP != "" && OpenS7Plc())
            {

                foreach (BufferBiz objBufferBiz in lstBuffer)
                {
                    if (objBufferBiz.ID != 0 && objBufferBiz.Tag != "")
                    {
                        dblValue = ReadTag(objBufferBiz.Tag);
                        PLCCol.SetNewBufferTempRow(ref dtTemp, objBufferBiz, strWorkOrder, dtTime, dblValue);
                        objBufferBiz.TempValue = dblValue;
                    }

                }
                CloseS7Plc();
            }
        }
        #region Stopped Code
        public void ReadMultipleVarsStopped(string strWorkOrder, DateTime dtTime, List<BufferBiz> lstBuffer, ref DataTable dtTemp)
        {
            List<DataItem> lstItem = lstBuffer.Select(x => x.DataItem).ToList();
            S7PLC.ReadMultipleVars(lstItem);

            double dblTemp = 0;
            bool blTemp;
            string[] arrStr;
            for (int intIndex = 0; intIndex < lstBuffer.Count; intIndex++)
            {
                //if (bool.TryParse(vrBufferItemBiz.Item.Value.ToString(), out blTemp))
                //    dblTemp = blTemp ? 1 : 0;
                //else
                if (lstItem[intIndex].Value != null)
                    double.TryParse(lstItem[intIndex].Value.ToString(), out dblTemp);
                arrStr = lstBuffer[intIndex].Tag.Split(".".ToCharArray());
                if (arrStr.Length > 2 && lstItem[intIndex].Value != null)
                {
                    int intBit = 0;
                    int.TryParse(arrStr[2], out intBit);
                    if (intBit <= 7)
                    {
                        BitArray objBoolArray = new BitArray(new byte[] { (byte)lstItem[intIndex].Value });
                        dblTemp = (bool)objBoolArray[intBit] ? 1 : 0;
                    }
                }
                else if (lstItem[intIndex].Value != null)
                {
                    UInt32 objU = (UInt32)lstItem[intIndex].Value;
                    dblTemp = S7.Net.Types.Double.FromDWord(objU);
                }
                lstBuffer[intIndex].TempValue = dblTemp;
                PLCCol.SetNewBufferTempRow(ref dtTemp, lstBuffer[intIndex], strWorkOrder, dtTime, dblTemp);
                //vrBufferItemBiz.Buffer.
            }
        }


        //public void ReadMultipleVars(string strWorkOrder,DateTime dtTime,List<BufferBiz> lstItem,ref DataTable dtTemp)
        //{

        //    S7PLC.ReadMultipleVars(lstItem);
        //    var vrBufferItem = from objBuffer in BufferCol.Cast<BufferBiz>()
        //                       from objItem in lstItem
        //                       where (objBuffer.DataItem.DB == objItem.DB && objBuffer.DataItem.StartByteAdr == objItem.StartByteAdr && objBuffer.DataItem.VarType == objItem.VarType && objBuffer.DataItem.Count == objItem.Count) select new { Item = objItem, Buffer = objBuffer };
        //    double dblTemp = 0;
        //    bool blTemp;
        //    string[] arrStr;
        //   foreach(var vrBufferItemBiz in vrBufferItem)
        //    {
        //        //if (bool.TryParse(vrBufferItemBiz.Item.Value.ToString(), out blTemp))
        //        //    dblTemp = blTemp ? 1 : 0;
        //        //else
        //        if(vrBufferItemBiz.Item.Value!= null)
        //            double.TryParse(vrBufferItemBiz.Item.Value.ToString(),out dblTemp);
        //        arrStr = vrBufferItemBiz.Buffer.Tag.Split(".".ToCharArray());
        //        if (arrStr.Length>2&& vrBufferItemBiz.Item.Value!= null)
        //        {
        //            int intBit = 0;
        //            int.TryParse(arrStr[2], out intBit);
        //            if(intBit<=7)
        //            {
        //               BitArray objBoolArray = new BitArray(new byte[] { (byte)vrBufferItemBiz.Item.Value });
        //                dblTemp = (bool)objBoolArray[intBit]?1:0;
        //            }
        //        }
        //        else if(vrBufferItemBiz.Item.Value!= null)
        //        {
        //            UInt32 objU = (UInt32)vrBufferItemBiz.Item.Value;
        //             dblTemp = S7.Net.Types.Double.FromDWord(objU);
        //        }
        //        vrBufferItemBiz.Buffer.TempValue = dblTemp;
        //       PLCCol.SetNewBufferTempRow(ref dtTemp, vrBufferItemBiz.Buffer, strWorkOrder, dtTime, dblTemp);
        //        //vrBufferItemBiz.Buffer.
        //    }
        //}
        #endregion
        #endregion

    }
}