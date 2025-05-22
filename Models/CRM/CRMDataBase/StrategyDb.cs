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
    public class StrategyDb : BaseSingleDb
    {
        #region Private Data
        protected int _ModelID;
        protected double _ProfitValue;
        protected bool _ProfitIsCompound;
        protected int _ProfitPeriod;
        protected double _PeriodAmount;
        protected int _Period;
        protected double _TotalValue;


        DataTable _InstallmentTable;

        #endregion

        #region Constructors
        public StrategyDb()
        {

        }

        public StrategyDb(int intID)
        {
            _ID = intID;
            DataTable dtTemp = Search();
            DataRow objDR = Search().Rows[0];
            _ModelID = int.Parse(objDR["ModelID"].ToString());
            _NameA = objDR["StrategyNameA"].ToString();
            _NameE = objDR["StrategyNameE"].ToString();
            _Period = int.Parse(objDR["StrategyPeriod"].ToString());
            _PeriodAmount = double.Parse(objDR["StrategyPeriodAmount"].ToString());
            _ProfitIsCompound = bool.Parse(objDR["StrategyProfitIsCompound"].ToString());
            _ProfitPeriod = int.Parse(objDR["StrategyProfitPeriod"].ToString());
            _ProfitValue = double.Parse(objDR["StrategyProfitValue"].ToString());
            _TotalValue = double.Parse(objDR["StrategyTotalValue"].ToString());
        }
        public StrategyDb(DataRow objDR)
        {
            _ID = int.Parse(objDR["StrategyID"].ToString());
            _ModelID = int.Parse(objDR["ModelID"].ToString());
            _NameA = objDR["StrategyNameA"].ToString();
            _NameE = objDR["StrategyNameE"].ToString();
            _Period = int.Parse(objDR["StrategyPeriod"].ToString());
            _PeriodAmount = double.Parse(objDR["StrategyPeriodAmount"].ToString());
            _ProfitIsCompound = bool.Parse(objDR["StrategyProfitIsCompound"].ToString());
            _ProfitPeriod = int.Parse(objDR["StrategyProfitPeriod"].ToString());
            _ProfitValue = double.Parse(objDR["StrategyProfitValue"].ToString());
            _TotalValue = double.Parse(objDR["StrategyTotalValue"].ToString());

        }
        #endregion
        #region Public Properties
        public int ModelID
        {
            set
            {
                _ModelID = value;
            }
            get
            {
                return _ModelID;
            }

        }
        public double ProfitValue
        {
            set
            {
                _ProfitValue = value;
            }
            get
            {
                return _ProfitValue;
            }

        }
        public bool ProfitIsCompound
        {
            set
            {
                _ProfitIsCompound = value;
            }
            get
            {
                return _ProfitIsCompound;
            }

        }
        public int ProfitPeriod
        {
            set
            {
                _ProfitPeriod = value;
            }
            get
            {
                return _ProfitPeriod;
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
        public DataTable InstallmentTable
        {
            set
            {
                _InstallmentTable = value;
            }
            get
            {
                return _InstallmentTable;
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
        public static string SearchStr
        {
            get
            {
                string Returned = "SELECT  StrategyID, StrategyNameA, StrategyNameE, StrategyProfitValue, StrategyProfitIsCompound, StrategyProfitPeriod, StrategyPeriodAmount, " +
                                    " StrategyPeriod,StrategyTotalValue,ModelTable.* " +
                                    " FROM CRMUnitModelPaymentStrategy  inner join (" + UnitModelDb.SearchStr + ") as ModelTable on  CRMUnitModelPaymentStrategy.ModelID = ModelTable.ModelID ";
                return Returned;

            }
        }
        #endregion
        #region Private Methods

        #endregion
        #region Public Methods
        public override void Add()
        {
            int intIsCompound = _ProfitIsCompound ? 1 : 0;
            string strSql = " INSERT INTO CRMUnitModelPaymentStrategy " +
                            " (ModelID, StrategyNameA, StrategyNameE, StrategyProfitValue, StrategyProfitIsCompound, StrategyProfitPeriod, StrategyPeriodAmount, " +
                            " StrategyPeriod,StrategyTotalValue)" +
                            " VALUES     (" + _ModelID + ",'" + _NameA + "','" + _NameE + "'," + _ProfitValue + "," + intIsCompound + "," + _ProfitPeriod + "," + _PeriodAmount + "," + _Period + "," + _TotalValue + ") ";
            _ID = SysData.SharpVisionBaseDb.InsertIdentityTable(strSql);
            JoinInstallment();
        }
        public override void Edit()
        {
            string strSql = " UPDATE    CRMUnitModelPaymentStrategy " +
                            " SET  ModelID =" + _ModelID + "" +
                            " , StrategyNameA ='" + _NameA + "','" +
                            " , StrategyNameE ='" + _NameE + "','" +
                            " , StrategyProfitValue =" + _ProfitValue + "" +
                            " , StrategyProfitIsCompound =" + _ProfitIsCompound + "" +
                            " , StrategyProfitPeriod =" + _ProfitPeriod + "" +
                            " , StrategyPeriodAmount =" + _PeriodAmount + "" +
                            " , StrategyPeriod = " + _Period + "" +
                            " , StrategyTotalValue = " + _TotalValue + "" +
                            " where (StrategyID = " + _ID + ")";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
            JoinInstallment();
        }
        public override void Delete()
        {
            string strSql = " UPDATE    CRMUnitModelPaymentStrategy SET    Dis = GetDate() " +
                            " Where StrategyID = " + _ID.ToString();
        }
        public override DataTable Search()
        {
            string strSql = SearchStr + " WHERE    (Dis IS NULL)";
            if (_ID != 0)
                strSql = strSql + " And StrategyID = " + _ID.ToString();
            if (_ModelID != 0)
                strSql = strSql + " And ModelTable.ModelID=" + _ModelID.ToString();
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        public void JoinInstallment()
        {
            string[] arrStr;
            if (_InstallmentTable == null)
                return;
            arrStr = new string[_InstallmentTable.Rows.Count + 1];
            arrStr[0] = "delete from  dbo.CRMPaymentStrategyInstallment where StrategyID=" + _ID;
            int intIndex = 1;
            foreach (DataRow objDr in _InstallmentTable.Rows)
            {
                arrStr[intIndex] = "insert into CRMPaymentStrategyInstallment ( StrategyID, InstallmentNo, InstallmentType, InstallmentValue," +
                    " InstallmentPeriod,InstallmentPeriodAmount, UsrIns, TimIns) values(" + _ID + "," + objDr["No"].ToString() + "," + objDr["Type"].ToString()
                    + "," + objDr["Value"].ToString() + "," + objDr["Period"].ToString() + "," + objDr["PeriodAmount"].ToString() + "," + SysData.CurrentUser.ID + ",GetDate())";
                intIndex++;

            }
            SysData.SharpVisionBaseDb.ExecuteNonQuery(arrStr);

        }
        public DataTable GetInstallment()
        {
            StrategyInstallmentDb objDb = new StrategyInstallmentDb();
            objDb.StrategyID = _ID;
            return objDb.Search();
        }

        #endregion

    }

}
