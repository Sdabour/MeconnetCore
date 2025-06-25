class Buffer {
    public ID: number;
    public Type: BufferType;
    
    public Code: string;
    public Desc: string;
    public Size: number;
    public Tag: string;
    public WorkCenter: number;
    public Machine: number;
    public Product: number;
    public Measurement: number;
    public PLC: PLC;
    public PLCDataType: number;
    public PLCVarType: number;
    public Threshold: number;
    public IsPerHour: boolean;

}
function GetBufferRow(objBiz: Buffer): string {
    var Returned: string = "<tr>";
    Returned += "<td>" + objBiz.PLC.Desc + "</td>";
    Returned += "<td>" + objBiz.Type.NameA + "</td>";
    Returned += "<td>" + objBiz.Code + "</td>";
    Returned += "<td>" + objBiz.Desc + "</td>";
  

    Returned += "</tr>";
    return Returned;
}