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
    public class ElementDb : BaseSelfRelatedDb
    {
        #region Private Data
        double _ElementValue;
        double _ElementEstimation;
        string _ElementIDs;
        int _Group;
        public int Group
        {
            set => _Group = value;
            get => _Group;
        }
        string _GroupIDs;
        public string GroupIDs
        { set => _GroupIDs = value; }
        #endregion
        #region Constructors
        public ElementDb()
        {
        }
        public ElementDb(DataRow objDr)
        {
            SetData(objDr);
        }
        public ElementDb(int intID)
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
        public double ElementValue { set { _ElementValue = value; } get { return _ElementValue; } }
        public double ElementEstimation { set { _ElementEstimation = value; } get { return _ElementEstimation; } }
        bool _IsFuzzy;
        public bool IsFuzzy
        {
            set => _IsFuzzy= value;
            get => _IsFuzzy;
        }
        public string ElementIDs { set { _ElementIDs = value; } }
        public string AddStr
        {
            get
            {

                string Returned = " INSERT INTO HRElement" +
                                  " (ElementGroup,ElementNameA, ElementNameE,GradeValue,ElementEstimation, UsrIns, TimIns)" +
                                  " VALUES (" + _Group + ",'" + _NameA + "','" + _NameE + "'," + _ElementValue + "," + _ElementEstimation + "," + SysData.CurrentUser.ID + ",GetDate())";
                return Returned;
            }
        }
        public string EditStr
        {
            get
            {


                string Returned = " UPDATE    HRElement " +
                                  " SET ElementGroup = " + _Group +
                                  ", ElementNameA ='" + _NameA + "'" +
                                  ", ElementNameE ='" + _NameE + "'" +
                                  ", GradeValue = " + _ElementValue + "" +
                                  ", ElementEstimation = " + _ElementEstimation + "" +
                                  ", UsrUpd =" + SysData.CurrentUser.ID + ", TimUpd =GetDate()" +
                                  " WHERE     (ElementID = " + _ID + ")";
                return Returned;
            }
        }
        public string DeleteStr
        {
            get
            {
                string Returned = " UPDATE    HRElement " +
                                " SET Dis =GetDate() " +
                                " WHERE     (ElementID = " + _ID + ")";
                return Returned;
            }
        }
        public static string SearchStr
        {
            get
            {
                string Returned = "SELECT     HRElement.ElementID, HRElement.ElementGroup ,HRElement.ElementNameA, HRElement.ElementNameE,HRElement.GradeValue,HRElement.ElementEstimation,HRElement.ElementIsFuzzy  ,GroupTable.* FROM         HRElement " +
                    "left outer join (" + new GroupElementDb().SearchStr + @") as GroupTable 
on HRElement.ElementGroup = GroupTable.GroupElementID ";
                return Returned;
            }
        }
        #endregion
        #region Private Methods
        void SetData(DataRow objDr)
        {
            if (objDr["ElementID"].ToString() == "")
                return;
            _ID = int.Parse(objDr["ElementID"].ToString());
            _NameA = objDr["ElementNameA"].ToString();
            _NameE = objDr["ElementNameE"].ToString();
            if (objDr["GradeValue"].ToString() != "")
                _ElementValue = double.Parse(objDr["GradeValue"].ToString());
            if (objDr["ElementEstimation"].ToString() != "")
                _ElementEstimation = double.Parse(objDr["ElementEstimation"].ToString());
            if (objDr.Table.Columns["GroupElementID"] != null && objDr["GroupElementID"].ToString() != "")
                int.TryParse(objDr["GroupElementID"].ToString(), out _Group);
            if(objDr.Table.Columns["ElementIsFuzzy"]!= null)
            bool.TryParse(objDr["ElementIsFuzzy"].ToString(), out _IsFuzzy);
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
            SysData.SharpVisionBaseDb.ExecuteNonQuery(EditStr);
        }
        public override DataTable Search()
        {
            string strSql = SearchStr + " Where Dis is Null ";
            if (_ID != 0)
            {
                strSql += " And ElementID =" + _ID + "";
            }
            if (_ElementIDs != null && _ElementIDs != "")
            {
                strSql += " And ElementID in (" + _ElementIDs + ")";
            }
            if (_GroupIDs != null && _GroupIDs != "")
                strSql += " and ElementGroup in (" + _GroupIDs + ") ";
            strSql += " Order by ElementID ";
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        #endregion
    }
}
