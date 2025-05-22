using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using SharpVision.Base.BaseDataBase;

namespace SharpVision.UMS.UMSDataBase
{
    public class EmployeeDepartmentDb
    {
        #region Private Data
        int _EmployeeID;
        int _DepartmentID;
        string _JobNatureName;
        string _EmployeeIDs;
        List<string> _ArrEmployeeIDs;
        #endregion
        #region Constructors
        public EmployeeDepartmentDb()
        { }
        public EmployeeDepartmentDb(DataRow objDr)
        {
            SetData(objDr);
        }
        #endregion
        #region Public Properties
        public int EmployeeID
        {
            set
            {
                _EmployeeID = value;
            }
            get
            {
                return _EmployeeID;
            }
        }
        public int DepartmentID
        {
            set
            {
                _DepartmentID = value;
            }
            get
            {
                return _DepartmentID;
            }
        }
        public string JobNatureName
        {
            set
            {
                _JobNatureName = value;
            }
            get
            {
                return _JobNatureName;
            }
        }
        public string EmployeeIDs
        {
            set
            {
                _EmployeeIDs = value;
            }
        }
        public List<string> ArrEmployeeStr
        {
            set
            {
                _ArrEmployeeIDs = value;
            }
        }
        public static string SearchStr
        {
            get
            {
                string Returned = "SELECT     dbo.HRApplicantWorkerCurrentSubSector.ApplicantID AS Employee, dbo.HRSubSector.SectorID AS Department,"+ 
                      " dbo.HRJobNatureType.JobNatureNameA, dbo.HRJobTitleType.JobTitleNameA "+
                      " FROM  dbo.HRApplicantWorkerCurrentSubSector left outer JOIN "+
                      " dbo.HRJobNatureType ON dbo.HRApplicantWorkerCurrentSubSector.JobNatureID = dbo.HRJobNatureType.JobNatureID INNER JOIN "+
                      " dbo.HRSubSector ON dbo.HRApplicantWorkerCurrentSubSector.SubSectorID = dbo.HRSubSector.SubSectorID LEFT OUTER JOIN "+
                      " dbo.HRJobTitleType ON dbo.HRApplicantWorkerCurrentSubSector.JobTitleID = dbo.HRJobTitleType.JobTitleID ";
                return Returned;
            }
        }
        #endregion
        #region Private Methods
        void SetData(DataRow objDr)
        {
            _EmployeeID = int.Parse(objDr["Employee"].ToString());
            _DepartmentID = int.Parse(objDr["Department"].ToString());
            _JobNatureName = objDr["JobNatureNameA"].ToString();
        }
        #endregion
        #region Public Methods
        public DataTable Search()
        {
            DataTable Returned ;
            string strSql = SearchStr + " where (1=1) ";

            if (_EmployeeIDs != null && _EmployeeIDs != "")
                strSql += " and (dbo.HRApplicantWorkerCurrentSubSector.ApplicantID in ("+ _EmployeeIDs +"))";
            if (_ArrEmployeeIDs != null && _ArrEmployeeIDs.Count > 0)
            {
                string strIDs = _ArrEmployeeIDs[0];
                string strTempSql = strSql + " and (dbo.HRApplicantWorkerCurrentSubSector.ApplicantID in (" + strIDs + "))";
                Returned = BaseDb.UMSBaseDb.ReturnDatatable(strTempSql);
                if (_ArrEmployeeIDs.Count > 1)
                {
                    DataTable dtTemp;
                    for (int intIndex = 1; intIndex < _ArrEmployeeIDs.Count; intIndex++)
                    {
                        strIDs = _ArrEmployeeIDs[intIndex];
                        strTempSql = strSql + " and (dbo.HRApplicantWorkerCurrentSubSector.ApplicantID in (" + strIDs + "))";
                        dtTemp = BaseDb.UMSBaseDb.ReturnDatatable(strTempSql);
                        DataRow objTempDr ;
                        foreach (DataRow objDr in dtTemp.Rows)
                        {
                            objTempDr = Returned.NewRow();
                            for (int intClIndex = 0; intClIndex < Returned.Columns.Count; intClIndex++)
                            {
                                objTempDr[intClIndex] = objDr[intClIndex];

                            }
                            Returned.Rows.Add(objTempDr);
                        }
                    }
                }
 
            }
            else
                Returned = BaseDb.UMSBaseDb.ReturnDatatable(strSql);
            return Returned;
        }
        #endregion
    }
}
