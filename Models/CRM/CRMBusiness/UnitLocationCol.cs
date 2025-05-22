using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
namespace SharpVision.CRM.CRMBusiness
{
    public class UnitLocationCol:CollectionBase
    {
        #region Private Data

        #endregion
        #region Constructors
        public UnitLocationCol(bool blIsEmpty)
        { 
        }

        #endregion
        #region Public Properties
        public UnitLocationBiz this[int intIndex]
        {
            set
            {
                List[intIndex] = value;
 
            }
            get 
            {
                return (UnitLocationBiz)List[intIndex];
            }
        }
        #endregion
        #region Private Methods

        #endregion
        #region Public Methods
        public void Add(UnitLocationBiz objBiz)
        {
            List.Add(objBiz);
        }
        #endregion
    }
}
