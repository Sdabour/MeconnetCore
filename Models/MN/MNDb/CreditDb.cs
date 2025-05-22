using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using SharpVision.SystemBase;

namespace AlgorithmatMN.MN.MNDb
{
   public  class CreditDb
    {

        #region Constructor
        public CreditDb()
        {
        }
        public CreditDb(DataRow objDr)
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
        string _ROCode;
        public string ROCode
        { set => _ROCode = value; }
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
        string _YearsStr;
        public string YearsStr { set => _YearsStr = value; }
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
        double _CrditInitialValue;
        public double CrditInitialValue
        {
            set
            {
                _CrditInitialValue = value;
            }
            get
            {
                return _CrditInitialValue;
            }
        }
        double _BonusValue;
        public double BonusValue
        {
            set
            {
                _BonusValue = value;
            }
            get
            {
                return _BonusValue;
            }
        }
        double _PaymentValue;
        public double PaymentValue
        {
            set
            {
                _PaymentValue = value;
            }
            get
            {
                return _PaymentValue;
            }
        }
        double _DiscountValue;
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
        double _Cost;
        public double Cost
        {
            set
            {
                _Cost = value;
            }
            get
            {
                return _Cost;
            }
        }
        string _IDs;
        public string IDs
        { set => _IDs = value; }
        string _ROIDs;
        public string ROIDs
        { set => _ROIDs = value; }
        string _ProjectCode;
        public string ProjectCode { set => _ProjectCode=value; }
        DataTable _CreditTable;
        public DataTable CreditTable
        {
            set => _CreditTable = value;
        }
        DataTable _DiscountTable;
        public DataTable DiscountTable
        { set => _DiscountTable = value; }
        DataTable _PaymentTable;
        public DataTable PaymentTable
        { set => _PaymentTable = value; }
        DataTable _CostTable;
        public DataTable CostTable
        { set => _CostTable = value; }
        public string AddStr
        {
            get
            {
                string Returned = " insert into MNROCredit (CreditRO,CreditYear,CreditStartDate,CreditEndDate,CrditInitialValue,CreditBonusValue,CreditPaymentValue,CreditDiscountValue,CreditCost,UsrIns,TimIns) values (" + RO + "," + Year + "," + (StartDate.ToOADate() - 2).ToString() + "," + (EndDate.ToOADate() - 2).ToString() + "," + CrditInitialValue + "," + BonusValue+","+ PaymentValue+","+DiscountValue + "," + Cost + "," + SysData.CurrentUser.ID + ",GetDate() ) ";
                return Returned;
            }
        }
        public string EditStr
        {
            get
            {
                string Returned = " update MNROCredit set CreditRO=" + RO + "" +
           ",CreditYear=" + Year + "" +
           ",CreditStartDate=" + (StartDate.ToOADate() - 2).ToString() + "" +
           ",CreditEndDate=" + (EndDate.ToOADate() - 2).ToString() + "" +
           ",CrditInitialValue=" + CrditInitialValue + "" +
           ",CreditBonusValue=" + BonusValue + "" +
           ",CreditPaymentValue="+PaymentValue+
           ",CreditDiscountValue="+DiscountValue+
           ",CreditCost=" + Cost + "" + ",UsrUpd=" + SysData.CurrentUser.ID + @",TimUpd=GetDate()  where ";
                return Returned;
            }
        }
        public string DeleteStr
        {
            get
            {
                string strCredit = @"delete 
    FROM dbo.MNROCreditTemp
WHERE(CreditUser = "+SysData.CurrentUser.ID+")";
                SysData.SharpVisionBaseDb.ExecuteNonQuery(strCredit);
                strCredit = @" insert into MNROCreditTemp (CreditID, CreditRO, CreditYear, CreditStartDate, CreditEndDate, CrditInitialValue, CreditBonusValue, CreditPaymentValue, CreditDiscountValue, CreditCost, CreditUser
)
SELECT CreditID, CreditRO, CreditYear, CreditStartDate, CreditEndDate, CrditInitialValue, CreditBonusValue, CreditPaymentValue, CreditDiscountValue, CreditCost, "+SysData.CurrentUser.ID.ToString()+@"
FROM     dbo.MNROCredit ";
                if (_IDs != null && _IDs != "")
                {
                    strCredit += @" inner join (
SELECT CreditRO, MAX(CreditID) AS MaxCreditID
 FROM     dbo.MNROCredit
 GROUP BY CreditRO
  HAVING (MAX(CreditID) in ("+_IDs+@"))
) as MaxCreditTable on MNROCredit.CreditID = MaxCreditTable.CreditID ";
                    strCredit += " where CreditID in (" + _IDs + ")";
                }
                else if (_ROIDs != null && _ROIDs != "")
                    strCredit += " where CreditRO in (" + _ROIDs + ") ";
                SysData.SharpVisionBaseDb.ExecuteNonQuery(strCredit);
                    
                string strIDs = _IDs == null ||_IDs == "" ?ID.ToString() : _IDs;
                string Returned = @" begin transaction Trans1; ";
                Returned += " begin try ";
Returned+= @"delete from MNROCredit where CreditID in (SELECT CreditID
FROM     dbo.MNROCreditTemp
WHERE  (CreditUser = "+SysData.CurrentUser.ID+")) ";
                Returned += @" update dbo.MNRoCost set CostCredit =0 
FROM dbo.MNRoCost INNER JOIN
                  dbo.MNROCreditTemp ON dbo.MNRoCost.CostCredit = dbo.MNROCreditTemp.CreditID
WHERE(dbo.MNROCreditTemp.CreditUser = "+ SysData.CurrentUser.ID +") AND(dbo.MNROCreditTemp.CreditID > 0)";

                Returned += @" update dbo.MNROCreditPayment set CreditID = 0
FROM     dbo.MNROCreditPayment INNER JOIN
                  dbo.MNROCreditTemp ON dbo.MNROCreditPayment.CreditID = dbo.MNROCreditTemp.CreditID
WHERE  (dbo.MNROCreditTemp.CreditUser = "+ SysData.CurrentUser.ID+@") AND (dbo.MNROCreditTemp.CreditID > 0)";

                Returned += @" update dbo.MNROCreditDiscount set CreditID = 0 
 FROM     dbo.MNROCreditDiscount INNER JOIN
                  dbo.MNROCreditTemp ON dbo.MNROCreditDiscount.CreditID = dbo.MNROCreditTemp.CreditID
WHERE  (dbo.MNROCreditTemp.CreditUser = "+SysData.CurrentUser.ID+@") AND (dbo.MNROCreditTemp.CreditID > 0) ";
                Returned += @" ";
                Returned += @" commitline: commit transaction Trans1;Return; ";
                Returned += @"
     END TRY ";


    Returned+= @" BEGIN CATCH 
   rolLine: RollBack TRAN Trans1 ; 
   END CATCH; ";
                return Returned;
            }
        }
        public string SearchStr
        {
            get
            {
                string Returned = @" select CreditID,CreditRO,CreditYear,CreditStartDate,CreditEndDate,CrditInitialValue,CreditBonusValue,CreditPaymentValue, CreditDiscountValue
,CreditCost,ROTable.*   from MNROCredit 
    inner join (" + new RODb().SearchStr + @") as ROTable 
   on MNROCredit.CreditRO  = ROTable.ROID ";
                return Returned;
            }
        }
        #endregion
        #region Private Method
        void SetData(DataRow objDr)
        {

            if (objDr.Table.Columns["CreditID"] != null)
                int.TryParse(objDr["CreditID"].ToString(), out _ID);

            if (objDr.Table.Columns["CreditRO"] != null)
                int.TryParse(objDr["CreditRO"].ToString(), out _RO);

            if (objDr.Table.Columns["CreditYear"] != null)
                int.TryParse(objDr["CreditYear"].ToString(), out _Year);

            if (objDr.Table.Columns["CreditStartDate"] != null)
                DateTime.TryParse(objDr["CreditStartDate"].ToString(), out _StartDate);

            if (objDr.Table.Columns["CreditEndDate"] != null)
                DateTime.TryParse(objDr["CreditEndDate"].ToString(), out _EndDate);

            if (objDr.Table.Columns["CrditInitialValue"] != null)
                double.TryParse(objDr["CrditInitialValue"].ToString(), out _CrditInitialValue);

            if (objDr.Table.Columns["CreditBonusValue"] != null)
                double.TryParse(objDr["CreditBonusValue"].ToString(), out _BonusValue);

            if (objDr.Table.Columns["CreditCost"] != null)
                double.TryParse(objDr["CreditCost"].ToString(), out _Cost);
            if (objDr.Table.Columns["CreditPaymentValue"] != null)
                double.TryParse(objDr["CreditPaymentValue"].ToString(), out _PaymentValue);
            if (objDr.Table.Columns["CreditDiscountValue"] != null)
                double.TryParse(objDr["CreditDiscountValue"].ToString(), out _DiscountValue);
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
            if (_ROIDs != null && _ROIDs != "")
                strSql += " and CreditRO in ("+ _ROIDs +") ";
            if (_ProjectCode != null && _ProjectCode != "")
                strSql += " and ROProjectCode='"+_ProjectCode+"' ";
            if (_ROCode != null && _ROCode != "")
                strSql += " and ROCode like '%"+_ROCode+"%' ";
            if(_YearsStr!= null && _YearsStr!= "")
            {
                strSql += " and CreditYear in ("+_YearsStr+") ";
            }
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        public void AddMultiple()
        {
            if (_CreditTable == null || _CreditTable.Rows.Count == 0)
                return;
            System.Data.SqlClient.SqlBulkCopy objCopy = new System.Data.SqlClient.SqlBulkCopy(SysData.SharpVisionBaseDb.sqlConnection.ConnectionString);
            SysData.SharpVisionBaseDb.ExecuteNonQuery("delete from MNROCreditTemp where CreditUser = " + SysData.CurrentUser.ID);
            objCopy.DestinationTableName = "MNROCreditTemp";
            DataRow[] arrDr = _CreditTable.Select("CreditID=0");
            objCopy.WriteToServer(_CreditTable);
            SysUtility.SaveTempForignTable("MNROCreditDiscount", _DiscountTable);
            SysUtility.SaveTempForignTable("MNROCreditPayment", _PaymentTable);

            SysUtility.SaveTempForignTable("MNROCost", _CostTable);
            List<string> lstSql = new List<string>();
            double dblTimIns = DateTime.Now.ToOADate() - 2;
            string strSql = @" insert into  MNROCredit 
 (CreditRO, CreditYear, CreditStartDate, CreditEndDate, CrditInitialValue, CreditBonusValue, CreditPaymentValue, CreditDiscountValue, CreditCost, CreditOrder, UsrIns, TimIns
)
SELECT CreditRO, CreditYear, CreditStartDate, CreditEndDate, CrditInitialValue, CreditBonusValue, CreditPaymentValue, CreditDiscountValue, CreditCost, CreditOrder, " + SysData.CurrentUser.ID+@" AS UsrIns, "+dblTimIns+@" AS TimIns
FROM     dbo.MNROCreditTemp
WHERE  (CreditUser = "+SysData.CurrentUser.ID+@") ";
            lstSql.Add(strSql);
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
            strSql = @" update dbo.MNRoCost set CostCredit=dbo.MNROCredit.CreditID
 FROM     dbo.MNROCredit INNER JOIN
                  dbo.MNROCreditTemp ON dbo.MNROCredit.CreditRO = dbo.MNROCreditTemp.CreditRO INNER JOIN
                  dbo.COMMONTempForign ON dbo.MNROCreditTemp.CreditOrder = dbo.COMMONTempForign.ForignID INNER JOIN
                  dbo.MNRoCost ON dbo.COMMONTempForign.PrimaryID = dbo.MNRoCost.CostID
WHERE  (dbo.MNROCreditTemp.CreditUser = "+SysData.CurrentUser.ID+ @") AND (dbo.COMMONTempForign.TypeDesc = 'MNRoCost') and (dbo.MNROCredit.TimIns>="+dblTimIns+@") ";
            lstSql.Add(strSql);
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);

            strSql = @" update dbo.MNROCreditPayment set CreditID =  dbo.MNROCredit.CreditID
 FROM     dbo.MNROCredit INNER JOIN
                  dbo.MNROCreditTemp ON dbo.MNROCredit.CreditRO = dbo.MNROCreditTemp.CreditRO INNER JOIN
                  dbo.COMMONTempForign ON dbo.MNROCreditTemp.CreditOrder = dbo.COMMONTempForign.ForignID INNER JOIN
                  dbo.MNROCreditPayment ON dbo.COMMONTempForign.PrimaryID = dbo.MNROCreditPayment.PaymentID
WHERE  (dbo.MNROCreditTemp.CreditUser = "+SysData.CurrentUser.ID+@") AND (dbo.COMMONTempForign.TypeDesc = 'MNROCreditPayment') AND (dbo.MNROCredit.TimIns >= "+dblTimIns+")";
            lstSql.Add(strSql);
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
            strSql = @" update dbo.MNROCreditDiscount set CreditID = dbo.MNROCredit.CreditID
FROM     dbo.MNROCredit INNER JOIN
                  dbo.MNROCreditTemp ON dbo.MNROCredit.CreditRO = dbo.MNROCreditTemp.CreditRO INNER JOIN
                  dbo.COMMONTempForign ON dbo.MNROCreditTemp.CreditOrder = dbo.COMMONTempForign.ForignID INNER JOIN
                  dbo.MNROCreditDiscount ON dbo.COMMONTempForign.PrimaryID = dbo.MNROCreditDiscount.CreditDiscountID
WHERE  (dbo.MNROCreditTemp.CreditUser = "+ SysData.CurrentUser.ID +@") AND (dbo.COMMONTempForign.TypeDesc = 'MNROCreditDiscount') AND (dbo.MNROCredit.TimIns >= "+dblTimIns+")";
            lstSql.Add(strSql);
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public void AddMultiple1()
        {
            if (_CreditTable == null || _CreditTable.Rows.Count == 0)
                return;
            List<string> lstStr = new List<string>();
            CreditDb objDb;
            foreach(DataRow objDr in _CreditTable.Rows)
            {
                objDb = new CreditDb(objDr);
                if (objDb.ID == 0)
                    lstStr.Add(objDb.AddStr);
                //else
                //    lstStr.Add(objDb.EditStr);
            }
            SysData.SharpVisionBaseDb.ExecuteNonQuery(lstStr);
        }
        #endregion
    }
}
