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
    public class SubSectorDb
    {
        #region PrivateData
        protected int _ID;
        protected int _SectorID;
        protected int _BranchID;

        
        protected int _CellID;
       
        protected string _Desc;
        protected string _SectorNameSearch;
        protected int _SubSectorAdmin;
        static DataTable _CachSubSectorAdminTable;
        string _SubSectorIDs;
        #endregion
        #region Constractprs
        public SubSectorDb()
        { 

        }
        public SubSectorDb(int intID)
        {
            _ID = intID;
            DataTable dtTemp = Search();
            DataRow objDR = dtTemp.Rows[0];
            SetData(objDR);
        }
        public SubSectorDb(DataRow objDR)
        {
            SetData(objDR);

        }
        #endregion
        #region PublicAccessorice
        public int ID
        {
            set
            {
                _ID = value;
            }
            get
            {
                return _ID;
            }
        }
        public int SectorID
        {
            set
            {
                _SectorID = value;
            }
            get
            {
                return _SectorID;
            }
        }

        public int BranchID
        {
            get { return _BranchID; }
            set { _BranchID = value; }
        }
        public int CellID
        {
            get { return _CellID; }
            set { _CellID = value; }
        }
        public int SubSectorAdmin
        {
            set
            {
                _SubSectorAdmin = value;
            }
            get
            {
                return _SubSectorAdmin;
            }

        }
        public static DataTable CachSubSectorAdminTable
        {
            set
            {
                _CachSubSectorAdminTable = value;
            }
            get
            {
                if (_CachSubSectorAdminTable == null)
                {
                    _CachSubSectorAdminTable = new DataTable();
                    _CachSubSectorAdminTable.Columns.Add("ApplicantID");
                }
                return _CachSubSectorAdminTable;
            }
        }
        public string SubSectorIDs
        {
            set
            {
                _SubSectorIDs = value;
            }
        }
        //public int BranchID
        //{
        //    set
        //    {
        //        _BranchID = value;
        //    }
        //    get
        //    {
        //        return _BranchID;
        //    }
        //}
        
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
        public string SectorNameSearch
        {
            set
            {
                _SectorNameSearch = value;
            }
           
        }
        public static string SearchStr
        {
            get
            {
                string Returned = " SELECT     HRSubSector.SubSectorID ,HRSubSector.SubSectorAdmin, HRSubSector.SubSectorDesc ,SectorTable.*," +
                                  " SubSectorBranchTable.*,SubSectorCellTable.*  FROM         HRSubSector  INNER  join "+
                                  "(" + SectorDb.SearchStr + ") as SectorTable" +
                                  " on HRSubSector.SectorID = SectorTable.SectorID left outer join "+
                                  " (" + SubSectorBranchDb.SearchStr + ") as SubsectorBranchTable " +
                                  " on HRSubSector.SubSectorID = SubSectorBranchTable.BranchSectorID " +
                                  " left outer join ("+SubSectorCellDb.SearchStr+") as SubSectorCellTable  "+
                                  " on  HRSubSector.SubSectorID=SubSectorCelltable.CellSectorID ";

               

                return Returned;
            }
        }
        #endregion
        #region PrivateData
        void SetData(DataRow objDR)
        {
            if (objDR["SubSectorID"].ToString()!="")
            _ID = int.Parse(objDR["SubSectorID"].ToString());
        if (objDR["SectorID"].ToString() != "")
            _SectorID = int.Parse(objDR["SectorID"].ToString());
        if (objDR["SubSectorAdmin"].ToString() != "")
            _SubSectorAdmin = int.Parse(objDR["SubSectorAdmin"].ToString());
            //_BranchID = int.Parse(objDR["BranchID"].ToString());
            //_CellID = int.Parse(objDR["CellID"].ToString());
            _Desc = objDR["SubSectorDesc"].ToString();

        }
        #endregion
        #region Public Data
        public virtual void Add()
        {
            string strSql = " INSERT INTO HRSubSector " +
                            " (SectorID,  SubSectorDesc,SubSectorAdmin)" +
                            " VALUES     (" + _SectorID + ",'" + _Desc + "'," + _SubSectorAdmin + ") ";
            _ID = SysData.SharpVisionBaseDb.InsertIdentityTable(strSql);
        }
        public virtual void Edit()
        {
            string strSql = " UPDATE    HRSubSector " +
                            " SET SectorID ="+_SectorID+"" +
                            ", SubSectorDesc ='"+_Desc+"' " +
                            ", SubSectorAdmin =" + _SubSectorAdmin + "" +
                            " Where SubSectorID = "+_ID+"";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);

        }
        public virtual void Delete()
        {
            string strSql = " UPDATE    HRSubSector SET Dis = GetDate() Where SubSectorID = " + _ID + " ";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);

        }
        public DataTable Search()
        {
            string strSql = SearchStr + " Where Dis Is Null   And SectorTable.DisSector Is null";
            if (_ID != 0)
                strSql += " And SubSectorID = " + _ID + "";
            if (_SubSectorIDs != null && _SubSectorIDs != "")
                strSql += " And SubSectorID in (" + _SubSectorIDs + ")";
            if (_SectorID != 0)
                strSql += " and (HRSubSector.SectorID =" + _SectorID + " Or SectorTable.SectorParentID = " + _SectorID + " )";
            if (_BranchID != 0)
                strSql += " and BranchID =" + _BranchID + "";
            if (_CellID != 0)
                strSql += " and CellID =" + _CellID + "";
            if (_SubSectorAdmin != 0)
                strSql += " and SubSectorAdmin =" + _SubSectorAdmin + "";
            if (_SectorNameSearch != null && _SectorNameSearch != "")
            {
                strSql += " and SectorTable.SectorNameA like '%" + _SectorNameSearch + "%'";
            }
            //if(_Cell
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        #endregion
    }
}
