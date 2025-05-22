using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Data;
using SharpVision.SystemBase;
using AlgorithmatMN.MN.MNDb;
namespace AlgorithmatMN.MN.MNBiz
{
   public  class ROCol:CollectionBase
    {
        int _MainCount=0;
        public int MainCount { get => _MainCount; }
        #region Constructor
        public ROCol()
        {

        }
        public ROCol(bool blIsEmbty)
        {
            if (blIsEmbty)
                return;
            ROBiz objBiz = new ROBiz();
          

            RODb objDb = new RODb();

            DataTable dtTemp = objDb.Search();


            foreach (DataRow objDR in dtTemp.Rows)
            {
                objBiz = new ROBiz(objDR);
                Add(objBiz);
            }
        }
        public ROCol(List<string> lstProjectCode)
        {
            if (lstProjectCode == null || lstProjectCode.Count == 0)
                return;
            string strProjectCode = "";
            foreach (string strTemp in lstProjectCode)
            {
                if (strTemp == "")
                    continue;
                if (strProjectCode != "")
                    strProjectCode += ",";
                strProjectCode += "'" + strTemp + "'";
            }
            RODb objDb = new RODb();
            objDb.ProjectCodeS = strProjectCode;
            DataTable dtTemp = objDb.Search();

            ROBiz objBiz;
            foreach (DataRow objDR in dtTemp.Rows)
            {
                objBiz = new ROBiz(objDR);
                Add(objBiz);
            }
            
        }

        public ROCol(string strProjectCode,string strROCode,string strCustomerName,int intIsEndedStatus,bool blIsDeliveryDateRange,DateTime dtDeliveryStart,DateTime dtDeliveryEnd)
        {
            RODb objDb = new RODb();
            objDb.ProjectCode = strProjectCode;
            objDb.Code = strROCode;
            objDb.Customer = strCustomerName;

            DataTable dtTemp = objDb.Search();

            ROBiz objBiz;
            foreach (DataRow objDR in dtTemp.Rows)
            {
                objBiz = new ROBiz(objDR);
                Add(objBiz);
            }

        }

        public ROCol(string strProjectCode, string strROCode)
        {
            if (strROCode == null || strROCode == "" || strProjectCode == null || strProjectCode == "")
                return;

            RODb objDb = new RODb();
            objDb.ProjectCode = strProjectCode;
            objDb.ExactCode = strROCode;
            //objDb.Customer = strCustomerName;

            DataTable dtTemp = objDb.Search();

            ROBiz objBiz;
            foreach (DataRow objDR in dtTemp.Rows)
            {
                objBiz = new ROBiz(objDR);
                Add(objBiz);
            }
            ProjectYearCol objYearCol = new ProjectYearCol();
            if (Count == 0)
                return;
            int intFirstYear = this.Cast<ROBiz>().Min(x => x.DeliveryDate.Year);
            ProjectYearBiz objYear = new ProjectYearBiz();
            while(intFirstYear<= DateTime.Now.Year)
            {
                foreach(ROBiz objRo in this)
                {
                    if (objRo.DeliveryDate.Year <= intFirstYear)
                        objYearCol.Add(new ProjectYearBiz() { ProjectCode = objRo.ProjectCode, Year = intFirstYear, StartDate = new DateTime(intFirstYear, 1, 1), EndDate = new DateTime(intFirstYear, 12, 31) });
                }
                intFirstYear++;
            }
            SetCredit(objYearCol,true);
        }
        #endregion
        #region Private Data
        Hashtable hsRo = new Hashtable();
        #endregion
        #region Properties
        public ROBiz this[int intIndex]
        {
            get
            {
                return (ROBiz)this.List[intIndex];
            }
        }
        public ROBiz this[string  strIndex]
        {
            get
            {
                if (hsRo[strIndex] == null)
                    return new ROBiz();
                else
                return (ROBiz)hsRo[strIndex];
            }
        }
        public List<string> ProjectCodeLst
        {
            get
            {
                List<string> Returned = new List<string>();
                var vrProject = from objRo in this.Cast<ROBiz>()
                                group objRo by new {ProjectCode= objRo.ProjectCode } into objCode
                                select objCode;
                foreach (var vrProjectCode in vrProject)
                {
                    Returned.Add(vrProjectCode.Key.ProjectCode);
                }
                return Returned;
            }
        }
        public List<int> YearLst
        {
            get
            {
                List<int> Returned = new List<int>();
                var vrProject = from objRo in this.Cast<ROBiz>()
                                 orderby objRo.DeliveryDate.Year
                                group objRo by new { Year = objRo.DeliveryDate.Year } into objYear
                                select objYear;
                foreach (var vrProjectCode in vrProject)
                {
                    Returned.Add(vrProjectCode.Key.Year);
                }
                return Returned;
            }
        }
        public CreditCol CreditCol
        {
            get
            {
                CreditCol Returned = new CreditCol(true);
                foreach (ROBiz objRo in this)
                    Returned.Add(objRo.CreditCol);
                return Returned;
            }
        }
        public string IDsStr
        { get
            {
                string Returned = "";
                foreach (ROBiz objBiz in this)
                {
                    if (Returned != "")
                        Returned += ",";
                    Returned += objBiz.ID.ToString();
                }
                return Returned;
            }
        }
        public List<int> CreditYearLst
        {
            get
            {
                List<int> Returned = new List<int>();
                CreditCol objCreditCol = CreditCol;
                Returned = (from objCredit in objCreditCol.Cast<CreditBiz>()
                              select objCredit.Year).Distinct().ToList();
                return Returned;
            }
        }
        public string ReservationIDs
        { get
            {
                string Returned = "";
                foreach(ROBiz objBiz in this)
                {
                    if (Returned != "")
                        Returned += ",";
                    Returned += objBiz.ReservationID;
                }
                return Returned;
            }
        }
      public  ProjectYearCol ProjectYearCol
        {
            get
            {
                ProjectYearCol objYearCol = new ProjectYearCol();
                if (Count == 0)
                    return objYearCol;
                int intFirstYear = this.Cast<ROBiz>().Min(x => x.DeliveryDate.Year);
                ProjectYearBiz objYear = new ProjectYearBiz();
                while (intFirstYear <= DateTime.Now.Year)
                {
                    foreach (ROBiz objRo in this)
                    {
                        if (objRo.DeliveryDate.Year <= intFirstYear)
                            objYearCol.Add(new ProjectYearBiz() { ProjectCode = objRo.ProjectCode, Year = intFirstYear, StartDate = new DateTime(intFirstYear, 1, 1), EndDate = new DateTime(intFirstYear, 12, 31) });
                    }
                    intFirstYear++;
                }
                return objYearCol;
            }
        }
        #endregion
        #region Private Method

        #endregion
        #region Public Method 
        public void Add(ROBiz objBiz)
        {
            if (hsRo[objBiz.ID.ToString()] == null)
                hsRo.Add(objBiz.ID.ToString(), objBiz);
            List.Add(objBiz);
        }
        public ROCol GetCol(string strTemp,bool blIsDateRange,DateTime dtStart,DateTime dtEnd,string strTower,int intDebitStatus,int intCreditedStatus,int intROType)
        {
            ROCol Returned = new ROCol(true);
            foreach (ROBiz objBiz in this)
            {
                if ((objBiz.Code.CheckStr(strTemp)||objBiz.Customer.CheckStr(strTemp)||objBiz.SapCustomerNo.CheckStr(strTemp))&&
                    (!blIsDateRange ||(objBiz.DeliveryDate.Year>= dtStart.Year && objBiz.DeliveryDate.Year<= dtEnd.Year))&&
                    (strTower ==""||objBiz.TowerCode == strTower) 
                    &&(intDebitStatus==0 || (objBiz.CreditCol.Count>0 && (objBiz.CreditCol[objBiz.CreditCol.Count-1].Closing>0 && intDebitStatus==2)|| (objBiz.CreditCol[objBiz.CreditCol.Count - 1].Closing <= 0 && intDebitStatus == 1)))
                    &&(intCreditedStatus == 0 ||
                    (intCreditedStatus == 1 && objBiz.Closing > objBiz.InitialMaintainanceValue) ||
                    (intCreditedStatus == 2 && objBiz.Closing < objBiz.InitialMaintainanceValue && objBiz.Closing>0) || (intCreditedStatus== 3 && objBiz.Closing<0)) && 
                    (intROType==0 || objBiz.Type == intROType))
                    Returned.Add(objBiz);
            }
            return Returned;
        }

        public DataTable GetTable()
        {
            DataTable Returned = new DataTable();
            Returned.Columns.AddRange(new DataColumn[] { new DataColumn("ROID"), new DataColumn("ROCode"),new DataColumn("ROArea"), new DataColumn("ROProjectCode"), new DataColumn("ROType"), new DataColumn("ROSapContract"), new DataColumn("ROSapCustomerNo"), new DataColumn("ROCustomer"), new DataColumn("RODeliveryDate", System.Type.GetType("System.DateTime")), new DataColumn("ROInitialMaintainanceValue"), new DataColumn("ROMaintainanceBonusPercPerYear") });
            DataRow objDr;
            foreach (ROBiz objBiz in this)
            {
                objDr = Returned.NewRow();
                objDr["ROID"] = objBiz.ID;
                objDr["ROCode"] = objBiz.Code;
                objDr["ROArea"] = objBiz.Area;
                objDr["ROProjectCode"] = objBiz.ProjectCode;
                objDr["ROType"] = objBiz.Type;
                objDr["ROSapContract"] = objBiz.SapContract;
                objDr["ROSapCustomerNo"] = objBiz.SapCustomerNo;
                objDr["ROCustomer"] = objBiz.Customer;
                objDr["RODeliveryDate"] = objBiz.DeliveryDate;
                objDr["ROInitialMaintainanceValue"] = objBiz.InitialMaintainanceValue;
                objDr["ROMaintainanceBonusPercPerYear"] = objBiz.MaintainanceBonusPercPerYear;
                Returned.Rows.Add(objDr);
            }
            return Returned;
        }
        public void SetCredit(ProjectYearCol objProjectYearCol,bool blIgnoreCost)
        {
            if (objProjectYearCol == null)
                objProjectYearCol = ProjectYearCol;
            ProjectCostCol objCostCol = blIgnoreCost?new ProjectCostCol(true): new ProjectCostCol(false);

           objCostCol.IntializeValue();


            CreditDb objCreditDb = new CreditDb();

            objCreditDb.ROIDs = IDsStr;
            DataTable dtCredit = objCreditDb.Search();
            Hashtable hsCredit = new Hashtable();
            CreditBiz objCreditBiz1;
            foreach (DataRow objDr in dtCredit.Rows)
            {
                objCreditBiz1 = new CreditBiz(objDr);
                if (this[objCreditBiz1.RO.ToString()].ID != 0)
                    objCreditBiz1.ROBiz = this[objCreditBiz1.RO.ToString()];
                if (hsCredit[objCreditBiz1.Key] == null)
                    hsCredit.Add(objCreditBiz1.Key, objCreditBiz1);


            }
            List<CreditBiz> lstCredit;
            foreach (ProjectYearBiz objYearBiz in objProjectYearCol)
            {
                objYearBiz.SetCostCol(objCostCol);
                lstCredit = (from objRo in this.Cast<ROBiz>()
                             where objRo.DeliveryDate.Year <= objYearBiz.Year && (!objRo.IsEnded || objRo.EndDate.Date >= objYearBiz.EndDate.Date) && objRo.ProjectCode.Trim().ToLower() == objYearBiz.ProjectCode.Trim().ToLower()
                             let xKey = objRo.ID.ToString() + "-" + objYearBiz.Year.ToString()
                             let X = hsCredit[xKey] == null ? new CreditBiz() { ROBiz = objRo, RO = objRo.ID, StartDate = objRo.DeliveryDate.Date >= objYearBiz.StartDate && objRo.DeliveryDate.Date <= objYearBiz.EndDate.Date ? objRo.DeliveryDate.Date : objYearBiz.StartDate.Date, EndDate = !objRo.IsEnded || objRo.EndDate.Date > objYearBiz.EndDate.Date ? objYearBiz.EndDate : objRo.EndDate.Date, Year = objYearBiz.Year, YearBiz = objYearBiz } : (CreditBiz)hsCredit[xKey]

                             select X).ToList();
               // List<ROCostBiz> objCostCol = ROCostLst;
                
                foreach (CreditBiz objCreditBiz in lstCredit)
                {

                    objCreditBiz.ROBiz.CreditCol.Add(objCreditBiz);

                    objYearBiz.CreditCol.Add(objCreditBiz);
                }

            }
            CreditBiz objRoCredit;
            //Credit Cost 
            #region Payment&Discount
            AdjustPayment();
            AdjustDiscount();
            #endregion
            DataRow[] arrDr;
          objCostCol =  SetCreditCostLst();
            foreach (ROBiz objRoBiz in this)
            {
                for (int intIndex = 0; intIndex < objRoBiz.CreditCol.Count; intIndex++)
                {
                    objRoCredit = objRoBiz.CreditCol[intIndex];
                    if (objRoCredit.ID != 0)
                        continue;
                    else
                    {
                    }
                    //Here is the changes for cost
                    //objRoCredit.Cost = objRoCredit.CostPart * objRoCredit.YearBiz.CostPart;
                    objRoCredit.Cost = objRoCredit.ROCostCol.TotalValue;
                    if (intIndex == 0)
                    {
                        objRoCredit.CrditInitialValue = objRoCredit.ROBiz.InitialMaintainanceValue;

                    }
                    else
                        objRoCredit.CrditInitialValue = objRoCredit.ROBiz.CreditCol[intIndex - 1].Closing;


                }
            }
            ////////////////////////////////
            var vrYearCol = from objRo in this.Cast<ROBiz>()
                            where objRo.DeliveryDate.Year > 0
                            orderby objRo.DeliveryDate.Year
                            group objRo by new ProjectYearBiz() { Year = objRo.DeliveryDate.Year, ProjectCode = objRo.ProjectCode, StartDate = new DateTime(objRo.DeliveryDate.Year, 1, 1), EndDate = new DateTime(objRo.DeliveryDate.Year, 12, 31) } into objYear
                            select objYear;
            ProjectYearBiz objYearBiz1;
            string strKey = "";
            foreach (ProjectYearBiz objYearBiz in objProjectYearCol)
            {
                objYearBiz.SetCostCol(objCostCol);
            }
                foreach (var vrYear in vrYearCol)
            {
                objYearBiz1 = vrYear.Key;
                strKey = objYearBiz1.ProjectCode + "-" + objYearBiz1.Year.ToString();
                if (objProjectYearCol[objYearBiz1.Key] == null)
                    objProjectYearCol.Add(objYearBiz1);
                else
                    objYearBiz1 = objProjectYearCol[objYearBiz1.Key];

                lstCredit = (from objRo in vrYear
                             select new CreditBiz() { ROBiz = objRo, RO = objRo.ID, StartDate = objRo.DeliveryDate.Date >= objYearBiz1.StartDate.Date && objRo.DeliveryDate.Date <= objYearBiz1.EndDate.Date ? objRo.DeliveryDate.Date : objYearBiz1.StartDate.Date, EndDate = objYearBiz1.EndDate, Year = objYearBiz1.Year }).ToList();


            }


        }
        public void SetCredit1( ProjectYearCol objProjectYearCol, ProjectCostCol objCostCol)
        {
            objCostCol.IntializeValue();
         

            CreditDb objCreditDb = new CreditDb();
            
            objCreditDb.ROIDs = IDsStr;
            DataTable dtCredit = objCreditDb.Search();
            Hashtable hsCredit = new Hashtable();
            CreditBiz objCreditBiz1;
            foreach(DataRow objDr in dtCredit.Rows)
            {
                objCreditBiz1 = new CreditBiz(objDr);
                if (this[objCreditBiz1.RO.ToString()].ID != 0)
                    objCreditBiz1.ROBiz = this[objCreditBiz1.RO.ToString()];
                if (hsCredit[objCreditBiz1.Key] == null)
                    hsCredit.Add(objCreditBiz1.Key, objCreditBiz1);
                        

            }
            List<CreditBiz> lstCredit;
            foreach (ProjectYearBiz objYearBiz in objProjectYearCol)
            {
                objYearBiz.SetCostCol(objCostCol);
              lstCredit =(from objRo in this.Cast<ROBiz>()
                          where objRo.DeliveryDate.Year <= objYearBiz.Year && (!objRo.IsEnded || objRo.EndDate.Date<=objYearBiz.EndDate.Date) && objRo.ProjectCode.Trim().ToLower() == objYearBiz.ProjectCode.Trim().ToLower()
                let xKey = objRo.ID.ToString()+"-"+objYearBiz.Year.ToString()
                          let X =hsCredit[xKey] == null? new CreditBiz() { ROBiz = objRo, RO = objRo.ID, StartDate = objRo.DeliveryDate > objYearBiz.StartDate && objRo.DeliveryDate <= objYearBiz.EndDate ? objRo.DeliveryDate : objYearBiz.StartDate, EndDate = !objRo.IsEnded || objRo.EndDate.Date > objYearBiz.EndDate.Date ? objYearBiz.EndDate : objRo.EndDate.Date, Year = objYearBiz.Year, YearBiz = objYearBiz } : (CreditBiz)hsCredit[xKey]
                          
                          select X).ToList();
                foreach(CreditBiz objCreditBiz in lstCredit)
                {
                   
                    objCreditBiz.ROBiz.CreditCol.Add(objCreditBiz);

                    objYearBiz.CreditCol.Add(objCreditBiz);
                }
             
            }
            CreditBiz objRoCredit;
            //Credit Cost 
            #region Payment&Discount
            AdjustPayment();
            AdjustDiscount();
            #endregion
            DataRow[] arrDr;
            foreach (ROBiz objRoBiz in this)
            {
                for(int intIndex=0;intIndex<objRoBiz.CreditCol.Count;intIndex++)
                {
                    objRoCredit = objRoBiz.CreditCol[intIndex];
                    if (objRoCredit.ID != 0)
                        continue;
                    else 
                    { 
                    }
                    objRoCredit.Cost = objRoCredit.CostPart * objRoCredit.YearBiz.CostPart;
                    if (intIndex == 0)
                    {
                        objRoCredit.CrditInitialValue = objRoCredit.ROBiz.InitialMaintainanceValue;
                     
                    }
                    else
                        objRoCredit.CrditInitialValue = objRoCredit.ROBiz.CreditCol[intIndex - 1].Closing; 


                }
            }
            ////////////////////////////////
            var vrYearCol = from objRo in this.Cast<ROBiz>()
                            where objRo.DeliveryDate.Year>0
                            orderby objRo.DeliveryDate.Year
                            group objRo by new ProjectYearBiz() { Year = objRo.DeliveryDate.Year, ProjectCode = objRo.ProjectCode, StartDate = new DateTime(objRo.DeliveryDate.Year, 1, 1), EndDate = new DateTime(objRo.DeliveryDate.Year, 12, 31) } into objYear
                            select objYear;
            ProjectYearBiz objYearBiz1;
            string strKey = "";
           
            foreach (var vrYear in vrYearCol)
            {
                objYearBiz1 = vrYear.Key;
                strKey = objYearBiz1.ProjectCode + "-" + objYearBiz1.Year.ToString();
                if (objProjectYearCol[objYearBiz1.Key] == null)
                    objProjectYearCol.Add(objYearBiz1);
                else
                    objYearBiz1 = objProjectYearCol[objYearBiz1.Key];

                lstCredit = (from objRo in vrYear
                             select new CreditBiz() { ROBiz = objRo, RO = objRo.ID, StartDate = objRo.DeliveryDate > objYearBiz1.StartDate && objRo.DeliveryDate <= objYearBiz1.EndDate ? objRo.DeliveryDate : objYearBiz1.StartDate, EndDate = objYearBiz1.EndDate, Year = objYearBiz1.Year }).ToList();


            }

           
        }
        void AdjustPayment()
        {
         

            MaintainancePaymentDb objPaymentDb = new MaintainancePaymentDb();
            objPaymentDb.CreditedStatus = 2;
            objPaymentDb.ROIDs = IDsStr;
            DataTable dtPayment = objPaymentDb.Search();
            DataRow[] arrDr = dtPayment.Select("", "CreditROID,PaymentDate");
            MaintainancePaymentBiz objBiz;
            List<ROBiz> lstRo;
            List<CreditBiz> lstCredit;
            ROBiz objRo = new ROBiz();
            foreach(DataRow objDr in arrDr)
            {

                objBiz = new MaintainancePaymentBiz(objDr);
                if(objRo.ID!= objBiz.ROBiz.ID)
                {
                    lstRo = (from objRoBiz in this.Cast<ROBiz>()
                             where objRoBiz.ID == objBiz.ROBiz.ID
                             select objRoBiz).ToList();
                    if (lstRo.Count > 0)
                        objRo = lstRo[0];
                }
                objBiz.ROBiz = objRo;
                lstCredit = (from objCredit in objRo.CreditCol.Cast<CreditBiz>()
                             where objCredit.StartDate.Date <= objBiz.Date.Date && objCredit.EndDate.Date.Date >= objBiz.Date.Date
                             select objCredit).ToList();
                if (lstCredit.Count > 0)
                    lstCredit[0].PaymentCol.Add(objBiz);
                else
                {
                    if(objRo.CreditCol.Count>0)
                    {
                        if(objRo.CreditCol[0].StartDate.Date>objBiz.Date.Date)
                        objRo.CreditCol[0].PaymentCol.Add(objBiz);
                    }
                }
            }
        }
        void AdjustDiscount()
        {
            MaintainanceDiscountDb objDiscountDb = new MaintainanceDiscountDb();
            objDiscountDb.CreditedStatus = 2;
            objDiscountDb.ROIDs = IDsStr;
            DataTable dtDiscount = objDiscountDb.Search();
            DataRow[] arrDr = dtDiscount.Select("", "CreditROID,CreditDiscountDate");
            MaintainanceDiscountBiz objBiz;
            List<ROBiz> lstRo;
            List<CreditBiz> lstCredit;
            ROBiz objRo = new ROBiz();
            foreach (DataRow objDr in arrDr)
            {

                objBiz = new MaintainanceDiscountBiz(objDr);
                if (objRo.ID != objBiz.ROBiz.ID)
                {
                    lstRo = (from objRoBiz in this.Cast<ROBiz>()
                             where objRoBiz.ID == objBiz.ROBiz.ID
                             select objRoBiz).ToList();
                    if (lstRo.Count > 0)
                        objRo = lstRo[0];
                }
                objBiz.ROBiz = objRo;
                lstCredit = (from objCredit in objRo.CreditCol.Cast<CreditBiz>()
                             where objCredit.StartDate.Date <= objBiz.Date.Date && objCredit.EndDate.Date.Date >= objBiz.Date.Date
                             select objCredit).ToList();
                if (lstCredit.Count > 0)
                    lstCredit[0].DiscountCol.Add(objBiz);
                else
                {
                    if (objRo.CreditCol.Count > 0)
                    {
                        objRo.CreditCol[0].DiscountCol.Add(objBiz);
                    }
                }
            }

        }
        public DataTable GetPivotTable()
        {
            DataTable Returned = new DataTable();
            Returned.Columns.AddRange(new DataColumn[] {new DataColumn("ID"), new DataColumn("مشروع"), new DataColumn("برج"), new DataColumn("وحدة"), new DataColumn("رقم_العقد"), new DataColumn("مساحة"), new DataColumn("عميل"), new DataColumn("رقم العميل"), new DataColumn("قيمة_الوديعة"), new DataColumn("تاريخ_استلام") });
            int intMainColumnCount = Returned.Columns.Count;
            List<int> lstYear = CreditYearLst;
            foreach (int objYear in lstYear)
            {
                Returned.Columns.Add("مصاريف_السنة" + objYear.ToString());
                Returned.Columns.Add("وحدة_الحساب" + objYear.ToString());
                Returned.Columns.Add("عدد_الايام" + objYear.ToString());

                Returned.Columns.Add("افتتاحى" + objYear.ToString());
                Returned.Columns.Add("تكلفة" + objYear.ToString());
                Returned.Columns.Add("دعم" + objYear.ToString());
                Returned.Columns.Add("اغلاق" + objYear.ToString());

            }
            DataRow objDr;
            string strTempColumnName = "";

            foreach (ROBiz objRo in this)
            {
                objDr = Returned.NewRow();
                objDr["ID"] = objRo.ID;
                objDr["مشروع"] = objRo.ProjectCode;
                objDr["برج"] = objRo.TowerCode;
                objDr["وحدة"] = objRo.Code;
                objDr["رقم_العقد"] = objRo.SapContract;
                objDr["مساحة"] = objRo.Area.ToString();
                objDr["عميل"] = objRo.Customer;
                objDr["رقم العميل"] = objRo.SapCustomerNo;
                objDr["قيمة_الوديعة"] = objRo.InitialMaintainanceValue;
                objDr["تاريخ_استلام"] = ((DateTime)objRo.DeliveryDate).ToString("yyyy-MM-dd");
                foreach (CreditBiz objCredit in objRo.CreditCol)
                {
                    strTempColumnName = "مصاريف_السنة" + objCredit.Year.ToString();
                    objDr[strTempColumnName] = objCredit.YearBiz.CostCol.TotalValue;
                    strTempColumnName = "وحدة_الحساب" + objCredit.Year.ToString();
                    objDr[strTempColumnName] = objCredit.YearBiz.CostPart.ToString();
                    strTempColumnName = "عدد_الايام" + objCredit.Year.ToString();
                    objDr[strTempColumnName] = objCredit.Days;
                    strTempColumnName = "افتتاحى" + objCredit.Year.ToString();
                    objDr[strTempColumnName] = objCredit.CrditInitialValue.ToString("0,0.0");
                    strTempColumnName = "تكلفة" + objCredit.Year.ToString();
                    objDr[strTempColumnName] = objCredit.Cost.ToString("0,0.0");
                    strTempColumnName = "دعم" + objCredit.Year.ToString();
                    objDr[strTempColumnName] = objCredit.BonusValue.ToString("0,0.0");
                    strTempColumnName = "اغلاق" + objCredit.Year.ToString();
                    objDr[strTempColumnName] = objCredit.Closing.ToString("0,0.0");

                }
                Returned.Rows.Add(objDr);
            }

            return Returned;
        }
        public DataTable GetSummaryTable(bool blTower)
        {
            DataTable Returned = new DataTable();
            Returned.Columns.AddRange(new DataColumn[] { new DataColumn("مشروع") });
            if(blTower)
            Returned.Columns.Add(new DataColumn("برج"));
             
            
            Returned.Columns.AddRange(   
            new DataColumn[]{ new DataColumn("عدد"),new DataColumn("عدد_مدين"), new DataColumn("اجمالى_مدين"), new DataColumn("عدد_مصفر"),new DataColumn("عدد_دائن"), new DataColumn("اجمالى_دائن"), new DataColumn("رصيد"),new DataColumn("اعلى_مديونية"),new DataColumn("اقل مديونية")});
            DataRow objDr;
            List<double> lstClosing ;
            var vrTowerCol = from objRo in this.Cast<ROBiz>()
                             orderby objRo.ProjectCode,objRo.TowerCode
                          group objRo by new { ProjectCode = objRo.ProjectCode, TowerCode = blTower ? objRo.TowerCode :""} into objTower
                          select objTower;
            foreach(var vrTower in vrTowerCol)
            {
                objDr = Returned.NewRow();
                objDr["مشروع"] = vrTower.Key.ProjectCode;
                if(blTower)
                 objDr["برج"] = vrTower.Key.TowerCode;
               // objDr["اجمالى_مساحة"] = vrTower.ToList().Sum(x => x.Area);
                objDr["عدد_مدين"] = vrTower.ToList().Sum(x => x.CreditCol.Count > 0 && x.CreditCol[x.CreditCol.Count - 1].Closing<0?1 : 0).ToString("0");
                objDr["اجمالى_مدين"] = vrTower.ToList().Sum(x => x.CreditCol.Count > 0 && x.CreditCol[x.CreditCol.Count - 1].Closing < 0 ? (x.CreditCol[x.CreditCol.Count - 1].Closing * -1) : 0).ToString("0,000");
                objDr["عدد_مصفر"] = vrTower.ToList().Sum(x => x.CreditCol.Count > 0 && x.CreditCol[x.CreditCol.Count - 1].Closing == 0 ? 1 : 0).ToString("0");
                objDr["عدد_دائن"] = vrTower.ToList().Sum(x => x.CreditCol.Count > 0 && x.CreditCol[x.CreditCol.Count - 1].Closing > 0 ? 1 : 0).ToString("0");
              
               
                objDr["اجمالى_دائن"] = vrTower.ToList().Sum(x => x.CreditCol.Count > 0 && x.CreditCol[x.CreditCol.Count - 1].Closing > 0 ? x.CreditCol[x.CreditCol.Count - 1].Closing : 0).ToString("0,000");
                objDr["رصيد"] = vrTower.ToList().Sum(x => x.CreditCol.Count > 0? x.CreditCol[x.CreditCol.Count - 1].Closing : 0).ToString("0,000");
                lstClosing = (from objROBiz in vrTower.ToList() where objROBiz.Closing <= 0 select Math.Abs(objROBiz.Closing)).ToList();
                objDr["اعلى_مديونية"] = lstClosing.Count>0 ?lstClosing.Max():0;
                objDr["اقل مديونية"] = lstClosing.Count > 0 ? lstClosing.Min() : 0;
                Returned.Rows.Add(objDr);
            }

            return Returned;
        }
        public void SetCreditRange(List<CreditRangeBiz>lstRange)
        {
            List<CreditRangeBiz> objRangeCol = (from objRange in lstRange
                                                orderby objRange.StartValue
                                                select objRange).ToList();
            foreach(ROBiz objRo in this)
            {
                foreach(CreditRangeBiz objRangeBiz in objRangeCol)
                    if(objRo.Closing >= objRangeBiz.StartValue && objRo.Closing<= objRangeBiz.EndValue)
                    {
                        objRo.RangeBiz = objRangeBiz;
                        break;
                    }
            }
        }
        public ProjectCostCol  SetCreditCostLst()
        {
           
                
                ROCostDb objDb = new ROCostDb() { ROIDs = IDsStr, CreditStatus = 2 };
                DataTable dtTemp = objDb.Search();
            ROCostBiz objCostBiz;
            string strCreditKey = "";
            ROBiz objRoBiz;
            CreditBiz objCreditBiz;
            ROCostCol objWastedCostCol = new ROCostCol(true);
            List<ROCostBiz> objROCostCol = new List<ROCostBiz>();
                foreach (DataRow objDr in dtTemp.Rows)
                {
                objCostBiz = new ROCostBiz(objDr);
                objROCostCol.Add(objCostBiz);
                objRoBiz = this[objCostBiz.ROBiz.ID.ToString()];
                strCreditKey = objCostBiz.ROBiz.ID + "-" + objCostBiz.Date.Year.ToString();
                objCreditBiz = objRoBiz.CreditCol[strCreditKey];
                if (objCreditBiz.RO != 0)
                    objCreditBiz.ROCostCol.Add(objCostBiz);
                else if (objCreditBiz.ROBiz.ID == 0 && objRoBiz.CreditCol.Count > 0)
                {
                    if (objRoBiz.CreditCol[0].StartDate > objCostBiz.Date)
                        objRoBiz.CreditCol[0].ROCostCol.Add(objCostBiz);
                    else
                        objWastedCostCol.Add(objCostBiz);
                     
                }
                }
            double dblTemp = 0;
             dtTemp = objWastedCostCol.GetTable();
             dblTemp = objWastedCostCol.Cast<ROCostBiz>().Sum(x => x.Value);
            var vrProjectCostCol = from objROCost in objROCostCol
                                group objROCost by new ProjectCostBiz { Date = objROCost.Date, StartDate = objROCost.StartDate, EndDate = objROCost.EndDate, Factor1 = objROCost.Factor1, Factor2 = objROCost.Factor2, Factor3 = objROCost.Factor3, Project = objROCost.ROBiz.ProjectCode, ID = objROCost.ProjectCost, Type = objROCost.Type, TypeBiz = objROCost.TypeBiz } into objProjectCost
                                select objProjectCost;
            ProjectCostCol objProjectCostCol = new ProjectCostCol(true);
            ProjectCostBiz objProjectCostBiz;
            foreach(var vrProjectCost in vrProjectCostCol)
            {
                objProjectCostBiz = vrProjectCost.Key;
                objProjectCostBiz.Value = vrProjectCost.ToList().Sum(x => x.Value);
                objProjectCostCol.Add(objProjectCostBiz);
            }
            objProjectCostCol.IntializeValue();
             dblTemp = objProjectCostCol.Cast<ProjectCostBiz>().Sum(x => x.Value);
            dblTemp = objROCostCol.Cast<ROCostBiz>().Sum(x => x.Value);
            dblTemp = this.Cast<ROBiz>().Sum(x=>  x.CreditCol.Cast<CreditBiz>().Sum(y => y.ROCostCol.Cast<ROCostBiz>().Sum(z => z.Value) ));
            objROCostCol.Clear();
            
            return objProjectCostCol;
        }
        public void CancelCreditCol()
        {
            CreditDb objDb = new CreditDb() { ROIDs = IDsStr };
            objDb.Delete();
        }
        public ROCol GetTop100()
        {
            ROCol Returned = new ROCol(true);
            for(int intIndex = 0;intIndex<Count&&intIndex<100;intIndex++)
            {
                Returned.Add(this[intIndex]);
            }
            return Returned;
        }
        #endregion
    }
}
