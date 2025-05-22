using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.SystemBase;
using SharpVision.HR.HRDataBase;
using System.Data.SqlClient;
namespace SharpVision.HR.HRDataBase
{
    public class ApplicantWorkerAttendanceDb
    {
        #region Private Data
        protected int _ApplicantAttendanceID;
        protected int _Applicant;
        protected DateTime _AttendanceTime;
        protected int _AttandanceType;

        protected DateTime _AttendanceTimeBuffer;
        protected int _AttandanceTypeBuffer;

        protected int _AttendanceStatement;
        protected DateTime _DateFromSearch;
        protected DateTime _DateToSearch;
        protected bool _DateSearch;
        protected bool _OrderDescSearch;

        protected DataTable _CheckInOutTable;
        string _IDsStr;
        protected string _ApplicantIDs;
        public bool _HasAttendanceStatement;
        DataTable _AttendanceTable;
        #endregion
        #region Constructors
        public ApplicantWorkerAttendanceDb()
        {
        }
        public ApplicantWorkerAttendanceDb(DataRow ObjDr)
        {
            SetData(ObjDr);
        }
        #endregion
        #region Public Properties
        public int ApplicantAttendanceID
        {
            set
            {
                _ApplicantAttendanceID = value;
            }
            get
            {
                return _ApplicantAttendanceID;
            }
        }
        public int Applicant
        {
            set
            {
                _Applicant = value;
            }
            get
            {
                return _Applicant;
            }
        }
        public DateTime AttendanceTime
        {
            set
            {
                _AttendanceTime = value;
            }
            get
            {
                return _AttendanceTime;
            }
        }
        public int AttandanceType
        {
            set
            {
                _AttandanceType = value;
            }
            get
            {
                return _AttandanceType;
            }
        }

        public DateTime AttendanceTimeBuffer
        {
            set
            {
                _AttendanceTimeBuffer = value;
            }
            get
            {
                return _AttendanceTimeBuffer;
            }
        }
        public int AttandanceTypeBuffer
        {
            set
            {
                _AttandanceTypeBuffer = value;
            }
            get
            {
                return _AttandanceTypeBuffer;
            }
        }

        public int AttendanceStatement
        {
            set
            {
                _AttendanceStatement = value;
            }
            get
            {
                return _AttendanceStatement;
            }
        }
        public string IDsStr
        {
            set
            {
                _IDsStr = value;
            }
        }
        public string ApplicantIDs
        {
            set
            {
                _ApplicantIDs = value;
            }
            get
            {
                return _ApplicantIDs;
            }
        }
        public DateTime DateFromSearch
        {
            set
            {
                _DateFromSearch = value;
            }
        }
        public DateTime DateToSearch
        {
            set
            {
                _DateToSearch = value;
            }
        }
        public bool OrderDescSearch
        {
            set
            {
                _OrderDescSearch = value;
            }
        }

        public DataTable CheckInOutTable
        {
            set
            {
                _CheckInOutTable = value;
            }
        }

        public bool DateSearch
        {
            set
            {
                _DateSearch = value;
            }
        }
        public bool HasAttendanceStatement
        {
            set
            {
                _HasAttendanceStatement = value;
            }
        }
        public DataTable AttendanceTable
        {
            set
            {
                _AttendanceTable = value;
            }
        }
        int _UserID;
        public int UserID { set => _UserID = value; }

        DateTime _CloseDate;
        public DateTime CloseDate { set => _CloseDate = value; }
        DateTime _CloseStartDate;
        public DateTime CloseStartDate { set => _CloseStartDate = value; }
        DateTime _CloseEndDate;
        public DateTime CloseEndDate { set => _CloseEndDate = value; }
        #region OldSearch
        public string SearchStr1
        {
            get
            {
                string strTimeIndex = "SELECT  ApplicantAttendanceID, AttendanceTime " +
                     " FROM    dbo.HRApplicantWorkerAttendance_ITime where (1=1) ";
                double dblDateFrom = SysUtility.Approximate(_DateFromSearch.ToOADate() - 2, 1, ApproximateType.Down);
                double dblDateTo = SysUtility.Approximate(_DateToSearch.ToOADate() - 2, 1, ApproximateType.Up);
                if (_DateSearch)
                    strTimeIndex += " and AttendanceTime>= " + dblDateFrom + " and AttendanceTime <" + dblDateTo;
                string strApplicantIndex = "SELECT  ApplicantAttendanceID, Applicant " +
                  " FROM         dbo.HRApplicantWorkerAttendance_IApplicant where (1=1) ";
                if (_Applicant != 0)
                    strApplicantIndex += " and Applicant = " + _Applicant;
                if (_ApplicantIDs != null && _ApplicantIDs != "")
                    strApplicantIndex += " and Applicant in (" + _ApplicantIDs + ")";
                string strStatementIndex = "SELECT  ApplicantAttendanceID, AttendanceStatement " +
                       " FROM        dbo.HRApplicantWorkerAttendance_IStatement ";
                if (_AttendanceStatement != 0)
                    strStatementIndex += " where (AttendanceStatement = " + _AttendanceStatement + ") ";
                string Returned = " SELECT     HRApplicantWorkerAttendance.ApplicantAttendanceID,ApplicantIndexTable.Applicant," +
                                 " TimeIndexTable.AttendanceTime, HRApplicantWorkerAttendance.AttandanceType, " +
                                 " HRApplicantWorkerAttendance.AttendanceTimeBuffer, HRApplicantWorkerAttendance.AttandanceTypeBuffer, " +
                                 " HRApplicantWorkerAttendance.AttendanceStatement,ApplicantWorkerTable.* " +//,AttendanceStatementTable.* " +
                                 " FROM   HRApplicantWorkerAttendance " +
                                 " inner join (" + strTimeIndex + ") as TimeIndexTable " +
                                 " on HRApplicantWorkerAttendance.AttendanceTime = TimeIndexTable.AttendanceTime " +
                                 " and  HRApplicantWorkerAttendance.ApplicantAttendanceID = TimeIndexTable.ApplicantAttendanceID" +
                                " inner join (" + strApplicantIndex + ") as ApplicantIndexTable " +
                                 " on HRApplicantWorkerAttendance.Applicant = ApplicantIndexTable.Applicant " +
                                 " and  HRApplicantWorkerAttendance.ApplicantAttendanceID = ApplicantIndexTable.ApplicantAttendanceID" +
                                 " Left Outer Join (" + new ApplicantWorkerDb().ShortSearchStr + ") ApplicantWorkerTable On ApplicantWorkerTable.ApplicantID = HRApplicantWorkerAttendance.Applicant" +
                                 " ";
                //" Left Outer Join (" + AttendanceStatementDb.SearchStr + ") AttendanceStatementTable On AttendanceStatementTable.StatementID = HRApplicantWorkerAttendance.AttendanceStatement";

                if (_AttendanceStatement != 0)
                    Returned += " inner join (" + strStatementIndex + ") as StatementTable " +
                         " on HRApplicantWorkerAttendance.AttendanceStatement = StatementTable.AttendanceStatement " +
                                 " and  HRApplicantWorkerAttendance.ApplicantAttendanceID = StatementTable.ApplicantAttendanceID";
                return Returned;
            }
        }
        #endregion
        bool _IsSummary;
        public bool IsSummary { set => _IsSummary = value; }
        bool _IgnoreApplicant;
        public bool IgnoreApplicant { set => _IgnoreApplicant = value; }
        public string SearchStr
        {
            get
            {

                double dblDateFrom = SysUtility.Approximate(_DateFromSearch.ToOADate() - 2, 1, ApproximateType.Down);
                //dblDateFrom--;
                double dblDateTo = SysUtility.Approximate(_DateToSearch.ToOADate() - 2, 1, ApproximateType.Up);
                //dblDateTo++;

                //if (_ApplicantIDs != null && _ApplicantIDs != "")
                //    strApplicantIndex += " and Applicant in (" + _ApplicantIDs + ")";
                //string strStatementIndex = "SELECT  ApplicantAttendanceID, AttendanceStatement " +
                //       " FROM        dbo.AttendanceTable_IStatement ";
                //if (_AttendanceStatement != 0)
                //    strStatementIndex += " where (AttendanceStatement = " + _AttendanceStatement + ") ";
                string Returned = " SELECT     AttendanceTable.ApplicantAttendanceID,AttendanceTable.Applicant," +
                                 " AttendanceTable.AttendanceTime, AttendanceTable.AttandanceType, " +
                                 " AttendanceTable.AttendanceTimeBuffer, AttendanceTable.AttandanceTypeBuffer, " +
                                 " AttendanceTable.AttendanceStatement";
                if (!_IgnoreApplicant)
                    Returned += ",ApplicantWorkerTable.* ";//,AttendanceStatementTable.* " +
                                 Returned+=" FROM  ";
                if (!_HasAttendanceStatement && _Applicant != 0 || (_ApplicantIDs != null && _ApplicantIDs != ""))
                    Returned += "  HRApplicantWorkerAttendance as AttendanceTable";
                else if (_HasAttendanceStatement || _AttendanceStatement != 0)
                    Returned += "  HRApplicantWorkerAttendanceProcessed as AttendanceTable ";
                if(!_IgnoreApplicant)
                Returned += " Left Outer Join (" + new ApplicantWorkerDb().ShortSearchStr + ") as ApplicantWorkerTable " +
                    " On ApplicantWorkerTable.ApplicantID = AttendanceTable.Applicant" +
                    " ";
                Returned += " where dis is null ";
                if (_Applicant != 0 || (_ApplicantIDs != null && _ApplicantIDs != ""))
                {
                    if (_ApplicantIDs != null && _ApplicantIDs != "")
                        Returned += " and AttendanceTable.Applicant in (" + _ApplicantIDs + ") ";
                    else if (_Applicant != 0)
                        Returned += " and AttendanceTable.Applicant=" + _Applicant;
                    if (dblDateFrom > 0 && dblDateTo > dblDateFrom)
                        Returned += " and AttendanceTable.AttendanceTime >=" + dblDateFrom + " and AttendanceTable.AttendanceTime <= " + dblDateTo;
                }
                if (_AttendanceStatement != 0)
                    Returned += " and  AttendanceTable.AttendanceStatement=" + _AttendanceStatement;
                return Returned;
            }
        }
        public virtual string AddStr
        {
            get
            {
                double dblAttendanceTime = _AttendanceTime.ToOADate() - 2;
                string strAttendanceStatement = _AttendanceStatement.ToString();
                if (_AttendanceStatement == 0)
                    strAttendanceStatement = "Null";
                string Returned = " INSERT INTO HRApplicantWorkerAttendance " +
                                  " ( Applicant, AttendanceTime, AttandanceType, AttendanceStatement,UsrIns,TimIns)" +
                                  " select " + _Applicant + " as ApplicantID," + 
                                  dblAttendanceTime + " as AttendanceTime1," +
                                  " " + _AttandanceType + " as AttendanceType1," +
                                  strAttendanceStatement + " as Statement," + SysData.CurrentUser.ID + " as UsrID,GetDate() as TimIns "+
                                  @" where not exists (SELECT        UserID, DateStr, TimIns
FROM            dbo.HRApplicantWorkerAttendanceUserClose
WHERE        (UserID = "+ SysData.CurrentUser.ID +") AND (DateStr = '"+ _AttendanceTime.ToString("yyyyMMdd")  +"')) ";
                return Returned;
            }
        }
        public virtual string AddMultipleStr
        {
            get
            {
                double dblAttendanceTime = _AttendanceTime.ToOADate() - 2;
                string strAttendanceStatement = _AttendanceStatement.ToString();
                if (_AttendanceStatement == 0)
                    strAttendanceStatement = "Null";
                string Returned = " INSERT INTO HRApplicantWorkerAttendance " +
                                  " ( Applicant, AttendanceTime, AttandanceType, AttendanceStatement,UsrIns,TimIns)" +
                                  @"  SELECT        ApplicantID, " + dblAttendanceTime + @" AS AttendanceTime, " + _AttandanceType + @" AS Type1, NULL AS AttendanceStatement, " + SysData.CurrentUser.ID +
                                  @" AS UsrIns, GETDATE() AS TimeIns
FROM dbo.HRApplicantWorker
WHERE(ApplicantID IN(" + _ApplicantIDs + ")) " +
  @" and not exists(SELECT        UserID, DateStr, TimIns
FROM            dbo.HRApplicantWorkerAttendanceUserClose
WHERE(UserID = "+ SysData.CurrentUser.ID +") AND(DateStr = '"+ _AttendanceTime.ToString("yyyyMMdd")  +"')) ";
                return Returned;
            }
        }
        public virtual string EditStr
        {
            get
            {
                double dblAttendanceTime = _AttendanceTime.ToOADate() - 2;
                string strAttendanceStatement = _AttendanceStatement.ToString();
                if (_AttendanceStatement == 0)
                    strAttendanceStatement = "Null";
                string Returned = " UPDATE    HRApplicantWorkerAttendance" +
                                  " SET  AttandanceType = " + _AttandanceType + "" +
                                  " ,AttendanceStatement = " + strAttendanceStatement + " " +
                                  " ,TimUpd = GetDate() ,UsrUpd = " + SysData.CurrentUser.ID + "" +
                                  " WHERE    (Applicant =" + _Applicant + " ) and (ApplicantAttendanceID = " + _ApplicantAttendanceID + ")";
                return Returned;
            }
        }
        public virtual string EditProcessedStr
        {
            get
            {
                double dblAttendanceTime = _AttendanceTime.ToOADate() - 2;
                string strAttendanceStatement = _AttendanceStatement.ToString();
                if (_AttendanceStatement == 0)
                    strAttendanceStatement = "Null";
                string Returned = " UPDATE    HRApplicantWorkerAttendanceProcessed " +
                                  " SET  AttendanceTime =" + dblAttendanceTime + "" +
                                  " ,AttandanceType = " + _AttandanceType + "" +
                                  " ,AttendanceStatement = " + strAttendanceStatement + " " +
                                  " ,TimUpd = GetDate() ,UsrUpd = " + SysData.CurrentUser.ID + "" +
                                  " WHERE   (AttendanceStatement = " + strAttendanceStatement + ") and  (ApplicantAttendanceID = " + _ApplicantAttendanceID + ")";
                return Returned;
            }
        }
        public virtual string DeleteStr
        {
            get
            {
                //string Returned = " DELETE FROM HRApplicantWorkerAttendance" +
                //                  " WHERE     (Applicant = " + _Applicant + ") AND (ApplicantAttendanceID = " + _ApplicantAttendanceID + ")";

                string Returned = " Update HRApplicantWorkerAttendance Set Dis = GetDate()" +
                                 " WHERE     (Applicant = " + _Applicant + 
                                 ") AND (ApplicantAttendanceID = " + _ApplicantAttendanceID + ")";
                return Returned;
            }
        }
        #endregion
        #region Private Methods
        void SetData(DataRow objDR)
        {
            _ApplicantAttendanceID = int.Parse(objDR["ApplicantAttendanceID"].ToString());
            _Applicant = int.Parse(objDR["Applicant"].ToString());
            // _AttandanceType = int.Parse(objDR["AttandanceType"].ToString());
            if (bool.Parse(objDR["AttandanceType"].ToString()) == true)
                _AttandanceType = 1;
            else
                _AttandanceType = 0;
            //_AttandanceType = int.Parse(objDR["AttandanceType"].ToString());
            _AttendanceTime = DateTime.Parse(objDR["AttendanceTime"].ToString());
            if (objDR["AttendanceStatement"].ToString() != "")
                _AttendanceStatement = int.Parse(objDR["AttendanceStatement"].ToString());
            else
                _AttendanceStatement = 0;
        }

        #endregion
        #region Public Methods
        public virtual void Add()
        {
            _ApplicantAttendanceID = SysData.SharpVisionBaseDb.InsertIdentityTable(AddStr);
        }
        public virtual void Edit()
        {
            SysData.SharpVisionBaseDb.ExecuteNonQuery(EditStr);
        }
        public void EditAttendanceType()
        {

            string strSql = " UPDATE    HRApplicantWorkerAttendance" +
                                 " SET  " +
                                 " AttandanceType = " + _AttandanceType + "" +
                                 " ,TimUpd = GetDate() " +
                                 " WHERE     (ApplicantAttendanceID = " + _ApplicantAttendanceID + ")";


            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public void EditAttendanceTypeCol()
        {
            if (_AttendanceTable == null || _AttendanceTable.Rows.Count == 0)
                return;
            string[] arrStr = new string[_AttendanceTable.Rows.Count];
            DataRow objDr;
            for (int intIndex = 0; intIndex < _AttendanceTable.Rows.Count; intIndex++)
            {
                objDr = _AttendanceTable.Rows[intIndex];
                arrStr[intIndex] = " UPDATE    HRApplicantWorkerAttendance" +
                                      " SET  " +
                                      " AttandanceType = " + (bool.Parse(objDr["AttandanceType"].ToString()) ? "1" : "0") + "" +
                                      " ,TimUpd = GetDate() " +
                                      " WHERE     ( Applicant = " + objDr["Applicant"].ToString() +
                                      " and ApplicantAttendanceID = " + objDr["ApplicantAttendanceID"].ToString() + ")";

            }
            SysData.SharpVisionBaseDb.ExecuteNonQuery(arrStr);
        }
        public void EditAttendanceStatement()
        {
            if (_IDsStr == null || _IDsStr == "")
                return;
            string strSql = " UPDATE    HRApplicantWorkerAttendance" +
                           " SET  AttendanceStatement = " + _AttendanceStatement + " " +
                           " WHERE   (ApplicantAttendanceID  in (" + _IDsStr + "))";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public virtual void Delete()
        {
            SysData.SharpVisionBaseDb.ExecuteNonQuery(DeleteStr);
        }
        public virtual DataTable Search()
        {
            string StrSql = SearchStr + "  ";
            //if (_Applicant != 0)
            //    StrSql = StrSql + " And ( Applicant = " + _Applicant + ")";
            if (_ApplicantAttendanceID != 0)
                StrSql = StrSql + " And ( ApplicantAttendanceID = " + _ApplicantAttendanceID + ")";
            if (_AttandanceType != 0)
                StrSql = StrSql + " And ( AttandanceType= " + _AttandanceType + ")";
            if (_HasAttendanceStatement == true)
                StrSql = StrSql + " And AttendanceStatement > 0 ";

            if (_OrderDescSearch == false)
                StrSql = StrSql + "Order By AttendanceTable.Applicant , AttendanceTable.AttendanceTime";
            else
                StrSql = StrSql + "Order By AttendanceTable.Applicant ,AttendanceTable.AttendanceTime Desc";
            return SysData.SharpVisionBaseDb.ReturnDatatable(StrSql);
        }
        public void JoinCheckInOut()
        {
            string[] arrStr = new string[_CheckInOutTable.Rows.Count];
            if (_CheckInOutTable == null || _CheckInOutTable.Rows.Count == 0)
            {
                return;
            }
            else
            {
                ApplicantWorkerAttendanceDb objDb;
                int intIndex = 0;
                string strTemp = "";
                foreach (DataRow objDr in _CheckInOutTable.Rows)
                {


                    //objDb = new ApplicantWorkerAttendanceDb(objDr, true);

                    // objDb.ApplicantID = _ID;
                    double dblDateTime = DateTime.Parse(objDr["CHECKTIME"].ToString()).ToOADate() - 2;
                    int intAttendanceType = 0;
                    if (objDr["CHECKTYPE"].ToString() == "I" || objDr["CHECKTYPE"].ToString() == "i")
                    {
                        intAttendanceType = 1;
                    }
                    string strSql = " INSERT INTO HRApplicantWorkerAttendance (AW.Applicant, AttendanceTime, AttandanceType,AttendanceTimeBuffer, AttandanceTypeBuffer)" +
                                    " Select AW.ApplicantID ," + dblDateTime + "," + intAttendanceType + " ," + dblDateTime + "," + intAttendanceType + " " +
                                    " From HRApplicantWorker AW Where AW.ApplicantCode = '" + objDr["Badgenumber"].ToString() + "'";

                    //strTemp = objDb.AddStr;
                    arrStr[intIndex] = strSql;
                    intIndex++;
                }
            }
            SysData.SharpVisionBaseDb.ExecuteNonQuery(arrStr);
        }
        public void UploadCheckInOut()
        {
            if (_AttendanceTable == null || _AttendanceTable.Rows.Count == 0)
                return;
            string strSql = "delete from HRApplicantWorkerAttendanceTemp ";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
            SqlBulkCopy objCopy = new SqlBulkCopy(SysData.SharpVisionBaseDb.Connection);
            objCopy.DestinationTableName = "HRApplicantWorkerAttendanceTemp";
            objCopy.WriteToServer(_AttendanceTable);

            string strMaxAttendance =
                @"SELECT        derivedtbl_1.Applicant, dbo.HRAttendanceStatement.StatementFrom,  dbo.GetApproximateDate(dbo.HRAttendanceStatement.StatementTo) MaxStatementTo
FROM(SELECT        MAX(ApplicantAttendanceStatmentID) AS MaxAttendanceStatement, Applicant
                           FROM            dbo.HRApplicantWorkerAttendanceStatement
                           GROUP BY Applicant) AS derivedtbl_1 INNER JOIN
                         dbo.HRApplicantWorkerAttendanceStatement AS HRApplicantWorkerAttendanceStatement_1 ON derivedtbl_1.MaxAttendanceStatement = HRApplicantWorkerAttendanceStatement_1.ApplicantAttendanceStatmentID INNER JOIN
                         dbo.HRAttendanceStatement ON HRApplicantWorkerAttendanceStatement_1.AttendanceStatment = dbo.HRAttendanceStatement.StatementID";

            strSql = " insert into HRApplicantWorkerAttendance (Applicant, AttendanceTime, AttandanceType, AttendanceStatement)  " +
                "SELECT        NewCheckInOutTable.ApplicantID, NewCheckInOutTable.AttendanceTime, NewCheckInOutTable.AttendanceType, 0 AS Satement " +
                 " FROM            (SELECT        dbo.HRApplicantWorker.ApplicantID, dbo.HRApplicantWorkerAttendanceTemp.AttendanceTime, dbo.HRApplicantWorkerAttendanceTemp.AttendanceType " +
                           " FROM            dbo.HRApplicantWorkerAttendanceTemp INNER JOIN " +
                           " dbo.HRApplicantWorker ON dbo.HRApplicantWorkerAttendanceTemp.ApplicantCode = dbo.HRApplicantWorker.ApplicantCode) AS NewCheckInOutTable LEFT OUTER JOIN " +
                          " dbo.HRApplicantWorkerAttendance "+
                          " ON NewCheckInOutTable.ApplicantID = dbo.HRApplicantWorkerAttendance.Applicant AND  " +
                         " NewCheckInOutTable.AttendanceTime = dbo.HRApplicantWorkerAttendance.AttendanceTime "+
                         " AND NewCheckInOutTable.AttendanceType = dbo.HRApplicantWorkerAttendance.AttandanceType " +
                         " and dbo.HRApplicantWorkerAttendance.Dis is null " +
                         " left outer join (" + strMaxAttendance + ") as MaxAttendanceTable  " +
                         " on NewCheckInOutTable.ApplicantID =  MaxAttendanceTable.Applicant   " +
                         " WHERE        (dbo.HRApplicantWorkerAttendance.ApplicantAttendanceID IS NULL)" +
                         " and ( (MaxAttendanceTable.Applicant is null) or (NewCheckInOutTable.AttendanceTime > MaxAttendanceTable.MaxStatementTo)  ) ";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);


        }
        public void AddMultiple()
        {
            if (_ApplicantIDs == null || _ApplicantIDs.Trim() == "")
                return;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(AddMultipleStr);

        }
        public void CloseUserDate()
        {
            if (_UserID == 0)
                return;
            string strDate = _CloseDate.ToString("yyyyMMdd");

            string strSql = @" insert into HRApplicantWorkerAttendanceUserClose 
     ( UserID, DateStr, TimIns)
    SELECT        " + _UserID + @" AS Expr1, '" + strDate + @"' AS Expr2, GETDATE() AS TimIns
WHERE        (NOT EXISTS
                             (SELECT        UserID, DateStr
                                FROM            dbo.HRApplicantWorkerAttendanceUserClose
                                WHERE        (UserID = " + _UserID + @") AND (DateStr = '" + strDate + "')))";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }

        public void CloseUserMultipleDate()
        {
            if (_UserID == 0)
                return;
            string strDate = _CloseStartDate.ToString("yyyyMMdd");
            string strEndDate = _CloseEndDate.ToString("yyyyMMdd");

            DateTime dtCloseDate = DateTime.Now;
            dtCloseDate = _CloseStartDate.Date;

            string strSql = "";
            List<string> arrStr = new List<string>();
            while (dtCloseDate <= _CloseEndDate)
            {
                strDate = dtCloseDate.ToString("yyyyMMdd");
                strSql = @" insert into HRApplicantWorkerAttendanceUserClose 
     ( UserID, DateStr, TimIns)
    SELECT        " + _UserID + @" AS Expr1, '" + strDate + @"' AS Expr2, GETDATE() AS TimIns
WHERE        (NOT EXISTS
                             (SELECT        UserID, DateStr
                                FROM            dbo.HRApplicantWorkerAttendanceUserClose
                                WHERE        (UserID = " + _UserID + @") AND (DateStr = '" + strDate + "')))";
                dtCloseDate = dtCloseDate.AddDays(1);
                arrStr.Add(strSql);
            }
                SysData.SharpVisionBaseDb.ExecuteNonQuery(arrStr);
        }
        public void OpenUserDate()
        {
            if (_UserID == 0)
                return;
            string strDate = _CloseDate.ToString("yyyyMMdd");

            string strSql = @"delete from   dbo.HRApplicantWorkerAttendanceUserClose
                                WHERE        (UserID = " + _UserID + @") AND (DateStr = '" + strDate + "') ";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public void OpenUserMultipleDate()
        {
            if (_UserID == 0)
                return;
            string strStartDate = _CloseStartDate.ToString("yyyyMMdd");
            string strEndDate = _CloseEndDate.ToString("yyyyMMdd");
            string strSql = @"delete from   dbo.HRApplicantWorkerAttendanceUserClose
                                WHERE        (UserID = " + _UserID + @") AND (DateStr >= '" + strStartDate + "') AND (DateStr <= '" + strEndDate + "')";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public bool IsUserClosed()
        {
            if (_UserID == 0)
                return false;
            string strDate = _CloseDate.ToString("yyyyMMdd");
            string strSql = @"SELECT        UserID, DateStr, TimIns
FROM            dbo.HRApplicantWorkerAttendanceUserClose
WHERE        (UserID = "+_UserID+@") AND (DateStr = '"+ strDate +"')";
            DataTable dtTemp = SysData.SharpVisionBaseDb.ReturnDatatable(strSql);

            return dtTemp.Rows.Count==1;
        }
        public DataTable GetClosDate()
        {
            if (_UserID == 0)
                return new DataTable();
            string strStartDate = _CloseStartDate.ToString("yyyyMMdd");
            string strEndDate = _CloseEndDate.ToString("yyyyMMdd");
            string strSql = @"SELECT        UserID, DateStr, TimIns
FROM            dbo.HRApplicantWorkerAttendanceUserClose
WHERE        (UserID = " + _UserID + @") AND (DateStr >= '" + strStartDate + "') and (DateStr <= '" + strEndDate + "')";
            DataTable Returned = SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
            return Returned;

        }
        public void EditSummary()
        {
            if (_IDsStr == null || _IDsStr == "")
                return;
            string strSql = @"update HRApplicantWorker set HasTimeShit = " +(_IsSummary?0:1).ToString() + 
                " where ApplicantID in ("+ _IDsStr +") ";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        #endregion
    }
}
