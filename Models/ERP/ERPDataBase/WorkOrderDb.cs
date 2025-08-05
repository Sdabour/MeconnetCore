using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using SharpVision.SystemBase;
namespace AlgorithmatENM.ERP.ERPDataBase
{
    public class WorkOrderDb
    {

        #region Constructor
        public WorkOrderDb()
        {
        }
        public WorkOrderDb(DataRow objDr)
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
        int _MO;
        public int MO
        {
            set => _MO = value;
            get => _MO;
        }
        string _Ref;
        public string Ref
        {
            set => _Ref = value;
            get => _Ref;
        }
        string _Desc;
        public string Desc
        {
            set => _Desc = value;
            get => _Desc;
        }
        int _Type;
        public int Type
        {
            set => _Type = value;
            get => _Type;
        }
        int _Product;
        public int Product
        {
            set => _Product = value;
            get => _Product;
        }
        DateTime _Date;
        public DateTime Date
        {
            set => _Date = value;
            get => _Date;
        }
        DateTime _Time;
        public DateTime Time
        {
            set => _Time = value;
            get => _Time;
        }
        double _Quantity;
        public double Quantity
        {
            set => _Quantity = value;
            get => _Quantity;
        }
        int _Periority;
        public int Periority
        {
            set => _Periority = value;
            get => _Periority;
        }
        string _ProductCode;
        public string ProductCode
        {
            set => _ProductCode = value;
            get => _ProductCode;
        }
        string _ProductNameA;
        public string ProductNameA
        {
            set => _ProductNameA = value;
            get => _ProductNameA;
        }
        string _ProductNameE;
        public string ProductNameE
        {
            set => _ProductNameE = value;
            get => _ProductNameE;
        }
        int _ProductMeasurementUnit;
        public int ProductMeasurementUnit
        {
            set => _ProductMeasurementUnit = value;
            get => _ProductMeasurementUnit;
        }
        string _ProductMeasurementCode;
        public string ProductMeasurementCode
        {
            set => _ProductMeasurementCode = value;
            get => _ProductMeasurementCode;
        }
        string _ProductMeasurementNameA;
        public string ProductMeasurementNameA
        {
            set => _ProductMeasurementNameA = value;
            get => _ProductMeasurementNameA;
        }
        string _ProductMeasurementNameE;
        public string ProductMeasurementNameE
        {
            set => _ProductMeasurementNameE = value;
            get => _ProductMeasurementNameE;
        }
        string _MachineCode;
        public string MachineCode
        {
            set => _MachineCode = value;
            get => _MachineCode;
        }
        int _MachineID;
        public int MachineID
        {
            set => _MachineID = value;
            get => _MachineID;
        }
        string _MachineDesc;
        public string MachineDesc
        {
            set => _MachineDesc = value;
            get => _MachineDesc;
        }
        int _MachineCenterID;
        public int MachineCenterID
        {
            set => _MachineCenterID = value;
            get => _MachineCenterID;
        }
        string _MOIDs;
        public string MOIDs { set=>_MOIDs = value; }
        public string AddStr
        {
            get
            {
                string Returned = " insert into ERPWorkOrder (WorkOrderMO,WorkOrderRef,WorkOrderDesc,WorkOrderType,WorkOrderProduct,WorkOrderDate,WorkOrderTime,WorkOrderQuantity,WorkOrderPeriority,UsrIns,TimIns) values (" + MO + ",'" + Ref + "','" + Desc + "'," + Type + "," + Product + "," + (Date.ToOADate() - 2).ToString() + "," + (Time.ToOADate() - 2).ToString() + "," + Quantity + "," + Periority + "," + SysData.CurrentUser.ID + ",GetDate() ) ";
                return Returned;
            }
        }
        public string EditStr
        {
            get
            {
                string Returned = " update ERPWorkOrder set " + "WorkOrderID=" + ID + "" +
           ",WorkOrderMO=" + MO + "" +
           ",WorkOrderRef='" + Ref + "'" +
           ",WorkOrderDesc='" + Desc + "'" +
           ",WorkOrderType=" + Type + "" +
           ",WorkOrderProduct=" + Product + "" +
           ",WorkOrderDate=" + (Date.ToOADate() - 2).ToString() + "" +
           ",WorkOrderTime=" + (Time.ToOADate() - 2).ToString() + "" +
           ",WorkOrderQuantity=" + Quantity + "" +
           ",WorkOrderPeriority=" + Periority + "" +
           ",WorkOrderProductCode='" + ProductCode + "'" +
           ",WorkOrderProductNameA='" + ProductNameA + "'" +
           ",WorkOrderProductNameE='" + ProductNameE + "'" +
           ",WorkOrderProductMeasurementUnit=" + ProductMeasurementUnit + "" +
           ",WorkOrderProductMeasurementCode='" + ProductMeasurementCode + "'" +
           ",WorkOrderProductMeasurementNameA='" + ProductMeasurementNameA + "'" +
           ",WorkOrderProductMeasurementNameE='" + ProductMeasurementNameE + "'" + ",UsrUpd=" + SysData.CurrentUser.ID + @",TimUpd=GetDate()  where ";
                return Returned;
            }
        }
        public string DeleteStr
        {
            get
            {
                string Returned = " update ERPWorkOrder set Dis = GetDate() where  ";
                return Returned;
            }
        }
        public string SearchStr
        {
            get
            {
                string strMachine = @"SELECT dbo.ERPMachine.MachineCode AS WorkOrderMachineCode, dbo.ERPMachine.MachineID AS WorkOrderMachineID, dbo.ERPMachine.MachineDesc AS WorkOrderMachineDesc, 
                  dbo.ERPWorkCenter.CenterID AS WorkOrderMachineCenterID, dbo.ERPWorkCenter.CenterCode AS WorkOrderMachineCenterCode, dbo.ERPWorkCenter.CenterNameA AS WorkOrderMachineCenterNameA
FROM     dbo.ERPWorkCenter INNER JOIN
                  dbo.ERPMachine ON dbo.ERPWorkCenter.CenterID = dbo.ERPMachine.MachineCenter";
                string Returned = @" SELECT dbo.ERPWorkOrder.WorkOrderID, dbo.ERPWorkOrder.WorkOrderMO, dbo.ERPWorkOrder.WorkOrderRef, dbo.ERPWorkOrder.WorkOrderDesc, dbo.ERPWorkOrder.WorkOrderType, dbo.ERPWorkOrder.WorkOrderProduct,                    dbo.ERPWorkOrder.WorkOrderDate, dbo.ERPWorkOrder.WorkOrderTime, dbo.ERPWorkOrder.WorkOrderQuantity, dbo.ERPWorkOrder.WorkOrderPeriority, dbo.ERPProduct.ProductCode AS WorkOrderProductCode,                    dbo.ERPProduct.ProductNameA AS WorkOrderProductNameA, dbo.ERPProduct.ProductNameE AS WorkOrderProductNameE, dbo.ERPProduct.ProductMeasurementUnit AS WorkOrderProductMeasurementUnit,                    dbo.ERPMeasurementUnit.MeasurementCode AS WorkOrderProductMeasurementCode, dbo.ERPMeasurementUnit.MeasurementNameA AS WorkOrderProductMeasurementNameA,                    dbo.ERPMeasurementUnit.MeasurementNameE AS WorkOrderProductMeasurementNameE,MachineTable.*
   FROM     dbo.ERPWorkOrder INNER JOIN                   dbo.ERPProduct ON dbo.ERPWorkOrder.WorkOrderProduct = dbo.ERPProduct.ProductID left outer  JOIN                   dbo.ERPMeasurementUnit ON dbo.ERPProduct.ProductMeasurementUnit = dbo.ERPMeasurementUnit.MeasurementID 
                  left outer join ("+strMachine+ @") as MachineTable 
     ON dbo.ERPWorkOrder.WorkOrderDesc = MachineTable.WorkOrderMachineCode ";
                return Returned;
            }
        }
        #endregion 
            #region Private Method
                 void SetData(DataRow objDr)
        {

            if (objDr.Table.Columns["WorkOrderID"] != null)
                int.TryParse(objDr["WorkOrderID"].ToString(), out _ID);

            if (objDr.Table.Columns["WorkOrderMO"] != null)
                int.TryParse(objDr["WorkOrderMO"].ToString(), out _MO);

            if (objDr.Table.Columns["WorkOrderRef"] != null)
                _Ref = objDr["WorkOrderRef"].ToString();

            if (objDr.Table.Columns["WorkOrderDesc"] != null)
                _Desc = objDr["WorkOrderDesc"].ToString();

            if (objDr.Table.Columns["WorkOrderType"] != null)
                int.TryParse(objDr["WorkOrderType"].ToString(), out _Type);

            if (objDr.Table.Columns["WorkOrderProduct"] != null)
                int.TryParse(objDr["WorkOrderProduct"].ToString(), out _Product);

            if (objDr.Table.Columns["WorkOrderDate"] != null)
                DateTime.TryParse(objDr["WorkOrderDate"].ToString(), out _Date);

            if (objDr.Table.Columns["WorkOrderTime"] != null)
                DateTime.TryParse(objDr["WorkOrderTime"].ToString(), out _Time);

            if (objDr.Table.Columns["WorkOrderQuantity"] != null)
                double.TryParse(objDr["WorkOrderQuantity"].ToString(), out _Quantity);

            if (objDr.Table.Columns["WorkOrderPeriority"] != null)
                int.TryParse(objDr["WorkOrderPeriority"].ToString(), out _Periority);

            if (objDr.Table.Columns["WorkOrderProductCode"] != null)
                _ProductCode = objDr["WorkOrderProductCode"].ToString();

            if (objDr.Table.Columns["WorkOrderProductNameA"] != null)
                _ProductNameA = objDr["WorkOrderProductNameA"].ToString();

            if (objDr.Table.Columns["WorkOrderProductNameE"] != null)
                _ProductNameE = objDr["WorkOrderProductNameE"].ToString();

            if (objDr.Table.Columns["WorkOrderProductMeasurementUnit"] != null)
                int.TryParse(objDr["WorkOrderProductMeasurementUnit"].ToString(), out _ProductMeasurementUnit);

            if (objDr.Table.Columns["WorkOrderProductMeasurementCode"] != null)
                _ProductMeasurementCode = objDr["WorkOrderProductMeasurementCode"].ToString();

            if (objDr.Table.Columns["WorkOrderProductMeasurementNameA"] != null)
                _ProductMeasurementNameA = objDr["WorkOrderProductMeasurementNameA"].ToString();

            if (objDr.Table.Columns["WorkOrderProductMeasurementNameE"] != null)
                _ProductMeasurementNameE = objDr["WorkOrderProductMeasurementNameE"].ToString();
            if (objDr.Table.Columns["WorkOrderMachineCode"] != null)
                _MachineCode = objDr["WorkOrderMachineCode"].ToString();

            if (objDr.Table.Columns["WorkOrderMachineID"] != null)
                int.TryParse(objDr["WorkOrderMachineID"].ToString(), out _MachineID);

            if (objDr.Table.Columns["WorkOrderMachineDesc"] != null)
                _MachineDesc = objDr["WorkOrderMachineDesc"].ToString();

            if (objDr.Table.Columns["WorkOrderMachineCenterID"] != null)
                int.TryParse(objDr["WorkOrderMachineCenterID"].ToString(), out _MachineCenterID);
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
            string strSql = SearchStr + " where (1=1) ";
            if(_MOIDs!= null &&_MOIDs!= "")
            {
                strSql += " and WorkOrderMO in ("+_MOIDs+") ";
            }
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        #endregion 
    }
}
