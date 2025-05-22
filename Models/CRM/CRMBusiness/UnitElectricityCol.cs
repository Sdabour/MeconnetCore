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
namespace SharpVision.CRM.CRMBusiness
{
   public class UnitElectricityCol : BaseCol
   {
       #region Private Data

       #endregion
       #region Constructors
       public UnitElectricityCol(bool blIsEmpty)
       { }
       public UnitElectricityCol(CellBiz objCellBiz, CustomerBiz objCustomerBiz,string strUnitCode ,
           int intElectricityUnitType,int intUnitType,int intFloor,int intMeterStatus,int intIlligalAction )
       {
           UnitElectricityDb objDb = new UnitElectricityDb();
           if(objCellBiz == null)
               objCellBiz = new CellBiz();
           if(objCustomerBiz == null)
               objCustomerBiz = new CustomerBiz();

           objDb.CustomerID = objCustomerBiz.ID;
           if (objCellBiz.ID != 0 && objCellBiz.ID == objCellBiz.FamilyID)
               objDb.CellFamily = objCellBiz.FamilyID;
           else if (objCellBiz.ID != 0)
               objDb.CellIDs = objCellBiz.IDsStr;
           objDb.UnitCode = strUnitCode;
           objDb.ElementUnitType = intElectricityUnitType;
           objDb.UnitType = intUnitType;
           objDb.Floor = intFloor;
           objDb.ElectricityMeterIllegalAction = intIlligalAction;
           objDb.ElectricityMeterStatus = intMeterStatus;
           DataTable dtTemp = objDb.Search();
           foreach (DataRow objDr in dtTemp.Rows)
           {
               Add(new UnitElectricityBiz(objDr));
           }

       }
        #endregion
       #region Public Properties
       public UnitElectricityBiz this[int intIndex]
       {
           get 
           {
               return (UnitElectricityBiz)List[intIndex];
           }
       }
        #endregion
       #region Private Methods

        #endregion
       #region Public Methods
       public void Add(UnitElectricityBiz objBiz)
       {
           List.Add(objBiz);
       }
       public DataTable GetTable()
       {
           DataTable Returned = new DataTable();
           Returned.Columns.AddRange(new DataColumn[] { new DataColumn("UnitElementID"),new DataColumn("UnitID"),
               new DataColumn("UnitHasElectricityMeter",Type.GetType("System.Boolean")),new DataColumn("UnitElectricityMeterStartDate")
                ,new DataColumn("UnitElectricityMeterOwner"),new DataColumn("UnitElectricityMeterStatus"),
                new DataColumn("UnitElectricityMeterIllegalAction"),new DataColumn("UnitElecticityMeterNotes"),
               new DataColumn("UnitElectricityPreMeterNo"),new DataColumn("UnitElectricityMeterNo"),
               new DataColumn("UnitElectricityMeterPower"),new DataColumn("CellID"),new DataColumn("UnitDesc")});
           DataRow objDr;
           foreach (UnitElectricityBiz objBiz in this)
           {
               objDr = Returned.NewRow();
               objDr["UnitElementID"] = objBiz.ID;
               objDr["UnitID"] = objBiz.UnitBiz.ID;
               objDr["UnitHasElectricityMeter"] = objBiz.HasElectricityMeter  ;
               objDr["UnitElectricityMeterStartDate"] = objBiz.ElectricityMeterHasStartDate ?
                   SysUtility.Approximate(objBiz.ElectricityMeterStartDate.ToOADate() - 2, 1, ApproximateType.Down).ToString() : "";
               objDr["UnitElectricityMeterOwner"] = objBiz.ElectricityMeterOwner;
               objDr["UnitElectricityMeterStatus"] = (int)objBiz.ElectricityMeterStatus;
               objDr["UnitElectricityMeterIllegalAction"] = (int)objBiz.ElectricityMeterIllegalAction;
               objDr["UnitElecticityMeterNotes"] = objBiz.ElecticityMeterNotes;
               objDr["UnitElectricityPreMeterNo"] = objBiz.PreMeterNo;
               objDr["UnitElectricityMeterNo"] = objBiz.MeterNo;
               objDr["UnitElectricityMeterPower"] = objBiz.Power;
               objDr["CellID"] = objBiz.CellBiz.ID;
               objDr["UnitDesc"] = objBiz.UnitDesc;
               Returned.Rows.Add(objDr);
           }
           return Returned;
       }
       public void Edit()
       {
           DataTable dtTemp = GetTable();
           UnitElectricityDb objDb = new UnitElectricityDb();
           objDb.ElectricityTable = dtTemp;
           objDb.EditCol();
       }
        #endregion
   }
}
