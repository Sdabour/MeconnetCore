using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.SystemBase;
namespace SharpVision.RP.RPDataBase
{
    public class ContractElementSelfDerivedDb : ContractElementDb
    {
        #region Private Data
        int _DerivedElementID;
        int _DerivedElementFamilyID;
        int _DerivedContractID;
        int _DerivedContractorID;
        string _DerivedContractorName;
        string _DerivedContractCellDesc;
        int _DerivedContractCellID;
        int _DerivedContractProcessTypeID;
        string _DerivedContractProcessTypeName;
        #endregion
        #region Constructors
        public ContractElementSelfDerivedDb(DataRow objDr)
            : base(objDr)
        {

           
        }
        public ContractElementSelfDerivedDb()
        {

            //aggregation : association |Composition
        }
        #endregion
        #region Public Properties
        public int DerivedElementID
        {
            set
            {
                _DerivedElementID = value;
            }
            get
            {
                return _DerivedElementID;
            }
        }

        public int DerivedContractID
        {
            set
            {
                _DerivedContractID = value;
            }
            get
            {
                return _DerivedContractID;
            }
        }
        public int DerivedContractorID
        {
            get
            {
                return _DerivedContractorID;
            }
        }
        public string DerivedContractorName
        {
            get
            {
                return _DerivedContractorName;
            }
        }
        public string DerivedContractCellDesc
        {
            get
            {
                return _DerivedContractCellDesc;
            }
        }
        public int DerivedContractCellID
        {
            get
            {
                return _DerivedContractCellID;
            }
        }
        public int DerivedContractProcessTypeID
        {
            get
            {
                return _DerivedContractProcessTypeID;
            }
        }
        public string DerivedContractProcessTypeName
        {
            get
            {
                return _DerivedContractProcessTypeName;
            }
        }
        public override string AddStr
        {
            get
            {
                string Returned = base.AddStr;
                Returned += " ";
                Returned += " ";

                return Returned;
            }
        }
        public override string EditStr
        {
            get
            {
                string Returned = base.EditStr;
                Returned += " ";
                Returned += "";
                return Returned;
            }
        }
        public static string SearchStr
        {
            get
            {
                string Returned = "SELECT  dbo.RPContractElementDerived.SrcContractElementID AS ContractElementSelfDerivedID, " +
               " dbo.RPContractElementDerived.SrcContractElementID AS ContractElementSelfDerivedSrcID, dbo.RPContractElement.ContractID AS ContractElementSelfDerivedSrcContractID,  " +
               " dbo.RPContractor.ContractorID AS ContractElementSelfDerivedSrcContractorID, dbo.RPContractor.ContractorFullName AS ContractElementSelfDerivedSrcContractorName,  " +
               " dbo.RPProcessType.PROCESSTypeID AS ContractElementSelfDerivedSrcProcessTypeID, " +
               " dbo.RPProcessType.PROCESSTypeNameA AS ContractElementSelfDerivedSrcProcessTypeName " +
               ", dbo.RPContract.CellID AS ContractElementSelfDerivedSrcCellID" +
               ",dbo.RPContract.ContractCellDesc AS ContractElementSelfDerivedSrcCellDesc" +
               ", dbo.RPContractElement.RefrenceValue AS ContractElementSelfDerivedSrcReferenceValue, " +
               "dbo.RPContractElement.UnitPrice AS ContractElementSelfDerivedSrcUnitPrice" +
               " FROM dbo.RPContractor INNER JOIN " +
               " dbo.RPContract ON dbo.RPContractor.ContractorID = dbo.RPContract.ContractorID INNER JOIN " +
               " dbo.RPProcessType ON dbo.RPContract.ContractProcessType = dbo.RPProcessType.PROCESSTypeID INNER JOIN " +
               " dbo.RPContractElement ON dbo.RPContract.ContractID = dbo.RPContractElement.ContractID INNER JOIN " +
               " dbo.RPContractElementDerived ON dbo.RPContractElement.ContractElementID = dbo.RPContractElementDerived.ContractElementID ";
                return Returned;
            }
        }
        #endregion
        #region Private Methods
        void SetData(DataRow objDr)
        {
            base.SetData(objDr);
            _DerivedElementID = int.Parse(objDr["ContractElementSelfDerivedSrcID"].ToString());

            _DerivedContractID = int.Parse(objDr["ContractElementSelfDerivedSrcContractID"].ToString());
            _DerivedContractorID = int.Parse(objDr["ContractElementSelfDerivedSrcContractorID"].ToString());
            _DerivedContractorName = objDr["ContractElementSelfDerivedSrcContractorName"].ToString();
            _DerivedContractCellDesc = objDr["ContractElementSelfDerivedSrcCellDesc"].ToString();
            _DerivedContractCellID = int.Parse(objDr["ContractElementSelfDerivedSrcCellID"].ToString());
            _DerivedContractProcessTypeID = int.Parse(objDr["ContractElementSelfDerivedSrcProcessTypeID"].ToString());
            _DerivedContractProcessTypeName = objDr["ContractElementSelfDerivedSrcProcessTypeName"].ToString();
            //_DerivedElementUnitPrice = double.Parse(objDr["ContractElementSelfDerivedSrcUnitPrice"].ToString());
            //_ElementReferenceValue = double.Parse(objDr["ContractElementSelfDerivedSrcReferenceValue"].ToString());
        }
        #endregion
        #region Public Methods
        public override void Add()
        {
            base.Add();
            if (_DerivedElementFamilyID == 0)
                _DerivedElementFamilyID = _ID;
            string strSql = "insert into RPContractElementDerived  (ContractElementID,SrcContractElementID,SrcContractElementFamilyID) " +
                " values (" + _ID + "," + _DerivedElementID + "," + _DerivedElementFamilyID + ")";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);

        }
        public override void Edit()
        {
            base.Edit();
            if (_DerivedElementFamilyID == 0)
                _DerivedElementFamilyID = _ID;
            string strSql = "insert into RPContractElementDerived  (ContractElementID,SrcContractElementID,SrcContractElementFamilyID) " +
                " values (" + _ID + "," + _DerivedElementID + "," + _DerivedElementFamilyID + ")";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }

        #endregion
    }
}
