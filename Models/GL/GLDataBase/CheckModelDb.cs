using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.SystemBase;
using SharpVision.Base.BaseDataBase;
using SharpVision.COMMON.COMMONDataBase;
namespace SharpVision.GL.GLDataBase
{
   public  class CheckModelDb
   {
       #region Private Data
       private int _ID;
        private int _FormatID;
        private string _Name;
        private int _Image;
        private string _DateSpacing;
        private bool _PayeeLineTwo;
        private bool _AmountInWordsTwo;
        DataTable _DimensionTable;


       #endregion
        #region Constructor
       public CheckModelDb()
       { 
       }
       public CheckModelDb(DataRow objDr)
       {
           SetData(objDr);
       }
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
        public int FormatID
        {
            set 
            {
                _FormatID = value;
            }
            get
            {
                return _FormatID;
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
        public int Image
        {
            set 
            {
                _Image = value;
            }
            get
            {
                return _Image;
            }
           
        }
        public string DateSpacing
        {
            set 
            {
                _DateSpacing = value;
            }
            get
            {
                return _DateSpacing;
            }
             
        }
        public bool PayeeLineTwo
        {
            set 
            {
                _PayeeLineTwo = value;
            }
            get
            {
                return _PayeeLineTwo;
            }
            
        }
        public bool AmountInWordsTwo
        {
            set
            {
                _AmountInWordsTwo = value;
            }
            get
            {
                return _AmountInWordsTwo;
            }

        }
       public DataTable DimensionTable
       {
           
           set 
           { 
               _DimensionTable = value;
           }
       }
        public string AddStr
        {
            get
            {
                int intPayeeLineTwo = _PayeeLineTwo ? 1 : 0;
                int intAmountInWordsTwo = _AmountInWordsTwo ? 1 : 0;
                string Returned = "insert into GLCheckModel ( ModelName, ModelDateFormatID, ModelImage, ModelDateSpacing"+
                    ", ModelPayeeLineTwo, ModelAmountInWordsTwo)  "+
                    " values ('"+ _Name + "'," + _FormatID + "," + _Image + ",'"+ _DateSpacing + "',"  + intPayeeLineTwo +
                    "," + intAmountInWordsTwo  +") ";
                return Returned;

            }
        }
       public string EditStr
       {
           get
           {
               int intPayeeLineTwo = _PayeeLineTwo ? 1 : 0;
               int intAmountInWordsTwo = _AmountInWordsTwo ? 1 : 0;
               string Returned = "update GLCheckModel "+
                   " set  ModelName='"+ _Name +"'"+
                   ", ModelDateFormatID="+ _FormatID +
                   ", ModelImage="+ _Image +
                   ", ModelDateSpacing='"+ _DateSpacing +"'" +
                   ", ModelPayeeLineTwo="+ intPayeeLineTwo +
                   ", ModelAmountInWordsTwo=" + intAmountInWordsTwo +
                   " where ModelID ="+ _ID ;
               return Returned;

           }
       }
        public string SearchStr
        {
            get
            {
                string Returned = "SELECT  ModelID, ModelName, ModelDateFormatID, ModelImage, ModelDateSpacing" +
                    ", ModelPayeeLineTwo, ModelAmountInWordsTwo,FormatTable.*  " +
                    ",ImageTable.* "+
                       " FROM    dbo.GLCheckModel " +
                       " left outer join (" + DateFormatDb.SearchStr + ") as FormatTable " +
                       "  on dbo.GLCheckModel.ModelDateFormatID =  FormatTable.FormatID "+
                       " left outer join ("+ ImageDb.SearchStr +") as ImageTable "+
                       " on GLCheckModel.ModelImage = ImageTable.ImageID ";
                return Returned;
            }
        }
        #endregion
        #region Private Method
        void SetData(DataRow objDr)
        {
            _ID = int.Parse(objDr["ModelID"].ToString());
            _Name = objDr["ModelName"].ToString();
            if(objDr["ModelDateFormatID"].ToString()!= "")
            _FormatID = int.Parse(objDr["ModelDateFormatID"].ToString());
            _Image = int.Parse(objDr["ModelImage"].ToString());
            _DateSpacing = objDr["ModelDateSpacing"].ToString();
            _PayeeLineTwo = bool.Parse(objDr["ModelPayeeLineTwo"].ToString());
            _AmountInWordsTwo = bool.Parse(objDr["ModelAmountInWordsTwo"].ToString());
        }
        #endregion
        #region Public Method
       public void Add()
       {
          _ID = SysData.SharpVisionBaseDb.InsertIdentityTable(AddStr);
           JoinDimensonCol();

       }
       public void Edit()
       {
           SysData.SharpVisionBaseDb.ExecuteNonQuery(EditStr);
           JoinDimensonCol();

       }
       public void Delete()
       {
           string  strSql =  "update GLCheckModel set Dis = GetDate() where ModelID = "+_ID;
           SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
            
       }
        public DataTable Search()
        {
            string strSql = SearchStr + " where Dis is null ";
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
       void JoinDimensonCol()
       {
           if (_DimensionTable == null || _DimensionTable.Rows.Count == 0)
               return;
           List<string> arrStr = new List<string>();
           arrStr.Add("delete from   dbo.GLCheckModelDimension where ModelID ="+ _ID );
           DimensionDb objDb;
           foreach (DataRow objDr in _DimensionTable.Rows)
           {
               objDb = new DimensionDb(objDr);
               objDb.LayoutID = ID;
               arrStr.Add(objDb.AddStr);
           }
           SysData.SharpVisionBaseDb.ExecuteNonQuery(arrStr);


       }
        #endregion
    }
}
