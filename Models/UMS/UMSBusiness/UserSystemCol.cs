using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using SharpVision.UMS.UMSDataBase;


namespace SharpVision.UMS.UMSBusiness
{
    public class UserSystemCol:CollectionBase
    {

        #region Constructor
        public UserSystemCol()
        {

        }
        public UserSystemCol(bool blIsEmbty)
        {
            if (blIsEmbty)
                return;
            UserSystemBiz objBiz = new UserSystemBiz();
            

            UserSystemDb objDb = new UserSystemDb();

            DataTable dtTemp = objDb.Search();


            foreach (DataRow objDR in dtTemp.Rows)
            {
                objBiz = new UserSystemBiz(objDR);
                Add(objBiz);
            }
        }

        #endregion
        #region Private Data

        #endregion
        #region Properties
        public UserSystemBiz this[int intIndex]
        {
            get
            {
                return (UserSystemBiz)this.List[intIndex];
            }
        }
        #endregion
        #region Private Method

        #endregion
        #region Public Method 
        public void Add(UserSystemBiz objBiz)
        {
            List.Add(objBiz);
        }
        public UserSystemCol GetCol(string strTemp)
        {
            UserSystemCol Returned = new UserSystemCol(true);
            foreach (UserSystemBiz objBiz in this)
            {
                if (objBiz.SystemBiz.Name.CheckUmsStr(strTemp))
                    Returned.Add(objBiz);
            }
            return Returned;
        }
        public DataTable GetTable()
        {
            DataTable Returned = new DataTable();
            Returned.Columns.AddRange(new DataColumn[] { new DataColumn("UserID"), new DataColumn("SysID"), new DataColumn("IsPermanent", System.Type.GetType("System.Boolean")), new DataColumn("StartDate", System.Type.GetType("System.DateTime")), new DataColumn("EndDate", System.Type.GetType("System.DateTime"))});
            DataRow objDr;
            foreach (UserSystemBiz objBiz in this)
            {
                objDr = Returned.NewRow();
                objDr["UserID"] = objBiz.UserID;
                objDr["SysID"] = objBiz.SystemBiz.ID;
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
