using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.SystemBase;
using SharpVision.Base.BaseDataBase;

namespace SharpVision.GL.GLDataBase
{
    public class OriginStatementBonusDb
    {
        #region Private Data
        protected int _OriginStatement;
        protected string _Desc;
        protected double _Value;
        protected DateTime _Date;
       
        #endregion

        #region Constractors
        public OriginStatementBonusDb()
        {

        }
        public OriginStatementBonusDb(int intID)
        {
            DataTable dtTemp = Search();
            DataRow objDR = dtTemp.Rows[0];
            SetData(objDR);
        }
        public OriginStatementBonusDb(DataRow objDR)
        {
            SetData(objDR);
        }
        #endregion

        #region Public Accessorice
        public int OriginStatement
        {
            set
            {
                _OriginStatement = value;
            }
            get
            {
                return _OriginStatement;
            }
        }
        public string Desc
        {
            set
            {
                _Desc = value;
            }
            get
            {
                return _Desc;
            }
        }
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
        public string AddStr
        {
            get
            {
                double dblDate = _Date.ToOADate() - 2;
                string Returned = " INSERT INTO GLOriginStatementBonus" +
                                " (OriginStatement, BonusDesc, BonusValue,BonusDate)" +
                                " VALUES     (" + _OriginStatement + ",'" + _Desc + "'," +
                                _Value + "," + dblDate + ") ";
                return Returned;

            }
        }
        public static string SearchStr
        {
            get
            {
                string Returned = " SELECT     OriginStatement, BonusDesc, BonusValue,BonusDate" +
                                  " FROM         GLOriginStatementBonus ";
                return Returned;
            }
        }
        #endregion

        #region Private Methods
        void SetData(DataRow objDR)
        {
            _OriginStatement = int.Parse(objDR["OriginStatement"].ToString());
            _Desc = objDR["BonusDesc"].ToString();
            _Value = double.Parse(objDR["BonusValue"].ToString());
            _Date = DateTime.Parse(objDR["BonusDate"].ToString());
        }
        #endregion

        #region Public Methods
        public void Add()
        {
            double dblDate = _Date.ToOADate() - 2;
            string strSql = " INSERT INTO GLOriginStatementBonus" +
                            " (OriginStatement, BonusDesc, BonusValue,BonusDate)" +
                            " VALUES     (" + _OriginStatement + ",'" + _Desc + "'," +
                            _Value + "," + dblDate + ") ";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public void Edit()
        {
            string strSql = " UPDATE    GLOriginStatementBonus" +
                            " SET   OriginStatement =" + _OriginStatement + "" +
                            " , BonusDesc ='" + _Desc + "'" +
                            " , BonusValue = " + _Value + "" +
                            " Where OriginStatement = " + _OriginStatement + "";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);

        }
        public void Delete()
        {
            string strSql = " DELETE FROM GLOriginStatementBonus Where OriginStatement = " + _OriginStatement + "";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);

        }
        public DataTable Search()
        {
            string strSql = SearchStr + " Where 1 = 1 ";
            if (_OriginStatement != 0)
                strSql += " and OriginStatement = " + _OriginStatement + "";
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }

        #endregion
    }
}
