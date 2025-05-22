using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.HR.HRDataBase;
using System.Data;
using SharpVision.COMMON.COMMONBusiness;
using SharpVision.UMS.UMSBusiness;
using SharpVision.COMMON.COMMONDataBase;

namespace SharpVision.HR.HRBusiness
{
    public class ApplicantBiz
    {
        #region Private Data
         protected ApplicantDb _ApplicantDb;
        
        protected IDTypeInstantBiz _IDTypeInstantBiz;
        protected AttachmentFileBiz _AttachmentCVBiz;
        
       
        protected CurrencyBiz _SalaryCurrencyBiz;
        string _PathCV;
        
        #endregion
        #region Constructors
        public ApplicantBiz()
        {
            _ApplicantDb = new ApplicantDb();
            
            _SalaryCurrencyBiz = new CurrencyBiz();
        }
        public ApplicantBiz(int intID)
        {
            _ApplicantDb = new ApplicantDb(intID);
           
            _IDTypeInstantBiz = new IDTypeInstantBiz();
        
        
        }
        public ApplicantBiz(DataRow objDR)
        {
            _ApplicantDb = new ApplicantDb(objDR);
           
            _SalaryCurrencyBiz = new CurrencyBiz(objDR);
            try
            {
                if (objDR.Table.Columns["IDTypeID"] != null && objDR["IDTypeID"].ToString() != "")
                    _IDTypeInstantBiz = new IDTypeInstantBiz(objDR);
                else
                {
                    _IDTypeInstantBiz = new IDTypeInstantBiz();
                    if (objDR.Table.Columns["IDValue"] != null)
                        _IDTypeInstantBiz.IDValue = objDR["IDValue"].ToString();
                    int intTemp = 0;
                    if (objDR.Table.Columns["ApplicantIDType"] != null)
                        int.TryParse(objDR["ApplicantIDType"].ToString(), out intTemp);
                    _IDTypeInstantBiz.ID = intTemp;
                }
            }
            catch
            { }

            

        }
        #endregion
        #region Public Properties
        public int ID
        {
            set
            {
                _ApplicantDb.ID = value;
            }
            get
            {
                return _ApplicantDb.ID;
            }
        }
        public int SexTypeID
        {
            set
            {
                _ApplicantDb.SexTypeID = value;
            }
            get
            {
                return _ApplicantDb.SexTypeID;
            }
        }
        public string Name
        {
            set
            {
                _ApplicantDb.Name = value;
            }
            get
            {
                if (_ApplicantDb.Name == null)
                    return "";
                return _ApplicantDb.Name;
            }

        }
        public string FamousName
        {
            set
            {
                _ApplicantDb.FamousName = value;
            }
            get
            {
                return _ApplicantDb.FamousName;
            }

        }
        public string NameComp
        {
            set
            {
                _ApplicantDb.NameComp = value;
            }
            get
            {
                if (_ApplicantDb.NameComp == null)
                    _ApplicantDb.NameComp = "";
                return _ApplicantDb.NameComp;
            }
        }
        public string UserName
        {
            set
            {
                _ApplicantDb.UserName = value;
            }
            get
            {
                return _ApplicantDb.UserName;
            }

        }
        public string Password
        {
            set
            {
                _ApplicantDb.Password = value;
            }
            get
            {
                return _ApplicantDb.Password;
            }

        }
        public string Desc
        {
            set
            {
                _ApplicantDb.Desc = value;
            }
            get
            {
                return _ApplicantDb.Desc;
            }
        }
        public string IDValue
        {
            set
            {
                _ApplicantDb.IDValue = value;
            }
            get
            {
                return _ApplicantDb.IDValue;
            }
        }
        public DateTime IDTypeIssueDate
        {
            set
            {
                _ApplicantDb.IDTypeIssueDate = value;
            }
            get
            {
                return _ApplicantDb.IDTypeIssueDate;
            }
        }
        public bool IDTypeIssueDateStatus
        {
            set
            {
                _ApplicantDb.IDTypeIssueDateStatus = value;
            }
            get
            {
                return _ApplicantDb.IDTypeIssueDateStatus;
            }
        }
        public IDTypeInstantBiz IDTypeInstantBiz
        {
            set
            {
                _IDTypeInstantBiz = value;
                try
                {
                    _ApplicantDb.IDTypeInstantDb = new IDTypeInstantDb(_ApplicantDb.IDTypeInstantDb.ID, _ApplicantDb.IDTypeInstantDb.Name, _ApplicantDb.IDTypeInstantDb.IDValue);
                }
                catch
                { }
            }
            get
            {
                if (_IDTypeInstantBiz == null)
                    _IDTypeInstantBiz = new IDTypeInstantBiz();
                return _IDTypeInstantBiz;
            }
        }
        public DateTime BirthDate
        {
            set
            {
                _ApplicantDb.BirthDate = value;
            }
            get
            {
                return _ApplicantDb.BirthDate;
            }
        }
        public bool BirthDateStatus
        {
            set
            {
                _ApplicantDb.BirthDateStatus = value;
            }
            get
            {
                return _ApplicantDb.BirthDateStatus;
            }
        }
        public string Address
        {
            set
            {
                _ApplicantDb.Address = value;
            }
            get
            {
                return _ApplicantDb.Address;
            }

        }
        public string BirthPlace
        {
            set
            {
                _ApplicantDb.BirthPlace = value;
            }
            get
            {
                return _ApplicantDb.BirthPlace;
            }

        }
        //public int RegionID
        //{
        //    set
        //    {
        //        _ApplicantDb.RegionID = value;
        //    }
        //    get
        //    {
        //        return _ApplicantDb.RegionID;
        //    }
        //}
     
        //public string RegionStr
        //{
        //    set { _ApplicantDb.RegionStr = value; }
        //    get { return _ApplicantDb.RegionStr; }
        //}
        public string NationalityStr
        {
            set { _ApplicantDb.NationalityStr = value; }
            get { return _ApplicantDb.NationalityStr; }
        }
        public int CommonService
        {
            set
            {
                _ApplicantDb.CommonService = value;
            }
            get
            {
                return _ApplicantDb.CommonService;
            }
        }
        public int MaritalStatusID
        {
            set { _ApplicantDb.MaritalStatusID = value; }
            get { return _ApplicantDb.MaritalStatusID; }
        }
        public string MaritalStatusStr
        {
            get
            {
                string Returned = "";
                if (MaritalStatusID == 0)
                    Returned = "€Ì— „Õœœ";
                else if (MaritalStatusID == 1)
                    Returned = "√⁄“»";
                else if (MaritalStatusID == 2)
                    Returned = "„ “ÊÃ";
                else if (MaritalStatusID == 3)
                    Returned = "„ÿ·ﬁ";
                else if (MaritalStatusID == 4)
                    Returned = "√—„·";
                else if (MaritalStatusID == 5)
                    Returned = "«‰”…";
                return Returned;
            }
        }
        public int MiltaryStatusID
        {
            set { _ApplicantDb.MiltaryStatusID = value; }
            get { return _ApplicantDb.MiltaryStatusID; }
        }
        public string MiltaryStatusAndCommonServiceStr
        {
            get
            {
                string Returned = "";
                if (SexTypeID == 1)
                {
                    if (MiltaryStatusID == 0)
                        Returned = "€Ì— „Õœœ";
                    else if (MiltaryStatusID == 1)
                        Returned = "„⁄«›Ï „ƒﬁ ";
                    else if (MiltaryStatusID == 2)
                        Returned = "„⁄«›Ï ‰Â«∆Ì";
                    else if (MiltaryStatusID == 3)
                        Returned = "√œÏ «·Œœ„…";
                    else if (MiltaryStatusID == 4)
                        Returned = "„ƒÃ·  Ã‰ÌœÂ";
                    else if (MiltaryStatusID == 5)
                        Returned = "·„ Ì’»Â «·œÊ—";
                    else if (MiltaryStatusID == 6)
                        Returned = "·„  Õœœ „⁄«„· Â";
                    else if (MiltaryStatusID == 7)
                        Returned = "ﬁÊ«  „”·Õ… / ‘—ÿÂ";
                    //else if (MiltaryStatusID == 8)
                    //    Returned = "·«ÌÊÃœ";
                    //else if (MiltaryStatusID == 9)
                    //    Returned = "·„ Ì’»Â «·œÊ—";
                }
                else if (SexTypeID == 2)
                {
                    if (CommonService == 0)
                        Returned = "€Ì— „Õœœ";
                    else if (CommonService == 1)
                        Returned = "√œ  «·Œœ„…";
                    else if (CommonService == 2)
                        Returned = "·„  √œÏ «·Œœ„…";
                }
                return Returned;
            }
        }
        public string SexTypeStr
        {
            get
            {
                string Returned = "";
                if (SexTypeID == 0)
                    Returned = "€Ì— „Õœœ";
                else if (SexTypeID == 1)
                    Returned = "–ﬂ—";
                else if (SexTypeID == 2)
                    Returned = "√‰ÀÏ";

                return Returned;
            }
        }
        public string ReligionStr
        {
            get
            {
                string Returned = "";
                if (ReligionID == 0)
                    Returned = "€Ì— „Õœœ";
                else if (ReligionID == 1)
                    Returned = "„”·„";
                else if (ReligionID == 2)
                    Returned = "„”ÌÕÏ";

                return Returned;
            }
        }
        public int ReligionID
        {
            set { _ApplicantDb.ReligionID = value; }
            get { return _ApplicantDb.ReligionID; }
        }
        public int NationalityID
        {
            set { _ApplicantDb.NationalityID = value; }
            get { return _ApplicantDb.NationalityID; }
        }
        public bool IsOwnCar
        {
            set { _ApplicantDb.IsOwnCar = value; }
            get { return _ApplicantDb.IsOwnCar; }
        }
        public bool IsHasDrivingLicense
        {
            set { _ApplicantDb.IsHasDrivingLicense = value; }
            get { return _ApplicantDb.IsHasDrivingLicense; }
        }
        public int YearExperience
        {
            set { _ApplicantDb.YearExperience = value; }
            get { return _ApplicantDb.YearExperience; }
        }
        public int StartWorkAfterWeek
        {
            set { _ApplicantDb.StartWorkAfterWeek = value; }
            get { return _ApplicantDb.StartWorkAfterWeek; }
        }
       
        public float SalaryValue
        {
            set { _ApplicantDb.SalaryValue = value; }
            get { return _ApplicantDb.SalaryValue; }
        }
       
        public CurrencyBiz SalaryCurrencyBiz
        {
            set { _SalaryCurrencyBiz = value; }
            get { return _SalaryCurrencyBiz; }
        }
      
        
       
        public int ApplicantStatus
        {
            set { _ApplicantDb.ApplicantStatus = value; }
            get { return _ApplicantDb.ApplicantStatus; }
        }
        public string PathCV
        {
            set
            {
                _PathCV = value;
            }
            get
            {
                if (_PathCV == null || _PathCV == "")
                {
                    if (AttachmentCVBiz != null && AttachmentCVBiz.ID != 0)
                    {
                        _PathCV = AttachmentCVBiz.Path;
                    }
                    else
                        _PathCV = "";

                }

                return _PathCV;
            }
        }
        public AttachmentFileBiz AttachmentCVBiz
        {
            set
            {
                _AttachmentCVBiz = value;
            }
            get
            {
                if (_AttachmentCVBiz == null)
                {
                    if (_ApplicantDb.ApplicantCV != 0)
                    {
                        _AttachmentCVBiz = new AttachmentFileBiz(_ApplicantDb.ApplicantCV);
                    }
                    else
                        _AttachmentCVBiz = new AttachmentFileBiz();
                }
                return _AttachmentCVBiz;
            }
        }

        

       
        #endregion
        #region Private Methods

        #endregion
        #region Public Methods
        public virtual void Add()
        {
            
            //_ApplicantDb.DegreeTable = _DegreeCol.GetTable();         
           
           
            _ApplicantDb.IDType = _IDTypeInstantBiz.ID;
            _ApplicantDb.IDValue = _IDTypeInstantBiz.IDValue;
           
            _ApplicantDb.SalaryCurrency = _SalaryCurrencyBiz.ID;
            //_ApplicantDb.RequestTable = _RequestCol.GetTable();

             
    
           
            if (PathCV != "")
            {
                AttachmentCVBiz.FilePath = PathCV;
                AttachmentCVBiz.Add();
            }
            _ApplicantDb.ApplicantCV = AttachmentCVBiz.ID;

            _ApplicantDb.Add();
        }
        public virtual void Edit()
        {
            
            //_ApplicantDb.DegreeTable = _DegreeCol.GetTable();            
            
            _ApplicantDb.IDType = _IDTypeInstantBiz.ID;
            _ApplicantDb.IDValue = _IDTypeInstantBiz.IDValue;

          
            _ApplicantDb.SalaryCurrency = _SalaryCurrencyBiz.ID;
            //_ApplicantDb.RequestTable = _RequestCol.GetTable();
      
        
          
            if (AttachmentCVBiz.Path != PathCV)
            {
                AttachmentCVBiz.Bytes = null;
                AttachmentCVBiz.FilePath = PathCV;
                AttachmentCVBiz.Edit();
            }


            _ApplicantDb.Edit();
        }
        public virtual void Delete()
        {
            _ApplicantDb.Delete();
        }
        public ApplicantWorkerBiz GetApplicantWorkerBiz()
        {

            ApplicantWorkerBiz objApplicantWorkerBiz = new ApplicantWorkerBiz();

            objApplicantWorkerBiz._ApplicantDb.Address = _ApplicantDb.Address;
            objApplicantWorkerBiz._ApplicantDb.BirthDate = _ApplicantDb.BirthDate;
            objApplicantWorkerBiz._ApplicantDb.BirthDateStatus = _ApplicantDb.BirthDateStatus;
            objApplicantWorkerBiz._ApplicantDb.BirthPlace = _ApplicantDb.BirthPlace;
            objApplicantWorkerBiz._ApplicantDb.CommonService = _ApplicantDb.CommonService;
            objApplicantWorkerBiz._ApplicantDb.FamousName = _ApplicantDb.FamousName;
            objApplicantWorkerBiz._ApplicantDb.ID = _ApplicantDb.ID;
            objApplicantWorkerBiz._ApplicantDb.IDType = _ApplicantDb.IDType;
            objApplicantWorkerBiz._ApplicantDb.IDTypeInstantDb = _ApplicantDb.IDTypeInstantDb;
            objApplicantWorkerBiz._ApplicantDb.IDValue = _ApplicantDb.IDValue;
            objApplicantWorkerBiz._ApplicantDb.MaritalStatusID = _ApplicantDb.MaritalStatusID;
            objApplicantWorkerBiz._ApplicantDb.MiltaryStatusID = _ApplicantDb.MiltaryStatusID;
            objApplicantWorkerBiz._ApplicantDb.Name = _ApplicantDb.Name;
            objApplicantWorkerBiz._ApplicantDb.NameComp = _ApplicantDb.NameComp;
            objApplicantWorkerBiz._ApplicantDb.NationalityID = _ApplicantDb.NationalityID;
            objApplicantWorkerBiz._ApplicantDb.NationalityStr = _ApplicantDb.NationalityStr;
            objApplicantWorkerBiz._ApplicantDb.RegionID = _ApplicantDb.RegionID;
            objApplicantWorkerBiz._ApplicantDb.RegionStr = _ApplicantDb.RegionStr;
            objApplicantWorkerBiz._ApplicantDb.ReligionID = _ApplicantDb.ReligionID;
            objApplicantWorkerBiz._ApplicantDb.SexTypeID = _ApplicantDb.SexTypeID;
            objApplicantWorkerBiz._ApplicantDb.IsOwnCar = _ApplicantDb.IsOwnCar;
            objApplicantWorkerBiz._ApplicantDb.IsHasDrivingLicense = _ApplicantDb.IsHasDrivingLicense;
            objApplicantWorkerBiz._ApplicantDb.YearExperience = _ApplicantDb.YearExperience;
            objApplicantWorkerBiz._ApplicantDb.StartWorkAfterWeek = _ApplicantDb.StartWorkAfterWeek;
            objApplicantWorkerBiz._ApplicantDb.JobTimeType = _ApplicantDb.JobTimeType;
            objApplicantWorkerBiz._ApplicantDb.SalaryValue = _ApplicantDb.SalaryValue;
            objApplicantWorkerBiz._ApplicantDb.RankRequested = _ApplicantDb.RankRequested;
            objApplicantWorkerBiz._ApplicantDb.SalaryCurrency = _ApplicantDb.SalaryCurrency;
            objApplicantWorkerBiz._IDTypeInstantBiz = new IDTypeInstantBiz(_ApplicantDb.IDTypeInstantDb);
         
            objApplicantWorkerBiz._ApplicantDb.IDTypeIssueDate = _ApplicantDb.IDTypeIssueDate;
            objApplicantWorkerBiz._ApplicantDb.IDTypeIssueDateStatus = _ApplicantDb.IDTypeIssueDateStatus;
            return objApplicantWorkerBiz;


        }
        public void EditApplicantCVValue(int intCVFileID)
        {
            _ApplicantDb.ApplicantCV = intCVFileID;
            _ApplicantDb.EditApplicantCVValue();
        }
        #endregion
    }
}
