using SharpVision.HR.HRDataBase;
using SharpVision.SystemBase;
using SharpVision.UMS.UMSBusiness;
using System;
using System.Collections;
using System.Data;
namespace SharpVision.HR.HRBusiness
{
    public class EmployeeSectorAssignmentCol : CollectionBase
    {
        #region Private Data
        Hashtable _SectorTable = new Hashtable();
        #endregion
        #region Constructors
        public EmployeeSectorAssignmentCol(bool blIsEmpty)
        {

        }
        public EmployeeSectorAssignmentCol(EmployeeBiz objEmployeeBiz)
        {
            if (objEmployeeBiz == null || objEmployeeBiz.ID == 0)
                return;
            EmployeeSectorAssignmentDb objDb = new EmployeeSectorAssignmentDb();
            objDb.EmployeeID = objEmployeeBiz.ID;
            DataTable dtTemp = objDb.Search();
            EmployeeSectorAssignmentBiz objBiz;
            foreach (DataRow objDr in dtTemp.Rows)
            {
                objBiz = new EmployeeSectorAssignmentBiz(objDr);
                objBiz.EmployeeBiz = objEmployeeBiz;
                Add(objBiz);
            }

        }
        #endregion
        #region Public Properties
        public EmployeeSectorAssignmentBiz this[int intIndex]
        {
            get
            {
                return (EmployeeSectorAssignmentBiz)List[intIndex];
            }
        }
        #endregion
        #region Private Methods

        #endregion
        #region Public Methods
        public void Add(EmployeeSectorAssignmentBiz objBiz)
        {
            string strKey = objBiz.SectorBiz.ID.ToString();
            if (_SectorTable == null)
                _SectorTable = new Hashtable();
            if (_SectorTable[strKey] == null)
            {
                _SectorTable.Add(strKey, Count);
                List.Add(objBiz);
            }
        }
        public DataTable GetTable()
        {
            DataTable Returned = new DataTable();
            Returned.Columns.AddRange(new DataColumn[] { new DataColumn("AssignmentID"),
                new DataColumn("AssignmentEmployeeID") ,new DataColumn("AssignmentSectorID"),
                new DataColumn("AssignmentIsPermanent",Type.GetType("System.Boolean")) ,new DataColumn("AssignmenEndDate")});
            DataRow objDr;
            foreach (EmployeeSectorAssignmentBiz objBiz in this)
            {
                objDr = Returned.NewRow();
                objDr["AssignmentID"] = objBiz.ID;
                objDr["AssignmentEmployeeID"] = objBiz.EmployeeBiz.ID;
                objDr["AssignmentSectorID"] = objBiz.SectorBiz.ID;
                objDr["AssignmentIsPermanent"] = objBiz.IsPermanent;
                objDr["AssignmenEndDate"] = objBiz.EndDate;

                Returned.Rows.Add(objDr);
            }
            return Returned;
        }
        public void AssignEmployeeSector(EmployeeBiz objBiz)
        {
            DataTable dtTemp = GetTable();
            EmployeeSectorAssignmentDb objDb = new EmployeeSectorAssignmentDb();
            objDb.SectorTable = dtTemp;
            objDb.EmployeeID = objBiz.ID;
            objDb.AssignSector();
        }
       
        public static bool CheckSectorAssigned(int intSectorID)
        {
            bool Returned = true;
           // Returned =true;
            return Returned; ;
        }
        #endregion
    }
}
