using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.UMS.UMSDataBase;
using System.Collections;
namespace SharpVision.UMS.UMSBusiness
{
    public class GroupTypeCol : CollectionBase
    {
       #region PrivateData
        #endregion
        
        public GroupTypeCol()
        {
            GroupTypeDb objGroupTypeDb = new GroupTypeDb();
            DataTable dtGroupType = objGroupTypeDb.Search();

            DataRow[] arrDR = dtGroupType.Select("GroupTypeID=GroupTypeParentID","GroupTypeName");
            GroupTypeBiz objGroupTypeBiz;
            foreach (DataRow DR in arrDR)
            {
                objGroupTypeBiz = new GroupTypeBiz(DR);
                
                SetGroupTypeChildren(ref objGroupTypeBiz,ref dtGroupType);
                this.Add(objGroupTypeBiz);

            }
          
        }
        public GroupTypeCol(bool blIsEmpty)
        {
            if (!blIsEmpty)
            {
                GroupTypeDb objGroupTypeDb = new GroupTypeDb();
                DataTable dtGroupType = objGroupTypeDb.Search();

                DataRow[] arrDR = dtGroupType.Select("GroupTypeID=GroupTypeParentID", "GroupTypeName");
                GroupTypeBiz objGroupTypeBiz;
                objGroupTypeBiz = new GroupTypeBiz();
                objGroupTypeBiz.ID = 0;
                objGroupTypeBiz.Name = "€Ì— „Õœœ";
                this.Add(objGroupTypeBiz);
                foreach (DataRow DR in arrDR)
                {
                    objGroupTypeBiz = new GroupTypeBiz(DR);

                    SetGroupTypeChildren(ref objGroupTypeBiz, ref dtGroupType);
                    this.Add(objGroupTypeBiz);

                }
            }

 
        }
        public virtual GroupTypeBiz this[int intIndex]
        {
            get
            {
                return (GroupTypeBiz)this.List[intIndex];
            }
        }
        public virtual GroupTypeBiz this[string strIndex]
        {
            get
            {
                GroupTypeBiz Returned = new GroupTypeBiz();
                foreach (GroupTypeBiz objGroupTypeBiz in this)
                {
                    if (objGroupTypeBiz.Name == strIndex)
                    {
                        Returned = objGroupTypeBiz.Copy();
                        break;
                    }
                }
                return Returned;
            }
        }
        static GroupTypeCol _CacheTypeCol;
        public static GroupTypeCol CacheTypeCol
        {
            get
            {
                if(_CacheTypeCol==null)
                {
                    _CacheTypeCol = new GroupTypeCol(false);
                }
                return _CacheTypeCol;
            }
        }
        #region  Privaet methods
        void SetGroupTypeChildren(ref GroupTypeBiz objGroupTypeBiz,ref DataTable dtGroupTypes )
        {
            objGroupTypeBiz.GroupTypeChildren = new GroupTypeCol(true);
            DataRow[] arrDR = dtGroupTypes.Select("GroupTypeID <> GroupTypeParentID and GroupTypeParentID=" + objGroupTypeBiz.ID , "GroupTypeName");
            GroupTypeBiz tempGroupTypeBiz;
            GroupTypeCol objGroupTypeCol;
            objGroupTypeCol = new GroupTypeCol(true);
            foreach (DataRow DR in arrDR)
            {
                tempGroupTypeBiz = new GroupTypeBiz(DR);
                SetGroupTypeChildren(ref tempGroupTypeBiz, ref dtGroupTypes);
                tempGroupTypeBiz.ParentBiz = objGroupTypeBiz;
                objGroupTypeCol.Add(tempGroupTypeBiz);

            }
            objGroupTypeBiz.GroupTypeChildren = objGroupTypeCol;
 
        }
        
        #endregion
        public virtual void Add(GroupTypeBiz objGroupTypeBiz)
        {
            this.List.Add(objGroupTypeBiz);
        }

        public virtual void Add(GroupTypeCol objGroupTypeCol)
        {
            foreach (GroupTypeBiz objGroupTypeBiz in objGroupTypeCol)
            {
                if(this[objGroupTypeBiz.Name].ID==0)
                    this.List.Add(objGroupTypeBiz.Copy());
                
            }
        }

        public GroupTypeCol Copy()
        {
            GroupTypeCol Returned = new GroupTypeCol(true);
            foreach (GroupTypeBiz objTemp in this)
            {
                Returned.Add(objTemp.Copy());
            }
            return Returned;
        }

   

    }
}
