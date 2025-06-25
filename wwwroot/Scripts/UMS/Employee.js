var Employee = /** @class */ (function () {
    function Employee() {
    }
    return Employee;
}());
function GetEmployeeRow(objBiz) {
    var Returned;
    Returned = "";
    Returned += "<tr>";
    var vrEmployeeID;
    vrEmployeeID = "lblEmployee" + objBiz.ID;
    Returned += "<input type=\"hidden\" id=\"" + vrEmployeeID + "\" value='" + JSON.stringify(objBiz) + "'\>";
    Returned += "<td>" + objBiz.ID + "</td>";
    Returned += "<td>" + objBiz.Code + "</td>";
    Returned += "<td>" + objBiz.Name + "</td>";
    Returned += "<td>" + objBiz.BranchName + "</td>";
    Returned += "<td><input type=\"button\" value=\"تثبيت\" id=\"btnReturnEmployee" + objBiz.ID + "\"  onclick=\"return onReturnEmployeeClick('" + objBiz.ID + "')\" name=\"btnReturnEmployee" + objBiz.ID + "\" /></td>";
    Returned += "</tr>";
    return Returned;
}
function onReturnEmployeeClick(vrEmpID) {
    var vrLblName = "lblEmployee" + vrEmpID;
    var vrLbl = document.getElementById(vrLblName).value;
    var vrEmployee = JSON.parse(vrLbl);
    //alert(document.getElementById("lblEmployee").innerText);
    SetEmployeeData(vrEmployee);
    return false;
}
function SetEmployeeData(vrEmployee) {
    document.getElementById("lblEmployee").innerText = vrEmployee.Name;
    document.getElementById("lblEmployeeValue").value = JSON.stringify(vrEmployee);
    if (document.getElementById("myEmployeeModal") != null) {
        var vrModal = document.getElementById("myEmployeeModal");
        vrModal.style.display = "none";
    }
}
function GetCurrentEmployee() {
    var Returned = new Employee();
    if (document.getElementById("lblEmployeeValue") != null && document.getElementById("lblEmployeeValue").value != "") {
        Returned = JSON.parse(document.getElementById("lblEmployeeValue").value);
    }
    return Returned;
}
//# sourceMappingURL=Employee.js.map