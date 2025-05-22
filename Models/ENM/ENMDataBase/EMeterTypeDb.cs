using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpVision.SystemBase;
using System.Data;
namespace AlgorithmatENM.ENM.ENMDb
{
    public class EMeterTypeDb
    {

        #region Constructor
        public EMeterTypeDb()
        {
        }
        public EMeterTypeDb(DataRow objDr)
        {
            SetData(objDr);
        }

        #endregion
        #region Properties
        int _ID;
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
        string _Code;
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
        string _NameA;
        public string NameA
        {
            set
            {
                _NameA = value;
            }
            get
            {
                return _NameA;
            }
        }
        string _NameE;
        public string NameE
        {
            set
            {
                _NameE = value;
            }
            get
            {
                return _NameE;
            }
        }
        string _WordStartAddress;
        public string WordStartAddress
        {
            set
            {
                _WordStartAddress = value;
            }
            get
            {
                return _WordStartAddress;
            }
        }
        int _WordNo;
        public int WordNo
        {
            set
            {
                _WordNo = value;
            }
            get
            {
                return _WordNo;
            }
        }
        bool _Swap;
        public bool Swap { set => _Swap = value; get => _Swap; }
        int _DataType;
        public int DataType { set => _DataType = value; get => _DataType; }
        DataTable _MeasureTypeTable;
        public DataTable MeasureTypeTable { set => _MeasureTypeTable = value; }
        public string AddStr
        {
            get
            {
                string Returned = " insert into ENMEMeterType (EMeterTypeCode,EMeterTypeNameA,EMeterTypeNameE,EMeterTypeWordStartAddress,EMeterTypeWordNo,EMeterTypeSwap, EMeterTypeDataType, UsrIns,TimIns) values ('" + Code + "','" + NameA + "','" + NameE + "','" + WordStartAddress + "'," + WordNo +","+(_Swap?1:0)+","+ _DataType + "," + SysData.CurrentUser.ID + ",GetDate() ) ";
                return Returned;
            }
        }
        public string EditStr
        {
            get
            {
                string Returned = " update ENMEMeterType set EMeterTypeCode='" + Code + "'" +
           ",EMeterTypeNameA='" + NameA + "'" +
           ",EMeterTypeNameE='" + NameE + "'" +
           ",EMeterTypeWordStartAddress='" + WordStartAddress + "'" +
           ",EMeterTypeWordNo=" + WordNo + ""
           +",EMeterTypeSwap="+(_Swap?1:0)
           + ",EMeterTypeDataType="+_DataType
           + ",UsrUpd=" + SysData.CurrentUser.ID + @",TimUpd=GetDate()  where EMeterTypeID = "+_ID;
                return Returned;
            }
        }
        public string DeleteStr
        {
            get
            {
                string Returned = " update ENMEMeterType set Dis = GetDate() where  EMeterTypeID ="+ _ID;
                return Returned;
            }
        }
        public string SearchStr
        {
            get
            {
                string Returned = @" select EMeterTypeID,EMeterTypeCode,EMeterTypeNameA,EMeterTypeNameE,EMeterTypeWordStartAddress,EMeterTypeWordNo,  EMeterTypeSwap, EMeterTypeDataType 
 from ENMEMeterType  ";
                return Returned;
            }
        }
        #endregion
        #region Private Method
        void SetData(DataRow objDr)
        {

            if (objDr.Table.Columns["EMeterTypeID"] != null)
                int.TryParse(objDr["EMeterTypeID"].ToString(), out _ID);

            if (objDr.Table.Columns["EMeterTypeCode"] != null)
                _Code = objDr["EMeterTypeCode"].ToString();

            if (objDr.Table.Columns["EMeterTypeNameA"] != null)
                _NameA = objDr["EMeterTypeNameA"].ToString();

            if (objDr.Table.Columns["EMeterTypeNameE"] != null)
                _NameE = objDr["EMeterTypeNameE"].ToString();

            if (objDr.Table.Columns["EMeterTypeWordStartAddress"] != null)
                _WordStartAddress = objDr["EMeterTypeWordStartAddress"].ToString();

            if (objDr.Table.Columns["EMeterTypeWordNo"] != null)
                int.TryParse(objDr["EMeterTypeWordNo"].ToString(), out _WordNo);
            if (objDr.Table.Columns["EMeterTypeSwap"] != null)
                bool.TryParse(objDr["EMeterTypeSwap"].ToString(), out _Swap);
            if (objDr.Table.Columns["EMeterTypeDataType"] != null)
                int.TryParse(objDr["EMeterTypeDataType"].ToString(), out _DataType);


        }

        #endregion
        #region Public Method 
        public void Add()
        {
            string strSql = AddStr;
           _ID=SysData.SharpVisionBaseDb.InsertIdentityTable(strSql);
            JoinMeasureType();
        }
        public void Edit()
        {
            string strSql = EditStr;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
            JoinMeasureType();
        }
        public void Delete()
        {
            string strSql = DeleteStr;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public DataTable Search()
        {
            string strSql = SearchStr + " where Dis is null ";


            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        public void JoinMeasureType()
        {

            if (_MeasureTypeTable == null || _MeasureTypeTable.Rows.Count == 0 ||ID==0)
                return;
            List<string> arrStrSql = new List<string>();
            arrStrSql.Add(" delete from ENMEMeterTypeMeasureType where EMeterType>0 and EMeterType=" + ID);
            EMeterTypeMeasureTypeDb objDb;
            foreach (DataRow objDr in _MeasureTypeTable.Rows)
            {
                objDb = new EMeterTypeMeasureTypeDb(objDr);
                objDb.MeterType = ID;
                arrStrSql.Add(objDb.AddStr);

            }
            SysData.SharpVisionBaseDb.ExecuteNonQuery(arrStrSql);

        }
        #endregion
    }
}
