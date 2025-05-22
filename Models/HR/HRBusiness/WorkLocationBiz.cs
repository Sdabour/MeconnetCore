using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.HR.HRDataBase;
using System.Data;
using SharpVision.UMS.UMSBusiness;
namespace SharpVision.HR.HRBusiness
{
    public class WorkLocationBiz
    {

        #region Constructor
        public WorkLocationBiz()
        {
            _LocationDb = new WorkLocationDb();
        }
        public WorkLocationBiz(DataRow objDr)
        {
            _LocationDb = new WorkLocationDb(objDr);
        }

        #endregion
        #region Private Data
        WorkLocationDb _LocationDb;
        #endregion
        #region Properties
        public int ID
        {
            set
            {
                _LocationDb.ID = value;
            }
            get
            {
                return _LocationDb.ID;
            }
        }
        public string Desc
        {
            set
            {
                _LocationDb.Desc = value;
            }
            get
            {
                return _LocationDb.Desc;
            }
        }
        public string CenterLong
        {
            set
            {
                _LocationDb.CenterLong = value;
            }
            get
            {
                return _LocationDb.CenterLong;
            }
        }
        public string CenterLat
        {
            set
            {
                _LocationDb.CenterLat = value;
            }
            get
            {
                return _LocationDb.CenterLat;
            }
        }
        public string PointLong
        {
            set
            {
                _LocationDb.PointLong = value;
            }
            get
            {
                return _LocationDb.PointLong;
            }
        }
        public string PointLat
        {
            set
            {
                _LocationDb.PointLat = value;
            }
            get
            {
                return _LocationDb.PointLat;
            }
        }
        #endregion
        #region Private Method

        #endregion
        #region Public Method 
        public void Add()
        {
            _LocationDb.Add();
        }
        public void Edit()
        {
            _LocationDb.Edit();
        }
        public void UploadLocation(string strPointType,string strLat,string strLong)
        {
            _LocationDb.CenterLat = strLat;
            _LocationDb.CenterLong = strLong;
            _LocationDb.PointLat = strLat;
            _LocationDb.PointLong = strLong;
            if (strPointType.ToLower() == "c")
                _LocationDb.EditCenter();
            else
                _LocationDb.EditPoint();
        }
        public void Delete()
        {
            _LocationDb.Delete();
        }
        #endregion
    }
}