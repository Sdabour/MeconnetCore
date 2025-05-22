using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.HR.HRDataBase;
using SharpVision.Base.BaseBusiness;
using System.Data;
using System.Collections;
//using SharpVision.SystemBase;
using System.Linq;
namespace SharpVision.HR.HRBusiness
{
    public class BranchCol : BaseCol
    {
        #region PrivateData
        BranchBiz _RootBiz;
        int _NodeNo;
        #endregion
        public BranchCol(bool blIsEmpty)
        { }
        public BranchCol()
        {
            BranchDb objBranchDb = new BranchDb();
            DataTable dtBranch = objBranchDb.Search();
            //dtBranch.Columns["BranchOrder"].DataType = Type.GetType("System.Int");
            DataRow[] arrDR = dtBranch.Select(" BranchID=BranchParentID ");
            BranchBiz objBranchBiz;
            BranchBiz objTempParent = new BranchBiz();

            foreach (DataRow DR in arrDR)
            {

                objBranchBiz = new BranchBiz(DR);

                SetChildren(ref objBranchBiz, ref dtBranch);
                this.Add(objBranchBiz);
                objBranchBiz.ParentBiz = objBranchBiz;
                this.Add(objBranchBiz);
            

            }

        }
        internal BranchCol(int intBranchID, DataTable dtBranch)
        {

            string strOrder = "";


            DataRow[] arrDR = dtBranch.Select("BranchID<>" + intBranchID + " and BranchParentID=" + intBranchID , strOrder);
            BranchBiz objBranchBiz;
            BranchBiz objTempParent = new BranchBiz();

            foreach (DataRow DR in arrDR)
            {
                objBranchBiz = new BranchBiz(DR);
               
                if (_NodeNo >= 100)
                    break;
                SetChildren( ref objBranchBiz, ref dtBranch);
                this.Add(objBranchBiz);
                objBranchBiz.ParentBiz = objTempParent;

            }

        }

        public BranchCol(int intTypeID, string strBranchName, 
            BranchBiz objParentBiz, bool blOnlyFamilies, bool blNoChildren)
        {
            DataTable dtTempBranch = new DataTable();


            if (objParentBiz == null)
                objParentBiz = new BranchBiz();
            else if (objParentBiz.ID != 0 && !blOnlyFamilies)
            {
                BranchDb objTempBranchDb = new BranchDb();
                objTempBranchDb.ID = objParentBiz.ID;
                objTempBranchDb.BranchTableSearch = new DataTable();
                dtTempBranch = objTempBranchDb.GetChildrenTable();
            }


            BranchDb objBranchDb = new BranchDb();
           

            objBranchDb.TypeID = intTypeID;
            objBranchDb.NameLike = strBranchName;
            objBranchDb.OnlyFamilies = blOnlyFamilies;
            objBranchDb.NoChildren = blNoChildren;
            if (objParentBiz.ID != 0 && !blOnlyFamilies)
            {
                objBranchDb.ParentID = objParentBiz.ID;
                objBranchDb.BranchTableSearch = dtTempBranch;
            }
            DataTable dtBranch;

            dtBranch = objBranchDb.GetAllBranch();
            if (dtBranch.Rows.Count == 0)
                return;
            int intTemp = 0;

            string strOrder = "BranchOrder";
            DataRow[] arrDR = dtBranch.Select("BranchID=BranchParentID", strOrder);
            BranchBiz objBranchBiz;
            BranchBiz objTempParent = new BranchBiz();
            foreach (DataRow DR in arrDR)
            {

                objBranchBiz = new BranchBiz(DR);
                
                if (intTemp == objBranchBiz.ID)
                    continue;
                else
                {

                    intTemp = objBranchBiz.ID;
                }
                if (_NodeNo >= 100)
                    break;
                SetChildren( ref objBranchBiz, ref dtBranch);
                this.Add(objBranchBiz);
                objBranchBiz.ParentBiz = objTempParent;

            }

        }
        public BranchCol(bool blIsEmpty,int intStoppedStatus)
        {
            if (!blIsEmpty)
            {
                BranchBiz objBiz = new BranchBiz();
                objBiz.NameA = "غير محدد";
                objBiz.NameE = "Not Specified";
                Add(objBiz);
                BranchDb objBranchDb = new BranchDb();
                objBranchDb.IsStoppedStatus = intStoppedStatus;
                objBranchDb.OnlyFamilies = true;
                DataTable dtTemp = objBranchDb.Search();
                foreach (DataRow objDr in dtTemp.Rows)
                {
                    Add(new BranchBiz(objDr));
                }
            }
        }
        public BranchCol(int intBranchID)
        {
            BranchDb objBranchDb = new BranchDb();
            DataTable dtBranch = objBranchDb.Search();

            string strOrder = "BranchOrder";

            DataRow[] arrDR = dtBranch.Select("BranchID=" + intBranchID);
            BranchBiz objBranchBiz;
            BranchBiz objTempParent = new BranchBiz();
            foreach (DataRow DR in arrDR)
            {
                objBranchBiz = new BranchBiz(DR);

                SetChildren( ref objBranchBiz, ref dtBranch);
                this.Add(objBranchBiz);
                if (_NodeNo >= 100)
                    break;
                objBranchBiz.ParentBiz = objTempParent;

            }

        }
        BranchCol _NonStoppedBranch;

        public BranchCol NonStoppedBranch
        {
            get {
                if(_NonStoppedBranch == null)
                {
                    bool blTemp;
                   
                    
                    var varBranch = from objBranch in this.Cast<BranchBiz>()
                                            where objBranch.IsStopped == false
                                            select objBranch;
                    _NonStoppedBranch = new BranchCol(true,0);
                   
                    int intCount = varBranch.Count<BranchBiz>();
                    intCount = this.Cast<BranchBiz>().Count<BranchBiz>();
                   // _NonStoppedBranch = varBranch.Cast<BranchBiz>();

                }
                return _NonStoppedBranch; }
            set { _NonStoppedBranch = value; }
        }

        public virtual BranchBiz this[int intIndex]
        {
            get
            {
                return (BranchBiz)this.List[intIndex];
            }
        }
        public virtual BranchBiz this[string strIndex]
        {
            get
            {
                BranchBiz Returned = new BranchBiz();
                foreach (BranchBiz objBranchBiz in this)
                {
                    if (objBranchBiz.Name == strIndex)
                    {
                        Returned = objBranchBiz;
                        break;
                    }
                }
                return Returned;
            }
        }
       
        public BranchBiz RootBiz
        {
            set
            {
                _RootBiz = value;
            }
        }
        public string IDs
        {
            get
            {
                string Returned = "";
                foreach (BranchBiz objBiz in this)
                {
                    if (Returned != "")
                        Returned += ",";
                    Returned += objBiz.ID.ToString();
                }
                return Returned;
            }
        }
        #region  Privaet methods
        void SetChildren(ref BranchBiz objBranchBiz, ref DataTable dtBranchs)
        {
            objBranchBiz.Children = new BranchCol(true,0);
            objBranchBiz.Children.RootBiz = objBranchBiz;
            DataRow[] arrDR = dtBranchs.Select("BranchID <> BranchParentID and BranchParentID=" + objBranchBiz.ID);
            BranchBiz tempBranchBiz;
            BranchCol objBranchCol;
            objBranchCol = new BranchCol(true,0);
            int intTemp = 0;

            foreach (DataRow DR in arrDR)
            {

                tempBranchBiz = new BranchBiz(DR);

                if (intTemp == tempBranchBiz.ID)
                    continue;
                else
                {

                    intTemp = tempBranchBiz.ID;
                  
                }
                if (_NodeNo >= 200)
                    break;
                SetChildren( ref tempBranchBiz, ref dtBranchs);
                tempBranchBiz.ParentBiz = objBranchBiz;
                objBranchCol.Add(tempBranchBiz);


            }
            objBranchBiz.Children = objBranchCol;

        }
        void SetChildrenCol(ref BranchCol objBranchCol, string strBranch, BranchBiz objBranchBiz)
        {
            if (objBranchBiz.Name.IndexOf(strBranch) != -1)
                objBranchCol.Add(objBranchBiz);
            else
            {
                if (objBranchBiz.Children != null)
                {
                    foreach (BranchBiz objBiz in objBranchBiz.Children)
                    {
                        SetChildrenCol(ref objBranchCol, strBranch, objBiz);
                    }
                }
            }
        }
        #endregion
        public virtual void Add(BranchBiz objBranchBiz)
        {

            int intIndex = GetIndex(objBranchBiz);
            if (intIndex == -1)
            {
                _NodeNo++;
                this.List.Add(objBranchBiz);
                _NodeNo = _NodeNo + objBranchBiz.Children._NodeNo;
            }
            else
            {

                this[intIndex].Children.Add(objBranchBiz.Children);
                _NodeNo = _NodeNo + objBranchBiz.Children._NodeNo;
            }
        }
        public virtual void Add(BranchCol objBranchCol)
        {
            foreach (BranchBiz objBranchBiz in objBranchCol)
            {
                this.Add(objBranchBiz);
            }
        }
        public bool Contains(BranchBiz objcellBiz)
        {
            foreach (BranchBiz objTemp in this)
            {
                if (objTemp.ID == objcellBiz.ID)
                    return true;
            }
            return false;
        }
        public int GetIndex(BranchBiz objBranchBiz)
        {

            BranchBiz objBiz;
            for (int intIndex = 0; intIndex < Count; intIndex++)
            {
                objBiz = this[intIndex];
                if (objBiz == objBranchBiz)
                    return intIndex;
                if (objBranchBiz.ID == objBiz.ID)
                {

                    if (objBiz.ID == 0)
                    {
                        if (objBiz.Name == objBranchBiz.Name)
                            return intIndex;


                    }
                    else
                        return intIndex;
                }

            }
            return -1;
        }
        public BranchCol GetCol(string strName)
        {
            BranchCol Returned = new BranchCol(true,0);
            foreach (BranchBiz objBiz in this)
            {
                SetChildrenCol(ref Returned, strName, objBiz);

            }
            return Returned;
        }
        public BranchBiz GetBranchByName(string strName)
        {
            BranchBiz Returned = new BranchBiz();
            foreach (BranchBiz objBiz in this)
            {
                if (objBiz.Name == strName)
                    return objBiz;
            }
            return Returned;
        }
        public BranchCol Copy()
        {
            BranchCol Returned = new BranchCol(true,0);
            foreach (BranchBiz objTemp in this)
            {
                Returned.Add(objTemp.Copy());
            }
            return Returned;
        }


    }
}