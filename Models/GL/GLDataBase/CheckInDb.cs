using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.SystemBase;
using SharpVision.Base.BaseDataBase;

namespace SharpVision.GL.GLDataBase
{
    public class CheckInDb :CheckDb
    {
        #region Private Data
        protected int _ID;
        protected int _BankID;
        protected DateTime _EntryDate;
        #endregion

        #region Constructors
        public CheckInDb()
        { 

        }
        public CheckInDb(int intID)
        {
            _ID = intID;
            DataTable dtTemp = Search();
            DataRow objDR = dtTemp.Rows[0];
            _BankID = int.Parse(objDR["CheckBankID"].ToString());
            _EntryDate = DateTime.Parse(objDR["CheckEntryDate"].ToString());
        }
        public CheckInDb(DataRow objDR)
        {
            _ID = int.Parse(objDR["CheckID"].ToString());
            _BankID = int.Parse(objDR["CheckBankID"].ToString());
            _EntryDate = DateTime.Parse(objDR["CheckEntryDate"].ToString());

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
        public int BankID
        {
            set
            {
                _BankID = value;
            }
            get
            {
                return _BankID;
            }
        }
        public DateTime EntryDate
        {
            set
            {
                _EntryDate = value;
            }
            get
            {
                return _EntryDate;
            }
        }
        public static string SearchStr
        {
            get
            {
                string Returned = " SELECT  CheckID as CheckInID,CheckBankID, CheckEntryDate "+
                          " FROM  dbo.GLCheckIn";
                return Returned;
            }
        }
        #endregion
        #region Private Methods

        #endregion
        #region Public Methods
        public void Add()
        {
            double dblEntryDate = _EntryDate.ToOADate() - 2;
            string strSql = " INSERT INTO GLCheckIn"+
                            " (CheckBankID, CheckEntryDate)"+
                            " VALUES     (" + _BankID + "," + dblEntryDate + ") ";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public void Edit()
        {
            double dblEntryDate = _EntryDate.ToOADate() - 2;
            string strSql = " UPDATE    GLCheckIn" +
                            " SET    CheckBankID =" + _BankID + "" +
                            " , CheckEntryDate = " + dblEntryDate + "" +
                            " Where CheckID = " + _ID + "";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public void Delete()
        {
            string strSql = " DELETE FROM GLCheckIn WHERE     (CheckID = "+_ID+") ";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);

        }
        public DataTable Search()
        {
            string strSql = SearchStr + " WHERE  (1 = 1)";
            if (_ID != 0)
                strSql = strSql + " and CheckBankID = " + _ID.ToString();
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        #endregion
    }
}
