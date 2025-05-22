using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SharpVision.Base.BaseDataBase;

using System.Data;
using SharpVision.UMS.UMSBusiness;
using SharpVision.SystemBase;
namespace Algorithmat.Algorithmat.AlgorithmatDataBase
{
    public class ParagraphDb
    {
        #region Private Data
        int _ID;

        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
        int _SUBID;

        public int SUBID
        {
            get { return _SUBID; }
            set { _SUBID = value; }
        }
        string _SUBIDs;

        public string SUBIDs
        {
          
            set { _SUBIDs = value; }
        }

        int _Order;

        public int Order
        {
            get { return _Order; }
            set { _Order = value; }
        }
        string _TextA;

        public string TextA
        {
            get { return _TextA; }
            set { _TextA = value; }
        }
        string _TextE;

        public string TextE
        {
            get { return _TextE; }
            set { _TextE = value; }
        }
        string _InnerHTMLA;

        public string InnerHTMLA
        {
            get { return _InnerHTMLA; }
            set { _InnerHTMLA = value; }
        }
        string _InnerHTMLE;

        public string InnerHTMLE
        {
            get { return _InnerHTMLE; }
            set { _InnerHTMLE = value; }
        }
        int _Content;

        public int Content
        {
            get { return _Content; }
            set { _Content = value; }
        }

        bool _IsChanged;

        public bool IsChanged
        {
            get { return _IsChanged; }
            set { _IsChanged = value; }
        }
        string _TitleA;

        public string TitleA
        {
            get { return _TitleA; }
            set { _TitleA = value; }
        }
        string _TitleE;

        public string TitleE
        {
            get { return _TitleE; }
            set { _TitleE = value; }
        }
        bool _IsCodePiece;

        public bool IsCodePiece
        {
            get { return _IsCodePiece; }
            set { _IsCodePiece = value; }
        }
        int _File;

        public int File
        {
            get { return _File; }
            set { _File = value; }
        }

        #endregion
        #region Constructors
        public ParagraphDb()
        { 
        }
        public ParagraphDb(DataRow objDr)
        {
            SetData(objDr);
        }
        #endregion
        #region Public Properties
        int _SecondaryParagraph;

        public int SecondaryParagraph
        {
            get { return _SecondaryParagraph; }
            set { _SecondaryParagraph = value; }
        }
        public string AddStr
        {
            get
            {

                int intCodePiece = _IsCodePiece ? 1 : 0;
                string Returned = "insert into PORTALParagraph (PARAGRAPHSUBID, PARAGRAPHTitleA, PARAGRAPHTitleE"+
                    ",ParagraphTextA, ParagraphTextE,PARAGRAPHInnerHTMLA,PARAGRAPHInnerHTMLE,PARAGRAPHOrder" +
                    ",PARAGRAPHContent,PARAGRAPHIsCodePiece,PARAGRAPHFile, UsrIns, TimIns) " +
                    " values (" + _SUBID + ",'" + _TitleA + "','" + _TitleE + "','" +
                    _TextA.Replace("'", "''") + "','" + _TextE.Replace("'", "''") + "','" +
                    _InnerHTMLA.Replace("'", "''") + "','" + _InnerHTMLE.Replace("'", "''") + "'," + _Order + "," +
                    _Content  + "," + intCodePiece + ","+ _File +
                    "," + SysData.CurrentUser.ID + ",GetDate()) ";
                return Returned;
            }
        }
        public string EditStr
        {
            get
            {
                int intCodePiece = _IsCodePiece ? 1 : 0;
                string Returned = "update PORTALParagraph  " +
                    " set PARAGRAPHSUBID ="+ _SUBID +
                    ", PARAGRAPHTitleA='"+ _TitleA.Replace("'","''") +"'"+
                    ", PARAGRAPHTitleE ='" + _TitleE.Replace("'", "''") + "' " + 
                    ", ParagraphTextA='" + _TextA.Replace("'", "''") + "'" +
                    ", ParagraphTextE='" + _TextE.Replace("'", "''") + "'" +
                     ", ParagraphInnerHTMLA='" + _InnerHTMLA.Replace("'", "''") + "'" +
                    ", ParagraphInnerHTMLE='" + _InnerHTMLE.Replace("'", "''") + "'" +
                    ",PARAGRAPHOrder="+ _Order +
                    ",PARAGRAPHContent="+_Content+
                    ",PARAGRAPHIsCodePiece="+ intCodePiece+
                    ",PARAGRAPHFile= "+ _File +
                    ", ParagraphChanged=1" +
                    ", UsrUpd=" + SysData.CurrentUser.ID +
                    ", TimUpd=GetDate() " +
                    " where PARAGRAPHSUBID = "+ _SUBID +" and  ParagraphID =" + _ID;
                return Returned;
            }
        }
        public string AddIdentityStr
        {
            get
            {
                string Returned = "INSERT INTO PORTALParagraph (ParagraphID) " +
                     " SELECT       " + _ID + " AS ParagraphID1 " +
                     " WHERE        (NOT EXISTS " +
                     " (SELECT        ParagraphID " +
                     " FROM            PORTALParagraph  " +
                     " WHERE        (ParagraphID = " + _ID + "))) ";
                Returned += " " + EditStr;
                return Returned;
            }
        }
        public string DeleteStr
        {
            get
            {
                string Returned = "update PORTALParagraph  " +
                  " set  PARAGRAPHChanged = 1,Dis=GetDate() " +
                  " where  PARAGRAPHSUBID = " + _SUBID + " and ParagraphID =" + _ID;
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
                string Returned = "update PORTALParagraph  " +
                  " set  PARAGRAPHChanged = 0  " +
                  " where  ParagraphID in (" + _IDsStr + ") ";
                return Returned;
            }
        }
        public static string SearchStr
        {
            get
            {
                string Returned = "SELECT          PARAGRAPHID, PARAGRAPHSUBID,PARAGRAPHTitleA, PARAGRAPHTitleE"+
                    ", PARAGRAPHTextA, PARAGRAPHTextE"+
                    ", PARAGRAPHInnerHTMLA, PARAGRAPHInnerHTMLE" +
                    ", PARAGRAPHOrder, PARAGRAPHChanged,PARAGRAPHIsCodePiece,PARAGRAPHFile,ContentTable.*,FileTable.* " +
                    " FROM  PORTALParagraph "+
                    " left outer join ("+ ContentDb.SearchStr + ") as ContentTable "+
                    " on PORTALParagraph.PARAGRAPHContent = ContentTable.ContentID  "+
                    " left outer join (" + FileDb.SearchStr + ") as FileTable  "+
                    " on PORTALParagraph.PARAGRAPHFile = FileTable.FileID ";
                return Returned;
            }
        }
        public static string TableName
        {
            get { return "ParagraphTable"; }
        }
        #endregion
        #region Private Methods
        void SetData(DataRow objDr)
        {
            _ID = int.Parse(objDr["ParagraphID"].ToString());
            _Order = int.Parse(objDr["PARAGRAPHOrder"].ToString());
            _TextA = objDr["ParagraphTextA"].ToString();
            _TextE = objDr["ParagraphTextE"].ToString();
            if(objDr.Table.Columns["ParagraphInnerHTMLA"]!= null )
            _InnerHTMLA = objDr["ParagraphInnerHTMLA"].ToString();
            _InnerHTMLE = objDr["ParagraphInnerHTMLE"].ToString();
            _TitleA = objDr["PARAGRAPHTitleA"].ToString();
            _TitleE = objDr["PARAGRAPHTitleE"].ToString();
            _SUBID = int.Parse(objDr["PARAGRAPHSUBID"].ToString());
            try
            {
                _IsChanged = bool.Parse(objDr["ParagraphIsChanged"].ToString());
            }
            catch { }
            if (objDr["ContentID"].ToString() != "")
                _Content = int.Parse(objDr["ContentID"].ToString());
            if (objDr.Table.Columns["SecondaryParagraph"] != null)
                _SecondaryParagraph = int.Parse(objDr["SecondaryParagraph"].ToString());
            if (objDr["PARAGRAPHIsCodePiece"].ToString() != "")
                _IsCodePiece = bool.Parse(objDr["PARAGRAPHIsCodePiece"].ToString());
            if (objDr.Table.Columns["PARAGRAPHFile"] != null && objDr["PARAGRAPHFile"].ToString() != "")
                _File = int.Parse(objDr["PARAGRAPHFile"].ToString());
        }
        #endregion
        #region Public Methods
        public void Add()
        {
            string strSql = AddStr;
            ID = SysData.SharpVisionBaseDb.InsertIdentityTable(strSql);
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
            if (_SUBIDs != null && _SUBIDs != "")
                strSql += " and PARAGRAPHSUBID in ("+ _SUBIDs +") ";
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql,TableName);
        }
        #endregion
    }
}