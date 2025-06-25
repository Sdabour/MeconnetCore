var MeterGroup = /** @class */ (function () {
    function MeterGroup() {
        this.MeterLst = [];
    }
    return MeterGroup;
}());
function GetMeterGroupRow(objBiz) {
    var Returned;
    Returned = "";
    var vrGroupID;
    vrGroupID = "lblGroup" + objBiz.ID;
    var strBtn = "<td><input type=\"button\" value=\"::\" id=\"btnReturnGroup" + objBiz.ID + "\"  onclick=\"return ShowMeterModal('" + objBiz.ID + "')\" name=\"btnReturnGroup" + objBiz.ID + "\" /></td>";
    Returned += GetGroupInitialRow(objBiz, strBtn);
    return Returned;
}
function GetGroupInitialRow(vrGroup, strBtns) {
    var Returned;
    var vrCount = vrGroup.MeterLst.length;
    var vrMeasureCount = vrGroup.MeterLst.map(function (x) { return x.MeasureLst.length; }).reduce(function (a, b) { return a + b; });
    Returned = "";
    Returned += "<tr>";
    var vrGroupID;
    vrGroupID = "lblGroup" + vrGroup.ID;
    Returned += "<input type=\"hidden\" id=\"" + vrGroupID + "\" value='" + JSON.stringify(vrGroup) + "'\>";
    Returned += "<td>" + vrGroup.NameA + "</td>";
    Returned += "<td>" + vrGroup.LastReadTime + "</td>";
    Returned += "<td>" + vrCount + "</td>";
    Returned += "<td>" + vrMeasureCount + "</td>";
    Returned += strBtns;
    Returned += "</tr>";
    return Returned;
}
function GetGroupPivot11(vrGroup) {
    var vrHeader = GetGroupHeaderArr(vrGroup);
    var Returned = "";
    Returned += "<table class=\"table\" style=\"max-height:90%;scroll-behavior: auto;\">";
    Returned += "<tr><th></th><th></th>";
    for (var vrIndex = 0; vrIndex < vrHeader.length; vrIndex++) {
        Returned += "<th>" + vrHeader[vrIndex] + "</th>";
    }
    Returned += "</tr>";
    var vrMeasure = new Measurement();
    var vrDisplay = "";
    var vrMeasureLst;
    for (var vrI = 0; vrI < vrGroup.MeterLst.length; vrI++) {
        Returned += "<tr>";
        Returned += "<td>" + vrGroup.MeterLst[vrI].Desc + "</td>";
        Returned += "<td>" + vrGroup.MeterLst[vrI].ProductName + "</td>";
        for (var vrJ = 0; vrJ < vrHeader.length; vrJ++) {
            vrMeasureLst = vrGroup.MeterLst[vrI].MeasureLst.filter(function (x) { return x.LastMeasureTypeNameA == vrHeader[vrJ]; });
            vrMeasure = vrMeasureLst.length > 0 ? vrMeasureLst[vrMeasureLst.length - 1] : new Measurement();
            vrDisplay = "";
            try {
                vrDisplay = vrMeasure.LastMeasureValue.toFixed(2);
            }
            catch (_a) { }
            Returned += "<td>" + vrDisplay + "</td>";
        }
        Returned += "</tr>";
    }
    Returned += "</table>";
    return Returned;
}
function GetGroupPivot(vrGroup) {
    var vrHeader = GetGroupHeaderArr(vrGroup);
    var Returned = "";
    Returned += "<table class=\"table\" style=\"max-height:90%;scroll-behavior: auto;\">";
    Returned += "<tr><th></th><th></th>";
    for (var vrIndex = 0; vrIndex < vrHeader.length; vrIndex++) {
        Returned += "<th>" + vrHeader[vrIndex] + "</th>";
    }
    Returned += "</tr>";
    var vrMeasure = new Measurement();
    var vrDisplay = "";
    var vrMeasureLst;
    for (var vrI = 0; vrI < vrGroup.MeterLst.length; vrI++) {
        Returned += "<tr>";
        Returned += "<td>" + vrGroup.MeterLst[vrI].Desc + "</td>";
        Returned += "<td>" + vrGroup.MeterLst[vrI].ProductName + "</td>";
        for (var vrJ = 0; vrJ < vrHeader.length; vrJ++) {
            //vrMeasureLst = vrGroup.MeterLst[vrI].MeasureLst.filter(x => x.LastMeasureTypeNameA == vrHeader[vrJ]);
            //vrMeasure = vrMeasureLst.length > 0 ? vrMeasureLst[vrMeasureLst.length-1] : new Measurement();
            vrMeasure = new Measurement();
            if (vrGroup.MeterLst[vrI].MeasureLst.length > vrJ) {
                vrMeasure = vrGroup.MeterLst[vrI].MeasureLst[vrJ];
            }
            vrDisplay = "";
            try {
                if (vrMeasure.LastMeasureType == undefined) {
                    vrDisplay = "";
                }
                else {
                    vrDisplay = vrMeasure.LastMeasureTypeNameA + "<br/>";
                    vrDisplay += "<label class=\"text-black\" style=\" background-color:aliceblue;text-align:center;width:100%;\" id=\"lblBufferValue" + vrMeasure.LastMeasureTypeID.toString() + "\">" + vrMeasure.LastMeasureValue.toFixed(2) + "</label>";
                    if (document.getElementById("lblBufferValue" + vrMeasure.LastMeasureTypeID.toString()) != null) {
                        document.getElementById("lblBufferValue" + vrMeasure.LastMeasureTypeID.toString()).innerText = vrMeasure.LastMeasureValue.toFixed(2);
                    }
                }
            }
            catch (_a) { }
            Returned += "<td>" + vrDisplay + "</td>";
        }
        Returned += "</tr>";
    }
    Returned += "</table>";
    return Returned;
}
function GetGroupCard(vrGroup) {
    var vrGroupPivot = GetGroupPivot(vrGroup);
    var Returned = "";
    Returned += " <div class=\"card\" id=\"dvGroupCard" + vrGroup.ID.toString() + "\">";
    Returned += "<div class=\"card-header bg-teal-400 text-white header-elements-inline\">";
    Returned += "<h6 class=\"card-title\">" + vrGroup.Desc + "</h6>";
    Returned += "<div class=\"header-elements\">" +
        "<div class=\"list-icons\">" +
        "<a class=\"list-icons-item\" data-action=\"collapse\" ></a>";
    Returned += "</div>" +
        "</div></div>";
    Returned += "<div class=\"card-body\" style=\"max-height:max;scroll-behavior: auto;\">";
    Returned += "<div class=\"table-responsive\">";
    Returned += vrGroupPivot;
    Returned += "</div>";
    Returned += "</div>";
    Returned += "</div>";
    return Returned;
}
function GetGroupHeaderArr1(vrGroup) {
    var Returned = [];
    var vrMeasure = "";
    /* Returned = vrGroup.MeterLst.map(x => x.MeasureLst.map(y => y.MeterTypeNameA));*/
    for (var vrIndex = 0; vrIndex < vrGroup.MeterLst.length; vrIndex++) {
        for (var vrM = 0; vrM < vrGroup.MeterLst[vrIndex].MeasureLst.length; vrM++) {
            vrMeasure = vrGroup.MeterLst[vrIndex].MeasureLst[vrM].LastMeasureTypeNameA;
            if (Returned.filter(function (x) { return x == vrMeasure; }).length == 0) {
                Returned[Returned.length] = vrMeasure;
            }
        }
    }
    return Returned;
}
function GetGroupHeaderArr(vrGroup) {
    var Returned = [];
    var vrMeasure = "";
    /* Returned = vrGroup.MeterLst.map(x => x.MeasureLst.map(y => y.MeterTypeNameA));*/
    var vrHeaderCount = 0;
    for (var vrIndex = 0; vrIndex < vrGroup.MeterLst.length; vrIndex++) {
        if (vrGroup.MeterLst[vrIndex].MeasureLst.length > vrHeaderCount) {
            vrHeaderCount = vrGroup.MeterLst[vrIndex].MeasureLst.length;
        }
    }
    for (var vrIndex = 0; vrIndex < vrHeaderCount; vrIndex++) {
        Returned[vrIndex] = "Measure" + (vrIndex + 1).toString();
    }
    return Returned;
}
//# sourceMappingURL=MeterGroup.js.map