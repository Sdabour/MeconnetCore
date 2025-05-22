using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using SharpVision.SystemBase;
namespace SharpVision.HR.HRBusiness
{
    public class SubSectorSimple
    {
        public SubSectorSimple()
        {
           
        }
        public SubSectorSimple(DataRow objDr)
        {
            SetData(objDr);
        }
        int _ID;
        public int ID { set => _ID = value; get => _ID; }
        string _SectorName;
        public string SectorName { set => _SectorName = value; get => _SectorName; }
        string _BranchName;
        public string BranchName { set => _BranchName = value; get => _BranchName; }
        static List<SubSectorSimple> _SubSectorLst;
        public static List<SubSectorSimple> SubSectorLst
        {
            get
            {
                if(_SubSectorLst== null)
                {
                    _SubSectorLst = new List<SubSectorSimple>();
                    DataTable dtTemp = new SubSectorSimple().SearchSubSectorDb();
                    foreach (DataRow objDr in dtTemp.Rows)
                        _SubSectorLst.Add(new SubSectorSimple(objDr));
                }
                return _SubSectorLst;

            }
        }
        public void SetData(DataRow objDr)
        {
            if (objDr.Table.Columns["SubSectorID"] != null)
                int.TryParse(objDr["SubSectorID"].ToString(), out _ID);
            if (objDr.Table.Columns["SectorNameA"] != null)
              _SectorName =  objDr["SectorNameA"].ToString() ;
            if (objDr.Table.Columns["BranchNameA"] != null)
                _BranchName = objDr["BranchNameA"].ToString();

        }
      public DataTable SearchSubSectorDb()
        {
            string strSql = @"SELECT dbo.HRSubSector.SubSectorID, dbo.HRSector.SectorNameA, dbo.HRBranch.BranchNameA
FROM     dbo.HRBranch INNER JOIN
                  dbo.HRSubSectorBranch ON dbo.HRBranch.BranchID = dbo.HRSubSectorBranch.BranchID INNER JOIN
                  dbo.HRSubSector INNER JOIN
                  dbo.HRSector ON dbo.HRSubSector.SectorID = dbo.HRSector.SectorID ON dbo.HRSubSectorBranch.SubSectorID = dbo.HRSubSector.SubSectorID INNER JOIN
                  dbo.HRSectorType ON dbo.HRSector.SectorType = dbo.HRSectorType.SectorTypeID ";
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
    }
}