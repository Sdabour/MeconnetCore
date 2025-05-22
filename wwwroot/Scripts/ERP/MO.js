var MO = /** @class */ (function () {
    function MO() {
    }
    return MO;
}());
function GetMORow(objBiz) {
    var Returned = "<tr>";
    Returned += "<td>" + objBiz.Ref + "</td>";
    Returned += "<td>" + objBiz.ProductName + "</td>";
    Returned += "<td>" + objBiz.Date + "</td>";
    Returned += "<td>" + objBiz.StartTimeStr + "</td>";
    Returned += "<td>" + objBiz.StatusStr + "</td>";
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
        "<div class=\"media-title\" >" +
        "<a href=\"#\" onclick=\"ShowMOLoginModal(" + objBiz.ID + ",1)\" >" +
        "<span class=\"font-weight-semibold\" >" + objBiz.ProductName + " </span>" +
        "<span class=\"text-muted float-right font-size-sm\" > " + objBiz.StartTimeStr + " </span>" +
        "</a>" +
        "</div>" +
        "<span class=\"text-muted\">" + objBiz.Ref + "</span>" +
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
function ShowMODisplayModal() {
    FillMOLstTable();
    document.getElementById("myMOListDisplayModal").style.display = "block";
}
//# sourceMappingURL=MO.js.map