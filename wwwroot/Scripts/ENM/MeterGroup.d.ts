declare class MeterGroup {
    ID: number;
    Code: string;
    NameA: string;
    NameE: string;
    Desc: string;
    LastUpdateTime: string;
    LastUpdateDate: string;
    OfflineCount: number;
    LastReadTime: string;
    MeterLst: Meter[];
}
declare function GetMeterGroupRow(objBiz: MeterGroup): string;
declare function GetGroupInitialRow(vrGroup: MeterGroup, strBtns: string): string;
declare function GetGroupPivot11(vrGroup: MeterGroup): string;
declare function GetGroupPivot(vrGroup: MeterGroup): string;
declare function GetGroupCard(vrGroup: MeterGroup): string;
declare function GetGroupHeaderArr1(vrGroup: MeterGroup): string[];
declare function GetGroupHeaderArr(vrGroup: MeterGroup): string[];
