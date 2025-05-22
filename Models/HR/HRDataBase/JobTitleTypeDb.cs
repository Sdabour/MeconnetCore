using System;
using System.Collections.Generic;
using System.Text;
//using SharpVision.UMS.UMSDataBase;
using SharpVision.SystemBase;
using System.Data;
using System.Data.SqlClient;
using SharpVision.Base.BaseDataBase;

namespace SharpVision.HR.HRDataBase
{
    public class JobTitleTypeDb : BaseSingleDb
    {
        #region Private Data
        bool _VIP;
        int _JobID;
        #endregion
        #region Constructors
        public JobTitleTypeDb()
        {

        }

        public JobTitleTypeDb(int intID)
        {
            _ID = intID;
            if (_ID != 0)
            {
                DataTable dtTemp = Search();
                DataRow objDR = Search().Rows[0];
                SetData(objDR);
            }
        }
        public JobTitleTypeDb(DataRow objDR)
        {
            //_JobDb = DR;
            SetData(objDR);
        }
        public JobTitleTypeDb(int intID, string strName)
        {
            //_JobDb = DR;
            ID = intID;
            //Name = strName;
        }

        #endregion
        #region Public Properties

        public bool VIP
        {
            set
            {
                _VIP = value;
            }
            get
            {
                return _VIP;
            }
        }
        public int JobID
        {
            set
            {
                _JobID = value;
            }
            get
            {
                return _JobID;
            }
        }
        public static string SearchStr
        {
            get
            {
                string Returned = @" SELECT HRJobTitleType.JobTitleID, HRJobTitleType.JobTitleNameA,HRJobTitleType.JobTitleNameE,HRJobTitleType.JobID as JobTypeID_TitleFK,HRJobTitleType.VIP as JobTitleTypeVIP  
                                     FROM HRJobTitleType ";
                return Returned;

            }
        }
        #endregion
        #region Private Methods
        void SetData(DataRow objDR)
        {
            if (objDR["JobTitleID"].ToString() == "")
                return;
            _ID = int.Parse(objDR["JobTitleID"].ToString());
            _NameA = objDR["JobTitleNameA"].ToString();
            _NameE = objDR["JobTitleNameE"].ToString();
            _VIP = bool.Parse(objDR["JobTitleTypeVIP"].ToString());
            if (objDR["JobTypeID_TitleFK"].ToString() != "")
                _JobID = int.Parse(objDR["JobTypeID_TitleFK"].ToString());
        }
        #endregion
        #region Public Methods
        public override void Add()
        {
            int intVIP = _VIP ? 1 : 0;
            string strSql = "insert into HRJobTitleType (JobTitleNameA,JobTitleNameE,JobID,VIP,UsrIns,TimIns) " +
            "values('" + _NameA + "','" + _NameE + "',"+ _JobID +"," + intVIP + "," + SysData.CurrentUser.ID + ",Getdate())";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
            //_ID = Convert.ToInt32(SysData.SharpVisionBaseDb.ReturnScalar(strSql));



        }
        public override void Edit()
        {
            int intVIP = _VIP ? 1 : 0;
            string strSql = "update  HRJobTitleType ";
            strSql = strSql + " set JobTitleNameA ='" + _NameA + "'";
            strSql = strSql + " , JobTitleNameE ='" + NameE + "'";
            strSql = strSql + " , VIP =" + intVIP;
            strSql = strSql + " , JobID =" + _JobID;
            strSql = strSql + ",UsrUpd = " + SysData.CurrentUser.ID;
            strSql = strSql + ",TimUpd =Getdate() ";
            strSql = strSql + " where JobTitleID = " + _ID;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public override void Delete()
        {
            string strSql = "update HRJobTitleType set Dis = GetDate() where JobTitleID=" + _ID;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }

        public override DataTable Search()
        {
            string strSql = SearchStr + " WHERE    (HRJobTitleType.Dis IS NULL)";
            if (_ID != 0)
                strSql = strSql + " and JobTitleID = " + _ID.ToString();
            if (_JobID != 0)
                strSql = strSql + " and JobID = " + _JobID.ToString();
            //if (_Name != "" && _Name != null)
            //    strSql = strSql + " and JobName = '" + _Name + "'  ";

            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        #endregion
    }
}
