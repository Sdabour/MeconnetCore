using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;

using SharpVision.CRM.CRMDataBase;
using System.Data;


using SharpVision.COMMON.COMMONBusiness;
using SharpVision.COMMON.COMMONDataBase;
namespace SharpVision.CRM.CRMBusiness
{
    public class ServiceCol : CollectionBase
    {
        DataTable _ServiceTable;
        public ServiceCol(int intSysID)
        {
            ServiceDb objServiceDb = new ServiceDb();
            //objServiceDb.SysID = intSysID;
            DataTable dtService = objServiceDb.Search();

            DataRow[] arrDR = dtService.Select("ServiceID=ServiceParentID", "ServiceName");
            ServiceBiz objServiceBiz;
            foreach (DataRow DR in arrDR)
            {
                objServiceBiz = new ServiceBiz(DR);

                SetServiceChildren(ref objServiceBiz, ref dtService);
                this.Add(objServiceBiz);

            }

        }
       
        public ServiceCol(bool blIsEmpty)
        {
            if (!blIsEmpty)
            {
                ServiceDb objServiceDb = new ServiceDb();
               
                DataTable dtService = objServiceDb.Search();

                DataRow[] arrDR = dtService.Select("ServiceID=ServiceParentID", "ServiceName");
                ServiceBiz objServiceBiz;
                

                foreach (DataRow DR in arrDR)
                {
                    objServiceBiz = new ServiceBiz(DR);

                    SetServiceChildren(ref objServiceBiz, ref dtService);
                    this.Add(objServiceBiz);

                }

            }
            

        }
        public bool Contains(string strName)
        {
            bool blReturned = false;
            foreach (ServiceBiz objServiceBiz in this)
            {
                if (objServiceBiz.Name == strName)
                {
                    blReturned = true;
                    break;
                }
            }
            return blReturned;

        }

        public virtual ServiceBiz this[int intIndex]
        {
            get
            {
                return (ServiceBiz)this.List[intIndex];

            }
        }
        public virtual ServiceBiz this[string strIndex]
        {
            get
            {
                ServiceBiz Returned = new ServiceBiz();
                foreach (ServiceBiz objServiceBiz in this)
                {
                    if (objServiceBiz.Name == strIndex)
                    {
                        Returned = objServiceBiz.Copy();
                        break;
                    }
                }
                return Returned;
            }
        }


        #region Methods
        void SetServiceChildren(ref ServiceBiz objServiceBiz, ref DataTable dtService)
        {
            objServiceBiz.ServiceChildren = new ServiceCol(true);
            DataRow[] arrDR = dtService.Select("ServiceID <> ServiceParentID and ServiceParentID=" + objServiceBiz.ID, "ServiceName");
            ServiceBiz tempServiceBiz;
            ServiceCol objServiceCol;
            objServiceCol = new ServiceCol(true);
            foreach (DataRow DR in arrDR)
            {
                tempServiceBiz = new ServiceBiz(DR);
                SetServiceChildren(ref tempServiceBiz, ref dtService);
                tempServiceBiz.ParentBiz = objServiceBiz;
                objServiceCol.Add(tempServiceBiz);

            }
            objServiceBiz.ServiceChildren = objServiceCol;

        }
        #endregion

        public virtual void Add(ServiceBiz objServiceBiz)
        {
            this.List.Add(objServiceBiz);
        }

        public virtual void Add(ServiceCol objServiceCol)
        {
            foreach (ServiceBiz objServiceBiz in objServiceCol)
            {
                if (this[objServiceBiz.Name].ID == 0)
                    this.List.Add(objServiceBiz.Copy());

            }
        }

        public ServiceCol Copy()
        {
            ServiceCol Returned = new ServiceCol(true);
            foreach (ServiceBiz objTemp in this)
            {
                Returned.Add(objTemp.Copy());
            }
            return Returned;
        }
        public DataTable ServiceTable
        {
            get
            {
                return _ServiceTable;
            }
        }

        //public virtual void Add(ServiceBiz objServiceBiz)
        //{
        //    this.List.Add(objServiceBiz);
        //    _ServiceTable.Rows.Add(objServiceBiz.ServiceBizDR);


        //}

    }
}
