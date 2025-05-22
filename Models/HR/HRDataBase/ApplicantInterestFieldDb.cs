using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.UMS.UMSDataBase;
using SharpVision.SystemBase;
using System.Data;
using System.Data.SqlClient;
using SharpVision.Base.BaseDataBase;
using SharpVision.COMMON.COMMONDataBase;


namespace SharpVision.HR.HRDataBase
{
    public class ApplicantInterestFieldDb 
    {
        #region PrivateData
        protected int _ApplicantID;
        protected int _FieldID;        
        protected string _ApplicantIDs;
        #endregion
        #region Constractors
        public ApplicantInterestFieldDb()
        {
        }

        public ApplicantInterestFieldDb(int intApplicantID,int intFieldID)
        {
            _ApplicantID = intApplicantID;
            _FieldID = intFieldID;
            DataTable dtTemp = Search();
            DataRow objDR = Search().Rows[0];  
            _ApplicantID = int.Parse(objDR["ApplicantID"].ToString());
            _FieldID = int.Parse(objDR["FieldID"].ToString());                                                   
        }

        public ApplicantInterestFieldDb(DataRow objDR)
        {
            _FieldID = int.Parse(objDR["FieldID"].ToString());
            _ApplicantID = int.Parse(objDR["ApplicantID"].ToString());                       
        }
        #endregion
        #region PublicAccessories
        public int ApplicantID
        {
            set
            {
                _ApplicantID = value;
            }
            get
            {
                return _ApplicantID;
            }

        }
        public int FieldID
        {
            set
            {
                _FieldID = value;
            }
            get
            {
                return _FieldID;
            }

        }
        public static string SearchStr
        {
            get
            {
                string Returned = " SELECT     HRApplicantField.ApplicantID, FieldTypeTable.*" +
                                  " " +
                                  " FROM  HRApplicantField Left Outer Join ("+ FieldTypeDb.SearchStr +") as FieldTypeTable On "+
                                  " HRApplicantField.FieldID = FieldTypeTable.FieldID ";                
                return Returned;
            }
        }
        public string AddStr
        {
            get
            {                                 
                string strReturn=" INSERT INTO HRApplicantField " +
                            " (ApplicantID, FieldID,UsrIns, TimIns) " +
                            " VALUES     (" + _ApplicantID + "," + _FieldID + "," + SysData.CurrentUser.ID + ",GetDate())";
                return strReturn;
            }

        }
        public string ApplicantIDs
        {
            set
            {
                _ApplicantIDs = value;
            }
        }
        #endregion
        #region Private Methods
     
        #endregion
        #region Public Methods
        public  void Add()
        {                      
            SysData.SharpVisionBaseDb.ExecuteNonQuery(AddStr);
        }
        public  void Edit()
        {           
        }
        public  DataTable Search()
        {
            string strSql = SearchStr + " WHERE    (1=1)";
            if (_FieldID != 0)
                strSql = strSql + " and HRApplicantField.FieldID = " + _FieldID;
            if (_ApplicantID != 0)
                strSql = strSql + " and HRApplicantField.ApplicantID = " + _ApplicantID;
            if (_ApplicantIDs != null && _ApplicantIDs != "")
            {
                strSql = strSql + " and HRApplicantField.ApplicantID in (" + _ApplicantIDs + ") ";
            }
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql, "HRApplicantField");
        }
        public  void Delete()
        {
            string strSql = "delete from HRApplicantField where ApplicantID = " + _ApplicantID;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);          
        }
        #endregion


    }
}
