using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.Base.BaseDataBase;
using SharpVision.Base.BaseBusiness;
using SharpVision.GL.GLDataBase;
using SharpVision.SystemBase;

namespace SharpVision.GL.GLBusiness
{
    public class ReceiptModelCol : BaseCol
    {
        static ReceiptModelCol _ActiveModelCol;
        static ReceiptModelCol _AllModelCol;
        public ReceiptModelCol(int intStoppedStatus)
        {
            ReceiptModelDb objDb = new ReceiptModelDb();
            objDb.StoppedStatus= intStoppedStatus;
            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
            {
                Add(new ReceiptModelBiz(objDr));
            }
        }
        public ReceiptModelCol(bool blIsempty)
        {
            if (blIsempty)
                return;
            ReceiptModelBiz objModelBiz = new ReceiptModelBiz();
            objModelBiz.Desc = "€Ì— „Õœœ";
            Add(objModelBiz);
            ReceiptModelDb objDb = new ReceiptModelDb();
            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
            {
                Add(new ReceiptModelBiz(objDr));
            }
        }
      

        public ReceiptModelBiz this[int intIndex]
        {

            get
            {
                return (ReceiptModelBiz)List[intIndex];
            }
        }
        public static ReceiptModelCol AllModelCol
        {
            set
            {
                _AllModelCol = value;
            }
            get
            {
                if (_AllModelCol == null)
                    _AllModelCol = new ReceiptModelCol(0);
                return _AllModelCol;
            }
        }
        public static ReceiptModelCol ActiveModelCol
        {
            set
            {
                _ActiveModelCol = value;
            }
            get
            {
                //if (_ActiveModelCol == null)
                //    _ActiveModelCol = new ReceiptModelCol(2);
                if (_ActiveModelCol == null)
                {
                    _ActiveModelCol = new ReceiptModelCol(true);
                    foreach (ReceiptModelBiz objBiz in AllModelCol)
                    {
                        if (!objBiz.IsStopped)
                            _ActiveModelCol.Add(objBiz);
                    }
                }
                return _ActiveModelCol;
            }
        }
        public static ReceiptModelCol ActiveInModelCol
        {
           
            get
            {
                ReceiptModelCol Returned = new ReceiptModelCol(true);
                    foreach (ReceiptModelBiz objBiz in AllModelCol)
                    {
                        if (!objBiz.IsStopped && objBiz.Direction)
                            Returned.Add(objBiz);
                    }
                 
                return Returned;
            }
        }
        public static ReceiptModelCol ActiveOutModelCol
        {

            get
            {
               ReceiptModelCol Returned = new ReceiptModelCol(true);
                    foreach (ReceiptModelBiz objBiz in AllModelCol)
                    {
                        if (!objBiz.IsStopped && !objBiz.Direction)
                            Returned.Add(objBiz);
                    }
               
                return Returned;
            }
        }
        public ReceiptModelBiz GetReceiptModelByID(int intID)
        {
            ReceiptModelBiz Returned = new ReceiptModelBiz();
            foreach (ReceiptModelBiz objBiz in this)
            {
                if (objBiz.ID == intID)
                {
                    Returned = objBiz;
                    break;
                }

            }
            return Returned;
        }
        public void Add(ReceiptModelBiz objBiz)
        {
            List.Add(objBiz);

        }
        public ReceiptModelBiz GetReceiptModelByID1(int intID)
        {
            ReceiptModelBiz Returned = new ReceiptModelBiz();
            foreach (ReceiptModelBiz objBiz in ActiveModelCol)
            {
                if (objBiz.ID == intID)
                    return objBiz;
            }
            return Returned;

        }
        public ReceiptModelCol GetColByDesc(string strDesc)
        {
            ReceiptModelCol Returned = new ReceiptModelCol(true);
            foreach (ReceiptModelBiz objBiz in this)
            {
                if (objBiz.Desc.IndexOf(strDesc, StringComparison.OrdinalIgnoreCase) != -1)
                    Returned.Add(objBiz);
            }
            return Returned;
        }
        public static ReceiptModelBiz GetModelBiz(bool blDirection,int intBranchID,int intProjectID)
        {

           
                ReceiptModelBiz Returned = new ReceiptModelBiz();
            
                foreach (ReceiptModelBiz objBiz in AllModelCol)
                {
                    if (!objBiz.IsStopped && objBiz.Direction == blDirection && (  objBiz.Branch == intBranchID) &&
                        ( objBiz.ProjectID == intProjectID ||  objBiz.ProjectHash[intProjectID.ToString()]!= null))
                        return objBiz;
                }
                foreach (ReceiptModelBiz objBiz in AllModelCol)
                {
                    if (!objBiz.IsStopped && objBiz.Direction == blDirection &&
                        (objBiz.Branch == 0 || objBiz.Branch == intBranchID) &&
                        ((objBiz.ProjectID == 0 || objBiz.ProjectID == intProjectID) &&
                        objBiz.ProjectHash[intProjectID.ToString()] != null))
                        return objBiz;
                }
                foreach (ReceiptModelBiz objBiz in AllModelCol)
                {
                    if (!objBiz.IsStopped && objBiz.Direction == blDirection &&  objBiz.ProjectID == intProjectID)
                        return objBiz;
                }
                foreach (ReceiptModelBiz objBiz in AllModelCol)
                {
                    if (!objBiz.IsStopped && objBiz.Direction == blDirection && objBiz.Branch == intBranchID )
                        return objBiz;
                }
                foreach (ReceiptModelBiz objBiz in AllModelCol)
                {
                    if (!objBiz.IsStopped && objBiz.Direction == blDirection )
                        return objBiz;
                }
                return Returned;
            
        }
    }
}
