using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.SystemBase;
using System.Data;
using System.Data.SqlClient;
using SharpVision.Base.BaseDataBase;
using SharpVision.UMS.UMSDataBase;
namespace SharpVision.HR.HRDataBase
{
    public class SectorDb : BaseSelfRelatedDb
    {
        #region Private Data
        protected string _Desc;
        protected SectorTypeDb _TypeDb;
        protected int _TypeID;
        protected int _NodeNo;
        protected int _SectorAdmin;
        protected string _SectorAdminName;
        protected string _SectorAdminCode;
        protected int _DefualtCostCenterID;
        protected int _DefualtMotivationCostCenterID;
        protected bool _DisManual;
        protected bool _IsShowReport;
        protected bool _IsInPayRollSectors;
        protected DataTable _SectorTableSearch;
        static DataTable _SectorTable;
        static DataTable _CachSectorAdminTable;
        protected int _SectorOrderVal;
        DataTable _SectorOrderTable;
        #region Private Data for search
        protected string _NameALike;
        protected string _NameELike;
        protected bool _OnlyFamilies;
        protected bool _NoChildren;
        protected bool _TableChanged;
        protected bool _ParentEqualFamily;
        protected bool _DisManualSearch;
        protected bool _IsInPayRollSectorsSearch;        
        #endregion
        #endregion
        #region Constructors
        public SectorDb()
        {
            _TypeDb = new SectorTypeDb();
        }
        public SectorDb(int intID)
        {
            _ID = intID;
            DataRow[] arrDR = SectorTable.Select("SectorID=" + _ID);
            if (arrDR.Length <= 0)
                return;
            //DataTable dtTemp = Search();

            DataRow objDR = arrDR[0];

            SetData(objDR);


        }
        public SectorDb(DataRow objDR)
        {
            //_SectorDb = DR;
            SetData(objDR);

        }
        public SectorDb(int intID, string strName)
        {
            _ID = intID;
            _NameA = strName;
            _TypeDb = new SectorTypeDb();
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
        public SectorTypeDb SectorTypeDb
        {
            set
            {
                _TypeDb = value;
            }
            get
            {
                return _TypeDb;
            }

        }
        public int TypeID
        {
            set
            {
                _TypeID = value;
            }
            get
            {
                return _TypeID;
            }

        }
        public int SectorOrderVal
        {
            set
            {
                _SectorOrderVal = value;
            }
            get
            {
                return _SectorOrderVal;
            }

        }
        public bool DisManual
        {
            set
            {
                _DisManual = value;
            }
            get
            {
                return _DisManual;
            }

        }
        public bool IsShowReport
        {
            set
            {
                _IsShowReport = value;
            }
            get
            {
                return _IsShowReport;
            }

        }
        public bool IsInPayRollSectors
        {
            set
            {
                _IsInPayRollSectors = value;
            }
            get
            {
                return _IsInPayRollSectors;
            }

        }
        bool _IsSector;
        public bool IsSector
        {
            set => _IsSector = value;
            get => _IsSector;
        }
        bool _IsDepartment;
        public bool IsDepartment
        {
            set => _IsDepartment = value;
            get => _IsDepartment;
        }
        public int SectorAdmin
        {
            set
            {
                _SectorAdmin = value;
            }
            get
            {
                return _SectorAdmin;
            }

        }
        public int DefualtCostCenterID
        {
            set
            {
                _DefualtCostCenterID = value;
            }
            get
            {
                return _DefualtCostCenterID;
            }

        }
        public int DefualtMotivationCostCenterID
        {
            set
            {
                _DefualtMotivationCostCenterID = value;
            }
            get
            {
                return _DefualtMotivationCostCenterID;
            }

        }
        public static DataTable CachSectorAdminTable
        {
            set
            {
                _CachSectorAdminTable = value;
            }
            get
            {
                if (_CachSectorAdminTable == null)
                {
                    _CachSectorAdminTable = new DataTable();
                    _CachSectorAdminTable.Columns.Add("ApplicantID");
                }
                return _CachSectorAdminTable;
            }
        }
        public bool IsInPayRollSectorsSearch
        {
            set
            {
                _IsInPayRollSectorsSearch = value;
            }
            get
            {
                return _IsInPayRollSectorsSearch;
            }

        }
        public DataTable SectorOrderTable
        {
            set
            {
                _SectorOrderTable = value;
            }
        }
        public string SectorAdminName
        {
            get
            {
                return _SectorAdminName;
            }
        }
        public string SectorAdminCode
        {
            get
            {
                return _SectorAdminCode;
            }
        }
        #region Set Properties for Search
        public string NameLike
        {
            set
            {
                if (SysData.Language == 0)
                    _NameALike = value;
                else
                    _NameELike = value;
            }
        }
        public DataTable SectorTableSearch
        {
            set
            {
                _SectorTableSearch = value;
            }
        }
        public bool OnlyFamilies
        {
            set
            {
                _OnlyFamilies = value;
            }
        }
        public bool NoChildren
        {
            set
            {
                _NoChildren = value;
            }
        }
        public bool ParentEqualFamily
        {
            set
            {
                _ParentEqualFamily = value;
            }
        }
        public bool DisManualSearch
        {
            set
            {
                _DisManualSearch = value;
            }
            get
            {
                return _DisManualSearch;
            }

        }
        #endregion
        #region GetOnlyProperty
        public static DataTable SectorTable
        {
            set
            {
                _SectorTable = value;
            }
            get
            {
                if (_SectorTable == null)
                {
                    SectorDb objSectorDb = new SectorDb();
                    _SectorTable = objSectorDb.Search();
                    _SectorTable.PrimaryKey = new DataColumn[] { _SectorTable.Columns["SectorID"] };
                }
                return _SectorTable;
            }
        }
        public static string SearchStr
        {
            get
            {
                string strAdmin = "SELECT  dbo.HRApplicant.ApplicantID,dbo.HRApplicant.ApplicantFirstName, dbo.HRApplicantWorker.ApplicantCode " +
                    " FROM         dbo.HRApplicant INNER JOIN "+
                    " dbo.HRApplicantWorker ON dbo.HRApplicant.ApplicantID = dbo.HRApplicantWorker.ApplicantID "; 

                string Returned = "SELECT     SectorID, SectorType, SectorNameA, SectorNameE, SectorDesc,SectorAdmin"+
                    ",DisManual,IsShowReport,IsInPayRollSectors,HRSector.Dis as DisSector ,SectorParentID, SectorFamilyID" +
                    ",DefualtCostCenterID,DefualtMotivationCostCenterID,SectorOrderVal, dbo.HRSector.SectorDisplayAsSector, dbo.HRSector.SectorDisplayAsDepartment "+
                    ",SectorTypeTable.*,CostCenterHRTable.*,AdminTable.ApplicantFirstName,AdminTable.ApplicantCode  " +
                    ",MotivationCostCenterTable.CostCenterID AS MotivationCostCenterID "+
                     ",MotivationCostCenterTable.CostCenterNameA AS MotivationCostCenterName "+
                                            " FROM    dbo.HRSector inner join (" + SectorTypeDb.SearchStr + ") as SectorTypeTable on SectorTypeTable.SectorTypeID = HRSector.SectorType " +
                                            " Left Outer Join (" + CostCenterHRDb.SearchStr + ") as CostCenterHRTable On CostCenterHRTable.CostCenterIDValue = HRSector.DefualtCostCenterID"+
                                            " left outer join (" + strAdmin + ") as AdminTable  "+
                                            " on HRSector.SectorAdmin = AdminTable.ApplicantID "+
                                            " left outer  JOIN "+
                                            " dbo.GLCostCenter AS MotivationCostCenterTable " +
                                            " ON dbo.HRSector.DefualtMotivationCostCenterID = MotivationCostCenterTable.CostCenterID ";
                return Returned;
            }
        }
        #endregion
        #endregion
        #region Private Methodsda
        void SetData(DataRow objDR)
        {
            if (objDR["SectorID"].ToString() == "")
                return;
            _ID = int.Parse(objDR["SectorID"].ToString());
            _DefualtCostCenterID = int.Parse(objDR["DefualtCostCenterID"].ToString());
            if (objDR["DefualtMotivationCostCenterID"].ToString() != "")
                _DefualtMotivationCostCenterID = int.Parse(objDR["DefualtMotivationCostCenterID"].ToString());
            _NameA = objDR["SectorNameA"].ToString();
            _DisManual = bool.Parse(objDR["DisManual"].ToString());
            if (objDR["IsShowReport"].ToString() != "")
                _IsShowReport = bool.Parse(objDR["IsShowReport"].ToString());
            _IsInPayRollSectors = bool.Parse(objDR["IsInPayRollSectors"].ToString());
            _NameE = objDR["SectorNameE"].ToString();
            _Desc = objDR["SectorDesc"].ToString();
            _ParentID = int.Parse(objDR["SectorParentID"].ToString());
            _FamilyID = int.Parse(objDR["SectorFamilyID"].ToString());
            _TypeID = int.Parse(objDR["SectorType"].ToString());
            if (objDR["SectorAdmin"].ToString() != "")
                _SectorAdmin = int.Parse(objDR["SectorAdmin"].ToString());
            if (objDR["SectorOrderVal"].ToString() != "")
                _SectorOrderVal = int.Parse(objDR["SectorOrderVal"].ToString());
            _SectorAdminName = objDR["ApplicantFirstName"].ToString();
            _SectorAdminCode = objDR["ApplicantCode"].ToString();
            //SectorDisplayAsSector,SectorDisplayAsDepartment
            if (objDR.Table.Columns["SectorDisplayAsSector"] != null)
                bool.TryParse(objDR["SectorDisplayAsSector"].ToString(), out _IsSector);
            if (objDR.Table.Columns["SectorDisplayAsDepartment"] != null)
                bool.TryParse(objDR["SectorDisplayAsDepartment"].ToString(), out _IsDepartment);
            if (IsSector)
            {

            }
        }
        public void SetRelatedSectors(string strParentID, DataTable dtTemp, ref string strIDs)
        {
            DataRow[] arrDR = dtTemp.Select("SectorID <> SectorParentID and SectorParentID = " + strParentID);
            string strTempParent;
            foreach (DataRow objDR in arrDR)
            {
                if (strIDs != "")
                    strIDs = strIDs + ",";
                strTempParent = objDR["SectorID"].ToString();
                strIDs = strIDs + objDR["SectorID"].ToString();
                SetRelatedSectors(strTempParent, dtTemp, ref strIDs);
            }
        }
        DataTable GetSector(DataTable dtSector)
        {
            _TableChanged = false;


            string strWhere = "Dis is null";
            if (_OnlyFamilies)
                strWhere = strWhere + " and SectorID = SectorParentID ";
            else
            {
                if (_TypeID != 0)
                {
                    string strTempID = "";
                    string strTempWhere = strWhere;
                    if (_NameALike != null && _NameALike != "")
                    {
                        strTempWhere = strTempWhere + " and SectorNameA like '%" + _NameALike + "%' ";
                        DataRow[] arrTemp = dtSector.Select(strTempWhere, "");

                        foreach (DataRow objDr in arrTemp)
                        {
                            if (strTempID != "")
                                strTempID = strTempID + ",";
                            strTempID = strTempID + objDr["SectorID"];
                            SetRelatedSectors(objDr["SectorID"].ToString(), dtSector, ref strTempID);
                        }
                    }


                    strWhere = strWhere + " and (SectorType=" + _TypeID + ")";

                    if (strTempID != "")
                    {
                        _TableChanged = true;
                        strWhere = strWhere + " and SectorID in (" + strTempID + ") ";
                    }
                }
                else
                {
                    if (_NameALike != null && _NameALike != "")
                    {
                        _TableChanged = true;
                        strWhere = strWhere + " and SectorNameA like '%" + _NameALike + "%' ";
                    }
                    if (_NameELike != null && _NameELike != "")
                    {
                        _TableChanged = true;
                        strWhere = strWhere + " and SectorNameE like '%" + _NameELike + "%' ";
                    }
                }
            }
            DataRow[] arrDr = dtSector.Select(strWhere, "");
            DataTable dtReturned = new DataTable();
            foreach (DataColumn dcTemp in dtSector.Columns)
            {
                dtReturned.Columns.Add(new DataColumn(dcTemp.ColumnName, dcTemp.DataType));
            }
            foreach (DataRow objDr in arrDr)
            {
                dtReturned.ImportRow(objDr);
            }


            return dtReturned;

        }
        void SetRecursiveTable(string strParentSectorID, ref DataTable dtDist, ref DataTable dtSource)
        {
            DataRow[] arrDr = dtSource.Select("SectorID=" + strParentSectorID);

            if (arrDr.Length > 0)
            {
                string strTemp = arrDr[0]["SectorParentID"].ToString();
                _NodeNo++;
                if (_NodeNo >= 200)
                    return;


                string strLevel = "1";
                if (strTemp != strParentSectorID)
                {
                    SetRecursiveTable(strTemp, ref dtDist, ref dtSource);
                    DataRow[] arrParentDr = dtSource.Select("SectorID=" + strTemp);

                }

                dtDist.ImportRow(arrDr[0]);
                dtSource.Rows.Remove(arrDr[0]);


            }
        }
        void SetRecursiveChildernTable(string strParentSectorID, ref DataTable dtDist, ref DataTable dtSource)
        {
            if (_NoChildren || _OnlyFamilies)
                return;
            int intNewLevel = 1;
            DataRow[] arrDr = dtSource.Select("SectorID<>SectorParentID and SectorParentID=" + strParentSectorID);




            if (arrDr.Length > 0)
            {
                foreach (DataRow objDr in arrDr)
                {
                    string strTemp = objDr["SectorID"].ToString();
                    _NodeNo++;
                    if (_NodeNo > 200 && _SectorTableSearch == null)
                        return;
                    dtDist.ImportRow(objDr);

                    dtSource.Rows.Remove(objDr);

                    SetRecursiveChildernTable(strTemp, ref dtDist, ref dtSource);
                }
            }
        }
        public void EditSectorCach()
        {
            //if (_SectorTable != null)
            //{
            SectorDb objSectorDb = new SectorDb();
            _SectorTable = objSectorDb.Search();
            //}
        }
        #endregion
        #region Public Methods
        public override void Add()
        {
            _SectorTable = null;
            _FamilyID = _FamilyID == 0 ? _ID : _FamilyID;
            _ParentID = _ParentID == 0 ? _ID : _ParentID;
            int intDisManual = _DisManual ? 1 : 0;
            int intIsShowReport = _IsShowReport ? 1 : 0;
            int intIsInPayRollSectors = _IsInPayRollSectors ? 1 : 0;
            int intIsSector = _IsSector ? 1 : 0;
            int intIsDepartment = _IsDepartment ? 1 : 0;
            string strSql = "insert into HRSector (SectorType, SectorNameA, SectorNameE, SectorDesc,SectorAdmin,DisManual,IsShowReport,IsInPayRollSectors , SectorParentID, SectorFamilyID,DefualtCostCenterID,DefualtMotivationCostCenterID,SectorOrderVal, SectorDisplayAsSector, SectorDisplayAsDepartment, UsrIns, TimIns) values(";
            strSql = strSql + "" + _TypeID + ",'" + _NameA + "','" + _NameE + "','" + _Desc + "'," + _SectorAdmin + "," + intDisManual + "," + intIsShowReport + "," + intIsInPayRollSectors + "," + _ParentID + "," + _FamilyID + "," + _DefualtCostCenterID + "," + _DefualtMotivationCostCenterID + "," + _SectorOrderVal + 
                "," +
                intIsSector  +"," + intIsDepartment +"," + SysData.CurrentUser.ID + ",Getdate())";
            _ID = SysData.SharpVisionBaseDb.InsertIdentityTable(strSql);
            if (_ParentID == 0)
            {
                strSql = "update HRSector set SectorParentID = " + _ID + ", SectorFamilyID =" + _ID;
                strSql = strSql + " where SectorID = " + _ID;
                SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
            }

            //EditSectorCach();
            //_SectorTable = null;
        }
        public override void Edit()
        {
            _SectorTable = null;
            _FamilyID = _FamilyID == 0 ? _ID : _FamilyID;
            _ParentID = _ParentID == 0 ? _ID : _ParentID;
            int intDisManual = _DisManual ? 1 : 0;
            int intIsShowReport = _IsShowReport ? 1 : 0;
            int intIsInPayRollSectors = _IsInPayRollSectors ? 1 : 0;
            int intIsSector = _IsSector ? 1 : 0;
            int intIsDepartment = _IsDepartment ? 1 : 0;
            string strSql = "update  HRSector ";
            strSql = strSql + " set SectorType=" + _TypeID;
            strSql = strSql + " ,SectorNameA ='" + _NameA + "'";
            strSql = strSql + ",SectorNameE ='" + _NameE + "'";
            strSql = strSql + " ,SectorDesc ='" + _Desc + "'";
            strSql = strSql + ",SectorAdmin =" + _SectorAdmin;
            strSql = strSql + ",DisManual =" + intDisManual;
            strSql = strSql + ",IsShowReport =" + intIsShowReport;
            strSql = strSql + ",IsInPayRollSectors =" + intIsInPayRollSectors;
            strSql = strSql + ",SectorParentID =" + _ParentID;
            strSql = strSql + ",SectorFamilyID=" + _FamilyID;
            strSql = strSql + ", DefualtCostCenterID=" + _DefualtCostCenterID;
            strSql = strSql + ", DefualtMotivationCostCenterID = " + _DefualtMotivationCostCenterID + "";
            strSql = strSql + ",SectorOrderVal=" + _SectorOrderVal;
            strSql += " , SectorDisplayAsSector="+ intIsSector +
                ", SectorDisplayAsDepartment="+intIsDepartment;
            strSql = strSql + ",TimUpd = GetDate()";
            strSql = strSql + ",UsrUpd =" + SysData.CurrentUser.ID;
            strSql = strSql + " where SectorID = " + _ID;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
            strSql = "select * from HRSector where SectorFamilyID in " +
                " (select SectorFamilyID from HRSector where SectorParentID=" + _ID + " and SectorID <> " + _ID + " and SectorFamilyID <> " + _FamilyID + ")";
            DataTable dtTemp = SysData.SharpVisionBaseDb.ReturnDatatable(strSql);

            if (dtTemp.Rows.Count == 0)
                return;
            string strIDs = "";
            SetRelatedSectors(_ID.ToString(), dtTemp, ref strIDs);
            strSql = "Update HRSector set SectorFamilyID = " + _FamilyID + " where SectorID in ( " + strIDs + ")";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
            //EditSectorCach();
            // 


        }
        public override void Delete()
        {
            string strSql = "update  HRSector  set Dis= GetDate() where SectorID=" + _ID;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public override DataTable Search()
        {
            string strSql = SearchStr + " WHERE (1=1) AND (HRSector.Dis IS NULL)";
            if (_ID != 0)
                strSql = strSql + " and HRSector.SectorID = " + _ID.ToString();
            if (_NameA != "" && _NameA != null)
                strSql = strSql + " and HRSector.SectorNameA = '" + _NameA + "'  ";
            if (_ParentID != 0)
                strSql = strSql + "  and HRSector.SectorParentID = " + _ParentID;
            if (_FamilyID != 0)
                strSql = strSql + " and HRSector.SectorFamilyID = " + _FamilyID;
            if (_TypeID != 0)
                strSql = strSql + " and HRSector.SectorType=" + _TypeID;
            if (_NameALike != null && _NameALike != "")
                strSql = strSql + " and HRSector.SectorNameA like '%" + _NameALike + "%' ";
            if (_NameELike != null && _NameELike != "")
                strSql = strSql + " and HRSector.SectorNameE like '%" + _NameELike + "%' ";
            if (_SectorAdmin != 0)
                strSql = strSql + " and HRSector.SectorAdmin = " + _SectorAdmin;
            if (_DisManualSearch == true)
                strSql = strSql + " and HRSector.DisManual = 1";
            else
                strSql = strSql + " and HRSector.DisManual = 0";

            if (_ParentEqualFamily == true)
                strSql = strSql + " and (HRSector.SectorParentID = HRSector.SectorFamilyID)";
            if (_IsInPayRollSectorsSearch == true)
                strSql = strSql + " and HRSector.IsInPayRollSectors = 1";


            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);


        }
        public DataTable GetChildrenTable()
        {
            DataTable dtReturned = new DataTable();
            foreach (DataColumn dcTemp in SectorTable.Columns)
            {
                dtReturned.Columns.Add(dcTemp.ColumnName, dcTemp.DataType);
            }
            DataTable dtSrc = SectorTable.Copy();
            DataRow[] arrDr = dtSrc.Select("SectorID=" + _ID.ToString());
            if (arrDr.Length != 0)
            {
                dtReturned.ImportRow(arrDr[0]);
                SetRecursiveChildernTable(_ID.ToString(), ref dtReturned, ref dtSrc);
            }
            return dtReturned;

        }
        public void EditSectorOrderVal()
        {
            string str = "update Set SectorOrderVal = "+ _SectorOrderVal +"  HRSector  where SectorID = " + _ID +"";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(str);
        }
        public void EditSectorDefaultCostCenter()
        {
            string strApplicantSector = "SELECT        dbo.HRApplicantWorkerCurrentSubSector.ApplicantID, dbo.HRSubSector.SectorID "+
                  " FROM            dbo.HRApplicantWorkerCurrentSubSector INNER JOIN "+
                  " dbo.HRSubSector ON dbo.HRApplicantWorkerCurrentSubSector.SubSectorID = dbo.HRSubSector.SubSectorID INNER JOIN "+
                   " dbo.HRApplicantWorker ON dbo.HRApplicantWorkerCurrentSubSector.ApplicantID = dbo.HRApplicantWorker.ApplicantID ";
            string strSector = "WITH SectorTable (      SectorID, SectorNameA  ) AS "+
                 " ( "+
                 "SELECT        SectorID, SectorNameA "+
                 " FROM            dbo.HRSector "+
                  " WHERE        (SectorID = "+ID  +") "+
                " UNION ALL "+
                " SELECT         dbo.HRSector.SectorID, dbo.HRSector.SectorNameA "+
                 " FROM    dbo.HRSector INNER JOIN SectorTable ON dbo.HRSector.SectorParentID = SectorTable.SectorID "+
                  " ) ";
            string strSql = strSector + " update dbo.HRApplicantWorkerCostCenter set CostCenter = "+ _DefualtCostCenterID +
             " FROM SectorTable "+ 
            " INNER JOIN ("+ strApplicantSector +") AS ApplicantSectorTable "+
						 " ON ApplicantSectorTable.SectorID = SectorTable.SectorID "+
						 " INNER JOIN dbo.HRApplicantWorkerCostCenter ON dbo.HRApplicantWorkerCostCenter.Applicant = ApplicantSectorTable.ApplicantID "+
						 ";";

            strSql += strSector +
            " update dbo.HRApplicantWorkerMotivationCostCenter set CostCenter = " + _DefualtMotivationCostCenterID +
          " FROM SectorTable " +
         " INNER JOIN (" + strApplicantSector + ") AS ApplicantSectorTable " +
                      " ON ApplicantSectorTable.SectorID = SectorTable.SectorID " +
                      " INNER JOIN dbo.HRApplicantWorkerMotivationCostCenter ON dbo.HRApplicantWorkerMotivationCostCenter.Applicant = ApplicantSectorTable.ApplicantID " +
                      ";";
            strSql +=  strSector + " update HRSector set DefualtCostCenterID = "+ _DefualtCostCenterID + ", DefualtMotivationCostCenterID="+ _DefualtMotivationCostCenterID +
                " from HRSector inner join SectorTable on HRSector.SectorID = SectorTable.SectorID;  ";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        #region Native GetAllSector
        public DataTable GetAllSector()
        {

            DataTable dtTempSector;
            if (_ParentID == 0)
            {
                dtTempSector = SectorTable;
            }
            else
            {
                dtTempSector = _SectorTableSearch;

            }
            //DataTable dtAllSector = 
            DataTable dtAllSector = GetSector(dtTempSector);


            DataTable dtReturned = new DataTable();
            if (dtAllSector.Rows.Count == 0)
                return dtReturned;


            foreach (DataColumn dcTemp in dtTempSector.Columns)
            {
                dtReturned.Columns.Add(new DataColumn(dcTemp.ColumnName, dcTemp.DataType));
            }

            string strSectorID;
            DataTable dtSrc = SectorTable.Copy();


            if (_TableChanged)
            {
                foreach (DataRow drTemp in dtAllSector.Rows)
                {
                    strSectorID = drTemp["SectorID"].ToString();
                    SetRecursiveTable(strSectorID, ref dtReturned, ref dtSrc);
                    SetRecursiveChildernTable(strSectorID, ref dtReturned, ref dtSrc);

                }
            }
            else
            {
                if (_ParentID != 0)
                {
                    SetRecursiveTable(_ParentID.ToString(), ref dtAllSector, ref dtSrc);
                    dtReturned = dtAllSector;

                }
                else
                    dtReturned = dtAllSector;

            }

            return dtReturned;

        }
        #endregion
        public void UpdateOrderVal(int intSectorID, int intOrderVal)
        {
            string str = " Update HRSector Set SectorOrderVal = " + intOrderVal + " Where SectorID = " + intSectorID + "";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(str);
        }
        public void ReOrderSector()
        {
            string[] arrStr = new string[_SectorOrderTable.Rows.Count];
            int intIndex =0;
            foreach (DataRow objDr in _SectorOrderTable.Rows)
            {
                arrStr[intIndex] = "Update HRSector set SectorOrderVal=" + objDr["SectorOrder"].ToString() +
                    " where SectorID =" + objDr["SectorID"].ToString();
                intIndex++;
            }
            SysData.SharpVisionBaseDb.ExecuteNonQuery(arrStr);
        }
        #endregion
    }
}
