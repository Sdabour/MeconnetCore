declare class WorkOrder {
    ID: number;
    MO: number;
    Ref: string;
    Desc: string;
    Type: number;
    Product: number;
    Date: Date;
    Time: Date;
    Quantity: number;
    Periority: number;
    ProductCode: string;
    ProductNameA: string;
    ProductNameE: string;
    ProductMeasurementUnit: number;
    ProductMeasurementCode: string;
    ProductMeasurementNameA: string;
    ProductMeasurementNameE: string;
}
declare function GetWorkOrderRow(vrWorkOrder: WorkOrder): string;
declare function ReturnWorkOrder(vrID: number): void;
declare function GetWorkOrderData(): WorkOrder;
declare function SetWorkOrderData(vrWorkOrder: WorkOrder): void;
