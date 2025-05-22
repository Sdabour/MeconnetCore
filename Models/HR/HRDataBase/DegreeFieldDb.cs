using System;
using System.Collections.Generic;
using System.Text;

using SharpVision.SystemBase;
using System.Data;
using System.Data.SqlClient;
using SharpVision.Base.BaseDataBase;

namespace SharpVision.COMMON.COMMONDataBase
{
    public class DegreeFieldDb : BaseSingleDb
    {
        #region Private Data
        protected int _FieldType;
        #endregion

        #region Constructors
        public DegreeFieldDb()
        {


        }
        public DegreeFieldDb(int intID)
        {
            _ID = intID;
            DataTable dtTemp = Search();
            if (dtTemp.Rows.Count != 0)
            {
                DataRow objDR = dtTemp.Rows[0];
                _NameA = objDR["FieldNameA"].ToString();
                _NameE = objDR["FieldNameE"].ToString();
                _FieldType = int.Parse(objDR["FieldType"].ToString());
            }
        }
        public DegreeFieldDb(DataRow objDR)
        {
            if (objDR["FieldID"].ToString() != "")
                _ID = int.Parse(objDR["FieldID"].ToString());
            else
                _ID = 0;

           
            _NameA = objDR["FieldNameA"].ToString();
            _NameE = objDR["FieldNameE"].ToString();
            if (objDR["FieldType"].ToString() != "")
                _FieldType = int.Parse(objDR["FieldType"].ToString());
            else
                _FieldType = 0;
        }

        #endregion

        #region Public Properties
        public static string SearchStr
        {
            get
            {
                string Returned = @"SELECT COMMONDegreeField.FieldID, COMMONDegreeField.FieldNameA"+
                    ",COMMONDegreeField.FieldNameE,COMMONDegreeField.FieldType ,FieldTypeTable.* " +
                    " from COMMONDegreeField "+
                    " left outer join ("+ DegreeFieldTypeDb.SearchStr +") as FieldTypeTable "+
                    "  on  COMMONDegreeField.FieldType = FieldTypeTable.FieldTypeID ";
                return Returned;

            }
        }
        public int FieldType
        {
            set
            {
                _FieldType = value;
            }
            get
            {
                return _FieldType;
            }
        }
        #endregion

        #region Private Methods
        #endregion

        #region Public Methods
        public override void Add()
        {
            string strSql = "insert into COMMONDegreeField (FieldNameA,FieldNameE,FieldType,UsrIns,TimIns) " +
            "values('" + _NameA + "','" + _NameE + "'," + _FieldType + "," + SysData.CurrentUser.ID + ",Getdate())";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
            //_ID = Convert.ToInt32(SysData.SharpVisionBaseDb.ReturnScalar(strSql));
        }
        public override void Edit()
        {
            string strSql = "update  COMMONDegreeField ";
            strSql = strSql + " set FieldNameA ='" + _NameA + "'";
            strSql = strSql + ", FieldNameE ='" + _NameE + "'";
            strSql = strSql + ", FieldType =" + _FieldType + "";
            strSql = strSql + ",UsrUpd = " + SysData.CurrentUser.ID;
            strSql = strSql + ",TimUpd =Getdate() ";
            strSql = strSql + " where FieldID = " + _ID;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public override void Delete()
        {
            string strSql = "update COMMONDegreeField set Dis = GetDate() where FieldID=" + _ID;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public override DataTable Search()
        {
            string strSql = SearchStr + " WHERE    (COMMONDegreeField.Dis IS NULL)";
            if (_ID != 0)
                strSql = strSql + " and FieldID = " + _ID.ToString();

            strSql += " Order by FieldNameA";
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        #endregion
    }
}
