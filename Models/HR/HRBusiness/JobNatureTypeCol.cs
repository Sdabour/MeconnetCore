using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.HR.HRDataBase;
using System.Data;
using SharpVision.Base.BaseBusiness;
using System.Collections;
using SharpVision.SystemBase;
namespace SharpVision.HR.HRBusiness
{
    public class JobNatureTypeCol : CollectionBase
    {
        Hashtable _JobNatureHash = new Hashtable();
        public JobNatureTypeCol()
        {
            JobNatureTypeBiz objJobNatureTypeBiz;           
            JobNatureTypeDb objJobNatureTypeDb = new JobNatureTypeDb();
            DataTable dtJobNatureType = objJobNatureTypeDb.Search();
           
            foreach (DataRow DR in dtJobNatureType.Rows)
            {
                objJobNatureTypeBiz = new JobNatureTypeBiz(DR);
                this.Add(objJobNatureTypeBiz);
            }

        }
        public JobNatureTypeCol(string strIDs,bool blSearchIDs)
        {
            JobNatureTypeBiz objJobNatureTypeBiz;
            JobNatureTypeDb objJobNatureTypeDb = new JobNatureTypeDb();
            objJobNatureTypeDb.IDs = strIDs;
            DataTable dtJobNatureType = objJobNatureTypeDb.Search();
            foreach (DataRow DR in dtJobNatureType.Rows)
            {
                objJobNatureTypeBiz = new JobNatureTypeBiz(DR);
                this.Add(objJobNatureTypeBiz);
            }

        }

        public JobNatureTypeCol(int intJobID)
        {
            JobNatureTypeBiz objJobNatureTypeBiz = new JobNatureTypeBiz(); ;

            JobNatureTypeDb objJobNatureTypeDb = new JobNatureTypeDb();
            objJobNatureTypeDb.JobID = intJobID;
            objJobNatureTypeBiz.ID = 0;
            objJobNatureTypeBiz.NameA = "€Ì— „Õœœ";
            objJobNatureTypeBiz.NameAComp = "";
            objJobNatureTypeBiz.NameE = "Not Specified";
            this.Add(objJobNatureTypeBiz);
            if (intJobID != 0)
            {
                DataTable dtJobNatureType = objJobNatureTypeDb.Search();


                foreach (DataRow DR in dtJobNatureType.Rows)
                {
                    objJobNatureTypeBiz = new JobNatureTypeBiz(DR);

                    this.Add(objJobNatureTypeBiz);
                }
            }

        }
        public JobNatureTypeCol(string strNameAComp, int intJobNatureID)
        {
            JobNatureTypeBiz objJobNatureTypeBiz = new JobNatureTypeBiz(); ;

            JobNatureTypeDb objJobNatureTypeDb = new JobNatureTypeDb();
            objJobNatureTypeDb.JobNatureIDSearch = intJobNatureID;
            objJobNatureTypeDb.NameACompSearch = strNameAComp;
            DataTable dtJobNatureType = objJobNatureTypeDb.Search();
            foreach (DataRow DR in dtJobNatureType.Rows)
            {
                objJobNatureTypeBiz = new JobNatureTypeBiz(DR);

                this.Add(objJobNatureTypeBiz);
            }


        }
        public JobNatureTypeCol(string strNameAComp)
        {
            JobNatureTypeBiz objJobNatureTypeBiz = new JobNatureTypeBiz(); ;

            JobNatureTypeDb objJobNatureTypeDb = new JobNatureTypeDb();            
            objJobNatureTypeDb.NameAComp = strNameAComp;
            DataTable dtJobNatureType = objJobNatureTypeDb.Search();
            foreach (DataRow DR in dtJobNatureType.Rows)
            {
                objJobNatureTypeBiz = new JobNatureTypeBiz(DR);

                this.Add(objJobNatureTypeBiz);
            }


        }
        public JobNatureTypeCol(bool blIsEmpty)
        {
            if (!blIsEmpty)
            {
                JobNatureTypeBiz objJobNatureTypeBiz;
                objJobNatureTypeBiz = new JobNatureTypeBiz();
                objJobNatureTypeBiz.ID = 0;
                objJobNatureTypeBiz.NameA = "€Ì— „Õœœ";
                objJobNatureTypeBiz.NameAComp = "";
                this.Add(objJobNatureTypeBiz);
                JobNatureTypeDb objJobNatureTypeDb = new JobNatureTypeDb();
                DataTable dtJobNatureType = objJobNatureTypeDb.Search();


                foreach (DataRow DR in dtJobNatureType.Rows)
                {
                    objJobNatureTypeBiz = new JobNatureTypeBiz(DR);

                    this.Add(objJobNatureTypeBiz);
                }
            }

        }
        public JobNatureTypeCol(byte byJobCategoryEstimationStatus)
        {
            JobNatureTypeBiz objJobNatureTypeBiz;
            JobNatureTypeDb objJobNatureTypeDb = new JobNatureTypeDb();
            objJobNatureTypeDb.JobCategoryEstimation = byJobCategoryEstimationStatus;
            DataTable dtJobNatureType = objJobNatureTypeDb.Search();
            foreach (DataRow DR in dtJobNatureType.Rows)
            {
                objJobNatureTypeBiz = new JobNatureTypeBiz(DR);
                this.Add(objJobNatureTypeBiz);
            }

        }
        public JobNatureTypeCol(byte byJobCategoryEstimationStatus,string strJobIDs)
        {
            JobNatureTypeBiz objJobNatureTypeBiz;
            JobNatureTypeDb objJobNatureTypeDb = new JobNatureTypeDb();
            objJobNatureTypeDb.JobCategoryEstimation = byJobCategoryEstimationStatus;
            objJobNatureTypeDb.IDs = strJobIDs;
            DataTable dtJobNatureType = objJobNatureTypeDb.Search();
            foreach (DataRow DR in dtJobNatureType.Rows)
            {
                objJobNatureTypeBiz = new JobNatureTypeBiz(DR);
                this.Add(objJobNatureTypeBiz);
            }

        }
        public virtual JobNatureTypeBiz this[int intIndex]
        {
            get
            {

                return (JobNatureTypeBiz)this.List[intIndex];

         }   }
        public virtual JobNatureTypeBiz this[string strIndex]
        {
            get
            {
                JobNatureTypeBiz Returned = new JobNatureTypeBiz();
                foreach (JobNatureTypeBiz objJobNatureTypeBiz in this)
                {
                    if (objJobNatureTypeBiz.Name == strIndex)
                    {
                        Returned = objJobNatureTypeBiz.Copy();
                        break;
                    }
                }
                return Returned;
            }
        }
        public string IDsStr
        {
            get
            {
                string Returned = "";
                foreach (JobNatureTypeBiz objBiz in this)
                {
                    if (Returned != "")
                        Returned += ",";
                    Returned += objBiz.ID.ToString();
                  
                }
                return Returned;
            }
        }

        public string Name
        {
            get
            {
                string Returned = "";
                foreach (JobNatureTypeBiz objBiz in this)
                {
                    if(Returned != "")
                        Returned += " Ê ";
                    Returned += objBiz.Name;
                }
                return Returned;
            }
        }
        public virtual void Add(JobNatureTypeBiz objJobNatureTypeBiz)
        {

            if (GetIndex(objJobNatureTypeBiz.ID) == -1)
            {
                _JobNatureHash.Add(objJobNatureTypeBiz.ID.ToString(), Count);
                this.List.Add(objJobNatureTypeBiz);
            }

        }
        public virtual void Add(JobNatureTypeCol objJobNatureTypeCol)
        {
            foreach (JobNatureTypeBiz objJobNatureTypeBiz in objJobNatureTypeCol)
            {
                Add(objJobNatureTypeBiz);

            }
        }
        public int GetIndex(int intID)
        {
            //for (int intIndex = 0; intIndex < Count; intIndex++)
            //{
            //    if (this[intIndex].ID == intID)
            //        return intIndex;
            //}
            if (_JobNatureHash[intID.ToString()] == null)
                return -1;
            else
                return (int)_JobNatureHash[intID.ToString()];
        }
        public JobNatureTypeCol Copy()
        {
            JobNatureTypeCol Returned = new JobNatureTypeCol(true);
            foreach (JobNatureTypeBiz objTemp in this)
            {
                Returned.Add(objTemp.Copy());
            }
            return Returned;
        }
        public JobNatureTypeCol GetCol(string strName)
        {
            JobNatureTypeCol objCol = new JobNatureTypeCol(true);
            
            foreach (JobNatureTypeBiz objBiz in this)
            {
               // if(SysUtility.ReplaceStringComp(objBiz.Name).IndexOf(SysUtility.ReplaceStringComp(strName))!= -1)
                if(objBiz.Name.CheckStr(strName))
                   objCol.Add(objBiz);
            }
            return objCol;
        }
        public JobNatureTypeCol GetJobNatureTypeOrderByCol()
        {
            JobNatureTypeCol objCol = new JobNatureTypeCol(true);
            JobNatureTypeDb objDb = new JobNatureTypeDb();
            objDb.IDs = IDsStr;
            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
            {
                objCol.Add(new JobNatureTypeBiz(objDr));
            }
            return objCol;
        }
        public JobNatureTypeCol GetJobNatureTypeCol(string strName)
        {
            JobNatureTypeCol Returned = new JobNatureTypeCol(true);
            strName = strName.Replace(" ", "");
            foreach (JobNatureTypeBiz objBiz in this)
            {
                if (objBiz.Name.CheckStr(strName))
                {
                    Returned.Add(objBiz);
                }
            }
            return Returned;
        }

        public JobCategoryEstimationCol GetJobCategoryEstimationCol(bool IsEmpty)
        {
            JobCategoryEstimationCol objCol = new JobCategoryEstimationCol(true);
            if (IsEmpty)
            {
                JobCategoryEstimationBiz obj = new JobCategoryEstimationBiz();
                objCol.Add(obj);
            }
            foreach (JobNatureTypeBiz objBiz in this)
            {
                if (objBiz.JobCategoryEstimationBiz.ID != 0)
                {
                    objCol.Add(objBiz.JobCategoryEstimationBiz);
                }
            }
            return objCol;
        }

        public static JobNatureTypeBiz GetJobNatureTypeBiz(int intID)
        {
            foreach (JobNatureTypeBiz objBiz in JobNatureTypeCol.CacheJobNatureTypeCol)
            {
                if (objBiz.ID == intID)
                {
                    return objBiz;
                }
            }
            return new JobNatureTypeBiz();
        }

        static JobNatureTypeCol _CacheJobNatureTypeCol;
        public static JobNatureTypeCol CacheJobNatureTypeCol
        {
            set
            {
                _CacheJobNatureTypeCol = value;
            }
            get
            {
                if (_CacheJobNatureTypeCol == null)
                {
                    _CacheJobNatureTypeCol = new JobNatureTypeCol(false);
                }
                return _CacheJobNatureTypeCol;
            }
        }
    }
}
