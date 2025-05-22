
class FunctionSimple
{
    public ID: number;
    public Name: string;
    public Desc: string;
    public SysID: number;
    public ParentID: number;
    public FamilyID: number;
    public ParentName: string;
    public FamilyName: string;
    public Stoped: boolean;
    GetRow(objBiz: FunctionSimple): string {
        let Returned: string;
        Returned = "";
        Returned += "<tr>";
        let vrFunctionID: string;
        vrFunctionID = "lblFunction" + objBiz.ID;
        Returned += "<input type=\"hidden\" id=\"" + vrFunctionID + "\" value='" + JSON.stringify(objBiz) + "'\>";
        Returned += "<td>" + objBiz.ID + "</td>";


        Returned += "<td>" + objBiz.ParentName + "</td>";
        Returned += "<td>" + objBiz.Name + "</td>";



      

        Returned += "<td><input type=\"button\" value=\"تثبيت\" id=\"btnReturnFunction" + objBiz.ID + "\"  onclick=\"return AddFunctionToInstantCol('" + objBiz.ID + "')\" name=\"btnReturnFunction" + objBiz.ID + "\" /></td>";
        Returned += "</tr>";

        return Returned;
    }
    GetFunctionInstant(objFunction:FunctionSimple): FunctionInstant {
        var Returned: FunctionInstant=new FunctionInstant();
        Returned.FunctionSimple = objFunction;
        Returned.IsPermanent = true;

        return Returned;
    }
}
function GetFunctionByID(vrID: number): FunctionSimple {
    var vrFunctionStr: string = (<HTMLInputElement>document.getElementById("lblFunction" + vrID)).value;
    
    var Returned: FunctionSimple = new FunctionSimple();
    if (vrFunctionStr != "") {
        Returned = JSON.parse(vrFunctionStr);

    }
    return Returned;
}
function AddFunctionToInstantCol(intID: number) {
    var vrFunction: FunctionSimple = GetFunctionByID(intID);
   
    var vrAllFunctionInstStr: string = (<HTMLInputElement>document.getElementById("lblAllFunctionInstant")).value;
    var vrAllFunctionLst: FunctionInstant[] = [];
    if (vrAllFunctionInstStr != "") {
        vrAllFunctionLst= JSON.parse(vrAllFunctionInstStr);
    }
    
    if (vrAllFunctionLst.filter(function (x) { return x.FunctionSimple.ID == vrFunction.ID }).length > 0)
        return;
    var vrFunctionTemp: FunctionSimple = new FunctionSimple();
    vrAllFunctionLst[vrAllFunctionLst.length] = vrFunctionTemp.GetFunctionInstant(vrFunction);
    (<HTMLInputElement>document.getElementById("lblAllFunctionInstant")).value = JSON.stringify(vrAllFunctionLst);
    FillFunctionInstantTable();

}
function FillFunctionTable() {
    var vrAllFunctionStr: string = (<HTMLInputElement>document.getElementById("lblAllFunction")).value;
    if (vrAllFunctionStr == "")
        return;
    var vrFunctionLst: FunctionSimple[] = JSON.parse(vrAllFunctionStr);
    var vrSys: number = Number((<HTMLInputElement>document.getElementById("cmbFunctionSystem")).value);
    vrFunctionLst = vrFunctionLst.filter(function (x) { return x.SysID == vrSys; });
    var vrFilter = (<HTMLInputElement>document.getElementById("txtFunctionFilter")).value;
    vrFunctionLst = vrFunctionLst.filter(function (x) { return vrFilter == "" || x.Name.indexOf(vrFilter) > -1 || x.ParentName.indexOf(vrFilter) > -1; });
    var vrOnlyFamily: boolean = (<HTMLInputElement>document.getElementById("chkFamilyNodes")).checked
    vrFunctionLst = vrFunctionLst.filter(function (x) { return vrOnlyFamily == false || x.ID==x.FamilyID; });
    var vrTable: string = "<table class=\"table\">";
    var vrFunction: FunctionSimple = new FunctionSimple();
    for (var vrIndex = 0; vrIndex < vrFunctionLst.length; vrIndex++) {
        vrTable += vrFunction.GetRow(vrFunctionLst[vrIndex]);

    }
    vrTable += "</table>";
    (<HTMLInputElement>document.getElementById("dvFunction")).innerHTML = vrTable;

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
