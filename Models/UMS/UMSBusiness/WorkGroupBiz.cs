using System;
using System.Collections.Generic;
using System.Text;

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.Base.BaseBusiness;
using SharpVision.UMS.UMSDataBase;


namespace SharpVision.UMS.UMSBusiness
{
    public enum WorkGroupType
    {
        NotSepcified,
        Administration,
        Project,
        Sales,
        Marketing
    }
    public class WorkGroupBiz : BaseSingleBiz
    {

        #region Private Data
        EmployeeCol _EmployeeCol;
        #endregion

        #region Constractors
        public WorkGroupBiz()
        {
            _BaseDb = new WorkGroupDb();
        }
        public WorkGroupBiz(int intID)
        {
            // _BaseDb = new WorkGroupDb(intID);
        }
        public WorkGroupBiz(DataRow objDR)
        {
            _BaseDb = new WorkGroupDb(objDR);
        }
        #endregion

        #region Public Accessorice
        public WorkGroupType Type
        {
            set
            {
                ((WorkGroupDb)_BaseDb).Type = (int)value;
            }
            get
            {
                return (WorkGroupType)((WorkGroupDb)_BaseDb).Type;
            }
        }
        public int VisitRangeStart
        {
            set => ((WorkGroupDb)_BaseDb).VisitRangeStart = value;
            get => ((WorkGroupDb)_BaseDb).VisitRangeStart;
        }
        public int VisitRangeEnd
        {
            set => ((WorkGroupDb)_BaseDb).VisitRangeEnd = value;
            get => ((WorkGroupDb)_BaseDb).VisitRangeEnd;
        }
        public EmployeeCol EmployeeCol
        {
            set
            {
                _EmployeeCol = value;
            }
            get
            {
                if (_EmployeeCol == null)
                {
                    _EmployeeCol = new EmployeeCol(true);
                    WorkGroupDb objDb = new WorkGroupDb();
                    objDb.ID = ID;
                    DataTable dtTemp = objDb.GetWorkGroupEmployee();
                    foreach (DataRow objDr in dtTemp.Rows)
                    {
                        _EmployeeCol.Add(new EmployeeBiz(objDr));
                    }

                }
                return _EmployeeCol;
            }
        }
        public static List<string> WorkGroupTypeStrArr
        {
            get
            {
                List<string> Returned = new List<string>();
                //          NotSepcified,
                Returned.Add("€Ì— „Õœœ");
                //Administration,
                Returned.Add("«œ«—…");
                //Project,
                Returned.Add("„‘«—Ì⁄");
                //Sales,
                Returned.Add("„»Ì⁄« ");
                //Marketing
                Returned.Add(" ”ÊÌﬁ");
                return Returned;
            }
        }
        SingleClassCol _VisitTypeCol;
        public SingleClassCol VisitTypeCol
        {
            set
            {
                _VisitTypeCol = value;
            }
            get
            {
                if (_VisitTypeCol == null)
                {
                    _VisitTypeCol = new SingleClassCol();
                    if (ID != 0)
                        _VisitTypeCol = WorkGroupCol.GetVisitTypeCol(ID);
                }
                return _VisitTypeCol;
            }
        }
        #endregion

        #region Private Methods
        #endregion

        #region Public Methods
        public void Add()
        {
            ((WorkGroupDb)_BaseDb).EmployeeTble = EmployeeCol.GetTable();
            ((WorkGroupDb)_BaseDb).VisitTypeIDs = VisitTypeCol.IDsStr;
            ((WorkGroupDb)_BaseDb).Add();
        }
        public void Edit()
        {
            ((WorkGroupDb)_BaseDb).EmployeeTble = EmployeeCol.GetTable();
            ((WorkGroupDb)_BaseDb).VisitTypeIDs = VisitTypeCol.IDsStr;
            ((WorkGroupDb)_BaseDb).Edit();
        }
        public void Delete()
        {
            ((WorkGroupDb)_BaseDb).Delete();
        }
        #endregion

    }
}
