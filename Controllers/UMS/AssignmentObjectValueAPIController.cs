using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SharpVision.Base.BaseBusiness;
using SharpVision.UMS.UMSBusiness;

namespace AlgorithmatENMMVCCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssignmentObjectValueAPIController : ControllerBase
    {
        public List<SerializableBiz> GetAssignmentObjectValueLst(string strCode)
        {
            AssignmentObjectBiz objBiz = new AssignmentObjectBiz(strCode);

            List<SerializableBiz> Returned = objBiz.ObjectCol.Cast<SingleObjectBiz>().Select(x => new SerializableBiz() { ID = x.ID, Name = x.NameA }).ToList();
            return Returned;
        }
        public List<SerializableBiz> GetUserAssignmentObjectValueLst(int intUser, string strCode)
        {
            AssignmentObjectBiz objBiz = new AssignmentObjectBiz(strCode);
            UserBiz objUser = new UserBiz() { ID = intUser };
            List<SerializableBiz> Returned = objBiz.GetAllAssignedObjectCol(objUser).Cast<UserObjectAssignmentBiz>().Select(x => new SerializableBiz() { ID = x.SingleObjectBiz.ID, Name = x.SingleObjectBiz.NameA }).ToList();
            return Returned;
        }
        [HttpPost]
        public void AssignObjectUserValue(AssignmentObjectListSimple objSimple)
        {
            AssignmentObjectBiz _ObjectBiz = new AssignmentObjectBiz(objSimple.strCode);
            UserBiz _UserBiz = new UserBiz() { ID = objSimple.intUser };
            UserObjectAssignmentCol _SelectedCol = new UserObjectAssignmentCol(true);
            foreach (SerializableBiz objKey in objSimple.lstAssignment)
                _SelectedCol.Add(new UserObjectAssignmentBiz() { ObjectValue = objKey.ID, IsPermanent = true, ObjectID = _ObjectBiz.ID, ObjectCode = _ObjectBiz.Code, UserID = _UserBiz.ID, StartDate = DateTime.Now, EndDate = DateTime.Now });
            AssignmentObjectBiz.AssignObjectColToUser(_ObjectBiz, _UserBiz, _SelectedCol);
        }
    }
}
