
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.HR.HRDataBase;
using System.Collections;
namespace SharpVision.HR.HRBusiness
{
    public class SectorTypeCol : CollectionBase
    {
        public SectorTypeCol()
        {
            SectorTypeBiz objSectorTypeBiz;

            SectorTypeDb objSectorTypeDb = new SectorTypeDb();
            DataTable dtSectorType = objSectorTypeDb.Search();


            foreach (DataRow DR in dtSectorType.Rows)
            {
                objSectorTypeBiz = new SectorTypeBiz(DR);

                this.Add(objSectorTypeBiz);
            }

        }
        public SectorTypeCol(bool blIsEmpty)
        {
            if (!blIsEmpty)
            {
                SectorTypeBiz objSectorTypeBiz;
                objSectorTypeBiz = new SectorTypeBiz();
                objSectorTypeBiz.ID = 0;
                objSectorTypeBiz.NameA = "غير محدد";
                this.Add(objSectorTypeBiz);
                SectorTypeDb objSectorTypeDb = new SectorTypeDb();
                DataTable dtSectorType = objSectorTypeDb.Search();


                foreach (DataRow DR in dtSectorType.Rows)
                {
                    objSectorTypeBiz = new SectorTypeBiz(DR);

                    this.Add(objSectorTypeBiz);
                }
            }

        }
        public virtual SectorTypeBiz this[int intIndex]
        {
            get
            {

                return (SectorTypeBiz)this.List[intIndex];

            }
        }
        public virtual SectorTypeBiz this[string strIndex]
        {
            get
            {
                SectorTypeBiz Returned = new SectorTypeBiz();
                foreach (SectorTypeBiz objSectorTypeBiz in this)
                {
                    if (objSectorTypeBiz.NameA == strIndex)
                    {
                        Returned = objSectorTypeBiz.Copy();
                        break;
                    }
                }
                return Returned;
            }
        }
        public virtual void Add(SectorTypeBiz objSectorTypeBiz)
        {
            if (this[objSectorTypeBiz.NameA].NameA == null || this[objSectorTypeBiz.NameA].NameA == "")
            {
                this.List.Add(objSectorTypeBiz.Copy());
            }

        }
        public virtual void Add(SectorTypeCol objSectorTypeCol)
        {
            foreach (SectorTypeBiz objSectorTypeBiz in objSectorTypeCol)
            {
                if (this[objSectorTypeBiz.NameA].ID == 0)
                    this.List.Add(objSectorTypeBiz.Copy());

            }
        }
        public SectorTypeCol Copy()
        {
            SectorTypeCol Returned = new SectorTypeCol(true);
            foreach (SectorTypeBiz objTemp in this)
            {
                Returned.Add(objTemp.Copy());
            }
            return Returned;
        }
        public static SectorTypeBiz GetSectorTypeBiz(int intID)
        {
            foreach (SectorTypeBiz objBiz in SectorTypeCol.CacheSectorTypeCol)
            {
                if (objBiz.ID == intID)
                {
                    return objBiz;
                }
            }
            return new SectorTypeBiz();
        }

        static SectorTypeCol _CacheSectorTypeCol;
        public static SectorTypeCol CacheSectorTypeCol
        {
            set
            {
                _CacheSectorTypeCol = value;
            }
            get
            {
                if (_CacheSectorTypeCol == null)
                {
                    _CacheSectorTypeCol = new SectorTypeCol(false);
                }
                return _CacheSectorTypeCol;
            }
        }
        public SectorTypeCol GetCol(string strFilter)
        {
            SectorTypeCol Returned = new SectorTypeCol(true);
            bool blIsFound = true;
            string[] arrStr = strFilter.Split("%".ToCharArray());
            foreach (SectorTypeBiz objBiz in this)
            {
                blIsFound = true;
                foreach (string strTemp in arrStr)
                {
                    if (objBiz.Code != "" && objBiz.Code.IndexOf(strTemp) == -1 &&
                        objBiz.NameA.IndexOf(strTemp) == -1 && objBiz.NameE.IndexOf(strTemp) == -1)
                        blIsFound = false;

                }
                if (blIsFound)
                    Returned.Add(objBiz);
            }
            return Returned;
        }
    }
}

