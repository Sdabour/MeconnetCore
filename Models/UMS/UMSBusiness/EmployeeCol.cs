using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.UMS.UMSDataBase;
using SharpVision.Base.BaseBusiness;
using System.Data;
using System.Collections;
//using SharpVision.SystemBase;
using SharpVision.Base.BaseDataBase;
namespace SharpVision.UMS.UMSBusiness
{
    public class EmployeeCol:CollectionBase
    {
        #region Private Data
        static EmployeeCol _EmployeeCol;
        Hashtable _EmployeeHs = new Hashtable();
        #endregion
        #region Constructors
        public EmployeeCol(bool blIsEmpty)
        {

 
        }
        public EmployeeCol(int intSectorID,int intID, string strCode, string strName,
            DepartmentBiz objDepartmentBiz, int intWorkingStatus)
        {
            if (objDepartmentBiz == null)
                objDepartmentBiz = new DepartmentBiz();
            EmployeeDb objDb = new EmployeeDb();
            objDb.SectorID = intSectorID;
            objDb.ID = intID;
            objDb.Code = strCode;
            objDb.Name = strName;
            objDb.DepartmentIDs = objDepartmentBiz.IDsStr;
            objDb.WorkingStatus = intWorkingStatus;
            EmployeeBiz objEmployeeBiz;
            DataTable dtTemp = objDb.Search();
            List<string> arrStrEmployee = BaseSingleDb.GetStringArr(dtTemp, "ApplicantID", 1000);
            EmployeeDepartmentDb objDepartmentDb = new EmployeeDepartmentDb();
            objDepartmentDb.ArrEmployeeStr = arrStrEmployee;
            DataTable dtDepartment = objDepartmentDb.Search();
            DataRow [] arrDepartmentDr;
            foreach (DataRow objDr in dtTemp.Rows)
            {
                objEmployeeBiz = new EmployeeBiz(objDr);

                arrDepartmentDr = dtDepartment.Select("Employee=" + objEmployeeBiz.ID);
                foreach (DataRow objDepartmentDr in arrDepartmentDr)
                {
                    objEmployeeBiz.EmployeeDepartmentCol.Add(new EmployeeDepartmentBiz(objDepartmentDr));
                }
                Add(objEmployeeBiz);
            }
 
        }
        public EmployeeCol()
        {
            EmployeeDb objDb = new EmployeeDb();
            DataTable dtTemp = objDb.Search();
            EmployeeBiz objBiz;
            foreach (DataRow objDr in dtTemp.Rows)
            {
                objBiz = new EmployeeBiz(objDr);
                Add(objBiz);
            }
        }
        #endregion
        #region Public Properties
        public EmployeeBiz this[int intIndex]
        {
            get
            {
                return (EmployeeBiz)List[intIndex];
            }
        }
        public EmployeeBiz this[string strIndex]
        {
            get
            {
                return _EmployeeHs[strIndex] == null ? new EmployeeBiz() : (EmployeeBiz)_EmployeeHs[strIndex];
 
            }
        }
        public static EmployeeCol CurrentEmployeeCol
        {
            get
            {
                if (_EmployeeCol == null)
                    _EmployeeCol = new EmployeeCol();
                return _EmployeeCol;
            }
        }
        public string IDsStr
        {
            get
            {
                string Returned = "";
                foreach (EmployeeBiz objBiz in this)
                {
                    if (Returned != "")
                        Returned += ",";
                    Returned += objBiz.ID.ToString();
                }    
                return Returned;
            }
        }
        #endregion
        #region Private Methods

        #endregion
        #region Public Methods
        public void Add(EmployeeBiz objBiz)
        {
            if (_EmployeeHs[objBiz.ID.ToString()] == null)
            {
                _EmployeeHs.Add(objBiz.ID.ToString(), objBiz);
                List.Add(objBiz);
            }
        }
        public void Add(EmployeeCol objCol)
        {
            foreach (EmployeeBiz objBiz in objCol)
                Add(objBiz);
        }
        public int GetIndex(EmployeeBiz objBiz)
        {
            for (int intIndex = 0; intIndex < Count; intIndex++)
            {
                if (objBiz.ID == this[intIndex].ID)
                    return intIndex;
            }
            return -1;
 
        }
        public EmployeeCol GetCol(string strFilter)
        {
            EmployeeCol Returned = new EmployeeCol(true);
            string[] arrStr = strFilter.Split("%".ToCharArray());
            bool blIsFound;
            foreach (EmployeeBiz objBiz in this)
            {
                blIsFound = true;
                foreach (string strTemp in arrStr)
                {
                    if (objBiz.Name.IndexOf(strTemp) == -1)
                        blIsFound = false;
                }
                if (blIsFound)
                    Returned.Add(objBiz);
            }
            return Returned;
        }
        public DataTable GetTable()
        {
            DataTable Returned = new DataTable();
            Returned.Columns.AddRange(new DataColumn[] {new DataColumn("EmployeeID") });
            DataRow objDr;
            foreach (EmployeeBiz objBiz in this)
            {
                objDr = Returned.NewRow();
                objDr["EmployeeID"] = objBiz.ID.ToString(); 
                Returned.Rows.Add(objDr);
            }
            return Returned;
        }
        #endregion
    }
}
