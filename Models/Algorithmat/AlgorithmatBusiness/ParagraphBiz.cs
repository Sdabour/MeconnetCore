using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Algorithmat.Algorithmat.AlgorithmatDataBase;

namespace Algorithmat.Algorithmat.AlgorithmatBusiness
{
    public class ParagraphBiz
    {
        #region Private Data and Public Properties
        ParagraphDb _ParagraphDb;
        public int ID
        {
            get { return _ParagraphDb.ID; }
            set { _ParagraphDb.ID = value; }
        }


        


        public string TextA
        {
            get { return _ParagraphDb.TextA; }
            set { _ParagraphDb.TextA = value; }
        }


        public string TextE
        {
            get { return _ParagraphDb.TextE; }
            set { _ParagraphDb.TextE = value; }
        }

        public string Text
        {
            get
            {
                string Returned = "";
                if (SharpVision.SystemBase.SysData.Language == 0 && TextA != null && TextA != "")
                    Returned = TextA;
                else
                    Returned = TextE;
                return Returned;
            }
        }

        public string InnerHTMLA
        {
            get { return _ParagraphDb.InnerHTMLA; }
            set { _ParagraphDb.InnerHTMLA = value; }
        }


        public string InnerHTMLE
        {
            get { return _ParagraphDb.InnerHTMLE; }
            set { _ParagraphDb.InnerHTMLE = value; }
        }

        public string InnerHTML
        {
            get
            {
                string Returned = "";
                if (SharpVision.SystemBase.SysData.Language == 0 && InnerHTMLA != null && InnerHTMLA != "")
                    Returned = InnerHTMLA;
                else
                    Returned = InnerHTMLE;
                return Returned;
            }
        }

        public string DisplayedParagraphText
        {
            get 
            {
                string Returned = "";
                Returned = Text == "" ? InnerHTML : Text;
                return Returned;
            }
        }
        public string TitleA
        {
            get { return _ParagraphDb.TitleA; }
            set { _ParagraphDb.TitleA = value; }
        }


        public string TitleE
        {
            get { return _ParagraphDb.TitleE; }
            set { _ParagraphDb.TitleE = value; }
        }

        public string Title
        {
            get
            {
                string Returned = "";
                if (SharpVision.SystemBase.SysData.Language == 0 && TitleA != null && TitleA != "")
                    Returned = TitleA;
                else
                    Returned = TitleE;
                return Returned;
            }
        }
        public int SUBID
        {
            get { return _ParagraphDb.SUBID; }
            set { _ParagraphDb.SUBID = value; }
        }


        public int Order
        {
            get { return _ParagraphDb.Order; }
            set { _ParagraphDb.Order = value; }
        }
        public bool IsCodePiece
        {
            get { return _ParagraphDb.IsCodePiece; }
            set { _ParagraphDb.IsCodePiece = value; }
        }

        ContentBiz _ContentBiz;

        public ContentBiz ContentBiz
        {
            get {
                if (_ContentBiz == null)
                    _ContentBiz = new ContentBiz();
                return _ContentBiz; }
            set { _ContentBiz = value; }
        }






        public bool IsChanged
        {
            get { return _ParagraphDb.IsChanged; }
            set { _ParagraphDb.IsChanged = value; }
        }
        ParagraphImageCol _ImageCol;

        public ParagraphImageCol ImageCol
        {
            get
            {
                if (_ImageCol == null)
                    _ImageCol = new ParagraphImageCol(true);
                return _ImageCol;
            }
            set { _ImageCol = value; }
        }
        FileBiz _FileBiz;

        public FileBiz FileBiz
        {
            get {
                if (_FileBiz == null)
                    _FileBiz = new FileBiz();
                return _FileBiz; }
            set { _FileBiz = value; }
        }
        #endregion
        #region Constructors
        public ParagraphBiz()
        {
            _ParagraphDb = new ParagraphDb();
        }
        public ParagraphBiz(DataRow objDr)
        {
            _ParagraphDb = new ParagraphDb(objDr);
            if (_ParagraphDb.Content != 0)
                _ContentBiz = new ContentBiz(objDr);
            if (_ParagraphDb.File != 0)
                _FileBiz = new FileBiz(objDr);
        }
        #endregion

        #region Private Methods

        #endregion
        #region Public Methods
        public void Add()
        {
            _ParagraphDb.Content = ContentBiz.ID;
            _ParagraphDb.Add();
        }
        public void Edit()
        {
            _ParagraphDb.Content = ContentBiz.ID;
            _ParagraphDb.Edit();
        }
        public void Delete()
        {
            _ParagraphDb.Delete();
        }
        public DataRow GetRow(int intSecondaryParagraph, int intSecondarySubID, DataTable dtParagraph)
        {
            DataRow Returned = dtParagraph.NewRow();
            Returned["ParagraphID"] = ID;
            Returned["ParagraphTitleA"] = TitleA;
            Returned["ParagraphTitleE"] = TitleE;
            Returned["ParagraphTextA"] =TextA;
            Returned["ParagraphTextE"] = TextE;
            Returned["ParagraphInnerHTMLA"] = InnerHTMLA;
            Returned["ParagraphInnerHTMLE"] = InnerHTMLE;
            Returned["ParagraphOrder"] = Order;
            Returned["ContentID"] = ContentBiz.ID;
            Returned["PARAGRAPHSUBID"] = SUBID;
            Returned["ParagraphIsChanged"] =IsChanged ? 1 : 0;
            Returned["SecondarySub"] = intSecondarySubID;
            Returned["SecondaryParagraph"] = intSecondaryParagraph;
            Returned["PARAGRAPHIsCodePiece"] = IsCodePiece ? 1 : 0;
            Returned["PARAGRAPHFile"] = FileBiz.ID;
            return Returned;
        }
        #endregion
    }
}