var SerializableSimple = /** @class */ (function () {
    function SerializableSimple() {
    }
    return SerializableSimple;
}());
function GetSerializableCmbStr(arrSerializable, strCmbID) {
    var Returned = "";
    Returned = "<select class=\"form-control form-control-uniform multiselect-filter\" name=\"" + strCmbID + "\" id=\"" + strCmbID + "\">";
    var objBiz = new SerializableSimple();
    for (var vrIndex = 0; vrIndex < arrSerializable.length; vrIndex++) {
        objBiz = arrSerializable[vrIndex];
        Returned += "<option value=" + objBiz.ID + ">" + objBiz.Name + "</option>";
    }
    Returned += "</select>";
    return Returned;
}
function GetSearchModal(lblSerializableArr, lblHidden, lblSelected) {
    var arrSerializable = JSON.parse(document.getElementById(lblSerializableArr).value);
    var Returned = "";
    Returned += "<div class=\"form-row\"><div class=\"col\"><input type=\"text\" id=\"txtSerialFilter\" value=\"\" onchange=\"SetFilterTable('" + lblSerializableArr + "','" + lblHidden + "','" + lblSelected + "')\"/></div></div>";
    Returned += "<div class=\"table-responsive\" style=\"max-height:200px;scroll-behavior: auto;\">";
    Returned += "<table class=\"table\" id=\"tblSerial\">";
    Returned += GetFilterTable(lblSerializableArr, lblHidden, lblSelected);
    Returned += "</table></div>";
    if (document.getElementById("dvSerialModalContent") != null) {
        document.getElementById("dvSerialModalContent").innerHTML = Returned;
    }
    ShowSerialModal();
    return Returned;
}
function ClickSerializableReturn(vrID, lblSelected, lblHidden) {
    var vrObj = JSON.parse(document.getElementById("lblSerializable" + vrID.toString()).value);
    document.getElementById(lblHidden).value = JSON.stringify(vrObj);
    document.getElementById(lblSelected).innerText = vrObj.Name;
    CloseSerialModal();
}
function GetFilterTable(lblSerializableArr, lblHidden, lblSelected) {
    var arrSerializable = JSON.parse(document.getElementById(lblSerializableArr).value);
    var objBiz = new SerializableSimple();
    var vrFilter = "";
    if (document.getElementById("txtSerialFilter") != null) {
        vrFilter = document.getElementById("txtSerialFilter").value;
    }
    var arrFilter = [];
    arrFilter = arrSerializable.filter(function (x) { return vrFilter == "" || x.Name.indexOf(vrFilter) > -1; });
    var vrTable = "";
    if (arrFilter.length == 0) {
        arrFilter = arrSerializable;
    }
    for (var vrIndex = 0; vrIndex < arrFilter.length; vrIndex++) {
        objBiz = arrFilter[vrIndex];
        vrTable += "<tr>";
        vrTable += "<input type=\"hidden\" id=\"lblSerializable" + objBiz.ID + "\" value='" + JSON.stringify(objBiz) + "'/>";
        vrTable += "<td>" + objBiz.Name + "</td>";
        vrTable += "<td><button onclick=\"ClickSerializableReturn(" + objBiz.ID + ",'" + lblSelected + "','" + lblHidden + "')\">�����</button></td>";
        vrTable += "</tr>";
    }
    return vrTable;
}
function SetFilterTable(lblSerializableArr, lblHidden, lblSelected) {
    var vrTable = GetFilterTable(lblSerializableArr, lblHidden, lblSelected);
    if (document.getElementById("tblSerial") != null) {
        document.getElementById("tblSerial").value = vrTable;
    }
    if (document.getElementById("dvSerialModalContent") != null) {
        document.getElementById("dvSerialModalContent").value = vrTable;
    }
}
function ShowSerialModal() {
    var vrModal = document.getElementById("mySerialModal");
    vrModal.style.display = "block";
    return false;
}
function CloseSerialModal() {
    var vrModal = document.getElementById("mySerialModal");
    vrModal.style.display = "none";
    return false;
}
function GetSerializableSimpleTable(vrObjectName) {
    var vrLblAll = "lblAll" + vrObjectName;
    var vrLblSelected = "lblSelected" + vrObjectName;
    var lstAll = [];
    var lstSelected = [];
    if (document.getElementById(vrLblAll) != null && document.getElementById(vrLblAll).value != "") {
        lstAll = JSON.parse(document.getElementById(vrLblAll).value);
    }
    if (document.getElementById(vrLblSelected) != null && document.getElementById(vrLblSelected).value != "") {
        lstSelected = JSON.parse(document.getElementById(vrLblSelected).value);
    }
    var vrChecked = "";
    var lstFilter = lstAll;
    var vrSelectedOnly = false;
    if (document.getElementById("chkOnlySelected" + vrObjectName) != null) {
        vrSelectedOnly = document.getElementById("chkOnlySelected" + vrObjectName).checked;
    }
    if (vrSelectedOnly) {
        lstFilter = lstFilter.filter(function (x) { return lstSelected.map(function (y) { return y.ID; }).filter(function (z) { return z == x.ID; }).length > 0; });
    }
    if (document.getElementById("txtFilter" + vrObjectName) != null && document.getElementById("txtFilter" + vrObjectName).value != "") {
        var vrTxtFilter = document.getElementById("txtFilter" + vrObjectName).value;
        lstFilter = lstFilter.filter(function (x) { return x.Name.indexOf(vrTxtFilter) != -1; });
    }
    var Returned = "<table class=\"table\" style=\"max-height:300px;\">";
    for (var vrIndex = 0; vrIndex < lstFilter.length; vrIndex++) {
        vrChecked = lstSelected.filter(function (x) { return x.ID == lstFilter[vrIndex].ID; }).length > 0 ? "checked" : "";
        Returned += "<tr>";
        Returned += "<td><input type=\"checkbox\" id=\"chk" + vrObjectName + lstFilter[vrIndex].ID.toString() + "\" " + vrChecked + " onchange=\"OnChangeSerializableObject('" + vrObjectName + "'," + lstFilter[vrIndex].ID.toString() + ")\"/>" + "</td>";
        Returned += "<td>" + lstFilter[vrIndex].ID.toString() + "</td>";
        Returned += "<td>" + lstFilter[vrIndex].Name + "</td>";
        Returned += "</tr>";
    }
    Returned += "</table>";
    if (document.getElementById("tbl" + vrObjectName) != null) {
        {
            document.getElementById("tbl" + vrObjectName).innerHTML = Returned;
        }
    }
}
function OnChangeSerializableObject(vrObjectName, vrID) {
    var vrCheckID = "chk" + vrObjectName + vrID.toString();
    if (document.getElementById(vrCheckID) != null) {
        var vrLblAll = "lblAll" + vrObjectName;
        var vrLblSelected = "lblSelected" + vrObjectName;
        var lstAll = [];
        var lstSelected = [];
        var lstNewSelected = [];
        if (document.getElementById(vrLblAll) != null && document.getElementById(vrLblAll).value != "") {
            lstAll = JSON.parse(document.getElementById(vrLblAll).value);
        }
        if (lstAll.filter(function (x) { return x.ID == vrID; }).length == 0) {
            return;
        }
        var vrSimple = new SerializableSimple();
        vrSimple = lstAll.filter(function (x) { return x.ID == vrID; })[0];
        if (document.getElementById(vrLblSelected) != null && document.getElementById(vrLblSelected).value != "") {
            lstSelected = JSON.parse(document.getElementById(vrLblSelected).value);
            lstNewSelected = lstSelected;
        }
        if (document.getElementById(vrCheckID).checked && lstNewSelected.filter(function (x) { return x.ID == vrID; }).length == 0) {
            lstNewSelected[lstNewSelected.length] = vrSimple;
        }
        else if (document.getElementById(vrCheckID).checked == false && lstNewSelected.filter(function (x) { return x.ID == vrID; }).length > 0) {
            lstNewSelected = [];
            for (var vrIndex = 0; vrIndex < lstSelected.length; vrIndex++) {
                if (lstSelected[vrIndex].ID != vrID) {
                    lstNewSelected[lstNewSelected.length] = vrSimple;
                }
            }
        }
        document.getElementById(vrLblSelected).value = JSON.stringify(lstNewSelected);
    }
}
//# sourceMappingURL=SerializableSimple.js.map