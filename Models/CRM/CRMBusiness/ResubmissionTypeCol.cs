using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.Base.BaseBusiness;
using SharpVision.CRM.CRMDataBase;
using SharpVision.SystemBase;

namespace SharpVision.CRM.CRMBusiness
{
    public class ResubmissionTypeCol : BaseCol
    {
        static ResubmissionTypeCol _CacheTypeCol;

        public static ResubmissionTypeCol CacheTypeCol
        {
            get {
                if (_CacheTypeCol == null)
                {
                    _CacheTypeCol = new ResubmissionTypeCol(false);
                }
                return ResubmissionTypeCol._CacheTypeCol; }
            set { ResubmissionTypeCol._CacheTypeCol = value; }
        }
        public ResubmissionTypeCol(bool blIsEmpty)
        {
            if (blIsEmpty)
                return;
            ResubmissionTypeDb objDb = new ResubmissionTypeDb();

            DataTable dtTemp = objDb.Search();
            ResubmissionTypeBiz objBiz = new ResubmissionTypeBiz();
            objBiz.ID = 0;
            objBiz.NameA = "غير محدد";
            Add(objBiz);
            foreach (DataRow objDR in dtTemp.Rows)
            {
                //objBiz = new ResubmissionTypeBiz(objDR);
                //this.Add(objBiz);
                Add(new ResubmissionTypeBiz(objDR));
            }

        }
        public ResubmissionTypeCol()
        {
            ResubmissionTypeDb objDb = new ResubmissionTypeDb();

            DataTable dtTemp = objDb.Search();
            ResubmissionTypeBiz objBiz = new ResubmissionTypeBiz();
            foreach (DataRow objDR in dtTemp.Rows)
            {
                Add(new ResubmissionTypeBiz(objDR));
            }

        }
        public ResubmissionTypeCol(int intID)
        {
            ResubmissionTypeDb objDb = new ResubmissionTypeDb();
            objDb.ID = intID;
            DataTable dtTemp = objDb.Search();
            ResubmissionTypeBiz objBiz;

            foreach (DataRow objDR in dtTemp.Rows)
            {
                objBiz = new ResubmissionTypeBiz(objDR);
                this.Add(objBiz);
            }

        }

        public virtual ResubmissionTypeBiz this[int intIndex]
        {
            get
            {
                return (ResubmissionTypeBiz)this.List[intIndex];
            }
        }
        public string IDs
        {
            get
            {
                string Returned = "";
                foreach (ResubmissionTypeBiz objBiz in this)
                {
                    if (objBiz.ID == 0)
                        continue;
                    if (Returned != "")
                        Returned += ",";
                    Returned += objBiz.ID.ToString();
                }
                return Returned;
            }
        }
        public virtual void Add(ResubmissionTypeBiz objBiz)
        {

            this.List.Add(objBiz);
        }
        public ResubmissionTypeCol GetCol(string strName)
        {
            ResubmissionTypeCol Returned = new ResubmissionTypeCol(true);
            bool blIsFound = true;
            string[] arrStr;
            foreach (ResubmissionTypeBiz objBiz in this)
            {
                arrStr = strName.Split("%".ToCharArray());
                blIsFound = true;
                foreach (string strTemp in arrStr)
                {
                    if (objBiz.Name.IndexOf(strTemp) == -1 && objBiz.Code.IndexOf(strTemp) == -1)
                    {
                        blIsFound = false;
                        break;
                    }
                }
                if (blIsFound)
                    Returned.Add(objBiz);
                
            }
            return Returned;
        }
        public ResubmissionTypeCol Copy()
        {
            ResubmissionTypeCol Returned = new ResubmissionTypeCol(true);
            foreach (ResubmissionTypeBiz objBiz in this)
                Returned.Add(objBiz);
            return Returned;
        }
    }
}
