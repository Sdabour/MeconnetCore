using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using SharpVision.UMS.UMSDataBase;
using System.Linq;

namespace SharpVision.UMS.UMSBusiness
{
    public class UserObjectAssignmentCol:CollectionBase
    {

        #region Constructor
        public UserObjectAssignmentCol()
        {

        }
        public UserObjectAssignmentCol(bool blIsEmbty)
        {
            if (blIsEmbty)
                return;
            UserObjectAssignmentBiz objBiz = new UserObjectAssignmentBiz();
          

            UserObjectAssignmentDb objDb = new UserObjectAssignmentDb();

            DataTable dtTemp = objDb.Search();


            foreach (DataRow objDR in dtTemp.Rows)
            {
                objBiz = new UserObjectAssignmentBiz(objDR);
                Add(objBiz);
            }
        }

        #endregion
        #region Private Data

        #endregion
        #region Properties
        public UserObjectAssignmentBiz this[int intIndex]
        {
            get
            {
                return (UserObjectAssignmentBiz)this.List[intIndex];
            }
        }
        public string IDsStr
        {
            get
            {
                string Returned = "";
                foreach(UserObjectAssignmentBiz objBiz in this)
                {
                    if (Returned != "")
                        Returned += ",";
                    Returned += objBiz.SingleObjectBiz.ID.ToString();
                }

                return Returned;
            }
        }
        #endregion
        #region Private Method

        #endregion
        #region Public Method 
        public void Add(UserObjectAssignmentBiz objBiz)
        {
            List.Add(objBiz);
        }
        public UserObjectAssignmentCol GetCol(string strTemp)
        {
            UserObjectAssignmentCol Returned = new UserObjectAssignmentCol(true);
            foreach (UserObjectAssignmentBiz objBiz in this)
            {
                if (objBiz.ObjectCode.CheckUmsStr(strTemp))
                    Returned.Add(objBiz);
            }
            return Returned;
        }
        public DataTable GetTable()
        {
            DataTable Returned = new DataTable();
            Returned.Columns.AddRange(new DataColumn[] { new DataColumn("UserID"), new DataColumn("ObjectCode"), new DataColumn("ObjectID"), new DataColumn("ObjectValue"), new DataColumn("AssignmentStartDate", System.Type.GetType("System.DateTime")), new DataColumn("AssignmentEndDate", System.Type.GetType("System.DateTime")), new DataColumn("AssignmentIsPermanent", System.Type.GetType("System.Boolean")) });
            DataRow objDr;
            foreach (UserObjectAssignmentBiz objBiz in this)
            {
                objDr = Returned.NewRow();
                objDr["UserID"] = objBiz.UserID;
                objDr["ObjectCode"] = objBiz.ObjectCode;
                objDr["ObjectID"] = objBiz.ObjectID;
                objDr["ObjectValue"] = objBiz.ObjectValue;
                objDr["AssignmentStartDate"] = objBiz.StartDate;
                objDr["AssignmentEndDate"] = objBiz.EndDate;
                objDr["AssignmentIsPermanent"] = objBiz.IsPermanent;
                Returned.Rows.Add(objDr);
            }
            return Returned;
        }
        public UserObjectAssignmentBiz GetBizByID(int intID)
        {
            UserObjectAssignmentBiz Returned = new UserObjectAssignmentBiz();
            List<UserObjectAssignmentBiz> lstTemp = this.Cast<UserObjectAssignmentBiz>().Where(x => x.SingleObjectBiz.ID == intID).ToList();
            if (lstTemp.Count > 0)
                Returned = lstTemp[0];

            return Returned;
        }
        #endregion
    }
}
