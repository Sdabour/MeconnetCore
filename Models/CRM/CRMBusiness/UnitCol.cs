using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.UMS.UMSBusiness;
using SharpVision.CRM.CRMDataBase;
using System.Data;
using System.Collections;
using SharpVision.Base.BaseBusiness;
using SharpVision.RP.RPBusiness;
using SharpVision.RP.RPDataBase;
using SharpVision.SystemBase;
using System.Linq;
namespace SharpVision.CRM.CRMBusiness
{
    public enum PriceValueType
    {
        Value,
        Perc,
        Fracture
    }
    public class UnitCol : BaseCol
    {
        #region Private Data
        int _MaxCount = 1500;
        int _ResultCount = 0;
        int _TheMinID;
        int _MaxID;
        int _MinID;
        int _CurrentIndex;
        bool _EnableNext;
        bool _EnablePrevious;
        CellBiz _CellBiz;
        UnitModelBiz _ModelBiz;
        UnitUsageTypeBiz _UsageTypeBiz = new UnitUsageTypeBiz();
        CustomerCol _CustomerCol;
        string _CellName;
        string _CellTowerName;
        double _FromSuervy;
        double _ToSurevy;
        double _StartPeripheralSurvey;
        double _EndPeripheralSurvey;
        int _UserClose;
        string _FlatNo = "";
        string _FloorStr = "";
        double _StartPrice;
        double _EndPrice;
        PeripheralTypeBiz _PeripheralTypeBiz = new PeripheralTypeBiz();
        int _Status;
        string _ReservationStatus = "";
        int _CellOrder;
        UnitTypeBiz _UnittypeBiz;
        int _DeliveryStatus;
        int _CellTowerDeliveryStatus;
        bool _IsDeliveryDateRange;
        DateTime _StartDeliveryDate;
        DateTime _EndDeliveryDate;
        bool _IsCloseTimeRange;
        DateTime _CloseTimeStart;
        DateTime _CloseTimeEnd;
        string _UnitCodeStr;
        string _FloorIDs;
        string _TowerIDs;
        string _ProjectIDs;
        bool _IsPriceDateRange;
        DateTime _PriceDateStart;
        DateTime _PriceDateEnd;
        ResubmissionTypeCol _ResubmissionTypeCol = new ResubmissionTypeCol(true);
        //UnitAttributeCol _SelectedAttributeCol = new UnitAttributeCol(true);
        bool _IsAnding;

        double _TotalAttributeStart;
        double _TotalAttributeEnd;
        //UnitCategoryCol 
        #endregion
        int _NativeCount = 0;
        UnitCategoryCol _CategoryCol = new UnitCategoryCol(true);
        List<int> _CategoryGradeLst = new List<int>();
        public UnitCol(bool blIsempty)
        {

        }


        public UnitCol(CellBiz objCellBiz, UnitModelBiz objModelBiz,
            CustomerCol objCustomerCol, string strCellName, string strCellTowerName, double dblFromSuervy,
            double dblToSurevy, int intStatus, string strReservationStatus, int intCellOrder,
            UnitTypeBiz objUnittypeBiz, int intDeliveryStatus, int intCellTowerDeliveryStatus,
            bool blIsDeliveryDateRange, DateTime dtStartDelivery,
            DateTime dtEndDelivery, string strUnitCode, PeripheralTypeBiz objPeripheralType,
            double dblStartPeripheralSurvey, double dblEndPeripheralSurvey,
            int intUserClose, string strFlatNo,
            UnitUsageTypeBiz objUsageTypeBiz, string strFloor
            , double dblStartPrice, double dblEndPrice,
            string strProjectIDs
            , string strTowerIDs, string strFloorIDs
            , bool blIsPriceDateRange
            , DateTime dtPriceDateStart, DateTime dtPriceDateEnd, ResubmissionTypeCol objResubmissionTypeCol
            , 
        bool blIsAnding,

        double dblTotalAttributeStart,
        double dblTotalAttributeEnd
            , UnitCategoryCol objCategoryCol, List<int> arrCategoryGrade, bool blIsCloseTimeRange, DateTime dtCloseStart, DateTime dtCloseEnd)
        {

            
            if (objCellBiz == null)
                objCellBiz = new CellBiz();
            if (objModelBiz == null)
                objModelBiz = new UnitModelBiz();
            if (objCustomerCol == null)
                objCustomerCol = new CustomerCol(true);
            if (objUsageTypeBiz == null)
                objUsageTypeBiz = new UnitUsageTypeBiz();
            UnitDb objUnitDb = new UnitDb();
            
            _IsAnding = blIsAnding;
            _TotalAttributeStart = dblTotalAttributeStart;
            _TotalAttributeEnd = dblTotalAttributeEnd;
            _CategoryCol = objCategoryCol;
            if (arrCategoryGrade == null)
                arrCategoryGrade = new List<int>();
            _CategoryGradeLst = arrCategoryGrade;

            SetDataInitially(objCellBiz, objModelBiz, objCustomerCol, strCellName, strCellTowerName, dblFromSuervy,
                dblToSurevy, intStatus, strReservationStatus, intCellOrder,
                objUnittypeBiz, intDeliveryStatus, intCellTowerDeliveryStatus,
                blIsDeliveryDateRange, dtStartDelivery, dtEndDelivery, strUnitCode,
                objPeripheralType, dblStartPeripheralSurvey
                , dblEndPeripheralSurvey, intUserClose, strFlatNo,
                strFloor, dblStartPrice, dblEndPrice,
                strProjectIDs, strTowerIDs, strFloorIDs
                , blIsPriceDateRange, dtPriceDateStart, dtPriceDateEnd, objResubmissionTypeCol, blIsCloseTimeRange, dtCloseStart, dtCloseEnd);
            _UsageTypeBiz = objUsageTypeBiz;
            GetSearchData(ref objUnitDb);
            DataTable dtUnit = objUnitDb.Search();
            _NativeCount = objUnitDb.ResultCount;
            _ResultCount = objUnitDb.ResultCount;
            DataRow[] arrDr = dtUnit.Select("", "ProjectID,CellTowerID,MaxCellOrder,UnitOrder");
            foreach (DataRow objDr in arrDr)
            {
                Add(new UnitBiz(objDr));

            }


            if (Count > 0)
            {
                arrDr = dtUnit.Select("", "UnitID");
                objUnitDb = new UnitDb(arrDr[Count - 1]);
                _MaxID = objUnitDb.ID;
                objUnitDb = new UnitDb(arrDr[0]);
                _MinID = objUnitDb.ID;
                _TheMinID = _MinID;
            }
            _EnablePrevious = false;
            if (Count >= _MaxCount)
            {
                _EnableNext = true;
            }

            //Hashtable objHash = new Hashtable();
            //UnitBiz objUnitBiz;
            //foreach (DataRow objDR in dtUnit.Rows)
            //{
            //    objUnitBiz = new UnitBiz(objDR);
            //    if (objHash[objUnitBiz.ID.ToString()] == null)
            //    {
            //        objHash.Add(objUnitBiz.ID.ToString(), objUnitBiz.ID);
            //        this.Add(objUnitBiz);
            //    }
            //}
        }
        public UnitCol(CellBiz objCellBiz, UnitModelBiz objModelBiz,
         CustomerCol objCustomerCol, string strCellName, string strCellTowerName, double dblFromSuervy,
         double dblToSurevy, int intStatus, string strReservationStatus, int intCellOrder,
         UnitTypeBiz objUnittypeBiz, int intDeliveryStatus, int intCellTowerDeliveryStatus,
         bool blIsDeliveryDateRange, DateTime dtStartDelivery,
         DateTime dtEndDelivery, string strUnitCode, PeripheralTypeBiz objPeripheralType,
         double dblStartPeripheralSurvey, double dblEndPeripheralSurvey,
         int intUserClose, string strFlatNo,
         UnitUsageTypeBiz objUsageTypeBiz, string strFloor
         , double dblStartPrice, double dblEndPrice,
         string strProjectIDs
         , string strTowerIDs, string strFloorIDs
         )
        {


            if (objCellBiz == null)
                objCellBiz = new CellBiz();
            if (objModelBiz == null)
                objModelBiz = new UnitModelBiz();
            if (objCustomerCol == null)
                objCustomerCol = new CustomerCol(true);
            if (objUsageTypeBiz == null)
                objUsageTypeBiz = new UnitUsageTypeBiz();
            UnitDb objUnitDb = new UnitDb();

          

            SetDataInitially(objCellBiz, objModelBiz, objCustomerCol, strCellName, strCellTowerName, dblFromSuervy,
                dblToSurevy, intStatus, strReservationStatus, intCellOrder,
                objUnittypeBiz, intDeliveryStatus, intCellTowerDeliveryStatus,
                blIsDeliveryDateRange, dtStartDelivery, dtEndDelivery, strUnitCode,
                objPeripheralType, dblStartPeripheralSurvey
                , dblEndPeripheralSurvey, intUserClose, strFlatNo,
                strFloor, dblStartPrice, dblEndPrice,
                strProjectIDs, strTowerIDs, strFloorIDs
                , false, DateTime.Now, DateTime.Now, null, false, DateTime.Now, DateTime.Now);
            _UsageTypeBiz = objUsageTypeBiz;
            GetSearchData(ref objUnitDb);
            DataTable dtUnit = objUnitDb.Search();
            _NativeCount = objUnitDb.ResultCount;
            _ResultCount = objUnitDb.ResultCount;
            DataRow[] arrDr = dtUnit.Select("", "ProjectID,CellTowerID,MaxCellOrder,UnitOrder");
            foreach (DataRow objDr in arrDr)
            {
                Add(new UnitBiz(objDr));

            }


            if (Count > 0)
            {
                arrDr = dtUnit.Select("", "UnitID");
                objUnitDb = new UnitDb(arrDr[Count - 1]);
                _MaxID = objUnitDb.ID;
                objUnitDb = new UnitDb(arrDr[0]);
                _MinID = objUnitDb.ID;
                _TheMinID = _MinID;
            }
            _EnablePrevious = false;
            if (Count >= _MaxCount)
            {
                _EnableNext = true;
            }

            //Hashtable objHash = new Hashtable();
            //UnitBiz objUnitBiz;
            //foreach (DataRow objDR in dtUnit.Rows)
            //{
            //    objUnitBiz = new UnitBiz(objDR);
            //    if (objHash[objUnitBiz.ID.ToString()] == null)
            //    {
            //        objHash.Add(objUnitBiz.ID.ToString(), objUnitBiz.ID);
            //        this.Add(objUnitBiz);
            //    }
            //}
        }
        public UnitCol(CellBiz objCellBiz)
        {
            if (_CellBiz == null)
                _CellBiz = new CellBiz();
            UnitDb objUnitDb = new UnitDb();
            objUnitDb.CellFamilyID = objCellBiz.ID == objCellBiz.FamilyID ? objCellBiz.ID : 0;
            objUnitDb.CellIDs = objCellBiz.ID == objCellBiz.FamilyID ? "" : objCellBiz.IDsStr;
            //DataTable dtTemp = objDb.Search();
            DataTable dtUnit = objUnitDb.Search();
            _NativeCount = objUnitDb.ResultCount;
            _ResultCount = objUnitDb.ResultCount;
            DataRow[] arrDr = dtUnit.Select("", "MaxCellFamilyID,CellTowerOrder,CellTowerID,MaxCellOrder,MinCellID,UnitOrder");
            foreach (DataRow objDr in arrDr)
            {
                Add(new UnitBiz(objDr));

            }


            if (Count > 0)
            {
                arrDr = dtUnit.Select("", "UnitID");
                objUnitDb = new UnitDb(arrDr[Count - 1]);
                _MaxID = objUnitDb.ID;
                objUnitDb = new UnitDb(arrDr[0]);
                _MinID = objUnitDb.ID;
                _TheMinID = _MinID;
            }
            _EnablePrevious = false;
            if (Count >= _MaxCount)
            {
                _EnableNext = true;
            }

        }
        
        public UnitBiz this[int intIndex]
        {

            get
            {
                return (UnitBiz)List[intIndex];
            }
        }
        public string IDsStr
        {
            get
            {
                string Returned = "";
                foreach (UnitBiz objBiz in this)
                {
                    if (Returned != "")
                        Returned = Returned + ",";
                    Returned = Returned + objBiz.ID;
                }
                return Returned;
            }
        }
        public int NativeCount
        {
            get
            {
                return _NativeCount;
            }
        }
        public bool EnableNext
        {
            get
            {
                return _EnableNext;
            }
        }
        public bool EnablePrevious
        {
            get
            {
                return _EnablePrevious;
            }
        }
        public PeripheralTypeCol PeripheralTypeCol
    {
            get
            {
                PeripheralTypeCol Returned = new PeripheralTypeCol(true);
                var vrUnit = from objUnit in this.Cast<UnitBiz>()
                             where objUnit.PeripheralCol.Count > 0
                             orderby objUnit.TypeBiz.ID
                             select objUnit;
                Hashtable hsTemp = new Hashtable();
                foreach(UnitBiz objBiz in vrUnit)
                {
                    foreach(UnitPeripheralBiz objPeripheral in objBiz.PeripheralCol)
                    {
                        if(hsTemp[objPeripheral.TypeBiz.ID.ToString()]== null)
                        {
                            hsTemp.Add(objPeripheral.TypeBiz.ID.ToString(), "");
                            Returned.Add(objPeripheral.TypeBiz);
                        }

                    }
                }
                return Returned;
            }
        }
        public UnitCol OpenedCol
        {
            get
            {
                UnitCol Returned = new UnitCol(true);
                Hashtable hsTemp = new Hashtable();
                foreach(UnitBiz objBiz in this)
                {
                    if (objBiz.Status != 3 && objBiz.Status != 4 && objBiz.Status != 2)
                    {
                        if(hsTemp[objBiz.ID.ToString()]== null)
                        {
                        Returned.Add(objBiz);
                        hsTemp.Add(objBiz.ID.ToString(), objBiz);
                        }
                    }
                }
                return Returned;
            }
        }
        public UnitCol ClosedCol
        {
            get
            {
                UnitCol Returned = new UnitCol(true);
                Hashtable hsTemp = new Hashtable();
                foreach (UnitBiz objBiz in this)
                {
                    if ((objBiz.Status == 3 || objBiz.Status == 4) && objBiz.Status != 2)
                    {
                        if (hsTemp[objBiz.ID.ToString()] == null)
                        {
                            Returned.Add(objBiz);
                            hsTemp.Add(objBiz.ID.ToString(), objBiz);
                        }
                    }
                }
                return Returned;
            }
        }
        public CustomerCol CustomerCol
        {
            get
            {
                CustomerCol Returned = new CustomerCol(true);

                Hashtable hsTemp = new Hashtable();
                foreach (UnitBiz objBiz in this)
                {
                    if (objBiz.CurrentReservation.ID != 0)
                    {
                        foreach (CustomerBiz objCustomerBiz in objBiz.CurrentReservation.CustomerCol)
                        {
                            if(hsTemp[objCustomerBiz.ID.ToString()]== null)
                            hsTemp.Add(objCustomerBiz.ID.ToString(), objCustomerBiz);

                        }
                    }
                }
                foreach (object objKey in hsTemp.Keys)
                {
                    Returned.Add((CustomerBiz)hsTemp[objKey]);
                }
                return Returned;
            }
        }
        public ReservationCol ReservationCol
        {
            get
            {
                ReservationCol Returned = new ReservationCol(true);
                foreach (UnitBiz objBiz in this)
                {
                    if (objBiz.CurrentReservation.ID != 0)
                    {

                        Returned.Add(objBiz.CurrentReservation);
                    }
                }
                return Returned;
            }
        }
        #region Private Method
        void SetDataInitially(CellBiz objCellBiz, UnitModelBiz objModelBiz,
            CustomerCol objCustomerCol, string strCellName, string strCellTowerName, double dblFromSuervy,
            double dblToSurevy, int intStatus, string strReservationStatus, 
            int intCellOrder, UnitTypeBiz objUnittypeBiz,int intDeliveryStatus,int intCellTowerDeliveryStatus,
            bool blIsDeliveryDateRange,DateTime dtStartDelivery,DateTime dtEndDelivery,string strUnitCode,PeripheralTypeBiz objPeripheralType,
            double dblStartPeripheralSurvey,double dblEndPeripheralSurvey,
            int intUserClose,string strFlatNo,string strFloor,double dblStartPrice,double dblEndPrice
            , string strProjectIDs, string strTowerIDs, string strFloorIDs
            , bool blIsPriceDateRange, DateTime dtPriceDateStart
            , DateTime dtPriceDateEnd,ResubmissionTypeCol objResubmissionTypeCol, bool blIsCloseTimeRange, DateTime dtCloseStart, DateTime dtCloseEnd)
        {
            _CellBiz = objCellBiz;
            _ModelBiz = objModelBiz;
            _CustomerCol = objCustomerCol;
            _CellName = strCellName;
            _CellTowerName = strCellTowerName;
            _FromSuervy = dblFromSuervy;
            _ToSurevy = dblToSurevy;
            _Status = intStatus;
            _ReservationStatus = strReservationStatus;
            _CellOrder = intCellOrder;
            _UnittypeBiz = objUnittypeBiz;
            _DeliveryStatus = intDeliveryStatus;
            _StartDeliveryDate = dtStartDelivery;
            _EndDeliveryDate = dtEndDelivery;
            _IsDeliveryDateRange = blIsDeliveryDateRange;
            _CellTowerDeliveryStatus = intCellTowerDeliveryStatus;
            _UnitCodeStr = strUnitCode;
            _PeripheralTypeBiz = objPeripheralType;
            _StartPeripheralSurvey = dblStartPeripheralSurvey;
            _EndPeripheralSurvey = dblEndPeripheralSurvey;
            _UserClose = intUserClose;
            _FlatNo = strFlatNo;
            _FloorStr = strFloor;
            _StartPrice = dblStartPrice;
            _EndPrice = dblEndPrice;
            _ProjectIDs = strProjectIDs;
            _TowerIDs = strTowerIDs;
            _FloorIDs = strFloorIDs;
            _IsPriceDateRange = blIsPriceDateRange;
            _PriceDateStart = dtPriceDateStart;
            _PriceDateEnd = dtPriceDateEnd;
            _ResubmissionTypeCol = objResubmissionTypeCol;
            _IsCloseTimeRange = blIsCloseTimeRange;
            _CloseTimeStart = dtCloseStart;
            _CloseTimeEnd = dtCloseEnd;

        }
        public UnitCol GetUnitCol(string strUnit,FloorBiz objFloorBiz)
        {
            if (objFloorBiz == null)
                objFloorBiz = new FloorBiz();
            UnitCol Returned = new UnitCol(true);
            if (strUnit == null)
                strUnit = "";
            IEnumerable<UnitBiz> objUnitCol = from objUnit in this.Cast<UnitBiz>()
                                              where (strUnit == "" || objUnit.Name.CheckStr(strUnit)) 
                                              && (objFloorBiz.ID == 0 || objUnit.FloorBiz.ID == objFloorBiz.ID)
                                              select objUnit;
            foreach (UnitBiz objUnitBiz in objUnitCol)
                Returned.Add(objUnitBiz);
            return Returned;
        }
        void GetSearchData(ref UnitDb objUnitDb)
        {
            if (_CellBiz == null)
                _CellBiz = new CellBiz();
            if (_ModelBiz == null)
                _ModelBiz = new UnitModelBiz();
            if (_CustomerCol == null)
                _CustomerCol = new CustomerCol(true);
            objUnitDb = new UnitDb();
            //objUnitDb.UnitID = objCellBiz.ID;
            if (_FlatNo == null)
                _FlatNo = "";
            string[] arrStr = _FlatNo.Split(",".ToCharArray());
            string strTempFlat = "";
            int intTemp=0;
            foreach (string strTemp in arrStr)
            {
                if (int.TryParse(strTemp, out intTemp))
                {
                    if (intTemp > 0)
                    {
                        if (strTempFlat != "")
                            strTempFlat += ",";
                        strTempFlat += intTemp.ToString();
                    }
                }
            }
            objUnitDb.FlatNo = strTempFlat;

            arrStr = _FloorStr.Split(",".ToCharArray());
            intTemp = 0;
            strTempFlat = "";
            foreach (string strTemp in arrStr)
            {
                if (int.TryParse(strTemp, out intTemp))
                {
                    if (intTemp > 0)
                    {
                        intTemp += 1;
                        if (strTempFlat != "")
                            strTempFlat += ",";
                        strTempFlat += intTemp.ToString();
                    }
                }
            }
            objUnitDb.FloorStr = strTempFlat;

          
            if (_CellBiz.ID == _CellBiz.ParentID)
            {
                objUnitDb.CellFamilyID = _CellBiz.ID;
                objUnitDb.FloorOrder = _CellOrder;
            }
            else
            {
                CellBiz objTemp;
                if (_CellBiz.ID != -1)
                    objTemp = new CellBiz(_CellBiz.ID);
                else
                    objTemp = _CellBiz;

                {
                    CellCol objCellCol = objTemp.GetTypedChildren(7, _CellOrder);
                    string strTemp = objCellCol.IDsStr;
                    if (strTemp == "")
                        strTemp = "0";
                    objUnitDb.CellIDs = strTemp;
                    CellDb.CachCellID = objTemp.ID;
                    CellDb.CachCellIDs = strTemp;
                    CellDb.CachTypeID = 7;
                }
            }
            // objUnitDb.CellName = strCellName;
            objUnitDb.ModelIDs = _ModelBiz.IDsStr;
            objUnitDb.CustomerIDs = _CustomerCol.IDsStr;
            objUnitDb.FromSurvey = _FromSuervy;
            objUnitDb.UnitStatus = _Status;
            objUnitDb.ToSurvey = _ToSurevy;
            objUnitDb.StatusStr = _ReservationStatus;
            objUnitDb.UnitNameLike = _CellName;
            objUnitDb.CellTowerName = _CellTowerName;
            objUnitDb.CellTowerDeliveryStatus = _CellTowerDeliveryStatus;
            objUnitDb.DeliveryStatus = _DeliveryStatus;
            objUnitDb.DeliveryDateRange = _IsDeliveryDateRange;
            objUnitDb.StartDeliveryDate = _StartDeliveryDate;
            objUnitDb.EndDeliveryDate = _EndDeliveryDate;
            objUnitDb.CellFamilyIDs = _CellBiz.FamilyIDs;
            if (_UnittypeBiz == null)
                _UnittypeBiz = new UnitTypeBiz();
            objUnitDb.UnitType = _UnittypeBiz.ID;
            objUnitDb.UnitCodeStr = _UnitCodeStr;
            if (_PeripheralTypeBiz == null)
                _PeripheralTypeBiz = new PeripheralTypeBiz();
            objUnitDb.PeripheralID = _PeripheralTypeBiz.ID;
            objUnitDb.StartPeripheralSurvey = _StartPeripheralSurvey;
            objUnitDb.EndPeripheralSurvey = _EndPeripheralSurvey;
            objUnitDb.UserClosed = _UserClose;
            if (_UsageTypeBiz == null)
                _UsageTypeBiz = new UnitUsageTypeBiz();
            objUnitDb.UsageType = _UsageTypeBiz.ID;
            objUnitDb.StartPrice = _StartPrice;
            objUnitDb.EndPrice = _EndPrice;
            objUnitDb.ProjectIDs = _ProjectIDs;
            objUnitDb.TowerIDs = _TowerIDs;
            objUnitDb.FloorIDs = _FloorIDs;
            objUnitDb.PriceDateRange = _IsPriceDateRange;
            objUnitDb.PriceDateStart = _PriceDateStart;
            objUnitDb.PriceDateEnd = _PriceDateEnd;
            if (_ResubmissionTypeCol == null)
                _ResubmissionTypeCol = new ResubmissionTypeCol(true);
            objUnitDb.ResubmissionTypeIDs = _ResubmissionTypeCol.IDs;
            objUnitDb.IsAndingAttribute = _IsAnding;
            objUnitDb.TotalAttributeStart = _TotalAttributeStart;
            objUnitDb.TotalAttributeEnd = _TotalAttributeEnd;
            //objUnitDb.AttributeTable = _SelectedAttributeCol.GetTable();
            objUnitDb.IsCloseTimeRange = _IsCloseTimeRange;
            objUnitDb.CloseTimeStart = _CloseTimeStart;
            objUnitDb.CloseTimeEnd = _CloseTimeEnd;
            objUnitDb.CategoryIDs = _CategoryCol.IDsStr;
            string strGrades = "";
            foreach (int intGrade in _CategoryGradeLst)
            {
                if (strGrades != "")
                    strGrades += ",";
                strGrades += intGrade.ToString();
            }
            int _UMSAllUnitType = 1290;
            if (SysData.CurrentUser.UserFunctionInstantCol.GetIndex(_UMSAllUnitType) == -1)
            {
                objUnitDb.UnitTypeIDs = UnitTypeCol.AssignedUnitTypeCol.TypeIDs;


            }
            objUnitDb.CategoryGrades = strGrades;

        }
        public void MoveNext()
        {

            Clear();
            UnitDb objUnitDb = new UnitDb();
            GetSearchData(ref objUnitDb);
            objUnitDb.MaxID = _MaxID;
            objUnitDb.MinID = 0;
            DataTable dtTemp = objUnitDb.Search();

          
          
            UnitBiz ObjUnitBiz;
            //UnitBiz objUnitBiz;
            foreach (DataRow objDr in dtTemp.Rows)
            {
                //Add(new UnitBiz(objDr));
                ObjUnitBiz = new UnitBiz(objDr);
               
                //objUnitBiz = new UnitBiz(objDr);
                this.Add(ObjUnitBiz);
            }

            if (Count > 0)
            {
                DataRow[] arrDr = dtTemp.Select("", "UnitID");
                objUnitDb = new UnitDb(arrDr[Count - 1]);
                _MaxID = objUnitDb.ID;
                objUnitDb = new UnitDb(arrDr[0]);
                _MinID = objUnitDb.ID;
                if (_MinID > _TheMinID)
                    _EnablePrevious = true;
            }

            if (Count == _MaxCount)
            {
                _EnableNext = true;
            }
            else if (Count < _MaxCount)
                _EnableNext = false;


        }
        public void MovePrevious()
        {


            Clear();
            UnitDb objUnitDb = new UnitDb();
            GetSearchData(ref objUnitDb);
            objUnitDb.MinID = _MinID;
            DataTable dtTemp = objUnitDb.Search();

          
            DataRow[] arrUsr;
            UnitBiz ObjUnitBiz;
            foreach (DataRow objDr in dtTemp.Rows)
            {
                //Add(new UnitBiz(objDr));
                ObjUnitBiz = new UnitBiz(objDr);
              
                this.Add(ObjUnitBiz);
            }
            if (Count > 0)
            {
                DataRow[] arrDr = dtTemp.Select("", "UnitID");
                objUnitDb = new UnitDb(arrDr[Count - 1]);
                _MaxID = objUnitDb.ID;
                objUnitDb = new UnitDb(arrDr[0]);
                _MinID = objUnitDb.ID;
                if (_MinID > _TheMinID)
                    _EnablePrevious = true;
                _EnableNext = true;
            }



        }
        #endregion
        public void Add(UnitBiz objBiz)
        {
            List.Add(objBiz);
 
        }
        public void Add(UnitCol objUnitCol)
        {
            foreach(UnitBiz objBiz in objUnitCol)
             Add(objBiz);

        }
        public void EditDelivery(bool blIsDelivered, DateTime dtDeliveryDate)
        {
            UnitDb objDb = new UnitDb();
            objDb.UnitIDs = IDsStr;
            objDb.IsDelivered = blIsDelivered;
            objDb.DeliveryDate = dtDeliveryDate;
            objDb.EditDeliveryDate();
        }
        public DataTable GetViewTable()
        {
            DataTable Returned = new DataTable();
            Returned.Columns.AddRange(new DataColumn[]{new DataColumn("UnitID"), new DataColumn("Project")
                ,new DataColumn("CellTower"),new DataColumn("Customer"),new DataColumn("Floor"),new DataColumn("Code1"), new DataColumn("UnitCode")
            ,new DataColumn("Area"),new DataColumn("Model"),new DataColumn("Status"),new DataColumn("UserClosed"),new DataColumn("UnitClosingDate"),
                new DataColumn("DeliveryDate"),new DataColumn("CellTowerDeliveryDate"),
                new DataColumn("ExpectedDeliveryDate"),new DataColumn("Sales_Price_Per_Meter"),
                new DataColumn("peripheral"),new DataColumn("Notes")
                ,new DataColumn("UnitOrder"),new DataColumn("CellOrder")
           ,new DataColumn("TotalPrice")});
            PeripheralTypeCol objTypeCol = PeripheralTypeCol;
            Hashtable hsPer = new Hashtable();
            foreach(PeripheralTypeBiz objPType in objTypeCol)
            {
                hsPer.Add(objPType.ID.ToString(), Returned.Columns.Count);
                Returned.Columns.Add(objPType.Name);
            }
                
          
            DataRow objDr;
            int intTempIndex = 0;
            foreach (UnitBiz objBiz in this)
            {
                objDr = Returned.NewRow();
                objDr["UnitID"] = objBiz.ID;
                objDr["Area"] = objBiz.Survey;
                objDr["Model"] = objBiz.ModelBiz.Name;
                objDr["Status"] = objBiz.StatusWithoutCustomerStr;
                objDr["UserClosed"] = objBiz.IsClosed ? (objBiz.UserClosed.EmployeeBiz.ID > 0 ? objBiz.UserClosed.EmployeeBiz.Name : objBiz.UserClosed.Name) : "";
                objDr["UnitClosingDate"] = objBiz.IsClosed ? objBiz.CloseDate.ToString("yyyy-MM-dd") : "";
                objDr["Floor"] = objBiz.Floor.Name; //objBiz.CellCol.Count > 0 ? objBiz.CellCol[0].CellBiz.AlterName : "";
                objDr["Project"] = objBiz.Project.AlterName;
                objDr["CellTower"] = objBiz.Tower.AlterName;
                objDr["Code1"] = objBiz.Code;
                objDr["UnitCode"] = objBiz.FullName;
                objDr["DeliveryDate"] = objBiz.IsDelivered ? objBiz.DeliveryDate.ToString("yyyy-MM-dd") : "";
                objDr["ExpectedDeliveryDate"] = objBiz.IsDelivered || objBiz.Tower.IsDelivered || !objBiz.Tower.IsEstimatedDeliver ?
                    "" : objBiz.Tower.EstimatedDeliverDate.ToString("yyyy-MM-dd");
                objDr["CellTowerDeliveryDate"] = objBiz.IsDelivered || !objBiz.Tower.IsDelivered ? (objBiz.IsReadyForDelivery?objBiz.ReadyForDeliveryDate.ToString("yyyy-MM-dd"):"") : objBiz.Tower.DeliverDate.ToString("yyyy-MM-dd");
                objDr["Customer"] = objBiz.CustomerStr;
                objDr["Sales_Price_Per_Meter"] = objBiz.UnitSalesPrice;
                objDr["peripheral"] = objBiz.PeripheralDesc;
                objDr["Notes"] = objBiz.Desc;
                objDr["UnitOrder"] = objBiz.Order.ToString();
                objDr["CellOrder"] = objBiz.Floor.Order - 1;
                objDr["TotalPrice"] = objBiz.ComputedTotalPrice.ToString("0,000.0");
                foreach(UnitPeripheralBiz objPer in objBiz.PeripheralCol)
                {
                    if (hsPer[objPer.TypeBiz.ID.ToString()] == null)
                        continue;
                    intTempIndex = (int)hsPer[objPer.TypeBiz.ID.ToString()];
                    objDr[intTempIndex] = objPer.Survey;
                }
                Returned.Rows.Add(objDr);
 
            }
            return Returned;
        }
        public DataTable GetTableWithElectricityData()
        {
            DataTable Returned = new DataTable();
            Returned.Columns.AddRange(new DataColumn[]{new DataColumn("Project")
                ,new DataColumn("CellTower"),new DataColumn("Customer"),new DataColumn("Floor"), new DataColumn("UnitCode")
            ,new DataColumn("Area"),new DataColumn("Model"),new DataColumn("Status"),
                new DataColumn("DeliveryDate"),new DataColumn("CellTowerDeliveryDate"),new DataColumn("ExpectedDeliveryDate")
            ,new DataColumn("HasMeter"),new DataColumn("MeterOwner"),new DataColumn("MeterStartDate"),
                new DataColumn("MeterStatus"),new DataColumn("MeterIllegalAction"),new DataColumn("MeterNotes")});
            DataRow objDr;
            foreach (UnitBiz objBiz in this)
            {
                objDr = Returned.NewRow();
                objDr["Area"] = objBiz.Survey;
                objDr["Model"] = objBiz.ModelBiz.Name;
                objDr["Status"] = objBiz.StatusWithoutCustomerStr;
                objDr["Floor"] = objBiz.CellCol.Count > 0 ? objBiz.CellCol[0].CellBiz.AlterName : "";
                objDr["Project"] = objBiz.Project.AlterName;
                objDr["CellTower"] = objBiz.Tower.AlterName;
                objDr["UnitCode"] = objBiz.FullName;
                objDr["DeliveryDate"] = objBiz.IsDelivered ? objBiz.DeliveryDate.ToString("yyyy-MM-dd") : "";
                objDr["ExpectedDeliveryDate"] = objBiz.IsDelivered || objBiz.Tower.IsDelivered || !objBiz.Tower.IsEstimatedDeliver ?
                    "" : objBiz.Tower.EstimatedDeliverDate.ToString("yyyy-MM-dd");
                objDr["CellTowerDeliveryDate"] = objBiz.IsDelivered || !objBiz.Tower.IsDelivered ? "" : objBiz.Tower.DeliverDate.ToString("yyyy-MM-dd");
                objDr["Customer"] = objBiz.CustomerStr;
                objDr["HasMeter"] = objBiz.HasElectricityMeter ? "íæÌÏ ÚÏÇÏ" : "";
                objDr["MeterOwner"] = objBiz.ElectricityMeterOwner;
                objDr["MeterStartDate"] = objBiz.ElectricityMeterHasStartDate ? objBiz.ElectricityMeterStartDate.ToString("yyyy-MM-dd") : "";
                objDr["MeterStatus"] = UnitBiz.MeterStatusStrArr[(int)objBiz.ElectricityMeterStatus];
                objDr["MeterIllegalAction"] = UnitBiz.MeterIllegalActionStrArr[(int)objBiz.ElectricityMeterIllegalAction];
                objDr["MeterNotes"] = objBiz.ElecticityMeterNotes;
                Returned.Rows.Add(objDr);

            }
            return Returned;
        }
        public DataTable GetElectricityTable()
        {
          
            DataTable Returned = new DataTable();
            Returned.Columns.AddRange(new DataColumn[] { new DataColumn("UnitID"),new DataColumn("HasElectricityMeter"),new DataColumn("ElectricityMeterStartDate")
                ,new DataColumn("ElectricityMeterOwner"),new DataColumn("ElectricityMeterStatus"),
                new DataColumn("ElectricityMeterIllegalAction"),new DataColumn("ElecticityMeterNotes")});
            DataRow objDr;
            foreach (UnitBiz objBiz in this)
            {
                objDr = Returned.NewRow();
                objDr["UnitID"] = objBiz.ID;
                objDr["HasElectricityMeter"] = objBiz.HasElectricityMeter ? 1 : 0;
                objDr["ElectricityMeterStartDate"] = objBiz.ElectricityMeterHasStartDate ? 
                    SysUtility.Approximate(objBiz.ElectricityMeterStartDate.ToOADate()-2,1,ApproximateType.Down).ToString() : "null";
                objDr["ElectricityMeterOwner"] = objBiz.ElectricityMeterOwner;
                objDr["ElectricityMeterStatus"] = (int)objBiz.ElectricityMeterStatus;
                objDr["ElectricityMeterIllegalAction"] = (int)objBiz.ElectricityMeterIllegalAction;
                objDr["ElecticityMeterNotes"] = objBiz.ElecticityMeterNotes;
                Returned.Rows.Add(objDr);
            }
           return Returned;
        }
        public DataTable GetTable()
        {
            DataTable Returned = new DataTable();
            Returned.Columns.AddRange(new DataColumn[] { new DataColumn("UnitID"), new DataColumn("UnitSurvey"),
                new DataColumn("UnitPricePerMeter"),
                new DataColumn("UnitNameA"),new DataColumn("UnitNameE"),new DataColumn("UnitFullName"),
                new DataColumn("UnitModel"),new DataColumn("UnitStatus"),new DataColumn("CurrentReservation"),
            new DataColumn("UnitUserClosed"),
            new DataColumn("UnitClosingDate"),new DataColumn("UnitView"),new DataColumn("UnitMainType"),
                new DataColumn("UnitUsageType"),new DataColumn("UnitViewSap"),new DataColumn("UnitNeighbor1"),
            new DataColumn("UnitNeighbor2"),new DataColumn("UnitNeighbor3"),new DataColumn("UnitNeighbor4")});
            DataRow objDr;
            foreach (UnitBiz objBiz in this)
            {
                objDr = Returned.NewRow();
                objDr["UnitID"] = objBiz.ID;
                objDr["UnitView"] = objBiz.ViewBiz.ID;
                objDr["UnitMainType"] = objBiz.MainTypeBiz.ID;
                objDr["UnitUsageType"] = objBiz.UsageTypeBiz.ID;
                objDr["UnitNeighbor1"] = objBiz.Neighbor1;
                objDr["UnitNeighbor2"] = objBiz.Neighbor2;
                objDr["UnitNeighbor3"] = objBiz.Neighbor3;
                objDr["UnitNeighbor4"] = objBiz.Neighbor4;
                objDr["UnitSurvey"] = objBiz.Survey;

                objDr["UnitPricePerMeter"] = objBiz.UnitSalesPrice;

                Returned.Rows.Add(objDr);
 
            }
            return Returned;
        }
        public void EditElectricityData()
        {
            DataTable dtTemp = GetElectricityTable();
            UnitDb objUnitDb = new UnitDb();
            objUnitDb.ElectricityTable = dtTemp;
            objUnitDb.EditElectricityData();
        }
        public bool Close(double dblTimeAmount, bool blIsPermanent, TimeClosePeriod objClosePeriod, string strReason,UserBiz objUserBiz)
        {
            UnitCol objUnitCol = OpenedCol;
            if (objUnitCol.Count == 0)
                return false;
            UnitDb objUnitDb = new UnitDb();
            objUnitDb.UnitIDs = objUnitCol.IDsStr;
            objUnitDb.CloseReason = strReason;
            objUnitDb.UserClosed = objUserBiz == null ? 0 : objUserBiz.ID;
            if (!blIsPermanent)
            {
                objUnitDb.TimeClose = dblTimeAmount;
                objUnitDb.ClosePeriod = (int)objClosePeriod;

            }
            else
                objUnitDb.PermanentClosed = true;
            objUnitDb.CloseUnit();
            return objUnitDb.EditSucceeded;
 
        }
        public bool Open()
        {
            UnitCol objUnitCol = ClosedCol;
            if (objUnitCol.Count == 0)
                return false;
            UnitDb objUnitDb = new UnitDb();
            objUnitDb.UnitIDs = objUnitCol.IDsStr;
            
            objUnitDb.OpenUnit();
            return objUnitDb.EditSucceeded;

        }
        public void Save()
        {
            UnitDb objDb = new UnitDb();
            objDb.UnitTable = GetTable();
            objDb.SaveCol();

        }
        public void SetPeripheralCol() 
        {
            string strIDs = IDsStr;
            UnitPeripheralDb objDb = new UnitPeripheralDb();
            objDb.UnitIDs = strIDs;
            DataTable dtTemp = objDb.Search();
            DataRow[] arrDr;
            foreach (UnitBiz objBiz in this)
            { 
                arrDr = dtTemp.Select("PeriphiralUnit ="+objBiz.ID );
                objBiz.PeripheralCol = new UnitPeripheralCol(true);
                foreach (DataRow objDr in arrDr)
                    objBiz.PeripheralCol.Add(new UnitPeripheralBiz(objDr));


            }
        }
        public void SetPrice(double dblPrice, DateTime dtPriceDate
            ,PeripheralTypeBiz objPeripheralTypeBiz,PriceValueType objPriceType)
        {
            if (Count == 0)
                return;
            if (objPeripheralTypeBiz == null)
                objPeripheralTypeBiz = new PeripheralTypeBiz();

            if (objPeripheralTypeBiz.ID == 0)
                objPriceType = PriceValueType.Value;
            UnitDb objDb = new UnitDb();
            objDb.UnitIDs = IDsStr;
            objDb.UnitSalesPrice = dblPrice;
            objDb.UnitSalesPriceDate = dtPriceDate;
            objDb.PeripheralID = objPeripheralTypeBiz.ID;
            objDb.PriceValueType = (int)objPriceType;
            objDb.EditPrice();

        }
        public void EditReadyForDelivery(bool blIsReadyForDelivery,DateTime dtReadyForDeliveryDate)
        {
            if (Count == 0)
                return;
            UnitDb objDb = new UnitDb();
            objDb.UnitIDs = IDsStr;
            objDb.IsReadyForDelivery = blIsReadyForDelivery;
            objDb.ReadyForDeliveryDate = dtReadyForDeliveryDate;
            objDb.EditReadyForDelivery();
        }
        public void AssignToCampaign(CampaignBiz objCampaignBiz)
        {
            if (Count == 0 || objCampaignBiz == null || objCampaignBiz.ID ==0)
                return;
            UnitDb objDb = new UnitDb();
            objDb.UnitIDs = IDsStr;
            objDb.Campaign = objCampaignBiz.ID;
            objDb.AssignToCampaign();
        }
        public void SetDesc(string strDesc)
        {
            UnitDb objDb = new UnitDb();
            objDb.Desc = strDesc;
            if (Count == 1)
                objDb.ID = this[0].ID;
            else
                objDb.UnitIDs = IDsStr;
            objDb.EditDesc();
        }
        public ReservationBonusCol GetReservationBonusCol()
        {
            ReservationBonusCol Returned = new ReservationBonusCol(true);
            DataTable dtTemp;
            ReservationDb objReservationDb = new ReservationDb();
            objReservationDb.IDs = ReservationCol.IDsStr;
            objReservationDb.TopSelect = ReservationCol.Count;

            dtTemp = objReservationDb.Search();

            ReservationCol objReservationCol = new ReservationCol(true);
            foreach (DataRow objDr in dtTemp.Rows)
            {
                objReservationCol.Add(new ReservationBiz(objDr));
            }
            ReservationBiz objReservation;
            foreach (UnitBiz objUnitBiz in this)
            {
                objReservation = objReservationCol[objUnitBiz.CurrentReservation.ID.ToString()];
                objReservation.AddUnit(objUnitBiz);
            }
            ReservationBonusDb objBonusDb = new ReservationBonusDb();
            objBonusDb.ReservationIDs = objReservationCol.IDsStr;
            dtTemp = objBonusDb.Search();

            ReservationBonusBiz objBiz;
            ReservationBiz objReservationBiz;
            Hashtable hsReservationBonus = new Hashtable();
            string strKey = "";
            foreach (DataRow objDr in dtTemp.Rows)
            {
                objBiz = new ReservationBonusBiz(objDr);
                objReservationBiz = objReservationCol[objBiz.ReservationID.ToString()];
                objBiz.ReservationBiz = objReservationBiz;
                strKey =objBiz.TypeBiz.ID.ToString()+"-"+ objBiz.ReservationID.ToString();
                if(hsReservationBonus[strKey]== null)
                hsReservationBonus.Add(strKey, strKey);

                Returned.Add(objBiz);
            }
            IEnumerable<System.Linq.IGrouping<BonusTypeBiz,ReservationBonusBiz>> objBonusTypeCol = 
                from objBonusBiz in Returned.Cast<ReservationBonusBiz>()
                                                        group objBonusBiz 
                                                        by new BonusTypeBiz() { ID = objBonusBiz.TypeBiz.ID,NameA = objBonusBiz.TypeBiz.NameA } 
                                                        into objType
                                                        select objType;

            foreach (var objTypeBiz1 in objBonusTypeCol)
            {
                foreach (ReservationBiz objReservationBiz1 in objReservationCol)
                {
                    strKey = "";
                    strKey = objTypeBiz1.Key.ID.ToString() + "-" + objReservationBiz1.ID.ToString();
                    if (hsReservationBonus[strKey] == null)
                    {
                        objBiz = new ReservationBonusBiz() { ReservationBiz = objReservationBiz1,TypeBiz= objTypeBiz1.Key};
                        Returned.Add(objBiz);
                        hsReservationBonus.Add(strKey, strKey);
                    }

                }
            }

            return Returned;
        }
        public void EditUnitCategory(UnitCategoryBiz objBiz)
        {
            if (objBiz == null || objBiz.ID == 0)
                return;
            UnitDb objDb = new UnitDb();
            objDb.Category = objBiz.ID;
            objDb.UnitIDs = IDsStr;
            objDb.EditCategory();
        }
        public void EditUnitEvaluation(double dblEvaluation)
        {
            
            UnitDb objDb = new UnitDb();
            objDb.NumericEvaluation = dblEvaluation;
            objDb.UnitIDs = IDsStr;
            objDb.EditNumericEvaluation();
        }
        public static UnitCol GetUnitColByIDsLst(List<int> lstIDs)
        {
            string strIDs = "";
            foreach(int intID in lstIDs)
            {
                if (strIDs != "")
                    strIDs += ",";
                strIDs += intID.ToString();
            }    
            UnitCol Returned = new UnitCol(true);
            UnitDb objDb = new UnitDb() { UnitIDs = strIDs };
            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
                Returned.Add(new UnitBiz(objDr));

            return Returned;
        }
        public static UnitCol GetUnitColByIDs(string strIDs)
        {
            UnitCol Returned = new UnitCol(true);
            UnitDb objDb = new UnitDb() { UnitIDs = strIDs };
            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
                Returned.Add(new UnitBiz(objDr));

            return Returned;
        }
    }
}
