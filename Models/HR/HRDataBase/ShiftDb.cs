using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.UMS.UMSDataBase;
using SharpVision.SystemBase;
using System.Data;
using System.Data.SqlClient;
using SharpVision.Base.BaseDataBase;

namespace SharpVision.HR.HRDataBase
{
    public class ShiftDb : BaseSelfRelatedDb
    {
        #region Private Data
        protected DateTime _TimeIn;
        protected DateTime _TimeOut;
        protected int _ShiftType;
        protected bool _IsStop;
        protected int _IsStopSearch;
        #endregion
        #region Constructors
        public ShiftDb()
        {
        }
        public ShiftDb(DataRow objDr)
        {
            SetData(objDr);
        }
        public ShiftDb(int intID)
        {
            _ID = intID;
            if (_ID != 0)
            {
                DataTable dtTemp = Search();
                DataRow objDR = Search().Rows[0];
                SetData(objDR);
            }
        }
        #endregion
        #region Public Properties
        public DateTime TimeIn
        {
            set { _TimeIn = value; }
            get { return _TimeIn; }
        }
        public DateTime TimeOut
        {
            set { _TimeOut = value; }
            get { return _TimeOut; }
        }
        public int ShiftType
        {
            set { _ShiftType = value; }
            get { return _ShiftType; }
        }
        public bool IsStop
        {
            set { _IsStop = value; }
            get { return _IsStop; }
        }
        public int IsStopSearch
        {
            set { _IsStopSearch = value; }           
        }
        public string AddStr
        {
            get
            {
                double dlIn = _TimeIn.ToOADate() - 2;
                double dlOut = _TimeOut.ToOADate() - 2;
                int intIsStop = _IsStop ? 1 : 0;
                string Returned = " INSERT INTO HRShift" +
                                  " (ShiftNameA, ShiftNameE,TimeIn,TimeOut, ShiftType,IsStop,UsrIns, TimIns)" +
                                  " VALUES ('" + _NameA + "','" + _NameE + "'," + dlIn + "," + dlOut + "," + _ShiftType + "," + intIsStop + "," + SysData.CurrentUser.ID + ",GetDate())";
                return Returned;
            }
        }
        public string EditStr
        {
            get
            {
                double dlIn = _TimeIn.ToOADate() - 2;
                double dlOut = _TimeOut.ToOADate() - 2;
                int intIsStop = _IsStop ? 1 : 0;
                string Returned = " UPDATE    HRShift " +
                                  " SET ShiftNameA ='" + _NameA + "'" +
                                  ", ShiftNameE ='" + _NameE + "'" +
                                  ", TimeIn =" + dlIn + "" +
                                  ", TimeOut =" + dlOut + "" +
                                  ", ShiftType = "+ _ShiftType +"" +
                                  ", IsStop = " + intIsStop + "" +
                                  ", UsrUpd =" + SysData.CurrentUser.ID + ", TimUpd =GetDate()" +
                                  " WHERE     (ShiftID = " + _ID + ")";
                return Returned;
            }
        }
        public string DeleteStr
        {
            get
            {
                string Returned = " UPDATE    HRShift " +
                                " SET Dis =GetDate() " +
                                " WHERE     (ShiftID = " + _ID + ")";
                return Returned;
            }
        }
        public static string SearchStr
        {
            get
            {
                string Returned = " SELECT     HRShift.ShiftID, HRShift.ShiftNameA, HRShift.ShiftNameE,HRShift.TimeIn,HRShift.TimeOut ,"+
                                  " HRShift.ShiftType,HRShift.IsStop,ShiftTypeTable.*" +
                                  " FROM         HRShift "+
                                  " Inner join ("+ ShiftTypeDb.SearchStr +") as ShiftTypeTable On "+
                                  " ShiftTypeTable.ShiftTypeID = HRShift.ShiftType"; 
                return Returned;
            }
        }
        #endregion
        #region Private Methods
        void SetData(DataRow objDr)
        {
            if (objDr["ShiftID"].ToString() == "")
                return;
            _ID = int.Parse(objDr["ShiftID"].ToString());
            _NameA = objDr["ShiftNameA"].ToString();
            _NameE = objDr["ShiftNameE"].ToString();
            _TimeIn = DateTime.Parse(objDr["TimeIn"].ToString());
            _TimeOut = DateTime.Parse(objDr["TimeOut"].ToString());
            _ShiftType = int.Parse(objDr["ShiftType"].ToString());
            if (objDr["IsStop"].ToString() != "")
                _IsStop = bool.Parse(objDr["IsStop"].ToString());
        }
        #endregion
        #region Public Methods
        public override void Add()
        {
            _ID = SysData.SharpVisionBaseDb.InsertIdentityTable(AddStr);
        }
        public override void Edit()
        {
            SysData.SharpVisionBaseDb.ExecuteNonQuery(EditStr);
        }
        public override void Delete()
        {
            SysData.SharpVisionBaseDb.ExecuteNonQuery(DeleteStr);
        }
        public override DataTable Search()
        {
            string strSql = SearchStr + " Where Dis is Null ";
            if (_ShiftType != 0)
            {
                strSql += " And ShiftType = "+ _ShiftType +"";
            }
            if (_IsStopSearch != 0)
            {
                if (_IsStopSearch == 1)
                {
                    strSql += " And IsStop = 0";
                }
                else if (_IsStopSearch == 2)
                {
                    strSql += " And IsStop = 1";
                }
            }
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        #endregion
    }
}
