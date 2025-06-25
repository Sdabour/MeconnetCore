class AssignmentObject {
    public ID: number;
    public Desc: string;
    public Code: string;
    public TableName: string;
    public TableValueName: string;
    public TableDisplayNameA: string;
    public TableDisplayNameE: string;
    public ConditionStr: string;

}
function GetAssignmentObjectRow(vrAssignment: AssignmentObject): string {
    var Returned: string = "<tr>";
    Returned += "<td><input type='button' value='+' onclick='ReturnAssignment(" + vrAssignment.ID + ");FillAissignmentObjectValueList();'></td>";
    //Returned += "<td>" + vrAssignment.ID.toString() + "</td>";
    Returned += "<td>" + vrAssignment.ID.toString() + "</td>";
    Returned += "<td>" + vrAssignment.Desc + "</td>";
    Returned += "</tr>";
    return Returned;
}
function FillAssignmentObjectTable() {
    var lstAssignment: AssignmentObject[] = [];
    var vrFilter: string = "";
    var lstAssigned: number[] = [];
    if (document.getElementById("lblAssignedAssignment") != null) {
        lstAssigned = JSON.parse((<HTMLInputElement>document.getElementById("lblAssignedAssignment")).value);
    }
    var vrAllAssignmentAuthorized: boolean = false;
    if (document.getElementById("lblAllAssignmentAuthorized") != null) {
        try {
            vrAllAssignmentAuthorized = (<HTMLInputElement>document.getElementById("lblAllAssignmentAuthorized")).value == "1";
        } catch {
            vrAllAssignmentAuthorized = true;
        }
    }

    if (document.getElementById("lblAllAssignmentObject") != null) {
        lstAssignment = JSON.parse((<HTMLInputElement>document.getElementById("lblAllAssignmentObject")).value);
    }
    if (document.getElementById("txtAssignmentObjectFilter") != null) {
        vrFilter = (<HTMLInputElement>document.getElementById("txtAssignmentObjectFilter")).value;
    }
    var lstFilter: AssignmentObject[] = [];
    lstFilter = lstAssignment.filter(x => (vrAllAssignmentAuthorized || lstAssigned.indexOf(x.ID) != -1) && x.Desc.indexOf(vrFilter) != -1);
    var Returned = "<table class=\"table\">";
    for (var vrIndex = 0; vrIndex < lstFilter.length; vrIndex++) {
        Returned += GetAssignmentObjectRow(lstFilter[vrIndex]);
    }
    Returned += "</table>";

    if (document.getElementById("tblAssignmentObject") != null) {
        (<HTMLInputElement>document.getElementById("tblAssignmentObject")).innerHTML = Returned;
    }

}

function ReturnAssignment(vrAssignmentID: number) {
    var lstAssignment: AssignmentObject[] = [];
    if (document.getElementById("lblAllAssignmentObject") != null) {
        lstAssignment = JSON.parse((<HTMLInputElement>document.getElementById("lblAllAssignmentObject")).value);
    }
    var lstFilter: AssignmentObject[] = [];
    lstFilter = lstAssignment.filter(x => x.ID == vrAssignmentID);
    if (lstFilter.length > 0) {
        if (document.getElementById("lblSelectedAssignmentObject") != null) {
            (<HTMLInputElement>document.getElementById("lblSelectedAssignmentObject")).value = JSON.stringify(lstFilter[0]);
            (<HTMLInputElement>document.getElementById("lblSelectedAssignmentObjectDesc")).innerText = lstFilter[0].Desc;
        }
    }
}

