using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlgorithmatMN.MN.MNDb;
using System.Data;
namespace AlgorithmatMN.MN.MNBiz
{
    public class ROBiz
    {

        #region Constructor
        public ROBiz()
        {
            _RODb = new RODb();
        }
        public ROBiz(DataRow objDr)
        {
            _RODb = new RODb(objDr);
        }
        public ROBiz(int intID,string strProjectCode,string strunitCode)
        {
            RODb objDb = new RODb();
            objDb.ID = intID;
            objDb.ProjectCode = strProjectCode;
            objDb.Code = strunitCode;
            DataTable dtTemp = objDb.Search();
            
            if (dtTemp.Rows.Count > 0)
            {
                _RODb = new RODb(dtTemp.Rows[0]);
            }
            else 
            {
                _RODb = new RODb();
            }
        }
        #endregion
        #region Private Data
        RODb _RODb;
        #endregion
        #region Properties
        public int ID
        {
            set
            {
                _RODb.ID = value;
            }
            get
            {
                return _RODb.ID;
            }
        }
        public string Code
        {
            set
            {
                _RODb.Code = value;
            }
            get
            {
                return _RODb.Code;
            }
        }
        public double Area
        {
            set
            {
                _RODb.Area = value;
            }
            get
            {
                return _RODb.Area;
            }
        }
        public double Value
        { get => _RODb.Value; }
        public DateTime ContractingDate { get => _RODb.ContractingDate; }
        public bool IsCanceled { get => _RODb.IsCanceled; }
        public DateTime CancelDate { get => _RODb.CancelDate; }
        public string Key1 { get => ProjectCode + "-" + Code+"-"+ReservationID.ToString(); }
        public string Key { get => ID.ToString(); }
        public string TowerCode
        {
            set
            {
                _RODb.TowerCode = value;
            }
            get
            {
                return _RODb.TowerCode;
            }
        }
        public string ProjectCode
        {
            set
            {
                _RODb.ProjectCode = value;
            }
            get
            {
                return _RODb.ProjectCode;
            }
        }
        public int Type
        {
            set
            {
                _RODb.Type = value;
            }
            get
            {
                return _RODb.Type;
            }
        }
        public string TypeStr { get => Type == 1 ? "سكني" : (Type == 2 ? "تجاري" : (Type==3?"اقتصادى":"ادارى")); }

        public int ReservationID
        {
            set
            {
                _RODb.ReservationID = value;
            }
            get
            {
                return _RODb.ReservationID;
            }
        }
        public double TypeWeight
        { get => Type == 1 ? 1 : 2; }
        public string SapContract
        {
            set
            {
                _RODb.SapContract = value;
            }
            get
            {
                return _RODb.SapContract;
            }
        }
        public string SapCustomerNo
        {
            set
            {
                _RODb.SapCustomerNo = value;
            }
            get
            {
                return _RODb.SapCustomerNo;
            }
        }
        public string Customer
        {
            set
            {
                _RODb.Customer = value;
            }
            get
            {
                return _RODb.Customer;
            }
        }
        public DateTime DeliveryDate
        {
            set
            {
                _RODb.DeliveryDate = value;
            }
            get
            {
                return _RODb.DeliveryDate;
            }
        }
        public bool IsEnded
        { set => _RODb.IsEnded = value;
            get => _RODb.IsEnded;
        }
        public DateTime EndDate
        {
            set
            {
                _RODb.EndDate = value;
            }
            get
            {
                return _RODb.EndDate;
            }
        }
        public double InitialMaintainanceValue
        {
            set
            {
                _RODb.InitialMaintainanceValue = value;
            }
            get
            {
                return _RODb.InitialMaintainanceValue;
            }
        }
        public double MaintainanceBonusPercPerYear
        {
            set
            {
                _RODb.MaintainanceBonusPercPerYear = value;
            }
            get
            {
                return _RODb.MaintainanceBonusPercPerYear;
            }
        }
        CreditCol _CreditCol;
        public CreditCol CreditCol 
        { set => _CreditCol = value;
            get 
            {
                if (_CreditCol == null)
                    _CreditCol = new CreditCol(true);
                return _CreditCol;
            }
        }
        public double Closing
        { get
            { double Returned = 0;
                Returned = CreditCol.Count > 0 ? CreditCol[CreditCol.Count - 1].Closing : 0;
                    return Returned;
            }
        }
        public double TotalCost
        { get => CreditCol.Count > 0 ? CreditCol.Cast<CreditBiz>().Sum(x => x.Cost) : 0; }
        public double TotalBonus
        { get => CreditCol.Count > 0 ? CreditCol.Cast<CreditBiz>().Sum(x => x.BonusValue) : 0; }
        CreditRangeBiz _RangeBiz;
        public CreditRangeBiz RangeBiz
        { set => _RangeBiz = value;
            get { 
                if (_RangeBiz == null)
                                 _RangeBiz = new CreditRangeBiz() { Desc=""};
                return _RangeBiz;
            }
        }
        public double Required
        { get => InitialMaintainanceValue - Closing>0? InitialMaintainanceValue - Closing:0; }
        #endregion
        #region Private Method

        #endregion
        #region Public Method 
        public void Add()
        {
            _RODb.Add();
        }
        public void Edit()
        {
            _RODb.Edit();
        }
        public void EditMaintainanceValue()
        {
            _RODb.EditMaintainanceValue();
        }
        public void Delete()
        {
            _RODb.Delete();
        }
        #endregion
    }
}
