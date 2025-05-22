using System;
using System.Collections.Generic;
using System.Text;

using SharpVision.SystemBase;
using System.Data;
using System.Data.SqlClient;
using SharpVision.Base.BaseDataBase;

namespace SharpVision.COMMON.COMMONDataBase
{
    public class DegreeFieldTypeDb : BaseSingleDb
    {
        #region Private Data

        #endregion

        #region Constructors
        public DegreeFieldTypeDb()
        {


        }
        public DegreeFieldTypeDb(int intID)
        {
            _ID = intID;
            DataTable dtTemp = Search();
            if (dtTemp.Rows.Count != 0)
            {
                DataRow objDR = dtTemp.Rows[0];
                _NameA = objDR["FieldTypeNameA"].ToString();
                _NameE = objDR["FieldTypeNameE"].ToString();
            }
        }
        public DegreeFieldTypeDb(DataRow objDR)
        {
            if (objDR["FieldTypeID"].ToString() != "")
                _ID = int.Parse(objDR["FieldTypeID"].ToString());
            else
                return;
            _NameA = objDR["FieldTypeNameA"].ToString();
            _NameE = objDR["FieldTypeNameE"].ToString();
        }
        #endregion

        #region Public Properties
        public static string SearchStr
        {
            get
            {
                string Returned = @"SELECT COMMONDegreeFieldType.FieldTypeID, COMMONDegreeFieldType.FieldTypeNameA,COMMONDegreeFieldType.FieldTypeNameE  from COMMONDegreeFieldType";
                return Returned;

            }
        }
        #endregion

        #region Private Methods
        #endregion

        #region Public Methods
        public override void Add()
        {
            string strSql = "insert into COMMONDegreeFieldType (FieldTypeNameA,FieldTypeNameE,UsrIns,TimIns) " +
            "values('" + _NameA + "','" + _NameE + "'," + SysData.CurrentUser.ID + ",Getdate())";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
            //_ID = Convert.ToInt32(SysData.SharpVisionBaseDb.ReturnScalar(strSql));
        }
        public override void Edit()
        {
            string strSql = "update  COMMONDegreeFieldType ";
            strSql = strSql + " set FieldTypeNameA ='" + _NameA + "'";
            strSql = strSql + ", FieldTypeNameE ='" + _NameE + "'";
            strSql = strSql + ",UsrUpd = " + SysData.CurrentUser.ID;
            strSql = strSql + ",TimUpd =Getdate() ";
            strSql = strSql + " where FieldTypeID = " + _ID;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public override void Delete()
        {
            string strSql = "update COMMONDegreeFieldType set Dis = GetDate() where FieldTypeID=" + _ID;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public override DataTable Search()
        {
            string strSql = SearchStr + " WHERE    (COMMONDegreeFieldType.Dis IS NULL)";
            if (_ID != 0)
                strSql = strSql + " and FieldTypeID = " + _ID.ToString();

            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        #endregion
    }
}
