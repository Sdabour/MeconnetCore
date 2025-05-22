using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using SharpVision.SystemBase;
namespace AlgorithmatMN.MN.MNDb
{
    public class ProjectCostDb
    {

        #region Constructor
        public ProjectCostDb()
        {
        }
        public ProjectCostDb(DataRow objDr)
        {
            SetData(objDr);
        }

        #endregion
        #region Properties
        int _ID;
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
        int _Type;
        public int Type
        {
            set
            {
                _Type = value;
            }
            get
            {
                return _Type;
            }
        }
        string _Project;
        public string Project
        {
            set
            {
                _Project = value;
            }
            get
            {
                return _Project;
            }
        }
        double _Value;
        public double Value
        {
            set
            {
                _Value = value;
            }
            get
            {
                return _Value;
            }
        }
        DateTime _Date;
        public DateTime Date
        {
            set
            {
                _Date = value;
            }
            get
            {
                return _Date;
            }
        }
        int _ROType;
        public int ROType
        {
            set
            {
                _ROType = value;
            }
            get
            {
                return _ROType;
            }
        }
        bool _IsDateRange;
        public bool IsDateRange { set => _IsDateRange = value; }
        DateTime _StartDate;
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
        DateTime _EndDate;
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
        int _Year;
        public int Year
        {
            set
            {
                _Year = value;
            }
            get
            {
                return _Year;
            }
        }
        double _Factor1;
        public double Factor1
        {
            set
            {
                _Factor1 = value;
            }
            get
            {
                return _Factor1;
            }
        }
        double _Factor2;
        public double Factor2
        {
            set
            {
                _Factor2 = value;
            }
            get
            {
                return _Factor2;
            }
        }
        double _Factor3;
        public double Factor3
        {
            set
            {
                _Factor3 = value;
            }
            get
            {
                return _Factor3;
            }
        }
        string _YearsStr;
        public string YearStr
        { set => _YearsStr = value; }
        double _TotalROCostValue;
        public double TotalROCostValue
        { set => _TotalROCostValue = value; get => _TotalROCostValue; }
        
        double _RemainingValue;
        public double RemainingValue
        { set => _RemainingValue = value; get => _RemainingValue; }
        string _IDs;
        public string IDs
        { set => _IDs = value; }
        public string AddStr
        {
            get
            {
                string Returned = " insert into MNProjectCost ( CostType,CostProject,CostValue,CostDate,CostROType,CostStartDate,CostEndDate,CostYear,CostFactor1,CostFactor2,CostFactor3,CostRemainingValue,UsrIns,TimIns) values (" + Type + ",'" + Project + "'," + Value + "," + (Date.ToOADate() - 2).ToString() + "," + ROType + "," + (StartDate.ToOADate() - 2).ToString() + "," + (EndDate.ToOADate() - 2).ToString() + "," + Year + "," + Factor1 + "," + Factor2 + "," + Factor3+","+ Value + "," + SysData.CurrentUser.ID + ",GetDate() ) ";
                return Returned;
            }
        }
        public string EditStr
        {
            get
            {
                string Returned = " update MNProjectCost set  CostType=" + Type + "" +
          // ",CostProject='" + Project + "'" +
           ",CostValue=" + Value + "" +
           ",CostDate=" + (Date.ToOADate() - 2).ToString() + "" +
           ",CostROType=" + ROType + "" +
           ",CostStartDate=" + (StartDate.ToOADate() - 2).ToString() + "" +
           ",CostEndDate=" + (EndDate.ToOADate() - 2).ToString() + "" +
           ",CostYear=" + Year + "" +
           ",CostFactor1=" + Factor1 + "" +
           ",CostFactor2=" + Factor2 + "" +
           ",CostFactor3=" + Factor3 + "" + ",UsrUpd=" + SysData.CurrentUser.ID + @",TimUpd=GetDate() 
  FROM     dbo.MNProjectCost INNER JOIN
                      (SELECT MNProjectCost_1.CostID, SUM(ISNULL(dbo.MNRoCost.CostValue, 0)) AS TotalDevidedCost
                       FROM      dbo.MNProjectCost AS MNProjectCost_1 LEFT OUTER JOIN
                                         dbo.MNRoCost ON MNProjectCost_1.CostID = dbo.MNRoCost.CostProjectCost
                       GROUP BY MNProjectCost_1.CostID) AS derivedtbl_1 ON dbo.MNProjectCost.CostID = derivedtbl_1.CostID
WHERE  (derivedtbl_1.TotalDevidedCost = 0) AND (dbo.MNProjectCost.CostID = "+_ID+")";
                return Returned;
            }
        }
        public string DeleteStr
        {
            get
            {
                string strCostSum = @"SELECT MNProjectCost_1.CostID
FROM     dbo.MNProjectCost AS MNProjectCost_1 LEFT OUTER JOIN
                  dbo.MNRoCost ON MNProjectCost_1.CostID = dbo.MNRoCost.CostProjectCost
GROUP BY MNProjectCost_1.CostID
HAVING (SUM(ISNULL(dbo.MNRoCost.CostValue, 0)) = 0) AND (MNProjectCost_1.CostID = " + _ID + ")";
                string Returned = " delete from MNProjectCost  where CostID in ("+strCostSum + ")";
                return Returned;
            }
        }
        public string CancelDivisionStr
        {
            get
            {
                string strTotalCost = @" update dbo.MNProjectCost set CostRemainingValue = dbo.MNProjectCost.CostValue- derivedtbl_1.TotalCost, dbo.MNProjectCost.CostDevidedValue = derivedtbl_1.TotalCost
FROM dbo.MNProjectCost INNER JOIN
                  (SELECT MNProjectCost_1.CostID, SUM(dbo.MNRoCost.CostValue) AS TotalCost

                   FROM      dbo.MNProjectCost AS MNProjectCost_1 INNER JOIN

                                     dbo.MNRoCost ON MNProjectCost_1.CostID = dbo.MNRoCost.CostProjectCost

                   GROUP BY MNProjectCost_1.CostID, MNProjectCost_1.CostProject, MNProjectCost_1.CostValue, MNProjectCost_1.CostRemainingValue, MNProjectCost_1.CostDevidedValue

                   HAVING(MNProjectCost_1.CostID in ("+_IDs+@"))) AS derivedtbl_1 ON dbo.MNProjectCost.CostID = derivedtbl_1.CostID";
                string Returned = @"delete from MNROCost where CostProjectCost in (" +_IDs + ") and CostCredit = 0 "+strTotalCost ;
                return Returned;
            }
        }
        public string SearchStr
        {
            get
            {
                string Returned = @" select CostID,CostType,CostProject,CostValue,CostDate,CostROType,CostStartDate,CostEndDate,CostYear,CostFactor1,CostFactor2,CostFactor3,CostRemainingValue,CostDevidedValue,TypeTable.*
  from MNProjectCost  
             left outer join (" + new CostTypeDb().SearchStr+ ") as TypeTable  on MNProjectCost.CostType = TypeTable.CostTypeID ";
                return Returned;
            }
        }
        public string RemainingSearchStr
        { get 
            {
                string Returned = @"SELECT dbo.MNProjectCost.CostID, dbo.MNProjectCost.CostValue,isnull(SUM(dbo.MNRoCost.CostValue),0) AS TotalROCostValue, dbo.MNProjectCost.CostValue - isnull(SUM(dbo.MNRoCost.CostValue),0) AS RemainingValue
FROM   dbo.MNProjectCost left outer  JOIN
             dbo.MNRoCost ON dbo.MNProjectCost.CostID = dbo.MNRoCost.CostProjectCost ";
Returned+= @" GROUP BY dbo.MNProjectCost.CostID, dbo.MNProjectCost.CostValue ";
                return Returned;
            } }
        #endregion
        #region Private Method
        void SetData(DataRow objDr)
        {

            if (objDr.Table.Columns["CostID"] != null)
                int.TryParse(objDr["CostID"].ToString(), out _ID);

            if (objDr.Table.Columns["CostType"] != null)
                int.TryParse(objDr["CostType"].ToString(), out _Type);

            if (objDr.Table.Columns["CostProject"] != null)
                _Project = objDr["CostProject"].ToString();

            if (objDr.Table.Columns["CostValue"] != null)
                double.TryParse(objDr["CostValue"].ToString(), out _Value);
            if (objDr.Table.Columns["CostRemainingValue"] != null)
                double.TryParse(objDr["CostRemainingValue"].ToString(), out _RemainingValue);
            if (objDr.Table.Columns["CostDate"] != null)
                DateTime.TryParse(objDr["CostDate"].ToString(), out _Date);

            if (objDr.Table.Columns["CostROType"] != null)
                int.TryParse(objDr["CostROType"].ToString(), out _ROType);

            if (objDr.Table.Columns["CostStartDate"] != null)
                DateTime.TryParse(objDr["CostStartDate"].ToString(), out _StartDate);

            if (objDr.Table.Columns["CostEndDate"] != null)
                DateTime.TryParse(objDr["CostEndDate"].ToString(), out _EndDate);

            if (objDr.Table.Columns["CostYear"] != null)
                int.TryParse(objDr["CostYear"].ToString(), out _Year);

            if (objDr.Table.Columns["CostFactor1"] != null)
                double.TryParse(objDr["CostFactor1"].ToString(), out _Factor1);

            if (objDr.Table.Columns["CostFactor2"] != null)
                double.TryParse(objDr["CostFactor2"].ToString(), out _Factor2);

            if (objDr.Table.Columns["CostFactor3"] != null)
                double.TryParse(objDr["CostFactor3"].ToString(), out _Factor3);
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

            if (_Project != null && _Project != "")
                strSql += " and CostProject='"+_Project+"' ";
            if (_Type != 0)
                strSql += " and CostType="+ _Type;
            if (_IsDateRange)
                strSql += " and CostDate between " + (_StartDate.Date.ToOADate() - 2) + " and " +(_EndDate.Date.ToOADate()-1);

            if (_YearsStr != null && _YearsStr != "")
                strSql += " and CostYear in ("+_YearsStr+")";
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        public void CancelDevision()
        {
            SysData.SharpVisionBaseDb.ExecuteNonQuery(CancelDivisionStr);
        }
        #endregion
    }
}
