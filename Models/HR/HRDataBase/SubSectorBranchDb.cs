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
    public class SubSectorBranchDb : SubSectorDb
    {
        #region PrivateData
        protected int _BranchID;
        #endregion

        #region Constractors
        public SubSectorBranchDb()
        {

        }
        public SubSectorBranchDb(int intID)
        {
            _ID = intID;
            DataTable dtTemp = Search();
            DataRow objDR = dtTemp.Rows[0];
            SetData(objDR);
        }
        public SubSectorBranchDb(DataRow objDR):base(objDR)
        {
            SetData(objDR);
        }
        #endregion
        #region Public Accessorice
        public int BranchID
        {
            set
            {
              _BranchID = value;
            }
            get
            {
                return _BranchID;
            }
        }
        public static string SearchStr
        {
            get
            {
                string Returned = " SELECT     SubSectorID as BranchSectorID, BranchTable.* "+
                    "  FROM  HRSubSectorBranch "+
                    " INNER JOIN (" + BranchDb.SearchStr + ") AS BranchTable ON "+
                    " HRSubSectorBranch.BranchID = BranchTable.BranchID ";
                        return Returned;
            }
        }

        #endregion
        #region PrivateMethods
        void SetData(DataRow objDR)
        {
            try
            {
                _BranchID = int.Parse(objDR["BranchID"].ToString());
            }
            catch (Exception)
            {

            }

        }
        #endregion

        #region PublicMethods
        public override void Add()
        {
            base.Add();
            string strSql = " INSERT INTO HRSubSectorBranch"+
                            " (SubSectorID, BranchID)"+
                            " VALUES     ("+_ID+","+_BranchID+") ";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);

        }
        public override void Edit()
        {
            base.Edit();
            string strSql = " UPDATE    HRSubSectorBranch"+
                            " SET   SubSectorID ="+_ID+""+
                            " , BranchID ="+_BranchID+""+
                            " WHERE     (SubSectorID = "+_ID+") ";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);

        }

        public void Delete()
        {
            base.Delete();
            string strSql = " DELETE FROM HRSubSectorBranch"+
                            " WHERE     (SubSectorID = "+_ID+") ";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);

        }

        public DataTable Search()
        {
            string strSql = SubSectorDb.SearchStr + " WHERE  (BranchSectorID is not null) And  SectorTable.DisSector Is null and HRSubSector.Dis Is Null";
            if (_ID != 0)
                strSql = strSql + " and SubSectorID = "+_ID+"";
            if(_BranchID != 0)
                strSql = strSql + " and BranchID = "+_BranchID+"";
            if (_SectorID != 0)
                strSql = strSql + " and HRSubSector.SectorID = " + _SectorID + "";
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);

        }
        #endregion
    }
}
