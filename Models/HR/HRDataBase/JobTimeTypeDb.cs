using System;
using System.Collections.Generic;
using System.Text;

using SharpVision.SystemBase;
using System.Data;
using System.Data.SqlClient;
using SharpVision.Base.BaseDataBase;

namespace SharpVision.COMMON.COMMONDataBase
{
    public class JobTimeTypeDb : BaseSingleDb
    {
        #region Private Data
        protected string _NameAComp;
        protected string _NameEComp;
        string _NameACompSearch;
        string _NameECompSearch;
        int _JobTimeTypeIDSearch;
        #endregion
        #region Constructors
        public JobTimeTypeDb()
        {
        }
        public JobTimeTypeDb(int intID)
        {
            _ID = intID;
            DataTable dtTemp = Search();
            if (dtTemp.Rows.Count != 0)
                SetData(dtTemp.Rows[0]);
        }
        public JobTimeTypeDb(DataRow objDR)
        {
            SetData(objDR);
        }
        #endregion

        #region Public Properties
        public string NameAComp
        {
            set
            {
                _NameAComp = value;
            }
            get
            {
                return _NameAComp;
            }
        }
        public string NameACompSearch
        {
            set
            {
                _NameACompSearch = value;
            }            
        }
        public string NameEComp
        {
            set
            {
                _NameEComp = value;
            }
            get
            {
                return _NameEComp;
            }
        }
        public string NameECompSearch
        {
            set
            {
                _NameECompSearch = value;
            }
        }
        public int JobTimeTypeIDSearch
        {
            set
            {
                _JobTimeTypeIDSearch = value;
            }
        }
        public static string SearchStr
        {
            get
            {
                string Returned = @" SELECT COMMONJobTimeType.JobTimeTypeID, COMMONJobTimeType.JobTimeTypeNameA,COMMONJobTimeType.JobTimeTypeNameE,"+
                                   " COMMONJobTimeType.JobTimeTypeNameAComp,COMMONJobTimeType.JobTimeTypeNameEComp from COMMONJobTimeType";
                return Returned;

            }
        }
        #endregion

        #region Private Methods
        void SetData(DataRow objDR)
        {
            if (objDR.Table.Columns["JobTimeTypeID"] == null ||objDR["JobTimeTypeID"].ToString() == "")
                return;
            _ID = int.Parse(objDR["JobTimeTypeID"].ToString());
            _NameA = objDR["JobTimeTypeNameA"].ToString();
            _NameE = objDR["JobTimeTypeNameE"].ToString();
            _NameAComp = objDR["JobTimeTypeNameAComp"].ToString();
            _NameEComp = objDR["JobTimeTypeNameEComp"].ToString();
        }
        #endregion

        #region Public Methods
        public override void Add()
        {
            string strSql = "insert into COMMONJobTimeType (JobTimeTypeNameA,JobTimeTypeNameE,JobTimeTypeNameAComp,JobTimeTypeNameEComp,UsrIns,TimIns) " +
            "values('" + _NameA + "','" + _NameE + "','" + _NameAComp + "','" + _NameEComp + "'," + SysData.CurrentUser.ID + ",Getdate())";
            //SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
            _ID = Convert.ToInt32(SysData.SharpVisionBaseDb.ReturnScalar(strSql));
        }
        public override void Edit()
        {
            string strSql = "update  COMMONJobTimeType ";
            strSql = strSql + " set JobTimeTypeNameA ='" + _NameA + "'";
            strSql = strSql + ", JobTimeTypeNameE ='" + _NameE + "'";
            strSql = strSql + ", JobTimeTypeNameAComp ='" + _NameAComp + "'";
            strSql = strSql + ", JobTimeTypeNameEComp ='" + _NameEComp + "'";
            strSql = strSql + ",UsrUpd = " + SysData.CurrentUser.ID;
            strSql = strSql + ",TimUpd =Getdate() ";
            strSql = strSql + " where JobTimeTypeID = " + _ID;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public override void Delete()
        {
            string strSql = "update COMMONJobTimeType set Dis = GetDate() where JobTimeTypeID=" + _ID;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public override DataTable Search()
        {
            string strSql = SearchStr + " WHERE    (COMMONJobTimeType.Dis IS NULL)";
            if (_ID != 0)
                strSql = strSql + " and JobTimeTypeID = " + _ID.ToString();
            if (_JobTimeTypeIDSearch != 0)
                strSql = strSql + " and JobTimeTypeID <> " + _JobTimeTypeIDSearch.ToString();
            if (_NameACompSearch != null && _NameACompSearch != "")
                strSql = strSql + " and JobTimeTypeNameAComp like '" + _NameACompSearch + "'  ";
            else if (_NameAComp != "" && _NameAComp != null)
                strSql = strSql + " and JobTimeTypeNameAComp like '%" + _NameAComp + "%'  ";

            if (_NameECompSearch != null && _NameECompSearch != "")
                strSql = strSql + " and JobTimeTypeNameEComp like '" + _NameECompSearch + "'  ";
            else if (_NameEComp != "" && _NameEComp != null)
                strSql = strSql + " and JobTimeTypeNameEComp like '%" + _NameEComp + "%'  ";



            strSql = strSql + " Order by JobTimeTypeID";
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql, "JobTimeType");
        }
        #endregion
    }
}
