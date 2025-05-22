using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SharpVision.SystemBase;
using System.Data;
 namespace AlgorithmatMVC.Models.MN.MNDb
{
    public class MaintainanceTempPaymentDb
    {
        #region Private Data
        
       
        #endregion
        #region Constructors
        public MaintainanceTempPaymentDb()
        { }
        public MaintainanceTempPaymentDb(DataRow objdr)
        {
            SetData(objdr);
        }
        #endregion
        #region Public Properties
       int _ID;
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
        DateTime _Date;
        public DateTime  Date
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
        double _Value;
        public double Value
        { set => _Value = value; get => _Value; }
        int _ROID;
        public int ROID
        { set => _ROID = value; get => _ROID; }
        public string AddStr
        {
            get
            {
                string Returned = "";
                return Returned;
            }
        }
        public string EditStr
        {
            get
            {
                string Returned = "";
                return Returned;
            }
        }
        public string DeleteStr
        {
            get
            {
                string Returned = "";
                return Returned;
            }
        }
        public static string SearchStr
        {
            get
            {
                string Returned = "";
                return Returned;
            }
        }
#endregion
        #region Private Methods
        void SetData(DataRow objDr)
        {

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