using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using SharpVision.SystemBase;
using System.Data;
namespace SharpVision.CRM.CRMBusiness
{
    public class UnitFloorCol : CollectionBase
    {
        #region Private Data
        Hashtable _HsFloor = new Hashtable();
        #endregion
        #region Constructors
        public UnitFloorCol(bool blIsEmpty)
        {

        }
        #endregion
        #region Public Properties
        public UnitFloorBiz this[int intIndex]
        {
            get
            {
                return (UnitFloorBiz)List[intIndex];
            }
        }
        public UnitFloorBiz this[string strValue]
        {
            get
            {
                return strValue == null || strValue == "" || _HsFloor[strValue] == null ? new UnitFloorBiz() : (UnitFloorBiz)_HsFloor[strValue];
            }
        }
        public UnitCol UnitCol
        {
            get
            {
                UnitCol Returned = new UnitCol(true);
                foreach (UnitFloorBiz objFloorBiz in this)
                {
                    foreach (UnitBiz objUnitBiz in objFloorBiz.UnitCol)
                    {
                        Returned.Add(objUnitBiz);
                    }
                }
                return Returned;
            }
        }
        #endregion
        #region Private Methods

        #endregion
        #region Public Methods
        public void Add(UnitFloorBiz objBiz)
        {
            if (_HsFloor[objBiz.Value.ToString()] == null)
            {
                List.Add(objBiz);

                _HsFloor.Add(objBiz.Value.ToString(), objBiz);
            }
        }
        public UnitFloorCol GetCol(string strCode)
        {
            UnitFloorCol Returned = new UnitFloorCol(true);
            string[] arrStr = strCode.Split("%".ToCharArray());
            bool blIsFound = false;
            foreach (UnitFloorBiz objBiz in this)
            {
                blIsFound = true;
                foreach (string strTemp in arrStr)
                {
                    if (SysUtility.ReplaceStringComp(objBiz.Name).IndexOf(SysUtility.ReplaceStringComp(strTemp)) == -1
                        && SysUtility.ReplaceStringComp(objBiz.Code).IndexOf(SysUtility.ReplaceStringComp(strTemp)) == -1)
                    {
                        blIsFound = false;
                        break;
                    }
                }
                if (blIsFound)
                    Returned.Add(objBiz);
            }
            return Returned;
        }
        public static UnitFloorBiz GetFloorBiz(int intValue)
        {
            foreach (UnitFloorBiz objBiz in UnitFloorBiz.FloorCol)
            {
                if (objBiz.Value == intValue)
                    return objBiz;
            }
            UnitFloorBiz Returned = new UnitFloorBiz();
            Returned.Name = "ÛíÑ ãÍÏÏ";

            return Returned;

        }
        public void ReorderFoorCol()
        {
            DataTable dtTemp = new DataTable();
            dtTemp.Columns.AddRange(new DataColumn[] { new DataColumn("OrderValue", System.Type.GetType("System.Int64")) });
            DataRow objDr;
            foreach (UnitFloorBiz objBiz in this)
            {
                objDr = dtTemp.NewRow();
                objDr["OrderValue"] = objBiz.Value;
                dtTemp.Rows.Add(objDr);
            }
            DataRow[] arrDr = dtTemp.Select("", "OrderValue");
            List.Clear();
            UnitFloorBiz objFloorBiz;
            foreach (DataRow objDr1 in arrDr)
            {
                if (_HsFloor[objDr1["OrderValue"].ToString()] != null)
                {
                    objFloorBiz = (UnitFloorBiz)_HsFloor[objDr1["OrderValue"].ToString()];
                    if (objFloorBiz != null && objFloorBiz.Value > 0)
                        List.Add(objFloorBiz);
                }
            }
        }
        #endregion
    }
}
