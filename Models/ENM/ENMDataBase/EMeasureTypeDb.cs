using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using SharpVision.SystemBase;
namespace AlgorithmatENM.ENM.ENMDb
{
   public  class EMeasureTypeDb
    {

        #region Constructor
        public EMeasureTypeDb()
        {
        }
        public EMeasureTypeDb(DataRow objDr)
        {
            SetData(objDr);
        }

        #endregion
        #region Properties
        int _ID;
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
        string _Code;
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
        string _NameA;
        public string NameA
        {
            set
            {
                _NameA = value;
            }
            get
            {
                return _NameA;
            }
        }
        string _NameE;
        public string NameE
        {
            set
            {
                _NameE = value;
            }
            get
            {
                return _NameE;
            }
        }
        string _Unit;
        public string Unit
        {
            set
            {
                _Unit = value;
            }
            get
            {
                return _Unit;
            }
        }
        bool _Accumulated;
        public bool Accumolated
        { set => _Accumulated = value; get => _Accumulated; }
        public string AddStr
        {
            get
            {
                string Returned = " insert into ENMEMeasureType (EMeasureTypeCode,EMeasureTypeNameA,EMeasureTypeNameE,EMeasureTypeUnit,EMeasureTypeAccumulated,UsrIns,TimIns) values ('" + Code + "','" + NameA + "','" + NameE + "','" + Unit + "',"+ (_Accumulated?1:0)+"," + SysData.CurrentUser.ID + ",GetDate() ) ";
                return Returned;
            }
        }
        public string EditStr
        {
            get
            {
                string Returned = " update ENMEMeasureType set EMeasureTypeCode='" + Code + "'" +
           ",EMeasureTypeNameA='" + NameA + "'" +
           ",EMeasureTypeNameE='" + NameE + "'" +
           ",EMeasureTypeUnit='" + Unit + "'"
           + ",EMeasureTypeAccumulated="+(_Accumulated?1:0)
           + ",UsrUpd=" + SysData.CurrentUser.ID + @",TimUpd=GetDate()  where EMeasureTypeID=" + ID ;
                return Returned;
            }
        }
        public string DeleteStr
        {
            get
            {
                string Returned = " update ENMEMeasureType set Dis = GetDate() where  EMeasureTypeID=" + ID  ;
                return Returned;
            }
        }
        public string SearchStr
        {
            get
            {
                string Returned = " select EMeasureTypeID,EMeasureTypeCode,EMeasureTypeNameA,EMeasureTypeNameE,EMeasureTypeUnit,EMeasureTypeAccumulated from ENMEMeasureType  ";
                return Returned;
            }
        }
        #endregion
        #region Private Method
        void SetData(DataRow objDr)
        {

            if (objDr.Table.Columns["EMeasureTypeID"] != null)
                int.TryParse(objDr["EMeasureTypeID"].ToString(), out _ID);

            if (objDr.Table.Columns["EMeasureTypeCode"] != null)
                _Code = objDr["EMeasureTypeCode"].ToString();

            if (objDr.Table.Columns["EMeasureTypeNameA"] != null)
                _NameA = objDr["EMeasureTypeNameA"].ToString();

            if (objDr.Table.Columns["EMeasureTypeNameE"] != null)
                _NameE = objDr["EMeasureTypeNameE"].ToString();

            if (objDr.Table.Columns["EMeasureTypeUnit"] != null)
                _Unit = objDr["EMeasureTypeUnit"].ToString();
            if (objDr.Table.Columns["EMeasureTypeAccumulated"] != null)
                bool.TryParse(objDr["EMeasureTypeAccumulated"].ToString(), out _Accumulated);
        }

        #endregion
        #region Public Method 
        public void Add()
        {
            string strSql = AddStr;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public void Edit()
        {
            string strSql = EditStr;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public void Delete()
        {
            string strSql = DeleteStr;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public DataTable Search()
        {
            string strSql = SearchStr + " where Dis is null ";


            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        #endregion
    }
}
