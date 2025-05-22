using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.RP.RPDataBase;
using SharpVision.Base.BaseBusiness;
using System.Data;
using System.Collections;
using SharpVision.SystemBase;
//using System.Threading;
namespace SharpVision.RP.RPBusiness
{
    public class CellCol : BaseCol
    {
        #region PrivateData
        CellBiz _RootBiz;
        int _NodeNo;
        Hashtable _TempCellTable = new Hashtable();
     
        #endregion
        #region Constructor
        public CellCol()
        {
            CellDb objCellDb = new CellDb();
            DataTable dtCell = objCellDb.Search();
            //dtCell.Columns["CellOrder"].DataType = Type.GetType("System.Int");
            string strOrder = "CellOrder";
            DataRow[] arrDR = dtCell.Select("Dis Is Null and CellID=CellParentID and Dis is null ", strOrder);
            CellBiz objCellBiz;
            CellBiz objTempParent = new CellBiz();
            string strCellIDs = "";
            foreach (DataRow DR in arrDR)
            {

                objCellBiz = new CellBiz(DR);
                if (_TempCellTable[objCellBiz.ID.ToString()] != null)
                    continue;
                if (strCellIDs != "")
                    strCellIDs += ",";
                strCellIDs = strCellIDs + objCellBiz.ID.ToString();
                Add(objCellBiz);
                objCellBiz.ParentBiz = objTempParent;
                objCellBiz.Children = new CellCol(true);
                _TempCellTable.Add(objCellBiz.ID.ToString(), objCellBiz);


            }
            SetChildren(strCellIDs, ref dtCell);

        }
        internal CellCol(int intCellID, DataTable dtCell)
        {

            string strOrder = "CellOrder";


            DataRow[] arrDR = dtCell.Select("CellID<>" + intCellID + " and CellParentID=" + intCellID + " and Dis is null ", strOrder);
            CellBiz objCellBiz;
            CellBiz objTempParent = new CellBiz();

            string strCellIDs = "";
            foreach (DataRow DR in arrDR)
            {

                objCellBiz = new CellBiz(DR);
                if (_TempCellTable[objCellBiz.ID.ToString()] != null)
                    continue;
                if (strCellIDs != "")
                    strCellIDs += ",";
                strCellIDs = strCellIDs + objCellBiz.ID.ToString();
                Add(objCellBiz);
                objCellBiz.ParentBiz = objTempParent;
                objCellBiz.Children = new CellCol(true);
                _TempCellTable.Add(objCellBiz.ID.ToString(), objCellBiz);


            }
            SetChildren(strCellIDs, ref dtCell);

        }

        public CellCol(int intTypeID, string strCellName,
            CellBiz objParentBiz, bool blOnlyFamilies, bool blNoChildren)
        {
            DataTable dtTempCell = new DataTable();


            if (objParentBiz == null)
                objParentBiz = new CellBiz();
            else if (objParentBiz.ID != 0 && !blOnlyFamilies && objParentBiz.ID != objParentBiz.ParentID)
            {
                CellDb objTempCellDb = new CellDb();
                objTempCellDb.ID = objParentBiz.ID;
                objTempCellDb.CellTableSearch = new DataTable();
                dtTempCell = objTempCellDb.GetChildrenTable();
            }


            CellDb objCellDb = new CellDb();
         

            objCellDb.TypeID = intTypeID;
            objCellDb.NameLike = strCellName;
            objCellDb.OnlyFamilies = blOnlyFamilies;
            objCellDb.NoChildren = blNoChildren;
            if (objParentBiz.ID != 0 && !blOnlyFamilies)
            {
                objCellDb.ParentID = objParentBiz.ID;
                if (objParentBiz.ID == objParentBiz.ParentID && objParentBiz.ID != 0)
                    objCellDb.FamilyID = objParentBiz.ID;
                if (dtTempCell.Columns.Count > 0)
                    objCellDb.CellTableSearch = dtTempCell;
            }
            DataTable dtCell;

            dtCell = objCellDb.GetAllCell();
            if (dtCell.Rows.Count == 0)
                return;


            string strOrder = "CellOrder";
            DataRow[] arrDR = dtCell.Select("CellID=CellParentID", strOrder);
            CellBiz objCellBiz;
            CellBiz objTempParent = new CellBiz();
            string strCellIDs = "";
            foreach (DataRow DR in arrDR)
            {

                objCellBiz = new CellBiz(DR);
                if (_TempCellTable[objCellBiz.ID.ToString()] != null)
                    continue;
                if (strCellIDs != "")
                    strCellIDs += ",";
                strCellIDs = strCellIDs + objCellBiz.ID.ToString();
                Add(objCellBiz);
                objCellBiz.ParentBiz = objTempParent;
                objCellBiz.Children = new CellCol(true);
                _TempCellTable.Add(objCellBiz.ID.ToString(), objCellBiz);


            }
            SetChildren(strCellIDs, ref dtCell);

        }
        public CellCol(bool blIsEmpty)
        {
            if (!blIsEmpty)
            {
                CellBiz objBiz = new CellBiz();
                objBiz.NameA = "€Ì— „Õœœ";
                objBiz.NameE = "Not Specified";
                Add(objBiz);
                CellDb objCellDb = new CellDb();
                objCellDb.OnlyFamilies = true;
                DataTable dtTemp = objCellDb.GetAllCell();
                foreach (DataRow objDr in dtTemp.Rows)
                {
                    Add(new CellBiz(objDr));
                }
            }

        }
        public CellCol(int intCellID)
        {
            CellDb objCellDb = new CellDb();
            DataTable dtCell = objCellDb.Search();

            DataRow[] arrDR = dtCell.Select("CellID=" + intCellID);
            CellBiz objCellBiz;
            CellBiz objTempParent = new CellBiz();
            string strCellIDs = "";
            foreach (DataRow DR in arrDR)
            {

                objCellBiz = new CellBiz(DR);
                if (_TempCellTable[objCellBiz.ID.ToString()] != null)
                    continue;
                if (strCellIDs != "")
                    strCellIDs += ",";
                strCellIDs = strCellIDs + objCellBiz.ID.ToString();
                Add(objCellBiz);
                objCellBiz.ParentBiz = objTempParent;
                objCellBiz.Children = new CellCol(true);
                _TempCellTable.Add(objCellBiz.ID.ToString(), objCellBiz);
            }
            SetChildren(strCellIDs, ref dtCell);

        }
        public CellCol(int intAccount, bool isTrue)
        {
            CellDb objCellDb = new CellDb();
            DataTable dtCell = objCellDb.Search();

            DataRow[] arrDR = dtCell.Select("CellGLAccount=" + intAccount);
            CellBiz objCellBiz;
            CellBiz objTempParent = new CellBiz();
            string strCellIDs = "";
            foreach (DataRow DR in arrDR)
            {

                objCellBiz = new CellBiz(DR);
                if (_TempCellTable[objCellBiz.ID.ToString()] != null)
                    continue;
                if (strCellIDs != "")
                    strCellIDs += ",";
                strCellIDs = strCellIDs + objCellBiz.ID.ToString();
                Add(objCellBiz);
                objCellBiz.ParentBiz = objTempParent;
                objCellBiz.Children = new CellCol(true);
                _TempCellTable.Add(objCellBiz.ID.ToString(), objCellBiz);
            }
            SetChildren(strCellIDs, ref dtCell);
        }
        #endregion
        #region Public Properties
        public virtual CellBiz this[int intIndex]
        {
            get
            {
                return (CellBiz)this.List[intIndex];
            }
        }
        public virtual CellBiz this[string strIndex]
        {
            get
            {
                CellBiz Returned = new CellBiz();
                foreach (CellBiz objCellBiz in this)
                {
                    if (objCellBiz.Name == strIndex)
                    {
                        Returned = objCellBiz;
                        break;
                    }
                }
                return Returned;
            }
        }
        public double ChildrenPercentSum
        {
            get
            {
                double dblReturned = 0;
                foreach (CellBiz objBiz in this)
                {
                    dblReturned = dblReturned + objBiz.ParentCostPerc;
                }
                return dblReturned;
            }
        }
        public CellBiz RootBiz
        {
            set
            {
                _RootBiz = value;
            }
        }
        public string IDsStr
        {
            get
            {
                string Returned = "";
                foreach (CellBiz objBiz in this)
                {
                    if (objBiz.IDsStr != "")
                    {
                        if (Returned != "")
                            Returned = Returned + ",";
                        Returned = Returned + objBiz.IDsStr;
                    }
                }
                return Returned;
            }

        }
        public string CurrentIDsStr
        {
            get
            {
                string Returned = "";
                foreach (CellBiz objBiz in this)
                {
                    if (objBiz.ID != 0)
                    {
                        if (Returned != "")
                            Returned = Returned + ",";
                        Returned = Returned + objBiz.ID;
                    }
                }
                return Returned;
            }

        }
        public string FamilyIDs
        {
            get
            {
                string Returned = "";
                foreach (CellBiz objBiz in this)
                {
 
                }
                return Returned;
            }
        }
        public static CellCol ProjectCol
        {
            get
            {
                CellCol Returned = new CellCol(true);
                 DataRow [] arrDr = CellDb.CellTable.Select("CellID=CellFamilyID and Dis is null", "");
                 CellBiz objBiz = new CellBiz();
                 objBiz.NameA = "€Ì— „Õœœ";
                 Returned.Add(objBiz);
                 foreach (DataRow objDr in arrDr)
                 {
                     objBiz = new CellBiz(objDr);
                     Returned.Add(objBiz);
                 }
                

                return Returned;
            }
        }
        public string DisplayStr
        {
            get
            {
                string Returned = "„Ã„⁄";
                string strDisplay = "";
                Hashtable hsTemp = new Hashtable();
                foreach (CellBiz objBiz in this)
                {
                    if (hsTemp[objBiz.Name] == null)
                    {
                        hsTemp.Add(objBiz.Name, objBiz);
                        if (strDisplay != "")
                            strDisplay += " & ";
                        strDisplay += objBiz.Name;
                    }
                }
                if (strDisplay != "")
                    Returned += "(" + strDisplay + ")";
                return Returned;
            }
        }
        #endregion
        #region  Privaet methods
        #region Old Recursive Function
        //void SetChildren(ref CellBiz objCellBiz, ref DataTable dtCells)
        //{
        //    objCellBiz.Children = new CellCol(true);
        //    objCellBiz.Children.RootBiz = objCellBiz;
        //    DataRow[] arrDR = dtCells.Select("Dis is null and CellID <> CellParentID and CellParentID=" + objCellBiz.ID,"CellOrder");
        //    CellBiz tempCellBiz;
        //    CellCol objCellCol;
        //    objCellCol = new CellCol(true);
        //    int intTemp = 0;

        //    foreach (DataRow DR in arrDR)
        //    {

        //        tempCellBiz = new CellBiz(DR);

        //        if (intTemp == tempCellBiz.ID)
        //            continue;
        //        else
        //        {

        //           intTemp = tempCellBiz.ID;

        //        }
        //        if (_NodeNo >= 200)
        //            break;
        //        SetChildren(ref tempCellBiz, ref dtCells);
        //        tempCellBiz.ParentBiz = objCellBiz;
        //        objCellCol.Add(tempCellBiz);


        //    }
        //    objCellBiz.Children = objCellCol;

        //}
        #endregion
        void SetChildren(string strCellIDs, ref DataTable dtCells)
        {
            if (strCellIDs == "")
                return;
            CellBiz objParentCellBiz;
            DataRow[] arrDR = dtCells.Select("Dis is null and CellID <> CellParentID " +
                " and CellParentID in (" + strCellIDs + ") ", "CellOrder");
            CellBiz objCellBiz;
            CellCol objCellCol;
            objCellCol = new CellCol(true);
            strCellIDs = "";
            foreach (DataRow DR in arrDR)
            {
                objCellBiz = new CellBiz(DR);
                if (_TempCellTable[objCellBiz.ID.ToString()] != null)
                    continue;
                if (strCellIDs != "")
                    strCellIDs = strCellIDs + ",";
                strCellIDs = strCellIDs + objCellBiz.ID.ToString();
                objParentCellBiz = (CellBiz)_TempCellTable[objCellBiz.ParentID.ToString()];
                objParentCellBiz.Children.Add(objCellBiz);
                objCellBiz.Children = new CellCol(true);
                _TempCellTable.Add(objCellBiz.ID.ToString(), objCellBiz);
                objCellBiz.ParentBiz = objParentCellBiz;
            }
            SetChildren(strCellIDs, ref dtCells);

        }
        void SetChildrenCol(ref CellCol objCellCol, string strCell, CellBiz objCellBiz)
        {
            if (objCellBiz.Name.IndexOf(strCell,StringComparison.OrdinalIgnoreCase) != -1 ||
                objCellBiz.AlterName.IndexOf(strCell, StringComparison.OrdinalIgnoreCase) != -1)
                objCellCol.Add(objCellBiz);
            else
            {
                if (objCellBiz.Children != null)
                {
                    foreach (CellBiz objBiz in objCellBiz.Children)
                    {
                        SetChildrenCol(ref objCellCol, strCell, objBiz);
                    }
                }
            }
        }
        #endregion
        public virtual void Add(CellBiz objCellBiz)
        {

            int intIndex = GetIndex(objCellBiz);
            if (intIndex == -1)
            {
                _NodeNo++;
                this.List.Add(objCellBiz);
                //_NodeNo = _NodeNo + objCellBiz.Children._NodeNo;
            }
            else
            {

                this[intIndex].Children.Add(objCellBiz.Children);
                // _NodeNo = _NodeNo + objCellBiz.Children._NodeNo;
            }
        }
        public virtual void Add(CellCol objCellCol)
        {
            foreach (CellBiz objCellBiz in objCellCol)
            {
                this.Add(objCellBiz);
            }
        }
        public bool Contains(CellBiz objcellBiz)
        {
            foreach (CellBiz objTemp in this)
            {
                if (objTemp.ID == objcellBiz.ID)
                    return true;
            }
            return false;
        }
        public int GetIndex(CellBiz objCellBiz)
        {

            CellBiz objBiz;
            for (int intIndex = 0; intIndex < Count; intIndex++)
            {
                objBiz = this[intIndex];
                if (objBiz == objCellBiz)
                    return intIndex;
                if (objCellBiz.ID == objBiz.ID)
                {

                    if (objBiz.ID == 0)
                    {
                        if (objBiz.Name == objCellBiz.Name)
                            return intIndex;


                    }
                    else
                        return intIndex;
                }

            }
            return -1;
        }

        public CellCol Copy()
        {
            CellCol Returned = new CellCol(true);
            foreach (CellBiz objTemp in this)
            {
                Returned.Add(objTemp.Copy());
            }
            return Returned;
        }
        public CellCol GetCellCol(string strCellName)
        {

            CellCol Returned = new CellCol(true);
            foreach (CellBiz objCellbiz in this)
            {
                SetChildrenCol(ref Returned, strCellName, objCellbiz);
            }
            return Returned;
        }

        public DataTable GetTable()
        {
            DataTable dtReturned = new DataTable("TempCell");
            dtReturned.Columns.AddRange(new DataColumn[] { new DataColumn("CellID"), new DataColumn("CellNameA") ,new DataColumn("CostCenterID")});
            DataRow objDr;
            foreach (CellBiz objBiz in this)
            {

                objDr = dtReturned.NewRow();

                objDr["CellID"] = objBiz.ID;
                objDr["CellNameA"] = objBiz.Name;
                objDr["CostCenterID"] = objBiz.CostCenterBiz.ID;
                dtReturned.Rows.Add(objDr);
            }
            return dtReturned;

        }
        public void EditDeliverDate(bool blIsDelivered,DateTime dtDeliver)
        {
            CellDb objDb = new CellDb();
            objDb.IDsStr = CurrentIDsStr;
            objDb.IsDelivered = blIsDelivered;
            objDb.DeliverDate = dtDeliver;
            objDb.EditDeliverDate();
        }
        public void EditEstimatedDeliverDate(bool blIsEstimatedDelivered, DateTime dtDeliver)
        {
            CellDb objDb = new CellDb();
            objDb.IDsStr = CurrentIDsStr;
            objDb.IsEstimatedDeliver = blIsEstimatedDelivered;
            objDb.EstimatedDeliverDate = dtDeliver;
            objDb.EditEstimatedDeliverDate();
        }
        public void EditCostCenter()
        {
            CellDb objDb = new CellDb();
            objDb.CostCenterTable = GetTable();
            objDb.EditCostCenter();
        }
        public void JoinAccount()
        { 
        }
    }
}