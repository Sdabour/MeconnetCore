declare class FunctionInstant {
    FunctionSimple: FunctionSimple;
    IsPermanent: boolean;
    StartDate: Date;
    EndDate: Date;
    IsAdmin: boolean;
    GetRow(objBiz: FunctionInstant): string;
}
declare function FillFunctionInstantTable(): void;
declare function EditFunctionInstant(vrID: number): void;
