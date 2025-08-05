var MOComponent = /** @class */ (function () {
    function MOComponent() {
    }
    return MOComponent;
}());
function GetMOComponentRow(vrMOComponent) {
    var Returned = "<tr>";
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
function ReturnMOComponent(vrID) {
    if (document.getElementById("lblMOComponent" + vrID.toString() + "") == null) {
        return;
    }
    var vrMOComponentStr = document.getElementById("lblMOComponent" + vrID.toString()).value;
    var vrMOComponent = JSON.parse(vrMOComponentStr);
    if (document.getElementById("lblCurrentMOComponent") != null) {
        document.getElementById("lblCurrentMOComponent").value = vrMOComponentStr;
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
        document.getElementById("lblMOComponentProductCode").innerText = vrMOComponent.ProductCode;
    }
    if (document.getElementById("lblMOComponentProductNameA") != null) {
        document.getElementById("lblMOComponentProductNameA").innerText = vrMOComponent.ProductNameA;
    }
    if (document.getElementById("lblMOComponentProductNameE") != null) {
        document.getElementById("lblMOComponentProductNameE").innerText = vrMOComponent.ProductNameE;
    }
    if (document.getElementById("lblMOComponentProductMeasurementID") != null) {
        /* (<HTMLInputElement>document.getElementById("lblMOComponentProductMeasurementID")).innerText = vrMOComponent.ProductMeasurementID;*/
    }
    if (document.getElementById("lblMOComponentProductMeasurementCode") != null) {
        document.getElementById("lblMOComponentProductMeasurementCode").innerText = vrMOComponent.ProductMeasurementCode;
    }
    if (document.getElementById("lblMOComponentProductMeasurementNameA") != null) {
        document.getElementById("lblMOComponentProductMeasurementNameA").innerText = vrMOComponent.ProductMeasurementNameA;
    }
    if (document.getElementById("lblMOComponentProductMeasurementNameE") != null) {
        document.getElementById("lblMOComponentProductMeasurementNameE").innerText = vrMOComponent.ProductMeasurementNameE;
    }
}
function GetMOComponentData() {
    if (document.getElementById("lblCurrentMOComponent") == null) {
        return;
    }
    var vrMOComponentStr = document.getElementById("lblCurrentMOComponent").value;
    var vrMOComponent = new MOComponent();
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
        vrMOComponent.ProductCode = document.getElementById("txtMOComponentProductCode").innerText;
    }
    if (document.getElementById("txtMOComponentProductNameA") != null) {
        vrMOComponent.ProductNameA = document.getElementById("txtMOComponentProductNameA").innerText;
    }
    if (document.getElementById("txtMOComponentProductNameE") != null) {
        vrMOComponent.ProductNameE = document.getElementById("txtMOComponentProductNameE").innerText;
    }
    if (document.getElementById("txtMOComponentProductMeasurementID") != null) {
        /* vrMOComponent.ProductMeasurementID = (<HTMLInputElement>document.getElementById("txtMOComponentProductMeasurementID")).innerText;*/
    }
    if (document.getElementById("txtMOComponentProductMeasurementCode") != null) {
        vrMOComponent.ProductMeasurementCode = document.getElementById("txtMOComponentProductMeasurementCode").innerText;
    }
    if (document.getElementById("txtMOComponentProductMeasurementNameA") != null) {
        vrMOComponent.ProductMeasurementNameA = document.getElementById("txtMOComponentProductMeasurementNameA").innerText;
    }
    if (document.getElementById("txtMOComponentProductMeasurementNameE") != null) {
        vrMOComponent.ProductMeasurementNameE = document.getElementById("txtMOComponentProductMeasurementNameE").innerText;
    }
}
function SetMOComponentData(vrMOComponent) {
    if (document.getElementById("lblCurrentMOComponent ") == null) {
        return;
    }
    document.getElementById("lblCurrentMOComponent ").value = JSON.stringify(vrMOComponent);
    if (document.getElementById("txtMOComponentMO") != null) {
        document.getElementById("txtMOComponentMO").innerText = vrMOComponent.MO.toString();
    }
    if (document.getElementById("txtMOComponentProduct") != null) {
        document.getElementById("txtMOComponentProduct").innerText = vrMOComponent.Product.toString();
    }
    if (document.getElementById("txtMOComponentQuantity") != null) {
        document.getElementById("txtMOComponentQuantity").innerText = vrMOComponent.Quantity.toString();
    }
    if (document.getElementById("txtMOComponentProductID") != null) {
        document.getElementById("txtMOComponentProductID").innerText = vrMOComponent.ProductID.toString();
    }
    if (document.getElementById("txtMOComponentProductCode") != null) {
        document.getElementById("txtMOComponentProductCode").innerText = vrMOComponent.ProductCode;
    }
    if (document.getElementById("txtMOComponentProductNameA") != null) {
        document.getElementById("txtMOComponentProductNameA").innerText = vrMOComponent.ProductNameA;
    }
    if (document.getElementById("txtMOComponentProductNameE") != null) {
        document.getElementById("txtMOComponentProductNameE").innerText = vrMOComponent.ProductNameE;
    }
    if (document.getElementById("txtMOComponentProductMeasurementID") != null) {
        document.getElementById("txtMOComponentProductMeasurementID").innerText = vrMOComponent.ProductMeasurementID.toString();
    }
    if (document.getElementById("txtMOComponentProductMeasurementCode") != null) {
        document.getElementById("txtMOComponentProductMeasurementCode").innerText = vrMOComponent.ProductMeasurementCode;
    }
    if (document.getElementById("txtMOComponentProductMeasurementNameA") != null) {
        document.getElementById("txtMOComponentProductMeasurementNameA").innerText = vrMOComponent.ProductMeasurementNameA;
    }
    if (document.getElementById("txtMOComponentProductMeasurementNameE") != null) {
        document.getElementById("txtMOComponentProductMeasurementNameE").innerText = vrMOComponent.ProductMeasurementNameE;
    }
}
//# sourceMappingURL=MOComponent.js.map