using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using SharpVision.CRM.CRMDataBase;
using System.Linq;
namespace SharpVision.CRM.CRMBusiness
{
    public class UnitPeripheralCol : CollectionBase
    {
        #region Private Data

        #endregion
        #region Constructors
        public UnitPeripheralCol()
        { }
        public UnitPeripheralCol(bool blIsEmpty)
        { 
        }
        #endregion
        #region Public Properties
        public UnitPeripheralBiz this[int intIndex]
        {
            get
            {
                return (UnitPeripheralBiz)List[intIndex];
            }
        }
        public double TotalPrice
        {
            get
            {
                double Returned = this.Cast<UnitPeripheralBiz>().Sum(X=>X.TotalPrice);

                return Returned;
            }
        }
        #endregion
        #region Private Methods

        #endregion
        #region Public Methods
        public void Add(UnitPeripheralBiz objBiz)
        {
            List.Add(objBiz);
        }
        public DataTable GetTable()
        {
            DataTable Returned = new DataTable();
            Returned.Columns.AddRange(new DataColumn[] { new DataColumn("PeriphiralID"), new DataColumn("PeriphiralUnit"),
            new DataColumn("PeriphiralType"),new DataColumn("PeripheralDesc"),new DataColumn("PeripheralSurvey")});
            DataRow objDr;
            foreach (UnitPeripheralBiz objBiz in this)
            {
                objDr = Returned.NewRow();
                objDr["PeriphiralID"] = objBiz.ID;
                objDr["PeriphiralUnit"] = objBiz.UnitBiz.ID;
                objDr["PeriphiralType"] = objBiz.TypeBiz.ID;
                objDr["PeripheralDesc"] = objBiz.Desc;
                objDr["PeripheralSurvey"] = objBiz.Survey;
                Returned.Rows.Add(objDr);
 
            }
            return Returned;
        }
        #endregion
    }
}
