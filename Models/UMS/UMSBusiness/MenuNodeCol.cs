using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using SharpVision.UMS.UMSDataBase;

using System.Linq;
namespace SharpVision.UMS.UMSBusiness
{ 
    public class MenuNodeCol : CollectionBase
    {

        #region Constructor
        public MenuNodeCol()
        {

        }
        public MenuNodeCol(bool blIsEmbty)
        {
            if (blIsEmbty)
                return;
            MenuNodeBiz objBiz = new MenuNodeBiz();
            objBiz.ID = 0;
            objBiz.NameA = "غير محدد";
            objBiz.NameE = "Not Specified";
            Add(objBiz);

            MenuNodeDb objDb = new MenuNodeDb();

            DataTable dtTemp = objDb.Search();


            foreach (DataRow objDR in dtTemp.Rows)
            {
                objBiz = new MenuNodeBiz(objDR);

                Add(objBiz);
            }
        }

        #endregion
        #region Private Data

        #endregion
        #region Properties
        public MenuNodeBiz this[int intIndex]
        {
            get
            {
                return (MenuNodeBiz)this.List[intIndex];
            }
        }
        public void SetNodeChildren(ref MenuNodeBiz objNodeBiz)
        {
            int intID = objNodeBiz.ID;
            IEnumerable<MenuNodeBiz> objCol = from objBiz in this.Cast<MenuNodeBiz>()
                                              where objBiz.Parent == intID
                                              select objBiz;
            MenuNodeBiz objBiz1;
            for (int intIndex = 0; intIndex < objCol.Count(); intIndex++)
            {
                objBiz1 = objCol.ElementAt(intIndex);
                SetAuthorizedNodeChildren(ref objBiz1);
                objNodeBiz.Children.Add(objBiz1);
            }
        }
        public void SetAuthorizedNodeChildren(ref MenuNodeBiz objNodeBiz)
        {
            int intID = objNodeBiz.ID;
            IEnumerable<MenuNodeBiz> objCol = from objBiz in this.Cast<MenuNodeBiz>()
                                              where objBiz.Parent == intID &&
                                              (objBiz.Function == 0 ) &&!objBiz.IsStopped
                                              select objBiz;
           // object objX =  UserBiz.CurrentUser.UserFunctionInstantCol["553"];
            MenuNodeBiz objBiz1;
            for (int intIndex = 0; intIndex < objCol.Count(); intIndex++)
            {
                objBiz1 = objCol.ElementAt(intIndex);
                
                SetAuthorizedNodeChildren(ref objBiz1);
                if(objBiz1.Function>0|| objBiz1.Children.Count>0)
                objNodeBiz.Children.Add(objBiz1);
            }
        }
        public MenuNodeCol MainNodeCol
        {
            get
            {
                MenuNodeCol Returned = new MenuNodeCol(true);
                IEnumerable<MenuNodeBiz> objCol = from objBiz in this.Cast<MenuNodeBiz>()
                                                  where objBiz.Parent == 0
                                                  select objBiz;
                MenuNodeBiz objNodeBiz;
                foreach (MenuNodeBiz objBiz in objCol)
                {
                    Returned.Add(objBiz);

                }
                for (int intIndex = 0; intIndex < Returned.Count; intIndex++)

                {
                    objNodeBiz = Returned[intIndex];
                    SetNodeChildren(ref objNodeBiz);
                }
                return Returned;
            }
        }
        public MenuNodeCol AuthorisedMainNodeCol
        {
            get
            {
                MenuNodeCol Returned = new MenuNodeCol(true);
                IEnumerable<MenuNodeBiz> objCol = from objBiz in this.Cast<MenuNodeBiz>()
                                                  where objBiz.Parent == 0 && !objBiz.IsStopped
                                                  select objBiz;
                MenuNodeBiz objNodeBiz;
                for (int intIndex = 0; intIndex < objCol.Count(); intIndex++)
                {
                    objNodeBiz = objCol.ElementAt(intIndex);
                    if (objNodeBiz.Function != 0 && UserBiz.CurrentUser.CheckFunction(objNodeBiz.Function))
                        Returned.Add(objNodeBiz);
                    else
                    {
                        SetAuthorizedNodeChildren(ref objNodeBiz);
                        if (objNodeBiz.Children.Count > 0)
                            Returned.Add(objNodeBiz);
                    }
                }

                return Returned;
            }
        }
        #endregion
        #region Private Method

        #endregion
        #region Public Method 
        public void Add(MenuNodeBiz objBiz)
        {
            List.Add(objBiz);
        }
        public MenuNodeCol GetCol(string strTemp)
        {
            MenuNodeCol Returned = new MenuNodeCol(true);
            foreach (MenuNodeBiz objBiz in this)
            {
                if (objBiz.Name.CheckUmsStr(strTemp))
                    Returned.Add(objBiz);
            }
            return Returned;
        }
        public bool CheckNodeName(string strName)
        {
            bool Returned = false;
            bool blFound = false;
            string strTempName = "";
            string strTempName1 = "";
            string[] arrStr;
            strName = strName.ToLower().Replace("#", "");
            foreach (MenuNodeBiz objBiz in this)
            {
                blFound = false;
                strTempName = "";
                
                if (objBiz.FunctionBiz.ID != 0 )
                {

                    arrStr = objBiz.AppliedURL.Split(@"/".ToCharArray());
                    if (arrStr.Length == 0)
                        continue;
                    strTempName = arrStr[arrStr.Length - 1].ToLower();
                    strTempName1 = "";
                    if (arrStr.Length > 1)
                        strTempName1 = arrStr[arrStr.Length - 2].ToLower();

                    if (strName.Trim().ToLower() == strTempName.Trim().ToLower() || (strName.Trim().ToLower() == strTempName1.Trim().ToLower()))
                        blFound = true;
                }
                if (blFound || objBiz.Children.CheckNodeName(strName))
                    return true;
            }
            return Returned;
        }
        public DataTable GetTable()
        {
            DataTable Returned = new DataTable();
            Returned.Columns.AddRange(new DataColumn[] { new DataColumn("NodeID"), new DataColumn("NodeCode"), new DataColumn("NodeNameA"), new DataColumn("NodeNameE"), new DataColumn("NodeParent"), new DataColumn("NodeFunction"), new DataColumn("NodeSystem"), new DataColumn("NodeIsStopped", System.Type.GetType("System.Boolean")) });
            DataRow objDr;
            foreach (MenuNodeBiz objBiz in this)
            {
                objDr = Returned.NewRow();
                objDr["NodeID"] = objBiz.ID;
                objDr["NodeCode"] = objBiz.Code;
                objDr["NodeNameA"] = objBiz.NameA;
                objDr["NodeNameE"] = objBiz.NameE;
                objDr["NodeParent"] = objBiz.Parent;
                objDr["NodeFunction"] = objBiz.Function;
                objDr["NodeSystem"] = objBiz.System;
                objDr["NodeIsStopped"] = objBiz.IsStopped;
                Returned.Rows.Add(objDr);
            }
            return Returned;
        }

        #endregion
    }
}
