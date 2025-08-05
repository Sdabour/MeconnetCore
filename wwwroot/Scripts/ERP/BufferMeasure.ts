class BufferMeasure {
    public ID: number;
    public Buffer: Buffer;
    public WorkOrder: string;
    public Date: Date;
    public DateStr: string;
    public Time: Date;
    public TimeStr: string;
    public Value: number;
    public FirstValue: number;
    public MinValue: number;
    public MaxValue: number;
    public MinTime: Date;
    public MinTimeStr: string;
    public Unit: number;

}
function GetBufferMeasureRow(objBiz: BufferMeasure): string {
    var Returned: string = "<tr>";
    Returned += "<td>" + objBiz.Buffer.PLC.Desc + "</td>";
    Returned += "<td>" + objBiz.Buffer.Desc + "</td>";
    Returned += "<td>" + objBiz.DateStr + "</td>";
    Returned += "<td>" + objBiz.TimeStr + "</td>";
    Returned += "<td>" + objBiz.Value.toFixed(2) + "</td>";
    Returned += "<td>" + objBiz.MinTimeStr + "</td>";
    Returned += "<td>" + objBiz.MinValue.toFixed(2) + "</td>";
    Returned += "<td>" + objBiz.MaxValue.toFixed(2) + "</td>";
    Returned += "<td>" + objBiz.FirstValue.toFixed(2) + "</td>";
    Returned += "</tr>";
    return Returned;
}
function FillBufferMeasureTable(arrMeasure: BufferMeasure[]) {
    var vrTable: string = "<table class=\"table\">";
    vrTable += "<tr>";
    vrTable += "<th>Machine</th>";
    vrTable += "<th>Buffer</th>";
    vrTable += "<th>Date</th>";
    vrTable += "<th>Time</th>";
    vrTable += "<th>Last Value</th>";
    vrTable += "<th>Min Time</th>";
    vrTable += "<th>Min Value</th>";
    vrTable += "<th>Max Value</th>";
    vrTable += "<th>First Value</th>";
    vrTable += "</tr>";
    for (var vrIndex = 0; vrIndex < arrMeasure.length&&vrIndex<100; vrIndex++)
    {
        vrTable += GetBufferMeasureRow(arrMeasure[vrIndex]);
    }
    vrTable += "</table>";
    if (document.getElementById("tblBufferMeasure") != null) {
        (<HTMLInputElement>document.getElementById("tblBufferMeasure")).innerHTML = vrTable;
    }
}