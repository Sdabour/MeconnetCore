using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.RP.RPDataBase;
using SharpVision.Base.BaseBusiness;
using System.Data;
namespace SharpVision.RP.RPBusiness
{
    public class CellTypeBiz : BaseSelfeRelatedBiz
    {
        #region Private Data
      
        
       
      
        #endregion
        #region Constructors
        public CellTypeBiz()
        {
            _BaseDb = new CellTypeDb();
        }
        public CellTypeBiz(int intCellTypeID)
        {
            _BaseDb = new CellTypeDb(intCellTypeID);
        }
        public CellTypeBiz(DataRow objDR)
        {
            _BaseDb = new CellTypeDb(objDR);
        }
      
       public CellTypeBiz(CellTypeDb objCellTypeDb)
       {
           _BaseDb = objCellTypeDb;
       }
        #endregion
        #region Public Properties
        public string Desc
        {
            set
            {
                ((CellTypeDb)_BaseDb).Desc = value;
            }
            get
            {
                return ((CellTypeDb)_BaseDb).Desc;
            }
        }
        
        
    
       public virtual  CellTypeBiz ParentBiz
       {
           set
           {
               _ParentBiz = value;
           }
           get
           {
               if (_ParentBiz == null)
               {
                   if (_BaseDb.ID == ((CellTypeDb)_BaseDb).ParentID)
                       _ParentBiz =  this;
                   else
                       _ParentBiz = new CellTypeBiz(((CellTypeDb)_BaseDb).ParentID);
               }
               return (CellTypeBiz)_ParentBiz;

           }
       }
        public string Ico
        {
            set
            {
                ((CellTypeDb)_BaseDb).Ico = value;
            }
            get
            {
                return ((CellTypeDb)_BaseDb).Ico;
            }
        }
       
       public CellTypeCol Children
       {
           set
           {
               _Children = value;
           }
           get
           {
               return (CellTypeCol)_Children;
           }
       }
     
      
        #endregion
        #region Public Methods
        public static void Add(string strCellTypeNameA, string strCellTypeNameE, string strCellTypeDesc, int intParentID, int intFamilyID, string strIco)
        {
            CellTypeDb objCellTypeDb = new CellTypeDb();
            objCellTypeDb.NameA = strCellTypeNameA;
            objCellTypeDb.NameE = strCellTypeNameE;
            objCellTypeDb.Desc = strCellTypeDesc;
            objCellTypeDb.ParentID = intParentID;
            objCellTypeDb.FamilyID = intFamilyID;
            objCellTypeDb.Ico = strIco;
            objCellTypeDb.Add();
          
            //JoinProcessType(objCellTypeDb.ID, objProcessTypeCol);
            CellTypeCol.UpdateCellTypeCol();

        }
        public static void Edit(int intCellTypeID, string strCellTypeNameA, string strCellTypeNameE, string strCellTypeDesc, int intCellTypeParentID, int intFamilyID, string strIco)
        {
            CellTypeDb objCellTypeDb = new CellTypeDb();
            objCellTypeDb.ID = intCellTypeID;
            objCellTypeDb.NameA = strCellTypeNameA;
            objCellTypeDb.NameE = strCellTypeNameE;
            objCellTypeDb.ParentID = intCellTypeParentID;
            objCellTypeDb.FamilyID = intFamilyID;
            objCellTypeDb.Desc = strCellTypeDesc;
            objCellTypeDb.Ico = strIco;
           
            objCellTypeDb.Edit();
          //  JoinCharcteristic(objCellTypeDb.ID, objCharcterCol);
           
            CellTypeCol.UpdateCellTypeCol();
        }
        public static void Delete(int intCellTypeID)
        {
            CellTypeDb objCellTypeDb = new CellTypeDb();
            objCellTypeDb.ID = intCellTypeID;
            objCellTypeDb.Delete();
            CellTypeCol.UpdateCellTypeCol();
        }
        
      
        public virtual CellTypeBiz Copy()
        {
            CellTypeBiz Returned = new CellTypeBiz();
            Returned.ID = this.ID;
            Returned.NameA = this.NameA;
            Returned.NameE = this.NameE;
            Returned.Desc = this.Desc;
            Returned.Ico = this.Ico;
            Returned.ParentID = this.ParentID;
            Returned.ParentBiz = this.ParentBiz;
            Returned.Children = this.Children;
            return Returned;
        }
        #endregion
        
    }
}
