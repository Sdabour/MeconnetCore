declare class FunctionSimple {
    ID: number;
    Name: string;
    Desc: string;
    SysID: number;
    ParentID: number;
    FamilyID: number;
    ParentName: string;
    FamilyName: string;
    Stoped: boolean;
    GetRow(objBiz: FunctionSimple): string;
    GetFunctionInstant(objFunction: FunctionSimple): FunctionInstant;
}
declare function GetFunctionByID(vrID: number): FunctionSimple;
declare function AddFunctionToInstantCol(intID: number): void;
declare function FillFunctionTable(): void;
declare function ShowFunctionModal(): boolean;
declare function CloseFunctionModal(): boolean;
