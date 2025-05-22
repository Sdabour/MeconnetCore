using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using SharpVision.SystemBase;
namespace SharpVision.HR.HRDataBase
{
    public class ApplicantWorkerEstimationStatementElementDb
    {
        #region Private Data
        protected int _ID;
        protected int _Element;
        protected double _EstimationValue;
        protected double _ElementValue;
        public ApplicantWorkerEstimationStatementElementDb()
        {
        }
        public ApplicantWorkerEstimationStatementElementDb(DataRow objDr)
        {
            SetData(objDr);
        }
        #endregion
        #region Constructors

        #endregion
        #region Public Properties
        public int ID { set { _ID = value; } get { return _ID; } }
        public int Element { set { _Element = value; } get { return _Element; } }
        string _Desc;
        public string Desc { set => _Desc = value;
            get=> _Desc; }
        public double EstimationValue { set { _EstimationValue = value; } get { return _EstimationValue; } }
        public double ElementValue { set { _ElementValue = value; } get { return _ElementValue; } }
        bool _IsFuzzyValue;
        public bool IsFuzzyValue
        {
            set { _IsFuzzyValue = value; }
            get { return _IsFuzzyValue; }
        }
        int _FuzzyValue;
        public int FuzzyValue
        {
            set { _FuzzyValue = value; }
            get { return _FuzzyValue; }
        }
        int _Group;
        public int Group
        {
            set => _Group = value;
            get => _Group;
        }
        double _GroupPerc;
        public double GroupPerc
        {
            set => _GroupPerc = value;
            get => _GroupPerc;
        }
        int _GroupOrder;
        public int GroupOrder
        {
            set => _GroupOrder = value;
            get => _GroupOrder;
        }
        string _GroupNameA;
        public string GroupNameA
        { set => _GroupNameA = value; get => _GroupNameA; }

        string _GroupNameE;
        public string GroupNameE
        { set => _GroupNameE = value; get => _GroupNameE; }
        int _TempElement;
        public int TempElement
        {
            set => _TempElement = value;get => _TempElement;
        }
        double _Weight;
        public double Weight
        { set => _Weight = value; get => _Weight; }
        public string AddStr
        {
            get
            {
                int intIsFuzzyValue = _IsFuzzyValue ? 1 : 0;
                string strReturn = @" Insert into HRApplicantWorkerEstimationStatementElement (ApplicantEstimationStatement, Element,ElementDesc, EstimationValue,ElementValue,ElementIsFuzzyValue,ElementFuzzyValue,ElementGroup, ElementGroupPerc, ElementGroupOrder,ElementWeight,ElementTempElement
)" +
                                   " Values (" + _ID + "," + _Element + " ,'" +_Desc+"',"+ _EstimationValue + "," + _ElementValue + "," + intIsFuzzyValue + "," + _FuzzyValue + "," + _Group + "," + _GroupPerc + "," + _GroupOrder+ ","+ _Weight +"," + _TempElement + ") ";

                return strReturn;
            }
        }
        public string DeleteStr
        {
            get
            {
                string strReturn = " Delete From HRApplicantWorkerEstimationStatementElement Where ApplicantEstimationStatement = " + _ID + "";
                return strReturn;
            }
        }
        public static string SearchStr
        {
            get
            {
                string strReturn = @" SELECT  ApplicantEstimationStatement, Element,ElementDesc, EstimationValue" +
                @",ElementValue,ElementIsFuzzyValue,ElementFuzzyValue,ElementGroupPerc,ElementGroupOrder,ElementWeight,ElementTempElement,ElementTable.*,StatementElementGroupTable.GroupElementNameA AS StatementElementGroupNameA, StatementElementGroupTable.GroupElementNameE AS StatementElementGroupNameE
  " +
                               @" FROM         HRApplicantWorkerEstimationStatementElement" +
                               " left outer join (" + ElementDb.SearchStr + ") as ElementTable " +
                               @" On ElementTable.ElementID = HRApplicantWorkerEstimationStatementElement.Element 
 LEFT OUTER JOIN
                         dbo.HRElementGroup AS StatementElementGroupTable ON dbo.HRApplicantWorkerEstimationStatementElement.ElementGroup = StatementElementGroupTable.GroupElementID ";
                return strReturn;
            }
        }
        #endregion
        #region Private Methods
        void SetData(DataRow objDr)
        {
            if (objDr["ApplicantEstimationStatement"].ToString() == "")
                return;
            _ID = int.Parse(objDr["ApplicantEstimationStatement"].ToString());

            _Element = int.Parse(objDr["Element"].ToString());
            _EstimationValue = double.Parse(objDr["EstimationValue"].ToString());
            _ElementValue = double.Parse(objDr["ElementValue"].ToString());
            bool.TryParse(objDr["ElementIsFuzzyValue"].ToString(), out _IsFuzzyValue);
            int.TryParse(objDr["ElementFuzzyValue"].ToString(), out _FuzzyValue);
            if (objDr.Table.Columns["ElementGroup"] != null && objDr["ElementGroup"].ToString() != "")
                int.TryParse(objDr["ElementGroup"].ToString(), out _Group);

            if (objDr.Table.Columns["ElementGroupPerc"] != null && objDr["ElementGroupPerc"].ToString() != "")
                double.TryParse(objDr["ElementGroupPerc"].ToString(), out _GroupPerc);
            if (objDr.Table.Columns["ElementGroupOrder"] != null && objDr["ElementGroupOrder"].ToString() != "")
                int.TryParse(objDr["ElementGroupOrder"].ToString(), out _GroupOrder);
            if (objDr.Table.Columns["ElementDesc"] != null)
            {
                _Desc = objDr["ElementDesc"].ToString();
            }
            if (objDr.Table.Columns["ElementWeight"] != null && objDr["ElementWeight"].ToString() != "")
               double.TryParse(objDr["ElementWeight"].ToString(), out _Weight);
            if (objDr.Table.Columns["ElementTempElement"] != null && objDr["ElementTempElement"].ToString() != "")
                int.TryParse(objDr["ElementTempElement"].ToString(), out _TempElement);
            if (objDr.Table.Columns["StatementElementGroupNameA"] != null)
            {
                _GroupNameA = objDr["StatementElementGroupNameA"].ToString();
            }
            if (objDr.Table.Columns["StatementElementGroupNameE"] != null)
            {
                _GroupNameE = objDr["StatementElementGroupNameE"].ToString();
            }
        }
        #endregion
        #region Public Methods
        public void Add()
        {
            SysData.SharpVisionBaseDb.ExecuteNonQuery(AddStr);
        }
        public void Delete()
        {
            SysData.SharpVisionBaseDb.ExecuteNonQuery(DeleteStr);
        }
        public DataTable Search()
        {
            string StrSql = SearchStr + " Where 1=1 ";
            if (_ID != 0)
                StrSql += " And (ApplicantEstimationStatement = " + _ID + ")";

            return SysData.SharpVisionBaseDb.ReturnDatatable(StrSql);
        }
        #endregion
    }
}
