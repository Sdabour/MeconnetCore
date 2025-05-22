using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.SystemBase;
using System.Data;
using System.Data.SqlClient;
using SharpVision.GL.GLDataBase;
namespace SharpVision.CRM.CRMDataBase
{
    public class InstallmentDiscountDb
    {
        #region Private Data
        int _ID;
        int _InstallmentID;
        double _Value;
        string _Reason;
        DateTime _Date;
        int _TypeID;
        protected bool _Direction;
        protected int _GLTransaction;
        protected int _GLTransactionStatus;
#region private data for search
        string _InstallmentIDs;
        string _ReservationIDs;
        int _CellFamilyID;
        string _CellIDs;
        string _UnitCode;
        bool _IsDateRange;
        DateTime _StartDate;
        DateTime _EndDate;
        bool _IsDueDateRange;
        DateTime _StartDueDate;
        DateTime _EndDueDate;

        int _HasTransactionStatus;/*
                                   * 0 dont care
                                   * 1 only has Transaction
                                   * 2 only dont have transaction
                                   */
        int _ReservationStatus;/*
                                * 0 dont care
                                * 1 only Reserved
                                * 2 only canceled
                                */
        string _InstallmentTypeIDs;
        int _MaxID;
        int _MinID;
        int _ResultCount;
        double _ResultValue;
        DataTable _TransactionTable;
#endregion
        #endregion

        #region Constructors
        public InstallmentDiscountDb()
        { 

        }
        public InstallmentDiscountDb(int intID)
        {
            _ID = intID;
            DataTable dtTemp = Search();
            DataRow objDR = dtTemp.Rows[0];
            _InstallmentID = int.Parse(objDR["InstallmentID"].ToString());
            _Reason = objDR["DiscountReason"].ToString();
            _Date = DateTime.Parse(objDR["DiscountDate"].ToString());
            _Value = double.Parse(objDR["DiscountValue"].ToString());
            _TypeID = int.Parse(objDR["TypeID"].ToString());
            
        }
        public InstallmentDiscountDb(DataRow objDR)
        {
            SetData(objDR);


        }
        #endregion

        #region Public Properties
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
        public string Reason
        {
            set
            {
                _Reason = value;
            }
            get
            {
                return _Reason;
            }

        }
        public double Value
        {
            set
            {
                _Value = value;
            }
            get
            {
                return _Value;
            }

        }

        public int InstallmentID
        {
            set
            {
                _InstallmentID = value;
            }
            get
            {
                return _InstallmentID;
            }

        }

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
        public int TypeID
        {
            set
            {
                _TypeID = value;
            }
            get
            {
                return _TypeID;
            }
        }
        public bool Direction
        {
            set
            {
                _Direction = value;
            }
            get
            {
                return _Direction;
            }
        }
        public int GLTransaction
        {
            set
            {
                _GLTransaction = value;
            }
            get
            {
                return _GLTransaction;
            }
        }
        public int GLTransactionStatus
        {
            set
            {
                _GLTransactionStatus = value;
            }

        }
        public string InstallmentIDs
        {
            set
            {
                _InstallmentIDs = value;
            }
        }
        public string ReservationIDs
        {
            set
            {
                _ReservationIDs = value;
            }
        }
        public int CellFamilyID
        {
            set
            {
                _CellFamilyID = value;
            }
        }
        public string CellIDs
        {
            set
            {
                _CellIDs = value;
            }
        }
        public string UnitCode
        {
            set
            {
                _UnitCode = value;
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
        public bool IsDueDateRange
        {
            set
            {
                _IsDueDateRange = value;
            }
        }
        public DateTime StartDueDate
        {
            set
            {
                _StartDueDate =  value;
            }
        }
        public DateTime EndDueDate
        {
            set
            {
                _EndDueDate = value;
            }
        }

        public int HasTransactionStatus
        {
            set
            {
                _HasTransactionStatus = value;
            }
        }
        public int ReservationStatus
        {
            set
            {
                _ReservationStatus = value;
            }

        }
        public string InstallmentTypeIDs
        {
            set
            {
                _InstallmentTypeIDs = value;
            }
        }
        public int MaxID
        {
            set
            {
                _MaxID = value;
            }
        }
        public int MinID
        {
            set
            {
                _MinID = value;
            }
        }
        public DataTable TransactionTable
        {
            set
            {
                _TransactionTable = value;
            }
        }
        public int ResultCount
        {
            get
            {
                return _ResultCount;
            }
        }
        public double ResultValue
        {
            get
            {
                return _ResultValue;
            }
        }
        public virtual string InverseStr
        {
            get
            {
                string Returned = "SELECT     InstallmentID, DiscountValue, DiscountReason, DiscountDate, TypeID, CASE WHEN DiscountDirection = 1 THEN 0 ELSE 1 END AS DiscountDirection1, "+
                      " DiscountID AS DiscountSourceID1, 0 AS DiscountReverseID1, 0 AS DiscountReceipt1, DiscountGLTransaction,"+ SysData.CurrentUser.ID +" as UsrIns1,GetDate() as TimIns1 "+
                      " FROM         dbo.CRMReservationInstallmentDiscount "+
                      " WHERE  (InstallmentID ="+ _InstallmentID +") AND (DiscountID = "+ _ID +") AND (DiscountReceipt > 0)";
                Returned = "insert into CRMReservationInstallmentDiscount (InstallmentID, DiscountValue, DiscountReason, DiscountDate, TypeID, DiscountDirection, DiscountSourceID, DiscountReverseID, DiscountReceipt, "+
                      " DiscountGLTransaction, UsrIns, TimIns " +
                      ") " +
                      " " + Returned;
                Returned += " declare @DiscountID numeric  " +
                    " set @DiscountID = (select @@IDENTITY as ID) " +
                    " update CRMReservationInstallmentDiscount set DiscountReverseID = case when @DiscountID = null then 0 else @DiscountID end  " +
                    " where DiscountID = " + _ID;
             

                return Returned;
            }
        }
        public  string SearchStr
        {
            get
            {
                ReservationInstallmentDb objInstallmentDb = new ReservationInstallmentDb();
                objInstallmentDb.CellIDs = _CellIDs;
                objInstallmentDb.CellFamilyID = _CellFamilyID;
                objInstallmentDb.DateRangeStatus = _IsDueDateRange ? 1 : 0;
                objInstallmentDb.UnitCode = _UnitCode;
                objInstallmentDb.TypeIDs = _InstallmentTypeIDs;
                objInstallmentDb.ReservationStatus = _ReservationStatus;
                objInstallmentDb.DateRangeStatus = _IsDueDateRange ? 1 : 0;
                objInstallmentDb.StartDueDate = _StartDueDate;
                objInstallmentDb.EndDueDate = _EndDueDate;
                objInstallmentDb.ReservationIDs = _ReservationIDs;
                string Returned = " SELECT     CRMReservationInstallmentDiscount.DiscountID, "+
                                  " CRMReservationInstallmentDiscount.DiscountValue, CRMReservationInstallmentDiscount.DiscountReason, "+
                                  " CRMReservationInstallmentDiscount.DiscountDate, CRMReservationInstallmentDiscount.TypeID,DiscountTypeTable.*" +
                                  ",InstallmentTable.* "+
                                  " FROM    CRMReservationInstallmentDiscount LEFT OUTER JOIN"+
                                  " (" + DiscountTypeDb.SearchStr + ") as DiscountTypeTable ON CRMReservationInstallmentDiscount.TypeID = DiscountTypeTable.DiscountTypeID "+
                                  " inner join (" + objInstallmentDb.StrSearch + ") as InstallmentTable "+
                                  " on CRMReservationInstallmentDiscount.InstallmentID = InstallmentTable.InstallmentID ";
                Returned += " where (1=1) ";
                if (_ID != 0)
                    Returned = Returned + " and CRMReservationInstallmentDiscount.DiscountID = " + _ID.ToString();
               if(_InstallmentID!= 0  ||
                   (_InstallmentIDs != null && _InstallmentIDs != "") || 
                   (_ReservationIDs != null && _ReservationIDs != ""))
                   Returned+= " and DiscountSourceID=0 and DiscountReverseID = 0 ";


                if (_InstallmentID != 0)
                    Returned = Returned + " and CRMReservationInstallmentDiscount.InstallmentID = " + _InstallmentID.ToString();
                if (_InstallmentIDs != null && _InstallmentIDs != "")
                    Returned = Returned + " and CRMReservationInstallmentDiscount.InstallmentID in (" + _InstallmentIDs + ") ";
              
                if (_TypeID != 0)
                    Returned = Returned + " and CRMReservationInstallmentDiscount.TypeID = " + _TypeID + " ";
                double dblStartDate = 0;
                double dblEndDate = 0;
                if (_IsDateRange)
                {
                    dblStartDate = SysUtility.Approximate(_StartDate.ToOADate() - 2, 1, ApproximateType.Down);
                    dblEndDate = SysUtility.Approximate(_EndDate.ToOADate() - 2, 1, ApproximateType.Up);
                    Returned += " and CRMReservationInstallmentDiscount.DiscountDate>"+ dblStartDate + 
                        " and CRMReservationInstallmentDiscount.DiscountDate < "+ dblEndDate;
                }
                if (_HasTransactionStatus != 0)
                {
                    if (_HasTransactionStatus == 1)
                    {
                        Returned += " and CRMReservationInstallmentDiscount.DiscountGLTransaction > 0 ";
                    }
                    else if (_HasTransactionStatus == 2)
                    {
                        Returned += " and (CRMReservationInstallmentDiscount.DiscountGLTransaction = 0)";
                    }
                }
                if (_GLTransactionStatus != 0)
                {
                    if (_GLTransactionStatus == 1)
                    {
                        Returned += " and CRMReservationInstallmentDiscount.DiscountGLTransaction > 0 ";
                    }
                    else if (_GLTransactionStatus == 2)
                    {
                        Returned += " and (CRMReservationInstallmentDiscount.DiscountGLTransaction = 0)";
                    }
                }
                return Returned;
            }
        }
        #endregion

        #region Private Methods
        void SetData(DataRow objDR)
        {
            _ID = int.Parse(objDR["DiscountID"].ToString());
            _InstallmentID = int.Parse(objDR["InstallmentID"].ToString());
            _Reason = objDR["DiscountReason"].ToString();
            _Date = DateTime.Parse(objDR["DiscountDate"].ToString());
            _Value = double.Parse(objDR["DiscountValue"].ToString());
            if (objDR["TypeID"].ToString() != "")
                _TypeID = int.Parse(objDR["TypeID"].ToString());
            
        }
        #endregion

        #region Public Methods
        public void Add()
        {
            double Date = _Date.ToOADate() - 2;
            InstallmentPaymentDb objDb = new InstallmentPaymentDb();
            objDb.InstallmentID = _InstallmentID;
            string strInstallmentPaymentDiscount = objDb.InstallmentPaymentDiscountStr ;
            string strSql = " begin transaction  Trans1; ";
            strSql +=" INSERT INTO CRMReservationInstallmentDiscount" +
                            " ( InstallmentID, DiscountValue, DiscountReason, DiscountDate,TypeID,UsrIns, TimIns)" +
                  
                            " VALUES     (" + _InstallmentID + "," + _Value + ",'" + _Reason + "'," + Date + "," + _TypeID +
                            "," + SysData.CurrentUser.ID  +  ",GetDate()) ";

            strSql += " declare @InstallmentCount int  " +
                            " set @InstallmentCount = (" + strInstallmentPaymentDiscount + "); " +
                            " if @InstallmentCount >0  goto rolLine ; ";

            strSql += " commitline: commit transaction Trans1;select  1 as exp1 ; return ; ";
            strSql += " rolLine: RollBack TRAN Trans1 ;select  -1 as exp1 ;";

            _ID = SysData.SharpVisionBaseDb.InsertIdentityTable(strSql);

        }
        public void Edit()
        {
            double Date = _Date.ToOADate() - 2;
            InstallmentPaymentDb objDb = new InstallmentPaymentDb();
            objDb.InstallmentID = _InstallmentID;
            string strInstallmentPaymentDiscount = objDb.InstallmentPaymentDiscountStr;
            string strSql = " begin transaction  Trans1; ";
            strSql+=" UPDATE    CRMReservationInstallmentDiscount" +
                             " SET  InstallmentID =" + _InstallmentID + "" +
                             " , DiscountValue =" + _Value + "" +
                             " , DiscountReason ='" + _Reason + "'" +
                             " , DiscountDate =" + Date + "" +
                             " , TypeID = " + _TypeID + "" +
                             " WHERE  InstallmentID =" + _InstallmentID + " and   (DiscountID = " + _ID + ") ";
            strSql += " declare @InstallmentCount int  " +
                          " set @InstallmentCount = (" + strInstallmentPaymentDiscount + "); " +
                          " if @InstallmentCount >0  goto rolLine ; ";

            strSql += " commitline: commit transaction Trans1;select  1 as exp1 ; return ; ";
            strSql += " rolLine: RollBack TRAN Trans1 ;select  -1 as exp1 ;";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);

        }

       

        public void Delete()
        {
            string strSql = InverseStr ;
                strSql+= " DELETE FROM CRMReservationInstallmentDiscount  WHERE  "+
                "InstallmentID =" + _InstallmentID + " and     (DiscountID = " + _ID +
                ") and (DiscountSourceID=0) and (DiscountReverseID=0) ";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public DataTable Search()
        {
            string strSql = SearchStr;
            if ((_ReservationIDs == null && _ReservationIDs == "") && (_InstallmentIDs == null || _InstallmentIDs == "") && _InstallmentID == 0)
            {
                if (_MaxID == 0 && _MinID == 0)
                {
                    string strCountSql = "select count(*) as ResultCount,sum(DiscountValue) as ResultValue from (" +
                        strSql + ")  AS NativeTable ";
                    DataTable dtReultTemp = SysData.SharpVisionBaseDb.ReturnDatatable(strCountSql);
                    if (dtReultTemp.Rows.Count > 0)
                    {
                        _ResultCount = int.Parse(dtReultTemp.Rows[0]["ResultCount"].ToString());
                        if (dtReultTemp.Rows[0]["ResultValue"].ToString() != "")
                            _ResultValue = double.Parse(dtReultTemp.Rows[0]["ResultValue"].ToString());
                    }


                }
                else
                {
                    if (_MaxID != 0)
                        strSql += " and dbo.CRMReservationInstallmentDiscount.DiscountID >" + _MaxID;
                    else if (_MinID != 0)
                    {
                        strSql += " and dbo.CRMReservationInstallmentDiscount.DiscountID<" + _MinID;
                    }
                }
            }
            strSql = "select distinct top 1000 * from (" + strSql + ") as NativeTable " +
                        " ORDER BY DiscountID "; 
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql,"InstallmentDiscount");

        }

        public void CreateTransaction()
        {
            if (_TransactionTable == null || _TransactionTable.Rows.Count == 0)
                return;
            string[] arrStr = new string[_TransactionTable.Rows.Count];
            string strTemp = "";
            int intIndex = 0;
            DataRow[] arrDr;

            foreach (DataRow objDr in _TransactionTable.Rows)
            {

                TransactionDb objTransactionDb = new TransactionDb(objDr);
                strTemp = objTransactionDb.AddStr;
                strTemp += " declare @TransactionID int; ";
                strTemp += " set @TransactionID = (select @@Identity as TransactionID); ";
                strTemp += "update CRMReservationInstallmentDiscount set  GLTransaction=@TransactionID " +
                    " where InstallmentID="+ objDr["InstallmentID"].ToString() +" and DiscountID= " + objDr["DiscountID"].ToString();



                arrStr[intIndex] = strTemp;
                intIndex++;

            }
            SysData.SharpVisionBaseDb.ExecuteNonQuery(arrStr);
        }

        #endregion
    }
}
