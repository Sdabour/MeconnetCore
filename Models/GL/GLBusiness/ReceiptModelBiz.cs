using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.GL.GLDataBase;
using SharpVision.Base.BaseBusiness;
using SharpVision.Base.BaseDataBase;
using SharpVision.UMS.UMSBusiness;
using SharpVision.COMMON.COMMONBusiness;
using System.Data;
using System.Collections;
namespace SharpVision.GL.GLBusiness
{
    public class ReceiptModelBiz
    {
        #region Private Data
        ReceiptModelDb _ReceiptModelDb;
        string _RTF;
        string _RTFFilePath;
        AttachmentFileBiz _RTFFileBiz;
        #endregion
        #region Constructors
        public ReceiptModelBiz()
        {
            _ReceiptModelDb = new ReceiptModelDb();
        }
        public ReceiptModelBiz(DataRow objDr)
        {
            _ReceiptModelDb = new ReceiptModelDb(objDr);
        }
        #endregion
        #region Private Properties
        byte[] ModelRTFBytes
        {
            get
            {
                byte[] Returned = new byte[0];
                if (RTF != null && RTF != "")
                {
                    Returned = System.Text.Encoding.Unicode.GetBytes(RTF);

                }
                return Returned;
            }
        }
        #endregion
        #region Public Properties
        public int ID
        {
            set
            {
                _ReceiptModelDb.ID = value;
            }
            get
            {
                return _ReceiptModelDb.ID;
            }
        }
        public string Desc
        {
            set
            {
                _ReceiptModelDb.Desc = value;
            }
            get
            {
                return _ReceiptModelDb.Desc;
            }
        }
        public int AttachmentID
        {
            set
            {
                _ReceiptModelDb.AttachmentID = value;
            }
            get
            {
                return _ReceiptModelDb.AttachmentID;
            }
        }
        public bool IsStopped
        {
            set
            {
                _ReceiptModelDb.IsStopped = value;
            }
            get
            {
                return _ReceiptModelDb.IsStopped;
            }
        }
        public bool Direction
        {
            set
            {
                _ReceiptModelDb.Direction = value;
            }
            get
            {
                return _ReceiptModelDb.Direction;
            }
        }
        public int Branch
        {
            set
            {
                _ReceiptModelDb.Branch = value;
            }
            get
            {
                return _ReceiptModelDb.Branch;
            }
        }
        public string BranchName
        {
            set
            {
                _ReceiptModelDb.BranchName = value;
            }
            get
            {
                return _ReceiptModelDb.BranchName;
            }
        }
        public int ProjectID
        {
            set
            {
                _ReceiptModelDb.ProjectID = value;
            }
            get
            {
                return _ReceiptModelDb.ProjectID;
            }

        }
        public string ProjectName
        {
            set
            {
                _ReceiptModelDb.ProjectName = value;
            }
            get
            {
                return _ReceiptModelDb.ProjectName;
            }

        }
        Hashtable _ProjectHash;

        public Hashtable ProjectHash
        {
            get {
                if (_ProjectHash == null)
                {
                    _ProjectHash = new Hashtable();
                    ReceiptModelDb objDb = new ReceiptModelDb();
                    objDb.ID = ID;
                    DataTable dtTemp = objDb.GetModelProject();
                    string strTemp = "";
                    foreach (DataRow objDr in dtTemp.Rows)
                    {
                        strTemp = objDr["ProjectID"].ToString();
                        if(_ProjectHash[strTemp]== null)
                        _ProjectHash.Add(strTemp, strTemp);
                    }
                }
                return _ProjectHash; }
            set { _ProjectHash = value; }
        }

        
        #region RTF
        public string RTF
        {
            set
            {

                _RTF = value;
            }
            get
            {
                if (_RTF == null || _RTF == "")
                {
                    if (_ReceiptModelDb.AttachmentID != 0)
                    {
                        if (RTFFileBiz.Bytes != null)
                            _RTF = System.Text.Encoding.Unicode.GetString(RTFFileBiz.Bytes);

                    }
                    if (_RTF == null)
                        _RTF = "No File";
                }
                return _RTF;
            }
        }
        public AttachmentFileBiz RTFFileBiz
        {
            set
            {
                _RTFFileBiz = value;
            }
            get
            {
                if (_RTFFileBiz == null)
                {
                    _RTFFileBiz = new AttachmentFileBiz();
                    if (_ReceiptModelDb.AttachmentID != 0)
                    {
                        _RTFFileBiz = new AttachmentFileBiz(_ReceiptModelDb.AttachmentID);
                    }
                }
                return _RTFFileBiz;
            }
        }
        #endregion
        #endregion
        #region Private Methods

        #endregion
        #region Public Methods
        public void Add()
        {
            if (_RTF != null && _RTF != "")
            {

                RTFFileBiz.Bytes = ModelRTFBytes;
                RTFFileBiz.Name = "ReceiptModel.rtf";
                RTFFileBiz.Add();
            }
            _ReceiptModelDb.AttachmentID = RTFFileBiz.ID;
            _ReceiptModelDb.Add();
        }
        public void Edit()
        {
            if (RTFFileBiz.ID != 0)
            {
                RTFFileBiz.Bytes = ModelRTFBytes;
                RTFFileBiz.Name = "ReceiptModel.rtf";
                RTFFileBiz.Edit();

            }
            else if (_RTF != null && _RTF != "")
            {
                RTFFileBiz.Bytes = ModelRTFBytes;
                RTFFileBiz.Name = "ReceiptModel.rtf";
                RTFFileBiz.Add();
            }
            _ReceiptModelDb.AttachmentID = RTFFileBiz.ID;
            _ReceiptModelDb.Edit();
        }
        public void Delete()
        {
            _ReceiptModelDb.Delete();
        }

        #endregion
    }
}