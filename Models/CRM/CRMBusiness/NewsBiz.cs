using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.Base.BaseDataBase;
using SharpVision.Base.BaseBusiness;
using SharpVision.CRM.CRMDataBase;
using SharpVision.SystemBase;
using SharpVision.COMMON.COMMONBusiness;
using SharpVision.RP.RPBusiness;
namespace SharpVision.CRM.CRMBusiness
{
    public enum NewsType
    { 
        NotSPecified,
        News= 1,
        Essay = 2,
        Advirtisement =3,
       
    }

    public class NewsBiz
    {
        #region Private Data
        NewsDb _NewsDb;
        SubjectCol _SubjectCol;
        CellCol _ProjectCol;
        CompetitorCol _CompetitorCol;
        CompetitorProejctCol _CompetitorProjectCol;
        NewsAttachmentCol _NewsAttachmentCol;
        NewsAttachmentCol _DeletedNewsAttachmentCol;
        #endregion

        #region Constractors
        public NewsBiz()
        {
            _NewsDb = new NewsDb();
        }
        public NewsBiz(int intID)
        {
            _NewsDb = new NewsDb(intID);
        }
        public NewsBiz(DataRow objDR)
        {
            _NewsDb = new NewsDb(objDR);
        }
        #endregion

        #region Public Accessorice
        public int ID
        {
            set
            {
                _NewsDb.ID = value;
            }
            get
            {
                return _NewsDb.ID;
            }
        }
        public DateTime Date
        {
            set
            {
                _NewsDb.Date = value;
            }
            get
            {
                return _NewsDb.Date;
            }
        }
        public NewsType Type
        {
            set
            {
                _NewsDb.Type = (int)value;
            }
            get
            {
                return (NewsType)_NewsDb.Type;
            }
        }
        public string TypeStr
        {
            get
            {
                string Returned = "";
                switch (Type)
                {
                    case NewsType.Advirtisement: Returned = "«⁄·«‰"; break;
                    case NewsType.Essay: Returned = "„ﬁ«· "; break;
                    case NewsType.News: Returned= "Œ»—"; break;
                    default:Returned = "€Ì— „Õœœ"; break;
                }
                return Returned;
 
            }
        }
        public string Title
        {
            set
            {
                _NewsDb.Title = value;

            }
            get
            {
                return _NewsDb.Title;
            }
        }
        public string Summary
        {
            set
            {
                _NewsDb.Summary = value;
            }
            get
            {
                return _NewsDb.Summary;
            }
        }
        public string Text
        {
            set
            {
                _NewsDb.Text = value;
            }
            get
            {
                return _NewsDb.Text;
            }
        }
        public string HTML
        {
            set
            {
                _NewsDb.HTML = value;
            }
            get
            {
                return _NewsDb.HTML;
            }
        }
        public SubjectCol SubjectCol
        {
            set
            {
                _SubjectCol = value;
            }
            get
            {
                if (_SubjectCol == null)
                {
                    _SubjectCol = new SubjectCol(true);
                    if (ID != 0)
                    {
                        DataTable dtTemp = _NewsDb.GetSubject();
                        foreach (DataRow objDr in dtTemp.Rows)
                        {
                            _SubjectCol.Add(new SubjectBiz(objDr));
                        }
 
                    }
                }
                return _SubjectCol;
            }
        }
        public CellCol ProjectCol
        {
            set
            {
                _ProjectCol = value;
            }
            get
            {
                if (_ProjectCol == null)
                {
                    _ProjectCol = new CellCol(true);
                    if (ID != 0)
                    {
                        DataTable dtTemp = _NewsDb.GetCell();
                        foreach (DataRow objDr in dtTemp.Rows)
                        {
                            _ProjectCol.Add(new CellBiz(objDr));
                        }
                    }
                }
                return _ProjectCol;
            }
        }
        public CompetitorCol CompetitorCol
        {
            set
            {
                _CompetitorCol = value;
            }
            get
            {
                if (_CompetitorCol == null)
                {

                    _CompetitorCol = new CompetitorCol(true);
                    if (ID != 0)
                    {
                        DataTable dtTemp = _NewsDb.GetCompetitor();
                        foreach (DataRow objDr in dtTemp.Rows)
                        {
                            _CompetitorCol.Add(new CompetitorBiz(objDr));
                        }
                    }
                }
                return _CompetitorCol;
            }
        }
        public CompetitorProejctCol CompetitorProjectCol
        {
            set
            {
                _CompetitorProjectCol = value;
            }
            get 
            {
                if (_CompetitorProjectCol == null)
                {
                    _CompetitorProjectCol = new CompetitorProejctCol(true);
                    if (ID != 0)
                    {
                        DataTable dtTemp = _NewsDb.GetCompetitorProject();
                        foreach (DataRow objDr in dtTemp.Rows)
                        {
                            _CompetitorProjectCol.Add(new CompetitorProejctBiz(objDr));
                        }
                    }
                }
                return _CompetitorProjectCol;
            }
        }
        public NewsAttachmentCol NewsAttachmentCol
        {
            set
            {
                _NewsAttachmentCol = value;
            }
            get
            {
                if (_NewsAttachmentCol == null)
                {
                    _NewsAttachmentCol = new NewsAttachmentCol(true);
                    if (ID != 0)
                    {
                        try
                        {
                             NewsAttachmentDb objDb = new NewsAttachmentDb();
                            objDb.NewsIDs = ID.ToString();
                            DataTable dtTemp = objDb.Search(); 
                            DataRow[] arrDr = dtTemp.Select();

                            NewsAttachmentBiz objTempBiz;
                            foreach (DataRow objDr in arrDr)
                            {
                                objTempBiz = new NewsAttachmentBiz(objDr);
                                objTempBiz.NewsBiz = this;
                                _NewsAttachmentCol.Add(objTempBiz);
                            }
                        }
                        catch
                        { }
                    }
                }
                return _NewsAttachmentCol;
            }
        }
        public NewsAttachmentCol DeletedNewsAttachmentCol
        {
            set
            {
                _DeletedNewsAttachmentCol = value;
            }
            get
            {
                if (_DeletedNewsAttachmentCol == null)
                    _DeletedNewsAttachmentCol = new NewsAttachmentCol(true);
                return _DeletedNewsAttachmentCol;
            }
        }
        #endregion

        #region Private Methods
        DataTable GetSubjectTable()
        {
            DataTable Returned = new DataTable();
            Returned.Columns.AddRange(new DataColumn[] {new DataColumn("Subject") });
            DataRow objDr;
            foreach (SubjectBiz objBiz in SubjectCol)
            {
                objDr = Returned.NewRow();
                objDr["Subject"] = objBiz.ID;
                Returned.Rows.Add(objDr);
            }
            return Returned;
        }
        DataTable GetCompetitorTable()
        {
            DataTable Returned = new DataTable();
            Returned.Columns.AddRange(new DataColumn[] { new DataColumn("Competitor") });
            DataRow objDr;
            foreach (CompetitorBiz objBiz in CompetitorCol)
            {
                objDr = Returned.NewRow();
                objDr["Competitor"] = objBiz.ID;
                Returned.Rows.Add(objDr);
            }
            return Returned;
        }
        DataTable GetCompetitorProjectTable()
        {
            DataTable Returned = new DataTable();
            Returned.Columns.AddRange(new DataColumn[] { new DataColumn("CompetitorProject") });
            DataRow objDr;
            foreach (CompetitorProejctBiz objBiz in CompetitorProjectCol)
            {
                objDr = Returned.NewRow();
                objDr["CompetitorProject"] = objBiz.ID;
                Returned.Rows.Add(objDr);
            }
            return Returned;
        }
        DataTable GetCellTable()
        {
            DataTable Returned = new DataTable();
            Returned.Columns.AddRange(new DataColumn[] { new DataColumn("Cell") });
            DataRow objDr;
            foreach (CellBiz objBiz in ProjectCol)
            {
                objDr = Returned.NewRow();
                objDr["Cell"] = objBiz.ID;
                Returned.Rows.Add(objDr);
            }
            return Returned;
        }
        #endregion

        #region Public Methods
        public void Add()
        {
            _NewsDb.Subject = GetSubjectTable();
            _NewsDb.Cell = GetCellTable();
            _NewsDb.Competitor = GetCompetitorTable();
            _NewsDb.CompetitorProject = GetCompetitorProjectTable();

            _NewsDb.Add();
           

        }
        public void Edit()
        {
            _NewsDb.Subject = GetSubjectTable();
            _NewsDb.Cell = GetCellTable();
            _NewsDb.Competitor = GetCompetitorTable();
            _NewsDb.CompetitorProject = GetCompetitorProjectTable();
            _NewsDb.Edit();
        }
        public void Delete()
        {
            _NewsDb.Delete();
        }
        #endregion
    }
}
