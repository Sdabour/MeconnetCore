using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using SharpVision.COMMON.COMMONDataBase;
namespace SharpVision.COMMON.COMMONBusiness
{
    public class ImageCol:CollectionBase
    {
        public ImageCol()
        {
 
        }
        public ImageCol(string strTitle, string strDesc,bool blIsDateRange,DateTime dtStartTime,DateTime dtEndDate,CountryBiz objCountryBiz,SubjectBiz objSubjectBiz)
        {
            ImageDb objImageDb = new ImageDb();
            objImageDb.Title = strTitle;
            objImageDb.Desc = strDesc;
            objImageDb.IsDateRange = blIsDateRange;
            objImageDb.StartDate = dtStartTime;
            objImageDb.EndDate = dtEndDate;
            objImageDb.CountryID = objCountryBiz.ID;
            objImageDb.SubjectID = objSubjectBiz.ID;
            DataTable dtTemp = objImageDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
                Add(new ImageBiz(objDr));
        }
        public ImageBiz this[int intIndex]
        {
            set
            {
                List[intIndex] = this;
            }
            get
            {
                return (ImageBiz)List[intIndex];
            }
        }
        public int GetIndex(ImageBiz objBiz)
        {
           
            int intIndex = 0;
            foreach (ImageBiz objTemp in this)
            {
                if (objTemp.ID == objBiz.ID)
                    return intIndex;
                intIndex++;
            }
            return -1;
        
        }
        public void Add(ImageBiz objBiz)
        {
            if(GetIndex(objBiz)==-1)
             List.Add(objBiz);
        }
    }
}
