using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.UMS.UMSDataBase;
using SharpVision.SystemBase;
using System.Data;
using System.Data.SqlClient;
using SharpVision.Base.BaseDataBase;
using SharpVision.COMMON.COMMONDataBase;


namespace SharpVision.HR.HRDataBase
{
    public class JobRequestStageDb
    {
        #region Private Data
        private int _StageID;
        private int _StageRequest;
        private int _StageType;
        private int _StageOrder;
        private float _StageEstimationPerc;
        private string _StageDesc;
        private DateTime _StageDateFrom;
        private DateTime _StageDateTo;
        protected string _JobRequestIDs;
        #endregion
        #region Constructors
        public JobRequestStageDb()
        {
        }
        public JobRequestStageDb(DataRow objDR)
        {
            SetData(objDR);
        }
        #endregion
        #region Public Properties
        public int StageID
        {
            set
            {
                _StageID = value;
            }
            get
            {
                return _StageID;
            }
        }
        public int StageRequest
        {
            set
            {
                _StageRequest = value;
            }
            get
            {
                return _StageRequest;
            }
        }
        public int StageType
        {
            set
            {
                _StageType = value;
            }
            get
            {
                return _StageType;
            }
        }
        public int StageOrder
        {
            set
            {
                _StageOrder = value;
            }
            get
            {
                return _StageOrder;
            }
        }
        public float StageEstimationPerc
        {
            set
            {
                _StageEstimationPerc = value;
            }
            get
            {
                return _StageEstimationPerc;
            }
        }
        public string StageDesc
        {
            set
            {
                _StageDesc = value;
            }
            get
            {
                return _StageDesc;
            }
        }
        public DateTime StageDateFrom
        {
            set
            {
                _StageDateFrom = value;
            }
            get
            {
                return _StageDateFrom;
            }
        }
        public DateTime StageDateTo
        {
            set
            {
                _StageDateTo = value;
            }
            get
            {
                return _StageDateTo;
            }
        }
        public string JobRequestIDs
        {
            set
            {
                _JobRequestIDs = value;
            }
        }
        public static string SearchStr
        {
            get
            {
                string ReturnStr = " SELECT     HRJobRequestStage.StageID, HRJobRequestStage.StageRequest, HRJobRequestStage.StageType, HRJobRequestStage.StageDesc, HRJobRequestStage.StageOrder, " +
                                   " HRJobRequestStage.StageDateFrom,HRJobRequestStage.StageDateTo, HRJobRequestStage.StageEstimationPerc ,RequestStageTypeTable.*,JobRequestTable.*" +
                                   " FROM         HRJobRequestStage Left Outer join (" + JobRequestStageTypeDb.SearchStr + ") RequestStageTypeTable On HRJobRequestStage.StageType =  RequestStageTypeTable.StageTypeID " +
                                   " Left outer join (" + JobRequestDb.SearchStr + ") JobRequestTable On HRJobRequestStage.StageRequest = JobRequestTable.RequestID";

                return ReturnStr;
            }
        }
        public string AddStr
        {
            get
            {
                double dblStageDateFrom = _StageDateFrom.ToOADate() - 2;
                double dblStageDateTo = _StageDateTo.ToOADate() - 2;
                string ReturnStr = " INSERT INTO HRJobRequestStage " +
                      " (StageRequest, StageType," +
                      " StageDesc, StageOrder, StageDateFrom,StageDateTo," +
                      " StageEstimationPerc, UsrIns, TimIns)" +
                      " VALUES     " +
                      " (" + _StageRequest + "," + _StageType + "," +
                      " '" + _StageDesc + "'," + _StageOrder + "," + dblStageDateFrom + "," + dblStageDateTo + "," +
                      " " + _StageEstimationPerc + "," + SysData.CurrentUser.ID + ",GetDate())";

                return ReturnStr;
            }
        }
        public string EditStr
        {
            get
            {
                double dblStageDateFrom = _StageDateFrom.ToOADate() - 2;
                double dblStageDateTo = _StageDateTo.ToOADate() - 2;
                string ReturnStr = " UPDATE    HRJobRequestStage " +
                                   " SET  " +
                                   "  StageType =" + _StageType + "" +
                                   " , StageDesc ='" + _StageDesc + "'" +
                                   " , StageOrder =" + _StageOrder + "" +
                                   " , StageDateFrom =" + dblStageDateFrom + "" +
                                   " , StageDateTo =" + dblStageDateTo + "" +
                                   " , StageEstimationPerc =" + _StageEstimationPerc + "" +
                                   " , UsrUpd =" + SysData.CurrentUser.ID + ", TimUpd =GetDate()" +
                                   " Where StageRequest = " + _StageRequest + " And StageID = " + _StageID + "";
                return ReturnStr;
            }
        }
        public string DeleteStr
        {
            get
            {
                string ReturnStr = " DELETE FROM HRJobRequestStage Where 1=1 ";
                if (_StageID != 0)
                    ReturnStr += " And    (StageID = " + _StageID + ")";
                if (_StageRequest != 0)
                {
                    ReturnStr += " And StageRequest = " + _StageRequest + "";
                }
                return ReturnStr;
            }
        }
        #endregion
        #region Private Methods
        void SetData(DataRow objDR)
        {
            _StageID = int.Parse(objDR["StageID"].ToString());
            _StageRequest = int.Parse(objDR["StageRequest"].ToString());
            _StageType = int.Parse(objDR["StageType"].ToString());
            _StageOrder = int.Parse(objDR["StageOrder"].ToString());
            _StageEstimationPerc = int.Parse(objDR["StageEstimationPerc"].ToString());
            _StageDateFrom = DateTime.Parse(objDR["StageDateFrom"].ToString());
            _StageDateTo = DateTime.Parse(objDR["StageDateTo"].ToString());
            _StageDesc = objDR["StageDesc"].ToString();
        }

        #endregion
        #region Public Methods
        public void Add()
        {
            _StageID = SystemBase.SysData.SharpVisionBaseDb.InsertIdentityTable(AddStr);
        }
        public void Edit()
        {
            SysData.SharpVisionBaseDb.ExecuteNonQuery(EditStr);
        }
        public void Delete()
        {
            SysData.SharpVisionBaseDb.ExecuteNonQuery(DeleteStr);
        }
        public DataTable Search()
        {
            string strSql = SearchStr + " Where 1=1 ";
            if (_StageRequest != 0)
                strSql = strSql + " And HRJobRequestStage.StageRequest= " + _StageRequest + "";
            if (_JobRequestIDs != null && _JobRequestIDs != "")
            {
                strSql = strSql + " and HRJobRequestStage.StageRequest in (" + _JobRequestIDs + ") ";
            }
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        #endregion
    }
}
