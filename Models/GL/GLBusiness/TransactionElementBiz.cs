using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.Base.BaseDataBase;
using SharpVision.Base.BaseBusiness;
using SharpVision.GL.GLDataBase;
using SharpVision.SystemBase;
using SharpVision.COMMON.COMMONBusiness;
 
namespace SharpVision.GL.GLBusiness
{
    public enum TransactionDirection
    {
        Credit,
        Debit
    }
    public class TransactionElementBiz
    {
        #region Private Data
        protected TransactionElementDb _TransactionElementDb;
        AccountBiz _AccountBiz;
        TransactionBiz _TransactionBiz;
        CostCenterBiz _CostCenterBiz;
        double _AccountCreditBalance;
        double _AccountDebitBalance;
        int _GeneratedID;
        /// <summary>
        /// Direction presents Either the element is eithe depit or credit
        /// true in Case of Credit œ«∆‰
        /// false in case of debit „œÌ‰
        /// </summary>
        #endregion
        #region Constractors
        public TransactionElementBiz()
        {
            _TransactionElementDb = new TransactionElementDb();
            _AccountBiz = new AccountBiz();
        }
        public TransactionElementBiz(DataRow objDR)
        {
            _TransactionElementDb = new TransactionElementDb(objDR);
            _AccountBiz = new AccountBiz(objDR);
            if (_TransactionElementDb.CostCenter != 0)
                _CostCenterBiz = new CostCenterBiz(objDR);
            _TransactionBiz = new TransactionBiz(objDR);
        }
        #endregion
        #region Public Accessorice
        public int ID
        {
            set
            {
                _TransactionElementDb.ID = value;
            }
            get
            {
                return _TransactionElementDb.ID;
            }
        }
        public int TRansaction
        {
            set
            {
                _TransactionElementDb.TRansaction = value;
            }
            get
            {
                return _TransactionElementDb.TRansaction;
            }
        }
       
        public bool Direction
        {
            set
            {
                _TransactionElementDb.Direction = value;
            }
            get
            {
                return _TransactionElementDb.Direction;
            }
        }
        public double Value
        {
            set
            {
                _TransactionElementDb.Value = value;
            }
            get
            {
                return _TransactionElementDb.Value;
            }
        }
        public AccountBiz AccountBiz
        {
            set
            {
                _AccountBiz = value;
            }
            get
            {
                if (_AccountBiz == null)
                    _AccountBiz = new AccountBiz();
                return _AccountBiz;
            }
        }
        public CostCenterBiz CostCenterBiz
        {
            set
            {
                _CostCenterBiz = value;
            }
            get
            {
                if (_CostCenterBiz == null)
                    _CostCenterBiz = new CostCenterBiz();
                return _CostCenterBiz;
            }
        }
        public string CostCenterDisplayedDesc
        {
            get
            {
                string Returned = "";
                Returned = CostCenterBiz.ID != 0 ? _CostCenterBiz.Name :
                            (_TransactionElementDb.UnitStr!= "" && _TransactionElementDb.CustomerStr != ""?_TransactionElementDb.CustomerStr+"_" +_TransactionElementDb.UnitStr:"");
               
                return Returned;
            }
        }
        public double CrditeTotalValue
        {
            set
            { 
                
              
                     _TransactionElementDb.Value = value;
            }
            get
            {
                if (!Direction)
                    return _TransactionElementDb.Value;
                else
                    return 0;
            }
        }
        public double DebitTotalValue
        {
            set 
            {
                if (Direction)
                     _TransactionElementDb.Value = value;
 
            }
            get
            {
                if (Direction)
                    return _TransactionElementDb.Value;
                else
                    return 0;
            }
        }
        public int Order
        {
            set
            {
                _TransactionElementDb.Order = value;
            }
            get
            {
                return _TransactionElementDb.Order;
            }
        }
        public string Desc
        {
            set
            {
                _TransactionElementDb.Desc = value;
            }
            get
            {
                return _TransactionElementDb.Desc;
            }
        }
        public TransactionBiz TransactionBiz
        {
            set
            {
                _TransactionBiz = value;
            }
            get
            {
                if (_TransactionBiz == null)
                    _TransactionBiz = new TransactionBiz();
                return _TransactionBiz;
            }
        }
        public double AccountCreditBalance
        {
            set
            {
                _AccountCreditBalance = value;
            }
            get
            {
                return _AccountCreditBalance;
            }
        }
        public double AccountDebitBalance
        {
            set
            {
                _AccountDebitBalance = value;
            }
            get
            {
                return _AccountDebitBalance;
            }
        }
        public double DebitBalance
        {
            set
            {
                _TransactionElementDb.DebitBalance = value;
            }
            get
            {
                return _TransactionElementDb.DebitBalance;
            }
        }
        public double CreditBalance
        {
            set
            {
                _TransactionElementDb.CreditBalance = value;
            }
            get
            {
                return _TransactionElementDb.CreditBalance;
            }
        }
        internal int GeneratedID
        {
            set
            {
                _GeneratedID = value;
            }
            get
            {
                return _GeneratedID;
            }
        }
        public int CellID
        {
            set
            {
                _TransactionElementDb.CellID = value;
            }
            get
            {
                return _TransactionElementDb.CellID;
            }
        }
        public int ReservationID
        {
            set
            {
                _TransactionElementDb.ReservationID = value;
            }
            get
            {
                return _TransactionElementDb.ReservationID;
            }
        }
        public string CellName
        {
            set
            {
                _TransactionElementDb.CellName = value ;
            }
            get
            {
                return _TransactionElementDb.CellName;
            }
        }
        public string CellFamilyName
        {
            set
            {
                _TransactionElementDb.CellFamilyName = value;
            }
            get
            {
                return _TransactionElementDb.CellFamilyName;
            }
        }
        public int CellFamilyID
        {
            set
            {
                _TransactionElementDb.CellFamilyID = value;
            }
            get
            {
                return _TransactionElementDb.CellFamilyID;
            }
        }

        public int SystemSource
        {
            set
            {
                _TransactionElementDb.SystemSource = value;
            }
            get
            {
                return _TransactionElementDb.SystemSource;
            }

        }
        public int SystemType
        {
            set
            {
                _TransactionElementDb.SystemType = value;
            }
            get
            {
                return _TransactionElementDb.SystemType;
            }
        }
        #endregion
        #region Private Methods
        #endregion
        #region Public Methods
        public virtual void Add()
        {
            _TransactionElementDb.TRansaction = _TransactionBiz.ID;
            _TransactionElementDb.Account = _AccountBiz.ID;
            _TransactionElementDb.Add();
        }
        public virtual void Edit()
        {
            _TransactionElementDb.Edit();
        }
        public virtual void Delete()
        {
            _TransactionElementDb.Delete();
        }
        public TransactionElementBiz Copy()
        {
            TransactionElementBiz Returned = new TransactionElementBiz();
            Returned.Direction = Direction;
            Returned.AccountBiz = AccountBiz;
            Returned.Value = Value;
            Returned.Desc = Desc;
            Returned.CostCenterBiz = CostCenterBiz;
            Returned.TransactionBiz = TransactionBiz;
            Returned.CellID = CellID;
            Returned.SystemType = SystemType;
            Returned.SystemSource = SystemSource;
            Returned.ReservationID = ReservationID;
            return Returned;
        }
        public void GetDataRow(ref DataRow objDr)
        {
           // DataRow objDr = new TransactionElementCol(true).GetTable().NewRow();
            objDr["ElementID"] = ID;
            objDr["ElementTransaction"] = TRansaction;
            objDr["ElementAccount"] = AccountBiz.ID;
            objDr["ElementDirection"] = Direction ? 1 : 0;
            objDr["ElementValue"] = Value;
            objDr["CostCenterID"] = CostCenterBiz.ID;
            objDr["ElementCostCenter"] = CostCenterBiz.ID;
            objDr["ElementOrder"] = Order;
            objDr["ElementDesc"] = Desc;
            objDr["GeneratedID"] = GeneratedID;
            objDr["ElementCell"] = CellID;
            objDr["ElementReservation"] = ReservationID;
            objDr["ElementSystemSourceID"] = SystemSource;
            objDr["ElementSyetemType"] = SystemType;
           // return objDr;
        }
        #endregion
    }
}
