class Machine {
    public ID: number;
    public Process: Process;
    public Center: WorkCenter;
    public Flow: number;
    public Code: string;
    public Desc: string;
    public NameA: string;
    public NameE: string;
   

}
function GetMachineRow(vrMachine: Machine): string{

    var Returned: string = "<tr>";
    Returned += "<input type =\"hidden\" id=\"lblMachine" + vrMachine.ID.toString() + "\" value='" + JSON.stringify(vrMachine) +"'/><td>" + vrMachine.Center.NameA + "</td>";
    Returned += "<td>" + vrMachine.Process.NameA + "</td>";
    Returned += "<td>" + vrMachine.Desc + "</td>";
    Returned += "<td>" + vrMachine.Desc + "</td>";
    Returned += "<td><input type=\"button\" value=\"+\" onclick=\"ReturnMachine(" + vrMachine.ID + ");\" /></td>";

    Returned += "</tr>";
    return Returned;
}
function ReturnMachine(vrID: number)
{
    if (document.getElementById("lblMachine" + vrID.toString()) == null) {
        return;
    }
    var vrMachineStr: string = (<HTMLInputElement>document.getElementById("lblMachine" + vrID.toString())).value;
    var vrMachine: Machine = JSON.parse(vrMachineStr);
    if (document.getElementById("lblCurrentMachine") != null) {
        (<HTMLInputElement>document.getElementById("lblCurrentMachine")).value = vrMachineStr;
    }
    if (document.getElementById("lblMachineNameA") != null) {
        (<HTMLInputElement>document.getElementById("lblMachineNameA")).innerText = vrMachine.NameA;
    }

}

