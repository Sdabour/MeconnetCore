
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.HR.HRDataBase;
using System.Collections;
namespace SharpVision.HR.HRBusiness
{
    public class DetailTypeCol : CollectionBase
    {
        public DetailTypeCol()
        {
            DetailTypeDb objDetailTypeDb = new DetailTypeDb();

            DetailTypeBiz objDetailTypeBiz;
            foreach (DataRow DR in objDetailTypeDb.Search().Rows)
            {
                objDetailTypeBiz = new DetailTypeBiz(DR);
                this.Add(objDetailTypeBiz);

            }


        }
        public DetailTypeCol(bool blIsEmpty)
        {
            if (!blIsEmpty)
            {
                DetailTypeDb objDetailTypeDb = new DetailTypeDb();

                DetailTypeBiz objDetailTypeBiz;
                objDetailTypeBiz = new DetailTypeBiz();
                objDetailTypeBiz.ID = 0;
                objDetailTypeBiz.NameA = "غير محدد";
                objDetailTypeBiz.NameE = "Not Specified";
                this.Add(objDetailTypeBiz);
                foreach (DataRow DR in objDetailTypeDb.Search().Rows)
                {
                    objDetailTypeBiz = new DetailTypeBiz(DR);
                    this.Add(objDetailTypeBiz);

                }


 
            }


        }

        public bool Contains(string strName)
        {
            bool blReturned = false;
            foreach (DetailTypeBiz objDetailTypeBiz in this)
            {
                if (objDetailTypeBiz.Name == strName)
                {
                    blReturned = true;
                    break;
                }
            }
            return blReturned;

        }
        public virtual DetailTypeBiz this[int intIndex]
        {
            get
            {

                return (DetailTypeBiz)this.List[intIndex];

            }
        }

        public virtual DetailTypeBiz this[string strIndex]
        {
            get
            {
                DetailTypeBiz Returned = new DetailTypeBiz();
                foreach (DetailTypeBiz objDetailTypeBiz in this)
                {
                    if (objDetailTypeBiz.Name == strIndex)
                    {
                        Returned = objDetailTypeBiz.Copy();
                        break;
                    }
                }
                return Returned;
            }
        }
        public virtual void Add(DetailTypeBiz objDetailTypeBiz)
        {
            this.List.Add(objDetailTypeBiz);

        }
        public DetailTypeCol GetCol(string strFilter)
        {
            DetailTypeCol Returned = new DetailTypeCol(true);
            bool blIsFound = true;
            string[] arrStr = strFilter.Split("%".ToCharArray());
            foreach (DetailTypeBiz objBiz in this)
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
        public DetailTypeCol Copy()
        {
            DetailTypeCol Returned = new DetailTypeCol(true);
            foreach (DetailTypeBiz objTemp in this)
            {
                Returned.Add(objTemp.Copy());
            }
            return Returned;
        }

    }
}

