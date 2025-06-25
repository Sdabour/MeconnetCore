class SerializableSimple {

    ID: number;
    Code: string;
    Name: string;
    ForeignKey: number;

}
function GetSerializableCmbStr(arrSerializable: SerializableSimple[], strCmbID: string): string {
    var Returned: string = "";
    Returned = "<select class=\"form-control form-control-uniform multiselect-filter\" name=\"" + strCmbID + "\" id=\"" + strCmbID + "\">";
    var objBiz: SerializableSimple = new SerializableSimple();
    for (var vrIndex = 0; vrIndex < arrSerializable.length; vrIndex++) {
        objBiz = arrSerializable[vrIndex];
        Returned += "<option value=" + objBiz.ID + ">" + objBiz.Name + "</option>";
    }
    Returned += "</select>";

    return Returned;

}
function GetSearchModal(lblSerializableArr: string, lblHidden: string, lblSelected: string): string {
    var arrSerializable: SerializableSimple[] = JSON.parse((<HTMLInputElement>document.getElementById(lblSerializableArr)).value);

    var Returned: string = "";
    Returned += "<div class=\"form-row\"><div class=\"col\"><input type=\"text\" id=\"txtSerialFilter\" value=\"\" onchange=\"SetFilterTable('" + lblSerializableArr + "','" + lblHidden + "','" + lblSelected + "')\"/></div></div>";
    Returned += "<div class=\"table-responsive\" style=\"max-height:200px;scroll-behavior: auto;\">";
    Returned += "<table class=\"table\" id=\"tblSerial\">";
    Returned += GetFilterTable(lblSerializableArr, lblHidden, lblSelected);

    Returned += "</table></div>";




    if (document.getElementById("dvSerialModalContent") != null) {
        (<HTMLInputElement>document.getElementById("dvSerialModalContent")).innerHTML = Returned;
    }
    ShowSerialModal();
    return Returned;

}
function ClickSerializableReturn(vrID: number, lblSelected: string, lblHidden: string) {
    var vrObj = JSON.parse((<HTMLInputElement>document.getElementById("lblSerializable" + vrID.toString())).value);
    (<HTMLInputElement>document.getElementById(lblHidden)).value = JSON.stringify(vrObj);
    (<HTMLInputElement>document.getElementById(lblSelected)).innerText = vrObj.Name;
    CloseSerialModal();
}
function GetFilterTable(lblSerializableArr: string, lblHidden: string, lblSelected: string): string {
    var arrSerializable: SerializableSimple[] = JSON.parse((<HTMLInputElement>document.getElementById(lblSerializableArr)).value);
    var objBiz: SerializableSimple = new SerializableSimple();
    var vrFilter: string = "";
    if (document.getElementById("txtSerialFilter") != null) {
        vrFilter = (<HTMLInputElement>document.getElementById("txtSerialFilter")).value;
    }
    var arrFilter: SerializableSimple[] = [];
    arrFilter = arrSerializable.filter(x => vrFilter == "" || x.Name.indexOf(vrFilter) > -1);
    var vrTable = "";
    if (arrFilter.length == 0) {
        arrFilter = arrSerializable;
    }
    for (var vrIndex = 0; vrIndex < arrFilter.length; vrIndex++) {
        objBiz = arrFilter[vrIndex];
        vrTable += "<tr>";
        vrTable += "<input type=\"hidden\" id=\"lblSerializable" + objBiz.ID + "\" value='" + JSON.stringify(objBiz) + "'/>";
        vrTable += "<td>" + objBiz.Name + "</td>";
        vrTable += "<td><button onclick=\"ClickSerializableReturn(" + objBiz.ID + ",'" + lblSelected + "','" + lblHidden + "')\"> À»Ì </button></td>";
        vrTable += "</tr>";
    }
    return vrTable;
}
function SetFilterTable(lblSerializableArr: string, lblHidden: string, lblSelected: string) {
    var vrTable: string = GetFilterTable(lblSerializableArr, lblHidden, lblSelected);

    if (document.getElementById("tblSerial") != null) {
        (<HTMLInputElement>document.getElementById("tblSerial")).value = vrTable;
    }
    if (document.getElementById("dvSerialModalContent") != null) {
        (<HTMLInputElement>document.getElementById("dvSerialModalContent")).value = vrTable;
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

function GetSerializableSimpleTable(vrObjectName: string) {
    var vrLblAll: string = "lblAll" + vrObjectName;
    var vrLblSelected: string = "lblSelected" + vrObjectName;

    var lstAll: SerializableSimple[] = [];
    var lstSelected: SerializableSimple[] = [];
    if (document.getElementById(vrLblAll) != null && (<HTMLInputElement>document.getElementById(vrLblAll)).value != "") {
        lstAll = JSON.parse((<HTMLInputElement>document.getElementById(vrLblAll)).value);
    }

    if (document.getElementById(vrLblSelected) != null && (<HTMLInputElement>document.getElementById(vrLblSelected)).value != "") {
        lstSelected = JSON.parse((<HTMLInputElement>document.getElementById(vrLblSelected)).value);
    }
    var vrChecked: string = "";
    var lstFilter: SerializableSimple[] = lstAll;
    var vrSelectedOnly: boolean = false;

    if (document.getElementById("chkOnlySelected" + vrObjectName) != null) {
        vrSelectedOnly = (<HTMLInputElement>document.getElementById("chkOnlySelected" + vrObjectName)).checked;
    }
    if (vrSelectedOnly) {
        lstFilter = lstFilter.filter(x => lstSelected.map(y => y.ID).filter(z => z == x.ID).length > 0);
    }
    if (document.getElementById("txtFilter" + vrObjectName) != null && (<HTMLInputElement>document.getElementById("txtFilter" + vrObjectName)).value != "") {
        var vrTxtFilter = (<HTMLInputElement>document.getElementById("txtFilter" + vrObjectName)).value;
        lstFilter = lstFilter.filter(x => x.Name.indexOf(vrTxtFilter) != -1);
    }
    var Returned: string = "<table class=\"table\" style=\"max-height:300px;\">";
    for (var vrIndex = 0; vrIndex < lstFilter.length; vrIndex++) {
        vrChecked = lstSelected.filter(x => x.ID == lstFilter[vrIndex].ID).length > 0 ? "checked" : "";
        Returned += "<tr>";
        Returned += "<td><input type=\"checkbox\" id=\"chk" + vrObjectName + lstFilter[vrIndex].ID.toString() + "\" " + vrChecked + " onchange=\"OnChangeSerializableObject('" + vrObjectName + "'," + lstFilter[vrIndex].ID.toString() + ")\"/>" + "</td>";
        Returned += "<td>" + lstFilter[vrIndex].ID.toString() + "</td>";
        Returned += "<td>" + lstFilter[vrIndex].Name + "</td>";
        Returned += "</tr>";
    }
    Returned += "</table>";
    if (document.getElementById("tbl" + vrObjectName) != null) {
        { (<HTMLInputElement>document.getElementById("tbl" + vrObjectName)).innerHTML = Returned; }
    }
}
function OnChangeSerializableObject(vrObjectName: string, vrID: number) {
    var vrCheckID = "chk" + vrObjectName + vrID.toString();

    if (document.getElementById(vrCheckID) != null) {
        var vrLblAll: string = "lblAll" + vrObjectName;
        var vrLblSelected: string = "lblSelected" + vrObjectName;


        var lstAll: SerializableSimple[] = [];
        var lstSelected: SerializableSimple[] = [];
        var lstNewSelected: SerializableSimple[] = [];
        if (document.getElementById(vrLblAll) != null && (<HTMLInputElement>document.getElementById(vrLblAll)).value != "") {
            lstAll = JSON.parse((<HTMLInputElement>document.getElementById(vrLblAll)).value);
        }
        if (lstAll.filter(x => x.ID == vrID).length == 0) { return; }
        var vrSimple: SerializableSimple = new SerializableSimple();
        vrSimple = lstAll.filter(x => x.ID == vrID)[0];

        if (document.getElementById(vrLblSelected) != null && (<HTMLInputElement>document.getElementById(vrLblSelected)).value != "") {
            lstSelected = JSON.parse((<HTMLInputElement>document.getElementById(vrLblSelected)).value);
            lstNewSelected = lstSelected;
        }
        if ((<HTMLInputElement>document.getElementById(vrCheckID)).checked && lstNewSelected.filter(x => x.ID == vrID).length == 0) {
            lstNewSelected[lstNewSelected.length] = vrSimple;
        }
        else if ((<HTMLInputElement>document.getElementById(vrCheckID)).checked == false && lstNewSelected.filter(x => x.ID == vrID).length > 0) {
            lstNewSelected = [];
            for (var vrIndex = 0; vrIndex < lstSelected.length; vrIndex++) {
                if (lstSelected[vrIndex].ID != vrID) {
                    lstNewSelected[lstNewSelected.length] = vrSimple;
                }
            }

        }

        (<HTMLInputElement>document.getElementById(vrLblSelected)).value = JSON.stringify(lstNewSelected);
    }
}


