declare class Machine {
    ID: number;
    Process: Process;
    Center: WorkCenter;
    Flow: number;
    Code: string;
    Desc: string;
    NameA: string;
    NameE: string;
}
declare function GetMachineRow(vrMachine: Machine): string;
declare function ReturnMachine(vrID: number): void;
