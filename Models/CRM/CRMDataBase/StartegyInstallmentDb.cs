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
    public class StrategyInstallmentDb
    {
        #region Private Data
        protected int _StrategyID;
        protected int _InstallmentNo;
        protected int _InstallmentType;
        protected double _InstallmentValue;
        protected double _Perc;
        protected int _InstallmentPeriod;
        protected double _PeriodAmount;
        #endregion

        #region Constructors
        public StrategyInstallmentDb()
        { 

        }
        public StrategyInstallmentDb(DataRow objDR)
        {
            _StrategyID = int.Parse(objDR["StrategyID"].ToString());
            _InstallmentNo = int.Parse(objDR["InstallmentNo"].ToString());
            _InstallmentType = int.Parse(objDR["InstallmentType"].ToString());
            _InstallmentValue = double.Parse(objDR["InstallmentValue"].ToString());
            _InstallmentPeriod = int.Parse(objDR["InstallmentPeriod"].ToString());
            _PeriodAmount = double.Parse(objDR["InstallmentPeriodAmount"].ToString());
            _Perc = Double.Parse(objDR["InstallmentPerc"].ToString());
 
        }
        #endregion


        #region Public Properties
        public int StrategyID
        {
            set
            {
                _StrategyID = value;
            }
            get
            {
                return _StrategyID;
            }

        }

        public int InstallmentNo
        {
            set
            {
                _InstallmentNo = value;
            }
            get
            
            
            
            
            {
                return _InstallmentNo;
            }

        }
        public int InstallmentType
        {
            set
            {
                _InstallmentType = value;
            }
            get
            {
                return _InstallmentType;
            }

        }

        public double Perc
        {
            set
            {
                _Perc = value;
            }
            get
            {
                return _Perc;
            }

        }

        public double InstallmentValue
        {
            set
            {
                _InstallmentValue = value;
            }
            get
            {
                return _InstallmentValue;
            }

        }
        public int InstallmentPeriod
        {
            set
            {
                _InstallmentPeriod = value;
            }
            get
            {
                return _InstallmentPeriod;
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
                string Returned = " SELECT     StrategyID, InstallmentNo, InstallmentType, InstallmentValue, InstallmentPeriod,InstallmentPeriodAmount,InstallmentPerc,TypeTable.* " +
                                    " FROM  CRMPaymentStrategyInstallment inner join ("+ InstallmentTypeDb.SearchStr +") as TypeTable"+
                                    " on CRMPaymentStrategyInstallment.InstallmentType =TypeTable.InstallmentTypeID  ";
                return Returned;
            }
        }

       
        #endregion



        #region Private Methods



        #endregion


        #region Public Methods

        public void Add()
        {
            string strSql = " INSERT INTO CRMPaymentStrategyInstallment "+
                                " (StrategyID, InstallmentNo, InstallmentType, InstallmentValue,InstallmentPerc, InstallmentPeriod,InstallmentPeriodAmount) " +
                                " VALUES     (" + _StrategyID + "," + _InstallmentNo + "," + _InstallmentType + "," + _InstallmentValue + "," + _Perc + "," + _InstallmentPeriod + "," + _PeriodAmount + ") ";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }

        public void Edit()
        {
            string strSql = " UPDATE    CRMPaymentStrategyInstallment " +
                            " SET InstallmentNo =" + _InstallmentNo + "" +
                            " , InstallmentType =" + _InstallmentType + "" +
                            " , InstallmentValue =" + _InstallmentValue + "" +
                            " , InstallmentPerc =" + _Perc + "" +
                            " , InstallmentPeriodAmount = "+_PeriodAmount+""+
                            " , InstallmentPeriod =" + _InstallmentPeriod + " " +
                            " Where  StrategyID =" + _StrategyID.ToString();
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }

        public  DataTable Search()
        {
            string strSql = SearchStr + " WHERE    (Dis IS NULL)";
            if (_StrategyID != 0)
                strSql = strSql + " And StrategyID = " + _StrategyID.ToString();
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }

        public void Delete()
        {
            string strSql = " UPDATE    CRMPaymentStrategyInstallment SET   Dis = GetDate() " +
                             " Where  StrategyID =" + _StrategyID.ToString();
        }
        #endregion
    }
}
