using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.UMS.UMSDataBase;
using System.Collections;
using SharpVision.Base.BaseBusiness;
namespace SharpVision.UMS.UMSBusiness
{
    public class GroupCol : BaseCol
    {
        Hashtable _TempGroupTable = new Hashtable();
        public GroupCol()
        {
           
             _TempGroupTable = new Hashtable();
            GroupDb objGroupDb = new GroupDb();
            DataTable dtGroup = objGroupDb.Search();
            //dtGroup.Columns["GroupOrder"].DataType = Type.GetType("System.Int");
            string strOrder = "";
            DataRow[] arrDR = dtGroup.Select("GroupID=GroupFamilyID", strOrder);
            GroupBiz objGroupBiz;
            GroupBiz objTempParent = new GroupBiz();
            string strGroupIDs = "";
            foreach (DataRow DR in arrDR)
            {

                objGroupBiz = new GroupBiz(DR);
                if (_TempGroupTable[objGroupBiz.ID.ToString()] != null)
                    continue;
                if (strGroupIDs != "")
                    strGroupIDs += ",";
                strGroupIDs = strGroupIDs + objGroupBiz.ID.ToString();
                Add(objGroupBiz);
                objGroupBiz.ParentBiz = objTempParent;
                objGroupBiz.Children = new GroupCol(true);
                _TempGroupTable.Add(objGroupBiz.ID.ToString(), objGroupBiz);


            }
            SetChildren(strGroupIDs, ref dtGroup);


        }
        public GroupCol(string strAuxiliaryFunctionIDs)
        {

            _TempGroupTable = new Hashtable();
            GroupDb objGroupDb = new GroupDb();
            objGroupDb.AuxiliaryFunctionIDs = strAuxiliaryFunctionIDs;
            DataTable dtGroup = objGroupDb.Search();
            //dtGroup.Columns["GroupOrder"].DataType = Type.GetType("System.Int");
            string strOrder = "";
            DataRow[] arrDR = dtGroup.Select("GroupID=GroupFamilyID", strOrder);
            GroupBiz objGroupBiz;
            GroupBiz objTempParent = new GroupBiz();
            string strGroupIDs = "";
            foreach (DataRow DR in arrDR)
            {

                objGroupBiz = new GroupBiz(DR);
                if (_TempGroupTable[objGroupBiz.ID.ToString()] != null)
                    continue;
                if (strGroupIDs != "")
                    strGroupIDs += ",";
                strGroupIDs = strGroupIDs + objGroupBiz.ID.ToString();
                Add(objGroupBiz);
                objGroupBiz.ParentBiz = objTempParent;
                objGroupBiz.Children = new GroupCol(true);
                _TempGroupTable.Add(objGroupBiz.ID.ToString(), objGroupBiz);


            }
            SetChildren(strGroupIDs, ref dtGroup);


        }
         public GroupCol(bool blIsEmpty)
        {
            if (!blIsEmpty)
            {
                GroupBiz objGroupBiz = new GroupBiz();
                objGroupBiz.NameA = "€Ì— „Õœœ";
                objGroupBiz.NameE = "Not Specified";
                Add(objGroupBiz);
                GroupDb objGroupDb = new GroupDb();
                DataTable dtTemp = objGroupDb.Search();
                foreach (DataRow objDr in dtTemp.Rows)
                {
                    objGroupBiz = new GroupBiz(objDr);
                    Add(objGroupBiz);
                }

 
            }
 
        }
        public virtual GroupBiz this[int intIndex]
        {
            get
            {

                return (GroupBiz)this.List[intIndex];

            }
        }
        public virtual GroupBiz this[string strIndex]
        {
            get
            {
                GroupBiz Returned = new GroupBiz();
                foreach (GroupBiz objGroupBiz in this)
                {
                    if (objGroupBiz.Name == strIndex)
                    {
                        Returned = objGroupBiz;
                        break;
                    }
                }
                return Returned;
            }
        }
        static GroupCol _CacheGroupCol;
        public static GroupCol CacheGroupCol
        {
            get
            { 
            if(_CacheGroupCol == null)
                {
                    _CacheGroupCol = new GroupCol(false);
                    
                }
                return _CacheGroupCol;
            }
        }
        //public string IDsStr
        //{
        //    get
        //    {
        //        string Returned = "";

        //        return Returned;
        //    }
        //}
        void SetChildren(string strGroupIDs, ref DataTable dtGroups)
        {
            if (strGroupIDs == "")
                return;
            GroupBiz objParentGroupBiz;
            DataRow[] arrDR = dtGroups.Select("GroupID <> GroupParentID " +
                " and GroupParentID in (" + strGroupIDs + ") ", "");
            GroupBiz objGroupBiz;
            GroupCol objGroupCol;
            objGroupCol = new GroupCol(true);
            strGroupIDs = "";
            foreach (DataRow DR in arrDR)
            {
                objGroupBiz = new GroupBiz(DR);
                if (_TempGroupTable[objGroupBiz.ID.ToString()] != null)
                    continue;
                if (strGroupIDs != "")
                    strGroupIDs = strGroupIDs + ",";
                strGroupIDs = strGroupIDs + objGroupBiz.ID.ToString();
                objParentGroupBiz = (GroupBiz)_TempGroupTable[objGroupBiz.ParentID.ToString()];
                objParentGroupBiz.Children.Add(objGroupBiz);
                objGroupBiz.Children = new GroupCol(true);
                _TempGroupTable.Add(objGroupBiz.ID.ToString(), objGroupBiz);
                objGroupBiz.ParentBiz = objParentGroupBiz;
            }
            SetChildren(strGroupIDs, ref dtGroups);

        }

        void SetGroupChildren(ref GroupBiz objGroupBiz, ref DataTable dtGroup)
        {
            
            objGroupBiz.GroupChildren = new GroupCol(true);
            objGroupBiz.Children = new GroupCol(true);
            DataRow[] arrDR = dtGroup.Select("GroupID <> GroupParentID and GroupParentID=" + objGroupBiz.ID, "GroupName");
            GroupBiz tempGroupBiz;
            GroupCol objGroupCol;
            objGroupCol = new GroupCol(true);
            foreach (DataRow DR in arrDR)
            {
                tempGroupBiz = new GroupBiz(DR);
                SetGroupChildren(ref tempGroupBiz, ref dtGroup);
                tempGroupBiz.ParentBiz = objGroupBiz;
                objGroupCol.Add(tempGroupBiz);

            }
            objGroupBiz.GroupChildren = objGroupCol;
            objGroupBiz.Children = objGroupCol;

        }
        void SetChildrenCol(ref GroupCol objGroupCol, string strGroup, GroupBiz objGroupBiz)
        {
            if (objGroupBiz.Name.IndexOf(strGroup) != -1)
                objGroupCol.Add(objGroupBiz);
            else
            {
                if (objGroupBiz.Children != null)
                {
                    foreach (GroupBiz objBiz in objGroupBiz.Children)
                    {
                        SetChildrenCol(ref objGroupCol, strGroup, objBiz);
                    }
                }
            }
        }
     
        public virtual void Add(GroupBiz objGroupBiz)
        {
            if (this[objGroupBiz.Name].Name ==null  || this[objGroupBiz.Name].Name=="")
            {
                this.List.Add(objGroupBiz);
            }

        }

    
    public virtual void Add(GroupCol objGroupCol)
        {
            foreach (GroupBiz objGroupBiz in objGroupCol)
            {
                if(this[objGroupBiz.Name].ID==0)
                    this.List.Add(objGroupBiz.Copy());
                
            }
        }
        public GroupCol GetGroupCol(string strGroupName)
        {
            GroupCol Returned = new GroupCol(true);
            foreach (GroupBiz objGroupbiz in this)
            {
                SetChildrenCol(ref Returned, strGroupName, objGroupbiz);
            }
            return Returned;
        }
        public GroupCol Copy()
        {
            GroupCol Returned = new GroupCol(true);
            foreach (GroupBiz objTemp in this)
            {
                Returned.Add(objTemp.Copy());
            }
            return Returned;
        }

    }
}
