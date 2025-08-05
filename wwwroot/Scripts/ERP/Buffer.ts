class Buffer {
    public ID: number;
    public Type: BufferType;
    
    public Code: string;
    public Desc: string;
    public Size: number;
    public Tag: string;
    public WorkCenter: number;
    public Machine: number;
    public Product: number;
    public Measurement: number;
    public PLC: PLC;
    public PLCDataType: number;
    public PLCVarType: number;
    public Threshold: number;
    public IsPerHour: boolean;

}
function GetBufferRow(objBiz: Buffer): string {
    var Returned: string = "<tr>";
    Returned += "<input type=\"hidden\" id=\"lblBuffer"+objBiz.ID+"\" value='"+JSON.stringify(objBiz)+"'>";
    Returned += "<td>" + objBiz.PLC.Desc + "</td>";
    Returned += "<td>" + objBiz.Type.NameA + "</td>";
    Returned += "<td>" + objBiz.Code + "</td>";
    Returned += "<td>" + objBiz.Desc + "</td>";
    Returned += "<td><input type=\"button\" value=\"+\" onclick=\"ReturnBuffer(" + objBiz.ID + ");\" /></td>";

    Returned += "</tr>";
    return Returned;
}
function FillBufferTable(arrBuffer:Buffer[]) {
    var vrTable: string = "<table class=\"table\">";
    for (var vrIndex = 0; vrIndex < arrBuffer.length; vrIndex++) {
        vrTable += GetBufferRow(arrBuffer[vrIndex]);
    }
    vrTable += "</table>";
    if (document.getElementById("tblBuffer") != null) {
        (<HTMLInputElement>document.getElementById("tblBuffer")).innerHTML = vrTable;
    }
}
function ReturnBuffer(vrID: number)
{
    if (document.getElementById("lblBuffer" + vrID.toString()) == null) {
        return;
    }
    var vrBufferStr :string= (<HTMLInputElement>document.getElementById("lblBuffer" + vrID.toString())).value;
    var vrBuffer: Buffer = JSON.parse(vrBufferStr);
    if (document.getElementById("lblCurrentBuffer") != null) {
        (<HTMLInputElement>document.getElementById("lblCurrentBuffer")).value = vrBufferStr;

    }
    //var vrBuffer: Buffer = JSON.parse(vrBufferStr);
    if (document.getElementById("lblCurrentBufferPlc") != null) {
        (<HTMLInputElement>document.getElementById("lblCurrentBufferPlc")).innerText = vrBuffer.PLC.Desc;

    }
    if (document.getElementById("lblCurrentBufferCode") != null) {
        (<HTMLInputElement>document.getElementById("lblCurrentBufferCode")).innerText = vrBuffer.Code;

    }
    if (document.getElementById("lblCurrentBufferDesc") != null) {
        (<HTMLInputElement>document.getElementById("lblCurrentBufferDesc")).innerText = vrBuffer.Desc;

    }

}