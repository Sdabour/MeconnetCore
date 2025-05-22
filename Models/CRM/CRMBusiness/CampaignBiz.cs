using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.UMS.UMSBusiness;
using SharpVision.CRM.CRMDataBase;
using System.Data;
using SharpVision.Base.BaseBusiness;
using SharpVision.COMMON.COMMONBusiness;
using System.Text;
using System.Collections;
using SharpVision.RP.RPBusiness;
using SharpVision.SystemBase;
namespace SharpVision.CRM.CRMBusiness
{
    public enum ContactType
    {
        NotSpecified,
        Phone,
        SMS,
        EMail,
        VisitingTheCustomer,//ÐåÇÈ Çáì ÇáÚãíá
        CustomerVisit,//ÍÖæÑ ÇáÚãíá Çáì ÇáãÞÑ
        Letter

    }
    public class CampaignBiz
    {
        #region Private Data
        CampaignDb _CampaignDb;
        
        CampaignCustomerCol _CustomerCol;
        CampaignCustomerCol _NonContactedCustomerCol;
        CampaignCustomerCol _DeleteedCustomerCol;
        CampaignCustomerCol _EditedCustomerCol;
        
        CampaignSMSCol _SMSCol;
        string _RTF;
        InstallmentTypeCol _InstallmentTypeCol;
        CellBiz _CellBiz;
        string _RTFFilePath;
        AttachmentFileBiz _RTFFileBiz;
        TopicBiz _TopicBiz;
        CampaignRuleCol _RuleCol;
        CampaignExceptedCustomerCol _ExceptedCustomerCol;
        #endregion
        #region Constructors
        public CampaignBiz()
        {
            _CampaignDb = new CampaignDb();
        }
        public CampaignBiz(int intID)
        {
            _CampaignDb = new CampaignDb(intID);
        }
        public CampaignBiz(DataRow objDR)
        {
            _CampaignDb = new CampaignDb(objDR);
           // _Contact = new ContactBiz(objDR);
            if (_CampaignDb.TopicID != 0)
            {
                _TopicBiz = new TopicBiz();
                _TopicBiz.ID = _CampaignDb.TopicID;
                _TopicBiz.NameA = _CampaignDb.TopicName;
            }
        }
        #endregion
        #region Private Properties
        byte[] LetterRTFBytes
        {
            get
            {
                byte[] Returned = new byte[0];
                if (RTF != null && RTF != "")
                {
                    Returned = System.Text.Encoding.Unicode.GetBytes(RTF);

                }
                return Returned;
            }
        }
        DataTable InstallmentTypeTable
        {
            get
            {
                DataTable Returned = new DataTable();
                Returned.Columns.AddRange(new DataColumn[] { new DataColumn("InstallmentType") });
                DataRow objDr;
                foreach (InstallmentTypeBiz objBiz in InstallmentTypeCol)
                {
                    objDr = Returned.NewRow();
                    objDr["InstallmentType"] = objBiz.ID;
                    Returned.Rows.Add(objDr);
 
                }
                return Returned;
            }
        }
        public string RTF
        {
            set
            {

                _RTF = value;
            }
            get
            {
                if (_RTF == null || _RTF == "")
                {
                    if (_CampaignDb.LetterRTF != 0)
                    {
                        if(RTFFileBiz.Bytes != null)
                        _RTF = System.Text.Encoding.Unicode.GetString(RTFFileBiz.Bytes);

                    }
                }
                return _RTF;
            }
        }
        public AttachmentFileBiz RTFFileBiz
        {
            set
            {
                _RTFFileBiz = value;
            }
            get
            {
                if (_RTFFileBiz == null)
                {
                    _RTFFileBiz = new AttachmentFileBiz();
                    if (_CampaignDb.LetterRTF != 0)
                    {
                        _RTFFileBiz = new AttachmentFileBiz(_CampaignDb.LetterRTF);
                    }
                }
                return _RTFFileBiz;
            }
        }
        #endregion
        #region Public Properties
        public int ID
        {
            set
            {
                _CampaignDb.ID = value;
            }
            get
            {
                return _CampaignDb.ID;
            }
        }
        public DateTime Date
        {
            set
            {
                _CampaignDb.Date = value;
            }
            get
            {
                return _CampaignDb.Date;
            }
        }
        public string Desc
        {
            set
            {
                _CampaignDb.Desc = value;
            }
            get
            {
                return _CampaignDb.Desc;
            }
        }
        public string Criteria
        {
            set
            {
                _CampaignDb.Criteria = value;
            }
            get
            {
                return _CampaignDb.Criteria;
            }
        }
        //public ContactBiz Contact
        //{
        //    set
        //    {

        //        _Contact = value;
        //    }
        //    get
        //    {
        //        if (_Contact == null)
        //            _Contact = new ContactBiz();
        //        return _Contact;
        //    }
        //}
        public ContactType ContactType
        {
            set
            {
                _CampaignDb.ContactItem = (int)value;
            }
            get
            {
                return  _CampaignDb.ContactItem >= ContactTypeCol.Count ? ContactType.NotSpecified :  (ContactType)_CampaignDb.ContactItem;
            }
        }
        public bool IsForInstallment
        {
            set
            {
                _CampaignDb.IsForInstallment = value;
            }
            get
            {
                return _CampaignDb.IsForInstallment;
            }
        }
        public bool IsSystemCampaign
        {
            set
            {
                _CampaignDb.IsSystemCampaign = value;
            }
            get
            {
                return _CampaignDb.IsSystemCampaign;
            }
        }
        public CellBiz CellBiz
        {
            set
            {
                _CellBiz = value;
            }
            get
            {
                if (_CellBiz == null)
                    _CellBiz = new CellBiz(_CampaignDb.CellFamilyID);
                return _CellBiz;
            }
        }
        public DateTime StartInstallmentDueDate
        {
            set
            {
                _CampaignDb.StartInstallmentDueDate = value;
            }
            get
            {
                return _CampaignDb.StartInstallmentDueDate;
            }
        }

        public DateTime EndInstallmentDueDate
        {
            set
            {
                _CampaignDb.EndInstallmentDueDate = value;
            }
            get
            {
                return _CampaignDb.EndInstallmentDueDate;
            }
        }
        public DateTime StartInstallmentPaymentDate
        {
            set
            {
                _CampaignDb.StartInstallmentPaymentDate = value;
            }
            get
            {
                return _CampaignDb.StartInstallmentPaymentDate;
            }
        }
        public DateTime EndInstallmentPaymentDate
        {
            set
            {
                _CampaignDb.EndInstallmentPaymentDate = value;
            }
            get
            {
                return _CampaignDb.EndInstallmentPaymentDate;
            }
        }
        public string Msg
        {
            set
            {
                _CampaignDb.Msg = value;
            }
            get
            {

                return _CampaignDb.Msg;
            }
        }
        public bool IsPeriodic
        {
            set { _CampaignDb.IsPeriodic = value; }
            get { return _CampaignDb.IsPeriodic; }
        }
        public DateTime WorkDate
        {
            set { _CampaignDb.WorkDate = value; }
            get { return _CampaignDb.WorkDate; }
        }
        public DateTime WorkHour
        {
            set { _CampaignDb.WorkHour = value; }
            get { return _CampaignDb.WorkHour; }
        }
        public bool AutomaticPerformed
        {
            set { _CampaignDb.AutomaticPerformed = value; }
            get { return _CampaignDb.AutomaticPerformed; }
        }
        public InstallmentTypeCol InstallmentTypeCol
        {
            set
            {
                _InstallmentTypeCol = value;
            }
            get
            {
                if (_InstallmentTypeCol == null)
                {
                    _InstallmentTypeCol = new InstallmentTypeCol(true);
                    if (ID != 0)
                    {
                        CampaignDb objDb = new CampaignDb();
                        objDb.ID = ID;
                        DataTable dtTemp = objDb.GetInstallmentTypeTable();
                        foreach (DataRow objDr in dtTemp.Rows)
                        {
                            _InstallmentTypeCol.Add(new InstallmentTypeBiz(objDr));
                        }
                    }

                }
                return _InstallmentTypeCol;
            }
        }

        public CampaignCustomerCol CustomerCol
        {
            set
            {
                _CustomerCol = value;
            }
            get
            {
                if (_CustomerCol == null)
                {
                    _CustomerCol = new CampaignCustomerCol(true);
                    if (ID != 0)
                    {
                        CampaignCustomerDb objDb = new CampaignCustomerDb();
                        objDb.Campaign = ID;
                        CampaignCustomerBiz objBiz;
                        DataTable dtTemp = objDb.Search();
                        foreach (DataRow objDr in dtTemp.Rows)
                        {
                            objBiz = new CampaignCustomerBiz(objDr);
                            objBiz.Campaign = this;
                            _CustomerCol.Add(objBiz);
                        }
                    }

                }
                return _CustomerCol;
            }
        }
        public CampaignCustomerCol NonContactedCustomerCol
        {
            set
            {
                _NonContactedCustomerCol = value;
            }
            get
            {
                if (_NonContactedCustomerCol == null)
                {
                    _NonContactedCustomerCol = new CampaignCustomerCol(true);
                    if (ID != 0)
                    {
                        CampaignCustomerDb objDb = new CampaignCustomerDb();
                        objDb.Campaign = ID;
                        objDb.ContactStatus  = 1;
                        CampaignCustomerBiz objBiz;
                        DataTable dtTemp = objDb.Search();
                        foreach (DataRow objDr in dtTemp.Rows)
                        {
                            objBiz = new CampaignCustomerBiz(objDr);
                            objBiz.Campaign = this;
                            _NonContactedCustomerCol.Add(objBiz);
                        }
                    }

                }
                return _NonContactedCustomerCol;
            }
        }
        public CampaignCustomerCol AddressedCustomerCol
        {
           
            get
            {
               
                    CampaignCustomerCol Returned= new CampaignCustomerCol(true);
                    foreach (CampaignCustomerBiz objBiz in CustomerCol)
                    {
                        if (objBiz.Customer.Address != null && objBiz.Customer.Address != "")
                            Returned.Add(objBiz);
                    }
                    return Returned;
            }
        }
        public CampaignCustomerCol DeleteedCustomerCol
        {
            set
            {
                _DeleteedCustomerCol = value;
            }
            get
            {
                if (_DeleteedCustomerCol == null)
                    _DeleteedCustomerCol = new CampaignCustomerCol(true);
                return _DeleteedCustomerCol;
            }
        }
        public CampaignCustomerCol EditedCustomerCol
        {
            set
            {
                _EditedCustomerCol = value;
            }
            get
            {
                if (_EditedCustomerCol == null)
                    _EditedCustomerCol = new CampaignCustomerCol(true);
                return _EditedCustomerCol;
            }
        }
        public CampaignSMSCol SMSCol
        {
            get
            {
                if (_SMSCol == null)
                {
                    _SMSCol = new CampaignSMSCol();
                    if (ID != 0)
                    {
                        CampaignSMSDb objDb = new CampaignSMSDb();
                        objDb.Campaign = ID;
                        DataTable dtTemp = objDb.Search();
                        CampaignSMSBiz objBiz;
                        foreach (DataRow objDr in dtTemp.Rows)
                        {
                            objBiz = new CampaignSMSBiz(objDr);
                            _SMSCol.Add(objBiz);
                        }
                    }
                }
                
                return _SMSCol;
            }
        }
        public int CustomerCount
        {
            get
            {
                return _CampaignDb.CustomerCount;
            }
        }
        public int NonContactedCustomerCount
        {
            get
            {
                return _CampaignDb.NonContactedCustomerCount;
            }
        }
        public int ContactedCustomerCount
        {
            get
            {
                return _CampaignDb.ContactedCustomerCount;
            }
        }
        public static CampaignBiz LastCampaignBiz
        {
            get
            {
                CampaignDb objDb = new CampaignDb();
                DataTable dtTemp = objDb.GetLastCampaign();
                if (dtTemp.Rows.Count > 0)
                {
                    return new CampaignBiz(dtTemp.Rows[0]);
                }
                else
                    return new CampaignBiz();
            }
        }
        public TopicBiz TopicBiz
        {
            set
            {
                _TopicBiz = value;
            }
            get
            {
                if (_TopicBiz == null)
                    _TopicBiz = new TopicBiz();
                return _TopicBiz;
            }
        }
        public CampaignRuleCol RuleCol
        {
            set 
            {
                _RuleCol = value;
            }
            get 
            {
                if (_RuleCol == null)
                {
                    _RuleCol = new CampaignRuleCol(true);
                    if (ID != 0)
                    {
                        CampaignRuleDb objDb = new CampaignRuleDb();
                        objDb.Campaign = ID;
                        DataTable dtTemp = objDb.Search();
                        foreach (DataRow objDr in dtTemp.Rows)
                        {
                            _RuleCol.Add(new CampaignRuleBiz(objDr));
                        }

                    }
                }
                return _RuleCol;
            }
        }
        public CampaignExceptedCustomerCol ExceptedCustomerCol
        {
            set 
            {
                _ExceptedCustomerCol = value;
            }
            get
            {
                if (_ExceptedCustomerCol == null)
                {
                    _ExceptedCustomerCol = new CampaignExceptedCustomerCol(true);
                    CampaignExceptedCustomerDb objDb = new CampaignExceptedCustomerDb();
                    objDb.Campaign = ID;
                    DataTable dtTemp = objDb.Search();
                    foreach (DataRow objDr in dtTemp.Rows)
                    {
                        _ExceptedCustomerCol.Add(new CampaignExceptedCustomerBiz(objDr));

                    }
                }
                return _ExceptedCustomerCol;
            }
        }
        CampaignScheduleCol _ScheduleCol;
        public CampaignScheduleCol ScheduleCol
        {
            set { _ScheduleCol = value; }
            get
            {
                if (_ScheduleCol == null)
                {
                    _ScheduleCol = new CampaignScheduleCol();
                    if (ID != 0)
                    {
                        CampaignScheduleDb objDb = new CampaignScheduleDb();
                        objDb.Campaign = ID;
                        DataTable dtTemp = objDb.Search();
                        CampaignScheduleBiz objBiz;
                        foreach (DataRow objDr in dtTemp.Rows)
                        {
                            objBiz = new CampaignScheduleBiz(objDr);
                            objBiz.CampaignBiz = this;
                            _ScheduleCol.Add(objBiz);
                        }
                    }
                }
                return _ScheduleCol;
            }
        }
        public static List<string> ContactTypeCol
        {
            get
            {
                List<string> Returned = new List<string>();
                Returned.Add("ÚíÑ ãÍÏÏ");
                Returned.Add("ÇÊÕÇá åÇÊÝì");
                Returned.Add("ÑÓÇáÉ ãæÈÇíá");
                Returned.Add("ÈÑíÏ ÇáíßÊÑæäì");
                Returned.Add("ÐåÇÈ Çáì ÇáÚãíá");
                Returned.Add("ÒíÇÑÉ ááÔÑßÉ");
                Returned.Add("ÎØÇÈ");

                return Returned;
            }
        }
        #endregion
        #region Private Methods
        void ResetCampaignCustomer()
        {
            _EditedCustomerCol = null;
            _CustomerCol = null;
            _DeleteedCustomerCol = null;
        }
        #endregion
        #region Public Methods
        public void Add()
        {
            //if (_Contact == null)
            //    _Contact = new ContactBiz();
            _CampaignDb.CellFamilyID = CellBiz.ID;
            _CampaignDb.InstallmentTypeTable = InstallmentTypeTable;
            //_CampaignDb.ContactItem = _Contact.ID;
            if (_RTF != null && _RTF != "")
            {

                RTFFileBiz.Bytes = LetterRTFBytes;
                RTFFileBiz.Name = "CampaignLetter.rtf";
                RTFFileBiz.Add();
            }
            //_CampaignDb.rule
            _CampaignDb.LetterRTF = RTFFileBiz.ID;
            _CampaignDb.RuleTable = RuleCol.GetTable();
            _CampaignDb.ScheduleTable = ScheduleCol.GetTable();
            _CampaignDb.Add();
        }
        public void Edit()
        {
            //if (_Contact == null)
            //    _Contact = new ContactBiz();

            //_CampaignDb.ContactItem = _Contact.ID;
            _CampaignDb.CellFamilyID = CellBiz.ID;
            _CampaignDb.InstallmentTypeTable = InstallmentTypeTable;
            if (RTFFileBiz.ID != 0)
            {
                RTFFileBiz.Bytes = LetterRTFBytes;
                RTFFileBiz.Name = "CampaignLetter.rtf";
                RTFFileBiz.Edit();
 
            }
            else if (_RTF != null && _RTF != "")
            {
                RTFFileBiz.Bytes = LetterRTFBytes;
                RTFFileBiz.Name = "CampaignLetter.rtf";
                RTFFileBiz.Add();
            }
            _CampaignDb.LetterRTF = RTFFileBiz.ID;
            _CampaignDb.RuleTable = RuleCol.GetTable();
            _CampaignDb.ScheduleTable = ScheduleCol.GetTable();
            _CampaignDb.Edit();
        }
        public void AddCustomer(CustomerBiz objCustomerBiz)
        {
            CampaignCustomerBiz objBiz = new CampaignCustomerBiz();
            objBiz.Campaign = this;
            objBiz.Customer = objCustomerBiz;
            CustomerCol.Add(objBiz);
            EditedCustomerCol.Add(objBiz);

        }
        public void AddCustomer(CustomerCol objCustomerCol)
        {
            CampaignCustomerBiz objBiz;
            foreach (CustomerBiz objCustomerBiz in objCustomerCol)
            {
                objBiz = new CampaignCustomerBiz();
                objBiz.Campaign = this;
                objBiz.Customer = objCustomerBiz;
                CustomerCol.Add(objBiz);
                EditedCustomerCol.Add(objBiz);
            }
        }
        //public void AddCustomer(ReservationCol objReservationCol)
        //{
        //    CampaignCustomerBiz objBiz;
        //    foreach (CustomerBiz objCustomerBiz in objCustomerCol)
        //    {
        //        objBiz = new CampaignCustomerBiz();
        //        objBiz.Campaign = this;
        //        objBiz.Customer = objCustomerBiz;
        //        CustomerCol.Add(objBiz);
        //        EditedCustomerCol.Add(objBiz);
        //    }
        //}
        public void DeleteCustomer(CampaignCustomerBiz objBiz)
        {
            if (objBiz.IsContacted)
                return;
            int intIndex = EditedCustomerCol.GetIndex(objBiz);
            if (intIndex != -1)
                EditedCustomerCol.RemoveAt(intIndex);
            intIndex = CustomerCol.GetIndex(objBiz);
            if (intIndex != -1)
            {
                if (objBiz.ID != 0)
                    DeleteedCustomerCol.Add(objBiz);
                CustomerCol.RemoveAt(intIndex);

            }
        }
        public void DeleteCustomer(CampaignCustomerCol objCol)
        {
            foreach (CampaignCustomerBiz objBiz in objCol)
                DeleteCustomer(objBiz);

        }

        public void Delete()
        {
            _CampaignDb.Delete();
        }
        public void SaveCampaignCustomer()
        {
            CampaignCustomerDb objDb = new CampaignCustomerDb();
            objDb.CustomerIDs = EditedCustomerCol.CustomerIDs;
            objDb.Campaign = ID;
            objDb.JoinCustomer();
            if (DeleteedCustomerCol.CustomerIDs != null && DeleteedCustomerCol.CustomerIDs != "")
            {
                objDb.CustomerIDs = DeleteedCustomerCol.CustomerIDs;
                objDb.Delete();
                ResetCampaignCustomer();
            }


        }
        public void SaveCampaignReservationCustmer(ReservationCol objReservationCol)
        {

            CampaignCustomerDb objDb = new CampaignCustomerDb();
            objDb.ReservationIDs = objReservationCol.IDsStr;
            objDb.Campaign = ID;
            objDb.JoinReservationCustomer();
 
        }
        public void StopCampaignReservationCustmer(ReservationCol objReservationCol)
        {

            CampaignCustomerDb objDb = new CampaignCustomerDb();
            objDb.ReservationIDs = objReservationCol.IDsStr;
            objDb.Campaign = ID;
            objDb.RemoveReservationCustomer();

        }
        public void SaveCampaignReservationCustmer(UnitCol objUnitCol)
        {

            CampaignCustomerDb objDb = new CampaignCustomerDb();
            objDb.UnitIDs = objUnitCol.IDsStr;
            objDb.Campaign = ID;
            objDb.JoinUnitCustomer();

        }
        public void StopCampaignCustomer(CustomerCol objCustomerCol)
        {
            CampaignCustomerDb objDb = new CampaignCustomerDb();
            objDb.CustomerIDs = objCustomerCol.IDsStr;
            objDb.Campaign = ID;
            objDb.StopCustomerContact();
        }
        public void StopCampaignReservationCustomer(ReservationCol objReservationCol)
        {
            CampaignCustomerDb objDb = new CampaignCustomerDb();
            objDb.ReservationIDs = objReservationCol.IDsStr;
            objDb.Campaign = ID;
            objDb.StopReservationContact();
 
        }
        public void MonitorCampaignReservation(ReservationCol objCol, EmployeeBiz objEmployeeBiz, int intSttaus,
            string strDesc, bool blWaitingMonitor, DateTime dtWaitingMonitorDate)
        {
            CampaignCustomerDb objDb = new CampaignCustomerDb();
            objDb.MonitoringStatus = intSttaus;
            objDb.MonitoringDesc = strDesc;
            objDb.MonitoringEmployee = objEmployeeBiz.ID;
            objDb.WaitingMonitor = blWaitingMonitor;
            objDb.WaitingMonitoringDate = dtWaitingMonitorDate;
            objDb.ReservationIDs = objCol.IDsStr;

            objDb.MonitorCol();
        }
        public void EditWaitingMonitorDate(ReservationCol objCol, bool blWaiting, DateTime dtWaitingDate)
        {
            CampaignCustomerDb objDb = new CampaignCustomerDb();
            objDb.ReservationIDs = objCol.IDsStr;
            objDb.WaitingMonitor = blWaiting;
            objDb.WaitingMonitoringDate = dtWaitingDate;
            objDb.EditMonitoringWaitingDateCol();
        }
        public CampaignBiz Copy()
        {
            CampaignBiz Returned = new CampaignBiz();
            Returned.ID = ID;
            Returned.Desc = Desc;
            Returned.Msg = Msg;
            return Returned;
        }
        public void SetRuleCampaignCustomerCol1()
        {
            Hashtable hsCustomer = new Hashtable();
            Hashtable hsException = new Hashtable();
            CampaignExceptedCustomerDb objExpted = new CampaignExceptedCustomerDb();
            objExpted.Campaign = ID;
             DataTable dtTemp;
             dtTemp = objExpted.Search();
            CampaignExceptedCustomerBiz objExpectedBiz ;
            foreach (DataRow objDr in dtTemp.Rows)
            {
                objExpectedBiz = new CampaignExceptedCustomerBiz(objDr);
                if (hsException[objExpectedBiz.CustomerBiz.ID.ToString()] == null)
                {
                    hsException.Add(objExpectedBiz.CustomerBiz.ID.ToString(), objExpectedBiz.CustomerBiz);
                }
            }

            CustomerBiz objCustomerBiz;
            CampaignCustomerBiz objCampaignCustomerBiz;
            CampaignRuleDb objRuleDb = new CampaignRuleDb();
            string strCustomerIDs = "";
            Hashtable hstCampaignCustomer = new Hashtable();
            DataTable dtTemp2;
            CampaignCustomerDb objCampaignCustomerDb;
            foreach (CampaignRuleBiz objBiz in RuleCol)
            {
                objRuleDb = new CampaignRuleDb();
                objRuleDb.ID = objBiz.ID;

               objRuleDb.PeriodType = (int)objBiz.PeriodType;

               dtTemp = objRuleDb.GetCustomer();
               if (dtTemp.Rows.Count > 0)
               {
                   strCustomerIDs = SysUtility.GetStringArr(dtTemp, "CustomerID", 5000)[0];
                   objCampaignCustomerDb = new CampaignCustomerDb();
                   objCampaignCustomerDb.CustomerIDs = strCustomerIDs;
                   objCampaignCustomerDb.Campaign = ID;
                   dtTemp2 = objCampaignCustomerDb.Search();
                   foreach (DataRow objDr in dtTemp2.Rows)
                   {
                       objCampaignCustomerBiz = new CampaignCustomerBiz(objDr);
                       if (hstCampaignCustomer[objCampaignCustomerBiz.Customer.ID.ToString()] == null)
                       {
                           hstCampaignCustomer.Add(objCampaignCustomerBiz.Customer.ID.ToString(), objCampaignCustomerBiz);

                       }
                   }

               }
                objBiz.CustomerCol = new CampaignCustomerCol(true);
                foreach (DataRow objDr in dtTemp.Rows)
                {

                    objCustomerBiz = new CustomerBiz(objDr);
                    if (hsCustomer[objCustomerBiz.ID.ToString()] != null ||
                        hsException[objCustomerBiz.ID.ToString()]!= null)
                        continue;
                    hsCustomer.Add(objCustomerBiz.ID.ToString(), objCustomerBiz.ID);
                    if (hstCampaignCustomer[objCustomerBiz.ID.ToString()] != null)
                    {
                        objCampaignCustomerBiz =(CampaignCustomerBiz) hstCampaignCustomer[objCustomerBiz.ID.ToString()];
                        if (objCampaignCustomerBiz.IsContacted && objCampaignCustomerBiz.ContactDate.Date.AddDays(objRuleDb.DayDiff - 1) > DateTime.Now.Date)
                            continue;
                    }
                  
                    objCampaignCustomerBiz = new CampaignCustomerBiz();
                    objCampaignCustomerBiz.Customer = objCustomerBiz;
                    objCampaignCustomerBiz.RuleBiz = objBiz;
                    objCampaignCustomerBiz.Campaign = Copy();
                    objCampaignCustomerBiz.Campaign.Msg = objBiz.Msg;
                    objBiz.CustomerCol.Add(objCampaignCustomerBiz);

                }



            }
            strCustomerIDs = "";
        }
        public void SetRuleCampaignCustomerCol()
        {
            Hashtable hsCustomer = new Hashtable();
            Hashtable hsException = new Hashtable();
            CampaignExceptedCustomerDb objExpted = new CampaignExceptedCustomerDb();
            objExpted.Campaign = ID;
            DataTable dtTemp;
            dtTemp = objExpted.Search();
            CampaignExceptedCustomerBiz objExpectedBiz;
            foreach (DataRow objDr in dtTemp.Rows)
            {
                objExpectedBiz = new CampaignExceptedCustomerBiz(objDr);
                if (hsException[objExpectedBiz.CustomerBiz.ID.ToString()] == null)
                {
                    hsException.Add(objExpectedBiz.CustomerBiz.ID.ToString(), objExpectedBiz.CustomerBiz);
                }
            }

            CustomerBiz objCustomerBiz;
            CampaignCustomerBiz objCampaignCustomerBiz;
            foreach (CampaignRuleBiz objBiz in RuleCol)
            {
                ReservationInstallmentDb objDb = new ReservationInstallmentDb();
                objDb.Campaign = ID;
                objDb.CampaignRuleID = objBiz.ID;
                objDb.StatusSearch = 1;
                objDb.ReservationStatus = 1;
                objDb.CampaignRulePeriodType = (int)objBiz.PeriodType;
                dtTemp = objDb.GetInstallmentCustomer();
                objBiz.CustomerCol = new CampaignCustomerCol(true);
                foreach (DataRow objDr in dtTemp.Rows)
                {
                    objCustomerBiz = new CustomerBiz(objDr);
                    if (hsCustomer[objCustomerBiz.ID.ToString()] != null ||
                        hsException[objCustomerBiz.ID.ToString()] != null)
                        continue;
                    hsCustomer.Add(objCustomerBiz.ID.ToString(), objCustomerBiz.ID);
                    objCampaignCustomerBiz = new CampaignCustomerBiz();
                    objCampaignCustomerBiz.Customer = objCustomerBiz;
                    objCampaignCustomerBiz.RuleBiz = objBiz;
                    objCampaignCustomerBiz.Campaign = Copy();
                    objCampaignCustomerBiz.Campaign.Msg = objBiz.Msg;
                    objBiz.CustomerCol.Add(objCampaignCustomerBiz);

                }



            }
        }
        public void SetRuleCampaignCustomerRemainingCol()
        {
            Hashtable hsCustomer = new Hashtable();
            DataTable dtTemp;
            CustomerBiz objCustomerBiz;
            CampaignCustomerBiz objCampaignCustomerBiz;
            List<string> arrCustomerStr = new List<string>();
            DataRow []arrDr;
            int intCustomerCount = 1500;
            string strCustomerID;
            ReservationInstallmentDb objDb;
            DataTable dtCustomerDeserved;
            foreach (CampaignRuleBiz objBiz in RuleCol)
            {
                 objDb = new ReservationInstallmentDb();
                objDb.Campaign = ID;
                objDb.CampaignRuleID = objBiz.ID;
                objDb.StatusSearch = 1;
                objDb.ReservationStatus = 1;
                objDb.CampaignRulePeriodType = (int)objBiz.PeriodType;
                dtTemp = objDb.GetInstallmentCustomer();
                objBiz.CustomerCol = new CampaignCustomerCol(true);
                if (dtTemp.Rows.Count == 0)
                    continue;
                arrCustomerStr = SysUtility.GetStringArr(dtTemp, "CustomerID", intCustomerCount);
                foreach (string strCustomer in arrCustomerStr)
                {
                    objDb = new ReservationInstallmentDb();
                    objDb.CustomerIDs = strCustomer;
                    dtCustomerDeserved = objDb.GetRemainingInstallmentTable();
                    //foreach (DataRow objDr in dtTemp.Rows)
                    foreach(DataRow objDr in dtCustomerDeserved.Rows)
                    {
                        strCustomerID = objDr["CustomerID"].ToString();
                        arrDr = dtTemp.Select("CustomerID=" + strCustomerID);
                        if (arrDr.Length == 0)
                            continue;
                        objCustomerBiz = new CustomerBiz(arrDr[0]);
                        objCustomerBiz.Debt = double.Parse(objDr["TotalRemainingValue"].ToString());
                        if (hsCustomer[objCustomerBiz.ID.ToString()] != null)
                            continue;
                        hsCustomer.Add(objCustomerBiz.ID.ToString(), objCustomerBiz.ID);
                        objCampaignCustomerBiz = new CampaignCustomerBiz();
                        objCampaignCustomerBiz.Customer = objCustomerBiz;
                        objCampaignCustomerBiz.RuleBiz = objBiz;
                        objCampaignCustomerBiz.Campaign = Copy();
                        objCampaignCustomerBiz.Campaign.Msg = objBiz.Msg;
                        objBiz.CustomerCol.Add(objCampaignCustomerBiz);

                    }
                }



            }
        }
        public static void SetMainExceptedCampaignCustomer(CustomerCol objCol, bool blIsDateLimited,
            DateTime dtLimitDate,string strReason)
        {
          
           CampaignExceptedCustomerDb objDb = new CampaignExceptedCustomerDb();
           objDb.CustomerIDs = objCol.IDsStr;
           objDb.IsDateLimited = blIsDateLimited;
           objDb.EndDate = dtLimitDate;
           objDb.Reason = strReason;
           objDb.SetExceptedSystemCampaignCustomer();
          
 
        }
        public static void SetExceptedCampaignCustomer(CampaignBiz objCampaignBiz,CustomerCol objCol, bool blIsDateLimited,
          DateTime dtLimitDate, string strReason)
        {
           
            CampaignExceptedCustomerDb objDb = new CampaignExceptedCustomerDb();
            objDb.CustomerIDs = objCol.IDsStr;
            objDb.IsDateLimited = blIsDateLimited;
            objDb.EndDate = dtLimitDate;
            objDb.Reason = strReason;
            objDb.Campaign = objCampaignBiz == null ? 0 : objCampaignBiz.ID;
            objDb.SetExceptedCampaignCustomer();


        }
        public static void ResetMainExceptedCampaignCustomer(CustomerCol objCol)
        {

            CampaignExceptedCustomerDb objDb = new CampaignExceptedCustomerDb();
            objDb.CustomerIDs = objCol.IDsStr;
            objDb.StopCampaignCustomerException();


        }
        public void JoinProjectCustomer(string strProjectIDs)
        {
            CampaignDb objDb = new CampaignDb();
            objDb.ID = ID;
            objDb.Project = strProjectIDs;
            objDb.JoinProjectCustomer();
        }
        public void JoinAllCustomer()
        {
            CampaignDb objDb = new CampaignDb();
            objDb.ID = ID;
            
            objDb.JoinAllProjectCustomer();
        }
        public void DeleteAllCustomer()
        {
            CampaignDb objDb = new CampaignDb();
            objDb.ID = ID;

            objDb.DeleteAllCustomer();
        }
        public void CopyCampaignCustomer(int intSourceCampaign)
        {
            CampaignDb objDb = new CampaignDb();
            objDb.ID = ID;
            objDb.SourceCampaign = intSourceCampaign;
            objDb.CopyCampaignCustomer();
        }
        #endregion
    }
}
