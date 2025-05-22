using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using SharpVision.SystemBase;
namespace SharpVision.HR.HRDataBase
{
   public  class ApplicantImageDb
    {

        #region Constructor
        public ApplicantImageDb()
        {
        }
        public ApplicantImageDb(DataRow objDr)
        {
            SetData(objDr);
        }

        #endregion
        #region Properties
        int _ID;
        public int ID
        {
            set
            {
                _ID = value;
            }
            get
            {
                return _ID;
            }
        }
        int _Image;
        public int Image
        {
            set
            {
                _Image = value;
            }
            get
            {
                return _Image;
            }
        }
        string _ImageName;
        public string ImageName
        {
            set
            {
                _ImageName = value;
            }
            get
            {
                return _ImageName;
            }
        }
        public string AddStr
        {
            get
            {
                string Returned = @" insert into HRApplicantImage (ApplicantID,ApplicantImage,ApplicantImageName,UsrIns,TimIns) select " + ID + " as AppID," + Image + ",'" + ImageName + "'," + SysData.CurrentUser.ID + @",GetDate()  FROM            dbo.HRApplicant
WHERE        (ApplicantID = " + ID + @") 
   and not exists (SELECT        ApplicantID
FROM            dbo.HRApplicantImage
WHERE        (ApplicantID = " + ID + @"))  " +
                    " ";
                Returned += @" update        HRApplicantImage_1 set ApplicantImage= derivedtbl_1.MaxID + 1 
FROM            (SELECT        ISNULL(MAX(ApplicantImage), 0) AS MaxID
                           FROM            dbo.HRApplicantImage
                           WHERE        (ApplicantID <> "+_ID+@")) AS derivedtbl_1 CROSS JOIN
                         dbo.HRApplicantImage AS HRApplicantImage_1
WHERE        (HRApplicantImage_1.ApplicantID = "+_ID+ @") 
  update HRApplicantImage set ApplicantImageName = '"+ ImageName + @"'
  where ApplicantID = ApplicantID
    SELECT        ApplicantImage 
FROM            dbo.HRApplicantImage
WHERE        (ApplicantID = " + ID+") ";
                return Returned;
            }
        }
        public string EditStr
        {
            get
            {
                string Returned = " update HRApplicantImage set " + "ApplicantID=" + ID + "" +
           ",ApplicantImage=" + Image + "" +
           ",ApplicantImageName='" + ImageName + "'" + ",UsrUpd=" + SysData.CurrentUser.ID + @",TimUpd=GetDate()  where ";
                return Returned;
            }
        }
        public string DeleteStr
        {
            get
            {
                string Returned = " update HRApplicantImage set Dis = GetDate() where  ";
                return Returned;
            }
        }
        public string SearchStr
        {
            get
            {
                string Returned = " select ApplicantID as ImageApplicantID,ApplicantImage,ApplicantImageName from HRApplicantImage  ";
                return Returned;
            }
        }
        #endregion
        #region Private Method
        void SetData(DataRow objDr)
        {

            if (objDr.Table.Columns["ImageApplicantID"] != null)
                int.TryParse(objDr["ImageApplicantID"].ToString(), out _ID);

            if (objDr.Table.Columns["ApplicantImage"] != null)
                int.TryParse(objDr["ApplicantImage"].ToString(), out _Image);

            if (objDr.Table.Columns["ApplicantImageName"] != null)
                _ImageName = objDr["ApplicantImageName"].ToString();
        }

        #endregion
        #region Public Method 
        public void Add()
        {
             string strSql = AddStr;
          object objTemp =  SysData.SharpVisionBaseDb.ReturnScalar(strSql);
            if (objTemp != null)
                int.TryParse(objTemp.ToString(), out _Image);
        }
        public void Edit()
        {
            string strSql = EditStr;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public void Delete()
        {
            string strSql = DeleteStr;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public DataTable Search()
        {
            string strSql = SearchStr + " where Dis is null ";


            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        #endregion
    }
}
