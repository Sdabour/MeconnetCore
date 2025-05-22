using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using SharpVision.SystemBase;
namespace SharpVision.COMMON.COMMONDataBase
{
    public class AttachmentFileDb
    {
        #region Private Data
        int _ID;
        byte[] _Bytes;
        string _Name;
        DateTime _LastModifiedDate;
        string _IDs;
        static DataTable _CacheAttachmentTable;
        static string _AttachmentIDs;
        #endregion

        #region Constructors
        public AttachmentFileDb()
        { 

        }
        public AttachmentFileDb(int intID)
        {
            _ID = intID;
            DataTable dtTemp = Search();
            if (dtTemp == null || dtTemp.Rows.Count == 0)
                return;
            //byte[] arrByte = (byte[])dtTemp.Rows[0]["AttachmentFile"];
           // SysCryptography.DecryptByteStream(arrByte, ref _Bytes);
           // _Bytes = arrByte;
            _Name = dtTemp.Rows[0]["AttachmentName"].ToString();
            _LastModifiedDate = DateTime.Parse(dtTemp.Rows[0]["AttachmentLastModifiedDate"].ToString());
        }
        
        #endregion
        #region Public Properties
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
        public byte[] Bytes
        {
            set 
            {
                _Bytes = value;
            }
            get
            {
                return _Bytes;
   
            }
        }
        public string Name
        {
            set
            {
                _Name = value;
            }
            get
            {
                return _Name;
            }
        }
        public DateTime LastModifiedDate
        {
            set 
            {
                _LastModifiedDate = value;
            }
            get 
            {
                return _LastModifiedDate;
            }
        }
        public static DataTable CacheAttachmentTable
        {
            set
            {
                _CacheAttachmentTable = value;
            }
            get
            {
                if (_CacheAttachmentTable == null && _AttachmentIDs != null && _AttachmentIDs != "")
                {
                    AttachmentFileDb objdb = new AttachmentFileDb();
                    objdb.IDs = _AttachmentIDs;
                    _CacheAttachmentTable = objdb.Search();
 
                }
                return _CacheAttachmentTable;
            }
        }
        public string IDs
        {
            set
            {
                _IDs = value;
            }
        }
        public static string AttachmentIDs
        {
            set
            {
                _AttachmentIDs = value;
            }
        }
        #endregion
        #region Private Methods

        #endregion
        #region Public Methods
        public void Add()
        {
           // SysCryptography.EncryptByteStream(_Bytes, _Bytes);
            SqlParameter[] arrParameter = new SqlParameter[2];

            string strSql = "insert into COMMONAttachment (AttachmentFile, AttachmentName) values(@File,@Name)";
            arrParameter[0] = new SqlParameter("@File", SqlDbType.Binary);
            arrParameter[0].Value = _Bytes;
            arrParameter[1] = new SqlParameter("@Name", SqlDbType.VarChar);
            arrParameter[1].Value = _Name;
            _ID = SysData.AttachmentDb.InsertIdentityTable(strSql,arrParameter) ;
 
        }
        public void Edit()
        {
            SqlParameter[] arrParameter = new SqlParameter[3];
            string strSql = "update COMMONAttachment  set AttachmentFile=@File" +
                ", AttachmentName=@Name,AttachmentLastModifiedDate=getdate() " +
                " where AttachmentID=@ID ";
            arrParameter[0] = new SqlParameter("@File", SqlDbType.Binary);
            arrParameter[0].Value = _Bytes;
            arrParameter[1] = new SqlParameter("@Name", SqlDbType.VarChar);
            arrParameter[1].Value = _Name;
            arrParameter[2] = new SqlParameter("@ID", SqlDbType.Int);
            arrParameter[2].Value = _ID;
            SysData.AttachmentDb.ExecuteNonQuery(strSql, arrParameter);
        }
        public void Delete()
        {
            string strSql = "delete from COMMONAttachment where AttachmentID=" + _ID;
            SysData.AttachmentDb.ExecuteNonQuery(strSql);
 
        }
        public DataTable Search()
        {
            string strSql = "SELECT  AttachmentID,AttachmentName,AttachmentLastModifiedDate " +
                " FROM  dbo.COMMONAttachment " +
                " where AttachmentID="+_ID;

            return SysData.AttachmentDb.ReturnDatatable(strSql);
        }
        public DataTable GetFilleByteArr()
        {
            string strSql = "SELECT  AttachmentID, AttachmentFile  " +
                " FROM  dbo.COMMONAttachment " +
                " where (1=1) ";
            if (_ID != 0)
            {
                strSql+=  " and AttachmentID="+_ID;
            }
            if(_IDs != null && _IDs != "")
                strSql += " and  AttachmentID in (" + _IDs + ") ";
            return SysData.AttachmentDb.ReturnDatatable(strSql);
        }

        #endregion
    }
}
