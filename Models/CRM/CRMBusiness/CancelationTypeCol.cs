using System;
using System.Collections.Generic;
using System.Text;
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.Base.BaseBusiness;
using SharpVision.CRM.CRMDataBase;
using SharpVision.SystemBase;

namespace SharpVision.CRM.CRMBusiness
{
    public class CancelationTypeCol : BaseCol
    {
        public CancelationTypeCol(bool blIsEmpty)
        {
            if (blIsEmpty)
                return;
            CancelationTypeDb objDb = new CancelationTypeDb();

            DataTable dtTemp = objDb.Search();
            CancelationTypeBiz objBiz = new CancelationTypeBiz();
            objBiz.ID = 0;
            objBiz.NameA = "غير محدد";

            Add(objBiz);
            foreach (DataRow objDR in dtTemp.Rows)
            {
                Add(new CancelationTypeBiz(objDR));
            }

        }
        public CancelationTypeCol()
        {
            CancelationTypeDb objDb = new CancelationTypeDb();

            DataTable dtTemp = objDb.Search();
            CancelationTypeBiz objBiz = new CancelationTypeBiz();
            foreach (DataRow objDR in dtTemp.Rows)
            {
                Add(new CancelationTypeBiz(objDR));
            }

        }
        public CancelationTypeCol(int intID)
        {
            CancelationTypeDb objDb = new CancelationTypeDb();
            objDb.ID = intID;
            DataTable dtTemp = objDb.Search();
            CancelationTypeBiz objBiz;

            foreach (DataRow objDR in dtTemp.Rows)
            {
                objBiz = new CancelationTypeBiz(objDR);
                this.Add(objBiz);
            }

        }
        public virtual CancelationTypeBiz this[int intIndex]
        {
            get
            {
                return (CancelationTypeBiz)this.List[intIndex];
            }
        }
        static CancelationTypeCol _CacheCancelationTypeCol;
        public static CancelationTypeCol CacheCancelationTypeCol
        {
            set => _CacheCancelationTypeCol = value;
            get
            {
                if(_CacheCancelationTypeCol== null)
                {
                    _CacheCancelationTypeCol = new CancelationTypeCol(false);
                }
                return _CacheCancelationTypeCol;
            }
        }
        public virtual void Add(CancelationTypeBiz objBiz)
        {

            this.List.Add(objBiz);
        }
    }
}


