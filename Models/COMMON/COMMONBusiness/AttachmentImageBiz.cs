using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.COMMON.COMMONDataBase;
using System.Data;
using SharpVision.Base.BaseBusiness;
using System.IO;

using System.Drawing;
namespace SharpVision.COMMON.COMMONBusiness
{
    public class AttachmentImageBiz : AttachmentFileBiz
    {
        #region Private Data

        #endregion
        #region Constructors
        public AttachmentImageBiz()
            : base()
        {

        }
        public AttachmentImageBiz(int intID)
            : base(intID)
        {

        }
        #endregion
        #region Public Properties
        public static string LocalPath
        {
            get
            {
                string strPath = "";// System.Windows.Forms.Application.StartupPath;
                strPath = strPath + @"\ImageTemp\";
                if (!Directory.Exists(strPath))
                    Directory.CreateDirectory(strPath);
                return strPath;

            }
        }
        public string CurrentLocalPath
        {
            get
            {
                string Returned = LocalPath + ID.ToString() + @"\";
                if (!Directory.Exists(Returned))
                    Directory.CreateDirectory(Returned);
                return Returned;
            }
        }
        public string CurrentLocalCachPath
        {
            get
            {
                string Returned = CurrentLocalPath + LastModifiedDate.ToString("ddMMyyyy") + @"\";
                DirectoryInfo objInfo = new DirectoryInfo(CurrentLocalPath);
                foreach (DirectoryInfo objTemp in objInfo.GetDirectories())
                {
                    if (objTemp.FullName != Returned)
                        objTemp.Delete(true);
                }
                if (!Directory.Exists(Returned))
                    Directory.CreateDirectory(Returned);
                return Returned;
            }
        }
        public override string Path
        {
            get
            {
                string Returned = "";
                if (Name != null && Name != "")
                {

                    Returned = CurrentLocalCachPath + ID.ToString() + Name;

                }

                return Returned;
            }
        }
        public override byte[] Bytes
        {
            set
            {
                _AttachmentDb.Bytes = value;
            }
            get
            {
                if (_AttachmentDb.Bytes == null)
                {
                    if (!File.Exists(Path))
                    {
                        try
                        {

                            DataTable dtTemp = _AttachmentDb.GetFilleByteArr();
                            _AttachmentDb.Bytes = (byte[])dtTemp.Rows[0]["AttachmentFile"];
                            FileStream objFs = new FileStream(Path, FileMode.Create, FileAccess.Write);
                            objFs.Write(_AttachmentDb.Bytes, 0, _AttachmentDb.Bytes.Length);
                            objFs.Close();
                        }
                        catch
                        {
                        }
                    }
                    else
                    {
                        _AttachmentDb.Bytes = ReadFile(Path);


                    }

                }
                return _AttachmentDb.Bytes;
            }
        }
        public Image Image
        {
            get
            {
                if (Bytes == null)
                {
                    return new Bitmap(1, 1);
                }
                MemoryStream Ms = new MemoryStream(Bytes);
                Image Returned = Image.FromStream(Ms);

                return Returned;

            }
        }
        #endregion
        #region Private Methods

        #endregion
        #region Public Methods

        #endregion
    }
}

