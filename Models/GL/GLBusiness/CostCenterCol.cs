using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using SharpVision.Base.BaseDataBase;
using SharpVision.Base.BaseBusiness;
using SharpVision.GL.GLDataBase;
using SharpVision.SystemBase;

namespace SharpVision.GL.GLBusiness
{
    public class CostCenterCol : BaseCol
    {
        #region Private Data
        Hashtable _TempCostCenterTable = new Hashtable();
        #endregion
        //public CostCenterCol()
        //{
        //    CostCenterDb objCostCenterDb = new CostCenterDb();
        //    DataTable dtCostCenter = objCostCenterDb.Search();
        //    //DataRow[] arrDR = dtCostCenter.Select("CostCenterID=CostCenterParentID ");
        //    DataRow[] arrDR;
        //    arrDR = dtCostCenter.Select("");
        //    CostCenterBiz objCostCenterBiz;
        //    CostCenterBiz objTempParent = new CostCenterBiz();

        //    foreach (DataRow DR in arrDR)
        //    {

        //        objCostCenterBiz = new CostCenterBiz(DR);


        //        //SetChildren(ref objCostCenterBiz, ref dtCostCenter);
        //        this.Add(objCostCenterBiz);
        //        //objCostCenterBiz.ParentBiz = objCostCenterBiz;

        //    }
        //}
        public CostCenterCol()
        {
            CostCenterDb objCostCenterDb = new CostCenterDb();
            DataTable dtCostCenter = objCostCenterDb.Search();
            DataColumn dcTemp = dtCostCenter.Columns["CostCenterParentID"];
           
            //dtCostCenter.Columns["CostCenterOrder"].DataType = Type.GetType("System.Int");
            string strOrder = "";
            DataRow[] arrDR = dtCostCenter.Select(" CostCenterID=CostCenterParentID ", strOrder);
            CostCenterBiz objCostCenterBiz;
            CostCenterBiz objTempParent = new CostCenterBiz();
            string strCostCenterIDs = "";
            foreach (DataRow DR in arrDR)
            {

                objCostCenterBiz = new CostCenterBiz(DR);
                if (_TempCostCenterTable[objCostCenterBiz.ID.ToString()] != null)
                    continue;
                if (strCostCenterIDs != "")
                    strCostCenterIDs += ",";
                strCostCenterIDs = strCostCenterIDs + objCostCenterBiz.ID.ToString();
                Add(objCostCenterBiz);
                objCostCenterBiz.ParentBiz = objTempParent;
                objCostCenterBiz.Children = new CostCenterCol(true);
                _TempCostCenterTable.Add(objCostCenterBiz.ID.ToString(), objCostCenterBiz);


            }
            SetChildren(strCostCenterIDs, ref dtCostCenter);
        }
        public CostCenterCol(bool blIsempty)
        {
            if (blIsempty)
                return;

            CostCenterDb objCostCenterDb = new CostCenterDb();
            DataTable dtCostCenter = objCostCenterDb.Search();
            DataRow[] arrDR = dtCostCenter.Select("CostCenterID=CostCenterParentID ");
            CostCenterBiz objCostCenterBiz;
            objCostCenterBiz = new CostCenterBiz();
            objCostCenterBiz.NameA = "غير محدد";
            Add(objCostCenterBiz);
            CostCenterBiz objTempParent = new CostCenterBiz();

            foreach (DataRow DR in arrDR)
            {

                objCostCenterBiz = new CostCenterBiz(DR);


                SetChildren(ref objCostCenterBiz, ref dtCostCenter);
                this.Add(objCostCenterBiz);
                objCostCenterBiz.ParentBiz = objCostCenterBiz;

            }
        }
        public CostCenterCol(CostCenterBiz objParentCostCenter)
        {
            if (objParentCostCenter == null)
                objParentCostCenter = new CostCenterBiz();
            CostCenterDb objDb = new CostCenterDb();
            objDb.ParentID = objParentCostCenter.ID;
            if (objParentCostCenter.ID == 0)
                objDb.OnlyFamily = true;
            DataTable dtTemp = objDb.Search();
            CostCenterBiz objBiz;
            foreach (DataRow objDr in dtTemp.Rows)
            {
                objBiz = new CostCenterBiz(objDr);
                objBiz.ParentBiz = objParentCostCenter;
                Add(objBiz);
            }
        }



        public CostCenterCol(string strCode, string strName, CostCenterBiz ParentBiz, int intStatus, int intDirection, int intType, int intSecondry)
        {
            CostCenterDb objDb = new CostCenterDb();
            objDb.Code = strCode;
            objDb.NameA = strName;
            if (ParentBiz == null)
                ParentBiz = new CostCenterBiz();
            objDb.ParentID = ParentBiz.ID;
            if (intStatus == 2)
                objDb.StatusDetermined = 2;

            if (intDirection < 2)
                objDb.DirectionDetermined = intDirection;

            objDb.SecondryDetermined = intSecondry;
            DataTable dtTemp = objDb.Search();

            foreach (DataRow objDr in dtTemp.Rows)
            {
                Add(new CostCenterBiz(objDr));
            }
        }
        #region Private Method
        void SetLinearCol(ref CostCenterCol objCostCenterCol, CostCenterBiz objCostCenterBiz)
        {
            objCostCenterCol.Add(objCostCenterBiz);
            if (objCostCenterBiz.Children == null || objCostCenterBiz.Children.Count == 0)
                return;
            foreach (CostCenterBiz objBiz in objCostCenterBiz.Children)
            {
                SetLinearCol(ref objCostCenterCol, objBiz);
            }
        }
        void SetChildren(string strCostCenterIDs, ref DataTable dtCostCenters)
        {
            if (strCostCenterIDs == "")
                return;
            CostCenterBiz objParentCostCenterBiz;
            DataRow[] arrDR = dtCostCenters.Select("CostCenterID <> CostCenterParentID " +
                " and CostCenterParentID in (" + strCostCenterIDs + ") ", "");
            int intLevel = 0;
            CostCenterBiz objCostCenterBiz;
            CostCenterCol objCostCenterCol;
            objCostCenterCol = new CostCenterCol(true);
            strCostCenterIDs = "";
            foreach (DataRow DR in arrDR)
            {
                objCostCenterBiz = new CostCenterBiz(DR);
                intLevel = objCostCenterBiz.Level;
                if (_TempCostCenterTable[objCostCenterBiz.ID.ToString()] != null)
                    continue;
                if (strCostCenterIDs != "")
                    strCostCenterIDs = strCostCenterIDs + ",";
                strCostCenterIDs = strCostCenterIDs + objCostCenterBiz.ID.ToString();
                objParentCostCenterBiz = (CostCenterBiz)_TempCostCenterTable[objCostCenterBiz.ParentID.ToString()];
                objParentCostCenterBiz.Children.Add(objCostCenterBiz);
                objCostCenterBiz.Children = new CostCenterCol(true);
                _TempCostCenterTable.Add(objCostCenterBiz.ID.ToString(), objCostCenterBiz);
                objCostCenterBiz.ParentBiz = objParentCostCenterBiz;
            }
            if(intLevel < SysData.CostCenterCodeLevelArr.Count)
            SetChildren(strCostCenterIDs, ref dtCostCenters);

        }
        void SetChildren(ref CostCenterBiz objCostCenterBiz, ref DataTable dtCostCenters)
        {
            objCostCenterBiz.Children = new CostCenterCol(true);
            //objCostCenterBiz.Children.RootBiz = objCostCenterBiz;
            DataRow[] arrDR = dtCostCenters.Select("CostCenterID <> CostCenterParentID and CostCenterParentID=" + objCostCenterBiz.ID);
            CostCenterBiz tempCostCenterBiz;
            CostCenterCol objCostCenterCol;
            objCostCenterCol = new CostCenterCol(true);
            int intTemp = 0;

            foreach (DataRow DR in arrDR)
            {

                tempCostCenterBiz = new CostCenterBiz(DR);

                if (intTemp == tempCostCenterBiz.ID)
                    continue;
                else
                {

                    intTemp = tempCostCenterBiz.ID;
                    SetChildren(ref tempCostCenterBiz, ref dtCostCenters);
                    tempCostCenterBiz.ParentBiz = objCostCenterBiz;
                    objCostCenterCol.Add(tempCostCenterBiz);


                }
                objCostCenterBiz.Children = objCostCenterCol;

            }
        }
        void SetChildrenCol(ref CostCenterCol objCostCenterCol, string strCostCenter, CostCenterBiz objCostCenterBiz)
        {
            // strCostCenter = SysUtility.ReverseString(strCostCenter );
            string[] arrStr = strCostCenter.Split('-');
            if (arrStr.Length <= 1)
            {
                arrStr = strCostCenter.Split('%');
                bool blIsOk = true;

                blIsOk = true;
                foreach (string strTemp in arrStr)
                {
                    if (SysUtility.ReplaceStringComp(objCostCenterBiz.Name).IndexOf(
                        SysUtility.ReplaceStringComp(strTemp), StringComparison.OrdinalIgnoreCase) == -1 &&
                        SysUtility.ReplaceStringComp(objCostCenterBiz.Code).IndexOf(
                        SysUtility.ReplaceStringComp(strTemp), StringComparison.OrdinalIgnoreCase) == -1)
                    {
                        blIsOk = false;
                        break;

                    }
                }
                if (blIsOk)
                    objCostCenterCol.Add(objCostCenterBiz);
                else
                {
                    if (objCostCenterBiz.Children != null)
                    {
                        foreach (CostCenterBiz objBiz in objCostCenterBiz.Children)
                        {
                            SetChildrenCol(ref objCostCenterCol, strCostCenter, objBiz);
                        }
                    }
                }
            }
            else
            {
                int intL1 = 0;
                int intL2 = 0;
                int intL3 = 0;
                int intL4 = 0;
                if (arrStr.Length >= 1)
                {
                    try
                    {
                        intL1 = int.Parse(arrStr[0]);
                    }
                    catch { }
                }
                if (arrStr.Length >= 2)
                {
                    try
                    {
                        intL2 = int.Parse(arrStr[1]);
                    }
                    catch { }
                }
                if (arrStr.Length >= 3)
                {
                    try
                    {
                        intL3 = int.Parse(arrStr[2]);
                    }
                    catch { }
                }
                if (arrStr.Length >= 4)
                {
                    try
                    {
                        intL4 = int.Parse(arrStr[3]);
                    }
                    catch { }
                }
                int intLevel = 0;
                if (intL4 == 0 && intL3 == 0 && intL2 == 0)
                    intLevel = 1;
                else if (intL4 == 0 && intL3 == 0)
                    intLevel = 2;
                else if (intL4 == 0)
                    intLevel = 3;
                else
                    intLevel = 4;
                foreach (CostCenterBiz objbiz in objCostCenterBiz.Children)
                {
                    try
                    {



                        if (((intL1 == 0 || intL1 == int.Parse(objbiz.CodeL1)) && objbiz.Level == 1)
                            || ((intL2 == 0 || intL2 == int.Parse(objbiz.CodeL2)) && objbiz.Level == 2) ||
                            ((intL3 == 0 || intL3 == int.Parse(objbiz.CodeL3)) && objbiz.Level == 3)
                          )
                        {
                            if (intLevel == objbiz.Level)
                                objCostCenterCol.Add(objbiz);
                            SetChildrenCol(ref objCostCenterCol, strCostCenter, objbiz);
                        }

                    }
                    catch { }

                }
            }
        }
        #endregion
        public CostCenterBiz this[int intIndex]
        {

            get
            {
                return (CostCenterBiz)List[intIndex];
            }
        }
        public CostCenterCol LinearCol
        {
            get
            {
                CostCenterCol Returned = new CostCenterCol(true);
                foreach (CostCenterBiz objBiz in this)
                {
                    SetLinearCol(ref Returned, objBiz);
                }
                return Returned;
            }
        }
        public CostCenterCol NodeCol
        {
            get
            {
                CostCenterCol Returned = new CostCenterCol(true);
                CostCenterCol objLinearCol = LinearCol;
                foreach (CostCenterBiz objBiz in objLinearCol)
                {
                    if (objBiz.CostCenterLevel == 4)
                        Returned.Add(objBiz);
                }
                return Returned;
            }

        }
        public DataTable DataTable
        {
            get
            {
                return GetTable();
            }
        }
        public int GetIndex(int intID)
        {
            int intIndex = 0;
            foreach (CostCenterBiz objBiz in this)
            {

                if (objBiz.ID == intID)
                {
                    return intIndex;

                }
                intIndex++;
            }
            return -1;
        }

        public void Add(CostCenterBiz objBiz)
        {
            List.Add(objBiz);

        }
        public DataTable GetTable()
        {
            DataTable Returned = new DataTable();
            Returned.Columns.AddRange(new DataColumn[] { new DataColumn("CostCenterID"), new DataColumn("CostCenterCode"),
                new DataColumn("CostCenterLevel"), new DataColumn("CostCenterNameA"),new DataColumn("CostCenterNameE"),new DataColumn("CostCenterIsClosing"),
                new DataColumn("CostCenterIsSecondary"),new DataColumn("CostCenterIsLeaf"),new DataColumn("CostCenterFamilyID") ,new DataColumn("CostCenterParentID"),
                new DataColumn("CostCenterDirection"),new DataColumn("CostCenterStatus")});
            DataRow objDR;
            foreach (CostCenterBiz objCostCenterBiz in this)
            {
                objDR = Returned.NewRow();
                objDR["CostCenterID"] = objCostCenterBiz.ID;
                objDR["CostCenterCode"] = objCostCenterBiz.Code;
                objDR["CostCenterLevel"] = objCostCenterBiz.Level;
                objDR["CostCenterNameA"] = objCostCenterBiz.NameA;
                objDR["CostCenterNameE"] = objCostCenterBiz.NameE;
               
                objDR["CostCenterFamilyID"] = objCostCenterBiz.FamilyID;
                objDR["CostCenterParentID"] = objCostCenterBiz.ParentID;
              
                Returned.Rows.Add(objDR);
            }
            return Returned;
        }
        public CostCenterCol GetCostCenterCol(string strCode, string strName)
        {
            CostCenterCol Returned = new CostCenterCol(true);
            foreach (CostCenterBiz objBiz in this)
            {
                if (objBiz.Name.IndexOf(strName) != -1 && objBiz.Code.IndexOf(strCode) != -1)
                    Returned.Add(objBiz);
            }
            return Returned;
        }
        public CostCenterCol GetCostCenterCol(string strCostCenterName)
        {

            CostCenterCol Returned = new CostCenterCol(true);
            //strCostCenterName = SysUtility.ReverseString(strCostCenterName);
            string strReverseName = strCostCenterName;
            string[] arrStr = strReverseName.Split('-');
            bool blIsOk = true;
            
            if (arrStr.Length <= 1)
            {
                arrStr = strCostCenterName.Split('%');

                foreach (CostCenterBiz objCostCenterbiz in this)
                {
                    blIsOk = true;
                   
                    foreach (string strTemp in arrStr)
                    {
                        if (SysUtility.ReplaceStringComp(objCostCenterbiz.Name).IndexOf(
                            SysUtility.ReplaceStringComp(strTemp),StringComparison.OrdinalIgnoreCase) == -1 &&
                            SysUtility.ReplaceStringComp(objCostCenterbiz.Code).IndexOf(
                            SysUtility.ReplaceStringComp(strTemp), StringComparison.OrdinalIgnoreCase) == -1)
                        {
                            blIsOk = false;
                            break;

                        }
                      
                         
                    }
                    if (blIsOk)
                        Returned.Add(objCostCenterbiz);
                    else
                        SetChildrenCol(ref Returned, strCostCenterName, objCostCenterbiz);
                }
            }
            else
            {
                int intL1 = 0;
                int intL2 = 0;
                int intL3 = 0;
                int intL4 = 0;

                if (arrStr.Length >= 1)
                {
                    try
                    {
                        intL1 = int.Parse(arrStr[0]);
                    }
                    catch { }
                }
                if (arrStr.Length >= 2)
                {
                    try
                    {
                        intL2 = int.Parse(arrStr[1]);
                    }
                    catch { }
                }
                if (arrStr.Length >= 3)
                {
                    try
                    {
                        intL3 = int.Parse(arrStr[2]);
                    }
                    catch { }
                }
                if (arrStr.Length >= 4)
                {
                    try
                    {
                        intL4 = int.Parse(arrStr[3]);
                    }
                    catch { }
                }
                int intLevel = intL2 == 0 && intL3 == 0 && intL4 == 0 ? 1 : (intL3 == 0 && intL4 == 0 ? 2 : (intL4 == 0 ? 3 : 4));
                foreach (CostCenterBiz objCostCenterbiz in this)
                {
                    try
                    {
                        if (intL1 == int.Parse(objCostCenterbiz.CodeL1) && (intL2 == int.Parse(objCostCenterbiz.CodeL2) || intL2 == 0) &&
                                 (intL3 == int.Parse(objCostCenterbiz.CodeL3) || intL3 == 0))
                                 //&&
                                 //objCostCenterbiz.Level >= intLevel)
                            Returned.Add(objCostCenterbiz);
                        if ((intL1 == int.Parse(objCostCenterbiz.CodeL1) && objCostCenterbiz.Level == 1)
                            || (intL2 == int.Parse(objCostCenterbiz.CodeL2) && objCostCenterbiz.Level == 2) ||
                            (intL3 == int.Parse(objCostCenterbiz.CodeL3) && objCostCenterbiz.Level == 3)
                            )
                        {

                            SetChildrenCol(ref Returned, strReverseName, objCostCenterbiz);
                        }

                    }
                    catch { }

                }
            }
            return Returned;
        }
        public CostCenterCol GetCostCenterColByCode(string strCostCenterName)
        {

            CostCenterCol Returned = new CostCenterCol(true);
            strCostCenterName = SysUtility.ReverseString(strCostCenterName, char.Parse(""));
            string[] arrStr = strCostCenterName.Split('-');
            bool blIsOk = true;

            if (arrStr.Length > 0)
            {
                int intL1 = 0;
                int intL2 = 0;
                int intL3 = 0;
                int intL4 = 0;

                if (arrStr.Length >= 1)
                {
                    try
                    {
                        intL1 = int.Parse(arrStr[0]);
                    }
                    catch { }
                }
                if (arrStr.Length >= 2)
                {
                    try
                    {
                        intL2 = int.Parse(arrStr[1]);
                    }
                    catch { }
                }
                if (arrStr.Length >= 3)
                {
                    try
                    {
                        intL3 = int.Parse(arrStr[2]);
                    }
                    catch { }
                }
                if (arrStr.Length >= 4)
                {
                    try
                    {
                        intL4 = int.Parse(arrStr[3]);
                    }
                    catch { }
                }
                foreach (CostCenterBiz objCostCenterbiz in this)
                {
                    try
                    {
                      
                        if ((intL1 == int.Parse(objCostCenterbiz.CodeL1) && objCostCenterbiz.Level == 1)
                           && (intL2 == int.Parse(objCostCenterbiz.CodeL2) && objCostCenterbiz.Level == 2) &&
                            (intL3 == int.Parse(objCostCenterbiz.CodeL3) && objCostCenterbiz.Level == 3)
                            )
                        {
                            Returned.Add(objCostCenterbiz);
                            SetChildrenCol(ref Returned, strCostCenterName, objCostCenterbiz);
                        }

                    }
                    catch { }

                }
            }
            return Returned;
        }
        public CostCenterCol GetLevelCostCenterCol(int intLevel)
        {

            CostCenterCol Returned = new CostCenterCol(true);
            CostCenterCol objLinearCol = LinearCol;
            foreach (CostCenterBiz objBiz in objLinearCol)
            {
                if (objBiz.CostCenterLevel == intLevel)
                    Returned.Add(objBiz);
            }
            return Returned;


        }
        public CostCenterCol GetChildrenCol(string strCode)
        {

            CostCenterCol Returned = new CostCenterCol(true);
            CostCenterCol objLinearCol = LinearCol;
            CostCenterBiz objTemp = new CostCenterBiz();
            objTemp.Code = strCode ;

            int intLevel = objTemp.CostCenterLevel;


            string strCodeLevel = "";
            foreach (CostCenterBiz objBiz in objLinearCol)
            {
                if (objBiz.Code == "")
                    continue;
                strCodeLevel = SysData.GetCostCenterLevelFullCode(intLevel, objBiz.Code);
                if (objBiz.CostCenterLevel == intLevel +1 && strCodeLevel == strCode)
                    Returned.Add(objBiz);
            }
            return Returned;


        }
        public string GetNewCostCenterLevelCode(int intLevel)
        {
            string Returned = "";
            CostCenterCol objCol = GetLevelCostCenterCol(intLevel);
            double dblTemp = 0;
            double dblMax = 0;
            string strTempLevel = "";
            string strTempCode = "";
            foreach (CostCenterBiz objBiz in objCol)
            {
                try
                {
                    strTempLevel = SysData.GetCostCenterLevelCod(intLevel, objBiz.Code);
                    dblTemp = double.Parse(strTempLevel);
                    if (dblTemp > dblMax)
                    {
                        dblMax = dblTemp;
                        strTempCode = objBiz.Code;
                    }
                }
                catch
                {

                }
            }
            dblMax++;
            Returned = dblMax.ToString();
            return Returned;
        }
        public string GetNewCostCenterCode(int intLevel)
        {
            string Returned = "";
            CostCenterCol objCol = GetLevelCostCenterCol(intLevel);
            double dblTemp = 0;
            double dblMax = 0;
            string strTempLevel = "";
            string strTempCode = "";
            foreach (CostCenterBiz objBiz in objCol)
            {
                try
                {
                    strTempLevel = SysData.GetCostCenterLevelCod(intLevel, objBiz.Code);
                    dblTemp = double.Parse(strTempLevel);
                    if (dblTemp > dblMax)
                    {
                        dblMax = dblTemp;
                        strTempCode = objBiz.Code;
                    }
                }
                catch
                {

                }
            }
            for (int intIndex = 1; intIndex < intLevel; intIndex++)
            {

            }
            return Returned;
        }
        public static CostCenterCol GetLinearCostCenterCol()
        {
            CostCenterDb objCostCenterDb = new CostCenterDb();
            DataTable dtCostCenter = objCostCenterDb.Search();
            CostCenterCol Returned = new CostCenterCol(true);
            foreach (DataRow objDr in dtCostCenter.Rows)
            {
                Returned.Add(new CostCenterBiz(objDr));
            }
            return Returned;
        }

    }
}
