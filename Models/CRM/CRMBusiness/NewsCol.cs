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
    public class NewsCol : BaseCol
    {
        public NewsCol(bool blIsEmpty)
        {

            if (!blIsEmpty)
            {
                NewsDb objDb = new NewsDb();
                DataTable dtTemp = objDb.Search();
                foreach (DataRow objDR in dtTemp.Rows)
                {
                    Add(new NewsBiz(objDR));
                }
            }
        }
        public NewsCol()
        {
            NewsDb objDb = new NewsDb();

            DataTable dtTemp = objDb.Search();
            NewsBiz objBiz = new NewsBiz();
            foreach (DataRow objDR in dtTemp.Rows)
            {
                Add(new NewsBiz(objDR));
            }

        }

        public NewsCol(NewsType objNewsType,string strText, SubjectBiz objSubjectBiz, CellBiz objProjectBiz, CompetitorBiz objCompetitorBiz,
            CompetitorProejctBiz objCompetitorProjectbiz,bool blIsDateRange,DateTime dtStartDate,DateTime dtEndDate)
        {
            NewsDb objNewsDb = new NewsDb();
            objNewsDb.SubjectIDs = objSubjectBiz.IDsStr;
            objNewsDb.CellID = objProjectBiz.ID;
            objNewsDb.CompetitorID = objCompetitorBiz.ID;
            objNewsDb.CompetitorProjectID = objCompetitorProjectbiz.ID;
            objNewsDb.TextSearch = strText;
            objNewsDb.Type = (int)objNewsType;
            objNewsDb.IsDateRange = blIsDateRange;
            objNewsDb.StartDate = dtStartDate;
            objNewsDb.EndDate = dtEndDate;
            DataTable dtTemp = objNewsDb.Search();
            foreach (DataRow objDR in dtTemp.Rows)
            {
                Add(new NewsBiz(objDR));
            }

        }
        public virtual NewsBiz this[int intIndex]
        {
            get
            {
                return (NewsBiz)this.List[intIndex];
            }
        }
        public virtual void Add(NewsBiz objBiz)
        {

            this.List.Add(objBiz);
        }
    }
}
