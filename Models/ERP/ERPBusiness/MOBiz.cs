using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AlgorithmatENM.ERP.ERPDataBase;
using System.Data;

namespace AlgorithmatENM.ERP.ERPBusiness
{
    public enum MOStatus { Created,Processing,Paused,Canceled,Finished}
    public class MOBiz
    {

        #region Constructor
        public MOBiz()
        {
            _MODb = new MODb();
        }
        public MOBiz(DataRow objDr)
        {
            _MODb = new MODb(objDr);
        }

        #endregion
        #region Private Data
        MODb _MODb;
        #endregion
        #region Properties
        public int ID
        {
            set => _MODb.ID = value;
            get => _MODb.ID;
        }
        public string Ref
        {
            set => _MODb.Ref = value;
            get => _MODb.Ref;
        }
        public DateTime Date
        {
            set => _MODb.Date = value;
            get => _MODb.Date;
        }
        public DateTime StartTime
        {
            set => _MODb.StartTime = value;
            get => _MODb.StartTime;
        }
        public string Desc
        {
            set => _MODb.Desc = value;
            get => _MODb.Desc;
        }
        public double Quantity
        {
            set => _MODb.Quantity = value;
            get => _MODb.Quantity;
        }
        public int Responsible
        {
            set => _MODb.Responsible = value;
            get => _MODb.Responsible;
        }
        public int Status
        {
            set => _MODb.Status = value;
            get => _MODb.Status;
        }
        public DateTime StatusTime
        {
            set => _MODb.StatusTime = value;
            get => _MODb.StatusTime;
        }
        public int UserStarted { set => _MODb.UserStarted = value; get => _MODb.UserStarted; }
        public int BOM { set => _MODb.BOM = value; get => _MODb.BOM; }
        public int Product { set => _MODb.Product = value; get => _MODb.UserStarted; }
        public string UserStartedName
        {
            set => _MODb.UserStartedName = value;
            get => _MODb.UserStartedName;
        }
        public string ResponsibleName {
            set => _MODb.ResponsibleName = value;
            get => _MODb.ResponsibleName;
        }
        public string BOMName
        {
            set => _MODb.BOMName = value;
            get => _MODb.BOMName;
        }
        public string ProductName
        {
            set => _MODb.ProductName = value;
            get => _MODb.ProductName;
        }
        public static int MOEditStatus = 2320;

        #endregion
        #region Private Method

        #endregion
        #region Public Method 
        public void Add()
        {
            _MODb.Add();
        }
        public void AddUniqueRef()
        {
            _MODb.AddUniqueRef();
        }
        public void Edit()
        {
            _MODb.Edit();
        }
        public void Delete()
        {
            _MODb.Delete();
        }
        public void EditStatus(int intStatus, int intUser)
        {
            _MODb.Status = intStatus;
            _MODb.User = intUser;
            _MODb.EditStatus();
            
        }
        #endregion
    }
}
