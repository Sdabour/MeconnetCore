var Buffer = /** @class */ (function () {
    function Buffer() {
    }
    return Buffer;
}());
function GetBufferRow(objBiz) {
    var Returned = "<tr>";
    Returned += "<input type=\"hidden\" id=\"lblBuffer" + objBiz.ID + "\" value='" + JSON.stringify(objBiz) + "'>";
    Returned += "<td>" + objBiz.PLC.Desc + "</td>";
    Returned += "<td>" + objBiz.Type.NameA + "</td>";
    Returned += "<td>" + objBiz.Code + "</td>";
    Returned += "<td>" + objBiz.Desc + "</td>";
    Returned += "<td><input type=\"button\" value=\"+\" onclick=\"ReturnBuffer(" + objBiz.ID + ");\" /></td>";
    Returned += "</tr>";
    return Returned;
}
function FillBufferTable(arrBuffer) {
    var vrTable = "<table class=\"table\">";
    for (var vrIndex = 0; vrIndex < arrBuffer.length; vrIndex++) {
        vrTable += GetBufferRow(arrBuffer[vrIndex]);
    }
    vrTable += "</table>";
    if (document.getElementById("tblBuffer") != null) {
        document.getElementById("tblBuffer").innerHTML = vrTable;
    }
}
function ReturnBuffer(vrID) {
    if (document.getElementById("lblBuffer" + vrID.toString()) == null) {
        return;
    }
    var vrBufferStr = document.getElementById("lblBuffer" + vrID.toString()).value;
    var vrBuffer = JSON.parse(vrBufferStr);
    if (document.getElementById("lblCurrentBuffer") != null) {
        document.getElementById("lblCurrentBuffer").value = vrBufferStr;
    }
    //var vrBuffer: Buffer = JSON.parse(vrBufferStr);
    if (document.getElementById("lblCurrentBufferPlc") != null) {
        document.getElementById("lblCurrentBufferPlc").innerText = vrBuffer.PLC.Desc;
    }
    if (document.getElementById("lblCurrentBufferCode") != null) {
        document.getElementById("lblCurrentBufferCode").innerText = vrBuffer.Code;
    }
    if (document.getElementById("lblCurrentBufferDesc") != null) {
        document.getElementById("lblCurrentBufferDesc").innerText = vrBuffer.Desc;
    }
}
//# sourceMappingURL=Buffer.js.map