var FunctionSimple = /** @class */ (function () {
    function FunctionSimple() {
    }
    FunctionSimple.prototype.GetRow = function (objBiz) {
        var Returned;
        Returned = "";
        Returned += "<tr>";
        var vrFunctionID;
        vrFunctionID = "lblFunction" + objBiz.ID;
        Returned += "<input type=\"hidden\" id=\"" + vrFunctionID + "\" value='" + JSON.stringify(objBiz) + "'\>";
        Returned += "<td>" + objBiz.ID + "</td>";
        Returned += "<td>" + objBiz.ParentName + "</td>";
        Returned += "<td>" + objBiz.Name + "</td>";
        Returned += "<td><input type=\"button\" value=\"+\" id=\"btnReturnFunction" + objBiz.ID + "\"  onclick=\"return AddFunctionToInstantCol('" + objBiz.ID + "')\" name=\"btnReturnFunction" + objBiz.ID + "\" /></td>";
        Returned += "</tr>";
        return Returned;
    };
    FunctionSimple.prototype.GetFunctionInstant = function (objFunction) {
        var Returned = new FunctionInstant();
        Returned.FunctionSimple = objFunction;
        Returned.IsPermanent = true;
        return Returned;
    };
    return FunctionSimple;
}());
function GetFunctionByID(vrID) {
    var vrFunctionStr = document.getElementById("lblFunction" + vrID).value;
    var Returned = new FunctionSimple();
    if (vrFunctionStr != "") {
        Returned = JSON.parse(vrFunctionStr);
    }
    return Returned;
}
function AddFunctionToInstantCol(intID) {
    var vrFunction = GetFunctionByID(intID);
    var vrAllFunctionInstStr = document.getElementById("lblAllFunctionInstant").value;
    var vrAllFunctionLst = [];
    if (vrAllFunctionInstStr != "") {
        vrAllFunctionLst = JSON.parse(vrAllFunctionInstStr);
    }
    if (vrAllFunctionLst.filter(function (x) { return x.FunctionSimple.ID == vrFunction.ID; }).length > 0)
        return;
    var vrFunctionTemp = new FunctionSimple();
    vrAllFunctionLst[vrAllFunctionLst.length] = vrFunctionTemp.GetFunctionInstant(vrFunction);
    document.getElementById("lblAllFunctionInstant").value = JSON.stringify(vrAllFunctionLst);
    FillFunctionInstantTable();
}
function FillFunctionTable() {
    var vrAllFunctionStr = document.getElementById("lblAllFunction").value;
    if (vrAllFunctionStr == "")
        return;
    var vrFunctionLst = JSON.parse(vrAllFunctionStr);
    var vrSys = Number(document.getElementById("cmbFunctionSystem").value);
    vrFunctionLst = vrFunctionLst.filter(function (x) { return x.SysID == vrSys; });
    var vrFilter = document.getElementById("txtFunctionFilter").value;
    vrFunctionLst = vrFunctionLst.filter(function (x) { return vrFilter == "" || x.Name.indexOf(vrFilter) > -1 || x.ParentName.indexOf(vrFilter) > -1; });
    var vrOnlyFamily = document.getElementById("chkFamilyNodes").checked;
    vrFunctionLst = vrFunctionLst.filter(function (x) { return vrOnlyFamily == false || x.ID == x.FamilyID; });
    var vrTable = "<table class=\"table\">";
    var vrFunction = new FunctionSimple();
    for (var vrIndex = 0; vrIndex < vrFunctionLst.length; vrIndex++) {
        vrTable += vrFunction.GetRow(vrFunctionLst[vrIndex]);
    }
    vrTable += "</table>";
    document.getElementById("dvFunction").innerHTML = vrTable;
}
function ShowFunctionModal() {
    FillFunctionTable();
    var vrModal = document.getElementById("myFunctionModal");
    vrModal.style.display = "block";
    return false;
}
function CloseFunctionModal() {
    var vrModal = document.getElementById("myFunctionModal");
    vrModal.style.display = "none";
    return false;
}
//# sourceMappingURL=Function.js.map