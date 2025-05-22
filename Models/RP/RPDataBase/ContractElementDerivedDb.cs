using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.SystemBase;
namespace SharpVision.RP.RPDataBase
{
    public class ContractElementDerivedDb : ContractElementDb
    {
        #region Private Data
        int _SrcElementID;
        int _SrcElementFamilyID;
        int _SrcContractID;
        int _SrcContractorID;
        string _SrcContractorName;
        string _SrcContractCellDesc;
        int _SrcContractCellID;
        int _SrcContractProcessTypeID;
        string _SrcContractProcessTypeName;
        double _SrcElementReferenceValue;
        double _SrcElementUnitPrice;

        #endregion
        #region Constructors
        public ContractElementDerivedDb(DataRow objDr)
            : base(objDr)
        {

            
        }
        public ContractElementDerivedDb() 
        {

            //aggregation : association |Composition
        }
        #endregion
        #region Public Properties
        public int SrcElementID
        {
            set
            {
                _SrcElementID = value;
            }
            get
            {
                return _SrcElementID;
            }
        }
        public int SrcElementFamilyID
        {
            set
            {
                _SrcElementFamilyID = value;
            }
            get
            {
                return _SrcElementFamilyID;
            }
        }
        public int SrcContractID
        {
            set
            {
                _SrcContractID = value;
            }
            get
            {
                return _SrcContractID;
            }
        }
        public int SrcContractorID
        {
            get
            {
                return _SrcContractorID;
            }
        }
        public string SrcContractorName
        {
            get
            {
                return _SrcContractorName;
            }
        }
        public string SrcContractCellDesc
        {
            get
            {
                return _SrcContractCellDesc;
            }
        }
        public int SrcContractCellID
        {
            get
            {
                return _SrcContractCellID;
            }
        }
        public int SrcContractProcessTypeID
        {
            get
            {
                return _SrcContractProcessTypeID;
            }
        }
        public string SrcContractProcessTypeName
        {
            get
            {
                return _SrcContractProcessTypeName;
            }
        }
        public double SrcElementReferenceValue
        {
            get
            {
                return _SrcElementReferenceValue;
            }
        }
        public double SrcElementUnitPrice
        {
            get
            {
                return _SrcElementUnitPrice;
            }
        }
        public static string SearchStr
        {
            get
            {
                string Returned = "SELECT  dbo.RPContractElementDerived.ContractElementID AS ContractElementDerivedID, "+
                      " dbo.RPContractElementDerived.SrcContractElementID AS ContractElementDerivedSrcID, dbo.RPContractElement.ContractID AS ContractElementDerivedSrcContractID,  "+
                      " dbo.RPContractor.ContractorID AS ContractElementDerivedSrcContractorID, dbo.RPContractor.ContractorFullName AS ContractElementDerivedSrcContractorName,  "+
                      " dbo.RPProcessType.PROCESSTypeID AS ContractElementDerivedSrcProcessTypeID, "+
                      " dbo.RPProcessType.PROCESSTypeNameA AS ContractElementDerivedSrcProcessTypeName "+
                      ", dbo.RPContract.CellID AS ContractElementDerivedSrcCellID"+
                      ",dbo.RPContract.ContractCellDesc AS ContractElementDerivedSrcCellDesc" +
                      ", dbo.RPContractElement.RefrenceValue AS ContractElementDerivedSrcReferenceValue, "+
                      "dbo.RPContractElement.UnitPrice AS ContractElementDerivedSrcUnitPrice"+
                      " FROM   dbo.RPContractor INNER JOIN "+
                      " dbo.RPContract ON dbo.RPContractor.ContractorID = dbo.RPContract.ContractorID INNER JOIN "+
                      " dbo.RPProcessType ON dbo.RPContract.ContractProcessType = dbo.RPProcessType.PROCESSTypeID INNER JOIN "+
                      " dbo.RPContractElement ON dbo.RPContract.ContractID = dbo.RPContractElement.ContractID INNER JOIN "+
                      " dbo.RPContractElementDerived ON dbo.RPContractElement.ContractElementID = dbo.RPContractElementDerived.SrcContractElementID "; 
                return Returned;
            }
        }
        #endregion
        #region Private Methods
        void SetData(DataRow objDr)
        {
            base.SetData(objDr);
            _SrcElementID = int.Parse(objDr["ContractElementDerivedSrcID"].ToString());

            _SrcContractID = int.Parse(objDr["ContractElementDerivedSrcContractID"].ToString());
            _SrcContractorID = int.Parse(objDr["ContractElementDerivedSrcContractorID"].ToString());
            _SrcContractorName = objDr["ContractElementDerivedSrcContractorName"].ToString();
            _SrcContractCellDesc = objDr["ContractElementDerivedSrcCellDesc"].ToString();
            _SrcContractCellID = int.Parse(objDr["ContractElementDerivedSrcCellID"].ToString());
            _SrcContractProcessTypeID = int.Parse(objDr["ContractElementDerivedSrcProcessTypeID"].ToString());
            _SrcContractProcessTypeName = objDr["ContractElementDerivedSrcProcessTypeName"].ToString();
            _SrcElementUnitPrice = double.Parse(objDr["ContractElementDerivedSrcUnitPrice"].ToString());
            _SrcElementReferenceValue = double.Parse(objDr["ContractElementDerivedSrcReferenceValue"].ToString());
        }
        #endregion
        #region Public Methods
        public override void Add()
        {
            base.Add();
            if (_SrcElementFamilyID == 0)
                _SrcElementFamilyID = _ID;
            string strSql = "insert into RPContractElementDerived  (ContractElementID,SrcContractElementID,SrcContractElementFamilyID) " +
                " values (" + _ID + "," + _SrcElementID + "," + _SrcElementFamilyID + ")";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);

        }
        public override void Edit()
        {
            base.Edit();
            if (_SrcElementFamilyID == 0)
                _SrcElementFamilyID = _ID;
            string strSql = "insert into RPContractElementDerived  (ContractElementID,SrcContractElementID,SrcContractElementFamilyID) " +
                " values (" + _ID + "," + _SrcElementID + "," + _SrcElementFamilyID + ")";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }

        #endregion
    }
}
