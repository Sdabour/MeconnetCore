using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using SharpVision.SystemBase;
namespace SharpVision.CRM.CRMDataBase
{
    public class ReservationBrokerageRuleDb
    {

        #region Constructor
        public ReservationBrokerageRuleDb()
        {
        }
        public ReservationBrokerageRuleDb(DataRow objDr)
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
        int _RuleID;
        public int RuleID
        {
            set
            {
                _RuleID = value;
            }
            get
            {
                return _RuleID;
            }
        }
        double _RuleValue;
        public double RuleValue
        {
            set
            {
                _RuleValue = value;
            }
            get
            {
                return _RuleValue;
            }
        }
        double _RuleReservationValue;
        public double RuleReservationValue
        {
            set
            {
                _RuleReservationValue = value;
            }
            get
            {
                return _RuleReservationValue;
            }
        }
        double _RulePerc;
        public double RulePerc
        {
            set
            {
                _RulePerc = value;
            }
            get
            {
                return _RulePerc;
            }
        }
        double _RuleDonatedValue;
        public double RuleDonatedValue
        {
            set
            {
                _RuleDonatedValue = value;
            }
            get
            {
                return _RuleDonatedValue;
            }
        }
        public string AddStr
        {
            get
            {
                string Returned = " insert into CRMReservationBrokerageRule (ReservationID,ReservationRuleID,ReservationRuleReservationValue,ReservationRuleValue,ReservationRulePerc,ReservationRuleDonatedValue,UsrIns,TimIns)  "+
                    @" select  " + ID + " as ReservationID," + RuleID+ " RuleID1," + _RuleReservationValue + " as ReservationValue," + RuleValue + " as RuleValue," + RulePerc + " as RulePerc," + RuleDonatedValue + " as RuleDonatedValue  where not exists (select ReservationID from CRMReservationBrokerageRule where ReservationID = "+ _ID +")  "+ EditStr;
                return Returned;
            }
        }
        public string EditStr
        {
            get
            {
                string Returned = " update CRMReservationBrokerageRule set ReservationRuleID=" + RuleID + "" +
           ",ReservationRuleReservationValue="+_RuleReservationValue +
           ",ReservationRuleValue=" + RuleValue + "" +
           ",ReservationRulePerc=" + RulePerc + "" +
           ",ReservationRuleDonatedValue=" + RuleDonatedValue + "" + " where ReservationID ="+_ID;
                return Returned;
            }
        }
        public string DeleteStr
        {
            get
            {
                string Returned = " update CRMReservationBrokerageRule set Dis = GetDate() where  ";
                return Returned;
            }
        }
        public string SearchStr
        {
            get
            {
                string Returned = @" select ReservationID as BrokerageReservationID,ReservationRuleID,ReservationRuleReservationValue,ReservationRuleValue,ReservationRulePerc,ReservationRuleDonatedValue,RuleTable.* 
 from CRMReservationBrokerageRule  
 inner join ("+ new BrokerageRuleDb().SearchStr + @") as RuleTable
 on CRMReservationBrokerageRule.ReservationRuleID = RuleTable.RuleID ";


                return Returned;
            }
        }
        #endregion
        #region Private Method
        void SetData(DataRow objDr)
        {

            if (objDr.Table.Columns["BrokerageReservationID"] != null)
                int.TryParse(objDr["BrokerageReservationID"].ToString(), out _ID);

            if (objDr.Table.Columns["ReservationRuleID"] != null)
                int.TryParse(objDr["ReservationRuleID"].ToString(), out _RuleID);
            //ReservationRuleReservationValue
            if (objDr.Table.Columns["ReservationRuleReservationValue"] != null)
                double.TryParse(objDr["ReservationRuleReservationValue"].ToString(), out _RuleReservationValue);
            if (objDr.Table.Columns["ReservationRuleValue"] != null)
                double.TryParse(objDr["ReservationRuleValue"].ToString(), out _RuleValue);

            if (objDr.Table.Columns["ReservationRulePerc"] != null)
                double.TryParse(objDr["ReservationRulePerc"].ToString(), out _RulePerc);

            if (objDr.Table.Columns["ReservationRuleDonatedValue"] != null)
                double.TryParse(objDr["ReservationRuleDonatedValue"].ToString(), out _RuleDonatedValue);
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
            string strSql = SearchStr + " where Dis is null ";


            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        #endregion
    }
}
