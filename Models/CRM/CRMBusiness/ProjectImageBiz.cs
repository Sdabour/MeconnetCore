using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.CRM.CRMDataBase;
using System.Data;
using System.Collections;
using SharpVision.COMMON.COMMONBusiness;
using SharpVision.COMMON.COMMONDataBase;
using SharpVision.Base.BaseBusiness;
using SharpVision.RP.RPBusiness;

namespace SharpVision.CRM.CRMBusiness
{
    public class ProjectImageBiz
    {
        #region Private Data
        ProjectImageDb _ProjectImageDb;
        #endregion

        #region Constractors
        public ProjectImageBiz()
        {
            _ProjectImageDb = new ProjectImageDb();
        }
        public ProjectImageBiz(int intID)
        {
            _ProjectImageDb = new ProjectImageDb(intID);
        }
        public ProjectImageBiz(DataRow objDR)
        {
            _ProjectImageDb = new ProjectImageDb(objDR);
        }
        #endregion

        #region Public Accessorice
        public int ID
        {
            set
            {
                _ProjectImageDb.ID = value;
            }
            get
            {
                return _ProjectImageDb.ID;
            }
        }
        public string Desc
        {
            set
            {
                _ProjectImageDb.Desc = value;
            }
            get
            {
                return _ProjectImageDb.Desc;
            }
        }
        public int Order
        {
            set
            {
                _ProjectImageDb.Order = value;
            }
            get
            {
                return _ProjectImageDb.Order;
            }
        }
        public int ProjectID
        {
            set
            {
                _ProjectImageDb.ProjectID = value;
            }
            get
            {
                return _ProjectImageDb.ProjectID;
            }
        }
        #endregion

        #region Private Methods
        public void Add()
        {
            _ProjectImageDb.Add();
        }
        public void Edit()
        {
            _ProjectImageDb.Edit();
        }
        public void Delete()
        {
            _ProjectImageDb.Delete();
        }
        #endregion


    }
}
