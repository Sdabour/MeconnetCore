using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.HR.HRDataBase;
using SharpVision.Base.BaseBusiness;
using SharpVision.Base.BaseDataBase;
using System.Data;
using System.Linq;
namespace SharpVision.HR.HRBusiness
{
    public class SectorSimple1
    {
        public int ID;
        public string Name;
        public int Level;
        static List<SectorSimple> _SectorLst;
        public static List<SectorSimple> SectorLst { set => _SectorLst = value; 
            get {
                if (_SectorLst == null)
                    _SectorLst = new List<SectorSimple>();
                return _SectorLst;
            } }

    }
    public class SectorBiz : BaseSelfeRelatedBiz
    {
        #region Private Data
        protected SectorCol _SectorFamily;
       // protected SectorBiz _ParentBiz;
        protected SectorTypeBiz _SectorTypeBiz;
        protected ApplicantWorkerBiz _SectorAdminBiz;
        SectorBiz _ParentBiz;
        SectorBiz _FamilyBiz;
        CostCenterHRBiz _DefualtCostCenterBiz;
        CostCenterHRBiz _DefualtMotivationCostCenterBiz;
      //  AttendanceStatementDelayLimitSectorBiz _DelayLimitSectorBiz;
        //int _Level;
        int _IndexInChildern;
        #endregion
        #region Constructors
        public SectorBiz()
        {
            _BaseDb = new SectorDb();
            _SectorTypeBiz = new SectorTypeBiz();
            _DefualtCostCenterBiz = new CostCenterHRBiz();
            _DefualtMotivationCostCenterBiz = new CostCenterHRBiz();
        }
        public SectorBiz(int intSectorID)
        {
            _BaseDb = new SectorDb(intSectorID);
           
            //_DefualtCostCenterBiz = new CostCenterHRBiz(((SectorDb)_BaseDb).DefualtCostCenterID);
            _DefualtCostCenterBiz = CostCenterHRCol.GetCostCenterHRBiz(((SectorDb)_BaseDb).DefualtCostCenterID);

            //_DefualtMotivationCostCenterBiz = new CostCenterHRBiz(((SectorDb)_BaseDb).DefualtMotivationCostCenterID);
            _DefualtMotivationCostCenterBiz = CostCenterHRCol.GetCostCenterHRBiz(((SectorDb)_BaseDb).DefualtMotivationCostCenterID);
             // this = SectorCol.CacheSectorCol[intSectorID.ToString());
        }
        public SectorBiz(DataRow objDR)
        {
            _BaseDb = new SectorDb(objDR);
            if (_BaseDb.ID == 108)
            {
                int x = 0;
            }
            //_SectorTypeBiz = SectorTypeCol.GetSectorTypeByID(((SectorDb)_BaseDb).TypeID); ;
            _SectorTypeBiz = new SectorTypeBiz(objDR);
            _DefualtCostCenterBiz = new CostCenterHRBiz(objDR);
            //_DefualtMotivationCostCenterBiz = new CostCenterHRBiz(((SectorDb)_BaseDb).DefualtMotivationCostCenterID);
            _DefualtMotivationCostCenterBiz = CostCenterHRCol.GetCostCenterHRBiz(((SectorDb)_BaseDb).DefualtMotivationCostCenterID);
            if (((SectorDb)_BaseDb).SectorAdmin != 0)
            {
                _SectorAdminBiz = new ApplicantWorkerBiz();
                _SectorAdminBiz.ID = ((SectorDb)_BaseDb).SectorAdmin;
                _SectorAdminBiz.Name = ((SectorDb)_BaseDb).SectorAdminName;
                _SectorAdminBiz.Code = ((SectorDb)_BaseDb).SectorAdminCode;
            }
            else
                _SectorAdminBiz = new ApplicantWorkerBiz();


        }
        public SectorBiz(DataRow objDR,bool blSetSectorAdmin)
        {
            _BaseDb = new SectorDb(objDR);
            if (_BaseDb.ID == 108)
            {
                int x = 0;
            }
            //_SectorTypeBiz = SectorTypeCol.GetSectorTypeByID(((SectorDb)_BaseDb).TypeID); ;
            _DefualtCostCenterBiz = new CostCenterHRBiz(objDR,false);
           // _DefualtMotivationCostCenterBiz = new CostCenterHRBiz(((SectorDb)_BaseDb).DefualtMotivationCostCenterID);
            _DefualtMotivationCostCenterBiz = CostCenterHRCol.GetCostCenterHRBiz(((SectorDb)_BaseDb).DefualtMotivationCostCenterID);
            if (blSetSectorAdmin)
            {
                if (objDR["SectorAdmin"].ToString() != "")
                {
                    DataRow[] ArrDr = SectorDb.CachSectorAdminTable.Select("ApplicantID=" + objDR["SectorAdmin"]);
                    if (ArrDr.Length != 0)
                        _SectorAdminBiz = new ApplicantWorkerBiz(ArrDr[0]);
                    else
                        _SectorAdminBiz = new ApplicantWorkerBiz();
                    //_PenaltyPersonBiz = new ApplicantWorkerBiz(int.Parse(objDR["PenaltyPerson"].ToString()));
                }
                else
                    _SectorAdminBiz = new ApplicantWorkerBiz();
            }
            else
                _SectorAdminBiz = new ApplicantWorkerBiz();


        }
        public SectorBiz(SectorDb objSectorDb)
        {
            _BaseDb = objSectorDb;
            try
            {
                //_SectorTypeBiz = SectorTypeCol.GetSectorTypeByID(((SectorDb)_BaseDb).TypeID); ;
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
                ((SectorDb)_BaseDb).Desc = value;
            }
            get
            {
                return ((SectorDb)_BaseDb).Desc;
            }
        }
        public bool IsInPayRollSectors
        {
            set
            {
                ((SectorDb)_BaseDb).IsInPayRollSectors = value;
            }
            get
            {
                return ((SectorDb)_BaseDb).IsInPayRollSectors;
            }

        }
        public int SectorOrderVal
        {
            set
            {
                ((SectorDb)_BaseDb).SectorOrderVal = value;
            }
            get
            {
                return ((SectorDb)_BaseDb).SectorOrderVal;
            }

        } 
        public SectorBiz Ancestor
        {
            get
            {
                SectorCol objSectorCol = new SectorCol(true);
                SetAncestor(ref objSectorCol, this);
                for (int i = 0; i < objSectorCol.Count; i++)
                {
                    int intTemp = objSectorCol[i].Children.Count;



                    if (i < objSectorCol.Count - 1)
                    {
                        objSectorCol[i].Children = new SectorCol(true);
                        objSectorCol[i].Children.Add(objSectorCol[i + 1]);

                    }
                    //else
                    //    objSectorCol[i].Children = new SectorCol(true);
                }
                SectorBiz Returned = objSectorCol[0];
                return Returned;


            }
        }
        public SectorTypeBiz SectorTypeBiz
        {
            set
            {
                _SectorTypeBiz = value;
                ((SectorDb)_BaseDb).TypeID = _SectorTypeBiz.ID;
            }
            get
            {
                if (_SectorTypeBiz == null)
                    _SectorTypeBiz = SectorTypeCol.CacheSectorTypeCol[((SectorDb)_BaseDb).TypeID.ToString()];
                return _SectorTypeBiz;
            }
        }
        public string FullName
        {
            get
            {
                string strFullName = "";
                strFullName = Name;
                if (_BaseDb.ID != ParentBiz.ID && _ParentBiz.ID != 0)
                {
                    strFullName = ((SectorBiz)ParentBiz).FullName + "(" + strFullName + ")";

                }

                return strFullName;
            }
        }
        public string ShortName
        {
            get
            {
                string strShortName = FamilyBiz.Name ;
                if (FamilyBiz.Name != Name)
                    strShortName += " - " + Name;              
                return strShortName;
            }
        }
        public SectorCol SectorFamily
        {
            set
            {
                _SectorFamily = value;
            }
            get
            {
                return _SectorFamily;
            }
        }
        public SectorCol Children
        {
            set
            {
                _Children = value;
            }
            get
            {
                if (_Children == null)
                {

                    _Children = new SectorCol(ID, ((SectorDb)_BaseDb).GetChildrenTable());

                }
                return (SectorCol)_Children;
            }
        }
        public  SectorBiz ParentBiz
        {
            set
            {
                _ParentBiz = value;
            }
            get
            {
                if (_ParentBiz == null)
                {
                    if (((SectorDb)_BaseDb).ID == ((SectorDb)_BaseDb).ParentID)
                        _ParentBiz = this;
                    else
                        _ParentBiz = SectorCol.CacheSectorCol[((SectorDb)_BaseDb).ParentID.ToString()];
                }
                return _ParentBiz;

            }
        }
        public SectorBiz DisplaySectorBiz
        {
            get
            {

                SectorCol objCol = new SectorCol(true);
                objCol.Add(Ancestor);
                objCol = objCol.LinearCol;

                List<SectorBiz> objSector = (from objBiz in objCol.Cast<SectorBiz>()
                                             where objBiz.IsSector
                                             select objBiz).ToList();

                SectorBiz Returned = new SectorBiz();
                if (objSector.Count > 0)
                    Returned = objSector[0];
                return Returned;
            }
        }
        public SectorBiz DisplayDepartmentBiz
        {
            get
            {

                SectorCol objCol = new SectorCol(true);
                objCol.Add(Ancestor);
                objCol = objCol.LinearCol;

                List<SectorBiz> objSector = (from objBiz in objCol.Cast<SectorBiz>()
                                             where objBiz.IsDepartment
                                             select objBiz).ToList();

                SectorBiz Returned = new SectorBiz();
                if (objSector.Count > 0)
                    Returned = objSector[0];
                return Returned;
            }
        }
        public SectorBiz FamilyBiz
        {
            set
            {
                _FamilyBiz = value;
            }
            get
            {
                if (IsShowReport == true)
                    return this;
                if (_FamilyBiz == null)
                {
                    _FamilyBiz = GetFirstIsShowInReport(this);
                    //_FamilyBiz = new SectorBiz(((SectorDb)_BaseDb).FamilyID);  
                  
                }
                return _FamilyBiz;

            }
        }
        public string AncestorIDsStr
        {
            get
            {
                string Returned = "";
                Returned = _BaseDb.ID.ToString();
                if (ID != ParentBiz.ID)
                {
                    Returned = Returned + "," + ((SectorBiz)_ParentBiz).AncestorIDsStr;
                }

                return Returned;
            }
        }
        public ApplicantWorkerBiz SectorAdminBiz
        {
            set
            {
                _SectorAdminBiz = value;
            }
            get
            {
                return _SectorAdminBiz;
            }
        }
        public bool DisManual
        {
            set
            {
                ((SectorDb)_BaseDb).DisManual = value;
            }
            get
            {
                return ((SectorDb)_BaseDb).DisManual;
            }

        }
        public bool IsShowReport
        {
            set
            {
                ((SectorDb)_BaseDb).IsShowReport = value;
            }
            get
            {
                return ((SectorDb)_BaseDb).IsShowReport;
            }

        }
        public bool IsSector
        {
            set
            {
                ((SectorDb)_BaseDb).IsSector = value;
            }
            get
            {
                return ((SectorDb)_BaseDb).IsSector;
            }

        }
        public bool IsDepartment
        {
            set
            {
                ((SectorDb)_BaseDb).IsDepartment = value;
            }
            get
            {
                return ((SectorDb)_BaseDb).IsDepartment;
            }

        }
        public CostCenterHRBiz DefualtCostCenterBiz
        {
            set
            {
                _DefualtCostCenterBiz = value;
            }
            get
            {
                if (_DefualtCostCenterBiz == null)
                    _DefualtCostCenterBiz = new CostCenterHRBiz(((SectorDb)_BaseDb).DefualtCostCenterID);
                return _DefualtCostCenterBiz;
            }
        }
        public CostCenterHRBiz DefualtMotivationCostCenterBiz
        {
            set
            {
                _DefualtMotivationCostCenterBiz = value;
            }
            get
            {
                if (_DefualtMotivationCostCenterBiz == null)
                    _DefualtMotivationCostCenterBiz = new CostCenterHRBiz(((SectorDb)_BaseDb).DefualtMotivationCostCenterID);
                return _DefualtMotivationCostCenterBiz;
            }
        }
    
        public int MinOrderVal
        {
            get
            {
                int _MinVal = 0;
                foreach (SectorBiz objBiz in Children)
                {
                    if (_MinVal >= objBiz.SectorOrderVal)
                    {
                        _MinVal = objBiz.SectorOrderVal;
                    }
                }
                return _MinVal;
            }
        }
        public int FirstOrderVal
        {
            get
            {
                int _FirstVal = 0;
                if (Children.Count != 0)
                    _FirstVal = Children[0].SectorOrderVal;
                return _FirstVal;
            }
        }
        public int LastOrderVal
        {
            get
            {
                int _LastVal = 0;
                if (Children.Count != 0)
                    _LastVal = Children[Children.Count -1].SectorOrderVal;
                return _LastVal;
            }
        }
        public int MaxOrderVal
        {
            get
            {
                int _MaxVal = 0;
                foreach (SectorBiz objBiz in Children)
                {
                    if (_MaxVal <= objBiz.SectorOrderVal)
                    {
                        _MaxVal = objBiz.SectorOrderVal;
                    }
                }
                return _MaxVal;
            }
        }
        public int IndexInChildern { set { _IndexInChildern = value; } get { return _IndexInChildern; } }
        
        #endregion
        #region Priuvate Method
        private void SetAncestor(ref SectorCol objCol, SectorBiz objSectorBiz)
        {
            SectorBiz Returned;

            if (objSectorBiz.ParentBiz != null && objSectorBiz.ParentBiz.ID != 0 && ((SectorBiz)objSectorBiz.ParentBiz).FullName != null)
            {
                SetAncestor(ref objCol, (SectorBiz)objSectorBiz.ParentBiz);
            }

            objCol.Add(objSectorBiz);

        }
        private SectorBiz GetAncestor(SectorBiz objSectorBiz,int intType)
        {
            SectorBiz Returned = objSectorBiz;

            if (objSectorBiz.ParentID!= objSectorBiz.ID && objSectorBiz.SectorTypeBiz.ID != intType)
            {
                Returned = GetAncestor( (SectorBiz)objSectorBiz.ParentBiz,intType);
            }
            string strTemp = Returned.Name;
            return Returned;

        }
        private SectorBiz GetSectorAncestor(SectorBiz objSectorBiz)
        {
            SectorBiz Returned = objSectorBiz;

            if (objSectorBiz.ParentID != objSectorBiz.ID && objSectorBiz.IsSector)
            {
                Returned = GetSectorAncestor((SectorBiz)objSectorBiz.ParentBiz);
            }
            string strTemp = Returned.Name;
            return Returned;

        }
        private SectorBiz GetFirstIsShowInReport(SectorBiz objSectorBiz)
        {
            SectorBiz Returned = objSectorBiz;

            //if (objSectorBiz.ParentID != objSectorBiz.ID && objSectorBiz.IsShowReport != true)
            //{
            //    Returned = GetFirstIsShowInReport((SectorBiz)objSectorBiz.ParentBiz);
            //}
            if (objSectorBiz.IsShowReport != true && objSectorBiz.ID !=0)
            {
                Returned = GetFirstIsShowInReport((SectorBiz)objSectorBiz.ParentBiz);
            }
            string strTemp = Returned.Name;
            return Returned;

        }
        private SectorBiz GetDelayLimitValue(SectorBiz objSectorBiz)
        {
            SectorBiz Returned = objSectorBiz;

            //if (objSectorBiz.ParentID != objSectorBiz.ID && objSectorBiz.IsShowReport != true)
            //{
            //    Returned = GetFirstIsShowInReport((SectorBiz)objSectorBiz.ParentBiz);
            //}
           
            return Returned;

        }   
        #endregion 
        #region Public Methods
        public void Add()
        {
            ((SectorDb)_BaseDb).ParentID = _ParentBiz.ID;
            ((SectorDb)_BaseDb).FamilyID = _ParentBiz.FamilyID;
            ((SectorDb)_BaseDb).TypeID = _SectorTypeBiz.ID;
            ((SectorDb)_BaseDb).SectorAdmin = _SectorAdminBiz.ID;
            ((SectorDb)_BaseDb).DefualtCostCenterID = _DefualtCostCenterBiz.ID;
            ((SectorDb)_BaseDb).DefualtMotivationCostCenterID = _DefualtMotivationCostCenterBiz.ID;
            _BaseDb.Add();
        }       
        public void  Edit()
        {
            ((SectorDb)_BaseDb).ParentID = _ParentBiz.ID;
            ((SectorDb)_BaseDb).FamilyID = _ParentBiz.FamilyID;
            ((SectorDb)_BaseDb).TypeID = _SectorTypeBiz.ID;
            ((SectorDb)_BaseDb).SectorAdmin = _SectorAdminBiz.ID;
            ((SectorDb)_BaseDb).DefualtCostCenterID = _DefualtCostCenterBiz.ID;
            ((SectorDb)_BaseDb).DefualtMotivationCostCenterID = _DefualtMotivationCostCenterBiz.ID;
            _BaseDb.Edit();
        }       
        public void Delete()
        {
            _BaseDb.Delete();
        }
        public virtual SectorBiz Copy()
        {
            SectorBiz Returned = new SectorBiz();
            try
            {
                Returned.ID = this.ID;
                Returned.NameA = this.Name;
                Returned.Desc = this.Desc;
                Returned.ParentID = this.ParentID;
                Returned.SectorTypeBiz = this.SectorTypeBiz;
                if (_ParentBiz != null && this.ID != _ParentBiz.ID)
                {
                    Returned.ParentBiz = this.ParentBiz;
                }
                else
                {
                    Returned.ParentBiz = Returned;
                }
                Returned.DefualtCostCenterBiz = this.DefualtCostCenterBiz;
                Returned.DefualtMotivationCostCenterBiz = this.DefualtMotivationCostCenterBiz;
                Returned.SectorFamily = this.SectorFamily;
                Returned.FamilyID = this.FamilyID;
                Returned.FamilyBiz = this.FamilyBiz;
                Returned.IsShowReport = this.IsShowReport;
                Returned.IsInPayRollSectors = this.IsInPayRollSectors;
                Returned.IsSector = IsSector;
                Returned.IsDepartment = IsDepartment;

                Returned.Children = this.Children;
            }
            catch
            {
            }
            return Returned;
        }
        public SectorBiz GetFirstAncestorByTypeID(int intTypeID)
        {
            SectorBiz objBiz = this;
            SectorBiz Returned =  GetAncestor(objBiz, intTypeID);
            string strTemp =  Name ;
            strTemp = Returned.Name;
            return Returned;
        }
       
        public CostCenterHRBiz GetFirstCostCestCenter(SectorBiz objSectorBiz)
        {
            CostCenterHRBiz Returned = objSectorBiz.DefualtCostCenterBiz;
            string str = objSectorBiz.Name;
            //if (objSectorBiz.ParentID != objSectorBiz.ID && objSectorBiz.IsShowReport != true)
            //{
            //    Returned = GetFirstIsShowInReport((SectorBiz)objSectorBiz.ParentBiz);
            //}
            if (Returned == null || Returned.ID == 0)
            {
                Returned = GetFirstCostCestCenter((SectorBiz)objSectorBiz.ParentBiz);
            }
            string strTemp = Returned.Name;
            return Returned;
        }
        public CostCenterHRBiz GetFirstMotivationCostCestCenter(SectorBiz objSectorBiz)
        {
            CostCenterHRBiz Returned = objSectorBiz.DefualtMotivationCostCenterBiz;
            string str = objSectorBiz.Name;
            //if (objSectorBiz.ParentID != objSectorBiz.ID && objSectorBiz.IsShowReport != true)
            //{
            //    Returned = GetFirstIsShowInReport((SectorBiz)objSectorBiz.ParentBiz);
            //}
            if (Returned == null || Returned.ID == 0)
            {
                Returned = GetFirstMotivationCostCestCenter((SectorBiz)objSectorBiz.ParentBiz);
            }
            string strTemp = Returned.Name;
            return Returned;
        }
        public void EditSectorOrderVal()
        {
            SectorDb objDb = new SectorDb();
            objDb.ID = ID;
            objDb.SectorOrderVal = SectorOrderVal;
            objDb.EditSectorOrderVal();
        }
        public void UpdateOrderVal(int intSectorID,int intOrderVal)
        {
            SectorDb objDb = new SectorDb();
            
            objDb.UpdateOrderVal(intSectorID,intOrderVal);
        }
        public void UpdateOrderVal(int intOrderVal)
        {
            SectorDb objDb = new SectorDb();

            objDb.UpdateOrderVal(this.ID, intOrderVal);
        }
        public bool CheckSectorParentBiz(SectorBiz objBiz)
        {

            SectorBiz objMainBiz = this;
            if (objBiz.ID == 917)
            { 
            }
            if (objMainBiz.ID == objBiz.ID)
                return true;
            else if (objMainBiz.ParentBiz.ID != 0 && objMainBiz.ParentBiz.ID != objMainBiz.ID)
                return objMainBiz.ParentBiz.CheckSectorParentBiz(objBiz);
            return false;
        }
        public void EditCostCenter(CostCenterHRBiz objBiz )
        {
            if (objBiz == null || objBiz.ID == 0)
                return;
            SectorDb objSectorDb = new SectorDb();
            objSectorDb.DefualtCostCenterID = objBiz.ID;
            objSectorDb.DefualtMotivationCostCenterID = objBiz.ID;
            objSectorDb.ID = ID;
            objSectorDb.EditSectorDefaultCostCenter();
        }
        #endregion
    }
}
