using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.Base.BaseDataBase;
using SharpVision.Base.BaseBusiness;
using SharpVision.CRM.CRMDataBase;
using SharpVision.SystemBase;
using SharpVision.COMMON.COMMONBusiness;
//using SharpVision.CRM.CRMWeb;
using SharpVision.HR.HRBusiness;
using SharpVision.GL.GLBusiness;
using System.Collections;
using SharpVision.UMS.UMSBusiness;
namespace SharpVision.CRM.CRMBusiness
{
   public class ReservationReceiptBiz :ReceiptBiz
   {
       #region Private Data
       ReservationPaymentCol _ReservationPaymentCol;
       #endregion
       #region Constructors
       public ReservationReceiptBiz()
           : base()
       { }
       public ReservationReceiptBiz(DataRow objDr)
           : base(objDr)
       { 
       }
        #endregion
       #region Public Properties
       public ReservationPaymentCol ReservationPaymentCol
       {
           set
           {
               _ReservationPaymentCol = value;
           }
           get
           {
               if (_ReservationPaymentCol == null)
               {
                   _ReservationPaymentCol = new ReservationPaymentCol(true);
                   if (ID != 0)
                   {
                       ReservationPaymentDb objDb = new ReservationPaymentDb();
                       objDb.ReceiptID = ID;
                       DataTable dtTemp = objDb.Search();
                       foreach (DataRow objDr in dtTemp.Rows)
                       {
                           _ReservationPaymentCol.Add(new ReservationPaymentBiz(objDr));
                       }
                   }

               }
               return _ReservationPaymentCol;
           }
       }
       public override string DisplayedCheckSerial
       {
           get
           {
               string Returned = base.DisplayedCheckSerial;
               if (_ReservationPaymentCol != null && _ReservationPaymentCol.Count > 0 && 
                   _ReservationPaymentCol[0].PaymentMean == PaymentType.BankingTransfering)
                   Returned = DisplayedWireTransfereBank;

               return Returned;
           }
       }
        #endregion
       #region Private Methods

        #endregion
       #region Public Methods
       public override void Add()
       {
           _ReceiptDb.PaymentTable = ReservationPaymentCol.GetTable();
           base.Add();
       }
       public override void Edit()
       {
           _ReceiptDb.PaymentTable = ReservationPaymentCol.GetTable();
           base.Edit();
       }
       public void ConstructReceipt()
       {
           Project = ReservationPaymentCol.Project;
           Tower = ReservationPaymentCol.Tower;
           Unit = ReservationPaymentCol.UnitName;
           Value = ReservationPaymentCol.Value ;
           DiscountStr = ReservationPaymentCol.InstallmentDiscount;
           Beneficiary = ReservationPaymentCol.Customer;
           Desc = ReservationPaymentCol.Desc;
           //EditorBiz = SysData.CurrentUser.EmployeeBiz;
           EditorBiz = new EmployeeBiz();
           EditorBiz.ID = ReservationPaymentCol.EmployeeID ==0 ?SysData.CurrentUser.EmployeeBiz.ID : ReservationPaymentCol.EmployeeID;
           EditorBiz.ShortName = ReservationPaymentCol.EmployeeID ==0 ?SysData.CurrentUser.EmployeeBiz.ShortName  : ReservationPaymentCol.EmployeeShortName;
           EditorBiz.Name = ReservationPaymentCol.EmployeeID ==0 ?SysData.CurrentUser.EmployeeBiz.Name  :ReservationPaymentCol.EmployeeName;
           Date = ReservationPaymentCol.Count>0 && ReservationPaymentCol[0].CheckBiz.ID!=0 && !_ReservationPaymentCol[0].CheckIsCollected?
               ReservationPaymentCol[0].CheckBiz.StatusDate:
               (ReservationPaymentCol.Count > 0 && ReservationPaymentCol[0].CheckBiz.ID != 0 && _ReservationPaymentCol[0].CheckIsCollected ?
               _ReservationPaymentCol[0].PaymentDate :DateTime.Now);

           BranchName = ReservationPaymentCol.BranchID == 0 ? SysData.CurrentUser.EmployeeBiz.BranchName :  ReservationPaymentCol.BranchName;
           BranchID =  ReservationPaymentCol.BranchID == 0 ? SysData.CurrentUser.EmployeeBiz.BranchID  : ReservationPaymentCol.BranchID;
           InstallmentDueDate = ReservationPaymentCol.InstallmentDueDate;
           CheckSerial = ReservationPaymentCol.CheckCode;
           PaymentEffect = ReservationPaymentCol.PaymentEffect;
           PaymentMean = ReservationPaymentCol.PaymentMean;
           EditorName = ReservationPaymentCol.Count > 0 && ReservationPaymentCol[0].CheckBiz.ID != 0 ?
               "" : EditorBiz.DisplayName;
           IP = SysData.IP+"-"+SysData.CurrentUser.Name;

       }
       
        #endregion
   }
}
