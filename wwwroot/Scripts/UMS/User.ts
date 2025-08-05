class User
{
    public ID: number;
    public Name: string;
    public Password: string;
    public Token: string;
    public FullName: string="";
    public EmployeeID: number;
    public EmployeeCode: string="";
    public EmployeeName: string = "";
    public Job: string = "";
    public Sector: string = "";

    
    
    
    public WorkGroup: number;
    public WorkGroupName: string="";

    public Group: number;
    public GroupName: string = "";
    public IsSystemAdmin: boolean;

    public IsStopped: boolean;
    public Branch: number;
    public FunctionLst: FunctionSimple[] = [];
    public LstFunction: FunctionInstant[] = [];
   
    public ChangePass: boolean;
    public OldPass: string="";
   //region xx
 

    //endregion

}
function GetCurrentUser(): User {
    var Returned: User = new User();
    if (document.getElementById("lblCurrentSimpleUser") != null && (<HTMLInputElement>document.getElementById("lblCurrentSimpleUser")).value != "") {
        Returned = JSON.parse((<HTMLInputElement>document.getElementById("lblCurrentSimpleUser")).value);
    }

    return Returned;
}
function GetUserRow(vrUser: User): string {
    var Returned: string = "<tr>";

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
function FillUserTable(lstUser: User[]) {
    var Returned: string = "";
    if (document.getElementById("lblAllUser") != null) {
        (<HTMLInputElement>document.getElementById("lblAllUser")).value = JSON.stringify(lstUser);
    }
    if (document.getElementById("tblUserSearch") != null) {
        Returned += "<table class=\"table\">";
        for (var vrIndex = 0; vrIndex < lstUser.length; vrIndex++) {
            Returned += GetUserRow(lstUser[vrIndex]);

        }
        Returned += "</table>";
        (<HTMLInputElement>document.getElementById("tblUserSearch")).innerHTML = Returned;
    }
}
function CHeckUserAddEditValidation(): boolean {
    var Returned: boolean = true;
    if ((<HTMLInputElement>document.getElementById("Name")).value == null || (<HTMLInputElement>document.getElementById("Name")).value == "") {
        alert("فضلا حدد اسم المستخدم");
        return false;
    }
    if ((<HTMLInputElement>document.getElementById("FullName")).value == null || (<HTMLInputElement>document.getElementById("FullName")).value == "") {
        alert("فضلا حدد الاسم الكامل للمستخدم");
        return false;
    }
    if ((<HTMLInputElement>document.getElementById("GroupID")).value == null || (<HTMLInputElement>document.getElementById("GroupID")).value == "" || (<HTMLInputElement>document.getElementById("GroupID")).value == "0") {
        alert("فضلا حدد المجموعة");
        return false;
    }
    return Returned;
}
function GetUserData(): User {
    var Returned: User = new User();
    if (document.getElementById("ID") != null) {
        Returned.ID = Number((<HTMLInputElement>document.getElementById("ID")).value);
    }
    if (document.getElementById("Name") != null) {
        Returned.Name = (<HTMLInputElement>document.getElementById("Name")).value;
    }
    if (document.getElementById("FullName") != null) {
        Returned.FullName = (<HTMLInputElement>document.getElementById("FullName")).value;
    }
    if (document.getElementById("Password") != null) {
        Returned.Password = (<HTMLInputElement>document.getElementById("Password")).value;
    }
    if (document.getElementById("GroupID") != null) {
        Returned.Group = Number((<HTMLInputElement>document.getElementById("GroupID")).value);
    }
    var vrEmp: Employee = GetCurrentEmployee();
    Returned.EmployeeID = vrEmp.ID;
    if (document.getElementById("lblAllFunctionInstant") != null && (<HTMLInputElement>document.getElementById("lblAllFunctionInstant")).value != "") {
        Returned.LstFunction = JSON.parse((<HTMLInputElement>document.getElementById("lblAllFunctionInstant")).value);
        //FillFunctionInstantTable();
    }
    return Returned;

}
function ReturnUser(vrUserID: number) {
    var lstUser: User[] = [];
    if (document.getElementById("lblAllUser") != null && (<HTMLInputElement>document.getElementById("lblAllUser")).value != "") {
        lstUser = JSON.parse((<HTMLInputElement>document.getElementById("lblAllUser")).value);
    }

    var lstUserFilter: User[] = [];
    lstUserFilter = lstUser.filter(x => x.ID == vrUserID);
    if (lstUserFilter.length == 0)
        return;
    var vrUser: User = lstUserFilter[0];
    SetUserData(vrUser);


}
function SetUserData(vrUser: User) {
    if (document.getElementById("ID") != null) {
        (<HTMLInputElement>document.getElementById("ID")).value = vrUser.ID.toString();
    }
    if (document.getElementById("Name") != null) {
        (<HTMLInputElement>document.getElementById("Name")).value = vrUser.Name;
    }
    if (document.getElementById("FullName") != null) {
        (<HTMLInputElement>document.getElementById("FullName")).value = vrUser.FullName;
    }
    if (document.getElementById("Password") != null) {
        (<HTMLInputElement>document.getElementById("Password")).value = "***********";
    }
    if (document.getElementById("GroupID") != null) {
        (<HTMLInputElement>document.getElementById("GroupID")).value = vrUser.Group.toString();

    }
    if (document.getElementById("txtToken") != null) {
        (<HTMLInputElement>document.getElementById("txtToken")).innerText = vrUser.Token.toString();

    }
    var vrEmployee: Employee = new Employee();
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
function ShowLogInModal(vrAlert: number) {
    (<HTMLInputElement>document.getElementById("lblUMSID")).value = vrAlert.toString();
    document.getElementById("myUserLogInModal").style.display = "block";

}
function GetUserChangePassword(): User
{
    var Returned: User = GetCurrentUser();
    if (Returned.ID == 0) {
        alert("لا يوجد مستخدم للتغير");
        return Returned;
    }
    var vrNewPass: string = "";
    var vrNewPassConfirm: string = "";
    var vrOldPass: string = "";

    if (document.getElementById("txtNewPassword") != null) {

        vrNewPass = (<HTMLInputElement>document.getElementById("txtNewPassword")).value;
    }
    if (document.getElementById("txtNewPasswordConfirm") != null) {

        vrNewPassConfirm = (<HTMLInputElement>document.getElementById("txtNewPasswordConfirm")).value;
    }
    if (document.getElementById("txtOldPassword") != null) {

        vrOldPass = (<HTMLInputElement>document.getElementById("txtOldPassword")).value;
    }
    if (vrOldPass == "") {
        alert("يجب تحديد كلمة المرور القديمة");
        Returned.ID = 0;

        return Returned;
    }
    if (vrNewPass == "" || vrNewPass!= vrNewPassConfirm) {
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
