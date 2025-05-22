using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.UMS.UMSDataBase;
using SharpVision.Base.BaseBusiness;
using System.Collections;
namespace SharpVision.UMS.UMSBusiness
{
    public class UserCol : BaseCol
    {
        public UserCol()
        {
            UserDb objUserDb = new UserDb();

            UserBiz objUserBiz;
            foreach (DataRow DR in objUserDb.Search().Rows)
            {
                objUserBiz = new UserBiz(DR);
                this.Add(objUserBiz);

            }


        }
        public UserCol(bool blIsEmpty)
        {
 
        }
         public UserCol(string strUserName)
      {
          UserDb objUserDb = new UserDb();
          objUserDb.FullName = strUserName;
          DataTable dtUser = objUserDb.Search();
          UserBiz objUserBiz;
          foreach (DataRow DR in dtUser.Rows)
          {
              objUserBiz = new UserBiz(DR);
              this.Add(objUserBiz);
          }
      }
        public UserCol(int intGroupID, int intUserID)
        {
            UserDb objUserDb = new UserDb();
            objUserDb.GroupID = intGroupID;
            objUserDb.ID = intUserID;
            UserBiz objUserBiz;
            DataTable dtUser = objUserDb.Search();
            foreach (DataRow DR in dtUser.Rows)
            {
                objUserBiz = new UserBiz(DR);
                this.Add(objUserBiz);
            }
        }

        public UserCol(int intGroupID, string strUserName, string strUserFullname,int intEmployeeID)
        {
            UserDb objUserDb = new UserDb();
            objUserDb.GroupID = intGroupID;
            objUserDb.FullName = strUserFullname;
            objUserDb.Name = strUserName;
            objUserDb.EmployeeID = intEmployeeID;
            UserBiz objUserBiz;

            DataTable dtUser = objUserDb.Search();
            foreach (DataRow objDR in dtUser.Rows)
            {
                objUserBiz = new UserBiz(objDR);
                this.Add(objUserBiz);
            }
        }
        public UserCol(GroupBiz objGroupBiz, string strUserName, string strUserFullname)
        {
            if (objGroupBiz == null)
                objGroupBiz = new GroupBiz();
            UserDb objUserDb = new UserDb();
           
            objUserDb.GroupIDs = objGroupBiz.IDsStr;
            objUserDb.FullName = strUserFullname;
            objUserDb.Name = strUserName;
            UserBiz objUserBiz;
            DataTable dtUser = objUserDb.Search();
            foreach (DataRow objDR in dtUser.Rows)
            {
                objUserBiz = new UserBiz(objDR);
                this.Add(objUserBiz);
            }
        }

        public bool Contains(string strName)
        {
            bool blReturned = false;
            foreach (UserBiz objUserBiz in this)
            {
                if (objUserBiz.FullName == strName)
                {
                    blReturned = true;
                    break;
                }
            }
            return blReturned;

        }
        public virtual UserBiz this[int intIndex]
        {
            get
            {

                return (UserBiz)this.List[intIndex];

            }
        }

        public virtual UserBiz this[string strIndex]
        {
            get
            {
                UserBiz Returned = new UserBiz();
                foreach (UserBiz objUserBiz in this)
                {
                    if (objUserBiz.Name == strIndex)
                    {
                        Returned = objUserBiz.Copy();
                        break;
                    }
                }
                return Returned;
            }
        }
        public void Add(UserBiz objUserBiz)
        {
                this.List.Add(objUserBiz);

        }
        public virtual void Add(UserCol objUserCol)
        {
            foreach (UserBiz objUserBiz in objUserCol)
            {
                if (this[objUserBiz.ID.ToString()].ID == 0 && this[objUserBiz.GroupID].GroupID == 0)
                    this.List.Add(objUserBiz);

            }
        }
        public void RemoveByID(int intID)
        {
            int intIndex = 0;
            foreach (UserBiz objBiz in this)
            {
                if (objBiz.ID == intID)
                {
                    RemoveAt(intIndex);
                    return;
                }
                intIndex++;
            }
        }
        public UserCol ReturnNewColWithoutID(int intID)
        {
            UserCol Returned = new UserCol(true);
           foreach (UserBiz objBiz in this)
           {
               if (objBiz.ID != intID)
               {
                   Returned.Add(objBiz);
               }
             
           }
           return Returned;
        }
        public UserCol GetUserCol(string strName,string strFullName,int intExceptedID)
        {
            UserCol Returned = new UserCol(true);
            foreach (UserBiz objBiz in this)
            {

                if ((objBiz.Name.IndexOf(strName, StringComparison.OrdinalIgnoreCase) != -1 || objBiz.ID.ToString().IndexOf(strName, StringComparison.OrdinalIgnoreCase) != -1) &&
                    objBiz.FullName.IndexOf(strFullName,StringComparison.OrdinalIgnoreCase)!=-1 && (intExceptedID == 0 || intExceptedID != objBiz.ID))
                {
                    Returned.Add(objBiz);
 
                }
            }
            return Returned;
        }
        public UserCol Copy()
        {
            UserCol Returned = new UserCol(true);
            foreach (UserBiz objTemp in this)
            {
                Returned.Add(objTemp.Copy());
            }
            return Returned;
        }
        public DataTable GetTable()
        {
            DataTable Returned = new DataTable();
            Returned.Columns.AddRange(new DataColumn[] { new DataColumn("EmployeeName"),new DataColumn("Group"),new DataColumn("Branch"), new DataColumn("UserStatus"),
                new DataColumn("UsrName"),new DataColumn("Code"), new DataColumn("Pass"),new DataColumn("NewPass") });
            DataRow objDr;
            DataTable dtTempKey = UserDb.GetTempKey();
            DataRow[] arrDr;
            string strTemp = "";
            foreach (UserBiz objBiz in this)
            {
                objDr = Returned.NewRow();
                objDr["EmployeeName"] = objBiz.EmployeeBiz.Name;
                objDr["Code"] = objBiz.EmployeeBiz.Code;
                objDr["Branch"] = objBiz.EmployeeBiz.BranchName;
                objDr["Group"] = objBiz.GroupName;
                if (objBiz.EmployeeBiz.ID != 0)
                {
                    if (objBiz.EmployeeBiz.StatusStr != "íÚãá")
                        continue;
                    objDr["UserStatus"] = objBiz.EmployeeBiz.StatusStr;
                }
                objDr["UsrName"] = objBiz.Name;
                objDr["Pass"] = objBiz.Password;
                //arrDr = dtTempKey.Select("UID=" + objBiz.ID);
                //if (arrDr.Length > 0)
                //{
                //    strTemp = arrDr[0]["PKey"].ToString();
                //    //   if (objBiz.Password.IndexOf(strTemp) == -1)
                //    objDr["NewPass"] = strTemp;
                //    //else
                //    //    continue;
                //}
                Returned.Rows.Add(objDr);
            }
            
            return Returned;
        }
        public DataTable GetBranch()
        {
            DataTable Returned = new DataTable();
            Returned.Columns.AddRange(new DataColumn[] {new DataColumn("BranchID"), new DataColumn("BranchName")});
            Hashtable hsTemp = new Hashtable();
            DataRow objDr;
            objDr = Returned.NewRow();
            objDr["BranchID"] = 0;
            objDr["BranchName"] = "ÛíÑ ãÍÏÏ";
            Returned.Rows.Add(objDr);
            foreach (UserBiz objBiz in this)
            {
                if(objBiz.EmployeeBiz.BranchName != null && hsTemp[objBiz.EmployeeBiz.BranchName]== null )
                {
                    hsTemp.Add(objBiz.EmployeeBiz.BranchName, objBiz.EmployeeBiz.BranchName);
                    objDr = Returned.NewRow();
                    objDr["BranchID"] = objBiz.EmployeeBiz.BranchID;
                    objDr["BranchName"] = objBiz.EmployeeBiz.BranchName;
                    Returned.Rows.Add(objDr);
                }
            }
            return Returned;
        }
        public DataTable GetKeyTable(string strBranch)
        {
            DataTable Returned = new DataTable();
            DataTable dtTempKey = UserDb.GetTempKey();
            DataRow[] arrDr;
            Returned.Columns.AddRange(new DataColumn[] {new DataColumn("UID"), new DataColumn("EmployeeName"),new DataColumn("UserStatus"), new DataColumn("UsrName"), 
                new DataColumn("Pass") ,new DataColumn("NewPass"),new DataColumn("NewUserName")});
            DataRow objDr;
            string strTemp = "";
            string strBranch1 = "ÇáÈÇÝÇÑíÇ";
            strBranch1 = "";
            foreach (UserBiz objBiz in this)
            {
                if (strBranch1 != "" && (objBiz.EmployeeBiz.BranchName != null && objBiz.EmployeeBiz.BranchName.IndexOf(strBranch1) != -1))
                    continue;
                objDr = Returned.NewRow();
                if ( strBranch != "" && (objBiz.EmployeeBiz.BranchName==null || objBiz.EmployeeBiz.BranchName.IndexOf(strBranch) == -1))
                    continue;

                objDr["UID"] = objBiz.ID;
                objDr["EmployeeName"] = objBiz.EmployeeBiz.Name;
                objDr["NewUserName"] = objBiz.EmployeeBiz.Code ==null?"":objBiz.EmployeeBiz.Code;
                objDr["UsrName"] = objBiz.Name;
                if(objBiz.EmployeeBiz.ID!=0)
                objDr["UserStatus"] = objBiz.EmployeeBiz.StatusStr;
                objDr["Pass"] = objBiz.Password;
                objDr["NewPass"] = objBiz.Password;
                
                arrDr  = dtTempKey.Select("UID="+ objBiz.ID);
                if (arrDr.Length > 0)
                {
                    strTemp = arrDr[0]["PKey"].ToString();
                    //if (objBiz.Password != strTemp)
                        objDr["NewPass"] = strTemp;
                    //else
                    //    continue;
                }
                else
                    continue;
                Returned.Rows.Add(objDr);
            }

            return Returned;
        }
        public static void EditNewPASS(DataTable dtTemp)
        {
            UserDb objDb = new UserDb();
            objDb.UserTable = dtTemp;
            objDb.EditAllPass();

        }

    }
}
