using System;
using System.Collections.Generic;
using System.Text;
//using SharpVision.UMS.UMSDataBase;
using SharpVision.SystemBase;
using System.Data;
using System.Data.SqlClient;
using SharpVision.Base.BaseDataBase;

namespace SharpVision.COMMON.COMMONDataBase
{
    public class JobDb : BaseSingleDb
    {
        #region Private Data
        int _JobTitleID;
        bool _VIP;
        #endregion
        #region Constructors
        public JobDb()
        {

        }

        public JobDb(int intID)
        {
            _ID = intID;
            DataTable dtTemp = Search();
            if (dtTemp.Rows.Count != 0)
            {
                DataRow objDR = dtTemp.Rows[0];
                SetData(objDR);
            }

        }
        public JobDb(DataRow objDR)
        {
            //_JobDb = DR;
            SetData(objDR);

        }
        public JobDb(int intID, string strName)
        {
            _ID = intID;
            _NameA = strName;
            //DataTable dtTemp = Search();
            //if (dtTemp.Rows.Count != 0)
            //{
            //    DataRow objDR = dtTemp.Rows[0];
            //    SetData(objDR);
            //}

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
        public int JobTitleID
        {
            set
            {
                _JobTitleID = value;
            }
            get
            {
                return _JobTitleID;
            }
        }
        public static string SearchStr
        {
            get
            {
                string Returned = @" SELECT COMMONJob.JobID, COMMONJob.JobNameA,COMMONJob.JobNameE,COMMONJob.VIP,COMMONJob.JobTitleID as JobTitle
                                     FROM COMMONJob ";
                return Returned;

            }
        }
        #endregion
        #region Private Methods
        void SetData(DataRow objDR)
        {
            _ID = int.Parse(objDR["JobID"].ToString());
            _NameA = objDR["JobNameA"].ToString();
            _NameE = objDR["JobNameE"].ToString();
            _VIP = bool.Parse(objDR["VIP"].ToString());
            if (objDR["JobTitle"].ToString() != "")
                _JobTitleID = int.Parse(objDR["JobTitle"].ToString());
            else
                _JobTitleID = 0;
        }
        #endregion
        #region Public Methods
        public override void Add()
        {
            int intVIP = _VIP ? 1 : 0;
            string strSql = "insert into COMMONJob (JobNameA,JobNameE,JobTitleID,VIP,UsrIns,TimIns) " +
            "values('" + _NameA + "','" + _NameE + "',"+ _JobTitleID +"," + intVIP + "," + SysData.CurrentUser.ID + ",Getdate())";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
            //_ID = Convert.ToInt32(SysData.SharpVisionBaseDb.ReturnScalar(strSql));



        }
        public override void Edit()
        {
            int intVIP = _VIP ? 1 : 0;
            string strSql = "update  COMMONJob ";
            strSql = strSql + " set JobNameA ='" + _NameA + "'";
            strSql = strSql + " , JobNameE ='" + NameE + "'";
            strSql = strSql + " , JobTitleID =" + _JobTitleID;
            strSql = strSql + " , VIP =" + intVIP;
            strSql = strSql + ",UsrUpd = " + SysData.CurrentUser.ID;
            strSql = strSql + ",TimUpd =Getdate() ";
            strSql = strSql + " where JobID = " + _ID;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public override void Delete()
        {
            string strSql = "update COMMONJob set Dis = GetDate() where JobID=" + _ID;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }

        public override DataTable Search()
        {
            string strSql = SearchStr + " WHERE    (COMMONJob.Dis IS NULL)";
            if (_ID != 0)
                strSql = strSql + " and JobID = " + _ID.ToString();
            //if (_Name != "" && _Name != null)
            //    strSql = strSql + " and JobName = '" + _Name + "'  ";
            strSql += " Order By JobNameA";
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        #endregion
    }
}
