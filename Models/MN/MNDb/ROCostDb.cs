using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using SharpVision.SystemBase;
namespace AlgorithmatMN.MN.MNDb
{
    public class ROCostDb
    {

        #region Constructor
        public ROCostDb()
        {
        }
        public ROCostDb(DataRow objDr)
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
        int _RO;
        public int RO
        {
            set
            {
                _RO = value;
            }
            get
            {
                return _RO;
            }
        }
        int _ProjectCost;
        public int ProjectCost
        {
            set
            {
                _ProjectCost = value;
            }
            get
            {
                return _ProjectCost;
            }
        }
        string _ProjectCode;
        public string ProjectCode { set => _ProjectCode = value; }
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
        int _CreditID;
        public int CreditID { set => _CreditID = value; get => _CreditID; }
        int _CreditStatus;
        public int CreditStatus { set=> _CreditStatus = value; }
        string _ROIDs;
        public string ROIDs { set => _ROIDs = value; }
        string _YearsStr;
        public string YearStr
        { set => _YearsStr = value; }
        DataTable _CostTable;
        public DataTable CostTable
        {
            set => _CostTable = value;
        }

        public string AddStr
        {
            get
            {
                string Returned = " insert into MNROCost ( CostType,CostRO,CostValue,CostDate,CostStartDate,CostEndDate,CostYear,CostFactor1,CostFactor2,CostFactor3,UsrIns,TimIns) values (" + Type + "," + RO + "," + Value + "," + (Date.ToOADate() - 2).ToString() + "," + (StartDate.ToOADate() - 2).ToString() + "," + (EndDate.ToOADate() - 2).ToString() + "," + Year + "," + Factor1 + "," + Factor2 + "," + Factor3 + "," + SysData.CurrentUser.ID + ",GetDate() ) ";
                return Returned;
            }
        }
        public string EditStr
        {
            get
            {
                string Returned = " update MNROCost set  CostType=" + Type + "" +
           ",CostRO=" + RO + "" +
           ",CostValue=" + Value + "" +
           ",CostDate=" + (Date.ToOADate() - 2).ToString() + "" +
           ",CostStartDate=" + (StartDate.ToOADate() - 2).ToString() + "" +
           ",CostEndDate=" + (EndDate.ToOADate() - 2).ToString() + "" +
           ",CostYear=" + Year + "" +
           ",CostFactor1=" + Factor1 + "" +
           ",CostFactor2=" + Factor2 + "" +
           ",CostFactor3=" + Factor3 + "" + ",UsrUpd=" + SysData.CurrentUser.ID + @",TimUpd=GetDate()  where CostID=" + ID + " and CostCredit=0 ";
                return Returned;
            }
        }
        public string DeleteStr
        {
            get
            {
                string Returned = " delete from MNROCost  where CostID= " + _ID + " and CostCredit=0 ";
                return Returned;
            }
        }
        public string SearchStr
        {
            get
            {
                string Returned = @" select CostID,CostType,CostRO,CostProjectCost,CostValue,CostDate,CostStartDate,CostEndDate,CostYear,CostFactor1,CostFactor2,CostFactor3,CostCredit,TypeTable.*,ROTable.* 
  from MNROCost  
             left outer join (" + new CostTypeDb().SearchStr + @") as TypeTable  on MNROCost.CostType = TypeTable.CostTypeID 
   left outer join ("+ new RODb().SearchStr +@") as ROTable  
   on MNROCost.CostRO = ROTable.ROID ";
                return Returned;
            }
        }
        #endregion
        #region Private Method
        void SetData(DataRow objDr)
        {

            if (objDr.Table.Columns["CostID"] != null)
                int.TryParse(objDr["CostID"].ToString(), out _ID);

            if (objDr.Table.Columns["CostType"] != null)
                int.TryParse(objDr["CostType"].ToString(), out _Type);

            if (objDr.Table.Columns["CostRO"] != null)
                int.TryParse( objDr["CostRO"].ToString(),out _RO);

            if (objDr.Table.Columns["CostProjectCost"] != null)
                int.TryParse(objDr["CostProjectCost"].ToString(), out _ProjectCost);

            if (objDr.Table.Columns["CostValue"] != null)
                double.TryParse(objDr["CostValue"].ToString(), out _Value);

            if (objDr.Table.Columns["CostDate"] != null)
                DateTime.TryParse(objDr["CostDate"].ToString(), out _Date);

            

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
            if (objDr.Table.Columns["CostCredit"] != null)
                int.TryParse(objDr["CostCredit"].ToString(), out _CreditID);
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

            if ( _RO != 0)
                strSql += " and CostRO=" + _RO + " ";
            if (_ROIDs != null && _ROIDs!="")
                strSql += " and CostRO in (" + _ROIDs + ") ";
            if (_CreditStatus == 2)
                strSql += " and CostCredit =0 ";
            if (_Type != 0)
                strSql += " and CostType=" + _Type;
            if (_IsDateRange)
                strSql += " and CostDate between " + (_StartDate.Date.ToOADate() - 2) + " and " + (_EndDate.Date.ToOADate() - 1);

            if (_YearsStr != null && _YearsStr != "")
                strSql += " and CostYear in (" + _YearsStr + ")";
            if (_ProjectCode != null && _ProjectCode != "")
                strSql += " and ROProjectCode = '"+ _ProjectCode +"' ";
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        public void AddProjectCostTable()
        {
            if (_CostTable == null || _CostTable.Rows.Count == 0)
                return;
            SysData.SharpVisionBaseDb.ExecuteNonQuery("truncate table MNROCostTemp");
            System.Data.SqlClient.SqlBulkCopy objCopy = new System.Data.SqlClient.SqlBulkCopy(SysData.SharpVisionBaseDb.sqlConnection.ConnectionString);
            objCopy.DestinationTableName = "MNROCostTemp";
            objCopy.WriteToServer(_CostTable);
            double dblTimIns = DateTime.Now.ToOADate() - 2;
            string strSql = @" insert into MNRoCost (CostType, CostProjectCost, CostRO, CostValue, CostDate, CostStartDate, CostEndDate, CostYear, CostFactor1, CostFactor2, CostFactor3, CostCredit, UsrIns, TimIns
) 
   SELECT CostType, CostProjectCost, CostRO, CostValue, CostDate, CostStartDate, CostEndDate, CostYear, CostFactor1, CostFactor2, CostFactor3, 0 AS CostCredit, "+ SysData.CurrentUser.ID +@" AS UsrIns, "+dblTimIns+@" AS TimIns
FROM     dbo.MNROCostTemp ";

            strSql += @" update dbo.MNProjectCost set CostRemainingValue= MNProjectCost.CostRemainingValue - ROCostTable.TotalRoValue,CostDevidedValue=ROCostTable.TotalRoValue
   FROM dbo.MNProjectCost INNER JOIN
                  (";
            strSql += @"SELECT MNProjectCost_1.CostID, MNProjectCost_1.CostRemainingValue, MNProjectCost_1.CostValue, SUM(dbo.MNRoCost.CostValue) AS TotalRoValue
FROM     dbo.MNProjectCost AS MNProjectCost_1 INNER JOIN
                  dbo.MNRoCost ON MNProjectCost_1.CostID = dbo.MNRoCost.CostProjectCost
WHERE  (dbo.MNRoCost.TimIns >="+dblTimIns+@")
GROUP BY MNProjectCost_1.CostID, MNProjectCost_1.CostValue, MNProjectCost_1.CostRemainingValue";
            strSql +=@") AS ROCostTable ON dbo.MNProjectCost.CostID = ROCostTable.CostID";

            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);

        }
        #endregion
    }
}

