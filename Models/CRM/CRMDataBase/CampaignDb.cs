using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.SystemBase;
using System.Data;
using System.Data.SqlClient;
using SharpVision.Base.BaseDataBase;

namespace SharpVision.CRM.CRMDataBase
{
    public class CampaignDb
    {
        #region Private Data
        protected int _ID;
        protected DateTime _Date;
        protected string _Desc;
        protected string _Criteria;
        protected int _ContactItem;
        protected string _Msg;
        protected int _LetterRTF;
        protected int _CustomerCount;
        protected int _ContactedCustomerCount;
        protected int _NonContactedCustomerCount;
        protected bool _IsForInstallment;
        protected int _CellFamilyID;
        
        protected bool _IsSystemCampaign;

        protected int _TopicID;

        protected string _TopicName;
        string _IDsStr;
        protected DateTime _StartInstallmentDueDate;
        protected DateTime _EndInstallmentDueDate;
        protected DateTime _StartInstallmentPaymentDate;
        protected DateTime _EndInstallmentPaymentDate;
        protected DataTable _InstallmentTypeTable;
        protected DataTable _RuleTable;
        protected int _SystemCampaignStatus;/*
                                             * 0 dont care 
                                             * 1 only system campaign
                                             * 2 only not system campaign
                                             */
        int _InstallmentStatus;/*
                                * 0 dont care
                                * 1 only for installment
                                * 2 only not for installment
                                */
        int _ContactedCustomerStatus;/*
                                      * 0 dont care
                                      * 1 only contacted customer 
                                      * 2 only dont have contacted customer
                                      */


        #region Data for Search
        bool _IsDateRange;
        DateTime _FromDate;
        DateTime _ToDate;
        string _TopicIDs;
        int _TopicFamily;
        #endregion
        #endregion
        #region Constractors
        public CampaignDb()
        { 
        }
        public CampaignDb(int intID)
        {
            DataTable dtTemp = Search();
            DataRow objDR = dtTemp.Rows[0];
            SetData(objDR);
        }
        public CampaignDb(DataRow objDR)
        {
            SetData(objDR);
        }
        #endregion
        #region Public Accessorice
        public int ID
        {
            set
            {
                _ID = value;
            }
            get
            {
                return _ID;
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
        public string Desc
        {
            set
            {
                _Desc = value;
            }
            get
            {
                return _Desc;
            }
        }
        public string Criteria
        {
            set
            {
                _Criteria = value;
            }
            get
            {
                return _Criteria;
            }
        }
        public int ContactItem
        {
            set
            {
                _ContactItem = value;
            }
            get
            {
                return _ContactItem;
            }
        }
        public string Msg
        {
            set
            {
                _Msg = value;
            }
            get
            {
                if (_Msg == null)
                    _Msg = "";
                return _Msg;
            }
        }
        public int LetterRTF
        {
            set
            {
                _LetterRTF = value;
            }
            get
            {
                return _LetterRTF;
            }
        }
        public int TopicID
        {
            set
            {
                _TopicID = value;
            }
            get
            {
                return _TopicID;
            }
        }
        
        public int CellFamilyID
        {
            set
            {
                _CellFamilyID = value;
            }
            get
            {
                return _CellFamilyID;
            }
        }
        public DateTime StartInstallmentDueDate
        {
            set
            {
                _StartInstallmentDueDate = value;
            }
            get
            {
                return _StartInstallmentDueDate;
            }
        }

        public DateTime EndInstallmentDueDate
        {
            set
            {
                _EndInstallmentDueDate = value;
            }
            get
            {
                return _EndInstallmentDueDate;
            }
        }
        public DateTime StartInstallmentPaymentDate
        {
            set
            {
                _StartInstallmentPaymentDate = value;
            }
            get
            {
                return _StartInstallmentPaymentDate;
            }
        }
        public DateTime EndInstallmentPaymentDate
        {
            set
            {
                _EndInstallmentPaymentDate = value;
            }
            get
            {
                return _EndInstallmentPaymentDate;
            }
        }
        public bool IsForInstallment
        {
            set
            {
                _IsForInstallment = value;
            }
            get
            {
                return _IsForInstallment;
            }
        }
        public bool IsSystemCampaign
        {
            set
            {
                _IsSystemCampaign = value;
            }
            get
            {
                return _IsSystemCampaign;
            }
        }
        public DataTable InstallmentTypeTable
        {
            set
            {
                _InstallmentTypeTable = value;
            }
        }
        public DataTable RuleTable
        {
            set
            {
                _RuleTable = value;
            }
        }
        public bool IsDateRange
        {
            set
            {
                _IsDateRange = value;
            }
        }
        public DateTime FromDate
        {
            set
            {
                _FromDate = value;
            }
        }
        public DateTime ToDate
        {
            set
            {
                _ToDate = value;
            }
        }
        public string IDsStr
        {
            set
            {
                _IDsStr = value;
            }
        }
        public int SystemCampaignStatus
        {
            set
            {
                _SystemCampaignStatus = value;
            }
        }
        public int InstallmentStatus
        {
            set
            {
                _InstallmentStatus = value;
            }
        }
        public int ContactedCustomerStatus
        {
            set
            {
                _ContactedCustomerStatus = value;
            }
        }
        public string TopicIDs
        {
            set 
            {
                _TopicIDs = value;
            }
        }
        public int TopicFamily
        {
            set
            {
                _TopicFamily = value;
            }
        }
        public int CustomerCount
        {
            get
            {
                return _CustomerCount;
            }
        }
        public int NonContactedCustomerCount
        {
            get 
            {
                return _NonContactedCustomerCount;
            }
        }
        public int ContactedCustomerCount
        {
            get 
            {
                return _ContactedCustomerCount;
            }
        }
        public string TopicName
        {
            get
            {
                return _TopicName;
            }
        }
        bool _IsPeriodic;
        public bool IsPeriodic
        {
            set { _IsPeriodic = value; }
            get { return _IsPeriodic; }
        }
        DateTime _WorkDate;
        public DateTime WorkDate
        {
            set { _WorkDate = value; }
            get { return _WorkDate; }
        }
        DateTime _WorkHour;
        public DateTime WorkHour
        {
            set { _WorkHour = value; }
            get { return _WorkHour; }
        }
        bool _AutomaticPerformed;
        public bool AutomaticPerformed
        {
            set { _AutomaticPerformed = value; }
            get { return _AutomaticPerformed; }
        }
        string _Project;
        public string Project
        {
            get { return _Project; }
            set { _Project = value; }
        }
        int _SourceCampaign;
        public int SourceCampaign
        {
            get { return _SourceCampaign; }
            set { _SourceCampaign = value; }
        }
        DataTable _ScheduleTable;
        public DataTable ScheduleTable
        {
            set { _ScheduleTable = value; }
        }

        public  string SearchStr
        {
            get
            {
                string strCampaignContact = "SELECT CampaignCustomerID, SUM(CASE WHEN ContactStatus = 1 THEN 1 ELSE 0 END) AS ContactCount "+
                     " FROM  dbo.CRMCampaignCustomerContact "+
                     " GROUP BY CampaignCustomerID ";
                string strCampaignCustomer = "SELECT  dbo.CRMCampaign.CampaignID as CustomerCampaignID "+
                    ", COUNT( dbo.CRMCampaignCustomer.Customer) AS CustomerCount, SUM(CASE WHEN CampaignContactTable.ContactCount IS NULL or CampaignContactTable.ContactCount =0 " +
                      " THEN 0 ELSE 1 END) AS ContactedCount, SUM(CASE WHEN ContactDate IS NOT NULL THEN 0 ELSE 1 END) AS NotContactedCount "+
                      " FROM   dbo.CRMCampaign LEFT OUTER JOIN "+
                      " dbo.CRMCampaignCustomer ON dbo.CRMCampaign.CampaignID = dbo.CRMCampaignCustomer.Campaign "+
                      " left outer join (" + strCampaignContact + ") as CampaignContactTable "+
                      " on CRMCampaignCustomer.CampaignCustomerID = CampaignContactTable.CampaignCustomerID  "+
                      " GROUP BY dbo.CRMCampaign.CampaignID ";
                string strCampaignTopic = "SELECT TopicID AS CampaignTopicID, TopicNameA AS CampaignTopicName "+
                       " FROM  dbo.COMMONTopic ";

                string Returned = "SELECT CampaignID, CampaignDate, CampaignDesc, CampaignCriteria, " +
                    " CampaignContactItem,CampaignMsg, CampaignIsForInstallment, CampaignCellFamily, " +
                    "CampaignInstallmentStartDueDate, CampaignInstallmentEndDueDate,CampaignIsSystemCampaign, " +
                      "CampaignInstallmentStartPaymentDate, CampaignInstallmentEndPaymentDate " +
                      ",CampaignIsPeriodic, CampaignWorkDate, CampaignWorkHour, CampaignAutomaticPerformed"+
                      ",CampaignLetterRTF,ContactTable.*";
                if (_ContactedCustomerStatus != 0)
                    Returned+= ",CampaignCustomerTable.*";
                Returned += ",TopicTable.* " +
                            " FROM  CRMCampaign INNER JOIN (" + COMMON.COMMONDataBase.ContactDb.SearchStr + ") as ContactTable " +
                            "  ON CRMCampaign.CampaignContactItem = ContactTable.ContactID ";
                if (_ContactedCustomerStatus != 0)
                     Returned+= " inner JOIN (" + strCampaignCustomer + ") as CampaignCustomerTable ON " +
                                      " dbo.CRMCampaign.CampaignID = CampaignCustomerTable.CustomerCampaignID ";
                                Returned+=  " left outer join (" + strCampaignTopic + ") as TopicTable "+
                                  " on CRMCampaign.CampaignTopic = TopicTable.CampaignTopicID ";

                return Returned;
            }
        }
        #endregion
        #region Private Methods
        void SetData(DataRow objDR)
        {
            _ID = int.Parse(objDR["CampaignID"].ToString());
            _Date = DateTime.Parse(objDR["CampaignDate"].ToString());
            _Desc = objDR["CampaignDesc"].ToString();
            _Criteria = objDR["CampaignCriteria"].ToString();
            _ContactItem = int.Parse(objDR["CampaignContactItem"].ToString());
            _Msg = objDR["CampaignMsg"].ToString();
            _LetterRTF = int.Parse(objDR["CampaignLetterRTF"].ToString());
           if(objDR.Table.Columns["CustomerCount"]!= null)
            _CustomerCount = int.Parse(objDR["CustomerCount"].ToString());
            if(objDR.Table.Columns["NotContactedCount"]!= null)
            _NonContactedCustomerCount = int.Parse(objDR["NotContactedCount"].ToString());
            if(objDR.Table.Columns["ContactedCount"]!= null)
            _ContactedCustomerCount = int.Parse(objDR["ContactedCount"].ToString());
            
            _IsForInstallment = bool.Parse(objDR["CampaignIsForInstallment"].ToString());
            if(objDR["CampaignIsSystemCampaign"].ToString()!= "")
            _IsSystemCampaign = bool.Parse(objDR["CampaignIsSystemCampaign"].ToString());
            _CellFamilyID = int.Parse(objDR["CampaignCellFamily"].ToString());
            _StartInstallmentDueDate = DateTime.Parse(objDR["CampaignInstallmentStartDueDate"].ToString());
            _EndInstallmentDueDate = DateTime.Parse(objDR["CampaignInstallmentEndDueDate"].ToString());
            _StartInstallmentPaymentDate = DateTime.Parse(objDR["CampaignInstallmentStartPaymentDate"].ToString());
            _EndInstallmentPaymentDate = DateTime.Parse(objDR["CampaignInstallmentEndPaymentDate"].ToString());

             bool.TryParse( objDR["CampaignIsPeriodic"].ToString(),out _IsPeriodic);
            DateTime.TryParse( objDR["CampaignWorkDate"].ToString(),out _WorkDate);
            DateTime.TryParse( objDR["CampaignWorkHour"].ToString(),out _WorkHour);
           bool.TryParse( objDR["CampaignAutomaticPerformed"].ToString(),out _AutomaticPerformed);


        }
        #endregion
        #region Public Methods
        public void Add()
        {
            string strDeleteSystemCampaign = "update CRMCampaign set CampaignIsSystemCampaign =0 ";
            int intIsForInstallment = _IsForInstallment ? 1 : 0;
            int intIsSysCampaign = _IsSystemCampaign ? 1 : 0;
            double dblDate = _Date.ToOADate() - 2;

            double dblStartInstallmentDueDate = SysUtility.Approximate(_StartInstallmentDueDate.ToOADate() - 2, 1, ApproximateType.Down);
            double dblEndInstallmentDueDate = SysUtility.Approximate(_EndInstallmentDueDate.ToOADate() - 2, 1, ApproximateType.Down);
            double dblStartInstallmentPaymentDate = SysUtility.Approximate(_StartInstallmentPaymentDate.ToOADate() - 2, 1, ApproximateType.Down);
            double dblEndInstallmentPaymentDate = SysUtility.Approximate(_EndInstallmentPaymentDate.ToOADate() - 2, 1, ApproximateType.Down);
            string strSql = "";
            double dblWorkingDate =SysUtility.Approximate( _WorkDate.ToOADate()-2,1,ApproximateType.Down);
            double dblWorkingHour = _WorkHour.ToOADate() - 2;
            int intIsPeriodic = _IsPeriodic ? 1 : 0;
            int intAutomaticISPerformed = _AutomaticPerformed ? 1 : 0;
            if (_IsSystemCampaign)
                strSql += strDeleteSystemCampaign;
            strSql += " INSERT INTO CRMCampaign" +
                             " (CampaignDate, CampaignDesc, CampaignCriteria, CampaignContactItem,CampaignMsg," +
                             "CampaignIsForInstallment,CampaignCellFamily, CampaignInstallmentStartDueDate," +
                             " CampaignInstallmentEndDueDate, CampaignInstallmentStartPaymentDate " +
                              " ,CampaignInstallmentEndPaymentDate,CampaignLetterRTF"+
                              ",CampaignTopic, CampaignIsSystemCampaign " +
                              ",CampaignIsPeriodic, CampaignWorkDate, CampaignWorkHour, CampaignAutomaticPerformed"+
                              ",UsrIns,TimIns)" +
                             " VALUES     (" + dblDate + ",'" + _Desc + "','" + _Criteria + "'," + _ContactItem + ",'" + _Msg + "'," +
                             intIsForInstallment + "," + _CellFamilyID + "," + dblStartInstallmentDueDate + "," + dblEndInstallmentDueDate + "," +
                             dblStartInstallmentPaymentDate + "," + dblEndInstallmentPaymentDate +
                             "," + _LetterRTF + "," + _TopicID +
                             
                             "," + intIsSysCampaign +
                             "," + intIsPeriodic + "," + dblWorkingDate + "," + dblWorkingHour + "," + intAutomaticISPerformed +
                             "," + SysData.CurrentUser.ID + ",GetDate()) ";
            _ID = SysData.SharpVisionBaseDb.InsertIdentityTable(strSql);
            JoinInstallmentType();
            JoinRule();
            JoinSchedule();
        }
        public void Edit()
        {
            double dblDate = _Date.ToOADate() - 2;
            int intIsSysCampaign = _IsSystemCampaign ? 1 : 0;
            int intIsForInstallment = _IsForInstallment ? 1 : 0;
            double dblStartInstallmentDueDate = SysUtility.Approximate(_StartInstallmentDueDate.ToOADate() - 2, 1, ApproximateType.Down);
            double dblEndInstallmentDueDate = SysUtility.Approximate(_EndInstallmentDueDate.ToOADate() - 2, 1, ApproximateType.Down);
            double dblStartInstallmentPaymentDate = SysUtility.Approximate(_StartInstallmentPaymentDate.ToOADate() - 2, 1, ApproximateType.Down);
            double dblEndInstallmentPaymentDate = SysUtility.Approximate(_EndInstallmentPaymentDate.ToOADate() - 2, 1, ApproximateType.Down);
            string strDeleteSystemCampaign = "update CRMCampaign set CampaignIsSystemCampaign =0 ";

            string strSql = "";
            double dblWorkingDate = SysUtility.Approximate(_WorkDate.ToOADate() - 2, 1, ApproximateType.Down);
            double dblWorkingHour = _WorkHour.ToOADate() - 2;
            int intIsPeriodic = _IsPeriodic ? 1 : 0;
            int intAutomaticISPerformed = _AutomaticPerformed ? 1 : 0;
            if (_IsSystemCampaign)
                strSql += strDeleteSystemCampaign;
            strSql+=" UPDATE    CRMCampaign" +
                            " SET   CampaignDate =" + dblDate + "" +
                            " , CampaignDesc ='" + _Desc + "'" +
                            " , CampaignCriteria ='" + _Criteria + "'" +
                            " , CampaignContactItem = " + _ContactItem + "" +
                            " , CampaignMsg = '" + _Msg+ "'" +
                            ",CampaignLetterRTF="+ _LetterRTF +
                            ",CampaignIsForInstallment=" + intIsForInstallment +
                            ",CampaignCellFamily="+_CellFamilyID +
                            ",CampaignInstallmentStartDueDate="+ dblStartInstallmentDueDate +
                            ",CampaignInstallmentEndDueDate=" + dblEndInstallmentDueDate +
                            ",CampaignInstallmentStartPaymentDate="+ dblStartInstallmentPaymentDate +
                            ",CampaignInstallmentEndPaymentDate="+ dblEndInstallmentPaymentDate +
                            ",CampaignTopic="+ _TopicID+
                            ",CampaignIsSystemCampaign="+ intIsSysCampaign+
                            ",CampaignIsPeriodic ="+ intIsPeriodic + 
                            ", CampaignWorkDate="+ dblWorkingDate +
                            ", CampaignWorkHour ="+ dblWorkingHour +
                            ", CampaignAutomaticPerformed = " + intAutomaticISPerformed +
                            " , UsrUpd = " + SysData.CurrentUser.ID + "" +
                            " , TimUpd = GetDate()"+
                            " Where CampaignID = "+_ID+"";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
            JoinInstallmentType();
            JoinRule();
            JoinSchedule();
        }
        public void JoinProjectCustomer()
        {
            if (_ID == 0)
                return;
            string strSql = @"SELECT    distinct    " + _ID + @" AS Campaign, dbo.CRMCustomer.CustomerID
FROM dbo.CRMCustomer INNER JOIN
                         dbo.CRMReservationCustomer ON dbo.CRMCustomer.CustomerID = dbo.CRMReservationCustomer.CustomerID INNER JOIN
                         dbo.CRMUnit ON dbo.CRMReservationCustomer.ReservationID = dbo.CRMUnit.CurrentReservation INNER JOIN
                         dbo.CRMUnitCell ON dbo.CRMUnit.UnitID = dbo.CRMUnitCell.UnitID INNER JOIN
                         dbo.RPCell ON dbo.CRMUnitCell.CellID = dbo.RPCell.CellID LEFT OUTER JOIN
                             (SELECT        CampaignCustomerID, Campaign, Customer
                                FROM            dbo.CRMCampaignCustomer
                                WHERE(Campaign = " + _ID + @")) AS AssignedCampaign ON dbo.CRMCustomer.CustomerID = AssignedCampaign.Customer
WHERE(dbo.RPCell.CellFamilyID in (" + _Project + @")) AND(AssignedCampaign.CampaignCustomerID IS NULL)";
            strSql = " insert into CRMCampaignCustomer (Campaign,Customer) " +
                ""+strSql;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);


        }
        public void CopyCampaignCustomer()
        {
            if (_ID == 0)
                return;
            string strSql = @"SELECT    distinct    " + _ID + @" AS Campaign,SourceCampaign.Customer
FROM            dbo.CRMCampaignCustomer AS SourceCampaign
 LEFT OUTER JOIN
                             (SELECT        CampaignCustomerID, Campaign, Customer
                                FROM            dbo.CRMCampaignCustomer
                                WHERE(Campaign = " + _ID + @")) AS AssignedCampaign ON SourceCampaign.Customer = AssignedCampaign.Customer
WHERE (SourceCampaign.Campaign = "+ _SourceCampaign +@") and (AssignedCampaign.CampaignCustomerID IS NULL)";
            strSql = " insert into CRMCampaignCustomer (Campaign,Customer) " +
                "" + strSql;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);


        }
        public void JoinAllProjectCustomer()
        {
            if (_ID == 0)
                return;
            string strSql = @"SELECT    distinct    " + _ID + @" AS Campaign, dbo.CRMCustomer.CustomerID
FROM dbo.CRMCustomer INNER JOIN
                         dbo.CRMReservationCustomer ON dbo.CRMCustomer.CustomerID = dbo.CRMReservationCustomer.CustomerID INNER JOIN
                         dbo.CRMUnit ON dbo.CRMReservationCustomer.ReservationID = dbo.CRMUnit.CurrentReservation INNER JOIN
                         dbo.CRMUnitCell ON dbo.CRMUnit.UnitID = dbo.CRMUnitCell.UnitID INNER JOIN
                         dbo.RPCell ON dbo.CRMUnitCell.CellID = dbo.RPCell.CellID LEFT OUTER JOIN
                             (SELECT        CampaignCustomerID, Campaign, Customer
                                FROM            dbo.CRMCampaignCustomer
                                WHERE(Campaign = " + _ID + @")) AS AssignedCampaign ON dbo.CRMCustomer.CustomerID = AssignedCampaign.Customer
WHERE (AssignedCampaign.CampaignCustomerID IS NULL)";
            strSql = " insert into CRMCampaignCustomer (Campaign,Customer) " +
                "" + strSql;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);


        }
        public void DeleteAllCustomer()
        {
            if (_ID == 0)
                return;
            string strSql = @"delete
FROM dbo.CRMCampaignCustomer
WHERE(Campaign = "+ _ID+@") AND(LastContactID = 0)";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public void Delete()
        { 
            string strSql = " DELETE FROM CRMCampaign Where  CampaignID = "+_ID+" and not exists (SELECT     ContactCampaign "+
                   " FROM         dbo.CRMCampaignCustomerContact "+
                   " WHERE     (ContactCampaign = "+ _ID +")) ";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public DataTable Search()
        {
            string strSql = SearchStr + " Where Dis Is Null ";
            if (_ID != 0)
                strSql += " and  CampaignID = " + _ID + "";
            if (_IsDateRange)
            {
                double dblStart = SysUtility.Approximate(_FromDate.ToOADate() - 2, 1, ApproximateType.Down);
                double dblEnd = SysUtility.Approximate(_ToDate.ToOADate() - 2, 1, ApproximateType.Up);
                strSql += " and CampaignDate>=" + dblStart + " and CampaignDate <" + dblEnd;
            }
            if (_Desc != null && _Desc != "")
            {
                strSql += " and CampaignDesc like '%" + _Desc + "%' ";
            }
            if (_ContactItem != 0)
            {
                strSql += " and CampaignContactItem="+ _ContactItem ;
            }
            if (_IDsStr != null && _IDsStr != "")
                strSql += " and CampaignID in ("+ _IDsStr +")";
            if (_InstallmentStatus != 0)
            {
                if(_InstallmentStatus == 1)
                    strSql += " and CampaignIsForInstallment = 1  ";
                else if(_InstallmentStatus == 2)
                    strSql += " and CampaignIsForInstallment = 0  ";
            }
            if (_CellFamilyID != 0)
                strSql += " and CampaignCellFamily="+_CellFamilyID;
            if (_ContactedCustomerStatus != 0)
            {
                if (_ContactedCustomerStatus == 1)
                    strSql += " and ContactedCount > 0 ";
                else if (_ContactedCustomerStatus == 2)
                {
                    strSql += " and ContactedCount <=0 ";
                }
            }
            if (_SystemCampaignStatus == 1)
            {
                strSql += " and CRMCampaign.CampaignIsSystemCampaign=1 ";
            }
            else if (_SystemCampaignStatus == 2)
            {
                strSql += " and CRMCampaign.CampaignIsSystemCampaign=0 ";
            }
            strSql += " order by CampaignID desc ";
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        public void JoinInstallmentType()
        {
            if (_InstallmentTypeTable == null)
                return;
            string[] arrStr = new string[_InstallmentTypeTable.Rows.Count + 1];
            arrStr[0] = "delete from CRMCampaignInstallmentType where Campaign=" +_ID;
            for (int intIndex = 1; intIndex <= _InstallmentTypeTable.Rows.Count; intIndex++)
            {
                arrStr[intIndex] = "insert into CRMCampaignInstallmentType (Campaign, InstallmentType) values ("+
                     _ID + "," + _InstallmentTypeTable.Rows[intIndex-1]["InstallmentType"].ToString() + ")";

            }
            SysData.SharpVisionBaseDb.ExecuteNonQuery(arrStr);


        }
        public void JoinRule()
        {
            if (_RuleTable == null)
                return;
            string[] arrStr = new string[_RuleTable.Rows.Count + 1];
            string strIDs = "";
            
            CampaignRuleDb objDb;
            foreach (DataRow objDr in _RuleTable.Rows)
            {
                objDb = new CampaignRuleDb(objDr);
                if (objDb.ID != 0)
                {
                    if (strIDs != "")
                        strIDs += ",";
                    strIDs += objDb.ID.ToString();
                }
            }
            arrStr = strIDs == "" ? new string[_RuleTable.Rows.Count] : new string[_RuleTable.Rows.Count + 1]; 
            int intIndex = 0;
            if (strIDs != "")
            {
                arrStr[0] = "update CRMCampaignRule set Dis = GetDate() where RuleCampaign=" + _ID + 
                    " and RuleID not in ("+ strIDs +")";
                intIndex++;
            }
            foreach (DataRow objDr in _RuleTable.Rows)
            {


                objDb = new CampaignRuleDb(objDr);
                objDb.Campaign = _ID;
                if (objDb.ID == 0)
                    arrStr[intIndex] = objDb.AddStr;
                else
                    arrStr[intIndex] = objDb.EditStr;
                intIndex++;
            }
            SysData.SharpVisionBaseDb.ExecuteNonQuery(arrStr);
        }
        public DataTable GetInstallmentTypeTable()
        {
            string strSql = "select Campaign,InstallmentType,InstallmentTypetable.* "+
                " from CRMCampaignInstallmentType inner join ("+ InstallmentTypeDb.SearchStr +") as InstallmentTypeTable "+
                " on CRMCampaignInstallmentType.InstallmentType=InstallmentTypeTable.InstallmentTypeID  "+
                " where CRMCampaignInstallmentType.Campaign="+_ID;

            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        public DataTable GetLastCampaign()
        {
            string strSql =SearchStr + " where CampaignID in(select max(CampaignID) from CRMCampaign )";
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        public void JoinSchedule()
        {
            if (_ScheduleTable == null || _ScheduleTable.Rows.Count == 0)
                return;
            List<string> arrStr = new List<string>();
            CampaignScheduleDb objDb;
            foreach(DataRow objDr in _ScheduleTable.Rows)
            {
                objDb = new CampaignScheduleDb(objDr);
                objDb.Campaign = ID;
                if (objDb.ID == 0)
                    arrStr.Add(objDb.AddStr);
                else
                    arrStr.Add(objDb.EditStr);

            }
            SysData.SharpVisionBaseDb.ExecuteNonQuery(arrStr);

        }
        #endregion


    }
}
