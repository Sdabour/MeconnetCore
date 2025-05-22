using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Collections;
using Algorithmat.Algorithmat.AlgorithmatDataBase;
using SharpVision.SystemBase;
namespace Algorithmat.Algorithmat.AlgorithmatBusiness
{
    public class PageCol:CollectionBase
    {
        #region Private Data and Public Properties

        #endregion
        #region Constructors
        public PageCol(bool blIsEmpty)
        {
 
        }
        public PageCol()
        {
            PageDb objDb = new PageDb();
            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
                Add(new PageBiz(objDr));
            
        }
        public PageCol(int intID, string strDesc, string strTitle, string strUrl)
        {
            PageDb objDb = new PageDb();
            objDb.ID = intID;
            objDb.Desc = strDesc;
            objDb.URLA = strUrl;
            objDb.TitleA = strTitle;
            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
                Add(new PageBiz(objDr));
        }
        #endregion
        #region Properties
        public PageBiz this[int intIndex]
        {
            get
            {
                return (PageBiz)List[intIndex];
            }
        }

        public List<string> DisplayLinkLst
        {
            get
            {
                List<string> Returned = new List<string>();
                foreach (PageBiz objBiz in this)
                {
                    Returned.Add( objBiz.URLA);
                    Returned.Add(objBiz.URLE);
                  
                }
                return Returned;
            }
        }
        #endregion
        #region Private Methods

        #endregion
        #region Public Methods
        public void Add(PageBiz objBiz)
        {
            List.Add(objBiz);
        }
        internal DataColumn[] Columns
        {
            get
            {
                DataColumn[] Returned = new DataColumn[] {new DataColumn("PageID"), new DataColumn("PageDesc"),
                new DataColumn("PageTitleA"),new DataColumn("PageTitleE"),new DataColumn("PageURLA"),
                new DataColumn("PageURLE"),new DataColumn("PageIsStoped",Type.GetType("System.Boolean")),
                new DataColumn("PageIsChanged",Type.GetType("System.Boolean"))
 };
                return Returned;
            }
        }
        public DataTable GetTable()
        {
            DataTable Returned = new DataTable(PageDb.TableName);
            Returned.Columns.AddRange(Columns);
            DataRow objDr;
            foreach (PageBiz objBiz in this)
            {
                objDr = Returned.NewRow();
                objDr["PageID"] = objBiz.ID;
                objDr["PageDesc"] = objBiz.Desc;
                objDr["PageTitleA"] = objBiz.TitleA;
                objDr["PageTitleE"] = objBiz.TitleE;
                objDr["PageURLA"] = objBiz.URLA;
                objDr["PageURLE"] = objBiz.URLE;
                objDr["PageIsStoped"] = objBiz.IsStoped;
                objDr["PageIsChanged"] = objBiz.IsChanged;

                Returned.Rows.Add(objDr);
            }
            return Returned;
        }
        public static string GetGoogleSiteMap()
        {
            string Returned = "";
            PageCol objPageCol = new PageCol();
            List<string> arrUrl = new List<string>();
            List<string> arrTemp = objPageCol.DisplayLinkLst;
            foreach (string strTemp in arrTemp)
            {
                arrUrl.Add(SysData.MainURL + "/" + strTemp);
            }
            ContentCol objContentCol = new ContentCol();
            arrTemp = objContentCol.DisplayHTMLLinkLst;
            foreach (string strTemp in arrTemp)
            {
                arrUrl.Add(SysData.MainURL + "/" + strTemp);
            }
            Returned = SysUtility.GetSiteMap(arrUrl);
            return Returned;
        }
        #endregion
    }
}