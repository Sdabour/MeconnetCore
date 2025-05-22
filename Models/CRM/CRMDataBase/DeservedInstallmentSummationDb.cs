using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.SystemBase;
namespace SharpVision.CRM.CRMDataBase
{
    public class DeservedInstallmentSummationDb
    {
        #region Private Data
        protected int _CellfamilyID;
        protected string _CellAlterName;
        protected string _InstallmentTypeNameA;
        protected string _CellIDs;
        protected int _ModelID;
        protected int _InstallmentType;

        protected string _TypeIDs;
        protected DateTime _StartDate;
        protected DateTime _EndDate;
        protected int _DateStatus;
        protected double _TotalValue;
        protected double _DeservedValue;
        protected double _DiscountValue;
        protected double _TotalPaidValue;
        protected double _WholeTotalPaidValue;
        protected double _DeservedCheckValue;
        protected double _NonDeservedCheckValue;

        protected double _PreDeliveryDeservedValue;
        protected double _PreDeliveryWholeTotalPaidValue;
        protected double _PreDeliveryDiscountValue;

        protected string _DateStr;
        protected int _intStatus;
        protected int _PaymentDateStatus;
        protected DateTime _StartPaymentDate;
        protected DateTime _EndPaymentDate;
        protected int _IncludeTempPayment;
        protected int _PeriodType;//0 no grouping with Period
                        //1 grouping by Year
                        //2 GroupingByMonth
        protected bool _IsProjectGrouping = true;
        protected bool _TypeGrouping;
        protected bool _MainTypeGrouping;
        protected int _Campaign;
        protected double _CampaignNonDeservedPaid;
        protected int _CampaignContactStatus;/*
                                              * 0 dont care
                                              * 1 only Contacted
                                              * 2 only not contacted
                                              */
        protected string _CampaignIDs;
        protected int _DeliveryStatus;/*
                                      * 0 dont care
                                      * 1 Delivered or not dueted
                                      * 2 delivery dueeted and not delivered
                                      */
        protected bool _IsDeliverDateStatus;
        protected DateTime _DeliveryRefrenceDate;/*
                                                  * 
                                                  */
        int _UnitDeliveryStatus;
        int _TowerDeliveryStatus;
        bool _IsContractingDateRange;
        DateTime _StartContractDate;
        DateTime _EndContractDate;
        #endregion

        #region Constructors
        public DeservedInstallmentSummationDb()
        {
            
        }
        public DeservedInstallmentSummationDb(DataRow objDR)
        {
            SetData(objDR);
        }
        #endregion

        #region Public Properties
        public double DeservedValue
        {
            set
            {
                _DeservedValue = value;
            }
            get
            {
                return _DeservedValue;
            }
        }
        public double DiscountValue
        {
            set
            {
                _DiscountValue = value;
            }
            get
            {
                return _DiscountValue;
            }
        }
        public double TotalPaidValue
        {
            set
            {
                _TotalPaidValue = value;
            }
            get
            {
                return _TotalPaidValue;
            }
        }
        public double WholeTotalPaidValue
        {
            set
            {
                _WholeTotalPaidValue = value;
            }
            get
            {
                return _WholeTotalPaidValue;
            }
        }
        public int CellFamilyID
        {
            set
            {
                _CellfamilyID = value;
            }
            get
            {
                return _CellfamilyID;
            }
        }
        public string CellAlterName
        {
            set
            {
                _CellAlterName = value;
            }
            get
            {
                return _CellAlterName;
            }
        }
        public string InstallmentTypeNameA
        {
            set
            {
                _InstallmentTypeNameA = value;
            }
            get
            {
                return _InstallmentTypeNameA;
            }
        }
        public double DeservedCheckValue
        {
            set
            {
                _DeservedCheckValue = value;
            }
            get
            {
                return _DeservedCheckValue;
            }
        }
        public double NonDeservedCheckValue
        {
            set
            {
                _NonDeservedCheckValue = value;
            }
            get
            {
                return _NonDeservedCheckValue;
            }
        }
        public double CampaignNonDeservedPaid
        {
            set
            {
                _CampaignNonDeservedPaid = value;
            }
            get
            {
                return _CampaignNonDeservedPaid;
            }
        }
        public string CellIDs
        {
            set
            {
                _CellIDs = value;
            }
        }
        public int ModelID
        {
            set
            {
                _ModelID = value;
            }
        }
        public DateTime StartDate
        {
            set
            {
                _StartDate = value;
            }
        }
        public int DateStatus
        {
            set
            {
                _DateStatus = value;
            }
            get
            {
                return _DateStatus;
            }
        }
        public string TypeIDs
        {
            set
            {
                _TypeIDs = value;
            }
        }
        public DateTime EndDate
        {
            set
            {
                _EndDate = value;
            }
        }
        public bool IsContractingDateRange
        {
            set
            {
                _IsContractingDateRange = value;
            }
        }

        public DateTime StartContractDate
        {
            set
            {
                _StartContractDate = value;
            }
        }
        public DateTime EndContractDate
        {
            set
            {
                _EndContractDate = value;
            }
        }
        public int UnitDeliveryStatus
        {
            set
            {
                _UnitDeliveryStatus = value;
            }
        }
        public int TowerDeliveryStatus
        {
            set
            {
                _TowerDeliveryStatus = value;
            }
        }
        public string DateStr
        {
            get
            {
                return _DateStr;
            }
        }
        public int PaymentDateStatus
        {
            set
            {
                _PaymentDateStatus = value;
            }
        }
        public DateTime StartPaymentDate
        {
            set
            {
                _StartPaymentDate = value;
            }
        }
        public DateTime EndPaymentDate
        {
            set
            {
                _EndPaymentDate = value;
            }
        }
        public int IncludeTempPaymnt
        {
            set
            {
                _IncludeTempPayment = value;
            }
        }
        public int PeriodType
        {
            set
            {
                _PeriodType = value;
            }
        }
        public bool IsProjectGrouping
        {
            set
            {
                _IsProjectGrouping = value;
            }
        }
        public bool TypeGrouping
        {
            set
            {
                _TypeGrouping = value;
            }
        }
        public bool MainTypeGrouping
        {
            set
            {
                _MainTypeGrouping = value;
            }
        }
        public int Campaign
        {
            set
            {
                _Campaign = value;
            }
            get
            {
                return _Campaign;
            }
        }
        public int CampaignContactStatus
        {
            set
            {
                _CampaignContactStatus = value;
            }
        }
        public string CampaignIDs
        {
            set 
            {
                _CampaignIDs = value;
            }
        }
        public int DeliveryStatus
        {
            set
            {
                _DeliveryStatus = value;
            }
        }
        public bool IsDeliverDateStatus
        {
            set
            {
                _IsDeliverDateStatus = value;
            }
        }
        public DateTime DeliveryRefrenceDate
        {
            set
            {
                _DeliveryRefrenceDate = value;
            }
        }
        public int intStatus
        {
            set
            {
                _intStatus = value;
            }
            get
            {
                return _intStatus;
            }
        }

        public double PreDeliveryDeservedValue
        {
            get
            {
                return _PreDeliveryDeservedValue;
            }
        }
        public double PreDeliveryWholeTotalPaidValue
        {
            get
            {
                return _PreDeliveryWholeTotalPaidValue;
            }
        }
        public double PreDeliveryDiscountValue
        {
            get
            {
                return _PreDeliveryDiscountValue;
            }
        }
        public string SearchStr
        {
            get
            {
                string Returned = "";
                string strPeriod ="";
                if(_PeriodType == 1)
                  strPeriod = " SUBSTRING(CONVERT(varchar(10), InstallmentDueDate, 103), 7, 10) ";
                else if (_PeriodType == 2)
                      strPeriod = " SUBSTRING(CONVERT(varchar(10), InstallmentDueDate, 103), 4, 10) ";
               
                #region Reservation data
              string strSql = "SELECT distinct dbo.CRMReservationInstallment.InstallmentID " +
                     " FROM   dbo.CRMReservationInstallment INNER JOIN " +
                     " dbo.CRMUnit INNER JOIN " +
                     " dbo.CRMUnitCell ON dbo.CRMUnit.UnitID = dbo.CRMUnitCell.UnitID INNER JOIN " +
                     " dbo.RPCell ON dbo.CRMUnitCell.CellID = dbo.RPCell.CellID ON " +
                     " dbo.CRMReservationInstallment.ReservationID = dbo.CRMUnit.CurrentReservation "+
                     " inner join CRMReservation "+
                     " on  dbo.CRMReservationInstallment.ReservationID = CRMReservation.ReservationID "+
                     " inner join RPCell as TowerTable  "+
                     " on RPCell.CellParentID = TowerTable.CellID  ";
              if (_UnitDeliveryStatus == 1)
              {
                  strSql += " and dbo.CRMUnit.UnitDeliveryDate is not null ";
              }
              else if (_UnitDeliveryStatus == 2)
              {
                  strSql += " and dbo.CRMUnit.UnitDeliveryDate is  null ";
              }
              if (_TowerDeliveryStatus == 1)
                  strSql += " and (TowerTable.CellDeliverDate is not null or dbo.CRMUnit.UnitIsReadyForDelivery =1) ";
              else if (_TowerDeliveryStatus == 2)
                  strSql += " and TowerTable.CellDeliverDate is  null and dbo.CRMUnit.UnitIsReadyForDelivery = 0 ";
              if (_Campaign != 0)
              {
                  string strCampaignContact = "SELECT  CampaignCustomerID, SUM(CASE WHEN ContactStatus = 1 THEN 1 ELSE 0 END) AS ContactCount "+
                  " FROM         dbo.CRMCampaignCustomerContact "+
                  " GROUP BY CampaignCustomerID ";
                  string strCampaign = "SELECT  dbo.CRMReservationCustomer.ReservationID ,count(dbo.CRMReservationCustomer.CustomerID) as CampaignCustomer " +
                         " FROM   dbo.CRMReservationCustomer INNER JOIN " +
                         " dbo.CRMCampaignCustomer  " +
                         " ON dbo.CRMReservationCustomer.CustomerID = dbo.CRMCampaignCustomer.Customer " +
                         " INNER JOIN  dbo.CRMCampaign "+
                         " ON dbo.CRMCampaignCustomer.Campaign = dbo.CRMCampaign.CampaignID "+
                         " left outer join ("+ strCampaignContact +") as CampaignContactTable "+
                         " on  CRMCampaignCustomer.CampaignCustomerID = CampaignContactTable.CampaignCustomerID " +
                         " WHERE     (dbo.CRMCampaignCustomer.Campaign = " + _Campaign + ")";
                  if (_CampaignContactStatus == 1)
                  {
                      strCampaign += " and (CampaignContactTable.ContactCount is not null and CampaignContactTable.ContactCount>0 ) ";
                  }
                  else if (_CampaignContactStatus == 2)
                  {
                      strCampaign += " and (CampaignContactTable.ContactCount is null or CampaignContactTable.ContactCount=0) ";
                  }
                  strCampaign += " group by dbo.CRMReservationCustomer.ReservationID ";
                  strSql += " inner join (" + strCampaign + ") as CampaignTable "+
                      " on dbo.CRMUnit.CurrentReservation = CampaignTable.ReservationID ";



              }
                strSql +=  " WHERE     (1=1) ";
                string strWhere = "";
               
                if (_ModelID != 0)
                {
                    strWhere = strWhere + " and CRMUnit.UnitModel=" + _ModelID;
                }

                if (_CellfamilyID != 0)
                    strWhere = strWhere + " and RPCell.CellFamilyID=" + _CellfamilyID;
                if (_CellIDs != null && _CellIDs != "")
                    strWhere = strWhere + " and CRMUnitCell.CellID in(" + _CellIDs + ") ";
                {
                    if (_DateStatus != 0)
                    {
                        double dblStartDate = _StartDate.ToOADate() - 2;
                        double dblEndDate = _EndDate.ToOADate() - 2;
                        int intStartdate, intEnddate;
                        intStartdate = (int)dblStartDate;
                        intEnddate = (int)dblEndDate;
                        if (intStartdate > dblStartDate)
                            intStartdate--;
                        if (intEnddate < dblEndDate)
                            intEnddate++;
                        strWhere = strWhere + " and CRMReservationInstallment.InstallmentDueDate>= " + intStartdate +
                            " and CRMReservationInstallment.InstallmentDueDate <" + intEnddate + " ";
                    }
                }

                if (_InstallmentType != 0)
                {
                    strWhere = strWhere + " and CRMReservationInstallment.InstallmentType = "+_InstallmentType+" ";
                }
                if (_TypeIDs != null && _TypeIDs != "")
                {
                    strWhere = strWhere + " and CRMReservationInstallment.InstallmentType in ( " + _TypeIDs + ") ";


                }
                if (_IsContractingDateRange)
                {
                    double dblStartContact, dblEndContact;
                    dblStartContact = SysUtility.Approximate(_StartContractDate.ToOADate() - 2, 1, ApproximateType.Down);
                    dblEndContact = SysUtility.Approximate(_EndContractDate.ToOADate() - 2, 1, ApproximateType.Up);
                    strWhere += " and dbo.CRMReservation.ReservationContractingDate >= " + dblStartContact +
                        " and dbo.CRMReservation.ReservationContractingDate <"+ dblEndContact;
                }
                /* Type Condetion*/
                strSql += strWhere;
                #endregion
                #region Str Query
                if (!_TypeGrouping)
                    _InstallmentType = -1;
                string strReservationCell = "";
                string strSelect = " SELECT  '' as Exp, ";
                if (strPeriod != "")
                {
                    if(_PeriodType== 2)
                        strSelect += "  Year(InstallmentDueDate) as Y, month(InstallmentDueDate) as M, " +
                            strPeriod + "  as DateStr";
                    else if(_PeriodType == 1)
                        strSelect += "  Year(InstallmentDueDate) as Y, 0  as M, " +
                            strPeriod + "  as DateStr";
                }
                else
                    strSelect += "0 as Y,0 as M,'' as DateStr  ";
                   
                   
                if (_CellfamilyID == 0)
                    strSelect += ",CellTable.CellAlterName,CellTable.CellfamilyID ";
                if (_InstallmentType == 0)
                    strSelect += ",CRMInstallmentType.InstallmentTypeNameA ";
                if(_MainTypeGrouping )
                    strSelect += ",CRMInstallmentType.InstallmentMainType ";
                string strCell = "select Distinct CurrentReservation,"+
                    "case when RPCell_1.CellAlterName is null or RPCell_1.CellAlterName ='' then RPCell_1.CellNameA else  RPCell_1.CellAlterName end as CellAlterName "+
                    ",RPCell_1.CellFamilyID from  CRMUnit inner join" +
                    " CRMUnitCell on CRMUnit.UnitID = CRMUnitCell.UnitID " +
                      " INNER JOIN" +
                      " RPCell ON CRMUnitCell.CellID = RPCell.CellID ";
              
                    strCell += " INNER JOIN dbo.RPCell RPCell_1 ON dbo.RPCell.CellFamilyID = RPCell_1.CellID ";
       
                string strFrom = "";
                string strInstallmentSearch = "select distinct InstallmentID from ("+ strSql +
                    ") as InstallmentTable ";
                strFrom = " FROM    (" + strCell + ") as CellTable  inner join "+
                    " CRMReservationInstallment on CRMReservationInstallment.ReservationID = CellTable.CurrentReservation ";
                //if(_InstallmentType == 0)
                    strFrom += " inner join CRMInstallmentType on CRMReservationInstallment.InstallmentType = CRMInstallmentType.InstallmentTypeID ";
                strFrom += " inner join (" + strSql + ") as  NativeInstallmentTable on "+
                    " CRMReservationInstallment.InstallmentID = NativeInstallmentTable.InstallmentID ";
                //strWhere = " where (CRMReservationInstallment.InstallmentID in ("+strSql+"))";
                strWhere = " where (1=1) ";
                string strStatusWhere = strWhere;
                if(_intStatus!=0)
                {
                    string strPaymentCheckStatus = "SELECT dbo.CRMInstallmentPayment.InstallmentID " +
                            " FROM  dbo.CRMInstallmentPayment INNER JOIN " +
                           " dbo.GLPayment ON dbo.CRMInstallmentPayment.PaymentID = dbo.GLPayment.PaymentID INNER JOIN " +
                           " dbo.GLCheckPayment ON dbo.GLPayment.PaymentID = dbo.GLCheckPayment.PaymentID INNER JOIN " +
                           " dbo.GLCheck ON dbo.GLCheckPayment.CheckID = dbo.GLCheck.CheckID " +
                           " WHERE     (dbo.GLCheckPayment.PaymentIsCollected <> 1) " +
                           " AND ((dbo.GLCheck.CheckCurrentStatus <>2))";
                    if (_intStatus == 1)
                        strStatusWhere += " and (CRMReservationInstallment.InstallmentStatus = 0 or CRMReservationInstallment.InstallmentID in(" +
                            strPaymentCheckStatus + ")) ";
                 
                }


                string strGroup = "";
                strGroup = strPeriod;
                if (strGroup != "")
                {
                    if(_PeriodType == 2)
                    strGroup += ", Year(InstallmentDueDate), month(InstallmentDueDate)";
                    else if(_PeriodType == 1)
                    strGroup += ", Year(InstallmentDueDate) ";
                }
               // strGroup += "CellTable.CellFamilyID ";

               // strGroup += " GROUP BY  " + strGroup; //strPeriod + ", CellTable.CellFamilyID  ";
                if (_CellfamilyID == 0)
                {
                    if (strGroup != "")
                        strGroup += ",";
                    strGroup += "CellTable.CellAlterName,CellTable.CellFamilyID ";
                }
                if (_InstallmentType == 0)
                {
                    if (strGroup != "")
                        strGroup += ",";
                    strGroup += "InstallmentTypeNameA ";
                }
                if (_MainTypeGrouping)
                {
                    if (strGroup != "")
                        strGroup += ",";
                    strGroup += " InstallmentMainType ";
                }

                if (strGroup != "")
                    strGroup = " Group by " + strGroup;

            
                #endregion
                #region Installment Payment Region

                string strInstallmentPayment = "";
                //TotalPaidValue presents the Total Collected Value either by cash paid or Collected Check 
                double dblStartPayment = _StartPaymentDate.ToOADate() - 2;
                double dblEndPayment = _EndPaymentDate.ToOADate() - 2;
                dblStartPayment = SysUtility.Approximate(dblStartPayment, 1, ApproximateType.Down);
                dblEndPayment = SysUtility.Approximate(dblEndPayment, 1, ApproximateType.Up);
               
                strInstallmentPayment = strSelect + ", SUM(CASE WHEN GLPayment.PaymentValue IS NULL " +
                 " THEN 0  when GLPayment.PaymentValue IS not NULL and GLCheckPayment.PaymentID is null ";
                if (_PaymentDateStatus != 0)
                    strInstallmentPayment += " and  dbo.GLPayment.PaymentDate >=" + dblStartPayment +
                        " and  dbo.GLPayment.PaymentDate < " + dblEndPayment;
                strInstallmentPayment += " then GLPayment.PaymentValue " +
                 " when ((GLCheck.CheckCurrentStatus= 2 or GLCheck.CheckCurrentStatus = 4) ";
                if (_PaymentDateStatus != 0)
                    strInstallmentPayment += " and dbo.GLCheck.CheckCurrentStatusDate>=" + dblStartPayment +
                        " and dbo.GLCheck.CheckCurrentStatusDate <" + dblEndPayment ;
                strInstallmentPayment += ") or (GLCheckPayment.PaymentIsCollected =1 ";
                if (_PaymentDateStatus != 0)
                   strInstallmentPayment+=  " and  dbo.GLCheckPayment.PaymentCollectingDate>= " + dblStartPayment +
                        " and  dbo.GLCheckPayment.PaymentCollectingDate<" + dblEndPayment;
                strInstallmentPayment += ") then  GLPayment.PaymentValue Else 0 END) AS CurrentTotalPaidValue ";

                strInstallmentPayment += ", SUM(CASE WHEN GLPayment.PaymentValue IS NULL " +
          " THEN 0  when GLPayment.PaymentValue IS not NULL and GLCheckPayment.PaymentID is null ";
              
                strInstallmentPayment += " then GLPayment.PaymentValue " +
                 " when ((GLCheck.CheckCurrentStatus= 2 or GLCheck.CheckCurrentStatus = 4) ";
              
                strInstallmentPayment += ") or (GLCheckPayment.PaymentIsCollected =1 ";
              
                strInstallmentPayment += ") then  GLPayment.PaymentValue Else 0 END) AS TotalPaidValue ";

                strInstallmentPayment += ",Sum(Case When GLCheckPayment.PaymentID is  null then 0 else ( " +
                    "case when GLCheck.CheckCurrentStatus <>2 and GLCheck.CheckCurrentStatus <>4 and GLCheckPayment.PaymentIsCollected =0  and GLCheck.CheckDueDate < GetDate() " +
                    " then  GLPayment.PaymentValue else 0 end)END ) as DeservedCheckValue ";
                strInstallmentPayment += ",Sum(Case When GLCheckPayment.PaymentID is  null then 0 else ( " +
                   "case when GLCheck.CheckCurrentStatus <>2 and GLCheck.CheckCurrentStatus <>4 and GLCheck.CheckDueDate >= GetDate() " +
                   "  and GLCheckPayment.PaymentIsCollected = 0 then  GLPayment.PaymentValue else 0 end)END ) as NonDeservedCheckValue ";
                strInstallmentPayment += strFrom + " left outer join CRMInstallmentPayment on " +
                    " CRMReservationInstallment.InstallmentID = CRMInstallmentPayment.InstallmentID " +
                    " left outer join GLPayment on  CRMInstallmentPayment.PaymentID = GLPayment.PaymentID ";
                #region Check
                strInstallmentPayment += " left outer join GLCheckPayment on GLCheckPayment.PaymentID = GLPayment.PaymentID  "+
                    "  left outer JOIN "+
                    " dbo.GLCheck ON dbo.GLCheckPayment.CheckID = dbo.GLCheck.CheckID ";
                #endregion
                string strPaymentWhere = strStatusWhere;
               
                strInstallmentPayment +=  strPaymentWhere ;//strStatusWhere;
                strInstallmentPayment += strGroup;

                #endregion
                #region Installment Value Region

                string strInstallmentValue = "";
                strInstallmentValue = strSelect + ",SUM(CRMReservationInstallment.InstallmentValue) AS TotalDeservedValue ";
             
               strInstallmentValue+= strFrom;
              
                strInstallmentValue += strWhere;
                strInstallmentValue += strGroup;
                //if (_InstallmentType == 0)
                //    strInstallmentValue += ",InstallmentTypeNameA ";

                  #endregion
                #region Discount Region
                string strDiscount = "";
                if(_PaymentDateStatus==0)
                strDiscount = strSelect + ",SUM(CASE WHEN CRMReservationInstallmentDiscount.DiscountValue IS NULL THEN 0 ELSE CRMReservationInstallmentDiscount.DiscountValue END)" +
                          " AS TotalDiscount ";
                else
                strDiscount = strSelect + ",SUM(CASE WHEN CRMReservationInstallmentDiscount.DiscountValue is null "+
                    " or DiscountPaymentTable.InstallmentID IS NULL THEN 0 ELSE CRMReservationInstallmentDiscount.DiscountValue END)" +
                     " AS TotalDiscount ";

                strDiscount += strFrom + " left outer join CRMReservationInstallmentDiscount on "+
                    " CRMReservationInstallmentDiscount.InstallmentID =CRMReservationInstallment.InstallmentID ";
                if (_PaymentDateStatus != 0)
                {
                    string strDiscountPayment = "SELECT  dbo.CRMInstallmentPayment.InstallmentID " +
                           " FROM         dbo.GLCheck RIGHT OUTER JOIN " +
                           " dbo.GLCheckPayment ON dbo.GLCheck.CheckID = dbo.GLCheckPayment.CheckID RIGHT OUTER JOIN " +
                           " dbo.CRMInstallmentPayment INNER JOIN " +
                           " dbo.GLPayment ON dbo.CRMInstallmentPayment.PaymentID = dbo.GLPayment.PaymentID ON  " +
                           " dbo.GLCheckPayment.PaymentID = dbo.GLPayment.PaymentID ";
                    strDiscountPayment += " where (GLCheckPayment.CheckID is null and GLPayment.PaymentDate>="+ dblStartPayment +" and GLPayment.PaymentDate <"+
                        dblEndPayment + ") or (dbo.GLCheck.CheckCurrentStatus=2 and  dbo.GLCheck.CheckCurrentStatusDate>=" + dblStartPayment +
                        " and  dbo.GLCheck.CheckCurrentStatusDate<"+ dblEndPayment +" ) "+
                        " or ( dbo.GLCheckPayment.PaymentIsCollected=1 and dbo.GLCheckPayment.PaymentCollectingDate>="+ dblStartPayment +" and dbo.GLCheckPayment.PaymentCollectingDate <"+ dblEndPayment +") ";
                    strDiscount += " left outer join (" + strDiscountPayment + ") as DiscountPaymentTable on CRMReservationInstallmentDiscount.InstallmentID = DiscountPaymentTable.InstallmentID  ";
                }
                strDiscount += strStatusWhere;
                strDiscount += strGroup;
                #endregion
                string strPaymentJoinType = " left outer join ";
                if (intStatus == 2)
                    strPaymentJoinType = " inner join ";
                Returned = "select DiscountTable.TotalDiscount,InstallmentTable.TotalDeservedValue,"+
                    "InstallmentPaymentTable.DeservedCheckValue,InstallmentPaymentTable.NonDeservedCheckValue,"+
                    "InstallmentPaymentTable.CurrentTotalPaidValue,InstallmentPaymentTable.TotalPaidValue"+
                    ",convert(int,InstallmentTable.Y) as Y," +
                    "convert(int,InstallmentTable.M) as M,InstallmentTable.DateStr  ";
                if (_InstallmentType == 0)
                    Returned += ",InstallmentTable.InstallmentTypeNameA ";
                else
                {
                    Returned += ", '' as InstallmentTypeNameA ";
                    if (!_MainTypeGrouping)
                        Returned += ",0 as InstallmentMainType ";
                }
                if(_CellfamilyID == 0)
                    Returned += ",InstallmentTable.CellAlterName,InstallmentTable.CellFamilyID ";
                Returned += " from (" + strInstallmentValue + ") as InstallmentTable "+ strPaymentJoinType +" (" +
                    strInstallmentPayment + ") as InstallmentPaymentTable " +
                    " on InstallmentTable.DateStr = InstallmentPaymentTable.DateStr ";
                if (_CellfamilyID == 0)
                    Returned += " and InstallmentTable.CellfamilyID = InstallmentPaymentTable.CellFamilyID ";
                if (_InstallmentType == 0)
                    Returned += " and InstallmentTable.InstallmentTypeNameA = InstallmentPaymentTable.InstallmentTypeNameA ";
                Returned += " left outer join (" + strDiscount + ") as DiscountTable  on InstallmentTable.DateStr " +
                    " = DiscountTable.DateStr ";
                if (_InstallmentType == 0)
                    Returned += " and InstallmentTable.InstallmentTypeNameA = DiscountTable.InstallmentTypeNameA ";
                if (_CellfamilyID == 0)
                    Returned += " and InstallmentTable.CellFamilyID = DiscountTable.CellFamilyID ";
                //Returned += " order by InstallmentTable.Y,InstallmentTable.M ";
                return Returned;


            }
        }

        public string TempPaymentSearchStr
        {
            get
            {
                string Returned = "";

                string strPeriod = "";
                if (_PeriodType == 1)
                    strPeriod = " SUBSTRING(CONVERT(varchar(10),GLPayment.PaymentDate, 103), 4, 10) ";
                
                #region Reservation data
                string strSql = "SELECT distinct dbo.CRMTempReservationPayment.PaymentID,"+
                    "case when RPCell1.CellAlterName is null or RPCell1.CellAlterName ='' then RPCell1.CellNameA else  RPCell1.CellAlterName end as CellAlterName" +
                    ",RPCell.CellFamilyID  " +
                       " FROM  " +
                       " dbo.CRMUnit INNER JOIN " +
                       " dbo.CRMUnitCell ON dbo.CRMUnit.UnitID = dbo.CRMUnitCell.UnitID "+
                       " INNER JOIN dbo.RPCell ON dbo.CRMUnitCell.CellID = dbo.RPCell.CellID " +
                       " inner join RPCell as TowerTable  "+
                       " on RPCell.CellParentID = TowerTable.CellID "+
                       " inner join RPCell as RPCell1  on RPCell.CellFamilyID = RPCell1.CellID inner join CRMTempReservationPayment  " +
                       " on dbo.CRMTempReservationPayment.ReservationID = dbo.CRMUnit.CurrentReservation " +
                       " inner join GLPayment on GLPayment.PaymentID = CRMTempReservationPayment.PaymentID "+
                       " inner join CRMReservation on  dbo.CRMTempReservationPayment.ReservationID = CRMReservation.ReservationID " +
                      " WHERE     (1=1) ";
                string strWhere = "";

                if (_ModelID != 0)
                {
                    strWhere = strWhere + " and CRMUnit.UnitModel=" + _ModelID;
                }
                if (_UnitDeliveryStatus == 1)
                {
                    strSql += " and dbo.CRMUnit.UnitDeliveryDate is not null ";
                }
                else if (_UnitDeliveryStatus == 2)
                {
                    strSql += " and dbo.CRMUnit.UnitDeliveryDate is  null ";
                }
                if (_TowerDeliveryStatus == 1)
                    strSql += " and TowerTable.CellDeliverDate is not null ";
                else if (_TowerDeliveryStatus == 2)
                    strSql += " and TowerTable.CellDeliverDate is  null ";
                if (_CellfamilyID != 0)
                    strWhere = strWhere + " and RPCell.CellFamilyID=" + _CellfamilyID;
                if (_IsContractingDateRange)
                {
                    double dblStartContact, dblEndContact;
                    dblStartContact = SysUtility.Approximate(_StartContractDate.ToOADate() - 2, 1, ApproximateType.Down);
                    dblEndContact = SysUtility.Approximate(_EndContractDate.ToOADate() - 2, 1, ApproximateType.Up);
                    strWhere += " and dbo.CRMReservation.ReservationContractingDate >= " + dblStartContact +
                        " and dbo.CRMReservation.ReservationContractingDate <" + dblEndContact;
                }
                if (_CellIDs != null && _CellIDs != "")
                    strWhere = strWhere + " and CRMUnitCell.CellID in(" + _CellIDs + ") ";
                {
                    double dblStartDate = 0;
                    double dblEndDate = 0;
                    if (_DateStatus != 0)
                    {
                        dblStartDate = _StartDate.ToOADate() - 2;
                        dblEndDate = _EndDate.ToOADate() - 2;
                        dblStartDate = SysUtility.Approximate(dblStartDate, 1, ApproximateType.Down);
                        dblEndDate = SysUtility.Approximate(dblEndDate, 1, ApproximateType.Up);

                    }
                    if (_PaymentDateStatus != 0)
                    {
                         dblStartDate = _StartPaymentDate.ToOADate() - 2;
                         dblEndDate = _EndPaymentDate.ToOADate() - 2;
                        dblStartDate = SysUtility.Approximate(dblStartDate, 1, ApproximateType.Down);
                        dblEndDate = SysUtility.Approximate(dblEndDate, 1, ApproximateType.Up);
                        
                    }
                    if (dblStartDate != 0)
                    {
                        strWhere = strWhere + " and GLPayment.PaymentDate>= " + dblStartDate +
                                " and GLPayment.PaymentDate<" + dblEndDate + " ";
                    }
                }
              
                /* Type Condetion*/
                strSql += strWhere;

                #endregion
                Returned = " SELECT SUM(dbo.GLPayment.PaymentValue) AS TotalValue,";

                if (strPeriod != "")
                    Returned += "  Year(GLPayment.PaymentDate) as Y, month(GLPayment.PaymentDate) as M, " +
                        strPeriod + "  as DateStr";
                else
                    Returned += "0 as Y,0 as M,'' as DateStr  ";
                //Returned = " SELECT SUM(dbo.GLPayment.PaymentValue) AS TotalValue,Year(GLPayment.PaymentDate) as Y,Month(GLPayment.PaymentDate) as M ";
                //Returned +=  ","+ strPeriod  +" as DateStr ";

                if (_CellfamilyID == 0)
                    Returned += ",CellTable.CellAlterName,CellTable.CellFamilyID ";
                Returned +=" FROM  CRMTempReservationPayment INNER JOIN " +
                   " dbo.GLPayment ON dbo.CRMTempReservationPayment.PaymentID = dbo.GLPayment.PaymentID "+
                   " inner join ("+ strSql +") as CellTable on CellTable.PaymentID = GLPayment.PaymentID ";
                //Returned += " group by "
                string strGroup = "";
                if(_CellfamilyID == 0)
                    strGroup +=  "CellTable.CellAlterName,CellTable.CellFamilyID ";
                if (strPeriod != "")
                {
                    if (strGroup != "")
                        strGroup += ",";
                    strGroup += strPeriod;
                    strGroup += ",Year(GLPayment.PaymentDate),Month(GLPayment.PaymentDate) ";
                }
                if (strGroup != "")
                    Returned += " group by " + strGroup;
               strSql =  "select 0 as TotalDiscount,TotalValue TotalDeservedValue," +
                   "0 as DeservedCheckValue,0 as NonDeservedCheckValue,TotalValue as CurrentTotalPaidValue,"+
                   "TotalValue as TotalPaidValue,Convert(int,Y) as Y," +
                   "convert(int,M) as M,DateStr  ";
               strSql += " ,'دفعات حجز وتعاقد' InstallmentTypeNameA,0 as InstallmentMainType";
               if (_CellfamilyID == 0)
               {
                   strSql += ",CellAlterName,CellFamilyID";
                  // Returned += ",CellAlterName,CellfamilyID";
               }

               Returned = strSql + " from (" + Returned + ") as NativeTable ";
              // Returned += " order by y,m ";
                return Returned;
            }
        }
        public string CampaignSearchStr1
        {
            get
            {
                string Returned = "";
                string strPeriod = "";
                if (_PeriodType == 1)
                    strPeriod = " SUBSTRING(CONVERT(varchar(10), InstallmentDueDate, 103), 4, 10) ";
                string strDeliveredUnit = "SELECT dbo.CRMReservation.ReservationID,dbo.CRMReservation.ReservationDeliveryDate " +
                    ",  SUM(CASE WHEN dbo.CRMUnit.UnitDeliveryDate IS NULL THEN 0 ELSE 1 END) AS DeliveredUnitCount " +
                        " FROM         dbo.CRMReservation LEFT OUTER JOIN " +
                        " dbo.CRMUnit ON dbo.CRMReservation.ReservationID = dbo.CRMUnit.CurrentReservation " +
                        " GROUP BY dbo.CRMReservation.ReservationID,dbo.CRMReservation.ReservationDeliveryDate  ";
                strDeliveredUnit = "select * from (" + strDeliveredUnit + ") as NativeDeliveredTable where (1=1) ";
                if (_DeliveryStatus != 0)
                {
                    if (_DeliveryStatus == 1)
                    {
                        strDeliveredUnit += " and (DeliveredUnitCount >0 or ";
                        if (_IsDeliverDateStatus)
                        {
                            double dblDeliveryDate = SysUtility.Approximate(_DeliveryRefrenceDate.ToOADate() - 2,
                                1, ApproximateType.Up);
                            strDeliveredUnit += " ReservationDeliveryDate > " + dblDeliveryDate;


                        }
                        else
                            strDeliveredUnit += " ReservationDeliveryDate >GetDate() ";
                        strDeliveredUnit += ")";



                    }
                    else
                    {
                        strDeliveredUnit += " and (DeliveredUnitCount =0 and ";
                        if (_IsDeliverDateStatus)
                        {
                            double dblDeliveryDate = SysUtility.Approximate(_DeliveryRefrenceDate.ToOADate() - 2,
                                1, ApproximateType.Up);
                            strDeliveredUnit += " ReservationDeliveryDate <= " + dblDeliveryDate;


                        }
                        else
                            strDeliveredUnit += " ReservationDeliveryDate <=GetDate() ";
                        strDeliveredUnit += ")";
                    }
                }

             
                string strReservation = "SELECT distinct  dbo.CRMReservationCustomer.ReservationID,dbo.CRMReservation.ReservationDeliveryDate " +
                ",DeliveredTable.DeliveredUnitCount " +
                  "" +
                    " FROM  CRMReservation inner join  dbo.CRMReservationCustomer " +
                    " on CRMReservation.ReservationID = CRMReservationCustomer.ReservationID " +
                       " inner join (" + strDeliveredUnit + ") as DeliveredTable " +
                       " on CRMReservation.ReservationID = DeliveredTable.ReservationID " +
                       " WHERE (1=1) ";

           
                string strSql = "SELECT distinct dbo.CRMReservationInstallment.InstallmentID " +
                      ",CampaignTable.DeliveredUnitCount,CampaignTable.ReservationDeliveryDate " +
                      " " +
                       " FROM   dbo.CRMReservationInstallment INNER JOIN " +
                       " dbo.CRMUnit INNER JOIN " +
                       " dbo.CRMUnitCell ON dbo.CRMUnit.UnitID = dbo.CRMUnitCell.UnitID INNER JOIN " +
                       " dbo.RPCell ON dbo.CRMUnitCell.CellID = dbo.RPCell.CellID ON " +
                       " dbo.CRMReservationInstallment.ReservationID = dbo.CRMUnit.CurrentReservation ";

                //strCampaign += " group by dbo.CRMReservationCustomer.ReservationID ";
                strSql += " inner join (" + strReservation + ") as CampaignTable " +
                    " on dbo.CRMUnit.CurrentReservation = CampaignTable.ReservationID ";





                strSql += " WHERE     (1=1) ";
                string strWhere = "";

                /* Type Condetion*/
                strSql += strWhere;

                #region Str Query
                if (!_TypeGrouping)
                    _InstallmentType = -1;
                string strReservationCell = "";
                string strSelect = " SELECT  0 as CampaignID,'' as Exp, ";

                strSelect += "0 as Y,0 as M,'' as DateStr  ";



                strSelect += ",'' as CellAlterName,0 as CellfamilyID ";



                string strFrom = "";
                strFrom = " FROM   CRMReservationInstallment  " +
                    " inner join (" + strSql + ") as CampaignTable on " +
                    //" CRMReservationInstallment.ReservationID = CampaignTable.ReservationID ";
                    " CRMReservationInstallment.InstallmentID = CampaignTable.InstallmentID ";

                //strWhere = " where (CRMReservationInstallment.InstallmentID in (select InstallmentID from (" + strSql + ") as NativeTable ))";
                strWhere = " where 1=1 ";
                string strStatusWhere = strWhere;



                string strGroup = "";
                strGroup = strPeriod == "" ? strGroup : strGroup + "" + strPeriod;
                //if (strGroup != "")
                //    strGroup += ", Year(InstallmentDueDate), month(InstallmentDueDate)";


                if (_InstallmentType == 0)
                {
                    if (strGroup != "")
                        strGroup += ",";
                    strGroup += "InstallmentTypeNameA ";
                }
                if (strGroup != "")
                    strGroup = " Group by " + strGroup;


                #endregion
                #region Installment Payment Region

                string strInstallmentPayment = "";

                double dblStartPayment = _StartPaymentDate.ToOADate() - 2;
                double dblEndPayment = _EndPaymentDate.ToOADate() - 2;
                dblStartPayment = SysUtility.Approximate(dblStartPayment, 1, ApproximateType.Down);
                dblEndPayment = SysUtility.Approximate(dblEndPayment, 1, ApproximateType.Up);

                strInstallmentPayment = strSelect + ", SUM(CASE WHEN GLPayment.PaymentValue IS NULL " +
                 " THEN 0  when GLPayment.PaymentValue IS not NULL and GLCheckPayment.PaymentID is null and dbo.GLPayment.PaymentDate >= CampaignTable.CampaignInstallmentStartPaymentDate ";
                if (_PaymentDateStatus != 0)
                    strInstallmentPayment += " and  dbo.GLPayment.PaymentDate >=" + dblStartPayment +
                        " and  dbo.GLPayment.PaymentDate < " + dblEndPayment;
                strInstallmentPayment += " then GLPayment.PaymentValue " +
                 " when ((GLCheck.CheckCurrentStatus= 2 or GLCheck.CheckCurrentStatus = 4) and dbo.GLCheck.CheckCurrentStatusDate >= CampaignTable.CampaignInstallmentStartPaymentDate ";
                if (_PaymentDateStatus != 0)
                    strInstallmentPayment += " and dbo.GLCheck.CheckCurrentStatusDate>=" + dblStartPayment +
                        " and dbo.GLCheck.CheckCurrentStatusDate <" + dblEndPayment;
                strInstallmentPayment += ") or (GLCheckPayment.PaymentIsCollected =1 and dbo.GLCheckPayment.PaymentCollectingDate >= CampaignTable.CampaignInstallmentStartPaymentDate ";
                if (_PaymentDateStatus != 0)
                    strInstallmentPayment += " and  dbo.GLCheckPayment.PaymentCollectingDate>= " + dblStartPayment +
                         " and  dbo.GLCheckPayment.PaymentCollectingDate<" + dblEndPayment;
                strInstallmentPayment += ") then  GLPayment.PaymentValue Else 0 END) AS CurrentTotalPaidValue ";
                #region TotalPaidValue
                strInstallmentPayment += ", SUM(CASE WHEN GLPayment.PaymentValue IS NULL " +
          " THEN 0  when GLPayment.PaymentValue IS not NULL and GLCheckPayment.PaymentID is null ";

                strInstallmentPayment += " then GLPayment.PaymentValue " +
                 " when ((GLCheck.CheckCurrentStatus= 2 or GLCheck.CheckCurrentStatus = 4) ";

                strInstallmentPayment += ") or (GLCheckPayment.PaymentIsCollected =1 ";

                strInstallmentPayment += ") then  GLPayment.PaymentValue Else 0 END) AS TotalPaidValue ";

                /////////////////////////////////////////
                strInstallmentPayment += ", SUM(CASE WHEN GLPayment.PaymentValue IS NULL " +
                    " or  dbo.CRMReservationInstallment.InstallmentDueDate  > CampaignTable.ReservationDeliveryDate or CampaignTable.DeliveredUnitCount>0 " +
       " THEN 0  when GLPayment.PaymentValue IS not NULL and GLCheckPayment.PaymentID is null ";
                strInstallmentPayment += " then GLPayment.PaymentValue " +
                 " when ((GLCheck.CheckCurrentStatus= 2 or GLCheck.CheckCurrentStatus = 4) ";

                strInstallmentPayment += ") or (GLCheckPayment.PaymentIsCollected =1 ";

                strInstallmentPayment += ") then  GLPayment.PaymentValue Else 0 END) AS PreDeliveryTotalPaidValue ";
                #endregion



                strInstallmentPayment += ",Sum(Case When GLCheckPayment.PaymentID is  null then 0 else ( " +
                    "case when GLCheck.CheckCurrentStatus <>2 and GLCheck.CheckCurrentStatus <>4 and GLCheckPayment.PaymentIsCollected =0  and GLCheck.CheckDueDate < GetDate() " +
                    " then  GLPayment.PaymentValue else 0 end)END ) as DeservedCheckValue ";
                strInstallmentPayment += ",Sum(Case When GLCheckPayment.PaymentID is  null then 0 else ( " +
                   "case when GLCheck.CheckCurrentStatus <>2 and GLCheck.CheckCurrentStatus <>4 and GLCheck.CheckDueDate >= GetDate() " +
                   "  and GLCheckPayment.PaymentIsCollected = 0 then  GLPayment.PaymentValue else 0 end)END ) as NonDeservedCheckValue ";
                strInstallmentPayment += strFrom + " left outer join CRMInstallmentPayment on " +
                    " CRMReservationInstallment.InstallmentID = CRMInstallmentPayment.InstallmentID " +
                    " left outer join GLPayment on  CRMInstallmentPayment.PaymentID = GLPayment.PaymentID ";
                #region Check
                strInstallmentPayment += " left outer join GLCheckPayment on GLCheckPayment.PaymentID = GLPayment.PaymentID  " +
                    "  left outer JOIN " +
                    " dbo.GLCheck ON dbo.GLCheckPayment.CheckID = dbo.GLCheck.CheckID ";
                #endregion
                string strPaymentWhere = "";//strStatusWhere;

                strInstallmentPayment += strPaymentWhere;//strStatusWhere;
                strInstallmentPayment += strGroup;

                #endregion
                #region Campaign NonDeserved Installment Payment Region


                string strTempCampaignPayment = "select distinct CampaignTable.CampaignID,CampaignTable.CampaignInstallmentStartDueDate, CampaignTable.CampaignInstallmentEndDueDate," +
                    " CampaignTable.CampaignInstallmentStartPaymentDate, CampaignTable.CampaignInstallmentEndPaymentDate,dbo.CRMReservationInstallment.ReservationID ";
                strTempCampaignPayment += " from CRMReservationInstallment inner join CRMInstallmentPayment on " +
                  " CRMReservationInstallment.InstallmentID = CRMInstallmentPayment.InstallmentID " +
                    " inner join (" + strReservation + ") as CampaignTable on " +
                    " CRMReservationInstallment.ReservationID =CampaignTable.ReservationID " +
                  " left outer join GLPayment on  CRMInstallmentPayment.PaymentID = GLPayment.PaymentID ";

                strTempCampaignPayment += " left outer join GLCheckPayment on GLCheckPayment.PaymentID = GLPayment.PaymentID  " +
                    "  left outer JOIN " +
                    " dbo.GLCheck ON dbo.GLCheckPayment.CheckID = dbo.GLCheck.CheckID " +
                    " where ( dbo.CRMReservationInstallment.InstallmentDueDate >=CampaignTable.CampaignInstallmentStartDueDate and " +
                    " dbo.CRMReservationInstallment.InstallmentDueDate < DATEADD(day, 1,  CampaignTable.CampaignInstallmentEndDueDate) ) ";

                strTempCampaignPayment += " and ((dbo.GLCheck.CheckID is null";
                if (_PaymentDateStatus != 0)
                    strTempCampaignPayment += " and GLPayment.PaymentDate >=" +
                                    dblStartPayment + " and  GLPayment.PaymentDate < " + dblEndPayment;
                strTempCampaignPayment += " and GLPayment.PaymentDate >= CampaignTable.CampaignInstallmentStartPaymentDate " +
                "  and GLPayment.PaymentDate< DATEADD(day,1,CampaignTable.CampaignInstallmentEndPaymentDate))" +
                " or(CheckCurrentStatus in (2,4) ";
                if (_PaymentDateStatus != 0)
                    strTempCampaignPayment += " and GLCheck.CheckCurrentStatusDate>=" + dblStartPayment +
                     " and GLCheck.CheckCurrentStatusDate < " + dblEndPayment;

                strTempCampaignPayment += " and GLCheck.CheckCurrentStatusDate >= CampaignTable.CampaignInstallmentStartPaymentDate " +
                "  and GLCheck.CheckCurrentStatusDate< DATEADD(day,1,CampaignTable.CampaignInstallmentEndPaymentDate)" +
                ") or ( GLCheckPayment.PaymentIsCollected=1 " +
                                  " and GLCheckPayment.PaymentCollectingDate >= CampaignTable.CampaignInstallmentStartPaymentDate " +
                                "  and GLCheckPayment.PaymentCollectingDate< DATEADD(day,1,CampaignTable.CampaignInstallmentEndPaymentDate) ";
                if (_PaymentDateStatus != 0)
                    strTempCampaignPayment += " and GLCheckPayment.PaymentCollectingDate >=" + dblStartPayment +
                         " and GLCheckPayment.PaymentCollectingDate<" + dblEndPayment;
                strTempCampaignPayment += " ))";

                string strNonDeservedPayment = "";



                strNonDeservedPayment = "select TempPaymentTable.CampaignID, SUM(CASE WHEN GLPayment.PaymentValue IS NULL " +
                 " THEN 0  when GLPayment.PaymentValue IS not NULL and GLCheckPayment.PaymentID is null and dbo.GLPayment.PaymentDate >= TempPaymentTable.CampaignInstallmentStartPaymentDate ";
                if (_PaymentDateStatus != 0)
                    strNonDeservedPayment += " and  dbo.GLPayment.PaymentDate >=" + dblStartPayment +
                        " and  dbo.GLPayment.PaymentDate < " + dblEndPayment;
                strNonDeservedPayment += " then GLPayment.PaymentValue " +
                 " when ((GLCheck.CheckCurrentStatus= 2 or GLCheck.CheckCurrentStatus = 4) and dbo.GLCheck.CheckCurrentStatusDate >= TempPaymentTable.CampaignInstallmentStartPaymentDate ";
                if (_PaymentDateStatus != 0)
                    strNonDeservedPayment += " and dbo.GLCheck.CheckCurrentStatusDate>=" + dblStartPayment +
                        " and dbo.GLCheck.CheckCurrentStatusDate <" + dblEndPayment;
                strNonDeservedPayment += ") or (GLCheckPayment.PaymentIsCollected =1 and dbo.GLCheckPayment.PaymentCollectingDate >= TempPaymentTable.CampaignInstallmentStartPaymentDate ";
                if (_PaymentDateStatus != 0)
                    strNonDeservedPayment += " and  dbo.GLCheckPayment.PaymentCollectingDate>= " + dblStartPayment +
                         " and  dbo.GLCheckPayment.PaymentCollectingDate<" + dblEndPayment;
                strNonDeservedPayment += ") then  GLPayment.PaymentValue Else 0 END) AS NonDeservedPaidValue ";



                // strNonDeservedPayment = "select CampaignTable.CampaignID ";
                strNonDeservedPayment += " from CRMReservationInstallment inner join (" + strTempCampaignPayment + ") as TempPaymentTable " +
                    " on CRMReservationInstallment.ReservationID = TempPaymentTable.ReservationID " +
                    " left outer join CRMInstallmentPayment on " +
                    " CRMReservationInstallment.InstallmentID = CRMInstallmentPayment.InstallmentID " +
                    " left outer join GLPayment on  CRMInstallmentPayment.PaymentID = GLPayment.PaymentID ";

                strNonDeservedPayment += " left outer join GLCheckPayment on GLCheckPayment.PaymentID = GLPayment.PaymentID  " +
                    "  left outer JOIN " +
                    " dbo.GLCheck ON dbo.GLCheckPayment.CheckID = dbo.GLCheck.CheckID " +
                    " where  dbo.CRMReservationInstallment.InstallmentDueDate > DateAdd(day,1,TempPaymentTable.CampaignInstallmentEndDueDate) ";

                strNonDeservedPayment += " group by TempPaymentTable.CampaignID  ";

                strNonDeservedPayment = "select CampaignID,sum(NonDeservedPaidValue)  as NonDeservedPaidValue" +
                    " from (" + strNonDeservedPayment + ") as NonDeservedPaidTable group by CampaignID  ";

                #endregion
                #region Installment Value Region

                string strInstallmentValue = "";
                strInstallmentValue = strSelect + ",SUM(CRMReservationInstallment.InstallmentValue) AS TotalDeservedValue ";

                strInstallmentValue += ",SUM(case when dbo.CRMReservationInstallment.InstallmentDueDate  > " +
                    " CampaignTable.ReservationDeliveryDate or CampaignTable.DeliveredUnitCount>0 then 0 else CRMReservationInstallment.InstallmentValue end) AS PreDeliveryTotalDeservedValue ";
                //" or  dbo.CRMReservationInstallment.InstallmentDueDate  > CampaignTable.ReservationDeliveryDate or CampaignTable.DeliveredUnitCount>0 ";

                strInstallmentValue += strFrom;

                strInstallmentValue += strWhere;
                strInstallmentValue += strGroup;


                #endregion
                #region Discount Region
                string strDiscount = "";
                if (_PaymentDateStatus == 0)
                    strDiscount = strSelect + ",SUM(CASE WHEN CRMReservationInstallmentDiscount.DiscountValue IS NULL THEN 0 ELSE CRMReservationInstallmentDiscount.DiscountValue END)" +
                              " AS TotalDiscount ";
                else
                    strDiscount = strSelect + ",SUM(CASE WHEN CRMReservationInstallmentDiscount.DiscountValue is null " +
                        " or DiscountPaymentTable.InstallmentID IS NULL THEN 0 ELSE CRMReservationInstallmentDiscount.DiscountValue END)" +
                         " AS TotalDiscount ";

                ////////////////////////////////////////////////////////////////////////////////
                if (_PaymentDateStatus == 0)
                    strDiscount += ",SUM(CASE WHEN CRMReservationInstallmentDiscount.DiscountValue IS NULL " +
                        " or  dbo.CRMReservationInstallment.InstallmentDueDate  > CampaignTable.ReservationDeliveryDate or CampaignTable.DeliveredUnitCount>0 " +
                        " THEN 0 ELSE CRMReservationInstallmentDiscount.DiscountValue END)" +
                              " AS PreDeliveryTotalDiscount ";
                else
                    strDiscount += ",SUM(CASE WHEN CRMReservationInstallmentDiscount.DiscountValue is null " +
                        " or  dbo.CRMReservationInstallment.InstallmentDueDate  > CampaignTable.ReservationDeliveryDate or CampaignTable.DeliveredUnitCount>0 " +
                        " or DiscountPaymentTable.InstallmentID IS NULL THEN 0 ELSE CRMReservationInstallmentDiscount.DiscountValue END)" +
                         " AS PreDeliveryTotalDiscount ";
                ///////////////////////////////////////////////////////////////////////////////

                strDiscount += strFrom + " left outer join CRMReservationInstallmentDiscount on " +
                    " CRMReservationInstallmentDiscount.InstallmentID =CRMReservationInstallment.InstallmentID ";
                if (_PaymentDateStatus != 0)
                {
                    string strDiscountPayment = "SELECT  dbo.CRMInstallmentPayment.InstallmentID " +
                           " FROM         dbo.GLCheck RIGHT OUTER JOIN " +
                           " dbo.GLCheckPayment ON dbo.GLCheck.CheckID = dbo.GLCheckPayment.CheckID RIGHT OUTER JOIN " +
                           " dbo.CRMInstallmentPayment INNER JOIN " +
                           " dbo.GLPayment ON dbo.CRMInstallmentPayment.PaymentID = dbo.GLPayment.PaymentID ON  " +
                           " dbo.GLCheckPayment.PaymentID = dbo.GLPayment.PaymentID ";
                    strDiscountPayment += " where (GLCheckPayment.CheckID is null and GLPayment.PaymentDate>=" + dblStartPayment + " and GLPayment.PaymentDate <" +
                        dblEndPayment + ") or (dbo.GLCheck.CheckCurrentStatus=2 and  dbo.GLCheck.CheckCurrentStatusDate>=" + dblStartPayment +
                        " and  dbo.GLCheck.CheckCurrentStatusDate<" + dblEndPayment + " ) " +
                        " or ( dbo.GLCheckPayment.PaymentIsCollected=1 and dbo.GLCheckPayment.PaymentCollectingDate>=" + dblStartPayment + " and dbo.GLCheckPayment.PaymentCollectingDate <" + dblEndPayment + ") ";
                    strDiscount += " left outer join (" + strDiscountPayment + ") as DiscountPaymentTable on CRMReservationInstallmentDiscount.InstallmentID = DiscountPaymentTable.InstallmentID  ";
                }
                strDiscount += strStatusWhere;
                strDiscount += strGroup;
                #endregion
                string strPaymentJoinType = " left outer join ";
                if (intStatus == 2)
                    strPaymentJoinType = " inner join ";
                Returned = "select InstallmentTable.CampaignID,0 as TotalDiscount,InstallmentTable.TotalDeservedValue," +
                    "InstallmentPaymentTable.DeservedCheckValue,InstallmentPaymentTable.NonDeservedCheckValue," +
                    "InstallmentPaymentTable.CurrentTotalPaidValue,InstallmentPaymentTable.TotalPaidValue" +
                    ",InstallmentTable.PreDeliveryTotalDeservedValue,InstallmentPaymentTable.PreDeliveryTotalPaidValue" +
                    ",convert(int,InstallmentTable.Y) as Y," +
                    "convert(int,InstallmentTable.M) as M,InstallmentTable.DateStr,InstallmentTable.CampaignID as InstallmentCampaign " +
                    ",case when NonDeservedTable.NonDeservedPaidValue is null then 0 else NonDeservedTable.NonDeservedPaidValue end " +
                    " as NonDeservedPaidValue ";
                if (_InstallmentType == 0)
                    Returned += ",InstallmentTable.InstallmentTypeNameA ";
                else
                    Returned += ", '' as InstallmentTypeNameA ";
                if (_CellfamilyID == 0)
                    Returned += ",InstallmentTable.CellAlterName,InstallmentTable.CellFamilyID ";
                Returned += " from (" + strInstallmentValue + ") as InstallmentTable " + strPaymentJoinType + " (" +
                    strInstallmentPayment + ") as InstallmentPaymentTable " +
                    " on InstallmentTable.CampaignID = InstallmentPaymentTable.CampaignID " +
                    " left outer join (" + strNonDeservedPayment + ") as NonDeservedTable on " +
                    " InstallmentTable.CampaignID = NonDeservedTable.CampaignID  ";
                if (_CellfamilyID == 0)
                    Returned += " and InstallmentTable.CellfamilyID = InstallmentPaymentTable.CellFamilyID ";
                if (_InstallmentType == 0)
                    Returned += " and InstallmentTable.InstallmentTypeNameA = InstallmentPaymentTable.InstallmentTypeNameA ";

                return Returned;


            }
        }

        #region Campaign Work
     

        public string CampaignSearchStr
        {
            get
            {
                string Returned = "";
                string strPeriod = "";
                if (_PeriodType == 1)
                    strPeriod = " SUBSTRING(CONVERT(varchar(10), InstallmentDueDate, 103), 4, 10) ";
                string strDeliveredUnit = "SELECT dbo.CRMReservation.ReservationID,dbo.CRMReservation.ReservationDeliveryDate "+
                    ",  SUM(CASE WHEN dbo.CRMUnit.UnitDeliveryDate IS NULL THEN 0 ELSE 1 END) AS DeliveredUnitCount " +
                        " FROM  dbo.CRMReservation LEFT OUTER JOIN " +
                        " dbo.CRMUnit ON dbo.CRMReservation.ReservationID = dbo.CRMUnit.CurrentReservation "+
                        " GROUP BY dbo.CRMReservation.ReservationID,dbo.CRMReservation.ReservationDeliveryDate  ";
              strDeliveredUnit = "select * from ("+ strDeliveredUnit +") as NativeDeliveredTable where (1=1) ";
                if (_DeliveryStatus != 0)
                {
                    if (_DeliveryStatus == 1)
                    {
                        strDeliveredUnit += " and (DeliveredUnitCount >0 or ";
                        if (_IsDeliverDateStatus)
                        {
                            double dblDeliveryDate = SysUtility.Approximate(_DeliveryRefrenceDate.ToOADate() - 2,
                                1, ApproximateType.Up);
                            strDeliveredUnit += " ReservationDeliveryDate > " + dblDeliveryDate;


                        }
                        else
                            strDeliveredUnit += " ReservationDeliveryDate >GetDate() ";
                        strDeliveredUnit += ")";



                    }
                    else
                    {
                        strDeliveredUnit += " and (DeliveredUnitCount =0 and ";
                        if (_IsDeliverDateStatus)
                        {
                            double dblDeliveryDate = SysUtility.Approximate(_DeliveryRefrenceDate.ToOADate() - 2,
                                1, ApproximateType.Up);
                            strDeliveredUnit += " ReservationDeliveryDate <= " + dblDeliveryDate;


                        }
                        else
                            strDeliveredUnit += " ReservationDeliveryDate <=GetDate() ";
                        strDeliveredUnit += ")";
                    }
                }
              
                string strCampaignInstallmentCount = "SELECT     dbo.CRMCampaign.CampaignID, COUNT(dbo.CRMCampaignInstallmentType.InstallmentType) AS CampaignInstallmentCount " +
               " FROM         dbo.CRMCampaign LEFT OUTER JOIN " +
               " dbo.CRMCampaignInstallmentType ON dbo.CRMCampaign.CampaignID = dbo.CRMCampaignInstallmentType.Campaign " +
               " GROUP BY dbo.CRMCampaign.CampaignID ";

                string strCampaignContact = "SELECT CampaignCustomerID, SUM(CASE WHEN ContactStatus = 1 THEN 1 ELSE 0 END) AS ContactCount "+
                  " FROM         dbo.CRMCampaignCustomerContact "+
                  " GROUP BY CampaignCustomerID ";

                string strCampaign = "SELECT distinct  dbo.CRMReservationCustomer.ReservationID,dbo.CRMReservation.ReservationDeliveryDate " +
                    ",dbo.CRMCampaign.CampaignID" +
                    ", dbo.CRMCampaign.CampaignDate, dbo.CRMCampaign.CampaignDesc, dbo.CRMCampaign.CampaignCellFamily, " +
                    "dbo.CRMCampaign.CampaignInstallmentStartDueDate, dbo.CRMCampaign.CampaignInstallmentEndDueDate, " +
                  "dbo.CRMCampaign.CampaignInstallmentStartPaymentDate, dbo.CRMCampaign.CampaignInstallmentEndPaymentDate " +
                  ",CampaignInstallmentCountTable.CampaignInstallmentCount,DeliveredTable.DeliveredUnitCount " +
                  "" +
                    " FROM  CRMReservation inner join  dbo.CRMReservationCustomer " +
                    " on CRMReservation.ReservationID = CRMReservationCustomer.ReservationID " +
                      " INNER JOIN  dbo.CRMCampaignCustomer  " +
                       " ON dbo.CRMReservationCustomer.CustomerID = dbo.CRMCampaignCustomer.Customer " +
                       " INNER JOIN  dbo.CRMCampaign " +
                       " ON dbo.CRMCampaignCustomer.Campaign = dbo.CRMCampaign.CampaignID " +
                       " inner join (" + strCampaignInstallmentCount + ") CampaignInstallmentCountTable " +
                       " on CRMCampaign.CampaignID =CampaignInstallmentCountTable.CampaignID " +
                       " inner join (" + strDeliveredUnit + ") as DeliveredTable " +
                       " on CRMReservation.ReservationID = DeliveredTable.ReservationID " +
                       " left outer join (" + strCampaignContact + ") as CampaignContactTable "+
                       " on CRMCampaignCustomer.CampaignCustomerID = CampaignContactTable.CampaignCustomerID "+
                       " WHERE (dbo.CRMCampaign.CampaignIsForInstallment = 1 ) ";

                strCampaign += " and (CampaignContactTable.ContactCount is not null and CampaignContactTable.ContactCount >0 ) ";
                if (_CampaignIDs != null && _CampaignIDs != "")
                    strCampaign += " and CRMCampaign.CampaignID in (" + _CampaignIDs + ") ";
                string strSql = "SELECT distinct dbo.CRMReservationInstallment.InstallmentID " +
                    ",CampaignTable.CampaignID, CampaignTable.CampaignCellFamily, CampaignTable.CampaignInstallmentStartDueDate," +
                      "CampaignTable.CampaignInstallmentEndDueDate, CampaignTable.CampaignInstallmentStartPaymentDate, " +
                      "CampaignTable.CampaignInstallmentEndPaymentDate, CampaignTable.CampaignDate, CampaignTable.CampaignDesc" +
                      ",CampaignTable.DeliveredUnitCount,CampaignTable.ReservationDeliveryDate " +
                      " " +
                       " FROM   dbo.CRMReservationInstallment INNER JOIN " +
                       " dbo.CRMUnit INNER JOIN " +
                       " dbo.CRMUnitCell ON dbo.CRMUnit.UnitID = dbo.CRMUnitCell.UnitID INNER JOIN " +
                       " dbo.RPCell ON dbo.CRMUnitCell.CellID = dbo.RPCell.CellID ON " +
                       " dbo.CRMReservationInstallment.ReservationID = dbo.CRMUnit.CurrentReservation ";

                //strCampaign += " group by dbo.CRMReservationCustomer.ReservationID ";
                strSql += " inner join (" + strCampaign + ") as CampaignTable " +
                    " on dbo.CRMUnit.CurrentReservation = CampaignTable.ReservationID and " +
                    " (RPCell.CellFamilyID = CampaignTable.CampaignCellFamily  or  CampaignTable.CampaignCellFamily = 0) " +
                    " and dbo.CRMReservationInstallment.InstallmentDueDate >=CampaignTable.CampaignInstallmentStartDueDate and " +
                    " dbo.CRMReservationInstallment.InstallmentDueDate <  DATEADD(day, 1, CampaignTable.CampaignInstallmentEndDueDate) " +
                      " left outer join CRMCampaignInstallmentType on " +
                      "CRMReservationInstallment.InstallmentType = CRMCampaignInstallmentType.InstallmentType and " +
                      " CampaignTable.CampaignID = CRMCampaignInstallmentType.Campaign ";





                strSql += " WHERE     (1=1) and (CampaignTable.CampaignInstallmentCount=0  or CRMCampaignInstallmentType.InstallmentType is not null ) ";
                string strWhere = "";

                /* Type Condetion*/
                strSql += strWhere;
             
                #region Str Query
                if (!_TypeGrouping)
                    _InstallmentType = -1;
                string strReservationCell = "";
                string strSelect = " SELECT  CampaignTable.CampaignID,'' as Exp, ";

                strSelect += "0 as Y,0 as M,'' as DateStr  ";



                strSelect += ",'' as CellAlterName,0 as CellfamilyID ";



                string strFrom = "";
                strFrom = " FROM   CRMReservationInstallment  " +
                    " inner join (" + strSql + ") as CampaignTable on " +
                    //" CRMReservationInstallment.ReservationID = CampaignTable.ReservationID ";
                    " CRMReservationInstallment.InstallmentID = CampaignTable.InstallmentID ";

                //strWhere = " where (CRMReservationInstallment.InstallmentID in (select InstallmentID from (" + strSql + ") as NativeTable ))";
                strWhere = " where 1=1 ";
                string strStatusWhere = strWhere;



                string strGroup = "CampaignTable.CampaignID";
                strGroup = strPeriod == "" ? strGroup : strGroup + "," + strPeriod;
                //if (strGroup != "")
                //    strGroup += ", Year(InstallmentDueDate), month(InstallmentDueDate)";


                if (_InstallmentType == 0)
                {
                    if (strGroup != "")
                        strGroup += ",";
                    strGroup += "InstallmentTypeNameA ";
                }
                if (strGroup != "")
                    strGroup = " Group by " + strGroup;


                #endregion
                #region Installment Payment Region

                string strInstallmentPayment = "";

                double dblStartPayment = _StartPaymentDate.ToOADate() - 2;
                double dblEndPayment = _EndPaymentDate.ToOADate() - 2;
                dblStartPayment = SysUtility.Approximate(dblStartPayment, 1, ApproximateType.Down);
                dblEndPayment = SysUtility.Approximate(dblEndPayment, 1, ApproximateType.Up);

                strInstallmentPayment = strSelect + ", SUM(CASE WHEN GLPayment.PaymentValue IS NULL " +
                 " THEN 0  when GLPayment.PaymentValue IS not NULL and GLCheckPayment.PaymentID is null and dbo.GLPayment.PaymentDate >= CampaignTable.CampaignInstallmentStartPaymentDate ";
                if (_PaymentDateStatus != 0)
                    strInstallmentPayment += " and  dbo.GLPayment.PaymentDate >=" + dblStartPayment +
                        " and  dbo.GLPayment.PaymentDate < " + dblEndPayment;
                strInstallmentPayment += " then GLPayment.PaymentValue " +
                 " when ((GLCheck.CheckCurrentStatus= 2 or GLCheck.CheckCurrentStatus = 4) and dbo.GLCheck.CheckCurrentStatusDate >= CampaignTable.CampaignInstallmentStartPaymentDate ";
                if (_PaymentDateStatus != 0)
                    strInstallmentPayment += " and dbo.GLCheck.CheckCurrentStatusDate>=" + dblStartPayment +
                        " and dbo.GLCheck.CheckCurrentStatusDate <" + dblEndPayment;
                strInstallmentPayment += ") or (GLCheckPayment.PaymentIsCollected =1 and dbo.GLCheckPayment.PaymentCollectingDate >= CampaignTable.CampaignInstallmentStartPaymentDate ";
                if (_PaymentDateStatus != 0)
                    strInstallmentPayment += " and  dbo.GLCheckPayment.PaymentCollectingDate>= " + dblStartPayment +
                         " and  dbo.GLCheckPayment.PaymentCollectingDate<" + dblEndPayment;
                strInstallmentPayment += ") then  GLPayment.PaymentValue Else 0 END) AS CurrentTotalPaidValue ";
                #region TotalPaidValue
                strInstallmentPayment += ", SUM(CASE WHEN GLPayment.PaymentValue IS NULL " +
          " THEN 0  when GLPayment.PaymentValue IS not NULL and GLCheckPayment.PaymentID is null ";

                strInstallmentPayment += " then GLPayment.PaymentValue " +
                 " when ((GLCheck.CheckCurrentStatus= 2 or GLCheck.CheckCurrentStatus = 4) ";

                strInstallmentPayment += ") or (GLCheckPayment.PaymentIsCollected =1 ";

                strInstallmentPayment += ") then  GLPayment.PaymentValue Else 0 END) AS TotalPaidValue ";

/////////////////////////////////////////
                strInstallmentPayment += ", SUM(CASE WHEN GLPayment.PaymentValue IS NULL " +
                    " or  dbo.CRMReservationInstallment.InstallmentDueDate  > CampaignTable.ReservationDeliveryDate or CampaignTable.DeliveredUnitCount>0 " +
       " THEN 0  when GLPayment.PaymentValue IS not NULL and GLCheckPayment.PaymentID is null ";
                strInstallmentPayment += " then GLPayment.PaymentValue " +
                 " when ((GLCheck.CheckCurrentStatus= 2 or GLCheck.CheckCurrentStatus = 4) ";

                strInstallmentPayment += ") or (GLCheckPayment.PaymentIsCollected =1 ";

                strInstallmentPayment += ") then  GLPayment.PaymentValue Else 0 END) AS PreDeliveryTotalPaidValue ";
                #endregion



                strInstallmentPayment += ",Sum(Case When GLCheckPayment.PaymentID is  null then 0 else ( " +
                    "case when GLCheck.CheckCurrentStatus <>2 and GLCheck.CheckCurrentStatus <>4 and GLCheckPayment.PaymentIsCollected =0  and GLCheck.CheckDueDate < GetDate() " +
                    " then  GLPayment.PaymentValue else 0 end)END ) as DeservedCheckValue ";
                strInstallmentPayment += ",Sum(Case When GLCheckPayment.PaymentID is  null then 0 else ( " +
                   "case when GLCheck.CheckCurrentStatus <>2 and GLCheck.CheckCurrentStatus <>4 and GLCheck.CheckDueDate >= GetDate() " +
                   "  and GLCheckPayment.PaymentIsCollected = 0 then  GLPayment.PaymentValue else 0 end)END ) as NonDeservedCheckValue ";
                strInstallmentPayment += strFrom + " left outer join CRMInstallmentPayment on " +
                    " CRMReservationInstallment.InstallmentID = CRMInstallmentPayment.InstallmentID " +
                    " left outer join GLPayment on  CRMInstallmentPayment.PaymentID = GLPayment.PaymentID ";
                #region Check
                strInstallmentPayment += " left outer join GLCheckPayment on GLCheckPayment.PaymentID = GLPayment.PaymentID  " +
                    "  left outer JOIN " +
                    " dbo.GLCheck ON dbo.GLCheckPayment.CheckID = dbo.GLCheck.CheckID ";
                #endregion
                string strPaymentWhere = "";//strStatusWhere;

                strInstallmentPayment += strPaymentWhere;//strStatusWhere;
                strInstallmentPayment += strGroup;

                #endregion
                #region Campaign NonDeserved Installment Payment Region


                string strTempCampaignPayment = "select distinct CampaignTable.CampaignID,CampaignTable.CampaignInstallmentStartDueDate, CampaignTable.CampaignInstallmentEndDueDate," +
                    " CampaignTable.CampaignInstallmentStartPaymentDate, CampaignTable.CampaignInstallmentEndPaymentDate,dbo.CRMReservationInstallment.ReservationID ";
                strTempCampaignPayment += " from CRMReservationInstallment inner join CRMInstallmentPayment on " +
                  " CRMReservationInstallment.InstallmentID = CRMInstallmentPayment.InstallmentID " +
                    " inner join (" + strCampaign + ") as CampaignTable on " +
                    " CRMReservationInstallment.ReservationID =CampaignTable.ReservationID " +
                  " left outer join GLPayment on  CRMInstallmentPayment.PaymentID = GLPayment.PaymentID ";

                strTempCampaignPayment += " left outer join GLCheckPayment on GLCheckPayment.PaymentID = GLPayment.PaymentID  " +
                    "  left outer JOIN " +
                    " dbo.GLCheck ON dbo.GLCheckPayment.CheckID = dbo.GLCheck.CheckID " +
                    " where ( dbo.CRMReservationInstallment.InstallmentDueDate >=CampaignTable.CampaignInstallmentStartDueDate and " +
                    " dbo.CRMReservationInstallment.InstallmentDueDate < DATEADD(day, 1,  CampaignTable.CampaignInstallmentEndDueDate) ) ";

                strTempCampaignPayment += " and ((dbo.GLCheck.CheckID is null";
                if (_PaymentDateStatus != 0)
                    strTempCampaignPayment += " and GLPayment.PaymentDate >=" +
                                    dblStartPayment + " and  GLPayment.PaymentDate < " + dblEndPayment;
                strTempCampaignPayment += " and GLPayment.PaymentDate >= CampaignTable.CampaignInstallmentStartPaymentDate " +
                "  and GLPayment.PaymentDate< DATEADD(day,1,CampaignTable.CampaignInstallmentEndPaymentDate))" +
                " or(CheckCurrentStatus in (2,4) ";
                if (_PaymentDateStatus != 0)
                    strTempCampaignPayment += " and GLCheck.CheckCurrentStatusDate>=" + dblStartPayment +
                     " and GLCheck.CheckCurrentStatusDate < " + dblEndPayment;

                strTempCampaignPayment += " and GLCheck.CheckCurrentStatusDate >= CampaignTable.CampaignInstallmentStartPaymentDate " +
                "  and GLCheck.CheckCurrentStatusDate< DATEADD(day,1,CampaignTable.CampaignInstallmentEndPaymentDate)" +
                ") or ( GLCheckPayment.PaymentIsCollected=1 " +
                                  " and GLCheckPayment.PaymentCollectingDate >= CampaignTable.CampaignInstallmentStartPaymentDate " +
                                "  and GLCheckPayment.PaymentCollectingDate< DATEADD(day,1,CampaignTable.CampaignInstallmentEndPaymentDate) ";
                if (_PaymentDateStatus != 0)
                    strTempCampaignPayment += " and GLCheckPayment.PaymentCollectingDate >=" + dblStartPayment +
                         " and GLCheckPayment.PaymentCollectingDate<" + dblEndPayment;
                strTempCampaignPayment += " ))";

                string strNonDeservedPayment = "";



                strNonDeservedPayment = "select TempPaymentTable.CampaignID, SUM(CASE WHEN GLPayment.PaymentValue IS NULL " +
                 " THEN 0  when GLPayment.PaymentValue IS not NULL and GLCheckPayment.PaymentID is null and dbo.GLPayment.PaymentDate >= TempPaymentTable.CampaignInstallmentStartPaymentDate ";
                if (_PaymentDateStatus != 0)
                    strNonDeservedPayment += " and  dbo.GLPayment.PaymentDate >=" + dblStartPayment +
                        " and  dbo.GLPayment.PaymentDate < " + dblEndPayment;
                strNonDeservedPayment += " then GLPayment.PaymentValue " +
                 " when ((GLCheck.CheckCurrentStatus= 2 or GLCheck.CheckCurrentStatus = 4) and dbo.GLCheck.CheckCurrentStatusDate >= TempPaymentTable.CampaignInstallmentStartPaymentDate ";
                if (_PaymentDateStatus != 0)
                    strNonDeservedPayment += " and dbo.GLCheck.CheckCurrentStatusDate>=" + dblStartPayment +
                        " and dbo.GLCheck.CheckCurrentStatusDate <" + dblEndPayment;
                strNonDeservedPayment += ") or (GLCheckPayment.PaymentIsCollected =1 and dbo.GLCheckPayment.PaymentCollectingDate >= TempPaymentTable.CampaignInstallmentStartPaymentDate ";
                if (_PaymentDateStatus != 0)
                    strNonDeservedPayment += " and  dbo.GLCheckPayment.PaymentCollectingDate>= " + dblStartPayment +
                         " and  dbo.GLCheckPayment.PaymentCollectingDate<" + dblEndPayment;
                strNonDeservedPayment += ") then  GLPayment.PaymentValue Else 0 END) AS NonDeservedPaidValue ";



                // strNonDeservedPayment = "select CampaignTable.CampaignID ";
                strNonDeservedPayment += " from CRMReservationInstallment inner join (" + strTempCampaignPayment + ") as TempPaymentTable " +
                    " on CRMReservationInstallment.ReservationID = TempPaymentTable.ReservationID " +
                    " left outer join CRMInstallmentPayment on " +
                    " CRMReservationInstallment.InstallmentID = CRMInstallmentPayment.InstallmentID " +
                    " left outer join GLPayment on  CRMInstallmentPayment.PaymentID = GLPayment.PaymentID ";

                strNonDeservedPayment += " left outer join GLCheckPayment on GLCheckPayment.PaymentID = GLPayment.PaymentID  " +
                    "  left outer JOIN " +
                    " dbo.GLCheck ON dbo.GLCheckPayment.CheckID = dbo.GLCheck.CheckID " +
                    " where  dbo.CRMReservationInstallment.InstallmentDueDate > DateAdd(day,1,TempPaymentTable.CampaignInstallmentEndDueDate) ";

                strNonDeservedPayment += " group by TempPaymentTable.CampaignID  ";

                strNonDeservedPayment = "select CampaignID,sum(NonDeservedPaidValue)  as NonDeservedPaidValue" +
                    " from (" + strNonDeservedPayment + ") as NonDeservedPaidTable group by CampaignID  ";

                #endregion
                #region Installment Value Region

                string strInstallmentValue = "";
                strInstallmentValue = strSelect + ",SUM(CRMReservationInstallment.InstallmentValue) AS TotalDeservedValue ";

                strInstallmentValue += ",SUM(case when dbo.CRMReservationInstallment.InstallmentDueDate  > " +
                    " CampaignTable.ReservationDeliveryDate or CampaignTable.DeliveredUnitCount>0 then 0 else CRMReservationInstallment.InstallmentValue end) AS PreDeliveryTotalDeservedValue ";
                //" or  dbo.CRMReservationInstallment.InstallmentDueDate  > CampaignTable.ReservationDeliveryDate or CampaignTable.DeliveredUnitCount>0 ";

                strInstallmentValue += strFrom;

                strInstallmentValue += strWhere;
                strInstallmentValue += strGroup;


                #endregion
                #region Discount Region
                string strDiscount = "";
                if (_PaymentDateStatus == 0)
                    strDiscount = strSelect + ",SUM(CASE WHEN CRMReservationInstallmentDiscount.DiscountValue IS NULL THEN 0 ELSE CRMReservationInstallmentDiscount.DiscountValue END)" +
                              " AS TotalDiscount ";
                else
                    strDiscount = strSelect + ",SUM(CASE WHEN CRMReservationInstallmentDiscount.DiscountValue is null " +
                        " or DiscountPaymentTable.InstallmentID IS NULL THEN 0 ELSE CRMReservationInstallmentDiscount.DiscountValue END)" +
                         " AS TotalDiscount ";

                ////////////////////////////////////////////////////////////////////////////////
                if (_PaymentDateStatus == 0)
                    strDiscount += ",SUM(CASE WHEN CRMReservationInstallmentDiscount.DiscountValue IS NULL "+
                        " or  dbo.CRMReservationInstallment.InstallmentDueDate  > CampaignTable.ReservationDeliveryDate or CampaignTable.DeliveredUnitCount>0 " +
                        " THEN 0 ELSE CRMReservationInstallmentDiscount.DiscountValue END)" +
                              " AS PreDeliveryTotalDiscount ";
                else
                    strDiscount += ",SUM(CASE WHEN CRMReservationInstallmentDiscount.DiscountValue is null " +
                        " or  dbo.CRMReservationInstallment.InstallmentDueDate  > CampaignTable.ReservationDeliveryDate or CampaignTable.DeliveredUnitCount>0 " +
                        " or DiscountPaymentTable.InstallmentID IS NULL THEN 0 ELSE CRMReservationInstallmentDiscount.DiscountValue END)" +
                         " AS PreDeliveryTotalDiscount ";
                ///////////////////////////////////////////////////////////////////////////////

                strDiscount += strFrom + " left outer join CRMReservationInstallmentDiscount on " +
                    " CRMReservationInstallmentDiscount.InstallmentID =CRMReservationInstallment.InstallmentID ";
                if (_PaymentDateStatus != 0)
                {
                    string strDiscountPayment = "SELECT  dbo.CRMInstallmentPayment.InstallmentID " +
                           " FROM         dbo.GLCheck RIGHT OUTER JOIN " +
                           " dbo.GLCheckPayment ON dbo.GLCheck.CheckID = dbo.GLCheckPayment.CheckID RIGHT OUTER JOIN " +
                           " dbo.CRMInstallmentPayment INNER JOIN " +
                           " dbo.GLPayment ON dbo.CRMInstallmentPayment.PaymentID = dbo.GLPayment.PaymentID ON  " +
                           " dbo.GLCheckPayment.PaymentID = dbo.GLPayment.PaymentID ";
                    strDiscountPayment += " where (GLCheckPayment.CheckID is null and GLPayment.PaymentDate>=" + dblStartPayment + " and GLPayment.PaymentDate <" +
                        dblEndPayment + ") or (dbo.GLCheck.CheckCurrentStatus=2 and  dbo.GLCheck.CheckCurrentStatusDate>=" + dblStartPayment +
                        " and  dbo.GLCheck.CheckCurrentStatusDate<" + dblEndPayment + " ) " +
                        " or ( dbo.GLCheckPayment.PaymentIsCollected=1 and dbo.GLCheckPayment.PaymentCollectingDate>=" + dblStartPayment + " and dbo.GLCheckPayment.PaymentCollectingDate <" + dblEndPayment + ") ";
                    strDiscount += " left outer join (" + strDiscountPayment + ") as DiscountPaymentTable on CRMReservationInstallmentDiscount.InstallmentID = DiscountPaymentTable.InstallmentID  ";
                }
                strDiscount += strStatusWhere;
                strDiscount += strGroup;
                #endregion
                string strPaymentJoinType = " left outer join ";
                if (intStatus == 2)
                    strPaymentJoinType = " inner join ";
                Returned = "select InstallmentTable.CampaignID,0 as TotalDiscount,InstallmentTable.TotalDeservedValue," +
                    "InstallmentPaymentTable.DeservedCheckValue,InstallmentPaymentTable.NonDeservedCheckValue," +
                    "InstallmentPaymentTable.CurrentTotalPaidValue,InstallmentPaymentTable.TotalPaidValue" +
                    ",InstallmentTable.PreDeliveryTotalDeservedValue,InstallmentPaymentTable.PreDeliveryTotalPaidValue" +
                    ",convert(int,InstallmentTable.Y) as Y," +
                    "convert(int,InstallmentTable.M) as M,InstallmentTable.DateStr,InstallmentTable.CampaignID as InstallmentCampaign " +
                    ",case when NonDeservedTable.NonDeservedPaidValue is null then 0 else NonDeservedTable.NonDeservedPaidValue end " +
                    " as NonDeservedPaidValue ";
                if (_InstallmentType == 0)
                    Returned += ",InstallmentTable.InstallmentTypeNameA ";
                else
                    Returned += ", '' as InstallmentTypeNameA ";
                if (_CellfamilyID == 0)
                    Returned += ",InstallmentTable.CellAlterName,InstallmentTable.CellFamilyID ";
                Returned += " from (" + strInstallmentValue + ") as InstallmentTable " + strPaymentJoinType + " (" +
                    strInstallmentPayment + ") as InstallmentPaymentTable " +
                    " on InstallmentTable.CampaignID = InstallmentPaymentTable.CampaignID " +
                    " left outer join (" + strNonDeservedPayment + ") as NonDeservedTable on " +
                    " InstallmentTable.CampaignID = NonDeservedTable.CampaignID  ";
                if (_CellfamilyID == 0)
                    Returned += " and InstallmentTable.CellfamilyID = InstallmentPaymentTable.CellFamilyID ";
                if (_InstallmentType == 0)
                    Returned += " and InstallmentTable.InstallmentTypeNameA = InstallmentPaymentTable.InstallmentTypeNameA ";

                return Returned;


            }
        }

        #endregion
        #endregion

        #region Private Methods
        void SetData(DataRow objDR)
        {
            if (objDR.Table.Columns["DateStr"] != null)
            {
                _DateStr = objDR["DateStr"].ToString();
            }
            if (objDR["TotalDeservedValue"].ToString() != "")
                _DeservedValue = double.Parse(objDR["TotalDeservedValue"].ToString());
            if (objDR["TotalDiscount"].ToString() != "")
                _DiscountValue = double.Parse(objDR["TotalDiscount"].ToString());
            if (objDR["TotalPaidValue"].ToString() != "")
                _WholeTotalPaidValue = double.Parse(objDR["TotalPaidValue"].ToString());
            if (objDR["CurrentTotalPaidValue"].ToString() != "")
                _TotalPaidValue = double.Parse(objDR["CurrentTotalPaidValue"].ToString());

            if (objDR["NonDeservedCheckValue"].ToString() != "")
                _NonDeservedCheckValue = double.Parse(objDR["NonDeservedCheckValue"].ToString());
            if (objDR["DeservedCheckValue"].ToString() != "")
                _DeservedCheckValue = double.Parse(objDR["DeservedCheckValue"].ToString());
            if (objDR.Table.Columns["CellFamilyID"] != null)
            {
                try
                {
                    if (objDR["CellFamilyID"].ToString() != null)
                        _CellfamilyID = int.Parse(objDR["CellFamilyID"].ToString());
                    if (objDR["CellAlterName"].ToString() != null)
                        _CellAlterName = objDR["CellAlterName"].ToString();
                }
                catch
                {
                }
            }
            if (objDR.Table.Columns["InstallmentTypeNameA"] != null)
            {
                _InstallmentTypeNameA = objDR["InstallmentTypeNameA"].ToString();
            }
            else
                _InstallmentTypeNameA = "";
            if (objDR.Table.Columns["InstallmentCampaign"] != null)
            {
                _Campaign = int.Parse(objDR["InstallmentCampaign"].ToString());


            }
            if (objDR.Table.Columns["NonDeservedPaidValue"] != null)
            {
                _CampaignNonDeservedPaid = double.Parse(objDR["NonDeservedPaidValue"].ToString());
            }
            if (objDR.Table.Columns["PreDeliveryTotalPaidValue"] != null)
            {
                _PreDeliveryWholeTotalPaidValue = double.Parse(objDR["PreDeliveryTotalPaidValue"].ToString());
 
            }
            if (objDR.Table.Columns["PreDeliveryTotalDeservedValue"] != null)
            {
                _PreDeliveryDeservedValue = double.Parse(objDR["PreDeliveryTotalDeservedValue"].ToString());
            }
        }
        #endregion

        #region Public Methods
        public virtual DataTable Search()
        {
            //_includeTempPayment  0 both 
            //1 only Installment
            //2 Only Temp Payment
            if (_intStatus == 1)
            {
                _IncludeTempPayment = 1;
                //_PaymentDateStatus = 0;
            }
            //if (_intStatus != 2)
            //    _PaymentDateStatus = 0;
            string strSql ="";// SearchStr;
            if (_IncludeTempPayment == 0 || _IncludeTempPayment == 1)
            {
                strSql = SearchStr;

            }

            if (_IncludeTempPayment == 0 || _IncludeTempPayment == 2)
            {
                if (strSql != "")
                    strSql += " union ";
                strSql += TempPaymentSearchStr;



            }

            #region Sum Installment Payment with Temp Payment
            //if (_IncludeTempPayment == 0 && !_TypeGrouping)
            //{
               string strTempSql ="select sum(TotalDiscount) as TotalDiscount,sum(TotalDeservedValue) as TotalDeservedValue," +
                       "sum(DeservedCheckValue) as DeservedCheckValue,sum(NonDeservedCheckValue) as NonDeservedCheckValue,"+
                       "sum(CurrentTotalPaidValue) as CurrentTotalPaidValue,sum(TotalPaidValue) as TotalPaidValue,convert(int,Y) as Y," +
                       "convert(int,M) as M,DateStr  "+
                       " ,'' InstallmentTypeNameA,";
                if(_CellfamilyID != 0 ||(_CellIDs != null && _CellIDs!="") || !_IsProjectGrouping)
                    strTempSql+=" '' as CellAlterName,0 as CellFamilyID ";
                else
                    strTempSql+= " CellAlterName,CellFamilyID";

                strTempSql+=" from (" + strSql + ") as NativeTable" +
                     " group by Y,M,DateStr  ";
                if (_CellfamilyID == 0 && (_CellIDs == null || _CellIDs == "")&&_IsProjectGrouping)
                    strTempSql += ",CellAlterName,CellFamilyID";
                strSql = strTempSql;

            //}  
            #endregion
            DataTable Returned = SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
            return Returned;
        }
        public virtual DataTable CampaignSearch()
        {
           
           
          
              string  strSql = CampaignSearchStr; //SearchStr;

           

            #region Sum Installment Payment with Temp Payment
            //if (_IncludeTempPayment == 0 && !_TypeGrouping)
            //{
              string strTempSql = "select  InstallmentCampaign,sum(TotalDiscount) as TotalDiscount,sum(TotalDeservedValue) as TotalDeservedValue," +
                      "sum(DeservedCheckValue) as DeservedCheckValue,sum(NonDeservedCheckValue) as NonDeservedCheckValue," +
                      "sum(CurrentTotalPaidValue) as CurrentTotalPaidValue,sum(TotalPaidValue) as TotalPaidValue"+
                      ",sum(PreDeliveryTotalPaidValue) as PreDeliveryTotalPaidValue,sum(PreDeliveryTotalDeservedValue) as PreDeliveryTotalDeservedValue,convert(int,Y) as Y," +
                      "convert(int,M) as M,DateStr  " +
                      ",sum(NonDeservedPaidValue) as NonDeservedPaidValue,'' InstallmentTypeNameA,";
              if (_CellfamilyID != 0 || (_CellIDs != null && _CellIDs != ""))
                  strTempSql += " '' as CellAlterName,0 as CellFamilyID ";
              else
                  strTempSql += " '' as  CellAlterName,0 as CellFamilyID";

              strTempSql += " from (" + strSql + ") as NativeTable" +
                   " group by InstallmentCampaign,Y,M,DateStr  ";
              if (_CellfamilyID == 0 && (_CellIDs == null || _CellIDs == ""))
                  strTempSql += ",'' as CellAlterName,0 as CellFamilyID";
             // strSql = strTempSql;

            //}
                //strSql = "select NativeTable.*,CampaignTable.* " +
                //    " from (" + strSql + ") as NativeTable inner join (" + CampaignDb.SearchStr +
                //    ") as CampaignTable on NativeTable.InstallmentCampaign = CampaignTable.CampaignID ";
            #endregion
            DataTable Returned = SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
            return Returned;
        }
        #endregion
    }
}
