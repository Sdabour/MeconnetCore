var Meter = /** @class */ (function () {
    function Meter() {
        this.MeasureLst = [];
    }
    Meter.prototype.GetRow = function (objBiz) {
        var Returned;
        Returned = "";
        var vrMeterID;
        vrMeterID = "lblMeter" + objBiz.ID;
        var strBtn = "<td><input type=\"button\" value=\"::\" id=\"btnReturnMeter" + objBiz.ID + "\"  onclick=\"return ShowMeasurementModal('" + objBiz.ID + "')\" name=\"btnReturnMeter" + objBiz.ID + "\" /></td>";
        Returned += GetMeterInitialRow(objBiz, strBtn);
        return Returned;
    };
    return Meter;
}());
function GetMeterInitialRow(vrMeter, strBtns) {
    var Returned;
    var vrCount = vrMeter.MeasureLst.length;
    Returned = "";
    Returned += "<tr>";
    var vrMeterID;
    vrMeterID = "lblMeter" + vrMeter.ID;
    Returned += "<input type=\"hidden\" id=\"" + vrMeterID + "\" value='" + JSON.stringify(vrMeter) + "'\>";
    Returned += "<td>" + vrMeter.Desc + "</td>";
    Returned += "<td>" + vrMeter.ProductName + "</td>";
    // Returned += "<td>" + vrMeter.LastReadTime + "</td>";
    Returned += "<td>" + vrCount + "</td>";
    // Returned += "<td>" + vrMeasureCount + "</td>";
    Returned += strBtns;
    Returned += "</tr>";
    return Returned;
}
function ShowMeterModal(vrGroupID) {
    DisplayMeterRead(vrGroupID);
    document.getElementById("lblMeterGroup").value = vrGroupID.toString();
    document.getElementById("myMeterModal").style.display = "block";
}
function DisplayMeterRead(vrGroupID) {
    var vrGroupLbl = document.getElementById("lblGroup" + vrGroupID).value;
    var vrMeterGroup = JSON.parse(vrGroupLbl);
    var vrMeterCol = vrMeterGroup.MeterLst;
    var vrMeterStr = GetMeterLstTable(vrMeterCol);
    document.getElementById("tblMeter").innerHTML = vrMeterStr;
}
function DisplayLatestMeterRead() {
    var vrMeterID = 0;
    var vrMeter = document.getElementById("lblMeterGroup").value;
    if (vrMeter == null || vrMeter == "0")
        return;
    vrMeterID = Number(vrMeter);
    DisplayMeterRead(vrMeterID);
}
function GetMeterLstTable(lstMeter) {
    var Returned = "";
    var vrTempMeter = new Meter();
    for (var vrIndex = 0; vrIndex < lstMeter.length; vrIndex++) {
        Returned += vrTempMeter.GetRow(lstMeter[vrIndex]);
    }
    var vrMeterTable = "";
    /* vrMeterTable = */
    return Returned;
}
//# sourceMappingURL=Meter.js.map