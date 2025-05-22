using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.SystemBase;
using SharpVision.Base.BaseDataBase;

namespace SharpVision.GL.GLDataBase
{
    public class RecursiveTransactionElementDb
    {
        #region Private Data
        protected int _ID;
        protected int _Transaction;
        protected int _Account;
        protected bool _Direction;
        protected double _Value;
        protected int _Order;
        protected int _CostCenter;
        #endregion
        #region Constractors
        public RecursiveTransactionElementDb()
        {

        }
        public RecursiveTransactionElementDb(DataRow objDR)
        {
            SetData(objDR);
        }
        #endregion
        #region Public Accessorice
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
        public int TRansaction
        {
            set
            {
                _Transaction = value;
            }
            get
            {
                return _Transaction;
            }
        }
        public int Account
        {
            set
            {
                _Account = value;
            }
            get
            {
                return _Account;
            }
        }
        public bool Direction
        {
            set
            {
                _Direction = value;
            }
            get
            {
                return _Direction;
            }
        }
        public double Value
        {
            set
            {
                _Value = value;
            }
            get
            {
                return _Value;
            }
        }
        public int Order
        {
            set
            {
                _Order = value;
            }
            get
            {
                return _Order;
            }
        }
        public int CostCenter
        {
            set
            {
                _CostCenter = value;
            }
            get
            {
                return _CostCenter;
            }
        }
        public static string SearchStr
        {
            get
            {
                AccountDb objAccountDb = new AccountDb();
                string Returned = " SELECT     GLRecursiveTransactionElement.ElementID, GLRecursiveTransactionElement.ElementTransaction, GLRecursiveTransactionElement.ElementAccount, " +
                                  " GLRecursiveTransactionElement.ElementValue, GLRecursiveTransactionElement.ElementDirection" +
                                  ",GLRecursiveTransactionElement.ElementOrder,AccountTable.*,CostCenterTable.* " +
                                  " FROM     GLRecursiveTransactionElement INNER JOIN" +
                                  " (" + objAccountDb.SearchStr + ") as AccountTable " +
                                  " ON GLRecursiveTransactionElement.ElementAccount = AccountTable.AccountID " +
                                  " left outer join (" + CostCenterDb.SearchStr + ") as CostCenterTable " +
                                  " on  GLRecursiveTransactionElement.ElementCostCenter = CostCenterTable.CostCenterID ";
                return Returned;
            }
        }
        public string AddStr
        {
            get
            {
                int intDirection = _Direction ? 1 : 0;
                string Returned = " INSERT INTO GLRecursiveTransactionElement " +
                                " (ElementTransaction, ElementAccount, ElementDirection, ElementValue,ElementCostCenter" +
                                ",ElementOrder)" +
                                " VALUES     (" + _Transaction + "," + _Account + "," + intDirection +
                                "," + _Value + "," + _CostCenter + "," + _Order + ") ";
                return Returned;
            }
        }
        public string EditStr
        {
            get
            {
                int intDirection = _Direction ? 1 : 0;
                string Returned = " update  GLRecursiveTransactionElement " +
                                " set  ElementAccount = " + _Account +
                                ", ElementDirection = " + intDirection +
                                ", ElementValue = " + _Value +
                                ",ElementCostCenter=" + _CostCenter +
                                ",ElementOrder=" + _Order +
                                " where ElementTransaction =" + _Transaction +
                                " and ElemntID=" + _ID;

                return Returned;
            }
        }
        public static DataTable EmptyTable
        {
            get
            {
                DataTable Returned = new DataTable();
                Returned.Columns.AddRange(new DataColumn[] { new DataColumn("ElemntID"), new DataColumn("ElementTransaction"), new DataColumn("ElementAccount"), new DataColumn("ElementDirection") 
            ,new DataColumn("ElementValue"),new DataColumn("ElementOrder")});
                return Returned;

            }
        }

        #endregion
        #region Private Methods
        void SetData(DataRow objDR)
        {

            _ID = int.Parse(objDR["ElementID"].ToString());
            _Transaction = int.Parse(objDR["ElementTransaction"].ToString());
            _Account = int.Parse(objDR["ElementAccount"].ToString());
            _Direction = bool.Parse(objDR["ElementDirection"].ToString());
            _Value = double.Parse(objDR["ElementValue"].ToString());
            if (objDR["ElementOrder"].ToString() != "")
                _Order = int.Parse(objDR["ElementOrder"].ToString());
            if (objDR["CostCenterID"].ToString() != "")
                _CostCenter = int.Parse(objDR["CostCenterID"].ToString());

        }
        #endregion
        #region Public Methods
        public void Add()
        {

            _ID = SysData.SharpVisionBaseDb.InsertIdentityTable(AddStr);
        }
        public void Edit()
        {
            int intDirection = _Direction ? 1 : 0;
            string strSql = " UPDATE    GLRecursiveTransactionElement" +
                            " SET   ElementTransaction =" + _Transaction + "" +
                            " , ElementAccount =" + _Account + "" +
                            " , ElementDirection =" + intDirection + "" +
                            " , ElementValue =" + _Value + "" +
                            " WHERE     (ElemntID = " + _ID + ") ";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public void Delete()
        {
            string strSql = " DELETE FROM GLRecursiveTransactionElement " +
                            " WHERE    (ElemntID = " + _ID + ") ";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public DataTable Search()
        {
            string strSql = SearchStr + " WHERE    (1=1)";
            if (_ID != 0)
                strSql = strSql + " and  ElemntID = " + _ID + " ";
            if (_Transaction != 0)
                strSql += " and  GLRecursiveTransactionElement.ElementTransaction =" + _Transaction;
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }

        #endregion
    }
}
