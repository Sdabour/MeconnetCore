using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.UMS.UMSDataBase;
using SharpVision.SystemBase;
using System.Data;
using System.Data.SqlClient;
using SharpVision.Base.BaseDataBase;
using SharpVision.COMMON.COMMONDataBase;

namespace SharpVision.CRM.CRMDataBase
{
    public class InstallmentTypeDb : BaseSingleDb
    {
        #region Private Data
        static DataTable _InstallmentTypeTable;
        protected double _PeriodAmount;
        protected int _Period;

        #endregion
        #region Constractor
        public InstallmentTypeDb()
        { 

        }

        public InstallmentTypeDb(int intID)
        {
           
            _ID = intID;
            DataTable dtTemp = Search();
            DataRow objDR = Search().Rows[0];
            _NameA = objDR["InstallmentTypeNameA"].ToString();
            _NameE = objDR["InstallmentTypeNameE"].ToString();
            _Period = int.Parse(objDR["InstallmentTypePeriod"].ToString());
            _PeriodAmount = double.Parse(objDR["InstallmentTypePeriodAmount"].ToString());
        }

        public InstallmentTypeDb(DataRow objDR)
        {
            _ID = int.Parse(objDR["InstallmentTypeID"].ToString());
            _NameA = objDR["InstallmentTypeNameA"].ToString();
            _NameE = objDR["InstallmentTypeNameE"].ToString();
            _Period = int.Parse(objDR["InstallmentTypePeriod"].ToString());
            _PeriodAmount = double.Parse(objDR["InstallmentTypePeriodAmount"].ToString());
            _MainType = int.Parse(objDR["InstallmentMainType"].ToString());
            
        }


        #endregion
        #region Public Probreties
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
        int _MainType;

        public int MainType
        {
            get { return _MainType; }
            set { _MainType = value; }
        }

        public static DataTable InstallmentTypeTable
        {
            get
            {
                if (_InstallmentTypeTable == null)
                    _InstallmentTypeTable = SysData.SharpVisionBaseDb.ReturnDatatable(SearchStr);
                return _InstallmentTypeTable;
 
            }
        }
        public static string SearchStr
        {
            get
            {
                string Returned = " SELECT InstallmentTypeID,InstallmentTypeNameA, "+
                    "InstallmentTypeNameE,InstallmentTypePeriodAmount,InstallmentTypePeriod,InstallmentMainType "+
                    "  FROM   CRMInstallmentType";

                return Returned;
            }
        }

        #endregion
        #region Private Methods

        #endregion
        #region Public Methods
        public override void Add()
        {
            string strSql = " INSERT INTO CRMInstallmentType (InstallmentTypeNameA, InstallmentTypeNameE,InstallmentTypePeriod,InstallmentTypePeriodAmount)" +
                            " VALUES     ('"+_NameA+"','"+_NameE+"',"+_Period+","+_PeriodAmount+") ";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);

        }

        public override void Edit()
        {
            string strSql = " UPDATE    CRMInstallmentType " +
                            " SET  InstallmentTypeNameA = '"+_NameA+"'" +
                            " , InstallmentTypeNameE = '" + _NameE + "'" +
                            ",InstallmentTypePeriod = "+_Period+""+
                            ",InstallmentTypePeriodAmount = "+_PeriodAmount+""+
                            " Where (CRMInstallmentType.InstallmentTypeID = "+_ID+")";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);

        }

        public override DataTable Search()
        {
            string strSql = SearchStr + " WHERE    (CRMInstallmentType.Dis  IS NULL)";
            if (_ID != 0)
                strSql = strSql + " CRMInstallmentType.InstallmentTypeID) = " + _ID.ToString();
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }

        public override void Delete()
        {
            string strSql = " UPDATE    CRMInstallmentType SET  Dis = GetDate()"+
                " where InstallmentTypeID ="+ _ID;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }

        #endregion

    }
}
