using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.SystemBase;
using System.Data;
using System.Data.SqlClient;
using SharpVision.COMMON.COMMONDataBase;

namespace SharpVision.RP.RPDataBase
{
    public class ContractElementHistoryDb
    {
        #region Private Data
        protected int _ID;
        protected int _ContractElementID;
        
        protected double _UnitPrice;
  
        protected bool _Stoped;
        protected string _ElementIDs;
        protected double _RefrenceValue;
        protected int _RefrenceValueUser;
        protected int _RefrenceValueEngineer;
        protected string _RefrenceValueEngineerName;
        protected DateTime _RefrenceValueDate;
        protected string _RefrenceValueComment;
        
   
      
        #endregion
        #region Constructors
        public ContractElementHistoryDb()
        {

        }
        public ContractElementHistoryDb(DataRow objDR)
        {
            SetData(objDR);
        }
        #endregion
        #region Public Properties
       
        public double UnitPrice
        {
            set
            {
                _UnitPrice = value;
            }
            get
            {
                return _UnitPrice;
            }

        }

        public int ContractElementID
        {
            set
            {
                _ContractElementID = value;
            }
            get
            {
                return _ContractElementID;
            }
        }
        public int ID
        {
            set
            {
                _ID = value;
            }
            get
            {
                return _ID;
            }
        }
     
       
      
        public double RefrenceValue
        {
            set
            {
                _RefrenceValue = value;
            }
            get
            {
                return _RefrenceValue;
            }
        }
        public int RefrenceValueUser
        {
            set
            {
                _RefrenceValueUser = value;
            }
            get
            {
                return _RefrenceValueUser;
            }
        }
        public int RefrenceValueEngineer
        {
            set
            {
                _RefrenceValueEngineer = value;
            }
            get
            {
                return _RefrenceValueEngineer;
            }
        }
        public string RefrenceValueEngineerName
        {
            set
            {
                _RefrenceValueEngineerName = value;
            }
            get
            {
                return _RefrenceValueEngineerName;
            }
        }
        public DateTime RefrenceValueDate
        {
            set
            {
                _RefrenceValueDate = value;
            }
            get
            {
                return _RefrenceValueDate;
            }
        }
        public string RefrenceValueComment
        {
            set
            {
                _RefrenceValueComment = value;
            }
            get
            {
                return _RefrenceValueComment;
            }
        }
      
        public string ElementIDs
        {
            set
            {
                _ElementIDs = value;
            }
        }
      
        
     
     
  
        public string SearchStr
        {
            get
            {
                string Returned = "SELECT  HistoryID, ContractElementID, ContractElementUnitPrice, ContractElementRefrenceValue, ConractElementRefrenceValueUser,  "+
                       " ContractElementRefrenceValueEmployee, ContractElementRefrenceValueDate, ContractElementRefrenceValueComment, UsrIns, TimIns "+
                       " FROM         dbo.RPContractElementHistory "+
                       " WHERE  (1=1) ";
                if (_ContractElementID!= 0)
                    Returned += "  and (ContractElementID =" + _ContractElementID + ")";
                if(_ElementIDs!= null && _ElementIDs != "")
                   Returned += "  and (ContractElementID IN ("+ _ElementIDs +"))";
                return Returned;

            }
        }
        #endregion
        #region Private Methods
        protected virtual void SetData(DataRow objDR)
        {
            if (objDR.Table.Columns["UnitPrice"] != null && objDR["UnitPrice"].ToString() != "")
                _UnitPrice = double.Parse(objDR["UnitPrice"].ToString());
          
          
            
          
        
            if (objDR.Table.Columns["ContractID"] != null)
                _ContractElementID = int.Parse(objDR["ContractID"].ToString());
            if (objDR.Table.Columns["ContractElementHistoryID"] != null)
                _ID = int.Parse(objDR["ContractElementHistoryID"].ToString());
       
         
            if (objDR.Table.Columns["ContractElementHistoryStoped"] != null)
                _Stoped = bool.Parse(objDR["ContractElementHistoryStoped"].ToString());
           
            if (objDR.Table.Columns["RefrenceValue"] != null && objDR["RefrenceValue"].ToString() != "")
                _RefrenceValue = double.Parse(objDR["RefrenceValue"].ToString());
            if (objDR.Table.Columns["RefrenceValueUser"] != null &&
                objDR["RefrenceValueUser"].ToString() != "")
                _RefrenceValueUser = int.Parse(objDR["RefrenceValueUser"].ToString());
            if (objDR.Table.Columns["EmployeeID"] != null && objDR["EmployeeID"].ToString() != "")
                _RefrenceValueEngineer = int.Parse(objDR["EmployeeID"].ToString());
            if (objDR.Table.Columns["EmployeeName"] != null && objDR["EmployeeName"].ToString() != "")
                _RefrenceValueEngineerName = objDR["EmployeeName"].ToString();
            if (objDR.Table.Columns["RefrenceValueEmployee"] != null && objDR["RefrenceValueEmployee"].ToString() != "")
                _RefrenceValueEngineer = int.Parse(objDR["RefrenceValueEmployee"].ToString());
            if (objDR.Table.Columns["RefrenceValueDate"] != null &&
                objDR["RefrenceValueDate"].ToString() != "" && objDR["RefrenceValueDate"].ToString() != "")
                _RefrenceValueDate = DateTime.Parse(objDR["RefrenceValueDate"].ToString());
            if (objDR.Table.Columns["RefrenceValueComment"] != null &&
              objDR["RefrenceValueComment"].ToString() != "")
                _RefrenceValueComment = objDR["RefrenceValueComment"].ToString();
          

            if (objDR.Table.Columns["ProcessEmployeeID"] != null && objDR["ProcessEmployeeID"].ToString() != "")
                _RefrenceValueEngineer = int.Parse(objDR["ProcessEmployeeID"].ToString());
            if (objDR.Table.Columns["ProcessEmployeeName"] != null && objDR["ProcessEmployeeName"].ToString() != "")
                _RefrenceValueEngineerName = objDR["ProcessEmployeeName"].ToString();

            if (objDR.Table.Columns["ProcessAmountDate"] != null &&
                objDR["ProcessAmountDate"].ToString() != "" && objDR["ProcessAmountDate"].ToString() != "")
                _RefrenceValueDate = DateTime.Parse(objDR["ProcessAmountDate"].ToString());
            if (objDR.Table.Columns["ProcessAmountComment"] != null &&
              objDR["ProcessAmountComment"].ToString() != "")
                _RefrenceValueComment = objDR["ProcessAmountComment"].ToString();
            if (objDR.Table.Columns["ProcessAmount"] != null && objDR["ProcessAmount"].ToString() != "")
                _RefrenceValue = double.Parse(objDR["ProcessAmount"].ToString());
            if (objDR.Table.Columns["ProcessAmountUsrUpd"] != null &&
                objDR["ProcessAmountUsrUpd"].ToString() != "")
                _RefrenceValueUser = int.Parse(objDR["ProcessAmountUsrUpd"].ToString());
          


        }
        #endregion
        #region Public Methods
      
       
        public virtual DataTable Search()
        {

            string strSql = SearchStr;

           


            strSql = "Select top 3000 * from (" + strSql + ") as NativeTable order by ContractElementHistoryID ";
            DataTable Returned = SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
            return Returned;
        }
       
        #endregion

    }
}
