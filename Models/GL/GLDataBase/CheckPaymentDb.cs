using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.SystemBase;


namespace SharpVision.GL.GLDataBase
{
    public class CheckPaymentDb
    {
        #region Private Data
        protected int _CheckID;
        protected int _PaymentID;
        int _Status;
        DateTime _StatusDate;
        bool _IsCollected;
        DateTime _CollectingDate;
        int _EmployeeID;
        string _EmployeeName;
        string _EmployeeCode;
        int _BranchID;
        string _BranchName;
        int _CofferID;
        string _CofferName;
        string _CofferCode;
        #endregion

        #region Constractors
        public CheckPaymentDb()
        {

        }
        public CheckPaymentDb(DataRow objDR)
        {
            SetData(objDR);
        }
        #endregion

        #region Public Accessorice
        public int CheckID
        {
            set
            {
                _CheckID = value;
            }
            get
            {
                return _CheckID;
            }
        }
        public int PaymentID
        {
            set
            {
                _PaymentID = value;
            }
            get
            {
                return _PaymentID;
            }
        }
        public int Status
        {
            set
            {
                _Status = value;
            }
            get
            {
                return _Status;
            }
        }
        public DateTime StatusDate
        {
            set
            {
                _StatusDate = value;
            }
            get
            {
                return _StatusDate;
            }
        }
        public bool IsCollected
        {
            set
            {
                _IsCollected = value;
            }
        }
        public DateTime CollectingDate
        {
            set
            {
                _CollectingDate = value;
            }
        }
        public int EmployeeID
        {
            set
            {
                _EmployeeID = value;
            }
            get
            {
                return _EmployeeID;
            }
        }
        public string EmployeeName
        {
            get
            {
                return _EmployeeName;
            }
        }
        public string EmployeeCode
        {
            get
            {
                return _EmployeeCode;
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

        public string BranchName
        {
            get
            {
                return _BranchName;
            }
        }
        public int CofferID
        {
           set
           {
               _CofferID = value;
           }
           get
            {
                return _CofferID;
           }
        }
        public string CofferName
        {
            get
            {
                return _CofferName;
            }
        }
        public string CofferCode
        {
            get
            {
                return _CofferCode;
            }
        }
        public string AddStr
        {
            get
            {
                double dblStatusDate = _StatusDate.ToOADate() - 2;
                int intStatusDate = (int)dblStatusDate;
                int intIsCollected = _IsCollected ? 1 : 0;
                double dblCollectingDate = SysUtility.Approximate(_CollectingDate.ToOADate() - 2, 1, ApproximateType.Down);
                string strCollectingDate = _IsCollected ? dblCollectingDate.ToString() : "null";
                intStatusDate = intStatusDate > dblStatusDate ? intStatusDate - 1 : intStatusDate;
                string strCollectingUser = _IsCollected ? SysData.CurrentUser.ID.ToString() : "null";
                _EmployeeID = _IsCollected ? _EmployeeID : 0;
                _BranchID = _IsCollected ? _BranchID : 0;
                string strCollectingRealDate = _IsCollected? "GetDate()": "NULL" ;
                string strPaymentID = _PaymentID == 0 ? "@PaymentID" : _PaymentID.ToString();
                string strStatus = intStatusDate < 0 ? "null" : intStatusDate.ToString();
                string Returned = " INSERT INTO GLCheckPayment " +
                                " (CheckID, PaymentID,PaymentIsCollected,PaymentCollectingDate,PaymentCollectingUsr" +
                                ",PaymentCollectingEmployee,PaymentCollectingBranch,PaymentCollectingRealDate"+
                                ", UsrIns, TimIns)" +
                                " VALUES     (" + _CheckID + "," + strPaymentID + "," + intIsCollected + "," +
                                strCollectingDate + "," + strCollectingUser + "," + _EmployeeID.ToString() + 
                                "," + _BranchID.ToString() + 
                                "," + strCollectingRealDate +","+
                                SysData.CurrentUser.ID + ",GetDate())";
                return Returned;
            }
        }
        public static string SearchStr
        {
            get
            {
                string strCollectingApplicant = "SELECT dbo.HRApplicant.ApplicantID AS CollectingApplicantID, dbo.HRApplicant.ApplicantFirstName AS CollectingApplicantName, "+
                      "dbo.HRApplicantWorker.ApplicantCode AS CollectingApplicantCode "+
                      " FROM         dbo.HRApplicantWorker INNER JOIN "+
                      " dbo.HRApplicant ON dbo.HRApplicantWorker.ApplicantID = dbo.HRApplicant.ApplicantID ";
                string strCollectingBranch = "SELECT   BranchID AS CollectingBranchID, BranchNameA AS CollectingBranchName "+
                        " FROM    dbo.HRBranch ";
                string strCollectingCoffer = "SELECT  CofferID AS CollectingCofferID, CofferCode AS CollectingCofferCode, CofferNameA AS CollectingCofferName " +
                   " FROM         dbo.GLCoffer ";
                string Returned = "SELECT GLCheckPayment.CheckID as PaymentCheck, PaymentID Payment,"+
                    "PaymentIsCollected,PaymentCollectingDate,CheckTable.*,CollectingApplicantTable.*,CollectingBranchTable.*  " +
                    ",CollectingCofferTable.* "+
                    " FROM GLCheckPayment inner join ("+ new CheckDb().SearchStr +") as CheckTable on "+
                    " GLCheckPayment.CheckID = CheckTable.CheckID  "+
                    " left outer join ("+ strCollectingApplicant +") as CollectingApplicantTable "+
                    " on   dbo.GLCheckPayment.PaymentCollectingEmployee = CollectingApplicantTable.CollectingApplicantID   "+
                    " left outer join (" + strCollectingBranch + ") as CollectingBranchTable "+
                    " on  dbo.GLCheckPayment.PaymentCollectingBranch = CollectingBranchTable.CollectingBranchID  "+
                         " left outer join (" + strCollectingCoffer + ") as CollectingCofferTable "+
                    " on  dbo.GLCheckPayment.PaymentCollectingCoffer = CollectingCofferTable.CollectingCofferID  ";
                return Returned;
            }
        }
        #endregion

        #region Private Methods
        void SetData(DataRow objDR)
        {
            _CheckID = int.Parse(objDR["CheckID"].ToString());
            _PaymentID = int.Parse(objDR["PaymentID"].ToString());
            _Status = int.Parse(objDR["PaymentCurrentStatus"].ToString());
            _StatusDate = DateTime.Parse(objDR["PaymentCurrentStatusDate"].ToString());
            if (objDR["CollectingApplicantID"].ToString() != "")
                _EmployeeID = int.Parse(objDR["CollectingApplicantID"].ToString());
            _EmployeeName = objDR["CollectingApplicantName"].ToString();
            _EmployeeCode = objDR["CollectingApplicantCode"].ToString();
            if(objDR["CollectingBranchID"].ToString()!= "")
                _BranchID = int.Parse(objDR["CollectingBranchID"].ToString());
            _BranchName = objDR["CollectingBranchName"].ToString();
            if (objDR["CollectingCofferID"].ToString() != "")
                _CofferID = int.Parse(objDR["CollectingCofferID"].ToString());
            _CofferCode = objDR["CollectingCofferCode"].ToString();
            _CofferName = objDR["CollectingCofferName"].ToString();

        }
        #endregion

        #region Public Methods
        public void Add()
        {
            //double dblStatusDate = _StatusDate.ToOADate()-2;
            //int intStatusDate = (int)dblStatusDate;
            //int intIsCollected = _IsCollected ? 1 : 0;
            //double dblCollectingDate = SysUtility.Approximate(_CollectingDate.ToOADate()-2,1,ApproximateType.Down);
            //string strCollectingDate = _IsCollected ? dblCollectingDate.ToString() : "null";
            //intStatusDate = intStatusDate > dblStatusDate ? intStatusDate - 1 : intStatusDate;
            //string strCollectingUser = _IsCollected ? SysData.CurrentUser.ID.ToString() :"null";
            //_EmployeeID = _IsCollected ? _EmployeeID : 0;
            //_BranchID = _IsCollected ? _BranchID : 0;
            //string strStatus = intStatusDate < 0 ? "null" : intStatusDate.ToString();
            //string strSql = " INSERT INTO GLCheckPayment " +
            //                " (CheckID, PaymentID,PaymentIsCollected,PaymentCollectingDate,PaymentCollectingUsr"+
            //                ",PaymentCollectingEmployee,PaymentCollectingBranch, UsrIns, TimIns)" +
            //                " VALUES     (" + _CheckID + "," + _PaymentID + ","+ intIsCollected +","  + 
            //                strCollectingDate + ","+ strCollectingUser +"," + _EmployeeID.ToString() +"," +_BranchID.ToString() + ","+
            //                SysData.CurrentUser.ID + ",GetDate())";
            
            SysData.SharpVisionBaseDb.ExecuteNonQuery(AddStr);
        }

        
        public void Delete()
        {
            string strSql = "delete from GLCheckPayment where PaymentID=" +_PaymentID;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
            
        }
        public DataTable Search()
        {
            string strSql = SearchStr + "Where 1 = 1";
            if (_CheckID != 0)
                strSql = strSql + " and  CheckID = " + _CheckID + "";
            if (_PaymentID != 0)
                strSql = strSql + " and  ";

            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        #endregion

    }
}
