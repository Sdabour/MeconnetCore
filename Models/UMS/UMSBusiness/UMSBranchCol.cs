using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.UMS.UMSDataBase;
using System.Collections;
//using System.Linq;
namespace SharpVision.UMS.UMSBusiness
{
    public class UMSBranchCol : CollectionBase
    {
        static UMSBranchCol _BranchCol;
        Hashtable _BranchHash = new Hashtable();
        public static UMSBranchCol BranchCol
        {
            get {
                if (_BranchCol == null)
                    _BranchCol = new UMSBranchCol(false);
                return UMSBranchCol._BranchCol; }
            set { UMSBranchCol._BranchCol = value; }
        }
        public UMSBranchCol()
        {
            UMSBranchDb objUMSBranchDb = new UMSBranchDb();

            UMSBranchBiz objUMSBranchBiz;
            foreach (DataRow DR in objUMSBranchDb.Search().Rows)
            {
                objUMSBranchBiz = new UMSBranchBiz(DR);
                this.Add(objUMSBranchBiz);

            }


        }
        public UMSBranchCol(bool blIsEmpty)
        {
            if (blIsEmpty)
                return;
            UMSBranchDb objUMSBranchDb = new UMSBranchDb();

            UMSBranchBiz objUMSBranchBiz = new UMSBranchBiz();
            objUMSBranchBiz.Name = "€Ì— „Õœœ";
            Add(objUMSBranchBiz);
            DataTable dtTemp = objUMSBranchDb.Search();
            foreach (DataRow DR in dtTemp.Rows)
            {
                objUMSBranchBiz = new UMSBranchBiz(DR);
                this.Add(objUMSBranchBiz);

            }
        }

        public bool Contains(string strName)
        {
            bool blReturned = false;
            foreach (UMSBranchBiz objUMSBranchBiz in this)
            {
                if (objUMSBranchBiz.Name == strName)
                {
                    blReturned = true;
                    break;
                }
            }
            return blReturned;

        }
        public virtual UMSBranchBiz this[int intIndex]
        {
            get
            {

                return (UMSBranchBiz)this.List[intIndex];

            }
        }

        public virtual UMSBranchBiz this[string strIndex]
        {
            get
            {
                UMSBranchBiz Returned = new UMSBranchBiz();
                if (strIndex == null)
                    strIndex = "";
                if (_BranchHash[strIndex] != null)
                    Returned = (UMSBranchBiz)_BranchHash[strIndex];

                return Returned;
            }
        }
        public static UMSBranchCol NonStoppedBranchCol
        {
            get
            {
                UMSBranchCol Returned = new UMSBranchCol(true);
                //IEnumerable<UMSBranchBiz> objCol = from objBiz in BranchCol.Cast<UMSBranchBiz>()
                //                                   where objBiz.IsStopped == true
                //                                   select objBiz;

                return Returned;
            }
        }
        public virtual void Add(UMSBranchBiz objUMSBranchBiz)
        {
            if (_BranchHash[objUMSBranchBiz.ID.ToString()] == null)
                _BranchHash.Add(objUMSBranchBiz.ID.ToString(), objUMSBranchBiz);

            this.List.Add(objUMSBranchBiz);

        }

        public UMSBranchCol Copy()
        {
            UMSBranchCol Returned = new UMSBranchCol(true);
            foreach (UMSBranchBiz objTemp in this)
            {
                Returned.Add(objTemp.Copy());
            }
            return Returned;
        }
        public UMSBranchCol GetCol(string strName)
        {
            UMSBranchCol Returned = new UMSBranchCol(true);
            string[] arrStr = strName.Split("%".ToCharArray());

            bool blIsFound = false;
            foreach (UMSBranchBiz objBiz in this)
            {
                blIsFound = true;
                foreach (string strTemp in arrStr)
                {
                    if (objBiz.Name.IndexOf(strTemp) == -1)
                        blIsFound = false;
                }
                if (blIsFound)
                    Returned.Add(objBiz);
            }
            return Returned;
        }


    }
}

