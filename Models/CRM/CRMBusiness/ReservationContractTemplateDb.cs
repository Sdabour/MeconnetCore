using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.SystemBase;
using System.Data;
using System.Data.SqlClient;
using SharpVision.HR.HRDataBase;
using SharpVision.GL.GLDataBase;
namespace SharpVision.CRM.CRMDataBase
{
    public class ReservationContractTemplateDb
    {
        #region Private Data
        int _ID;
        string _Title;
        string _Desc;
        bool _IsStoped;
        int _RTF;
        int _IsStopedStatus;
        
        #endregion
        #region Constructors
        public ReservationContractTemplateDb()
        {
 
        }
        public ReservationContractTemplateDb(DataRow objDr)
        {
            SetData(objDr);
           
        }
        #endregion
        #region Public Properties
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
        public bool IsStoped
        {
            set
            {
                _IsStoped = value;
            }
            get
            {
                return _IsStoped;
            }
        }
        public int RTF
        {
            set 
            {
                _RTF = value;
            }
            get
            {
                return _RTF;
            }
        }
        int IsStopedStatus;
        public static string SearchStr
        {
            get
            {
                string Returned = "SELECT  TemplateID, TemplateTitle, TemplateDesc,TemplateRTF, TemplateIsStoped "+
                    " FROM    dbo.CRMReservationContractTemplate ";
                return Returned;
            }

        }
        #endregion
        #region Private Methods
        void SetData(DataRow objDr)
        {
            _ID = int.Parse(objDr["TemplateID"].ToString());
            _Title = objDr["TemplateTitle"].ToString();
            _Desc = objDr["TemplateDesc"].ToString();
           _RTF = int.Parse( objDr["TemplateRTF"].ToString());
            _IsStoped = bool.Parse(objDr["TemplateIsStoped"].ToString());
        }
        #endregion
        #region Public Methods
        public void Add()
        {
            int intIsStoped = _IsStoped ? 1 : 0;
            string strSql = "insert into CRMReservationContractTemplate (TemplateTitle, TemplateDesc, TemplateRTF, TemplateIsStoped) "+
                "  values ('"+_Title + "','" + _Desc + "',"  + _RTF + ","  + intIsStoped + ") ";
           _ID =  SysData.SharpVisionBaseDb.InsertIdentityTable(strSql);
        }
        public void Edit()
        {
            int intIsStoped = _IsStoped ? 1 : 0;
            string strSql = "update CRMReservationContractTemplate set TemplateTitle='" + _Title + "'"+
                ",TemplateDesc='" + _Desc + "'"+
                ",TemplateRTF=" + _RTF + ""+
                ",TemplateIsStoped=" + intIsStoped +
                " where TemplateID=" +_ID;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public void Delete()
        {
            string strSql = "update CRMReservationContractTemplate set Dis = GetDate() " +
               " where TemplateID=" + _ID;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public DataTable Search()
        {
            string strSql = SearchStr + " where Dis is null  ";
            if (_ID != 0)
                strSql += " and TemplateID="+ _ID;

            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        #endregion
    }
}
