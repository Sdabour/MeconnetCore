declare class Buffer {
    ID: number;
    Type: BufferType;
    Code: string;
    Desc: string;
    Size: number;
    Tag: string;
    WorkCenter: number;
    Machine: number;
    Product: number;
    Measurement: number;
    PLC: PLC;
    PLCDataType: number;
    PLCVarType: number;
    Threshold: number;
    IsPerHour: boolean;
}
declare function GetBufferRow(objBiz: Buffer): string;
