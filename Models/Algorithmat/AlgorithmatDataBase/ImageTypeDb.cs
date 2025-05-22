using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using SharpVision.SystemBase;
using SharpVision.Base.BaseDataBase;
namespace Algorithmat.Algorithmat.AlgorithmatDataBase
{
    public class ImageTypeDb : BaseSingleDb
    {

        #region Private Data


        #endregion
        #region Constractors
        public ImageTypeDb()
        {

        }
        public ImageTypeDb(DataRow objDR)
        {
            SetData(objDR);
        }
        #endregion
        #region Public Accessorice
        public string AddStr
        {
            get
            {
                string Returned = " INSERT INTO PORTALImageType" +
                          " (ImageTypeCode, ImageTypeNameA, ImageTypeNameE,UsrIns,TimIns)" +
                          " VALUES     ('" + _Code + "','" + _NameA + "','" + _NameE + "'," + SysData.CurrentUser.ID +
                          ",GetDate()) ";
                return Returned;
            }
        }
        public string EditStr
        {
            get
            {
                string Returned = " UPDATE    PORTALImageType" +
                            " SET  ImageTypeCode ='" + _Code + "'" +
                            " , ImageTypeNameA ='" + _NameA + "'" +
                            "  ,ImageTypeNameE = '" + _NameE + "'" +
                            ",UsrUpd=" + SysData.CurrentUser.ID +
                            " ,TimUpd= GetDate() " +
                            " where ImageTypeID  = " + _ID;
                return Returned;
            }
        }
        public string DeleteStr
        {
            get
            {
                string Returned = " UPDATE    PORTALImageType" +
                            " SET ImageTypeChanged = 1,Dis= GetDate() " +
                            " where ImageTypeID  = " + _ID;
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
                string Returned = " UPDATE    PORTALImageType" +
                            " SET ImageTypeChanged = 0 " +
                            " where ImageTypeID  in (" + _IDsStr + ")";
                return Returned;
            }
        }
        public string AddIdentityStr
        {
            get
            {
                string Returned = "INSERT INTO PORTALImageType (ImageTypeID) " +
                     " SELECT       " + _ID + " AS ImageTypeID1 " +
                     " WHERE        (NOT EXISTS " +
                     " (SELECT        ImageTypeID " +
                     " FROM            PORTALImageType  " +
                     " WHERE        (ImageTypeID = " + _ID + "))) ";
                Returned += " " + EditStr;
                return Returned;
            }
        }
        public static string SearchStr
        {
            get
            {
                string Returned = " SELECT     ImageTypeID, ImageTypeCode, ImageTypeNameA, ImageTypeNameE  " +
                                  " FROM         PORTALImageType ";
                return Returned;
            }
        }
        public static string TableName
        {
            get { return "ImageTypeTable"; }
        }
        #endregion
        #region Private Methods
        void SetData(DataRow objDR)
        {
            _ID = int.Parse(objDR["ImageTypeID"].ToString());
            _NameA = objDR["ImageTypeNameA"].ToString();
            _NameE = objDR["ImageTypeNameE"].ToString();
            _Code = objDR["ImageTypeCode"].ToString();

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
                strSql = strSql + " and  ImageTypeID  = " + _ID;

            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql,TableName);
        }
        #endregion

    }
}