using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.SystemBase;
using System.Data;
using System.Data.SqlClient;
using SharpVision.HR.HRDataBase;
using SharpVision.RP.RPDataBase;
using SharpVision.UMS.UMSDataBase;
namespace SharpVision.CRM.CRMDataBase
{
    public class SalesManDb : EmployeeDb
    {
        #region Private Data
        protected int _BranchID;
        int _User;
        #region Private Data For Methods
        protected bool _IsSectorAdmin;
        //protected int _UserID;
        protected string _FirstNameLike;
        protected string _NameCompLike;
        protected string _FamousNameLike;
        protected string _CodeLike;
        #endregion
        #endregion
        #region Constractors
        public SalesManDb()
        {

        }
        public SalesManDb(DataRow objDR) : base(objDR)
        {
            int.TryParse(objDR["BranchID"].ToString(),out _BranchID);
           try
           {
               _User = int.Parse(objDR["ApplicantUser"].ToString());
           }
           catch { }
        }
        public SalesManDb(int intSaleMan)
            
        {
            _ID = intSaleMan;
            if (intSaleMan == 0)
                return;
            DataTable dtTemp = Search();
            if (dtTemp.Rows.Count == 0)
                return;
            DataRow drTemp = dtTemp.Rows[0];
            base.SetData(drTemp);
          //  SetData(drTemp);

            _BranchID = int.Parse(drTemp["BranchID"].ToString());
            try
            {
                _User = int.Parse(drTemp["ApplicantUser"].ToString());
            }
            catch { }
        }
        #endregion
        #region Public Accessorice
        public bool IsSectorAdmin
        {
            set
            {
                _IsSectorAdmin = value;
            }
            get
            {
                return _IsSectorAdmin;
            }
        }
        public int BranchID
        {
            set
            {
                _BranchID = value;
            }
            get
            {
                return _BranchID;
            }
        }
        string _BranchIDs;

        public string BranchIDs
        {
            get { return _BranchIDs; }
            set { _BranchIDs = value; }
        }
        #region Public Accessorice For Search
         public string FirstNameLike
        {
            set
            {
                _FirstNameLike = value;
            }
        }
        public string NameCompLike
        {
            set
            {
                _NameCompLike = value;
            }
        }
        public string FamousNameLike
        {
            set
            {
                _FamousNameLike = value;
            }
        }
        #endregion

      

        public static string SearchStr
        {
            //CRMSalesMan.BranchID,
            get
            {
                string Returned = " SELECT   HRApplicantWorkerTable.*,HRBranchTable.* " +
                                  " FROM         CRMSalesMan right outer JOIN" +
                                  " (" + EmployeeDb.SearchStr + ")as HRApplicantWorkerTable ON CRMSalesMan.ApplicantID = HRApplicantWorkerTable.ApplicantID " +
                                  " left outer JOIN (" + HR.HRDataBase.BranchDb.SearchStr + ") as HRBranchTable ON CRMSalesMan.BranchID = HRBranchTable.BranchID";
                                 // " INNER JOIN (" + ApplicantWorkerDb.SearchStr + ")as HRApplicantTable ON HRApplicantWorkerTable.ApplicantID = HRApplicantTable.ApplicantID";

                return Returned;
            }
        }

        #endregion
        #region Private Methods
        
        #endregion
        #region Public Methods
       

        public override void Add()
        {
            int intSectorAdmin = _IsSectorAdmin == true ? 1 : 0;
            string strSql = " INSERT INTO CRMSalesMan " +
                            " (ApplicantID, BranchID,UserID,IsSectorAdmin)" +
                            " VALUES     (" + _ID + "," + _BranchID + "," + _User + "," + intSectorAdmin + ") ";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public override void Edit()
        {
            int intSectorAdmin = _IsSectorAdmin == true ? 1 : 0;
            string strInsert = " INSERT INTO CRMSalesMan " +
                            " (ApplicantID, BranchID,UserID,IsSectorAdmin) "+
                            " SELECT  ApplicantID, "+ _BranchID +" AS BranchID, "+ _User +" AS UserID, "+
                             intSectorAdmin +" AS IsSectorAdmin "+ 
                            " FROM         dbo.HRApplicant "+
                            " WHERE     (ApplicantID = "+ _ID +") and not exists (SELECT  ApplicantID "+
                            " FROM         dbo.CRMSalesMan "+
                            " WHERE     (ApplicantID = "+ _ID +")) ";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strInsert);
            string strSql = " UPDATE    CRMSalesMan " +
                            " SET  ApplicantID = " + _ID + "" +
                            " , BranchID = " + _BranchID + "" +
                            " , UserID = " + _User + "" +
                            " ,IsSectorAdmin = " + intSectorAdmin + "" +
                            " Where AppicantID = " + _ID + "";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public override void Delete()
        {
            string strSql = " DELETE FROM CRMSalesMan where  ApplicantID = " + _ID + "";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public DataTable Search()
        {
            string strSql = SearchStr + " Where ApplicantStatusID =1  ";
            if (_ID != 0)
                strSql += " and  HRApplicantWorkerTable.ApplicantID = " + _ID + "";
            if (_User != 0)
                strSql += " and ApplicantUser = " + _User + "";
            if (_BranchID != 0)
                strSql += " and  CRMSalesMan.BranchID = " + _BranchID + "";
            if (_BranchIDs != null && _BranchIDs!= "" && _BranchIDs!="0")
                strSql += " and  CRMSalesMan.BranchID in (" + _BranchIDs + ") ";
            // if (_FirstNameLike != null && _FirstNameLike != "")
            //    strSql = strSql + " And ApplicantFirstName Like '%" + _FirstNameLike + "%'";

            //if (_NameCompLike != null && _NameCompLike != "")
            //    strSql = strSql + " And ApplicantNameComp Like '%" + _NameCompLike + "%'";

            //if (_FamousNameLike != null && _FamousNameLike != "")
            //    strSql = strSql + " And ApplicantFamousName Like '%" + _FamousNameLike + "%'";

            //if (_CodeLike != null && _CodeLike != "")
            //    strSql = strSql + " And ApplicantCode Like '%" + _CodeLike + "%'";
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }

        #endregion
    }
}
