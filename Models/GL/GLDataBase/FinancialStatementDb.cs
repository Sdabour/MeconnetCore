using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.SystemBase;
using SharpVision.Base.BaseDataBase;

namespace SharpVision.GL.GLDataBase
{
    public class FinancialStatementDb
    {
        #region Private Methods
        protected int _ID;
        protected DateTime _Date;
        protected int _Type;
        protected string _Title;
        #endregion
        #region Constractors
        public FinancialStatementDb()
        {

        }
        public FinancialStatementDb(int intID)
        {
            _ID = intID;
            DataTable dtTemp = Search();
            DataRow objDR = dtTemp.Rows[0];
            SetData(objDR);
        }
        public FinancialStatementDb(DataRow objDR)
        {
            SetData(objDR);
        }
        #endregion
        #region Public Accessorices
        public int ID 
        {
            set
            {
                _ID= value;
            }
            get
            {
                return _ID;
            }
        }
        public DateTime Date
        {
            set
            {
                _Date = value;
            }
            get
            {
                return _Date;
            }

        }
        public int Type
        {
            set
            {
                _Type = value;
            }
            get
            {
                return _Type;
            }
        }
        public string Title
        {
            set
            {
                _Title = value;
            }
            get
            {
                return _Title;
            }
        }
        public static string SearchStr
        {
            get
            {
                string Returned = " SELECT     FinancialStatementID, FinancialStatementDate, FinancialStatementType, FinancialStateTitle"+
                                  " FROM         GLFinancialStatement "; 
                return Returned;
            }
        }
        #endregion
        #region Private Methods
        void SetData(DataRow objDR)
        {
            _ID = int.Parse(objDR["FinancialStatementID"].ToString());
            _Date = DateTime.Parse(objDR["FinancialStatementDate"].ToString());
            _Type = int.Parse(objDR["FinancialStatementType"].ToString());
            _Title = objDR["FinancialStateTitle"].ToString();
        }
        #endregion
        #region Public Methods
        public void Add()
        {
            double dblDate = _Date.ToOADate()-2;
            string strSql = " INSERT INTO GLFinancialStatement"+
                            " ( FinancialStatementDate, FinancialStatementType, FinancialStateTitle)"+
                            " VALUES     ("+dblDate+","+_Type+",'"+_Title+"') ";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public void Edit()
        {
            double dblDate = _Date.ToOADate()-2;
            string strSql = " UPDATE    GLFinancialStatement"+
                            " SET   FinancialStatementDate = "+dblDate+""+
                            " , FinancialStatementType = "+_Type+""+
                            " , FinancialStateTitle ='"+_Title+"' "+
                            " Where FinancialStatementID  = "+_ID+"";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public void Delete()
        {
            string strSql = " DELETE FROM GLFinancialStatement  Where FinancialStatementID  = "+_ID+"";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public DataTable Search()
        {
            string strSql = SearchStr + " Where 1 = 1 ";
            if(_ID != 0)
                strSql += " and  FinancialStatementID  = "+_ID+"";
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        #endregion
    }
}
