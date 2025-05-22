using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Collections;
using AlgorithmatENM.ERP.ERPDataBase;
using SharpVision.SystemBase;
using AlgorithmatENM.ENM.ENMBiz;

namespace AlgorithmatENM.ERP.ERPBusiness
{
    public class BufferMeasureCol:CollectionBase
    {

        #region Constructor
        public BufferMeasureCol()
        {

        }
        public BufferMeasureCol(bool blIsEmbty)
        {
            if (blIsEmbty)
                return;
            BufferMeasureBiz objBiz = new BufferMeasureBiz();
           
            BufferMeasureDb objDb = new BufferMeasureDb();

            DataTable dtTemp = objDb.Search();


            foreach (DataRow objDR in dtTemp.Rows)
            {
                objBiz = new BufferMeasureBiz(objDR);
                Add(objBiz);
            }
        }
        public BufferMeasureCol(bool blIsDateRange,DateTime dtStart,DateTime dtEnd)
        {
         
            BufferMeasureBiz objBiz = new BufferMeasureBiz();

            BufferMeasureDb objDb = new BufferMeasureDb();
            objDb.IsDateRange = blIsDateRange;
            objDb.StartDate = dtStart;
            objDb.EndDate = dtEnd;
            DataTable dtTemp = objDb.Search();


            foreach (DataRow objDR in dtTemp.Rows)
            {
                objBiz = new BufferMeasureBiz(objDR);
                Add(objBiz);
            }
        }

        public BufferMeasureCol(int intBuffer,bool blIsDateRange, DateTime dtStart, DateTime dtEnd)
        {

            BufferMeasureBiz objBiz = new BufferMeasureBiz();

            BufferMeasureDb objDb = new BufferMeasureDb() { BufferID=intBuffer,IsDateRange=blIsDateRange,StartDate=dtStart,EndDate=dtEnd};

            DataTable dtTemp = objDb.Search();


            foreach (DataRow objDR in dtTemp.Rows)
            {
                objBiz = new BufferMeasureBiz(objDR);
                Add(objBiz);
            }
        }
        #endregion
        #region Private Data

        #endregion
        #region Properties
        public BufferMeasureBiz this[int intIndex]
        {
            get
            {
                return (BufferMeasureBiz)this.List[intIndex];
            }
        }
        #endregion
        #region Private Method

        #endregion
        #region Public Method 
        public void Add(BufferMeasureBiz objBiz)
        {
            List.Add(objBiz);
        }
        public BufferMeasureCol GetCol(string strTemp)
        {
            BufferMeasureCol Returned = new BufferMeasureCol(true);
            foreach (BufferMeasureBiz objBiz in this)
            {
                if (objBiz.BufferTypeNameA.CheckStr(strTemp))
                    Returned.Add(objBiz);
            }
            return Returned;
        }
        public DataTable GetTable()
        {
            DataTable Returned = new DataTable();
            Returned.Columns.AddRange(new DataColumn[] { new DataColumn("MeasureID"), new DataColumn("MeasureWorkOrder"), new DataColumn("MeasureDate", System.Type.GetType("System.DateTime")), new DataColumn("MeasureTime", System.Type.GetType("System.DateTime")), new DataColumn("MeasureValue"), new DataColumn("MeasureFirstValue"), new DataColumn("MeasureMinValue"), new DataColumn("MeasureMaxValue"), new DataColumn("MeasureMinTime", System.Type.GetType("System.DateTime")), new DataColumn("BufferID"), new DataColumn("BufferCode"), new DataColumn("BufferDesc"), new DataColumn("BufferSize"), new DataColumn("BufferTag"), new DataColumn("BufferTypeID"), new DataColumn("BufferTypeCode"), new DataColumn("BufferTypeNameA"), new DataColumn("BufferTypeNameE"), new DataColumn("BufferMachineID"), new DataColumn("BufferMachineCeneter"), new DataColumn("BufferMachineFlow"), new DataColumn("BufferMachineCode"), new DataColumn("BufferMachineDesc"), new DataColumn("BufferMachineNameA"), new DataColumn("BufferMachineNameE"), new DataColumn("BufferProductID"), new DataColumn("BufferProductCode"), new DataColumn("BufferProductNameA"), new DataColumn("BufferProductNameE"), new DataColumn("BufferCenterID"), new DataColumn("BufferCenterCode"), new DataColumn("BufferCenterNameA"), new DataColumn("BufferCenterNameE"), new DataColumn("BufferMeasurementID"), new DataColumn("BufferMeasurementCode"), new DataColumn("BufferMeasurementNameA"), new DataColumn("BufferMeasurementNameE") });
            DataRow objDr;
            foreach (BufferMeasureBiz objBiz in this)
            {
                objDr = Returned.NewRow();
                objDr["MeasureID"] = objBiz.MeasureID;
                objDr["MeasureWorkOrder"] = objBiz.MeasureWorkOrder;
                objDr["MeasureDate"] = objBiz.MeasureDate;
                objDr["MeasureTime"] = objBiz.MeasureTime;
                objDr["MeasureValue"] = objBiz.MeasureValue;
                objDr["MeasureFirstValue"] = objBiz.MeasureFirstValue;
                objDr["MeasureMinValue"] = objBiz.MeasureMinValue;
                objDr["MeasureMaxValue"] = objBiz.MeasureMaxValue;
                objDr["MeasureMinTime"] = objBiz.MeasureMinTime;
                objDr["BufferID"] = objBiz.BufferID;
                objDr["BufferCode"] = objBiz.BufferCode;
                objDr["BufferDesc"] = objBiz.BufferDesc;
                objDr["BufferSize"] = objBiz.BufferSize;
                objDr["BufferTag"] = objBiz.BufferTag;
                objDr["BufferTypeID"] = objBiz.BufferTypeID;
                objDr["BufferTypeCode"] = objBiz.BufferTypeCode;
                objDr["BufferTypeNameA"] = objBiz.BufferTypeNameA;
                objDr["BufferTypeNameE"] = objBiz.BufferTypeNameE;
                objDr["BufferMachineID"] = objBiz.BufferMachineID;
                objDr["BufferMachineCeneter"] = objBiz.BufferMachineCeneter;
                objDr["BufferMachineFlow"] = objBiz.BufferMachineFlow;
                objDr["BufferMachineCode"] = objBiz.BufferMachineCode;
                objDr["BufferMachineDesc"] = objBiz.BufferMachineDesc;
                objDr["BufferMachineNameA"] = objBiz.BufferMachineNameA;
                objDr["BufferMachineNameE"] = objBiz.BufferMachineNameE;
                objDr["BufferProductID"] = objBiz.BufferProductID;
                objDr["BufferProductCode"] = objBiz.BufferProductCode;
                objDr["BufferProductNameA"] = objBiz.BufferProductNameA;
                objDr["BufferProductNameE"] = objBiz.BufferProductNameE;
                objDr["BufferCenterID"] = objBiz.BufferCenterID;
                objDr["BufferCenterCode"] = objBiz.BufferCenterCode;
                objDr["BufferCenterNameA"] = objBiz.BufferCenterNameA;
                objDr["BufferCenterNameE"] = objBiz.BufferCenterNameE;
                objDr["BufferMeasurementID"] = objBiz.mentID;
                objDr["BufferMeasurementCode"] = objBiz.mentCode;
                objDr["BufferMeasurementNameA"] = objBiz.mentNameA;
                objDr["BufferMeasurementNameE"] = objBiz.mentNameE;
                Returned.Rows.Add(objDr);
            }
            return Returned;
        }
        public List<GroupSimple> GetGroupSimple()
        {
            List<GroupSimple> Returned = new List<GroupSimple>();
            MeterSimple objMeterSimple;
            //var vrGroupLst = from objMeasure in this.Cast<MeasurementBiz>()
            //            group objMeasure by new GroupSimple() { ID = objMeasure.MeterGroup, Code = objMeasure.MeterGroupCode, Desc = objMeasure.MeterGroupDesc, NameA = objMeasure.MeterGroupNameA, NameE = objMeasure.MeterGroupNameE } into objGroup
            //            select objGroup;
            var vrGroupLst = from objMeasure in this.Cast<BufferMeasureBiz>()
                             group objMeasure by new {MeterGroup=objMeasure.BufferTypeID, MeterGroupCode=objMeasure.BufferTypeCode,MeterGroupDesc=objMeasure.BufferTypeNameA, MeterGroupNameA=objMeasure.BufferTypeNameA,MeterGroupNameE=objMeasure.BufferTypeNameE} into objNewGroup
                             select objNewGroup;
            int intCount = vrGroupLst.Count();
            DataTable dtTemp = GetTable();
            GroupSimple objGroup = new GroupSimple();
            foreach (var vrGroup in vrGroupLst)
            {
                objGroup = new GroupSimple() { Code = vrGroup.Key.MeterGroupCode, Desc = vrGroup.Key.MeterGroupDesc, ID =0, NameA = vrGroup.Key.MeterGroupNameA, NameE = vrGroup.Key.MeterGroupNameE };


                var vrMeterLst = from objMeasure1 in vrGroup
                                 group objMeasure1 by new { MeterDesc= objMeasure1.BufferDesc, MeterGroupCode=objMeasure1.BufferTypeCode, MeterGroupDesc=objMeasure1.BufferTypeNameA, ProductName=objMeasure1.BufferContent, MeterGroup=objMeasure1.BufferTypeID, MeterGroupNameA=objMeasure1.BufferTypeNameA, MeterGroupNameE=objMeasure1.BufferTypeNameE, MeterID=objMeasure1.BufferID, MeterTypeCode=objMeasure1.BufferTypeCode, MeterTypeID=objMeasure1.BufferTypeID, MeterTypeNameA=objMeasure1.BufferTypeNameA, MeterTypeNameE=objMeasure1.BufferTypeNameE }
                into objNewMeter
                                 select objNewMeter;
                intCount = vrMeterLst.Count();
                foreach (var vrMeter in vrMeterLst)
                {
                    objMeterSimple = new MeterSimple() { Desc = vrMeter.Key.MeterDesc, GroupCode = vrMeter.Key.MeterGroupCode, GroupDesc = vrMeter.Key.MeterGroupDesc, GroupID = vrMeter.Key.MeterGroup, GroupNameA = vrMeter.Key.MeterGroupNameA, GroupNameE = vrMeter.Key.MeterGroupNameE, ID = vrMeter.Key.MeterID, TypeCode = vrMeter.Key.MeterTypeCode, TypeID = vrMeter.Key.MeterTypeID, TypeNameA = vrMeter.Key.MeterTypeNameA, TypeNameE = vrMeter.Key.MeterTypeNameE, ProductName = vrMeter.Key.ProductName };
                   objMeterSimple.MeasureLst = vrMeter.ToList().GetSimpleLst();
                    objGroup.MeterLst.Add(objMeterSimple);
                }
                objGroup.LastReadTime = DateTime.Now.ToString("HH:mm:ss");
                Returned.Add(objGroup);
            }
            return Returned;
        }
        public BufferMeasureCol GetColWithComposition()
        {
            BufferMeasureCol Returned = new BufferMeasureCol(true);
            List<BufferMeasureBiz> lstMeasure = this.Cast<BufferMeasureBiz>().Where(x => !x.BufferProductIsComposed).ToList();

            foreach(BufferMeasureBiz objBiz in lstMeasure)
            {
                Returned.Add(objBiz);
            }
            List<BufferMeasureBiz> lstComposedMeasure = this.Cast<BufferMeasureBiz>().Where(x => x.BufferProductIsComposed).ToList();
            Hashtable hsTemp = new Hashtable();
            string strComposedProductIDs = "";
            foreach(BufferMeasureBiz objBiz in lstComposedMeasure)
            {
                if (objBiz.BufferProductID == 0|| hsTemp[objBiz.BufferProductID.ToString()]!= null)
                    continue;
                hsTemp.Add(objBiz.BufferProductID.ToString(), objBiz.BufferProductID);
                if (strComposedProductIDs != "")
                    strComposedProductIDs += ",";
                strComposedProductIDs += objBiz.BufferProductID.ToString();
            }
            if (strComposedProductIDs != "")
            {
                ProductDb objProductDb = new ProductDb() { IDs = strComposedProductIDs };
                ProductCol objProductCol = new ProductCol(true);
                DataTable dtTemp = objProductDb.GetSubProduct();
                foreach (DataRow objDr in dtTemp.Rows)
                    objProductCol.Add(new ProductBiz(objDr));
                if (objProductCol.Count > 0)
                {
                    BufferMeasureBiz objCopy;
                    List<ProductBiz> lstProduct = new List<ProductBiz>();
                    foreach (BufferMeasureBiz objBiz in lstComposedMeasure)
                    {
                        lstProduct = objProductCol.Cast<ProductBiz>().Where(x => x.MainID == objBiz.BufferProductID).ToList();
                        foreach(ProductBiz objProduct in lstProduct)
                        {
                            objCopy = objBiz.Copy();
                            objCopy.BufferProductCode = objProduct.Code;
                            objCopy.BufferProductID = objProduct.ID;
                            objCopy.BufferProductIsComposed = false;
                            objCopy.BufferProductNameA = objProduct.NameA;
                            objCopy.MeasureFirstValue = objBiz.MeasureFirstValue * objProduct.SubProductAmountPerUnit;
                            objCopy.MeasureMaxValue = objBiz.MeasureMaxValue * objProduct.SubProductAmountPerUnit;
                            objCopy.MeasureMinValue = objBiz.MeasureMinValue * objProduct.SubProductAmountPerUnit;
                            objCopy.MeasureValue = objBiz.MeasureValue * objProduct.SubProductAmountPerUnit;
                            Returned.Add(objCopy);
                        }
                    }
                }
            }
            return Returned;
        }
        #endregion
    }
}