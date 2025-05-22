using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using Algorithmat.Algorithmat.AlgorithmatDataBase;
namespace Algorithmat.Algorithmat.AlgorithmatBusiness
{
    public class ImageCol:CollectionBase
    {

        public ImageCol()
        {
 
        }
        public ImageCol(bool blIsEmpty)
        {

        }
        public ImageCol(string strTitle, string strDesc,bool blIsDateRange,DateTime dtStartTime,DateTime dtEndDate,
            CountryBiz objCountryBiz,
            SubjectBiz objSubjectBiz,ImageTypeBiz objTypeBiz,SizeBiz objSizeBiz)
        {
            if (objTypeBiz == null)
                objTypeBiz = new ImageTypeBiz();
            if (objSizeBiz == null)
                objSizeBiz = new SizeBiz();
            ImageDb objImageDb = new ImageDb();
            objImageDb.TitleA = strTitle;
            objImageDb.Desc = strDesc;
            objImageDb.IsDateRange = blIsDateRange;
            objImageDb.StartDate = dtStartTime;
            objImageDb.EndDate = dtEndDate;
            objImageDb.CountryID = objCountryBiz.ID;
            objImageDb.SubjectID = objSubjectBiz.ID;
            objImageDb.Type = objTypeBiz.ID;
            objImageDb.Size = objSizeBiz.ID;
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
        public DataTable GetTable()
        {
            DataTable Returned = new DataTable(ImageDb.TableName);
            Returned.Columns.AddRange(new DataColumn[] { new DataColumn("ImageID"), new DataColumn("ImageTitleA")
                , new DataColumn("ImageShortDesc")  , new DataColumn("ImageDate") 
                , new DataColumn("ImageType") , new DataColumn("ImageMainPath") 
                , new DataColumn("ImagePath") , new DataColumn("ImageName")
            , new DataColumn("ImageSmallName") , new DataColumn("ImageSize")
            , new DataColumn("ImageSmallSize") 
            , new DataColumn("ImageSizeName") , new DataColumn("ImageLanguage")});
            DataRow objDr;
            foreach (ImageBiz objBiz in this)
            {
                objDr = Returned.NewRow();
                objDr["ImageID"] = objBiz.ID;
                objDr["ImageTitleA"] = objBiz.TitleA;
                objDr["ImageShortDesc"] = objBiz.Desc;
                objDr["ImageDate"] = objBiz.Date;
                objDr["ImageType"] = objBiz.TypeBiz.ID;
                objDr["ImageMainPath"] = objBiz.MainPath;
                objDr["ImagePath"] = objBiz.Path;
                objDr["ImageName"] = objBiz.Name;
                objDr["ImageSmallName"] = objBiz.SmallName;
                objDr["ImageSize"] = objBiz.SizeBiz.ID;
                objDr["ImageSmallSize"] = objBiz.SmallBiz.ID;
                objDr["ImageSmallName"] = objBiz.SmallName;
                objDr["ImageSizeName"] = "";
                objDr["ImageLanguage"] = objBiz.Language;
                
                Returned.Rows.Add(objDr);
            }
            return Returned;
        }

    }
}
