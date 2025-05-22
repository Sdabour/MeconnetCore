using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using SharpVision.HR.HRDataBase;
using System.Data;
using SharpVision.SystemBase;
namespace SharpVision.HR.HRBusiness
{
    public class GroupElementCol :CollectionBase
    {

        #region Constructor
        public GroupElementCol()
        {
            GroupElementDb objDb = new GroupElementDb();

            DataTable dtTemp = objDb.Search();

            GroupElementBiz objBiz = new GroupElementBiz();
            foreach (DataRow objDR in dtTemp.Rows)
            {
                objBiz = new GroupElementBiz(objDR);
                Add(objBiz);
            }
        }
        public GroupElementCol(bool blIsEmbty)
        {
            if (blIsEmbty)
                return;
            GroupElementBiz objBiz = new GroupElementBiz();
            objBiz.ID = 0;
            objBiz.NameA = "غير محدد";
            objBiz.NameE = "Not Specified";
            Add(objBiz);

            GroupElementDb objDb = new GroupElementDb();

            DataTable dtTemp = objDb.Search();


            foreach (DataRow objDR in dtTemp.Rows)
            {
                objBiz = new GroupElementBiz(objDR);
                Add(objBiz);
            }
        }

        #endregion
        #region Private Data

        #endregion
        #region Properties
        public GroupElementBiz this[int intIndex]
        {
            get
            {
                return (GroupElementBiz)this.List[intIndex];
            }
        }
        #endregion
        #region Private Method

        #endregion
        #region Public Method 
        public void Add(GroupElementBiz objBiz)
        {
            List.Add(objBiz);
        }
        public GroupElementCol GetCol(string strTemp)
        {
            GroupElementCol Returned = new GroupElementCol(true);
            foreach (GroupElementBiz objBiz in this)
            {
                if (objBiz.Name.CheckStr(strTemp))
                    Returned.Add(objBiz);
            }
            return Returned;
        }
        public DataTable GetTable()
        {
            DataTable Returned = new DataTable();
            Returned.Columns.AddRange(new DataColumn[] { new DataColumn("GroupElementID"), new DataColumn("GroupElementCode"), new DataColumn("GroupElementNameA"), new DataColumn("GroupElementNameE") });
            DataRow objDr;
            foreach (GroupElementBiz objBiz in this)
            {
                objDr = Returned.NewRow();
                objDr["GroupElementID"] = objBiz.ID;
                objDr["GroupElementCode"] = objBiz.Code;
                objDr["GroupElementNameA"] = objBiz.NameA;
                objDr["GroupElementNameE"] = objBiz.NameE;
                Returned.Rows.Add(objDr);
            }
            return Returned;
        }
        public GroupElementCol Copy()
        {
            GroupElementCol Returned = new GroupElementCol(true);
            foreach (GroupElementBiz objBiz in this)
                Returned.Add(objBiz);
            return Returned;
        }
        #endregion
    }
}
