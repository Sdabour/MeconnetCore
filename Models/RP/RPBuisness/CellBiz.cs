using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.RP.RPDataBase;
using SharpVision.Base.BaseBusiness;
using SharpVision.Base.BaseDataBase;
using System.Data;
using SharpVision.COMMON.COMMONBusiness;
using SharpVision.GL.GLBusiness;
namespace SharpVision.RP.RPBusiness
{
    public enum FloorOrderType
    {
        UnderGround,
        Ground,
        First,
        Second,
        Third,
        Fourth,
        Fifth,
        Sixth,
        Seventh,
        Eightth,
        Nineth,
        Tenth,
        Eleventh,
        Twelfth,
        Thirteenth,
        Fourteenth,
        Fifteenth,
        Sixteenth,
        Seveneenth,
        Eighteenth,
        NineTeenth,
        Twenty

        
    }
    public class CellBiz : BaseSelfeRelatedBiz
    {
        #region Private Data
        protected CellCol _CellFamily;
        protected CellBiz _ParentBiz;
        protected CellTypeBiz _CellTypeBiz;
      
        int _Level;
        ImageBiz _Layout;
        ImageBiz _Logo;

        CostCenterBiz _CostCenterBiz;
        AccountBiz _AccountBiz;
        #endregion
        #region Constructors
        public CellBiz()
        {
           _BaseDb = new CellDb();
            _CellTypeBiz = new CellTypeBiz();
        }
        public CellBiz(int intCellID)
        {
            if (intCellID == 0)
                _BaseDb = new CellDb();
            else
              _BaseDb = new CellDb(intCellID);
            //_CellTypeBiz = CellTypeCol.GetCellTypeByID(((CellDb)_BaseDb).TypeID);
          if (((CellDb)_BaseDb).CostCenterID != 0)
          {
              _CostCenterBiz = new CostCenterBiz();
              _CostCenterBiz.ID = ((CellDb)_BaseDb).CostCenterID;
              _CostCenterBiz.Code = ((CellDb)_BaseDb).CostCenterCode;
              _CostCenterBiz.NameA = ((CellDb)_BaseDb).CostCenterName;
          }
            
        }
        public CellBiz(DataRow objDR)
        {
            _BaseDb = new CellDb(objDR);
            if (((CellDb)_BaseDb).CostCenterID != 0)
            {
                _CostCenterBiz = new CostCenterBiz();
                _CostCenterBiz.ID = ((CellDb)_BaseDb).CostCenterID;
                _CostCenterBiz.Code = ((CellDb)_BaseDb).CostCenterCode;
                _CostCenterBiz.NameA = ((CellDb)_BaseDb).CostCenterName;
            }
          
        }

        public CellBiz(CellDb objCellDb)
        {
            _BaseDb = objCellDb;
            try
            {
                //_CellTypeBiz = CellTypeCol.GetCellTypeByID(((CellDb)_BaseDb).TypeID); ;
            }
        catch
        {
        }
            
        }
        #endregion
        #region Public Properties
        public string AlterName
        {
            set
            {
                ((CellDb)_BaseDb).ALterName = value;
            }
            get
            {
                if (((CellDb)_BaseDb).ALterName == null || ((CellDb)_BaseDb).ALterName == "" ||
                    ((CellDb)_BaseDb).ALterName == "_")
                    return ((CellDb)_BaseDb).Name;
                else
                  return ((CellDb)_BaseDb).ALterName;
            }
        }
        public string FullAlterName
        {
            get
            {
                string strFullName = "";
                if(AlterName != "_")
                  strFullName = "(" + AlterName + ")";
                if (_BaseDb.ID != ParentBiz.ID && _ParentBiz.ID != 0)
                    strFullName = ParentBiz.FullAlterName +  strFullName ;

                return strFullName;
            }
        }
        public string Desc
        {
            set
            {
                ((CellDb)_BaseDb).Desc = value;
            }
            get
            {
                return ((CellDb)_BaseDb).Desc;
            }
        }
        public int Order
        {
            set
            {
                ((CellDb)_BaseDb).Order = value;
            }
            get
            {
                return ((CellDb)_BaseDb).Order;
            }
        }
        public ImageBiz Layout
        {
            set
            {
                _Layout = value;
            }
            get
            {
                if (_Layout == null && ((CellDb)_BaseDb).Layout != 0)
                {
                    _Layout = new ImageBiz(((CellDb)_BaseDb).Layout);
                }
                return _Layout;
            }
        }
        public ImageBiz Logo
        {
            set
            {
                _Logo = value;
            }
            get
            {
                if (_Logo == null )
                {
                    _Logo = new ImageBiz(((CellDb)_BaseDb).Logo);
                }
                return _Logo;
            }
        }
        public int LayoutID
        {
            get
            {
                return ((CellDb)_BaseDb).Layout;
            }
        }
        public virtual CellBiz ParentBiz
        {
            set
            {
                _ParentBiz = value;
            }
            get
            {
                if (_ParentBiz == null)
                {
                    if (((CellDb)_BaseDb).ID == ((CellDb)_BaseDb).ParentID)
                        _ParentBiz = this;
                    else
                        _ParentBiz = new CellBiz(((CellDb)_BaseDb).ParentID);
                }
                return _ParentBiz;

            }
        }
        public CellBiz Ancestor
        {
            get
            {
                CellCol objCellCol = new CellCol(true);
                SetAncestor(ref objCellCol, this);
                for (int i = 0; i < objCellCol.Count; i++)
                {
                    int intTemp = objCellCol[i].Children.Count;



                    if (i < objCellCol.Count - 1)
                    {
                        objCellCol[i].Children = new CellCol(true);
                        objCellCol[i].Children.Add(objCellCol[i + 1]);
                        
                    }
                    //else
                    //    objCellCol[i].Children = new CellCol(true);
                }
                CellBiz Returned = objCellCol[0];
                return Returned;


            }
        }
        public double ParentCostPerc
        {
            set
            {
                ((CellDb)_BaseDb).ParentCostPerc = value;
            }
            get
            {
                return ((CellDb)_BaseDb).ParentCostPerc;
            }
        }
        public DateTime WorkStartDate
        {
            set
            {
                ((CellDb)_BaseDb).WorkStartDate = value;
            }
            get
            {
                return ((CellDb)_BaseDb).WorkStartDate;
            }
        }
        public bool IsEstimatedDeliver
        {
            set
            {
                ((CellDb)_BaseDb).IsEstimatedDeliver = value;
            }
            get
            {
                return ((CellDb)_BaseDb).IsEstimatedDeliver;
            }
        }
        public DateTime EstimatedDeliverDate
        {
            set
            {
                ((CellDb)_BaseDb).EstimatedDeliverDate = value;
            }
            get
            {
                return ((CellDb)_BaseDb).EstimatedDeliverDate;
            }
        }
        public bool IsDelivered
        {
            set
            {
                ((CellDb)_BaseDb).IsDelivered = value;
            }
            get
            {
                return ((CellDb)_BaseDb).IsDelivered;
            }
        }
        public DateTime DeliverDate
        {
            set
            {
                ((CellDb)_BaseDb).DeliverDate = value;
            }
            get
            {
                return ((CellDb)_BaseDb).DeliverDate;
            }
        }
        public double Survey
        {
            set
            {
                ((CellDb)_BaseDb).Survey = value;
            }
            get
            {
                return ((CellDb)_BaseDb).Survey;
            }
        }
        public bool IsVirtual
        {
            set
            {
                ((CellDb)_BaseDb).IsVirtual = value;
            }
            get
            {
                return ((CellDb)_BaseDb).IsVirtual;
            }
        }
        public CellTypeBiz CellTypeBiz
        {
            set
            {
                _CellTypeBiz = value;
                ((CellDb)_BaseDb).TypeID = _CellTypeBiz.ID;
            }
            get
            {
                return CellTypeCol.GetCellTypeByID(((CellDb)_BaseDb).TypeID); ;
            }
        }
        public string FullName
        {
            get
            {
                string strFullName = "";
                strFullName = Name;
                if (_BaseDb.ID != ParentBiz.ID && _ParentBiz.ID != 0)
                    strFullName = ParentBiz.FullName + "(" + strFullName + ")";
            
                return strFullName;
            }
        }
        public CellCol CellFamily
        {
            set
            {
                _CellFamily = value;
            }
            get
            {
                return _CellFamily;
            }
        }
        public CellCol Children
        {
            set
            {
                _Children = value;
            }
            get
            {
                if (_Children == null)
                {
                    if (ID > 0)
                    {
                        ((CellDb)_BaseDb).Level = Level;
                        _Children = new CellCol(ID, ((CellDb)_BaseDb).GetChildrenTable());
                    }
                    else
                        _Children = new CellCol(true);

                }
                return (CellCol)_Children;
            }
        }
        public override string IDsStr
        {
            get
            {
                string strTemp = "";
                if (ID != -1 && ID == CellDb.CachCellID && CellDb.CachTypeID == 0)
                    return CellDb.CachCellIDs;
                else
                {
                    string Returned = ID!= 0&& ID != FamilyID ? ID.ToString() : "";
                    if (ID!= 0&& ID != FamilyID)
                    {
                        foreach (CellBiz objCellBiz in Children)
                        {
                            strTemp = objCellBiz.IDsStr;
                            if (strTemp == "")
                                continue;
                            if (Returned != "")
                                Returned += ",";
                            Returned += strTemp;
                        }
                    }
                    CellDb.CachCellIDs = Returned;
                    CellDb.CachTypeID = 0;
                    CellDb.CachCellID = ID;
                    return Returned;
                }

            }
        }
      
        public string FamilyIDs
        {
            get
            {
                string Returned = "";
                if (ID > 0 && ID == FamilyID)
                {
                    Returned += ID.ToString();
                }
                else if (ID == -1)
                {
                    foreach (CellBiz objBiz in Children)
                    {
                        if (objBiz.ID != 0 && objBiz.ID == objBiz.FamilyID)
                        {
                            if (Returned != "")
                                Returned += ",";
                            Returned += objBiz.ID.ToString();
                        }
 
                    }
                }
                return Returned;
            }
        }

        public CellCol LinearChildren
        {
            get
            {
                CellCol Returned = new CellCol(true);
                CellBiz obJCellBiz = new CellBiz();
                obJCellBiz.NameA = "€Ì— „Õœœ";
                Returned.Add(obJCellBiz);
                DataRow [] arrDr = CellDb.CellTable.Select("CellParentID<>CellID and CellParentID=" + ID);
                foreach (DataRow objDr in arrDr)
                {
                    Returned.Add(new CellBiz(objDr));
                }
                return Returned;
            }
        }
        public CellCol LinearRealChildren
        {
            get
            {
                CellCol Returned = new CellCol(true);
                CellBiz obJCellBiz = new CellBiz();
                obJCellBiz.NameA = "€Ì— „Õœœ";
                Returned.Add(obJCellBiz);
                DataRow[] arrDr = CellDb.CellTable.Select("CellISVirtual = 0 and CellParentID<>CellID and CellParentID=" + ID);
                foreach (DataRow objDr in arrDr)
                {
                    Returned.Add(new CellBiz(objDr));
                }
                return Returned;
            }
        }
        
        public int Level
        {
            set
            {
                _Level = value;
            }
            get
            {
                if (_Level == 0)
                {
                    if (((CellDb)_BaseDb).Level != 0)
                    {
                        _Level = ((CellDb)_BaseDb).Level;
                    }
                    else
                    {
                        _Level = 1;
                        CellBiz objTemp = this;
                        while (objTemp.ID != ((CellDb)objTemp._BaseDb).ParentID)
                        {
                            _Level++;
                            objTemp = objTemp.ParentBiz;
                        }
                    }
                }
                return _Level;
                
            }
        }


       
       
        public CellBiz ProjectBiz
        {
            get
            {
                return new CellBiz(((CellDb)_BaseDb).FamilyID);
            }
        }
    
        public CellCol LayoutAncestor
        {
            get
            {
                CellCol objCellCol = new CellCol(true);
                SetAncestor(ref objCellCol, this);
                string strAncestor = objCellCol.IDsStr;
                objCellCol = new CellCol(true);
                if (strAncestor != "")
                {
                    DataRow[] arrDr = CellDb.CellTable.Select("CellID in(" + strAncestor + ") and CellLayout <>0 ");

                    foreach (DataRow objDr in arrDr)
                    {
                        objCellCol.Add(new CellBiz(objDr));
                    }
                }
                return objCellCol;
            }
        }
        public CellCol LayoutChildren
        {
            get
            {
                CellCol objCellCol = new CellCol(true);

                DataRow[] arrDr = CellDb.CellTable.Select("CellFamilyID =" + ID + " and CellLayout <>0 ");

                foreach (DataRow objDr in arrDr)
                {
                    objCellCol.Add(new CellBiz(objDr));
                }

                return objCellCol;
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
                    Returned = Returned + "," +  _ParentBiz.AncestorIDsStr;
                }

                return Returned;
            }
        }
        public int TowerUnitNo
        {
            get
            {
                return ((CellDb)_BaseDb).TowerUnitNo;
            }
        }
      
        public CostCenterBiz CostCenterBiz
        {
            set
            {
                _CostCenterBiz = value;
            }
            get
            {
                if (_CostCenterBiz == null)
                _CostCenterBiz = new CostCenterBiz();
                return _CostCenterBiz;
            }

        }
        public AccountBiz AccountBiz
        {
            set
            {
                _AccountBiz = value;
            }
            get
            {
                if (_AccountBiz == null)
                    _AccountBiz = new AccountBiz();
                return _AccountBiz;
            }

        }
        public CostCenterBiz CurrentCostCenter
        {
            get
            {
                if (CostCenterBiz.ID != 0)
                    return CostCenterBiz;
                else if (ID != ParentBiz.ID)
                    return ParentBiz.CurrentCostCenter;
                else
                    return new CostCenterBiz();
            }
        }
        public CellCol TowerCol
        {
            get
            {
                CellCol Returned = new CellCol(true);
                if (TowerUnitNo > 0)
                    Returned.Add(this);
                if (Children != null)
                {
                    foreach (CellBiz objBiz in Children)
                    {
                        Returned.Add(objBiz.TowerCol);
                    }
                }
                return Returned;
            }
        }
        public static List<string> FloorOrderTypeArr
        {
            get
            {
                List<string> Returned = new List<string>();
              Returned.Add("»œ—Ê„");
              Returned.Add("√—÷Ï");
              Returned.Add("√Ê·");
              Returned.Add("À«‰Ï");
              Returned.Add("À«·À");
              Returned.Add("—«»⁄");
              Returned.Add("Œ«„”");
              Returned.Add("”«œ”");
              Returned.Add("”«»⁄");
              Returned.Add("À«„‰");
              Returned.Add(" «”⁄");
              Returned.Add("⁄«‘—");
              Returned.Add("Õ«œÏ ⁄‘—");
              Returned.Add("À«‰Ï ⁄‘—");
              Returned.Add("À«·À ⁄‘—");
              Returned.Add("—«»⁄ ⁄‘—");
              Returned.Add("Œ«„” ⁄‘—");
              Returned.Add("”«œ” ⁄‘—");
              Returned.Add("”«»⁄ ⁄‘—");
              Returned.Add("À«„‰ ⁄‘—");
              Returned.Add(" «”⁄ ⁄‘—");
              Returned.Add("⁄‘—Ì‰");
                return Returned;
            }
        }
        
       #endregion
        #region Priuvate Method
        private void SetAncestor(ref CellCol objCol, CellBiz objCellBiz)
        {
            CellBiz Returned;

            if (objCellBiz.ParentBiz != null && objCellBiz.ParentBiz.ID != 0 && objCellBiz.ParentBiz.FullName != null)
            {
                SetAncestor(ref objCol, objCellBiz.ParentBiz);
            }

            objCol.Add(objCellBiz);

        }
        #endregion
        #region Public Methods
        public virtual void Add()
        {
            _BaseDb.Add();
        }

        public static void Add(string strCellName, string strCellAlterName, string strCellDesc, int intParentID, int intFamilyID, int intTypeID, int intOrder, bool blIsVirtual, double dblSurvey, 
            DateTime dtStartDate,bool blIsEstimated, DateTime dtEstimatedDate,bool blIsDelivered, DateTime dtDelivarDate)
        {
            CellDb objCellDb = new CellDb();
            objCellDb.NameA = strCellName;
            objCellDb.ALterName = strCellAlterName;
            objCellDb.Desc = strCellDesc;
            objCellDb.ParentID = intParentID;
            objCellDb.FamilyID = intFamilyID;
            objCellDb.TypeID = intTypeID;
            objCellDb.Order = intOrder;

            objCellDb.IsVirtual = blIsVirtual;
            objCellDb.Survey = dblSurvey;
            objCellDb.StartDate = dtStartDate;
            objCellDb.IsEstimatedDeliver = blIsEstimated;
            objCellDb.EstimatedDeliverDate = dtEstimatedDate;
            objCellDb.IsDelivered = blIsDelivered;
            objCellDb.DeliverDate = dtDelivarDate;
            
            objCellDb.Add();
           
        }
        public static void Edit(int intCellID, string strCellName, string strCellAlterName, string strCellDesc, int intCellParentID, int intFamilyID, int intTypeID, int intOrder, 
            bool blIsVirtual, double dblSurvey, DateTime dtStartDate, bool blIsEstimated, DateTime dtEstimatedDate, bool blIsDelivered,DateTime dtDelivarDate)
        {
            CellDb objCellDb = new CellDb();
            objCellDb.ID = intCellID;
            objCellDb.NameA = strCellName;
            objCellDb.ALterName = strCellAlterName;
            objCellDb.ParentID = intCellParentID;
            objCellDb.FamilyID = intFamilyID;
            objCellDb.Desc = strCellDesc;
            objCellDb.TypeID = intTypeID;
            objCellDb.Order = intOrder;

            objCellDb.IsVirtual = blIsVirtual;
            objCellDb.Survey = dblSurvey;
            objCellDb.StartDate = dtStartDate;
            objCellDb.IsEstimatedDeliver = blIsEstimated;
            objCellDb.EstimatedDeliverDate = dtEstimatedDate;
            objCellDb.IsDelivered = blIsDelivered;
            objCellDb.DeliverDate = dtDelivarDate;
            
            objCellDb.Edit();
        }
        public void EditLayout()
        {
            if (_Layout == null)
                return;
            ((CellDb)_BaseDb).Layout = Layout.ID;
            ((CellDb)_BaseDb).EditLayout();
            DataRow[] arrDr = CellDb.CellTable.Select("CellID=" + ID);
            if (arrDr.Length > 0)
            {
                arrDr[0]["CellLayout"] = Layout.ID;
            }

        }

        public void EditGLAccount(int intGLAccount)
        {
            string strTemp="";
            CellCol objCellCol = GetTypedChildren(7, -1);
            strTemp = objCellCol.IDsStr;
            if (strTemp == "")
                strTemp = "0";

            CellDb.CachCellID = ID;
            CellDb.CachCellIDs = strTemp;
            CellDb.CachTypeID = 0;


            ((CellDb)_BaseDb).IDsStr = strTemp;
            ((CellDb)_BaseDb).GLAccount = intGLAccount;
            ((CellDb)_BaseDb).EditAccount();

        }

        public virtual void Edit()
        {
            _BaseDb.Edit();
        }

        public static void Delete(int intCellID)
        {
            CellDb objCellDb = new CellDb();
            objCellDb.ID = intCellID;
            objCellDb.Delete();
        }

        public virtual void Delete()
        {
            _BaseDb.Delete();
        }

        public CellCol GetTypedChildren(int intType,int intOrder)
        {
            CellCol Returned = new CellCol(true);
            if (ID > 0)
            {

                CellDb objCellDb = new CellDb();
                objCellDb.ID = ID;
                // objCellDb.ParentID = ID;
                objCellDb.OnlyType = true;
                objCellDb.VirtualSearch = 1;
                objCellDb.TypeID = intType;
                //objCellDb.NameLike = "120";
                objCellDb.Order = intOrder > 0 ? intOrder : 0;
                DataTable dtTemp = objCellDb.GetChildrenTable();

                foreach (DataRow objDr in dtTemp.Rows)
                {
                    Returned.Add(new CellBiz(objDr));
                }
                // Returned = new CellCol(ID, objCellDb.GetChildrenTable());
            }
            else
            {
                Returned = GetDirectTypedChildren(intType, intOrder);
            }
            return Returned;
 
        }
        public CellCol GetDirectTypedChildren(int intType, int intOrder)
        {
            CellCol Returned = new CellCol(true);
            
                foreach (CellBiz objBiz in Children)
                {
                    if (objBiz.CellTypeBiz.ID == intType && ( objBiz.Order == intOrder || intOrder <=0 ))
                    {
                        Returned.Add(objBiz);
                    }
                    Returned.Add(objBiz.GetDirectTypedChildren(intType, intOrder));
                }
            
            return Returned;

        }
      
       
        public void EditChildrenCostPecent()
        {
            CellDb objCellDb = new CellDb();
            foreach (CellBiz objBiz in Children)
            {
                objCellDb.ID = objBiz.ID;
                objCellDb.ParentCostPerc = objBiz.ParentCostPerc;
                objCellDb.EditParentCostPerc();

            }
        }
        public virtual CellBiz GetNewCopy()
        {
            CellBiz Returned = new CellBiz();
            try
            {
               // Returned.ID = this.ID;
                Returned.NameA = this.Name;
                Returned.Desc = this.Desc;
              //  Returned.ParentID = this.ParentID;
                Returned.CellTypeBiz = this.CellTypeBiz;
              
            }
            catch
            {
            }
            return Returned;
        }
        public string GetFullAlterName(int intTypeID)
        {
            
                string strFullName = "";
                if (AlterName != "_")
                    strFullName = "(" + AlterName + ")";
                if (_BaseDb.ID != ParentBiz.ID && _ParentBiz.ID != 0  && ((CellDb)_BaseDb).TypeID != intTypeID)
                    strFullName = ParentBiz.GetFullAlterName(intTypeID) + strFullName;

                return strFullName;
            
        }
        public virtual CellBiz Copy()
        {
            CellBiz Returned = new CellBiz();
            try
            {
                Returned.ID = this.ID;
                Returned.NameA = this.Name;
                Returned.AlterName = this.AlterName;
                Returned.Desc = this.Desc;
                Returned.ParentID = this.ParentID;
                Returned.CellTypeBiz = this.CellTypeBiz;
                if (_ParentBiz != null && this.ID != _ParentBiz.ID)
                {
                    Returned.ParentBiz = this.ParentBiz;
                }
                else
                {
                    Returned.ParentBiz = Returned;
                }
                Returned.CellFamily = this.CellFamily;
                Returned.Children = this.Children;
            }
            catch
            { 
            }
            return Returned;
        }
        public  CellCol GetFloorCol(int intNo, bool blHasUnderGround)
        {
            CellCol Returned = new CellCol(true);
            string strName;
            int intOrder = 0 ;
            CellBiz objBiz;
            if (blHasUnderGround)
            {
                objBiz = new CellBiz();
                objBiz.Order = intOrder;
                objBiz.NameA = FloorOrderTypeArr[intOrder];
                objBiz.ParentBiz = this;
                Returned.Add(objBiz);
 
            }
            for (int intIndex = 1; intIndex < intNo; intIndex++)
            {
                objBiz = new CellBiz();
                objBiz.Order = intIndex;
                objBiz.CellTypeBiz = new CellTypeBiz();

                objBiz.NameA = FloorOrderTypeArr[intIndex];
                objBiz.ParentBiz = this;
                Returned.Add(objBiz);
            }
            return Returned;
        }
        public CellCol GetTowerCol(int intNo,int intStart,string strPrefix,char chrSeparator,
            double dblSurvey,bool blIsStartDateLimited,DateTime dtStartDate)
        {
            CellCol Returned = new CellCol(true);
            string strName;
            int intOrder = 0;
            CellBiz objBiz;
           
            for (int intIndex = intStart; intIndex <intStart+ intNo; intIndex++)
            {
                objBiz = new CellBiz();
                objBiz.Order = intOrder;
                strName = strPrefix + chrSeparator.ToString() + intIndex.ToString();
                objBiz.NameA = strName;
                objBiz.Survey = dblSurvey;
                objBiz.CellTypeBiz = new CellTypeBiz();
                objBiz.CellTypeBiz.ID = 2;
                if(blIsStartDateLimited)
                   objBiz.WorkStartDate = dtStartDate;
                objBiz.ParentBiz = this;
                Returned.Add(objBiz);
                intOrder++;
            }
            return Returned;
        }
        public bool CheckCell(CellBiz objCellBiz)
        {
            if (objCellBiz.ID == ID)
                return true;
            foreach (CellBiz objBiz in Children)
                if (objBiz.CheckCell(objCellBiz))
                    return true;
            return false;
        }
        #endregion
    }
}
