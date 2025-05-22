using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.SystemBase;
using System.Data;
using SharpVision.UMS.UMSDataBase;
namespace SharpVision.HR.HRDataBase
{
    public class ApplicantEstimationDb
    {
        #region Private Data

        protected int _ApplicantEstimationID;
        protected int _ApplicantID;
        protected int _EstimationStatementID;
        protected DateTime _EstimationDate;
        protected float _EstimationValue;
        protected int _EstimationEstimator;
        protected bool _StatusDelete;
        protected string _ApplicantName;
        protected string _ApplicantFamousName;
        protected string _ApplicantCode;

        string _ApplicantIDs;
        #endregion
        #region Constructors
        public ApplicantEstimationDb()
        {
        }
        public ApplicantEstimationDb(int intApplicantEstimationID, int intApplicantID, int intEstimationStatementID,int intEstimationEstimatorID)
        {
            _ApplicantEstimationID = intApplicantEstimationID;
            _ApplicantID = intApplicantID;
            _EstimationStatementID = intEstimationStatementID;
            _EstimationEstimator = intEstimationEstimatorID;
            DataTable dtTemp = Search();
            DataRow objDR = dtTemp.Rows[0];
            SetData(objDR);
        }       
        public ApplicantEstimationDb(DataRow objDR)
        {
            SetData(objDR);           
        }
        public ApplicantEstimationDb(DataRow objDR, bool blBelongStatus)
        {
            _ApplicantEstimationID = int.Parse(objDR["ApplicantEstimationID"].ToString());
            _ApplicantID = int.Parse(objDR["ApplicantID"].ToString());
            _EstimationStatementID = int.Parse(objDR["EstimationStatementID"].ToString());
            _EstimationDate = DateTime.Parse(objDR["EstimationDate"].ToString());
            _EstimationValue = float.Parse(objDR["EstimationValue"].ToString());
            _EstimationEstimator = int.Parse(objDR["EstimationEstimator"].ToString());
            _StatusDelete = bool.Parse(objDR["StatusDelete"].ToString());
        }
        #endregion
        #region Public Properties
        public int ApplicantEstimationID
        {
            set { _ApplicantEstimationID = value; }
            get { return _ApplicantEstimationID; }          
        }

        public int ApplicantID
        {
            set { _ApplicantID = value; }
            get { return _ApplicantID; }            
        }

        public int EstimationStatementID
        {
            set { _EstimationStatementID = value; }
            get { return _EstimationStatementID; }           
        }

        public DateTime EstimationDate
        {
            set { _EstimationDate = value; }
            get { return _EstimationDate; }            
        }

        public float EstimationValue
        {
            set { _EstimationValue = value; }
            get { return _EstimationValue; }           
        }

        public int EstimationEstimator
        {
            set { _EstimationEstimator = value; }
            get { return _EstimationEstimator; }            
        }

        public bool StatusDelete
        {
            set { _StatusDelete = value; }
            get { return _StatusDelete; }
        }

        public string ApplicantName
        {
            set
            {
                _ApplicantName = value;
            }
        }
        public string ApplicantFamousName
        {
            set
            {
                _ApplicantFamousName = value;
            }
        }
        public string ApplicantCode
        {
            set
            {
                _ApplicantCode = value;
            }
        }
        public string ApplicantIDs
        {
            set
            {
                _ApplicantIDs = value;
            }
        }
        public static string SearchStr
        {
            get
            {
                string ReturnStr = " SELECT     HRApplicantEstimation.ApplicantEstimationID,"+// HRApplicantEstimation.ApplicantID,"+
                                   " HRApplicantEstimation.EstimationStatementID, HRApplicantEstimation.EstimationDate, "+
                                   " HRApplicantEstimation.EstimationValue, HRApplicantEstimation.EstimationEstimator,ApplicantWorkerTable.* " +
                                   " FROM  HRApplicantEstimation inner join (" +EmployeeDb.SearchStr + ") ApplicantWorkerTable On ApplicantWorkerTable.ApplicantID = HRApplicantEstimation.ApplicantID";
                return ReturnStr;
            }
        }
        public  string AddStr
        {
            get
            {
                double dblEstimationDate = _EstimationDate.ToOADate() - 2;
                string ReturnStr = " INSERT INTO HRApplicantEstimation " +
                                " (ApplicantID, EstimationStatementID, EstimationDate, EstimationValue, EstimationEstimator)" +
                                " VALUES " +
                                " (" + _ApplicantID + "," + _EstimationStatementID + "," + dblEstimationDate + "," + _EstimationValue + "," + _EstimationEstimator + ")";

                return ReturnStr;
            }
        }
        public  string EditStr
        {
            get
            {
                double dblEstimationDate = _EstimationDate.ToOADate() - 2;
                string ReturnStr = " UPDATE    HRApplicantEstimation " +
                                " SET  ApplicantID =" + _ApplicantID + "" +
                                " , EstimationStatementID =" + _EstimationStatementID + "" +
                                " , EstimationDate =" + dblEstimationDate + "" +
                                " , EstimationValue =" + _EstimationValue + "" +
                                " , EstimationEstimator = " + _EstimationEstimator + "" +
                                " WHERE     (ApplicantEstimationID = " + _ApplicantEstimationID + ")";
                return ReturnStr;
            }
        }
        public  string DeleteStr
        {
            get
            {
                string ReturnStr = " DELETE FROM HRApplicantEstimation WHERE  1=1 ";
                if (_ApplicantEstimationID != 0)
                    ReturnStr = ReturnStr + " AND   (ApplicantEstimationID = " + _ApplicantEstimationID + ")";
                //if (_ApplicantID != 0)
                //    ReturnStr = ReturnStr + " AND (ApplicantID = " + _ApplicantID + ") ";
                //if (_EstimationStatementID != 0)
                //    ReturnStr = ReturnStr + " AND (EstimationStatementID = " + _EstimationStatementID + ")";

                return ReturnStr;
            }
        } 
        #endregion
        #region Private Methods
        void SetData(DataRow objDR)
        {
            _ApplicantEstimationID = int.Parse(objDR["ApplicantEstimationID"].ToString());
            _ApplicantID = int.Parse(objDR["ApplicantID"].ToString());
            _EstimationStatementID = int.Parse(objDR["EstimationStatementID"].ToString());
            _EstimationDate = DateTime.Parse(objDR["EstimationDate"].ToString());
            _EstimationValue = float.Parse(objDR["EstimationValue"].ToString());
            _EstimationEstimator = int.Parse(objDR["EstimationEstimator"].ToString());
            _StatusDelete = false;
        }
        #endregion
        #region Public Methods
        public void Add()
        {
            _ApplicantEstimationID = SystemBase.SysData.SharpVisionBaseDb.InsertIdentityTable(AddStr);
        }
        public void Edit()
        {
            SysData.SharpVisionBaseDb.ExecuteNonQuery(EditStr);
        }
        public void Delete()
        {
            SysData.SharpVisionBaseDb.ExecuteNonQuery(DeleteStr);
        }
        public DataTable Search()
        {
            string strSql = SearchStr + " Where 1=1 ";
            if (_ApplicantEstimationID != 0)
                strSql = strSql + " And ApplicantEstimationID = " + _ApplicantEstimationID + "";
            if (_ApplicantID != 0)
                strSql = strSql + " AND (ApplicantID = " + _ApplicantID + ") ";
            if (_EstimationStatementID != 0)
                strSql = strSql + " AND (EstimationStatementID = " + _EstimationStatementID + ")";
            if (_EstimationEstimator != 0)
                strSql = strSql + " AND (EstimationEstimator = " + _EstimationEstimator + ")";
            if (_ApplicantName != "" && _ApplicantName != null)
                strSql = strSql + " AND (ApplicantNameComp Like '%" + SysUtility.ReplaceStringComp(_ApplicantName) + "%')";
            if (_ApplicantFamousName != "" && _ApplicantFamousName != null)
                strSql = strSql + " AND (ApplicantFamousName Like '%" + _ApplicantFamousName + "%')";
            if (_ApplicantCode != "" && _ApplicantCode !=null)
                 strSql = strSql + " AND (ApplicantCode Like '%" + _ApplicantCode + "%')";


            


            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        public void AddMultiple()
        {
            if (_ApplicantIDs == null || _ApplicantIDs == "")
                return;
            double dblEstimationDate = _EstimationDate.ToOADate()-2;
            string strSql = " INSERT INTO HRApplicantEstimation " +
                " select HRApplicant.ApplicantID," + _EstimationStatementID + " as EstimationID," + dblEstimationDate + " as estimationDate,0 as Value,0 as Estimator " +
                " From HRApplicant where ApplicantID in (" + _ApplicantIDs + ") and ApplicantID not in (select ApplicantID from " +
                "HRApplicantEstimation where EstimationStatementID=" + _EstimationStatementID + ")";
                           //" (ApplicantID, EstimationStatementID, EstimationDate, EstimationValue, EstimationEstimator) " +
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public void DeleteMultiple()
        {
            if (_ApplicantIDs == null || _ApplicantIDs == "")
                return;
            string strSql = " Delete From HRApplicantEstimation " +                
                " where ApplicantID in (" + _ApplicantIDs + ") and EstimationStatementID=" + _EstimationStatementID + "";
            //" (ApplicantID, EstimationStatementID, EstimationDate, EstimationValue, EstimationEstimator) " +
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
#endregion
    }
}
