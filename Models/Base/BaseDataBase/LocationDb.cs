using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
namespace SharpVision.Base.BaseDataBase
{
    public class LocationDb
    {
        #region Private Data
        protected int _ID;
        protected int _X;
        protected int _Y;
        protected int _Width;
        protected int _Height;
        protected int _ImageID;
        #endregion
        #region Constructors

        #endregion
        #region Public Properties
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
        public int X
        {
            set
            {
                _X = value;
            }
            get
            {
                return _X;
            }
        }
        public int Y
        {
            set
            {
                _Y = value;
            }
            get
            {
                return _Y;
            }
        }
        public int Width
        {
            set
            {
                _Width = value;
            }
            get
            {
                return _Width;
            }
        }
        public int Height
        {
            set
            {
                _Height = value;
            }
            get
            {
                return _Height;
            }
        }
        public int ImageID
        {
            set
            {
                _ImageID = value;
            }
            get 
            {
                return _ImageID;
            }
        }
        #endregion
        #region Private Methods

        #endregion
        #region Public Methods
      
        #endregion
    }
}
