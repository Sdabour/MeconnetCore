using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

using SharpVision.Base.BaseBusiness;
using SharpVision.UMS.UMSDataBase;
using System.Data;
namespace SharpVision.UMS.UMSBusiness
{
    public class EmployeeDepartmentCol : CollectionBase
    {
        #region Private Data

        #endregion
        #region Constructors
        public EmployeeDepartmentCol(bool blIsEmpty)
        {
 
        }
        #endregion
        #region Public Properties
        public EmployeeDepartmentBiz this[int intIndex]
        {
            get
            {
                return (EmployeeDepartmentBiz)List[intIndex];
            }
        }
        #endregion
        #region Private Methods

        #endregion
        #region Public Methods
        public void Add(EmployeeDepartmentBiz objBiz)
        {
            List.Add(objBiz);
        }
        #endregion
    }

}
