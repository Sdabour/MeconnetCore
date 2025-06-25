var Buffer = /** @class */ (function () {
    function Buffer() {
    }
    return Buffer;
}());
function GetBufferRow(objBiz) {
    var Returned = "<tr>";
    Returned += "<td>" + objBiz.PLC.Desc + "</td>";
    Returned += "<td>" + objBiz.Type.NameA + "</td>";
    Returned += "<td>" + objBiz.Code + "</td>";
    Returned += "<td>" + objBiz.Desc + "</td>";
    Returned += "</tr>";
    return Returned;
}
//# sourceMappingURL=Buffer.js.map