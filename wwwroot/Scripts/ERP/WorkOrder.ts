class WorkOrder {
    public ID: number;
    public MO: number;
    public Ref: string;
    public Desc: string;
    public Type: number;
    public Product: number;
    public Date: Date;
    public Time: Date;
    public Quantity: number;
    public Periority: number;
    public ProductCode: string;
    public ProductNameA: string;
    public ProductNameE: string;
    public ProductMeasurementUnit: number;
    public ProductMeasurementCode: string;
    public ProductMeasurementNameA: string;
    public ProductMeasurementNameE: string;

}
function GetWorkOrderRow(vrWorkOrder: WorkOrder): string {
    var Returned: string = "<tr>";
    Returned += "<input type \"hidden\" id=\"lblWorkOrder" + vrWorkOrder.ID.toString() + "\" value='" + JSON.stringify(vrWorkOrder) + "'/>";
    Returned += "<td>" + vrWorkOrder.ID + "</td>";
    Returned += "<td>" + vrWorkOrder.MO + "</td>";
    Returned += "<td>" + vrWorkOrder.Ref + "</td>";
    Returned += "<td>" + vrWorkOrder.Desc + "</td>";
    Returned += "<td>" + vrWorkOrder.Type + "</td>";
    Returned += "<td>" + vrWorkOrder.Product + "</td>";
    Returned += "<td>" + vrWorkOrder.Date + "</td>";
    Returned += "<td>" + vrWorkOrder.Time + "</td>";
    Returned += "<td>" + vrWorkOrder.Quantity + "</td>";
    Returned += "<td>" + vrWorkOrder.Periority + "</td>";
    Returned += "<td>" + vrWorkOrder.ProductCode + "</td>";
    Returned += "<td>" + vrWorkOrder.ProductNameA + "</td>";
    Returned += "<td>" + vrWorkOrder.ProductNameE + "</td>";
    Returned += "<td>" + vrWorkOrder.ProductMeasurementUnit + "</td>";
    Returned += "<td>" + vrWorkOrder.ProductMeasurementCode + "</td>";
    Returned += "<td>" + vrWorkOrder.ProductMeasurementNameA + "</td>";
    Returned += "<td>" + vrWorkOrder.ProductMeasurementNameE + "</td>";
    Returned += "<td><input type=\"button\" value=\"+\" onclick=\"ReturnWorkOrder(" + vrWorkOrder.ID + ");\" /></td>";

    Returned += "</tr>";
    return Returned;
}
function ReturnWorkOrder(vrID: number) {
    if (document.getElementById("lblWorkOrder" + vrID.toString() + "") == null) {
        return;
    }
    var vrWorkOrderStr: string = (<HTMLInputElement>document.getElementById("lblWorkOrder" + vrID.toString())).value;
    var vrWorkOrder: WorkOrder = JSON.parse(vrWorkOrderStr);
    if (document.getElementById("lblCurrentWorkOrder") != null) {
        (<HTMLInputElement>document.getElementById("lblCurrentWorkOrder")).value = vrWorkOrderStr;
    }
    if (document.getElementById("lblWorkOrderID") != null) {
        (<HTMLInputElement>document.getElementById("lblWorkOrderID")).innerText = vrWorkOrder.ID.toString();
    }
    if (document.getElementById("lblWorkOrderMO") != null) {
        (<HTMLInputElement>document.getElementById("lblWorkOrderMO")).innerText = vrWorkOrder.MO.toString();
    }
    if (document.getElementById("lblWorkOrderRef") != null) {
        (<HTMLInputElement>document.getElementById("lblWorkOrderRef")).innerText = vrWorkOrder.Ref;
    }
    if (document.getElementById("lblWorkOrderDesc") != null) {
        (<HTMLInputElement>document.getElementById("lblWorkOrderDesc")).innerText = vrWorkOrder.Desc;
    }
    if (document.getElementById("lblWorkOrderType") != null) {
        (<HTMLInputElement>document.getElementById("lblWorkOrderType")).innerText = vrWorkOrder.Type.toString();
    }
    if (document.getElementById("lblWorkOrderProduct") != null) {
        (<HTMLInputElement>document.getElementById("lblWorkOrderProduct")).innerText = vrWorkOrder.Product.toString();
    }
    if (document.getElementById("lblWorkOrderDate") != null) {
        (<HTMLInputElement>document.getElementById("lblWorkOrderDate")).innerText = vrWorkOrder.Date.toISOString().substring(0,10);
    }
    if (document.getElementById("lblWorkOrderTime") != null) {
        (<HTMLInputElement>document.getElementById("lblWorkOrderTime")).innerText = vrWorkOrder.Time.toISOString().substring(0, 10);
    }
    if (document.getElementById("lblWorkOrderQuantity") != null) {
        (<HTMLInputElement>document.getElementById("lblWorkOrderQuantity")).innerText = vrWorkOrder.Quantity.toString();
    }
    if (document.getElementById("lblWorkOrderPeriority") != null) {
        (<HTMLInputElement>document.getElementById("lblWorkOrderPeriority")).innerText = vrWorkOrder.Periority.toString();
    }
    if (document.getElementById("lblWorkOrderProductCode") != null) {
        (<HTMLInputElement>document.getElementById("lblWorkOrderProductCode")).innerText = vrWorkOrder.ProductCode;
    }
    if (document.getElementById("lblWorkOrderProductNameA") != null) {
        (<HTMLInputElement>document.getElementById("lblWorkOrderProductNameA")).innerText = vrWorkOrder.ProductNameA;
    }
    if (document.getElementById("lblWorkOrderProductNameE") != null) {
        (<HTMLInputElement>document.getElementById("lblWorkOrderProductNameE")).innerText = vrWorkOrder.ProductNameE;
    }
    if (document.getElementById("lblWorkOrderProductMeasurementUnit") != null) {
        (<HTMLInputElement>document.getElementById("lblWorkOrderProductMeasurementUnit")).innerText = vrWorkOrder.ProductMeasurementUnit.toString();
    }
    if (document.getElementById("lblWorkOrderProductMeasurementCode") != null) {
        (<HTMLInputElement>document.getElementById("lblWorkOrderProductMeasurementCode")).innerText = vrWorkOrder.ProductMeasurementCode;
    }
    if (document.getElementById("lblWorkOrderProductMeasurementNameA") != null) {
        (<HTMLInputElement>document.getElementById("lblWorkOrderProductMeasurementNameA")).innerText = vrWorkOrder.ProductMeasurementNameA;
    }
    if (document.getElementById("lblWorkOrderProductMeasurementNameE") != null) {
        (<HTMLInputElement>document.getElementById("lblWorkOrderProductMeasurementNameE")).innerText = vrWorkOrder.ProductMeasurementNameE;
    }

}
function GetWorkOrderData(): WorkOrder {
    if (document.getElementById("lblCurrentWorkOrder") == null) {
        return;
    }
    var vrWorkOrderStr: string = (<HTMLInputElement>document.getElementById("lblCurrentWorkOrder")).value;
    var vrWorkOrder: WorkOrder = new WorkOrder();
    if (vrWorkOrderStr != "") {
        vrWorkOrder = JSON.parse(vrWorkOrderStr);
    }
    if (document.getElementById("txtWorkOrderID") != null) {
        vrWorkOrder.ID =Number( (<HTMLInputElement>document.getElementById("txtWorkOrderID")).innerText);
    }
    if (document.getElementById("txtWorkOrderMO") != null) {
       /* vrWorkOrder.MO = (<HTMLInputElement>document.getElementById("txtWorkOrderMO")).innerText;*/
    }
    if (document.getElementById("txtWorkOrderRef") != null) {
        vrWorkOrder.Ref = (<HTMLInputElement>document.getElementById("txtWorkOrderRef")).innerText;
    }
    if (document.getElementById("txtWorkOrderDesc") != null) {
        vrWorkOrder.Desc = (<HTMLInputElement>document.getElementById("txtWorkOrderDesc")).innerText;
    }
    if (document.getElementById("txtWorkOrderType") != null) {
       /* vrWorkOrder.Type = (<HTMLInputElement>document.getElementById("txtWorkOrderType")).innerText;*/
    }
    if (document.getElementById("txtWorkOrderProduct") != null) {
      /*  vrWorkOrder.Product = (<HTMLInputElement>document.getElementById("txtWorkOrderProduct")).innerText;*/
    }
    if (document.getElementById("dtWorkOrderDate") != null) {
       /* vrWorkOrder.Date = (<HTMLInputElement>document.getElementById("dtWorkOrderDate")).value;*/
    }
    if (document.getElementById("dtWorkOrderTime") != null) {
       /* vrWorkOrder.Time = (<HTMLInputElement>document.getElementById("dtWorkOrderTime")).value;*/
    }
    if (document.getElementById("txtWorkOrderQuantity") != null) {
       /* vrWorkOrder.Quantity = (<HTMLInputElement>document.getElementById("txtWorkOrderQuantity")).innerText;*/
    }
    if (document.getElementById("txtWorkOrderPeriority") != null) {
      /*  vrWorkOrder.Periority = (<HTMLInputElement>document.getElementById("txtWorkOrderPeriority")).innerText;*/
    }
    if (document.getElementById("txtWorkOrderProductCode") != null) {
        vrWorkOrder.ProductCode = (<HTMLInputElement>document.getElementById("txtWorkOrderProductCode")).innerText;
    }
    if (document.getElementById("txtWorkOrderProductNameA") != null) {
        vrWorkOrder.ProductNameA = (<HTMLInputElement>document.getElementById("txtWorkOrderProductNameA")).innerText;
    }
    if (document.getElementById("txtWorkOrderProductNameE") != null) {
        vrWorkOrder.ProductNameE = (<HTMLInputElement>document.getElementById("txtWorkOrderProductNameE")).innerText;
    }
    if (document.getElementById("txtWorkOrderProductMeasurementUnit") != null) {
     /*   vrWorkOrder.ProductMeasurementUnit = (<HTMLInputElement>document.getElementById("txtWorkOrderProductMeasurementUnit")).innerText;*/
    }
    if (document.getElementById("txtWorkOrderProductMeasurementCode") != null) {
        vrWorkOrder.ProductMeasurementCode = (<HTMLInputElement>document.getElementById("txtWorkOrderProductMeasurementCode")).innerText;
    }
    if (document.getElementById("txtWorkOrderProductMeasurementNameA") != null) {
        vrWorkOrder.ProductMeasurementNameA = (<HTMLInputElement>document.getElementById("txtWorkOrderProductMeasurementNameA")).innerText;
    }
    if (document.getElementById("txtWorkOrderProductMeasurementNameE") != null) {
        vrWorkOrder.ProductMeasurementNameE = (<HTMLInputElement>document.getElementById("txtWorkOrderProductMeasurementNameE")).innerText;
    }

}
function SetWorkOrderData(vrWorkOrder: WorkOrder) {
    if (document.getElementById("lblCurrentWorkOrder ") == null) {
        return;
    }
    (<HTMLInputElement>document.getElementById("lblCurrentWorkOrder ")).value = JSON.stringify(vrWorkOrder);

    if (document.getElementById("txtWorkOrderID") != null) {
        (<HTMLInputElement>document.getElementById("txtWorkOrderID")).innerText = vrWorkOrder.ID.toString();
    }
    if (document.getElementById("txtWorkOrderMO") != null) {
        (<HTMLInputElement>document.getElementById("txtWorkOrderMO")).innerText = vrWorkOrder.MO.toString();
    }
    if (document.getElementById("txtWorkOrderRef") != null) {
        (<HTMLInputElement>document.getElementById("txtWorkOrderRef")).innerText = vrWorkOrder.Ref;
    }
    if (document.getElementById("txtWorkOrderDesc") != null) {
        (<HTMLInputElement>document.getElementById("txtWorkOrderDesc")).innerText = vrWorkOrder.Desc;
    }
    if (document.getElementById("txtWorkOrderType") != null) {
        (<HTMLInputElement>document.getElementById("txtWorkOrderType")).innerText = vrWorkOrder.Type.toString();
    }
    if (document.getElementById("txtWorkOrderProduct") != null) {
        (<HTMLInputElement>document.getElementById("txtWorkOrderProduct")).innerText = vrWorkOrder.Product.toString();
    }
    if (document.getElementById("dtWorkOrderDate") != null) {
       /* (<HTMLInputElement>document.getElementById("dtWorkOrderDate")).value = vrWorkOrder.Date;*/
    }
    if (document.getElementById("dtWorkOrderTime") != null) {
      /*  (<HTMLInputElement>document.getElementById("dtWorkOrderTime")).value = vrWorkOrder.Time;*/
    }
    if (document.getElementById("txtWorkOrderQuantity") != null) {
      /*  (<HTMLInputElement>document.getElementById("txtWorkOrderQuantity")).innerText = vrWorkOrder.Quantity;*/
    }
    if (document.getElementById("txtWorkOrderPeriority") != null) {
      /*  (<HTMLInputElement>document.getElementById("txtWorkOrderPeriority")).innerText = vrWorkOrder.Periority;*/
    }
    if (document.getElementById("txtWorkOrderProductCode") != null) {
        (<HTMLInputElement>document.getElementById("txtWorkOrderProductCode")).innerText = vrWorkOrder.ProductCode;
    }
    if (document.getElementById("txtWorkOrderProductNameA") != null) {
        (<HTMLInputElement>document.getElementById("txtWorkOrderProductNameA")).innerText = vrWorkOrder.ProductNameA;
    }
    if (document.getElementById("txtWorkOrderProductNameE") != null) {
        (<HTMLInputElement>document.getElementById("txtWorkOrderProductNameE")).innerText = vrWorkOrder.ProductNameE;
    }
    if (document.getElementById("txtWorkOrderProductMeasurementUnit") != null) {
       /* (<HTMLInputElement>document.getElementById("txtWorkOrderProductMeasurementUnit")).innerText = vrWorkOrder.ProductMeasurementUnit;*/
    }
    if (document.getElementById("txtWorkOrderProductMeasurementCode") != null) {
        (<HTMLInputElement>document.getElementById("txtWorkOrderProductMeasurementCode")).innerText = vrWorkOrder.ProductMeasurementCode;
    }
    if (document.getElementById("txtWorkOrderProductMeasurementNameA") != null) {
        (<HTMLInputElement>document.getElementById("txtWorkOrderProductMeasurementNameA")).innerText = vrWorkOrder.ProductMeasurementNameA;
    }
    if (document.getElementById("txtWorkOrderProductMeasurementNameE") != null) {
        (<HTMLInputElement>document.getElementById("txtWorkOrderProductMeasurementNameE")).innerText = vrWorkOrder.ProductMeasurementNameE;
    }

}
