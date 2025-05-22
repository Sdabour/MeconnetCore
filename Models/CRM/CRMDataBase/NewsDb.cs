using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.SystemBase;
using System.Data;
using System.Data.SqlClient;
using SharpVision.COMMON.COMMONDataBase;
using SharpVision.Base.BaseDataBase;
using SharpVision.RP.RPDataBase;
namespace SharpVision.CRM.CRMDataBase
{
    public class NewsDb
    {
        #region Private Data
        protected int _ID;
        protected int _Type;
        protected string _Title;
        protected string _Summary;
        protected string _Text;
        protected string _HTML;
        DateTime _Date;
        DataTable _Subject;
        DataTable _Competitor;
        DataTable _CompetitorProject;
        DataTable _Cell;
        bool _IsDateRange;
        DateTime _StartDate;
        DateTime _EndDate;
        #region Private Data for search
        int _CellID;
        int _CompetitorID;
        int _CompetitorProjectID;
        int _SubjectID;
        string _SubjectIDs;
        string _TextSearch;
        #endregion
        #endregion

        #region Constractors
        public NewsDb()
        { 

        }
        public NewsDb(int intID)
        {
            _ID = intID;
            DataTable dtTemp = Search();
            DataRow objDR = dtTemp.Rows[0];
            SetData(objDR);
        }
        public NewsDb(DataRow objDR)
        {
            SetData(objDR);
        }
        #endregion

        #region Public Accessorice
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
        public int Type
        {
            set
            {
                _Type = value;
            }
            get
            {
                return _Type;
            }
        }
        public string Title
        {
            set
            {
                _Title = value;

            }
            get
            {
                return _Title;
            }
        }
        public string Summary
        {
            set
            {
                _Summary = value;
            }
            get
            {
                return _Summary;
            }
        }
        public string Text
        {
            set
            {
                _Text = value;
            }
            get
            {
                return _Text;
            }
        }
        public string HTML
        {
            set
            {
                _HTML = value;
            }
            get
            {
                return _HTML;
            }
        }
        public DateTime Date
        {
            set
            {
                _Date = value;
            }
            get
            {
                return _Date;
            }

        }
        public DataTable Subject
        {
            set 
            {
                _Subject = value;
            }
        }
        public DataTable Competitor
        {
            set 
            {
                _Competitor = value;
            }
        }
        public DataTable CompetitorProject
        {
            set
            {
                _CompetitorProject = value;
            }
        }
        public DataTable Cell
        {
            set
            {
                _Cell = value;
            }
        }


        public int CellID
        {
            set
            {
                _CellID = value;
            }
        }
        public int CompetitorID
        {
            set
            {
                _CompetitorID = value;
            }
        }
        public int CompetitorProjectID
        {
            set
            {
                _CompetitorProjectID = value;
            }
        }
        public int SubjectID
        {
            set
            {
                _SubjectID = value;
            }
        }
        public string SubjectIDs
        {
            set
            {
                _SubjectIDs = value;
            }
        }
        public string TextSearch
        {
            set
            {
                _TextSearch = value;
            }
        }
        public bool IsDateRange
        {
            set
            {
                _IsDateRange = value;
            }
        }
        public DateTime StartDate
        {
            set
            {
                _StartDate = value;
            }
        }
        public DateTime EndDate
        {
            set
            {
                _EndDate = value;
            }
        }

        public static string SearchStr
        {
            get
            {
                string Returned = " SELECT     NewsID,NewsDate, NewsType, NewsTitle, NewsSummary, NewsText, NewsHTML,NewsDate " +
                                  " FROM         CRMNews ";
                return Returned;
            }
        }
        #endregion

        #region Private Methods
        void SetData(DataRow objDR)
        {
            _ID = int.Parse(objDR["NewsID"].ToString());
            _Type = int.Parse(objDR["NewsType"].ToString());
            _Title = objDR["NewsTitle"].ToString();
            _Summary = objDR["NewsSummary"].ToString();
            _Text = objDR["NewsText"].ToString();
            _HTML = objDR["NewsHTML"].ToString();
            if (objDR["NewsDate"].ToString() != "")
                _Date = DateTime.Parse(objDR["NewsDate"].ToString());
        }
        #endregion
        #region Public Methods
        public void Add()
        {
            double dblDate = _Date.ToOADate() - 2;
            string strSql = " INSERT INTO CRMNews"+
                            " (NewsDate,NewsType, NewsTitle, NewsSummary, NewsText, NewsHTML)"+
                            " VALUES     (" + dblDate + "," +_Type+",'"+_Title+"','"+_Summary+"','"+_Text+"','"+_HTML+"') ";
            ID =  SysData.SharpVisionBaseDb.InsertIdentityTable(strSql);
            JoinSubject();
            JoinCompetitor();
            JoinCompetitorProject();
            JoinCell();
        }
        public void Edit()
        {
            double dblDate = _Date.ToOADate() - 2;
            string strSql = " UPDATE    CRMNews" +
                            " SET  NewsDate="+dblDate+
                            ",NewsType =" + _Type + "" +
                            " , NewsTitle ='" + _Title + "'" +
                            " , NewsSummary ='" + _Summary + "'" +
                            " , NewsText ='" + _Text + "'" +
                            " , NewsHTML = '" + _HTML + "'" +
                            " Where NewsID = " + _ID + "";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
            JoinSubject();
            JoinCompetitor();
            JoinCompetitorProject();
            JoinCell();
        }
        public void Delete()
        {
            string strSql = " Delete From CRMNews Where NewsID = " + _ID + " ";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public DataTable Search()
        {
            string strSql = SearchStr + " Where 1 = 1 ";
            if (_ID != 0)
                strSql = strSql + " and NewsID = " + _ID + " ";
            if (_SubjectID != 0)
                strSql += " and NewsID in (select NewsID from CRMNewsSubject where SubjectID=" + _SubjectID + ")";
            if (_SubjectIDs != null && _SubjectIDs != "")
                strSql += " and NewsID in (select NewsID from CRMNewsSubject where SubjectID in(" + _SubjectIDs + "))";
            if (_CellID != 0)
                strSql += " and NewsID in (select NewsID from CRMNewsCell where CellID = "+ _CellID +")";
            if (_CompetitorID != 0)
                strSql += " and NewsID in (select NewsID from CRMNewsCompetitor where CompetitorID=" + _CompetitorID + ")";
            if(_CompetitorProjectID != 0)
                strSql += " and NewsID in (select NewsID from CRMNewsCompetitorProject where ProjectID=" + _CompetitorProjectID + ")";
            if (_TextSearch != null && _TextSearch != "")
            {
                strSql += " and (NewsTitle like '%" + _TextSearch + "%' or NewsSummary like '%"+ _TextSearch +"%')";
            }
            if (_Type != 0)
                strSql += " and NewsType = " + _Type;
            if (_IsDateRange)
            {
                double dblStartDate = SysUtility.Approximate(_StartDate.ToOADate() - 2, 1, ApproximateType.Down);
                double dblEndDate = SysUtility.Approximate(_EndDate.ToOADate() - 2, 1, ApproximateType.Up);
                strSql += " and NewsDate>=" + dblStartDate + " and NewsDate<"+ dblEndDate ;
            }
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        void JoinSubject()
        {
            if (_Subject == null)
                return;
            string[] arrStr = new string[_Subject.Rows.Count + 1];
            arrStr[0] = "delete from CRMNewsSubject  where NewsID="+ _ID;
            int intIndex = 1;
            foreach(DataRow objDr in _Subject.Rows)
            {
                arrStr[intIndex] = "insert into CRMNewsSubject (NewsID,SubjectID) values ("+ ID +"," +
                    objDr["Subject"].ToString() +")";
                intIndex++;
            }
            SysData.SharpVisionBaseDb.ExecuteNonQuery(arrStr);
        }
        public DataTable GetSubject()
        {
            string strSql = "select NewsID,SubjectTable.* "+
                " from (" + SubjectDb.SearchStr + ") as SubjectTable inner join "+
                "CRMNewsSubject on SubjectTable.SubjectID = CRMNewsSubject.SubjectID where (NewsID = " + ID + ")";
           

            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }

        void JoinCompetitor()
        {
            if (_Competitor == null)
                return;
            string[] arrStr = new string[_Competitor.Rows.Count + 1];
            arrStr[0] = "delete from CRMNewsCompetitor  where NewsID=" + _ID;
            int intIndex = 1;
            foreach (DataRow objDr in _Competitor.Rows)
            {
                arrStr[intIndex] = "insert into CRMNewsCompetitor (NewsID,CompetitorID) values (" + ID + "," +
                    objDr["Competitor"].ToString() + ")";
                intIndex++;
            }
            SysData.SharpVisionBaseDb.ExecuteNonQuery(arrStr);
        }
        public DataTable GetCompetitor()
        {
            string strSql = "select NewsID,CompetitorTable.* " +
                " from (" + CompetitorDb.SearchStr + ") as CompetitorTable inner join " +
                "CRMNewsCompetitor on CompetitorTable.CompetitorID = CRMNewsCompetitor.CompetitorID where (NewsID = " + ID + ")";


            return  SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        void JoinCell()
        {
            if (_Cell == null)
                return;
            string[] arrStr = new string[_Cell.Rows.Count + 1];
            arrStr[0] = "delete from CRMNewsCell  where NewsID=" + _ID;
            int intIndex = 1;
            foreach (DataRow objDr in _Cell.Rows)
            {
                arrStr[intIndex] = "insert into CRMNewsCell (NewsID,CellID) values (" + ID + "," +
                    objDr["Cell"].ToString() + ")";
                intIndex++;
            }
            SysData.SharpVisionBaseDb.ExecuteNonQuery(arrStr);
        }
        public DataTable GetCell()
        {
            string strSql = "select NewsID,CellTable.* " +
                " from (" + CellDb.SearchStr + ") as CellTable inner join " +
                "CRMNewsCell on CellTable.CellID = CRMNewsCell.CellID where (NewsID = " + ID + ")";


            return  SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        void JoinCompetitorProject()
        {
            if (_CompetitorProject == null)
                return;
            string[] arrStr = new string[_CompetitorProject.Rows.Count + 1];
            arrStr[0] = "delete from CRMNewsCompetitorProject  where NewsID=" + _ID;
            int intIndex = 1;
            foreach (DataRow objDr in _CompetitorProject.Rows)
            {
                arrStr[intIndex] = "insert into CRMNewsCompetitorProject (NewsID,ProjectID) values (" + ID + "," +
                    objDr["CompetitorProject"].ToString() + ")";
                intIndex++;
            }
            SysData.SharpVisionBaseDb.ExecuteNonQuery(arrStr);
        }
        public DataTable GetCompetitorProject()
        {
            string strSql = "select NewsID,CompetitorProjectTable.* " +
                " from (" + CompetitorProjectDb.SearchStr + ") as CompetitorProjectTable inner join " +
                "CRMNewsCompetitorProject on CompetitorProjectTable.ProjectID = CRMNewsCompetitorProject.ProjectID where (NewsID = " + ID + ")";


            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        #endregion
    }
}
