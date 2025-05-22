using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.SystemBase;
using SharpVision.Base.BaseDataBase;
using SharpVision.UMS.UMSDataBase;
namespace SharpVision.GL.GLDataBase
{
    public class CheckPrintDb
    {
        #region Private Data
        int _ID;

      
        int _CheckID;
        int _Model;
        DateTime _Date;

        int _Employee;

        string _EmployeeName;

     
        int _Status;

      

        #endregion
        #region Constructors
        public CheckPrintDb()
        { }
        public CheckPrintDb(DataRow objDr)
        {
            SetData(objDr);
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
        public int CheckID
        {
            set
            {
                _CheckID = value;
            }
            get
            {
                return _CheckID;
            }
        }
        public int Model
        {
            set
            {
                _Model = value;
            }
            get
            {
                return _Model;
            }
        }

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
        public int Employee
        {
            set
            {
                _Employee = value;
            }
            get
            {
                return _Employee;
            }

        }
        public string EmployeeName
        {
            
          
            get 
            {
                return _EmployeeName;
            }
        }
        public int Status
        {
            set
            {
                _Status = value; 
            }
            get
            {
                return _Status;
            }
            
        }
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
                string strEmployeeName = "SELECT  ApplicantID AS PrintEmployeeID, ApplicantFirstName AS PrintEmployeeName "+
                       " FROM    dbo.HRApplicant ";
                string Returned = "SELECT   PrintID,PrintCheckID, PrintCheckModel, PrintDate, PrintEmployee, PrintStatus "+
                    ",EmployeeTable.* "+
                       " FROM  dbo.GLCheckPrint "+
                       " left outer join ("+ strEmployeeName+") as EmployeeTable "+
                       " on dbo.GLCheckPrint.PrintEmployee = EmployeeTable.PrintEmployeeID "; 
                return Returned;
            }
        }
        #endregion
        #region Private Methods
        void SetData(DataRow objDr)
        {
            _ID = int.Parse(objDr["PrintID"].ToString());

            _CheckID = int.Parse(objDr["PrintCheckID"].ToString());
            _Model = int.Parse(objDr["PrintCheckModel"].ToString());
            _Date = DateTime.Parse(objDr["PrintDate"].ToString());
            _Employee = int.Parse(objDr["PrintEmployee"].ToString());
            _EmployeeName = objDr["PrintEmployeeName"].ToString();
            _Status = int.Parse(objDr["PrintStatus"].ToString());
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
            string strSql = SearchStr + " where (1=1) ";
            if (_CheckID != 0)
                strSql += " and PrintCheckID = " +_CheckID;

            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        #endregion
    }
}
