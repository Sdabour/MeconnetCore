class MOComponent {
    public MO: number;
    public Product: number;
    public Quantity: number;
    public ProductID: number;
    public ProductCode: string;
    public ProductNameA: string;
    public ProductNameE: string;
    public ProductMeasurementID: number;
    public ProductMeasurementCode: string;
    public ProductMeasurementNameA: string;
    public ProductMeasurementNameE: string;

}
function GetMOComponentRow(vrMOComponent: MOComponent): string {
    var Returned: string = "<tr>";
   /* Returned += "<input type \"hidden\" id=\"lblMOComponent" + vrMOComponent.ID.toString() + "\" value='" + JSON.stringify(vrMOComponent) + "'/>";*/
    Returned += "<td>" + vrMOComponent.MO + "</td>";
    Returned += "<td>" + vrMOComponent.Product + "</td>";
    Returned += "<td>" + vrMOComponent.Quantity + "</td>";
    Returned += "<td>" + vrMOComponent.ProductID + "</td>";
    Returned += "<td>" + vrMOComponent.ProductCode + "</td>";
    Returned += "<td>" + vrMOComponent.ProductNameA + "</td>";
    Returned += "<td>" + vrMOComponent.ProductNameE + "</td>";
    Returned += "<td>" + vrMOComponent.ProductMeasurementID + "</td>";
    Returned += "<td>" + vrMOComponent.ProductMeasurementCode + "</td>";
    Returned += "<td>" + vrMOComponent.ProductMeasurementNameA + "</td>";
    Returned += "<td>" + vrMOComponent.ProductMeasurementNameE + "</td>";
/*    Returned += "<td><input type=\"button\" value=\"+\" onclick=\"ReturnMOComponent(" + vrMOComponent.ID + ");\" /></td>";*/

    Returned += "</tr>";
    return Returned;
}
function ReturnMOComponent(vrID: number) {
    if (document.getElementById("lblMOComponent" + vrID.toString() + "") == null) {
        return;
    }
    var vrMOComponentStr: string = (<HTMLInputElement>document.getElementById("lblMOComponent" + vrID.toString())).value;
    var vrMOComponent: MOComponent = JSON.parse(vrMOComponentStr);
    if (document.getElementById("lblCurrentMOComponent") != null) {
        (<HTMLInputElement>document.getElementById("lblCurrentMOComponent")).value = vrMOComponentStr;
    }
    if (document.getElementById("lblMOComponentMO") != null) {
      /*  (<HTMLInputElement>document.getElementById("lblMOComponentMO")).innerText = vrMOComponent.MO;*/
    }
    if (document.getElementById("lblMOComponentProduct") != null) {
  /*      (<HTMLInputElement>document.getElementById("lblMOComponentProduct")).innerText = vrMOComponent.Product;*/
    }
    if (document.getElementById("lblMOComponentQuantity") != null) {
       /* (<HTMLInputElement>document.getElementById("lblMOComponentQuantity")).innerText = vrMOComponent.Quantity;*/
    }
    if (document.getElementById("lblMOComponentProductID") != null) {
      /*  (<HTMLInputElement>document.getElementById("lblMOComponentProductID")).innerText = vrMOComponent.ProductID;*/
    }
    if (document.getElementById("lblMOComponentProductCode") != null) {
        (<HTMLInputElement>document.getElementById("lblMOComponentProductCode")).innerText = vrMOComponent.ProductCode;
    }
    if (document.getElementById("lblMOComponentProductNameA") != null) {
        (<HTMLInputElement>document.getElementById("lblMOComponentProductNameA")).innerText = vrMOComponent.ProductNameA;
    }
    if (document.getElementById("lblMOComponentProductNameE") != null) {
        (<HTMLInputElement>document.getElementById("lblMOComponentProductNameE")).innerText = vrMOComponent.ProductNameE;
    }
    if (document.getElementById("lblMOComponentProductMeasurementID") != null) {
       /* (<HTMLInputElement>document.getElementById("lblMOComponentProductMeasurementID")).innerText = vrMOComponent.ProductMeasurementID;*/
    }
    if (document.getElementById("lblMOComponentProductMeasurementCode") != null) {
        (<HTMLInputElement>document.getElementById("lblMOComponentProductMeasurementCode")).innerText = vrMOComponent.ProductMeasurementCode;
    }
    if (document.getElementById("lblMOComponentProductMeasurementNameA") != null) {
        (<HTMLInputElement>document.getElementById("lblMOComponentProductMeasurementNameA")).innerText = vrMOComponent.ProductMeasurementNameA;
    }
    if (document.getElementById("lblMOComponentProductMeasurementNameE") != null) {
        (<HTMLInputElement>document.getElementById("lblMOComponentProductMeasurementNameE")).innerText = vrMOComponent.ProductMeasurementNameE;
    }

}
function GetMOComponentData(): MOComponent {
    if (document.getElementById("lblCurrentMOComponent") == null) {
        return;
    }
    var vrMOComponentStr: string = (<HTMLInputElement>document.getElementById("lblCurrentMOComponent")).value;
    var vrMOComponent: MOComponent = new MOComponent();
    if (vrMOComponentStr != "") {
        vrMOComponent = JSON.parse(vrMOComponentStr);
    }
    if (document.getElementById("txtMOComponentMO") != null) {
       /* vrMOComponent.MO = (<HTMLInputElement>document.getElementById("txtMOComponentMO")).innerText;*/
    }
    if (document.getElementById("txtMOComponentProduct") != null) {
        /*vrMOComponent.Product = (<HTMLInputElement>document.getElementById("txtMOComponentProduct")).innerText;*/
    }
    if (document.getElementById("txtMOComponentQuantity") != null) {
     /*   vrMOComponent.Quantity = (<HTMLInputElement>document.getElementById("txtMOComponentQuantity")).innerText;*/
    }
    if (document.getElementById("txtMOComponentProductID") != null) {
       /* vrMOComponent.ProductID = (<HTMLInputElement>document.getElementById("txtMOComponentProductID")).innerText;*/
    }
    if (document.getElementById("txtMOComponentProductCode") != null) {
        vrMOComponent.ProductCode = (<HTMLInputElement>document.getElementById("txtMOComponentProductCode")).innerText;
    }
    if (document.getElementById("txtMOComponentProductNameA") != null) {
        vrMOComponent.ProductNameA = (<HTMLInputElement>document.getElementById("txtMOComponentProductNameA")).innerText;
    }
    if (document.getElementById("txtMOComponentProductNameE") != null) {
        vrMOComponent.ProductNameE = (<HTMLInputElement>document.getElementById("txtMOComponentProductNameE")).innerText;
    }
    if (document.getElementById("txtMOComponentProductMeasurementID") != null) {
       /* vrMOComponent.ProductMeasurementID = (<HTMLInputElement>document.getElementById("txtMOComponentProductMeasurementID")).innerText;*/
    }
    if (document.getElementById("txtMOComponentProductMeasurementCode") != null) {
        vrMOComponent.ProductMeasurementCode = (<HTMLInputElement>document.getElementById("txtMOComponentProductMeasurementCode")).innerText;
    }
    if (document.getElementById("txtMOComponentProductMeasurementNameA") != null) {
        vrMOComponent.ProductMeasurementNameA = (<HTMLInputElement>document.getElementById("txtMOComponentProductMeasurementNameA")).innerText;
    }
    if (document.getElementById("txtMOComponentProductMeasurementNameE") != null) {
        vrMOComponent.ProductMeasurementNameE = (<HTMLInputElement>document.getElementById("txtMOComponentProductMeasurementNameE")).innerText;
    }

}
function SetMOComponentData(vrMOComponent: MOComponent) {
    if (document.getElementById("lblCurrentMOComponent ") == null) {
        return;
    }
    (<HTMLInputElement>document.getElementById("lblCurrentMOComponent ")).value = JSON.stringify(vrMOComponent);

    if (document.getElementById("txtMOComponentMO") != null) {
        (<HTMLInputElement>document.getElementById("txtMOComponentMO")).innerText = vrMOComponent.MO.toString();
    }
    if (document.getElementById("txtMOComponentProduct") != null) {
        (<HTMLInputElement>document.getElementById("txtMOComponentProduct")).innerText = vrMOComponent.Product.toString();
    }
    if (document.getElementById("txtMOComponentQuantity") != null) {
        (<HTMLInputElement>document.getElementById("txtMOComponentQuantity")).innerText = vrMOComponent.Quantity.toString();
    }
    if (document.getElementById("txtMOComponentProductID") != null) {
        (<HTMLInputElement>document.getElementById("txtMOComponentProductID")).innerText = vrMOComponent.ProductID.toString();
    }
    if (document.getElementById("txtMOComponentProductCode") != null) {
        (<HTMLInputElement>document.getElementById("txtMOComponentProductCode")).innerText = vrMOComponent.ProductCode;
    }
    if (document.getElementById("txtMOComponentProductNameA") != null) {
        (<HTMLInputElement>document.getElementById("txtMOComponentProductNameA")).innerText = vrMOComponent.ProductNameA;
    }
    if (document.getElementById("txtMOComponentProductNameE") != null) {
        (<HTMLInputElement>document.getElementById("txtMOComponentProductNameE")).innerText = vrMOComponent.ProductNameE;
    }
    if (document.getElementById("txtMOComponentProductMeasurementID") != null) {
        (<HTMLInputElement>document.getElementById("txtMOComponentProductMeasurementID")).innerText = vrMOComponent.ProductMeasurementID.toString();
    }
    if (document.getElementById("txtMOComponentProductMeasurementCode") != null) {
        (<HTMLInputElement>document.getElementById("txtMOComponentProductMeasurementCode")).innerText = vrMOComponent.ProductMeasurementCode;
    }
    if (document.getElementById("txtMOComponentProductMeasurementNameA") != null) {
        (<HTMLInputElement>document.getElementById("txtMOComponentProductMeasurementNameA")).innerText = vrMOComponent.ProductMeasurementNameA;
    }
    if (document.getElementById("txtMOComponentProductMeasurementNameE") != null) {
        (<HTMLInputElement>document.getElementById("txtMOComponentProductMeasurementNameE")).innerText = vrMOComponent.ProductMeasurementNameE;
    }

}
