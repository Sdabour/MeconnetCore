using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using SharpVision.SystemBase;
using SharpVision.Base.BaseDataBase;
namespace Algorithmat.Algorithmat.AlgorithmatDataBase
{
    public class FileTypeDb : BaseSingleDb
    {

        #region Private Data


        #endregion
        #region Constractors
        public FileTypeDb()
        {

        }
        public FileTypeDb(DataRow objDR)
        {
            SetData(objDR);
        }
        #endregion
        #region Public Accessorice
        public string AddStr
        {
            get
            {
                string Returned = " INSERT INTO PORTALFileType" +
                          " (FileTypeCode, FileTypeNameA, FileTypeNameE,UsrIns,TimIns)" +
                          " VALUES     ('" + _Code + "','" + _NameA + "','" + _NameE + "'," + SysData.CurrentUser.ID +
                          ",GetDate()) ";
                return Returned;
            }
        }
        public string EditStr
        {
            get
            {
                string Returned = " UPDATE    PORTALFileType" +
                            " SET  FileTypeCode ='" + _Code + "'" +
                            " , FileTypeNameA ='" + _NameA + "'" +
                            "  ,FileTypeNameE = '" + _NameE + "'" +
                            ",UsrUpd=" + SysData.CurrentUser.ID +
                            " ,TimUpd= GetDate() " +
                            " where FileTypeID  = " + _ID;
                return Returned;
            }
        }
        public string DeleteStr
        {
            get
            {
                string Returned = " UPDATE    PORTALFileType" +
                            " SET FileTypeChanged = 1,Dis= GetDate() " +
                            " where FileTypeID  = " + _ID;
                return Returned;
            }
        }
        string _IDsStr;

        public string IDsStr
        {
            set { _IDsStr = value; }
        }
        public string EditChangedStr
        {
            get
            {
                string Returned = " UPDATE    PORTALFileType" +
                            " SET FileTypeChanged = 0 " +
                            " where FileTypeID  in (" + _IDsStr + ")";
                return Returned;
            }
        }
        public string AddIdentityStr
        {
            get
            {
                string Returned = "INSERT INTO PORTALFileType (FileTypeID) " +
                     " SELECT       " + _ID + " AS FileTypeID1 " +
                     " WHERE        (NOT EXISTS " +
                     " (SELECT        FileTypeID " +
                     " FROM            PORTALFileType  " +
                     " WHERE        (FileTypeID = " + _ID + "))) ";
                Returned += " " + EditStr;
                return Returned;
            }
        }
        public static string SearchStr
        {
            get
            {
                string Returned = " SELECT     FileTypeID, FileTypeCode, FileTypeNameA, FileTypeNameE  " +
                                  " FROM         PORTALFileType ";
                return Returned;
            }
        }
        public static string TableName
        {
            get { return "FileTypeTable"; }
        }
        #endregion
        #region Private Methods
        void SetData(DataRow objDR)
        {
            _ID = int.Parse(objDR["FileTypeID"].ToString());
            _NameA = objDR["FileTypeNameA"].ToString();
            _NameE = objDR["FileTypeNameE"].ToString();
            _Code = objDR["FileTypeCode"].ToString();

        }
        #endregion
        #region Public Methods
        public override void Add()
        {

            string strSql = AddStr;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public override void Edit()
        {

            string strSql = EditStr;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public override void Delete()
        {
            string strSql = DeleteStr;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public override DataTable Search()
        {
            string strSql = SearchStr + " where Dis is null ";
            if (_ID != 0)
                strSql = strSql + " and  FileTypeID  = " + _ID;

            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql,TableName);
        }
        #endregion

    }
}