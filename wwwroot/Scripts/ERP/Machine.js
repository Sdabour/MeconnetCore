var Machine = /** @class */ (function () {
    function Machine() {
    }
    return Machine;
}());
function GetMachineRow(vrMachine) {
    var Returned = "<tr>";
    Returned += "<input type =\"hidden\" id=\"lblMachine" + vrMachine.ID.toString() + "\" value='" + JSON.stringify(vrMachine) + "'/><td>" + vrMachine.Center.NameA + "</td>";
    Returned += "<td>" + vrMachine.Process.NameA + "</td>";
    Returned += "<td>" + vrMachine.Desc + "</td>";
    Returned += "<td>" + vrMachine.Desc + "</td>";
    Returned += "<td><input type=\"button\" value=\"+\" onclick=\"ReturnMachine(" + vrMachine.ID + ");\" /></td>";
    Returned += "</tr>";
    return Returned;
}
function ReturnMachine(vrID) {
    if (document.getElementById("lblMachine" + vrID.toString()) == null) {
        return;
    }
    var vrMachineStr = document.getElementById("lblMachine" + vrID.toString()).value;
    var vrMachine = JSON.parse(vrMachineStr);
    if (document.getElementById("lblCurrentMachine") != null) {
        document.getElementById("lblCurrentMachine").value = vrMachineStr;
    }
    if (document.getElementById("lblMachineNameA") != null) {
        document.getElementById("lblMachineNameA").innerText = vrMachine.NameA;
    }
}
//# sourceMappingURL=Machine.js.map