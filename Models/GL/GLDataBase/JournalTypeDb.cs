using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.SystemBase;
using SharpVision.Base.BaseDataBase;

namespace SharpVision.GL.GLDataBase
{
    public class JournalTypeDb : BaseSingleDb
    {
        #region Private Data
        protected string _Code;
        #endregion

        #region Constractors
        public JournalTypeDb()
        { 

        }
        public JournalTypeDb(DataRow objDR)
        {
            SetData(objDR);
        }
        #endregion

        #region public Accessorice
        public string Code
        {
            set
            {
                _Code = value;
            }
            get
            {
                return _Code;
            }
        }
        public static string SearchStr
        {
            get
            {
                string Returned = " SELECT     JournalTypeID, JournalTypeCode, JournalTypeNaemeA, JournalTypeNameE"+
                                  " FROM         GLJournalType ";
                return Returned;
            }
        }
        #endregion

        #region Private Methods
        void SetData(DataRow objDR)
        {
            if (objDR["JournalTypeID"].ToString() == "")
                return;
            _ID = int.Parse(objDR["JournalTypeID"].ToString());
            _Code = objDR["JournalTypeCode"].ToString();
            _NameA = objDR["JournalTypeNaemeA"].ToString();
            _NameE = objDR["JournalTypeNameE"].ToString();
        }
        #endregion

        #region Public Methods
        public override void Add()
        {
            string strSql = " INSERT INTO GLJournalType"+
                            " (JournalTypeCode, JournalTypeNaemeA, JournalTypeNameE)"+
                            " VALUES     ('"+_Code+"','"+_NameA+"','"+_NameE+"') ";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public override void Edit()
        {
            string strSql = " UPDATE    GLJournalType"+
                            " SET   JournalTypeCode ='"+_Code+"'"+
                            " , JournalTypeNaemeA ='"+_NameA+"'"+
                            " , JournalTypeNameE ='"+_NameE+"'"+
                            " WHERE     (JournalTypeID = "+_ID+") ";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public override void Delete()
        {
            string strSql = " UPDATE    GLJournalType  SET   Dis = GetDate() WHERE     (JournalTypeID = 1) ";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public override DataTable Search()
        {
            string strSql = SearchStr + " where 1 = 1 ";
            if (_ID != 0)
                strSql = strSql + " and  JournalTypeID = " + _ID + "";
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        #endregion
    }
}