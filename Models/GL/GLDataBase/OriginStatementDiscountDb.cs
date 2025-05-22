using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.SystemBase;
using SharpVision.Base.BaseDataBase;

namespace SharpVision.GL.GLDataBase
{
    public class OriginStatementDiscountDb
    {
        #region Private Data
        protected int _OriginStatement;
        protected string _Desc;
        protected double _Value;
        protected DateTime _Date;
        #endregion

        #region Constractors
        public OriginStatementDiscountDb()
        {

        }
        public OriginStatementDiscountDb(int intID)
        {
            DataTable dtTemp = Search();
            DataRow objDR = dtTemp.Rows[0];
            SetData(objDR);
        }
        public OriginStatementDiscountDb(DataRow objDR)
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
        public static string SearchStr
        {
            get
            {
                string Returned = " SELECT     OriginStatement, DiscountDesc, DiscountValue,DiscountDate " +
                                  " FROM         GLOriginStatementDiscount ";
                return Returned;
            }
        }
        #endregion

        #region Private Methods
        void SetData(DataRow objDR)
        {
            _OriginStatement = int.Parse(objDR["OriginStatement"].ToString());
            _Desc = objDR["DiscountDesc"].ToString();
            _Value = double.Parse(objDR["DiscountValue"].ToString());
            _Date = DateTime.Parse(objDR["DiscountDate"].ToString());
        }
        #endregion

        #region Public Methods
        public virtual void Add()
        {
            double dblDate = _Date.ToOADate() - 2;
            string strSql = " INSERT INTO GLOriginStatementDiscount" +
                            " (OriginStatement, DiscountDesc, DiscountValue,DiscountDate)" +
                            " VALUES     (" + _OriginStatement + ",'" + _Desc + "'," +
                            _Value + "," + dblDate + ") ";
          SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public virtual void Edit()
        {
            string strSql = " UPDATE    GLOriginStatementDiscount" +
                            " SET   OriginStatement =" + _OriginStatement + "" +
                            " , DiscountDesc ='" + _Desc + "'" +
                            " , DiscountValue = " + _Value + "" +
                            " Where OriginStatement = " + _OriginStatement + "";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);

        }
        public virtual void Delete()
        {
            string strSql = " DELETE FROM GLOriginStatementDiscount " +
                " Where OriginStatement = " + _OriginStatement + "";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);

        }
        public virtual DataTable Search()
        {
            string strSql = SearchStr + " Where 1 = 1 ";
            if (_OriginStatement != 0)
                strSql += " and OriginStatement = " + _OriginStatement + "";
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }

        #endregion
    }
}
