var Measurement = /** @class */ (function () {
    function Measurement() {
    }
    Measurement.prototype.GetRow = function (objBiz) {
        var Returned;
        Returned = "";
        var vrMeasurementID;
        // vrMeasurementID = "lblMeasurement" + objBiz.;
        var strBtn = ""; //"<td><input type=\"button\" value=\"::\" id=\"btnReturnMeasurement" + objBiz.ID + "\"  onclick=\"return onReturnMeasurementClick('" + vrMeasurementID + "')\" name=\"btnReturnMeasurement" + objBiz.ID + "\" /></td>"
        Returned += GetMeasurementInitialRow(objBiz, strBtn);
        return Returned;
    };
    return Measurement;
}());
function GetMeasurementInitialRow(vrMeasurement, strBtns) {
    var Returned;
    var vrOnlineStatusBackColor = "red";
    Returned = "";
    Returned += "<tr>";
    var vrMeasurementID;
    //    vrMeasurementID = "lblMeasurement" + vrMeasurement.ID;
    /* Returned += "<input type=\"hidden\" id=\"" + vrMeasurementID + "\" value='" + JSON.stringify(vrMeasurement) + "'\>";*/
    Returned += "<td><button id=\"btnShowMeasureMeter" + vrMeasurement.MeterID.toString() + "-" + vrMeasurement.LastMeasureTypeID.toString() + "\" class=\"e-button\" onclick=\"return ShowMeterMeasureModal(" + vrMeasurement.MeterID + "," + vrMeasurement.LastMeasureTypeID + ");\">تفاصيل</button></td>";
    Returned += "<td>" + vrMeasurement.ProductName + "</td>";
    Returned += "<td>" + vrMeasurement.LastMeasureTypeNameA + "</td>";
    Returned += "<td>" + vrMeasurement.LastMeasureDateStr + "</td>";
    Returned += "<td>" + vrMeasurement.LastNonZeroMeasureTimeStr + "</td>";
    Returned += "<td>" + vrMeasurement.LastMeasureValue + "</td>";
    switch (vrMeasurement.OnlineStatus) {
        case (0):
            vrOnlineStatusBackColor = "red";
            break;
        case (1):
            vrOnlineStatusBackColor = "green";
            break;
        default:
            vrOnlineStatusBackColor = "yellow";
            break;
    }
    Returned += "<td style=\"background-color:" + vrOnlineStatusBackColor + ";\"></td>";
    /*  Returned += "<td><span style=\"width:50%;background-color:" + vrOnlineStatusBackColor + ";\"></span></td>";*/
    Returned += strBtns;
    Returned += "</tr>";
    return Returned;
}
function ShowMeasurementModal(vrMeterID) {
    DisplayMeasureRead(vrMeterID);
    //lblMeasureMeter
    document.getElementById("lblMeasureMeter").value = vrMeterID.toString();
    document.getElementById("myMeasurementModal").style.display = "block";
}
function DisplayMeasureRead(vrMeterID) {
    var vrMeterLbl = document.getElementById("lblMeter" + vrMeterID).value;
    var vrMeter = JSON.parse(vrMeterLbl);
    var vrMeasurementCol = vrMeter.MeasureLst;
    var vrMeasurementStr = GetMeasurementLstTable(vrMeasurementCol);
    document.getElementById("tblMeasurement").innerHTML = vrMeasurementStr;
}
function DisplayLatestMeasureRead() {
    var vrMeterID = 0;
    var vrMeter = document.getElementById("lblMeasureMeter").value;
    if (vrMeter == null || vrMeter == "0")
        return;
    vrMeterID = Number(vrMeter);
    DisplayMeasureRead(vrMeterID);
}
function GetMeasurementLstTable(lstMeasurement) {
    var Returned = "";
    var vrTempMeasurement = new Measurement();
    for (var vrIndex = 0; vrIndex < lstMeasurement.length; vrIndex++) {
        Returned += vrTempMeasurement.GetRow(lstMeasurement[vrIndex]);
    }
    var vrMeasurementTable = "";
    /* vrMeasurementTable = */
    return Returned;
}
//# sourceMappingURL=Measurement.js.map