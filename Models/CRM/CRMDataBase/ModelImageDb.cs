using System;
using System.Collections.Generic;
using System.Linq;
using SharpVision.Base.BaseDataBase;
using System.Data;
using SharpVision.COMMON.COMMONDataBase;
using SharpVision.SystemBase;

namespace SharpVision.CRM.CRMDataBase
{
    public class ModelImageDb
    {
        #region Private Data

        #endregion
        #region Constructors
        public ModelImageDb()
        { }
        public ModelImageDb(DataRow objDr)
        {
            SetData(objDr);
        }
        #endregion
        #region Public Properties
        int _ModelID;

        public int ModelID
        {
            get { return _ModelID; }
            set { _ModelID = value; }
        }
        int _ImageID;

        public int ImageID
        {
            get { return _ImageID; }
            set { _ImageID = value; }
        }
        int _Order;

        public int Order
        {
            get { return _Order; }
            set { _Order = value; }
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
      
        public string AddStr
        {
            get
            {
                string Returned = "insert into CRMUnitModelImage (ModelID, ImageID, ImageOrder, ModelImageTitleA,ModelImageTitleE) " +
                    " values (" + _ModelID + "," + _ImageID + "," + _Order + ",'" + _TitleA + "','" + _TitleE + "') ";
                return Returned;
            }
        }

        public static string SearchStr
        {
            get
            {
                string Returned = "SELECT        CRMUnitModelImage.ModelID, CRMUnitModelImage.ImageOrder" +
                    ", CRMUnitModelImage.ModelImageTitleA, CRMUnitModelImage.ModelImageTitleE " +
                    ",ImageTable.* " +
                        " FROM    CRMUnitModelImage INNER JOIN " +
                       " (" + ImageDb.SearchStr + ") AS ImageTable ON CRMUnitModelImage.ImageID = ImageTable.ImageID " +
                       "  INNER JOIN    CRMUnitModel " +
                       " ON CRMUnitModelImage.ModelID = CRMUnitModel.ModelID " ;
                return Returned;
            }
        }
        public static string TableName
        {
            get { return "ModelImageTable"; }
        }
        #endregion
        #region Private Methods
        void SetData(DataRow objDr)
        {
            _ModelID = int.Parse(objDr["ModelID"].ToString());
            _ImageID = int.Parse(objDr["ImageID"].ToString());
            _Order = int.Parse(objDr["ImageOrder"].ToString());
            _TitleA = objDr["ModelImageTitleA"].ToString();
            _TitleE = objDr["ModelImageTitleE"].ToString();
        }
        #endregion
        #region Publi Method
        public DataTable Search()
        {
            string strSql = SearchStr + " where (1=1) ";
            if (_ModelID != 0)
                strSql += " and  CRMUnitModelImage.ModelID = " + _ModelID;
            DataTable Returned = SysData.SharpVisionBaseDb.ReturnDatatable(strSql, TableName);
            return Returned;
        }
        #endregion
    }
}