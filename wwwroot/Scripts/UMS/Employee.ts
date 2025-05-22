class Employee {
    public ID: number;
    public Code: string;
    public Name: string;
    public FamousName: string;
    public BranchName: string;
    public Department: string;
    public User: number;
    public UserName: string;
   

}
function GetEmployeeRow(objBiz: Employee): string {
    let Returned: string;
    Returned = "";
    Returned += "<tr>";
    let vrEmployeeID: string;
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
    var vrLblName: string = "lblEmployee" + vrEmpID;
    var vrLbl: string = (<HTMLInputElement>document.getElementById(vrLblName)).value;

    var vrEmployee : Employee = JSON.parse(vrLbl);

    //alert(document.getElementById("lblEmployee").innerText);
   (<HTMLInputElement> document.getElementById("lblEmployee")).innerText = vrEmployee.Name;
    (<HTMLInputElement>document.getElementById("lblEmployeeValue")).value= vrLbl;

    var vrModal = document.getElementById("myEmployeeModal");
    vrModal.style.display = "none";
    return false;
}