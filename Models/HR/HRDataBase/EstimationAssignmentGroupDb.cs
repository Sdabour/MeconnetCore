using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpVision.SystemBase;
using System.Data;
namespace SharpVision.HR.HRDataBase
{
    public class EstimationAssignmentGroupDb
    {

        #region Constructor
        public EstimationAssignmentGroupDb()
        {
        }
        public EstimationAssignmentGroupDb(DataRow objDr)
        {
            SetData(objDr);
        }

        #endregion
        #region Properties
        int _AssignmentID;
        public int AssignmentID
        {
            set
            {
                _AssignmentID = value;
            }
            get
            {
                return _AssignmentID;
            }
        }
        int _GroupElementID;
        public int GroupElementID
        {
            set
            {
                _GroupElementID = value;
            }
            get
            {
                return _GroupElementID;
            }
        }
        double _Perc;
        public double Perc
        {
            set
            {
                _Perc = value;
            }
            get
            {
                return _Perc;
            }
        }
        int _Order;
        public int Order
        {
            set
            {
                _Order = value;
            }
            get
            {
                return _Order;
            }
        }
        string _AssignmentIDs;
        public string AssignmentIDs
        { set => _AssignmentIDs = value; }
        public string AddStr
        {
            get
            {
                string Returned = " insert into HREstimationAssignmentGroupElement (AssignmentID,GroupElementID,GroupElementPerc,GroupElementOrder) values (" + AssignmentID + "," + _GroupElementID + "," + Perc + "," + Order + ") ";
                return Returned;
            }
        }
        public string EditStr
        {
            get
            {
                string Returned = " update HREstimationAssignmentGroup set " + "AssignmentID=" + AssignmentID + "" +
           ",GroupElementID=" + _GroupElementID + "" +
           ",GroupElementPerc=" + Perc + "" +
           ",GroupElementOrder=" + Order + "" + ",UsrUpd=" + SysData.CurrentUser.ID + @",TimUpd=GetDate()  where ";
                return Returned;
            }
        }
        public string DeleteStr
        {
            get
            {
                string Returned = " update HREstimationAssignmentGroup set Dis = GetDate() where  ";
                return Returned;
            }
        }
        public string SearchStr
        {
            get
            {
                string Returned = @" select HREstimationAssignmentGroupElement.AssignmentID,HREstimationAssignmentGroupElement.GroupElementID,GroupElementPerc,GroupElementOrder
,GroupElementTable.* 
from HREstimationAssignmentGroupElement  
   inner join (" + new GroupElementDb().SearchStr + @") as GroupElementTable 
   on HREstimationAssignmentGroupElement.GroupElementID = GroupElementTable.GroupElementID ";
                return Returned;
            }
        }
        #endregion
        #region Private Method
        void SetData(DataRow objDr)
        {

            if (objDr.Table.Columns["AssignmentID"] != null)
                int.TryParse(objDr["AssignmentID"].ToString(), out _AssignmentID);

            if (objDr.Table.Columns["GroupElementID"] != null)
                int.TryParse(objDr["GroupElementID"].ToString(), out _GroupElementID);

            if (objDr.Table.Columns["GroupElementPerc"] != null)
                double.TryParse(objDr["GroupElementPerc"].ToString(), out _Perc);

            if (objDr.Table.Columns["GroupElementOrder"] != null)
                int.TryParse(objDr["GroupElementOrder"].ToString(), out _Order);
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
            if (_GroupElementID != 0)
                strSql += " and dbo.HREstimationAssignmentGroupElement.AssignmentID=" + _AssignmentID;
            if (_AssignmentID != 0)
                strSql += " and HREstimationAssignmentGroupElement.AssignmentID =" + _AssignmentID;
            if (_AssignmentIDs != null && _AssignmentIDs!= "")
                strSql += " and HREstimationAssignmentGroupElement.AssignmentID in (" + _AssignmentIDs+")";
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        #endregion
    }
}
