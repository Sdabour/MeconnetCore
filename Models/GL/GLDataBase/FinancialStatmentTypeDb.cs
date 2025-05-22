using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.SystemBase;
using SharpVision.Base.BaseDataBase;

namespace SharpVision.GL.GLDataBase
{
    public class FinancialStatmentTypeDb : BaseSingleDb
    {
        #region Private Data
        protected int _Period;
        protected double _PeriodAmount;
        #endregion

        #region Constractors
        public FinancialStatmentTypeDb()
        {

        }
        public FinancialStatmentTypeDb(int intID)
        {
            _ID = intID;
            DataTable dtTemp = Search();
            DataRow objDR = dtTemp.Rows[0];
            SetData(objDR);
        }
        public FinancialStatmentTypeDb(DataRow objDR)
        {
            SetData(objDR);
        }
        #endregion

        #region Public Accessorice
        public int Period
        {
            set
            {
                _Period = value;
            }
            get
            {
                return _Period;
            }
        }
        public double PeriodAmount
        {
            set
            {
                _PeriodAmount = value;
            }
            get
            {
                return _PeriodAmount;
            }
        }

        public static string SearchStr
        {
            get
            {
                string Returned = " SELECT     StatementTypeID, StatementTypeNameA, StatementTypeNameE, StatementTypePeriod, StatementTypePeriodAmount"+
                                  " FROM         GLFinancialStatementType ";
                return Returned;
            }
        }
        #endregion

        #region Private Methods
        void SetData(DataRow objDR)
        {
            _ID = int.Parse(objDR["StatementTypeID"].ToString());
            _NameA = objDR["StatementTypeNameA"].ToString();
            _NameE = objDR["StatementTypeNameE"].ToString();
            _Period = int.Parse(objDR["StatementTypePeriod"].ToString());
            _PeriodAmount = double.Parse(objDR["StatementTypePeriodAmount"].ToString());
        }
        #endregion

        #region Public Methods
        public override void Add()
        {
            string strSql = " INSERT INTO GLFinancialStatementType"+
                            " (StatementTypeNameA, StatementTypeNameE, StatementTypePeriod, StatementTypePeriodAmount)"+
                            " VALUES     ('"+_NameA+"','"+_NameE+"',"+_Period+","+_PeriodAmount+")";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public override void Edit()
        {
            string strSql = " UPDATE    GLFinancialStatementType"+
                            " SET  StatementTypeNameA ='"+_NameA+"'"+
                            " , StatementTypeNameE ='"+_NameE+"'"+
                            " , StatementTypePeriod ="+_Period+""+
                            " , StatementTypePeriodAmount ="+_PeriodAmount+" "+
                            " Where StatementTypeID  = "+_ID+"";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public override void Delete()
        {
            string strSql = " DELETE FROM GLFinancialStatementType Where StatementTypeID  = "+_ID+" ";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public override DataTable Search()
        {
            string strSql = SearchStr + " Where 1 = 1 ";
            if (_ID != 0)
                strSql = strSql + " and StatementTypeID = " + _ID.ToString();
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        #endregion
    }
}
