using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpVision.SystemBase;
using System.Data;
namespace SharpVision.HR.HRDataBase
{
   public  class EstimationAssignmentElementDb
    {

        #region Constructor
        public EstimationAssignmentElementDb()
        {
        }
        public EstimationAssignmentElementDb(DataRow objDr)
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
        int _ElementID;
        public int ElementID
        {
            set
            {
                _ElementID = value;
            }
            get
            {
                return _ElementID;
            }
        }
        int _ElementGroup;
        public int ElementGroup
        {
            set
            {
                _ElementGroup = value;
            }
            get
            {
                return _ElementGroup;
            }
        }
        double _ElementGroupPerc;
        public double ElementGroupPerc
        {
            set
            {
                _ElementGroupPerc = value;
            }
            get
            {
                return _ElementGroupPerc;
            }
        }
        int _ElementGroupOrder;
        public int ElementGroupOrder
        {
            set
            {
                _ElementGroupOrder = value;
            }
            get
            {
                return _ElementGroupOrder;
            }
        }
        double _ElementWeight;
        public double ElementWeight
        {
            set
            {
                _ElementWeight = value;
            }
            get
            {
                return _ElementWeight;
            }
        }
        bool _ElementIsFuzzy;
        public bool ElementIsFuzzy
        {
            set
            {
                _ElementIsFuzzy = value;
            }
            get
            {
                return _ElementIsFuzzy;
            }
        }
        double _ElementValue;
        public double ElementValue
        {
            set
            {
                _ElementValue = value;
            }
            get
            {
                return _ElementValue;
            }
        }
       
        int _ElementOrder;
        public int ElementOrder
        { set => _ElementOrder = value;
            get => _ElementOrder;
        }
        int _GroupElelemntID;
        public int GroupElelemntID
        {
            set
            {
                _GroupElelemntID = value;
            }
            get
            {
                return _GroupElelemntID;
            }
        }
        string _GroupElementCode;
        public string GroupElementCode
        {
            set
            {
                _GroupElementCode = value;
            }
            get
            {
                return _GroupElementCode;
            }
        }
        string _GroupElementNameA;
        public string GroupElementNameA
        {
            set
            {
                _GroupElementNameA = value;
            }
            get
            {
                return _GroupElementNameA;
            }
        }
        string _GroupElementNameE;
        public string GroupElementNameE
        {
            set
            {
                _GroupElementNameE = value;
            }
            get
            {
                return _GroupElementNameE;
            }
        }
        string _AssignmentIDs;
        public string AssignmentIDs
        { set => _AssignmentIDs = value; }
        public string AddStr
        {
            get
            {
                string Returned = " insert into HREstimationAssignmentElement  (AssignmentID,AssignmentElementID,AssignmentElementGroup,AssignmentElementGroupPerc,AssignmentElementGroupOrder,AssignmentElementWeight,AssignmentElementIsFuzzy,AssignmentElementValue,AssignmentElementOrder) values (" + ID + "," + ElementID + "," + ElementGroup + "," + ElementGroupPerc + "," + ElementGroupOrder + "," + ElementWeight + "," + (ElementIsFuzzy ? 1 : 0) + "," + ElementValue + "," + _ElementOrder+ ") ";
                return Returned;
            }
        }
        public string EditStr
        {
            get
            {
                string Returned = " update HREstimationAssignmentElement  set " + "AssignmentID=" + ID + "" +
           ",AssignmentElementID=" + ElementID + "" +
           ",AssignmentElementGroup=" + ElementGroup + "" +
           ",AssignmentElementGroupPerc=" + ElementGroupPerc + "" +
           ",AssignmentElementGroupOrder=" + ElementGroupOrder + "" +
           ",AssignmentElementWeight=" + ElementWeight + "" +
           ",AssignmentElementIsFuzzy=" + (ElementIsFuzzy ? 1 : 0) + "" +
           ",AssignmentElementValue=" + ElementValue + "" +
           ",AssignmentGroupElelemntID=" + GroupElelemntID + "" +
           ",AssignmentGroupElementCode='" + GroupElementCode + "'" +
           ",AssignmentGroupElementNameA='" + GroupElementNameA + "'" +
           ",AssignmentGroupElementNameE='" + GroupElementNameE + "'" + ",UsrUpd=" + SysData.CurrentUser.ID + @",TimUpd=GetDate()  where ";
                return Returned;
            }
        }
        public string DeleteStr
        {
            get
            {
                string Returned = " update HREstimationAssignmentElement  set Dis = GetDate() where  ";
                return Returned;
            }
        }
        public string SearchStr
        {
            get
            {
                string Returned = @"SELECT        dbo.HREstimationAssignmentElement.AssignmentID, dbo.HREstimationAssignmentElement.AssignmentElementID, dbo.HREstimationAssignmentElement.AssignmentElementGroup, 
                         dbo.HREstimationAssignmentElement.AssignmentElementGroupPerc, dbo.HREstimationAssignmentElement.AssignmentElementGroupOrder, dbo.HREstimationAssignmentElement.AssignmentElementWeight, 
                         dbo.HREstimationAssignmentElement.AssignmentElementIsFuzzy, dbo.HREstimationAssignmentElement.AssignmentElementValue,AssignmentElementOrder, dbo.HRElementGroup.GroupElementID AS AssignmentGroupElelemntID, 
                         dbo.HRElementGroup.GroupElementCode AS AssignmentGroupElementCode, dbo.HRElementGroup.GroupElementNameA AS AssignmentGroupElementNameA, 
                         dbo.HRElementGroup.GroupElementNameE AS AssignmentGroupElementNameE,ElementTable.* 
FROM            dbo.HREstimationAssignmentElement 
 inner join (" + ElementDb.SearchStr + @") as ElementTable
 on dbo.HREstimationAssignmentElement.AssignmentElementID = ElementTable.ElementID 
 LEFT OUTER JOIN
                         dbo.HRElementGroup ON dbo.HREstimationAssignmentElement.AssignmentElementGroup = dbo.HRElementGroup.GroupElementID";
                return Returned;
            }
        }
        #endregion
        #region Private Method
        void SetData(DataRow objDr)
        {

            if (objDr.Table.Columns["AssignmentID"] != null)
                int.TryParse(objDr["AssignmentID"].ToString(), out _ID);

            if (objDr.Table.Columns["AssignmentElementID"] != null)
                int.TryParse(objDr["AssignmentElementID"].ToString(), out _ElementID);

            if (objDr.Table.Columns["AssignmentElementGroup"] != null)
                int.TryParse(objDr["AssignmentElementGroup"].ToString(), out _ElementGroup);

            if (objDr.Table.Columns["AssignmentElementGroupPerc"] != null)
                double.TryParse(objDr["AssignmentElementGroupPerc"].ToString(), out _ElementGroupPerc);

            if (objDr.Table.Columns["AssignmentElementGroupOrder"] != null)
                int.TryParse(objDr["AssignmentElementGroupOrder"].ToString(), out _ElementGroupOrder);

            if (objDr.Table.Columns["AssignmentElementWeight"] != null)
                double.TryParse(objDr["AssignmentElementWeight"].ToString(), out _ElementWeight);

            if (objDr.Table.Columns["AssignmentElementIsFuzzy"] != null)
                bool.TryParse(objDr["AssignmentElementIsFuzzy"].ToString(), out _ElementIsFuzzy);

            if (objDr.Table.Columns["AssignmentElementValue"] != null)
                double.TryParse(objDr["AssignmentElementValue"].ToString(), out _ElementValue);
            if (objDr.Table.Columns["AssignmentElementOrder"] != null)
                int.TryParse(objDr["AssignmentElementOrder"].ToString(), out _ElementOrder);

            if (objDr.Table.Columns["AssignmentGroupElelemntID"] != null)
                int.TryParse(objDr["AssignmentGroupElelemntID"].ToString(), out _GroupElelemntID);

            if (objDr.Table.Columns["AssignmentGroupElementCode"] != null)
                _GroupElementCode = objDr["AssignmentGroupElementCode"].ToString();

            if (objDr.Table.Columns["AssignmentGroupElementNameA"] != null)
                _GroupElementNameA = objDr["AssignmentGroupElementNameA"].ToString();

            if (objDr.Table.Columns["AssignmentGroupElementNameE"] != null)
                _GroupElementNameE = objDr["AssignmentGroupElementNameE"].ToString();
        }

        #endregion
        #region Public Method 
        public void Add()
        {
            string strSql = AddStr;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
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
            string strSql = SearchStr + " where (1=1) ";
            if (ID != 0)
                strSql += " and AssignmentID =" + ID;
            if(_AssignmentIDs!= null && _AssignmentIDs!= "")
                strSql += " and AssignmentID in (" + _AssignmentIDs +")";
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        #endregion
    }
}
