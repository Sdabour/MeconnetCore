using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.HR.HRDataBase;
using SharpVision.Base.BaseBusiness;
using SharpVision.Base.BaseDataBase;
using System.Data;
namespace SharpVision.HR.HRBusiness
{
    public class BranchBiz : BaseSelfeRelatedBiz
    {
        #region Private Data
        protected BranchCol _BranchFamily;
       // protected BranchBiz _ParentBiz;
        protected BranchTypeBiz _BranchTypeBiz;
        //int _Level;
        #endregion
        #region Constructors
        public BranchBiz()
        {
            _BaseDb = new BranchDb();
            _BranchTypeBiz = new BranchTypeBiz();
        }
        public BranchBiz(int intBranchID)
        {
            _BaseDb = new BranchDb(intBranchID);
            //_BranchTypeBiz = BranchTypeCol.GetBranchTypeByID(((BranchDb)_BaseDb).TypeID);

        }
        public BranchBiz(DataRow objDR)
        {
            _BaseDb = new BranchDb(objDR);
            //_BranchTypeBiz = BranchTypeCol.GetBranchTypeByID(((BranchDb)_BaseDb).TypeID); ;

        }

        public BranchBiz(BranchDb objBranchDb)
        {
            _BaseDb = objBranchDb;
            try
            {
                //_BranchTypeBiz = BranchTypeCol.GetBranchTypeByID(((BranchDb)_BaseDb).TypeID); ;
            }
            catch
            {
            }

        }
        #endregion
        #region Public Properties

        public string Desc
        {
            set
            {
                ((BranchDb)_BaseDb).Desc = value;
            }
            get
            {
                return ((BranchDb)_BaseDb).Desc;
            }
        }

       // bool _IsStopped;

        public bool IsStopped
        {
            get { return ((BranchDb)_BaseDb). IsStopped; }
            set { ((BranchDb)_BaseDb).IsStopped = value; }
        }
      
        public BranchBiz Ancestor
        {
            get
            {
                BranchCol objBranchCol = new BranchCol(true,2);
                SetAncestor(ref objBranchCol, this);
                for (int i = 0; i < objBranchCol.Count; i++)
                {
                    int intTemp = objBranchCol[i].Children.Count;



                    if (i < objBranchCol.Count - 1)
                    {
                        objBranchCol[i].Children = new BranchCol(true,2);
                        objBranchCol[i].Children.Add(objBranchCol[i + 1]);

                    }
                    //else
                    //    objBranchCol[i].Children = new BranchCol(true);
                }
                BranchBiz Returned = objBranchCol[0];
                return Returned;


            }
        }

        public BranchTypeBiz BranchTypeBiz
        {
            set
            {
                _BranchTypeBiz = value;
                ((BranchDb)_BaseDb).TypeID = _BranchTypeBiz.ID;
            }
            get
            {
                if (_BranchTypeBiz == null)
                    _BranchTypeBiz = new BranchTypeBiz(((BranchDb)_BaseDb).TypeID);
                return _BranchTypeBiz;
            }
        }
        public string FullName
        {
            get
            {
                string strFullName = "";
                strFullName = Name;
                if (_BaseDb.ID != ParentBiz.ID && _ParentBiz.ID != 0)
                    strFullName = ((BranchBiz)ParentBiz).FullName + "(" + strFullName + ")";

                return strFullName;
            }
        }
        public BranchCol BranchFamily
        {
            set
            {
                _BranchFamily = value;
            }
            get
            {
                return _BranchFamily;
            }
        }
        public BranchCol Children
        {
            set
            {
                _Children = value;
            }
            get
            {
                if (_Children == null)
                {

                    _Children = new BranchCol(ID, ((BranchDb)_BaseDb).GetChildrenTable());

                }
                return (BranchCol)_Children;
            }
        }


        public string AncestorIDsStr
        {
            get
            {
                string Returned = "";
                Returned = _BaseDb.ID.ToString();
                if (ID != _ParentBiz.ID)
                {
                    Returned = Returned + "," +((BranchBiz) _ParentBiz).AncestorIDsStr;
                }

                return Returned;
            }
        }

        #endregion
        #region Priuvate Method
        private void SetAncestor(ref BranchCol objCol, BranchBiz objBranchBiz)
        {
            BranchBiz Returned;

            if (objBranchBiz.ParentBiz != null && objBranchBiz.ParentBiz.ID != 0 && ((BranchBiz)objBranchBiz.ParentBiz).FullName != null)
            {
                SetAncestor(ref objCol, ((BranchBiz)objBranchBiz.ParentBiz));
            }

            objCol.Add(objBranchBiz);

        }
        #endregion
        #region Public Methods
        public void Add()
        {
            ((BranchDb)_BaseDb).ParentID = _ParentBiz.ID;
            ((BranchDb)_BaseDb).FamilyID = _ParentBiz.FamilyID;
            ((BranchDb)_BaseDb).TypeID = _BranchTypeBiz.ID;
            _BaseDb.Add();
            
        }



        public void Edit()
        {
            ((BranchDb)_BaseDb).ParentID = _ParentBiz.ID;
            ((BranchDb)_BaseDb).FamilyID = _ParentBiz.FamilyID;
            ((BranchDb)_BaseDb).TypeID = _BranchTypeBiz.ID;
            _BaseDb.Edit();
        }


        public void Delete()
        {
            _BaseDb.Delete();
        }





        public virtual BranchBiz Copy()
            {
            BranchBiz Returned = new BranchBiz();
            try
            {
                Returned.ID = this.ID;
                Returned.NameA = this.Name;
                Returned.Desc = this.Desc;
                Returned.ParentID = this.ParentID;
                Returned.BranchTypeBiz = this.BranchTypeBiz;
                if (_ParentBiz != null && this.ID != _ParentBiz.ID)
                {
                    Returned.ParentBiz = this.ParentBiz;
                }
                else
                {
                    Returned.ParentBiz = Returned;
                }
                Returned.BranchFamily = this.BranchFamily;
                Returned.Children = this.Children;
            }
            catch
            {
            }
            return Returned;
        }
        #endregion
    }
}
