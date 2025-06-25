declare class Employee {
    ID: number;
    Code: string;
    Name: string;
    FamousName: string;
    BranchName: string;
    Department: string;
    User: number;
    UserName: string;
}
declare function GetEmployeeRow(objBiz: Employee): string;
declare function onReturnEmployeeClick(vrEmpID: any): boolean;
declare function SetEmployeeData(vrEmployee: Employee): void;
declare function GetCurrentEmployee(): Employee;
