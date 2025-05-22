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
    public class JobTitleDb : BaseSingleDb
    {
        #region Private Data
        bool _VIP;
        #endregion
        #region Constructors
        public JobTitleDb()
        {

        }

        public JobTitleDb(int intID)
        {
            _ID = intID;
            DataTable dtTemp = Search();
            if (dtTemp.Rows.Count != 0)
            {
                DataRow objDR = dtTemp.Rows[0];
                SetData(objDR);
            }


        }
        public JobTitleDb(DataRow objDR)
        {
            //_JobDb = DR;
            SetData(objDR);

        }
        public JobTitleDb(int intID, string strName)
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

        public static string SearchStr
        {
            get
            {
                string Returned = @" SELECT COMMONJobTitle.JobTitleID, COMMONJobTitle.JobTitleNameA,COMMONJobTitle.JobTitleNameE,COMMONJobTitle.VIP as VIPVal  
                                     FROM COMMONJobTitle ";
                return Returned;

            }
        }
        #endregion
        #region Private Methods
        void SetData(DataRow objDR)
        {
            _ID = int.Parse(objDR["JobTitleID"].ToString());
            _NameA = objDR["JobTitleNameA"].ToString();
            _NameE = objDR["JobTitleNameE"].ToString();
            _VIP = bool.Parse(objDR["VIPVal"].ToString());
        }
        #endregion
        #region Public Methods
        public override void Add()
        {
            int intVIP = _VIP ? 1 : 0;
            string strSql = "insert into COMMONJobTitle (JobTitleNameA,JobTitleNameE,VIP,UsrIns,TimIns) " +
            "values('" + _NameA + "','" + _NameE + "'," + intVIP + "," + SysData.CurrentUser.ID + ",Getdate())";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
            //_ID = Convert.ToInt32(SysData.SharpVisionBaseDb.ReturnScalar(strSql));



        }
        public override void Edit()
        {
            int intVIP = _VIP ? 1 : 0;
            string strSql = "update  COMMONJobTitle ";
            strSql = strSql + " set JobTitleNameA ='" + _NameA + "'";
            strSql = strSql + " , JobTitleNameE ='" + NameE + "'";
            strSql = strSql + " , VIP =" + intVIP;
            strSql = strSql + ",UsrUpd = " + SysData.CurrentUser.ID;
            strSql = strSql + ",TimUpd =Getdate() ";
            strSql = strSql + " where JobTitleID = " + _ID;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public override void Delete()
        {
            string strSql = "update COMMONJobTitle set Dis = GetDate() where JobTitleID=" + _ID;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }

        public override DataTable Search()
        {
            string strSql = SearchStr + " WHERE    (COMMONJobTitle.Dis IS NULL)";
            if (_ID != 0)
                strSql = strSql + " and JobTitleID = " + _ID.ToString();
            //if (_Name != "" && _Name != null)
            //    strSql = strSql + " and JobName = '" + _Name + "'  ";

            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        #endregion
    }
}
