using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.Base.BaseDataBase;
using SharpVision.SystemBase;

namespace SharpVision.CRM.CRMDataBase
{
    public class Event1DB : BaseSingleDb
    {

        #region Private Data
        protected int _ID;
        protected int _Type;
        protected int _Customer;
        protected int _User;
        protected string _Desc;
        protected DateTime _SatisfactionDate;
        protected bool _IsSatisfied;

        #region private data for search
        protected bool _IsDateRange;
        protected DateTime _StartDate;
        protected DateTime _EndDate;

        #endregion
       
        #endregion


        #region Constructors
        public Event1DB()
        { 
        }

        public Event1DB(int intID)
        {
            _ID = intID;
            DataTable dtTemp = Search();
            DataRow objDR = Search().Rows[0];
            _Type = int.Parse(objDR["EventType"].ToString());
            _Customer = int.Parse(objDR["EventCustomer"].ToString());
            _User = int.Parse(objDR["EventUser"].ToString());
            _Desc = objDR["EventDesc"].ToString();
            _SatisfactionDate = DateTime.Parse(objDR["EventSatisfactionDate"].ToString());
        }
        public Event1DB(DataRow objDR)
        {
            _ID = int.Parse(objDR["EventID"].ToString());
            _Type = int.Parse(objDR["EventType"].ToString());
            _Customer = int.Parse(objDR["EventCustomer"].ToString());
            _User = int.Parse(objDR["EventUser"].ToString());
            _Desc = objDR["EventDesc"].ToString();
            _SatisfactionDate = DateTime.Parse(objDR["EventSatisfactionDate"].ToString());
        }

        #endregion

        #region Public Properties
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
        public int Type
        {
            set 
            { 
                _Type = value;
            }
            get 
            { 
                return _Type; 
            }
            
        }
        public int Customer
        {
            set 
            { 
                _Customer = value; 
            }
            get
            { 
                return _Customer; 
            }
            
        }
        public int User
        {
            set
            {
                _User = value;
            }
            get 
            {
                return _User;
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
        public DateTime SatisfactionDate
        {
            set 
            {
                _SatisfactionDate = value;
            }
            get 
            {
                return _SatisfactionDate; 
            }
            
        }
        public bool IsSatisfied
        {
            set
            {
                _IsSatisfied = value;
            }
            get
            {
                return _IsSatisfied;
            }

        }
        public bool IsDateRange
        {
            set
            {
                _IsDateRange = value;
            }
        }
        public DateTime StartDate
        {
            set
            {
                _StartDate = value;
            }
        }
        public DateTime EndDate
        {
            set
            {
                _EndDate = value;
            }
        }

        public static string SearchStr
        {
            get
            {
                string Returned = " SELECT   EventID, EventType, EventCustomer, EventUser, EventDesc, EventSatisfactionDate,EventTypeTable.* ";
                Returned = Returned + " from CRMEvent iner join " +
                "(" + EventTypeDB.SearchStr + ") as EventTypeTable  " +
                " on CRMEvent.EventType = EventTypeTable.EventTypeID ";

                return Returned;
          

            }
        }
        #endregion


        #region Private Methods

        #endregion


        #region Public Methods

        public override void Add()
        {
            //double dblSatisfactionDate = SatisfactionDate.ToOADate() - 2;

            string strSatisfied = _IsSatisfied ? "GetDate()" : "null";
            string strSql = " INSERT INTO CRMEvent" +
                            "(EventType, EventCustomer, EventUser, EventDesc, EventSatisfactionDate, UsrIns, TimIns)" +
                            " VALUES     (" + _Type + "," + _Customer + "," + _User + "," + _Desc + "," + strSatisfied + "," + SysData.CurrentUser.ID + ",GetDate()) ";
            _ID = SysData.SharpVisionBaseDb.InsertIdentityTable(strSql);
        }


        public override void Edit()
        {
            double dblSatisfactionDate = SatisfactionDate.ToOADate() - 2;

            string strSql = " UPDATE    CRMEvent " +
                            " SET  EventType =" + _Type + "" +
                            ", EventCustomer =" + _Customer + "" +
                            ", EventUser =" + _User + "" +
                            ", EventDesc =" + _Desc + "" +
                            ", EventSatisfactionDate =" + _SatisfactionDate + "" +
                            ", UsrUpd =" + SysData.CurrentUser.ID + "" +
                            ", TimUpd = Getdate()" +
                            " where EventID=" + _ID.ToString();

            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }


        public override void Delete()
        {
            string strSql = "DELETE FROM CRMEvent where EventID = " + _ID;
        }


        public override DataTable Search()
        {
            string strSql = SearchStr +"  where (1 = 1)";
            if (_ID != 0)
                strSql += " And  EventID = " + _ID;
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);

        }

        //public DataTable GetAssignment()
        //{

        //}

        #endregion

    }
}
