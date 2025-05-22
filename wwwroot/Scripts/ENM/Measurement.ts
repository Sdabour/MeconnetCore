class Measurement {
    public MeterID: number;
    public MeterTypeID: number;
    public MeterTypeCode: string;
    public MeterTypeNameA: string;
    public MeterTypeNameE: string;
    public ProductName: string;
    public MeterGroup: number;
    public MeterGroupCode: string;
    public MeterGroupNameA: string;
    public MeterGroupNameE: string;
    public MeterGroupDesc: string;
    public LastNonZeroMeasureDate: Date;
    public LastNonZeroMeasureTime: Date;
    public LastNonZeroMeasureDateStr: string;
    public LastNonZeroMeasureTimeStr: string;
    public LastNonZeroMeasureUnit: string;
    public LastNonZeroMeasureValue: number;
    public LastNonZeroMeasureType: number;
    public LastNonZeroMeasureTypeID: number;
    public LastNonZeroMeasureTypeCode: string;
    public LastNonZeroMeasureTypeNameA: string;
    public LastNonZeroMeasureTypeNameE: string;
    public LastMeasureDate: Date;
    public LasMeasureTime: Date;
    public LastMeasureDateStr: string;
    public LasMeasureTimeStr: string;
    public LastMeasureUnit: string;
    public LastMeasureValue: number;
    public LastMeasureType: number;
    public LastMeasureTypeID: number;
    public LastMeasureTypeCode: string;
    public LastMeasureTypeNameA: string;
    public LastMeasureTypeNameE: string;
    public OnlineStatus: number;
    public ValueStatus: boolean;//
    GetRow(objBiz: Measurement): string {
        let Returned: string;

        Returned = "";
        let vrMeasurementID: string;
       // vrMeasurementID = "lblMeasurement" + objBiz.;
        let strBtn: string = "";//"<td><input type=\"button\" value=\"::\" id=\"btnReturnMeasurement" + objBiz.ID + "\"  onclick=\"return onReturnMeasurementClick('" + vrMeasurementID + "')\" name=\"btnReturnMeasurement" + objBiz.ID + "\" /></td>"
        Returned += GetMeasurementInitialRow(objBiz, strBtn);

        return Returned;
    }
}
function GetMeasurementInitialRow(vrMeasurement: Measurement, strBtns: string): string {
    let Returned: string;
    var vrOnlineStatusBackColor: string="red";

    Returned = "";
    Returned += "<tr>";
    let vrMeasurementID: string;
//    vrMeasurementID = "lblMeasurement" + vrMeasurement.ID;
   /* Returned += "<input type=\"hidden\" id=\"" + vrMeasurementID + "\" value='" + JSON.stringify(vrMeasurement) + "'\>";*/




    Returned += "<td><button id=\"btnShowMeasureMeter" + vrMeasurement.MeterID.toString() + "-" + vrMeasurement.LastMeasureTypeID.toString() + "\" class=\"e-button\" onclick=\"return ShowMeterMeasureModal(" + vrMeasurement.MeterID + "," + vrMeasurement.LastMeasureTypeID +");\">تفاصيل</button></td>";
    Returned += "<td>" + vrMeasurement.ProductName + "</td>";
    Returned += "<td>" + vrMeasurement.LastMeasureTypeNameA + "</td>";
    Returned += "<td>" + vrMeasurement.LastMeasureDateStr + "</td>";
    Returned += "<td>" + vrMeasurement.LastNonZeroMeasureTimeStr + "</td>";
    Returned += "<td>" + vrMeasurement.LastMeasureValue + "</td>";
    switch (vrMeasurement.OnlineStatus)
    {
        case (0): vrOnlineStatusBackColor = "red"; break;
        case (1): vrOnlineStatusBackColor = "green"; break;
        default: vrOnlineStatusBackColor = "yellow"; break;


    }
    Returned += "<td style=\"background-color:" + vrOnlineStatusBackColor + ";\"></td>";

  /*  Returned += "<td><span style=\"width:50%;background-color:" + vrOnlineStatusBackColor + ";\"></span></td>";*/
    Returned += strBtns;
    Returned += "</tr>";

    return Returned;
}
function ShowMeasurementModal(vrMeterID: number) {
    DisplayMeasureRead(vrMeterID);
    //lblMeasureMeter
    (<HTMLInputElement>document.getElementById("lblMeasureMeter")).value = vrMeterID.toString();
    document.getElementById("myMeasurementModal").style.display = "block";
}

function DisplayMeasureRead(vrMeterID: number)
{
    var vrMeterLbl: string = (<HTMLInputElement>document.getElementById("lblMeter" + vrMeterID)).value;
    var vrMeter: Meter = JSON.parse(vrMeterLbl);
    var vrMeasurementCol: Measurement[] = vrMeter.MeasureLst;
    var vrMeasurementStr: string = GetMeasurementLstTable(vrMeasurementCol);
    (<HTMLInputElement>document.getElementById("tblMeasurement")).innerHTML = vrMeasurementStr;
}
function DisplayLatestMeasureRead() {
    var vrMeterID: number = 0;
    var vrMeter: string = (<HTMLInputElement>document.getElementById("lblMeasureMeter")).value;
    if (vrMeter == null || vrMeter == "0")
        return;
    vrMeterID = Number(vrMeter);
    DisplayMeasureRead(vrMeterID);
}
function GetMeasurementLstTable(lstMeasurement: Measurement[]): string {
    var Returned: string = "";
    var vrTempMeasurement: Measurement = new Measurement();
    for (var vrIndex = 0; vrIndex < lstMeasurement.length; vrIndex++) {
        Returned += vrTempMeasurement.GetRow(lstMeasurement[vrIndex]);
    }
    var vrMeasurementTable: string = "";
    /* vrMeasurementTable = */

    return Returned;
}