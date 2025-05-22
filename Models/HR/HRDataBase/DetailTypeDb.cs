using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.SystemBase;
using System.Data;
using SharpVision.Base.BaseDataBase;



namespace SharpVision.HR.HRDataBase
{
    public class DetailTypeDb : BaseSingleDb
    {
        #region Private Data
        protected bool _DetailTypeEstimationEffect;
        #endregion
        #region Constructors
        public DetailTypeDb()
        {
        }
        public DetailTypeDb(int intID)
        {
            _ID = intID;
            DataTable dtTemp = Search();
            DataRow objDR = dtTemp.Rows[0];
            SetData(objDR);
        }
        public DetailTypeDb(DataRow objDR)
        {
            SetData(objDR);
        }
        #endregion
        #region Public Properties
        public bool DetailTypeEstimationEffect
        {
            set { _DetailTypeEstimationEffect = value; }
            get { return _DetailTypeEstimationEffect; }
        }
        public static string SearchStr
        {
            get
            {
                string Returned = "SELECT     HRDetailType.DetailTypeID, HRDetailType.DetailTypeNameA, HRDetailType.DetailTypeNameE, HRDetailType.DetailTypeEstimationEffect FROM  HRDetailType ";
                return Returned;
            }
        }
        #endregion
        #region Private Methods
        void SetData(DataRow objDR)
        {
            _ID = int.Parse(objDR["DetailTypeID"].ToString());
            _NameA = objDR["DetailTypeNameA"].ToString();
            _NameE = objDR["DetailTypeNameE"].ToString();
            _DetailTypeEstimationEffect = bool.Parse(objDR["DetailTypeEstimationEffect"].ToString());
        }
        #endregion
        #region Public Methods
        public override void Add()
        {
            int intDetailTypeEstimationEffect;
            if (_DetailTypeEstimationEffect == true)
                intDetailTypeEstimationEffect = 1;
            else
                intDetailTypeEstimationEffect = 0;
            string strSql = "insert into HRDetailType (DetailTypeNameA,DetailTypeNameE,DetailTypeEstimationEffect,UsrIns,TimIns) " +
            "values('" + _NameA + "','" + _NameE + "'," + intDetailTypeEstimationEffect + "," + SysData.CurrentUser.ID + ",Getdate())";
            _ID = SystemBase.SysData.SharpVisionBaseDb.InsertIdentityTable(strSql);
        }
        public override void Edit()
        {
            int intDetailTypeEstimationEffect;
            if (_DetailTypeEstimationEffect == true)
                intDetailTypeEstimationEffect = 1;
            else
                intDetailTypeEstimationEffect = 0;

            string strSql = "update  HRDetailType ";
            strSql = strSql + " set DetailTypeNameA ='" + _NameA + "'";
            strSql = strSql + " ,DetailTypeNameE ='" + _NameE + "'";
            strSql = strSql + ",DetailTypeEstimationEffect = " + intDetailTypeEstimationEffect + "";
            strSql = strSql + ",UsrUpd = " + SysData.CurrentUser.ID + "";
            strSql = strSql + ",TimUpd =Getdate() ";
            strSql = strSql + " where DetailTypeID = " + _ID;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public override void Delete()
        {
            string strSql = "update HRDetailType set Dis = GetDate() where DetailTypeID=" + _ID;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public override DataTable Search()
        {
            string strSql = SearchStr + " WHERE    (HRDetailType.Dis IS NULL)";
            if (_ID != 0)
                strSql = strSql + " and DetailTypeID = " + _ID.ToString();


            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        #endregion
    }
}
