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
    public class JobNatureTypeDb : BaseSingleDb
    {
        #region Private Data
        string _NameAComp;
        bool _VIP;
        bool _RelatedBySkeleton;
        int _JobID;
        int _JobNatureIDSearch;
        string _NameACompSearch;
        int _JobCategory;
        string _IDs;
        byte _JobCategoryEstimation;
        #endregion
        #region Constructors
        public JobNatureTypeDb()
        {

        }

        public JobNatureTypeDb(int intID)
        {
            _ID = intID;
            if (_ID != 0)
            {
                DataTable dtTemp = Search();
                DataRow objDR = Search().Rows[0];
                SetData(objDR);
            }
        }
        public JobNatureTypeDb(DataRow objDR)
        {
            //_JobDb = DR;
            SetData(objDR);

        }
        public JobNatureTypeDb(int intID, string strName)
        {
            //_JobDb = DR;
            ID = intID;
            //Name = strName;

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
            get
            {
                return _NameACompSearch;
            }
        }
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
        public bool RelatedBySkeleton
        {
            set
            {
                _RelatedBySkeleton = value;
            }
            get
            {
                return _RelatedBySkeleton;
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
        public int JobCategory
        {
            set
            {
                _JobCategory = value;
            }
            get
            {
                return _JobCategory;
            }
        }
        public int JobNatureIDSearch
        {
            set
            {
                _JobNatureIDSearch = value;
            }
            get
            {
                return _JobNatureIDSearch;
            }
        }
        public string IDs
        {
            set
            {
                _IDs = value;
            }
        }
        public byte JobCategoryEstimation
        {
            set
            {
                _JobCategoryEstimation = value;
            }
            get
            {
                return _JobCategoryEstimation;
            }
        }
        public static string SearchStr
        {
            get
            {
                string Returned = @"  SELECT HRJobNatureType.JobNatureID, HRJobNatureType.JobNatureNameA,HRJobNatureType.JobNatureNameAComp,HRJobNatureType.JobNatureNameE,HRJobNatureType.JobID as JobTypeID_NatureFK ,HRJobNatureType.JobRelatedBySkeleton,HRJobNatureType.VIP as JobNatureTypeVIPVIP "+
                                   " ,HRJobNatureType.JobCategory,JobCategoryTable.* FROM HRJobNatureType " +
                                   " Left outer Join (" + JobCategoryDb.SearchStr + ") as JobCategoryTable On JobCategoryTable.JobCategoryID = HRJobNatureType.JobCategory";
                return Returned;
            }
        }
        #endregion
        #region Private Methods
        void SetData(DataRow objDR)
        {
            if (objDR["JobNatureID"].ToString() == "")
                return;
            _ID = int.Parse(objDR["JobNatureID"].ToString());
            _NameA = objDR["JobNatureNameA"].ToString();
            _NameE = objDR["JobNatureNameE"].ToString();
            _NameAComp = objDR["JobNatureNameAComp"].ToString();
            _VIP = bool.Parse(objDR["JobNatureTypeVIPVIP"].ToString());
            _RelatedBySkeleton = bool.Parse(objDR["JobRelatedBySkeleton"].ToString());
            if (objDR["JobTypeID_NatureFK"].ToString() != "")
                _JobID = int.Parse(objDR["JobTypeID_NatureFK"].ToString());
            if (objDR["JobCategory"].ToString() != "")
                _JobCategory = int.Parse(objDR["JobCategory"].ToString());
        }
        #endregion
        #region Public Methods
        public override void Add()
        {
            int intVIP = _VIP ? 1 : 0;
            int intRelatedBySkeleton = _RelatedBySkeleton ? 1 : 0;
            string strSql = "insert into HRJobNatureType (JobNatureNameA,JobNatureNameE,JobNatureNameAComp,JobID,JobRelatedBySkeleton,VIP,JobCategory,UsrIns,TimIns) " +
            "values('" + _NameA + "','" + _NameE + "','" + _NameAComp + "'," + _JobID + "," + intRelatedBySkeleton + "," + intVIP + "," + _JobCategory + "," + SysData.CurrentUser.ID + ",Getdate())";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
            //_ID = Convert.ToInt32(SysData.SharpVisionBaseDb.ReturnScalar(strSql));



        }
        public override void Edit()
        {
            int intVIP = _VIP ? 1 : 0;
            int intRelatedBySkeleton = _RelatedBySkeleton ? 1 : 0;
            string strSql = "update  HRJobNatureType ";
            strSql = strSql + " set JobNatureNameA ='" + _NameA + "'";
            strSql = strSql + " , JobNatureNameE ='" + _NameE + "'";
            strSql = strSql + " , JobNatureNameAComp ='" + _NameAComp + "'";
            strSql = strSql + " , VIP =" + intVIP;
            strSql = strSql + " , JobRelatedBySkeleton =" + intRelatedBySkeleton;
            strSql = strSql + " , JobID =" + _JobID;
            strSql = strSql + " , JobCategory =" + _JobCategory;
            strSql = strSql + ",UsrUpd = " + SysData.CurrentUser.ID;
            strSql = strSql + ",TimUpd =Getdate() ";
            strSql = strSql + " where JobNatureID = " + _ID;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public override void Delete()
        {
            string strSql = "update HRJobNatureType set Dis = GetDate() where JobNatureID=" + _ID;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }

        public override DataTable Search()
        {
            string strSql = SearchStr + " WHERE    (HRJobNatureType.Dis IS NULL)";
            if (_ID != 0)
                strSql = strSql + " and JobNatureID = " + _ID.ToString();
            //if (_JobNatureIDSearch != 0)
            //    strSql = strSql + " and JobNatureID <> " + _JobNatureIDSearch.ToString();
            if (_JobID != 0)
                strSql = strSql + " and JobID = " + _JobID.ToString();
            if(_JobNatureIDSearch!=0)
                strSql = strSql + " and JobNatureID <> " + _JobNatureIDSearch.ToString();
            if (_NameACompSearch != null && _NameACompSearch!="")
                strSql = strSql + " and JobNatureNameAComp like '" + _NameACompSearch + "'  ";
            else if (_NameAComp != "" && _NameAComp != null)
                strSql = strSql + " and JobNatureNameAComp like '%" + _NameAComp + "%'  ";

             if (_IDs != "" && _IDs != null)
                strSql = strSql + " and JobNatureID in (" + _IDs + ")";
            if (_JobCategoryEstimation != 0)
            {
                if (_JobCategoryEstimation == 1)
                {
                    strSql += " And JobNatureID in (SELECT JobNature FROM HRJobCategoryEstimationJobNature)";
                }
                else if (_JobCategoryEstimation == 2)
                {
                    strSql += " And JobNatureID not in (SELECT JobNature FROM HRJobCategoryEstimationJobNature)";
                }
            }

            strSql = strSql + " Order by HRJobNatureType.JobNatureNameAComp";
            //strSql = strSql + " Order by JobCategoryTable.OrderValue,HRJobNatureType.JobCategory,HRJobNatureType.JobNatureNameAComp";
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        #endregion
    }
}
