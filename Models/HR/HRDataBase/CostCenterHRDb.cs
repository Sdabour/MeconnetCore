using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.SystemBase;
using SharpVision.GL.GLDataBase;
namespace SharpVision.HR.HRDataBase
{
    public class CostCenterHRDb : CostCenterDb
    {
        #region Private Data        
        protected int _CostCenterType;
        protected double _MotivationAddValue;
        protected int _ParentID;
        protected bool _GlobalStatus;
        protected bool _MotivationStatus;
        protected byte _GlobalStatusSearch;
        protected byte _MotivationStatusSearch;
        string _CostCenterIDs;
        string _CostCenterTypeIDs;
        #endregion
        #region Constructors
        public CostCenterHRDb()
        {
        }
        public CostCenterHRDb(DataRow objDr)
            :base(objDr)
        {
            
            SetData(objDr);
        }
        public CostCenterHRDb(int intID)
            : base(intID)
        {
            if (intID == 0)
                return;
            _ID = intID;
            DataTable dtTemp = Search();
            if (dtTemp.Rows.Count == 0)
                return;
            DataRow objDR = dtTemp.Rows[0];          
            SetData(objDR);            
        }
        #endregion
        #region Public Properties        
        public int CostCenterType
        {
            set
            {
                _CostCenterType = value;
            }
            get
            {
                return _CostCenterType;
            }
        }
        public double MotivationAddValue
        {
            set
            {
                _MotivationAddValue = value;
            }
            get
            {
                return _MotivationAddValue;
            }
        }
        public int ParentID
        {
            set
            {
                _ParentID = value;
            }
            get
            {
                return _ParentID;
            }
        }
        public bool GlobalStatus
        {
            set
            {
                _GlobalStatus = value;
            }
            get
            {
                return _GlobalStatus;
            }
        }
        public bool MotivationStatus
        {
            set
            {
                _MotivationStatus = value;
            }
            get
            {
                return _MotivationStatus;
            }
        }
        public byte GlobalStatusSearch
        {
            set
            {
                _GlobalStatusSearch = value;
            }            
        }
        public byte MotivationStatusSearch
        {
            set
            {
                _MotivationStatusSearch = value;
            }            
        }
        public string CostCenterIDs
        {
            set
            {
                _CostCenterIDs = value;
            }
        }
        public string CostCenterTypeIDs
        {
            set
            {
                _CostCenterTypeIDs = value;
            }
        }
        public string AddStr
        {
            get
            {
               // string strReturned = " INSERT INTO HRCostCenter(CostCenter, CostCenterType,MotivationAddValue)" +
               //                      " VALUES     (" + _ID + "," + _CostCenterType + "," + _MotivationAddValue + ")";
               // return strReturned;
                string strReturned = " UPDATE HRCostCenter SET  CostCenterType = " + _CostCenterType + ",MotivationAddValue = " + _MotivationAddValue + "" +
                                    " WHERE     (CostCenter = " + _ID + ")";
                return strReturned;
            }
        }
        public string EditStr
        {
            get
            {
                string strReturned = " UPDATE    HRCostCenter "+
                                     " SET              MotivationAddValue =" + _MotivationAddValue + " " +
                                     " WHERE     (CostCenter = "+ _ID +")";
                return strReturned;
            }
        }
        public string DeleteStr
        {
            get
            {
                string strReturned = " Delete From HRCostCenter Where CostCenter = "+ _ID +" and CostCenterType = "+ _CostCenterType +"";
                return strReturned;
            }
        }
        public static string SearchStr
        {
            get
            {
                string strHrCostCenter = "SELECT     HRCostCenter.CostCenter as CostCenterIDValue, HRCostCenter.CostCenterType,HRCostCenter.MotivationAddValue,HRCostCenter.ParentID FROM HRCostCenter";
                string strReturned = " SELECT     GLCostCenter.CostCenterID, GLCostCenter.CostCenterNameA, GLCostCenter.CostCenterNameE,GLCostCenter.OrderVal,HRCostCenterTable.*,CostCenterTypeTable.*  " +
                    " FROM  GLCostCenter " +
                      " inner  Join ("+strHrCostCenter+") as HRCostCenterTable On HRCostCenterTable.CostCenterIDValue = GLCostCenter.CostCenterID " +
                                     " Left Outer Join (" + CostCenterTypeDb.SearchStr + ") as CostCenterTypeTable On CostCenterTypeTable.CostCenterTypeID = HRCostCenterTable.CostCenterType ";
                return strReturned;

                
                //return strReturned;
            }
        }
        #endregion
        #region Private Methods
        void SetData(DataRow objDr)
        {
            if (objDr["CostCenterType"].ToString() != "")
                _CostCenterType = int.Parse(objDr["CostCenterType"].ToString());
            if (objDr["MotivationAddValue"].ToString() != "")
                _MotivationAddValue = double.Parse(objDr["MotivationAddValue"].ToString());
            if (objDr["ParentID"].ToString() != "")
                _ParentID = int.Parse(objDr["ParentID"].ToString());
        }
        #endregion
        #region Public Methods
        public override void Add()
        {
            //base.Add();
            SysData.SharpVisionBaseDb.ExecuteNonQuery(AddStr); 
        }        
        public void Delete()
        {
            SysData.SharpVisionBaseDb.ExecuteNonQuery(DeleteStr);
            string strSql = " Delete From GLCostCenter Where CostCenter = " + _ID + "";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public  DataTable Search()
        {
            string strSql = SearchStr + " Where 1=1 and (GLCostCenter.CostCenterCode is null)";
            if (_CostCenterType != 0)
            {
                strSql += " And CostCenterType =" + _CostCenterType + "";
            }
            if (_CostCenterTypeIDs != null && _CostCenterTypeIDs!="")
            {
                strSql += " And CostCenterType in (" + _CostCenterTypeIDs + ")";
            }
            if (_ID != 0)
            {
                strSql += " And CostCenterIDValue =" + _ID + "";
            }
            if (_CostCenterIDs != null && _CostCenterIDs!="")
            {
                strSql += " And CostCenterIDValue in (" + _CostCenterIDs + ")";
            }
            if (_GlobalStatusSearch != 0)
            {
                if(_GlobalStatusSearch==1)
                    strSql += " And GlobalStatus =1";
                else
                    strSql += " And GlobalStatus =0";
            }
            if (_MotivationStatusSearch != 0)
            {
                if (_MotivationStatusSearch == 1)
                    strSql += " And MotivationStatus =1";
                else
                    strSql += " And MotivationStatus =0";
            }
            strSql += " Order by GLCostCenter.OrderVal";
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }

        public DataTable GetCostCenter()
        {
            string strSql = CostCenterTypeDb.SearchStr;
            
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        public void EditCostCenterType()
        {
            string strsql = "UPDATE    HRCostCenter SET   CostCenterType = "+ _CostCenterType +" WHERE (CostCenter = "+ _ID +")";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strsql);
        }
        public void EditMotivationAddValue()
        {
            string strsql = "UPDATE    HRCostCenter SET   MotivationAddValue = " + _MotivationAddValue + " WHERE (CostCenter = " + _ID + ")";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strsql);
        }
        #endregion
    }
}
