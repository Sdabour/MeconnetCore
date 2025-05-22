using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using SharpVision.Base.BaseDataBase;
namespace SharpVision.Base.BaseBusiness
{
    public class LocationBiz
    {
        #region Private Data
        protected LocationDb _LocationDb;
        #endregion
        #region Constructors
        public LocationBiz()
        {
            _LocationDb = new LocationDb();
        }
        #endregion
        #region Public Properties
        public int ID
        {
            set
            {
                _LocationDb.ID = value;
            }
            get
            {
                return _LocationDb.ID;
            }
        }
        public int X
        {
            set
            {
                _LocationDb.X= value;
            }
            get
            {
                return _LocationDb.X;
            }
        }
        public int Y
        {
            set
            {
                _LocationDb.Y = value;
            }
            get
            {
                return _LocationDb.Y;
            }
        }
        public int Width
        {
            set
            {
                _LocationDb.Width = value;
            }
            get
            {
                return _LocationDb.Width;
            }
        }
        public int Height
        {
            set
            {
                _LocationDb.Height = value;
            }
            get
            {
                return _LocationDb.Height;
            }
        }
       
        #endregion
        #region Private Methods

        #endregion
        #region Public Methods

        #endregion
    }
}
