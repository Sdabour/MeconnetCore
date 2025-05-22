using System;
using System.Collections.Generic;
using System.Text;
using System.Data;


namespace SharpVision.UMS.UMSDataBase
{
    public class GroupTypeDb
    {
        #region Private Data
        protected int _ID;
        protected string _Name;
        protected int _ParentID;
        protected int _FamilyID;
        
        #endregion
        #region Constructors
        public GroupTypeDb()
        {
           
        }
        public GroupTypeDb(int intGroupTypeID)
        {

            _ID = intGroupTypeID;
            DataTable dtTemp = Search();
            DataRow objDR = dtTemp.Rows[0];
            _Name = objDR["GroupTypeName"].ToString();
            _ParentID = int.Parse(objDR["GroupTypeParentID"].ToString());
            _FamilyID = int.Parse(objDR["GroupTypeFamilyID"].ToString());
           
            
        }
        public GroupTypeDb(DataRow objDR)
        {

            try
            {
                _ID = int.Parse(objDR["GroupTypeID"].ToString());
                _Name = objDR["GroupTypeName"].ToString();
                _ParentID = int.Parse(objDR["GroupTypeParentID"].ToString());
                _FamilyID = int.Parse(objDR["GroupTypeFamilyID"].ToString());
            }
            catch
            { 
            }
          
        }
        
        #endregion
        #region Public Poberities
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
        public string Name
        {
            set
            {
                _Name = value;
            }
            get
            {
                return _Name;
            }
        }
        
        public int ParentID
        {
            set
            {
                _ParentID = value;
            }
            get
            {
                return _ParentID;
            }
        }
        public int FamilyID
        {
            set
            {
                _FamilyID = value;
            }
            get
            {
                return _FamilyID;
            }
        }
        #endregion
        #region Public Methods
        public virtual void Add()
        {
            _ParentID = _ParentID == 0 ? _ID : _ParentID;
            _FamilyID = _FamilyID == 0 ? _ID : _FamilyID;
            string strSql = "INSERT INTO UMSGroupType (GroupTypeName, GroupTypeParentID ,GroupTypeFamilyID)"+
                            " VALUES ('" + _Name + "'," + _ParentID + "," + _FamilyID + ")";
            if (_ParentID == 0)
            {
                _ID = BaseDb.UMSBaseDb.InsertIdentityTable(strSql);
                strSql = "update UMSGroupType set GroupTypeParentID = " + _ID + ", GroupTypeFamilyID =" + _ID;
                strSql = strSql + " where GroupTypeID = " + _ID;
                BaseDb.UMSBaseDb.ExecuteNonQuery(strSql);
            }
            else
             BaseDb.UMSBaseDb.ExecuteNonQuery(strSql);
        }
        public virtual void Edit()
        {
            _ParentID = _ParentID == 0 ? _ID : _ParentID;
            _FamilyID = _FamilyID == 0 ? _ID : _FamilyID;           //  _FamilyID = _ParentID == _ID ? _ID : new GroupTypeDb(_ParentID)._FamilyID;
            string strSql = "UPDATE UMSGroupType SET GroupTypeName='" + _Name + "' ," ;
            strSql = strSql + "GroupTypeParentID= " + _ParentID + " ,";
            strSql = strSql + "GroupTypeFamilyID= " + _FamilyID + " ";
            strSql = strSql + " WHERE GroupTypeID=" + _ID;

             BaseDb.UMSBaseDb.ExecuteNonQuery(strSql);
        }
        public virtual void Delete()
        {

            string strSql = "update UMSGroupType set Dis=Getdate() WHERE GroupTypeID="+_ID;
             BaseDb.UMSBaseDb.ExecuteNonQuery(strSql);
        }
        public virtual DataTable Search()
        {
            string strSql = "SELECT GroupTypeID, GroupTypeName, GroupTypeParentID,GroupTypeFamilyID  "+
                            " FROM      UMSGroupType "+
                            " WHERE     (Dis IS NULL)";
            if(_ID != 0 )
            {
                strSql = strSql +" AND GroupTypeID= "+_ID;
            }
            if (_FamilyID != 0)
                strSql = strSql + " AND GroupTypeFamilyID = " + _FamilyID;
            if (_ParentID != 0)
                strSql = strSql + " AND GroupTypeParentID = " + _ParentID;

          DataTable dtReturned =   BaseDb.UMSBaseDb.ReturnDatatable(strSql);
            return dtReturned;
        }
        #endregion
    }
}

