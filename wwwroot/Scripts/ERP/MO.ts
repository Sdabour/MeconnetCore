class MO {
    public ID: number;
    public Ref: string;
    public Date: Date;
    public DateStr: string;
    public StartTime: Date
    public StartTimeStr: string;
    public Desc: string;
    public Quantity: number;
    public Responsible: number;
    public ResponsibleName: string;
    public Status: number;
    public StatusStr: string;
    public StatusTime: Date;
    public StatusTimeStr: string;
    public UserStarted: number;
    public UserStartedName: string;
    public BOM: number;
    public BOMName: string;
    public Product: number;
    public ProductName: string;



}
function GetMORow(objBiz: MO):string {
    var Returned: string = "<tr>";
    Returned += "<td>" + objBiz.Ref + "</td>";
    Returned += "<td>" + objBiz.ProductName + "</td>";
    Returned += "<td>" + objBiz.DateStr + "</td>";
    Returned += "<td>" + objBiz.StartTimeStr + "</td>";
    Returned += "<td>" + objBiz.StatusStr + "</td>";
    Returned += "<td>" + objBiz.StatusTimeStr + "</td>";
    Returned += "</tr>";
    return Returned;
}
function GetMOURL(objBiz: MO): string {
    //var vrSender = objBiz.Group == 0 ? objBiz.SenderApplicantName : objBiz.GroupName;
    var vrImage: string = objBiz.Status>0 ? "success.png" : "placeholder.jpg";
    vrImage = objBiz.Status > 0 ? "success.png" : "warning.png";
    //"pnotify""placeholders"
    let Returned: string = "<li class=\"media\">" +
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
        "<div class=\"form-row\"><div class=\"col-2\"><span class=\"text-muted\">" + objBiz.Ref + "</span></div><div class=\"col-3\" style=\"align-content:center;color:red;\">"+objBiz.StatusStr+"</div>";
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
     Returned+="</div>" +
        "</div>" +
        "</li>";
    return Returned;
}
function FillMOLst() {
    var lstMO: MO[] = [];
    if (document.getElementById("lblAllMO") != null && (<HTMLInputElement>document.getElementById("lblAllMO")).value!="" ) {
        lstMO = JSON.parse((<HTMLInputElement>document.getElementById("lblAllMO")).value);

    }
    var vrLstStr: string = "";
    for (var vrIndex = 0; vrIndex < lstMO.length; vrIndex++) {
        vrLstStr += GetMOURL(lstMO[vrIndex]);
    }
    var lstFilter: MO[] = lstMO.filter(x => x.Status == 0);
    var vrMsgCount: string = lstFilter.length == 0 ? "" : lstFilter.length.toString();
    document.getElementById("lblMOCount").innerText = vrMsgCount;
    if (document.getElementById("ulMO") != null) {
        (<HTMLInputElement>document.getElementById("ulMO")).innerHTML = vrLstStr;
     
    }
}
function AddMoListByRef(vrMO: MO) {
    var lstMO: MO[] = [];
    if (document.getElementById("lblAllMO") != null && (<HTMLInputElement>document.getElementById("lblAllMO")).value != "") {
        lstMO = JSON.parse((<HTMLInputElement>document.getElementById("lblAllMO")).value);

    }
    var lstFilter: MO[] = lstMO.filter(x => x.Ref == vrMO.Ref);

    if (lstFilter.length == 0) {
        lstMO[lstMO.length] = vrMO;
        (<HTMLInputElement>document.getElementById("lblAllMO")).value = JSON.stringify(lstMO);
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
        (<HTMLInputElement>document.getElementById("lblAllMO")).value = JSON.stringify(lstMO);
        FillMOLst();

    }
}
function EditMOStatusByID(vrMO: MO) {
    var lstMO: MO[] = [];
    if (document.getElementById("lblAllMO") != null && (<HTMLInputElement>document.getElementById("lblAllMO")).value != "") {
        lstMO = JSON.parse((<HTMLInputElement>document.getElementById("lblAllMO")).value);

    }
    var lstFilter: MO[] = lstMO.filter(x => x.ID == vrMO.ID);

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
        (<HTMLInputElement>document.getElementById("lblAllMO")).value = JSON.stringify(lstMO);
        FillMOLst();

    }
}
function ShowMOLoginModal(vrMo: number, vrStatus: number) {
    (<HTMLInputElement>document.getElementById("lblMOID")).value = vrMo.toString();
    (<HTMLInputElement>document.getElementById("lbStatus")).value = vrStatus.toString();

    (<HTMLInputElement>document.getElementById("myUserLogInModal")).style.display = "block";

}
function FillMOLstTable() {
    var lstMO: MO[] = [];
    if (document.getElementById("lblAllMO") != null && (<HTMLInputElement>document.getElementById("lblAllMO")).value != "") {
        lstMO = JSON.parse((<HTMLInputElement>document.getElementById("lblAllMO")).value);

    }
    var vrLstStr: string = "<table class=\"table\">";
    for (var vrIndex = 0; vrIndex < lstMO.length; vrIndex++) {
        vrLstStr += GetMORow(lstMO[vrIndex]);
    }
    vrLstStr += "</table>";
    if (document.getElementById("tblMODisplay") != null) {
        (<HTMLInputElement>document.getElementById("tblMODisplay")).innerHTML = vrLstStr;

    }
}
function FillMOTable(arrMO: MO[]) {

    var vrTable: string = "<table class=\"table\">";
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
        (<HTMLInputElement>document.getElementById("tblMO")).innerHTML = vrTable;
    }
}
function ShowMODisplayModal() {
    FillMOLstTable();

    (<HTMLInputElement>document.getElementById("myMOListDisplayModal")).style.display = "block";

}