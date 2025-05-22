using System;
using System.Collections.Generic;
using System.Text;

using SharpVision.SystemBase;
using System.Data;
using System.Data.SqlClient;
using SharpVision.Base.BaseDataBase;

namespace SharpVision.COMMON.COMMONDataBase
{
    public class DegreeSubFieldDb : BaseSingleDb
    {
        #region Private Data
        protected int _Field;
        #endregion

        #region Constructors
        public DegreeSubFieldDb()
        {
        }
        public DegreeSubFieldDb(int intID)
        {
            _ID = intID;
            DataTable dtTemp = Search();
            if (dtTemp.Rows.Count != 0)
            {
                DataRow objDR = dtTemp.Rows[0];
                _NameA = objDR["SubFieldNameA"].ToString();
                _NameE = objDR["SubFieldNameE"].ToString();
                if (objDR["Field"].ToString() != "")
                    _Field = int.Parse(objDR["Field"].ToString());
            }
        }
        public DegreeSubFieldDb(DataRow objDR)
        {
            if (objDR["SubFieldID"].ToString() != "")
                _ID = int.Parse(objDR["SubFieldID"].ToString());
            else
                _ID = 0;
            
            _NameA = objDR["SubFieldNameA"].ToString();
            _NameE = objDR["SubFieldNameE"].ToString();
            if (objDR["Field"].ToString()!="")
            _Field = int.Parse(objDR["Field"].ToString());

        }
        #endregion

        #region Public Properties
        public int Field
        {
            set
            {
                _Field = value;
            }
            get
            {
                return _Field;
            }
        }
        public static string SearchStr
        {
            get
            {
                string Returned = @"SELECT COMMONDegreeSubField.SubFieldID, COMMONDegreeSubField.SubFieldNameA"+
                    ",COMMONDegreeSubField.SubFieldNameE,COMMONDegreeSubField.Field,FieldTable.* "+
                    "  from COMMONDegreeSubField "+
                    " left outer join ("+ DegreeFieldDb.SearchStr +") as FieldTable "+
                    " on COMMONDegreeSubField.Field = FieldTable.FieldID  ";
                return Returned;

            }
        }
        #endregion

        #region Private Methods
        #endregion

        #region Public Methods
        public override void Add()
        {
            string strSql = "insert into COMMONDegreeSubField (SubFieldNameA,SubFieldNameE,Field,UsrIns,TimIns) " +
            "values('" + _NameA + "','" + _NameE + "'," + _Field + "," + SysData.CurrentUser.ID + ",Getdate())";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
            //_ID = Convert.ToInt32(SysData.SharpVisionBaseDb.ReturnScalar(strSql));
        }
        public override void Edit()
        {
            string strSql = "update  COMMONDegreeSubField ";
            strSql = strSql + " set SubFieldNameA ='" + _NameA + "'";
            strSql = strSql + ", SubFieldNameE ='" + _NameE + "'";
            strSql = strSql + ", Field =" + _Field + "";
            strSql = strSql + ",UsrUpd = " + SysData.CurrentUser.ID;
            strSql = strSql + ",TimUpd =Getdate() ";
            strSql = strSql + " where SubFieldID = " + _ID;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public override void Delete()
        {
            string strSql = "update COMMONDegreeSubField set Dis = GetDate() where SubFieldID=" + _ID;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public override DataTable Search()
        {
            string strSql = SearchStr + " WHERE    (COMMONDegreeSubField.Dis IS NULL)";
            if (_ID != 0)
                strSql = strSql + " and SubFieldID = " + _ID.ToString();
            if (_Field != 0)
                strSql = strSql + " and Field = " + _Field.ToString();

            strSql += " Order by SubFieldNameA";
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        #endregion
    }
}
