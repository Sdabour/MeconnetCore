declare class BufferMeasure {
    ID: number;
    Buffer: Buffer;
    WorkOrder: string;
    Date: Date;
    DateStr: string;
    Time: Date;
    TimeStr: string;
    Value: number;
    FirstValue: number;
    MinValue: number;
    MaxValue: number;
    MinTime: Date;
    MinTimeStr: string;
    Unit: number;
}
declare function GetBufferMeasureRow(objBiz: BufferMeasure): string;
declare function FillBufferMeasureTable(arrMeasure: BufferMeasure[]): void;
