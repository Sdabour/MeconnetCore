using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using SharpVision.UMS.UMSDataBase;


namespace SharpVision.UMS.UMSBusiness
{
    public class UserGroupCol : CollectionBase
    {

        #region Constructor
        public UserGroupCol()
        {

        }
        public UserGroupCol(bool blIsEmbty)
        {
            if (blIsEmbty)
                return;
            UserGroupBiz objBiz = new UserGroupBiz();


            UserGroupDb objDb = new UserGroupDb();

            DataTable dtTemp = objDb.Search();


            foreach (DataRow objDR in dtTemp.Rows)
            {
                objBiz = new UserGroupBiz(objDR);
                Add(objBiz);
            }
        }

        #endregion
        #region Private Data

        #endregion
        #region Properties
        public UserGroupBiz this[int intIndex]
        {
            get
            {
                return (UserGroupBiz)this.List[intIndex];
            }
        }
        #endregion
        #region Private Method

        #endregion
        #region Public Method 
        public void Add(UserGroupBiz objBiz)
        {
            List.Add(objBiz);
        }
        public UserGroupCol GetCol(string strTemp)
        {
            UserGroupCol Returned = new UserGroupCol(true);
            foreach (UserGroupBiz objBiz in this)
            {
                if (objBiz.GroupBiz.Name.CheckUmsStr(strTemp))
                    Returned.Add(objBiz);
            }
            return Returned;
        }
        public DataTable GetTable()
        {
            DataTable Returned = new DataTable();
            Returned.Columns.AddRange(new DataColumn[] { new DataColumn("UserID"), new DataColumn("GroupID"), new DataColumn("IsPermanent", System.Type.GetType("System.Boolean")), new DataColumn("StartDate", 
                System.Type.GetType("System.DateTime")), new DataColumn("EndDate", System.Type.GetType("System.DateTime")) });
            DataRow objDr;
            foreach (UserGroupBiz objBiz in this)
            {
                objDr = Returned.NewRow();
                objDr["UserID"] = objBiz.UserID;
                objDr["GroupID"] = objBiz.GroupBiz.ID;
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
