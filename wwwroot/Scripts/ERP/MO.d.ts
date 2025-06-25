declare class MO {
    ID: number;
    Ref: string;
    Date: Date;
    StartTime: Date;
    StartTimeStr: string;
    Desc: string;
    Quantity: number;
    Responsible: number;
    ResponsibleName: string;
    Status: number;
    StatusStr: string;
    StatusTime: Date;
    UserStarted: number;
    UserStartedName: string;
    BOM: number;
    BOMName: string;
    Product: number;
    ProductName: string;
}
declare function GetMORow(objBiz: MO): string;
declare function GetMOURL(objBiz: MO): string;
declare function FillMOLst(): void;
declare function AddMoListByRef(vrMO: MO): void;
declare function EditMOStatusByID(vrMO: MO): void;
declare function ShowMOLoginModal(vrMo: number, vrStatus: number): void;
declare function FillMOLstTable(): void;
declare function ShowMODisplayModal(): void;
