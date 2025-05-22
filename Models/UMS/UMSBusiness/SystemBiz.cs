using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.UMS.UMSDataBase;

namespace SharpVision.UMS.UMSBusiness
{



    public class SystemBiz
    {
        #region Private Data
        SystemDb _SystemDb;
       
        
        #endregion
        #region Constructors
        public SystemBiz()
        {
            _SystemDb = new SystemDb();
        }
        public SystemBiz(int intSystemID)
        {
            _SystemDb = new SystemDb(intSystemID);
            
        }
        public SystemBiz(DataRow objDR)
        {
            _SystemDb = new SystemDb(objDR);
            
        }
       
        #endregion
        #region Public Properties
        public int ID
        {
            set
            {
                _SystemDb.ID = value;
            }
            get
            {
                return _SystemDb.ID;
            }
        }
        public string Name
        {
            set
            {
                _SystemDb.Name = value;
            }
            get
            {
                return _SystemDb.Name;
            }
        }
        public string Desc
        {
            set
            {
                _SystemDb.Desc = value;
            }
            get
            {
                return _SystemDb.Desc ;
            }
        }
        public int CurrentVersion
        {
            set
            {
                _SystemDb.CurrentVersion = value;
            }
            get
            {
                return _SystemDb.CurrentVersion;
            }
        }
        public string Directory
        {
            set
            {
                _SystemDb.Directory = value;
            }
            get
            {
              //  _SystemTypeBiz = new SystemTypeBiz(_SystemDb.SystemTypeDb);
                return _SystemDb.Directory;
            }
        }
        public string Url
        {
            set
            {
                _SystemDb.Url = value;
            }
            get
            {
                return _SystemDb.Url;
            }
        }
        MenuNodeCol _NodeCol;
        public MenuNodeCol NodeCol
        {
            set
            {
                _NodeCol = value;
            }
            get
            {
                if (_NodeCol == null)
                {
                    _NodeCol = new MenuNodeCol(true);
                    MenuNodeDb objDB = new MenuNodeDb();
                    objDB.System = ID;
                    DataTable dtTemp = objDB.Search();
                    foreach (DataRow objDr in dtTemp.Rows)
                        _NodeCol.Add(new MenuNodeBiz(objDr));

                }
                return _NodeCol;
            }
        }
        #endregion
        #region Public Methods
        
        public static void Add(string strName, string strDesc, int intCurrentVersion,string strDirectory,string strUrl)
        {
            strUrl = (strDirectory == "" ? strUrl : "");
            SystemDb objSystemDb = new SystemDb();
            objSystemDb.Name = strName;
            objSystemDb.Desc = strDesc;
            objSystemDb.Directory = strDirectory;
            objSystemDb.CurrentVersion = intCurrentVersion;
            objSystemDb.Url = strUrl;
            objSystemDb.Add();
        
        }
        public static void Edit(int intSystemID ,string strName, string strDesc, int intCurrentVersion,string strDirectory,string strUrl)
        {
            strUrl = (strDirectory == ""?strUrl : "");
            SystemDb objSystemDb = new SystemDb();
            objSystemDb.ID = intSystemID;
            objSystemDb.Name = strName;
            objSystemDb.Desc = strDesc;
            objSystemDb.Directory = strDirectory;
            objSystemDb.CurrentVersion = intCurrentVersion;
            objSystemDb.Url = strUrl;
            objSystemDb.Edit();
        
        }
        public static void Delete(int intSystemID)
        {
            SystemDb objSystemDb = new SystemDb();
            objSystemDb.ID = intSystemID;
            objSystemDb.Delete();
        }
        public SystemBiz Copy()
        {
            SystemBiz Returned = new SystemBiz();
            Returned.ID = this.ID;
            Returned.Name = this.Name;
            Returned.Desc = this.Desc;
            Returned.Directory = this.Directory;
            Returned.CurrentVersion = this.CurrentVersion;
            Returned.Url = this.Url;
            return Returned;
        }
        #endregion
    }
}
