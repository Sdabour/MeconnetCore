using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using SharpVision.SystemBase;
using System.Data.SqlClient;
namespace AlgorithmatENM.ERP.ERPDataBase
{
    public class BufferDb
    {

        #region Constructor
        public BufferDb()
        {
        }
        public BufferDb(DataRow objDr)
        {
            SetData(objDr);
        }

        #endregion
        #region Properties
        int _ID;
        public int ID
        {
            set => _ID = value;
            get => _ID;
        }
        int _Type;
        public int Type
        {
            set => _Type = value;
            get => _Type;
        }
        string _Code;
        public string Code
        {
            set => _Code = value;
            get => _Code;
        }
        string _Desc;
        public string Desc
        {
            set => _Desc = value;
            get => _Desc;
        }
        double _Size;
        public double Size
        {
            set => _Size = value;
            get => _Size;
        }
        string _Tag;
        public string Tag
        {
            set => _Tag = value;
            get => _Tag;
        }
        int _WorkCenter;
        public int WorkCenter
        {
            set => _WorkCenter = value;
            get => _WorkCenter;
        }
        int _Machine;
        public int Machine
        {
            set => _Machine = value;
            get => _Machine;
        }
        int _Product;
        public int Product
        {
            set => _Product = value;
            get => _Product;
        }
        int _Measurement;
        public int Measurement
        {
            set => _Measurement = value;
            get => _Measurement;
        }
        int _PLC;
        public int PLC
        {
            set => _PLC = value;
            get => _PLC;
        }
        int _PLCDataType;
        public int PLCDataType
        {
            set => _PLCDataType = value;
            get => _PLCDataType;
        }
        int _PLCVarType;
        public int PLCVarType
        {
            set => _PLCVarType = value;
            get => _PLCVarType;
        }
        double _Threshold;
        public double Threshold
        {
            set => _Threshold = value;
            get => _Threshold;
        }
        public string AddStr
        {
            get
            {
                string Returned = " insert into ERPBuffer (BufferID,BufferType,BufferCode,BufferDesc,BufferSize,BufferTag,BufferWorkCenter,BufferMachine,BufferProduct,BufferMeasurement,BufferPLC,BufferPLCDataType,BufferPLCVarType,BufferThreshold,UsrIns,TimIns) values (," + ID + "," + Type + ",'" + Code + "','" + Desc + "'," + Size + ",'" + Tag + "'," + WorkCenter + "," + Machine + "," + Product + "," + Measurement + "," + PLC + "," + PLCDataType + "," + PLCVarType + "," + _Threshold + "," + SysData.CurrentUser.ID + ",GetDate() ) ";
                return Returned;
            }
        }
        public string EditStr
        {
            get
            {
                string Returned = " update ERPBuffer set " + "BufferID=" + ID + "" +
           ",BufferType=" + Type + "" +
           ",BufferCode='" + Code + "'" +
           ",BufferDesc='" + Desc + "'" +
           ",BufferSize=" + Size + "" +
           ",BufferTag='" + Tag + "'" +
           ",BufferWorkCenter=" + WorkCenter + "" +
           ",BufferMachine=" + Machine + "" +
           ",BufferProduct=" + Product + "" +
           ",BufferMeasurement=" + Measurement + "" +
           ",BufferPLC=" + PLC + "" +
           ",BufferPLCDataType=" + PLCDataType + "" +
           ",BufferPLCVarType=" + PLCVarType + "" +
           ",BufferThreshold=" + _Threshold +
           ",UsrUpd=" + SysData.CurrentUser.ID + @",TimUpd=GetDate()  where ";
                return Returned;
            }
        }
        public string DeleteStr
        {
            get
            {
                string Returned = " update ERPBuffer set Dis = GetDate() where  ";
                return Returned;
            }
        }
        public string SearchStr
        {
            get
            {
                string Returned = @"SELECT dbo.ERPBuffer.BufferID, dbo.ERPBuffer.BufferType, dbo.ERPBuffer.BufferCode, dbo.ERPBuffer.BufferDesc, dbo.ERPBuffer.BufferSize, dbo.ERPBuffer.BufferTag, dbo.ERPBuffer.BufferWorkCenter, dbo.ERPBuffer.BufferMachine, 
                  dbo.ERPBuffer.BufferProduct, dbo.ERPBuffer.BufferMeasurement, dbo.ERPBuffer.BufferPLC, dbo.ERPBuffer.BufferPLCDataType, dbo.ERPBuffer.BufferPLCVarType,dbo.ERPBuffer.BufferThreshold,PLCTable.*  
   FROM     dbo.ERPBuffer INNER JOIN
                  dbo.ERPBufferType AS BufferTypeTable ON dbo.ERPBuffer.BufferType = BufferTypeTable.TypeID LEFT OUTER JOIN
                  dbo.ERPMeasurementUnit AS MeasureUnitTable ON dbo.ERPBuffer.BufferMeasurement = MeasureUnitTable.MeasurementID LEFT OUTER JOIN
                   (" + new PLCDb().SearchStr + @") AS PLCTable ON dbo.ERPBuffer.BufferPLC = PLCTable.PLCID LEFT OUTER JOIN
                  dbo.ERPMachine AS MachineTable ON dbo.ERPBuffer.BufferMachine = MachineTable.MachineID LEFT OUTER JOIN
                  dbo.ERPProduct AS ProductTable ON dbo.ERPBuffer.BufferProduct = ProductTable.ProductID LEFT OUTER JOIN
                  dbo.ERPWorkCenter AS WorkCenterTable ON dbo.ERPBuffer.BufferWorkCenter = WorkCenterTable.CenterID ";
                return Returned;
            }
        }
        DataTable _BufferTable;
        public DataTable BufferTable { set => _BufferTable = value; }

        #endregion
        #region Private Method
        void SetData(DataRow objDr)
        {

            if (objDr.Table.Columns["BufferID"] != null)
                int.TryParse(objDr["BufferID"].ToString(), out _ID);

            if (objDr.Table.Columns["BufferType"] != null)
                int.TryParse(objDr["BufferType"].ToString(), out _Type);

            if (objDr.Table.Columns["BufferCode"] != null)
                _Code = objDr["BufferCode"].ToString();

            if (objDr.Table.Columns["BufferDesc"] != null)
                _Desc = objDr["BufferDesc"].ToString();

            if (objDr.Table.Columns["BufferSize"] != null)
                double.TryParse(objDr["BufferSize"].ToString(), out _Size);

            if (objDr.Table.Columns["BufferThreshold"] != null)
                double.TryParse(objDr["BufferThreshold"].ToString(), out _Threshold);

            if (objDr.Table.Columns["BufferTag"] != null)
                _Tag = objDr["BufferTag"].ToString();

            if (objDr.Table.Columns["BufferWorkCenter"] != null)
                int.TryParse(objDr["BufferWorkCenter"].ToString(), out _WorkCenter);

            if (objDr.Table.Columns["BufferMachine"] != null)
                int.TryParse(objDr["BufferMachine"].ToString(), out _Machine);

            if (objDr.Table.Columns["BufferProduct"] != null)
                int.TryParse(objDr["BufferProduct"].ToString(), out _Product);

            if (objDr.Table.Columns["BufferMeasurement"] != null)
                int.TryParse(objDr["BufferMeasurement"].ToString(), out _Measurement);

            if (objDr.Table.Columns["BufferPLC"] != null)
                int.TryParse(objDr["BufferPLC"].ToString(), out _PLC);

            if (objDr.Table.Columns["BufferPLCDataType"] != null)
                int.TryParse(objDr["BufferPLCDataType"].ToString(), out _PLCDataType);

            if (objDr.Table.Columns["BufferPLCVarType"] != null)
                int.TryParse(objDr["BufferPLCVarType"].ToString(), out _PLCVarType);
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
            string strSql = SearchStr + " where ERPBuffer.Dis is null ";


            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        public void SaveBufferTable()
        {
            if (_BufferTable == null || _BufferTable.Rows.Count == 0)
                return;
            SysData.SharpVisionBaseDb.ExecuteNonQuery("truncate table ERPBufferMeasureTemp");

            SqlBulkCopy objCopy = new SqlBulkCopy(SysData.SharpVisionBaseDb.sqlConnection.ConnectionString);
            objCopy.DestinationTableName = "ERPBufferMeasureTemp";
            objCopy.WriteToServer(_BufferTable);
            SysData.SharpVisionBaseDb.ExecuteNonQuery("exec SaveBufferMeasurementData");


        }
        #endregion
    }
}