using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.Base.BaseDataBase;
using SharpVision.Base.BaseBusiness;
using SharpVision.CRM.CRMDataBase;
using SharpVision.SystemBase;
using SharpVision.COMMON.COMMONBusiness;

namespace SharpVision.CRM.CRMBusiness
{
    public enum InstallmentType
    {
        Installment=1,//ﬁ”ÿ
        DownPayment=3,//œ›⁄… „ﬁœ„…
        DelivaryAmount=8,//œ›⁄… «” ·«„
        ThreeMonthAMount=11,//œ›⁄… »⁄œ À·«À ‘ÂÊ—
        SixMonthAmount=12,//œ›⁄… »⁄œ ” … «‘Â—

    }
    public enum InstallmentMainType
    {
        NotSpecified,
        Installment,//«ﬁ”«ÿ
        PeriodicPayment,//œ›⁄« 
        DeliveryPayment//œ›⁄… «” ·«„

    }
    public class InstallmentTypeBiz : BaseSingleBiz
    {
        #region Private Data
        //InstallmentTypeDb _InstallmentTypeDb;
        ReservationInstallmentCol _InstallmentCol;
        #endregion
        #region Constructors
        public InstallmentTypeBiz()
        {
            _BaseDb = new InstallmentTypeDb();
        }
        public InstallmentTypeBiz(int intID)
        {
            DataRow[] arrDr = InstallmentTypeDb.InstallmentTypeTable.Select("InstallmentTypeID=" + intID);
            if (arrDr.Length == 0)
                _BaseDb = new InstallmentTypeDb();
            else
                _BaseDb = new InstallmentTypeDb(arrDr[0]);
        }

        
        
        public InstallmentTypeBiz(DataRow objDR)
        {
            _BaseDb = new InstallmentTypeDb(objDR);
        }

        #endregion
        #region Public Properties
        public ReservationInstallmentCol InstallmentCol
        {
            set
            {
                _InstallmentCol = value;
            }
            get
            {
                return _InstallmentCol;
            }
        }
        public Period Period
        {
            set
            {
                ((InstallmentTypeDb)_BaseDb).Period = (int)value;
            }
            get
            {
                return (Period)((InstallmentTypeDb)_BaseDb).Period;
            }

        }
        public double PeriodAmount
        {
            set
            {
                ((InstallmentTypeDb)_BaseDb).PeriodAmount = value;
            }
            get
            {
                return((InstallmentTypeDb)_BaseDb).PeriodAmount;
            }

        }
        public InstallmentMainType MainType
        {
            set
            {
                ((InstallmentTypeDb)_BaseDb).MainType = (int)value; 
            }
            get
            {
                return (InstallmentMainType)((InstallmentTypeDb)_BaseDb).MainType;
            }

        }
        public static List<string> InstallmentMainTypeLst
        {
            get
            {
                List<string> Returned = new List<string>();
        //          NotSpecified,
                Returned.Add("€Ì— „Õœœ");
        //Installment,//«ﬁ”«ÿ
                Returned.Add("«ﬁ”«ÿ");
        //PeriodicPayment,//œ›⁄« 
                Returned.Add("œ›⁄« ");
        //DeliveryPayment//œ›⁄… «” ·«„
                Returned.Add("œ›⁄… «” ·«„");
                return Returned;
            }
        }
        #endregion
        #region Private Methods

        #endregion
        #region Public Methods
        public void Add()
        {
            _BaseDb.Add();
        }
        public void Edit()
        {
            _BaseDb.Edit();
        }
        public void Delete()
        {
            _BaseDb.Delete();
        }
        #region OledCode
        //public static void Add(string  strNameA, string strNameE)
        //{
        //    InstallmentTypeDb objInstallmentTypeDb = new InstallmentTypeDb();
        //    objInstallmentTypeDb.NameA = strNameA;
        //    objInstallmentTypeDb.NameE = strNameE;
        //    objInstallmentTypeDb.Add();
        //}
        //public static void Edit(int intPaymentID, string strNameA, string strNameE)
        //{
        //    InstallmentTypeDb objInstallmentTypeDb = new InstallmentTypeDb();
        //    objInstallmentTypeDb.ID = intPaymentID;
        //    objInstallmentTypeDb.NameA = strNameA;
        //    objInstallmentTypeDb.NameE = strNameE;
        //    objInstallmentTypeDb.Edit();
        //}
        //public static void Delete(int intID)
        //{
        //    InstallmentTypeDb objInstallmentTypeDb = new InstallmentTypeDb();
        //    objInstallmentTypeDb.ID = intID;
        //    objInstallmentTypeDb.Delete();
        //}
        #endregion
        #endregion
    }
}
