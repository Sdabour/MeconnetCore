using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.CRM.CRMDataBase;
using System.Data;
using System.Collections;
using SharpVision.COMMON.COMMONBusiness;
using SharpVision.COMMON.COMMONDataBase;
using SharpVision.Base.BaseBusiness;
using SharpVision.RP.RPBusiness;
using SharpVision.HR.HRBusiness;
using SharpVision.SystemBase;
namespace SharpVision.CRM.CRMBusiness
{
    public class CustomerCol : BaseCol
    {
        #region PrivateData
        int _ResultCount =0;
        int _MaxCount = 1500;
      
        string _MaxName;
        string _MinName;
        string _TheMinName;
        bool _EnableNext;
        bool _EnablePrevious;
        Hashtable _CustomerHs = new Hashtable();
        #region Private Data for Previous Search
        CustomerBiz _ParentBiz;
        string _ModelIDs;
        string _CellIDs;
        int _CellFamilyID;
        string _LikeName;
        IDTypeInstantBiz _IDTypeBiz;
        JobBiz _JobBiz;
        CountryBiz _countryBiz;
        CustomerTypeBiz _TypeBiz;
        byte _ContactStatus;
        byte _AttachmentStatus;
        int _RservationStatus;
        int _ReservationStartCount;
        int _ReservationEndCount;
        double _ReservationStartValue;
        double _ReservationEndValue;
        string _UnitCode;
        bool _IsContractingDateRange;
        DateTime _StartContractingDate;
        DateTime _EndContractingDate;
        CampaignBiz _CampaignBiz;
        int _AddressStatus;
        int _MobileStatus;
        string _PhoneNo;
        #endregion
        void SetDataInitially(CustomerBiz objParentBiz, string strLikeName, 
            IDTypeInstantBiz objIDTypeBiz, JobBiz objJobBiz, CountryBiz objcountryBiz,
            CustomerTypeBiz objTypeBiz,
            byte btContactStatus, byte btAttachmentStatus,int intReservationStatus,
            UnitModelBiz objModelBiz,CellBiz objCellBiz,int intReservationStartCount,int intReservationEndCount,
            double dblReservationStartValue,double dblReservationEndValue,string strUnitCode,bool blIsContractingDateRange,
            DateTime dtStartContractDate,DateTime dtEndContractDate,
            CampaignBiz objCampaignBiz,int intAddressStatus,int intMobileStatus,string strPhone)
        {
            
            _ParentBiz = objParentBiz;
            _LikeName = strLikeName;
            _IDTypeBiz = objIDTypeBiz;
            _JobBiz = objJobBiz;
            _countryBiz = objcountryBiz;
            _TypeBiz = objTypeBiz;
            _ContactStatus = btContactStatus;
            _ReservationStartCount = intReservationStartCount;
            _ReservationEndCount = intReservationEndCount;
            _ReservationStartValue = dblReservationStartValue;
            _ReservationEndValue = dblReservationEndValue;
            _AttachmentStatus = btAttachmentStatus;
            _RservationStatus = intReservationStatus;
            _UnitCode = strUnitCode;
            _IsContractingDateRange = blIsContractingDateRange;
            _StartContractingDate = dtStartContractDate;
            _EndContractingDate = dtEndContractDate;
            //_CampaignBiz = objCampaignBiz;
            if (objCampaignBiz == null)
                objCampaignBiz = new CampaignBiz();
            _CampaignBiz = objCampaignBiz;
            if (objModelBiz != null && objModelBiz.ID != 0)
                _ModelIDs = objModelBiz.IDsStr;
            if (objCellBiz != null && objCellBiz.ID != 0)
            {
                if (objCellBiz.ID == objCellBiz.ParentID)
                    _CellFamilyID = objCellBiz.ID;
                else
                {
                    if(objCellBiz.ID != -1)
                       objCellBiz.Children = null;
                    CellCol objCellcol = objCellBiz.Children;
                    _CellIDs = objCellBiz.IDsStr;

                }
            }
            _AddressStatus = intAddressStatus;
            _MobileStatus = intMobileStatus;
            _PhoneNo = strPhone;
 
        }
        void GetSearchData(ref CustomerDb objCustomerDb)
        {
            if (_JobBiz == null)
                _JobBiz = new JobBiz();
            if (_countryBiz == null)
                _countryBiz = new CountryBiz();
            if (_TypeBiz == null)
                _TypeBiz = new CustomerTypeBiz();
            if (_IDTypeBiz == null)
                _IDTypeBiz = new IDTypeInstantBiz();
            objCustomerDb.NameLike = _LikeName;
            objCustomerDb.IDTypeInstantDb = new IDTypeInstantDb(_IDTypeBiz.ID, _IDTypeBiz.Name, _IDTypeBiz.IDValue);
            objCustomerDb.JobDb = new JobDb(_JobBiz.ID, _JobBiz.Name);
            objCustomerDb.CountryDb = new CountryDb(_countryBiz.ID, _countryBiz.Name, _countryBiz.Nationality);
            objCustomerDb.CustomerTypeDb = new CustomerTypeDb(_TypeBiz.ID, _TypeBiz.Name, _TypeBiz.IsSecondaryType);
            objCustomerDb.ReservationStartCount = _ReservationStartCount;
            objCustomerDb.ReservationEndCount = _ReservationEndCount;
            objCustomerDb.ReservationStartValue = _ReservationStartValue;
            objCustomerDb.ReservationEndValue = _ReservationEndValue;
            if (_ParentBiz == null)
                _ParentBiz = new CustomerBiz();
            objCustomerDb.ParentID = _ParentBiz.ID;
            objCustomerDb.HasContactStatus = _ContactStatus;
            objCustomerDb.HasAttachmentStatus = _AttachmentStatus;
            objCustomerDb.ReservationStatus = _RservationStatus;
            objCustomerDb.CellFamilyID = _CellFamilyID;
            objCustomerDb.CellIDs = _CellIDs;
            objCustomerDb.ModelIDs = _ModelIDs;
            objCustomerDb.UnitCode = _UnitCode;
            objCustomerDb.ContractingDateRange = _IsContractingDateRange;
            objCustomerDb.ContractingStartDate = _StartContractingDate;
            objCustomerDb.ContractingEndDate = _EndContractingDate;
            if (_CampaignBiz == null)
                _CampaignBiz = new CampaignBiz();
            objCustomerDb.CampaignID = _CampaignBiz.ID;
            if(_CampaignBiz.ID !=0)
            objCustomerDb.CampaignDealStatus = 1;
        objCustomerDb.AddressStatus = _AddressStatus;
        objCustomerDb.MobileStatus = _MobileStatus;
        objCustomerDb.PhoneSearchNum = _PhoneNo;
 
        }
        #endregion

        public CustomerCol()
        {
            CustomerDb objCustomerDb = new CustomerDb();
            DataTable dtCustomer = objCustomerDb.Search();
            _ResultCount = objCustomerDb.ResultCount;
            
            DataRow[] arrDR = dtCustomer.Select("", "CustomerFullnameName");
            CustomerBiz objCustomerBiz;
            foreach (DataRow DR in arrDR)
            {
                objCustomerBiz = new CustomerBiz(DR);

                //SetCustomerChildren(ref objCustomerBiz, ref dtCustomer);
                this.Add(objCustomerBiz);

            }
            if (Count > 0)
            {
                _MaxName = this[Count-1].Name;
               
                _MinName = this[0].Name;
                //_TheMinID = _MinID;
            }
            _EnablePrevious = false;
            if (Count >= _MaxCount)
            {
                _EnableNext = true;
            }


        }
        public CustomerCol(CustomerBiz objParentBiz,string strLikeName,IDTypeInstantBiz objIDTypeBiz,
            JobBiz objJobBiz,CountryBiz objcountryBiz,CustomerTypeBiz objTypeBiz,
            byte btContactStatus,byte btAttachmentStatus,CellBiz objCellBiz,UnitModelBiz objModelBiz,string strPhoneNo)
        {
            CustomerDb objCustomerDb = new CustomerDb();
            SetDataInitially(objParentBiz, strLikeName, objIDTypeBiz,
                objJobBiz, objcountryBiz, objTypeBiz, btContactStatus, btAttachmentStatus, 0, 
                objModelBiz, objCellBiz,0,0,0,0,"",false,DateTime.Now,DateTime.Now,new CampaignBiz(),0,0,strPhoneNo);
            GetSearchData(ref objCustomerDb);
            DataTable dtCustomer = objCustomerDb.Search();
            _ResultCount = objCustomerDb.ResultCount;
            if(dtCustomer.Rows.Count == 0)
                return;
            DataRow[] arrDR = dtCustomer.Select("", "CustomerFullName");
            CustomerBiz objCustomerBiz;
            CustomerBiz objTempParent = new CustomerBiz();
            foreach (DataRow DR in arrDR)
            {
                objCustomerBiz = new CustomerBiz(DR);
                objTempParent = new CustomerBiz();
               
                objCustomerBiz.ParentBiz = objTempParent;
                this.Add(objCustomerBiz);
              
            }
            if (Count > 0)
            {
                _MaxName = this[Count - 1].Name;

                _MinName = this[0].Name;
                //_TheMinID = _MinID;
            }
            _EnablePrevious = false;
            if (Count >= _MaxCount)
            {
                _EnableNext = true;
            }

        }

        public CustomerCol(CustomerBiz objParentBiz, string strLikeName, IDTypeInstantBiz objIDTypeBiz, JobBiz objJobBiz, CountryBiz objcountryBiz, CustomerTypeBiz objTypeBiz,
           byte btContactStatus, byte btAttachmentStatus, CellBiz objCellBiz, 
            UnitModelBiz objModelBiz,int intStartCount,int intEndCount,double dblStartValue,
            double dblEndValue,string strUnitCode,bool blcontractingDateRange,DateTime dtStartDate,
            DateTime dtEndDate,CampaignBiz objCampaignBiz,int intAddressStatus,int intMobileStatus,string strPhone)
        {
            CustomerDb objCustomerDb = new CustomerDb();
            SetDataInitially(objParentBiz, strLikeName, objIDTypeBiz, objJobBiz,
                objcountryBiz, objTypeBiz, btContactStatus, btAttachmentStatus, 0, 
                objModelBiz, objCellBiz,intStartCount,intEndCount, dblStartValue,
                dblEndValue,strUnitCode,blcontractingDateRange,
                dtStartDate,dtEndDate,objCampaignBiz,intAddressStatus,intMobileStatus,strPhone);
            //objCustomerDb.UnitCode = strUnitCode;

            //objCustomerDb.ContractingDateRange = blcontractingDateRange;
            //objCustomerDb.ContractingStartDate = dtStartDate;
            //objCustomerDb.ContractingEndDate = dtEndDate;

            GetSearchData(ref objCustomerDb);
            DataTable dtCustomer = objCustomerDb.Search();
            _ResultCount = objCustomerDb.ResultCount;
            if (dtCustomer.Rows.Count == 0)
                return;
            DataRow[] arrDR = dtCustomer.Select("", "CustomerFullName");
            CustomerBiz objCustomerBiz;
            CustomerBiz objTempParent = new CustomerBiz();
            foreach (DataRow DR in arrDR)
            {
                objCustomerBiz = new CustomerBiz(DR);
                objTempParent = new CustomerBiz();

                objCustomerBiz.ParentBiz = objTempParent;
                this.Add(objCustomerBiz);

            }
            if (Count > 0)
            {
                _MaxName = this[Count - 1].Name;

                _MinName = this[0].Name;
                //_TheMinID = _MinID;
            }
            _EnablePrevious = false;
            if (Count >= _MaxCount)
            {
                _EnableNext = true;
            }

        }
        public CustomerCol(string strLikeName,CellBiz objCellbiz,int intCampaignID)
        {
            CustomerDb objCustomerDb = new CustomerDb();
            objCustomerDb.NameLike = strLikeName;
            objCustomerDb.CampaignID = intCampaignID;
            objCustomerDb.CampaignDealStatus = 0;
            if (objCellbiz != null && objCellbiz.ID != 0)
            {
                if (objCellbiz.ID == objCellbiz.ParentID)
                {
                    objCustomerDb.CellFamilyID = objCellbiz.ID;

                }
                else
                    objCustomerDb.CellIDs = objCellbiz.IDsStr;
            }
            DataTable dtCustomer = objCustomerDb.Search();
            _ResultCount = objCustomerDb.ResultCount;
            if (dtCustomer.Rows.Count == 0)
                return;
            DataRow[] arrDR = dtCustomer.Select("", "CustomerFullName");
            CustomerBiz objCustomerBiz;
            CustomerBiz objTempParent = new CustomerBiz();
            foreach (DataRow DR in arrDR)
            {
                objCustomerBiz = new CustomerBiz(DR);
                objTempParent = new CustomerBiz();
               // SetCustomerChildren(ref objCustomerBiz, ref dtCustomer);
                objCustomerBiz.ParentBiz = objTempParent;
                this.Add(objCustomerBiz);

            }
            if (Count > 0)
            {
                _MaxName = this[Count - 1].Name;

                _MinName = this[0].Name;
                //_TheMinID = _MinID;
            }
            _EnablePrevious = false;
            if (Count >= _MaxCount)
            {
                _EnableNext = true;
            }

        }
        public CustomerCol(string strLikeName, IDTypeInstantBiz objIDTypeBiz, JobBiz objJobBiz, CountryBiz objcountryBiz, CustomerTypeBiz objTypeBiz,int intRservationStatus,byte btContactStatus,string strPhone)
        {
            CustomerDb objCustomerDb = new CustomerDb();
            SetDataInitially(new CustomerBiz(), strLikeName, objIDTypeBiz, objJobBiz, objcountryBiz, objTypeBiz, btContactStatus, 0, intRservationStatus, new UnitModelBiz(), new CellBiz(), 0, 0, 0, 0, "", false, DateTime.Now, DateTime.Now,new CampaignBiz(),0,0,strPhone);
            GetSearchData(ref objCustomerDb);
            DataTable dtCustomer = objCustomerDb.Search();
            _ResultCount = objCustomerDb.ResultCount;
            if (dtCustomer.Rows.Count == 0)
                return;
            DataRow[] arrDR = dtCustomer.Select("", "CustomerFullName");
            CustomerBiz objCustomerBiz;
            CustomerBiz objTempParent = new CustomerBiz();
            foreach (DataRow DR in arrDR)
            {
                objCustomerBiz = new CustomerBiz(DR);
                objTempParent = new CustomerBiz();
                //SetCustomerChildren(ref objCustomerBiz, ref dtCustomer);
                objCustomerBiz.ParentBiz = objTempParent;
                this.Add(objCustomerBiz);

            }
            if (Count > 0)
            {
                _MaxName = this[Count - 1].Name;

                _MinName = this[0].Name;
                //_TheMinID = _MinID;
            }
            _EnablePrevious = false;
            if (Count >= _MaxCount)
            {
                _EnableNext = true;
            }

        }
        public CustomerCol(bool blIsEmpty)
        {

        }
        public CustomerCol(bool blGetCustomerWithVisits, SalesManBiz objSalesManBiz)
        {
            CustomerDb objCustomerDb = new CustomerDb();
            DataTable dtTemp = objCustomerDb.GetCustomerWithVisit(objSalesManBiz.ID);

            foreach (DataRow objDr in dtTemp.Rows)
            {
                this.Add(new CustomerBiz(objDr));
            }
        }
        public CustomerCol(bool blGetCustomerWithVisits, BranchBiz objBranchBiz, SalesManBiz objSalesManBiz
            , bool blSearch, DateTime dtFrom, DateTime dtTo, VisitResult objVisitStatus)
        {
            CustomerDb objCustomerDb = new CustomerDb();
            if (objBranchBiz == null)
                objBranchBiz = new BranchBiz();
            if (objSalesManBiz == null)
                objSalesManBiz = new SalesManBiz();
            string strVisitStatus="";
            if ((int)objVisitStatus == 1)
                strVisitStatus = "1,4";
            else if ((int)objVisitStatus == 2)
                strVisitStatus = "2,5";
            else if ((int)objVisitStatus == 3)
                strVisitStatus = "3";
            else if ((int)objVisitStatus == 4)
                strVisitStatus = "4";
            else if ((int)objVisitStatus == 5)
                strVisitStatus = "5";
            DataTable dtTemp = objCustomerDb.GetCustomerWithVisit(objBranchBiz.ID, objSalesManBiz.ID, blSearch, dtFrom, dtTo, strVisitStatus);

            foreach (DataRow objDr in dtTemp.Rows)
            {
                this.Add(new CustomerBiz(objDr));
            }
        }
        public  CustomerCol(string strCustomerNameLike, string strPhone,
            string strCustomerIDNo, string strCustomerUnitCode, ProjectCol objProjectCol)
        {
            if (objProjectCol == null)
                objProjectCol = new ProjectCol(true);
            CustomerDb objDb = new CustomerDb();
            objDb.UnitCode = strCustomerUnitCode;
            objDb.NameLike = strCustomerNameLike;
            objDb.PhoneSearchNum = strPhone;
            objDb.IDTypeInstantDb = new IDTypeInstantDb() { IDValue = strCustomerIDNo };

            string strProjectIDs = objProjectCol.IDsStr;
            if (strProjectIDs != "0")
                objDb.ProjectIDs = strProjectIDs;
            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
                Add(new CustomerBiz(objDr));

          
        }
        public virtual CustomerBiz this[int intIndex]
        {
            get
            {
                return (CustomerBiz)this.List[intIndex];
            }
        }
        public virtual CustomerBiz this[string strIndex]
        {
            get
            {
                CustomerBiz Returned = new CustomerBiz();
                foreach (CustomerBiz objCustomerBiz in this)
                {
                    if (objCustomerBiz.Name == strIndex)
                    {
                        Returned = (CustomerBiz)objCustomerBiz.Copy();
                        break;
                    }
                }
                return Returned;
            }
        }
        public int ResultCount
        {
            get
            {
                return _ResultCount;
            }
        }
        public bool EnableNext
        {
            get
            {
                return _EnableNext;
            }
        }
        public bool EnablePrevious
        {
            get
            {
                return _EnablePrevious;
            }
        }
        public string IDsStr
        {
            get
            {
                string Returned = "";
                foreach (CustomerBiz objBiz in this)
                {
                    if (Returned != "")
                        Returned = Returned + ",";
                    Returned = Returned + objBiz.IDsStr;
                }
                return Returned;
            }
        }
        public string NameStr
        {
            get
            {
                string Returned = "";
                foreach (CustomerBiz objBiz in this)
                {
                    if (Returned != "")
                        Returned += " & ";
                    Returned += objBiz.Name;
                }
                return Returned;
            }
        }
        public ReservationCol ReservationCol
        {
            get
            {
                ReservationCol Returned = new ReservationCol(true);
                //ReservationBiz objBiz;
                foreach (CustomerBiz objCustomerBiz in this)
                {
                    foreach (ReservationBiz objBiz in objCustomerBiz.ReservationCol)
                    {
                        if (objBiz.Status != ReservationStatus.Cession && objBiz.Status != ReservationStatus.Cancellation)
                        {
                            objBiz.CustomerCol = new CustomerCol(true);
                            objBiz.CustomerCol.Add(objCustomerBiz);
                            Returned.Add(objBiz);
                        }
                    }
 
                }

                return Returned;
            }
        }
      
        #region  Privaet methods
        void SetCustomerChildren(ref CustomerBiz objCustomerBiz, ref DataTable dtCustomers)
        {
            objCustomerBiz.Children = new CustomerCol(true);
            DataRow[] arrDR = dtCustomers.Select("CustomerID <> CustomerParentID and CustomerParentID=" + objCustomerBiz.ID, "CustomerFullName");
            CustomerBiz tempCustomerBiz;
            CustomerCol objCustomerCol;
            objCustomerCol = new CustomerCol(true);
            foreach (DataRow DR in arrDR)
            {
                tempCustomerBiz = new CustomerBiz(DR);
                SetCustomerChildren(ref tempCustomerBiz, ref dtCustomers);
                tempCustomerBiz.ParentBiz = objCustomerBiz;
                objCustomerCol.Add(tempCustomerBiz);

            }
            objCustomerBiz.CustomerChildren = objCustomerCol;

        }

        #endregion
        public bool Contains(CustomerBiz objCustomerBiz)
        {
            
            //foreach (CustomerBiz objBiz in this)
            //{
            //    if (objCustomerBiz.ID == objBiz.ID)
            //    {
            //        if (objBiz.ID == 0)
            //        {
            //            if (objBiz.Name == objCustomerBiz.Name)
            //                return true;


            //        }
            //        else
            //            return true;
            //    }

            //}
            //return false;
            return GetIndex(objCustomerBiz) > -1;
 
        }
        public int GetIndex1(CustomerBiz objCustomerBiz)
        {
           
            CustomerBiz objBiz;
            for (int intIndex = 0; intIndex < Count;intIndex++ )
            {
                objBiz = this[intIndex];
                if(objBiz == objCustomerBiz)
                    return intIndex;
                if (objCustomerBiz.ID == objBiz.ID)
                {

                    if (objBiz.ID == 0)
                    {
                        if (objBiz.Name == objCustomerBiz.Name)
                            return intIndex;


                    }
                    else
                    {

                        return intIndex;
                    }
                }

            }
            return -1;
        }
        public int GetIndex(CustomerBiz objCustomerBiz)
        {

            if (objCustomerBiz.ID == 0 || _CustomerHs[objCustomerBiz.ID.ToString()] == null)
                return -1;
            else
            {
                return (int)_CustomerHs[objCustomerBiz.ID.ToString()];
            }
        }
        public int GetObjectIndex(CustomerBiz objCustomerBiz)
        {

            CustomerBiz objBiz;
            for (int intIndex = 0; intIndex < Count; intIndex++)
            {
                objBiz = this[intIndex];
                if (objBiz == objCustomerBiz)
                    return intIndex;
                

            }
            return -1;
        }
        public virtual void Add1(CustomerBiz objCustomerBiz)
        {
            if (objCustomerBiz == null)
                return;
           int intIndex = GetIndex(objCustomerBiz);
           if (intIndex == -1)
               this.List.Add(objCustomerBiz);
           else
               this[intIndex].CustomerChildren.Add(objCustomerBiz.CustomerChildren);
        }
        public virtual void Add(CustomerBiz objCustomerBiz)
        {
            if (objCustomerBiz == null)
                return;
            int intIndex = GetIndex(objCustomerBiz);
            if (intIndex == -1)
            {

                this.List.Add(objCustomerBiz);
                if(objCustomerBiz.ID >0)
                   _CustomerHs.Add(objCustomerBiz.ID.ToString() ,List.Count - 1);
            }
            else
                this[intIndex].CustomerChildren.Add(objCustomerBiz.CustomerChildren);
        }
        public virtual void Add(CustomerCol objCustomerCol)
        {
            int intIndex;
            foreach (CustomerBiz objCustomerBiz in objCustomerCol)
            {
                //intIndex = GetIndex(objCustomerBiz);
                //if (intIndex == -1)
                    this.Add(objCustomerBiz);

            }
        }
        public void MoveNext()
        {

            Clear();
            CustomerDb objCustomerDb = new CustomerDb();
            GetSearchData(ref objCustomerDb);
            objCustomerDb.MaxName = _MaxName;
            objCustomerDb.MinName = "";
            DataTable dtTemp = objCustomerDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
                Add(new CustomerBiz(objDr));

            if (Count > 0)
            {
                _MaxName = this[Count - 1].Name;

                _MinName = this[0].Name;
                //_TheMinID = _MinID;
            }
            _EnablePrevious = true;
            if (Count >= _MaxCount)
            {
                _EnableNext = true;
            }


        }
        public void MovePrevious()
        {


            Clear();
            CustomerDb objCustomerDb = new CustomerDb();
            GetSearchData(ref objCustomerDb);
            objCustomerDb.MinName = _MinName;
            objCustomerDb.MaxName = "";
            DataTable dtTemp = objCustomerDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
                Add(new CustomerBiz(objDr));
            if (Count > 0)
            {
                _MaxName = this[Count - 1].Name;

                _MinName = this[0].Name;
                if (_MinName.CompareTo(_TheMinName) > 0)
                    _EnablePrevious = true;
                _EnableNext = true;
            }



        }

        public CustomerCol Copy()
        {
            CustomerCol Returned = new CustomerCol(true);
            foreach (CustomerBiz objTemp in this)
            {
                Returned.Add((CustomerBiz)objTemp.Copy());
            }
            return Returned;
        }
        public DataTable GetTable()
        {
            DataTable Returned = new DataTable();
            Returned.Columns.AddRange(new DataColumn[] {new DataColumn("Name"),new DataColumn("PhoneNumber"),new DataColumn("Mobile"),
                new DataColumn("Address"),new DataColumn("ID"),new DataColumn("UnitCode"),new DataColumn("Tower"),new DataColumn("Project")  });
            DataRow objDr;

            foreach (CustomerBiz objBiz in this)
            {
                objDr = Returned.NewRow();
                objDr["Name"] = objBiz.Name;
                objDr["PhoneNumber"] = objBiz.HomePhone;
                objDr["Mobile"] = objBiz.Mobile;
                objDr["Address"] = objBiz.Address;
                objDr["ID"] = objBiz.IDTypeInstantBiz.IDValue + "-" + objBiz.IDTypeInstantBiz.Name;
                objDr["UnitCode"] = objBiz.UnitFullName;
                objDr["Tower"] = objBiz.TowerName;
                objDr["Project"] = objBiz.ProjectName;
                Returned.Rows.Add(objDr);
            }
            return Returned;
        }
        public CampaignCustomerCol GetCampaignCustomerCol(CampaignBiz objCampaignBiz)
        {
            CampaignCustomerCol Returned = new CampaignCustomerCol(true);
            CampaignCustomerBiz objTemp;
            foreach (CustomerBiz objCustomerBiz in this)
            {
                objTemp = new CampaignCustomerBiz();
                objTemp.Campaign = objCampaignBiz;
                objTemp.Customer = objCustomerBiz;
                objTemp.Direction = false;
                objTemp.EmployeeBiz = SysData.CurrentUser.EmployeeBiz;
                Returned.Add(objTemp);
            }
            return Returned;
        }
        public bool CheckCustomer(bool blContactIsMandatory)
        {
            foreach (CustomerBiz objBiz in this )
            {
                if (blContactIsMandatory && (objBiz.IDTypeInstantBiz.IDValue == "" || objBiz.Address == "" || objBiz.Mobile == ""))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
