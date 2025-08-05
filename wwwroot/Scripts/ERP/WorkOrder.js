var WorkOrder = /** @class */ (function () {
    function WorkOrder() {
    }
    return WorkOrder;
}());
function GetWorkOrderRow(vrWorkOrder) {
    var Returned = "<tr>";
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
function ReturnWorkOrder(vrID) {
    if (document.getElementById("lblWorkOrder" + vrID.toString() + "") == null) {
        return;
    }
    var vrWorkOrderStr = document.getElementById("lblWorkOrder" + vrID.toString()).value;
    var vrWorkOrder = JSON.parse(vrWorkOrderStr);
    if (document.getElementById("lblCurrentWorkOrder") != null) {
        document.getElementById("lblCurrentWorkOrder").value = vrWorkOrderStr;
    }
    if (document.getElementById("lblWorkOrderID") != null) {
        document.getElementById("lblWorkOrderID").innerText = vrWorkOrder.ID.toString();
    }
    if (document.getElementById("lblWorkOrderMO") != null) {
        document.getElementById("lblWorkOrderMO").innerText = vrWorkOrder.MO.toString();
    }
    if (document.getElementById("lblWorkOrderRef") != null) {
        document.getElementById("lblWorkOrderRef").innerText = vrWorkOrder.Ref;
    }
    if (document.getElementById("lblWorkOrderDesc") != null) {
        document.getElementById("lblWorkOrderDesc").innerText = vrWorkOrder.Desc;
    }
    if (document.getElementById("lblWorkOrderType") != null) {
        document.getElementById("lblWorkOrderType").innerText = vrWorkOrder.Type.toString();
    }
    if (document.getElementById("lblWorkOrderProduct") != null) {
        document.getElementById("lblWorkOrderProduct").innerText = vrWorkOrder.Product.toString();
    }
    if (document.getElementById("lblWorkOrderDate") != null) {
        document.getElementById("lblWorkOrderDate").innerText = vrWorkOrder.Date.toISOString().substring(0, 10);
    }
    if (document.getElementById("lblWorkOrderTime") != null) {
        document.getElementById("lblWorkOrderTime").innerText = vrWorkOrder.Time.toISOString().substring(0, 10);
    }
    if (document.getElementById("lblWorkOrderQuantity") != null) {
        document.getElementById("lblWorkOrderQuantity").innerText = vrWorkOrder.Quantity.toString();
    }
    if (document.getElementById("lblWorkOrderPeriority") != null) {
        document.getElementById("lblWorkOrderPeriority").innerText = vrWorkOrder.Periority.toString();
    }
    if (document.getElementById("lblWorkOrderProductCode") != null) {
        document.getElementById("lblWorkOrderProductCode").innerText = vrWorkOrder.ProductCode;
    }
    if (document.getElementById("lblWorkOrderProductNameA") != null) {
        document.getElementById("lblWorkOrderProductNameA").innerText = vrWorkOrder.ProductNameA;
    }
    if (document.getElementById("lblWorkOrderProductNameE") != null) {
        document.getElementById("lblWorkOrderProductNameE").innerText = vrWorkOrder.ProductNameE;
    }
    if (document.getElementById("lblWorkOrderProductMeasurementUnit") != null) {
        document.getElementById("lblWorkOrderProductMeasurementUnit").innerText = vrWorkOrder.ProductMeasurementUnit.toString();
    }
    if (document.getElementById("lblWorkOrderProductMeasurementCode") != null) {
        document.getElementById("lblWorkOrderProductMeasurementCode").innerText = vrWorkOrder.ProductMeasurementCode;
    }
    if (document.getElementById("lblWorkOrderProductMeasurementNameA") != null) {
        document.getElementById("lblWorkOrderProductMeasurementNameA").innerText = vrWorkOrder.ProductMeasurementNameA;
    }
    if (document.getElementById("lblWorkOrderProductMeasurementNameE") != null) {
        document.getElementById("lblWorkOrderProductMeasurementNameE").innerText = vrWorkOrder.ProductMeasurementNameE;
    }
}
function GetWorkOrderData() {
    if (document.getElementById("lblCurrentWorkOrder") == null) {
        return;
    }
    var vrWorkOrderStr = document.getElementById("lblCurrentWorkOrder").value;
    var vrWorkOrder = new WorkOrder();
    if (vrWorkOrderStr != "") {
        vrWorkOrder = JSON.parse(vrWorkOrderStr);
    }
    if (document.getElementById("txtWorkOrderID") != null) {
        vrWorkOrder.ID = Number(document.getElementById("txtWorkOrderID").innerText);
    }
    if (document.getElementById("txtWorkOrderMO") != null) {
        /* vrWorkOrder.MO = (<HTMLInputElement>document.getElementById("txtWorkOrderMO")).innerText;*/
    }
    if (document.getElementById("txtWorkOrderRef") != null) {
        vrWorkOrder.Ref = document.getElementById("txtWorkOrderRef").innerText;
    }
    if (document.getElementById("txtWorkOrderDesc") != null) {
        vrWorkOrder.Desc = document.getElementById("txtWorkOrderDesc").innerText;
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
        vrWorkOrder.ProductCode = document.getElementById("txtWorkOrderProductCode").innerText;
    }
    if (document.getElementById("txtWorkOrderProductNameA") != null) {
        vrWorkOrder.ProductNameA = document.getElementById("txtWorkOrderProductNameA").innerText;
    }
    if (document.getElementById("txtWorkOrderProductNameE") != null) {
        vrWorkOrder.ProductNameE = document.getElementById("txtWorkOrderProductNameE").innerText;
    }
    if (document.getElementById("txtWorkOrderProductMeasurementUnit") != null) {
        /*   vrWorkOrder.ProductMeasurementUnit = (<HTMLInputElement>document.getElementById("txtWorkOrderProductMeasurementUnit")).innerText;*/
    }
    if (document.getElementById("txtWorkOrderProductMeasurementCode") != null) {
        vrWorkOrder.ProductMeasurementCode = document.getElementById("txtWorkOrderProductMeasurementCode").innerText;
    }
    if (document.getElementById("txtWorkOrderProductMeasurementNameA") != null) {
        vrWorkOrder.ProductMeasurementNameA = document.getElementById("txtWorkOrderProductMeasurementNameA").innerText;
    }
    if (document.getElementById("txtWorkOrderProductMeasurementNameE") != null) {
        vrWorkOrder.ProductMeasurementNameE = document.getElementById("txtWorkOrderProductMeasurementNameE").innerText;
    }
}
function SetWorkOrderData(vrWorkOrder) {
    if (document.getElementById("lblCurrentWorkOrder ") == null) {
        return;
    }
    document.getElementById("lblCurrentWorkOrder ").value = JSON.stringify(vrWorkOrder);
    if (document.getElementById("txtWorkOrderID") != null) {
        document.getElementById("txtWorkOrderID").innerText = vrWorkOrder.ID.toString();
    }
    if (document.getElementById("txtWorkOrderMO") != null) {
        document.getElementById("txtWorkOrderMO").innerText = vrWorkOrder.MO.toString();
    }
    if (document.getElementById("txtWorkOrderRef") != null) {
        document.getElementById("txtWorkOrderRef").innerText = vrWorkOrder.Ref;
    }
    if (document.getElementById("txtWorkOrderDesc") != null) {
        document.getElementById("txtWorkOrderDesc").innerText = vrWorkOrder.Desc;
    }
    if (document.getElementById("txtWorkOrderType") != null) {
        document.getElementById("txtWorkOrderType").innerText = vrWorkOrder.Type.toString();
    }
    if (document.getElementById("txtWorkOrderProduct") != null) {
        document.getElementById("txtWorkOrderProduct").innerText = vrWorkOrder.Product.toString();
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
        document.getElementById("txtWorkOrderProductCode").innerText = vrWorkOrder.ProductCode;
    }
    if (document.getElementById("txtWorkOrderProductNameA") != null) {
        document.getElementById("txtWorkOrderProductNameA").innerText = vrWorkOrder.ProductNameA;
    }
    if (document.getElementById("txtWorkOrderProductNameE") != null) {
        document.getElementById("txtWorkOrderProductNameE").innerText = vrWorkOrder.ProductNameE;
    }
    if (document.getElementById("txtWorkOrderProductMeasurementUnit") != null) {
        /* (<HTMLInputElement>document.getElementById("txtWorkOrderProductMeasurementUnit")).innerText = vrWorkOrder.ProductMeasurementUnit;*/
    }
    if (document.getElementById("txtWorkOrderProductMeasurementCode") != null) {
        document.getElementById("txtWorkOrderProductMeasurementCode").innerText = vrWorkOrder.ProductMeasurementCode;
    }
    if (document.getElementById("txtWorkOrderProductMeasurementNameA") != null) {
        document.getElementById("txtWorkOrderProductMeasurementNameA").innerText = vrWorkOrder.ProductMeasurementNameA;
    }
    if (document.getElementById("txtWorkOrderProductMeasurementNameE") != null) {
        document.getElementById("txtWorkOrderProductMeasurementNameE").innerText = vrWorkOrder.ProductMeasurementNameE;
    }
}
//# sourceMappingURL=WorkOrder.js.map