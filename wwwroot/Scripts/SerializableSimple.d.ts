declare class SerializableSimple {
    ID: number;
    Code: string;
    Name: string;
    ForeignKey: number;
}
declare function GetSerializableCmbStr(arrSerializable: SerializableSimple[], strCmbID: string): string;
declare function GetSearchModal(lblSerializableArr: string, lblHidden: string, lblSelected: string): string;
declare function ClickSerializableReturn(vrID: number, lblSelected: string, lblHidden: string): void;
declare function GetFilterTable(lblSerializableArr: string, lblHidden: string, lblSelected: string): string;
declare function SetFilterTable(lblSerializableArr: string, lblHidden: string, lblSelected: string): void;
declare function ShowSerialModal(): boolean;
declare function CloseSerialModal(): boolean;
declare function GetSerializableSimpleTable(vrObjectName: string): void;
declare function OnChangeSerializableObject(vrObjectName: string, vrID: number): void;
