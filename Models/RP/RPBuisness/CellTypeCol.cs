using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.RP.RPDataBase;
using System.Data;
using System.Collections;
using SharpVision.Base.BaseBusiness;
using SharpVision.SystemBase;
namespace SharpVision.RP.RPBusiness
{
    public class CellTypeCol : BaseCol
    {
        #region PrivateData
        static CellTypeCol _CellTypeCol;
        #endregion
        
        public CellTypeCol()
        {
            CellTypeDb objCellTypeDb = new CellTypeDb();
            DataTable dtCellType = objCellTypeDb.Search();
            string strOrder = "";
            if (SysData.Language == 0)
                strOrder = "CellTypeNameA";
            else
                strOrder = "CellTypeNameE";

            DataRow[] arrDR = dtCellType.Select("CellTypeID=CellTypeParentID",strOrder);
            CellTypeBiz objCellTypeBiz;
            foreach (DataRow DR in arrDR)
            {
                objCellTypeBiz = new CellTypeBiz(DR);
                
                SetCellTypeChildren(ref objCellTypeBiz,ref dtCellType);
                this.Add(objCellTypeBiz);

            }
          
        }
        public CellTypeCol(bool blIsEmpty)
        {
            if (!blIsEmpty)
            {
                CellTypeDb objCellTypeDb = new CellTypeDb();
                DataTable dtCellType = objCellTypeDb.Search();
                string strOrder = "";

                DataRow[] arrDR = dtCellType.Select("CellTypeID=CellTypeParentID", "CellTypeNameA");
                CellTypeBiz objCellTypeBiz;
                objCellTypeBiz = new CellTypeBiz();
                objCellTypeBiz.ID = 0;
                objCellTypeBiz.NameA = "€Ì— „Õœœ…";
                objCellTypeBiz.NameE= "Not Defined";
                this.Add(objCellTypeBiz);
                foreach (DataRow DR in arrDR)
                {
                    objCellTypeBiz = new CellTypeBiz(DR);

                    //SetCellTypeChildren(ref objCellTypeBiz, ref dtCellType);
                    this.Add(objCellTypeBiz);

                }
            }
 
        }
        public virtual CellTypeBiz this[int intIndex]
        {
            get
            {
                return (CellTypeBiz)this.List[intIndex];
            }
        }
        public virtual CellTypeBiz this[string strIndex]
        {
            get
            {
                CellTypeBiz Returned = new CellTypeBiz();
                foreach (CellTypeBiz objCellTypeBiz in this)
                {
                    if (objCellTypeBiz.Name == strIndex)
                    {
                        Returned = objCellTypeBiz.Copy();
                        break;
                    }
                }
                return Returned;
            }
        }
        public static CellTypeCol TypeCol
        {
            set
            {
                _CellTypeCol = value;
            }
            get
            {
                if (_CellTypeCol == null)
                    _CellTypeCol = new CellTypeCol(false);
                return _CellTypeCol;
            }
        }
        #region  Privaet methods
        void SetCellTypeChildren(ref CellTypeBiz objCellTypeBiz,ref DataTable dtCellTypes )
        {
            objCellTypeBiz.Children = new CellTypeCol(true);
            string strOrder = "";
            if (SysData.Language == 0)
                strOrder = "CellTypeNameA";
            else
                strOrder = "CellTypeNameE";
            DataRow[] arrDR = dtCellTypes.Select("CellTypeID <> CellTypeParentID and CellTypeParentID=" + objCellTypeBiz.ID , strOrder);
            CellTypeBiz tempCellTypeBiz;
            CellTypeCol objCellTypeCol;
            objCellTypeCol = new CellTypeCol(true);
            foreach (DataRow DR in arrDR)
            {
                tempCellTypeBiz = new CellTypeBiz(DR);
                SetCellTypeChildren(ref tempCellTypeBiz, ref dtCellTypes);
                tempCellTypeBiz.ParentBiz = objCellTypeBiz;
                objCellTypeCol.Add(tempCellTypeBiz);

            }
            objCellTypeBiz.Children = objCellTypeCol;
 
        }
        
        #endregion
        public virtual void Add(CellTypeBiz objCellTypeBiz)
        {
            this.List.Add(objCellTypeBiz);
        }

        public virtual void Add(CellTypeCol objCellTypeCol)
        {
            foreach (CellTypeBiz objCellTypeBiz in objCellTypeCol)
            {
                if(this[objCellTypeBiz.Name].ID==0)
                    this.List.Add(objCellTypeBiz.Copy());
                
            }
        }
        public static CellTypeBiz GetCellTypeByID(int intID)
        {
            if (_CellTypeCol == null)
                _CellTypeCol = new CellTypeCol(false);
            for (int intIndex = 0; intIndex < _CellTypeCol.Count; intIndex++)
            {
                if (_CellTypeCol[intIndex].ID == intID)
                    return _CellTypeCol[intIndex];
            }
            return _CellTypeCol[0];
        }
        public static void UpdateCellTypeCol()
        {
            _CellTypeCol = new CellTypeCol(false);
        }
        public CellTypeCol Copy()
        {
            CellTypeCol Returned = new CellTypeCol(true);
            foreach (CellTypeBiz objTemp in this)
            {
                Returned.Add(objTemp.Copy());
            }
            return Returned;
        }
    }
}
