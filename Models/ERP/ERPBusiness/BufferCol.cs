using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Collections;
using AlgorithmatENM.ERP.ERPDataBase;
using SharpVision.SystemBase;
using S7.Net.Types;

namespace AlgorithmatENM.ERP.ERPBusiness
{
    public class BufferCol : CollectionBase
    {

        #region Constructor
        public BufferCol()
        {

        }
        public BufferCol(bool blIsEmbty)
        {
            if (blIsEmbty)
                return;
            BufferBiz objBiz = new BufferBiz();


            BufferDb objDb = new BufferDb();

            DataTable dtTemp = objDb.Search();


            foreach (DataRow objDR in dtTemp.Rows)
            {
                objBiz = new BufferBiz(objDR);
                Add(objBiz);
            }
        }

        #endregion
        #region Private Data

        #endregion
        #region Properties
        public BufferBiz this[int intIndex]
        {
            get
            {
                return (BufferBiz)this.List[intIndex];
            }
        }
        public PLCCol PLCCol
        {
            get
            {
                PLCCol Returned = new PLCCol(true);
                PLCBiz objBiz;
                Hashtable hsPlc = new Hashtable();
                foreach (BufferBiz objBuffer in this)
                {
                    objBiz = objBuffer.PLCBiz;
                    if (hsPlc[objBiz.ID.ToString()] == null)
                    {
                        objBiz.BufferCol.Add(objBuffer);

                        hsPlc.Add(objBiz.ID.ToString(), objBiz);
                        Returned.Add(objBiz);

                    }
                    else
                    {
                        objBiz = (PLCBiz)hsPlc[objBiz.ID.ToString()];
                        objBiz.BufferCol.Add(objBuffer);
                    }
                }
                return Returned;
            }
        }
        #endregion
        #region Private Method

        #endregion
        #region Public Method 
        public void Add(BufferBiz objBiz)
        {
            List.Add(objBiz);
        }
        public BufferCol GetCol(string strTemp)
        {
            BufferCol Returned = new BufferCol(true);
            foreach (BufferBiz objBiz in this)
            {
                if (objBiz.Desc.CheckStr(strTemp) || objBiz.Code.CheckStr(strTemp) || objBiz.PLCBiz.IP.CheckStr(strTemp))
                    Returned.Add(objBiz);
            }
            return Returned;
        }
        public DataTable GetTable()
        {
            DataTable Returned = new DataTable();
            Returned.Columns.AddRange(new DataColumn[] { new DataColumn("BufferID"), new DataColumn("BufferType"), new DataColumn("BufferCode"), new DataColumn("BufferDesc"), new DataColumn("BufferSize"), new DataColumn("BufferTag"), new DataColumn("BufferWorkCenter"), new DataColumn("BufferMachine"), new DataColumn("BufferProduct"), new DataColumn("BufferMeasurement"), new DataColumn("BufferPLC"), new DataColumn("BufferPLCDataType"), new DataColumn("BufferPLCVarType") });
            DataRow objDr;
            foreach (BufferBiz objBiz in this)
            {
                objDr = Returned.NewRow();
                objDr["BufferID"] = objBiz.ID;
                objDr["BufferType"] = objBiz.Type;
                objDr["BufferCode"] = objBiz.Code;
                objDr["BufferDesc"] = objBiz.Desc;
                objDr["BufferSize"] = objBiz.Size;
                objDr["BufferTag"] = objBiz.Tag;
                objDr["BufferWorkCenter"] = objBiz.WorkCenter;
                objDr["BufferMachine"] = objBiz.Machine;
                objDr["BufferProduct"] = objBiz.Product;
                objDr["BufferMeasurement"] = objBiz.Measurement;
                objDr["BufferPLC"] = objBiz.PLC;
                objDr["BufferPLCDataType"] = objBiz.PLCDataType;
                objDr["BufferPLCVarType"] = objBiz.PLCVarType;
                Returned.Rows.Add(objDr);
            }
            return Returned;
        }
        public List<BufferCol> GetBufferColLst(int intCount)
        {
            List<BufferCol> Returned = new List<BufferCol>();
            int intGroupCount = ((Count % intCount) > 0 ? 1 : 0) + (Count / intCount);
            BufferCol objCol = new BufferCol(true);
            for (int intGroupIndex = 0; intGroupIndex < intGroupCount; intGroupIndex++)
            {
                objCol = new BufferCol(true);
                for (int intIndex = 0; intIndex < intCount; intIndex++)
                {
                    objCol.Add(this[(intGroupIndex * intCount) + intIndex]);
                }
                Returned.Add(objCol);
            }
            return Returned;
        }
        public List<List<BufferBiz>> GetBufferLst(int intCount)
        {
            List<List<BufferBiz>> Returned = new List<List<BufferBiz>>();
            List<BufferBiz> lstBuffer = this.Cast<BufferBiz>().Where(x => x.Tag != null && x.Tag != "").ToList();
            int intGroupCount = ((lstBuffer.Count % intCount) > 0 ? 1 : 0) + (lstBuffer.Count / intCount);
            List<BufferBiz> objCol = new List<BufferBiz>();
            for (int intGroupIndex = 0; intGroupIndex < intGroupCount; intGroupIndex++)
            {
                objCol = new List<BufferBiz>();
                for (int intIndex = 0; intIndex < intCount; intIndex++)
                {
                    if ((intGroupIndex * intCount) + intIndex >= lstBuffer.Count)
                        break;
                    objCol.Add(lstBuffer[(intGroupIndex * intCount) + intIndex]);
                }
                Returned.Add(objCol);
            }
            return Returned;

        }
        public List<List<DataItem>> GetItemLst1(int intCount)
        {
            List<List<DataItem>> Returned = new List<List<DataItem>>();
            List<BufferBiz> lstBuffer = this.Cast<BufferBiz>().Where(x => x.Tag != null && x.Tag != "").ToList();
            int intGroupCount = ((lstBuffer.Count % intCount) > 0 ? 1 : 0) + (lstBuffer.Count / intCount);
            List<DataItem> objCol = new List<DataItem>();
            for (int intGroupIndex = 0; intGroupIndex < intGroupCount; intGroupIndex++)
            {
                objCol = new List<DataItem>();
                for (int intIndex = 0; intIndex < intCount; intIndex++)
                {
                    if ((intGroupIndex * intCount) + intIndex >= lstBuffer.Count)
                        break;
                    objCol.Add(lstBuffer[(intGroupIndex * intCount) + intIndex].DataItem);
                }
                Returned.Add(objCol);
            }
            return Returned;

        }
        #endregion

    }
}