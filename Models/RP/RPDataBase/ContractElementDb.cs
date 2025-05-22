using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.SystemBase;
using System.Data;
using System.Data.SqlClient;
using SharpVision.COMMON.COMMONDataBase;

namespace SharpVision.RP.RPDataBase
{
    public class ContractElementDb
    {
        #region Private Data
        protected int _ID;
        protected int _ContractID;
        protected int _UnitID;
        protected double _UnitPrice;
        protected double _MaxUnitPrice;
        protected double _TotalAcheivedAmount;
        protected DateTime _EndDate;
        protected DateTime _EstimationDate;
        protected DateTime _StartDate;
        protected DateTime _AssignDate;
        protected string _ContractElementDesc;
        protected int _ElementType;
        protected double _EvaluatedValue;
        protected int _CategoryType;
        protected double _Percent;
        protected int _Order;
        protected bool _Stoped;
        protected string _ElementIDs;
        protected int _ProcessType;
        protected string _ProcessTypeIDs;
       // protected string _InvoiceStatementIDs;
        protected string _TypeName;
       protected int _Cell;
        protected string _CellDesc;
        protected DateTime _ContractStartDate;
        protected int _ContractCellID;
        protected string _ContractCellDesc;
        protected string _ContractorFullName;
        protected int _ContractProcessTypeID;
        protected string _ContractProcessTypeName;
        protected double _RefrenceValue;
        protected bool _HasInvoiceElement;
        protected int _LastInvoiceElement;
        protected int _InvoiceElementCount;
        protected int _InvoiceElementFinacedCount;
        protected int _RefrenceValueUser;
        protected int _RefrenceValueEngineer;
        protected string _RefrenceValueEngineerName;
        protected DateTime _RefrenceValueDate;
        protected string _RefrenceValueComment;
        static string _ContractIDs;
        protected int _ContractElementType;
        protected double _OldUnitPrice;
        protected double _OldPercent;
        protected double _OldAcheivedAmount;
        static DataTable _ElementTable;
        static DataTable _ContractTable;
        static DataTable _SrcElementTable;


        protected int _MaxID;
        protected int _MinID;
        protected int _ResultCount;
        protected double _ResultValue;
        protected double _DiscountResultValue;
        protected double _TaxPercent;
        protected double _InsurancePercent;
        #region Private Data For search
        protected int _ContractorID;
        protected string _ContractorIDs;
        protected double _FromUnitPrice;
        protected double _ToUnitPrice;
        protected string _CellIDs;
        protected int _CellFamilyID;
        protected string _CellFamilyIDs;
        protected int _DiscountType;
        
       // protected int _ElementType;
        protected bool _IsPeriodRange;/*
                                     * presents the period to comute
                                     */
        int _InvoiceType;
        int _InvoiceStatement;
        string _InvoiceStatementIDs;
        DateTime _PeriodStartDate;
        DateTime _PeriodEndDate;
        bool _IsDateLimited;
        DateTime _LimitDate;
        int _RefrenceValueStatus;/*
                                  * 0 dont Care
                                  * 1 only has Refrence
                                  * 2 only dont have
                                  */
        int _OverAcheivedProcessStatus; /*
                                         * 0 dont care
                                         * 1 OverAcheived
                                         */
        int _StoppedElementStatus;
        int _NewElementStatus;
        bool _IncludeDisabled;
        int _InvoiceStage;
        DataTable _ContractElementTable;
        int _ElementDiscountID;
        int _ElementDiscountEmployee;
        int _ElementProcessID;
        string _IDs;
        double _StartPerc;
        double _EndPerc;
        #endregion
        #region Protected Property
        public string ContractElementSearchStr
        {
            get
            {
                string Returned = SearchStr + " where 1=1 ";
                if (!_IncludeDisabled)
                    Returned += " and  ContractTable.ContractDis is null and RPContractElement.Dis is null  ";
                if(_ElementIDs != null && _ElementIDs != "")
                    Returned += " and RPContractElement.ContractElementID in (" + _ElementIDs + ")";
                if (_ContractID != 0)
                    Returned = Returned + " and RPContractElement.ContractID =" + _ContractID;
                if (_CellIDs != null && _CellIDs != "")
                    Returned = Returned + " and RPContractElement.ContractElementCell in" +
                     " (" + _CellIDs + ")";
                if (_CellFamilyID != 0)
                {
                    //Returned = Returned + " and RPContractElement.ContractElementCell in" +
                    // " (select CellID " +
                    // " from RPCell where CellFamilyID=" + _CellFamilyID + ")";
                    Returned += " and CellTable.CellFamilyID =" + _CellFamilyID;
                 
                }
                if(_CellFamilyIDs != null && _CellFamilyIDs != "")
                    Returned += " and CellTable.CellFamilyID in (" + _CellFamilyIDs + ") ";
                if (_ElementType != 0)
                {

                    if (_ElementType == 2)
                        Returned += " and ContractElementProcessID is not null and ContractElementProcessID <> 0 ";
                    else if (_ElementType == 4)
                        Returned += " and ContractElementCategoryID is not null and ContractElementCategoryID <> 0  ";
                    else if (_ElementType == 5)
                        Returned += " and SrcContractElementID is not null and SrcContractElementID <>0 " +
                            " and SrcContractElementID= SrcContractElementFamilyID ";
                    else if (_ElementType == 3)
                        Returned += " and SrcContractElementID is not null and SrcContractElementID <>0 " +
                           " and SrcContractElementID<> SrcContractElementFamilyID ";
                    else if (_ElementType == 6)
                        Returned += " and ContractElementDiscountID is not null and ContractElementDiscountID<>0 ";
                    else
                        Returned += " and ContractElementDiscountID is  null and ContractElementProcessID is null  " +
                           " and ContractElementCategoryID is null  ";
                }
                if (_DiscountType != 0)
                    Returned += " and DiscountTypeID =" + _DiscountType;
                if (_ProcessType != 0)
                    Returned += " and RPContractElement.ContractElementType=" + _ProcessType;
                if (_ProcessTypeIDs != null&& _ProcessTypeIDs!= "")
                    Returned += " and RPContractElement.ContractElementType in (" + _ProcessTypeIDs + ")";
                if (_FromUnitPrice != 0 && _ToUnitPrice == 0)
                    Returned += " and RPContractElement.UnitPrice > " + _FromUnitPrice;
                else if(_ToUnitPrice != 0 && _FromUnitPrice == 0)
                    Returned += " and RPContractElement.UnitPrice < " + _ToUnitPrice;
                else if(_FromUnitPrice != 0 && _ToUnitPrice != 0)
                    Returned += " and RPContractElement.UnitPrice between " + _FromUnitPrice + " and " + _ToUnitPrice;
                if (_ContractorID != 0)
                    Returned += " and RPContractElement.ContractID in (Select ContractID from RPContract where ContractorID =" + _ContractorID + ")  ";
               
                if (_ContractorIDs != null && _ContractorIDs != "")
                    Returned += " and RPContractElement.ContractID in (Select ContractID from RPContract where ContractorID in (" + _ContractorIDs + "))  ";

              if(_ContractElementDesc != null && _ContractElementDesc!= "")
                  Returned+= " and dbo.ReplaceStringComp(ContractElementDesc) like '%"+ SysUtility.ReplaceStringComp(_ContractElementDesc) +"%' ";
              if (_RefrenceValueStatus != 0)
              {
                  if (_RefrenceValueStatus == 1)
                  {
                      Returned += " and  ("+
                          "(ContractElementProcessID is  null and RPContractElement.RefrenceValue <> 0 and RPContractElement.RefrenceValue is not null)"+
                          " or (ContractElementProcessID is not null and ContractProcessTable.ProcessAmount > 0 ) " +
                          ")";

                  }
                  else if(_RefrenceValueStatus == 2)
                      Returned += " and  (" +
                          "(ContractElementProcessID is  null and (RPContractElement.RefrenceValue is null or RPContractElement.RefrenceValue = 0  ))" +
                          " or (ContractElementProcessID is not null and (ContractProcessTable.ProcessAmount  = 0 or ContractProcessTable.ProcessAmount  is  null)) " +
                          ")"; 

              }
              if (_StoppedElementStatus == 1)
                  Returned += " and RPContractElement.ContractElementStoped = 1 ";
              else if (_StoppedElementStatus == 2)
                  Returned += " and RPContractElement.ContractElementStoped = 0 ";
                return Returned;
            }
        }
        #endregion
        #endregion
        #region Constructors
        public ContractElementDb()
        {

        }
        public ContractElementDb(DataRow objDR)
        {
            SetData(objDR);
        }
        #endregion
        #region Public Properties
        public int UnitID
        {
            set
            {
                _UnitID = value;
            }
            get
            {
                return _UnitID;
            }
        }
        public double UnitPrice
        {
            set
            {
                _UnitPrice = value;
            }
            get
            {
                return _UnitPrice;
            }

        }
        public double MaxUnitPrice
        {
            get
            {
                return _MaxUnitPrice;
            }
        }
     
        public double TotalAcheivedAmount
        {
            set
            {
                _TotalAcheivedAmount = value;
            }
            get
            {
                return _TotalAcheivedAmount;
            }

        }
        public DateTime StartDate
        {
            set
            {
                _StartDate = value;
            }
            get
            {
                return _StartDate;
            }
        }
        public DateTime EstimationDate
        {
            set
            {
                _EstimationDate = value;
            }
            get
            {
                return _EstimationDate;
            }
        }
        public DateTime EndDate
        {
            set
            {
                _EndDate = value;
            }
            get
            {
                return _EndDate;
            }

        }
        public double EvaluatedValue
        {
            set
            {
                _EvaluatedValue = value;
            }

            get
            {
                return _EvaluatedValue;
            }
        }
        public int ContractID
        {
            set
            {
                _ContractID = value;
            }
            get
            {
                return _ContractID;
            }
        }
        public int ID
        {
            set
            {
                _ID = value;
            }
            get
            {
                return _ID;
            }
        }
        public int Cell
        {
            set
            {
                _Cell = value;
            }
            get
            {
                return _Cell;
            }
        }
        public string CellDesc
        {
            set
            {
                _CellDesc = value;
            }
            get
            {
                return _CellDesc;
            }
        }
        public string ContractElementDesc
        {
            set
            {
                _ContractElementDesc = value;
            }
            get
            {
                return _ContractElementDesc;
            }
        }
        public int ProcessType
        {
            set
            {
                _ProcessType = value;
            }
            get
            {
                return _ProcessType;
            }
        }
        public Double Percent
        {
            set
            {
                _Percent = value;
            }
            get
            {

                return _Percent;
            }
        }
        public DateTime AssignDate
        {
            set
            {
                _AssignDate = value;
            }
            get
            {
                return _AssignDate;
            }
        }
        public bool Stoped
        {
            set
            {
                _Stoped = value;
            }
            get
            {
                return _Stoped;
            }
        }
        public int Order
        {
            set
            {
                _Order = value;
            }
            get
            {
                return _Order;
            }
        }
        public double RefrenceValue
        {
            set
            {
                _RefrenceValue = value;
            }
            get
            {
                return _RefrenceValue;
            }
        }
        public int RefrenceValueUser
        {
            set
            {
                _RefrenceValueUser = value;
            }
            get
            {
                return _RefrenceValueUser;
            }
        }
        public int RefrenceValueEngineer
        {
            set
            {
                _RefrenceValueEngineer = value;
            }
            get
            {
                return _RefrenceValueEngineer;
            }
        }
        public string RefrenceValueEngineerName
        {
            set
            {
                _RefrenceValueEngineerName = value;
            }
            get
            {
                return _RefrenceValueEngineerName;
            }
        }
        public DateTime RefrenceValueDate
        {
            set 
            {
                _RefrenceValueDate = value;
            }
            get
            {
                return _RefrenceValueDate;
            }
        }
        public string RefrenceValueComment
        {
            set
            {
                _RefrenceValueComment = value;
            }
            get
            {
                return _RefrenceValueComment;
            }
        }
        public double TaxPercent
        {
            set
            {
                _TaxPercent = value;
            }
            get
            {
                return _TaxPercent;
            }
        }
        public double InsurancePercent
        {
            set
            {
                _InsurancePercent = value;
            }
            get
            {
                return _InsurancePercent;
            }
        }
        public string ElementIDs
        {
            set
            {
                _ElementIDs = value;
            }
        }
        public string ProcessTypeIDs
        {
            set
            {
                _ProcessTypeIDs = value;
            }
        }
        public string InvoiceStatementIDs
        {
            set
            {
                _InvoiceStatementIDs = value;
            }
        }
      
        public int ContractorID
        {
            set
            {
                _ContractorID = value;
            }
        }
        public string ContractorIDs
        {
            set
            {
                _ContractorIDs = value;
            }
        }
        public static string ContractIDs
        {
            set
            {
                _ContractIDs = value;
            }
        }
        public int ElementType
        {
            set
            {
                _ElementType = value;
            }
        }
        public int DiscountType
        {
            set
            {
                _DiscountType = value;
            }
        }
        public double FromUnitPrice
        {
            set
            {
                _FromUnitPrice = value;
            }
        }
        public double ToUnitPrice
        {
            set
            {
                _ToUnitPrice = value;
            }
        }
        public int CellfamilyID
        {
            set
            {
                _CellFamilyID = value;
            }
        }
        public string CellFamilyIDs
        {
            set 
            {
                _CellFamilyIDs = value;
            }
        }
        public string CellIDs
        {
            set
            {
                _CellIDs = value;
            }
        }
        public bool IsDateLimited
        {
            set
            {
                _IsDateLimited = value;
            }
        }
        public DateTime LimitDate
        {
            set
            {
                _LimitDate = value;
            }
        }
        public int RefrenceValueStatus
        {
            set
            {
                _RefrenceValueStatus = value;
            }
        }
        public int InvoiceType
        {
            set
            {
                _InvoiceType = value;
            }
        }
        public int InvoiceStatement
        {
            set
            {
                _InvoiceStatement = value;
            }
        }
        public int OverAcheivedProcessStatus
        {
            set
            {
                _OverAcheivedProcessStatus = value;
            }
        }
        public int StoppedElementStatus
        {
            set
            {
                _StoppedElementStatus = value;
            }
        }
        public int NewElementStatus
        {
            set
            {
                _NewElementStatus = value;
            }
        }
        public bool IncludeDisabled
        {
            set
            {
                _IncludeDisabled = value;
            }
        }
        public int InvoiceStage
        {
            set
            {
                _InvoiceStage = value;
            }
        }
        public string IDs
        {
            set
            {
                _IDs = value;
            }
        }
        public double OldUnitPrice
        {
            get
            {
                return _OldUnitPrice;
            }
        }
        public double OldPercent
        {
            get
            {
                return _OldPercent;
            }
        }
        public double OldAcheivedAmount
        {
            get
            {
                return _OldAcheivedAmount;
            }
        }

        public static DataTable ElementTable
        {
            set
            {
                _ElementTable = value;
            }
            get
            {
                if (_ElementTable == null && _ContractIDs != null && _ContractIDs != "")
                {
                    ContractElementDb objElementDb = new ContractElementDb();
                    string strSql = objElementDb.SearchStr + " where RPContractElement.Dis is null and ContractID in(" + _ContractIDs + ")";
                    string strDrivedSql = "SELECT DISTINCT dbo.RPContractElementDerived.SrcContractElementID "+
                           " FROM         dbo.RPContractElementDerived INNER JOIN "+
                           " dbo.RPContractElement ON dbo.RPContractElementDerived.ContractElementID = dbo.RPContractElement.ContractElementID "+
                           " WHERE     (dbo.RPContractElement.ContractID IN ("+ _ContractIDs +"))";
                    strDrivedSql = "select NativeTable.* from (" + objElementDb.SearchStr + ") as NativeTable " +
                        " inner join ("+ strDrivedSql +") as DrivedTable "+
                        " on NativeTable.ContractElementID = DrivedTable.SrcContractElementID ";
                    strSql += " union "+
                        strDrivedSql ;
                    _ElementTable = SysData.SharpVisionBaseDb.ReturnDatatable(strSql);

                }
                return _ElementTable;

            }
        }
        public static DataTable SrcElementTable
        {
            set
            {
                _SrcElementTable = value;
            }
            get
            {
                if (_SrcElementTable == null)
                {
                    _SrcElementTable = new DataTable();
                    _SrcElementTable.Columns.Add(new DataColumn("ContractElementID"));
                }
                return _SrcElementTable;
            }
        }
        public static DataTable ContractTable
        {
            set
            {
                _ContractTable = value;
            }
            get
            {
                if (_ContractTable == null)
                {
                    _ContractTable = new DataTable();
                    _ContractTable.Columns.Add(new DataColumn("ContractID"));
                }
                return _ContractTable;
            }
        }
        public double StartPerc
        {
            set
            {
                _StartPerc = value;
            }
        }
        public double EndPerc
        {
            set
            {
                _EndPerc = value;
            }
        }
        public DataTable ContractElementTable
        {
            set
            {
                _ContractElementTable = value;
            }
        }

        public int MaxID
        {
            set
            {
                _MaxID = value;
            }
        }
        public int MinID
        {
            set
            {
                _MinID = value;
            }
        }
        public int ContractElementType
        {
            set
            {
                _ContractElementType = value;
            }
            get
            {
                return _ContractElementType;
            }
        }
        public int LastInvoiceElement
        {
            set
            {
                _LastInvoiceElement = value;
            }
            get
            {
                return _LastInvoiceElement;
            }

        }
        public int InvoiceElementCount
        {
            get
            {
                return _InvoiceElementCount;
            }

        }
        public int InvoiceElementFinancedCount
        {
            set
            {
                _InvoiceElementFinacedCount = value;
            }
            get
            {
                return _InvoiceElementFinacedCount;
            }

        }
        public DateTime ContractStartDate
        {
            get
            {
                return _ContractStartDate;
            }
        }
        public int ContractCellID
        {
            get
            {
                return _ContractCellID;
            }
        }
        public string ContractCellDesc
        {
           
            get
            {
                return _ContractCellDesc;
            }
        }
        public string ContractorFullName
        {
            get
            {
                return _ContractorFullName;
            }
        }
        public int ContractProcessTypeID
        {
            get
            {
                return _ContractProcessTypeID;
            }
        }
        public string ContractProcessTypeName
        {
            get
            {
                return _ContractProcessTypeName;
            }
        }
        public bool HasInvoiceElement
        {
            get
            {
                return _HasInvoiceElement;
            }
        }
        public int ResultCount
        {
            get
            {
                return _ResultCount;

            }
        }
        public double ResultValue
        {
            get
            {
                return _ResultValue;
            }
        }
        public double DiscountResultValue
        {
            get
            {
                return _DiscountResultValue;
            }
        }
        public string TypeName
        {
            get
            {
                return _TypeName;
            }
        }
        public string EditRefrenceValueStr
        {
            get
            {
                string strRefrenceDate = _RefrenceValue != 0 ? (DateTime.Now.ToOADate() - 2).ToString() : "null";
               
                string Returned = " update RPContractElement set UnitPrice = " + _UnitPrice +
                   
                    ", RefrenceValueUser= case when RefrenceValue =" + _RefrenceValue + " then RefrenceValueUser  else " + SysData.CurrentUser.ID + " end " +
                    ", RefrenceValueEmployee= case when RefrenceValue =" + _RefrenceValue + " then  RefrenceValueEmployee else " + _RefrenceValueEngineer + " end " +
                     " ,RefrenceValue =" + _RefrenceValue +  
                    ",RefrenceValueDate =case when RefrenceValue =" + _RefrenceValue + " then RefrenceValueDate else " + strRefrenceDate + " end " +
                      ",RefrenceValueComment='" + _RefrenceValueComment + "' " +
                      " where  ContractElementID=" + _ID;
              //  arrStr.Add(Returned);
                Returned += " update RPProcess set ProcessAmount=dbo.RPContractElement.RefrenceValue" +
                    ",ProcessAmountUsrUpd= dbo.RPContractElement.RefrenceValueUser, " +
                      " ProcessAmountEmployee = dbo.RPContractElement.RefrenceValueEmployee,ProcessAmountDate=  " +
                      " dbo.RPContractElement.RefrenceValueDate, ProcessAmountComment= dbo.RPContractElement.RefrenceValueComment " +
                      " FROM         dbo.RPProcess INNER JOIN " +
                      " dbo.RPContractElementProcess ON dbo.RPProcess.ProcessID = dbo.RPContractElementProcess.ProcessID INNER JOIN " +
                      " dbo.RPContractElement ON dbo.RPContractElementProcess.ContractElementID = dbo.RPContractElement.ContractElementID " +
                      " WHERE     (dbo.RPContractElement.ContractElementID = " + _ID + ")";
              //  arrStr.Add(Returned);
                Returned += " update   RPContractorInvoiceElement set InvoiceElementUnitPrice=dbo.RPContractElement.UnitPrice " +
                     " FROM   dbo.RPContractorInvoiceElement INNER JOIN " +
                     " dbo.RPContractElement ON dbo.RPContractorInvoiceElement.ContractElementID = dbo.RPContractElement.ContractElementID AND " +
                     " dbo.RPContractorInvoiceElement.InvoiceElementUnitPrice <> dbo.RPContractElement.UnitPrice " +
                     "INNER JOIN  (" + //InvoiceDb.LastFreeInvoiceStr +
                     ") AS MaxInvoiceTable " +
                     " ON  dbo.RPContractorInvoiceElement.InvoiceID = MaxInvoiceTable.InvoiceID " +
                       " WHERE     (dbo.RPContractElement.ContractElementID = " + _ID + ")";
               // arrStr.Add(Returned);

                return Returned;
            }
        }
     
        public string InsertHistoryStr
        {
            get
            {


                string Returned = "insert into RPContractElementHistory "+ 
                    " (ContractElementID, ContractElementUnitPrice, ContractElementRefrenceValue, ConractElementRefrenceValueUser, ContractElementRefrenceValueEmployee, "+
                      " ContractElementRefrenceValueDate, ContractElementRefrenceValueComment, UsrIns, TimIns "+
                      " ) "+
                      " SELECT     dbo.RPContractElement.ContractElementID, dbo.RPContractElement.UnitPrice"+
                      ", dbo.RPContractElement.RefrenceValue, dbo.RPContractElement.RefrenceValueUser, "+
                      " dbo.RPContractElement.RefrenceValueEmployee, dbo.RPContractElement.RefrenceValueDate"+
                      ", dbo.RPContractElement.RefrenceValueComment,"+ SysData.CurrentUser.ID +" as UsrIns,GetDate() as TimIns "+
                      " FROM         dbo.RPContractElement left outer JOIN "+
                      " (SELECT     dbo.RPContractElementHistory.ContractElementID, dbo.RPContractElementHistory.ContractElementUnitPrice, "+
                      " dbo.RPContractElementHistory.ContractElementRefrenceValue,RPContractElementHistory.ContractElementRefrenceValueComment " +
                      " FROM         dbo.RPContractElementHistory INNER JOIN "+
                     " (SELECT     MAX(HistoryID) AS MaxHistoryID, ContractElementID "+
                     " FROM         dbo.RPContractElementHistory AS RPContractElementHistory_1 "+
                      " GROUP BY ContractElementID) AS MaxTable ON dbo.RPContractElementHistory.HistoryID = MaxTable.MaxHistoryID AND  "+
                      " dbo.RPContractElementHistory.ContractElementID = MaxTable.ContractElementID) AS MaxHistoryTable ON  "+
                      " dbo.RPContractElement.UnitPrice = MaxHistoryTable.ContractElementUnitPrice AND  "+
                      " dbo.RPContractElement.ContractElementID = MaxHistoryTable.ContractElementID AND "+
                      " dbo.RPContractElement.RefrenceValue = MaxHistoryTable.ContractElementRefrenceValue "+
                      " and ((MaxHistoryTable.ContractElementRefrenceValueComment is null and   dbo.RPContractElement.RefrenceValueComment is null ) " +
                      " or (dbo.RPContractElement.RefrenceValueComment = MaxHistoryTable.ContractElementRefrenceValueComment  ) ) " +
                      " WHERE     (MaxHistoryTable.ContractElementID IS NULL) ";
                if (_ElementIDs != null && _ElementIDs != "")
                    Returned += " and dbo.RPContractElement.ContractElementID in ("+ _ElementIDs +")";
              if(_ID != 0)
                  Returned += " and dbo.RPContractElement.ContractElementID =" + _ID + "";

                return Returned;
            }
        }
        public virtual string AddStr
        {
            get
            {
                double dblStartDate = _StartDate.ToOADate() - 2;
                double dblEstimationDate = _EstimationDate.ToOADate() - 2;
                double dblAssignDate = _AssignDate.ToOADate() - 2;

                string Returned = "insert into RPContractElement (ContractID, UnitPrice,ContractElementUnitID" +
                                ",StartDate, EstimatedDate,ContractElementType,ContractElementCell,ContractElementDesc" +
                                ",AssignmentDate,ContractElementOrder,RefrenceValue,ContractElementTax,ContractElementInsurance,UsrIns,TimIns) " +
                                " select " + _ContractID + " as ContractID," + _UnitPrice + " As UnitPrice," +
                                _UnitID + " as UnitID ," +
                                dblStartDate + " as StartDate," + dblEstimationDate + " as EstimationDate," +
                                _ProcessType + " as ProcessType," + _Cell + "  as Cell,'" +
                                _ContractElementDesc.Replace("'","''") + "' as ElementDesc," + dblAssignDate + " as AsignDate," +
                                "case when 0=" + _Order +
                                " then  CASE WHEN MAX(ContractElementOrder) IS NULL THEN 0 ELSE MAX(ContractElementOrder) END + 1 " +
                                " else " + _Order + " end " +
                                " as ElementOrder," +
                                _RefrenceValue + " as RefrenceValue," + _TaxPercent + "," + _InsurancePercent + ","+
                                SysData.CurrentUser.ID.ToString() + " as UsrIns,GetDate() as TimIns " +
                                " FROM  dbo.RPContractElement " +
                               " WHERE     (ContractID = " + _ContractID + ")";
                return Returned;

            }
        }
        public virtual string EditStr
        {
            get
            {
                double dblStartDate = _StartDate.ToOADate() - 2;
                double dblEstimationDate = _EstimationDate.ToOADate() - 2;
                double dblAssignDate = _AssignDate.ToOADate() - 2;
                // base.Edit();
                string Returned = " update RPContractElement " +
                       " set  ContractElementUnitID = "+ _UnitID +
                      // ",UnitPrice = " + _UnitPrice +
                      " ,StartDate = " + dblStartDate +
                     " ,EstimatedDate = " + dblEstimationDate +
                     " ,ContractElementType = " + _ProcessType +
                     " ,ContractElementCell = " + _Cell +
                    ",ContractElementDesc ='" + _ContractElementDesc.Replace("'" , "''" ) + "'" +
                     ",AssignmentDate=" + dblAssignDate +
                    ",ContractElementOrder=" + _Order +
                    //",RefrenceValue=" + _RefrenceValue.ToString() +
                    ",ContractElementTax="+ _TaxPercent.ToString() +
                    ",ContractElementInsurance="+_InsurancePercent.ToString() +
                    ",UsrUpd=" + SysData.CurrentUser.ID.ToString() + ",TimUpd=GetDate()" +
                    " where  ContractElementID=" + _ID;
                Returned += EditRefrenceValueStr;

                Returned += " delete FROM  RPContractElementCategory " +
                       " WHERE     (ContractElementID = " + _ID + ")";
                Returned += " delete FROM   dbo.RPContractElementProcess " +
                       " WHERE     (ContractElementID = " + _ID + ")";
                Returned += " delete FROM   dbo.RPContractElementDerived " +
                      " WHERE     (ContractElementID = " + _ID + ")";
                Returned += " delete FROM   dbo.RPContractElementDiscount " +
                    " WHERE     (ContractElementID = " + _ID + ")";
                return Returned;

            }
        }
        public  string SearchStr
        {
            get
            {
                string strContract = "SELECT dbo.RPContract.ContractID as NativeContractID"+
                    ", dbo.RPContract.StartDate AS ContractStartDate, dbo.RPContract.CellID AS ContractCellID,  ContractCellDesc  "+
                    ",dbo.RPContract.TaxPercent,dbo.RPContract.AssurancePercent" +
                      ", dbo.RPContractor.ContractorFullName AS ContractContractorName, dbo.RPProcessType.PROCESSTypeID AS ContractProcessTypeID"+
                      ",dbo.RPProcessType.PROCESSTypeNameA AS ContractProcessTypeName,RPContract.Dis as ContractDis " +
                      " FROM  dbo.RPContract INNER JOIN "+
                      " dbo.RPContractor ON dbo.RPContract.ContractorID = dbo.RPContractor.ContractorID left outer JOIN "+
                      " dbo.RPProcessType ON dbo.RPContract.ContractProcessType = dbo.RPProcessType.PROCESSTypeID";

                
         
                    
                string strContractElementProcessType = "SELECT  PROCESSTypeID AS ContractElementProcessTypeID, PROCESSTypeNameA AS ContractElementProcessTypeName "+
                         " FROM   dbo.RPProcessType ";
                string strInvoiceElement = "SELECT ContractElementID, MAX(InvoiceElementID) AS MaxInvoiceElement " +
                    ",count(InvoiceElementID) as CountInvoiceElement"+
                    ",sum(case when  dbo.RPContractorInvoice.InvoiceFinancialStatmentID >0 then 1 else 0 end) as CountInvoiceElementFinaced  " +
                    " FROM   dbo.RPContractorInvoiceElement   " +
                    " INNER JOIN dbo.RPContractorInvoice " +
                    "  ON dbo.RPContractorInvoiceElement.InvoiceID = dbo.RPContractorInvoice.InvoiceID where (1=1) ";
                if (_IsDateLimited)
                {
                    double dblLimitDate = SysUtility.Approximate(_LimitDate.ToOADate() - 2, 1, ApproximateType.Up);
                    strInvoiceElement += " and dbo.RPContractorInvoice.InvoiceDate < "+ dblLimitDate ;
                }
                if (_InvoiceStage > 0)
                    strInvoiceElement += " and dbo.RPContractorInvoice.InvoiceStage >=" + _InvoiceStage;
                if (_EndPerc > _StartPerc || (_EndPerc == _StartPerc && _StartPerc > 0))
                    strInvoiceElement += " and  RPContractorInvoiceElement.NewPercent >=" + _StartPerc +
                        " and RPContractorInvoiceElement.NewPercent <="+_EndPerc;
                    strInvoiceElement += " GROUP BY ContractElementID ";
                         strInvoiceElement = "SELECT  MaxInvoiceElementTable.MaxInvoiceElement,MaxInvoiceElementTable.CountInvoiceElementFinaced,TotalAcheivedAmount AS MaxTotalAcheivedAmount, OldPercent AS MaxOldPerc, NewPercent AS MaxNewPerc, " +
                      " OldAcheivedAmount AS MaxOldAcheivedAmount, RPContractorInvoiceElement.ContractElementID " +
                      ",InvoiceElementUnitPrice as MaxUnitPrice"+
                      ",dbo.RPContractorInvoiceElement.InvoiceElementOldUnitPrice AS MaxOldUnitPrice  "+
                      " FROM   dbo.RPContractorInvoiceElement " +
                      " inner join (" + strInvoiceElement + ") as MaxInvoiceElementTable on "+
                      " RPContractorInvoiceElement.ContractElementID = MaxInvoiceElementTable.ContractElementID  "+
                      "  and RPContractorInvoiceElement.InvoiceElementID = MaxInvoiceElementTable.MaxInvoiceElement "+
                      "  inner join RPContractorInvoice "+
                      " on dbo.RPContractorInvoiceElement.InvoiceID = dbo.RPContractorInvoice.InvoiceID where (1=1) ";
                    if ((_InvoiceStatementIDs!= null && _InvoiceStatementIDs != "") || _InvoiceStatement != 0 || _InvoiceType != 0 || _NewElementStatus != 0 )
                    {
                        if(_InvoiceType != 0)
                        strInvoiceElement += " and RPContractorInvoice.InvoiceType = "+ _InvoiceType ;
                    if (_InvoiceStatement != 0 )
                        strInvoiceElement += " and RPContractorInvoice.InvoiceStatement ="+_InvoiceStatement ;
                    if(_InvoiceStatementIDs!= null && _InvoiceStatementIDs != "")
                        strInvoiceElement += " and RPContractorInvoice.InvoiceStatement in(" + _InvoiceStatementIDs + ") ";
                        if (_NewElementStatus == 2)
                            strInvoiceElement += " and  ( " +
                                 "dbo.RPContractorInvoiceElement.OldAcheivedAmount = dbo.RPContractorInvoiceElement.TotalAcheivedAmount " +
                               " and dbo.RPContractorInvoiceElement.OldPercent = dbo.RPContractorInvoiceElement.NewPercent" +
                               " and  dbo.RPContractorInvoiceElement.InvoiceElementUnitPrice = dbo.RPContractorInvoiceElement.InvoiceElementOldUnitPrice " +
                               ")";
                    else if (_NewElementStatus == 1)
                        strInvoiceElement += " and  ( " +
                            "dbo.RPContractorInvoiceElement.OldAcheivedAmount <> dbo.RPContractorInvoiceElement.TotalAcheivedAmount " +
                          " or dbo.RPContractorInvoiceElement.OldPercent <> dbo.RPContractorInvoiceElement.NewPercent" +
                          " or  dbo.RPContractorInvoiceElement.InvoiceElementUnitPrice <> dbo.RPContractorInvoiceElement.InvoiceElementOldUnitPrice " +
                          ")";
                    }

                    string strEmployee = "SELECT  dbo.HRApplicant.ApplicantID, dbo.HRApplicantWorker.ApplicantCode, dbo.HRApplicant.ApplicantFirstName, dbo.HRApplicant.ApplicantFamousName, " +
                      " dbo.HRApplicant.ApplicantNameComp, dbo.HRApplicantWorker.ApplicantUser, dbo.HRApplicantWorker.ApplicantStatusID " +
                      ",dbo.HRApplicantWorker.ApplicantEndDate  " +
                      " FROM   dbo.HRApplicant INNER JOIN " +
                      " dbo.HRApplicantWorker ON dbo.HRApplicant.ApplicantID = dbo.HRApplicantWorker.ApplicantID ";
                    string strCell = "SELECT CellID, CellNameA, CellFamilyID "+
                         " FROM   dbo.RPCell ";
                    string Returned = "SELECT  dbo.RPContractElement.ContractElementID,dbo.RPContractElement.ContractID, " +
                        " dbo.RPContractElement.ContractElementUnitID," +
                        "  dbo.RPContractElement.UnitPrice, dbo.RPContractElement.Dis as ContractElementDis ,case when  MaxTotalAcheivedAmount is null then 0  else 1 end as HasInvoiceElement" +
                        ",case when  MaxTotalAcheivedAmount is null then 0 else " +
                        "  MaxTotalAcheivedAmount " +
                        " end RealCounting,case when  InvoiceElementTable.MaxNewPerc  is null then 0 else " +
                        "  InvoiceElementTable.MaxNewPerc end as TotalAchievedPercent, ContractElementDesc, AssignmentDate, " +
                        " RPContractElement.StartDate as ElementStartDate,ContractElementType,ContractElementCell,ContractElementCellDesc, RPContractElement.EndDate as ElementEndDate, EstimatedDate," +
                        "ContractElementOrder,ContractElementStoped,dbo.RPContractElement.RefrenceValue, dbo.RPContractElement.RefrenceValueUser, dbo.RPContractElement.RefrenceValueEmployee " +
                        ",dbo.RPContractElement.RefrenceValueDate,dbo.RPContractElement.RefrenceValueComment" +
                        ",ContractProcessTable.*,CategoryTable.* ,DerivedTable.*,SelfDerivedTable.* ,ContractElementTypeTable.*  " +
                        " ,ContractTable.*,DiscountElementTable.*,InvoiceElementTable.MaxInvoiceElement  " +
                        ",EmployeeTable.ApplicantID as EmployeeID,EmployeeTable.ApplicantFirstName as EmployeeName" +
                        ",case when ContractElementDiscountID is not null and ContractElementDiscountID<>0 then 1 else 0 end as ElementIsDiscount" +
                        ",RPContractElement.ContractElementTax,RPContractElement.ContractElementInsurance " +
                        ",InvoiceElementTable.MaxOldPerc,InvoiceElementTable.MaxNewPerc"+
                        ",InvoiceElementTable.MaxOldAcheivedAmount,InvoiceElementTable.MaxUnitPrice, InvoiceElementTable.MaxOldUnitPrice  " +
                       ",InvoiceElementTable.CountInvoiceElementFinaced "+
                        " FROM   dbo.RPContractElement   " +
                        " inner join (" + strContract + ") as ContractTable " +
                        " on  dbo.RPContractElement.ContractID = ContractTable.NativeContractID"+
                        " left outer join ("+ strCell+ ")  as CellTable "+
                        " on  RPContractElement.ContractElementCell = CellTable.CellID ";
                if(_OverAcheivedProcessStatus== 1)
                    Returned += " inner join (" + ContractElementProcessDb.SearchStr + ") ";
                else
                    Returned += " left outer join (" + ContractElementProcessDb.SearchStr + ") ";
                       Returned += " as ContractProcessTable  " +
                        " on ContractProcessTable.ContractElementProcessID =RPContractElement.ContractElementID   " +
                        " left outer join (" + ContractElementCategoryDb.SearchStr + ") as CategoryTable  on  " +
                        " RPContractElement.ContractElementID = CategoryTable.ContractElementCategoryID " +
                        " left outer join (" + ContractElementDerivedDb.SearchStr + ") as DerivedTable  " +
                        " on RPContractElement.ContractElementID = DerivedTable.ContractElementDerivedID  " +
                        " left outer join (" + ContractElementSelfDerivedDb.SearchStr + ") as SelfDerivedTable  " +
                        " on RPContractElement.ContractElementID = SelfDerivedTable.ContractElementSelfDerivedID  " +
                        " left outer join (" + ContractElementDiscountDb.SearchStr + ") as DiscountElementTable " +
                        " on dbo.RPContractElement.ContractElementID = DiscountElementTable.ContractElementDiscountID " +
                        " left outer join (" + strContractElementProcessType + ") as ContractElementTypeTable on  " +
                        " RPContractElement.ContractElementType = ContractElementTypeTable.ContractElementProcessTypeID ";
                    if ((_InvoiceStatementIDs!= null && _InvoiceStatementIDs != "") || 
                        _InvoiceStatement != 0 || _InvoiceType != 0 ||_NewElementStatus!=0 ||
                       ( _EndPerc > _StartPerc || (_EndPerc == _StartPerc && _StartPerc > 0))
                        )
                        Returned += " inner join ";
                    else
                        Returned += " left outer join ";
                          Returned +=  "(" + strInvoiceElement + ") as InvoiceElementTable on dbo.RPContractElement.ContractElementID = InvoiceElementTable.ContractElementID " +
                        " left outer join ("+ strEmployee +") as EmployeeTable "+
                        " on dbo.RPContractElement.RefrenceValueEmployee = EmployeeTable.ApplicantID ";
                         
                
                if (_OverAcheivedProcessStatus == 1)
                              Returned += " inner join ("+ new ProcessDb().OverLapedProcess +") as ProcessTotalAcheivedTable "+
                                  " on ContractProcessTable.ProcessID = ProcessTotalAcheivedTable.ProcessID ";
                return Returned;

            }
        }
        #endregion
        #region Private Methods
        protected virtual void SetData(DataRow objDR)
        {
            if (objDR.Table.Columns["UnitPrice"] != null && objDR["UnitPrice"].ToString()!="")
            _UnitPrice = double.Parse(objDR["UnitPrice"].ToString());
            if(objDR.Table.Columns["RealCounting"]!= null && objDR["RealCounting"].ToString()!= "")
             _TotalAcheivedAmount = double.Parse(objDR["RealCounting"].ToString());
         if (objDR.Table.Columns["ElementStartDate"] != null)
         {
             if (objDR["ElementStartDate"].ToString() != "")
                 _StartDate = DateTime.Parse(objDR["ElementStartDate"].ToString());
         }
            if(objDR.Table.Columns["ContractElementDesc"] != null)
             _ContractElementDesc = objDR["ContractElementDesc"].ToString();
            if(objDR.Table.Columns["AssignmentDate"]!= null)
              _AssignDate = DateTime.Parse(objDR["AssignmentDate"].ToString());
            try
            {
                if (objDR.Table.Columns["EstimatedDate"] != null)
                {
                    if (objDR["EstimatedDate"].ToString() != "")
                        _EstimationDate = DateTime.Parse(objDR["EstimatedDate"].ToString());
                }
            }
            catch
            {
            }
            if(objDR.Table.Columns["ContractID"]!= null)
            _ContractID = int.Parse(objDR["ContractID"].ToString());
            if(objDR.Table.Columns["ContractElementID"]!= null)
             _ID = int.Parse(objDR["ContractElementID"].ToString());
         if (objDR.Table.Columns["TotalAchievedPercent"] != null && objDR["TotalAchievedPercent"].ToString()!= "")
            _Percent = double.Parse(objDR["TotalAchievedPercent"].ToString());
        if (objDR.Table.Columns["ContractElementUnitID"] != null)
        {
            if(objDR["ContractElementUnitID"].ToString()!= "")
            _UnitID = int.Parse(objDR["ContractElementUnitID"].ToString());
        }
        if (objDR.Table.Columns["ContractElementOrder"] != null && objDR["ContractElementOrder"].ToString() != "")
              _Order = int.Parse(objDR["ContractElementOrder"].ToString());
            if(objDR.Table.Columns["ContractElementStoped"]!= null)
            _Stoped = bool.Parse(objDR["ContractElementStoped"].ToString());
        if (objDR.Table.Columns["ContractElementCell"] != null && objDR["ContractElementCell"].ToString() != "")
            _Cell = int.Parse(objDR["ContractElementCell"].ToString());
        if (objDR.Table.Columns["ContractElementType"] != null && objDR["ContractElementType"].ToString() != "")
              _ProcessType = int.Parse(objDR["ContractElementType"].ToString());
            if(objDR.Table.Columns["ContractElementProcessTypeName"]!= null)
             _TypeName = objDR["ContractElementProcessTypeName"].ToString();
         if (objDR.Table.Columns["ContractStartDate"] != null && objDR["ContractStartDate"].ToString() != "")
            _ContractStartDate = DateTime.Parse(objDR["ContractStartDate"].ToString());
           if(objDR.Table.Columns["ContractCellID"]!= null)
            _ContractCellID = int.Parse(objDR["ContractCellID"].ToString());
            if(objDR.Table.Columns["ContractContractorName"]!= null)
            _ContractorFullName = objDR["ContractContractorName"].ToString();
        if (objDR.Table.Columns["ContractProcessTypeID"] != null && objDR["ContractProcessTypeID"].ToString() != "")
            _ContractProcessTypeID = int.Parse(objDR["ContractProcessTypeID"].ToString());
          if(objDR.Table.Columns["ContractProcessTypeName"]!=null)
            _ContractProcessTypeName = objDR["ContractProcessTypeName"].ToString();
           if(objDR.Table.Columns["RefrenceValue"]!= null && objDR["RefrenceValue"].ToString()!= "")
            _RefrenceValue = double.Parse(objDR["RefrenceValue"].ToString());
            if (objDR.Table.Columns["RefrenceValueUser"] != null &&
                objDR["RefrenceValueUser"].ToString() != "")
                _RefrenceValueUser = int.Parse(objDR["RefrenceValueUser"].ToString());
            if (objDR.Table.Columns["EmployeeID"] != null && objDR["EmployeeID"].ToString() != "")
                _RefrenceValueEngineer = int.Parse(objDR["EmployeeID"].ToString());
            if (objDR.Table.Columns["EmployeeName"] != null && objDR["EmployeeName"].ToString() != "")
                _RefrenceValueEngineerName = objDR["EmployeeName"].ToString();
            if (objDR.Table.Columns["RefrenceValueEmployee"] != null && objDR["RefrenceValueEmployee"].ToString() != "")
                _RefrenceValueEngineer = int.Parse(objDR["RefrenceValueEmployee"].ToString());
            if (objDR.Table.Columns["RefrenceValueDate"]!= null &&
                objDR["RefrenceValueDate"].ToString() != "" && objDR["RefrenceValueDate"].ToString() != "")
                _RefrenceValueDate = DateTime.Parse(objDR["RefrenceValueDate"].ToString());
            if (objDR.Table.Columns["RefrenceValueComment"] != null &&
              objDR["RefrenceValueComment"].ToString() != "" )
                _RefrenceValueComment = objDR["RefrenceValueComment"].ToString();
            _HasInvoiceElement = false;
            if (objDR.Table.Columns["HasInvoiceElement"] != null && objDR["HasInvoiceElement"].ToString() != "")
                _HasInvoiceElement = objDR["HasInvoiceElement"].ToString() != "0";
            if(objDR.Table.Columns["ContractElementCellDesc"]!= null)
            _CellDesc = objDR["ContractElementCellDesc"].ToString();
        if (objDR.Table.Columns["ContractCellDesc"] != null)
            _ContractCellDesc = objDR["ContractCellDesc"].ToString();

        if (objDR.Table.Columns["ProcessID"] != null && objDR["ProcessID"].ToString() != "")
            _ElementProcessID = int.Parse(objDR["ProcessID"].ToString());
        if (objDR.Table.Columns["DiscountTypeID"] != null && objDR["DiscountTypeID"].ToString() != "")
            _ElementDiscountID = int.Parse(objDR["DiscountTypeID"].ToString());
        if (objDR.Table.Columns["DiscountEmployeeID"] != null && objDR["DiscountEmployeeID"].ToString() != "")
            _ElementDiscountEmployee = int.Parse(objDR["DiscountEmployeeID"].ToString());
        if (objDR.Table.Columns["ElementType"] != null && objDR["ElementType"].ToString() != "")
            _ContractElementType = int.Parse(objDR["ElementType"].ToString());
            if(objDR.Table.Columns["CountInvoiceElementFinaced"] != null && 
                objDR["CountInvoiceElementFinaced"].ToString()!= "")
        _InvoiceElementFinacedCount = int.Parse(objDR["CountInvoiceElementFinaced"].ToString());


        if (objDR.Table.Columns["ProcessEmployeeID"] != null && objDR["ProcessEmployeeID"].ToString() != "")
            _RefrenceValueEngineer = int.Parse(objDR["ProcessEmployeeID"].ToString());
        if (objDR.Table.Columns["ProcessEmployeeName"] != null && objDR["ProcessEmployeeName"].ToString() != "")
            _RefrenceValueEngineerName = objDR["ProcessEmployeeName"].ToString();
        
        if (objDR.Table.Columns["ProcessAmountDate"] != null &&
            objDR["ProcessAmountDate"].ToString() != "" && objDR["ProcessAmountDate"].ToString() != "")
            _RefrenceValueDate = DateTime.Parse(objDR["ProcessAmountDate"].ToString());
        if (objDR.Table.Columns["ProcessAmountComment"] != null &&
          objDR["ProcessAmountComment"].ToString() != "")
            _RefrenceValueComment = objDR["ProcessAmountComment"].ToString();
        if (objDR.Table.Columns["ProcessAmount"] != null && objDR["ProcessAmount"].ToString() != "")
            _RefrenceValue = double.Parse(objDR["ProcessAmount"].ToString());
        if (objDR.Table.Columns["ProcessAmountUsrUpd"] != null &&
            objDR["ProcessAmountUsrUpd"].ToString() != "")
            _RefrenceValueUser = int.Parse(objDR["ProcessAmountUsrUpd"].ToString());
        if (objDR.Table.Columns["MaxInvoiceElement"] != null && objDR["MaxInvoiceElement"].ToString() != "")
            _LastInvoiceElement = int.Parse(objDR["MaxInvoiceElement"].ToString());
        if (objDR.Table.Columns["ContractElementInsurance"] != null && objDR["ContractElementInsurance"].ToString() != "")
            _InsurancePercent = double.Parse(objDR["ContractElementInsurance"].ToString());
        else if(objDR.Table.Columns["AssurancePercent"] != null && objDR["AssurancePercent"].ToString()!= "")
            _InsurancePercent = double.Parse(objDR["AssurancePercent"].ToString());

        if (objDR.Table.Columns["ContractElementTax"] != null && objDR["ContractElementTax"].ToString() != "")
            _TaxPercent = double.Parse(objDR["ContractElementTax"].ToString());
        else if(objDR.Table.Columns["TaxPercent"]!= null && objDR["TaxPercent"].ToString()!= "")
            _TaxPercent = double.Parse(objDR["TaxPercent"].ToString());
            if(objDR.Table.Columns["MaxOldPerc"]!= null && objDR["MaxOldPerc"].ToString()!= "")
             _OldPercent = double.Parse(objDR["MaxOldPerc"].ToString());
            if(objDR.Table.Columns["MaxOldUnitPrice"]!= null && objDR["MaxOldUnitPrice"].ToString()!= "")
               _OldUnitPrice = double.Parse(objDR["MaxOldUnitPrice"].ToString());
            if(objDR.Table.Columns["MaxOldAcheivedAmount"]!= null && objDR["MaxOldAcheivedAmount"].ToString()!= "")
               _OldAcheivedAmount = double.Parse(objDR["MaxOldAcheivedAmount"].ToString());

           
        }
        #endregion
        #region Public Methods
        public  virtual void Add()
        {
        
            string strSql = AddStr;

            _ID = SysData.SharpVisionBaseDb.InsertIdentityTable(strSql);
            _ElementTable = null;
        }
        public virtual void Edit()
        {
           string strSql = EditStr;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
            _ElementTable = null;
        }
     public void EditMultiple()
     {
         if (_ContractElementTable == null || _ContractElementTable.Rows.Count == 0)
             return;
         string[] arrStr = new string[_ContractElementTable.Rows.Count+1];
         string strSql;
         double dblStartDate = 0;
         double dblEstimationDate = 0;
         double dblAssignDate = 0;
         int intIndex = 0;
         foreach (DataRow objDr in _ContractElementTable.Rows)
         {
             SetData(objDr);

             strSql = " update RPContractElement " +
                    " set ContractElementType = " + _ProcessType +
                  " ,ContractElementCell = " + _Cell +
                  ",ContractElementDesc ='" + _ContractElementDesc.Replace("'","''") + "'" +
                  ",ContractElementUnitID=" + _UnitID +
                  ",UsrUpd=" + SysData.CurrentUser.ID.ToString() + ",TimUpd=GetDate()" +
                 " where  ContractElementID=" + _ID;
            // strSql = EditStr;
             strSql += " delete FROM  RPContractElementCategory " +
                     " WHERE     (ContractElementID = " + _ID + ")";
             strSql += " delete FROM   dbo.RPContractElementProcess " +
                    " WHERE     (ContractElementID = " + _ID + ")";
             strSql += " delete FROM   dbo.RPContractElementDerived " +
                   " WHERE     (ContractElementID = " + _ID + ")";
            strSql += " delete FROM   dbo.RPContractElementDiscount " +
                 " WHERE     (ContractElementID = " + _ID + ")";
                 if(_ElementProcessID != 0)
                 {
                     strSql += " insert into RPContractElementProcess (ContractElementID, ProcessID) "+
                         " select ContractElementID," + _ElementProcessID + " as ContractElementProcess  " +
                         " from  RPContractElement "+
                         " where RPContractElement.ContractElementID = "+ _ID +
                         " and not exists (select ContractElementID from RPContractElementProcess where ContractElementID ="+_ID+ ") "+
                         " and not exists (select ContractElementID from RPContractElementDiscount where ContractElementID =" + _ID + ") ";

                     strSql += " Update RPContractElementProcess set ProcessID="+ _ElementProcessID+
                         " where ContractElementID ="+ _ID;
                 }
                 if (_ElementDiscountID != 0)
                 {
                     strSql += " insert into RPContractElementDiscount ( ContractElementID, DiscountEmployee, DiscountTypeID)  " +
                         " select ContractElementID," + _ElementDiscountEmployee + " as DiscountEmpoyee," + _ElementDiscountID + " as DiscountTYpeID "+
                         " from  RPContractElement " +
                         " where RPContractElement.ContractElementID = " + _ID +
                         " and not exists (select ContractElementID from RPContractElementProcess where ContractElementID =" + _ID + ")" +
                         " and not exists (select ContractElementID from RPContractElementDiscount where ContractElementID =" + _ID + ")";

                     strSql += " Update RPContractElementDiscount set DiscountEmployee=" + _ElementDiscountEmployee + ",DiscountTypeID="+ _ElementDiscountID+
                         " where ContractElementID =" + _ID;
                 }
                 arrStr[intIndex] = strSql;
                 intIndex++;
         }
         List<string> arrTempStr = SysUtility.GetStringArr(_ContractElementTable, "ContractElementID", 5000);
        ContractElementDb objTemp = new ContractElementDb();
         objTemp.ElementIDs = arrTempStr[0];
         arrStr[intIndex] = objTemp.InsertHistoryStr;
       
         SysData.SharpVisionBaseDb.ExecuteNonQuery(arrStr);
         _ElementTable = null;
     }
        public void EditUnitPrice()
        {


            string strSql = "update RPContractElement ";
            strSql = strSql + " set UnitPrice = " + _UnitPrice;
            strSql = strSql + " where ContractID=" + _ContractID + " and ContractElementID=" + _ID;


            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
            _ElementTable = null;
        }
        public void StopElement()
        {

            int intIsStopped = _Stoped ? 1 : 0;

            string strSql = "update RPContractElement ";
            strSql = strSql + " set ContractElementStoped="+intIsStopped;
            if (_ID != 0)
                strSql = strSql + " where  ContractElementID=" + _ID;
            else if (_IDs != null && _IDs != "")
                strSql = strSql + " where  ContractElementID in (" + _IDs + ") ";
            else
                return;


            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public virtual void Delete()
        {


            string strSql = "";
            strSql = "delete from  RPContractElement " +
                   " where ContractElementID  =" + _ID + " and   ContractElementID not in (" +
                   "SELECT  ContractElementID " +
                   " FROM         dbo.RPContractorInvoiceElement " +
                   " WHERE     (ContractElementID =" + _ID + " )" +
                   ")" +
                   " update RPContractElement set Dis = GetDate()  " +
                   "    where ContractElementID =" + _ID + "  and   ContractElementID  in (" +
                  "SELECT  ContractElementID " +
                   " FROM         dbo.RPContractorInvoiceElement " +
                   " WHERE     (ContractElementID = " + _ID + " ))"; ;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
            _ElementTable = null;
        }
        public virtual DataTable Search()
        {

          string strSql = ContractElementSearchStr;

          if (_MaxID == 0 && _MinID == 0)
          {
              string strCountSql = "select count(*) as ResultCount, "+
                  " sum(case when ElementIsDiscount = 0 then RealCounting * UnitPrice * TotalAchievedPercent/100 else 0 end) AS ResultValue "+
                  ",sum(case when ElementIsDiscount = 1 then RealCounting * UnitPrice * TotalAchievedPercent/100 else 0 end) AS ResultDiscountValue" +
                  " from (" + strSql + ")  AS NativeTable ";
              DataTable dtTemp = SysData.SharpVisionBaseDb.ReturnDatatable(strCountSql);
              if(dtTemp.Rows.Count>0)
              {
                  _ResultCount = int.Parse(dtTemp.Rows[0]["ResultCount"].ToString());
                  if (dtTemp.Rows[0]["ResultValue"].ToString() != "")
                  {
                      _ResultValue = double.Parse(dtTemp.Rows[0]["ResultValue"].ToString());
                      _DiscountResultValue = double.Parse(dtTemp.Rows[0]["ResultDiscountValue"].ToString());
                  }
              //_ResultCount = int.Parse(SysData.SharpVisionBaseDb.ReturnScalar(strCountSql).ToString());
              }
          }
          else
          {
              if (_MaxID != 0)
                  strSql += " and RPContractElement.ContractElementID >" + _MaxID;
              else if (_MinID != 0)
              {
                  strSql += " and RPContractElement.ContractElementID <" + _MinID;
              }
          }




          strSql = "Select top 3000 * from (" + strSql + ") as NativeTable order by ContractElementID ";
          DataTable Returned = SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
          return Returned;
        }
        public void EditRefrenceValue()
        {
            if (_ContractElementTable == null || _ContractElementTable.Rows.Count == 0)
                return;
            string[] arrStr = new string[_ContractElementTable.Rows.Count+1];
            ContractElementDb objTemp;
            int intIndex = 0;
            foreach (DataRow objDr in _ContractElementTable.Rows)
            {
                objTemp = new ContractElementDb(objDr);
                arrStr[intIndex] = objTemp.EditRefrenceValueStr;
                intIndex++;
            }
            string strElementID = SysUtility.GetStringArr(_ContractElementTable, "ContractElementID", 5000)[0];
            objTemp = new ContractElementDb();
            objTemp.ElementIDs = strElementID;
            arrStr[intIndex] = objTemp.InsertHistoryStr;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(arrStr);

        }
        public void EditUnitPriceCol()
        {
            if (_ContractElementTable == null || _ContractElementTable.Rows.Count == 0)
                return;
            string[] arrStr = new string[_ContractElementTable.Rows.Count+1];
            ContractElementDb objTemp;
            int intIndex = 0;
            foreach (DataRow objDr in _ContractElementTable.Rows)
            {
                SetData(objDr);
                arrStr[intIndex] = "update RPContractElement " +
                  " set UnitPrice = " + objDr["UnitPrice"].ToString() +
                " where  ContractElementID=" + _ID;
                intIndex++;
            }
            List<string> arrTempStr = SysUtility.GetStringArr(_ContractElementTable, "ContractElementID", 5000);
            objTemp = new ContractElementDb();
            objTemp.ElementIDs = arrTempStr[0];
            arrStr[intIndex] = objTemp.InsertHistoryStr; 
            SysData.SharpVisionBaseDb.ExecuteNonQuery(arrStr);

        }
        #endregion

    }
}
