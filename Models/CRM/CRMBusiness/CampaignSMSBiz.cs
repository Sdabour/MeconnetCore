using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.UMS.UMSBusiness;
using SharpVision.CRM.CRMDataBase;
using System.Data;
using SharpVision.Base.BaseBusiness;
using SharpVision.SystemBase;
using System.Net;
using System.IO;
namespace SharpVision.CRM.CRMBusiness
{
    public class CampaignSMSBiz
    {
        #region Private Data
        CampaignSMSDb _CampaignSMSDb;
        CampaignCustomerBiz _CampaignCustomer;
        CampaignCustomerCol _CampaignCustomerCol;
        #endregion
        #region Constructors
        public CampaignSMSBiz()
        {
            _CampaignSMSDb = new CampaignSMSDb();
        }
        public CampaignSMSBiz(int intID)
        {
            _CampaignSMSDb = new CampaignSMSDb(intID);
        }
        public CampaignSMSBiz(DataRow objDR)
        {
            _CampaignSMSDb = new CampaignSMSDb(objDR);
        }
        #endregion
        #region Public Properties
        public int ID
        {
            set
            {
                _CampaignSMSDb.ID = value;
            }
            get
            {
                return _CampaignSMSDb.ID;
            }
        }
        public string PhoneNum
        {
            set
            {
                _CampaignSMSDb.PhoneNum = value;
            }
            get
            {
                return _CampaignSMSDb.PhoneNum;
            }
        }
        public string Msg
        {
            set
            {
                _CampaignSMSDb.Msg = value;
            }
            get
            {
                return _CampaignSMSDb.Msg;
            }
        }
        public CampaignCustomerBiz CampaignCustomer
        {
            set
            {
                _CampaignCustomer = value;
            }
            get
            {
                return _CampaignCustomer;
            }
        }
        public CampaignCustomerCol CampaignCustomerCol
        {
            set
            {
                _CampaignCustomerCol = value;
            }
            get
            {
                if (_CampaignCustomerCol == null)
                    _CampaignCustomerCol = new CampaignCustomerCol(true);
                return _CampaignCustomerCol;
            }
        }
        public string ProviderID
        {
            set
            {
                _CampaignSMSDb.ProviderID = value;
            }
            get
            {
                return _CampaignSMSDb.ProviderID;
            }
        }
        static string ServiceUrl
        {
            get
            {
                string Returned = SysData.MsgUrl;
                return Returned;
            }
        }
        public static string GetServiceSendingUrl(string strMsg, string strPhoneNo)
        {
            string Returned = ServiceUrl;
            Returned += "&to=" + strPhoneNo + "&msg=" + strMsg;
            return Returned;
        }
        #endregion
        #region Private Methods

        #endregion
        #region Public Methods
        public void Add()
        {
            _CampaignSMSDb.CustomerCampaign = CampaignCustomer.ID;
            _CampaignSMSDb.Add();
        }
        public void Edit()
        {
            _CampaignSMSDb.CustomerCampaign = CampaignCustomer.ID;
            _CampaignSMSDb.Edit();
        }
        public void Delete()
        {
            _CampaignSMSDb.Delete();
        }

        public bool Send(out string strError)
        {
            strError = "";
            HttpWebRequest objRequest;
            HttpWebResponse objResponse;
            Stream objStream;
            try
            {
             
                string strPhoneNum =  PhoneNum;
                if (PhoneNum.Length == 11)
                    strPhoneNum = "2" + PhoneNum;

                byte[] bytes = new byte[Msg.Length * sizeof(char)];
                bytes = System.Text.Encoding.Unicode.GetBytes(Msg);
               // System.Buffer.BlockCopy(Msg.ToCharArray(), 0, bytes, 0, bytes.Length);
                UnicodeEncoding uni = new UnicodeEncoding();
                string strMsg = uni.GetString(bytes);
                
                string strUrl = ServiceUrl;

              
                strUrl+= "&Recipients=" + strPhoneNum + "&MessageText=" + Msg;

             
             

                objRequest = (HttpWebRequest)WebRequest.Create(strUrl);
                objRequest.Timeout = 3*60*1000;
                objResponse = (HttpWebResponse)objRequest.GetResponse();

                 objStream = objResponse.GetResponseStream();
                StreamReader objReader = new StreamReader(objStream, Encoding.UTF8);

                string strReply = objReader.ReadToEnd();
                ProviderID = strReply;
                return true;
            }
            catch (Exception objEx)
            {
                strError = objEx.Message;
                return false;
            }
            //objRequest.RequestUri = strUrl;


        }

        /// <summary>
        /// /dot masr
        /// </summary>
        /// <returns></returns>
        public bool Send1(out string strException)
        {
            strException = "";
            try
            {


                string strPhoneNum = PhoneNum;
                strPhoneNum = strPhoneNum.Trim();
                strPhoneNum = strPhoneNum.Replace(" ", "");
                if (PhoneNum.Length == 11)
                    strPhoneNum = "2" + PhoneNum;

                byte[] bytes = new byte[Msg.Length * sizeof(char)];
                bytes = System.Text.Encoding.Unicode.GetBytes(Msg);
                // System.Buffer.BlockCopy(Msg.ToCharArray(), 0, bytes, 0, bytes.Length);
                UnicodeEncoding uni = new UnicodeEncoding();
                string strMsg = uni.GetString(bytes);

                string strUrl = ServiceUrl;

                //strUrl+= "&Recipients=" + strPhoneNum + "&MessageText=" + Msg;
                strUrl += "&Number=" + strPhoneNum + "&Binary=08 &Code=" + Msg;
                // strUrl = @"https://smsvas.vlserv.com/KannelSending/service.asmx/SendSMS?username=sdabour&password=UR8awLdrqf&SMSSender=ALWALYGROUP&SMSText="+ Msg +"&SMSLang=A&SMSReceiver=01117073174";

                HttpWebRequest objRequest = (HttpWebRequest)WebRequest.Create(strUrl);
                objRequest.Timeout = 3 * 60 * 1000;
                HttpWebResponse objResponse = (HttpWebResponse)objRequest.GetResponse();

                Stream objStream = objResponse.GetResponseStream();
                StreamReader objReader = new StreamReader(objStream, Encoding.UTF8);

                string strReply = objReader.ReadToEnd();
                ProviderID = strReply;
                return true;
            }
            catch (Exception objEx)
            {
                strException = objEx.Message;
                return false;
            }
            //objRequest.RequestUri = strUrl;


        }
       
        public static bool CheckMsgNo(ref string strNo)
        {
            
            if (strNo == null || strNo == "" || strNo.Length < 11)
            {
                strNo = "";
                return false;
            }
            string strPhoneNum =strNo;
            //if (strNo.Length == 11)
            //    strPhoneNum = "2" + strPhoneNum;
            strNo = strPhoneNum;

            
            return true;
        }
       
        #endregion
    }
}
