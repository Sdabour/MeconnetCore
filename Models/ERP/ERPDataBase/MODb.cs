using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using SharpVision.SystemBase;
using System.ComponentModel;
namespace AlgorithmatENM.ERP.ERPDataBase
{
    public class MODb
    {
        //id,bom,product,workorders,user,quantity,responsible,components,byproducts
        #region Constructor
        public MODb()
        {
        }
        public MODb(DataRow objDr)
        {
            SetData(objDr);
        }

        #endregion
        #region Properties
        int _ID;
        public int ID
        {
            set => _ID = value;
            get => _ID;
        }
        string _Ref;
        public string Ref
        {
            set => _Ref = value;
            get => _Ref;
        }
        DateTime _Date;
        public DateTime Date
        {
            set => _Date = value;
            get => _Date;
        }
        DateTime _StartTime;
        public DateTime StartTime
        {
            set => _StartTime = value;
            get => _StartTime;
        }
        string _Desc;
        public string Desc
        {
            set => _Desc = value;
            get => _Desc;
        }
        double _Quantity;
        public double Quantity
        {
            set => _Quantity = value;
            get => _Quantity;
        }
        int _Responsible;
        public int Responsible
        {
            set => _Responsible = value;
            get => _Responsible;
        }
        int _Status;
        public int Status
        {
            set => _Status = value;
            get => _Status;
        }
        DateTime _StatusTime;
        public DateTime StatusTime
        {
            set => _StatusTime = value;
            get => _StatusTime;
        }
        int _UserStarted;
        public int UserStarted { set => _UserStarted = value; get => _UserStarted; }
        int _Product;
        public int Product { set => _Product = value; get => _Product; }
        int _BOM;
        public int BOM { set => _BOM = value; get => _BOM; }
        string _ResponsibleName;
        public string ResponsibleName { get => _ResponsibleName; set => _ResponsibleName = value; }

        string _UserStartedName;
        public string UserStartedName
        {
            set => _UserStartedName = value;
            get => _UserStartedName;
        }
        string _BOMName;
        public string BOMName
        {
            set => _BOMName = value;
            get => _BOMName;
        }
        string _ProductName;
        public string ProductName
        {
            set => _ProductName = value;
            get => _ProductName;
        }
        string _StatusStr;
        public string StatusStr { set => _StatusStr = value; }
        int _User;
        public int User
        {
            set => _User=value;
            get
                { 
                return _User==0?SysData.CurrentUser.ID:_User; 
            }
        }
        bool _IsDateRange;
        public bool IsDateRange { set=>_IsDateRange= value; }
        DateTime _DateStart;
        public DateTime DateStart {  set => _DateStart= value; }
        DateTime _DateEnd;
        public DateTime DateEnd {  set => _DateEnd= value; }
        int _ChangedStatus;
        public int ChangedStatus {  set => _ChangedStatus= value; }

        int _StatusChangedStatus;
        public int StatusChangedStatus { set => _StatusChangedStatus = value; }
        string _BufferIDs;
        public string BufferIDs { set => _BufferIDs= value; }

        string _IDs;
        public string IDs { set=> _IDs= value; }

        DataTable _ComponentTable;
        public DataTable ComponentTable { set => _ComponentTable = value; }
        DataTable _ByproductTable;
        public DataTable ByproductTable { set => _ByproductTable = value; }
        DataTable _WorkorderTable;
        public DataTable WorkorderTable { set => _WorkorderTable = value; }


        public string AddStr
        {
            get
            {
                string Returned = " insert into ERPMO (MORef,MODate,MOStartTime,MODesc,MOQuantity,MOResponsible,MOResponsibleName,MOStatus,MOStatusTime,MOUserStarted,MOUserStartedName, MOBOM, MOBOMName, MOProduct,MOProductName,UsrIns,TimIns) values ('" + Ref + "'," + (Date.ToOADate() - 2).ToString() + "," + (StartTime.ToOADate() - 2).ToString() + ",'" + Desc + "'," + Quantity + "," + Responsible+"','"+_ResponsibleName + "'," + Status + "," + (StatusTime.ToOADate() - 2).ToString()+","+_UserStarted+",'"+_UserStartedName +"',"+_BOM+",'"+_BOMName+"'," +_Product+",'" +_ProductName+ "'," + SysData.CurrentUser.ID + ",GetDate() ) ";
                return Returned;
            }
        }

        public string AddUniqueRefStr1
        {
            get
            {
                string Returned = @" insert into ERPMO (MORef,MODate,MOStartTime,MODesc,MOQuantity,MOResponsible,MOResponsibleName,MOStatus,MOStatusTime,MOUserStarted,MOUserStartedName, MOBOM, MOBOMName, MOProduct,MOProductName,UsrIns,TimIns) 
 select '" + Ref + "' as Ref1," + (Date.ToOADate() - 2).ToString() + " as Date1," + (StartTime.ToOADate() - 2).ToString() + " as StartTime1,'" + Desc + "' as Desc1," + Quantity + " as Quantity1," + Responsible + " as Reponsible1,'" + _ResponsibleName + "' as ResponsibleName1," + Status + " as Status1," + (StatusTime.ToOADate() - 2).ToString() + " as SttausTime1," + _UserStarted + " as UserStarted1,'" + _UserStartedName + "' as UserName1," + _BOM + " as Bom1,'" + _BOMName + "' as BONname1," + _Product + " as Product1,'" + _ProductName + "' as ProductName1," + _User + @" as UserIns1,GetDate()  as TimIns1 
   where not exists (select MOID from ERPMO where MORef = '"+_Ref+ @"')
    SELECT MOID 
FROM     dbo.ERPMO
WHERE  (MORef = '"+_Ref+"') ";
                return Returned;
            }
        }

        public string AddUniqueRefStr
        {
            get
            {
                string Returned = @"
declare @ID int;
declare @New int;
set @New = 0;
 set @ID = (select top 1 MOID from ERPMO where MORef='" + _Ref + @"');
if @ID > 0 goto EndLine;

insert into ERPMO (MORef,MODate,MOStartTime,MODesc,MOQuantity,MOResponsible,MOResponsibleName,MOStatus,MOStatusTime,MOUserStarted,MOUserStartedName, MOBOM, MOBOMName, MOProduct,MOProductName,UsrIns,TimIns) 
 select '" + Ref + "' as Ref1," + (Date.ToOADate() - 2).ToString() + " as Date1," + (StartTime.ToOADate() - 2).ToString() + " as StartTime1,'" + Desc + "' as Desc1," + Quantity + " as Quantity1," + Responsible + " as Reponsible1,'" + _ResponsibleName + "' as ResponsibleName1," + Status + " as Status1," + (StatusTime.ToOADate() - 2).ToString() + " as SttausTime1," + _UserStarted + " as UserStarted1,'" + _UserStartedName + "' as UserName1," + _BOM + " as Bom1,'" + _BOMName + "' as BONname1," + _Product + " as Product1,'" + _ProductName + "' as ProductName1," + User + @" as UserIns1,GetDate()  as TimIns1 
   where not exists (select MOID from ERPMO where MORef = '" + _Ref + @"')
       set @New=1;
   set @ID = (select @@IDENTITY as NewID);
  Endline: select @New as IsNew,@ID as MOID ";
                return Returned;
            }
        }

        public string EditStr
        {
            get
            {
                string Returned = " update ERPMO set MORef='" + Ref + "'" +
           ",MODate=" + (Date.ToOADate() - 2).ToString() + "" +
           ",MOStartTime=" + (StartTime.ToOADate() - 2).ToString() + "" +
           ",MODesc='" + Desc + "'" +
           ",MOQuantity=" + Quantity + "" +
           ",MOResponsible=" + Responsible + "" +
           ",MOStatus=" + Status + "" +
           ",MOStatusTime=" + (StatusTime.ToOADate() - 2).ToString() + "" + ",UsrUpd=" + SysData.CurrentUser.ID + @",TimUpd=GetDate()  where MOID="+_ID;
                return Returned;
            }
        }

        public string DeleteStr
        {
            get
            {
                string Returned = " update ERPMO set Dis = GetDate() where  ";
                return Returned;
            }
        }
        public string SearchStr
        {
            get
            {
                string Returned = @" select MOID,MORef,MODate,MOStartTime,MODesc,MOQuantity,MOResponsible,MOStatus,MOStatusTime,MOUserStarted, MOBOM, MOProduct, MOUserStartedName, MOBOMName, MOProductName, MOResponsibleName

    from ERPMO  ";
                return Returned;
            }
        }
        #endregion
        #region Private Method
        void SetData(DataRow objDr)
        {

            if (objDr.Table.Columns["MOID"] != null)
                int.TryParse(objDr["MOID"].ToString(), out _ID);

            if (objDr.Table.Columns["MORef"] != null)
                _Ref = objDr["MORef"].ToString();

            if (objDr.Table.Columns["MODate"] != null)
                DateTime.TryParse(objDr["MODate"].ToString(), out _Date);

            if (objDr.Table.Columns["MOStartTime"] != null)
                DateTime.TryParse(objDr["MOStartTime"].ToString(), out _StartTime);

            if (objDr.Table.Columns["MODesc"] != null)
                _Desc = objDr["MODesc"].ToString();

            if (objDr.Table.Columns["MOQuantity"] != null)
                double.TryParse(objDr["MOQuantity"].ToString(), out _Quantity);

            if (objDr.Table.Columns["MOResponsible"] != null)
                int.TryParse(objDr["MOResponsible"].ToString(), out _Responsible);

            if (objDr.Table.Columns["MOStatus"] != null)
                int.TryParse(objDr["MOStatus"].ToString(), out _Status);

            if (objDr.Table.Columns["MOStatusTime"] != null)
                DateTime.TryParse(objDr["MOStatusTime"].ToString(), out _StatusTime);

            if (objDr.Table.Columns["MOUserStarted"] != null)
                int.TryParse(objDr["MOUserStarted"].ToString(), out _UserStarted);
            if (objDr.Table.Columns["MOBOM"] != null)
                int.TryParse(objDr["MOBOM"].ToString(), out _BOM);
            if (objDr.Table.Columns["MOProduct"] != null)
                int.TryParse(objDr["MOProduct"].ToString(), out _Product);
            if (objDr.Table.Columns["MOUserStartedName"] != null)
                _UserStartedName = objDr["MOUserStartedName"].ToString();

            if (objDr.Table.Columns["MOBOMName"] != null)
                _BOMName = objDr["MOBOMName"].ToString();

            if (objDr.Table.Columns["MOProductName"] != null)
                _ProductName = objDr["MOProductName"].ToString();
            if (objDr.Table.Columns["MOResponsibleName"] != null)
                _ResponsibleName = objDr["MOResponsibleName"].ToString();
        }

        #endregion
        #region Public Method 
        public void Add()
        {
            string strSql = AddStr;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public void AddUniqueRef()
        {
            string strSql = AddUniqueRefStr;
            DataTable dtTemp = SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
            bool blIsNew = false;
            if (dtTemp.Rows.Count > 0) {
                int.TryParse(dtTemp.Rows[0]["MOID"].ToString(), out _ID);
                if (dtTemp.Rows[0]["IsNew"].ToString() == "1")
                    blIsNew = true;

            }
            //if(objTemp != null)
            //    int.TryParse(objTemp.ToString(),out _ID);
            if (!blIsNew)
                return;
            List<string> lstWorkOrder = new List<string>();
            WorkOrderDb objWorkOrder;
            foreach (DataRow objDr in _WorkorderTable.Rows) {
                objWorkOrder = new WorkOrderDb(objDr);
                objWorkOrder.MO = _ID;
                lstWorkOrder.Add(objWorkOrder.AddStr);
            }
            SysData.SharpVisionBaseDb.ExecuteNonQuery(lstWorkOrder);
            MOComponentDb objProduct;
            List<string> lstComponent = new List<string>();
            foreach (DataRow objDr in _ComponentTable.Rows)
            {
                objProduct = new MOComponentDb(objDr);
                objProduct.MO = _ID;
                lstComponent.Add(objProduct.AddStr);

            }
            SysData.SharpVisionBaseDb.ExecuteNonQuery(lstComponent);
            List<string>  lstProduct = new List<string>();
            foreach (DataRow objDr in _ByproductTable.Rows)
            {
                objProduct = new MOComponentDb(objDr);
                objProduct.MO = _ID;
                lstProduct.Add(objProduct.AddByproductStr);

            }
            SysData.SharpVisionBaseDb.ExecuteNonQuery(lstProduct);
            InsertMOStatus();
        }
        public void Edit()
        {
            string strSql = EditStr;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);

        }
        public void Delete()
        {
            string strSql = DeleteStr;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public DataTable Search()
        {
            string strSql = SearchStr + " where Dis is null ";
            if (_ID != 0)
            {
                strSql += " and ERPMO.MOID="+_ID;
            }
            if(_StatusStr != null&&_StatusStr!= "")
            {
                strSql += " and ERPMO.MOStatus in("+_StatusStr+") ";
            }
            if(_IsDateRange)
            {
                strSql += " and ERPMO.MODate between "+(_DateStart.Date.ToOADate()-2) +" and " + (_DateEnd.Date.ToOADate()-2);
            }
            if (_ChangedStatus != 0)
                strSql += " and ERPMO.MOChanged=1 ";
            if (_StatusChangedStatus != 0)
                strSql += " and ERPMO.MOStatusChanged=1 ";
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        public void EditStatus()
        {
            if (_ID == 0)
                return;
            string strSql = "";
           
            strSql = " update ERPMO set MOStatus ="+_Status + @",MOStatusChanged=1"
                + @"  where ERPMO.MOID="+_ID;

            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);

            InsertMOStatus();

        }
        void InsertMOStatus()
        {
            string strSql = "execute InsertMOStatus "+_ID+","+_Status +","+User;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);

            return;
             
        }
        public void EditChangedStatus()
        {
            if (_IDs == null||_IDs=="")
                return;
            if (_ChangedStatus != 0)
                _ChangedStatus = 1;
            string strSql = "update ERPMO set MOChanged =" + _ChangedStatus
                + @" where ERPMO.MOID in(" + _IDs+")";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);


        }
        public void EditStatusChangedStatus()
        {
            if (_IDs == null || _IDs == "")
                return;
            if (_ChangedStatus != 0)
                _ChangedStatus = 1;
            string strSql = "update ERPMO set MOStatusChanged =0 "
                + @" where ERPMO.MOID in(" + _IDs + ")";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);


        }
        public static void InsertLog()
        {
            string strSql = "insert into ERPMOLog (LOGDate) values (GetDate())";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        #endregion
    }
}
