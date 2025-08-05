declare class MOComponent {
    MO: number;
    Product: number;
    Quantity: number;
    ProductID: number;
    ProductCode: string;
    ProductNameA: string;
    ProductNameE: string;
    ProductMeasurementID: number;
    ProductMeasurementCode: string;
    ProductMeasurementNameA: string;
    ProductMeasurementNameE: string;
}
declare function GetMOComponentRow(vrMOComponent: MOComponent): string;
declare function ReturnMOComponent(vrID: number): void;
declare function GetMOComponentData(): MOComponent;
declare function SetMOComponentData(vrMOComponent: MOComponent): void;
