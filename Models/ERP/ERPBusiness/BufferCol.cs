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
        public BufferCol(int intBufferType,string strCode,int intPlc)
        {
            if (strCode == "EMBTY")
                strCode = "";

               
            BufferDb objDb = new BufferDb() { Type = intBufferType, Code = strCode, PLC = intPlc };
            DataTable dtTemp = objDb.Search();
            foreach(DataRow objDr in dtTemp.Rows)
            {
                Add(new BufferBiz(objDr));
            }

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
        static Hashtable _CacheBufferHs;
        public static Hashtable CacheBufferHs
        {
            get {
                if(_CacheBufferHs== null)
                {
                    _CacheBufferHs = new Hashtable();
                    BufferCol objCol = new BufferCol(false);
                    foreach(BufferBiz objBiz in objCol)
                    {
                        if (objBiz.ID!=0&& _CacheBufferHs[objBiz.ID.ToString()]==null)
                        {
                            _CacheBufferHs.Add(objBiz.ID.ToString(), objBiz);
                        }
                    }
                }
                return _CacheBufferHs;
            }
        }
        static Hashtable _CacheMachineBufferHs;
        public static Hashtable CacheMachineBufferHs
        {
            get
            {
                if (_CacheMachineBufferHs == null)
                {
                    _CacheMachineBufferHs = new Hashtable();
                    BufferBiz objBiz = new BufferBiz();
                    foreach (object objKey in CacheBufferHs.Keys)
                    {
                        objBiz = (BufferBiz)CacheBufferHs[ objKey];
                        if (objBiz.Machine != 0 && _CacheMachineBufferHs[objBiz.Machine.ToString()] == null)
                        {
                            _CacheMachineBufferHs.Add(objBiz.Machine.ToString(), objBiz);
                        }
                    }
                }
                return _CacheMachineBufferHs;
            }
        }
        static Hashtable _CacheProductBufferHs;
        public static Hashtable CacheProductBufferHs
        {
            get
            {
                if (_CacheProductBufferHs == null)
                {
                    _CacheProductBufferHs = new Hashtable();
                    BufferBiz objBiz = new BufferBiz();
                    foreach (object objKey in CacheBufferHs.Keys)
                    {
                        objBiz = (BufferBiz)CacheBufferHs[objKey];
                        if (objBiz.Product != 0 && _CacheProductBufferHs[objBiz.Product.ToString()] == null)
                        {
                            _CacheProductBufferHs.Add(objBiz.Product.ToString(), objBiz);
                        }
                    }
                }
                return _CacheProductBufferHs;
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
                objDr["BufferType"] = objBiz.TypeBiz.ID;
                objDr["BufferCode"] = objBiz.Code;
                objDr["BufferDesc"] = objBiz.Desc;
                objDr["BufferSize"] = objBiz.Size;
                objDr["BufferTag"] = objBiz.Tag;
                objDr["BufferWorkCenter"] = objBiz.WorkCenter;
                objDr["BufferMachine"] = objBiz.Machine;
                objDr["BufferProduct"] = objBiz.Product;
                objDr["BufferMeasurement"] = objBiz.Measurement;
                objDr["BufferPLC"] = objBiz.PLCBiz.ID;
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