using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.Base.BaseDataBase;
using SharpVision.Base.BaseBusiness;
using SharpVision.GL.GLDataBase;
using SharpVision.SystemBase;
using SharpVision.UMS.UMSBusiness;
namespace SharpVision.GL.GLBusiness
{
    public class EmployeeAssignedCofferCol : BaseCol
    {
        #region Private Data

        #endregion
        #region Constructors
        public EmployeeAssignedCofferCol(EmployeeBiz objEmployeeBiz)
        {
 
        }
        #endregion
        #region Public Properties
        public EmployeeAssignedCofferBiz this[int intIndex]
        {
            get
            {
                return (EmployeeAssignedCofferBiz)List[intIndex];
            }
        }
        public CofferCol CofferCol
        {
            get
            {
                CofferCol Returned = new CofferCol(true,0);
                foreach (EmployeeAssignedCofferBiz objBiz in this)
                {
                    Returned.Add(objBiz.CofferBiz);
                }
                return Returned;
            }
        }
        #endregion
        #region Private Methods

        #endregion
        #region Public Methods
        public void Add(EmployeeAssignedCofferBiz objBiz)
        {
            List.Add(objBiz);
        }
        public DataTable GetTable()
        {
            DataTable Returned = new DataTable();
            Returned.Columns.AddRange(new DataColumn[] {new DataColumn("ApplicantID"),new DataColumn("CofferID")
                ,new DataColumn("UserID"),new DataColumn("IsPermanent",Type.GetType("system.boolean")),new DataColumn("StartDate"),
                new DataColumn("EndDate") });
            DataRow objDr;
            foreach (EmployeeAssignedCofferBiz objBiz in this)
            {
                objDr = Returned.NewRow();
                objDr["ApplicantID"] = objBiz.EmployeeBiz.ID;
                objDr["UserID"] = objBiz.UserID;
                objDr["CofferID"] = objBiz.CofferBiz.ID;
                objDr["IsPermanent"] = objBiz.IsPermanent;
                objDr["StartDate"] = objBiz.StartDate;
                objDr["EndDate"] = objBiz.EndDate;
                Returned.Rows.Add(objDr);
            }
            return Returned;
        }
        #endregion
    }
}
