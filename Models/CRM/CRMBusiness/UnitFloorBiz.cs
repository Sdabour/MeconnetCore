using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
namespace SharpVision.CRM.CRMBusiness
{
    public class UnitFloorBiz
    {
        #region Private Data
        int _Value;


        string _Code;


        string _Name;

        UnitCol _UnitCol;
        Hashtable _UnitHs;
        #endregion
        #region Constructors

        public UnitFloorBiz()
        {

        }
        public UnitFloorBiz(int intValue)
        {
            if (intValue < 96 || intValue > FloorStrCol.Count + 96)
                return;
            Value = intValue;
            Name = FloorStrCol[intValue - 96];
            Code = FloorCodeStrCol[intValue - 96];
        }
        #endregion
        #region Public Properties
        public int Value
        {
            get { return _Value; }
            set { _Value = value; }
        }
        public string Code
        {
            get { return _Code; }
            set { _Code = value; }
        }
        public string Name
        {
            get { return _Name == null ? "" : _Name; }
            set { _Name = value; }
        }
        public static List<string> FloorStrCol
        {
            get
            {
                List<string> Returned = new List<string>();
                Returned.Add("ÇáÈÏÑæã ÇáËÇáË");
                Returned.Add("ÇáÈÏÑæã ÇáËÇäì");
                Returned.Add("ÇáÈÏÑæã");
                Returned.Add("ÇáÇÑÖì ãäÎİÖ");
                Returned.Add("ÇáÇÑÖì");
                Returned.Add("ÇáÇæá");
                Returned.Add("ÇáËÇäì");
                Returned.Add("ÇáËÇáË");
                Returned.Add("ÇáÑÇÈÚ");
                Returned.Add("ÇáÎÇãÓ");
                Returned.Add("ÇáÓÇÏÓ");
                Returned.Add("ÇáÓÇÈÚ");
                Returned.Add("ÇáËÇãä");
                Returned.Add("ÇáÊÇÓÚ");
                Returned.Add("ÇáÚÇÔÑ");
                Returned.Add("ÇáÍÇÏì ÚÔÑ");
                Returned.Add("ÇáËÇäì ÚÔÑ");
                Returned.Add("ÇáËÇáË ÚÔÑ");
                Returned.Add("ÇáÑÇÈÚ ÚÔÑ");
                Returned.Add("ÇáÎÇãÓ ÚÔÑ");
                Returned.Add("ÇáÓÇÏÓ ÚÔÑ");
                Returned.Add("ÇáÓÇÈÚ ÚÔÑ");
                Returned.Add("ÇáËÇãä ÚÔÑ");
                Returned.Add("ÇáÊÇÓÚ ÚÔÑ");
                Returned.Add("ÇáÚÔÑíä");
                return Returned;
            }
        }
        public static List<string> FloorCodeStrCol
        {
            get
            {
                List<string> Returned = new List<string>();
                Returned.Add("B3");
                Returned.Add("B2");
                Returned.Add("B");
                Returned.Add("GL");
                Returned.Add("G");
                Returned.Add("1st");
                Returned.Add("2nd");
                Returned.Add("3rd");
                Returned.Add("4th");
                Returned.Add("5th");
                Returned.Add("6th");
                Returned.Add("7th");
                Returned.Add("8th");
                Returned.Add("9th");
                Returned.Add("10th");
                Returned.Add("11th");
                Returned.Add("12th");
                Returned.Add("13th");
                Returned.Add("14th");
                Returned.Add("15th");
                Returned.Add("16th");
                Returned.Add("17th");
                Returned.Add("18th");
                Returned.Add("19th");
                Returned.Add("20th");
                return Returned;
            }
        }

        public static UnitFloorCol FloorCol
        {
            get
            {
                UnitFloorCol Returned = new UnitFloorCol(true);
                UnitFloorBiz objBiz = new UnitFloorBiz();
                objBiz.Value = 0;
                objBiz.Name = "ÛíÑ ãÍÏÏ";
                Returned.Add(objBiz);

                for (int intIndex = 96; intIndex < FloorStrCol.Count + 96; intIndex++)
                {
                    objBiz = new UnitFloorBiz();
                    objBiz.Value = intIndex;
                    objBiz.Name = FloorStrCol[intIndex - 96];
                    objBiz.Code = FloorCodeStrCol[intIndex - 96];
                    Returned.Add(objBiz);
                }

                return Returned;
            }
        }
        public UnitCol UnitCol
        {
            get
            {
                if (_UnitCol == null)
                {
                    _UnitCol = new UnitCol(true);
                }
                return _UnitCol;
            }
            set
            {
                _UnitCol = value;
            }
        }
        public Hashtable UnitHs
        {
            set
            {
                _UnitHs = value;
            }
            get
            {
                if (_UnitHs == null)
                    _UnitHs = new Hashtable();
                return _UnitHs;
            }
        }
        public FloorBiz FloorBiz
        {
            get
            {
                FloorBiz Returned = new FloorBiz();
                Returned.Code = Code;
                Returned.Value = Value;
                Returned.ID = Value - 96 + 1;
                Returned.NameA = Name;

                return Returned;
            }
        }
        #endregion
        #region Private Methods

        #endregion
        #region Public Methods
        public void AddUnit(UnitBiz objUnitBiz)
        {
            if (UnitHs[objUnitBiz.Code] == null)
            {
                UnitHs.Add(objUnitBiz.Code, objUnitBiz);
            }
            if (_UnitCol == null)
                _UnitCol = new UnitCol(true);
            _UnitCol.Add(objUnitBiz);
        }
        #endregion
    }
}
