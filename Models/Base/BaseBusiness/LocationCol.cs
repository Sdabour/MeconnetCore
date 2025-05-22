using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Collections;
using SharpVision.Base.BaseDataBase;
namespace SharpVision.Base.BaseBusiness
{
    public class LocationCol:CollectionBase
    {
        #region Private Data

        #endregion
        #region Constructors
        public LocationCol(bool blIsEmpty)
        {
 
        }
        #endregion
        #region Public Properties
        public LocationBiz this[int intIndex]
        {
            set
            {
                List[intIndex] = value;
            }
            get
            {
                return (LocationBiz)List[intIndex];
            }
        }
        public string IDsStr
        {
            get
            {
                string Returned = "";
                foreach (LocationBiz objBiz in this)
                {
                    if (objBiz.ID != 0)
                    {
                        if (Returned != "")
                            Returned += ",";
                        Returned += objBiz.ID.ToString();
                    }
                }
                return Returned;
            }
        }
        #endregion
        #region Private Methods

        #endregion
        #region Public Methods
        public LocationCol GetLocationCol(int intX, int intY)
        {
            LocationCol Returned = new LocationCol(true);
            int intMaxX, intMaxY;
            foreach (LocationBiz objBiz in this)
            {
                intMaxX = objBiz.X + objBiz.Width;
                intMaxY = objBiz.Height;
                if ((intX >= objBiz.X && intX <= intMaxX) && (intY >= objBiz.Y && intY <= intMaxY))
                    Returned.Add(objBiz);
               
            }
            return Returned;

        }
        public int GetLocationIndex(int intX, int intY)
        {
            int intMaxX, intMaxY;
            int intIndex = 0;
            foreach (LocationBiz objBiz in this)
            {
                intMaxX = objBiz.X + objBiz.Width;
                intMaxY = objBiz.Height;
                if ((intX >= objBiz.X && intX <= intMaxX) && (intY >= objBiz.Y && intY <= intMaxY))
                    return intIndex;
                intIndex++;

            }
            return -1;
        }
        public void Add(LocationBiz objBiz)
        {
            List.Add(objBiz);
        }
        #endregion
    }
}
