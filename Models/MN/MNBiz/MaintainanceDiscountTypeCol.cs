using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using AlgorithmatMN.MN.MNDb;
using System.Collections;
using SharpVision.SystemBase;
namespace AlgorithmatMN.MN.MNBiz
{
    public  class MaintainanceDiscountTypeCol:CollectionBase
    {

        #region Constructor
        public MaintainanceDiscountTypeCol()
        {
            MaintainanceDiscountTypeBiz objBiz = new MaintainanceDiscountTypeBiz();
         

            MaintainanceDiscountTypeDb objDb = new MaintainanceDiscountTypeDb();

            DataTable dtTemp = objDb.Search();


            foreach (DataRow objDR in dtTemp.Rows)
            {
                objBiz = new MaintainanceDiscountTypeBiz(objDR);
                Add(objBiz);
            }
        }
        public MaintainanceDiscountTypeCol(bool blIsEmbty)
        {
            if (blIsEmbty)
                return;
            MaintainanceDiscountTypeBiz objBiz = new MaintainanceDiscountTypeBiz();
            objBiz.ID = 0;
            objBiz.NameA = "غير محدد";
            objBiz.NameE = "Not Specified";
            Add(objBiz);

            MaintainanceDiscountTypeDb objDb = new MaintainanceDiscountTypeDb();

            DataTable dtTemp = objDb.Search();


            foreach (DataRow objDR in dtTemp.Rows)
            {
                objBiz = new MaintainanceDiscountTypeBiz(objDR);
                Add(objBiz);
            }
        }

        #endregion
        #region Private Data

        #endregion
        #region Properties
        public MaintainanceDiscountTypeBiz this[int intIndex]
        {
            get
            {
                return (MaintainanceDiscountTypeBiz)this.List[intIndex];
            }
        }
        #endregion
        #region Private Method

        #endregion
        #region Public Method 
        public void Add(MaintainanceDiscountTypeBiz objBiz)
        {
            List.Add(objBiz);
        }
        public MaintainanceDiscountTypeCol GetCol(string strTemp)
        {
            MaintainanceDiscountTypeCol Returned = new MaintainanceDiscountTypeCol(true);
            foreach (MaintainanceDiscountTypeBiz objBiz in this)
            {
                if (objBiz.NameA.CheckStr(strTemp))
                    Returned.Add(objBiz);
            }
            return Returned;
        }
        public DataTable GetTable()
        {
            DataTable Returned = new DataTable();
            Returned.Columns.AddRange(new DataColumn[] { new DataColumn("DiscountTypeID"), new DataColumn("DiscountTypeCode"), new DataColumn("DiscountTypeNameA"), new DataColumn("DiscountTypeNameE") });
            DataRow objDr;
            foreach (MaintainanceDiscountTypeBiz objBiz in this)
            {
                objDr = Returned.NewRow();
                objDr["DiscountTypeID"] = objBiz.ID;
                objDr["DiscountTypeCode"] = objBiz.Code;
                objDr["DiscountTypeNameA"] = objBiz.NameA;
                objDr["DiscountTypeNameE"] = objBiz.NameE;
                Returned.Rows.Add(objDr);
            }
            return Returned;
        }
        public MaintainanceDiscountTypeCol Copy()
        { MaintainanceDiscountTypeCol Returned = new MaintainanceDiscountTypeCol(true);
            foreach (MaintainanceDiscountTypeBiz objBiz in this)
                Returned.Add(objBiz);
            return Returned;
        }
        #endregion
    }
}
