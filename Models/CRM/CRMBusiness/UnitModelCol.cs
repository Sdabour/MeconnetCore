using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.UMS.UMSBusiness;
using SharpVision.CRM.CRMDataBase;
using System.Data;
using SharpVision.Base.BaseBusiness;
using SharpVision.RP.RPBusiness;
using SharpVision.RP.RPDataBase;
using SharpVision.SystemBase;
namespace SharpVision.CRM.CRMBusiness
{
    public class UnitModelCol : BaseCol
    {
        public UnitModelCol(bool blIsempty)
        {
            if (blIsempty)
                return;
            Add(new UnitModelBiz() { ID = 0, NameA = "€Ì— „Õœœ", NameE = "NotSpecified" });

            UnitModelDb objDb = new UnitModelDb();
            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
            {
                Add(new UnitModelBiz(objDr));
            }

        }

        public UnitModelCol(CellBiz objCellBiz)
        {
            UnitModelDb objModelDb = new UnitModelDb();
            objModelDb.CellID = objCellBiz.ID;
            DataTable dtTemp = objModelDb.Search();
            UnitModelBiz objBiz = new UnitModelBiz();
            objBiz.ID = 0;
            objBiz.NameA = "€Ì— „Õœœ";
            Add(objBiz);
            // DataTable dtTemp = objModelDb.Search();
            DataRow[] arrDr = dtTemp.Select("ModelID=ModelParentID", "");
            UnitModelBiz objTemp;
            foreach (DataRow objDr in arrDr)
            {
                objTemp = new UnitModelBiz(objDr);
                SetChildren(ref objTemp, ref dtTemp);
                this.Add(objTemp);
            }
        }
        public UnitModelCol(int intProjectID)
        {
            UnitModelDb objModelDb = new UnitModelDb();
            objModelDb.CellID = intProjectID;
            DataTable dtTemp = objModelDb.Search();
            //DataTable dtTemp = objModelDb.Search();
            DataRow[] arrDr = dtTemp.Select(" ModelID=ModelParentID", "");
            UnitModelBiz objTemp;
            foreach (DataRow objDr in arrDr)
            {
                objTemp = new UnitModelBiz(objDr);
                SetChildren(ref objTemp, ref dtTemp);
                this.Add(objTemp);
            }
        }
        public UnitModelCol(CellBiz ObjCellBiz, string strNameA, string strNameE, double dblSurveyFrom, double dblSurveyTo, double dblUnitPriceFrom, double dblUnitPriceTo)
        {

            if (dblUnitPriceFrom != 0 && dblUnitPriceTo == 0)
                dblUnitPriceTo = dblUnitPriceFrom;
            if (dblSurveyFrom != 0 && dblSurveyTo == 0)
                dblSurveyTo = dblUnitPriceFrom;

            UnitModelDb objModelDb = new UnitModelDb();

            objModelDb.CellID = ObjCellBiz.ID;

            objModelDb.SurveyFrom = dblSurveyFrom;
            objModelDb.SurveyTo = dblSurveyTo;
            objModelDb.UnitPriceFrom = dblUnitPriceFrom;
            objModelDb.UnitPriceTo = dblUnitPriceTo;
            objModelDb.NameAlike = strNameA;
            objModelDb.NameElike = strNameE;

            DataTable dtTemp = objModelDb.Search();
            DataRow[] arrDr = dtTemp.Select(" ModelID=ModelParentID", "");
            UnitModelBiz objTemp;
            foreach (DataRow objDr in arrDr)
            {
                objTemp = new UnitModelBiz(objDr);
                SetChildren(ref objTemp, ref dtTemp);
                this.Add(objTemp);
            }

        }
        #region public Property
        public UnitModelBiz this[int intIndex]
        {

            get
            {
                return (UnitModelBiz)List[intIndex];
            }
        }
        public string IDsStr
        {
            get
            {
                string Returned = "";
                foreach (UnitModelBiz objBiz in this)
                {
                    if (Returned != "")
                        Returned = Returned + ",";
                    Returned = Returned + objBiz.ID;
                }
                return Returned;
            }
        }
        public UnitModelCol LinearCol
        {
            get
            {
                UnitModelCol Returned = new UnitModelCol(true);
                foreach (UnitModelBiz objBiz in this)
                {
                    Returned.Add(objBiz);
                    SetLinearChildren(objBiz, ref Returned);
                }
                return Returned;
            }
        }
        #endregion
        #region Private Method
        void SetChildren(ref UnitModelBiz objUnitModelBiz, ref DataTable dtUnitModels)
        {
            objUnitModelBiz.Children = new UnitModelCol(true);
            //objUnitModelBiz.Children.RootBiz = objUnitModelBiz;
            DataRow[] arrDR = dtUnitModels.Select(" ModelID <> ModelParentID and ModelParentID=" + objUnitModelBiz.ID);
            UnitModelBiz tempUnitModelBiz;
            UnitModelCol objUnitModelCol;
            objUnitModelCol = new UnitModelCol(true);
            int intTemp = 0;

            foreach (DataRow DR in arrDR)
            {

                tempUnitModelBiz = new UnitModelBiz(DR);

                if (intTemp == tempUnitModelBiz.ID)
                    continue;
                else
                {

                    intTemp = tempUnitModelBiz.ID;
                    SetChildren(ref tempUnitModelBiz, ref dtUnitModels);
                    tempUnitModelBiz.ParentBiz = objUnitModelBiz;
                    objUnitModelCol.Add(tempUnitModelBiz);


                }
                objUnitModelBiz.Children = objUnitModelCol;

            }
        }
        void SetLinearChildren(UnitModelBiz objBiz, ref UnitModelCol objCol)
        {
            if (objCol == null)
                objCol = new UnitModelCol(true);
            if (objBiz.Children == null)
                return;
            foreach (UnitModelBiz objModelBiz in objBiz.Children)
            {
                objCol.Add(objModelBiz);
            }

        }
        #endregion
        #region Public Method
        public void Add(UnitModelBiz objBiz)
        {
            List.Add(objBiz);

        }
        public UnitModelCol GetCol(string strName)
        {
            UnitModelCol Returned = new UnitModelCol(true);
            foreach (UnitModelBiz objBiz in this)
            {
                if (objBiz.Name.CheckStr(strName))
                    Returned.Add(objBiz);
            }
            return Returned;
        }
        public UnitModelCol Copy()
        {
            UnitModelCol Returned = new UnitModelCol(true);
            foreach (UnitModelBiz objBiz in this)
            {
                Returned.Add(objBiz);
            }
            return Returned;
        }
        #endregion
    }
}
