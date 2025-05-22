using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.UMS.UMSBusiness;
using SharpVision.CRM.CRMDataBase;
using System.Data;
using SharpVision.COMMON.COMMONBusiness;
using SharpVision.COMMON.COMMONDataBase;
using System.Collections;
using SharpVision.Base.BaseBusiness;

using SharpVision.SystemBase;
namespace SharpVision.CRM.CRMBusiness
{

    public enum CustomerSex
    {
        NotSpecified, // ÛíÑ ãÍÏÏ
        Male, // ÏßÑ
        Female // ÃäËì
    }

    public class CustomerBiz : BaseSelfeRelatedBiz
    {
        #region Private Data
        CustomerCol _CustomerChildren;
        CustomerBiz _ParentBiz;
        ReservationCol _ReservationCol;
        CustomerHomeBiz _CustomerHomeBiz;
        CountryBiz _CountryBiz;
        JobBiz _jobBiz;
        IDTypeInstantBiz _IDTypeInstantBiz;
        CustomerTypeBiz _CustomerTypeBiz;
        ContactInstantCol _ContactInstantCol;//added by Mostafa

        CustomerAttachmentCol _CustomerAttachmentCol;
        AttachmentCol _AllAttachmentCol;
        CampaignCustomerContactCol _AllContactCol;
        // New Data
        //CountryBiz _CountryWork;
        //CountryBiz _CountryHome;

        //CityBiz _CityWork;
        //CityBiz _CityHome;

        //RegionBiz _RegionWork;
        //RegionBiz _RegionHome;
        // End New Data

        #endregion
        #region Constructors
        public CustomerBiz()
        {

            _BaseDb = new CustomerDb();
            _Children = new CustomerCol(true);
            _CountryBiz = new CountryBiz(((CustomerDb)_BaseDb).CountryDb);
            // _RegionWork = new RegionBiz(((CustomerDb)_BaseDb).
            _jobBiz = new JobBiz(((CustomerDb)_BaseDb).JobDb);
            _IDTypeInstantBiz = new IDTypeInstantBiz(((CustomerDb)_BaseDb).IDTypeInstantDb);
            _CustomerTypeBiz = new CustomerTypeBiz(((CustomerDb)_BaseDb).CustomerTypeDb);

        }

        public CustomerBiz(int intCustomerID)
        {
            _BaseDb = new CustomerDb();
            _CountryBiz = new CountryBiz();
            _jobBiz = new JobBiz();
            _IDTypeInstantBiz = new IDTypeInstantBiz();
            _CustomerTypeBiz = new CustomerTypeBiz();
            if (intCustomerID == 0)
                return;
            CustomerDb objDb = new CustomerDb();
            objDb.ID = intCustomerID;
            DataTable dtTemp = objDb.Search();
            if (dtTemp.Rows.Count > 0)
            {
                DataRow objDr = dtTemp.Rows[0];
                _BaseDb = new CustomerDb(objDr);
                _CountryBiz = new CountryBiz(((CustomerDb)_BaseDb).CountryDb);
                _jobBiz = new JobBiz(((CustomerDb)_BaseDb).JobDb);
                _IDTypeInstantBiz = new IDTypeInstantBiz(((CustomerDb)_BaseDb).IDTypeInstantDb);
                _CustomerTypeBiz = new CustomerTypeBiz(((CustomerDb)_BaseDb).CustomerTypeDb);
            }

        }
        public CustomerBiz(DataRow objDr)
        {
            _BaseDb = new CustomerDb(objDr);
            _CountryBiz = new CountryBiz(((CustomerDb)_BaseDb).CountryDb);
            _jobBiz = new JobBiz(((CustomerDb)_BaseDb).JobDb);
            _IDTypeInstantBiz = new IDTypeInstantBiz(((CustomerDb)_BaseDb).IDTypeInstantDb);
            _CustomerTypeBiz = new CustomerTypeBiz(((CustomerDb)_BaseDb).CustomerTypeDb);
            //_CountryHome = new CountryBiz();
            //_CountryWork = new CountryBiz();
            //_CityHome = new CityBiz();
            //_CityWork = new CityBiz();
            //_RegionWork = new RegionBiz();
            //_RegionHome = new RegionBiz();

        }
        public CustomerBiz(CustomerDb objCustomerDb)
        {
            _BaseDb = objCustomerDb;
            _CountryBiz = new CountryBiz(((CustomerDb)_BaseDb).CountryDb);
            _jobBiz = new JobBiz(((CustomerDb)_BaseDb).JobDb);
            _IDTypeInstantBiz = new IDTypeInstantBiz(((CustomerDb)_BaseDb).IDTypeInstantDb);
            _CustomerTypeBiz = new CustomerTypeBiz(((CustomerDb)_BaseDb).CustomerTypeDb);


        }

        public CustomerBiz(string strUserName)
        {
            _BaseDb = new CustomerDb(strUserName);
        }
        #endregion
        #region Public Properties
        public CustomerCol CustomerChildren
        {
            set
            {
                _CustomerChildren = value;
            }
            get
            {
                if (_CustomerChildren == null)
                {
                    //here complete your code
                    _CustomerChildren = new CustomerCol(true);
                }
                return _CustomerChildren;
            }
        }
        public CustomerBiz ParentBiz
        {
            set
            {
                _ParentBiz = value;
            }
            get
            {
                return _ParentBiz;
            }
        }
        public int ParentID
        {
            set
            {
                ((CustomerDb)_BaseDb).ParentID = value;
            }
            get
            {
                return ((CustomerDb)_BaseDb).ParentID;
            }
        }
        public int FamilyID
        {
            set
            {
                ((CustomerDb)_BaseDb).FamilyID = value;
            }
            get
            {
                return ((CustomerDb)_BaseDb).FamilyID;
            }
        }
        public string UserName
        {
            set
            {
                ((CustomerDb)_BaseDb).UserName = value;
            }
            get
            {
                return ((CustomerDb)_BaseDb).UserName;
            }
        }
        public string Password
        {
            set
            {
                ((CustomerDb)_BaseDb).Password = value;
            }
            get
            {
                return ((CustomerDb)_BaseDb).Password;
            }
        }
        public CountryBiz CountryBiz
        {
            set
            {
                _CountryBiz = value;
                //((CustomerDb)_BaseDb).CountryDb = new CountryDb(_CountryBiz.ID, _CountryBiz.Name, _CountryBiz.Nationality);

            }
            get
            {
                return _CountryBiz;
            }
        }
        public JobBiz JobBiz
        {
            set
            {
                _jobBiz = value;
                // ((CustomerDb)_BaseDb).JobDb = new JobDb(_jobBiz.ID, _jobBiz.Name);
            }
            get
            {
                return _jobBiz;
            }
        }


        public string JobDesc
        {
            set
            {
                ((CustomerDb)_BaseDb).JobDesc = value;
            }
            get
            {
                return ((CustomerDb)_BaseDb).JobDesc;
            }
        }
        public string WorkDest
        {
            set
            {
                ((CustomerDb)_BaseDb).WorkDest = value;
            }
            get
            {
                return ((CustomerDb)_BaseDb).WorkDest;
            }
        }
        public string WorkAddress
        {
            set
            {
                ((CustomerDb)_BaseDb).WorkAddress = value;
            }
            get
            {
                return ((CustomerDb)_BaseDb).WorkAddress;
            }
        }
        public string Address
        {
            set
            {
                ((CustomerDb)_BaseDb).Address = value;
            }
            get
            {
                
                return ((CustomerDb)_BaseDb).Address;
            }
        }
        public string HomePhone
        {
            set
            {
                ((CustomerDb)_BaseDb).HomePhone = value;
            }
            get
            {
                return ((CustomerDb)_BaseDb).HomePhone;
            }
        }
        public string WorkPhone
        {
            set
            {
                ((CustomerDb)_BaseDb).WorkPhone = value;
            }
            get
            {
                return ((CustomerDb)_BaseDb).WorkPhone;
            }
        }
        public string Mobile
        {
            set
            {
                ((CustomerDb)_BaseDb).Mobile = value;
            }
            get
            {
                return ((CustomerDb)_BaseDb).Mobile;
            }
        }

        // New Data

        public int HomeCountry
        {
            set
            {
                ((CustomerDb)_BaseDb).HomeCountry = value;

            }
            get
            {
                return ((CustomerDb)_BaseDb).HomeCountry;
            }
        }
        public int HomeCity
        {
            set
            {
                ((CustomerDb)_BaseDb).HomeCity = value;
            }
            get
            {
                return ((CustomerDb)_BaseDb).HomeCity;
            }
        }
        public int HomeRegion
        {
            set
            {
                ((CustomerDb)_BaseDb).HomeRegion = value;
            }
            get
            {
                return ((CustomerDb)_BaseDb).HomeRegion;
            }
        }
        public int WorkCountry
        {
            set
            {
                ((CustomerDb)_BaseDb).WorkCountry = value;
            }
            get
            {
                return ((CustomerDb)_BaseDb).WorkCountry;
            }
        }
        public int WorkCity
        {
            set
            {
                ((CustomerDb)_BaseDb).WorkCity = value;
            }
            get
            {
                return ((CustomerDb)_BaseDb).WorkCity;
            }
        }
        public int WorkRegion
        {
            set
            {
                ((CustomerDb)_BaseDb).WorkRegion = value;
            }
            get
            {
                return ((CustomerDb)_BaseDb).WorkRegion;
            }
        }



        public string SecondMobile
        {
            set
            {
                ((CustomerDb)_BaseDb).SecondMobile = value;
            }
            get
            {
                return ((CustomerDb)_BaseDb).SecondMobile;
            }
        }

        public bool IsBirthDate
        {
            set
            {
                ((CustomerDb)_BaseDb).IsBirthDate = value;
            }
            get
            {
                return ((CustomerDb)_BaseDb).IsBirthDate;
            }
        }

        public string HomeCountryName
        {
            get
            {
                return ((CustomerDb)_BaseDb).HomeCountryName;
            }
        }
        public string HomeCityName
        {
            get
            {
                return ((CustomerDb)_BaseDb).HomeCityName;
            }
        }
        public string HomeRegionName
        {
            get
            {
                return ((CustomerDb)_BaseDb).HomeRegionName;
            }
        }
        public string WorkCountryName
        {
            get
            {
                return ((CustomerDb)_BaseDb).WorkCountryName;
            }
        }
        public string WorkCityName
        {
            get
            {
                return ((CustomerDb)_BaseDb).WorkCityName;
            }
        }
        public string WorkRegionName
        {
            get
            {
                return ((CustomerDb)_BaseDb).WorkRegionName;
            }
        }

        EmployeeBiz _ResponsibleEmployee;

        public EmployeeBiz ResponsibleEmployee
        {
            get {
                if (_ResponsibleEmployee == null)
                    _ResponsibleEmployee = new EmployeeBiz();
                return _ResponsibleEmployee; }
            set { _ResponsibleEmployee = value; }
        }

        //public CountryBiz CountryHome
        //{
        //    set
        //    {
        //        _CountryHome = value;

        //    }
        //    get
        //    {
        //        if (_CountryHome == null)
        //            _CountryHome = new CountryBiz();
        //        return _CountryHome;
        //    }
        //}
        //public CityBiz CityHome
        //{
        //    set
        //    {
        //        _CityHome = value;
        //    }
        //    get
        //    {
        //        if (_CityHome == null)
        //            _CityHome = new CityBiz();
        //        return _CityHome;
        //    }
        //}
        //public RegionBiz RegionHome
        //{
        //    set
        //    {
        //        _RegionHome = value;
        //    }
        //    get
        //    {
        //        if (_RegionHome == null)
        //            _RegionHome = new RegionBiz();
        //        return _RegionHome;
        //    }
        //}
        //public CountryBiz CountryWork
        //{
        //    set
        //    {
        //        _CountryWork = value;
        //    }
        //    get
        //    {
        //        if (_CountryWork == null)
        //            _CountryWork = new CountryBiz();
        //        return _CountryWork;
        //    }
        //}
        //public CityBiz CityWork
        //{
        //    set
        //    {
        //        _CityWork = value;
        //    }
        //    get
        //    {
        //        if (_CityWork == null)
        //            _CityWork = new CityBiz();
        //        return _CityWork;
        //    }
        //}
        //public RegionBiz RegionWork
        //{
        //    set
        //    {
        //        _RegionWork = value;
        //    }
        //    get
        //    {
        //        if (_RegionWork == null)
        //            _RegionWork = new RegionBiz();
        //        return _RegionWork;
        //    }
        //}
        // End New Data





        public string MailAddress
        {
            set
            {
                ((CustomerDb)_BaseDb).MailAddress = value;
            }
            get
            {
                return ((CustomerDb)_BaseDb).MailAddress;
            }
        }



        public CustomerSex Sex
        {
            set
            {
                ((CustomerDb)_BaseDb).Sex = (int)value;
            }
            get
            {
                return (CustomerSex)((CustomerDb)_BaseDb).Sex;
            }
        }
        public DateTime BirthDate
        {
            set
            {
                ((CustomerDb)_BaseDb).BirthDate = value;
            }
            get
            {
                return ((CustomerDb)_BaseDb).BirthDate;
            }
        }

        public IDTypeInstantBiz IDTypeInstantBiz
        {
            set
            {
                _IDTypeInstantBiz = value;
                //((CustomerDb)_BaseDb).IDTypeInstantDb = new IDTypeInstantDb(_IDTypeInstantBiz.ID, _IDTypeInstantBiz.Name, _IDTypeInstantBiz.IDValue);
            }
            get
            {
                if (_IDTypeInstantBiz == null)
                    _IDTypeInstantBiz = new IDTypeInstantBiz();
                return _IDTypeInstantBiz;
            }
        }
        public CustomerTypeBiz CustomerTypeBiz
        {
            set
            {
                _CustomerTypeBiz = value;
                //((CustomerDb)_BaseDb).CustomerTypeDb = new CustomerTypeDb(_CustomerTypeBiz.ID, _CustomerTypeBiz.Name, _CustomerTypeBiz.IsSecondaryType);
            }
            get
            {
                return _CustomerTypeBiz;
            }
        }

        public CustomerBiz Ancestor
        {
            get
            {
                CustomerCol objCustomerCol = new CustomerCol(true);
                SetAncestor(ref objCustomerCol, this);
                for (int i = 0; i < objCustomerCol.Count; i++)
                {
                    objCustomerCol[i].CustomerChildren = new CustomerCol(true);
                    if (i < objCustomerCol.Count - 1)
                        objCustomerCol[i].CustomerChildren.Add(objCustomerCol[i + 1]);
                    else
                        objCustomerCol[i].CustomerChildren = new CustomerCol(true);
                }
                CustomerBiz Returned = objCustomerCol[0];
                return Returned;


            }
        }


        public ReservationCol ReservationCol
        {
            set
            {
                _ReservationCol = value;
            }
            get
            {
                if (_ReservationCol == null)
                {
                    _ReservationCol = new ReservationCol(true);
                    if (CustomerDb.CacheReservationTable != null)
                    {
                        DataRow[] arrDr = CustomerDb.CacheReservationTable.Select("ReservationCustomer=" + ID);

                      
                        foreach (DataRow objDr in arrDr)
                        {
                            _ReservationCol.Add(new ReservationBiz(objDr));
                        }
                    }
                    else
                    {
                        ReservationDb objReservationDb = new ReservationDb();
                        objReservationDb.CustomerID = ID;
                        DataTable dtTemp = objReservationDb.Search();
                        foreach (DataRow objDr in dtTemp.Rows)
                        {
                            _ReservationCol.Add(new ReservationBiz(objDr));
                        }
                    }
                }
                return _ReservationCol;
            }

        }
        public ReservationCol CurrentReservationCol
        {
            get
            {
                ReservationCol Returned = new ReservationCol(true);
                foreach (ReservationBiz objBiz in ReservationCol)
                {
                    if (objBiz.Status != ReservationStatus.Cancellation && objBiz.Status != ReservationStatus.Cession)
                    {
                        Returned.Add(objBiz);
                    }
                }
                return Returned;
            }
        }
    
        public CustomerAttachmentCol CustomerAttachmentCol
        {
            set
            {
                _CustomerAttachmentCol = value;
            }
            get
            {
                if (_CustomerAttachmentCol == null)
                {
                    _CustomerAttachmentCol = new CustomerAttachmentCol(true);
                    if (ID != 0)
                    {
                        CustomerAttachmentDb objDb = new CustomerAttachmentDb();
                        objDb.CustomerID = ID;
                        DataTable dtTemp = objDb.Search();
                        CustomerAttachmentBiz objTemp;
                        foreach (DataRow objDr in dtTemp.Rows)
                        {
                            objTemp = new CustomerAttachmentBiz(objDr);
                            objTemp.CustomerBiz = this;
                            _CustomerAttachmentCol.Add(objTemp);
                        }
                    }
                }
                return _CustomerAttachmentCol;
            }

        }
        public AttachmentCol AllAttachmentCol
        {
            get
            {
                if (_AllAttachmentCol == null)
                {
                    _AllAttachmentCol = new AttachmentCol(true);
                    if (ID != 0)
                    {
                        foreach (CustomerAttachmentBiz objBiz in CustomerAttachmentCol)
                            _AllAttachmentCol.Add(objBiz);
                        foreach (ReservationBiz objReservationBiz in ReservationCol)
                        {
                            foreach (ReservationAttachmentBiz objBiz in objReservationBiz.ReservationAttachmentCol)
                                _AllAttachmentCol.Add(objBiz);
                        }
                    }
                }
                return _AllAttachmentCol;

            }
        }
        public CampaignCustomerContactCol AllContactCol
        {
            get
            {
                if (_AllContactCol == null)
                {
                    _AllContactCol = new CampaignCustomerContactCol(true);
                    if (ID != 0)
                    {
                        CampaignCustomerContactDb objDb = new CampaignCustomerContactDb();
                        // objDb.CampaignCustomerID = ID;
                        objDb.CustomerID = ID;
                        DataTable dtTemp = objDb.Search();
                        foreach (DataRow objDr in dtTemp.Rows)
                        {
                            _AllContactCol.Add(new CampaignCustomerContactBiz(objDr));
                        }
                    }
                }
                return _AllContactCol;
            }
        }

        public double Debt
        {
            set
            {
                ((CustomerDb)_BaseDb).Debt = value;
            }
            get
            {
                return ((CustomerDb)_BaseDb).Debt;
            }
        }
        public double Due
        {
            set
            {
                ((CustomerDb)_BaseDb).Due = value;
            }
            get
            {
                return ((CustomerDb)_BaseDb).Due;
            }
        }
        public string UnitFullName
        {
            set
            {
                ((CustomerDb)_BaseDb).UnitFullName = value;
            }
            get
            {
                return ((CustomerDb)_BaseDb).UnitFullName;
            }
        }
        public string TowerName
        {
            set
            {
                ((CustomerDb)_BaseDb).TowerName = value;
            }
            get
            {
                return ((CustomerDb)_BaseDb).TowerName;
            }
        }
        public string ProjectName
        {
            set
            {
                ((CustomerDb)_BaseDb).ProjectName = value;
            }
            get
            {
                return ((CustomerDb)_BaseDb).ProjectName;
            }
        }
      
        public CustomerHomeBiz CustomerHomeBiz
        {
            set
            {
                _CustomerHomeBiz = value;
            }
            get
            {
                if (_CustomerHomeBiz == null)
                    _CustomerHomeBiz = new CustomerHomeBiz(this);
                return _CustomerHomeBiz;
            }
        }
        CustomerWorkBiz _CustomerWorkBiz;
        public CustomerWorkBiz CustomerWorkBiz
        {
            set
            {
                _CustomerWorkBiz = value;
            }
            get
            {
                if(_CustomerWorkBiz==null)
                    _CustomerWorkBiz = new CustomerWorkBiz(this);
                return _CustomerWorkBiz;
            }
        }
        #endregion
        #region Private Methods
        private void SetAncestor(ref CustomerCol objCol, CustomerBiz objCustomerBiz)
        {
            CustomerBiz Returned;

            if (objCustomerBiz.ParentBiz != null && objCustomerBiz.ParentBiz.ID != 0 && objCustomerBiz.ParentBiz.Name != null)
            {
                SetAncestor(ref objCol, objCustomerBiz.ParentBiz);
            }

            objCol.Add(objCustomerBiz);

        }
        private void SetReservationCol(DataTable dtTemp)
        {
            _ReservationCol = new ReservationCol(true);
            foreach (DataRow objDr in dtTemp.Rows)
            {
                _ReservationCol.Add(new ReservationBiz(objDr));
            }
        }
        private void SetFullReservationCol(DataTable dtTemp)
        {

            _ReservationCol = new ReservationCol(true);
            ReservationBiz objreservationBiz;
            foreach (DataRow objDr in dtTemp.Rows)
            {
                objreservationBiz = new ReservationBiz(objDr);
                ReservationInstallmentCol objTempInstallmentCol = objreservationBiz.LinearInstallmentCol;
                ReservationBonusCol objBonusCol = objreservationBiz.BonusCol;
                ReservationDiscountCol objDiscountCol = objreservationBiz.DiscountCol;
                ReservationUnitCol objUnitCol = objreservationBiz.UnitCol;
                ReservationUtilityCol objUtilityCol = objreservationBiz.UtilityCol;
                _ReservationCol.Add(objreservationBiz);
            }

        }
        #endregion
        #region Public Methods
        public void Add()
        {
            if (CountryBiz == null)
                _CountryBiz = new CountryBiz();
            if (CustomerTypeBiz == null)
                _CustomerTypeBiz = new CustomerTypeBiz();
            if (JobBiz == null)
                _jobBiz = new JobBiz();
            if (_IDTypeInstantBiz == null)
                _IDTypeInstantBiz = new IDTypeInstantBiz();
            ((CustomerDb)_BaseDb).CountryID = _CountryBiz.ID;
            ((CustomerDb)_BaseDb).CustomerTypeID = _CustomerTypeBiz.ID;
            ((CustomerDb)_BaseDb).IDTypeID = _IDTypeInstantBiz.ID;
            ((CustomerDb)_BaseDb).IDTypeValue = _IDTypeInstantBiz.IDValue;

            // New Data
            //((CustomerDb)_BaseDb).HomeCountry = CountryHome.ID;
            //((CustomerDb)_BaseDb).HomeCity = CityHome.ID;
            //((CustomerDb)_BaseDb).HomeRegion = RegionHome.ID;

            //((CustomerDb)_BaseDb).WorkCountry = CountryWork.ID;
            //((CustomerDb)_BaseDb).WorkCity = CityWork.ID;
            //((CustomerDb)_BaseDb).WorkRegion = RegionWork.ID;

            // End New Data


            ((CustomerDb)_BaseDb).JobID = _jobBiz.ID;
            if (_ParentBiz == null)
                _ParentBiz = new CustomerBiz();
            ((CustomerDb)_BaseDb).ParentID = _ParentBiz.ID;
            ((CustomerDb)_BaseDb).FamilyID = _ParentBiz.FamilyID;
            _BaseDb.Add();
            if (_CustomerChildren == null)
                _CustomerChildren = new CustomerCol(true);
            foreach (CustomerBiz objCustomer in _CustomerChildren)
            {
                objCustomer.ParentID = _BaseDb.ID;
                objCustomer.FamilyID = ((CustomerDb)_BaseDb).FamilyID;
                if (objCustomer.ID == 0)
                {
                    objCustomer.Add();
                }
                else
                {
                    objCustomer.Edit();

                }
            }


            JoinContact(this, _ContactInstantCol);

        }
        public void Edit()
        {
            if (CountryBiz == null)
                _CountryBiz = new CountryBiz();
            if (CustomerTypeBiz == null)
                _CustomerTypeBiz = new CustomerTypeBiz();
            if (JobBiz == null)
                _jobBiz = new JobBiz();
            if (_IDTypeInstantBiz == null)
                _IDTypeInstantBiz = new IDTypeInstantBiz();
            ((CustomerDb)_BaseDb).CountryID = _CountryBiz.ID;
            ((CustomerDb)_BaseDb).CustomerTypeID = _CustomerTypeBiz.ID;
            ((CustomerDb)_BaseDb).IDTypeID = _IDTypeInstantBiz.ID;
            ((CustomerDb)_BaseDb).IDTypeValue = _IDTypeInstantBiz.IDValue;

            ((CustomerDb)_BaseDb).JobID = _jobBiz.ID;
            if (_ParentBiz == null)
                _ParentBiz = new CustomerBiz();
            ((CustomerDb)_BaseDb).FamilyID = _ParentBiz.FamilyID;
            ((CustomerDb)_BaseDb).ParentID = _ParentBiz.ID;

            // New Data
            //((CustomerDb)_BaseDb).HomeCountry = CountryHome.ID;
            //((CustomerDb)_BaseDb).HomeCity = CityHome.ID;
            //((CustomerDb)_BaseDb).HomeRegion = RegionHome.ID;

            //((CustomerDb)_BaseDb).WorkCountry = CountryWork.ID;
            //((CustomerDb)_BaseDb).WorkCity = CityWork.ID;
            //((CustomerDb)_BaseDb).WorkRegion = RegionWork.ID;

            // End New Data

            _BaseDb.Edit();

            if (_CustomerChildren != null)
            {
                foreach (CustomerBiz objCustomer in _CustomerChildren)
                {
                    objCustomer.ParentID = _BaseDb.ID;
                    objCustomer.FamilyID = ((CustomerDb)_BaseDb).FamilyID;
                    if (objCustomer.ID == 0)
                    {
                        objCustomer.Add();
                    }
                    else
                    {
                        objCustomer.Edit();

                    }
                }
            }


            JoinContact(this, _ContactInstantCol);

        }
        public void EditCustomerAccount()
        {
            ((CustomerDb)_BaseDb).EditCustomerAccount();
        }
        #region static methods
        public static void Add(string strFullName, string strName, string strPassword, int intGroupID, UserFunctionInstantCol objUserFunctionInstantCol)
        {
            CustomerDb objCustomerDb = new CustomerDb();
            objCustomerDb.NameA = strFullName;

            objCustomerDb.Add();
            int intID = objCustomerDb.ID;


        }
        public static void Edit(int intID, string strFullName, string strName, string strPassword, int intGroupID, UserFunctionInstantCol objUserFunctionInstantCol)
        {
            CustomerDb objCustomerDb = new CustomerDb();
            objCustomerDb.ID = intID;
            objCustomerDb.NameA = strFullName;

            objCustomerDb.Edit();



        }
        public static void Delete(int intID)
        {
            CustomerDb objCustomerDb = new CustomerDb();
            objCustomerDb.ID = intID;
            objCustomerDb.Delete();
        }
        internal static void JoinContact(CustomerBiz objCustomerBiz, ContactInstantCol objContactInstantCol)
        {
            if (objContactInstantCol == null)
                return;
            DataTable dtContactInstant = new DataTable();
            dtContactInstant.Columns.AddRange(new DataColumn[] { new DataColumn("ContactID"), new DataColumn("ContactValue") });
            CustomerDb objCustomerDb = new CustomerDb();
            objCustomerDb.ID = objCustomerBiz.ID;
            objCustomerDb.ParentID = objCustomerBiz.ParentID;
            objCustomerDb.FamilyID = objCustomerBiz.FamilyID;
            DataRow objDR;
            foreach (ContactInstantBiz objContactInstantBiz in objContactInstantCol)
            {
                objDR = dtContactInstant.NewRow();
                objDR["ContactID"] = objContactInstantBiz.ID;
                objDR["ContactValue"] = objContactInstantBiz.ContactValue;
                dtContactInstant.Rows.Add(objDR);
            }
            objCustomerDb.ContactInstant = dtContactInstant;
            objCustomerDb.SetContact();
        }

        #endregion
        public CustomerBiz Copy()
        {
            CustomerBiz Returned = new CustomerBiz();


            Returned.ID = this.ID;
            Returned.NameA = this.NameA;

            Returned.JobBiz = this.JobBiz.Copy();
            Returned.CountryBiz = this.CountryBiz.Copy();
            Returned.ParentBiz = this.ParentBiz;

            //if (this.CustomerContactCol != null)
            //    Returned.CustomerContactCol = this.CustomerContactCol.Copy();

            return Returned;
        }
        public static bool CheckCustomer(string strCustomerName, string strPassword, out CustomerBiz objCustomerBiz)
        {
            bool blReturned = false;

            CustomerDb objCustomerDb;

            if (SysData.IsOnline)
            {

                objCustomerDb = new CustomerDb(strCustomerName, strPassword); ;// new CustomerWeb(strCustomerName, strPassword);
                objCustomerBiz = new CustomerBiz(objCustomerDb);
                objCustomerBiz.SetFullReservationCol(
                    ReservationDb.CachReservationTable);

            }
            else
            {
                objCustomerDb = new CustomerDb(strCustomerName, strPassword);
                objCustomerBiz = new CustomerBiz(objCustomerDb);
            }

            if (objCustomerDb.ID != 0)
            {
                blReturned = true;

            }

            return blReturned;
        }
        public void EditContactData()
        {
            ((CustomerDb)_BaseDb).EditContactData();
        }
        #endregion
    }
}
