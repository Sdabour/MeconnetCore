using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using SharpVision.UMS.UMSDataBase;
using SharpVision.Base.BaseBusiness;
using System.Linq;
namespace SharpVision.UMS.UMSBusiness
{
   public  class AssignmentObjectBiz
    {

        #region Constructor
        public AssignmentObjectBiz()
        {
            _AssignmentObjectDb = new AssignmentObjectDb();
        }
        public AssignmentObjectBiz(DataRow objDr)
        {
            _AssignmentObjectDb = new AssignmentObjectDb(objDr);
        }
        public AssignmentObjectBiz(string strKey)
        {
            _AssignmentObjectDb = new AssignmentObjectDb();
            AssignmentObjectDb objDb = new AssignmentObjectDb() { Code = strKey };
            DataTable dtTemp = objDb.Search();
            if (dtTemp.Rows.Count > 0)
                _AssignmentObjectDb = new AssignmentObjectDb(dtTemp.Rows[0]);


        }

        #endregion
        #region Private Data
        AssignmentObjectDb _AssignmentObjectDb;
        #endregion
        #region Properties
        public int ID
        {
            set
            {
                _AssignmentObjectDb.ID = value;
            }
            get
            {
                return _AssignmentObjectDb.ID;
            }
        }
        public string Desc
        {
            set
            {
                _AssignmentObjectDb.Desc = value;
            }
            get
            {
                return _AssignmentObjectDb.Desc;
            }
        }
        public string Code
        {
            set
            {
                _AssignmentObjectDb.Code = value;
            }
            get
            {
                return _AssignmentObjectDb.Code;
            }
        }
        public string TableName
        {
            set
            {
                _AssignmentObjectDb.TableName = value;
            }
            get
            {
                return _AssignmentObjectDb.TableName;
            }
        }
        public string TableValueName
        {
            set
            {
                _AssignmentObjectDb.TableValueName = value;
            }
            get
            {
                return _AssignmentObjectDb.TableValueName;
            }
        }
        public string TableDisplayNameA
        {
            set
            {
                _AssignmentObjectDb.TableDisplayNameA = value;
            }
            get
            {
                return _AssignmentObjectDb.TableDisplayNameA;
            }
        }
        public string TableDisplayNameE
        {
            set
            {
                _AssignmentObjectDb.TableDisplayNameE = value;
            }
            get
            {
                return _AssignmentObjectDb.TableDisplayNameE;
            }
        }
        public string ConditionStr
        {
            set
            {
                _AssignmentObjectDb.ConditionStr = value;
            }
            get
            {
                return _AssignmentObjectDb.ConditionStr;
            }
        }
        SingleObjectCol _ObjectCol;
        public SingleObjectCol ObjectCol
        {
            get
            {
                if(_ObjectCol == null)
                {
                    _ObjectCol = new SingleObjectCol();
                    if (ID != 0)
                    {
                        _ObjectCol.Add(new SingleObjectBiz() { ID = 0, NameA = "الكل",NameE= "All" });
                        DataTable dtTemp = _AssignmentObjectDb.GetSimpleObject();
                        
                        foreach(DataRow objDr in dtTemp.Rows)
                        {
                            _ObjectCol.Add(new SingleObjectBiz(objDr));

                        }
                    }
                }
                return _ObjectCol;
            }
        }
        public UserObjectAssignmentCol GetObjectCol(UserBiz objUserBiz)
        {
            UserObjectAssignmentCol Returned = new UserObjectAssignmentCol();
                
                  //  Returned = new SingleObjectCol();
                    if (ID != 0)
                    {
                int intUserID = objUserBiz.ID == 0 ? -1 : objUserBiz.ID;
                UserObjectAssignmentDb objDb = new UserObjectAssignmentDb() { UserID = intUserID, ObjectCode = Code };

                DataTable dtTemp = objDb.Search(); //_AssignmentObjectDb.GetSimpleObject();
                UserObjectAssignmentBiz objBiz;
                        foreach (DataRow objDr in dtTemp.Rows)
                        {
                    objBiz = new UserObjectAssignmentBiz(objDr);
                    if (objBiz.ObjectID == 0)
                    {

                    }
                        if (objBiz.ObjectID!= 0)
                            Returned.Add(new UserObjectAssignmentBiz(objDr));

                        }
                    }
                
                return Returned;
            
        }

        public UserObjectAssignmentCol GetAllAssignedObjectCol(UserBiz objUserBiz)
        {
            UserObjectAssignmentCol Returned = GetObjectCol(objUserBiz);


            //  Returned = new SingleObjectCol();
            IEnumerable<UserObjectAssignmentBiz> objZero = from objBiz in Returned.Cast<UserObjectAssignmentBiz>()
                                                           where objBiz.ObjectValue == 0
                                                           select objBiz;

            if (objZero.Count() > 0)
            {
                UserObjectAssignmentBiz objTemp = objZero.First();
                Returned = new UserObjectAssignmentCol(true);
                foreach (SingleObjectBiz objBiz in ObjectCol)
                {
                    Returned.Add(new UserObjectAssignmentBiz() { UserID = objUserBiz.ID, EndDate = objTemp.EndDate, IsPermanent = objTemp.IsPermanent, ObjectCode = objTemp.ObjectCode, ObjectID = objTemp.ObjectID, ObjectValue = objBiz.ID, StartDate = objTemp.StartDate });

                }
            }
            return Returned;

        }
        #endregion
        #region Private Method

        #endregion
        #region Public Method 
        public void Add()
        {
            _AssignmentObjectDb.Add();
        }
        public void Edit()
        {
            _AssignmentObjectDb.Edit();
        }
        public void Delete()
        {
            _AssignmentObjectDb.Delete();
        }
        public static void AssignObjectColToUser(AssignmentObjectBiz objAssignmentBiz,UserBiz objUserBiz, UserObjectAssignmentCol objCol)
        {
            if (objUserBiz == null || objUserBiz.ID == 0 || objAssignmentBiz== null || objAssignmentBiz.ID==0)
                return;
            UserObjectAssignmentDb objDb = new UserObjectAssignmentDb();
            objDb.UserID = objUserBiz.ID;
            objDb.ObjectCode = objAssignmentBiz.Code;
            objDb.ObjectAssignTable = objCol.GetTable();
            objDb.JoinUserAssignmentObject();
        }
        #endregion
    }
}
