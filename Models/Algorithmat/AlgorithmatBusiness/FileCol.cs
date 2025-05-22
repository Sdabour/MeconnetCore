using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using Algorithmat.Algorithmat.AlgorithmatDataBase;
namespace Algorithmat.Algorithmat.AlgorithmatBusiness
{
    public class FileCol:CollectionBase
    {

        public FileCol()
        {
 
        }
        public FileCol(string strTitle, string strDesc,bool blIsDateRange,DateTime dtStartTime,DateTime dtEndDate,
            CountryBiz objCountryBiz,
            SubjectBiz objSubjectBiz,FileTypeBiz objTypeBiz,SizeBiz objSizeBiz)
        {
            if (objTypeBiz == null)
                objTypeBiz = new FileTypeBiz();
            if (objSizeBiz == null)
                objSizeBiz = new SizeBiz();
            FileDb objFileDb = new FileDb();
            objFileDb.TitleA = strTitle;
            objFileDb.Desc = strDesc;
            objFileDb.IsDateRange = blIsDateRange;
            objFileDb.StartDate = dtStartTime;
            objFileDb.EndDate = dtEndDate;
            objFileDb.CountryID = objCountryBiz.ID;
            objFileDb.SubjectID = objSubjectBiz.ID;
            objFileDb.Type = objTypeBiz.ID;
            objFileDb.Size = objSizeBiz.ID;
            DataTable dtTemp = objFileDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
                Add(new FileBiz(objDr));
        }
        public FileBiz this[int intIndex]
        {
            set
            {
                List[intIndex] = this;
            }
            get
            {
                return (FileBiz)List[intIndex];
            }
        }
        public int GetIndex(FileBiz objBiz)
        {
           
            int intIndex = 0;
            foreach (FileBiz objTemp in this)
            {
                if (objTemp.ID == objBiz.ID)
                    return intIndex;
                intIndex++;
            }
            return -1;
        
        }
        public void Add(FileBiz objBiz)
        {
            if(GetIndex(objBiz)==-1)
             List.Add(objBiz);
        }
        public DataTable GetTable()
        {
            DataTable Returned = new DataTable(FileDb.TableName);
            Returned.Columns.AddRange(new DataColumn[] { new DataColumn("FileID"), 
                new DataColumn("FileTitleA"), new DataColumn("FileTitleE"),new DataColumn("FileShortDesc"),
                new DataColumn("FileDate"),new DataColumn("FileType"),new DataColumn("FileMainPath"),
                new DataColumn("FilePath"),new DataColumn("FileName") });
            DataRow objDr;
            foreach (FileBiz objBiz in this)
            {
                objDr = Returned.NewRow();
                objDr["FileID"] = objBiz.ID;
                objDr["FileTitleA"] = objBiz.TitleA;
                objDr["FileTitleE"] = objBiz.TitleE;
                objDr["FileShortDesc"] = objBiz.Desc;
                objDr["FileDate"] = objBiz.Date;
                objDr["FileType"] = objBiz.TypeBiz.ID;
                objDr["FileMainPath"] = objBiz.MainPath;
                objDr["FilePath"] = objBiz.Path;
                objDr["FileName"] = objBiz.Name;
                Returned.Rows.Add(objDr);
            }
            return Returned;
        }

    }
}
