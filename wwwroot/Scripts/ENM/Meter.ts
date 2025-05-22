class Meter {
    public ID: number;
    public ProductName: string;
    public GroupID: number;
    public GroupCode: string;
    public GroupNameA: string;
    public GroupNameE: string;
    public GroupDesc: string;
    public TypeID: number;
    public TypeCode: string;
    public TypeNameA: string;
    public TypeNameE: string;
    public Desc: string;
    public LastUpdateTime: string;
    public LastUpdateDate: string;
    public MeasureLst: Measurement[] = [];
    public OfflineCount: number;
    GetRow(objBiz: Meter): string {
        let Returned: string;

        Returned = "";
        let vrMeterID: string;
        vrMeterID = "lblMeter" + objBiz.ID;
        let strBtn: string = "<td><input type=\"button\" value=\"::\" id=\"btnReturnMeter" + objBiz.ID + "\"  onclick=\"return ShowMeasurementModal('" + objBiz.ID + "')\" name=\"btnReturnMeter" + objBiz.ID + "\" /></td>"
        Returned += GetMeterInitialRow(objBiz, strBtn);

        return Returned;
    }
}
function GetMeterInitialRow(vrMeter: Meter, strBtns: string): string {
    let Returned: string;
    var vrCount = vrMeter.MeasureLst.length;
     
    Returned = "";
    Returned += "<tr>";
    let vrMeterID: string;
    vrMeterID = "lblMeter" + vrMeter.ID;
    Returned += "<input type=\"hidden\" id=\"" + vrMeterID + "\" value='" + JSON.stringify(vrMeter) + "'\>";







    Returned += "<td>" + vrMeter.Desc + "</td>";
    Returned += "<td>" + vrMeter.ProductName + "</td>";
   // Returned += "<td>" + vrMeter.LastReadTime + "</td>";
    Returned += "<td>" + vrCount + "</td>";
   // Returned += "<td>" + vrMeasureCount + "</td>";
    Returned += strBtns;
    Returned += "</tr>";

    return Returned;
}
function ShowMeterModal(vrGroupID: number)
{
    DisplayMeterRead(vrGroupID);
    (<HTMLInputElement>document.getElementById("lblMeterGroup")).value = vrGroupID.toString();
    document.getElementById("myMeterModal").style.display = "block";
}

function DisplayMeterRead(vrGroupID: number) {
    var vrGroupLbl: string = (<HTMLInputElement>document.getElementById("lblGroup" + vrGroupID)).value;
    var vrMeterGroup: MeterGroup = JSON.parse(vrGroupLbl);
    var vrMeterCol: Meter[] = vrMeterGroup.MeterLst;
    var vrMeterStr: string = GetMeterLstTable(vrMeterCol);
    (<HTMLInputElement>document.getElementById("tblMeter")).innerHTML = vrMeterStr;
}
function DisplayLatestMeterRead() {
    var vrMeterID: number = 0;
    var vrMeter: string = (<HTMLInputElement>document.getElementById("lblMeterGroup")).value;
    if (vrMeter == null || vrMeter == "0")
        return;
    vrMeterID = Number(vrMeter);
    DisplayMeterRead(vrMeterID);
}
function GetMeterLstTable(lstMeter: Meter[]): string {
    var Returned: string = "";
    var vrTempMeter: Meter =new Meter();
    for (var vrIndex = 0; vrIndex < lstMeter.length; vrIndex++) {
        Returned += vrTempMeter.GetRow(lstMeter[vrIndex]);
    }
    var vrMeterTable: string = "";
   /* vrMeterTable = */
   
    return Returned;
}