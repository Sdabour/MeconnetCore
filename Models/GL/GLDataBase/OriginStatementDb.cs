using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.SystemBase;
using SharpVision.Base.BaseDataBase;

namespace SharpVision.GL.GLDataBase
{
    public class OriginStatementDb
    {
        #region Private Data
        protected int _ID;
        protected DateTime _Date;
        protected int _PreviousStatement;
        protected double _OldDue;
        protected double _TaxValue;
        protected int _TaxStatement;
        protected double _PaidValue;
        protected double _DiscountValue;
        protected double _TotalValue;
        protected bool _StatementReviewed;
        protected int _StatementStage;
        protected DataTable _DiscountTable;
        protected DataTable _BonusTable;
        #endregion

        #region Constractors
        public OriginStatementDb()
        {

        }
        public OriginStatementDb(int intID)
        {
            _ID = intID;
            DataTable dtTemp = Search();
            DataRow objDR = dtTemp.Rows[0];
            SetData(objDR);

        }
        public OriginStatementDb(DataRow objDR)
        {
            SetData(objDR);
        }
        #endregion
        #region Public Accessorice
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
        public int PreviousStatement
        {
            set
            {
                _PreviousStatement = value;
            }
            get
            {
                return _PreviousStatement;
            }
        }
        public double OldDue
        {
            set
            {
                _OldDue = value;
            }
            get
            {
                return _OldDue;
            }
        }
        public double TaxValue
        {
            set
            {
                _TaxValue = value;
            }
            get
            {
                return _TaxValue;
            }
        }
        public int TaxStatement
        {
            set
            {
                _TaxStatement = value;
            }
            get
            {
                return _TaxStatement;
            }
        }
        public double PaidValue
        {
            set
            {
                _PaidValue = value;
            }
            get
            {
                return _PaidValue;
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
        public bool StatementReviewed
        {
            set
            {
                _StatementReviewed = value;
            }
            get
            {
                return _StatementReviewed;
            }
        }
        public int StatementStage
        {
            set
            {
                _StatementStage = value;
            }
            get
            {
                return _StatementStage;
            }
        }
        public DataTable BonusTable
        {
            set
            {
                _BonusTable = value;
            }
        }
        public DataTable DiscountTable
        {
            set
            {
                _DiscountTable = value;
            }
        }
        public virtual string AddStr
        {
            get
            {
                double dblDate = _Date.ToOADate() - 2;
                int intReviewed = _StatementReviewed == true ? 1 : 0;
                string Returned = " INSERT INTO GLOriginStatement " +
                                " (OriginStatementDate, OrginePreviousStatement, OriginStatementOldDue, OriginStatmentTaxValue, OriginStatementTaxStatement, " +
                                " OriginStatementPaidValue, OriginStatementDiscountValue, OriginStatementTotalValue,OriginStatementReviewed,OriginStatementStage,UsrIns,TimIns)" +
                                " VALUES     (" + dblDate + "," + _PreviousStatement + "," + _OldDue + "," + _TaxValue + "," + _TaxStatement + "," + _PaidValue + "," +
                                _DiscountValue + "," + _TotalValue + "," + intReviewed + ","+ _StatementStage +"," + SysData.CurrentUser.ID + ",GetDate()) ";
                return Returned;
            }
        }
        public static string SearchStr
        {
            get
            {
                string Returned = " SELECT     OriginStatementID, OriginStatementDate, OrginePreviousStatement, OriginStatementOldDue, OriginStatmentTaxValue, OriginStatementTaxStatement, " +
                                  " OriginStatementPaidValue, OriginStatementDiscountValue, OriginStatementTotalValue, OriginStatementReviewed,OriginStatementStage,TimIns,UsrIns" +
                                  " FROM         GLOriginStatement ";
                return Returned;
            }
        }
        #endregion
        #region Private Methods
        protected void SetData(DataRow objDR)
        {
            _ID = int.Parse(objDR["OriginStatementID"].ToString());
            _Date = DateTime.Parse(objDR["OriginStatementDate"].ToString());
            _OldDue = double.Parse(objDR["OriginStatementOldDue"].ToString());
            _DiscountValue = double.Parse(objDR["OriginStatementDiscountValue"].ToString());
            _TotalValue = double.Parse(objDR["OriginStatementTotalValue"].ToString());
            _TaxValue = double.Parse(objDR["OriginStatmentTaxValue"].ToString());
            _PreviousStatement = int.Parse(objDR["OrginePreviousStatement"].ToString());
            _TaxStatement = int.Parse(objDR["OriginStatementTaxStatement"].ToString());
            _PaidValue = double.Parse(objDR["OriginStatementPaidValue"].ToString());
            _StatementReviewed = bool.Parse(objDR["OriginStatementReviewed"].ToString());
            StatementStage = int.Parse(objDR["OriginStatementStage"].ToString());
        }
        
        #endregion
        #region Public Methods
        public virtual void Add()
        {
           
            _ID = SysData.SharpVisionBaseDb.InsertIdentityTable(AddStr);
            JoinDiscount();
            JoinBonus();
        }
        public virtual void Edit()
        {
            double dblDate = _Date.ToOADate() - 2;
            int intReviewed = _StatementReviewed == true ? 1 : 0;

            string strSql = " UPDATE    GLOriginStatement" +
                            " SET  OriginStatementDate =" + dblDate + "" +
                            " , OrginePreviousStatement =" + _PreviousStatement + "" +
                            " , OriginStatementOldDue =" + _OldDue + "" +
                            " , OriginStatmentTaxValue =" + _TaxValue + "" +
                            " , OriginStatementTaxStatement =" + _TaxStatement + "" +
                            " , OriginStatementPaidValue =" + _PaidValue + "" +
                            " , OriginStatementDiscountValue =" + _DiscountValue + "" +
                            " , OriginStatementTotalValue =" + _TotalValue + "" +
                            " , OriginStatementReviewed =" + intReviewed + "" +
                            " , OriginStatementStage = "+ _StatementStage+""+
                            ",UsrUpd=" + SysData.CurrentUser.ID + ""+
                            ",TimUpd= GetDate()" +
                            " WHERE     (originstatementid = " + _ID + ") ";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
            JoinDiscount();
            JoinBonus();


        }

        public virtual void EditStatementReviewed()
        {
            int intReviewed = _StatementReviewed == true ? 1 : 0;
            string strSql = " UPDATE    GLOriginStatement" +
                           " SET  OriginStatementReviewed =" + intReviewed + "" +
                             " WHERE     (originstatemenetid = " + _ID + ") ";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);

        }

        public virtual void Delete()
        {
            string strSql = " DELETE FROM GLOriginStatement" +
                            " WHERE     (OriginStatementID = " + _ID + ") ";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public virtual DataTable Search()
        {
            string strSql = SearchStr + " WHERE  (1 = 1)";
            if (_ID != 0)
                strSql = strSql + " and OriginStatmentID = " + _ID.ToString();
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        public virtual void JoinDiscount()
        {
            if (_DiscountTable == null)
                return;
            string[] arrStr = new string[_DiscountTable.Rows.Count + 1];
            arrStr[0] = "delete from GLOriginStatementDiscount where OriginStatement=" + _ID;
            int intIndex = 1;
            double dblDate;
            foreach (DataRow objDr in _DiscountTable.Rows)
            {
                dblDate = DateTime.Parse(objDr["DiscountDate"].ToString()).ToOADate() - 2;
                arrStr[intIndex] = "insert into GLOriginStatementDiscount ( OriginStatement, DiscountDesc, DiscountValue, DiscountDate) " +
                    " values (" + _ID + ",'" + objDr["DiscountDesc"].ToString() + "'," +
                    objDr["DiscountValue"].ToString() + "," + dblDate + ")";
                intIndex++;

            }
            SysData.SharpVisionBaseDb.ExecuteNonQuery(arrStr);
        }
        public void JoinBonus()
        {
            if (_BonusTable == null)
                return;
            string[] arrStr = new string[_BonusTable.Rows.Count + 1];
            arrStr[0] = "delete from GLOriginStatementBonus where OriginStatement=" + _ID;
            int intIndex = 1;
            double dblDate;
            foreach (DataRow objDr in _BonusTable.Rows)
            {
                dblDate = DateTime.Parse(objDr["BonusDate"].ToString()).ToOADate() - 2;
                arrStr[intIndex] = "insert into GLOriginStatementBonus ( OriginStatement, BonusDesc, BonusValue, BonusDate) " +
                    " values (" + _ID + ",'" + objDr["BonusDesc"].ToString() + "'," +
                    objDr["BonusValue"].ToString() + "," + dblDate + ")";
                intIndex++;

            }
            SysData.SharpVisionBaseDb.ExecuteNonQuery(arrStr);
        }
        #endregion
    }
}
