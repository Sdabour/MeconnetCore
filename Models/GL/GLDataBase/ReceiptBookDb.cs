using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.SystemBase;
using SharpVision.Base.BaseDataBase;

namespace SharpVision.GL.GLDataBase
{
    public class ReceiptBookDb
    {
        #region Private Data
        int _ID;
        string _Code;
        string _Desc;
        int _StartSerial;
        int _EndSerial;
        int _Employee;
        string _EmployeeName;
        string _EmployeeCode;
        int _Model;
        string _ModelDesc;
        int _ModelAttachment;
        #endregion
        #region Constructors
        public ReceiptBookDb()
        { 
        }
        public ReceiptBookDb(DataRow objDr)
        {
            SetData(objDr);
        }
        #endregion
        #region Public Properties
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
        public string Code
        {
            set
            {
                _Code = value;
            }
            get
            {
                return _Code;
            }
        }
        public string Desc
        {
            set
            {
                _Desc = value;
            }
            get
            {
                return _Desc;
            }
        }
        public int StartSerial
        {
            set
            {
                _StartSerial = value;
            }
            get
            {
                return _StartSerial;
            }
        }
        public int EndSerial
        {
            set
            {
                _EndSerial = value;
            }
            get
            {
                return _EndSerial;
            }
        }
        public int Employee
        {
            set
            {
                _Employee = value;
            }
            get
            {
                return _Employee;
            }
        }
        public int Model
        {
            set
            {
                _Model = value;
            }
            get
            {
                return _Model;
            }
        }

        public string ModelDesc
        {
            get
            {
                return _ModelDesc;
            }
        }
        public int ModelAttachment
        {
            get
            {
                return _ModelAttachment;
            }
        }
        public string EmployeeName
        {
            get
            {
                return _EmployeeName;
            }
        }
        public string EmployeeCode
        {
            get
            {
                return _EmployeeCode;
            }
        }
        public string AddStr
        {
            get
            {
                string Returned = "insert into GLReceiptBook (ReceiptBookModel,ReceiptBookDesc, ReceiptBookStartSerial" +
                    ", ReceiptBookEndSerial, ReceiptBookEmployee, UsrIns, TimIns) "+
                    " values ("+ _Model +",'"+ _Desc +"',"+ _StartSerial + "," + _EndSerial + "," + _Employee + "," + SysData.CurrentUser.ID +",GetDate()) ";
                return Returned;
            }
        }
        public string EditStr
        {
            get
            {
                string Returned = "update  GLReceiptBook  set ReceiptBookModel ="+_Model+
                    ", ReceiptBookDesc='" + _Desc + "'" +
                    ", ReceiptBookStartSerial=" + _StartSerial +
                    ", ReceiptBookEndSerial=" + _EndSerial +
                    ", ReceiptBookEmployee=" + _Employee +
                    ", UsrUpd=" + SysData.CurrentUser.ID +
                    ", TimUpd=GetDate()  " +
                    " where ReceiptBookID = "+ _ID;
                return Returned;
            }
        }
        public static string SearchStr
        {
            get
            {
                string strEmployee = "SELECT  dbo.HRApplicant.ApplicantID AS ReceiptBookEmployeeID, dbo.HRApplicant.ApplicantFirstName AS ReceiptBookEmployeeName, "+
                      " dbo.HRApplicantWorker.ApplicantCode AS ReceiptBookEmployeeCode "+
                      " FROM     dbo.HRApplicant INNER JOIN "+
                      " dbo.HRApplicantWorker ON dbo.HRApplicant.ApplicantID = dbo.HRApplicantWorker.ApplicantID ";
                string strModel = "SELECT ModelID AS BookModelID, ModelDesc AS BookModelDesc, ModelAttachmentID AS BookModelAttachment "+
                       " FROM   dbo.GLReceiptModel ";
                string Returned = "SELECT   ReceiptBookID,ReceiptBookModel, ReceiptBookDesc, ReceiptBookStartSerial, ReceiptBookEndSerial" +
                    ", ReceiptBookEmployee,EmployeeTable.*,BookModelTable.*  "+
                       " FROM   dbo.GLReceiptBook "+
                       " left outer join ("+ strEmployee +") as EmployeeTable  "+
                       " on GLReceiptBook.ReceiptBookEmployee = EmployeeTable.ReceiptBookEmployeeID "+
                       "  left outer  JOIN ("+ strModel +") AS BookModelTable "+
                       " ON dbo.GLReceiptBook.ReceiptBookModel = BookModelTable.ModelID ";
                return Returned;
            }
        }
        #endregion
        #region Private Methods
        void SetData(DataRow objDr)
        {
            _ID = int.Parse(objDr["ReceiptBookID"].ToString());
            // _Code = objDr[""].ToString();
             _Desc = objDr["ReceiptBookDesc"].ToString();
             _StartSerial = int.Parse(objDr["ReceiptBookStartSerial"].ToString());
             _EndSerial = int.Parse(objDr["ReceiptBookEndSerial"].ToString());
            if(objDr["ReceiptBookEmployeeID"].ToString()!= "")
             _Employee = int.Parse(objDr["ReceiptBookEmployeeID"].ToString());
             _EmployeeName = objDr["ReceiptBookEmployeeName"].ToString();
             _EmployeeCode = objDr["ReceiptBookEmployeeCode"].ToString();
            if (objDr["BookModelID"].ToString() != "")
            _Model = int.Parse(objDr["BookModelID"].ToString());
        _ModelDesc = objDr["BookModelDesc"].ToString();
          if(objDr["BookModelAttachment"].ToString()!= "")
             _ModelAttachment = int.Parse(objDr["BookModelAttachment"].ToString());
        }
        #endregion
        #region Public Methods
        public void Add()
        {
            string strSql =AddStr;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public void Edit()
        {
            string strSql = EditStr;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public void Delete()
        {
            string strSql = "update dbo.GLReceiptBook set Dis = GetDate() where ReceiptBookID=" + _ID;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public DataTable Search()
        {
            string strSql = SearchStr;
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        #endregion

    }
}
