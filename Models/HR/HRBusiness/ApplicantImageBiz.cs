using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using SharpVision.HR.HRDataBase;
using System.Drawing;
using System.IO;
using SharpVision.SystemBase;
namespace SharpVision.HR.HRBusiness
{
    public delegate void ImageAdded();
    public class ApplicantImageBiz
    {

        #region Constructor
        public ApplicantImageBiz()
        {
            _ApplicantImageDb = new ApplicantImageDb();
        }
        public ApplicantImageBiz(DataRow objDr)
        {
            _ApplicantImageDb = new ApplicantImageDb(objDr);
        }

        #endregion
        #region Private Data
        ApplicantImageDb _ApplicantImageDb;
        #endregion
        #region Properties
        public int ID
        {
            set
            {
                _ApplicantImageDb.ID = value;
            }
            get
            {
                return _ApplicantImageDb.ID;
            }
        }
        public int ImageID
        {
            set
            {
                _ApplicantImageDb.Image = value;
            }
            get
            {
                return _ApplicantImageDb.Image;
            }
        }
        public string ImageName
        {
            set
            {
                _ApplicantImageDb.ImageName = value;
            }
            get
            {
                return _ApplicantImageDb.ImageName;
            }
        }

        string _Path;
        public string Path
        {
            
            get
            {
                int intRemaining = ImageID % 100;
                intRemaining = ImageID - intRemaining + 1;
                string Returned = intRemaining.ToString();
                return Returned;
                //int intRemaining = ImageID % 100 ;
                //intRemaining = ImageID - intRemaining + 1;
                //string Returned = intRemaining.ToString()+@"\"+ ID.ToString();
                //return Returned;
            }
        }
        public string URL
        {

            get
            {
                int intRemaining = ImageID % 100;
                intRemaining = ImageID - intRemaining + 1;
                string Returned = intRemaining.ToString() ;
                return Returned;
            }
        }
        string _MainPath;
        public string MainPath { get => SysData.AplicantImageMainPath; }
        public string MainURL { get => SysData.AplicantImageMainURL; }
        string _ForignPath;

        public string ForignPath
        {
            get { return _ForignPath; }
            set { _ForignPath = value; }
        }
        public string FullPath
        {
            get
            {
                string Returned = ForignPath == null ? "" : ForignPath;

                string strTemp = "";
                if (ID != 0 && ImageName != "")
                {
                    strTemp = MainPath + @"\" + Path + @"\" + ImageName;
                }
                if (strTemp != "")
                    Returned = strTemp;
                return Returned;
            }
        }

        public string FullURL
        {
            get
            {
                string Returned = "";

                string strTemp = "";
                if (ID != 0 && ImageName != "")
                {
                    strTemp = MainURL + @"/" + URL + @"/" + ImageName;
                }
                if (strTemp != "")
                    Returned = strTemp;
                return Returned;
            }
        }
        public string FullDirectory
        {
            get
            {
                string Returned = "";
                string strTemp = "";
                if (ID != 0)
                {
                    strTemp = MainPath + @"\" + Path + @"\";
                }
                if (strTemp != "")
                    Returned = strTemp;
                return Returned;
            }
        }
        public  Image Image
        {

            get
            {
                return Image.FromFile(FullPath);
                //return AttachmentBiz.Image;
            }
        }
        public ImageAdded NewImageAdded = new ImageAdded(OnNewImageAdded);
        #endregion
        #region Private Method

        #endregion
        #region Public Method 
        public void Add()
        {
            _ApplicantImageDb.Add();
            NewImageAdded();
        }
        public void Edit()
        {
            _ApplicantImageDb.Edit();
            NewImageAdded();
        }
        public void Delete()
        {
            _ApplicantImageDb.Delete();
        }
        public static void OnNewImageAdded()
        { }
        #endregion
    }
}
