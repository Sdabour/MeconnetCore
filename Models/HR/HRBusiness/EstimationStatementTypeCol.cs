
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.HR.HRDataBase;
using System.Collections;
namespace SharpVision.HR.HRBusiness
{
    public class EstimationStatementTypeCol : CollectionBase
    {
        public EstimationStatementTypeCol()
        {
            EstimationStatementTypeDb objDb = new EstimationStatementTypeDb();

            EstimationStatementTypeBiz objBiz;
            foreach (DataRow DR in objDb.Search().Rows)
            {
                objBiz = new EstimationStatementTypeBiz(DR);
                this.Add(objBiz);

            }


        }
        public EstimationStatementTypeCol(int intID)
        {
            EstimationStatementTypeDb objDb = new EstimationStatementTypeDb();
            objDb.ID = intID;
            EstimationStatementTypeBiz objBiz;
            foreach (DataRow DR in objDb.Search().Rows)
            {
                objBiz = new EstimationStatementTypeBiz(DR);
                this.Add(objBiz);

            }


        }
        public EstimationStatementTypeCol(bool blIsEmpty)
        {
            if (!blIsEmpty)
            {
                EstimationStatementTypeDb objDb = new EstimationStatementTypeDb();

                EstimationStatementTypeBiz objBiz;
                objBiz = new EstimationStatementTypeBiz();
                objBiz.ID = 0;
                objBiz.NameA = "غير محدد";
                objBiz.NameE = "Not Specified";
                this.Add(objBiz);
                foreach (DataRow DR in objDb.Search().Rows)
                {
                    objBiz = new EstimationStatementTypeBiz(DR);
                    this.Add(objBiz);

                }


 
            }


        }

        public bool Contains(string strName)
        {
            bool blReturned = false;
            foreach (EstimationStatementTypeBiz objBiz in this)
            {
                if (objBiz.Name == strName)
                {
                    blReturned = true;
                    break;
                }
            }
            return blReturned;

        }
        public virtual EstimationStatementTypeBiz this[int intIndex]
        {
            get
            {

                return (EstimationStatementTypeBiz)this.List[intIndex];

            }
        }

        public virtual EstimationStatementTypeBiz this[string strIndex]
        {
            get
            {
                EstimationStatementTypeBiz Returned = new EstimationStatementTypeBiz();
                foreach (EstimationStatementTypeBiz objStatementTypeBiz in this)
                {
                    if (objStatementTypeBiz.Name == strIndex)
                    {
                        Returned = objStatementTypeBiz.Copy();
                        break;
                    }
                }
                return Returned;
            }
        }
        public virtual void Add(EstimationStatementTypeBiz objBiz)
        {
            this.List.Add(objBiz);

        }

        public EstimationStatementTypeCol Copy()
        {
            EstimationStatementTypeCol Returned = new EstimationStatementTypeCol(true);
            foreach (EstimationStatementTypeBiz objTemp in this)
            {
                Returned.Add(objTemp.Copy());
            }
            return Returned;
        }
        public static EstimationStatementTypeBiz GetEstimationStatementTypeBiz(int intID)
        {
            foreach (EstimationStatementTypeBiz objBiz in EstimationStatementTypeCol.CacheEstimationStatementTypeCol)
            {
                if (objBiz.ID == intID)
                {
                    return objBiz;
                }
            }
            return new EstimationStatementTypeBiz();
        }

        static EstimationStatementTypeCol _CacheEstimationStatementTypeCol;
        public static EstimationStatementTypeCol CacheEstimationStatementTypeCol
        {
            set
            {
                _CacheEstimationStatementTypeCol = value;
            }
            get
            {
                if (_CacheEstimationStatementTypeCol == null)
                {
                    _CacheEstimationStatementTypeCol = new EstimationStatementTypeCol(false);
                }
                return _CacheEstimationStatementTypeCol;
            }
        }
        public EstimationStatementTypeCol GetCol(string strFilter)
        {
            EstimationStatementTypeCol Returned = new EstimationStatementTypeCol(true);
            bool blIsFound = true;
            string[] arrStr = strFilter.Split("%".ToCharArray());
            foreach (EstimationStatementTypeBiz objBiz in this)
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

