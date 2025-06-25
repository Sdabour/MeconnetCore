var User = /** @class */ (function () {
    function User() {
        this.FullName = "";
        this.EmployeeCode = "";
        this.EmployeeName = "";
        this.Job = "";
        this.Sector = "";
        this.WorkGroupName = "";
        this.GroupName = "";
        this.FunctionLst = [];
        this.LstFunction = [];
        this.OldPass = "";
        //region xx
        //endregion
    }
    return User;
}());
function GetCurrentUser() {
    var Returned = new User();
    if (document.getElementById("lblCurrentSimpleUser") != null && document.getElementById("lblCurrentSimpleUser").value != "") {
        Returned = JSON.parse(document.getElementById("lblCurrentSimpleUser").value);
    }
    return Returned;
}
function GetUserRow(vrUser) {
    var Returned = "<tr>";
    Returned += "<td>" + vrUser.ID + "</td>";
    Returned += "<td>" + vrUser.Name + "</td>";
    Returned += "<td>" + vrUser.FullName + "</td>";
    Returned += "<td>" + vrUser.GroupName + "</td>";
    Returned += "<td>" + vrUser.EmployeeCode + "</td>";
    Returned += "<td>" + vrUser.EmployeeName + "</td>";
    Returned += "<td><input type=\"button\" value=\"+\" onclick=\"ReturnUser(" + vrUser.ID + ");SetUserFunctionInstant(" + vrUser.ID + ");\" /></td>";
    Returned += "</tr>";
    return Returned;
}
function FillUserTable(lstUser) {
    var Returned = "";
    if (document.getElementById("lblAllUser") != null) {
        document.getElementById("lblAllUser").value = JSON.stringify(lstUser);
    }
    if (document.getElementById("tblUserSearch") != null) {
        Returned += "<table class=\"table\">";
        for (var vrIndex = 0; vrIndex < lstUser.length; vrIndex++) {
            Returned += GetUserRow(lstUser[vrIndex]);
        }
        Returned += "</table>";
        document.getElementById("tblUserSearch").innerHTML = Returned;
    }
}
function CHeckUserAddEditValidation() {
    var Returned = true;
    if (document.getElementById("Name").value == null || document.getElementById("Name").value == "") {
        alert("فضلا حدد اسم المستخدم");
        return false;
    }
    if (document.getElementById("FullName").value == null || document.getElementById("FullName").value == "") {
        alert("فضلا حدد الاسم الكامل للمستخدم");
        return false;
    }
    if (document.getElementById("GroupID").value == null || document.getElementById("GroupID").value == "" || document.getElementById("GroupID").value == "0") {
        alert("فضلا حدد المجموعة");
        return false;
    }
    return Returned;
}
function GetUserData() {
    var Returned = new User();
    if (document.getElementById("ID") != null) {
        Returned.ID = Number(document.getElementById("ID").value);
    }
    if (document.getElementById("Name") != null) {
        Returned.Name = document.getElementById("Name").value;
    }
    if (document.getElementById("FullName") != null) {
        Returned.FullName = document.getElementById("FullName").value;
    }
    if (document.getElementById("Password") != null) {
        Returned.Password = document.getElementById("Password").value;
    }
    if (document.getElementById("GroupID") != null) {
        Returned.Group = Number(document.getElementById("GroupID").value);
    }
    var vrEmp = GetCurrentEmployee();
    Returned.EmployeeID = vrEmp.ID;
    if (document.getElementById("lblAllFunctionInstant") != null && document.getElementById("lblAllFunctionInstant").value != "") {
        Returned.LstFunction = JSON.parse(document.getElementById("lblAllFunctionInstant").value);
        //FillFunctionInstantTable();
    }
    return Returned;
}
function ReturnUser(vrUserID) {
    var lstUser = [];
    if (document.getElementById("lblAllUser") != null && document.getElementById("lblAllUser").value != "") {
        lstUser = JSON.parse(document.getElementById("lblAllUser").value);
    }
    var lstUserFilter = [];
    lstUserFilter = lstUser.filter(function (x) { return x.ID == vrUserID; });
    if (lstUserFilter.length == 0)
        return;
    var vrUser = lstUserFilter[0];
    SetUserData(vrUser);
}
function SetUserData(vrUser) {
    if (document.getElementById("ID") != null) {
        document.getElementById("ID").value = vrUser.ID.toString();
    }
    if (document.getElementById("Name") != null) {
        document.getElementById("Name").value = vrUser.Name;
    }
    if (document.getElementById("FullName") != null) {
        document.getElementById("FullName").value = vrUser.FullName;
    }
    if (document.getElementById("Password") != null) {
        document.getElementById("Password").value = "***********";
    }
    if (document.getElementById("GroupID") != null) {
        document.getElementById("GroupID").value = vrUser.Group.toString();
    }
    var vrEmployee = new Employee();
    vrEmployee.ID = vrUser.EmployeeID;
    vrEmployee.Name = vrUser.EmployeeName;
    vrEmployee.Code = vrUser.EmployeeCode;
    vrEmployee.BranchName = "";
    vrEmployee.Department = "";
    vrEmployee.User = vrUser.ID;
    vrEmployee.UserName = vrUser.Name;
    vrEmployee.FamousName = "";
    SetEmployeeData(vrEmployee);
}
function CloseUserLoginModal() {
    document.getElementById("myUserLogInModal").style.display = "none";
    return false;
}
function ShowLogInModal(vrAlert) {
    document.getElementById("lblUMSID").value = vrAlert.toString();
    document.getElementById("myUserLogInModal").style.display = "block";
}
function GetUserChangePassword() {
    var Returned = GetCurrentUser();
    if (Returned.ID == 0) {
        alert("لا يوجد مستخدم للتغير");
        return Returned;
    }
    var vrNewPass = "";
    var vrNewPassConfirm = "";
    var vrOldPass = "";
    if (document.getElementById("txtNewPassword") != null) {
        vrNewPass = document.getElementById("txtNewPassword").value;
    }
    if (document.getElementById("txtNewPasswordConfirm") != null) {
        vrNewPassConfirm = document.getElementById("txtNewPasswordConfirm").value;
    }
    if (document.getElementById("txtOldPassword") != null) {
        vrOldPass = document.getElementById("txtOldPassword").value;
    }
    if (vrOldPass == "") {
        alert("يجب تحديد كلمة المرور القديمة");
        Returned.ID = 0;
        return Returned;
    }
    if (vrNewPass == "" || vrNewPass != vrNewPassConfirm) {
        alert("يحب تحديد كلمة المرور الجديدة واعادة ادخالها بشكل صحيح");
        Returned.ID = 0;
        return Returned;
    }
    Returned.ChangePass = true;
    Returned.Password = vrNewPass;
    Returned.OldPass = vrOldPass;
    Returned.EmployeeCode = "";
    Returned.EmployeeName = "";
    Returned.FullName = "";
    Returned.GroupName = "";
    Returned.Sector = "";
    return Returned;
}
//# sourceMappingURL=User.js.map