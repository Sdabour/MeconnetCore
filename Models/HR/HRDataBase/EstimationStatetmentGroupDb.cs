using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpVision.SystemBase;
using System.Data;
namespace SharpVision.HR.HRDataBase
{
    public class EstimationStatetmentGroupDb
    {

        #region Constructor
        public EstimationStatetmentGroupDb()
        {
        }
        public EstimationStatetmentGroupDb(DataRow objDr)
        {
            SetData(objDr);
        }

        #endregion
        #region Properties
        int _StatementID;
        public int StatementID
        {
            set
            {
                _StatementID = value;
            }
            get
            {
                return _StatementID;
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
        public string AddStr
        {
            get
            {
                string Returned = " insert into HREstimationStatetmentGroup (StatementID,GroupElementID,GroupElementPerc,GroupElementOrder) values (" + StatementID + "," + _GroupElementID + "," + Perc + "," + Order + ") ";
                return Returned;
            }
        }
        public string EditStr
        {
            get
            {
                string Returned = " update HREstimationStatetmentGroup set " + "StatementID=" + StatementID + "" +
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
                string Returned = " update HREstimationStatetmentGroup set Dis = GetDate() where  ";
                return Returned;
            }
        }
        public string SearchStr
        {
            get
            {
                string Returned = @" select HREstimationStatetmentGroup.StatementID,HREstimationStatetmentGroup.GroupElementID,GroupElementPerc,GroupElementOrder
,GroupElementTable.* 
from HREstimationStatetmentGroup  
   inner join (" + new GroupElementDb().SearchStr + @") as GroupElementTable 
   on HREstimationStatetmentGroup.GroupElementID = GroupElementTable.GroupElementID ";
                return Returned;
            }
        }
        #endregion
        #region Private Method
        void SetData(DataRow objDr)
        {

            if (objDr.Table.Columns["StatementID"] != null)
                int.TryParse(objDr["StatementID"].ToString(), out _StatementID);

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
                strSql += " and dbo.HREstimationStatetmentGroup.StatementID="+_StatementID;
            if (_StatementID != 0)
                strSql += " and HREstimationStatetmentGroup.StatementID ="+_StatementID;
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        #endregion
    }
}
