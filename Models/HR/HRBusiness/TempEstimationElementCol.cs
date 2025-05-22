using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using SharpVision.HR.HRDataBase;
using System.Collections;
using SharpVision.SystemBase;
namespace SharpVision.HR.HRBusiness
{
    public class TempEstimationElementCol:CollectionBase
    {

        #region Constructor
        public TempEstimationElementCol()
        {

        }
        public TempEstimationElementCol(bool blIsEmbty)
        {
            if (blIsEmbty)
                return;
            TempEstimationElementBiz objBiz = new TempEstimationElementBiz();
            objBiz.ID = 0;
            objBiz.NameA = "غير محدد";
            objBiz.NameE = "Not Specified";
            Add(objBiz);

            TempEstimationElementDb objDb = new TempEstimationElementDb();

            DataTable dtTemp = objDb.Search();


            foreach (DataRow objDR in dtTemp.Rows)
            {
                objBiz = new TempEstimationElementBiz(objDR);
                Add(objBiz);
            }
        }
        public TempEstimationElementCol(int intAppID)
        {
             
            TempEstimationElementBiz objBiz = new TempEstimationElementBiz();
            
            TempEstimationElementDb objDb = new TempEstimationElementDb();
            objDb.Applicant = intAppID;
            DataTable dtTemp = objDb.Search();


            foreach (DataRow objDR in dtTemp.Rows)
            {
                objBiz = new TempEstimationElementBiz(objDR);
                Add(objBiz);
            }
        }
        #endregion
        #region Private Data

        #endregion
        #region Properties
        public TempEstimationElementBiz this[int intIndex]
        {
            get
            {
                return (TempEstimationElementBiz)this.List[intIndex];
            }
        }
        #endregion
        #region Private Method

        #endregion
        #region Public Method 
        public void Add(TempEstimationElementBiz objBiz)
        {
            List.Add(objBiz);
        }
        public TempEstimationElementCol GetCol(string strTemp)
        {
            TempEstimationElementCol Returned = new TempEstimationElementCol(true);
            foreach (TempEstimationElementBiz objBiz in this)
            {
                if (objBiz.NameA.CheckStr(strTemp))
                    Returned.Add(objBiz);
            }
            return Returned;
        }
        public DataTable GetTable()
        {
            DataTable Returned = new DataTable();
            Returned.Columns.AddRange(new DataColumn[] { new DataColumn("TempElementID"), new DataColumn("TempElementNameA"), new DataColumn("TempElementNameE"), new DataColumn("TempElementApplicant"), new DataColumn("TempElementIsFuzzy", System.Type.GetType("System.Boolean")), new DataColumn("TempElementGradeValue") });
            DataRow objDr;
            foreach (TempEstimationElementBiz objBiz in this)
            {
                objDr = Returned.NewRow();
                objDr["TempElementID"] = objBiz.ID;
                objDr["TempElementNameA"] = objBiz.NameA;
                objDr["TempElementNameE"] = objBiz.NameE;
                objDr["TempElementApplicant"] = objBiz.Applicant;
                objDr["TempElementIsFuzzy"] = objBiz.IsFuzzy;
                objDr["TempElementGradeValue"] = objBiz.GradeValue;
                Returned.Rows.Add(objDr);
            }
            return Returned;
        }

        #endregion
    }
}