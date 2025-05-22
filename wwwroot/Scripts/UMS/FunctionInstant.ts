class FunctionInstant
{
    //public ID: number;
    //public Name: string;
    //public System: number;
    //public ParentID: number;
    //public ParentName: string;
    public FunctionSimple: FunctionSimple = new FunctionSimple();
    public IsPermanent: boolean;
    public StartDate: Date;
    public EndDate: Date;
    public IsAdmin: boolean;
    GetRow(objBiz: FunctionInstant): string {
        let Returned: string;
        Returned = "";
        Returned += "<tr>";
        let vrFunctionID: string;
        vrFunctionID = "lblFunction" + objBiz.FunctionSimple.ID;
        Returned += "<input type=\"hidden\" id=\"" + vrFunctionID + "\" value='" + JSON.stringify(objBiz) + "'\>";
        Returned += "<td>" + objBiz.FunctionSimple.ID + "</td>";


        Returned += "<td>" + objBiz.FunctionSimple.ParentName + "</td>";
        Returned += "<td>" + objBiz.FunctionSimple.Name + "</td>";
        var vrChecked: string = objBiz.IsPermanent ? "checked" : "";

        Returned += "<td><input type=\"checkbox\" id=\"chkIsPermanent" + objBiz.FunctionSimple.ID.toString() + "\" " + vrChecked + ">" + "</td>";
        vrChecked= objBiz.IsAdmin ? "checked" : "";
        Returned += "<td><input type=\"checkbox\" id=\"chkIsAdmin" + objBiz.FunctionSimple.ID.toString() + "\" " + vrChecked + ">" + "</td>";
        var vrDate = objBiz.IsPermanent ? "" : objBiz.StartDate.toString().substring(0, 10); 
        Returned += "<td> <input type=\"date\" id=\"dtStartDate" + objBiz.FunctionSimple.ID + "\" value=\"" + vrDate + "\" /></td>";
         vrDate = objBiz.IsPermanent ? "" : objBiz.EndDate.toString().substring(0, 10); 
        Returned += "<td> <input type=\"date\" id=\"dtEndDate" + objBiz.FunctionSimple.ID + "\" value=\"" + vrDate + "\" /></td>";
        Returned += "<td><input type=\"button\" value=\"E\" id=\"btnEditFunction" + objBiz.FunctionSimple.ID + "\"  onclick=\"return EditFunctionInstant('" + objBiz.FunctionSimple.ID + "')\" name=\"btnEditFunction" + objBiz.FunctionSimple.ID + "\" /></td>";
        Returned += "</tr>";

        return Returned;
    }
}
function FillFunctionInstantTable()
{
    var vrAllFunctionStr: string = (<HTMLInputElement>document.getElementById("lblAllFunctionInstant")).value;
    if (vrAllFunctionStr == "")
        return;
    var vrTable: string = "<table class=\"table\">";
    vrTable += "<tr><th></th><th></th><th></th><th>IsPer</th><th>IsAdmin</th></tr>";
    var arrFunction: FunctionInstant[] = JSON.parse(vrAllFunctionStr);
    var vrSystem: number = Number((<HTMLInputElement>document.getElementById("cmbSystem")).value);
    arrFunction = arrFunction.filter(function (x) { return x.FunctionSimple.SysID == vrSystem });
    var vrTempFunction: FunctionInstant = new FunctionInstant(); 
    for (var vrIndex = 0; vrIndex < arrFunction.length; vrIndex++) {
        vrTable += vrTempFunction.GetRow(arrFunction[vrIndex]);
    }
    vrTable += "</table>";
    (<HTMLInputElement>document.getElementById("dvFunctionInstant")).innerHTML = vrTable;
}
 
function EditFunctionInstant(vrID:number)
{
    var vrAllFunctionInstStr: string = (<HTMLInputElement>document.getElementById("lblAllFunctionInstant")).value;
    var vrAllFunctionLst: FunctionInstant[] = [];
    if (vrAllFunctionInstStr != "") {
        vrAllFunctionLst = JSON.parse(vrAllFunctionInstStr);
    }
    var vrFunction: FunctionInstant = new FunctionInstant();
    for (var vrIndex = 0; vrIndex < vrAllFunctionLst.length; vrIndex++) {

        if (vrAllFunctionLst[vrIndex].FunctionSimple.ID == vrID) {
            vrFunction = vrAllFunctionLst[vrIndex];
            vrFunction.IsPermanent = Boolean((<HTMLInputElement>document.getElementById("chkIsPermanent" + vrID)).checked);
            vrFunction.StartDate = new Date(Date.now());
            vrFunction.EndDate = new Date(Date.now());
            vrFunction.IsAdmin = Boolean((<HTMLInputElement>document.getElementById("chkIsAdmin" + vrID)).checked);
            if (!vrFunction.IsPermanent)
            {
                vrFunction.StartDate = new Date((<HTMLInputElement>document.getElementById("dtStartDate" + vrID)).value);
                vrFunction.EndDate = new Date((<HTMLInputElement>document.getElementById("dtEndDate" + vrID)).value);
            }
            vrAllFunctionLst[vrIndex] = vrFunction;
            break;
        }
    }
    vrAllFunctionInstStr = JSON.stringify(vrAllFunctionLst);
    (<HTMLInputElement>document.getElementById("lblAllFunctionInstant")).value = vrAllFunctionInstStr;
    FillFunctionInstantTable();

}