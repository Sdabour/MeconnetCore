using System;
using System.Collections.Generic;
using System.Text;
//using SharpVision.UMS.UMSDataBase;
using SharpVision.SystemBase;
using System.Data;
using System.Data.SqlClient;
using SharpVision.Base.BaseDataBase;

namespace SharpVision.HR.HRDataBase
{
    public class FieldTypeDb : BaseSingleDb
    {
        #region Private Data        
        bool _VIP;
        #endregion
        #region Constructors
        public FieldTypeDb()
        {

        }

        public FieldTypeDb(int intID)
        {
            _ID = intID;
            if (_ID != 0)
            {
                DataTable dtTemp = Search();
                DataRow objDR = Search().Rows[0];
                SetData(objDR);
            }


        }
        public FieldTypeDb(DataRow objDR)
        {
            //_FieldDb = DR;
            SetData(objDR);

        }
        public FieldTypeDb(int intID, string strName)
        {
            _ID = intID;
            _NameA = strName;
            //DataTable dtTemp = Search();
            //DataRow objDR = Search().Rows[0];
            //SetData(objDR);

        }

        #endregion
        #region Public Properties

        public bool VIP
        {
            set
            {
                _VIP = value;
            }
            get
            {
                return _VIP;
            }
        }
        
        public static string SearchStr
        {
            get
            {
                string Returned = @" SELECT HRFieldType.FieldID, HRFieldType.FieldNameA,HRFieldType.FieldNameE,HRFieldType.VIP as FieldTypeVIP
                                     FROM HRFieldType ";
                return Returned;

            }
        }
        #endregion
        #region Private Methods
        void SetData(DataRow objDR)
        {
            _ID = int.Parse(objDR["FieldID"].ToString());
            _NameA = objDR["FieldNameA"].ToString();
            _NameE = objDR["FieldNameE"].ToString();
            _VIP = bool.Parse(objDR["FieldTypeVIP"].ToString());
            
            
        }
        #endregion
        #region Public Methods
        public override void Add()
        {
            int intVIP = _VIP ? 1 : 0;
            string strSql = "insert into HRFieldType (FieldNameA,FieldNameE,VIP,UsrIns,TimIns) " +
            "values('" + _NameA + "','" + _NameE + "'," + intVIP + "," + SysData.CurrentUser.ID + ",Getdate())";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
            //_ID = Convert.ToInt32(SysData.SharpVisionBaseDb.ReturnScalar(strSql));



        }
        public override void Edit()
        {
            int intVIP = _VIP ? 1 : 0;
            string strSql = "update  HRFieldType ";
            strSql = strSql + " set FieldNameA ='" + _NameA + "'";
            strSql = strSql + " , FieldNameE ='" + NameE + "'";            
            strSql = strSql + " , VIP =" + intVIP;
            strSql = strSql + ",UsrUpd = " + SysData.CurrentUser.ID;
            strSql = strSql + ",TimUpd =Getdate() ";
            strSql = strSql + " where FieldID = " + _ID;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public override void Delete()
        {
            string strSql = "update HRFieldType set Dis = GetDate() where FieldID=" + _ID;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public override DataTable Search()
        {
            string strSql = SearchStr + " WHERE    (HRFieldType.Dis IS NULL)";
            if (_ID != 0)
                strSql = strSql + " and FieldID = " + _ID.ToString();
            //if (_Name != "" && _Name != null)
            //    strSql = strSql + " and FieldName = '" + _Name + "'  ";

            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql, "InterestFieldType");
        }
        #endregion
    }
}
