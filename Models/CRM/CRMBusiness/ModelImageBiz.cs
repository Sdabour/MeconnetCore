using System;
using System.Collections.Generic;
using System.Linq;

using System.Data;
using SharpVision.CRM.CRMDataBase;
using SharpVision.COMMON.COMMONBusiness;
namespace SharpVision.CRM.CRMBusiness
{
    public class ModelImageBiz
    {
        #region Private Data and Public Properties
        ModelImageDb _ModelImagedDb;
        ImageBiz _ImageBiz;

        public ImageBiz ImageBiz
        {
            get { return _ImageBiz; }
            set { _ImageBiz = value; }
        }
        public int ModelID
        {
            get { return _ModelImagedDb.ModelID; }
            set { _ModelImagedDb.ModelID = value; }
        }





        public int Order
        {
            get { return _ModelImagedDb.Order; }
            set
            {
                _ModelImagedDb.Order = value;
            }
        }


        public string TitleA
        {
            get { return _ModelImagedDb.TitleA; }
            set { _ModelImagedDb.TitleA = value; }
        }


        public string TitleE
        {
            get { return _ModelImagedDb.TitleE; }
            set { _ModelImagedDb.TitleE = value; }
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
        public ModelImageBiz()
        {
            _ModelImagedDb = new ModelImageDb();
        }
        public ModelImageBiz(DataRow objDr)
        {
            _ModelImagedDb = new ModelImageDb(objDr);
            _ImageBiz = new ImageBiz(objDr);
        }
        #endregion

        #region Private Methods

        #endregion
        #region Public Methods
        public DataRow GetRow(int intModel, DataTable dtImage)
        {
            DataRow objDr = dtImage.NewRow();
            objDr["ModelID"] = ModelID;
            objDr["ImageID"] = ImageBiz.ID;
            objDr["ImageOrder"] = Order;
            objDr["ModelImageTitleA"] = TitleA;
            objDr["ModelImageTitleE"] = TitleE;
            objDr["SecondaryModel"] = intModel;
            return objDr;
        }
        #endregion
    }
}