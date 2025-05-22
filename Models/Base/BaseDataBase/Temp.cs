using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace BaseDataBase
{
    class Temp
    {
        //for copy only


        //#region Private Data
        //int _ID;
        //string _Code;
        //#endregion
        //#region Constructors

        //#endregion
        //#region Public Properties
        //public int ID
        //{
        //    set
        //    {
        //        _ID = value;
        //    }
        //    get
        //    {
        //        return _ID;
        //    }
        //}
        //public string Code
        //{
        //    set
        //    {
        //        _Code = value;
        //    }
        //    get
        //    {
        //        return _Code;
        //    }
        //}
        public string AddStr
        {
            get
            {
                string Returned = "";
                return Returned;
            }
        }
        public string EditStr
        {
            get
            {
                string Returned = "";
                return Returned;
            }
        }
        public string DeleteStr
        {
            get
            {
                string Returned = "";
                return Returned;
            }
        }
        //public static string SearchStr
        //{
        //    get
        //    {
        //        string Returned = "";
        //        return Returned;
        //    }
        //}
        //#endregion
        //#region Private Methods
        //void SetData(DataRow objDr)
        //{

        //}
        //#endregion
        //#region Public Methods
        //public void Add()
        //{
        //    string strSql = AddStr;
        //    SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        //}
        //public void Edit()
        //{
        //    string strSql = EditStr;
        //    SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        //}
        //public void Delete()
        //{
        //    string strSql = DeleteStr;
        //    SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        //}
        //public DataTable Search()
        //{
        //    string strSql = SearchStr;
        //    return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        //}
        //#endregion




        #region Properties
        public double FirstValue;
        public double MinValue;
        public double MaxValue;
        public DateTime MinTime;
        #endregion





    }
}
