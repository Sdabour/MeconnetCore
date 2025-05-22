using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.Base.BaseBusiness;
using SharpVision.CRM.CRMDataBase;
using SharpVision.SystemBase;
using SharpVision.UMS.UMSBusiness;
namespace SharpVision.CRM.CRMBusiness
{
    public class UnitTypeCol : BaseCol
    {
        public UnitTypeCol(bool blIsEmpty)
        {
            if (blIsEmpty)
                return;
            UnitTypeDb objDb = new UnitTypeDb();
            
            DataTable dtTemp = objDb.Search();
            UnitTypeBiz objBiz =  new UnitTypeBiz();
            objBiz.ID = 0;
            objBiz.NameA = "€Ì— „Õœœ";
            Add(objBiz);
            foreach (DataRow objDR in dtTemp.Rows)
            {
                //objBiz = new UnitTypeBiz(objDR);
                //this.Add(objBiz);
                Add(new UnitTypeBiz(objDR));
            }

        }
        public UnitTypeCol()
        {
            UnitTypeDb objDb = new UnitTypeDb();

            DataTable dtTemp = objDb.Search();
         
            foreach (DataRow objDR in dtTemp.Rows)
            {
                Add(new UnitTypeBiz(objDR));
            }

        }
        public UnitTypeCol(int intID)
        {
            UnitTypeDb objDb = new UnitTypeDb();
            objDb.ID = intID;
            DataTable dtTemp = objDb.Search();
            UnitTypeBiz objBiz;

            foreach (DataRow objDR in dtTemp.Rows)
            {
                objBiz = new UnitTypeBiz(objDR);
                this.Add(objBiz);
            }

        }
        public UnitTypeCol(UserBiz objUserBiz)
        {
            if (objUserBiz == null)
                objUserBiz = new UserBiz();
            UnitTypeDb objDb = new UnitTypeDb();
            objDb.UserID = objUserBiz.ID;
            DataTable dtTemp = objDb.GetUserUnitType();
            UnitTypeBiz objBiz = new UnitTypeBiz();
            objBiz.ID = 0;
            objBiz.NameA = "€Ì— „Õœœ";
            Add(objBiz);
            foreach (DataRow objDR in dtTemp.Rows)
            {
                Add(new UnitTypeBiz(objDR));
            }
        }
        public virtual UnitTypeBiz this[int intIndex]
        {
            get
            {
                return (UnitTypeBiz)this.List[intIndex];
            }
        }
        static UnitTypeCol _AssignedUnitTypeCol;
        public static UnitTypeCol AssignedUnitTypeCol
        {
            get
            {
                if (_AssignedUnitTypeCol == null)
                {
                    _AssignedUnitTypeCol = new UnitTypeCol(SysData.CurrentUser);

                }
                return _AssignedUnitTypeCol;
            }
        }
        public string TypeIDs
        {
            get
            {
                string Returned = "";
                foreach (UnitTypeBiz objBiz in this)
                {
                    if (Returned != "")
                        Returned += ",";
                    Returned += objBiz.ID.ToString();

                }
                return Returned;
            }
        }
        public virtual void Add(UnitTypeBiz objBiz)
        {

            this.List.Add(objBiz);
        }
        public void AssignToUser(int intUserID)
        {
            UnitTypeDb objDb = new UnitTypeDb() { UserID = intUserID, TypeIDs = TypeIDs };
            objDb.AssignUserUnitType();
        }
    }
}
