declare class Meter {
    ID: number;
    ProductName: string;
    GroupID: number;
    GroupCode: string;
    GroupNameA: string;
    GroupNameE: string;
    GroupDesc: string;
    TypeID: number;
    TypeCode: string;
    TypeNameA: string;
    TypeNameE: string;
    Desc: string;
    LastUpdateTime: string;
    LastUpdateDate: string;
    MeasureLst: Measurement[];
    OfflineCount: number;
    GetRow(objBiz: Meter): string;
}
declare function GetMeterInitialRow(vrMeter: Meter, strBtns: string): string;
declare function ShowMeterModal(vrGroupID: number): void;
declare function DisplayMeterRead(vrGroupID: number): void;
declare function DisplayLatestMeterRead(): void;
declare function GetMeterLstTable(lstMeter: Meter[]): string;
