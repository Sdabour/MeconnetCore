using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.SystemBase;
using System.Data;
using System.Data.SqlClient;
using SharpVision.COMMON.COMMONDataBase;
using SharpVision.Base.BaseDataBase;
using SharpVision.RP.RPDataBase;

namespace SharpVision.CRM.CRMDataBase
{
    public class ProjectDb : BaseSingleDb
    {

        #region Private Data
        protected DateTime _ReservationStartDate;
        protected DateTime _ReservationStopDate;
        protected DateTime _ContractingStartDate;
        int _CellID;

        public int CellID
        {
            get { return _CellID; }
            set { _CellID = value; }
        }
        string _Desc;

        public string Desc
        {
            get { return _Desc; }
            set { _Desc = value; }
        }
        string _PostalCode;

        public string PostalCode
        {
            get { return _PostalCode; }
            set { _PostalCode = value; }
        }
        int _City;

        public int City
        {
            get { return _City; }
            set { _City = value; }
        }
        string _License;

        public string License
        {
            get { return _License; }
            set { _License = value; }
        }
        protected int _Logo;
        int _Layout;

        public int Layout
        {
            get { return _Layout; }
            set { _Layout = value; }
        }
        string _ProfitCenter;

        public string ProfitCenter
        {
            get { return _ProfitCenter; }
            set { _ProfitCenter = value; }
        }
        string _WBS;

        public string WBS
        {
            get { return _WBS; }
            set { _WBS = value; }
        }
        bool _StartDateDecided;

        public bool StartDateDecided
        {
            get { return _StartDateDecided; }
            set { _StartDateDecided = value; }
        }
        bool _StopDateDecided;

        public bool StopDateDecided
        {
            get { return _StopDateDecided; }
            set { _StopDateDecided = value; }
        }
        bool _ContractingStartDateDecided;

        public bool ContractingStartDateDecided
        {
            get { return _ContractingStartDateDecided; }
            set { _ContractingStartDateDecided = value; }
        }
        #endregion

        #region Constractors
        public ProjectDb()
        {

        }
        public ProjectDb(int intID)
        {
            _ID = intID;
            DataTable dtTemp = Search();
            DataRow objDR = dtTemp.Rows[0];
            if (objDR.Table.Columns["ProjectNameA"] != null && objDR["ProjectNameA"].ToString() != "")
                _NameA = objDR["ProjectNameA"].ToString();
            _NameE = objDR["ProjectNameE"].ToString();
            if (objDR["ProjectCell"].ToString() != "")
                _CellID = int.Parse(objDR["ProjectCell"].ToString());
            _Code = objDR["ProjectCode"].ToString();
            if (objDR.Table.Columns["ProjectReservationStartDate"] != null && objDR["ProjectReservationStartDate"].ToString() != "")
            {
                _ReservationStartDate = DateTime.Parse(objDR["ProjectReservationStartDate"].ToString());
                _StartDateDecided = true;
            }
            if (objDR.Table.Columns["ProjectReservationStopDate"] != null &&
                objDR["ProjectReservationStopDate"].ToString() != null)
            {
                _ReservationStopDate = DateTime.Parse(objDR["ProjectReservationStopDate"].ToString());
                _StopDateDecided = true;
            }
            if (objDR.Table.Columns["ProjectContractingStartDate"] != null &&
                objDR["ProjectContractingStartDate"].ToString() != "")
            {
                _ContractingStartDateDecided = true;

                _ContractingStartDate = DateTime.Parse(objDR["ProjectContractingStartDate"].ToString());
            }
            if (objDR.Table.Columns["ProjectLogo"] != null && objDR["ProjectLogo"] != "")
                _Logo = int.Parse(objDR["ProjectLogo"].ToString());

        }
        public ProjectDb(DataRow objDR)
        {
            SetData(objDR);
        }
        #endregion

        #region Public Accessorice
        public DateTime ReservationStartDate
        {
            set
            {
                _ReservationStartDate = value;
            }
            get
            {
                return _ReservationStartDate;
            }
        }
        public DateTime ReservationStopDate
        {
            set
            {
                _ReservationStopDate = value;
            }
            get
            {
                return _ReservationStopDate;
            }
        }
        public DateTime ContractingStartDate
        {
            set
            {
                _ContractingStartDate = value;
            }
            get
            {
                return _ContractingStartDate;
            }
        }
        public int Logo
        {
            set
            {
                _Logo = value;
            }
            get
            {
                return _Logo;
            }
        }

        public static string SearchStr
        {
            get
            {
                string strProjectUnit = @"select distinct ROProjectCode  from MNRO ";
                string Returned = "SELECT        ProjectID, ProjectCell, ProjectCode, ProjectNameA, ProjectNameE, ProjectLogo,ProjectLayout, ProjectPostalCode, ProjectCity, ProjectLicense, ProjectProfitCenter, ProjectWbsCode, " +
                          " ProjectReservationStartDate, ProjectReservationStopDate, ProjectContractingStartDate " +
                         @" FROM            dbo.CRMProject  ";
  //              " inner join (" + strProjectUnit + @") as ROProjectTable
  //on CRMProject.ProjectCode = ROProjectTable.ROProjectCode ";

                return Returned;
            }
        }
        #endregion

        #region Private Methods
        void SetData(DataRow Objdr)
        {
            if (Objdr.Table.Columns["ProjectID"] != null && Objdr["ProjectID"].ToString() != "")
                _ID = int.Parse(Objdr["ProjectID"].ToString());
            if (Objdr.Table.Columns["ProjectCell"] != null && Objdr["ProjectCell"].ToString() != "")
                _CellID = int.Parse(Objdr["ProjectCell"].ToString());

            if (Objdr.Table.Columns["ProjectCode"] != null && Objdr["ProjectCode"].ToString() != "")
                _Code = Objdr["ProjectCode"].ToString();

            if (Objdr.Table.Columns["ProjectNameA"] != null && Objdr["ProjectNameA"].ToString() != "")
                _NameA = Objdr["ProjectNameA"].ToString();
            if (Objdr.Table.Columns["ProjectNameE"] != null && Objdr["ProjectNameE"].ToString() != "")
                _NameE = Objdr["ProjectNameE"].ToString();

            if (Objdr.Table.Columns["ProjectLogo"] != null && Objdr["ProjectLogo"].ToString() != "")
                _Logo = int.Parse(Objdr["ProjectLogo"].ToString());

            if (Objdr.Table.Columns["ProjectPostalCode"] != null && Objdr["ProjectPostalCode"].ToString() != "")
                _PostalCode = Objdr["ProjectPostalCode"].ToString();
            if (Objdr.Table.Columns["ProjectCity"] != null && Objdr["ProjectCity"].ToString() != "")
                _City = int.Parse(Objdr["ProjectCity"].ToString());

            if (Objdr.Table.Columns["ProjectLicense"] != null && Objdr["ProjectLicense"].ToString() != "")
                _License = Objdr["ProjectLicense"].ToString();

            if (Objdr.Table.Columns["ProjectProfitCenter"] != null && Objdr["ProjectProfitCenter"].ToString() != "")
                _ProfitCenter = Objdr["ProjectProfitCenter"].ToString();
            if (Objdr.Table.Columns["ProjectWbsCode"] != null && Objdr["ProjectWbsCode"].ToString() != "")
                _WBS = Objdr["ProjectWbsCode"].ToString();
            if (Objdr.Table.Columns["ProjectReservationStartDate"] != null && Objdr["ProjectReservationStartDate"].ToString() != "")
            {
                _ReservationStartDate = DateTime.Parse(Objdr["ProjectReservationStartDate"].ToString());
                _StartDateDecided = true;

            }
            if (Objdr.Table.Columns["ProjectReservationStopDate"] != null && Objdr["ProjectReservationStopDate"].ToString() != "")
            {
                _ReservationStopDate = DateTime.Parse(Objdr["ProjectReservationStopDate"].ToString());
                _StopDateDecided = true;

            }
            if (Objdr.Table.Columns["ProjectContractingStartDate"] != null && Objdr["ProjectContractingStartDate"].ToString() != "")
            {
                _ContractingStartDate = DateTime.Parse(Objdr["ProjectContractingStartDate"].ToString());
                _ContractingStartDateDecided = true;

            }
            if (Objdr.Table.Columns["ProjectLayout"] != null && Objdr["ProjectLayout"].ToString() != "")
                _Layout = int.Parse(Objdr["ProjectLayout"].ToString());
        }
        #endregion

        #region Public Methods
        public override void Add()
        {
            double dblReservationStartDate = _ReservationStartDate.ToOADate() - 2;
            double dblReservationStopDate = _ReservationStopDate.ToOADate() - 2;
            double dblContractingStartDate = _ContractingStartDate.ToOADate() - 2;
            string strReservationStartDate = _StartDateDecided ? dblReservationStartDate.ToString() : "NULL";
            string strContractingStartDate = _ContractingStartDateDecided ? dblContractingStartDate.ToString() : "NULL";
            string strReservationStopDate = _StopDateDecided ? dblReservationStopDate.ToString() : "NULL";

            string strSql = " INSERT INTO CRMProject " +
                            " (   ProjectCell, ProjectCode, ProjectNameA, ProjectNameE, ProjectLogo, ProjectLayout" +
                            ", ProjectPostalCode, ProjectCity, ProjectLicense, ProjectProfitCenter, " +
                           " ProjectWbsCode, ProjectReservationStartDate, ProjectReservationStopDate" +
                           ", ProjectContractingStartDate, UsrIns, TimIns, IPIns)" +
                            " VALUES     (" + _CellID + ",'" + _Code + "','" + _NameA + "','" + _NameE + "'," +
                            _Logo + "," + _Layout + ",'" + _PostalCode + "'," + _City +
                            ",'" + _License + "','" + _ProfitCenter + "','" + _WBS + "'," +
                            strReservationStartDate + "," + strReservationStopDate + "," +
                            strContractingStartDate + "," + SysData.CurrentUser.ID + ",GetDate(),'" + SysData.IP + "')";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }

        public override void Edit()
        {
            double dblReservationStartDate = _ReservationStartDate.ToOADate() - 2;
            double dblReservationStopDate = _ReservationStopDate.ToOADate() - 2;
            double dblContractingStartDate = _ContractingStartDate.ToOADate() - 2;

            string strReservationStartDate = _StartDateDecided ? dblReservationStartDate.ToString() : "NULL";
            string strContractingStartDate = _ContractingStartDateDecided ? dblContractingStartDate.ToString() : "NULL";
            string strReservationStopDate = _StopDateDecided ? dblReservationStopDate.ToString() : "NULL";

            string strSql = " UPDATE    CRMProject" +
                            " SET   ProjectReservationStartDate =" + strReservationStartDate + "" +
                            " , ProjectReservationStopDate =" + strReservationStopDate + "" +
                            " , ProjectContractingStartDate = " + strContractingStartDate + "" +
                            " , ProjectLogo = " + _Logo + "" +
                            ",ProjectLayout=" + _Layout +
                            " where ProjectID=" + _ID;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public void EditLayOut()
        {
            string strSql = " UPDATE    CRMProject" +
                                   " SET ProjectLayout = " + _Layout + "" +
                                   " where ProjectID = " + _ID;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public override void Delete()
        {
            //throw new Exception("The method or operation is not implemented.");
        }
        public override DataTable Search()
        {
            string strSql = SearchStr + " Where 1 = 1 ";
            if (_ID != 0)
                strSql = strSql + " and  RPCell.CellID = " + _ID + "";
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        #endregion

    }
}
