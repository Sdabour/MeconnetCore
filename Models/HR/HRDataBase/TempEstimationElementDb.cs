using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SharpVision.SystemBase;
using System.Data;

namespace SharpVision.HR.HRDataBase
{
    public class TempEstimationElementDb
    {

        #region Constructor
        public TempEstimationElementDb()
        {
        }
        public TempEstimationElementDb(DataRow objDr)
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
        int _Applicant;
        public int Applicant
        {
            set
            {
                _Applicant = value;
            }
            get
            {
                return _Applicant;
            }
        }
        bool _IsFuzzy;
        public bool IsFuzzy
        {
            set
            {
                _IsFuzzy = value;
            }
            get
            {
                return _IsFuzzy;
            }
        }
        double _GradeValue;
        public double GradeValue
        {
            set
            {
                _GradeValue = value;
            }
            get
            {
                return _GradeValue;
            }
        }
        double _Weight;
        public double Weight
        { set => _Weight = value; get => _Weight; }
        public string AddStr
        {
            get
            {
                string Returned = " insert into HRTempEstimationElement (TempElementNameA,TempElementNameE,TempElementApplicant,TempElementIsFuzzy,TempElementGradeValue,TempElementWeight,UsrIns,TimIns) values ('" + NameA + "','" + NameE + "'," + Applicant + "," + (IsFuzzy ? 1 : 0) + "," + GradeValue+","+ _Weight + "," + SysData.CurrentUser.ID + ",GetDate() ) ";
                return Returned;
            }
        }
        public string EditStr
        {
            get
            {
                string Returned = " update HRTempEstimationElement set " + "TempElementID=" + ID + "" +
           ",TempElementNameA='" + NameA + "'" +
           ",TempElementNameE='" + NameE + "'" +
           ",TempElementApplicant=" + Applicant + "" +
           ",TempElementIsFuzzy=" + (IsFuzzy ? 1 : 0) + "" +
           ",TempElementGradeValue=" + GradeValue +
           ",TempElementWeight="+_Weight+
           "" + ",UsrUpd=" + SysData.CurrentUser.ID + @",TimUpd=GetDate()  where ";
                return Returned;
            }
        }
        public string DeleteStr
        {
            get
            {
                string Returned = " update HRTempEstimationElement set Dis = GetDate() where  ";
                return Returned;
            }
        }
        public string SearchStr
        {
            get
            {
                string Returned = " select TempElementID,TempElementNameA,TempElementNameE,TempElementApplicant,TempElementIsFuzzy,TempElementGradeValue,TempElementWeight from HRTempEstimationElement  ";
                return Returned;
            }
        }
        #endregion
        #region Private Method
        void SetData(DataRow objDr)
        {

            if (objDr.Table.Columns["TempElementID"] != null)
                int.TryParse(objDr["TempElementID"].ToString(), out _ID);

            if (objDr.Table.Columns["TempElementNameA"] != null)
                _NameA = objDr["TempElementNameA"].ToString();

            if (objDr.Table.Columns["TempElementNameE"] != null)
                _NameE = objDr["TempElementNameE"].ToString();

            if (objDr.Table.Columns["TempElementApplicant"] != null)
                int.TryParse(objDr["TempElementApplicant"].ToString(), out _Applicant);

            if (objDr.Table.Columns["TempElementIsFuzzy"] != null)
                bool.TryParse(objDr["TempElementIsFuzzy"].ToString(), out _IsFuzzy);

            if (objDr.Table.Columns["TempElementGradeValue"] != null)
                double.TryParse(objDr["TempElementGradeValue"].ToString(), out _GradeValue);
            if (objDr.Table.Columns["TempElementWeight"] != null)
                double.TryParse(objDr["TempElementWeight"].ToString(), out _Weight);
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
            string strSql = SearchStr + " where (1=1) ";

            if (_Applicant != 0)
                strSql += " and TempElementApplicant="+_Applicant;
            strSql += " order by TempElementID desc ";
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        #endregion
    }
}