using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.SystemBase;
using SharpVision.Base.BaseDataBase;

namespace SharpVision.GL.GLDataBase
{
    public class DirectPaymentTypeDB : BaseSingleDb
    {
        #region Private Data
        string _Code;
        #endregion
        #region Constractors
        public DirectPaymentTypeDB()
        {

        }
        public DirectPaymentTypeDB(DataRow objDR)
        {
            SetData(objDR);
        }
        #endregion
        #region Public Accessorice
        public string Code
        {
            set
            {
                _Code = value;
            }
            get
            {
                return _Code;
            }
        }

        public static string SearchStr
        {
            get
            {
                string Returned = " SELECT     PaymentTypeID, PaymentTypeCode, PaymentTypeNameA, PaymentTypeNameE  " +
                                  " FROM         GLDirectPaymentType ";
                return Returned;
            }
        }
        #endregion
        #region Private Methods
        void SetData(DataRow objDR)
        {
            _ID = int.Parse(objDR["PaymentTypeID"].ToString());
            _NameA = objDR["PaymentTypeNameA"].ToString();
            _NameE = objDR["PaymentTypeNameE"].ToString();
            _Code = objDR["PaymentTypeCode"].ToString();

        }
        #endregion
        #region Public Methods
        public override void Add()
        {

            string strSql = " INSERT INTO GLDirectPaymentType" +
                            " (PaymentTypeCode, PaymentTypeNameA, PaymentTypeNameE,UsrIns,TimIns)" +
                            " VALUES     ('" + _Code + "','" + _NameA + "','" + _NameE + "'," + SysData.CurrentUser.ID +
                            ",GetDate()) ";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public override void Edit()
        {

            string strSql = " UPDATE    GLDirectPaymentType" +
                            " SET  PaymentTypeCode ='" + _Code + "'" +
                            " , PaymentTypeNameA ='" + _NameA + "'" +
                            "  ,PaymentTypeNameE = '" + _NameE + "'" +
                            ",UsrUpd=" + SysData.CurrentUser.ID +
                            ",TimUpd=GetDate() " +
                            " where PaymentTypeID  = " + _ID;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public override void Delete()
        {
            string strSql = " update GLDirectPaymentType set Dis = GetDate() where PaymentTypeID  = " + _ID;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public override DataTable Search()
        {
            string strSql = SearchStr + " where Dis is null ";
            if (_ID != 0)
                strSql = strSql + " and  PaymentTypeID  = " + _ID;

            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        #endregion
    }
}