using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.GL.GLDataBase;
using SharpVision.Base.BaseBusiness;
using SharpVision.Base.BaseDataBase;
using SharpVision.UMS.UMSBusiness;
using SharpVision.COMMON.COMMONBusiness;
using System.Data;
using SharpVision.SystemBase;
namespace SharpVision.GL.GLBusiness
{
     

    public class CostCenterBiz : BaseSelfeRelatedBiz
    {
        #region Private Data
        TransactionElementCol _ElementCol;
        double _DebitBalance;
        double _CreditBalance;
        #endregion

        #region Constractors
        public CostCenterBiz()
        {
            _BaseDb = new CostCenterDb();
        }
        public CostCenterBiz(int intID)
        {
            if (intID == 0)
                _BaseDb = new CostCenterDb();
            else
            {
                CostCenterDb objTemp = new CostCenterDb();
                objTemp.ID = intID;
                DataTable dtTemp = objTemp.Search();
                if (dtTemp.Rows.Count > 0)
                    _BaseDb = new CostCenterDb(dtTemp.Rows[0]);
                else
                    _BaseDb = new CostCenterDb();
            }
        }
        public CostCenterBiz(DataRow objDR)
        {
            _BaseDb = new CostCenterDb(objDR);
       
        }

        
        #endregion

        #region Public Accessorice
        public CostCenterCol Children
        {
            set
            {
                _Children = value;
            }
            get
            {
                if (_Children == null)
                {

                    _Children = new CostCenterCol(true);

                }
                return (CostCenterCol)_Children;
            }
        }
        public CostCenterBiz ParentBiz
        {
            set
            {
                _ParentBiz = value;
            }
            get
            {
                return (CostCenterBiz)_ParentBiz;
            }
        }
        public string Code
        {
            set
            {
                ((CostCenterDb)_BaseDb).Code = value;
            }
            get
            {
                return ((CostCenterDb)_BaseDb).Code;
            }
        }
        public int Level
        {
            set
            {
                ((CostCenterDb)_BaseDb).Level = value;
            }
            get
            {
                return ((CostCenterDb)_BaseDb).Level;
            }
        }

        public int OrderVal
        {
            set
            {
                ((CostCenterDb)_BaseDb).OrderVal = value;
            }
            get
            {
                return ((CostCenterDb)_BaseDb).OrderVal;
            }
        }
        public TransactionElementCol ElementCol
        {
            set
            {
                _ElementCol = value;
            }
            get
            {
                if (_ElementCol == null)
                    _ElementCol = new TransactionElementCol(true);
                return _ElementCol;
            }

        }
        public double DebitBalance
        {
            set
            {
                _DebitBalance = value;
            }
            get
            {
                return _DebitBalance;
            }
        }
        public double CreditBalance
        {
            set
            {
                _CreditBalance = value;
            }
            get
            {
                return _CreditBalance;
            }
        }
       
      
        #region Code Data
        public string CodeL1
        {
            get
            {
                string Returned = "";
                Returned = SysData.GetCostCenterLevelCod(1, Code);
                return Returned;
            }
        }
        public string CodeL2
        {
            get
            {
                string Returned = "";
                Returned = SysData.GetCostCenterLevelCod(2, Code);
                return Returned;
            }
        }
        public string CodeL3
        {
            get
            {
                string Returned = "";
                Returned = SysData.GetCostCenterLevelCod(3, Code);
                return Returned;
            }
        }
     
        public int CostCenterLevel
        {
            get
            {
                int Returned = 0;
                int intTemp = 0;
                try
                {
                    intTemp = int.Parse(CodeL2);
                    if (intTemp == 0)
                        return 1;
                }
                catch { }
                try
                {
                    intTemp = int.Parse(CodeL3);
                    if (intTemp == 0)
                        return 2;
                }
                catch { }
               
                Returned = 3;
                return Returned;
            }
        }
        #endregion
        #endregion

        #region Private Methods

        #endregion

        #region Public Methods
        public void Add()
        {
            ((CostCenterDb)_BaseDb).ParentID = _ParentBiz.ID;
            ((CostCenterDb)_BaseDb).FamilyID = _ParentBiz.FamilyID;
            
            ((CostCenterDb)_BaseDb).Add();
        }
        public void Edit()
        {
            ((CostCenterDb)_BaseDb).ParentID = _ParentBiz.ID;
            ((CostCenterDb)_BaseDb).FamilyID = _ParentBiz.FamilyID;
             
            ((CostCenterDb)_BaseDb).Edit();
        }
        public void Delete()
        {
            ((CostCenterDb)_BaseDb).Delete();
        }
        public bool CompareCodeString(string strName)
        {
           
            string strReverseName = strName;
            string[] arrStr = strReverseName.Split('-');
            bool blIsOk = true;
            if (arrStr.Length <= 1)
            {
                arrStr = strName.Split('%');


                blIsOk = true;
                foreach (string strTemp in arrStr)
                {
                    if (SysUtility.ReplaceStringComp(Name).IndexOf(
                        SysUtility.ReplaceStringComp(strTemp), StringComparison.OrdinalIgnoreCase) == -1 &&
                        SysUtility.ReplaceStringComp(Code).IndexOf(
                        SysUtility.ReplaceStringComp(strTemp), StringComparison.OrdinalIgnoreCase) == -1)
                    {
                        blIsOk = false;
                        break;

                    }
                }
                if (blIsOk)
                    return true;


            }
            else
            {
                int intL1 = 0;
                int intL2 = 0;
                int intL3 = 0;
                int intL4 = 0;

                if (arrStr.Length >= 1)
                {
                    try
                    {
                        intL1 = int.Parse(arrStr[0]);
                    }
                    catch { }
                }
                if (arrStr.Length >= 2)
                {
                    try
                    {
                        intL2 = int.Parse(arrStr[1]);
                    }
                    catch { }
                }
                if (arrStr.Length >= 3)
                {
                    try
                    {
                        intL3 = int.Parse(arrStr[2]);
                    }
                    catch { }
                }
                if (arrStr.Length >= 4)
                {
                    try
                    {
                        intL4 = int.Parse(arrStr[3]);
                    }
                    catch { }
                }
                int intLevel = 0;
                if (intL4 == 0 && intL3 == 0 && intL2 == 0)
                    intLevel = 1;
                else if (intL4 == 0 && intL3 == 0)
                    intLevel = 2;
                else if (intL4 == 0)
                    intLevel = 3;
                else
                    intLevel = 4;
                try
                {
                    if (((intL1 == 0 || intL1 == int.Parse(CodeL1)) )
                      && (intL2 == 0 || intL2 == int.Parse(CodeL2)) &&
                      ((intL3 == 0 || intL3 == int.Parse(CodeL3)))
                     )
                    {
                       // if (intLevel == Level)
                            return true;
                        //SetChildrenCol(ref objAccountCol, strAccount, objbiz);
                    }

                }
                catch { }
            }
                
            return false;
        }
        #endregion
    }
}