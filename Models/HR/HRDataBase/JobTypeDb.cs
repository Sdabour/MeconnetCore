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
    public class JobTypeDb : BaseSingleDb
    {
        #region Private Data        
        bool _VIP;
        #endregion
        #region Constructors
        public JobTypeDb()
        {

        }

        public JobTypeDb(int intID)
        {
            _ID = intID;
            if (_ID != 0)
            {
                DataTable dtTemp = Search();
                DataRow objDR = Search().Rows[0];
                SetData(objDR);
            }


        }
        public JobTypeDb(DataRow objDR)
        {
            //_JobDb = DR;
            SetData(objDR);

        }
        public JobTypeDb(int intID, string strName)
        {
            _ID = intID;
            _NameA = strName;
            //DataTable dtTemp = Search();
            //DataRow objDR = Search().Rows[0];
            //SetData(objDR);

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
                string Returned = @" SELECT HRJobType.JobID, HRJobType.JobNameA,HRJobType.JobNameE,HRJobType.VIP as JobTypeVIP
                                     FROM HRJobType ";
                return Returned;

            }
        }
        #endregion
        #region Private Methods
        void SetData(DataRow objDR)
        {
            if (objDR["JobID"].ToString() == "")
                return;
            _ID = int.Parse(objDR["JobID"].ToString());
            _NameA = objDR["JobNameA"].ToString();
            _NameE = objDR["JobNameE"].ToString();
            _VIP = bool.Parse(objDR["JobTypeVIP"].ToString());
            
            
        }
        #endregion
        #region Public Methods
        public override void Add()
        {
            int intVIP = _VIP ? 1 : 0;
            string strSql = "insert into HRJobType (JobNameA,JobNameE,VIP,UsrIns,TimIns) " +
            "values('" + _NameA + "','" + _NameE + "'," + intVIP + "," + SysData.CurrentUser.ID + ",Getdate())";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
            //_ID = Convert.ToInt32(SysData.SharpVisionBaseDb.ReturnScalar(strSql));



        }
        public override void Edit()
        {
            int intVIP = _VIP ? 1 : 0;
            string strSql = "update  HRJobType ";
            strSql = strSql + " set JobNameA ='" + _NameA + "'";
            strSql = strSql + " , JobNameE ='" + NameE + "'";            
            strSql = strSql + " , VIP =" + intVIP;
            strSql = strSql + ",UsrUpd = " + SysData.CurrentUser.ID;
            strSql = strSql + ",TimUpd =Getdate() ";
            strSql = strSql + " where JobID = " + _ID;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public override void Delete()
        {
            string strSql = "update HRJobType set Dis = GetDate() where JobID=" + _ID;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }

        public override DataTable Search()
        {
            string strSql = SearchStr + " WHERE    (HRJobType.Dis IS NULL)";
            if (_ID != 0)
                strSql = strSql + " and JobID = " + _ID.ToString();
            //if (_Name != "" && _Name != null)
            //    strSql = strSql + " and JobName = '" + _Name + "'  ";

            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        #endregion
    }
}
