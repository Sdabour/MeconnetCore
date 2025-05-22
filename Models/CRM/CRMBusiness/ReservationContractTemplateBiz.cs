using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.Base.BaseDataBase;
using SharpVision.Base.BaseBusiness;
using SharpVision.SystemBase;
using SharpVision.RP.RPBusiness;
using SharpVision.CRM.CRMDataBase;
using SharpVision.COMMON.COMMONBusiness;
using System.Collections;
namespace SharpVision.CRM.CRMBusiness
{
    public class ReservationContractTemplateBiz
    {
        #region Private Data
        ReservationContractTemplateDb _TemplateDb;
        string _RTF;

        AttachmentFileBiz _RTFFileBiz;
        #region Keys
        static List<string> _LstKeys;
        #endregion
        #endregion
        #region Constructors
        public ReservationContractTemplateBiz()
        {
            _TemplateDb = new ReservationContractTemplateDb();
        }
        public ReservationContractTemplateBiz(DataRow objDr)
        {

            _TemplateDb = new ReservationContractTemplateDb(objDr);
        }

        #endregion
        #region Private Properties
        AttachmentFileBiz RTFFileBiz
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
                    if (_TemplateDb.RTF != 0)
                    {
                        _RTFFileBiz = new AttachmentFileBiz(_TemplateDb.RTF);
                    }
                }
                return _RTFFileBiz;
            }
        }
        byte[] RTFBytes
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
        #endregion

        #region Public Properties
        public int ID
        {
            set
            {
                _TemplateDb.ID = value;
            }
            get
            {
                return _TemplateDb.ID;
            }
        }
        public string Title
        {
            set
            {
                _TemplateDb.Title = value;
            }
            get
            {
                return _TemplateDb.Title;
            }
        }
        public string Desc
        {
            set
            {
                _TemplateDb.Desc = value;
            }
            get
            {
                return _TemplateDb.Desc;
            }
        }
        public bool IsStoped
        {
            set
            {
                _TemplateDb.IsStoped = value;
            }
            get
            {
                return _TemplateDb.IsStoped;
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
                    if (_TemplateDb.RTF != 0)
                    {
                        _RTF = System.Text.Encoding.Unicode.GetString(RTFFileBiz.Bytes);
                        
                    }
                }
                return _RTF;
            }
        }
        public static List<string> LstKeys
        {
            get
            {
                if (_LstKeys == null)
                {
                    _LstKeys = new List<string>();
                    _LstKeys.Add("{ÇÓã ÇáÚãíá}");//0
                    _LstKeys.Add("{ÚäæÇä ÇáÚãíá}");//1
                    _LstKeys.Add("{ÌäÓíÉ ÇáÚãíá}");//2
                    _LstKeys.Add("{ÈØÇÞÉ}");//3
                    _LstKeys.Add("{ÑÞã ÇáÈÑÌ}");//4
                    _LstKeys.Add("{ÑÞã ÇáæÍÏÉ}");//5
                    _LstKeys.Add("{ÇáãÓÇÍÉ}");//6
                    _LstKeys.Add("{ÇáÍÏ ÇáÈÍÑì}");//7
                    _LstKeys.Add("{ÇáÍÏ ÇáÞÈáì}");//8
                    _LstKeys.Add("{ÇáÍÏ ÇáÔÑÞì}");//9
                    _LstKeys.Add("{ÇáÍÏ ÇáÛÑÈì}");//10
                    _LstKeys.Add("{ÊÇÑíÎ ÇáÊÚÇÞÏ}");//11
                    _LstKeys.Add("{ÞíãÉ ÇáÊÚÇÞÏ}");//12
                    _LstKeys.Add("{ÏÝÚÇÊ ÇáÍÌÒ æÇáÊÚÇÞÏ}");//13
                    _LstKeys.Add("{ÊÇÑíÎ ÇáÊÓáíã}");//14
                    _LstKeys.Add("{ÇáãÔÑæÚ}");//15
                    

                }
                return _LstKeys;
            }
        }
        #endregion
        #region Private Methods
      
        #endregion
        #region Public Methods
        public void Add()
        {
            RTFFileBiz.Bytes = RTFBytes;
            RTFFileBiz.Name = "ContractTemplete.rtf";
            RTFFileBiz.Add();
            _TemplateDb.RTF = RTFFileBiz.ID;
            _TemplateDb.Add();
        }
        public void Edit()
        {
            RTFFileBiz.Bytes = RTFBytes;
            RTFFileBiz.Name = "ContractTemplete.rtf";
            RTFFileBiz.Edit();
            _TemplateDb.Edit();
        }
        public void Delete()
        {
            RTFFileBiz.Delete(RTFFileBiz.ID);
            _TemplateDb.Delete();
        }
        public static string GetPropertyStr(int intIndex, ReservationBiz objBiz)
        {
            string Returned = "";
            switch (intIndex)
            {
                case 0: Returned = objBiz.CustomerStr; break;
                case 1: Returned = objBiz.CustomerStr; break;
                case 2: Returned = objBiz.CustomerStr; break;
                case 3: Returned = objBiz.CustomerStr; break;
                case 4: Returned = objBiz.CustomerStr; break;
                case 5: Returned = objBiz.CustomerStr; break;
                case 6: Returned = objBiz.CustomerStr; break;
                case 7: Returned = objBiz.CustomerStr; break;
                case 8: Returned = objBiz.CustomerStr; break;
                case 9: Returned = objBiz.CustomerStr; break;
                case 10: Returned = objBiz.CustomerStr; break;
                case 11: Returned = objBiz.CustomerStr; break;
                case 12: Returned = objBiz.CustomerStr; break;
                case 13: Returned = objBiz.CustomerStr; break;

                    

            }
            return Returned;
        }
        public static string GetPropertyStr(int intIndex, CustomerBiz objCustomerBiz)
        {
            string Returned = "";
            string strCustomerName = objCustomerBiz.Name;
            string[] arrStr = strCustomerName.Split(' ');
           // strCustomerName = arrStr.Length >1 ? arrStr[0] + " "+ arrStr[1] : (arrStr.Length >0 ? arrStr[0] : "");
            switch (intIndex)
            {
                   
                //case 0: Returned = objCustomerBiz.Name; break;
                case 0: Returned = strCustomerName; break;
                case 1: Returned = objCustomerBiz.Address; break;
                case 4: Returned = objCustomerBiz.CurrentReservationCol.UnitTowerName; break;
                case 5: Returned = objCustomerBiz.CurrentReservationCol.UnitName; break;
                case 15: Returned = objCustomerBiz.CurrentReservationCol.UnitProjectName; break;



            }
            return Returned;
        }
        public static string GetPropertyStr(int intIndex, CustomerBiz objCustomerBiz,UnitBiz objUntBiz)
        {
            string Returned = "";
            switch (intIndex)
            {
                case 0: Returned = objCustomerBiz.Name; break;
                case 1: Returned = objCustomerBiz.Address; break;
                case 4: Returned = objUntBiz.Tower.AlterName; break;
                case 5: Returned = objUntBiz.Name; break;
                case 15: Returned = objUntBiz.Project.AlterName; break;



            }
            return Returned;
        }
        #endregion
    }
}
