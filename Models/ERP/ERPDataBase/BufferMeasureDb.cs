using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SharpVision.SystemBase;
using System.Data;

namespace AlgorithmatENM.ERP.ERPDataBase
{
    public class BufferMeasureDb
    {

        #region Constructor
        public BufferMeasureDb()
        {
        }
        public BufferMeasureDb(DataRow objDr)
        {
            SetData(objDr);
        }

        #endregion
        #region Properties
        int _MeasureID;
        public int MeasureID
        {
            set => _MeasureID = value;
            get => _MeasureID;
        }
        string _MeasureWorkOrder;
        public string MeasureWorkOrder
        {
            set => _MeasureWorkOrder = value;
            get => _MeasureWorkOrder;
        }
        DateTime _MeasureDate;
        public DateTime MeasureDate
        {
            set => _MeasureDate = value;
            get => _MeasureDate;
        }
        DateTime _MeasureTime;
        public DateTime MeasureTime
        {
            set => _MeasureTime = value;
            get => _MeasureTime;
        }
        double _MeasureValue;
        public double MeasureValue
        {
            set => _MeasureValue = value;
            get => _MeasureValue;
        }
        double _MeasureFirstValue;
        public double MeasureFirstValue
        {
            set => _MeasureFirstValue = value;
            get => _MeasureFirstValue;
        }
        double _MeasureMinValue;
        public double MeasureMinValue
        {
            set => _MeasureMinValue = value;
            get => _MeasureMinValue;
        }
        double _MeasureMaxValue;
        public double MeasureMaxValue
        {
            set => _MeasureMaxValue = value;
            get => _MeasureMaxValue;
        }
        DateTime _MeasureMinTime;
        public DateTime MeasureMinTime
        {
            set => _MeasureMinTime = value;
            get => _MeasureMinTime;
        }
        int _BufferID;
        public int BufferID
        {
            set => _BufferID = value;
            get => _BufferID;
        }
        string _BufferCode;
        public string BufferCode
        {
            set => _BufferCode = value;
            get => _BufferCode;
        }
        string _BufferDesc;
        public string BufferDesc
        {
            set => _BufferDesc = value;
            get => _BufferDesc;
        }
        double _BufferSize;
        public double BufferSize
        {
            set => _BufferSize = value;
            get => _BufferSize;
        }
        string _BufferTag;
        public string BufferTag
        {
            set => _BufferTag = value;
            get => _BufferTag;
        }
        bool _BufferIsPerHour;
        public bool BufferIsPerHour
        {
            set => _BufferIsPerHour = true;
            get => _BufferIsPerHour;
        }
        int _BufferTypeID;
        public int BufferTypeID
        {
            set => _BufferTypeID = value;
            get => _BufferTypeID;
        }
        string _BufferTypeCode;
        public string BufferTypeCode
        {
            set => _BufferTypeCode = value;
            get => _BufferTypeCode;
        }
        string _BufferTypeNameA;
        public string BufferTypeNameA
        {
            set => _BufferTypeNameA = value;
            get => _BufferTypeNameA;
        }
        string _BufferTypeNameE;
        public string BufferTypeNameE
        {
            set => _BufferTypeNameE = value;
            get => _BufferTypeNameE;
        }
        int _BufferMachineID;
        public int BufferMachineID
        {
            set => _BufferMachineID = value;
            get => _BufferMachineID;
        }
        int _BufferMachineCeneter;
        public int BufferMachineCeneter
        {
            set => _BufferMachineCeneter = value;
            get => _BufferMachineCeneter;
        }
        int _BufferMachineFlow;
        public int BufferMachineFlow
        {
            set => _BufferMachineFlow = value;
            get => _BufferMachineFlow;
        }
        string _BufferMachineCode;
        public string BufferMachineCode
        {
            set => _BufferMachineCode = value;
            get => _BufferMachineCode;
        }
        string _BufferMachineDesc;
        public string BufferMachineDesc
        {
            set => _BufferMachineDesc = value;
            get => _BufferMachineDesc;
        }
        string _BufferMachineNameA;
        public string BufferMachineNameA
        {
            set => _BufferMachineNameA = value;
            get => _BufferMachineNameA;
        }
        string _BufferMachineNameE;
        public string BufferMachineNameE
        {
            set => _BufferMachineNameE = value;
            get => _BufferMachineNameE;
        }
        int _BufferProductID;
        public int BufferProductID
        {
            set => _BufferProductID = value;
            get => _BufferProductID;
        }
        string _BufferProductCode;
        public string BufferProductCode
        {
            set => _BufferProductCode = value;
            get => _BufferProductCode;
        }
        string _BufferProductNameA;
        public string BufferProductNameA
        {
            set => _BufferProductNameA = value;
            get => _BufferProductNameA;
        }
        string _BufferProductNameE;
        public string BufferProductNameE
        {
            set => _BufferProductNameE = value;
            get => _BufferProductNameE;
        }
        bool _BufferProductIsComposed;
        public bool BufferProductIsComposed { set => _BufferProductIsComposed = value; get => _BufferProductIsComposed; }
        bool _OnlyComposition;
        public bool OnlyComposition { set => _OnlyComposition = value; }
        int _BufferCenterID;
        public int BufferCenterID
        {
            set => _BufferCenterID = value;
            get => _BufferCenterID;
        }
        string _BufferCenterCode;
        public string BufferCenterCode
        {
            set => _BufferCenterCode = value;
            get => _BufferCenterCode;
        }
        string _BufferCenterNameA;
        public string BufferCenterNameA
        {
            set => _BufferCenterNameA = value;
            get => _BufferCenterNameA;
        }
        string _BufferCenterNameE;
        public string BufferCenterNameE
        {
            set => _BufferCenterNameE = value;
            get => _BufferCenterNameE;
        }
        int _mentID;
        public int mentID
        {
            set => _mentID = value;
            get => _mentID;
        }
        string _mentCode;
        public string mentCode
        {
            set => _mentCode = value;
            get => _mentCode;
        }
        string _mentNameA;
        public string mentNameA
        {
            set => _mentNameA = value;
            get => _mentNameA;
        }
        string _mentNameE;
        public string mentNameE
        {
            set => _mentNameE = value;
            get => _mentNameE;
        }
        bool _IsDateRange;
        public bool IsDateRange { set => _IsDateRange = value; }
        DateTime _StartDate;
        public DateTime StartDate { set => _StartDate = value; }
        DateTime _EndDate;
        public DateTime EndDate { set => _EndDate = value; }
        bool _OnlyLastRead;
        public bool OnlyLastRead { set => _OnlyLastRead = value; }
        public string AddStr
        {
            get
            {
                string Returned = " insert into ERPBufferMeasure (MeasureID,MeasureWorkOrder,MeasureDate,MeasureTime,MeasureValue,MeasureFirstValue,MeasureMinValue,MeasureMaxValue,MeasureMinTime,BufferID,BufferCode,BufferDesc,BufferSize,BufferTag,BufferTypeID,BufferTypeCode,BufferTypeNameA,BufferTypeNameE,BufferMachineID,BufferMachineCeneter,BufferMachineFlow,BufferMachineCode,BufferMachineDesc,BufferMachineNameA,BufferMachineNameE,BufferProductID,BufferProductCode,BufferProductNameA,BufferProductNameE,BufferCenterID,BufferCenterCode,BufferCenterNameA,BufferCenterNameE,BufferMeasurementID,BufferMeasurementCode,BufferMeasurementNameA,BufferMeasurementNameE,UsrIns,TimIns) values (," + MeasureID + ",'" + MeasureWorkOrder + "'," + (MeasureDate.ToOADate() - 2).ToString() + "," + (MeasureTime.ToOADate() - 2).ToString() + "," + MeasureValue + "," + MeasureFirstValue + "," + MeasureMinValue + "," + MeasureMaxValue + "," + (MeasureMinTime.ToOADate() - 2).ToString() + "," + BufferID + ",'" + BufferCode + "','" + BufferDesc + "'," + BufferSize + ",'" + BufferTag + "'," + BufferTypeID + ",'" + BufferTypeCode + "','" + BufferTypeNameA + "','" + BufferTypeNameE + "'," + BufferMachineID + "," + BufferMachineCeneter + "," + BufferMachineFlow + ",'" + BufferMachineCode + "','" + BufferMachineDesc + "','" + BufferMachineNameA + "','" + BufferMachineNameE + "'," + BufferProductID + ",'" + BufferProductCode + "','" + BufferProductNameA + "','" + BufferProductNameE + "'," + BufferCenterID + ",'" + BufferCenterCode + "','" + BufferCenterNameA + "','" + BufferCenterNameE + "'," + mentID + ",'" + mentCode + "','" + mentNameA + "','" + mentNameE + "'," + SysData.CurrentUser.ID + ",GetDate() ) ";
                return Returned;
            }
        }
        public string EditStr
        {
            get
            {
                string Returned = " update ERPBufferMeasure set " + "MeasureID=" + MeasureID + "" +
           ",MeasureWorkOrder='" + MeasureWorkOrder + "'" +
           ",MeasureDate=" + (MeasureDate.ToOADate() - 2).ToString() + "" +
           ",MeasureTime=" + (MeasureTime.ToOADate() - 2).ToString() + "" +
           ",MeasureValue=" + MeasureValue + "" +
           ",MeasureFirstValue=" + MeasureFirstValue + "" +
           ",MeasureMinValue=" + MeasureMinValue + "" +
           ",MeasureMaxValue=" + MeasureMaxValue + "" +
           ",MeasureMinTime=" + (MeasureMinTime.ToOADate() - 2).ToString() + "" +
           ",BufferID=" + BufferID + "" +
           ",BufferCode='" + BufferCode + "'" +
           ",BufferDesc='" + BufferDesc + "'" +
           ",BufferSize=" + BufferSize + "" +
           ",BufferTag='" + BufferTag + "'" +
           ",BufferTypeID=" + BufferTypeID + "" +
           ",BufferTypeCode='" + BufferTypeCode + "'" +
           ",BufferTypeNameA='" + BufferTypeNameA + "'" +
           ",BufferTypeNameE='" + BufferTypeNameE + "'" +
           ",BufferMachineID=" + BufferMachineID + "" +
           ",BufferMachineCeneter=" + BufferMachineCeneter + "" +
           ",BufferMachineFlow=" + BufferMachineFlow + "" +
           ",BufferMachineCode='" + BufferMachineCode + "'" +
           ",BufferMachineDesc='" + BufferMachineDesc + "'" +
           ",BufferMachineNameA='" + BufferMachineNameA + "'" +
           ",BufferMachineNameE='" + BufferMachineNameE + "'" +
           ",BufferProductID=" + BufferProductID + "" +
           ",BufferProductCode='" + BufferProductCode + "'" +
           ",BufferProductNameA='" + BufferProductNameA + "'" +
           ",BufferProductNameE='" + BufferProductNameE + "'" +
           ",BufferCenterID=" + BufferCenterID + "" +
           ",BufferCenterCode='" + BufferCenterCode + "'" +
           ",BufferCenterNameA='" + BufferCenterNameA + "'" +
           ",BufferCenterNameE='" + BufferCenterNameE + "'" +
           ",BufferMeasurementID=" + mentID + "" +
           ",BufferMeasurementCode='" + mentCode + "'" +
           ",BufferMeasurementNameA='" + mentNameA + "'" +
           ",BufferMeasurementNameE='" + mentNameE + "'" + ",UsrUpd=" + SysData.CurrentUser.ID + @",TimUpd=GetDate()  where ";
                return Returned;
            }
        }
        public string DeleteStr
        {
            get
            {
                string Returned = " update ERPBufferMeasure set Dis = GetDate() where  ";
                return Returned;
            }
        }
        public string SearchStr
        {
            get
            {
                string Returned = @" SELECT dbo.ERPBufferMeasure.MeasureID, dbo.ERPBufferMeasure.MeasureWorkOrder, dbo.ERPBufferMeasure.MeasureDate, dbo.ERPBufferMeasure.MeasureTime, dbo.ERPBufferMeasure.MeasureValue, 
                  dbo.ERPBufferMeasure.MeasureFirstValue, dbo.ERPBufferMeasure.MeasureMinValue, dbo.ERPBufferMeasure.MeasureMaxValue, dbo.ERPBufferMeasure.MeasureMinTime, dbo.ERPBuffer.BufferID, dbo.ERPBuffer.BufferCode, 
                  dbo.ERPBuffer.BufferDesc, dbo.ERPBuffer.BufferSize, dbo.ERPBuffer.BufferTag,dbo.ERPBuffer.BufferIsPerHour, dbo.ERPBufferType.TypeID AS BufferTypeID, dbo.ERPBufferType.TypeCode AS BufferTypeCode, dbo.ERPBufferType.TypeNameA AS BufferTypeNameA, 
                  dbo.ERPBufferType.TypeNameE AS BufferTypeNameE, dbo.ERPMachine.MachineID AS BufferMachineID, dbo.ERPMachine.MachineCenter AS BufferMachineCeneter, dbo.ERPMachine.MachineFlow AS BufferMachineFlow, 
                  dbo.ERPMachine.MachineCode AS BufferMachineCode, dbo.ERPMachine.MachineDesc AS BufferMachineDesc, dbo.ERPMachine.MachineNameA AS BufferMachineNameA, dbo.ERPMachine.MachineNameE AS BufferMachineNameE, 
                  dbo.ERPProduct.ProductID AS BufferProductID, dbo.ERPProduct.ProductCode AS BufferProductCode, dbo.ERPProduct.ProductNameA AS BufferProductNameA, dbo.ERPProduct.ProductNameE AS BufferProductNameE,dbo.ERPProduct.ProductIsComposed
 as BufferProductIsComposed, 
                  dbo.ERPWorkCenter.CenterID AS BufferCenterID, dbo.ERPWorkCenter.CenterCode AS BufferCenterCode, dbo.ERPWorkCenter.CenterNameA AS BufferCenterNameA, dbo.ERPWorkCenter.CenterNameE AS BufferCenterNameE, 
                  dbo.ERPMeasurementUnit.MeasurementID AS BufferMeasurementID, dbo.ERPMeasurementUnit.MeasurementCode AS BufferMeasurementCode, dbo.ERPMeasurementUnit.MeasurementNameA AS BufferMeasurementNameA, 
                  dbo.ERPMeasurementUnit.MeasurementNameE AS BufferMeasurementNameE,
dbo.ERPPLC.PLCID, dbo.ERPPLC.PLCDesc, dbo.ERPPLC.PLCIP

FROM     dbo.ERPBufferMeasure INNER JOIN
                  dbo.ERPBuffer ON dbo.ERPBufferMeasure.BufferID = dbo.ERPBuffer.BufferID INNER JOIN
                  dbo.ERPBufferType ON dbo.ERPBuffer.BufferType = dbo.ERPBufferType.TypeID left outer JOIN
                  dbo.ERPMeasurementUnit ON dbo.ERPBuffer.BufferMeasurement = dbo.ERPMeasurementUnit.MeasurementID LEFT OUTER JOIN
                  dbo.ERPWorkCenter ON dbo.ERPBuffer.BufferWorkCenter = dbo.ERPWorkCenter.CenterID LEFT OUTER JOIN
                  dbo.ERPProduct ON dbo.ERPBuffer.BufferProduct = dbo.ERPProduct.ProductID LEFT OUTER JOIN
                  dbo.ERPMachine ON dbo.ERPBuffer.BufferMachine = dbo.ERPMachine.MachineID 
     INNER JOIN
                  dbo.ERPPLC ON dbo.ERPBuffer.BufferPLC = dbo.ERPPLC.PLCID ";
                if (_OnlyLastRead)
                {
                    string strMaxMeasure = @"SELECT BufferID AS MaxBufferID, MAX(MeasureID) AS MaxMeasureID, MeasureDate AS MaxMeasureDate
FROM     dbo.ERPBufferMeasure
GROUP BY BufferID, MeasureDate";
                    Returned += @" INNER JOIN
                      ("+strMaxMeasure+@") AS MaxBufferMeasureTable ON dbo.ERPBufferMeasure.BufferID = MaxBufferMeasureTable.MaxBufferID AND
                  dbo.ERPBufferMeasure.MeasureDate = MaxBufferMeasureTable.MaxMeasureDate AND dbo.ERPBufferMeasure.MeasureID = MaxBufferMeasureTable.MaxMeasureID ";
                }
                    return Returned;
            }
        }
        #endregion
        #region Private Method
        void SetData(DataRow objDr)
        {

            if (objDr.Table.Columns["MeasureID"] != null)
                int.TryParse(objDr["MeasureID"].ToString(), out _MeasureID);

            if (objDr.Table.Columns["MeasureWorkOrder"] != null)
                _MeasureWorkOrder = objDr["MeasureWorkOrder"].ToString();

            if (objDr.Table.Columns["MeasureDate"] != null)
                DateTime.TryParse(objDr["MeasureDate"].ToString(), out _MeasureDate);

            if (objDr.Table.Columns["MeasureTime"] != null)
                DateTime.TryParse(objDr["MeasureTime"].ToString(), out _MeasureTime);

            if (objDr.Table.Columns["MeasureValue"] != null)
                double.TryParse(objDr["MeasureValue"].ToString(), out _MeasureValue);

            if (objDr.Table.Columns["MeasureFirstValue"] != null)
                double.TryParse(objDr["MeasureFirstValue"].ToString(), out _MeasureFirstValue);

            if (objDr.Table.Columns["MeasureMinValue"] != null)
                double.TryParse(objDr["MeasureMinValue"].ToString(), out _MeasureMinValue);

            if (objDr.Table.Columns["MeasureMaxValue"] != null)
                double.TryParse(objDr["MeasureMaxValue"].ToString(), out _MeasureMaxValue);

            if (objDr.Table.Columns["MeasureMinTime"] != null)
                DateTime.TryParse(objDr["MeasureMinTime"].ToString(), out _MeasureMinTime);

            if (objDr.Table.Columns["BufferID"] != null)
                int.TryParse(objDr["BufferID"].ToString(), out _BufferID);

            if (objDr.Table.Columns["BufferCode"] != null)
                _BufferCode = objDr["BufferCode"].ToString();

            if (objDr.Table.Columns["BufferDesc"] != null)
                _BufferDesc = objDr["BufferDesc"].ToString();

            if (objDr.Table.Columns["BufferSize"] != null)
                double.TryParse(objDr["BufferSize"].ToString(), out _BufferSize);

            if (objDr.Table.Columns["BufferTag"] != null)
                _BufferTag = objDr["BufferTag"].ToString();

            if (objDr.Table.Columns["BufferTypeID"] != null)
                int.TryParse(objDr["BufferTypeID"].ToString(), out _BufferTypeID);

            if (objDr.Table.Columns["BufferTypeCode"] != null)
                _BufferTypeCode = objDr["BufferTypeCode"].ToString();

            if (objDr.Table.Columns["BufferTypeNameA"] != null)
                _BufferTypeNameA = objDr["BufferTypeNameA"].ToString();

            if (objDr.Table.Columns["BufferTypeNameE"] != null)
                _BufferTypeNameE = objDr["BufferTypeNameE"].ToString();

            if (objDr.Table.Columns["BufferMachineID"] != null)
                int.TryParse(objDr["BufferMachineID"].ToString(), out _BufferMachineID);

            if (objDr.Table.Columns["BufferMachineCeneter"] != null)
                int.TryParse(objDr["BufferMachineCeneter"].ToString(), out _BufferMachineCeneter);

            if (objDr.Table.Columns["BufferMachineFlow"] != null)
                int.TryParse(objDr["BufferMachineFlow"].ToString(), out _BufferMachineFlow);

            if (objDr.Table.Columns["BufferMachineCode"] != null)
                _BufferMachineCode = objDr["BufferMachineCode"].ToString();

            if (objDr.Table.Columns["BufferMachineDesc"] != null)
                _BufferMachineDesc = objDr["BufferMachineDesc"].ToString();

            if (objDr.Table.Columns["BufferMachineNameA"] != null)
                _BufferMachineNameA = objDr["BufferMachineNameA"].ToString();

            if (objDr.Table.Columns["BufferMachineNameE"] != null)
                _BufferMachineNameE = objDr["BufferMachineNameE"].ToString();

            if (objDr.Table.Columns["BufferProductID"] != null)
                int.TryParse(objDr["BufferProductID"].ToString(), out _BufferProductID);

            if (objDr.Table.Columns["BufferProductCode"] != null)
                _BufferProductCode = objDr["BufferProductCode"].ToString();

            if (objDr.Table.Columns["BufferProductNameA"] != null)
                _BufferProductNameA = objDr["BufferProductNameA"].ToString();

            if (objDr.Table.Columns["BufferProductNameE"] != null)
                _BufferProductNameE = objDr["BufferProductNameE"].ToString();

            if (objDr.Table.Columns["BufferCenterID"] != null)
                int.TryParse(objDr["BufferCenterID"].ToString(), out _BufferCenterID);

            if (objDr.Table.Columns["BufferCenterCode"] != null)
                _BufferCenterCode = objDr["BufferCenterCode"].ToString();

            if (objDr.Table.Columns["BufferCenterNameA"] != null)
                _BufferCenterNameA = objDr["BufferCenterNameA"].ToString();

            if (objDr.Table.Columns["BufferCenterNameE"] != null)
                _BufferCenterNameE = objDr["BufferCenterNameE"].ToString();

            if (objDr.Table.Columns["BufferMeasurementID"] != null)
                int.TryParse(objDr["BufferMeasurementID"].ToString(), out _mentID);

            if (objDr.Table.Columns["BufferMeasurementCode"] != null)
                _mentCode = objDr["BufferMeasurementCode"].ToString();

            if (objDr.Table.Columns["BufferMeasurementNameA"] != null)
                _mentNameA = objDr["BufferMeasurementNameA"].ToString();

            if (objDr.Table.Columns["BufferMeasurementNameE"] != null)
                _mentNameE = objDr["BufferMeasurementNameE"].ToString();
            if (objDr.Table.Columns["BufferIsPerHour"] != null)
                bool.TryParse(objDr["BufferIsPerHour"].ToString(), out _BufferIsPerHour);
            if (objDr.Table.Columns["BufferProductIsComposed"] != null)
                bool.TryParse(objDr["BufferProductIsComposed"].ToString(), out _BufferProductIsComposed); 
            if(_BufferProductIsComposed)
            {

            }
        }

        #endregion
        #region Public Method 
        public void Add()
        {
            string strSql = AddStr;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public void Edit()
        {
            string strSql = EditStr;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public void Delete()
        {
            string strSql = DeleteStr;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public DataTable Search()
        {
            //_OnlyLastRead = true;
            string strSql = SearchStr + " where (1=1) ";
           // _BufferID = 66;
            //_IsDateRange = true;
            //_StartDate = DateTime.Now.AddDays(-1);
            //_EndDate = DateTime.Now.AddDays(-1);
            if (_BufferID != 0)
                strSql += " and dbo.ERPBuffer.BufferID="+_BufferID;
            if (_IsDateRange)
                strSql += " and dbo.ERPBufferMeasure.MeasureDate >="+(_StartDate.Date.ToOADate()-2) + " and dbo.ERPBufferMeasure.MeasureDate <"+(_EndDate.Date.ToOADate()-1);
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        #endregion

    }
}