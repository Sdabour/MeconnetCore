class BufferMeasure {
    public ID: number;
    public BufferID: number;
    public WorkOrder: string;
    public Date: Date;
    public Time: Date;
    public Value: number;
    public FirstValue: number;
    public MinValue: number;
    public MaxValue: number;
    public MinTime: Date;
    public Unit: number;

}
function GetBufferMeasureRow(objBiz: BufferMeasure): string {
    var Returned: string = "<tr>";
    Returned += "<td>" + objBiz.PLC.Desc + "</td>";
    Returned += "<td>" + objBiz.Type.NameA + "</td>";
    Returned += "<td>" + objBiz.Code + "</td>";
    Returned += "<td>" + objBiz.Desc + "</td>";


    Returned += "</tr>";
    return Returned;
}