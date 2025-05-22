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
    public class ApplicantDegreeDb 
    {
        #region PrivateData
        protected int _ApplicantID;
        protected int _DegreeID;
        protected string _Description;
        protected DateTime _FromDate;
        protected DateTime _ToDate;
        private bool _StatusFromDate;

        
        protected bool _StatusToDate;
        protected string _ApplicantIDs;

        #endregion

        #region Constractors

        public ApplicantDegreeDb()
        {
        }

        public ApplicantDegreeDb(int intApplicantID,int intDegreeID)
        {
            _ApplicantID = intApplicantID;
            _DegreeID = intDegreeID;
            DataTable dtTemp = Search();
            DataRow objDR = Search().Rows[0];  
            _ApplicantID = int.Parse(objDR["ApplicantID"].ToString());
            _DegreeID = int.Parse(objDR["DegreeID"].ToString());
            _Description = objDR["Description"].ToString();
            if ((objDR["FromDate"].ToString() == "") || (objDR["FromDate"].ToString() == null))
            {
                _StatusFromDate = false;
            }
            else
            {
                _StatusFromDate = true;
                _FromDate = DateTime.Parse(objDR["FromDate"].ToString());
            }

            if ((objDR["ToDate"].ToString() == "") || (objDR["ToDate"].ToString() == null))
            {
                _StatusToDate = false;
            }
            else
            {
                _StatusToDate = true;
                _ToDate = DateTime.Parse(objDR["ToDate"].ToString());
            }                                 
        }

        public ApplicantDegreeDb(DataRow objDR)
        {
            _DegreeID = int.Parse(objDR["DegreeID"].ToString());
            _ApplicantID = int.Parse(objDR["ApplicantID"].ToString());
            _Description = objDR["Description"].ToString();
            if ((objDR["FromDate"].ToString() == "") || (objDR["FromDate"].ToString() == null))
            {
                _StatusFromDate = false;
            }
            else
            {
                _StatusFromDate = true;
                _FromDate = DateTime.Parse(objDR["FromDate"].ToString());
            }

            if ((objDR["ToDate"].ToString() == "") || (objDR["ToDate"].ToString() == null))
            {
                _StatusToDate = false;
            }
            else
            {
                _StatusToDate = true;
                _ToDate = DateTime.Parse(objDR["ToDate"].ToString());
            }     

        }

        public ApplicantDegreeDb(DataRow objDR, bool DrBelongStatus)
        {
            _DegreeID = int.Parse(objDR["DegreeID"].ToString());
            _ApplicantID = int.Parse(objDR["ApplicantID"].ToString());
            _Description = objDR["Description"].ToString();
            if (bool.Parse(objDR["StatusFromDate"].ToString()) == false)
            {
                _StatusFromDate = false;
            }
            else
            {
                _StatusFromDate = true;
                _FromDate = DateTime.Parse(objDR["FromDate"].ToString());
            }

            if (bool.Parse(objDR["StatusToDate"].ToString()) == false)
            {
                _StatusToDate = false;
            }
            else
            {
                _StatusToDate = true;
                _ToDate = DateTime.Parse(objDR["ToDate"].ToString());
            }

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
        public int DegreeID
        {
            set
            {
                _DegreeID = value;
            }
            get
            {
                return _DegreeID;
            }

        }
        public string Description
        {
            set
            {
                _Description = value;
            }
            get
            {
                return _Description;
            }
        }
        public DateTime FromDate
        {
            set { _FromDate = value; }
            get { return _FromDate; }
        }
        public DateTime ToDate
        {
            set { _ToDate = value; }
            get { return _ToDate; }
        }
        public bool StatusFromDate
        {
            set
            {
                _StatusFromDate = value;
            }
            get
            {
                return _StatusFromDate;
            }
        }
        public bool StatusToDate
        {
            set
            {
                _StatusToDate = value;
            }
            get
            {
                return _StatusToDate;
            }
        }
        public static string SearchStr
        {
            get
            {
                //string Returned = " SELECT     HRApplicantDegree.ApplicantID , HRApplicantDegree.DegreeID , HRApplicantDegree.Description , " +
                //                  " HRApplicantDegree.FromDate , HRApplicantDegree.ToDate , COMMONDegree.DegreeID, COMMONDegree.DegreeNameA, " +
                //                  " COMMONDegree.DegreeNameE " +
                //                  " FROM  HRApplicantDegree INNER JOIN " +
                //                  " COMMONDegree ON HRApplicantDegree.DegreeID = COMMONDegree.DegreeID ";

                string Returned = " SELECT     HRApplicantDegree.ApplicantID , HRApplicantDegree.DegreeID , HRApplicantDegree.Description , " +
                                  " HRApplicantDegree.FromDate , HRApplicantDegree.ToDate " +
                                  "  " +
                                  " FROM  HRApplicantDegree " +
                                  "  ";

                return Returned;
            }
        }
        public string AddStr
        {
            get
            {
               
                
                string strFromDate = "";
                string strToDate="";
                if (StatusFromDate == true)
                {
                    double FromDate = _FromDate.ToOADate() - 2;
                    strFromDate = FromDate.ToString();
                }
                else
                {
                    strFromDate = "Null";
                }

                if (StatusToDate == true)
                {
                    double ToDate = _ToDate.ToOADate() - 2;
                    strToDate = ToDate.ToString();
                }
                else
                {
                    strToDate = "Null";
                }

                string strReturn=" INSERT INTO HRApplicantDegree " +
                            " (ApplicantID, DegreeID, Description, FromDate, ToDate, UsrIns, TimIns) " +
                            " VALUES     (" + _ApplicantID + "," + _DegreeID + ",'" + _Description + "'," + strFromDate + "," + strToDate + "," + SysData.CurrentUser.ID + ",GetDate())";
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
            if (_DegreeID != 0)
                strSql = strSql + " and HRApplicantDegree.DegreeID = " + _DegreeID;
            if (_ApplicantID != 0)
                strSql = strSql + " and HRApplicantDegree.ApplicantID = " + _ApplicantID;
            if (_ApplicantIDs != null && _ApplicantIDs != "")
            {
                strSql = strSql + " and HRApplicantDegree.ApplicantID in (" + _ApplicantIDs + ") ";
            }
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        public  void Delete()
        {
            string strSql = "delete from HRApplicantDegree where ApplicantID = " + _ApplicantID;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);          
        }
        #endregion


    }
}
