var AssignmentObject = /** @class */ (function () {
    function AssignmentObject() {
    }
    return AssignmentObject;
}());
function GetAssignmentObjectRow(vrAssignment) {
    var Returned = "<tr>";
    Returned += "<td><input type='button' value='+' onclick='ReturnAssignment(" + vrAssignment.ID + ");FillAissignmentObjectValueList();'></td>";
    //Returned += "<td>" + vrAssignment.ID.toString() + "</td>";
    Returned += "<td>" + vrAssignment.ID.toString() + "</td>";
    Returned += "<td>" + vrAssignment.Desc + "</td>";
    Returned += "</tr>";
    return Returned;
}
function FillAssignmentObjectTable() {
    var lstAssignment = [];
    var vrFilter = "";
    var lstAssigned = [];
    if (document.getElementById("lblAssignedAssignment") != null) {
        lstAssigned = JSON.parse(document.getElementById("lblAssignedAssignment").value);
    }
    var vrAllAssignmentAuthorized = false;
    if (document.getElementById("lblAllAssignmentAuthorized") != null) {
        try {
            vrAllAssignmentAuthorized = document.getElementById("lblAllAssignmentAuthorized").value == "1";
        }
        catch (_a) {
            vrAllAssignmentAuthorized = true;
        }
    }
    if (document.getElementById("lblAllAssignmentObject") != null) {
        lstAssignment = JSON.parse(document.getElementById("lblAllAssignmentObject").value);
    }
    if (document.getElementById("txtAssignmentObjectFilter") != null) {
        vrFilter = document.getElementById("txtAssignmentObjectFilter").value;
    }
    var lstFilter = [];
    lstFilter = lstAssignment.filter(function (x) { return (vrAllAssignmentAuthorized || lstAssigned.indexOf(x.ID) != -1) && x.Desc.indexOf(vrFilter) != -1; });
    var Returned = "<table class=\"table\">";
    for (var vrIndex = 0; vrIndex < lstFilter.length; vrIndex++) {
        Returned += GetAssignmentObjectRow(lstFilter[vrIndex]);
    }
    Returned += "</table>";
    if (document.getElementById("tblAssignmentObject") != null) {
        document.getElementById("tblAssignmentObject").innerHTML = Returned;
    }
}
function ReturnAssignment(vrAssignmentID) {
    var lstAssignment = [];
    if (document.getElementById("lblAllAssignmentObject") != null) {
        lstAssignment = JSON.parse(document.getElementById("lblAllAssignmentObject").value);
    }
    var lstFilter = [];
    lstFilter = lstAssignment.filter(function (x) { return x.ID == vrAssignmentID; });
    if (lstFilter.length > 0) {
        if (document.getElementById("lblSelectedAssignmentObject") != null) {
            document.getElementById("lblSelectedAssignmentObject").value = JSON.stringify(lstFilter[0]);
            document.getElementById("lblSelectedAssignmentObjectDesc").innerText = lstFilter[0].Desc;
        }
    }
}
//# sourceMappingURL=AssignmentObject.js.map