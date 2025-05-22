class MeterMeasure
{
    public ID: number;
    public MeterID: number;
    public ProductName:string;
    public MeterDesc: string;
    public Date: Date;
    public DateStr: string;
    public Time: Date;
    public FirstValue: number;
    public MinValue: number;
    public MaxValue: number;
    public MinTime: Date;
    public MinTimeStr: string;
    public TimeStr: string;
    public TimeLabel: string;
    GetTimeLabel(vrSameDay:boolean): string {
        var Returned: string = vrSameDay ? this.TimeStr : this.DateStr;
        return Returned;
    }
    public Type: number;
    public TypeName: string;
    public IsAccumulated:boolean;
    public Value: number;
    public Unit: string;
    static GetRow(vrBiz: MeterMeasure): string {
        var Returned: string = "<tr>";
        Returned += "<td>" + vrBiz.DateStr + "</td>";
        Returned += "<td>" + vrBiz.MinTimeStr + "</td>";
        Returned += "<td> : </td>";
        Returned += "<td>" + vrBiz.TimeStr + "</td>";
        Returned += "<td>" + vrBiz.Value.toFixed(3) + "</td>";
        Returned += "<td>" + vrBiz.Unit + "</td>";
        Returned + "</tr>";
        return Returned;
    }

}
function ShowMeterMeasureModal(vrMeter: number, vrMeasureType: number)
{
    if (document.getElementById("lblIsBuffer") == null) {
        (<HTMLInputElement>document.getElementById("lblMeter")).value = vrMeter.toString();
    }
    else {
        (<HTMLInputElement>document.getElementById("lblMeter")).value = vrMeasureType.toString();
    }
    (<HTMLInputElement>document.getElementById("lblMeasureType")).value = vrMeasureType.toString();
    
    document.getElementById("myMeterMeasureModal").style.display = "block";
    return false;
}
function CloseMeterMeasureModal() {
    document.getElementById("myMeterMeasureModal").style.display = "none";
    (<HTMLInputElement>document.getElementById("lblMeter")).value = "0";
    (<HTMLInputElement>document.getElementById("lblMeasureType")).value = "0";
    return false;
}
function SetMeterLstMorisDat(vrMeasureLst: MeterMeasure[])
{
    var vrPoint;
    var vrMeasure: MeterMeasure;
    var vrPreviousMeasure: MeterMeasure;
    var vrSameDay: boolean = true;
    //var vrMaxDate: Date = vrMeasureLst.map(x => x.Time).reduce((a, b) => a > b ? a : b);
    //var vrMinDate: Date = vrMeasureLst.map(x => x.Time).reduce((a, b) => a < b ? a : b);
    var vrJsonData= [];
    var vrTimeDiff: number;
    for (var vrIndex = 0; vrIndex < vrMeasureLst.length; vrIndex++) {
        vrMeasure = vrMeasureLst[vrIndex];
        if (vrIndex < vrMeasureLst.length-1) {
            vrPreviousMeasure = vrMeasureLst[vrIndex + 1];
            vrTimeDiff = new Date(vrMeasure.MinTime).getTime();
            vrTimeDiff = (new Date(vrMeasure.MinTime).getTime() - new Date(vrPreviousMeasure.Time).getTime()) /( 1000 * 60);
            if (vrTimeDiff > 10)
            {
                vrPoint = { Time: new Date(vrPreviousMeasure.Time).setTime(new Date(vrPreviousMeasure.Time).getTime() + 1000), Value: 0 };
                vrJsonData[vrJsonData.length] = vrPoint;
                vrPoint = { Time:new Date(vrMeasure.MinTime).setTime(new Date(vrMeasure.MinTime).getTime() - 1000), Value: 0 };
                vrJsonData[vrJsonData.length] = vrPoint;
            }
        }
        vrPoint = { Time: vrMeasure.Time, Value: vrMeasure.Value };
        vrJsonData[vrJsonData.length] = vrPoint;
    }
    (<HTMLInputElement>document.getElementById("lblGraphJson")).value = JSON.stringify(vrJsonData);
    (<HTMLInputElement>document.getElementById("lblGraphJsonX")).value = "Time";
    var vrYKeys: string[] = [];
    vrYKeys[vrYKeys.length] = "Value";

    var vrLabel: string[]=[];

    vrLabel[0]= vrMeasureLst.length == 0 ? "" : vrMeasureLst[0].TypeName;

    (<HTMLInputElement>document.getElementById("lblGraphJsonY")).value =JSON.stringify(vrYKeys);
    (<HTMLInputElement>document.getElementById("lblGraphJsonLabel")).value = JSON.stringify(vrLabel);
}