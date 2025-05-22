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
    public class AttachmentFileBiz
    {
        #region Private Data
        protected AttachmentFileDb _AttachmentDb;
        string _FilePath;
        #endregion
        #region Constructors
        public AttachmentFileBiz()
        {
            _AttachmentDb = new AttachmentFileDb();
        }
        public AttachmentFileBiz(int intID)
        {
            _AttachmentDb = new AttachmentFileDb(intID);
        }

        #endregion
        #region Public Properties
        public int ID
        {

            set
            {
                _AttachmentDb.ID = value;
            }
            get
            {
                return _AttachmentDb.ID;
            }
        }
        public string Name
        {
            set
            {
                _AttachmentDb.Name = value;
            }
            get
            {
                return _AttachmentDb.Name;
            }
        }
        internal DateTime LastModifiedDate
        {
            get
            {
                return _AttachmentDb.LastModifiedDate;
            }

        }
        public virtual string Path
        {
            get
            {
                string Returned = "";
                if (Name != null && Name != "")
                {

                    Returned = LocalPath + ID.ToString() + Name;

                }

                return Returned;
            }
        }
        public string FilePath
        {
            set
            {
                _FilePath = value;
            }
            get
            {
                return _FilePath;
            }
        }
        public static string LocalPath
        {
            get
            {
                string strPath ="" ;// System.Windows.Forms.Application.StartupPath;
                strPath = strPath + @"\FileTemp\";
                if (!Directory.Exists(strPath))
                    Directory.CreateDirectory(strPath);
                return strPath;

            }
        }

        public virtual byte[] Bytes
        {
            set
            {
                _AttachmentDb.Bytes = value;
            }
            get
            {
                if (_AttachmentDb.Bytes == null)
                {
                
                        try
                        {

                            DataTable dtTemp = _AttachmentDb.GetFilleByteArr();
                            _AttachmentDb.Bytes = (byte[])dtTemp.Rows[0]["AttachmentFile"];

                        }
                        catch
                        {
                        }
                
                }
                return _AttachmentDb.Bytes;
            }
        }
        #endregion
        #region Private Methods
        #endregion
        #region Public Methods
        public void Add()
        {
            if (_AttachmentDb.Bytes == null || _AttachmentDb.Bytes.Length == 0)
            {
                if (_FilePath == null || _FilePath == "")
                    return;
                _AttachmentDb.Bytes = AttachmentFileBiz.ReadFile(_FilePath);
                _AttachmentDb.Name = AttachmentFileBiz.GetName(_FilePath);

            }
            _AttachmentDb.Add();
        }
        public void Edit()
        {
            if (_AttachmentDb.Bytes == null || _AttachmentDb.Bytes.Length == 0)
            {
                if (_FilePath == null || _FilePath == "")
                    return;
                _AttachmentDb.Bytes = AttachmentFileBiz.ReadFile(_FilePath);
                _AttachmentDb.Name = AttachmentFileBiz.GetName(_FilePath);

            }
            _AttachmentDb.Edit();
        }
        public void Delete(int ID)
        {
            AttachmentFileDb objAttachment = new AttachmentFileDb();
            objAttachment.ID = ID;
            objAttachment.Delete();
        }
        public static byte[] ReadFile(string strFileName)
        {
            FileInfo fInfo = new FileInfo(strFileName);

            int intNumBytes;
            if (!fInfo.Exists)
            {
                return new byte[0];
            }
            intNumBytes = (int)fInfo.Length;
            FileStream FS = new FileStream(strFileName, FileMode.Open, FileAccess.Read);
            BinaryReader BR = new BinaryReader(FS);
            byte[] Data = BR.ReadBytes(intNumBytes);
            BR.Close();
            FS.Close();
            return Data;
        }
        public static string GetName(string strPath)
        {
            string Returned = "";
            char[] Spliter = @"\".ToCharArray();
            string[] objName = strPath.Split(Spliter);
            int intCount = objName.Length;
            Returned = objName.GetValue(intCount - 1).ToString();
            return Returned;
        }
        public static Image GetFile(byte[] arrByte)
        {
            MemoryStream Ms = new MemoryStream(arrByte);
            Image returnImage = Image.FromStream(Ms);

            return returnImage;
        }

        #endregion


    }
}

