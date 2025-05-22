using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.HR.HRDataBase;
using SharpVision.Base.BaseBusiness;
using System.Data;
using System.Collections;
using SharpVision.SystemBase;
using System.Threading;
namespace SharpVision.HR.HRBusiness
{
    public class SectorCol : BaseCol
    {
        #region PrivateData
        SectorBiz _RootBiz;
        int _NodeNo;
        Hashtable _SectorHash = new Hashtable();
        int _Order = 0;
       // Hashtable _SectorHash = new Hashtable();
         static SectorCol _SectorCol;
         static object _SectorMonitor = new object();
        #endregion
        #region Constructor
        int _OrderVal = 1;
        static bool _ReorderVal;

        public static bool ReorderVal
        {
            get { return SectorCol._ReorderVal; }
            set { SectorCol._ReorderVal = value; }
        }
        
         
        public SectorCol()
        {
            SectorDb objSectorDb = new SectorDb();
            objSectorDb.DisManualSearch = false;
            //objSectorDb.ID = 108;
            DataTable dtSector = SectorDb.SectorTable;


            DataRow[] arrDR = dtSector.Select("SectorID=SectorParentID", "SectorOrderVal"); //SectorOrderVal
            SectorBiz objSectorBiz;
            SectorBiz objTempParent = new SectorBiz();
            objTempParent.IndexInChildern = 0;
            string strSectorIDs = "";
            int intOrder = 0;
            foreach (DataRow DR in arrDR)
            {

                objSectorBiz = new SectorBiz(DR);

                if (_SectorHash[objSectorBiz.ID.ToString()] != null)
                    continue;
                if (strSectorIDs != "")
                    strSectorIDs += ",";
                strSectorIDs = strSectorIDs + objSectorBiz.ID.ToString();
                //objSectorBiz.SectorOrderVal = _Order;
                Add(objSectorBiz);
                objSectorBiz.ParentBiz = objTempParent;
                objSectorBiz.Children = new SectorCol(true);
                _SectorHash.Add(objSectorBiz.ID.ToString(), objSectorBiz);
                _Order++;


            }
            SetChildren(strSectorIDs, ref dtSector);

        }
        
        internal SectorCol(int intSectorID, DataTable dtSector)
        {

            string strOrder = "";


            DataRow[] arrDR = dtSector.Select("SectorID<>" + intSectorID + " and SectorParentID=" + intSectorID + "  ", "SectorOrderVal");
            SectorBiz objSectorBiz;
            SectorBiz objTempParent = new SectorBiz();

            foreach (DataRow DR in arrDR)
            {
                objSectorBiz = new SectorBiz(DR);

                if (_NodeNo >= 100)
                    break;
                SetChildren(ref objSectorBiz, ref dtSector);
                this.Add(objSectorBiz);
                objSectorBiz.ParentBiz = objTempParent;

            }

        }

        public SectorCol(int intTypeID, string strSectorName,
            SectorBiz objParentBiz, bool blOnlyFamilies, bool blNoChildren)
        {
            DataTable dtTempSector = new DataTable();


            if (objParentBiz == null)
                objParentBiz = new SectorBiz();
            else if (objParentBiz.ID != 0 && !blOnlyFamilies)
            {
                SectorDb objTempSectorDb = new SectorDb();
                objTempSectorDb.ID = objParentBiz.ID;
                objTempSectorDb.SectorTableSearch = new DataTable();
                dtTempSector = objTempSectorDb.GetChildrenTable();
            }


            SectorDb objSectorDb = new SectorDb();


            objSectorDb.TypeID = intTypeID;
            objSectorDb.NameLike = strSectorName;
            objSectorDb.OnlyFamilies = blOnlyFamilies;
            objSectorDb.NoChildren = blNoChildren;
            if (objParentBiz.ID != 0 && !blOnlyFamilies)
            {
                objSectorDb.ParentID = objParentBiz.ID;
                objSectorDb.SectorTableSearch = dtTempSector;
            }
            DataTable dtSector;

            dtSector = objSectorDb.GetAllSector();
            
            FillCachSectorAdminTable(dtSector);
            if (dtSector.Rows.Count == 0)
                return;
            int intTemp = 0;

            string strOrder = "SectorOrder";
            DataRow[] arrDR = dtSector.Select("SectorID=SectorParentID", "SectorOrderVal");
            SectorBiz objSectorBiz;
            SectorBiz objTempParent = new SectorBiz();
            foreach (DataRow DR in arrDR)
            {

                objSectorBiz = new SectorBiz(DR);

                if (intTemp == objSectorBiz.ID)
                    continue;
                else
                {

                    intTemp = objSectorBiz.ID;
                }
                if (_NodeNo >= 100)
                    break;
                SetChildren(ref objSectorBiz, ref dtSector);
                this.Add(objSectorBiz);
                objSectorBiz.ParentBiz = objTempParent;

            }

        }
        public SectorCol(bool blIsEmpty)
        {
            if (!blIsEmpty)
            {
                SectorBiz objBiz = new SectorBiz();
                objBiz.NameA = "غير محدد";
                objBiz.NameE = "Not Specified";
                Add(objBiz);
                SectorDb objSectorDb = new SectorDb();

                objSectorDb.OnlyFamilies = true;
                DataTable dtTemp = objSectorDb.Search();
                FillCachSectorAdminTable(dtTemp);
                foreach (DataRow objDr in dtTemp.Rows)
                {
                    Add(new SectorBiz(objDr));
                }
            }

            
        }

        public SectorCol(bool blIsEmpty, bool blSetSectorAdmin)
        {
            if (!blIsEmpty)
            {
                SectorBiz objBiz = new SectorBiz();
                objBiz.NameA = "غير محدد";
                objBiz.NameE = "Not Specified";
                Add(objBiz);
                SectorDb objSectorDb = new SectorDb();

                objSectorDb.OnlyFamilies = true;
                DataTable dtTemp = objSectorDb.Search();
                int intx = dtTemp.Rows.Count;
                if (blSetSectorAdmin)
                    FillCachSectorAdminTable(dtTemp);
                foreach (DataRow objDr in dtTemp.Rows)
                {
                    if (blSetSectorAdmin)
                        Add(new SectorBiz(objDr));
                    else
                        Add(new SectorBiz(objDr, false),false);
                }
            }
        }
        public SectorCol(int intSectorID)
        {
            SectorDb objSectorDb = new SectorDb();
            DataTable dtSector = objSectorDb.Search();
            FillCachSectorAdminTable(dtSector);

            string strOrder = "SectorOrder";

            DataRow[] arrDR = dtSector.Select("SectorID=" + intSectorID);
            SectorBiz objSectorBiz;
            SectorBiz objTempParent = new SectorBiz();
            foreach (DataRow DR in arrDR)
            {
                objSectorBiz = new SectorBiz(DR);

                SetChildren(ref objSectorBiz, ref dtSector);
                this.Add(objSectorBiz);
                if (_NodeNo >= 100)
                    break;
                objSectorBiz.ParentBiz = objTempParent;

            }

        }
        public SectorCol(string StrCond)//SectorParentID = SectorFamilyID
        {
            SectorDb objSectorDb = new SectorDb();            
            DataTable dtSector = objSectorDb.Search();
            FillCachSectorAdminTable(dtSector);


            DataRow[] arrDR = dtSector.Select(StrCond);
            SectorBiz objSectorBiz;
            SectorBiz objTempParent = new SectorBiz();

            foreach (DataRow DR in arrDR)
            {

                objSectorBiz = new SectorBiz(DR);

               
                this.Add(objSectorBiz);
                objSectorBiz.ParentBiz = objTempParent;
            }

        }
        #endregion
        public virtual SectorBiz this[int intIndex]
        {
            get
            {
                return (SectorBiz)this.List[intIndex];
            }
        }
        public virtual SectorBiz this[string strIndex]
        {
            get
            {
                SectorBiz Returned = new SectorBiz();
                if (_SectorHash[strIndex] != null)
                    Returned = (SectorBiz)_SectorHash[strIndex];
                return Returned;
            }
        }
        public string IDsStr
        {
            get
            {
                string Returned = "";
                foreach(SectorBiz objBiz in this)
                {
                    if (Returned != "")
                        Returned += ",";
                    Returned += objBiz.IDsStr;
                }
                return Returned;
            }
        }
        public string FlatIDs
        {
            get
            {
                string Returned = "";
                foreach (SectorBiz objBiz in this)
                {
                    if (Returned != "")
                        Returned += ",";
                    Returned += objBiz.ID.ToString();
                }
                return Returned;
            }
        }
        public string FamilyIDs
        {
            get
            {
                string Returned = "";
                foreach (SectorBiz objBiz in this)
                {
                    if (objBiz.ParentID == objBiz.ID)
                    {
                        if (Returned != "")
                            Returned += ",";
                        Returned += objBiz.ID.ToString();
                    }
                }
                return Returned;
            }
        }
        public SectorBiz RootBiz
        {
            set
            {
                _RootBiz = value;
            }
        }
        public string AdminIDs
        {
            get
            {
                string strIDs = "";
                foreach (SectorBiz objBiz in this)
                {
                    if (objBiz.SectorAdminBiz != null && objBiz.SectorAdminBiz.ID != 0)
                    {
                        if (strIDs != "")
                            strIDs = strIDs + ",";
                        strIDs = strIDs + objBiz.SectorAdminBiz.ID.ToString();
                    }
                }
                return strIDs;
            }
        }
        public string AdminSectorPayRollIDs
        {
            get
            {
                string strIDs = "";
                foreach (SectorBiz objBiz in this)
                {
                    if (objBiz.SectorAdminBiz != null && objBiz.SectorAdminBiz.ID != 0 && objBiz.IsInPayRollSectors==true)
                    {
                        if (strIDs != "")
                            strIDs = strIDs + ",";
                        strIDs = strIDs + objBiz.SectorAdminBiz.ID.ToString();
                    }
                }
                string strTemp = "";
                foreach (SectorBiz objBiz in this)
                {

                    strTemp = objBiz.Children.AdminSectorPayRollIDs;
                    if (strTemp != "")
                    {
                        if (strIDs != "")
                            strIDs = strIDs + ",";
                        strIDs += strTemp;
                    }
                 
                }

                return strIDs;
            }
        }
        public int AdminSectorPayRollCount
        {
            get
            {
                int intCount = 0;
                foreach (SectorBiz objBiz in this)
                {
                    if (objBiz.SectorAdminBiz != null && objBiz.SectorAdminBiz.ID != 0 && objBiz.IsInPayRollSectors == true)
                    {
                        intCount++;
                    }
                }
                foreach (SectorBiz objBiz in this)
                {

                    intCount  += objBiz.Children.AdminSectorPayRollCount;                   
                }
                return intCount;
            }
        }
        public SectorCol LinearCol
        {
            get
            {
                SectorCol Returned = new SectorCol(true);
                
                foreach (SectorBiz objBiz in this)
                {
                    Returned.Add(objBiz);
                    if (objBiz.Children != null && objBiz.Children.Count != 0)
                        Returned.Add(objBiz.Children.LinearCol);
                }
                return Returned;
            }
        }
        public static SectorCol CacheSectorCol
        {
            get
            {
                Monitor.Enter(_SectorMonitor);
                if (_SectorCol == null)
                    _SectorCol = new SectorCol();
                Monitor.Exit(_SectorMonitor);
                return _SectorCol;
            }
        }
        #region  Privaet methods
        void SetChildren(string strSectorIDs, ref DataTable dtSectors)
        {
            if (strSectorIDs == "")
                return;
            SectorBiz objParentSectorBiz;
            DataRow[] arrDR = dtSectors.Select("SectorID <> SectorParentID " +
                " and SectorParentID in (" + strSectorIDs + ") ", "SectorOrderVal");
            SectorBiz objSectorBiz;
            SectorCol objSectorCol;
            objSectorCol = new SectorCol(true);
            strSectorIDs = "";
            foreach (DataRow DR in arrDR)
            {
                objSectorBiz = new SectorBiz(DR);
                //objSectorBiz.SectorOrderVal = _Order;
                if (_SectorHash[objSectorBiz.ID.ToString()] != null)
                    continue;
                if (strSectorIDs != "")
                    strSectorIDs = strSectorIDs + ",";
                strSectorIDs = strSectorIDs + objSectorBiz.ID.ToString();
                objParentSectorBiz = (SectorBiz)_SectorHash[objSectorBiz.ParentID.ToString()];
                objParentSectorBiz.Children.Add(objSectorBiz);
                objSectorBiz.Children = new SectorCol(true);
                _SectorHash.Add(objSectorBiz.ID.ToString(), objSectorBiz);
                objSectorBiz.ParentBiz = objParentSectorBiz;
                _Order++;
            }
            SetChildren(strSectorIDs, ref dtSectors);

        }
        void SetChildrenCol(ref SectorCol objSectorCol, string strSector, SectorBiz objSectorBiz)
        {
            if (objSectorBiz.Name.CheckStr(strSector))//, StringComparison.OrdinalIgnoreCase) != -1)
                objSectorCol.Add(objSectorBiz);
            else
            {
                if (objSectorBiz.Children != null)
                {
                    foreach (SectorBiz objBiz in objSectorBiz.Children)
                    {
                        SetChildrenCol(ref objSectorCol, strSector, objBiz);
                    }
                }
            }
        }
        void SetChildren(ref SectorBiz objSectorBiz, ref DataTable dtSectors)
        {
            objSectorBiz.Children = new SectorCol(true);
            objSectorBiz.Children.RootBiz = objSectorBiz;
            DataRow[] arrDR = dtSectors.Select(" SectorID <> SectorParentID and SectorParentID=" + objSectorBiz.ID, "SectorOrderVal");//SectorOrderVal
            SectorBiz tempSectorBiz;
            SectorCol objSectorCol;
            objSectorCol = new SectorCol(true);
            int intTemp = 0;
            int intIndex = 0;
            
            foreach (DataRow DR in arrDR)
            {

                tempSectorBiz = new SectorBiz(DR);
                if (_ReorderVal)
                {
                    tempSectorBiz.UpdateOrderVal(tempSectorBiz.ID, _OrderVal);
                    _OrderVal++;
                }
                tempSectorBiz.IndexInChildern = intIndex;
                if (intTemp == tempSectorBiz.ID)
                    continue;
                else
                {

                    intTemp = tempSectorBiz.ID;

                }
               
                SetChildren(ref tempSectorBiz, ref dtSectors);
                tempSectorBiz.ParentBiz = objSectorBiz;
                objSectorCol.Add(tempSectorBiz);
                intIndex++;
            }
            objSectorBiz.Children = objSectorCol;

        }
        static void FillCachSectorAdminTable(DataTable dtSector)
        {
            DataRow[] arrDR;
            arrDR = dtSector.Select("", "SectorAdmin");
            string strTempSectorAdmin = "";
            string strSectorAdminIDs = "";
            foreach (DataRow objDr in arrDR)
            {
                if (objDr["SectorAdmin"].ToString() != "0")
                {
                    if (strTempSectorAdmin != objDr["SectorAdmin"].ToString())
                    {
                        if (strSectorAdminIDs != "")
                            strSectorAdminIDs += ",";
                        strSectorAdminIDs += objDr["SectorAdmin"].ToString();
                        strTempSectorAdmin = objDr["SectorAdmin"].ToString();
                    }
                }
            }

            ApplicantWorkerDb objApplicantWorkerDb = new ApplicantWorkerDb();
            objApplicantWorkerDb.IDs = strSectorAdminIDs;

            SectorDb.CachSectorAdminTable = objApplicantWorkerDb.Search();
        }
        //void SetChildrenCol(ref SectorCol objSectorCol, string strSector, SectorBiz objSectorBiz)
        //{
        //    if (objSectorBiz.Name.IndexOf(strSector) != -1)
        //        objSectorCol.Add(objSectorBiz);
        //    else
        //    {
        //        if (objSectorBiz.Children != null)
        //        {
        //            foreach (SectorBiz objBiz in objSectorBiz.Children)
        //            {
        //                SetChildrenCol(ref objSectorCol, strSector, objBiz);
        //            }
        //        }
        //    }
        //}
        public static void SetLinearCol(SectorCol objSectorCol, ref SectorCol objDesCol)
        {
            if (objDesCol == null)
                return;
            foreach (SectorBiz objBiz in objSectorCol)
            {
                objDesCol.Add(objBiz);
                SetLinearCol(objBiz.Children, ref objDesCol);


            }
        }
        #endregion
        public void ReOrderSector()
        { 
            SectorCol objCol = LinearCol;
            for (int intOrder = 0; intOrder < objCol.Count; intOrder++)
            {
                objCol[intOrder].SectorOrderVal = intOrder;
            }
        }
        public virtual void Add(SectorBiz objSectorBiz)
        {

            SectorBiz objBiz = new SectorBiz();
            if(_SectorHash[objSectorBiz.ID.ToString()]!= null)
            objBiz = (SectorBiz)_SectorHash[objSectorBiz.ID.ToString()];
            if (objBiz.ID==0)
            {
                //_NodeNo++;
                this.List.Add(objSectorBiz);
               // _NodeNo = _NodeNo + objSectorBiz.Children._NodeNo;
            }
            else
            {

                objBiz.Children.Add(objSectorBiz.Children);
                //_NodeNo = _NodeNo + objSectorBiz.Children._NodeNo;
            }
        }
        public virtual void Add(SectorBiz objSectorBiz, bool blSetChild)
        {
            if (blSetChild)
            {
                int intIndex = GetIndex(objSectorBiz);
                if (intIndex == -1)
                {
                    _NodeNo++;
                    this.List.Add(objSectorBiz);
                    _NodeNo = _NodeNo + objSectorBiz.Children._NodeNo;
                }
                else
                {

                    this[intIndex].Children.Add(objSectorBiz.Children);
                    _NodeNo = _NodeNo + objSectorBiz.Children._NodeNo;
                }
            }
            else
                this.List.Add(objSectorBiz);
        }
        public virtual void Add(SectorCol objSectorCol)
        {
            foreach (SectorBiz objSectorBiz in objSectorCol)
            {
                this.Add(objSectorBiz);
            }
        }
        public bool Contains(SectorBiz objcellBiz)
        {
            foreach (SectorBiz objTemp in this)
            {
                if (objTemp.ID == objcellBiz.ID)
                    return true;
            }
            return false;
        }
        public int GetIndex(SectorBiz objSectorBiz)
        {

            SectorBiz objBiz;
            for (int intIndex = 0; intIndex < Count; intIndex++)
            {
                objBiz = this[intIndex];
                if (objBiz == objSectorBiz)
                    return intIndex;
                if (objSectorBiz.ID == objBiz.ID)
                {

                    if (objBiz.ID == 0)
                    {
                        if (objBiz.Name == objSectorBiz.Name)
                            return intIndex;


                    }
                    else
                        return intIndex;
                }

            }
            return -1;
        }
        public SectorCol GetSectorCol(string strSectorName)
        {

            SectorCol Returned = new SectorCol(true);
            foreach (SectorBiz objSectorbiz in this)
            {
                SetChildrenCol(ref Returned, strSectorName, objSectorbiz);
            }
            return Returned;
        }        
        public SectorCol Copy()
        {
            SectorCol Returned = new SectorCol(true);
            foreach (SectorBiz objTemp in this)
            {
                Returned.Add(objTemp.Copy());
            }
            return Returned;
        }
        public void EditOrder()
        {
            DataTable dtTemp = new DataTable();
            dtTemp.Columns.AddRange(new DataColumn[] { new DataColumn("SectorID"),new DataColumn("SectorOrder"),
                new DataColumn("SectorName")});
            SectorCol objCol = new SectorCol(true);
            SetLinearCol(this, ref objCol);
            DataRow objDr;
            int intX = 0;
            DataRow[] arrTemp;
            foreach (SectorBiz objBiz in objCol)
            {
                objDr = dtTemp.NewRow();
                arrTemp = SectorDb.SectorTable.Select("SectorID=" + objBiz.ID, "");
                if (arrTemp.Length > 0)
                    arrTemp[0]["SectorOrderVal"] = objBiz.SectorOrderVal; 
                objDr["SectorID"] = objBiz.ID;
                objDr["SectorOrder"] = objBiz.SectorOrderVal;
                objDr["SectorName"] = objBiz.Name;
                if (objBiz.ID == 49)
                    intX = objBiz.SectorOrderVal;

                dtTemp.Rows.Add(objDr);
                
            }

            SectorDb objDb = new SectorDb();
            objDb.SectorOrderTable = dtTemp;
            objDb.ReOrderSector();




        }

    }
}