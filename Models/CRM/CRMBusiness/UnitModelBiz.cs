using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.UMS.UMSBusiness;
using SharpVision.CRM.CRMDataBase;
using System.Data;
using SharpVision.Base.BaseBusiness;
using SharpVision.RP.RPBusiness;
using SharpVision.COMMON.COMMONBusiness;
namespace SharpVision.CRM.CRMBusiness
{
    public class UnitModelBiz : BaseSelfeRelatedBiz
    {
        #region Private Data
        CellBiz _CellBiz;
        StrategyCol _StrategyCol;
        ModelComponantCol _ComponantCol;
        UnitModelAttachmentCol _UnitModelAttachmentCol;
        AttachmentMovieBiz _MovieBiz;
        ImageBiz _LogoBiz;
        UnitModelBiz _ParentBiz;
        protected string _MoviePath;
        protected string _LogoPath;
        
        
        #endregion
        #region Constructors
        public UnitModelBiz()
        {
            _BaseDb = new UnitModelDb();
        }
        public UnitModelBiz(int intID)
        {
            _BaseDb = new UnitModelDb(intID);
            if (((UnitModelDb)_BaseDb).ParentID == _BaseDb.ID)
                _ParentBiz = this;
        }
        public UnitModelBiz(DataRow objDR)
        {
            _BaseDb = new UnitModelDb(objDR);
            if (((UnitModelDb)_BaseDb).ParentID == _BaseDb.ID)
                _ParentBiz = this;
           // _UnitBiz = new UnitBiz(objDR);
            //_AttachmentMovieBiz = new AttachmentMovieBiz();
            //_AttachmentImageBiz = new AttachmentImageBiz();
        }
        public UnitModelBiz(UnitModelDb objDb)
        {
            _BaseDb = objDb;
         //   _UnitBiz = new UnitBiz(objDR);
        }
        public UnitModelBiz(string strNameA)
        {
            _BaseDb = new UnitModelDb();
            _BaseDb.NameA = strNameA;
            DataTable dtTemp = _BaseDb.Search();
            if (dtTemp.Rows.Count > 0)
            {
                _BaseDb = new UnitModelDb(dtTemp.Rows[0]);
            }
        }
        #endregion
        #region Public Properties

      
        public double Survey
        {
            set
            {
                ((UnitModelDb)_BaseDb).Survey = value;
            }
            get
            {
                return ((UnitModelDb)_BaseDb).Survey;
            }

        }
        public double UnitPrice
        {
            set
            {
                ((UnitModelDb)_BaseDb).UnitPrice = value;
            }
            get
            {
                return ((UnitModelDb)_BaseDb).UnitPrice;
            }

        }

        public UnitModelBiz ParentBiz
        {
            set
            {
                _ParentBiz = value;
            }
            get
            {
                return _ParentBiz;
            }
        }
        
        public AttachmentMovieBiz MovieBiz
        {
            set
            {
                _MovieBiz = value;
            }
            get
            {
                if (_MovieBiz == null)
                    _MovieBiz = new AttachmentMovieBiz(((UnitModelDb)_BaseDb).Movie);
                return _MovieBiz;
            }
        }

        public ImageBiz LogoBiz
        {
            set
            {
                _LogoBiz = value;
            }
            get
            {
                if (_LogoBiz == null)
                    _LogoBiz = new ImageBiz(((UnitModelDb)_BaseDb).Logo);
                return _LogoBiz;
            }



        }

        public string MoviePath
        {
            set
            {
                _MoviePath = value;
            }
            get
            {
                if (_MoviePath == null || _MoviePath == "")
                {
                    if (_MovieBiz != null && _MovieBiz.ID != 0)
                    {
                        _MoviePath = _MovieBiz.Path;
                    }
                    else
                        _MoviePath = "";

                }

                return _MoviePath;
            }
        }


        public string LogoPath
        {
            set
            {
                _LogoPath = value;
            }
            get
            {
                if (_LogoPath == null || _LogoPath == "")
                {
                    if (_LogoBiz != null && _LogoBiz.ID != 0)
                    {
                        _LogoPath = _LogoBiz.Path;
                    }
                    else
                        _LogoPath = "";

                }

                return _LogoPath;
            }
        }


        public double CachePrice
        {
            set
            {
                if (((UnitModelDb)_BaseDb).UnitPrice == 0)
                    ((UnitModelDb)_BaseDb).CachePrice = value;
                else
                    ((UnitModelDb)_BaseDb).CachePrice = 0;
            }
            get
            {

                return ((UnitModelDb)_BaseDb).UnitPrice == 0 ? ((UnitModelDb)_BaseDb).CachePrice :
                    (((UnitModelDb)_BaseDb).UnitPrice * ((UnitModelDb)_BaseDb).Survey);
                
                
            }

        }
        public FinishingType  Finishing
        {
            set
            {
                ((UnitModelDb)_BaseDb).Finishing = (int)value;
            }
            get
            {
                return (FinishingType)((UnitModelDb)_BaseDb).Finishing;
            }
        }
        public int RoomNo
        {
            set
            {
                ((UnitModelDb)_BaseDb).RoomNo = value;
            }
            get
            {
                return ((UnitModelDb)_BaseDb).RoomNo;
            }
        }
        public bool IsDuplex
        {
            set
            {
                bool blTemp = value;
                ((UnitModelDb)_BaseDb).FloorNo = blTemp ? 2 : 1;
            }
            get
            {
                return ((UnitModelDb)_BaseDb).FloorNo > 1;
            }
        }
        public StrategyCol StrategyCol
        {
            set
            {
                _StrategyCol = value;
            }
            get
            {
                if (_StrategyCol == null)
                {
                    _StrategyCol = new StrategyCol(true);
                    if (ID != 0)
                    {
                        DataTable dtTemp = ((UnitModelDb)_BaseDb).GetStrategy();
                        foreach (DataRow objDr in dtTemp.Rows)
                        {
                            _StrategyCol.Add(new StrategyBiz(objDr));
                        }
                    }
 
                }
                return _StrategyCol;
            }
        }
        public CellBiz cellBiz
        {
            set
            {
                _CellBiz = value;
            }
            get
            {
                if (_CellBiz == null)
                    _CellBiz = new CellBiz(((UnitModelDb)_BaseDb).CellID);
                return _CellBiz;
            }
        
        }
        public ModelComponantCol ComponantCol
        {
            set
            {
                _ComponantCol = value;
            }
            get
            {
                if (_ComponantCol == null)
                {
                    _ComponantCol = new ModelComponantCol(true);
                    if (ID != 0)
                    {
                       
                        ModelComponantDb objDb = new ModelComponantDb();
                        objDb.ModelID = ID;
                        ModelComponantBiz objTempBiz;
                        DataTable dtTemp = objDb.Search();
                        foreach (DataRow objDr in dtTemp.Rows)
                        {
                            objTempBiz = new ModelComponantBiz(objDr);
                            objTempBiz.ModelBiz = this;
                            _ComponantCol.Add(objTempBiz);
                        }
                    }
                }
                return _ComponantCol;
            }

        }
        public UnitModelAttachmentCol UnitModelAttachmentCol
        {
            set
            {
                _UnitModelAttachmentCol = value;
            }
            get
            {
                if (_UnitModelAttachmentCol == null)
                {
                    _UnitModelAttachmentCol = new UnitModelAttachmentCol(true);
                    if (ID != 0)
                    {
                        UnitModelAttachmentDb objDb = new UnitModelAttachmentDb();
                        objDb.UnitModelID = ID;
                        DataTable dtTemp = objDb.Search();
                        UnitModelAttachmentBiz objTempBiz;
                        foreach (DataRow objDr in dtTemp.Rows)
                        {
                            objTempBiz = new UnitModelAttachmentBiz(objDr);
                            objTempBiz.ModelBiz = this;
                            _UnitModelAttachmentCol.Add(objTempBiz);
                        }
                    }
                }
                return _UnitModelAttachmentCol;
            }

        }

      

        //public UnitModelCol Children
        //{
        //    set
        //    {
        //        _Children = value;
        //    }
        //    get
        //    {
        //        return (UnitModelCol)_Children;
        //    }
        //}
        ModelImageCol _ImageCol;
        public ModelImageCol ImageCol { get
            {
                if (_ImageCol== null) _ImageCol = new ModelImageCol();
                return _ImageCol;
            } set => _ImageCol = value; }
        #endregion
        #region Private Methods



        #endregion
        #region Public Methods

        public static void Add(int intModelCellID, double dblModelSurvey, double dblModelUnitPrice, string strNameA,string strNameE,int intFinishing)
        {
            UnitModelDb objUnitModelDb = new UnitModelDb();
            objUnitModelDb.CellID = intModelCellID;
            objUnitModelDb.NameA = strNameA;
            objUnitModelDb.NameE = strNameE;
            objUnitModelDb.UnitPrice = dblModelUnitPrice;
            objUnitModelDb.Survey = dblModelSurvey;
            objUnitModelDb.Finishing = intFinishing;
            objUnitModelDb.Add();
        }
        public static void Edit(int intID, int intModelCellID, double dblModelSurvey, double dblModelUnitPrice, string strNameA, string strNameE, int intFinishing)
        {
            UnitModelDb objUnitModelDb = new UnitModelDb();
            objUnitModelDb.ID = intID;
            objUnitModelDb.CellID = intModelCellID;
            objUnitModelDb.NameA = strNameA;
            objUnitModelDb.NameE = strNameE;
            objUnitModelDb.UnitPrice = dblModelUnitPrice;
            objUnitModelDb.Survey = dblModelSurvey;
            objUnitModelDb.Finishing = intFinishing;
            objUnitModelDb.Edit();
        }
        public static void Delete(int intID)
        {
            UnitModelDb objUnitModelDb = new UnitModelDb();
            objUnitModelDb.ID = intID;
            objUnitModelDb.Delete();
        }
        public void Add()
        {

            ((UnitModelDb)_BaseDb).FamilyID = _ParentBiz.FamilyID;
            ((UnitModelDb)_BaseDb).ParentID = _ParentBiz.ID;

            ((UnitModelDb)_BaseDb).CellID = _CellBiz.ID;
            if (((UnitModelDb)_BaseDb).UnitPrice != 0)
                ((UnitModelDb)_BaseDb).CachePrice = 0;
            ((UnitModelDb)_BaseDb).ComponantTable = ComponantCol.GetTable();
           

            if (_MoviePath != "")
            {
                MovieBiz.FilePath = _MoviePath;
                MovieBiz.Add();
            }

            if (_LogoPath != "")
            {
                _LogoBiz.Path = _LogoPath;
                _LogoBiz.Add();
            }
            ((UnitModelDb)_BaseDb).Movie = MovieBiz.ID;
            ((UnitModelDb)_BaseDb).Logo = LogoBiz.ID;
            ((UnitModelDb)_BaseDb).ImageTable = ImageCol.GetTable();
            _BaseDb.Add();
            if (_StrategyCol == null)
                _StrategyCol = new StrategyCol(true);
            foreach (StrategyBiz objStrategyBiz in _StrategyCol)
            {
                objStrategyBiz.ModelBiz = this;
                objStrategyBiz.Add();
            }
           
        }
        public void Edit()
        {

            ((UnitModelDb)_BaseDb).FamilyID = _ParentBiz.FamilyID;
            ((UnitModelDb)_BaseDb).ParentID = _ParentBiz.ID;

            ((UnitModelDb)_BaseDb).CellID = _CellBiz.ID;
            if (((UnitModelDb)_BaseDb).UnitPrice != 0)
                ((UnitModelDb)_BaseDb).CachePrice = 0;
            ((UnitModelDb)_BaseDb).ComponantTable = ComponantCol.GetTable();
            ((UnitModelDb)_BaseDb).ImageTable = ImageCol.GetTable();

            if (_MoviePath != "")
            {
                _MovieBiz.FilePath = _MoviePath;
                if (_MovieBiz.ID == 0)
                    _MovieBiz.Add();
                else
                    _MovieBiz.Edit();
            }

            if (_LogoPath != "")
            {
                _LogoBiz.Path = _LogoPath;
                if (_LogoBiz.ID == 0)
                    _LogoBiz.Add();
                else
                    _LogoBiz.Edit();
            }
            //((UnitModelDb)_BaseDb).Movie = MovieBiz.ID;
            ((UnitModelDb)_BaseDb).Logo = LogoBiz.ID;
             _BaseDb.Edit();
             foreach (StrategyBiz objStrategyBiz in _StrategyCol)
             {
                 objStrategyBiz.ModelBiz = this;
                 if (objStrategyBiz.ID == 0)
                     objStrategyBiz.Add();
                 else
                     objStrategyBiz.Edit();
             }
         
        }
        #endregion
    }
}
