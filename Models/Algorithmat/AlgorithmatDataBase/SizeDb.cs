using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using SharpVision.SystemBase;
using SharpVision.Base.BaseDataBase;
namespace Algorithmat.Algorithmat.AlgorithmatDataBase
{
    public class SizeDb : BaseSingleDb
    {

        #region Private Data


        #endregion
        #region Constractors
        public SizeDb()
        {

        }
        public SizeDb(DataRow objDR)
        {
            SetData(objDR);
        }
        #endregion
        #region Public Accessorice

        int _Width;

        public int Width
        {
            get { return _Width; }
            set { _Width = value; }
        }
        int _Length;

        public int Length
        {
            get { return _Length; }
            set { _Length = value; }
        }
        string _IDsStr;

        public string IDsStr
        {
            set { _IDsStr = value; }
        }
        public string AddStr
        {
            get
            {
                string Returned = " INSERT INTO PORTALImageSize" +
                         " (SizeCode, SizeNameA, SizeNameE, SizePixelWidth, SizePixelLength,UsrIns,TimIns)" +
                         " VALUES     ('" + _Code + "','" + _NameA + "','" + _NameE + "'," + _Width + "," + _Length + "," +
                         SysData.CurrentUser.ID +
                         ",GetDate()) ";
                return Returned;
            }
        }
        public string EditStr
        {
            get
            {
                string Returned = " UPDATE    PORTALImageSize" +
                           " SET  SizeCode ='" + _Code + "'" +
                           " , SizeNameA ='" + _NameA + "'" +
                           "  ,SizeNameE = '" + _NameE + "'" +
                           ", SizePixelWidth=" + _Width +
                           ", SizePixelLength=" + _Length +
                           ",UsrUpd=" + SysData.CurrentUser.ID +
                           " ,TimUpd= GetDate() " +
                           " where SizeID  = " + _ID;
                return Returned;
            }
        }
        public string DeleteStr
        {
            get
            {
                string Returned = " update PORTALImageSize set SizeChanged =1, Dis = GetDate() where SizeID  = " + _ID; ;
                return Returned;
            }
        }
        public string AddIdentityStr
        {
            get
            {
                string Returned = "INSERT INTO PORTALImageSize (SizeID) " +
                     " SELECT       " + _ID + " AS SizeID1 " +
                     " WHERE        (NOT EXISTS " +
                     " (SELECT        SizeID " +
                     " FROM            PORTALImageSize  " +
                     " WHERE        (SizeID = " + _ID + "))) ";
                Returned += " " + EditStr;
                return Returned;
            }
        }
        public string EditChangedStr
        {
            get
            {
                string Returned = " update PORTALImageSize set SizeChanged =0 where SizeID  in (" + _IDsStr + ") "; ;
                return Returned;
            }
        }
        public static string SearchStr
        {
            get
            {
                string Returned = " SELECT     SizeID, SizeCode, SizeNameA, SizeNameE, SizePixelWidth, SizePixelLength   " +
                                  " FROM         PORTALImageSize ";
                return Returned;
            }
        }
        #endregion
        #region Private Methods
        void SetData(DataRow objDR)
        {
            _ID = int.Parse(objDR["SizeID"].ToString());
            _NameA = objDR["SizeNameA"].ToString();
            _NameE = objDR["SizeNameE"].ToString();
            _Code = objDR["SizeCode"].ToString();
            _Width = int.Parse(objDR["SizePixelWidth"].ToString());
            _Length = int.Parse(objDR["SizePixelLength"].ToString());
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

            string strSql =EditStr;
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
                strSql = strSql + " and  SizeID  = " + _ID;

            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        #endregion

    }
}