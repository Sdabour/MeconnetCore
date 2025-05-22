using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.SystemBase;
using System.Data;
using System.Data.SqlClient;
using SharpVision.Base.BaseDataBase;
namespace SharpVision.RP.RPDataBase
{
    public class ProcessDb : BaseSelfRelatedDb
    {
        #region Private Data

        CellDb _CellDb;
        int _CellID;
        int _TypeID;
        DateTime _StartDate;
        DateTime _EndDate;
        DateTime _EstimationDate;
        double _ParentPerc;
        bool _IsScondary;
        string _Desc;
        double _Amount;
        double _TotalContractElementAchieved;
        bool _IsOverAchieved;
        int _AmountUsrUpd;
        int _AmountEmployee;
        string _AmountEmployeeName;
        string _AmountComment;
        DateTime _AmountDate;
        bool _AllProcess;
        DataTable _CategoryTypeTable;

        #region Private Data For Search
        string _ProcessSttr;
        string _CellStr;
        bool _OnlyZeros;
        int _ContractorID;
        double _MaxUnitPrice;
        double _MinUnitprice;
        bool _AsignedToContract;
        int _CellFamilyID;
        DataTable _ProcessTable;
        #endregion
        static DataTable _ContractTable;
        static DataTable _ContractProcessTable;

        #endregion

        #region Constructors
        public ProcessDb()
        {
            
        }
        public ProcessDb(int intID)
        {
            _ID = intID;
             DataTable dtTemp = Search();

             DataRow objDR = dtTemp.Rows[0];
            _CellID = int.Parse(objDR["CellID"].ToString());
            _ParentID = int.Parse(objDR["ProcessParentID"].ToString());
            _FamilyID = int.Parse(objDR["ProcessFamilyID"].ToString());
            _TypeID = int.Parse(objDR["ProcessTypeID"].ToString());
            _CellID = int.Parse(objDR["CellID"].ToString());
            _Amount = double.Parse(objDR["ProcessAmount"].ToString());
            _AmountUsrUpd = int.Parse(objDR["ProcessAmountUsrUpd"].ToString());
            DataRow[] arrDR = CellDb.CellTable.Select("CellID=" + _CellID);
            if (arrDR.Length > 0)
                _CellDb = new CellDb(arrDR[0]);
            _AllProcess = true;
            
        }

        public ProcessDb(DataRow objDR) 
        {
            //_ProcessDb = DR;
            SetData(objDR);
        }

        public ProcessDb(int intID, string strName)
        {
            _ID = intID;
            _NameA = strName;
            
        }
        #endregion

        #region Public Properties
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
        public int TypeID
        {
            set
            {
                _TypeID = value;
            }
            get
            {
                return _TypeID;
            }

        }
        public string Desc
        {
            set { _Desc = value; }
            get { return _Desc; }
        }
        public double Amount
        {
            set
            {
                _Amount = value;
            }
            get
            {
                return _Amount;
            }
        }
        public int AmountEmployee
        {
            get
            {
                return _AmountEmployee;
            }
        }
        public string AmountEmployeeName
        {
            get
            {
                return _AmountEmployeeName;
            }
        }
        public string AmountComment
        {
            set
            {
                _AmountComment = value;
            }
            get
            {
                return _AmountComment;
            }
        }
        public DateTime AmountDate
        {
            set
            {
                _AmountDate = value;
            }
            get
            {
                return _AmountDate;
            }
        }
        public double ParentPerc
        {
            set
            {
                _ParentPerc = value;
            }
            get
            {
                return _ParentPerc;
            }
        }
        public bool IsSecondary
        {
            set
            {
                _IsScondary = value;
            }
            get
            {
                return _IsScondary;
            }
        }

        public double TotalContractElementAchieved
        {
            set
            {
                _TotalContractElementAchieved = value;
            }
            get
            {
                return  _TotalContractElementAchieved;
            }
        }
        public bool IsOverAchieved
        {
            set
            {
                _IsOverAchieved = value;
            }
            get 
            {
                return _IsOverAchieved;
            }
        }
        public bool AllProcess
        {
            set
            {
                _AllProcess = value;
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
        public CellDb CellDb
        {
            set
            {
                _CellDb = value;
            }
            get
            {
                return _CellDb;
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
                return _ContractTable;
            }
        }
        public   static DataTable ContractProcessTable
        {
            set
            {
                _ContractProcessTable = value;
            }
            get
            {
                return _ContractProcessTable;
            }
 
        }
        public string CellStr
        {
            set
            {
                _CellStr = value;

            }
        }
        public DataTable CategoryTypeTable
        {
            set
            {
                _CategoryTypeTable = value;
            }
        }
        public bool OnlyZeros
        {
            set
            {
                _OnlyZeros = value;
            }
        }

        public string ProcessStr
        {
            set
            {
                _ProcessSttr = value;
            }
        }
        public int ContractorID
        {
            set
            {
                _ContractorID = value;
            }
        }
        public double MaxUnitPrice
        {
            set
            {
                _MaxUnitPrice = value;
            }
        }
        public double MinUnitPrice
        {
            set
            {
                _MinUnitprice = value;
            }
        }
        public bool AsignedToContract
        {
            set
            {
                _AsignedToContract = value; 
            }
        }
        public int CellFamilyID
        {
            set
            {
                _CellFamilyID = value;
            }
        }
        public DataTable ProcessTable
        {
            set
            {
                _ProcessTable = value;
            }

        }
        public string EditEstimationStr
        {
            get
            {
                string Returned = "update  RPProcess ";
                Returned = Returned + " set ProcessAmount=" + _Amount;
                Returned = Returned + ",ProcessAmountUsrUpd =" + SysData.CurrentUser.ID;
                Returned = Returned + ",TimUpd = GetDate()";
                Returned = Returned + ",UsrUpd =" + SysData.CurrentUser.ID;
                Returned = Returned + " where ProcessID = " + _ID;
                return Returned;
            }
        }
        public string OverLappeContractdElementValueStr
        {
            get
            {
                string Returned = "SELECT  dbo.RPProcess.ProcessAmount,dbo.RPContractElementProcess_IProcess.ProcessID, SUM(RPContractorInvoiceElement_1.TotalAcheivedAmount) AS TotalContractElementAcheivedAmount " +
                       " FROM     RPProcess "+
                       " inner join     dbo.RPContractElementProcess_IProcess "+
                       " on RPProcess.ProcessID = dbo.RPContractElementProcess_IProcess.ProcessID " +
                       " INNER JOIN  dbo.RPContractElementProcess ON dbo.RPContractElementProcess_IProcess.ContractElementID = dbo.RPContractElementProcess.ContractElementID INNER JOIN "+
                       " (SELECT     ContractElementID, MAX(InvoiceElementID) AS MaxInvoiceElement "+
                       " FROM         dbo.RPContractorInvoiceElement "+
                       " GROUP BY ContractElementID) AS derivedtbl_1 ON dbo.RPContractElementProcess.ContractElementID = derivedtbl_1.ContractElementID INNER JOIN "+
                       " dbo.RPContractorInvoiceElement AS RPContractorInvoiceElement_1 ON derivedtbl_1.MaxInvoiceElement = RPContractorInvoiceElement_1.InvoiceElementID AND  "+
                       " derivedtbl_1.ContractElementID = RPContractorInvoiceElement_1.ContractElementID "+
                       " GROUP BY dbo.RPContractElementProcess_IProcess.ProcessID,dbo.RPProcess.ProcessAmount  ";
                return Returned;
 
            }
        }
        public string OverLapedProcess
        {
            get
            {
                string Returned = "SELECT dbo.RPContractElementProcess.ProcessID "+
                    ", SUM(dbo.RPContractorInvoiceElement.TotalAcheivedAmount) AS TotalAchievedAmount "+
                     " ,dbo.RPProcess.ProcessAmount "+
                     " FROM  dbo.RPContractorInvoiceElement INNER JOIN "+
                     " (SELECT ContractElementID, MAX(InvoiceElementID) AS CurrentInvoiceElement "+
                     " FROM   dbo.RPContractorInvoiceElement AS RPContractorInvoiceElement_1 "+
                     " GROUP BY ContractElementID) AS MaxInvoiceElementTAble ON "+
                     " dbo.RPContractorInvoiceElement.InvoiceElementID = MaxInvoiceElementTAble.CurrentInvoiceElement AND  "+
                     " dbo.RPContractorInvoiceElement.ContractElementID = MaxInvoiceElementTAble.ContractElementID INNER JOIN "+
                     " dbo.RPContractElementProcess ON dbo.RPContractorInvoiceElement.ContractElementID = dbo.RPContractElementProcess.ContractElementID INNER JOIN "+
                     " dbo.RPProcess ON dbo.RPContractElementProcess.ProcessID = dbo.RPProcess.ProcessID "+
                     " GROUP BY dbo.RPContractElementProcess.ProcessID, dbo.RPProcess.ProcessAmount "+
                     " HAVING      (SUM(dbo.RPContractorInvoiceElement.TotalAcheivedAmount) - dbo.RPProcess.ProcessAmount > 2) and RPProcess.ProcessAmount > 0";
                Returned = "SELECT ProcessID "+
                    ",TotalContractElementAcheivedAmount AS TotalAchievedAmount "+
                     " ,ProcessAmount "+
                     " from (" + OverLappeContractdElementValueStr + ") as OverAchievedTable  "+
                     " where ProcessAmount > 0 and (TotalContractElementAcheivedAmount - ProcessAmount)>2 ";
                return Returned;
            }
        }
       
        public  string SearchStr
        {
            get
            {

                string strEmployee = "SELECT  dbo.HRApplicant.ApplicantID, dbo.HRApplicantWorker.ApplicantCode, dbo.HRApplicant.ApplicantFirstName, dbo.HRApplicant.ApplicantFamousName, " +
                  " dbo.HRApplicant.ApplicantNameComp, dbo.HRApplicantWorker.ApplicantUser, dbo.HRApplicantWorker.ApplicantStatusID " +
                  ",dbo.HRApplicantWorker.ApplicantEndDate  " +
                  " FROM   dbo.HRApplicant INNER JOIN " +
                  " dbo.HRApplicantWorker ON dbo.HRApplicant.ApplicantID = dbo.HRApplicantWorker.ApplicantID ";
                string Returned = "SELECT  dbo.RPProcess.ProcessID, dbo.RPProcess.ProcessDesc,dbo.RPProcess.ProcessAmount,dbo.RPProcess.ProcessAmountUsrUpd,"+
                    "  dbo.RPProcess.ProcessAmountEmployee, dbo.RPProcess.ProcessAmountDate, dbo.RPProcess.ProcessAmountComment "+
                    " ,dbo.RPProcess.ProcessParentID, dbo.RPProcess.ProcessFamilyID,ProcessParentPerc,ProcessIsSecondary, " +
                    " dbo.RPProcess.ProcessType, dbo.RPProcess.CellID, dbo.RPProcess.StartDate, dbo.RPProcess.EndDate, dbo.RPProcess.EstimationDate " +
                    ",ProcessTypeTable.*,ProcessEmployeeTable.ApplicantID as ProcessEmployeeID,ProcessEmployeeTable.ApplicantFirstName  as ProcessEmployeeName " +
                    ",OverLappedContractElementTable.TotalContractElementAcheivedAmount " +
                    ",case when OverLappedContractElementTable.ProcessID is not null and OverLappedContractElementTable.TotalContractElementAcheivedAmount > dbo.RPProcess.ProcessAmount+2 and dbo.RPProcess.ProcessAmount > 0 then 1 else 0 end as IsOverAchieved   " +
                    " FROM   dbo.RPProcess inner join (" + ProcessTypeDb.SearchStr + ") as ProcessTypeTable "+
                    " on RPProcess.ProcessType = ProcessTypeTable.ProcessTypeID "+
                    " left outer join ("+ strEmployee +") as ProcessEmployeeTable "+
                    " on dbo.RPProcess.ProcessAmountEmployee = ProcessEmployeeTable.ApplicantID "+
                    " left outer join ("+ OverLappeContractdElementValueStr +") as OverLappedContractElementTable "+
                    " on dbo.RPProcess.ProcessID = OverLappedContractElementTable.ProcessID ";
                return Returned;
                    
 
            }
        }

        #endregion

        #region Private Methodsda

        void SetOldRelatedProcesss(string strParentID,DataTable dtTemp, ref string strIDs)
        {
            DataRow[] arrDR = dtTemp.Select("ProcessParentID = " + strParentID);
            string strTempParent;
            foreach (DataRow objDR in arrDR)
            {
                if (strIDs != "")
                    strIDs = strIDs + ",";
                strTempParent = objDR["ProcessID"].ToString();
                strIDs = strIDs + objDR["ProcessID"].ToString();
                SetOldRelatedProcesss(strTempParent, dtTemp, ref strIDs);
            }

 
        }

       
      

        void SetRecursiveTable(string strParentProcessID,ref DataTable dtDist,DataTable dtSource)
        {
            DataRow[] arrDr = dtSource.Select("ProcessID=" + strParentProcessID);
            if (arrDr.Length > 0)
            {
                string strTemp = arrDr[0]["ProcessParentID"].ToString();
                dtDist.ImportRow(arrDr[0]);
                if (strTemp != strParentProcessID)
                {
                    SetRecursiveTable(strTemp, ref dtDist, dtSource);
                }
            }
        }
        void SetData(DataRow objDR)
        {
            _ID = int.Parse(objDR["ProcessID"].ToString());
            _ParentID = int.Parse(objDR["ProcessParentID"].ToString());
            _FamilyID = int.Parse(objDR["ProcessFamilyID"].ToString());
            _TypeID = int.Parse(objDR["ProcessType"].ToString());
            _CellID = int.Parse(objDR["CellID"].ToString());
            _Amount = double.Parse(objDR["ProcessAmount"].ToString());
            try
            {
                _AmountUsrUpd = int.Parse(objDR["ProcessAmountUsrUpd"].ToString());
            }
            catch
            {
            }
            _AllProcess = true;
            _Desc = objDR["ProcessDesc"].ToString();

            DataRow[] arrDR = CellDb.CellTable.Select("CellID=" + _CellID);


            if (arrDR.Length > 0)
                _CellDb = new CellDb(arrDR[0]);
            if (objDR.Table.Columns["TotalContractElementAcheivedAmount"] != null &&
                objDR["TotalContractElementAcheivedAmount"].ToString() != "")
                _TotalContractElementAchieved = double.Parse(objDR["TotalContractElementAcheivedAmount"].ToString());
            if (objDR.Table.Columns["IsOverAchieved"] != null && objDR["IsOverAchieved"].ToString() != "")
            {
                _IsOverAchieved = objDR["IsOverAchieved"].ToString() == "1";
            }
            if (objDR.Table.Columns["ProcessEmployeeID"] != null && objDR["ProcessEmployeeID"].ToString() != "")
                _AmountEmployee = int.Parse(objDR["ProcessEmployeeID"].ToString());
            if (objDR.Table.Columns["ProcessEmployeeName"] != null)
                _AmountEmployeeName = objDR["ProcessEmployeeName"].ToString();
            if (objDR.Table.Columns["ProcessAmountDate"] != null && objDR["ProcessAmountDate"].ToString() != "")
                _AmountDate = DateTime.Parse(objDR["ProcessAmountDate"].ToString());
            if (objDR.Table.Columns["ProcessAmountComment"] != null && objDR["ProcessAmountComment"].ToString() != "")
                _AmountComment =objDR["ProcessAmountComment"].ToString() ;

        }
        #endregion

        #region Public Methods

        public override void Add()
        {
            _FamilyID = _FamilyID == 0 ? _ID : _FamilyID;
            _ParentID = _ParentID == 0 ? _ID : _ParentID;
            int intIsSecondary = _IsScondary ? 1 : 0;
            double dblStartDate = _StartDate.ToOADate() - 2;
            double dblEndDate = _EndDate.ToOADate() - 2;
            double dblEstimationDate = _EstimationDate.ToOADate() - 2;
            dblStartDate = dblStartDate > 0 ? dblStartDate : 0;
            dblEstimationDate = dblEstimationDate > 0 ? dblEstimationDate : 0;
            
            //double dblEstimationDate = _EstimationDate.ToOADate() - 2;
            int intAmountUser = _Amount == 0 ? 0 : SysData.CurrentUser.ID;
            string strSql = "insert into RPProcess (ProcessType, ProcessDesc,CellID, StartDate, EstimationDate,ProcessAmount,"+
                "ProcessAmountUsrUpd, ProcessParentID, ProcessFamilyID,ProcessParentPerc,ProcessIsSecondary,  UsrIns, TimIns) values(";
            strSql = strSql  + _TypeID + ",'"+_Desc+"'," + _CellID + "," + dblStartDate + ","+ dblEstimationDate + "," + _Amount +"," + 
                intAmountUser +","+_ParentID+","+_FamilyID+"," + _ParentPerc + "," + intIsSecondary +"," + SysData.CurrentUser.ID + ",Getdate())";
            if (_ParentID == 0)
            {
                _ID = SysData.SharpVisionBaseDb.InsertIdentityTable(strSql);
                strSql = "update RPProcess set ProcessParentID = " + _ID + ", ProcessFamilyID =" + _ID;
                strSql = strSql + " where ProcessID = " + _ID;
                SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
            }
            else
                _ID = SysData.SharpVisionBaseDb.InsertIdentityTable(strSql);



        }

        public override void Edit()
        {
            _FamilyID = _FamilyID == 0 ? _ID : _FamilyID;
            _ParentID = _ParentID == 0 ? _ID : _ParentID;
            int intIsSecondary = _IsScondary ? 1 : 0;
            string strSql = "update  RPProcess ";
            strSql = strSql + " set ProcessType=" + _TypeID;
            strSql = strSql + ",CellID=" + _CellID;

            strSql = strSql + ",ProcessDesc ='" + _Desc + "'";
            //strSql = strSql + ",ProcessAmount=" + _Amount;
            strSql = strSql + ",ProcessParentID =" + _ParentID;
            strSql = strSql + ",ProcessFamilyID=" + _FamilyID;
            strSql = strSql + ",ProcessParentPerc=" + _ParentPerc;
            strSql = strSql + ",ProcessIsSecondary=" + intIsSecondary;
          
            strSql = strSql + ",TimUpd = GetDate()";
            strSql = strSql + ",UsrUpd =" + SysData.CurrentUser.ID;
            strSql = strSql + " where ProcessID = " + _ID;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
            strSql = "select * from RPProcess where ProcessFamilyID in " + 
                " (select ProcessFamilyID from RPProcess where ProcessParentID=" + _ID + " and ProcessID <> " + _ID + " and ProcessFamilyID <> " + _FamilyID  + ")";
            DataTable dtTemp = SysData.SharpVisionBaseDb.ReturnDatatable(strSql);

            if (dtTemp.Rows.Count == 0)
                return;
            string strIDs = "";
            SetOldRelatedProcesss(_ID.ToString(), dtTemp, ref strIDs);
            strSql = "Update RPProcess set ProcessFamilyID = " + _FamilyID + " where ProcessID in ( " + strIDs + ")";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);


            
        }

        public void EditEstimation()
        {
           
            SysData.SharpVisionBaseDb.ExecuteNonQuery(EditEstimationStr);
        }
        public void EditEstimationCol()
        {
            if (_ProcessTable == null || _ProcessTable.Rows.Count == 0)
                return;
            ProcessDb objDb ;
            string[] arrStr = new string[_ProcessTable.Rows.Count];
            int intIndex = 0;
            foreach (DataRow objDr in _ProcessTable.Rows)
            {

                objDb = new ProcessDb(objDr);
                arrStr[intIndex] = objDb.EditEstimationStr;

                intIndex++;
            }
            SysData.SharpVisionBaseDb.ExecuteNonQuery(arrStr);
        }
        public void JoinCategoryType()
        {
            if (_CategoryTypeTable == null)
                return;
            string[] arrStr = new string[_CategoryTypeTable.Rows.Count + 1];
            arrStr[0] = "delete from RPProcessCategoryType where ProcessID="+_ID;
            int intIndex = 1;
            foreach (DataRow objDr in _CategoryTypeTable.Rows)
            {
                arrStr[intIndex] = "INSERT INTO RPProcessCategoryType (ProcessID, CategoryID, " +
                     "Unit,Amount,AllowedScrapPerc) VALUES (" +
                     _ID + "," + objDr["CategoryID"].ToString() + "," +
                     objDr["Unit"].ToString() + "," + objDr["Amount"].ToString() + "," + objDr["AllowedScrapPerc"].ToString() + ")";
                intIndex++;
            }
            SysData.SharpVisionBaseDb.ExecuteNonQuery(arrStr);
        }
        public override void Delete()
        {
            string strSql = "delete from  RPProcess where ProcessID=" + _ID;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }

        public override DataTable Search()
        {
            string strSql =SearchStr + " WHERE 1=1 ";
            //if (!_AllProcess)
            //    strSql = strSql + " and RPProcess.ProcessAmount = 0";
            if (_ID != 0)
                strSql = strSql + " and ProcessID = " + _ID.ToString();
            else
            {

                if (_ParentID != 0)
                    strSql = strSql + "  and ProcessParentID = " + _ParentID;
                if (_FamilyID != 0)
                    strSql = strSql + " and ProcessFamilyID = " + _FamilyID;
                if (_CellID != 0)
                    strSql = strSql + " and RPProcess.cellID = " + _CellID;
                if (_OnlyZeros)
                    strSql = strSql + " and dbo.RPProcess.ProcessAmount = 0 ";
                if (_CellStr != null && _CellStr != "")
                { 
                    strSql = strSql + " and dbo.RPProcess.CellID in ("+ _CellStr +")";
                }
                if(_CellFamilyID != 0)
                    strSql = strSql + " and dbo.RPProcess.CellID "+
                        "in (select CellID from RPCell where CellFamilyID = "+ _CellFamilyID +")";
                if (_TypeID != 0)
                    strSql = strSql + " and dbo.RPProcess.ProcessType = " + _TypeID;
                if (_AsignedToContract)
                {
                    strSql = strSql + " and RPProcess.ProcessID in ( SELECT ProcessID FROM dbo.RPContractElementProcess )";
                }
                if (_Desc != null && _Desc != "")
                    strSql += " and   dbo.RPProcess.ProcessDesc like '%"+ _Desc +"%'";
            }

            strSql = "select top 1000 * from (" + strSql +") as NativeTable "; 
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);

        }
        public string GetProcessStr()
        {
            DataTable dtTemp = Search();
            string strReturned = "";
            int intCount = 0;
            foreach (DataRow objDr in dtTemp.Rows)
            {
                intCount++;
                if (strReturned != "")
                    strReturned = strReturned + ",";
                strReturned = strReturned + objDr["ProcessID"].ToString();
                if (intCount > 200)
                    break;
            }
            return strReturned;

        }
        public DataTable GetProcessCategories()
        {
            string strSql = "SELECT dbo.RPProcessCategory.ID, dbo.RPProcessCategory.ProcessID, dbo.RPProcessCategory.CategoryID, dbo.RPProcessCategory.Amount, " +
                         " dbo.RPProcessCategory.UnitCost, dbo.RPProcessCategory.UnitCostCurrency,dbo.RPProcessCategory.UnitID,"+
                         "RPCategory.CategoryID , RPCategory.CategoryCode , RPCategory.CategoryNameA , RPCategory.CategoryNameE , RPCategory.MeasureStanderdUnit," +
                         " RPCategory.IsRaw,CategoryTypeID , CategoryTypeNameA , CategoryTypeNameE  " +
                         " FROM  dbo.RPProcessCategory INNER JOIN " +
                         " dbo.RPCategory ON dbo.RPProcessCategory.CategoryID = dbo.RPCategory.CategoryID  " +
                         "inner Join RPCategoryType on RPCategory.CategoryType = RPCategoryType.CategoryTypeID " +
                         " where RPProcessCategory.ProcessID=" + _ID;
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        public DataTable GetElementContract()
        {
            string strSql = " SELECT distinct RPContractElementProcess.ProcessID,ContractTable.* " +
                            " FROM  dbo.RPContractElementProcess inner join RPContractElement "+
                            " on RPContractElement.ContractElementID = RPContractElementProcess.ContractElementID  "+
                            " inner join (" + //ContractDb.SearchStr +
                            ") as ContractTable "+
                            "ON ContractTable.ContractID = dbo.RPContractElement.ContractID " +
                            "  "+
                            " WHERE (1=1)  ";
            if (_ProcessSttr != null && _ProcessSttr != "")
            {
                strSql = strSql + " AND (dbo.RPContractElementProcess.ProcessID in(" + _ProcessSttr + "))";
            }
            else
                strSql = strSql + " and 1=0 ";
            if (_ContractorID != 0)
                strSql = strSql + " and ContractTable.ContractorID = " + _ContractorID;


            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        public DataTable GetProcessContractProcess()
        {
            #region Hash
            //string strSql = "SELECT distinct dbo.RPProcess.ProcessID, dbo.RPProcess.ProcessDesc, dbo.RPProcess.ProcessParentID, dbo.RPProcess.ProcessFamilyID, " +
            //                " dbo.RPProcess.ProcessType, dbo.RPProcess.CellID, dbo.RPProcess.StartDate, dbo.RPProcess.EndDate, dbo.RPProcess.EstimationDate, " +
            //                " dbo.RPProcess.ProcessAmount,dbo.RPProcess.ProcessAmountUsrUpd,"+
            //                " dbo.RPContractProcess.ContractID,"+
            //                " dbo.RPContractProcess.UnitPrice, dbo.RPContractProcess.UnitPriceCurrency, " +
            //                " dbo.RPContractProcess.EstimatedCountintg, dbo.RPContractProcess.RealCounting, dbo.RPContractProcess.TotalAchievedPercent, " +
            //                " dbo.RPContractProcess.StartDate AS ProcessStartDate, dbo.RPContractProcess.EndDate AS ProcessEndDate, " +
            //                " dbo.RPContractProcess.EstimatedDate AS ProcessEstimatedDate, dbo.RPContractProcess.ContractProcessID, " +
            //                " dbo.RPContractProcess.ContractProcessDesc,RPContractProcess.AssignmentDate,RPCellType.CellTypeOrder " +
            //                " FROM dbo.RPProcess INNER JOIN " +
            //                " dbo.RPProcessContract ON dbo.RPProcess.ProcessID = dbo.RPProcessContract.ProcessID INNER JOIN " +
            //                " dbo.RPContractProcess ON dbo.RPProcessContract.ContractID = dbo.RPContractProcess.ContractID " +
            //                " INNER JOIN " +
            //                " dbo.RPCell ON dbo.RPProcess.CellID = dbo.RPCell.CellID INNER JOIN " +
            //                " dbo.RPCellType ON dbo.RPCell.CellType = dbo.RPCellType.CellTypeID ";
            #endregion
            ContractElementDb objContractElementDb = new ContractElementDb();
            string strSql = "select ContractProcessTable.*,CellTable.CellTypeOrder  from (" + objContractElementDb.SearchStr + ") as ContractProcessTable " +
                "  inner join " +
                " (" + CellDb.SearchStr + ") as Celltable on ContractProcessTable.CellID = CellTable.CellID ";
            strSql = strSql + " where (ContractProcessTable.ProcessID in(" + _ProcessSttr + "))  ";
            if (_MinUnitprice != 0 && _MaxUnitPrice != 0)
            {
                strSql = strSql + " and  (ContractProcessTable.UnitPrice>" + _MaxUnitPrice + " or ContractProcessTable.UnitPrice <" + _MinUnitprice + ")";
            }
            strSql = strSql + " order by CellTypeOrder,ProcessType,ContractElementDesc,ProcessDesc ";
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        public static string GetOverAchievedProcesses()
        {
            string strSql = "SELECT dbo.RPProcess.ProcessID, dbo.RPProcess.ProcessAmount,dbo.RPProcess.ProcessAmountUsrUpd, SUM(dbo.RPContractElement.RealCounting) AS AchievedAmount " +
                            " FROM   dbo.RPProcess INNER JOIN "+
                            "  RPContractElementProcess on RPContractElementProcess.ProcessID = RPProcess.ProcessID  "+
                            " inner join RPContractElement on RPContractElement.ContractElementID = RPContractElementProcess.ContractElementID "+
                            " GROUP BY dbo.RPProcess.ProcessID, dbo.RPProcess.ProcessAmount,RPProcess.ProcessAmountUsrUpd " +
                            " HAVING      (dbo.RPProcess.ProcessAmount <> 0) AND (SUM(dbo.RPContractElement.RealCounting) > dbo.RPProcess.ProcessAmount)";
            DataTable dtTemp = SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
            
            string strProcessIDs = "";
            foreach (DataRow objDr in dtTemp.Rows)
            {
                if (strProcessIDs != "")
                    strProcessIDs = strProcessIDs + ",";
                strProcessIDs = strProcessIDs + objDr["ProcessID"].ToString();
            }
            return strProcessIDs;
            

        }
        
        
        #endregion
    }
}
