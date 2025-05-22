using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace SharpVision.HR.HRBusiness
{
    public class EstimationFuzzyValueBiz
    {
        #region Private Data

        #endregion
        #region Constructors
        public EstimationFuzzyValueBiz()
        { }
     
        #endregion
        #region Public Properties
        int _ID;
        public int ID
        {
            set => _ID = value;
            get => _ID;
        }
        string _NameA;
        public string NameA { set => _NameA = value; get => _NameA; }
        string _NameE;
        public string NameE{ set => _NameE = value; get => _NameE; }
        string _ProposedAction;
        public string ProposedAction
        { set => _ProposedAction = value; get => _ProposedAction; }
       
        double _StartValue;
        public double StartValue { set => _StartValue = value; get => _StartValue; }
        double _EndValue;
        public double EndValue { set => _EndValue = value; get => _EndValue; }
        double _AVGValue;
        public double AVGValue { set => _AVGValue = value; get => _AVGValue; }

        #endregion
        #region Private Methods

        #endregion
        #region Public Methods
        static List<EstimationFuzzyValueBiz> _EstimationFuzzyValueLst;
        public static List<EstimationFuzzyValueBiz> EstimationFuzzyValueLst
        {
            get
            {
                if (_EstimationFuzzyValueLst == null)
                {
                    _EstimationFuzzyValueLst = new List<EstimationFuzzyValueBiz>();
                    _EstimationFuzzyValueHs = new Hashtable();
                    EstimationFuzzyValueBiz objBiz = new EstimationFuzzyValueBiz() { ID = 0, AVGValue = 0, EndValue = 0, NameA = "غير محدد", NameE = "NotSpecified", StartValue = 0 };
                    _EstimationFuzzyValueLst.Add(objBiz);
                    _EstimationFuzzyValueHs.Add(objBiz.ID.ToString(), objBiz);
                    objBiz = new EstimationFuzzyValueBiz() { ID = 1, AVGValue = 25, EndValue = 49, NameA = "مرفوض", NameE = "Rejected", StartValue = 0, ProposedAction = "Shift or Dispense" };
                    _EstimationFuzzyValueLst.Add(objBiz);
                    _EstimationFuzzyValueHs.Add(objBiz.ID.ToString(), objBiz);

                    objBiz = new EstimationFuzzyValueBiz() { ID = 2, AVGValue = 55, EndValue = 59, NameA = "ضعيف", NameE = "Poor", StartValue = 50, ProposedAction = "Coach, Rotate & Monitor" };
                    _EstimationFuzzyValueLst.Add(objBiz);
                    _EstimationFuzzyValueHs.Add(objBiz.ID.ToString(), objBiz);

                    objBiz = new EstimationFuzzyValueBiz() { ID = 3, AVGValue = 65, EndValue = 69, NameA = "مقبول", NameE = "Accepted", StartValue = 60, ProposedAction = "Train, Enrich & Monitor" };
                    _EstimationFuzzyValueLst.Add(objBiz);
                    _EstimationFuzzyValueHs.Add(objBiz.ID.ToString(), objBiz);

                    objBiz = new EstimationFuzzyValueBiz() { ID = 4, AVGValue = 75, EndValue = 79, NameA = "جيد", NameE = "Good", StartValue = 70, ProposedAction = "Keep & Empower" };
                    _EstimationFuzzyValueLst.Add(objBiz);
                    _EstimationFuzzyValueHs.Add(objBiz.ID.ToString(), objBiz);
                    objBiz = new EstimationFuzzyValueBiz() { ID = 5, AVGValue = 85, EndValue = 89, NameA = "جيد جدا", NameE = "VeryGood", StartValue = 80, ProposedAction = "Promote& Empower" };
                    _EstimationFuzzyValueLst.Add(objBiz);
                    _EstimationFuzzyValueHs.Add(objBiz.ID.ToString(), objBiz);
                    objBiz = new EstimationFuzzyValueBiz() { ID = 6, AVGValue = 95, EndValue = 100, NameA = "متميز", NameE = "Distinctive", StartValue = 90, ProposedAction = "Promote & Invest" };
                    _EstimationFuzzyValueLst.Add(objBiz);
                    _EstimationFuzzyValueHs.Add(objBiz.ID.ToString(), objBiz);

                }
                return _EstimationFuzzyValueLst;
            }
        }
        static Hashtable _EstimationFuzzyValueHs;
        public static Hashtable EstimationFuzzyValueHs
        {
            get 
            {
                if (_EstimationFuzzyValueHs == null)
                {
                    List<EstimationFuzzyValueBiz> arrFuzzy = EstimationFuzzyValueLst;
                }
                return _EstimationFuzzyValueHs;
            }
        }
        public static EstimationFuzzyValueBiz GetFuzzyValue(double dblValue)
        {
            EstimationFuzzyValueBiz Returned = new EstimationFuzzyValueBiz();
            Returned.NameA = "";
            Returned.NameE = "";
            foreach (EstimationFuzzyValueBiz objBiz in EstimationFuzzyValueLst)
            {
                if (dblValue >0 && dblValue >= objBiz.StartValue && dblValue <= objBiz.EndValue)
                    return objBiz;
            }
            return Returned;
        }
        public static EstimationFuzzyValueBiz GetFuzzyValueBiz(EstimationFuzzyValue objValue)
        {
            EstimationFuzzyValueBiz Returned = new EstimationFuzzyValueBiz();
            Returned.NameA = "";
            Returned.NameE = "";
            if (EstimationFuzzyValueHs[((int)objValue).ToString()] != null)
                Returned = (EstimationFuzzyValueBiz)EstimationFuzzyValueHs[((int)objValue).ToString()];
            if (Returned.ID != 0)
            { 
            }
            return Returned;
        }
        #endregion
    }
}
