declare class AssignmentObject {
    ID: number;
    Desc: string;
    Code: string;
    TableName: string;
    TableValueName: string;
    TableDisplayNameA: string;
    TableDisplayNameE: string;
    ConditionStr: string;
}
declare function GetAssignmentObjectRow(vrAssignment: AssignmentObject): string;
declare function FillAssignmentObjectTable(): void;
declare function ReturnAssignment(vrAssignmentID: number): void;
