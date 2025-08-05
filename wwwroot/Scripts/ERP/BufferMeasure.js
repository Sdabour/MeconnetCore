var BufferMeasure = /** @class */ (function () {
    function BufferMeasure() {
    }
    return BufferMeasure;
}());
function GetBufferMeasureRow(objBiz) {
    var Returned = "<tr>";
    Returned += "<td>" + objBiz.Buffer.PLC.Desc + "</td>";
    Returned += "<td>" + objBiz.Buffer.Desc + "</td>";
    Returned += "<td>" + objBiz.DateStr + "</td>";
    Returned += "<td>" + objBiz.TimeStr + "</td>";
    Returned += "<td>" + objBiz.Value.toFixed(2) + "</td>";
    Returned += "<td>" + objBiz.MinTimeStr + "</td>";
    Returned += "<td>" + objBiz.MinValue.toFixed(2) + "</td>";
    Returned += "<td>" + objBiz.MaxValue.toFixed(2) + "</td>";
    Returned += "<td>" + objBiz.FirstValue.toFixed(2) + "</td>";
    Returned += "</tr>";
    return Returned;
}
function FillBufferMeasureTable(arrMeasure) {
    var vrTable = "<table class=\"table\">";
    vrTable += "<tr>";
    vrTable += "<th>Machine</th>";
    vrTable += "<th>Buffer</th>";
    vrTable += "<th>Date</th>";
    vrTable += "<th>Time</th>";
    vrTable += "<th>Last Value</th>";
    vrTable += "<th>Min Time</th>";
    vrTable += "<th>Min Value</th>";
    vrTable += "<th>Max Value</th>";
    vrTable += "<th>First Value</th>";
    vrTable += "</tr>";
    for (var vrIndex = 0; vrIndex < arrMeasure.length && vrIndex < 100; vrIndex++) {
        vrTable += GetBufferMeasureRow(arrMeasure[vrIndex]);
    }
    vrTable += "</table>";
    if (document.getElementById("tblBufferMeasure") != null) {
        document.getElementById("tblBufferMeasure").innerHTML = vrTable;
    }
}
//# sourceMappingURL=BufferMeasure.js.map