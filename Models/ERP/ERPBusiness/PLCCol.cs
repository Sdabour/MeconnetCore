using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SharpVision.SystemBase;
using AlgorithmatENM.ERP.ERPDataBase;
using System.Collections;
using System.Data;
using S7.Net.Types;

namespace AlgorithmatENM.ERP.ERPBusiness
{
    public class PLCCol : CollectionBase
    {

        #region Constructor
        public PLCCol()
        {

        }
        public PLCCol(bool blIsEmbty)
        {
            if (blIsEmbty)
                return;
            PLCBiz objBiz = new PLCBiz();
            objBiz.ID = 0;

            PLCDb objDb = new PLCDb();

            DataTable dtTemp = objDb.Search();


            foreach (DataRow objDR in dtTemp.Rows)
            {
                objBiz = new PLCBiz(objDR);
                Add(objBiz);
            }
        }

        #endregion
        #region Private Data

        #endregion
        #region Properties
        public PLCBiz this[int intIndex]
        {
            get
            {
                return (PLCBiz)this.List[intIndex];
            }
        }
        public BufferCol BufferCol
        {
            get
            {
                BufferCol Returned = new BufferCol(true);
                foreach (PLCBiz objPlc in this)
                {
                    foreach (BufferBiz objBiz in objPlc.BufferCol)
                    {
                        Returned.Add(objBiz);
                    }
                }
                return Returned;
            }
        }
        #endregion
        #region Private Method

        #endregion
        #region Public Method 
        public void Add(PLCBiz objBiz)
        {
            List.Add(objBiz);
        }
        public PLCCol GetCol(string strTemp)
        {
            PLCCol Returned = new PLCCol(true);
            foreach (PLCBiz objBiz in this)
            {
                if (objBiz.Desc.CheckStr(strTemp))
                    Returned.Add(objBiz);
            }
            return Returned;
        }
        public DataTable GetTable()
        {
            DataTable Returned = new DataTable();
            Returned.Columns.AddRange(new DataColumn[] { new DataColumn("PLCID"), new DataColumn("PLCType"), new DataColumn("PLCCpuType"), new DataColumn("PLCIP"), new DataColumn("PLCSlot"), new DataColumn("PLCRack") });
            DataRow objDr;
            foreach (PLCBiz objBiz in this)
            {
                objDr = Returned.NewRow();
                objDr["PLCID"] = objBiz.ID;
                objDr["PLCType"] = objBiz.Type;
                objDr["PLCCpuType"] = objBiz.CpuType;
                objDr["PLCIP"] = objBiz.IP;
                objDr["PLCSlot"] = objBiz.Slot;
                objDr["PLCRack"] = objBiz.Rack;
                Returned.Rows.Add(objDr);
            }
            return Returned;
        }
        public static DataTable GetBufferTempEmptyTable()
        {
            DataTable Returned = new DataTable();
            Returned.Columns.AddRange(new DataColumn[] { new DataColumn("BufferID"), new DataColumn("MeasureWorkOrder"), new DataColumn("MeasureDate", System.Type.GetType("System.DateTime")), new DataColumn("MeasureTime", System.Type.GetType("System.DateTime")), new DataColumn("MeasureValue") });


            return Returned;
        }
        public static void SetNewBufferTempRow(ref DataTable dtBufferMeasure, BufferBiz objBuffer, string strWorkOrder, DateTime dtTime, double dblValue)
        {
            DataRow objDr = dtBufferMeasure.NewRow();
            objDr["BufferID"] = objBuffer.ID;
            objDr["MeasureWorkOrder"] = strWorkOrder;
            objDr["MeasureDate"] = DateTime.Now.Date;
            objDr["MeasureTime"] = dtTime;
            objDr["MeasureValue"] = dblValue;
            dtBufferMeasure.Rows.Add(objDr);
        }
        public DataTable SaveS7BufferRead(string strWorkOrder)
        {
            DataTable Returned = GetBufferTempEmptyTable();


            double dblValue = 0;
            DateTime dtTime = DateTime.Now;
            foreach (PLCBiz objPlc in this)
            {
                if (objPlc.ID != 0 && objPlc.IP != "" && objPlc.OpenS7Plc())
                {

                    foreach (BufferBiz objBufferBiz in objPlc.BufferCol)
                    {
                        if (objBufferBiz.ID != 0 && objBufferBiz.Tag != "")
                        {
                            dblValue = objPlc.ReadTag(objBufferBiz.Tag);
                            SetNewBufferTempRow(ref Returned, objBufferBiz, strWorkOrder, dtTime, dblValue);
                        }

                    }
                    objPlc.CloseS7Plc();
                }
            }
            BufferDb objBufferDb = new BufferDb() { BufferTable = Returned };
            objBufferDb.SaveBufferTable();
            return Returned;
        }

        public void SetS7BufferRead()
        {
            DataTable Returned = GetBufferTempEmptyTable();


            double dblValue = 0;
            DateTime dtTime = DateTime.Now;
            List<List<BufferBiz>> lstItem = new List<List<BufferBiz>>();

            foreach (PLCBiz objPlc in this)
            {
                if (objPlc.ID != 0 && objPlc.IP != "" && objPlc.OpenS7Plc())
                {

                    lstItem = objPlc.BufferCol.GetBufferLst(300);
                    foreach (List<BufferBiz> lstSub in lstItem)
                    {

                        objPlc.ReadMultipleVars("", dtTime, lstSub, ref Returned);
                    }
                    objPlc.CloseS7Plc();
                }
            }
            //BufferDb objBufferDb = new BufferDb() { BufferTable = Returned };
            //objBufferDb.SaveBufferTable();
            //return Returned;
        }
        #endregion
    }
}