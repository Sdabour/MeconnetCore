using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.SystemBase;
using System.Data;
using System.Data.SqlClient;
using SharpVision.Base.BaseDataBase;

namespace SharpVision.RP.RPDataBase
{
    public class ProcessTypeDb : BaseSelfRelatedDb
    {
        #region Private Data
        int _MeasurementUnit;
        DataTable _CategoryTable;
        string _ProcesstypeIDs;
        int _ContractElementType;
        string _FamilyName;
        int _AccountID;
        string _AccountCode;
        string _AccountName;
        DataTable _ProcessTypeTable;
        #endregion
        #region Constructors
        public ProcessTypeDb()
        {

        }

        public ProcessTypeDb(int intID)
        {
            _ID = intID;
            DataTable dtTemp = Search();
            DataRow objDR = dtTemp.Rows[0];
            SetData(objDR);
        }
        public ProcessTypeDb(DataRow objDR)
        {
            try
            {
                SetData(objDR);
            }
            catch
            { 
            }
           
        }
        public ProcessTypeDb(int intID, string strName)
        {
            _ID = intID;
            if (SysData.Language == 0)
            {
                _NameA = strName;
                
            }
            else
            {
                _NameA = strName;
               

            }
        }
        public DataTable ProcessTypeTable
        {
            set
            {
                _ProcessTypeTable = value;
            }
        }
        #endregion
        #region Public Properties
        public int MeasurementUnit
        {
            set
            {
                _MeasurementUnit = value;
            }
            get
            {
                return _MeasurementUnit;
            }
        }
        public int ContractElementType
        {
            set
            {
                _ContractElementType = value;
            }
            get
            {
                return _ContractElementType;
            }
        }
        public string FamilyName
        {
            set
            {
                _FamilyName = value;
            }
            get
            {
                return _FamilyName;
            }
        }
        public DataTable CategoryTable
        {
            set
            {
                _CategoryTable = value;
            }
        }
        public string ProcesstypeIDs
        {
            set
            {
                _ProcesstypeIDs = value;
            }
        }
        public int AccountID
        {
            get
            {
                return _AccountID;
            }
        }
        public string AccountCode
        {
            get
            {
                return _AccountCode;
            }
        }
        public string AccountName
        {
            get
            {
                return _AccountName;
            }
        }
        public static string SearchStr
        {
            get
            {
                string strAccount = "SELECT AccountID AS ProcessTypeAccountID, AccountCode AS ProcessTypeAccountCode, AccountNameA AS ProcessTypeAccountName "+
                                    " FROM         dbo.GLAccount ";
                string strProcessFamily = "SELECT  PROCESSTypeID AS ProcessTypeFamily, PROCESSTypeNameA AS ProcessTypeFamilyName "+
                       " FROM dbo.RPProcessType ";
                string Returned = "SELECT RPProcessType.ProcessTypeID, RPProcessType.ProcessTypeNameA"+
                    ",RPProcessType.ProcessTypeNameE"+
                    ",case when "+SysData.Language + "=0 then RPProcessType.ProcessTypeNameA else RPProcessType.ProcessTypeNameE end as ProcessTypeName "+
                    ",PROCESSTYPEParentID,PROCESSTYPEFamilyID" +
                    ",MeasurementUnit,ContractElementtable.*,FamilyTable.*,AccountTable.*  " +
                    " from RPProcessType left outer join (" + new ContractElementTypeDb().SearchStr + ") as ContractElementTable  " +
                        " on RPProcessType.ContractElementType = ContractElementTable.ContractElementTypeID "+
                        " inner join ("+ strProcessFamily +") as FamilyTable "+
                        " on RPProcessType.ProcessTypeID = FamilyTable.ProcessTypeFamily "+
                        " left outer join (" + strAccount + ") as AccountTable "+
                        " on RPProcessType.ProcessTypeGLAccount  = AccountTable.ProcessTypeAccountID ";
                return Returned;
            }
        }

        
        #endregion
        #region Private Methods
        void SetOldRelatedCosts(string strParentID, DataTable dtTemp, ref string strIDs)
        {
            DataRow[] arrDR = dtTemp.Select("PROCESSTYPEParentID = " + strParentID);
            string strTempParent;
            foreach (DataRow objDR in arrDR)
            {
                if (strIDs != "")
                    strIDs = strIDs + ",";
                strTempParent = objDR["PROCESSTYPEID"].ToString();
                strIDs = strIDs + objDR["PROCESSTYPEID"].ToString();
                SetOldRelatedCosts(strTempParent, dtTemp, ref strIDs);
            }
        }
        void SetData(DataRow objDR)
        {
            try
            {
                _ID = int.Parse(objDR["ProcessTypeID"].ToString());
                _NameA = objDR["ProcessTypeNameA"].ToString();
                _NameE = objDR["ProcessTypeNameE"].ToString();
                _ParentID = int.Parse(objDR["PROCESSTYPEParentID"].ToString());
                _FamilyID = int.Parse(objDR["PROCESSTYPEFamilyID"].ToString());
                _MeasurementUnit = int.Parse(objDR["MeasurementUnit"].ToString());
                _FamilyName = objDR["ProcessTypeFamilyName"].ToString();
                if (objDR.Table.Columns["ContractElementTypeID"] != null && objDR["ContractElementTypeID"].ToString() != "")
                    _ContractElementType = int.Parse(objDR["ContractElementTypeID"].ToString());
                if (objDR.Table.Columns["ProcessTypeAccountID"] != null && objDR["ProcessTypeAccountID"].ToString() != "")
                    _AccountID = int.Parse(objDR["ProcessTypeAccountID"].ToString());
                if (objDR.Table.Columns["ProcessTypeAccountCode"] != null)
                    _AccountCode = objDR["ProcessTypeAccountCode"].ToString();
                if (objDR.Table.Columns["ProcessTypeAccountName"] != null)
                    _AccountName = objDR["ProcessTypeAccountName"].ToString();
            }
            catch
            {
            }

        }
        #endregion
        #region Public Methods
        public override void Add()
        {
            string strSql = "insert into RPProcessType (ProcessTypeNameA,ProcessTypeNameE,MeasurementUnit,ContractElementType"+
                ",PROCESSTypeParentID,PROCESSTypeFamilyID,UsrIns,TimIns) " +
            "values('" + _NameA + "','" + _NameE + "'," + _MeasurementUnit + "," +  _ContractElementType+ "," + _ParentID + "," + 
            _FamilyID  + "," + SysData.CurrentUser.ID + ",Getdate())";
            if (_ParentID == 0)
            {
                _ID = SysData.SharpVisionBaseDb.InsertIdentityTable(strSql);
                strSql = "update RPPROCESSTYPE set PROCESSTYPEParentID = " + _ID + ", PROCESSTYPEFamilyID =" + _ID;
                strSql = strSql + " where PROCESSTYPEID = " + _ID;
                SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
            }
            else
                _ID = SysData.SharpVisionBaseDb.InsertIdentityTable(strSql);
        }
        public override void Edit()
        {
            string strSql = "update  RPProcessType ";
            strSql = strSql + " set ProcessTypeNameA ='" + _NameA + "'";
            strSql = strSql + " ,ProcessTypeNameE ='" + _NameE + "'";
            strSql = strSql + ",MeasurementUnit= " + _MeasurementUnit;
            strSql = strSql + ",ContractElementType= " + _ContractElementType;
            strSql += ",PROCESSTYPEParentID="+_ParentID;
            strSql += ",PROCESSTYPEFamilyID="+ _FamilyID;
            strSql = strSql + ",UsrUpd = " + SysData.CurrentUser.ID;
            strSql = strSql + ",TimUpd =Getdate() ";
            strSql = strSql + " where ProcessTypeID = " + _ID;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
            strSql = "select * from RPPROCESSTYPE where PROCESSTYPEFamilyID in " +
           " (select PROCESSTYPEFamilyID from RPPROCESSTYPE where PROCESSTYPEParentID=" + _ID + " and PROCESSTYPEID <> " + _ID + " and PROCESSTYPEFamilyID <> " + _FamilyID + ")";
            DataTable dtTemp = SysData.SharpVisionBaseDb.ReturnDatatable(strSql);

            if (dtTemp.Rows.Count == 0)
                return;
            string strIDs = "";
            SetOldRelatedCosts(_ID.ToString(), dtTemp, ref strIDs);
            strSql = "Update RPPROCESSTYPE set PROCESSTYPEFamilyID = " + _FamilyID + " where PROCESSTYPEID in ( " + strIDs + ")";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public override void Delete()
        {
            string strSql = "update RPProcessType set Dis = GetDate() where ProcessTypeID=" + _ID;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);

        }

        public override DataTable Search()
        {
            string strSql = SearchStr + " WHERE    (1=1)";//(RPProcessType.Dis IS NULL)";
            if (_ID != 0)
                strSql = strSql + " and ProcessTypeID = " + _ID.ToString();


            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        public DataTable GetCategory()
        {
            ProcessTypeCategoryDb objDb = new ProcessTypeCategoryDb();
            
            objDb.ProcessTypeID = _ID;
            objDb.ProcessTypeIDs = _ProcesstypeIDs;
            return objDb.Search();
        }
        public void JoinCategory()
        {
            if (_CategoryTable == null || _CategoryTable.Rows.Count == 0)
                return;
            //ResetOrderCategory();
            string strTemp = "";
            string[] arrStr = new string[_CategoryTable.Rows.Count + 1];
            strTemp = "delete from RPProcessTypeCategory where ProcessTypeID =" + _ID;
            arrStr[0] = strTemp;
            int intIndex = 1;
            foreach (DataRow objDr in _CategoryTable.Rows)
            {
                strTemp = "INSERT INTO RPProcessTypeCategory (ProcessTypeID, CategoryID, " +
                     "Unit,Amount) VALUES (" +
                     _ID + "," + objDr["CategoryID"].ToString() + "," +
                     objDr["Unit"].ToString() + "," + objDr["Amount"].ToString()+ ")";
                arrStr[intIndex] = strTemp;
                intIndex++;
            }
            SysData.SharpVisionBaseDb.ExecuteNonQuery(arrStr);

        }
        public void JoinAccount()
        {
            string[] arrStr = new string[_ProcessTypeTable.Rows.Count];
            int intIndex = 0;
            foreach (DataRow objDr in _ProcessTypeTable.Rows)
            {
                arrStr[intIndex] = "update RPProcessType set ProcessTypeGLAccount =" + objDr["AccountID"].ToString() +
                    " where ProcessTypeID= " + objDr["ProcessTypeID"].ToString();
                intIndex++;
            }
            SysData.SharpVisionBaseDb.ExecuteNonQuery(arrStr);
        }
        #endregion
    }
}
