using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.SystemBase;
using System.Data;
using System.Data.SqlClient;
using SharpVision.Base.BaseDataBase;
using SharpVision.UMS.UMSDataBase;
using SharpVision.RP.RPDataBase;


namespace SharpVision.HR.HRDataBase
{
    public class SubSectorCellDb : SubSectorDb
    {
        #region PrivateData
        protected int _CellID;
        #endregion

        #region Constractors
        public SubSectorCellDb()
        {

        }
        public SubSectorCellDb(int intID)
        {
            _ID = intID;
            DataTable dtTemp = Search();
            DataRow objDR = dtTemp.Rows[0];
            SetData(objDR);
        }
        public SubSectorCellDb(DataRow objDR):base(objDR)
        {
            SetData(objDR);
        }
        #endregion

        #region Public Accessorice
        public int CellID
        {
            set
            {
              _CellID = value;
            }
            get
            {
                return _CellID;
            }
        }
        public static string SearchStr
        {
            get
            {
                string Returned = " SELECT     SubSectorID as CellSectorID,CellID  "+
                                  "  FROM  HRSubSectorCell ";
                return Returned;
            }
        }

        #endregion

        #region PrivateMethods
        void SetData(DataRow objDR)
        {
            try
            {
_CellID = int.Parse(objDR["CellID"].ToString());
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
            string strSql = " INSERT INTO HRSubSectorCell"+
                            " (SubSectorID, CellID)"+
                            " VALUES     ("+_ID+","+_CellID+") ";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);

        }
        public override void Edit()
        {
            base.Edit();
            string strSql = " UPDATE    HRSubSectorCell"+
                            " SET   SubSectorID ="+_ID+""+
                            " , CellID ="+_CellID+""+
                            " WHERE     (SubSectorID = "+_ID+") ";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);

        }

        public void Delete()
        {
            base.Delete();
            string strSql = " DELETE FROM HRSubSectorCell"+
                            " WHERE     (SubSectorID = "+_ID+") ";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);

        }

        public DataTable Search()
        {
             string strSql = SubSectorDb.SearchStr + " WHERE  (CellID is not null)";
            if (_ID != 0)
                strSql = strSql + " and SubSectorID = "+_ID+"";
            if(_CellID != 0)
                strSql = strSql + " and CellID = "+_CellID+"";
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);

        }
        #endregion
    }
}
