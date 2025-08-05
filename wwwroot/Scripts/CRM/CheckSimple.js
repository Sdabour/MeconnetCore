var CheckSimple = /** @class */ (function () {
    function CheckSimple() {
    }
    CheckSimple.prototype.GetRow = function (objBiz) {
        var Returned;
        Returned = "";
        var vrCheckID;
        vrCheckID = "lblCheck" + objBiz.ID;
        var strBtn = "<td><input type=\"button\" value=\"تثبيت\" id=\"btnReturnCheck" + objBiz.ID + "\"  onclick=\"return onReturnCheckClick('" + vrCheckID + "')\" name=\"btnReturnCheck" + objBiz.ID + "\" /></td>";
        Returned += GetCheckInitialRow(objBiz, strBtn);
        return Returned;
    };
    CheckSimple.prototype.GetNewCheckRow = function (vrIndex) {
        var Returned;
        var objBiz = this;
        Returned = "";
        Returned += "<tr>";
        var vrCheckID;
        vrCheckID = "lblCheck" + vrIndex.toString();
        var vrTemp = "";
        vrTemp = objBiz.DueDate.toString();
        vrTemp = objBiz.DueDate.toString().substring(0, 10);
        /*    Returned += "<input type=\"hidden\" id=\"" + vrCheckID + "\" value='" + JSON.stringify(objBiz) + "'\>";*/
        Returned += "<td>" + objBiz.Code + "</td>";
        Returned += "<td>" + objBiz.EditorName + "</td>";
        Returned += "<td>" + objBiz.BeneficiaryName + "</td>";
        Returned += "<td><input type=\"number\" id=\"txtCheckValue" + vrIndex.toString() + "\" name=\"txtCheckValue" + vrIndex.toString() + "\"  value=\"" + objBiz.Value + "\"/></td>";
        Returned += "<td> <input type=\"date\" id=\"dtDueDate" + vrIndex.toString() + "\" value=\"" + objBiz.DueDate.toISOString().substring(0, 10) + "\" /></td>";
        Returned += "<td><input type=\"button\" id=\"btnEditCheck" + vrIndex.toString() + "\" name=\"btnEditCheck" + vrIndex.toString() + "\" onclick=\"EditCheck(" + vrIndex.toString() + ")\" value=\"E\"/></td>";
        Returned += "</tr>";
        return Returned;
    };
    CheckSimple.prototype.FillSelectedTable = function () {
        var objBiz;
        var vrSelectedStr = document.getElementById("lblSelectedCheck").getAttribute("value");
        var vrSelectedLst;
        vrSelectedLst = JSON.parse(vrSelectedStr);
        var Returned;
        Returned = "<table class=\"table\">";
        var vrCheckID;
        var intIndex;
        for (intIndex = 0; intIndex < vrSelectedLst.length; intIndex++) {
            Returned += "<tr>";
            objBiz = vrSelectedLst[intIndex];
            vrCheckID = "lblCheck" + objBiz.ID;
            Returned += "<input type=\"hidden\" id=\"" + vrCheckID + "\" value='" + JSON.stringify(objBiz) + "'\>";
            Returned += "<td>" + objBiz.ID + "</td>";
            Returned += "<td>" + objBiz.ID + "</td>";
            Returned += "<td>" + objBiz.Code + "</td>";
            Returned += "<td>" + objBiz.EditorName + "</td>";
            Returned += "<td>" + objBiz.Value + "</td>";
            Returned += "<td>" + objBiz.DueDate + "</td>";
            Returned += "<td><input type=\"button\" value=\"-\" id=\"btnDeleteCheck" + intIndex + "\"  onclick=\"return onDeleteCheckClick(" + intIndex + ")\" name=\"btnDeleteCheck" + intIndex + "\" /></td>";
            Returned += "</tr>";
        }
        Returned += "</table>";
        document.getElementById("dvSelectedCheck").innerHTML = Returned;
        return Returned;
    };
    CheckSimple.prototype.AddCheckToSelected = function (intID) {
        var vrSelectedLbl = document.getElementById("lblSelectedCheck");
        var vrSelectedStr = vrSelectedLbl.getAttribute("value");
        var vrSelectedLst;
        vrSelectedLst = JSON.parse(vrSelectedStr);
        var objBiz;
        var vrCheckStr = document.getElementById("lblCheck" + intID).getAttribute("value");
        objBiz = JSON.parse(vrCheckStr);
        if (vrSelectedLst.filter(function (x) { return x.ID == objBiz.ID; }).length == 0) {
            vrSelectedLst[vrSelectedLst.length] = objBiz;
            vrSelectedLbl.setAttribute("value", JSON.stringify(vrSelectedLst));
            this.FillSelectedTable();
        }
    };
    CheckSimple.prototype.DeleteCheck = function (intIndex) {
        var objBiz;
        var vrSelectedLbl = document.getElementById("lblSelectedCheck");
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
    CheckSimple.prototype.GetCheckCopy = function () {
        var Returned = new CheckSimple();
        Returned.Bank = this.Bank;
        Returned.BankName = this.BankName;
        Returned.BankSubmissionDate = this.BankSubmissionDate;
        Returned.BeneficiaryName = this.BeneficiaryName;
        Returned.Code = this.Code;
        Returned.Currency = this.Currency;
        Returned.CurrencyName = this.CurrencyName;
        Returned.CurrentStatus = this.CurrentStatus;
        Returned.CurrentStatusDesc = this.CurrentStatusDesc;
        Returned.Customer = this.Customer;
        Returned.CustomerName = this.CustomerName;
        Returned.Direction = this.Direction;
        Returned.DirectionDesc = this.DirectionDesc;
        Returned.DueDate = new Date(this.DueDate.toString());
        Returned.DueDateMonthNo = this.DueDateMonthNo;
        Returned.EditorName = this.EditorName;
        Returned.IsBankOriented = this.IsBankOriented;
        Returned.IsBankOrientedDesc = this.IsBankOrientedDesc;
        Returned.IssueDate = new Date(this.IssueDate.toString());
        Returned.Note = this.Note;
        Returned.Place = this.Place;
        Returned.PlaceName = this.PlaceName;
        Returned.Type = this.Type;
        Returned.TypeName = this.TypeName;
        Returned.Value = this.Value;
        return Returned;
    };
    CheckSimple.prototype.GetCheckLst = function () {
        var Returned;
        var vrCheck;
        Returned = [];
        var vrCheckNo = this.CodeFrom;
        var vrCurrentMonth;
        var vrDueDate = this.DueDate.getDate().toString();
        vrCurrentMonth = this.DueDate.getMonth();
        var vrIndex = 0;
        var vrDays = 0;
        var vrDate;
        vrDate = this.DueDate;
        while (vrCheckNo <= this.CodeTo) {
            var vrCheck_1 = this.GetCheckCopy();
            vrCheck_1.Code = vrCheckNo.toString();
            /*vrCheck.DueDate.setDate((vrIndex * this.DueDateDaysNo));*/
            /*vrDate = new Date(vrDate.getFullYear(),  vrDate.setMonth(vrDate.getMonth() + vrMonthes));*/
            vrCurrentMonth = this.DueDate.getMonth();
            vrCurrentMonth += this.DueDateMonthNo;
            vrDate.setMonth(vrCurrentMonth);
            vrCheck_1.DueDate = new Date(vrDate.toString());
            Returned[vrIndex] = vrCheck_1;
            vrIndex++;
            vrCheckNo++;
        }
        return Returned;
    };
    return CheckSimple;
}());
function CheckCheckValidation() {
    if (document.getElementById("EditorName").value == "") {
        alert("فضلا حدد اسم المحرر");
        return false;
    }
    if (document.getElementById("BeneficiaryName").value == "") {
        alert("فضلا حدد اسم المستفيد");
        return false;
    }
    if (document.getElementById("Code").value == null || document.getElementById("Code").value == "") {
        alert("فضلا حدد رقم الشيك");
        return false;
    }
    if (document.getElementById("Value").value == null || document.getElementById("Value").value == "" || document.getElementById("Value").value == "0") {
        alert("فضلا حدد قيمة الشيك");
        return false;
    }
    return true;
}
function CheckCheckMultipleValidation() {
    if (document.getElementById("lblCheck").value == "") {
        alert("فضلا حدد مجموعة الشيكات");
        return false;
    }
    var vrCheckLst = [];
    try {
        vrCheckLst = JSON.parse(document.getElementById("lblCheck").value);
    }
    catch (_a) { }
    if (vrCheckLst.length == 0) {
        alert("فضلا حدد مجموعة الشيكات");
        return false;
    }
    return true;
}
function GetPaymentCheckRow(intIndex, objBiz) {
    var Returned;
    Returned = "";
    var vrBtn = "<td><input type=\"button\" value=\"+\" id=\"btnReturnWithCheck" + intIndex + "\"  onclick=\"return SetInstallmentPaymentCheckLabel(" + intIndex + ")\" name=\"btnReturnWithCheck" + intIndex + "\" /></td>";
    var vrAllCheck = [];
    var vrCheckStr = document.getElementById("lblAllCheck").value;
    if (vrCheckStr != null && vrCheckStr != "") {
        vrAllCheck = JSON.parse(vrCheckStr);
        if (vrAllCheck.length > intIndex) {
            {
                var vrCheckSimple = vrAllCheck[intIndex];
                Returned += GetCheckInitialRow(vrCheckSimple, vrBtn);
            }
        }
    }
    return Returned;
}
function ReturnCheck(intIndex, strAllCheckLbl, strCheckLbl) {
    var vrCheckLstStr = document.getElementById(strAllCheckLbl).value;
    var vrChekLst = JSON.parse(vrCheckLstStr);
    if (vrChekLst.length <= intIndex)
        return;
    var vrBiz = vrChekLst[intIndex];
    document.getElementById(strCheckLbl).innerText = vrBiz.Code;
}
function FillPaymentCheckTable() {
    var vrCheckLstStr = document.getElementById("lblAllCheck").value;
    var vrChekLst = JSON.parse(vrCheckLstStr);
    var Returned = "<table class=\"table\">";
    for (var vrIndex = 0; vrIndex < vrChekLst.length; vrIndex++) {
        Returned += GetPaymentCheckRow(vrIndex, vrChekLst[vrIndex]);
    }
    Returned += "</table>";
    document.getElementById("dvCheck").innerHTML = Returned;
    return Returned;
}
function GetCheckSimpleMultiple() {
    var Returned = new CheckSimple();
    Returned.Bank = Number(document.getElementById("Bank").value);
    Returned.BankName = document.getElementById("Bank").value;
    Returned.BeneficiaryName = document.getElementById("BeneficiaryName").value;
    Returned.CodeFrom = Number(document.getElementById("CodeFrom").value);
    Returned.CodeTo = Number(document.getElementById("CodeTo").value);
    Returned.Currency = Number(document.getElementById("Currency").value);
    var vrControl = document.getElementById("Currency");
    var vrTemp = "";
    vrTemp = document.getElementById("Currency").value;
    Returned.CurrencyName = document.getElementById("Currency").innerText;
    Returned.CurrentStatus = Number(document.getElementById("lblStatus").value); //
    var vrCustomerStr = document.getElementById("lblCustomerValue").value;
    var vrCustomer = JSON.parse(vrCustomerStr);
    Returned.Customer = vrCustomer.ID;
    Returned.CustomerName = vrCustomer.Name;
    vrTemp = document.getElementById("lblDirection").value;
    Returned.Direction = document.getElementById("lblDirection").value == "true";
    Returned.Direction = true;
    Returned.EditorName = document.getElementById("EditorName").value;
    Returned.IsBankOriented = document.getElementById("IsBankOriented").checked;
    Returned.IssueDate = new Date(document.getElementById("IssueDate").value);
    Returned.DueDate = new Date(document.getElementById("DueDate").value);
    Returned.Note = document.getElementById("Note").value;
    Returned.Place = Number(document.getElementById("Coffer").value);
    Returned.Type = Number(document.getElementById("Type").value);
    Returned.Value = Number(document.getElementById("Value").value);
    Returned.DueDateMonthNo = Number(document.getElementById("DueDateMonthNo").value);
    return Returned;
}
function FillNewMultipleCheck() {
    var vrCheckSimple = GetCheckSimpleMultiple();
    var arrCheck = vrCheckSimple.GetCheckLst();
    FillMultipleCheckLst(arrCheck);
}
function FillMultipleCheckLst(arrCheck) {
    var vrCheckLstStr = "";
    for (var vrIndex = 0; vrIndex < arrCheck.length; vrIndex++) {
        vrCheckLstStr += arrCheck[vrIndex].GetNewCheckRow(vrIndex);
    }
    document.getElementById("tblCheck").innerHTML = vrCheckLstStr;
    document.getElementById("lblCheck").value = JSON.stringify(arrCheck);
}
function EditCheck(vrIndex) {
    var vrCheck = new CheckSimple();
    var vrCheckStr = document.getElementById("lblCheck").value;
    var vrCheckLst = JSON.parse(vrCheckStr);
    if (vrCheckLst.length > 0) {
        vrCheck = vrCheckLst[vrIndex];
        vrCheck.DueDate = new Date(document.getElementById("dtDueDate" + vrIndex.toString()).value);
        vrCheck.Value = Number(document.getElementById("txtCheckValue" + vrIndex.toString()).value);
        vrCheckLst[vrIndex] = vrCheck;
    }
    document.getElementById("lblCheck").value = JSON.stringify(vrCheckLst);
    //FillMultipleCheckLst(vrCheckLst);
}
function GetCheckInitialRow(vrCheck, strBtns) {
    var Returned;
    Returned = "";
    Returned += "<tr>";
    var vrCheckID;
    vrCheckID = "lblCheck" + vrCheck.ID;
    Returned += "<input type=\"hidden\" id=\"" + vrCheckID + "\" value='" + JSON.stringify(vrCheck) + "'\>";
    Returned += "<td>" + vrCheck.ID + "</td>";
    Returned += "<td>" + vrCheck.Code + "</td>";
    Returned += "<td>" + vrCheck.EditorName + "</td>";
    Returned += "<td>" + vrCheck.BeneficiaryName + "</td>";
    Returned += "<td>" + vrCheck.Value + "</td>";
    Returned += "<td>" + vrCheck.DueDate.toString().substring(0, 10) + "</td>";
    Returned += strBtns;
    Returned += "</tr>";
    return Returned;
}
//# sourceMappingURL=CheckSimple.js.map