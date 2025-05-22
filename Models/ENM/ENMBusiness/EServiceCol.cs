using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Data;
using AlgorithmatENM.ENM.ENMDb;
using SharpVision.SystemBase;
namespace AlgorithmatENM.ENM.ENMBiz
{
    public class EServiceCol:CollectionBase
    {

        #region Constructor
        public EServiceCol()
        {
            EServiceBiz objBiz = new EServiceBiz();

            EServiceDb objDb = new EServiceDb();
            DataTable dtTemp = objDb.Search();


            foreach (DataRow objDR in dtTemp.Rows)
            {
                objBiz = new EServiceBiz(objDR);
                Add(objBiz);
            }
        }
        public EServiceCol(bool blIsEmbty)
        {
            if (blIsEmbty)
                return;
            EServiceBiz objBiz = new EServiceBiz();
            objBiz.ID = 0;
            objBiz.Desc = "غير محدد";
            Add(objBiz);
            EServiceDb objDb = new EServiceDb();

            DataTable dtTemp = objDb.Search();


            foreach (DataRow objDR in dtTemp.Rows)
            {
                objBiz = new EServiceBiz(objDR);
                Add(objBiz);
            }
        }

        #endregion
        #region Private Data

        #endregion
        #region Properties
        public EServiceBiz this[int intIndex]
        {
            get
            {
                return (EServiceBiz)this.List[intIndex];
            }
        }
        #endregion
        #region Private Method

        #endregion
        #region Public Method 
        public void Add(EServiceBiz objBiz)
        {
            List.Add(objBiz);
        }
        public EServiceCol GetCol(string strTemp)
        {
            EServiceCol Returned = new EServiceCol(true);
            foreach (EServiceBiz objBiz in this)
            {
                if (objBiz.Desc.CheckStr(strTemp))
                    Returned.Add(objBiz);
            }
            return Returned;
        }
        public DataTable GetTable()
        {
            DataTable Returned = new DataTable();
            Returned.Columns.AddRange(new DataColumn[] { new DataColumn("EServiceID"), new DataColumn("EServiceDesc"), new DataColumn("EServiceIterationPeriod"), new DataColumn("EServiceIterationValue"), new DataColumn("EServicePortName"), new DataColumn("EServiceParity"), new DataColumn("EServiceStopBits"), new DataColumn("EServiceDataBits"), new DataColumn("EServiceBaudRate"), new DataColumn("EServiceStopped", System.Type.GetType("System.Boolean")) });
            DataRow objDr;
            foreach (EServiceBiz objBiz in this)
            {
                objDr = Returned.NewRow();
                objDr["EServiceID"] = objBiz.ID;
                objDr["EServiceDesc"] = objBiz.Desc;
                objDr["EServiceIterationPeriod"] = objBiz.IterationPeriod;
                objDr["EServiceIterationValue"] = objBiz.IterationValue;
                objDr["EServicePortName"] = objBiz.PortName;
                objDr["EServiceParity"] = objBiz.Parity;
                objDr["EServiceStopBits"] = objBiz.StopBits;
                objDr["EServiceDataBits"] = objBiz.DataBits;
                objDr["EServiceBaudRate"] = objBiz.BaudRate;
                objDr["EServiceStopped"] = objBiz.Stopped;
                Returned.Rows.Add(objDr);
            }
            return Returned;
        }

        #endregion
    }
}
