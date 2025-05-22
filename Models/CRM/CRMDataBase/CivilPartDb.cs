using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using SharpVision.SystemBase;

namespace SharpVision.CRM.CRMDataBase
{
    public class CivilPartDb
    {

        #region Constructor
        public CivilPartDb()
        {
        }
        public CivilPartDb(DataRow objDr)
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
        int _Project;
        public int Project
        {
            set
            {
                _Project = value;
            }
            get
            {
                return _Project;
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
        string _Desc;
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
        bool _IsDelivered;
        public bool IsDelivered
        {
            set
            {
                _IsDelivered = value;
            }
            get
            {
                return _IsDelivered;
            }
        }
        DateTime _DeliveryDate;
        public DateTime DeliveryDate
        {
            set
            {
                _DeliveryDate = value;
            }
            get
            {
                return _DeliveryDate;
            }
        }
        string _ProjectCode;
        public string ProjectCode
        {
            set
            {
                _ProjectCode = value;
            }
            get
            {
                return _ProjectCode;
            }
        }
        string _ProjectNameA;
        public string ProjectNameA
        {
            set
            {
                _ProjectNameA = value;
            }
            get
            {
                return _ProjectNameA;
            }
        }
        string _ProjectNameE;
        public string ProjectNameE
        {
            set
            {
                _ProjectNameE = value;
            }
            get
            {
                return _ProjectNameE;
            }
        }
        public string AddStr
        {
            get
            {
                string Returned = " insert into CRMProjectCivilPart (PartProject,PartCode,PartDesc,PartIsDelivered,PartDeliveryDate,UsrIns,TimIns) values (" + Project + ",'" + Code + "','" + Desc + "'," + (IsDelivered ? 1 : 0) + "," + (DeliveryDate.ToOADate() - 2).ToString() + "," + SysData.CurrentUser.ID + ",GetDate() ) ";
                return Returned;
            }
        }
        public string EditStr
        {
            get
            {
                string Returned = " update CRMProjectCivilPart set  PartProject=" + Project + "" +
           ",PartCode='" + Code + "'" +
           ",PartDesc='" + Desc + "'" +
           ",PartIsDelivered=" + (IsDelivered ? 1 : 0) + "" +
           ",PartDeliveryDate=" + (DeliveryDate.ToOADate() - 2).ToString() + "" +
           ",UsrUpd=" + SysData.CurrentUser.ID + @",TimUpd=GetDate()  where PartID=" + ID ;
                return Returned;
            }
        }
        public string DeleteStr
        {
            get
            {
                string Returned = " update CRMProjectCivilPart set Dis = GetDate() where  ";
                return Returned;
            }
        }
        public string SearchStr
        {
            get
            {
                string Returned = @" SELECT dbo.CRMProjectCivilPart.PartID, dbo.CRMProjectCivilPart.PartProject, dbo.CRMProjectCivilPart.PartCode, dbo.CRMProjectCivilPart.PartDesc, dbo.CRMProjectCivilPart.PartIsDelivered, dbo.CRMProjectCivilPart.PartDeliveryDate, 
dbo.CRMProjectCivilPart.PartOrder,
                  PartProjectTable.PartProjectCode, PartProjectTable.PartProjectNameA, PartProjectTable.PartProjectNameE
FROM     dbo.CRMProjectCivilPart INNER JOIN
                      (SELECT ProjectID AS PartProjectID, ProjectCode AS PartProjectCode, ProjectNameA AS PartProjectNameA, ProjectNameE AS PartProjectNameE
                       FROM      dbo.CRMProject) AS PartProjectTable ON dbo.CRMProjectCivilPart.PartProject = PartProjectTable.PartProjectID ";
                return Returned;
            }
        }
        #endregion
        #region Private Method
        void SetData(DataRow objDr)
        {

            if (objDr.Table.Columns["PartID"] != null)
                int.TryParse(objDr["PartID"].ToString(), out _ID);

            if (objDr.Table.Columns["PartProject"] != null)
                int.TryParse(objDr["PartProject"].ToString(), out _Project);

            if (objDr.Table.Columns["PartCode"] != null)
                _Code = objDr["PartCode"].ToString();

            if (objDr.Table.Columns["PartDesc"] != null)
                _Desc = objDr["PartDesc"].ToString();

            if (objDr.Table.Columns["PartIsDelivered"] != null)
                bool.TryParse(objDr["PartIsDelivered"].ToString(), out _IsDelivered);

            if (objDr.Table.Columns["PartDeliveryDate"] != null)
                DateTime.TryParse(objDr["PartDeliveryDate"].ToString(), out _DeliveryDate);

            if (objDr.Table.Columns["PartProjectCode"] != null)
                _ProjectCode = objDr["PartProjectCode"].ToString();

            if (objDr.Table.Columns["PartProjectNameA"] != null)
                _ProjectNameA = objDr["PartProjectNameA"].ToString();

            if (objDr.Table.Columns["PartProjectNameE"] != null)
                _ProjectNameE = objDr["PartProjectNameE"].ToString();
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
            string strSql = SearchStr + " where CRMProjectCivilPart.Dis is null ";


            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        #endregion
    }
}
