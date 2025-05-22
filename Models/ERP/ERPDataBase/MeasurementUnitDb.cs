using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using SharpVision.SystemBase;

namespace AlgorithmatENM.ERP.ERPDataBase
{
    public class MeasurementUnitDb
    {

        #region Constructor
        public MeasurementUnitDb()
        {
        }
        public MeasurementUnitDb(DataRow objDr)
        {
            SetData(objDr);
        }

        #endregion
        #region Properties
        int _ID;
        public int ID
        {
            set => _ID = value;
            get => _ID;
        }
        int _Main;
        public int Main
        {
            set => _Main = value;
            get => _Main;
        }
        string _Code;
        public string Code
        {
            set => _Code = value;
            get => _Code;
        }
        string _NameA;
        public string NameA
        {
            set => _NameA = value;
            get => _NameA;
        }
        string _NameE;
        public string NameE
        {
            set => _NameE = value;
            get => _NameE;
        }
        double _Factor;
        public double Factor
        {
            set => _Factor = value;
            get => _Factor;
        }
        bool _IsBasic;
        public bool IsBasic
        {
            set => _IsBasic = value;
            get => _IsBasic;
        }
        public string AddStr
        {
            get
            {
                string Returned = " insert into ERPMeasurementUnit (MeasurementID,MeasurementMain,MeasurementCode,MeasurementNameA,MeasurementNameE,MeasurementFactor,MeasurementIsBasic,UsrIns,TimIns) values (," + ID + "," + Main + ",'" + Code + "','" + NameA + "','" + NameE + "'," + Factor + "," + (IsBasic ? 1 : 0) + "," + SysData.CurrentUser.ID + ",GetDate() ) ";
                return Returned;
            }
        }
        public string EditStr
        {
            get
            {
                string Returned = " update ERPMeasurementUnit set " + "MeasurementID=" + ID + "" +
           ",MeasurementMain=" + Main + "" +
           ",MeasurementCode='" + Code + "'" +
           ",MeasurementNameA='" + NameA + "'" +
           ",MeasurementNameE='" + NameE + "'" +
           ",MeasurementFactor=" + Factor + "" +
           ",MeasurementIsBasic=" + (IsBasic ? 1 : 0) + "" + ",UsrUpd=" + SysData.CurrentUser.ID + @",TimUpd=GetDate()  where ";
                return Returned;
            }
        }
        public string DeleteStr
        {
            get
            {
                string Returned = " update ERPMeasurementUnit set Dis = GetDate() where  ";
                return Returned;
            }
        }
        public string SearchStr
        {
            get
            {
                string Returned = " select MeasurementID,MeasurementMain,MeasurementCode,MeasurementNameA,MeasurementNameE,MeasurementFactor,MeasurementIsBasic from ERPMeasurementUnit  ";
                return Returned;
            }
        }
        #endregion
        #region Private Method
        void SetData(DataRow objDr)
        {

            if (objDr.Table.Columns["MeasurementID"] != null)
                int.TryParse(objDr["MeasurementID"].ToString(), out _ID);

            if (objDr.Table.Columns["MeasurementMain"] != null)
                int.TryParse(objDr["MeasurementMain"].ToString(), out _Main);

            if (objDr.Table.Columns["MeasurementCode"] != null)
                _Code = objDr["MeasurementCode"].ToString();

            if (objDr.Table.Columns["MeasurementNameA"] != null)
                _NameA = objDr["MeasurementNameA"].ToString();

            if (objDr.Table.Columns["MeasurementNameE"] != null)
                _NameE = objDr["MeasurementNameE"].ToString();

            if (objDr.Table.Columns["MeasurementFactor"] != null)
                double.TryParse(objDr["MeasurementFactor"].ToString(), out _Factor);

            if (objDr.Table.Columns["MeasurementIsBasic"] != null)
                bool.TryParse(objDr["MeasurementIsBasic"].ToString(), out _IsBasic);
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