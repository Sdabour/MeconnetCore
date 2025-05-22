using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.SystemBase;
using System.Data;
using SharpVision.Base.BaseDataBase;
namespace SharpVision.CRM.CRMDataBase
{
   public  class EventDb 
    {
        #region Private Data
    
      
        #endregion
        #region Constructors
       public EventDb()
       { }
       public EventDb(DataRow objDr)
       {
           SetData(objDr);
       }
        #endregion
        #region Public Properties

       int _ID;
       public int ID
       {
           set { _ID = value; }
           get { return _ID; }
       }
        int _Type;
        public int Type
        {
            set { _Type = value; }
            get { return _Type; }
        }
        string _NameA;
        public string NameA
        {
            set { _NameA = value; }
            get { return _NameA; }
        }
        string _NameE;
        public string NameE
        {
            set { _NameE = value; }
            get { return _NameE; }
        }
        DateTime _StartDate;
        public DateTime StartDate
        {
            set { _StartDate = value; }
            get { return _StartDate; }
        }
        DateTime _EndDate;
        public DateTime EndDate
        {
            set { _EndDate = value; }
            get { return _EndDate; }
        }
        int _Category;
        public int Category
        {
            set { _Category = value; }
            get { return _Category; }
        }
        int _Evaluation;
        public int Evaluation
        {
            set { _Evaluation = value; }
            get { return _Evaluation; }
        }
        public string AddStr
        {
            get
            {
                double dblStart = SysUtility.Approximate(_StartDate.ToOADate() - 2, 1, ApproximateType.Down);
                double dblEnd = SysUtility.Approximate(_EndDate.ToOADate() - 2, 1, ApproximateType.Down);
                string Returned = " insert into  (EventType, EventNameA, EventNameE, EventStartDate, EventEndDate, EventCategory, EventEvaluation"+
                   ",UsrIns,TimIns) values ("+_Type+",'"+_NameA+"','"+_NameE+"',"+dblStart+","+dblEnd+","+
                   _Category+","+_Evaluation+ "," + SysData.CurrentUser.ID + ",GtDate()"+")";
                return Returned;
            }
        }
        public string EditStr
        {
            get
            {
                double dblStart = SysUtility.Approximate(_StartDate.ToOADate() - 2, 1, ApproximateType.Down);
                double dblEnd = SysUtility.Approximate(_EndDate.ToOADate() - 2, 1, ApproximateType.Down);
                string Returned = " update    CRMEvent set EventType=" + _Type +
                    ", EventNameA='"+_NameA+ "'"+
                    ", EventNameE='"+ _NameE+ "'"+
                    ", EventStartDate="+dblStart+
                    ", EventEndDate="+dblEnd+
                    ", EventCategory="+_Category+
                    ", EventEvaluation="+_Evaluation+
                    ",UsrUpd="+SysData.CurrentUser.ID+
                    ",TimUpd=GetDate() "+
                    " where EventID =" +_ID;
                return Returned;
            }
        }
        public string DeleteStr
        {
            get
            {
                string Returned = " update CRMEvent set Dis = GetDate() where EventID="+_ID;
                return Returned;
            }
        }
        public static string SearchStr
        {
            get
            {
                string Returned = "SELECT  dbo.CRMEvent.EventID, dbo.CRMEvent.EventType, dbo.CRMEvent.EventNameA, dbo.CRMEvent.EventNameE, dbo.CRMEvent.EventStartDate, dbo.CRMEvent.EventEndDate, dbo.CRMEvent.EventCategory,  "+
                          " dbo.CRMEvent.EventEvaluation "+
                          " FROM            dbo.CRMEvent INNER JOIN "+
                         "  ("+ EventTypeDB.SearchStr +") AS EventTable ON dbo.CRMEvent.EventType = EventTable.EventTypeID ";

                return Returned;
            }
        }
        #endregion
        #region Private Methods
        void SetData(DataRow objDr)
        {
            int.TryParse( objDr["EventID"].ToString(),out _ID);
            int.TryParse(objDr["EventType"].ToString(), out _Type);
           _NameA = objDr["EventNameA"].ToString();
           _NameE = objDr["EventNameE"].ToString();
          DateTime.TryParse( objDr["EventStartDate"].ToString(),out _StartDate);
          DateTime.TryParse( objDr["EventEndDate"].ToString(),out _EndDate);
         int.TryParse( objDr["EventCategory"].ToString(),out _Category);
          int.TryParse(objDr["EventEvaluation"].ToString(),out _Evaluation);



        }
        #endregion
        #region Public Methods
        public void Add()
        {
            string strSql = AddStr;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public void Edit()
        {
            string strSql = EditStr;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public void Delete()
        {
            string strSql = DeleteStr;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public DataTable Search()
        {
            string strSql = SearchStr;
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        #endregion
    }
}
