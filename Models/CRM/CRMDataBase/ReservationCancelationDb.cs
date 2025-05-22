using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.SystemBase;
using System.Data;
using System.Data.SqlClient;
using SharpVision.Base.BaseDataBase;

namespace SharpVision.CRM.CRMDataBase
{
    public class ReservationCancelationDb
    {
        #region Private Data
        protected int _ReservationID;
        protected DateTime _Date;
        protected string _Note;
        protected double _Cost;
        protected bool _PayBackComplete;
        protected double _TotalPayBackValue;
        protected bool _ReasignSucceded = false;
        bool _IsDelegated;
        DateTime _DelegationDate;
        int _Type;

        public int Type
        {
            get { return _Type; }
            set { _Type = value; }
        }
        DateTime _PayBackCompleteDate;

        public DateTime PayBackCompleteDate
        {
            get { return _PayBackCompleteDate; }
            set { _PayBackCompleteDate = value; }
        }
        int _PayBackCompleteUsr;

        public int PayBackCompleteUsr
        {
            get { return _PayBackCompleteUsr; }
            set { _PayBackCompleteUsr = value; }
        }

        #endregion
        #region Constractors
        public ReservationCancelationDb()
        {

        }
        public ReservationCancelationDb(int intID)
        {
            _ReservationID = intID;
            DataTable dtTemp = Search();
            if (dtTemp.Rows.Count > 0)
            {
                DataRow objDR = dtTemp.Rows[0];
                SetData(objDR);
            }
        }
        public ReservationCancelationDb(DataRow objDR)
        {
          SetData(objDR);
        }
        #endregion
        #region Public Accessorice
        public int ReservationID
        {
            set
            {
                _ReservationID = value;
            }
            get
            {
                return _ReservationID;
            }
        }
        public DateTime Date
        {
            set
            {
                _Date = value;
            }
            get
            {
                return _Date;
            }
        }
        public string Note
        {
            set
            {
                _Note = value;
            }
            get
            {
                return _Note;
            }
        }
        public double Cost
        {
            set
            {
                _Cost= value;
            }
            get
            {
                return _Cost;
            }
        }
        public bool PayBackComplete
        {
            set
            {
                _PayBackComplete = value;
            }
            get
            {
                return _PayBackComplete;
            }
        }
        public double TotalPaybackValue
        {
            set
            {
                _TotalPayBackValue = value;
            }
            get
            {
                return _TotalPayBackValue;
            }
        }
        public bool ReasignedSucceded
        {
            get
            {
                return _ReasignSucceded;
            }
        }
        public bool IsDelegated
        {
            set
            {
                _IsDelegated = value;
            }
            get
            {
                return _IsDelegated;
            }
        }
        public DateTime DelegationDate
        {
            set
            {
                _DelegationDate = value;
            }
            get
            {
                return _DelegationDate;
            }
        }
        bool _Canceled;

        public bool Canceled
        {
            get { return _Canceled; }
            set { _Canceled = value; }
        }

        public string NonCollectedCheckPaymentStr
        {
            get
            {
                        string Returned = "SELECT  dbo.CRMReservationInstallment.InstallmentID,GLPayment.PaymentID " +
                            " FROM    dbo.CRMReservationInstallment INNER JOIN " +
                            " dbo.CRMInstallmentPayment ON dbo.CRMReservationInstallment.InstallmentID = dbo.CRMInstallmentPayment.InstallmentID INNER JOIN " +
                            " dbo.GLPayment ON dbo.CRMInstallmentPayment.PaymentID = dbo.GLPayment.PaymentID INNER JOIN " +
                            " dbo.GLCheckPayment ON dbo.GLPayment.PaymentID = dbo.GLCheckPayment.PaymentID INNER JOIN " +
                            " dbo.GLCheck ON dbo.GLCheckPayment.CheckID = dbo.GLCheck.CheckID " +
                            " WHERE     (dbo.GLCheckPayment.PaymentIsCollected = 0) AND (dbo.GLCheck.CheckCurrentStatus <> 2 AND dbo.GLCheck.CheckCurrentStatus <> 4) AND  " +
                            " (dbo.CRMReservationInstallment.ReservationID = " + _ReservationID + ")";
                return Returned;
            }
        }
        public static string SearchStr
        {
            get
            {
                string returned;
                string strPayBack = "SELECT  ReservationID , SUM(PaymentValue) AS PayBackValue "+
                       " FROM         dbo.CRMReservationPayBack "+
                       " GROUP BY ReservationID ";
                returned = "SELECT  CRMReservationCancelation.ReservationID as CanceledReservation, CancelationDate, CancelationNote, CancelationCost,PayBackComplete" +
                    ",PayBackCompleteDate,PayBackCompleteUsr " +
                    ",UsrIns as CancelationUsr,case when PayBacktable.PayBackValue is null  then 0 else PayBackTable.PayBackValue end as TotalPayBackValue " +
                    ",CancelationTypeTable.* " +             
                    "  FROM CRMReservationCancelation left outer join ("+
                                  strPayBack + ") as PayBackTable on CRMReservationCancelation.ReservationID = PayBackTable.ReservationID "+
                                  " left outer join ("+ CancelationTypeDb.SearchStr +") as CancelationTypeTable "+
                                  " on  CRMReservationCancelation.CancelationType = CancelationTypeTable.CancelationTypeID ";
                return returned;
            }
        }
        #endregion
        #region Private Methods
        void SetData(DataRow objDR)
        {
            if (objDR["CanceledReservation"].ToString() != "")
            {
                _ReservationID = int.Parse(objDR["CanceledReservation"].ToString());
                _Date = DateTime.Parse(objDR["CancelationDate"].ToString());
                _Note = objDR["CancelationNote"].ToString();
                _Cost = double.Parse(objDR["CancelationCost"].ToString());
                _PayBackComplete = bool.Parse(objDR["PayBackComplete"].ToString());
                _TotalPayBackValue = double.Parse(objDR["TotalPayBackValue"].ToString());
                if(objDR["CancelationTypeID"].ToString()!= "")
                _Type = int.Parse(objDR["CancelationTypeID"].ToString());
                if (objDR["PayBackCompleteDate"].ToString() != "")
                    _PayBackCompleteDate = DateTime.Parse(objDR["PayBackCompleteDate"].ToString());
                if (objDR["PayBackCompleteUsr"].ToString() != "")
                    _PayBackCompleteUsr = int.Parse(objDR["PayBackCompleteUsr"].ToString());

            }
        }
        #endregion
        #region Public Methods
        public void Add()
        {
            double dblDate = _Date.ToOADate() - 2;
            int intPayBack = _PayBackComplete ? 1 : 0;
            string strPayBackCompletDate = _PayBackComplete ? (_PayBackCompleteDate.ToOADate() - 2).ToString() : "null";
            int intPayBackCompletUser = _PayBackComplete ? SysData.CurrentUser.ID : 0;
            string strDelegation = _IsDelegated ?
                SysUtility.Approximate(_DelegationDate.ToOADate() - 2, 1, ApproximateType.Down).ToString() : "NULL";
            string strInner = NonCollectedCheckPaymentStr;

            string strSql = " begin transaction Trans1; "+
                " declare @CheckCount int ; "+
                " set @CheckCount = (select count(InstallmentID) as InstallmentCount from ("+ strInner +
                ") as NonPaidTable ) " +
                " if @CheckCount > 0  goto rolLine;";
            strSql+= " INSERT INTO CRMReservationCancelation" +
                             " (ReservationID, CancelationDate, CancelationNote," +
                             " CancelationCost,PayBackComplete,PayBackCompleteDate,PayBackCompleteUsr,CancelationType,UsrIns,TimIns)" +
                             " VALUES     (" + _ReservationID + "," + dblDate + ",'" + _Note + "'," + _Cost + "," +
                             intPayBack + "," + strPayBackCompletDate + "," + intPayBackCompletUser + "," + _Type + "," + SysData.CurrentUser.ID + ",GetDate()) ";
            strSql += " update CRMUnit  set    CurrentReservation = 0 " +
                     " WHERE  (CurrentReservation = " + _ReservationID + ")";
            strSql += "  update CRMReservation  set  ReservationStatus = 6 " +
                  " WHERE     (ReservationID = " + _ReservationID + ")";

            strSql += "update CRMReservationInstallment set InstallmentStatus=2 " +
             "  where InstallmentStatus<>1 and ReservationID =" + _ReservationID;
            if (_IsDelegated)
                strSql += " update CRMReservation " +
                   " set ReservationDelegationDate =  " + strDelegation +
                   " WHERE     (ReservationID = " + _ReservationID + ")";

            strSql += " commitline: commit transaction Trans1;select 1 as exp1 ; return ; ";
            strSql += " rolLine: RollBack TRAN Trans1 ;select  -1 as exp1 ;";
           int intOk = (int) SysData.SharpVisionBaseDb.ReturnScalar(strSql);

           _Canceled = intOk == 1;

           if (_Canceled)
           {
               ReservationDb objReservationDb = new ReservationDb();
               objReservationDb.ID = ReservationID;
               objReservationDb.InsertHistory();
           }
        }
        public void DeleteNonCollectedCheckPayment()
        {
            string strInner = NonCollectedCheckPaymentStr;
             string strSql = "delete from CRMInstallmentPayment where InstallmentID in (select InstallmentID from (" + strInner + ") as NativeInstallment) and PaymentID in (select PaymentID from (" + strInner + ") as NativePayment)";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public void Add1()
        {
            double dblDate = _Date.ToOADate()-2;
            int intPayBack = _PayBackComplete ? 1 : 0;
            string strPayBackCompletDate = _PayBackComplete ? (_PayBackCompleteDate.ToOADate() - 2).ToString() : "null";
            int intPayBackCompletUser = _PayBackComplete ? SysData.CurrentUser.ID : 0;
            string strDelegation = _IsDelegated ?
                SysUtility.Approximate(_DelegationDate.ToOADate() - 2, 1, ApproximateType.Down).ToString() : "NULL";
            

            string strSql = " INSERT INTO CRMReservationCancelation"+
                            " (ReservationID, CancelationDate, CancelationNote,"+
                            " CancelationCost,PayBackComplete,PayBackCompleteDate,PayBackCompleteUsr,CancelationType,UsrIns,TimIns)" +
                            " VALUES     ("+_ReservationID+","+dblDate+",'"+_Note+"',"+_Cost+"," +
                            intPayBack + ","+ strPayBackCompletDate + "," + intPayBackCompletUser + "," + _Type +"," + SysData.CurrentUser.ID  + ",GetDate()) ";
            strSql += " update CRMUnit  set    CurrentReservation = 0 "+
                     " WHERE  (CurrentReservation = "+ _ReservationID +")";
            strSql += "  update CRMReservation  set  ReservationStatus = 6 "+
                  " WHERE     (ReservationID = " + _ReservationID + ")";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
            #region PaymentRegion
            if(_PayBackComplete)
            {
            //string strInstallmentPaidValue = "SELECT  dbo.CRMReservationInstallment.ReservationID, SUM(dbo.GLPayment.PaymentValue) AS TotalInstallmentPaidValue" +
            //         " FROM         dbo.GLCheck INNER JOIN " +
            //         " dbo.GLCheckPayment ON dbo.GLCheck.CheckID = dbo.GLCheckPayment.CheckID RIGHT OUTER JOIN " +
            //         " dbo.CRMReservationInstallment INNER JOIN " +
            //         " dbo.CRMInstallmentPayment ON dbo.CRMReservationInstallment.InstallmentID = dbo.CRMInstallmentPayment.InstallmentID INNER JOIN " +
            //         " dbo.GLPayment ON dbo.CRMInstallmentPayment.PaymentID = dbo.GLPayment.PaymentID ON " +
            //         " dbo.GLCheckPayment.PaymentID = dbo.GLPayment.PaymentID " +
            //         " WHERE     ((dbo.GLCheck.CheckCurrentStatus IN (2, 4)) OR " +
            //         " (dbo.GLCheckPayment.PaymentIsCollected = 1) OR " +
            //         " (dbo.GLCheckPayment.CheckID IS NULL)) and dbo.CRMReservationInstallment.ReservationID= " + _ReservationID +
            //         " GROUP BY dbo.CRMReservationInstallment.ReservationID";
            //strInstallmentPaidValue = "select CRMReservation.ReservationID,case when InstallmentPaymentTable.TotalInstallmentPaidValue is null then 0 else InstallmentPaymentTable.TotalInstallmentPaidValue end as TotalInstallmentPaidValue " +
            //    " from CRMReservation left outer join (" + strInstallmentPaidValue + ") as InstallmentPaymentTable on CRMReservation.ReservationID = "+
            //    "InstallmentPaymentTable.ReservationID where CRMReservation.ReservationID="+ _ReservationID;
            //string strTempPayment = "SELECT  CRMReservation.ReservationID, CASE WHEN TempPaymentTable.TotalPaymentValue IS NULL " +
            //       " THEN 0 ELSE TempPaymentTable.TotalPaymentValue END AS TempPaymentValue " +
            //       " FROM  CRMReservation LEFT OUTER JOIN " +
            //       " (SELECT     CRMTempReservationPayment.ReservationID, SUM(GLPayment.PaymentValue) AS TotalPaymentValue " +
            //       " FROM         CRMTempReservationPayment INNER JOIN " +
            //       " GLPayment ON CRMTempReservationPayment.PaymentID = GLPayment.PaymentID " +
            //       " GROUP BY CRMTempReservationPayment.ReservationID) TempPaymentTable ON  " +
            // " TempPaymentTable.ReservationID = CRMReservation.ReservationID where CRMReservation.ReservationID=" + _ReservationID;
            //strTempPayment = "select TempPaymentTable.ReservationID,sum(TempPaymentTable.TempPaymentValue) as TempPaymentValue from (" + strTempPayment + ") as TempPaymentTable group by ReservationID";
            //strTempPayment 
            //string strPayment = "select TempPaymentTable.TempPaymentValue+InstallmentPaymentTable.TotalInstallmentPaidValue-" +
            //    "CRMReservationCancelation.CancelationCost As PaymentValue,CRMReservationCancelation.CancelationDate,1 as PaymentCurrency"+
            //    ",1 as PaymentCurrencyValue,0 as PaymentType,'«” —œ«œ ﬁÌ„… ÕÃ“' as PaymentDesc"+
            //    ",0 as PaymentDirection,"+ SysData.CurrentUser.EmployeeBiz.ID +" as PaymentEmployee,"+ SysData.CurrentUser.EmployeeBiz.BranchID +" as PaymentBranch"+
            //    ", " + SysData.CurrentUser.ID + " as UsrIns,GetDate() as TimIns " +
            //    " from CRMReservationCancelation inner join (" + strTempPayment + 
            //    ") as TempPaymentTable on CRMReservationCancelation.ReservationID = TempPaymentTable.ReservationID  inner join ("+ strInstallmentPaidValue +
            //    ") as InstallmentPaymentTable on CRMReservationCancelation.ReservationID = InstallmentPaymentTable.ReservationID  ";
            //strPayment = "insert into CRMReservationPayBack (ReservationID, PaymentType, PaymentDate, PaymentValue,UsrIns,TimIns) " + strPayment;

            //strPayment = "  INSERT INTO GLPayment" +
            //               " ( PaymentValue, PaymentDate,PaymentCurrency,PaymentCurrencyValue, PaymentType, PaymentDesc " +
            //               ",PaymentDirection,PaymentEmployee,PaymentBranch,UsrIns,TimIns) " + strPayment;
            //strPayment += " declare @PaymentID numeric(18,0) "+
            //    " set @PaymentID = (select @@IDENTITY) "+
            //    " INSERT INTO CRMReservationPayBack" +
            //    "  (PaymentID,ReservationID)" +
            //    " VALUES     (@PaymentID," + _ReservationID + ") ";
            //    SysData.SharpVisionBaseDb.ExecuteNonQuery(strPayment);
            }
            #endregion
            strSql = "update CRMReservationInstallment set InstallmentStatus=2 "+
                "  where InstallmentStatus<>1 and ReservationID =" + _ReservationID;
            if (_IsDelegated)
                strSql += " update CRMReservation "+
                   " set ReservationDelegationDate =  "+ strDelegation +
                   " WHERE     (ReservationID = "+ _ReservationID +")";
            string strInner = "SELECT  dbo.CRMReservationInstallment.InstallmentID,GLPayment.PaymentID " +
                   " FROM    dbo.CRMReservationInstallment INNER JOIN " +
                   " dbo.CRMInstallmentPayment ON dbo.CRMReservationInstallment.InstallmentID = dbo.CRMInstallmentPayment.InstallmentID INNER JOIN " +
                   " dbo.GLPayment ON dbo.CRMInstallmentPayment.PaymentID = dbo.GLPayment.PaymentID INNER JOIN " +
                   " dbo.GLCheckPayment ON dbo.GLPayment.PaymentID = dbo.GLCheckPayment.PaymentID INNER JOIN " +
                   " dbo.GLCheck ON dbo.GLCheckPayment.CheckID = dbo.GLCheck.CheckID " +
                   " WHERE     (dbo.GLCheckPayment.PaymentIsCollected = 0) AND (dbo.GLCheck.CheckCurrentStatus <> 2 AND dbo.GLCheck.CheckCurrentStatus <> 4) AND  " +
                   " (dbo.CRMReservationInstallment.ReservationID = " + _ReservationID + ")";
            strSql += "delete from CRMInstallmentPayment where InstallmentID in (select InstallmentID from (" + strInner + ") as NativeInstallment) and PaymentID in (select PaymentID from (" + strInner + ") as NativePayment)";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
            ReservationDb objReservationDb = new ReservationDb();
            objReservationDb.ID = ReservationID;
            objReservationDb.InsertHistory();
        }
        public void Edit()
        {
            double dblDate = _Date.ToOADate() - 2;
            int intPayBack = _PayBackComplete ? 1 : 0;
            string strPayBackCompletDate = _PayBackComplete ? (_PayBackCompleteDate.ToOADate() - 2).ToString() : "null";
            int intPayBackCompletUser = _PayBackComplete ? SysData.CurrentUser.ID : 0;
            string strDelegation = _IsDelegated ?
              SysUtility.Approximate(_DelegationDate.ToOADate() - 2, 1, ApproximateType.Down).ToString() : "NULL";
            string strSql = "update CRMReservationCancelation" +
                            " set CancelationDate=" + dblDate + ", CancelationNote='" + _Note + "'," +
                            " CancelationCost=" + _Cost + ",PayBackComplete=" + intPayBack +
                            ",PayBackCompleteDate=" + strPayBackCompletDate +
                            ",PayBackCompleteUsr= case when PayBackComplete = 0  then " + intPayBackCompletUser + " else PayBackCompleteUsr end " +
                            ",CancelationType="+_Type+
                            ",UsrUpd=" + SysData.CurrentUser.ID + ",TimUpd=GetDate() where ReservationID=" + _ReservationID ;
            strSql += " update CRMReservation " +
                  " set ReservationDelegationDate =  " + strDelegation +
                  " WHERE     (ReservationID = " + _ReservationID + ")";
            string strInner = "SELECT  dbo.CRMReservationInstallment.InstallmentID,GLPayment.PaymentID " +
                  " FROM    dbo.CRMReservationInstallment INNER JOIN " +
                  " dbo.CRMInstallmentPayment ON dbo.CRMReservationInstallment.InstallmentID = dbo.CRMInstallmentPayment.InstallmentID INNER JOIN " +
                  " dbo.GLPayment ON dbo.CRMInstallmentPayment.PaymentID = dbo.GLPayment.PaymentID INNER JOIN " +
                  " dbo.GLCheckPayment ON dbo.GLPayment.PaymentID = dbo.GLCheckPayment.PaymentID INNER JOIN " +
                  " dbo.GLCheck ON dbo.GLCheckPayment.CheckID = dbo.GLCheck.CheckID " +
                  " WHERE     (dbo.GLCheckPayment.PaymentIsCollected = 0)  "+
                  " AND (dbo.GLCheck.CheckCurrentStatus <> 2 AND dbo.GLCheck.CheckCurrentStatus <> 4) AND  " +
                  " (dbo.CRMReservationInstallment.ReservationID = " + _ReservationID + ")";
            strSql += "delete from CRMInstallmentPayment where InstallmentID in (select InstallmentID from (" + strInner +
                ") as NativeInstallment) and PaymentID in (select PaymentID from (" + strInner + ") as NativePayment)";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);

            //strSql = "update CRMReservationInstallment set InstallmentStatus=2 " +
            //    "  where InstallmentStatus<>1 and ReservationID =" + _ReservationID;
            //SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
            ReservationDb objReservationDb = new ReservationDb();
            objReservationDb.ID = ReservationID;
            objReservationDb.InsertHistory();

        }
        public void Delete()
        {
            _ReasignSucceded = false;
            string strUnit = "  SELECT  dbo.CRMReservationUnit.ReservationID, dbo.CRMUnit.UnitClosedPermanent, dbo.CRMUnit.CurrentReservation, dbo.CRMUnit.UnitUserClosed, " +
                      " dbo.CRMUnit.UnitTimeOpen " +
                      " FROM    dbo.CRMUnit INNER JOIN " +
                      " dbo.CRMReservationUnit ON dbo.CRMUnit.UnitID = dbo.CRMReservationUnit.UnitID AND " +
                      " dbo.CRMUnit.CurrentReservation <> dbo.CRMReservationUnit.ReservationID " +
                      " WHERE  (dbo.CRMReservationUnit.ReservationID = " + _ReservationID + ")  "+
                      " and (  (dbo.CRMUnit.UnitClosedPermanent = 1) or (dbo.CRMUnit.CurrentReservation <> 0) "+
                      " or ((dbo.CRMUnit.UnitUserClosed <> " + SysData.CurrentUser.ID + ") AND   (dbo.CRMUnit.UnitTimeOpen > GETDATE()))"+
                      ") ";
            string strPayBack = "SELECT     ReservationID "+
                   " FROM    dbo.CRMReservationPayBack "+
                   " WHERE  (ReservationID = "+ _ReservationID +")";
            string strSql = "update CRMUnit set CurrentReservation= dbo.CRMReservationUnit.ReservationID "+
                       " FROM         dbo.CRMUnit INNER JOIN "+
                       " dbo.CRMReservationUnit ON dbo.CRMUnit.UnitID = dbo.CRMReservationUnit.UnitID AND "+
                       " dbo.CRMUnit.CurrentReservation <> dbo.CRMReservationUnit.ReservationID "+
                       " WHERE     (dbo.CRMReservationUnit.ReservationID = " + _ReservationID + ") and not exists (" + strUnit + ")"+
                       " and not exists (" + strPayBack + ")"; 
             strSql+=   "delete from  CRMReservationCancelation" +
                       " where ReservationID=" + _ReservationID + " and not exists ("+ strUnit +") "+
                       " and not exists ("+strPayBack+") ";

            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
            strUnit = "SELECT     COUNT(dbo.CRMUnit.UnitID) AS UnitCount "+
                     " FROM         dbo.CRMUnit INNER JOIN "+
                     " dbo.CRMReservationUnit ON dbo.CRMUnit.UnitID = dbo.CRMReservationUnit.UnitID AND  "+
                      " dbo.CRMUnit.CurrentReservation <> dbo.CRMReservationUnit.ReservationID "+
                      " WHERE     (dbo.CRMReservationUnit.ReservationID = "+ _ReservationID +")";
            int intFailureCount = (int)SysData.SharpVisionBaseDb.ReturnScalar(strUnit);
            if (intFailureCount == 0)
            {
                strSql = "update    CRMReservation  "+
                     " set  ReservationStatus =   CASE WHEN ReservationContractingDate > '1-1-1920' THEN  3  ELSE 2  END "+
                     " WHERE     (ReservationID ="+ _ReservationID +") ";
                strSql += " update CRMReservationInstallment set InstallmentStatus=0 " +
                    "  where InstallmentStatus=2 and ReservationID =" + _ReservationID;
                SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
                _ReasignSucceded = true;
                ReservationDb objReservationDb = new ReservationDb();
                    objReservationDb.ID = ReservationID;
                objReservationDb.InsertHistory();
            }

        }
        public DataTable Search()
        {
            string strSql = SearchStr + "Where 1 = 1";
            if(_ReservationID != 0)
                strSql = strSql + " And ReservationID = "+_ReservationID+"";
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        #endregion
    }
}
