using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.SystemBase;
using System.Data;
using System.Data.SqlClient;
using SharpVision.Base.BaseDataBase;

namespace SharpVision.CRM.CRMDataBase
{
    public class PositionUnitStatisticDb
    {
        #region Private Data
        protected string _ProjectName;
        protected int _TowerNum;
        protected int _TotalResidentialUnit;
        protected int _TotalCommercialUnit;
        protected int _TotalOfficesUnit;
        protected int _DeservedResidentialUnit;
        protected int _DeservedCommercialUnit;
        protected int _DeservedOfficesUnit;
        protected int _RemainingResidentialUnit;
        protected int _RemainingCommercialUnit;
        protected int _RemainingOfficesUnit;
        protected double _TotalValue;
        protected double _RemainingValue;
        #endregion

        #region Constractors
        public PositionUnitStatisticDb()
        { 

        }
        public PositionUnitStatisticDb(DataRow objDR)
        {
            SetData(objDR);
        }
        #endregion

        #region Public Accessorice
        public string ProjectName
        {
            set
            {
                _ProjectName = value;
            }
            get
            {
                return _ProjectName;
            }
        }
        public int TowerNum
        {
            set
            {
                _TowerNum = value;
            }
            get
            {
                return _TowerNum;
            }
        }
        public int TotalResidentialUnit
        {
            set
            {
                _TotalResidentialUnit = value;
            }
            get
            {
                return _TotalResidentialUnit;
            }
        }
        public int TotalCommercialUnit
        {
            set
            {
                _TotalCommercialUnit = value;
            }
            get
            {
                return _TotalCommercialUnit;
            }
        }
        public int TotalOfficesUnit
        {
            set
            {
                _TotalOfficesUnit = value;
            }
            get
            {
                return _TotalOfficesUnit;
            }
        }
        public int DeservedResidentialUnit
        {
            set
            {
                _DeservedResidentialUnit = value;
            }
            get
            {
                return _DeservedResidentialUnit;
            }
        }
        public int DeservedCommercialUnit
        {
            set
            {
                _DeservedCommercialUnit = value;
            }
            get
            {
                return _DeservedCommercialUnit;
            }
        }
        public int DeservedOfficesUnit
        {
            set
            {
                _DeservedOfficesUnit = value;
            }
            get
            {
                return _DeservedOfficesUnit;
            }
        }
        public int RemainingResidentialUnit
        {
            set
            {
                _RemainingResidentialUnit = value;
            }
            get
            {
                return _RemainingResidentialUnit;
            }
        }
        public int RemainingCommercialUnit
        {
            set
            {
                _RemainingCommercialUnit = value;
            }
            get
            {
                return _RemainingCommercialUnit;
            }
        }
        public int RemainingOfficesUnit
        {
            set
            {
                _RemainingOfficesUnit = value;
            }
            get
            {
                return _RemainingOfficesUnit;
            }
        }
        public double TotalValue
        {
            set
            {
                _TotalValue = value;
            }
            get
            {
                return _TotalValue;
            }
        }
        public double RemainingValue
        {
            set
            {
                _RemainingValue = value;
            }
            get
            {
                return _RemainingValue;
            }
        }
        /// <summary>
        /// Presents Project and Tower No
        /// </summary>
        public static string StatisticTowerNo
        {
            get
            {
                string Returned = "SELECT     RPCell_2.CellOrder, RPCell_2.CellNameA, COUNT(DISTINCT RPCell_1.CellID) AS TowerNo, COUNT(DISTINCT dbo.CRMUnit.UnitID) AS TotalUnitNo, RPCell_2.CellID " +
                      " FROM         dbo.CRMUnitCell INNER JOIN "+
                      " dbo.RPCell ON dbo.CRMUnitCell.CellID = dbo.RPCell.CellID INNER JOIN "+
                      " dbo.RPCell RPCell_1 ON dbo.RPCell.CellParentID = RPCell_1.CellID INNER JOIN "+
                      " dbo.RPCell RPCell_2 ON RPCell_1.CellFamilyID = RPCell_2.CellID INNER JOIN "+
                      " dbo.CRMUnit ON dbo.CRMUnitCell.UnitID = dbo.CRMUnit.UnitID "+
                      " GROUP BY RPCell_2.CellOrder,RPCell_2.CellNameA, RPCell_2.CellID "+
                      " order by RPCell_2.CellOrder " ;
                return Returned;
            }
        }
        /// <summary>
        /// Presents Project and Free Unit
        /// </summary>
        public static string StatisticFreeUnit
        {
            get
            {
                string Returned = "SELECT DISTINCT "+
                      " RPCell_1.CellID, RPCell_1.CellNameA, dbo.CRMUnitType.UnitTypeID, dbo.CRMUnitType.UnitTypeNameA, COUNT(DISTINCT dbo.CRMUnitCell.UnitID) "+
                      " AS FreeUnitCount "+
                      " FROM         dbo.RPCell INNER JOIN "+
                      " dbo.CRMUnitCell ON dbo.RPCell.CellID = dbo.CRMUnitCell.CellID INNER JOIN "+
                      " dbo.RPCell RPCell_1 ON dbo.RPCell.CellFamilyID = RPCell_1.CellID INNER JOIN "+
                      " dbo.CRMUnit ON dbo.CRMUnitCell.UnitID = dbo.CRMUnit.UnitID INNER JOIN "+
                      " dbo.CRMUnitType ON dbo.CRMUnit.UnitType = dbo.CRMUnitType.UnitTypeID "+
                      " left outer join CRMReservation   "+
                      " on  dbo.CRMUnit.CurrentReservation = CRMReservation.ReservationID  " +
                      " WHERE     ("+
                      "(CRMReservation.ReservationContractingDate  is null ) " +
                      "or (dbo.GetApproximateDate(ReservationContractingDate) < dbo.GetApproximateDate(ReservationDate)) "+
                      " )" +
                      " GROUP BY RPCell_1.CellID, RPCell_1.CellNameA, dbo.CRMUnitType.UnitTypeID, dbo.CRMUnitType.UnitTypeNameA ";
                return Returned;
            }
        }
        /// <summary>
        /// Presents Project and ReservedCount,TotalValue , TotalInstallmentValue and TotalPaidValue + UnitTypeID
        /// </summary>
        public static string StatisticReserved
        {
            get
            {
                string strProjectReservation = "SELECT DISTINCT "+
                      " dbo.CRMReservation.ReservationID, RPCell_1.CellID, RPCell_1.CellNameA, dbo.CRMReservation.ReservationValue, dbo.CRMUnitType.UnitTypeID, "+
                      " dbo.CRMUnitType.UnitTypeNameA, COUNT(DISTINCT dbo.CRMUnitCell.UnitID) AS ReservedCount, dbo.CRMReservation.ReservationStatus "+
                      " FROM  dbo.RPCell INNER JOIN "+
                      " dbo.CRMUnitCell ON dbo.RPCell.CellID = dbo.CRMUnitCell.CellID INNER JOIN "+
                      " dbo.RPCell RPCell_1 ON dbo.RPCell.CellFamilyID = RPCell_1.CellID INNER JOIN "+
                      " dbo.CRMUnit ON dbo.CRMUnitCell.UnitID = dbo.CRMUnit.UnitID INNER JOIN "+
                      " dbo.CRMUnitType ON dbo.CRMUnit.UnitType = dbo.CRMUnitType.UnitTypeID INNER JOIN "+
                      " dbo.CRMReservation ON dbo.CRMUnit.CurrentReservation = dbo.CRMReservation.ReservationID "+
                      //" AND (dbo.GetApproximateDate(ReservationContractingDate) >= dbo.GetApproximateDate(ReservationDate)) " +
                      "  GROUP BY dbo.CRMReservation.ReservationID, RPCell_1.CellID, RPCell_1.CellNameA, dbo.CRMReservation.ReservationValue, dbo.CRMUnitType.UnitTypeID, " +
                      " dbo.CRMUnitType.UnitTypeNameA, dbo.CRMReservation.ReservationStatus";


                string strInstallmentValue = "SELECT     VStatisticProjectReservation.ReservationID, VStatisticProjectReservation.CellID, VStatisticProjectReservation.ReservationValue, "+
                       " VStatisticProjectReservation.UnitTypeID, VStatisticProjectReservation.UnitTypeNameA, "+
                       " VStatisticProjectReservation.ReservedCount AS ReservedUnitCount,sum(CRMReservationInstallment.InstallmentValue) as TotalInstallmentValue  " +
                       " FROM   ("+ strProjectReservation +") as VStatisticProjectReservation LEFT OUTER JOIN "+
                       " dbo.CRMReservationInstallment ON VStatisticProjectReservation.ReservationID = dbo.CRMReservationInstallment.ReservationID "+
                       " GROUP BY VStatisticProjectReservation.ReservationID, VStatisticProjectReservation.CellID, VStatisticProjectReservation.ReservationValue, "+
                       " VStatisticProjectReservation.UnitTypeID, VStatisticProjectReservation.UnitTypeNameA, VStatisticProjectReservation.ReservedCount";
                string strTempPayment = "SELECT dbo.CRMTempReservationPayment.ReservationID, SUM(dbo.GLPayment.PaymentValue) AS TempValue "+
                       " FROM    dbo.CRMTempReservationPayment INNER JOIN "+
                        " dbo.GLPayment ON dbo.CRMTempReservationPayment.PaymentID = dbo.GLPayment.PaymentID "+
                        " GROUP BY dbo.CRMTempReservationPayment.ReservationID";
                string strUnitNonPaidValue = "SELECT     VStatisticProjectReservation.ReservationID, VStatisticProjectReservation.CellID, VStatisticProjectReservation.ReservationValue, "+
                      " VStatisticProjectReservation.UnitTypeID, VStatisticProjectReservation.UnitTypeNameA, "+
                       " VStatisticProjectReservation.ReservedCount AS ReservedUnitCount, SUM(CASE WHEN dbo.CRMReservationInstallment.InstallmentValue IS NULL "+
                      " THEN 0 ELSE dbo.CRMReservationInstallment.InstallmentValue END) AS TotalInstallmentValue, "+
                      " SUM(CASE WHEN dbo.GLPayment.PaymentValue IS NULL THEN 0 ELSE dbo.GLPayment.PaymentValue END) AS TotalPaidValue "+
                      " FROM    (" + strProjectReservation+ ") as VStatisticProjectReservation LEFT OUTER JOIN "+
                      " dbo.CRMReservationInstallment ON "+
                      " VStatisticProjectReservation.ReservationID = dbo.CRMReservationInstallment.ReservationID LEFT OUTER JOIN "+
                      " CRMInstallmentPayment on CRMReservationInstallment.InstallmentID = CRMInstallmentPayment.InstallmentID "+
                      " left outer join GLPayment on dbo.CRMInstallmentPayment.PaymentID = GLPayment.PaymentID "+
                      " left outer JOIN "+
                      " dbo.GLCheckPayment ON GLPayment.PaymentID = dbo.GLCheckPayment.PaymentID left OUTER JOIN " +
                      " GLCheck on dbo.GLCheck.CheckID = dbo.GLCheckPayment.CheckID "+
                      " WHERE     (dbo.GLCheckPayment.CheckID IS NULL) OR "+
                      " (dbo.GLCheckPayment.PaymentIsCollected = 1) OR " +
                      " (dbo.GLCheck.CheckCurrentStatus IN (2, 4))"+
                      " GROUP BY VStatisticProjectReservation.ReservationID, VStatisticProjectReservation.CellID, VStatisticProjectReservation.ReservationValue, "+
                      " VStatisticProjectReservation.UnitTypeID, VStatisticProjectReservation.UnitTypeNameA, VStatisticProjectReservation.ReservedCount";
                string strInstallmentDiscount = "SELECT     dbo.CRMReservationInstallment.ReservationID, "+
                    "SUM(case when dbo.CRMReservationInstallmentDiscount.DiscountValue is null then 0 else dbo.CRMReservationInstallmentDiscount.DiscountValue end) AS TotalInstallmentDiscount " +
                       " FROM         dbo.CRMReservationInstallment left outer JOIN "+
                       " dbo.CRMReservationInstallmentDiscount ON  "+
                       " dbo.CRMReservationInstallment.InstallmentID = dbo.CRMReservationInstallmentDiscount.InstallmentID "+
                       " GROUP BY dbo.CRMReservationInstallment.ReservationID";
             
                string Returned = "SELECT     VStatisticProjectReservation.CellID, VStatisticProjectReservation.CellNameA,"+
                    "sum(case when VTempPayment.TempValue is null then 0 else VTempPayment.TempValue end)+"+
                    "SUM(case when VInstallmentValue.TotalInstallmentValue is null then 0 else VInstallmentValue.TotalInstallmentValue end) - "+
                    " sum(case when VInstallmentDiscount.TotalInstallmentDiscount is null then 0 else VInstallmentDiscount.TotalInstallmentDiscount end)   " +//"SUM(VStatisticProjectReservation.ReservationValue) " +
                      " AS TotalValue, VStatisticProjectReservation.UnitTypeID, VStatisticProjectReservation.UnitTypeNameA, "+
                      " SUM(VStatisticProjectReservation.ReservedCount) AS ReservedCount, SUM(VInstallmentValue.TotalInstallmentValue) - sum(VInstallmentDiscount.TotalInstallmentDiscount) " +
                      " AS TotalInstallmentValue, SUM(VStatisticUnitNonPaidValue.TotalPaidValue) AS TotalPaidValue,sum(case when VTempPayment.TempValue is null then 0 else VTempPayment.TempValue end) as TotalTempPayment "+
                      " FROM (" + strProjectReservation + ") as VStatisticProjectReservation left outer JOIN "+
                      " ("+ strUnitNonPaidValue +") as VStatisticUnitNonPaidValue ON VStatisticProjectReservation.ReservationID = VStatisticUnitNonPaidValue.ReservationID "+
                      " left outer join ("+ strInstallmentValue +") VInstallmentvalue on VStatisticProjectReservation.ReservationID = VInstallmentValue.ReservationID " +
                      " left outer join ("+ strInstallmentDiscount +") as VInstallmentDiscount on VInstallmentDiscount.ReservationID =  VStatisticProjectReservation.ReservationID " +
                      " left outer join ("+ strTempPayment +") as VTempPayment on VStatisticProjectReservation.ReservationID = VTempPayment.ReservationID "+
                      " GROUP BY VStatisticProjectReservation.CellID, VStatisticProjectReservation.CellNameA, VStatisticProjectReservation.UnitTypeID,  "+
                      " VStatisticProjectReservation.UnitTypeNameA";
                return Returned;
            }
        }
        public static string SearchStr
        {
            get
            {
                string Returned = "";
                return Returned;
            }
        }
        #endregion

        #region Private Data
        DataTable GetTable()
        {
            DataTable Returned = new DataTable();
            Returned.Columns.AddRange(new DataColumn[]{new DataColumn("ProjectID"),new DataColumn("ProjectName"),new DataColumn("TowerNum"),
                new DataColumn("TotalResidentialUnit"),new DataColumn("TotalCommercialUnit"),new DataColumn("TotalOfficesUnit"),
            new DataColumn("DeservedResidentialUnit"),new DataColumn("DeservedCommercialUnit"),new DataColumn("DeservedOfficesUnit"),new DataColumn("RemainingResidentialUnit"),
            new DataColumn("RemainingCommercialUnit"),new DataColumn("RemainingOfficesUnit"),new DataColumn("TotalValue"),new DataColumn("RemainingValue")});
            DataRow objDR;
         
            return Returned;
        }
        void SetData(DataRow objDR)
        {
            _ProjectName = objDR["ProjectName"].ToString();
            _TowerNum = int.Parse(objDR["TowerNum"].ToString());
            _TotalResidentialUnit = int.Parse( objDR["TotalResidentialUnit"].ToString());
            _TotalCommercialUnit =int.Parse( objDR["TotalCommercialUnit"].ToString());
            _TotalOfficesUnit =int.Parse( objDR["TotalOfficesUnit"].ToString());
            _DeservedResidentialUnit = int.Parse(objDR["DeservedResidentialUnit"].ToString());
            _DeservedCommercialUnit = int.Parse(objDR["DeservedCommercialUnit"].ToString());
            _DeservedOfficesUnit = int.Parse(objDR["DeservedOfficesUnit"].ToString());
            _RemainingResidentialUnit =int.Parse(objDR["RemainingResidentialUnit"].ToString());
            _RemainingCommercialUnit = int.Parse(objDR["RemainingCommercialUnit"].ToString());
            _RemainingOfficesUnit = int.Parse(objDR["RemainingOfficesUnit"].ToString());
            _TotalValue = double.Parse( objDR["TotalValue"].ToString());
           _RemainingValue =double.Parse( objDR["RemainingValue"].ToString());
        }
        DataTable VStatisticProjectReservation()
        {
            string strSql = "SELECT DISTINCT " +
                                  " dbo.CRMReservation.ReservationID, RPCell_1.CellID, RPCell_1.CellNameA, dbo.CRMReservation.ReservationValue, dbo.CRMUnitType.UnitTypeID, " +
                                  " dbo.CRMUnitType.UnitTypeNameA, COUNT(DISTINCT dbo.CRMUnitCell.UnitID) AS ReservedCount, dbo.CRMReservation.ReservationStatus" +
                                  " FROM         dbo.RPCell INNER JOIN" +
                                  " dbo.CRMUnitCell ON dbo.RPCell.CellID = dbo.CRMUnitCell.CellID INNER JOIN" +
                                  " dbo.RPCell RPCell_1 ON dbo.RPCell.CellFamilyID = RPCell_1.CellID INNER JOIN" +
                                  " dbo.CRMUnit ON dbo.CRMUnitCell.UnitID = dbo.CRMUnit.UnitID INNER JOIN" +
                                  " dbo.CRMUnitType ON dbo.CRMUnit.UnitType = dbo.CRMUnitType.UnitTypeID INNER JOIN" +
                                  " dbo.CRMReservation ON dbo.CRMUnit.CurrentReservation = dbo.CRMReservation.ReservationID" +
                                  " GROUP BY dbo.CRMReservation.ReservationID, RPCell_1.CellID, RPCell_1.CellNameA, dbo.CRMReservation.ReservationValue, dbo.CRMUnitType.UnitTypeID, " +
                                  " dbo.CRMUnitType.UnitTypeNameA, dbo.CRMReservation.ReservationStatus";
            return SysData.AttachmentDb.ReturnDatatable(strSql);
        }
        DataTable VStatisticUnitNonPaidValue()
        {
            string strSql = " SELECT     dbo.VStatisticProjectReservation.ReservationID, dbo.VStatisticProjectReservation.CellID, dbo.VStatisticProjectReservation.ReservationValue, "+
                            " dbo.VStatisticProjectReservation.UnitTypeID, dbo.VStatisticProjectReservation.UnitTypeNameA, "+
                            " dbo.VStatisticProjectReservation.ReservedCount AS ReservedUnitCount, SUM(CASE WHEN dbo.CRMReservationInstallment.InstallmentValue IS NULL "+
                            " THEN 0 ELSE dbo.CRMReservationInstallment.InstallmentValue END) AS TotalInstallmentValue, "+
                            " SUM(CASE WHEN dbo.GLPayment.PaymentValue IS NULL THEN 0 ELSE dbo.GLPayment.PaymentValue END) AS TotalPaidValue"+
                            " FROM         dbo.VStatisticProjectReservation LEFT OUTER JOIN"+
                            " dbo.CRMReservationInstallment ON "+
                            " dbo.VStatisticProjectReservation.ReservationID = dbo.CRMReservationInstallment.ReservationID LEFT OUTER JOIN"+
                            " dbo.GLCheck INNER JOIN"+
                            " dbo.GLCheckPayment ON dbo.GLCheck.CheckID = dbo.GLCheckPayment.CheckID RIGHT OUTER JOIN"+
                            " dbo.GLPayment INNER JOIN"+
                            " dbo.CRMInstallmentPayment ON dbo.GLPayment.PaymentID = dbo.CRMInstallmentPayment.PaymentID ON "+
                            " dbo.GLCheckPayment.PaymentID = dbo.GLPayment.PaymentID ON "+
                            " dbo.CRMReservationInstallment.InstallmentID = dbo.CRMInstallmentPayment.InstallmentID"+
                            " WHERE     (dbo.GLCheckPayment.CheckID IS NULL) OR"+
                            " (dbo.GLCheckPayment.PaymentCollectingUsr = 2) OR"+
                            " (dbo.GLCheck.CheckCurrentStatus IN (2, 4))"+
                            " GROUP BY dbo.VStatisticProjectReservation.ReservationID, dbo.VStatisticProjectReservation.CellID, dbo.VStatisticProjectReservation.ReservationValue, "+
                            " dbo.VStatisticProjectReservation.UnitTypeID, dbo.VStatisticProjectReservation.UnitTypeNameA, dbo.VStatisticProjectReservation.ReservedCount ";
            return SysData.AttachmentDb.ReturnDatatable(strSql);
        }
        DataTable VStatisticDeserved()
        {
            string strSql = " SELECT     dbo.VStatisticProjectReservation.CellID, dbo.VStatisticProjectReservation.CellNameA, SUM(dbo.VStatisticProjectReservation.ReservationValue) " +
                      " AS TotalValue, dbo.VStatisticProjectReservation.UnitTypeID, dbo.VStatisticProjectReservation.UnitTypeNameA, " +
                      " SUM(dbo.VStatisticProjectReservation.ReservedCount) AS ReservedCount, SUM(dbo.VStatisticUnitNonPaidValue.TotalInstallmentValue) " +
                      " AS TotalInstallmentValue, SUM(dbo.VStatisticUnitNonPaidValue.TotalPaidValue) AS TotalPaidValue " +
                      " FROM         dbo.VStatisticProjectReservation INNER JOIN" +
                      " dbo.VStatisticUnitNonPaidValue ON dbo.VStatisticProjectReservation.ReservationID = dbo.VStatisticUnitNonPaidValue.ReservationID" +
                      " GROUP BY dbo.VStatisticProjectReservation.CellID, dbo.VStatisticProjectReservation.CellNameA, dbo.VStatisticProjectReservation.UnitTypeID, " +
                      " dbo.VStatisticProjectReservation.UnitTypeNameA ";
            return SysData.AttachmentDb.ReturnDatatable(strSql);
        }
        #endregion
        #region Public Methods
        public DataTable Search()
        {
            DataTable Returned = GetTable();
            DataTable dtTemp = SysData.SharpVisionBaseDb.ReturnDatatable(StatisticTowerNo);
            DataRow drTemp;
            double dblTemp=0;
            foreach (DataRow objDr in dtTemp.Rows)
            {
                drTemp = Returned.NewRow();
                drTemp["ProjectID"] = objDr["CellID"].ToString();
                drTemp["ProjectName"] = objDr["CellNameA"].ToString();
                drTemp["TowerNum"] = objDr["TowerNo"].ToString();
                Returned.Rows.Add(drTemp);
 
            }

            string strCellID;
            DataRow[] arrDr;
           // DataRow[] arrInner;
            dtTemp = SysData.SharpVisionBaseDb.ReturnDatatable(StatisticFreeUnit);
          
            foreach (DataRow objDr in Returned.Rows)
            {
                strCellID = objDr["ProjectID"].ToString();
                arrDr = dtTemp.Select("CellID=" + strCellID +"  and UnitTypeID=1");
                if (arrDr.Length > 0)
                    objDr["RemainingResidentialUnit"] = arrDr[0]["FreeUnitCount"].ToString();
                else
                    objDr["RemainingResidentialUnit"] = "0";

                arrDr = dtTemp.Select("CellID=" + strCellID + "  and UnitTypeID=2");
                if (arrDr.Length > 0)
                    objDr["RemainingCommercialUnit"] = arrDr[0]["FreeUnitCount"].ToString();
                else
                    objDr["RemainingCommercialUnit"] = "0";
                arrDr = dtTemp.Select("CellID=" + strCellID + "  and UnitTypeID=4");
                if (arrDr.Length > 0)
                    objDr["RemainingOfficesUnit"] = arrDr[0]["FreeUnitCount"].ToString();
                else
                    objDr["RemainingOfficesUnit"] = "0";

                
            }

            dtTemp = SysData.SharpVisionBaseDb.ReturnDatatable(StatisticReserved);
           // DataRow[] arrDrTest = dtTemp.Select("CellID=1198");
            
            foreach (DataRow objDr in Returned.Rows)
            {
               
                strCellID = objDr["ProjectID"].ToString();
                arrDr = dtTemp.Select("CellID=" + strCellID + "  and UnitTypeID=1");
                if (arrDr.Length > 0)
                    objDr["DeservedResidentialUnit"] = arrDr[0]["ReservedCount"].ToString();
                else
                    objDr["DeservedResidentialUnit"] = "0";

                arrDr = dtTemp.Select("CellID=" + strCellID + "  and UnitTypeID=2");
                if (arrDr.Length > 0)
                    objDr["DeservedCommercialUnit"] = arrDr[0]["ReservedCount"].ToString();
                else
                    objDr["DeservedCommercialUnit"] = "0";
                arrDr = dtTemp.Select("CellID=" + strCellID + "  and UnitTypeID=4");
                if (arrDr.Length > 0)
                    objDr["DeservedOfficesUnit"] = arrDr[0]["ReservedCount"].ToString();
                else
                    objDr["DeservedOfficesUnit"] = "0";


                arrDr = dtTemp.Select("CellID=" + strCellID);
                dblTemp = 0;
                foreach (DataRow objDr1 in arrDr)
                {
                    dblTemp += double.Parse(objDr1["TotalValue"].ToString());

 
                }
                objDr["TotalValue"] = dblTemp.ToString();
                dblTemp = 0;
                foreach (DataRow objDr1 in arrDr)
                {
                    if (objDr1["TotalPaidValue"].ToString() != "" && objDr1["TotalInstallmentValue"].ToString() != "")
                    dblTemp += (double.Parse(objDr1["TotalInstallmentValue"].ToString())-double.Parse(objDr1["TotalPaidValue"].ToString()));


                }
                objDr["RemainingValue"] = dblTemp.ToString();




            }
            foreach (DataRow objDr in Returned.Rows)
            {
                // "DeservedResidentialUnit"),"DeservedCommercialUnit"),"DeservedOfficesUnit"),"RemainingResidentialUnit"),
                //"RemainingCommercialUnit"),"RemainingOfficesUnit"),"TotalValue"),"RemainingValue")});
                //("TotalResidentialUnit"),"TotalCommercialUnit"),"TotalOfficesUnit"),
                objDr["TotalResidentialUnit"] = double.Parse(objDr["DeservedResidentialUnit"].ToString()) + double.Parse(objDr["RemainingResidentialUnit"].ToString());
                objDr["TotalCommercialUnit"] = double.Parse(objDr["DeservedCommercialUnit"].ToString()) + double.Parse(objDr["RemainingCommercialUnit"].ToString());
                objDr["TotalOfficesUnit"] = double.Parse(objDr["DeservedOfficesUnit"].ToString()) + double.Parse(objDr["RemainingOfficesUnit"].ToString());

 
            }
            return Returned;
        }
        #endregion
    }
}
