class Tank {
    public Name:string;
    public ProductName:string;
    public DateStr:string;
    public TimeStr:string;

    public  LastRead:boolean;
  
    public Height:number;

  
    public  Volume:number;

    
    public  Temp:number;

    public  Density:number;

    public  Quantity:number;
}
function GetTankRow(vrBiz: Tank): string {
    var Returned: string = "<tr>";
    Returned += "<td>" + vrBiz.Name + "</td>";
    Returned += "<td>" + vrBiz.TimeStr + "</td>";
    Returned += "<td>" + vrBiz.ProductName + "</td>";
    Returned += "<td>" + vrBiz.TimeStr + "</td>";
    Returned += "<td>" + vrBiz.Height + "</td>";
    Returned += "<td>" + vrBiz.Volume + "</td>";
    Returned += "<td>" + vrBiz.Temp + "</td>";
    Returned += "<td>" + vrBiz.Quantity + "</td>";
    Returned += "<td>" + vrBiz.Density + "</td>";
    Returned + "</tr>";
    return Returned;
}