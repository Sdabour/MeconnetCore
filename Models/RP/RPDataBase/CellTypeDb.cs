using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using SharpVision.SystemBase;
using SharpVision.Base.BaseDataBase;
namespace SharpVision.RP.RPDataBase
{
    public class CellTypeDb : BaseSelfRelatedDb
    {
        #region Private Data
        
        string _Desc;
            
        string _Ico;
        DataTable _ProcessType;
        DataTable _Characteristic;//
        #endregion
        #region Constructors
        public CellTypeDb()
        {
           
        }

        public CellTypeDb(int intID)
        {
            //DataRow [] arrDR 
            _ID = intID;
            DataTable dtTemp = Search();
            DataRow objDR = dtTemp.Rows[0];
            _NameA = objDR["CellTypeNameA"].ToString();
            _NameE = objDR["CellTypeNameE"].ToString();
            _Desc = objDR["CellTypeDesc"].ToString();
            _ParentID = int.Parse(objDR["CellTypeParentID"].ToString());
            _FamilyID = int.Parse(objDR["CellTypeFamilyID"].ToString());
            _Ico = objDR["CellTypeIco"].ToString();
           

        }
        public CellTypeDb(DataRow objDR)
        {
            //_CellTypeDb = DR;
            _ID = int.Parse(objDR["CellTypeID"].ToString());
            _NameA = objDR["CellTypeNameA"].ToString();
            _NameE = objDR["CellTypeNameE"].ToString();
            _Desc = objDR["CellTypeDesc"].ToString();
            _ParentID = int.Parse(objDR["CellTypeParentID"].ToString());
            _FamilyID = int.Parse(objDR["CellTypeFamilyID"].ToString());
            _Ico = objDR["CellTypeIco"].ToString();
           
           
        }
        public CellTypeDb(int intID, string strName,string strIco)
        {
            _ID = intID;
            _NameA = strName;
            _Ico = strIco;
           
        }
        

        #endregion
        #region Public Properties
        
        
        public string Desc
        {
            set
            {
                _Desc = value;
            }
            get
            {
                return _Desc;
            }
        }
        
        public string Ico
        {
            set
            {
                _Ico = value; ;
            }
            get 
            {
                return _Ico;
            }

        }
     
        public DataTable Characteristic//
        {
            set
            {
                _Characteristic = value;
            }
            get
            {
                return _Characteristic;
            }
        }
        public DataTable ProcessType
        {
            set
            {
                _ProcessType = value;
            }
        }
        #endregion
        #region Private Methods
        #endregion
        #region Public Methods
        public override void Add()
        {
            _FamilyID = _FamilyID == 0 ? _ID : _FamilyID;
            _ParentID = _ParentID == 0 ? _ID : _ParentID;
            string strSql = "insert into RPCellType (CellTypeNameA,CellTypeNameE, CellTypeDesc, CellTypeParentID, CellTypeFamilyID,CelltypeIco, UsrIns, TimIns) values(";
            strSql = strSql + "'" + _NameA + "','" + _NameE + "','" + _Desc + "'," + _ParentID + "," + _FamilyID + ",'" + _Ico + "'," + SysData.CurrentUser.ID + ",Getdate())";
            _ID = SysData.SharpVisionBaseDb.InsertIdentityTable(strSql);
            if (_ParentID == 0)
            {
               
                strSql = "update RPCellType set CellTypeParentID = " + _ID + ", CellTypeFamilyID =" + _ID;
                strSql = strSql + " where CellTypeID = " + _ID;
                SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
            }
           

            

        }
        public override void Edit()
        {
            _FamilyID = _FamilyID == 0 ? _ID : _FamilyID;
            _ParentID = _ParentID == 0 ? _ID : _ParentID;
            string strSql = "update  RPCellType ";
            strSql = strSql + " set CellTypeNameA ='" + _NameA + "'";
            strSql = strSql + " , CellTypeNameE ='" + _NameE + "'";
            strSql = strSql + " ,CellTypeDesc ='" + _Desc + "'";
            strSql = strSql + ",CellTypeParentID =" + _ParentID;
            strSql = strSql + ",CellTypeFamilyID=" + _FamilyID;
            strSql = strSql + ",CellTypeIco ='" + _Ico +"'";
            strSql = strSql + ",TimUpd = GetDate()";
            strSql = strSql + ",UsrUpd =" + SysData.CurrentUser.ID;
            strSql = strSql + " where CellTypeID = " + _ID;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public override void Delete()
        {
            string strSql = "update  RPCellType  set Dis= GetDate() where CellTypeID=" + _ID;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }

        public override DataTable Search()
        {
            string strSql = "SELECT  CellTypeID, CellTypeNameA,CellTypeNameE, CellTypeDesc, CellTypeParentID,"+
                " CellTypeFamilyID,CellTypeIco,CellTypeOrder " +
                            " FROM         dbo.RPCellType "+
                            " WHERE     (Dis IS NULL)";
            if (_ID != 0)
                strSql = strSql + " and CellTypeID = " + _ID.ToString();
            
            if (_ParentID != 0)
                strSql = strSql + "  and CellTypeParentID = " + _ParentID;
            if (_FamilyID != 0)
                strSql = strSql + " and CellTypeFamilyID = " + _FamilyID;
            
           return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
           
        }

        public void JoinCharacteristic()//
        {
            string strSql = "delete from RPCellTypeCharacteristic where CellTypeID = " + _ID;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
            foreach (DataRow objDR in _Characteristic.Rows)
            {
                strSql = "insert into RPCellTypeCharacteristic (CellTypeID,CharacteristicID) Values (" + _ID + "," + objDR["CharacteristicID"].ToString() + ")";
                SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
            }
        }

        public DataTable GetCellCharacteristics()//
        {
            string strSql = "SELECT  dbo.RPCharacteristic.CharacteristicID, dbo.RPCharacteristic.CharacteristicName "+
                            " FROM    dbo.RPCellTypeCharacteristic INNER JOIN "+
                            " dbo.RPCharacteristic ON dbo.RPCellTypeCharacteristic.CharacteristicID = dbo.RPCharacteristic.CharacteristicID "+
                            " where dbo.RPCellTypeCharacteristic.CellTypeID=" + _ID; 
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        public void JoinProcessType()//
        {
            string strSql = "delete from RPCellTypeProcessType where CellTypeID = " + _ID;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
            foreach (DataRow objDR in _ProcessType.Rows)
            {
                strSql = "insert into RPCellTypeProcessType (CellTypeID,ProcessTypeID) Values (" + _ID + "," + objDR["ProcessTypeID"].ToString() + ")";
                SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
            }
        }
        public DataTable GetCellTypeProcessType()
        {
            string strSql = "SELECT dbo.RPProcessType.PROCESSTypeID, dbo.RPProcessType.PROCESSTypeNameA, dbo.RPProcessType.PROCESSTypeNameE, "+
                            " dbo.RPProcessType.MeasurementUnit "+
                            " FROM  dbo.RPCellTypeProcessType INNER JOIN "+
                            " dbo.RPProcessType ON dbo.RPCellTypeProcessType.ProcessTypeID = dbo.RPProcessType.PROCESSTypeID "+
                            " WHERE  dbo.RPCellTypeProcessType.CellTypeID =" + _ID;
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
      
        #endregion
    }
}
