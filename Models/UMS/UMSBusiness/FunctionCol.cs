using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.UMS.UMSDataBase;
using SharpVision.Base.BaseBusiness;
using System.Collections;

namespace SharpVision.UMS.UMSBusiness
{
    public class FunctionCol : BaseCol
    {
        DataTable _FunctionTable;
        Hashtable _FunctionHs =new Hashtable();
        public FunctionCol(int intSysID)
        {
            FunctionDb objFunctionDb = new FunctionDb();
            objFunctionDb.SysID = intSysID;
            DataTable dtFunction = objFunctionDb.Search();

            DataRow[] arrDR = dtFunction.Select(" FunctionID=FunctionParentID ");
            FunctionBiz objFunctionBiz;
            FunctionBiz objTempParent = new FunctionBiz();

            foreach (DataRow DR in arrDR)
            {

                objFunctionBiz = new FunctionBiz(DR);
                objFunctionBiz.RootBiz = objFunctionBiz;

                SetChildren(ref objFunctionBiz, ref dtFunction);
                this.Add(objFunctionBiz);
                
                //objFunctionBiz.ParentBiz = objFunctionBiz;

            }


           

        }
        public FunctionCol(bool blIsEmpty)
        {
           //  _FunctionTable = FunctionDb.FunctionTableStructure;

        }
       
        public bool Contains(string strName)
        {
            bool blReturned = false;
            foreach (FunctionBiz objFunctionBiz in this)
            {
                if (objFunctionBiz.Name == strName)
                {
                    blReturned = true;
                    break;
                }
            }
            return blReturned;

        }

        public virtual FunctionBiz this[int intIndex]
        {
            get
            {
                return (FunctionBiz)this.List[intIndex];

            }
        }
        public virtual FunctionBiz this[string strIndex]
        {
            get
            {
                FunctionBiz Returned = new FunctionBiz();
                foreach (FunctionBiz objFunctionBiz in this)
                {
                    if (objFunctionBiz.Name == strIndex)
                    {
                        Returned = objFunctionBiz.Copy();
                        break;
                    }
                }
                return Returned;
            }
        }
        public FunctionCol LinearCol
        {
            get
            {
                FunctionCol Returned = new FunctionCol(true);
                foreach (FunctionBiz objBiz in this)
                {
                    SetCol(objBiz, ref Returned);
                }
                return Returned;
            }
        }
        public DataTable FunctionTable
        {
            get
            {
                return _FunctionTable;
            }
        }


        #region Methods
        void SetFunctionChildren(ref FunctionBiz objFunctionBiz, ref DataTable dtFunction)
        {
            objFunctionBiz.FunctionChildren = new FunctionCol(true);
            DataRow[] arrDR = dtFunction.Select("FunctionID <> FunctionParentID and FunctionParentID=" + objFunctionBiz.ID, "FunctionNameA");
            FunctionBiz tempFunctionBiz;
            FunctionCol objFunctionCol;
            objFunctionCol = new FunctionCol(true);
            foreach (DataRow DR in arrDR)
            {
                tempFunctionBiz = new FunctionBiz(DR);
                SetFunctionChildren(ref tempFunctionBiz, ref dtFunction);
                tempFunctionBiz.ParentBiz = objFunctionBiz;
                objFunctionCol.Add(tempFunctionBiz);

            }
            objFunctionBiz.FunctionChildren = objFunctionCol;

        }
        void SetChildren(ref FunctionBiz objFunctionBiz, ref DataTable dtFunctions)
        {
            objFunctionBiz.Children = new FunctionCol(true);
            //objFunctionBiz.Children.RootBiz = objFunctionBiz;
            DataRow[] arrDR = dtFunctions.Select("FunctionID <> FunctionParentID and FunctionParentID=" + objFunctionBiz.ID);
            FunctionBiz tempFunctionBiz;
            FunctionCol objFunctionCol;
            objFunctionCol = new FunctionCol(true);
            int intTemp = 0;

            foreach (DataRow DR in arrDR)
            {

                tempFunctionBiz = new FunctionBiz(DR);
                tempFunctionBiz.ParentBiz = objFunctionBiz;
                if (intTemp == tempFunctionBiz.ID)
                    continue;
                else
                {

                    intTemp = tempFunctionBiz.ID;
                    SetChildren(ref tempFunctionBiz, ref dtFunctions);
                    tempFunctionBiz.ParentBiz = objFunctionBiz;
                    tempFunctionBiz.RootBiz = objFunctionBiz.RootBiz;
                    objFunctionCol.Add(tempFunctionBiz);


                }
                objFunctionBiz.Children = objFunctionCol;

            }
        }
        void SetChildrenCol(ref FunctionCol objFunctionCol, string strFunction, FunctionBiz objFunctionBiz,int intFunctionID,bool blIsLinear)
        {
            bool blIsFound = true;

            string[] arrStr = strFunction.Split("%".ToCharArray());
            foreach (string strTemp in arrStr)
            {
                if (objFunctionBiz.Name.IndexOf(strTemp) == -1)
                    blIsFound = false;


            }
            if (intFunctionID != 0 && objFunctionBiz.ID == intFunctionID)
                blIsFound = true;
            else if (intFunctionID != 0 && objFunctionBiz.ID != intFunctionID)
                blIsFound = false;
            if (blIsFound)
            {
                objFunctionCol.Add(objFunctionBiz);
                if (objFunctionBiz.Children != null&& blIsLinear)// && ((strFunction != null && strFunction != "")|| intFunctionID!= 0  ))
                    objFunctionCol.Add(objFunctionBiz.Children.LinearCol);
            }
            else
                if (objFunctionBiz.Children != null)
                {
                    foreach (FunctionBiz objBiz in objFunctionBiz.Children)
                    {
                        SetChildrenCol(ref objFunctionCol, strFunction, objBiz,intFunctionID,blIsLinear);
                    }
                }
            
        }
        void SetFunctionBiz(int intFunctionID,FunctionBiz objSrcFunction,ref FunctionBiz objDestFunctionBiz)
        {
            if (objDestFunctionBiz == null)
                objDestFunctionBiz = new FunctionBiz();
            if (objSrcFunction == null)
            {
                objSrcFunction = new FunctionBiz();
            }
            if (objSrcFunction.Children == null)
                objSrcFunction.Children = new FunctionCol(true);
            if (objSrcFunction.ID == intFunctionID)
                objDestFunctionBiz = objSrcFunction;
            else
            {
                foreach (FunctionBiz objFunctionBiz in objSrcFunction.Children)
                {
                    SetFunctionBiz(intFunctionID, objFunctionBiz, ref objDestFunctionBiz);
                }
            }
 
        }
        void SetCol(FunctionBiz objBiz, ref FunctionCol objCol)
        {
            if (objCol == null)
                objCol = new FunctionCol(true);
            objCol.Add(objBiz);
            if (objBiz.Children != null)
            {
                foreach (FunctionBiz objFunctionBiz in objBiz.Children)
                    SetCol(objFunctionBiz, ref objCol);
            }
        }
        #endregion

        public virtual void Add(FunctionBiz objFunctionBiz)
        {
            if (_FunctionHs == null)
                _FunctionHs = new Hashtable();
            if (_FunctionHs[objFunctionBiz.ID.ToString()] == null)
            {
                this.List.Add(objFunctionBiz);
                _FunctionHs.Add(objFunctionBiz.ID.ToString(), Count - 1);
            }
        }

        public virtual void Add(FunctionCol objFunctionCol)
        {
            if (_FunctionHs == null)
                _FunctionHs = new Hashtable();
            foreach (FunctionBiz objFunctionBiz in objFunctionCol)
            {
                //if (_FunctionHs[objFunctionBiz.ID.ToString()] == null)
                //{
                //    this.List.Add(objFunctionBiz);
                //    _FunctionHs.Add(objFunctionBiz.ID.ToString(), Count - 1);
                //}
                Add(objFunctionBiz);

            }
        }

        public FunctionCol Copy()
        {
            FunctionCol Returned = new FunctionCol(true);
            foreach (FunctionBiz objTemp in this)
            {
                Returned.Add(objTemp.Copy());
            }
            return Returned;
        }
        public FunctionCol GetFunctionCol(string strFunctionName,int intFunctionID,bool blIsLinear)
        {

            FunctionCol Returned = new FunctionCol(true);

            foreach (FunctionBiz objFunctionbiz in this)
            {
                SetChildrenCol(ref Returned, strFunctionName, objFunctionbiz,intFunctionID,blIsLinear);
            }
            return Returned;
        }
        public FunctionBiz GetFunctionBiz(int intFunctionID)
        {
            FunctionBiz Returned = new FunctionBiz();
            foreach (FunctionBiz objBiz in this)
            {
                SetFunctionBiz(intFunctionID, objBiz, ref Returned);
                if (Returned.ID != 0)
                    break;
            }
            return Returned;
 
        }
        public static FunctionCol GetFunctionColByIDs(string strIDs)
        {
            if (strIDs == null || strIDs.Trim() == "")
                return new FunctionCol(true);
            FunctionCol Returned = new FunctionCol(true);
            FunctionDb objDb = new FunctionDb();
            objDb.FunctionIDs = strIDs;
            objDb.IsStopedStatus = 1;
            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
            {
                Returned.Add(new FunctionBiz(objDr));
            }
            return Returned;
        }
       
    }
}
