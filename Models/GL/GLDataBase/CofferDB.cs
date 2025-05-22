using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.SystemBase;
using SharpVision.Base.BaseDataBase;

namespace SharpVision.GL.GLDataBase
{
    public class CofferDB : BaseSingleDb
    {
        #region Private Data
        protected string _Code;
        bool _IsBank;
        bool _IsMain;

        public bool IsMain
        {
            get { return _IsMain; }
            set { _IsMain = value; }
        }
        int _IsBankStatus;/*
                           * 0 dont care
                           * 1 is bank only
                           * 2 is not bank only
                           */
        #endregion
        #region Constractors
        public CofferDB()
        { 

        }
        public CofferDB(DataRow objDR)
        {
            SetData(objDR);
        }
        #endregion
        #region Public Accessorice
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
        public bool IsBank
        {
            set
            {
                _IsBank = value;
            }
            get
            {
                return _IsBank;
            }

        }
        public int IsBankStatus
        {
            set
            {
                _IsBankStatus = value;
            }
        }
        public static string SearchStr
        {
            get
            {
                string Returned = " SELECT     CofferID, CofferCode, CofferNameA, CofferNameE,CofferIsBank,CofferIsMain " +
                                  " FROM         GLCoffer ";
                return Returned;
            }
        }
        #endregion
        #region Private Methods
        void SetData(DataRow objDR)
        {
            try
            {
                _ID = int.Parse(objDR["CofferID"].ToString());
                _NameA = objDR["CofferNameA"].ToString();
                _NameE = objDR["CofferNameE"].ToString();
                _Code = objDR["CofferCode"].ToString();
                _IsBank = bool.Parse(objDR["CofferIsBank"].ToString());
                _IsMain = bool.Parse(objDR["CofferIsMain"].ToString());


            }
            catch { }
        }
        #endregion
        #region Public Methods
        public override void Add()
        {
            int intIsBank = _IsBank ? 1 : 0;
            int intIsMain = _IsMain ? 1 : 0;
            string strSql = " INSERT INTO GLCoffer"+
                            " (CofferCode, CofferNameA, CofferNameE,CofferIsBank,CofferIsMain)" +
                            " VALUES     ('"+_Code+"','"+_NameA+"','"+_NameE+"',"+ intIsBank + "," + intIsMain +") ";
          

            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public override void Edit()
        {
            int intIsBank = _IsBank?1:0;
            int intIsMain = _IsMain ? 1 : 0;
            string strSql = " UPDATE    GLCoffer" +
                            " SET  CofferCode ='" + _Code + "'" +
                            " , CofferNameA ='" + _NameA + "'" +
                            "  ,CofferNameE = '" + _NameE + "'" +
                            ",CofferIsBank=" + intIsBank +
                            ",CofferIsMain="+intIsMain +
                            " where CofferID  = " + _ID;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public override void Delete()
        {
            string strSql = " DELETE FROM GLCoffer  where CofferID  = " + _ID;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public override DataTable Search()
        {
            string strSql = SearchStr + " where 1 = 1";
            if (_ID != 0)
                strSql = strSql + " and  CofferID  = " + _ID;
            if (_IsBankStatus == 1)
                strSql += " and CofferIsBank=1 ";
            else if(_IsBankStatus == 2)
                strSql += " and CofferIsBank=0 ";
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        #endregion
    }
}