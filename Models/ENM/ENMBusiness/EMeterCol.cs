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
   public  class EMeterCol:CollectionBase
    {

        #region Constructor
        public EMeterCol()
        {
            EMeterBiz objBiz = new EMeterBiz();


            EMeterDb objDb = new EMeterDb();

            DataTable dtTemp = objDb.Search();


            foreach (DataRow objDR in dtTemp.Rows)
            {
                objBiz = new EMeterBiz(objDR);
                Add(objBiz);
            }

        }
        public EMeterCol(bool blIsEmbty)
        {
            if (blIsEmbty)
                return;
            EMeterBiz objBiz = new EMeterBiz();
           

            EMeterDb objDb = new EMeterDb();

            DataTable dtTemp = objDb.Search();


            foreach (DataRow objDR in dtTemp.Rows)
            {
                objBiz = new EMeterBiz(objDR);
                Add(objBiz);
            }
        }

        #endregion
        #region Private Data

        #endregion
        #region Properties
        public EMeterBiz this[int intIndex]
        {
            get
            {
                return (EMeterBiz)this.List[intIndex];
            }
        }
        #endregion
        #region Private Method

        #endregion
        #region Public Method 
        public void Add(EMeterBiz objBiz)
        {
            List.Add(objBiz);
        }
        public EMeterCol GetCol(string strTemp)
        {
            EMeterCol Returned = new EMeterCol(true);
            foreach (EMeterBiz objBiz in this)
            {
                if (objBiz.Desc.CheckStr(strTemp))
                    Returned.Add(objBiz);
            }
            return Returned;
        }
        public EMeterCol GetCol(int intType,int intGroup)
        {
            EMeterCol Returned = new EMeterCol(true);
            foreach (EMeterBiz objBiz in this)
            {
                if ((intType==0|| objBiz.Type==intType)&&(intGroup==0 ||intGroup == objBiz.GroupBiz.ID))
                    Returned.Add(objBiz);
            }
            return Returned;
        }
        public DataTable GetTable()
        {
            DataTable Returned = new DataTable();
            Returned.Columns.AddRange(new DataColumn[] { new DataColumn("EMeterID"), new DataColumn("EMeterType"), new DataColumn("EMeterDesc"), new DataColumn("EMeterWordStartAddress"), new DataColumn("EMeterWordNo"), new DataColumn("EMeterEService"), new DataColumn("EMeterAddress"), new DataColumn("EMeterStopped", System.Type.GetType("System.Boolean")) });
            DataRow objDr;
            foreach (EMeterBiz objBiz in this)
            {
                objDr = Returned.NewRow();
                objDr["EMeterID"] = objBiz.ID;
                objDr["EMeterType"] = objBiz.Type;
                objDr["EMeterDesc"] = objBiz.Desc;
                objDr["EMeterWordStartAddress"] = objBiz.WordStartAddress;
                objDr["EMeterWordNo"] = objBiz.WordNo;
                objDr["EMeterEService"] = objBiz.EService;
                objDr["EMeterAddress"] = objBiz.Address;
                objDr["EMeterStopped"] = objBiz.Stopped;
                Returned.Rows.Add(objDr);
            }
            return Returned;
        }
        public EMeterCol Copy()
        {
            EMeterCol Returned = new EMeterCol(true);
            foreach (EMeterBiz objBiz in this)
            {
                Returned.Add(objBiz);
            }
            return Returned;
                
        }
        #endregion
    }
}
