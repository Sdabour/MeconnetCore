declare class CustomerSimple {
    ID: number;
    Name: string;
    UnitCode: string;
    TowerCode: string;
    ProjectCode: string;
    Project: string;
    ProjectName: string;
    Mobile1: string;
    Mobile2: string;
    Phone1: string;
    Phone2: string;
    GetRow(objBiz: CustomerSimple): string;
    FillSelectedTable(): void;
    AddCustomerToSelected(intID: number): void;
    DeleteCustomer(intIndex: number): void;
}
