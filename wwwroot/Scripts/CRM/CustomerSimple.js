var CustomerSimple = /** @class */ (function () {
    function CustomerSimple() {
    }
    CustomerSimple.prototype.GetRow = function (objBiz) {
        var Returned;
        Returned = "";
        Returned += "<tr>";
        var vrCustomerID;
        vrCustomerID = "lblCustomer" + objBiz.ID;
        Returned += "<input type=\"hidden\" id=\"" + vrCustomerID + "\" value='" + JSON.stringify(objBiz) + "'\>";
        Returned += "<td>" + objBiz.ID + "</td>";
        Returned += "<td>" + objBiz.Name + "</td>";
        Returned += "<td>" + objBiz.ProjectName + "</td>";
        Returned += "<td>" + objBiz.UnitCode + "</td>";
        Returned += "<td>" + objBiz.Mobile1 + "</td>";
        Returned += "<td><input type=\"button\" value=\"تثبيت\" id=\"btnReturnCustomer" + objBiz.ID + "\"  onclick=\"return onReturnCustomerClick('" + vrCustomerID + "')\" name=\"btnReturnCustomer" + objBiz.ID + "\" /></td>";
        Returned += "</tr>";
        return Returned;
    };
    CustomerSimple.prototype.FillSelectedTable = function () {
        var objBiz;
        var vrSelectedStr = document.getElementById("lblSelectedCustomer").getAttribute("value");
        var vrSelectedLst;
        vrSelectedLst = JSON.parse(vrSelectedStr);
        var Returned;
        Returned = "<table class=\"table\">";
        var vrCustomerID;
        var intIndex;
        for (intIndex = 0; intIndex < vrSelectedLst.length; intIndex++) {
            Returned += "<tr>";
            objBiz = vrSelectedLst[intIndex];
            vrCustomerID = "lblCustomer" + objBiz.ID;
            Returned += "<input type=\"hidden\" id=\"" + vrCustomerID + "\" value='" + JSON.stringify(objBiz) + "'\>";
            Returned += "<td>" + objBiz.ID + "</td>";
            Returned += "<td>" + objBiz.Name + "</td>";
            Returned += "<td>" + objBiz.UnitCode + "</td>";
            Returned += "<td>" + objBiz.Mobile1 + "</td>";
            Returned += "<td><input type=\"button\" value=\"-\" id=\"btnDeleteCustomer" + intIndex + "\"  onclick=\"return onDeleteCustomerClick(" + intIndex + ")\" name=\"btnDeleteCustomer" + intIndex + "\" /></td>";
            Returned += "</tr>";
        }
        Returned += "</table>";
        document.getElementById("dvSelectedCustomer").innerHTML = Returned;
        //return Returned;
    };
    CustomerSimple.prototype.AddCustomerToSelected = function (intID) {
        var vrSelectedLbl = document.getElementById("lblSelectedCustomer");
        var vrSelectedStr = vrSelectedLbl.getAttribute("value");
        var vrSelectedLst = [];
        if (vrSelectedStr != "") {
            vrSelectedLst = JSON.parse(vrSelectedStr);
        }
        var objBiz;
        var vrCustomerStr = document.getElementById("lblCustomer" + intID).getAttribute("value");
        objBiz = JSON.parse(vrCustomerStr);
        if (vrSelectedLst.filter(function (x) { return x.ID == objBiz.ID; }).length == 0) {
            vrSelectedLst[vrSelectedLst.length] = objBiz;
            vrSelectedLbl.setAttribute("value", JSON.stringify(vrSelectedLst));
            this.FillSelectedTable();
        }
    };
    CustomerSimple.prototype.DeleteCustomer = function (intIndex) {
        var objBiz;
        var vrSelectedLbl = document.getElementById("lblSelectedCustomer");
        var vrSelectedStr = vrSelectedLbl.getAttribute("value");
        var vrSelectedLst;
        var vrNewSelectedLst;
        vrNewSelectedLst = [];
        vrSelectedLst = JSON.parse(vrSelectedStr);
        if (vrSelectedLst.length > intIndex) {
            var vrIndex = void 0;
            for (vrIndex = 0; vrIndex < vrSelectedLst.length; vrIndex++) {
                if (intIndex != vrIndex) {
                    objBiz = vrSelectedLst[vrIndex];
                    vrNewSelectedLst[vrNewSelectedLst.length] = objBiz;
                }
                vrSelectedLbl.setAttribute("value", JSON.stringify(vrNewSelectedLst));
                this.FillSelectedTable();
            }
        }
    };
    return CustomerSimple;
}());
//# sourceMappingURL=CustomerSimple.js.map