using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.UMS.UMSDataBase;
using System.Collections;
namespace SharpVision.UMS.UMSBusiness
{
    public class SystemCol : CollectionBase
    {
        public SystemCol()
        {
            SystemDb objSystemDb = new SystemDb();

            SystemBiz objSystemBiz;
            foreach (DataRow DR in objSystemDb.Search().Rows)
            {
                objSystemBiz = new SystemBiz(DR);
                this.Add(objSystemBiz);

            }


        }
        public SystemCol(bool blIsEmpty)
        {
 
        }
      
        public bool Contains(string strName)
        {
            bool blReturned = false;
            foreach (SystemBiz objSystemBiz in this)
            {
                if (objSystemBiz.Name == strName)
                {
                    blReturned = true;
                    break;
                }
            }
            return blReturned;

        }
        public virtual SystemBiz this[int intIndex]
        {
            get
            {

                return (SystemBiz)this.List[intIndex];

            }
        }

        public virtual SystemBiz this[string strIndex]
        {
            get
            {
                SystemBiz Returned = new SystemBiz();
                foreach (SystemBiz objSystemBiz in this)
                {
                    if (objSystemBiz.Name == strIndex)
                    {
                        Returned = objSystemBiz.Copy();
                        break;
                    }
                }
                return Returned;
            }
        }
        public virtual void Add(SystemBiz objSystemBiz)
        {
                this.List.Add(objSystemBiz);

        }
       
        public SystemCol Copy()
        {
            SystemCol Returned = new SystemCol(true);
            foreach (SystemBiz objTemp in this)
            {
                Returned.Add(objTemp.Copy());
            }
            return Returned;
        }
        public SystemCol GetCol(string strName)
        {
            SystemCol Returned = new SystemCol(true);
            foreach (SystemBiz objBiz in this)
                if (objBiz.Name.CheckUmsStr(strName))
                    Returned.Add(objBiz);
            return Returned;
        }

    }
}

