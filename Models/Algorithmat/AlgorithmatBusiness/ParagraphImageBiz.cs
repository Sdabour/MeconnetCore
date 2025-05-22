using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Algorithmat.Algorithmat.AlgorithmatDataBase;
namespace Algorithmat.Algorithmat.AlgorithmatBusiness
{
    public class ParagraphImageBiz
    {
        #region Private Data and Public Properties
        ParagraphImageDb _ParagraphImagedDb;
        ImageBiz _ImageBiz;

        public ImageBiz ImageBiz
        {
            get { return _ImageBiz; }
            set { _ImageBiz = value; }
        }
        public int ParagraphID
        {
            get { return _ParagraphImagedDb.ParagraphID; }
            set { _ParagraphImagedDb.ParagraphID = value; }
        }





        public int Order
        {
            get { return _ParagraphImagedDb.Order; }
            set
            {
                _ParagraphImagedDb.Order = value;
            }
        }


        public string TitleA
        {
            get { return _ParagraphImagedDb.TitleA; }
            set { _ParagraphImagedDb.TitleA = value; }
        }


        public string TitleE
        {
            get { return _ParagraphImagedDb.TitleE; }
            set { _ParagraphImagedDb.TitleE = value; }
        }
        public string Title
        {
            get
            {
                string Returned = "";
                if (SharpVision.SystemBase.SysData.Language == 0 || TitleE == null || TitleE == "")
                    Returned = TitleA;
                else
                    Returned = TitleE;
                return Returned;
            }
        }
        #endregion
        #region Constructors
        public ParagraphImageBiz()
        {
            _ParagraphImagedDb = new ParagraphImageDb();
        }
        public ParagraphImageBiz(DataRow objDr)
        {
            _ParagraphImagedDb = new ParagraphImageDb(objDr);
            _ImageBiz = new ImageBiz(objDr);
        }
        #endregion

        #region Private Methods

        #endregion
        #region Public Methods
        public DataRow GetRow(int intParagraph, DataTable dtImage)
        {
            DataRow objDr = dtImage.NewRow();
            objDr["ParagraphID"] = ParagraphID;
            objDr["ImageID"] = ImageBiz.ID;
            objDr["ImageOrder"] = Order;
            objDr["ParagraphImageTitleA"] = TitleA;
            objDr["ParagraphImageTitleE"] = TitleE;
            objDr["SecondaryParagraph"] = intParagraph;
            return objDr;
        }
        #endregion
    }
}