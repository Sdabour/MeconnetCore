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
    public class JobRequestQualificationDb
    {
        #region Private Data
        protected int _RequestID;
        protected int _QualificationOrder;
        protected string _QualificationDesc;
        protected string _JobRequestIDs;
        #endregion
        #region Constructors
        public JobRequestQualificationDb()
        {
        }
        public JobRequestQualificationDb(int intRequest)
        {
            _RequestID = intRequest;
            DataTable dtTemp = Search();
            DataRow objDR = dtTemp.Rows[0];
            SetData(objDR);
        }
        public JobRequestQualificationDb(DataRow objDR)
        {
            SetData(objDR);
        }
        
              
#endregion
        #region Public Properties

        public int RequestID
        {
            set { _RequestID = value; }
            get { return _RequestID; }
        }
        public int QualificationOrder
        {
            set { _QualificationOrder = value; }
            get { return _QualificationOrder; }
        }
        public string QualificationDesc
        {
            set { _QualificationDesc = value; }
            get { return _QualificationDesc; }
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
                string Returnstr = "  SELECT     HRJobRequestQualification.RequestID, HRJobRequestQualification.QualificationDesc, HRJobRequestQualification.QualificationOrder" +
                                   "  ,JobRequestTable.* FROM         HRJobRequestQualification" +
                                   "  Left outer join (" + JobRequestDb.SearchStr + ") JobRequestTable On HRJobRequestQualification.RequestID = JobRequestTable.RequestID";
                return Returnstr;
            }
        }
        public string AddStr
        {
            get
            {
                string Returnstr = " INSERT INTO HRJobRequestQualification " +
                                   " (RequestID, QualificationDesc, QualificationOrder)" +
                                   " VALUES ("+ _RequestID +",'"+ _QualificationDesc +"',"+ _QualificationOrder +") ";
                return Returnstr;
            }
        }        
        public string DeleteStr
        {
            get
            {
                string Returnstr = "DELETE FROM HRJobRequestQualification Where RequestID = "+ _RequestID +"";
                return Returnstr;
            }
        }
        #endregion
        #region Private Methods
        void SetData(DataRow objDR)
        {
            try
            {
                _RequestID = int.Parse(objDR["RequestID"].ToString());
                _QualificationOrder = int.Parse(objDR["QualificationOrder"].ToString());
                _QualificationDesc = objDR["QualificationDesc"].ToString();
            }
            catch (Exception Ex)
            {

            }
        }
        #endregion
        #region Public Methods
        public void Add()
        {
            SystemBase.SysData.SharpVisionBaseDb.ExecuteNonQuery(AddStr);
        }       
        public DataTable Search()
        {
            string strSql = SearchStr + " WHERE    (1=1)";
            if (_RequestID != 0)
                strSql = strSql + " and HRJobRequestQualification.RequestID = " + _RequestID;
            if (_JobRequestIDs != null && _JobRequestIDs != "")
            {
                strSql = strSql + " and HRJobRequestQualification.RequestID in (" + _JobRequestIDs + ") ";
            }
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        public void Delete()
        {            
            SysData.SharpVisionBaseDb.ExecuteNonQuery(DeleteStr);
        }
        #endregion
    }
}
