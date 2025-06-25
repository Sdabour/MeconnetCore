using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using SharpVision.UMS.UMSDataBase;

using System.Linq;

namespace SharpVision.UMS.UMSBusiness
{
    public class AssignmentObjectCol:CollectionBase
    {

        #region Constructor
        public AssignmentObjectCol()
        {

        }
        public AssignmentObjectCol(bool blIsEmbty)
        {
            if (blIsEmbty)
                return;
            AssignmentObjectBiz objBiz = new AssignmentObjectBiz();
            objBiz.ID = 0;
           

            AssignmentObjectDb objDb = new AssignmentObjectDb();

            DataTable dtTemp = objDb.Search();


            foreach (DataRow objDR in dtTemp.Rows)
            {
                objBiz = new AssignmentObjectBiz(objDR);
                Add(objBiz);
            }
        }

        #endregion
        #region Private Data

        #endregion
        #region Properties
        public AssignmentObjectBiz this[int intIndex]
        {
            get
            {
                return (AssignmentObjectBiz)this.List[intIndex];
            }
        }
        #endregion
        #region Private Method

        #endregion
        #region Public Method 
        public void Add(AssignmentObjectBiz objBiz)
        {
            List.Add(objBiz);
        }
        public AssignmentObjectCol GetCol(string strTemp)
        {
            AssignmentObjectCol Returned = new AssignmentObjectCol(true);
            foreach (AssignmentObjectBiz objBiz in this)
            {
                if (objBiz.TableName.CheckUmsStr(strTemp) || objBiz.Code.CheckUmsStr(strTemp))
                    Returned.Add(objBiz);
            }
            return Returned;
        }
        public DataTable GetTable()
        {
            DataTable Returned = new DataTable();
            Returned.Columns.AddRange(new DataColumn[] { new DataColumn("ObjectID"), new DataColumn("ObjectDesc"), new DataColumn("ObjectCode"), new DataColumn("ObjectTableName"), new DataColumn("ObjectTableValueName"), new DataColumn("ObjectTableDisplayNameA"), new DataColumn("ObjectTableDisplayNameE"),new DataColumn("ObjectConditionStr") });
            DataRow objDr;
            foreach (AssignmentObjectBiz objBiz in this)
            {
                objDr = Returned.NewRow();
                objDr["ObjectID"] = objBiz.ID;
                objDr["ObjectDesc"] = objBiz.Desc;
                objDr["ObjectCode"] = objBiz.Code;
                objDr["ObjectTableName"] = objBiz.TableName;
                objDr["ObjectTableValueName"] = objBiz.TableValueName;
                objDr["ObjectTableDisplayNameA"] = objBiz.TableDisplayNameA;
                objDr["ObjectTableDisplayNameE"] = objBiz.TableDisplayNameE;
                objDr["ObjectConditionStr"] = objBiz.ConditionStr;
                Returned.Rows.Add(objDr);
            }
            return Returned;
        }

        #endregion
    }
}
