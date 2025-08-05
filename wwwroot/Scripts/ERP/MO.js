var MO = /** @class */ (function () {
    function MO() {
    }
    return MO;
}());
function GetMORow(objBiz) {
    var Returned = "<tr>";
    Returned += "<td>" + objBiz.Ref + "</td>";
    Returned += "<td>" + objBiz.ProductName + "</td>";
    Returned += "<td>" + objBiz.DateStr + "</td>";
    Returned += "<td>" + objBiz.StartTimeStr + "</td>";
    Returned += "<td>" + objBiz.StatusStr + "</td>";
    Returned += "<td>" + objBiz.StatusTimeStr + "</td>";
    Returned += "</tr>";
    return Returned;
}
function GetMOURL(objBiz) {
    //var vrSender = objBiz.Group == 0 ? objBiz.SenderApplicantName : objBiz.GroupName;
    var vrImage = objBiz.Status > 0 ? "success.png" : "placeholder.jpg";
    vrImage = objBiz.Status > 0 ? "success.png" : "warning.png";
    //"pnotify""placeholders"
    var Returned = "<li class=\"media\">" +
        "<div class=\"md-3 position-relative\" >" +
        "<img src=\"images/pnotify/" + vrImage + "\" width = \"36\" height = \"36\" class=\"rounded-circle\" style=\"width: 18px; height: 18px;\" alt = \"\" >" +
        "</div>";
    Returned += "<div class=\"media-body\">" +
        "<div class=\"media-title\" >";
    if (objBiz.Status == 0) {
        Returned += "<a href=\"#\" onclick=\"ShowMOLoginModal(" + objBiz.ID + ",1)\" >";
    }
    Returned += "<span class=\"font-weight-semibold\">" + objBiz.ProductName + "</span>" +
        "<span class=\"text-muted float-right font-size-sm\">" + objBiz.StartTimeStr + "</span>";
    if (objBiz.Status == 0) {
        Returned += "</a>";
    }
    Returned += "</div>" +
        "<div class=\"form-row\"><div class=\"col-2\"><span class=\"text-muted\">" + objBiz.Ref + "</span></div><div class=\"col-3\" style=\"align-content:center;color:red;\">" + objBiz.StatusStr + "</div>";
    if (objBiz.Status == 1) {
        Returned += "<div class=\"col-2\" style=\"align-content:center;\"><a href=\"#\" onclick=\"ShowMOLoginModal(" + objBiz.ID + ",2)\" >Pause</a></div>";
        Returned += "<div class=\"col-2\" style=\"align-content:center;\"><a href=\"#\" onclick=\"ShowMOLoginModal(" + objBiz.ID + ",4)\" >Finish</a></div>";
        Returned += "<div class=\"col-2\" style=\"align-content:center;\"><a href=\"#\" onclick=\"ShowMOLoginModal(" + objBiz.ID + ",3)\" >Cancel</a></div>";
    }
    if (objBiz.Status == 2) {
        Returned += "<div class=\"col-2\" style=\"align-content:center;\"><a href=\"#\" onclick=\"ShowMOLoginModal(" + objBiz.ID + ",1)\">Resume</a></div>";
        Returned += "<div class=\"col-2\" style=\"align-content:center;\"><a href=\"#\" onclick=\"ShowMOLoginModal(" + objBiz.ID + ",4)\">Finish</a></div>";
        Returned += "<div class=\"col-2\" style=\"align-content:center;\"><a href=\"#\" onclick=\"ShowMOLoginModal(" + objBiz.ID + ",3)\">Cancel</a></div>";
    }
    Returned += "</div>" +
        "</div>" +
        "</li>";
    return Returned;
}
function FillMOLst() {
    var lstMO = [];
    if (document.getElementById("lblAllMO") != null && document.getElementById("lblAllMO").value != "") {
        lstMO = JSON.parse(document.getElementById("lblAllMO").value);
    }
    var vrLstStr = "";
    for (var vrIndex = 0; vrIndex < lstMO.length; vrIndex++) {
        vrLstStr += GetMOURL(lstMO[vrIndex]);
    }
    var lstFilter = lstMO.filter(function (x) { return x.Status == 0; });
    var vrMsgCount = lstFilter.length == 0 ? "" : lstFilter.length.toString();
    document.getElementById("lblMOCount").innerText = vrMsgCount;
    if (document.getElementById("ulMO") != null) {
        document.getElementById("ulMO").innerHTML = vrLstStr;
    }
}
function AddMoListByRef(vrMO) {
    var lstMO = [];
    if (document.getElementById("lblAllMO") != null && document.getElementById("lblAllMO").value != "") {
        lstMO = JSON.parse(document.getElementById("lblAllMO").value);
    }
    var lstFilter = lstMO.filter(function (x) { return x.Ref == vrMO.Ref; });
    if (lstFilter.length == 0) {
        lstMO[lstMO.length] = vrMO;
        document.getElementById("lblAllMO").value = JSON.stringify(lstMO);
        FillMOLst();
    }
    else if (lstFilter[0].Status != vrMO.Status) {
        for (var vrIndex = 0; vrIndex < lstMO.length; vrIndex++) {
            if (lstMO[vrIndex].Ref == vrMO.Ref) {
                lstMO[vrIndex].Status = vrMO.Status;
                lstMO[vrIndex].StatusStr = vrMO.StatusStr;
                lstMO[vrIndex].StatusTime = vrMO.StatusTime;
            }
        }
        document.getElementById("lblAllMO").value = JSON.stringify(lstMO);
        FillMOLst();
    }
}
function EditMOStatusByID(vrMO) {
    var lstMO = [];
    if (document.getElementById("lblAllMO") != null && document.getElementById("lblAllMO").value != "") {
        lstMO = JSON.parse(document.getElementById("lblAllMO").value);
    }
    var lstFilter = lstMO.filter(function (x) { return x.ID == vrMO.ID; });
    if (lstFilter.length == 0) {
        return;
    }
    else if (lstFilter[0].Status != vrMO.Status) {
        for (var vrIndex = 0; vrIndex < lstMO.length; vrIndex++) {
            if (lstMO[vrIndex].ID == vrMO.ID) {
                lstMO[vrIndex].Status = vrMO.Status;
                lstMO[vrIndex].StatusStr = vrMO.StatusStr;
                lstMO[vrIndex].StatusTime = vrMO.StatusTime;
            }
        }
        document.getElementById("lblAllMO").value = JSON.stringify(lstMO);
        FillMOLst();
    }
}
function ShowMOLoginModal(vrMo, vrStatus) {
    document.getElementById("lblMOID").value = vrMo.toString();
    document.getElementById("lbStatus").value = vrStatus.toString();
    document.getElementById("myUserLogInModal").style.display = "block";
}
function FillMOLstTable() {
    var lstMO = [];
    if (document.getElementById("lblAllMO") != null && document.getElementById("lblAllMO").value != "") {
        lstMO = JSON.parse(document.getElementById("lblAllMO").value);
    }
    var vrLstStr = "<table class=\"table\">";
    for (var vrIndex = 0; vrIndex < lstMO.length; vrIndex++) {
        vrLstStr += GetMORow(lstMO[vrIndex]);
    }
    vrLstStr += "</table>";
    if (document.getElementById("tblMODisplay") != null) {
        document.getElementById("tblMODisplay").innerHTML = vrLstStr;
    }
}
function FillMOTable(arrMO) {
    var vrTable = "<table class=\"table\">";
    vrTable += "<tr>";
    vrTable += "<th>Ref</th>";
    vrTable += "<th>Product.Name</th>";
    vrTable += "<th>Date</th>";
    vrTable += "<th>Start.Time</th>";
    vrTable += "<th>Status</th>";
    vrTable += "<th>Status.Time</th>";
    vrTable += "</tr>";
    for (var vrIndex = 0; vrIndex < arrMO.length && vrIndex < 100; vrIndex++) {
        vrTable += GetMORow(arrMO[vrIndex]);
    }
    vrTable += "</table>";
    if (document.getElementById("tblMO") != null) {
        document.getElementById("tblMO").innerHTML = vrTable;
    }
}
function ShowMODisplayModal() {
    FillMOLstTable();
    document.getElementById("myMOListDisplayModal").style.display = "block";
}
//# sourceMappingURL=MO.js.map