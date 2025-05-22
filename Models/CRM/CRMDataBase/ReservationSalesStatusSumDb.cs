
using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.UMS.UMSDataBase;
using SharpVision.SystemBase;
using System.Data;
using System.Data.SqlClient;
using SharpVision.Base.BaseDataBase;
using SharpVision.COMMON.COMMONDataBase;
using SharpVision.RP.RPDataBase;

namespace SharpVision.CRM.CRMDataBase
{
    public class ReservationSalesStatusSumDb
    {
#region Private Data

        protected string _WorkerName;
        protected double _ContractingCount;
        protected double _DeservedCount;
        protected double _CompletedCount;
        protected double _CancellationCount;
        protected double _CessionCount;
        protected double _TotalValue;
        protected double _TotalContractingValue;
        protected double _TotalCancelationValue;
        protected double _CanceledValue;
        protected double _ContractedValue;
        protected double _JustReservedValue;
        protected double _CanceledWithoutContractingValue;
        
       #region Private Data For Search
        protected int _CellID;
        protected int _ApplicantID;
        protected int _BranchID;
        protected int _SalesManID;
        protected DateTime _ReservationStartDate;
        
        protected DateTime _ReservationEndDate;
        protected bool _IsDateRange;
        protected bool _IsContractingDateRange;
        protected DateTime _ContractingStartDate;
        protected DateTime _ContractingEndDate;

        bool _StatusDateRange;
        DateTime _StatusStartDate;
        DateTime _StatusEndDate;
        #endregion
        #endregion

        #region Constractors
        public ReservationSalesStatusSumDb()
        {
            
        }
        public ReservationSalesStatusSumDb(DataRow objDR)
        {
            SetData(objDR);
        }
        #endregion

        #region Public Accessorice
        public string WorkerName
        {
            set
            {
                _WorkerName = value;
            }
            get
            {
                return _WorkerName;
            }
        }
        public double ContractingCount
        {
            set
            {
                _ContractingCount = value;
            }
            get
            {
                return _ContractingCount;
            }
        }
        public double DeservedCount
        {
            set
            {
                _DeservedCount = value;
            }
            get
            {
                return _DeservedCount;
            }
        }
        public double CompletedCount
        {
            set
            {
                _CompletedCount = value;
            }
            get
            {
                return _CompletedCount;
            }
        }
        public double CancellationCount
        {
            set
            {
                _CancellationCount = value;
            }
            get
            {
                return _CancellationCount;
            }
        }
        public double CessionCount
        {
            set
            {
                _CessionCount = value;
            }
            get
            {
                return _CessionCount;
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

        public double CanceledValue
        {
            set
            {
                _CanceledValue = value;
            }
            get
            {
                return _CanceledValue;
            }
        }
        public double ContractedValue
        {
            set
            {
                _ContractedValue = value;
            }
            get
            {
                return _ContractedValue;
            }
        }
        public double JustReservedValue
        {
            set
            {
                _JustReservedValue = value;
            }
            get
            {
                return _JustReservedValue;
            }
        }
       public double CanceledWithoutContractingValue
        {
            set
            {
                _CanceledWithoutContractingValue = value;
            }
            get
            {
                return _CanceledWithoutContractingValue;
            }
        }



        #region Private Data For Search
        
        public int CellID
        {
            set
            {
                _CellID = value;
            }
            get
            {
                return _CellID;
            }
        }
        public int WorkerID
        {
            set
            {
                _ApplicantID = value;
            }
            get
            {
                return  _ApplicantID;
            }
        }
        public int BranchID
        {
            set
            {
                _BranchID = value;
            }
            get
            {
                return _BranchID;
            }
        }
        public DateTime DateFrom
        {
            set
            {
                _ReservationStartDate = value;
            }
           
        }
        public DateTime DateTo
        {
            set
            {
                _ReservationEndDate = value;
            }
          
        }
        public bool IsDateRange
        {
            set
            {
                _IsDateRange = value;
            }
      
        }
        public bool IsContractingDateRange
        {
            set
            {
                _IsContractingDateRange = value;
            }
        }
        public DateTime ContractingDateFrom
        {
            set
            {
                _ContractingStartDate = value;
            }
            
        }
        public DateTime ContractingDateTo
        {
            set
            {
                _ContractingEndDate = value;
            }
           
        }
        public bool StatusDateRange
        {
            set
            {
                _StatusDateRange = value;
            }
        }
        public DateTime StatusStartDate
        {
            set
            {
                _StatusStartDate = value;
            }
        }
        public DateTime StatusEndDate
        {
            set
            {
                _StatusEndDate = value;
            }
        }
        public int SalesManID
        {
            set
            {
                _SalesManID = value;
            }
            get
            {
                return _SalesManID;
            }
        }

    
        public string SearchStr
        {
            get
            {
                #region Cell+TempPayment +Installment+InstallmentDiscount
                string strCellQuery = "SELECT     dbo.CRMReservation.ReservationID " +
                     " FROM         dbo.CRMUnit INNER JOIN " +
                      " dbo.CRMUnitCell ON dbo.CRMUnit.UnitID = dbo.CRMUnitCell.UnitID INNER JOIN " +
                      " dbo.CRMReservationUnit ON dbo.CRMUnit.UnitID = dbo.CRMReservationUnit.UnitID INNER JOIN " +
                      " dbo.CRMReservation ON dbo.CRMReservationUnit.ReservationID = dbo.CRMReservation.ReservationID INNER JOIN " +
                      " dbo.RPCell ON dbo.CRMUnitCell.CellID = dbo.RPCell.CellID where 1=1  ";
               


                string strInstallment = "SELECT CRMReservation.ReservationID, SUM(CASE WHEN CRMReservationInstallment.InstallmentValue IS NULL " +
                      " THEN 0 ELSE CRMReservationInstallment.InstallmentValue END) AS TotalInstallmentValue " +
                      " FROM         CRMReservation LEFT OUTER JOIN " +
                      " CRMReservationInstallment ON CRMReservation.ReservationID = CRMReservationInstallment.ReservationID " +
                       " GROUP BY CRMReservation.ReservationID ";
                string strTempPayment = "SELECT     CRMReservation.ReservationID, CASE WHEN TempPaymentTable.TotalPaymentValue IS NULL " +
                      " THEN 0 ELSE TempPaymentTable.TotalPaymentValue END AS TempPaymentValue " +
                      " FROM         CRMReservation LEFT OUTER JOIN " +
                      " (SELECT     CRMTempReservationPayment.ReservationID, SUM(GLPayment.PaymentValue) AS TotalPaymentValue " +
                      " FROM         CRMTempReservationPayment INNER JOIN " +
                      " GLPayment ON CRMTempReservationPayment.PaymentID = GLPayment.PaymentID " +
                      " GROUP BY CRMTempReservationPayment.ReservationID) TempPaymentTable ON  " +
                     " TempPaymentTable.ReservationID = CRMReservation.ReservationID";
                string strInstallmentDiscount = "SELECT     dbo.CRMReservation.ReservationID, SUM(CASE WHEN dbo.CRMReservationInstallmentDiscount.DiscountValue IS NULL " +
                       " THEN 0 ELSE dbo.CRMReservationInstallmentDiscount.DiscountValue END) AS TotalDiscount " +
                      " FROM         dbo.CRMReservationInstallmentDiscount RIGHT OUTER JOIN " +
                      " dbo.CRMReservationInstallment ON  " +
                      " dbo.CRMReservationInstallmentDiscount.InstallmentID = dbo.CRMReservationInstallment.InstallmentID RIGHT OUTER JOIN " +
                      " dbo.CRMReservation ON dbo.CRMReservationInstallment.ReservationID = dbo.CRMReservation.ReservationID " +
                      " GROUP BY dbo.CRMReservation.ReservationID ";
                #endregion
                #region Reservation
                string strReservationStatus = "CRMReservation.ReservationStatus";
                double dblStatusStartDate = SysUtility.Approximate(_StatusStartDate.ToOADate() - 2, 1, ApproximateType.Down);
                double dblStatusEndDate = SysUtility.Approximate(_StatusEndDate.ToOADate() - 2, 1, ApproximateType.Up);
                if (_StatusDateRange)
                {
                   

                   
                    strReservationStatus = " case when CanceledReservation is not null and CancelationDate >="+
                        dblStatusStartDate + " and CancelationDate<" + dblStatusEndDate + " then 6 when ReservationContractingDate is not null"+
                        " and ReservationContractingDate>=  " + dblStatusStartDate + " and ReservationContractingDate <" + dblStatusEndDate + " then 3 "+
                        " else 2 end as  ReservationStatus ";


                }



                #region Status
                //canceled
                string strReservationStatus1 = "";
                 strReservationStatus1 = "case when CanceledReservation is not null and ReservationContractingDate is not null "+
                     " and convert(float,ReservationContractingDate)<>0  ";
                 if (_StatusDateRange)
                     strReservationStatus1 += " and CancelationDate>="+ dblStatusStartDate + " and CancelationDate <" +
                         dblStatusEndDate ;
                 strReservationStatus1 += " then 1 else 0 end as IsCanceled ";
               //contracted
              
                 strReservationStatus1 += ",case when  ReservationContractingDate is not null " +
                     " and convert(float,ReservationContractingDate)<>0  ";
                 if (_StatusDateRange)
                     strReservationStatus1 += " and ReservationContractingDate>=" + dblStatusStartDate + " and ReservationContractingDate <" +
                         dblStatusEndDate;
                 strReservationStatus1 += " then 1 else 0 end as IsContracted ";

                 //JustReserved

                 strReservationStatus1 += ",case when  ReservationContractingDate is null " +
                     " or convert(float,ReservationContractingDate)=0  ";
                 if (_StatusDateRange)
                     strReservationStatus1 += " and ReservationDate>=" + dblStatusStartDate + " and ReservationDate <" +
                         dblStatusEndDate;
                 strReservationStatus1 += " then 1 else 0 end as IsJustReserved ";

                 //CanceledWithoutContracting

                 strReservationStatus1 += ",case when  CanceledReservation is not null and (ReservationContractingDate is null " +
                     " or convert(float,ReservationContractingDate)=0)  ";
                 if (_StatusDateRange)
                     strReservationStatus1 += " and CancelationDate>=" + dblStatusStartDate + " and CancelationDate <" +
                         dblStatusEndDate;
                 strReservationStatus1 += " then 1 else 0 end as IsCancelledWithoutContracting ";
                #endregion



                string strReservation = "select " + strReservationStatus + ",CRMReservation.ReservationDate,CRMReservation.ReservationContractingDate,InstallmentTable.ReservationID,InstallmentTable.TotalInstallmentValue+" +
                    " TempPaymentTable.TempPaymentValue - DiscountTable.TotalDiscount as ReservationValue ," + strReservationStatus1 + 
                    ",ReservationBranch,CancelationTable.* " +
                    " from (" + strInstallment + ") as InstallmentTable inner join (" + strInstallmentDiscount +
                    ") as DiscountTable on DiscountTable.ReservationID = InstallmentTable.ReservationID " +
                    " inner join ( " + strTempPayment + ") as TempPaymentTable on  InstallmentTable.ReservationID = TempPaymentTable.ReservationID " +
                    " inner join CRMReservation on InstallmentTable.ReservationID = CRMReservation.ReservationID " +
                    " left outer join (" + ReservationCancelationDb.SearchStr + ") as CancelationTable " +
                    " on CRMReservation.ReservationID = CancelationTable.CanceledReservation ";
                #endregion

                string strContribution = "SELECT  dbo.CRMReservation.ReservationID, CASE WHEN COUNT(distinct HRApplicant.ApplicantID) " +
                       " > 0 THEN COUNT(distinct HRApplicant.ApplicantID) ELSE 1 END AS WorkerCount " +
                       " FROM         dbo.CRMReservation LEFT OUTER JOIN " +
                       " dbo.CRMReservationWorkerContribution ON dbo.CRMReservation.ReservationID = dbo.CRMReservationWorkerContribution.ReservationID " +
                       " left outer join  dbo.HRApplicant ON dbo.CRMReservationWorkerContribution.WorkerID = dbo.HRApplicant.ApplicantID " +
                       " GROUP BY dbo.CRMReservation.ReservationID ";

                string Returned = " SELECT   sum(1),  dbo.HRApplicant.ApplicantFirstName, SUM(CASE WHEN ReservationStatus = 3 THEN 1/convert(float,WorkerTable.WorkerCount) ELSE 0 END) AS ContractingCount, " +
                                  " SUM(CASE WHEN ReservationStatus = 2 THEN 1/convert(float,WorkerTable.WorkerCount) ELSE 0 END) AS DeservedCount, SUM(CASE WHEN ReservationStatus = 4 THEN 1/convert(float,WorkerTable.WorkerCount) ELSE 0 END) AS CompletedCount, " +
                                  " SUM(CASE WHEN ReservationStatus = 6 THEN 1/convert(float,WorkerTable.WorkerCount) ELSE 0 END) AS CancellationCount, SUM(CASE WHEN ReservationStatus = 5 THEN 1/convert(float,WorkerTable.WorkerCount) ELSE 0 END) AS CessionCount, " +
                                  " SUM(CASE WHEN (ReservationStatus = 5 or ReservationStatus = 6) THEN 0 ELSE ReservationValue/convert(float,WorkerTable.WorkerCount) END) AS TotalValue" +
                                  ",sum(case when IsCanceled=1 then  ReservationValue/convert(float,WorkerTable.WorkerCount) else 0 end) as CanceledValue  " +
                                  ",sum(case when IsContracted=1 then  ReservationValue/convert(float,WorkerTable.WorkerCount) else 0 end) as ContractedValue  " +
                                  ",sum(case when IsJustReserved=1 then  ReservationValue/convert(float,WorkerTable.WorkerCount) else 0 end) as JustReservedValue  " +
                                  ",sum(case when IsCancelledWithoutContracting=1 then  ReservationValue/convert(float,WorkerTable.WorkerCount) else 0 end) as CanceledWithoutContractingValue  " +
                                  " FROM  " +
                                  " (" + strReservation + ") ReservationTable left outer JOIN" +
                                  " dbo.CRMReservationWorkerContribution ON ReservationTable.ReservationID = dbo.CRMReservationWorkerContribution.ReservationID left outer JOIN" +
                                  " dbo.HRApplicant ON dbo.CRMReservationWorkerContribution.WorkerID = dbo.HRApplicant.ApplicantID " +
                                  " inner join (" + strContribution + ") as WorkerTable on ReservationTable.ReservationID = WorkerTable.ReservationID  " +
                                  "where 1 = 1";
                if (_CellID != 0)
                {
                    strCellQuery += " And (dbo.RPCell.CellFamilyID = " + _CellID + ") ";
                    Returned += " and ReservationTable.ReservationID in (" + strCellQuery + ")";

                }
                if (_BranchID != 0)
                {
                    Returned += " and (ReservationTable.ReservationBranch = " + _BranchID + ")";
                }
                if (_ApplicantID != 0)
                {
                    Returned += " and (dbo.HRApplicant.ApplicantID = " + _ApplicantID + ")";
                }
              
                if (_IsDateRange || _IsContractingDateRange)
                {
                    string strSearchDate = "";
                    if (_IsDateRange)
                    {
                        double dblStart = _ReservationStartDate.ToOADate() - 2;
                        dblStart = SysUtility.Approximate(dblStart, 1, ApproximateType.Down);
                        double dblEnd = _ReservationEndDate.ToOADate() - 2;

                        dblEnd = SysUtility.Approximate(dblEnd, 1, ApproximateType.Up);



                        strSearchDate = "  (ReservationDate >= " + dblStart + " and ReservationDate <" + dblEnd + ") ";

                    }
                    if (_IsContractingDateRange)
                    {

                        double dblStart = _ContractingStartDate.ToOADate() - 2;
                        dblStart = SysUtility.Approximate(dblStart, 1, ApproximateType.Down);
                        double dblEnd = _ContractingEndDate.ToOADate() - 2;
                        dblEnd = SysUtility.Approximate(dblEnd, 1, ApproximateType.Up);
                        if (strSearchDate != "")
                            strSearchDate += " or ";
                        strSearchDate += "(ReservationContractingDate >=" + dblStart +
                            " and ReservationContractingDate < " + dblEnd + ") ";

                    }
                    if (strSearchDate != "")
                        Returned += " and ( " + strSearchDate + ")";
                }
                if (_StatusDateRange)
                {
                    //double dblStatusStartDate = SysUtility.Approximate(_StatusStartDate.ToOADate() - 2, 1, ApproximateType.Down);
                    //double dblStatusEndDate = SysUtility.Approximate(_StatusEndDate.ToOADate() - 2, 1, ApproximateType.Up);
                    #region StatusDate Range
                    if (_StatusDateRange)
                    {
                     
                        string strStatusWhere = "(ReservationStatus=6 and  CanceledReservation is not null and  CancelationDate>= " +
                            dblStatusStartDate + " and CancelationDate<" + dblStatusEndDate + ") or " +
                           " ((ReservationStatus = 4 or ReservationStatus = 3) and  ReservationContractingDate>= " +
                           dblStatusStartDate + " and ReservationContractingDate<" + dblStatusEndDate + ") or " +
                           "((ReservationStatus = 1 or ReservationStatus = 2) and   ReservationDate>= " + dblStatusStartDate +
                           " and ReservationDate < " + dblStatusEndDate + ")";
                        Returned += " and (" + strStatusWhere + ")";
                    }
                    #endregion
                }


                Returned += " GROUP BY dbo.HRApplicant.ApplicantFirstName " +
                    " ORDER BY dbo.HRApplicant.ApplicantFirstName ";
                return Returned;
            }
        }

        #endregion
        #endregion

        #region Private Methods
        void SetData(DataRow objDR)
        {
            _WorkerName = objDR["ApplicantFirstName"].ToString();
            _DeservedCount = double.Parse(objDR["DeservedCount"].ToString());
            _ContractingCount = double.Parse(objDR["ContractingCount"].ToString());
            _CompletedCount = double.Parse(objDR["CompletedCount"].ToString());
            _CancellationCount = double.Parse(objDR["CancellationCount"].ToString());
            _CessionCount = double.Parse(objDR["CessionCount"].ToString());
            _TotalValue = double.Parse(objDR["TotalValue"].ToString());
            _CanceledValue = double.Parse(objDR["CanceledValue"].ToString());
            _ContractedValue = double.Parse(objDR["ContractedValue"].ToString());
            _JustReservedValue = double.Parse(objDR["JustReservedValue"].ToString());
            _CanceledWithoutContractingValue = double.Parse(objDR["CanceledWithoutContractingValue"].ToString());
        }
        #endregion

        #region Public Methods
         public DataTable Search()
        {
            return SysData.SharpVisionBaseDb.ReturnDatatable(SearchStr);
        }
        #endregion
    }
}

