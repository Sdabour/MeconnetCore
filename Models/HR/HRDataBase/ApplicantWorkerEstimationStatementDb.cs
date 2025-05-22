using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using SharpVision.SystemBase;
namespace SharpVision.HR.HRDataBase
{
    public class ApplicantWorkerEstimationStatementDb
    {
        #region Private Data
        protected int _ID;
        protected int _Applicant;
        protected int _EstimationStatement;
        protected int _JobNature;
        protected int _SubSector;
        protected int _JobCategoryEstimation;
        protected int _CostCenter;
        protected string _Remarks;
        protected string _EstimationStatementIDs;
        protected bool _EstimationStatementIsSum;
        protected double _EstimationValue;
        protected double _EstimationValuePrec;

        string _ApplicantIDs;
        int _ApplicantSearch;
        int _EstimationStatementSearch;


        byte _OperationStatus;
        double _EstimationValueFrom;
        double _EstimationValueTo;
        string _SectorOnlyIDs;
        string _WorkUpToNowSectorIDs;
        #endregion
        #region Constructors
        public ApplicantWorkerEstimationStatementDb()
        {
        }
        public ApplicantWorkerEstimationStatementDb(DataRow ObjDr)
        {
            SetData(ObjDr);
        }
        public ApplicantWorkerEstimationStatementDb(int intEstimationStatementID, int intApplicantWorkerID)
        {
            _ApplicantSearch = intApplicantWorkerID;
            _EstimationStatementSearch = intEstimationStatementID;
            DataTable dtTemp = Search();
            if (dtTemp.Rows.Count != 0)
                SetData(dtTemp.Rows[0]);
        }
        #endregion
        #region Public Properties
        public int ID
        {
            set { _ID = value; }
            get { return _ID; }
        }
        public int Applicant
        {
            set { _Applicant = value; }
            get { return _Applicant; }
        }
        public int EstimationStatement
        {
            set { _EstimationStatement = value; }
            get { return _EstimationStatement; }
        }
        public bool EstimationStatementIsSum
        {
            set { _EstimationStatementIsSum = value; }
            get { return _EstimationStatementIsSum; }
        }
        public int JobNature
        {
            set { _JobNature = value; }
            get { return _JobNature; }
        }
        public int CostCenter
        {
            set { _CostCenter=value; }
            get { return _CostCenter; }
        }
        public string Remarks
        {
            set { _Remarks = value; }
            get { return _Remarks; }
        }
        string _Remarks1;
        public string Remarks1
        {
            set { _Remarks1 = value; }
            get { return _Remarks1; }
        }
        string _Remarks2;
        public string Remarks2
        {
            set { _Remarks2 = value; }
            get { return _Remarks2; }
        }
        string _Remarks3;
        public string Remarks3
        {
            set { _Remarks3 = value; }
            get { return _Remarks3; }
        }
        string _Remarks4;
        public string Remarks4
        {
            set { _Remarks4 = value; }
            get { return _Remarks4; }
        }
        string _Remarks5;
        public string Remarks5
        {
            set { _Remarks5 = value; }
            get { return _Remarks5; }
        }
        public int JobCategoryEstimation
        {
            set { _JobCategoryEstimation = value; }
            get { return _JobCategoryEstimation; }
        }
        public int SubSector
        {
            set { _SubSector = value; }
            get { return _SubSector; }
        }
        public double EstimationValue
        {
            set { _EstimationValue = value; }
            get { return _EstimationValue; }
        }
        public double EstimationValuePrec
        {
            set { _EstimationValuePrec = value; }
            get { return _EstimationValuePrec; }
        }
        public string ApplicantIDs
        {
            set
            { _ApplicantIDs = value; }
        }
        public string EstimationStatementIDs
        {
            set
            { _EstimationStatementIDs = value; }
        }
        public byte OperationStatus{set { _OperationStatus = value; }}
        public double EstimationValueFrom { set { _EstimationValueFrom = value; } }
        public double EstimationValueTo { set { _EstimationValueTo = value; } }
        public string SectorOnlyIDs { set { _SectorOnlyIDs = value; } }
        public string WorkUpToNowSectorIDs { set { _WorkUpToNowSectorIDs = value; } }
        byte _WorkUpToNowInSector;
        public byte WorkUpToNowInSector { set { _WorkUpToNowInSector = value; } }

        DataTable _ElementTable;
        public DataTable ElementTable
        {
            set { _ElementTable = value; }
        }
        public static string EstimationPercStr
        {
            get
            {
                string Returned = @"SELECT        dbo.HRApplicantWorkerEstimationStatement.ApplicantEstimationStatementID AS ApplicantEstimationStatement, 
                         CASE WHEN dbo.HRApplicantWorkerEstimationStatement.EstimationStatementIsSum = 1 THEN dbo.HRApplicantWorkerEstimationStatement.EstimationValuePrec ELSE derivedtbl_1.DetailsValue * 100 END AS EstimationPerc, dbo.HRApplicantWorkerEstimationStatement.EstimationStatement
,dbo.HRApplicantWorkerEstimationStatement.Applicant 

FROM            dbo.HRApplicantWorkerEstimationStatement LEFT OUTER JOIN
                             (SELECT        ApplicantEstimationStatementID, SUM(CurrentEstimationValue) / CASE WHEN SUM(CurrentElementValue) = 0 THEN 1 ELSE SUM(CurrentElementValue) END AS DetailsValue
                                FROM            (SELECT        HRApplicantWorkerEstimationStatement_1.ApplicantEstimationStatementID, CASE WHEN dbo.HRApplicantWorkerEstimationStatementElement.ElementIsFuzzyValue = 0 AND 
                                                                                    dbo.HRApplicantWorkerEstimationStatementElement.EstimationValue > 0 THEN dbo.HRApplicantWorkerEstimationStatementElement.EstimationValue WHEN dbo.HRApplicantWorkerEstimationStatementElement.ElementIsFuzzyValue
                                                                                     = 1 THEN dbo.HRFuzzyEstimationElementValue.AVGValue ELSE 0 END AS CurrentEstimationValue, CASE WHEN dbo.HRApplicantWorkerEstimationStatementElement.ElementIsFuzzyValue = 0 AND 
                                                                                    dbo.HRApplicantWorkerEstimationStatementElement.EstimationValue > 0 THEN dbo.HRApplicantWorkerEstimationStatementElement.ElementValue WHEN dbo.HRApplicantWorkerEstimationStatementElement.ElementIsFuzzyValue
                                                                                     = 1 THEN 100 ELSE 0 END AS CurrentElementValue, CASE WHEN dbo.HRApplicantWorkerEstimationStatementElement.ElementIsFuzzyValue > 0 OR
                                                                                    dbo.HRApplicantWorkerEstimationStatementElement.EstimationValue > 0 THEN 1 ELSE 0 END AS CurrentEstimationElementCount
                                                           FROM            dbo.HRApplicantWorkerEstimationStatement AS HRApplicantWorkerEstimationStatement_1 INNER JOIN
                                                                                    dbo.HRApplicantWorkerEstimationStatementElement ON 
                                                                                    HRApplicantWorkerEstimationStatement_1.ApplicantEstimationStatementID = dbo.HRApplicantWorkerEstimationStatementElement.ApplicantEstimationStatement LEFT OUTER JOIN
                                                                                    dbo.HRFuzzyEstimationElementValue ON dbo.HRApplicantWorkerEstimationStatementElement.ElementFuzzyValue = dbo.HRFuzzyEstimationElementValue.ID) AS EstimationElementTable
                                GROUP BY ApplicantEstimationStatementID) AS derivedtbl_1 ON dbo.HRApplicantWorkerEstimationStatement.ApplicantEstimationStatementID = derivedtbl_1.ApplicantEstimationStatementID";
                Returned = @"SELECT        ApplicantEstimationStatementID AS ApplicantEstimationStatement, EstimationValue AS EstimationPerc, EstimationStatement, Applicant
FROM            dbo.HRApplicantWorkerEstimationStatement";
                return Returned;
            }
        }
        public string ElementTotalValue
        {
            get
            {
                string strElement = @"SELECT        dbo.HRApplicantWorkerEstimationStatement.ApplicantEstimationStatementID, CASE WHEN (dbo.HRApplicantWorkerEstimationStatementElement.EstimationValue = - 1 OR
                         dbo.HRApplicantWorkerEstimationStatementElement.ElementValue = 0) AND 
                         dbo.HRApplicantWorkerEstimationStatementElement.ElementIsFuzzyValue = 0 THEN 0 WHEN dbo.HRApplicantWorkerEstimationStatementElement.ElementIsFuzzyValue = 1 THEN dbo.HRFuzzyEstimationElementValue.AVGValue
                          / 100 WHEN dbo.HRApplicantWorkerEstimationStatementElement.EstimationValue <> - 1 AND dbo.HRApplicantWorkerEstimationStatementElement.ElementValue <> 0 AND 
                         dbo.HRApplicantWorkerEstimationStatementElement.ElementIsFuzzyValue = 0 THEN dbo.HRApplicantWorkerEstimationStatementElement.EstimationValue / dbo.HRApplicantWorkerEstimationStatementElement.ElementValue ELSE
                          0 END AS ElementEstimationValue, dbo.HRApplicantWorkerEstimationStatementElement.ElementIsFuzzyValue, CASE WHEN ElementID IS NULL THEN 1 ELSE 0 END AS IsFlexableElement, 
                         dbo.HRApplicantWorkerEstimationStatementElement.ElementWeight, ISNULL(dbo.HRApplicantWorkerEstimationStatement.StatementFreeElementPerc, 0) AS StatementFreeElementPerc,   dbo.HRApplicantWorkerEstimationStatementElement.ElementGroupPerc
  FROM            dbo.HRApplicantWorkerEstimationStatement INNER JOIN
                         dbo.HRApplicantWorkerEstimationStatementElement ON 
                         dbo.HRApplicantWorkerEstimationStatement.ApplicantEstimationStatementID = dbo.HRApplicantWorkerEstimationStatementElement.ApplicantEstimationStatement LEFT OUTER JOIN
                         dbo.HRFuzzyEstimationElementValue ON dbo.HRApplicantWorkerEstimationStatementElement.ElementFuzzyValue = dbo.HRFuzzyEstimationElementValue.ID LEFT OUTER JOIN
                         dbo.HRElement ON dbo.HRApplicantWorkerEstimationStatementElement.Element = dbo.HRElement.ElementID
WHERE        (dbo.HRApplicantWorkerEstimationStatement.ApplicantEstimationStatementID = " + ID + ")";
                //ApplicantEstimationStatementID,TotalEstimationValue
                string Returned = @"SELECT        ApplicantEstimationStatementID, SUM(ElementEstimationValue * (ISNULL(ElementWeight, 0) / 100) * CASE WHEN IsFlexableElement = 1 THEN StatementFreeElementPerc / 100 ELSE (100 - StatementFreeElementPerc) end
 *(CASE WHEN IsFlexableElement = 1 THEN 1  ELSE (ElementGroupPerc / 100) END)) AS TotalEstimationValue
FROM (" + strElement + @") as ElementTable
GROUP BY ApplicantEstimationStatementID
HAVING(ApplicantEstimationStatementID = " + ID + ")";
                return Returned;
            }
        }
        public static string SearchStr
        {
            get
            {
                //string strApplicantSubSector = "SELECT     ApplicantID as CurrentSubSectorWorkerID, SubSectorID "+
                //        " FROM   dbo.HRApplicantWorkerCurrentSubSector ";
                //string strApplicantCostCenter = "SELECT     Applicant as CostCenterWorkerID, CostCenter "+
                //          " FROM         dbo.HRApplicantWorkerCostCenter ";
                string strDetailedValue  = @"SELECT        ApplicantEstimationStatementID, SUM(CurrentEstimationValue) / CASE WHEN SUM(CurrentElementValue) = 0 THEN 1 ELSE SUM(CurrentElementValue) END AS Expr2
FROM            (SELECT        dbo.HRApplicantWorkerEstimationStatement.ApplicantEstimationStatementID, CASE WHEN dbo.HRApplicantWorkerEstimationStatementElement.ElementIsFuzzyValue = 0 AND 
                                                    dbo.HRApplicantWorkerEstimationStatementElement.EstimationValue > 0 THEN dbo.HRApplicantWorkerEstimationStatementElement.EstimationValue WHEN dbo.HRApplicantWorkerEstimationStatementElement.ElementIsFuzzyValue
                                                     = 1 THEN dbo.HRFuzzyEstimationElementValue.AVGValue ELSE 0 END AS CurrentEstimationValue, CASE WHEN dbo.HRApplicantWorkerEstimationStatementElement.ElementIsFuzzyValue = 0 AND 
                                                    dbo.HRApplicantWorkerEstimationStatementElement.EstimationValue > 0 THEN dbo.HRApplicantWorkerEstimationStatementElement.ElementValue WHEN dbo.HRApplicantWorkerEstimationStatementElement.ElementIsFuzzyValue
                                                     = 1 THEN 100 ELSE 0 END AS CurrentElementValue, CASE WHEN dbo.HRApplicantWorkerEstimationStatementElement.ElementIsFuzzyValue > 0 OR
                                                    dbo.HRApplicantWorkerEstimationStatementElement.EstimationValue > 0 THEN 1 ELSE 0 END AS CurrentEstimationElementCount
                           FROM            dbo.HRApplicantWorkerEstimationStatement INNER JOIN
                                                    dbo.HRApplicantWorkerEstimationStatementElement ON 
                                                    dbo.HRApplicantWorkerEstimationStatement.ApplicantEstimationStatementID = dbo.HRApplicantWorkerEstimationStatementElement.ApplicantEstimationStatement LEFT OUTER JOIN
                                                    dbo.HRFuzzyEstimationElementValue ON dbo.HRApplicantWorkerEstimationStatementElement.ElementFuzzyValue = dbo.HRFuzzyEstimationElementValue.ID) AS EstimationElementTable
GROUP BY ApplicantEstimationStatementID"; ;
                   strDetailedValue = @" SELECT        TOP (100) PERCENT ApplicantEstimationStatement, SUM(EstimationValue) AS Expr1, SUM(ElementValue) AS TotalElementValue, COUNT(*) AS CountElement, SUM(EstimationValue) / SUM(ElementValue) 
                         * 100 AS DetailedPerc
FROM            dbo.HRApplicantWorkerEstimationStatementElement
GROUP BY ApplicantEstimationStatement ";
                string Returned = " SELECT    HRApplicantWorkerEstimationStatement.ApplicantEstimationStatementID, " +
                                  " HRApplicantWorkerEstimationStatement.Applicant, HRApplicantWorkerEstimationStatement.EstimationStatement," +
                                  " HRApplicantWorkerEstimationStatement.SubSector,HRApplicantWorkerEstimationStatement.JobNature,HRApplicantWorkerEstimationStatement.CostCenter " +
                                  ",HRApplicantWorkerEstimationStatement.Remarks" +
                                  ",HRApplicantWorkerEstimationStatement.Remarks1,HRApplicantWorkerEstimationStatement.Remarks2,HRApplicantWorkerEstimationStatement.Remarks3,HRApplicantWorkerEstimationStatement.Remarks4,HRApplicantWorkerEstimationStatement.Remarks5" +
                                  ", HRApplicantWorkerEstimationStatement.EstimationStatementIsSum, HRApplicantWorkerEstimationStatement.EstimationValue,HRApplicantWorkerEstimationStatement.EstimationValuePrec, " +
                                  " ApplicantWorkerTable.*,EstimationStatementTable.*,JobNatureTypeTable.*,HRApplicantWorkerEstimationStatement.JobCategoryEstimation,JobCategoryEstimationTable.*" +
                                  ""+
                                  " FROM         HRApplicantWorkerEstimationStatement " +
                                  " inner join (" + new ApplicantWorkerDb() { }.SearchStr + ") as ApplicantWorkerTable On ApplicantWorkerTable.ApplicantID = HRApplicantWorkerEstimationStatement.Applicant" +
                                  " inner join (" + EstimationStatementDb.SearchStr + ") as EstimationStatementTable On EstimationStatementTable.EstimationStatementID = HRApplicantWorkerEstimationStatement.EstimationStatement" +
                                  " Left Outer join (" + JobNatureTypeDb.SearchStr + ") as JobNatureTypeTable On JobNatureTypeTable.JobNatureID = HRApplicantWorkerEstimationStatement.JobNature " +
                                  " Left Outer join (" + JobCategoryEstimationDb.SearchStr + ") as JobCategoryEstimationTable On JobCategoryEstimationTable.JobCategoryEstimationID = HRApplicantWorkerEstimationStatement.JobCategoryEstimation " +
                                  " left outer join (" + strDetailedValue + ") as DetailedTable " +
                                  " on dbo.HRApplicantWorkerEstimationStatement.ApplicantEstimationStatementID = DetailedTable.ApplicantEstimationStatement ";
                                  
                                  //" left outer join (" + strApplicantSubSector + ") as CurrentSubSectorTable "+
                                  //" on ApplicantWorkerTable.ApplicantWorkerID = CurrentSubSectorTable.CurrentSubSectorWorkerID" +
                                  //" and  CurrentSubSectorTable.SubsectorID= HRApplicantWorkerEstimationStatement.SubSector " +
                                  //" left outer join   (" + strApplicantCostCenter + ") as CurrentCostCenterTable "+
                                  //" on  ApplicantWorkerTable.ApplicantWorkerID = CurrentCostCenterTable.CostCenterWorkerID "+
                                  //" and HRApplicantWorkerEstimationStatement.CostCenter = CurrentCostCenterTable.CostCenter ";

                return Returned;
            }
        }
        public string AddStr
        {
            get
            {
                int intIsSum = _EstimationStatementIsSum ? 1 : 0;
                string Returned = " INSERT INTO HRApplicantWorkerEstimationStatement "+
                                  " (Applicant, EstimationStatement, EstimationStatementIsSum, EstimationValue,EstimationValuePrec,SubSector," +
                                  " CostCenter,JobNature,JobCategoryEstimation,Remarks, Remarks1, Remarks2, Remarks3,Remarks4, Remarks5, UsrIns, TimIns)" +
                                  " VALUES "+
                                  " (" + _Applicant + "," + _EstimationStatement + "," + intIsSum + "," +
                                  " " + _EstimationValue + "," + _EstimationValuePrec + "," + _SubSector + ","+
                                  " " + _CostCenter + "," + _JobNature + "," + _JobCategoryEstimation +
                                  ",'" + _Remarks+"','" +
                                  _Remarks1 + "','"+ _Remarks2 + "','" + _Remarks3 + "','" + _Remarks4 + "','" + _Remarks5 + "'," + SysData.CurrentUser.ID + ",GetDate())";

                return Returned;
            }
        }
        public string EditStr
        {
            get
            {
                int intIsSum = _EstimationStatementIsSum ? 1 : 0;
                string Returned = " UPDATE    HRApplicantWorkerEstimationStatement "+
                                  "   SET    Applicant =" + _Applicant + "" +
                                  " , EstimationStatement =" + _EstimationStatement + "" +
                                  " , EstimationStatementIsSum =" + intIsSum + "" +
                                  " , EstimationValue =" + _EstimationValue + "" +
                                  " , EstimationValuePrec =" + _EstimationValuePrec + "" +
                                  " , SubSector =" + _SubSector + "" +
                                  " , JobNature =" + _JobNature + "" +
                                  " , CostCenter =" + _CostCenter + "" +
                                  " , Remarks = '" + _Remarks + "'" +
                                   " , Remarks1 = '" + _Remarks1 + "'" +
                                    " , Remarks2 = '" + _Remarks2 + "'" +
                                     " , Remarks3 = '" + _Remarks3 + "'" +
                                     " , Remarks4 = '" + _Remarks4 + "'" +
                                     " , Remarks5 = '" + _Remarks5 + "'" +
                                  " , JobCategoryEstimation = " + _JobCategoryEstimation +""+
                                  " , UsrUpd =" + SysData.CurrentUser.ID + ",  TimUpd=GetDate()" +
                                  " WHERE     (ApplicantEstimationStatementID = "+ _ID +")";

                return Returned;
            }
        }
        public string DeleteStr
        {
            get
            {
                string Returned = " DELETE FROM HRApplicantWorkerEstimationStatement "+
                                  " WHERE     (ApplicantEstimationStatementID = " + _ID + ")";

                return Returned;
            }
        }
        #endregion
        #region Private Methods
        void SetData(DataRow objDr)
        {
            if (objDr["ApplicantEstimationStatementID"].ToString() == "")
                return;
            _ID = int.Parse(objDr["ApplicantEstimationStatementID"].ToString());
            _Applicant = int.Parse(objDr["Applicant"].ToString());
            _EstimationStatement = int.Parse(objDr["EstimationStatement"].ToString());
            if(objDr["EstimationStatementIsSum"].ToString()!="")
            _EstimationStatementIsSum = bool.Parse(objDr["EstimationStatementIsSum"].ToString());
            _EstimationValue = double.Parse(objDr["EstimationValue"].ToString());
            string str = objDr["EstimationValuePrec"].ToString();
            if(objDr["EstimationValuePrec"].ToString()!="")
            _EstimationValuePrec = double.Parse(objDr["EstimationValuePrec"].ToString());//SysUtility.Approximate(double.Parse(objDr["EstimationValuePrec"].ToString()),0.1,ApproximateType.Default);

            if (objDr["SubSector"].ToString() != "")
                _SubSector = int.Parse(objDr["SubSector"].ToString());
            if (objDr["JobNature"].ToString() != "")
                _JobNature = int.Parse(objDr["JobNature"].ToString());

            if (objDr["JobCategoryEstimation"].ToString() != "")
                _JobCategoryEstimation = int.Parse(objDr["JobCategoryEstimation"].ToString());
            if (objDr["CostCenter"].ToString() != "")
                _CostCenter = int.Parse(objDr["CostCenter"].ToString());

            _Remarks = objDr["Remarks"].ToString();
            _Remarks1 = objDr["Remarks1"].ToString();
            _Remarks2 = objDr["Remarks2"].ToString();
            _Remarks3 = objDr["Remarks3"].ToString();
            _Remarks4 = objDr["Remarks4"].ToString();
            _Remarks5 = objDr["Remarks5"].ToString();

        }
        #endregion
        #region Public Methods
        public void Add()
        {
            _ID = SysData.SharpVisionBaseDb.InsertIdentityTable(AddStr);
        }
        public void Edit()
        {
            SysData.SharpVisionBaseDb.ExecuteNonQuery(EditStr);
        }
        public void EditTotalEstimationValue()
        {
            string strSql = @"update   HRApplicantWorkerEstimationStatement set      EstimationValue= ValueTable.TotalEstimationValue
FROM dbo.HRApplicantWorkerEstimationStatement
inner join (" + ElementTotalValue + @") as ValueTable
on HRApplicantWorkerEstimationStatement.ApplicantEstimationStatementID = ValueTable.ApplicantEstimationStatementID
 WHERE(HRApplicantWorkerEstimationStatement.ApplicantEstimationStatementID = " + ID + ") AND(EstimationStatementIsSum = 0)";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public void Delete()
        {
            SysData.SharpVisionBaseDb.ExecuteNonQuery(DeleteStr);
        }
        public DataTable Search()
        {
            string StrSql = SearchStr + " Where 1=1 ";
            if (_Applicant != 0)
                StrSql += " And (Applicant = "+ _Applicant +")";
            if (_EstimationStatement != 0)
                StrSql += " And (EstimationStatement = " + _EstimationStatement + ")";
            if (_ApplicantSearch != 0)
                StrSql += " And (Applicant = " + _ApplicantSearch + ")";
            if (_EstimationStatementSearch != 0)
                StrSql += " And (EstimationStatement = " + _EstimationStatementSearch + ")";
            if (_ApplicantIDs != null && _ApplicantIDs!="")
                StrSql += " And (Applicant in ( " + _ApplicantIDs + "))";
            if (_EstimationStatementIDs != null && _EstimationStatementIDs != "")
                StrSql += " And (EstimationStatement in ( " + _EstimationStatementIDs + "))";

            if (_OperationStatus != 0)
            {                
                if (_OperationStatus == 1) //BW
                {
                    StrSql += @" And (
  CASE WHEN DetailedTable.ApplicantEstimationStatement IS NULL THEN HRApplicantWorkerEstimationStatement.EstimationValuePrec ELSE DetailedTable.DetailedPerc END 
Between " + _EstimationValueFrom + " And " + _EstimationValueTo + " )";
                }
                else if (_OperationStatus == 2) //LessThan
                {
                    StrSql += @" And (
 CASE WHEN DetailedTable.ApplicantEstimationStatement IS NULL THEN HRApplicantWorkerEstimationStatement.EstimationValuePrec ELSE DetailedTable.DetailedPerc END 
<= " + _EstimationValueFrom + " )";
                }
                else if (_OperationStatus == 3) //LargeThan
                {
                    StrSql += @" And ( 
 CASE WHEN DetailedTable.ApplicantEstimationStatement IS NULL THEN HRApplicantWorkerEstimationStatement.EstimationValuePrec ELSE DetailedTable.DetailedPerc END 
>= " + _EstimationValueTo + " )";
                }
                else if (_OperationStatus == 4) //Equal
                {
                    StrSql += @" And (
 CASE WHEN DetailedTable.ApplicantEstimationStatement IS NULL THEN HRApplicantWorkerEstimationStatement.EstimationValuePrec ELSE DetailedTable.DetailedPerc END 
= " + _EstimationValueFrom + " )";
                }
            }
            if (_SectorOnlyIDs != null && _SectorOnlyIDs != "")
            {
                string str = " SELECT     SubSectorID FROM         HRSubSector WHERE     (SectorID IN (" + _SectorOnlyIDs + "))";
                StrSql += " and ( HRApplicantWorkerEstimationStatement.SubSector in (" + str + "))";
            }
            if (_WorkUpToNowSectorIDs != null && _WorkUpToNowSectorIDs != "")
            {
                string str = " SELECT     HRApplicantWorkerCurrentSubSector.ApplicantID FROM         HRApplicantWorkerCurrentSubSector INNER JOIN "+
                             " HRSubSector ON HRApplicantWorkerCurrentSubSector.SubSectorID = HRSubSector.SubSectorID "+
                             " WHERE     (HRSubSector.SectorID IN (" + _WorkUpToNowSectorIDs + "))";
                string str1 = " Select ApplicantID From HRApplicantWorker Where ApplicantID in (" + str + ") and ApplicantStatusID = 1";
                StrSql += " and ( HRApplicantWorkerEstimationStatement.Applicant in (" + str1 + "))";
            }
            
            
            return SysData.SharpVisionBaseDb.ReturnDatatable(StrSql);
        }


        public DataTable GetSubSectorAndCostcenter(string strEstimationStatement,string strApplicantIDs)        
        {
            string StrSql = " SELECT     Applicant, SubSector, CostCenter, JobNature, JobCategoryEstimation " +
                            " FROM         HRApplicantWorkerEstimationStatement " +
                            " WHERE     (ApplicantEstimationStatementID IN " +
                            " (SELECT     MAX(ApplicantEstimationStatementID) AS ID " +
                            " FROM         HRApplicantWorkerEstimationStatement AS HRApplicantWorkerEstimationStatement_1" +
                            " WHERE     (EstimationStatement IN (" + strEstimationStatement + ")) AND (Applicant IN (" + strApplicantIDs + "))";
            if (_SectorOnlyIDs != null && _SectorOnlyIDs != "")
            {
                string str = " SELECT     SubSectorID FROM         HRSubSector WHERE     (SectorID IN (" + _SectorOnlyIDs + "))";
                StrSql += " and ( SubSector in (" + str + "))";
            }
            StrSql += " GROUP BY Applicant))";

            
                           
            return SysData.SharpVisionBaseDb.ReturnDatatable(StrSql);
        }
        public void JoinElementCol()
        {
            if (_ElementTable == null || _ElementTable.Rows.Count == 0)
                return;
            ApplicantWorkerEstimationStatementElementDb objDb;
            List<string> arrStr = new List<string>();
            arrStr.Add(" delete FROM   dbo.HRApplicantWorkerEstimationStatementElement WHERE(ApplicantEstimationStatement = "+ ID +")");
            foreach (DataRow objDr in _ElementTable.Rows)
            {
                objDb = new ApplicantWorkerEstimationStatementElementDb(objDr);
                objDb.ID = ID;
                arrStr.Add(objDb.AddStr);
            }
            SysData.SharpVisionBaseDb.ExecuteNonQuery(arrStr);
            EditTotalEstimationValue();
        }
        public DataTable GetAttendanceStatementTable()
        {
            string strAttendance = @"SELECT        dbo.HRApplicantWorkerAttendanceStatement.ApplicantAttendanceStatmentID, dbo.HRApplicantWorkerAttendanceStatement.Applicant, dbo.HREstimationStatementAttendanceStatement.EstimationStatement
FROM            dbo.HREstimationStatementAttendanceStatement INNER JOIN
                         dbo.HRApplicantWorkerAttendanceStatement ON dbo.HREstimationStatementAttendanceStatement.AttendanceStatement = dbo.HRApplicantWorkerAttendanceStatement.AttendanceStatment
WHERE        (dbo.HRApplicantWorkerAttendanceStatement.Applicant = "+_Applicant+@") AND (dbo.HREstimationStatementAttendanceStatement.EstimationStatement ="+_EstimationStatement+")";
            string strSql = new ApplicantWorkerAttendanceStatementDb().SearchStr +" inner join ("+ strAttendance + @") as EstimationAttendanceTable on HRApplicantWorkerAttendanceStatement.ApplicantAttendanceStatmentID =  EstimationAttendanceTable.ApplicantAttendanceStatmentID ";
            DataTable Returned = new DataTable();
            Returned = SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
            return Returned;
            }
        #endregion
    }
}
