using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using SharpVision.SystemBase;
namespace SharpVision.CRM.CRMDataBase
{
   public  class BrokerageRuleDb
    {

        #region Constructor
        public BrokerageRuleDb()
        {
        }
        public BrokerageRuleDb(DataRow objDr)
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
        string _Desc;
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
        int _Project;
        public int Project
        {
            set
            {
                _Project = value;
            }
            get
            {
                return _Project;
            }
        }
        int _UnitType;
        public int UnitType
        {
            set
            {
                _UnitType = value;
            }
            get
            {
                return _UnitType;
            }
        }
        double _Perc;
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
        bool _IncludeDeposit;
        public bool IncludeDeposit
        {
            set
            {
                _IncludeDeposit = value;
            }
            get
            {
                return _IncludeDeposit;
            }
        }
        public string AddStr
        {
            get
            {
                string Returned = " insert into CRMBrokerageRule (RuleDesc,RuleProject,RuleUnitType,RulePerc,RuleIncludeDeposit,UsrIns,TimIns) values ('" + Desc + "'," + Project + "," + UnitType + "," + Perc + "," + (IncludeDeposit ? 1 : 0) + "," + SysData.CurrentUser.ID + ",GetDate() ) ";
                return Returned;
            }
        }
        public string EditStr
        {
            get
            {
                string Returned = " update CRMBrokerageRule set RuleDesc='" + Desc + "'" +
           ",RuleProject=" + Project + "" +
           ",RuleUnitType=" + UnitType + "" +
           ",RulePerc=" + Perc + "" +
           ",RuleIncludeDeposit=" + (IncludeDeposit ? 1 : 0) + "" + ",UsrUpd=" + SysData.CurrentUser.ID + @",TimUpd=GetDate()  where RuleID=" + ID ;
                return Returned;
            }
        }
        public string DeleteStr
        {
            get
            {
                string Returned = " update CRMBrokerageRule set Dis = GetDate() where  RuleID=" + ID;
                return Returned;
            }
        }
        public string SearchStr
        {
            get
            {
                string Returned = " select RuleID,RuleDesc,RuleProject,RuleUnitType,RulePerc,RuleIncludeDeposit from CRMBrokerageRule  ";
                return Returned;
            }
        }
        #endregion
        #region Private Method
        void SetData(DataRow objDr)
        {

            if (objDr.Table.Columns["RuleID"] != null)
                int.TryParse(objDr["RuleID"].ToString(), out _ID);

            if (objDr.Table.Columns["RuleDesc"] != null)
                _Desc = objDr["RuleDesc"].ToString();

            if (objDr.Table.Columns["RuleProject"] != null)
                int.TryParse(objDr["RuleProject"].ToString(), out _Project);

            if (objDr.Table.Columns["RuleUnitType"] != null)
                int.TryParse(objDr["RuleUnitType"].ToString(), out _UnitType);

            if (objDr.Table.Columns["RulePerc"] != null)
                double.TryParse(objDr["RulePerc"].ToString(), out _Perc);

            if (objDr.Table.Columns["RuleIncludeDeposit"] != null)
                bool.TryParse(objDr["RuleIncludeDeposit"].ToString(), out _IncludeDeposit);
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
