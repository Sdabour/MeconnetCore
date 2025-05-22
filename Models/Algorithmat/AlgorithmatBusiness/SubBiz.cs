using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Algorithmat.Algorithmat.AlgorithmatDataBase;

namespace Algorithmat.Algorithmat.AlgorithmatBusiness
{
    public class SubBiz
    {
        #region Private Data and Public Properties
        SUBDb _SubDb;
        public int ID
        {
            get { return _SubDb.ID; }
            set { _SubDb.ID = value; }
        }


        public string Desc
        {
            get { return _SubDb.Desc; }
            set { _SubDb.Desc = value; }
        }


        public string TitleA
        {
            get { return _SubDb.TitleA; }
            set { _SubDb.TitleA = value; }
        }


        public string TitleE
        {
            get { return _SubDb.TitleE; }
            set { _SubDb.TitleE = value; }
        }
        public string Title
        {
            get
            {
                if (SharpVision.SystemBase.SysData.Language == 0 && TitleA != null && TitleA != "")
                    return TitleA;
                else
                    return TitleE;
            }
        }

        public int  ContentID
        {
            get { return _SubDb.ContentID; }
            set { _SubDb.ContentID = value; }
        }


        public int Order
        {
            get { return _SubDb.Order; }
            set { _SubDb.Order = value; }
        }


        public bool HasAnIndex
        {
            get { return _SubDb.HasAnIndex; }
            set { _SubDb.HasAnIndex = value; }
        }





        public bool IsChanged
        {
            get { return _SubDb.IsChanged; }
            set { _SubDb.IsChanged = value; }
        }
        ParagraphCol _ParagraphCol;

        public ParagraphCol ParagraphCol
        {
            get {
                if (_ParagraphCol == null)
                {
                    _ParagraphCol = new ParagraphCol(true);
                    
                }
                return _ParagraphCol; }
            set { _ParagraphCol = value; }
        }
        ParagraphCol _DeletedParagraphCol;

        public ParagraphCol DeletedParagraphCol
        {
            get {
                if (_DeletedParagraphCol == null)
                    _DeletedParagraphCol = new ParagraphCol(true);
                return _DeletedParagraphCol; }
            set { _DeletedParagraphCol = value; }
        }
        #endregion
        #region Constructors
        public SubBiz()
        {
            _SubDb = new SUBDb();
        }
        public SubBiz(DataRow objDr)
        {
            _SubDb = new SUBDb(objDr);
        }
        #endregion

        #region Private Methods

        #endregion
        #region Public Methods
        public void Add()
        {
            _SubDb.Add();
        }
        public void Edit()
        {
            _SubDb.Edit();
        }
        public void Delete()
        {
            _SubDb.Delete();
        }
        #endregion
    }
}